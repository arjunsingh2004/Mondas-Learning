using System;

namespace Mondas.Models
{
    public sealed class AttemptRecord
    {
        public long Id {get; set;}
        public string UserKey {get; set;} = "";
        public int QuestionId {get; set;}
        public string SelectedOptionIdsJson {get; set;} = "[]";
        public bool IsCorrect {get; set;}
        public double SecondsTaken {get; set;}
        public DateTime SubmittedAt {get; set;}
        public string ReasonString {get; set;} = "";
        public string RulesFiredJson {get; set;} = "[]";
    }
}