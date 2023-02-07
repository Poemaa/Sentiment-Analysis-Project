using MessagePack;
using System;
using System.Collections.Generic;

namespace Sentiment_Analysis_Project.Models
{
    public  class Fakulteti
    {
        public int FakultetiId { get; set; } 
        public string Dega { get; set; } = null!;
        public string TitulliDiplomimit { get; set; } = null!;

        public List<Feedback> Feedbacks { get; set; }
        public List<Infk> Infks { get; set; }
        
    }
}
