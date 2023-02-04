using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Instituti
    {
        public Instituti()
        {
            Feedbacks = new HashSet<Feedback>();
            Infks = new HashSet<Infk>();
            Users = new HashSet<User>();
        }

        public int InstitutiId { get; set; }
        public string Emri { get; set; } = null!;
        public string Lokacioni { get; set; } = null!;
        public int NrStudenteve { get; set; }
        public string Nrtelefonit { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Infk> Infks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
