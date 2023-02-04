using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Fakulteti
    {
        public Fakulteti()
        {
            Feedbacks = new HashSet<Feedback>();
            Infks = new HashSet<Infk>();
            Users = new HashSet<User>();
        }

        public int FakultetiId { get; set; }
        public string Dega { get; set; } = null!;
        public string TitulliDiplomimit { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Infk> Infks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
