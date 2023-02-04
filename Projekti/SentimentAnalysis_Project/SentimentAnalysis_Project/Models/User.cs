using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int IdUser { get; set; }
        public string Emri { get; set; } = null!;
        public string Mbiemri { get; set; } = null!;
        public DateTime Ditelindja { get; set; }
        public string Gjinia { get; set; } = null!;
        public string InstitutiEmri { get; set; } = null!;
        public string Dega { get; set; } = null!;
        public int FakultetiId { get; set; }
        public bool? Statusi { get; set; }
        public DateTime FillimiStudimeve { get; set; }
        public decimal MesatarjaNotes { get; set; }

        public virtual Fakulteti DegaNavigation { get; set; } = null!;
        public virtual Instituti InstitutiEmriNavigation { get; set; } = null!;
        public virtual UserAcc? UserAcc { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
