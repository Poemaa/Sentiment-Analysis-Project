using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sentiment_Analysis_Project.Models
{
    public  class Feedback
    {
        public int FeedbackId { get; set; }
        public string Permbajtja { get; set; } = null!;
        public DateTime Data { get; set; }
        public int InstitutiId { get; set; } 
        [ForeignKey("InstitutiId")]
        public Instituti Instituti { get; set; } = null!;
        
        public int FakultetiId { get; set; } 
        [ForeignKey("FakultetiId")]
        public Fakulteti Fakulteti { get; set; } = null!;

        public List<Analiza> Analizas { get; set; }

    }
}
