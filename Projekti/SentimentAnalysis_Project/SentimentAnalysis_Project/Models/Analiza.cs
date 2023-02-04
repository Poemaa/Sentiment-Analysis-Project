using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Analiza
    {
        public int Idanaliza { get; set; }
        public string Rezultati { get; set; } = null!;
        public int Idfeedback { get; set; }

        public virtual Feedback IdfeedbackNavigation { get; set; } = null!;
    }
}
