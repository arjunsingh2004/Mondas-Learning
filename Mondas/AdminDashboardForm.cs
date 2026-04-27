using Microsoft.Data.Sqlite;
using Mondas.Models;
using Mondas.Services;
using Newtonsoft.Json;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Mondas
{
    public partial class AdminDashboardForm : SfForm
    {
        private readonly string _dbPath;
        private readonly string _questionsPath;
        private readonly string _phishingPath;
        private readonly string _authPath;

        private readonly DashboardStatsService _statsService;
        private readonly SqliteUserRepository _users;
        private readonly JsonSerializerOptions _json = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, Converters = { new JsonStringEnumConverter() } };

        private readonly Dictionary<string, string> _userNameByKey = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private List<Question> _questions = new List<Question>();
        private List<PhishingEmail> _phishingEmails = new List<PhishingEmail>();
        private List<AuthenticationDefenseScenario> _authScenarios = new List<AuthenticationDefenseScenario>();

        private List<UserSummaryRow> _userRows = new List<UserSummaryRow>();
        private List<ActivityRow> _activityRows = new List<ActivityRow>();
        private List<MisHitRow> _misHits = new List<MisHitRow>();
        private List<BankRow> _bankRows = new List<BankRow>();

        private BankRow _selectedBankRow;
        private string _adminName = "ADMIN";
        private bool _editorLoading;

        public AdminDashboardForm() : this("ADMIN")
        {

        }

        public AdminDashboardForm(string adminName)
        {
            InitializeComponent();

            _adminName = string.IsNullOrWhiteSpace(adminName) ? "ADMIN" : adminName.Trim().ToUpperInvariant();

            lblAdminUser.Text = _adminName;
            lblFooterUser.Text = $"ROLE: ADMIN | {_adminName}";

            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _questionsPath = FixPath("questions.json");
            _phishingPath = FixPath("phishing_emails.json");
            _authPath = FixPath("auth_defense_scenarios.json");

            _statsService = new DashboardStatsService(_dbPath);
            _users = new SqliteUserRepository(_dbPath);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            SetCombos();
            SetGrids();
            RefreshAll();
            UpdateInvisibleFields();
        }

        private void SetCombos()
        {
            cmbRange.Items.Clear();
            cmbRange.Items.AddRange(new object[] { "All Time", "Today", "Last 7 Days", "Last 30 Days" });
            cmbRange.SelectedIndex = 0;

            cmbContentType.Items.Clear();
            cmbContentType.Items.AddRange(new object[] { "All", "Quiz", "Phishing", "Auth" });
            cmbContentType.SelectedIndex = 0;

            cmbBankTopic.Items.Clear();
            cmbBankTopic.Items.Add("All");

            foreach (Topic topic in Enum.GetValues(typeof(Topic)))
            {
                if (topic == Topic.Other)
                {
                    continue;
                }

                cmbBankTopic.Items.Add(DisplayEnum(topic));
            }

            cmbBankTopic.SelectedIndex = 0;

            cmbBankDifficulty.Items.Clear();
            cmbBankDifficulty.Items.Add("All");

            foreach (DifficultyBand difficulty in Enum.GetValues(typeof(DifficultyBand)))
            {
                cmbBankDifficulty.Items.Add(DisplayEnum(difficulty));
            }

            cmbBankDifficulty.SelectedIndex = 0;

            SetEnumCombo(cmbQuizTopic, typeof(Topic), Topic.Other);
            SetEnumCombo(cmbQuizDifficulty, typeof(DifficultyBand), null);
            SetEnumCombo(cmbQuizType, typeof(QuestionType), null);
            SetEnumCombo(cmbPhishDifficulty, typeof(DifficultyBand), null);
            SetEnumCombo(cmbThreatType, typeof(AuthThreatType), null);
            SetEnumCombo(cmbGoalType, typeof(AuthGoalType), null);
            SetEnumCombo(cmbAuthDifficulty, typeof(DifficultyBand), null);
            SetEnumCombo(cmbRecAuthMethod, typeof(AuthMethodType), null);
            SetEnumCombo(cmbRecRecovery, typeof(RecoveryType), null);
            SetEnumCombo(cmbRecSession, typeof(SessionControlType), null);
        }

        private void SetGrids()
        {
            if (dgvUsers != null)
            {
                dgvUsers.Rows.Clear();
            }

            if (dgvMisconceptions != null)
            {
                dgvMisconceptions.Rows.Clear();
            }

            if (dgvRecentActivity != null)
            {
                dgvRecentActivity.Rows.Clear();
            }

            if (dgvBankItems != null)
            {
                dgvBankItems.Rows.Clear();
            }

            if (dgvQuizOptions != null)
            {
                dgvQuizOptions.Rows.Clear();
            }
        }

        private void RefreshAll()
        {
            LoadJsonContent();
            LoadUsers();
            LoadActivity();
            LoadMisconceptions();
            BuildBankRows();
            ApplyOverview();
            ApplyUserGrid();
            ApplyMisconceptionsGrid();
            ApplyRecentActivityGrid();
            ApplyBankGrid();
        }

        private void LoadJsonContent()
        {
            _questions = new JsonQuestionRepository(_questionsPath).GetAllQuestions().ToList();
            _phishingEmails = new PhishingEmailRepository(_phishingPath).LoadAll().ToList();
            _authScenarios = new AuthenticationDefenseScenarioRepository(_authPath).LoadAll().ToList();
        }

        private void LoadUsers()
        {
            _userRows.Clear();
            _userNameByKey.Clear();

            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, FullName, Email FROM Users WHERE IsAdmin = 0 ORDER BY FullName;";

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var userId = r.GetInt64(0);
                var fullName = r.IsDBNull(1) ? "USER" : (r.GetString(1) ?? "USER").Trim();
                var email = r.IsDBNull(2) ? "" : (r.GetString(2) ?? "").Trim();
                var userKey = "u:" + userId.ToString(CultureInfo.InvariantCulture);

                _userNameByKey[userKey] = fullName;

                DashboardStats stats;

                try
                {
                    stats = _statsService.Load(userId, userKey, StatsSource.All);
                }

                catch
                {
                    stats = new DashboardStats { UserId = userId, UserKey = userKey, FullName = fullName };
                }

                _userRows.Add(new UserSummaryRow { UserId = userId, UserKey = userKey, FullName = fullName, Email = email, Attempts = stats.TotalAttempts, Accuracy01 = stats.Accuracy01, AvgSeconds = stats.AvgSeconds, WeakestTopic = stats.WeakestTopic.HasValue ? ShowTopic(stats.WeakestTopic.Value) : "-", LastActiveUtc = GetLastActiveUtc(userKey) });
            }
        }

        private void LoadActivity()
        {
            _activityRows.Clear();

            using var conn = Open();

            AddQuizActivity(conn);
            AddPhishingActivity(conn);
            AddAuthActivity(conn);

            _activityRows = _activityRows.OrderByDescending(x => x.WhenUtc).Take(500).ToList();
        }

        private void AddQuizActivity(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT UserKey, IsCorrect, SubmittedAt FROM Attempts ORDER BY SubmittedAt DESC LIMIT 300;";
        
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var userKey = SafeString(r, 0);
                _activityRows.Add(new ActivityRow { UserKey = userKey, UserName = FixUserName(userKey), Mode = "QUIZ", Result = r.GetInt32(1) == 1 ? "CORRECT" : "INCORRECT", WhenUtc = ParseUtc(SafeString(r, 2)) });
            }
        }

        private void AddPhishingActivity(SqliteConnection conn)
        {
            if (!TableExists(conn, "PhishingAttempts"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT UserKey, Action, IsCorrect, SubmittedAt FROM PhishingAttempts WHERE Action IN ($a1, $a2) ORDER BY SubmittedAt DESC LIMIT 300;";
            cmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
            cmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var userKey = SafeString(r, 0);
                var action = r.GetInt32(1);
                var ok = r.GetInt32(2) == 1;

                _activityRows.Add(new ActivityRow { UserKey = userKey, UserName = FixUserName(userKey), Mode = "PHISHING", Result = BuildPhishingResult(action, ok), WhenUtc = ParseUtc(SafeString(r, 3)) });
            }
        }

        private void AddAuthActivity(SqliteConnection conn)
        {
            if (!TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT UserKey, IsCorrect, Accuracy01, SubmittedAt FROM AuthenticationDefenseAttempts ORDER BY SubmittedAt DESC LIMIT 300;";

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var userKey = SafeString(r, 0);
                var isCorrect = r.GetInt32(1) == 1;
                double? acc = r.IsDBNull(2) ? (double?)null : r.GetDouble(2);

                _activityRows.Add(new ActivityRow{ UserKey = userKey, UserName = FixUserName(userKey), Mode = "AUTH DEFENSE", Result = BuildAuthResult(isCorrect, acc), WhenUtc = ParseUtc(SafeString(r, 3)) });
            }
        }

        private void LoadMisconceptions()
        {
            _misHits.Clear();

            using var conn = Open();

            AddQuizMisconceptionHits(conn);
            AddPhishingMisconceptionHits(conn);
            AddAuthMisconceptionHits(conn);
        }

        private void AddQuizMisconceptionHits(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT mt.Tag, a.SubmittedAt FROM Attempts a JOIN QuestionMisconceptionTags qmt ON qmt.QuestionId = a.QuestionId JOIN MisconceptionTags mt ON mt.Id = qmt.TagId WHERE a.IsCorrect = 0;";

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                _misHits.Add(new MisHitRow { Type = "QUIZ", Tag = SafeString(r, 0), WhenUtc = ParseUtc(SafeString(r, 1)) });
            }
        }

        private void AddPhishingMisconceptionHits(SqliteConnection conn)
        {
            if (!TableExists(conn, "PhishingAttempts"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @" SELECT EmailSnapshotJson, SubmittedAt FROM PhishingAttempts WHERE Action IN ($a1, $a2) AND IsCorrect = 0;";
            cmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
            cmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var email = ReadPhishingSnapshot(SafeString(r, 0));
                var whenUtc = ParseUtc(SafeString(r, 1));

                if (email == null)
                {
                    continue;
                }

                var tags = email.Tags != null && email.Tags.Count > 0 ? email.Tags : new List<string> { "phishing-general" };

                foreach (var tag in tags)
                {
                    if (string.IsNullOrWhiteSpace(tag))
                    {
                        continue;
                    }

                    _misHits.Add(new MisHitRow { Type = "PHISHING", Tag = tag.Trim(), WhenUtc = whenUtc });
                }
            }
        }

        private void AddAuthMisconceptionHits(SqliteConnection conn)
        {
            if (!TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @" SELECT TagsJson, SubmittedAt FROM AuthenticationDefenseAttempts WHERE IsCorrect = 0;";

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var tags = ReadStringList(SafeString(r, 0));
                var whenUtc = ParseUtc(SafeString(r, 1));

                foreach (var tag in tags)
                {
                    if (string.IsNullOrWhiteSpace(tag))
                    {
                        continue;
                    }

                    _misHits.Add(new MisHitRow{ Type = "AUTH SCENARIO", Tag = tag.Trim(), WhenUtc = whenUtc });
                }
            }
        }

        private void BuildBankRows()
        {
            _bankRows.Clear();

            foreach (var q in _questions)
            {
                _bankRows.Add(new BankRow { Kind = BankKind.Quiz, Key = q.Id.ToString(CultureInfo.InvariantCulture), Title = q.Text ?? "", Topic = ShowTopic(q.Metadata.Topic), Difficulty = DisplayEnum(q.Metadata.Difficulty), SearchText = $"{q.Id} {q.Text} {q.Explanation} {q.Metadata.Topic} {q.Metadata.Difficulty} {q.Metadata.QuestionType}" });
            }

            foreach (var p in _phishingEmails)
            {
                _bankRows.Add(new BankRow{ Kind = BankKind.Phishing, Key = p.Id.ToString(CultureInfo.InvariantCulture), Title = p.Subject ?? "", Topic = "Phishing", Difficulty = DisplayEnum(p.Difficulty), SearchText = $"{p.Id} {p.Subject} {p.SenderName} {p.SenderEmail} {p.Body} {p.Explanation}" });
            }

            foreach (var a in _authScenarios)
            {
                _bankRows.Add(new BankRow { Kind = BankKind.Auth, Key = a.Id ?? "", Title = a.Title ?? "", Topic = ShowTopic(MapAuthTopic(a)), Difficulty = DisplayEnum(a.Difficulty), SearchText = $"{a.Id} {a.Title} {a.Body} {a.ThreatType} {a.GoalType} {string.Join(" ", a.Tags ?? new List<string>())}" });
            }
        }

        private void ApplyOverview()
        {
            var totalUsers = _userRows.Count;
            var activeToday = _userRows.Count(x => x.LastActiveUtc.HasValue && x.LastActiveUtc.Value.Date == DateTime.UtcNow.Date);
            var avgAccuracy = totalUsers == 0 ? 0.0 : _userRows.Average(x => x.Accuracy01);
            var atRiskUsers = _userRows.Count(x => x.Attempts >= 5 && x.Accuracy01 < 0.60);
            var totalContent = _questions.Count + _phishingEmails.Count + _authScenarios.Count;

            lblTotalUsersValue.Text = totalUsers.ToString(CultureInfo.InvariantCulture);
            lblActiveTodayValue.Text = activeToday.ToString(CultureInfo.InvariantCulture);
            lblAvgAccuracyValue.Text = avgAccuracy.ToString("P0", CultureInfo.InvariantCulture);
            lblAtRiskUsersValue.Text = atRiskUsers.ToString(CultureInfo.InvariantCulture);
            lblTotalContentValue.Text = totalContent.ToString(CultureInfo.InvariantCulture);
        }

        private void ApplyUserGrid()
        {
            if (dgvUsers == null)
            {
                return;
            }

            var search = (txtSearch?.Text ?? "").Trim();
            var rows = _userRows.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                rows = rows.Where(x => x.FullName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || x.Email.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvUsers.Rows.Clear();

            foreach (var row in rows.OrderBy(x => x.FullName))
            {
                dgvUsers.Rows.Add(row.FullName, row.Attempts.ToString(CultureInfo.InvariantCulture), row.Accuracy01.ToString("P0", CultureInfo.InvariantCulture), row.AvgSeconds <= 0 ? "-" : row.AvgSeconds.ToString("0.0", CultureInfo.InvariantCulture) + "s", row.WeakestTopic, row.LastActiveUtc.HasValue ? row.LastActiveUtc.Value.ToLocalTime().ToString("dd MMM yyyy HH:mm", CultureInfo.InvariantCulture) : "-");
            }
        }

        private void ApplyMisconceptionsGrid()
        {
            if (dgvMisconceptions == null)
            {
                return;
            }

            var type = (cmbContentType?.Text ?? "All").Trim().ToUpperInvariant();
            var search = (txtSearch?.Text ?? "").Trim();
            var sinceUtc = GetSinceUtc();

            var rows = _misHits.Where(x => (sinceUtc == null || x.WhenUtc >= sinceUtc.Value) && (type == "ALL" || x.Type.ToUpperInvariant().Contains(type.Replace(" EMAIL", "").Replace(" QUESTION", "").Replace(" SCENARIO", ""))));

            if (!string.IsNullOrWhiteSpace(search))
            {
                rows = rows.Where(x => x.Tag.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var grouped = rows.GroupBy(x => x.Tag, StringComparer.OrdinalIgnoreCase).Select(g => new { Tag = g.Key, Count = g.Count(), LastSeen = g.Max(x => x.WhenUtc) }).OrderByDescending(x => x.LastSeen).ThenByDescending(x => x.Count).Take(100).ToList();

            dgvMisconceptions.Rows.Clear();

            foreach (var row in grouped)
            {
                dgvMisconceptions.Rows.Add(row.Tag, row.Count.ToString(CultureInfo.InvariantCulture), row.LastSeen.ToLocalTime().ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
            }
        }

        private void ApplyRecentActivityGrid()
        {
            if (dgvRecentActivity == null)
            {
                return;
            }

            var type = (cmbContentType?.Text ?? "All").Trim().ToUpperInvariant();
            var search = (txtSearch?.Text ?? "").Trim();
            var sinceUtc = GetSinceUtc();

            var rows = _activityRows.AsEnumerable();

            if (sinceUtc.HasValue)
            {
                rows = rows.Where(x => x.WhenUtc >= sinceUtc.Value);
            }

            if (type != "ALL")
            {
                rows = rows.Where(x => x.Mode.ToUpperInvariant().Contains(type.Replace(" EMAIL", "").Replace(" QUESTION", "").Replace(" SCENARIO", "")));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                rows = rows.Where(x => x.UserName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || x.Mode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || x.Result.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvRecentActivity.Rows.Clear();

            foreach (var row in rows.OrderByDescending(x => x.WhenUtc).Take(200))
            {
                dgvRecentActivity.Rows.Add(row.UserName, row.Mode, row.Result, row.WhenUtc.ToLocalTime().ToString("dd MMM yyyy HH:mm", CultureInfo.InvariantCulture));
            }
        }

        private void ApplyBankGrid()
        {
            if (dgvBankItems == null)
            {
                return;
            }

            var type = string.IsNullOrWhiteSpace(cmbContentType?.Text) ? "All" : cmbContentType.Text.Trim();
            var topic = string.IsNullOrWhiteSpace(cmbBankTopic?.Text) ? "All" : cmbBankTopic.Text.Trim();
            var difficulty = string.IsNullOrWhiteSpace(cmbBankDifficulty?.Text) ? "All" : cmbBankDifficulty.Text.Trim();
            var search = (txtSearch?.Text ?? "").Trim();

            var rows = _bankRows.AsEnumerable();

            if (!string.Equals(type, "All", StringComparison.OrdinalIgnoreCase))
            {
                rows = rows.Where(x => x.Kind == ParseBankKind(type));
            }

            if (!string.Equals(topic, "All", StringComparison.OrdinalIgnoreCase))
            {
                rows = rows.Where(x => string.Equals(x.Topic, topic, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.Equals(difficulty, "All", StringComparison.OrdinalIgnoreCase))
            {
                rows = rows.Where(x => string.Equals(x.Difficulty, difficulty, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                rows = rows.Where(x => x.SearchText.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvBankItems.Rows.Clear();

            foreach (var row in rows.OrderBy(x => x.Kind).ThenBy(x => x.Title))
            {
                var gridIndex = dgvBankItems.Rows.Add(row.Key, row.Title, BankKindText(row.Kind));
                dgvBankItems.Rows[gridIndex].Tag = row;
            }
        }

        private void PopulateEditorFromSelection(BankRow row)
        {
            if (row == null)
            {
                return;
            }

            _editorLoading = true;

            try
            {
                _selectedBankRow = row;

                switch (row.Kind)
                {
                    case BankKind.Quiz:
                        tabEditor.SelectedTab = tabQuizQuestion;
                        PopulateQuizEditor(_questions.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == row.Key));
                        break;

                    case BankKind.Phishing:
                        tabEditor.SelectedTab = tabPhishingEmail;
                        PopulatePhishingEditor(_phishingEmails.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == row.Key));
                        break;

                    case BankKind.Auth:
                        tabEditor.SelectedTab = tabAuthScenario;
                        PopulateAuthEditor(_authScenarios.FirstOrDefault(x => string.Equals(x.Id, row.Key, StringComparison.OrdinalIgnoreCase)));
                        break;
                }
            }

            finally
            {
                _editorLoading = false;
            }
        }

        private void PopulateQuizEditor(Question q)
        {
            ClearQuizEditor();

            if (q == null)
            {
                return;
            }

            rtbQuizQuestionText.Text = q.Text ?? "";
            rtbQuizExplanation.Text = q.Explanation ?? "";
            cmbQuizTopic.Text = DisplayEnum(q.Metadata.Topic);
            cmbQuizDifficulty.Text = DisplayEnum(q.Metadata.Difficulty);
            cmbQuizType.Text = DisplayEnum(q.Metadata.QuestionType);
            txtMisTags.Text = string.Join(Environment.NewLine, q.Metadata.MisconceptionTags ?? new List<string>());

            dgvQuizOptions.Rows.Clear();

            foreach (var option in q.Options ?? new List<AnswerOption>())
            {
                dgvQuizOptions.Rows.Add(option.Text ?? "", option.IsCorrect);
            }
        }

        private void PopulatePhishingEditor(PhishingEmail email)
        {
            ClearPhishingEditor();

            if (email == null)
            {
                return;
            }

            txtSenderName.Text = email.SenderName ?? "";
            txtSenderEmail.Text = email.SenderEmail ?? "";
            txtReplyTo.Text = email.ReplyToEmail ?? "";
            txtToEmail.Text = email.ToEmail ?? "";
            txtPhishSubject.Text = email.Subject ?? "";
            cmbPhishDifficulty.Text = DisplayEnum(email.Difficulty);

            chkIsPhishing.Checked = email.IsPhishing;
            chkHasLink.Checked = email.HasLink;
            chkHasAttachment.Checked = email.HasAttachment;

            txtLinkDisplayText.Text = email.Link?.DisplayText ?? "";
            txtLinkUrl.Text = email.Link?.Url ?? "";
            txtAttachmentName.Text = email.Attachment?.FileName ?? "";

            rtbPhishBody.Text = email.Body ?? "";
            rtbPhishExplanation.Text = email.Explanation ?? "";
            txtPhishTags.Text = string.Join(Environment.NewLine, email.Tags ?? new List<string>());

            UpdateInvisibleFields();
        }

        private void PopulateAuthEditor(AuthenticationDefenseScenario scenario)
        {
            ClearAuthEditor();

            if (scenario == null)
            {
                return;
            }

            txtScenarioTitle.Text = scenario.Title ?? "";
            rtbScenarioBody.Text = scenario.Body ?? "";
            rtbScenarioHints.Text = string.Join(Environment.NewLine, scenario.Hints ?? new List<string>());
            txtScenarioTags.Text = string.Join(Environment.NewLine, scenario.Tags ?? new List<string>());

            cmbThreatType.Text = DisplayEnum(scenario.ThreatType);
            cmbGoalType.Text = DisplayEnum(scenario.GoalType);
            cmbAuthDifficulty.Text = DisplayEnum(scenario.Difficulty);
            cmbRecAuthMethod.Text = DisplayEnum(scenario.RecommendedAuthMethod);
            cmbRecRecovery.Text = DisplayEnum(scenario.RecommendedRecovery);
            cmbRecSession.Text = DisplayEnum(scenario.RecommendedSessionControl);

            chkReqMfa.Checked = scenario.RequireMfa;
            chkReqPhishResistant.Checked = scenario.RequirePhishingResistant;
            chkReqStepUp.Checked = scenario.RequireRiskBasedStepUp;
            chkReqLegacyBlock.Checked = scenario.RequireBlockLegacyAuth;
            chkReqDeviceBinding.Checked = scenario.RequireDeviceBinding;
            chkReqAlertOnSuspicious.Checked = scenario.RequireAlertOnSuspicious;
        }

        private void ClearQuizEditor()
        {
            rtbQuizQuestionText.Text = "";
            rtbQuizExplanation.Text = "";
            cmbQuizTopic.SelectedIndex = -1;
            cmbQuizDifficulty.SelectedIndex = -1;
            cmbQuizType.SelectedIndex = -1;
            txtMisTags.Text = "";
            dgvQuizOptions.Rows.Clear();
        }

        private void ClearPhishingEditor()
        {
            txtSenderName.Text = "";
            txtSenderEmail.Text = "";
            txtReplyTo.Text = "";
            txtToEmail.Text = "";
            txtPhishSubject.Text = "";
            cmbPhishDifficulty.SelectedIndex = -1;

            chkIsPhishing.Checked = false;
            chkHasLink.Checked = false;
            chkHasAttachment.Checked = false;

            txtLinkDisplayText.Text = "";
            txtLinkUrl.Text = "";
            txtAttachmentName.Text = "";

            rtbPhishBody.Text = "";
            rtbPhishExplanation.Text = "";
            txtPhishTags.Text = "";

            UpdateInvisibleFields();
        }

        private void ClearAuthEditor()
        {
            txtScenarioTitle.Text = "";
            rtbScenarioBody.Text = "";
            rtbScenarioHints.Text = "";
            txtScenarioTags.Text = "";

            cmbThreatType.SelectedIndex = -1;
            cmbGoalType.SelectedIndex = -1;
            cmbAuthDifficulty.SelectedIndex = -1;
            cmbRecAuthMethod.SelectedIndex = -1;
            cmbRecRecovery.SelectedIndex = -1;
            cmbRecSession.SelectedIndex = -1;

            chkReqMfa.Checked = false;
            chkReqPhishResistant.Checked = false;
            chkReqStepUp.Checked = false;
            chkReqLegacyBlock.Checked = false;
            chkReqDeviceBinding.Checked = false;
            chkReqAlertOnSuspicious.Checked = false;
        }

        private void SaveCurrentEditor()
        {
            switch (CurrentEditorKind())
            {
                case BankKind.Quiz:
                    SaveQuizItem();
                    break;

                case BankKind.Phishing:
                    SavePhishingItem();
                    break;

                case BankKind.Auth:
                    SaveAuthItem();
                    break;
            }

            BuildBankRows();
            ApplyOverview();
            ApplyBankGrid();
        }

        private void SaveQuizItem()
        {
            var text = (rtbQuizQuestionText.Text ?? "").Trim();
            var topic = ParseEnumValue<Topic>(cmbQuizTopic.Text, Topic.Phishing);
            var difficulty = ParseEnumValue<DifficultyBand>(cmbQuizDifficulty.Text, DifficultyBand.Medium);
            var qType = ParseEnumValue<QuestionType>(cmbQuizType.Text, QuestionType.SingleChoice);

            if (text.Length == 0)
            {
                throw new InvalidOperationException("Quiz question text is required.");
            }

            var options = ReadQuizOptions();

            if (options.Count < 2)
            {
                throw new InvalidOperationException("Add at least two answer options.");
            }

            if (!options.Any(x => x.IsCorrect))
            {
                throw new InvalidOperationException("At least one option must be marked correct.");
            }

            var target = _selectedBankRow != null && _selectedBankRow.Kind == BankKind.Quiz ? _questions.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key) : null;

            if (target == null)
            {
                target = new Question{ Id = _questions.Count == 0 ? 1 : _questions.Max(x => x.Id) + 1, Metadata = new QuestionMetadata()};

                _questions.Add(target);
            }

            target.Text = text;
            target.Explanation = (rtbQuizExplanation.Text ?? "").Trim();
            target.Metadata.Topic = topic;
            target.Metadata.Difficulty = difficulty;
            target.Metadata.QuestionType = qType;
            target.Metadata.MisconceptionTags = ReadMultiText(txtMisTags.Text);
            target.Options = options;

            SaveQuestionsFile();
        }

        private void SavePhishingItem()
        {
            var subject = (txtPhishSubject.Text ?? "").Trim();
            var body = (rtbPhishBody.Text ?? "").Trim();

            if (subject.Length == 0)
            {
                throw new InvalidOperationException("Phishing subject is required.");
            }

            if (body.Length == 0)
            {
                throw new InvalidOperationException("Phishing email body is required.");
            }

            var hasLink = chkHasLink.Checked;
            var hasAttachment = chkHasAttachment.Checked;
            var linkDisplayText = (txtLinkDisplayText.Text ?? "").Trim();
            var linkUrl = (txtLinkUrl.Text ?? "").Trim();
            var attachmentName = (txtAttachmentName.Text ?? "").Trim();

            if (hasLink && linkUrl.Length == 0)
            {
                throw new InvalidOperationException("Enter a link URL or untick 'has link'.");
            }

            if (hasLink && linkDisplayText.Length == 0)
            {
                throw new InvalidOperationException("Enter link display text or untick 'has link'.");
            }

            if (hasAttachment && attachmentName.Length == 0)
            {
                throw new InvalidOperationException("Enter an attachment name or untick 'has attachment'.");
            }

            var target = _selectedBankRow != null && _selectedBankRow.Kind == BankKind.Phishing ? _phishingEmails.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key) : null;

            if (target == null)
            {
                target = new PhishingEmail{ Id = _phishingEmails.Count == 0 ? 1 : _phishingEmails.Max(x => x.Id) + 1 };

                _phishingEmails.Add(target);
            }

            target.SenderName = (txtSenderName.Text ?? "").Trim();
            target.SenderEmail = (txtSenderEmail.Text ?? "").Trim();
            target.ReplyToEmail = (txtReplyTo.Text ?? "").Trim();
            target.ToEmail = (txtToEmail.Text ?? "").Trim();
            target.Subject = subject;
            target.Body = body;
            target.Explanation = (rtbPhishExplanation.Text ?? "").Trim();
            target.Difficulty = ParseEnumValue<DifficultyBand>(cmbPhishDifficulty.Text, DifficultyBand.Medium);
            target.IsPhishing = chkIsPhishing.Checked;
            target.Link = new PhishingLink { Url = hasLink ? linkUrl : "", DisplayText = hasLink ? linkDisplayText : "" };
            target.Attachment = new PhishingAttachment { FileName = hasAttachment ? attachmentName : "" };
            target.Tags = ReadMultiText(txtPhishTags.Text);

            SavePhishingFile();
        }

        private void SaveAuthItem()
        {
            var title = (txtScenarioTitle.Text ?? "").Trim();
            var body = (rtbScenarioBody.Text ?? "").Trim();

            if (title.Length == 0)
            {
                throw new InvalidOperationException("Scenario title is required.");
            }

            if (body.Length == 0)
            {
                throw new InvalidOperationException("Scenario body is required.");
            }

            var target = _selectedBankRow != null && _selectedBankRow.Kind == BankKind.Auth ? _authScenarios.FirstOrDefault(x => string.Equals(x.Id, _selectedBankRow.Key, StringComparison.OrdinalIgnoreCase)) : null;

            if (target == null)
            {
                target = new AuthenticationDefenseScenario { Id = "auth_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) };

                _authScenarios.Add(target);
            }

            target.Title = title;
            target.Body = body;
            target.Hints = ReadMultiText(rtbScenarioHints.Text);
            target.Tags = ReadMultiText(txtScenarioTags.Text);

            target.ThreatType = ParseEnumValue<AuthThreatType>(cmbThreatType.Text, AuthThreatType.CredentialStuffing);
            target.GoalType = ParseEnumValue<AuthGoalType>(cmbGoalType.Text, AuthGoalType.ProtectUserSignIn);
            target.Difficulty = ParseEnumValue<DifficultyBand>(cmbAuthDifficulty.Text, DifficultyBand.Medium);
            target.RecommendedAuthMethod = ParseEnumValue<AuthMethodType>(cmbRecAuthMethod.Text, AuthMethodType.PasswordAndOtp);
            target.RecommendedRecovery = ParseEnumValue<RecoveryType>(cmbRecRecovery.Text, RecoveryType.BackupCodes);
            target.RecommendedSessionControl = ParseEnumValue<SessionControlType>(cmbRecSession.Text, SessionControlType.Basic);

            target.RecommendedPasswordPolicy = PasswordPolicyType.StrongUnique;
            target.RecommendedMonitoring = MonitoringType.BasicLogs;
            target.RecommendedRateLimit = RateLimitType.BasicLockout;

            target.RequireMfa = chkReqMfa.Checked;
            target.RequirePhishingResistant = chkReqPhishResistant.Checked;
            target.RequireRiskBasedStepUp = chkReqStepUp.Checked;
            target.RequireBlockLegacyAuth = chkReqLegacyBlock.Checked;
            target.RequireDeviceBinding = chkReqDeviceBinding.Checked;
            target.RequireAlertOnSuspicious = chkReqAlertOnSuspicious.Checked;

            SaveAuthFile();
        }

        private void SaveQuestionsFile()
        {
            File.WriteAllText(_questionsPath, System.Text.Json.JsonSerializer.Serialize(_questions, _json));
        }

        private void SavePhishingFile()
        {
            File.WriteAllText(_phishingPath, System.Text.Json.JsonSerializer.Serialize(_phishingEmails, _json));
        }

        private void SaveAuthFile()
        {
            File.WriteAllText(_authPath, System.Text.Json.JsonSerializer.Serialize(_authScenarios, _json));
        }

        private List<AnswerOption> ReadQuizOptions()
        {
            var list = new List<AnswerOption>();
            var nextId = 1;

            foreach (DataGridViewRow row in dgvQuizOptions.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var text = Convert.ToString(row.Cells[0].Value)?.Trim() ?? "";

                if (text.Length == 0)
                {
                    continue;
                }

                var isCorrect = false;

                try
                {
                    isCorrect = row.Cells[1].Value != null && Convert.ToBoolean(row.Cells[1].Value, CultureInfo.InvariantCulture);
                }

                catch
                {
                    isCorrect = false;
                }

                list.Add(new AnswerOption { Id = nextId++, Text = text, IsCorrect = isCorrect });
            }

            return list;
        }

        private void CreateNewItem()
        {
            _selectedBankRow = null;

            switch (CurrentEditorKind())
            {
                case BankKind.Quiz:
                    ClearQuizEditor();
                    break;

                case BankKind.Phishing:
                    ClearPhishingEditor();
                    break;

                case BankKind.Auth:
                    ClearAuthEditor();
                    break;
            }
        }

        private void DuplicateSelectedItem()
        {
            if (_selectedBankRow == null)
            {
                MessageBox.Show(this, "Select a content item first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (_selectedBankRow.Kind)
            {
                case BankKind.Quiz:
                    var q = _questions.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key);

                    if (q == null)
                    {
                        return;
                    }

                    _questions.Add(new Question
                    {
                        Id = _questions.Max(x => x.Id) + 1,
                        Text = q.Text,
                        Explanation = q.Explanation,
                        Metadata = new QuestionMetadata { Topic = q.Metadata.Topic, Difficulty = q.Metadata.Difficulty, QuestionType = q.Metadata.QuestionType, MisconceptionTags = new List<string>(q.Metadata.MisconceptionTags ?? new List<string>()) },

                        Options = q.Options.Select(x => new AnswerOption { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList() });

                    SaveQuestionsFile();
                    break;

                case BankKind.Phishing:
                    var p = _phishingEmails.FirstOrDefault(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key);
                    if (p == null)
                    {
                        return;
                    }

                    _phishingEmails.Add(new PhishingEmail { Id = _phishingEmails.Max(x => x.Id) + 1, Difficulty = p.Difficulty, SenderName = p.SenderName, SenderEmail = p.SenderEmail, ToEmail = p.ToEmail, Subject = p.Subject, Body = p.Body, ReplyToEmail = p.ReplyToEmail, Link = new PhishingLink { Url = p.Link?.Url ?? "", DisplayText = p.Link?.DisplayText ?? "" }, Attachment = new PhishingAttachment { FileName = p.Attachment?.FileName ?? "" }, IsPhishing = p.IsPhishing, Explanation = p.Explanation, Tags = new List<string>(p.Tags ?? new List<string>()) });
                    SavePhishingFile();
                    break;

                case BankKind.Auth:
                    var a = _authScenarios.FirstOrDefault(x => string.Equals(x.Id, _selectedBankRow.Key, StringComparison.OrdinalIgnoreCase));
                    if (a == null)
                    {
                        return;
                    }

                    _authScenarios.Add(new AuthenticationDefenseScenario { Id = "auth_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), Title = a.Title, ThreatType = a.ThreatType, GoalType = a.GoalType, Difficulty = a.Difficulty, Body = a.Body, Hints = new List<string>(a.Hints ?? new List<string>()), Tags = new List<string>(a.Tags ?? new List<string>()), RecommendedAuthMethod = a.RecommendedAuthMethod, RecommendedPasswordPolicy = a.RecommendedPasswordPolicy, RecommendedRecovery = a.RecommendedRecovery, RecommendedMonitoring = a.RecommendedMonitoring, RecommendedRateLimit = a.RecommendedRateLimit, RecommendedSessionControl = a.RecommendedSessionControl, RequireMfa = a.RequireMfa, RequirePhishingResistant = a.RequirePhishingResistant, RequireDeviceBinding = a.RequireDeviceBinding, RequireRiskBasedStepUp = a.RequireRiskBasedStepUp, RequireBlockLegacyAuth = a.RequireBlockLegacyAuth, RequireAlertOnSuspicious = a.RequireAlertOnSuspicious });
                    SaveAuthFile();
                    break;
            }

            RefreshAll();
        }

        private void DeleteSelectedItem()
        {
            if (_selectedBankRow == null)
            {
                MessageBox.Show(this, "Select a content item first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ok = MessageBox.Show(this, "Delete the selected item?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (ok != DialogResult.OK)
            {
                return;
            }

            switch (_selectedBankRow.Kind)
            {
                case BankKind.Quiz:
                    _questions.RemoveAll(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key);
                    SaveQuestionsFile();
                    ClearQuizEditor();
                    break;

                case BankKind.Phishing:
                    _phishingEmails.RemoveAll(x => x.Id.ToString(CultureInfo.InvariantCulture) == _selectedBankRow.Key);
                    SavePhishingFile();
                    ClearPhishingEditor();
                    break;

                case BankKind.Auth:
                    _authScenarios.RemoveAll(x => string.Equals(x.Id, _selectedBankRow.Key, StringComparison.OrdinalIgnoreCase));
                    SaveAuthFile();
                    ClearAuthEditor();
                    break;
            }

            _selectedBankRow = null;
            RefreshAll();
        }

        private void SaveEverything()
        {
            SaveQuestionsFile();
            SavePhishingFile();
            SaveAuthFile();
            RefreshAll();
        }

        private void RevertEverything()
        {
            var ok = MessageBox.Show(this, "Discard unsaved editor changes and reload from disk?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (ok != DialogResult.OK)
            {
                return;
            }

            _selectedBankRow = null;
            RefreshAll();
            ClearQuizEditor();
            ClearPhishingEditor();
            ClearAuthEditor();
        }

        private void ExportCurrentGrid()
        {
            var grid = FocusedGrid();

            if (grid == null || grid.Rows.Count == 0)
            {
                MessageBox.Show(this, "There is nothing to export.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new SaveFileDialog { Filter = "CSV Files|*.csv", FileName = "admin_export_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".csv" };

            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var sb = new StringBuilder();

            var headers = new List<string>();

            foreach (DataGridViewColumn col in grid.Columns)
            {
                headers.Add(EscapeCsv(col.HeaderText));
            }

            sb.AppendLine(string.Join(",", headers));

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var cells = new List<string>();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cells.Add(EscapeCsv(Convert.ToString(cell.Value) ?? ""));
                }

                sb.AppendLine(string.Join(",", cells));
            }

            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show(this, "Export complete.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataGridView FocusedGrid()
        {
            if (dgvBankItems.Focused || dgvBankItems.ContainsFocus)
            {
                return dgvBankItems;
            }

            if (dgvRecentActivity.Focused || dgvRecentActivity.ContainsFocus)
            {
                return dgvRecentActivity;
            }

            if (dgvMisconceptions.Focused || dgvMisconceptions.ContainsFocus)
            {
                return dgvMisconceptions;
            }

            if (dgvUsers.Focused || dgvUsers.ContainsFocus)
            {
                return dgvUsers;
            }

            return dgvUsers;
        }

        private DateTime? GetSinceUtc()
        {
            var text = (cmbRange?.Text ?? "All Time").Trim().ToUpperInvariant();
            var now = DateTime.UtcNow;

            if (text == "TODAY")
            {
                return now.Date;
            }

            if (text.Contains("7"))
            {
                return now.AddDays(-7);
            }

            if (text.Contains("30"))
            {
                return now.AddDays(-30);
            }

            return null;
        }

        private DateTime? GetLastActiveUtc(string userKey)
        {
            using var conn = Open();

            var parts = new List<string>();

            if (TableExists(conn, "Attempts"))
            {
                parts.Add("SELECT SubmittedAt FROM Attempts WHERE UserKey = $uk");
            }

            if (TableExists(conn, "PhishingAttempts"))
            {
                parts.Add("SELECT SubmittedAt FROM PhishingAttempts WHERE UserKey = $uk");
            }

            if (TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                parts.Add("SELECT SubmittedAt FROM AuthenticationDefenseAttempts WHERE UserKey = $uk");
            }

            if (TableExists(conn, "LearningModuleAttempts"))
            {
                parts.Add("SELECT SubmittedAt FROM LearningModuleAttempts WHERE UserKey = $uk");
            }

            if (parts.Count == 0)
            {
                return null;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT MAX(SubmittedAt) FROM (" + string.Join(" UNION ALL ", parts) + ");";
            cmd.Parameters.AddWithValue("$uk", userKey);

            var value = cmd.ExecuteScalar();

            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return ParseUtc(Convert.ToString(value) ?? "");
        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection("Data Source=" + _dbPath);
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }

        private static bool TableExists(SqliteConnection conn, string tableName)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=$name LIMIT 1;";
            cmd.Parameters.AddWithValue("$name", tableName);

            var value = cmd.ExecuteScalar();
            return value != null && value != DBNull.Value;
        }

        private string FixPath(string fileName)
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);

            while (dir != null)
            {
                var candidate = Path.Combine(dir.FullName, "Resources", fileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                dir = dir.Parent;
            }

            return Path.Combine(AppContext.BaseDirectory, "Resources", fileName);
        }

        private static void SetEnumCombo(ComboBox combo, Type enumType, object excluded)
        {
            if (combo == null)
            {
                return;
            }

            combo.Items.Clear();

            foreach (var value in Enum.GetValues(enumType))
            {
                if (excluded != null && value.Equals(excluded))
                {
                    continue;
                }

                combo.Items.Add(DisplayEnum((Enum)value));
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        private static string ShowTopic(Topic topic)
        {
            return DisplayEnum(topic);
        }

        private static string DisplayEnum(Enum value)
        {
            var raw = value.ToString();
            var sb = new StringBuilder(raw.Length + 8);

            for (int i = 0; i < raw.Length; i++)
            {
                var c = raw[i];

                if (i > 0 && char.IsUpper(c) && !char.IsUpper(raw[i - 1]))
                {
                    sb.Append(' ');
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        private static T ParseEnumValue<T>(string text, T fallback) where T : struct
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return fallback;
            }

            var compact = text.Replace(" ", "");

            return Enum.TryParse(compact, true, out T value) ? value : fallback;
        }
        
        private static List<string> ReadMultiText(string text)
        {
            return (text ?? "").Split(new[] { '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static List<string> ReadStringList(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
            }

            catch
            {
                return new List<string>();
            }
        }

        private static PhishingEmail ReadPhishingSnapshot(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<PhishingEmail>(json);
            }

            catch
            {
                return null;
            }
        }

        private string FixUserName(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return "USER";
            }

            if (_userNameByKey.TryGetValue(userKey.Trim(), out var name))
            {
                return name;
            }

            return userKey.Trim();
        }

        private static string SafeString(SqliteDataReader r, int ordinal)
        {
            return r.IsDBNull(ordinal) ? "" : (r.GetString(ordinal) ?? "");
        }

        private static DateTime ParseUtc(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return DateTime.UtcNow;
            }

            if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var value))
            {
                return value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
            }

            return DateTime.UtcNow;
        }

        private static string BuildPhishingResult(int action, bool ok)
        {
            if (action == (int)PhishingAction.TrustKeep)
            {
                return ok ? "SAFE CALL" : "MISSED PHISH";
            }

            if (action == (int)PhishingAction.ReportPhishing)
            {
                return ok ? "GOOD CATCH" : "FALSE ALARM";
            }

            return ok ? "CORRECT" : "INCORRECT";
        }

        private static string BuildAuthResult(bool isCorrect, double? accuracy01)
        {
            if (!accuracy01.HasValue)
            {
                return isCorrect ? "PASS" : "MISS";
            }

            var accuracy = Math.Max(0.0, Math.Min(1.0, accuracy01.Value));

            if (isCorrect)
            {
                return "PASS";
            }

            if (accuracy >= 0.40)
            {
                return "PARTIAL";
            }

            return "MISS";
        }

        private static Topic MapAuthTopic(AuthenticationDefenseScenario scenario)
        {
            if (scenario == null)
            {
                return Topic.Passwords;
            }

            switch (scenario.ThreatType)
            {
                case AuthThreatType.HelpdeskTakeover:
                case AuthThreatType.MfaFatigue:
                    return Topic.SocialEngineering;

                case AuthThreatType.SessionHijack:
                case AuthThreatType.TokenReplay:
                    return Topic.DeviceSecurity;

                default:
                    return Topic.Passwords;
            }
        }

        private static BankKind ParseBankKind(string text)
        {
            var t = (text ?? "").Trim().ToUpperInvariant();

            if (t.Contains("PHISH"))
            {
                return BankKind.Phishing;
            }

            if (t.Contains("AUTH"))
            {
                return BankKind.Auth;
            }

            return BankKind.Quiz;
        }

        private static string BankKindText(BankKind kind)
        {
            switch (kind)
            {
                case BankKind.Phishing:
                    return "PHISHING";

                case BankKind.Auth:
                    return "AUTH";

                default: return "QUIZ";
            }
        }

        private BankKind CurrentEditorKind()
        {
            if (tabEditor.SelectedTab == tabPhishingEmail)
            {
                return BankKind.Phishing;
            }

            if (tabEditor.SelectedTab == tabAuthScenario)
            {
                return BankKind.Auth;
            }

            return BankKind.Quiz;
        }

        private static string EscapeCsv(string text)
        {
            var value = text ?? "";

            if (value.Contains("\""))
            {
                value = value.Replace("\"", "\"\"");
            }

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
            {
                value = "\"" + value + "\"";
            }

            return value;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            ExportCurrentGrid();
        }

        private void btnLoadSelected_Click(object sender, EventArgs e)
        {
            if (_selectedBankRow == null)
            {
                MessageBox.Show(this, "Select an item in the content bank first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            PopulateEditorFromSelection(_selectedBankRow);
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCurrentEditor();
                MessageBox.Show(this, "Item saved.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEverything();
                MessageBox.Show(this, "All changes saved.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateInvisibleFields()
        {
            var showLink = chkHasLink != null && chkHasLink.Checked;
            var showAttachment = chkHasAttachment != null && chkHasAttachment.Checked;

            if (txtLinkDisplayText != null)
            {
                txtLinkDisplayText.Visible = showLink;
            }

            if (txtLinkUrl != null)
            {
                txtLinkUrl.Visible = showLink;
            }

            if (txtAttachmentName != null)
            {
                txtAttachmentName.Visible = showAttachment;
            }
        }

        private void btnRevertChanges_Click(object sender, EventArgs e)
        {
            RevertEverything();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            CreateNewItem();
        }

        private void btnDuplicateItem_Click(object sender, EventArgs e)
        {
            DuplicateSelectedItem();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.Show();
            Close();
        }

        private void cmbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyMisconceptionsGrid();
            ApplyRecentActivityGrid();
        }

        private void cmbContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyMisconceptionsGrid();
            ApplyRecentActivityGrid();
            ApplyBankGrid();
        }

        private void cmbBankTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBankGrid();
        }

        private void cmbBankDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyBankGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyUserGrid();
            ApplyMisconceptionsGrid();
            ApplyRecentActivityGrid();
            ApplyBankGrid();
        }

        private void dgvBankItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBankItems == null || dgvBankItems.SelectedRows.Count == 0)
            {
                return;
            }

            _selectedBankRow = dgvBankItems.SelectedRows[0].Tag as BankRow;
        }

        private void tabEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editorLoading)
            {
                return;
            }
        }

        private enum BankKind
        {
            Quiz,
            Phishing,
            Auth
        }

        private sealed class UserSummaryRow
        {
            public long UserId { get; set; }
            public string UserKey { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public int Attempts { get; set; }
            public double Accuracy01 { get; set; }
            public double AvgSeconds { get; set; }
            public string WeakestTopic { get; set; }
            public DateTime? LastActiveUtc { get; set; }
        }

        private sealed class ActivityRow
        {
            public string UserKey { get; set; }
            public string UserName { get; set; }
            public string Mode { get; set; }
            public string Result { get; set; }
            public DateTime WhenUtc { get; set; }
        }

        private sealed class MisHitRow
        {
            public string Type { get; set; }
            public string Tag { get; set; }
            public DateTime WhenUtc { get; set; }
        }

        private sealed class BankRow
        {
            public BankKind Kind { get; set; }
            public string Key { get; set; }
            public string Title { get; set; }
            public string Topic { get; set; }
            public string Difficulty { get; set; }
            public string SearchText { get; set; }
        }

        private void pnlAvgAccuracy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLinkUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkHasLink_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInvisibleFields();
        }

        private void chkHasAttachment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInvisibleFields();
        }

        private void lblAdminUser_Click(object sender, EventArgs e)
        {

        }
    }
}