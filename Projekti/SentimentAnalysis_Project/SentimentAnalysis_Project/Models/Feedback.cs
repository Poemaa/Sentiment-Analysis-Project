using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Analizas = new HashSet<Analiza>();
        }

        public int Idfeedback { get; set; }
        public string Permbajtja { get; set; } = null!;
        public DateTime Data { get; set; }
        public string InstitutiF { get; set; } = null!;
        public string DegaF { get; set; } = null!;
        public int UserId { get; set; }

        public virtual Fakulteti DegaFNavigation { get; set; } = null!;
        public virtual Instituti InstitutiFNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Analiza> Analizas { get; set; }
    }
}
