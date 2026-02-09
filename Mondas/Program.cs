using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Threading;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Mondas.Contracts.Services;
using Mondas.Contracts.Views;
using Mondas.Models;
using Mondas.Services;
using Mondas.Views;

using SQLitePCL;

namespace Mondas
{
    internal static class Program
    {
        public static IHost _host;

        public static T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JFaF5cXGRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH9ednVdRmJeWEZzXEFWYEg=");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var baseDir = AppContext.BaseDirectory;

            SQLitePCL.Batteries_V2.Init();

            var init = new Mondas.Services.SqliteDatabaseInitializer (
                Path.Combine(baseDir, "mondas.db"),
                Path.Combine(baseDir, "Resources", "questions.json"));

            init.Initialize();
            OnStartup();
            Application.Run(new SignupForm());
            _host.Dispose();
            _host = null;
        }
        private static async void OnStartup()
        {
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
            _host = Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration(c =>
                    {
                        c.SetBasePath(appLocation);
                    })
                    .ConfigureServices(ConfigureServices)
                    .Build();

            await _host.RunAsync();

        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Core Services

            // Services
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Views
            services.AddTransient<IShellWindow, ShellWindow>();
            services.AddTransient<MainPage>();

            services.AddTransient<Start>();

            // Configuration
            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
        }
    }
}