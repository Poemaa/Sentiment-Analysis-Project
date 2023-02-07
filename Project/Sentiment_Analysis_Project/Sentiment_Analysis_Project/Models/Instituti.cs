using System;
using System.Collections.Generic;

namespace Sentiment_Analysis_Project.Models
{
    public  class Instituti
    {
        public int InstitutiId { get; set; }
        public string Emri { get; set; } = null!;
        public string Lokacioni { get; set; } = null!;
        public int NrStudenteve { get; set; }
        public string Nrtelefonit { get; set; } = null!;

        public List<Feedback> Feedbacks { get; set; }
        public List<Infk> Infks { get; set; }


    }
}
