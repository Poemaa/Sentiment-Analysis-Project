using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sentiment_Analysis_Project.Models
{
    public partial class Infk
    {
        public int InfkId { get; set; }
        public string Email { get; set; } = null!;
        public string StatusiAkredititmit { get; set; }
        public DateTime VitiAkreditimit { get; set; }

        public int FakultetiId { get; set; } 
        [ForeignKey("FakultetiId")]
        public Fakulteti Fakulteti { get; set; } = null!;

        public int InstitutiId { get; set; } 
        public Instituti Instituti { get; set; } = null!;

        
    }
}
