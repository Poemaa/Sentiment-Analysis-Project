using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Feedback
    {
        public int Idfeedback { get; set; }
        public string Permbajtja { get; set; } = null!;
        public DateTime Data { get; set; }
        public int InstitutiId { get; set; }
        public int FakultetiId { get; set; }
        public int UserId { get; set; }

        public virtual Fakulteti Fakulteti { get; set; } = null!;
        public virtual Instituti Instituti { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
