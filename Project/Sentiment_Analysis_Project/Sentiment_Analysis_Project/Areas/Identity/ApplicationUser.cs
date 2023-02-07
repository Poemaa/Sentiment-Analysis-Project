using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sentiment_Analysis_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sentiment_Analysis_Project.Areas.Identity
{
    public class ApplicationUser:IdentityUser
    
    {
        public string Emri { get; set; } = null!;
        public string Mbiemri { get; set; } = null!;
        public DateTime Ditelindja { get; set; }
        public string Gjinia { get; set; } = null!;
        public int InstitutiId { get; set; }
        [ForeignKey("InstitutiId")]
        public Instituti Instituti { get; set; } = null!;

        public int FakultetiId { get; set; }
        [ForeignKey("FakultetiId")]
        public Fakulteti Fakulteti { get; set; } = null!;
        public int IdentifikimiFakultetit { get; set; }
        //public bool? Statusi { get; set; }
        public DateTime FillimiStudimeve { get; set; }
        
        [Precision(4,2)]        
        public decimal MesatarjaNotes { get; set; }

        public List<Feedback> Feedbacks { get; set; }

     
    }
}
