using System;
using System.Collections.Generic;

namespace SentimentAnalysis_Project.Models
{
    public partial class UserAcc
    {
        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Roli { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
