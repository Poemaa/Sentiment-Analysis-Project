using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Infk
    {
        public int Idinfk { get; set; }
        public string InstitutiEmri { get; set; } = null!;
        public string FakultetiDega { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? StatusiAkredititmit { get; set; }
        public DateTime VitiAkreditimit { get; set; }

        public virtual Fakulteti FakultetiDegaNavigation { get; set; } = null!;
        public virtual Instituti InstitutiEmriNavigation { get; set; } = null!;
    }
}
