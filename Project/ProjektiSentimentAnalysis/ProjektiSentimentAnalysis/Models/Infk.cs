using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektiSentimentAnalysis.Models
{
    public partial class Infk
    {
        public int InfkId { get; set; }
        public string Email { get; set; } = null!;
        public string? StatusiAkredititmit { get; set; }
        public DateTime VitiAkreditimit { get; set; }

        [ForeignKey("FakultetiId")]
        public int FakultetiId { get; set; } 
        public Fakulteti Fakulteti { get; set; } = null!;

        [ForeignKey("InstitutiId")] 
        public int InstitutiId { get; set; } 
        public Instituti Instituti { get; set; } = null!;

        
    }
}
