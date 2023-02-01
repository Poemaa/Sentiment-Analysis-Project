using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Fakulteti
    {
        public Fakulteti()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int FakultetiId { get; set; }
        public string Dega { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? StatusiAkredititmit { get; set; }
        public DateTime VitiAkreditimit { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
