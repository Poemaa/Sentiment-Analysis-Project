using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sentiment_Analysis_Project.Models
{
    public class Analiza
    {
        public int AnalizaId { get; set; }
        public string Rezultati { get; set; } = null!;
        public int? FeedbackId { get; set; }
        [ForeignKey("FeedbackId")]
        
        public  Feedback Feedback { get; set; } = null!;
    }
}
