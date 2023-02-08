using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektiSentimentAnalysis.Models
{
    public  class Feedback
    {
        public int FeedbackId { get; set; }
        public string Permbajtja { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("InstitutiId")] 
        public int InstitutiId { get; set; } 
        
        public Instituti Instituti { get; set; } = null!;

        [ForeignKey("FakultetiId")] 
        public int FakultetiId { get; set; } 
        public Fakulteti Fakulteti { get; set; } = null!;

    }
}
