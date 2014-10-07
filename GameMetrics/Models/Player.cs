using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMetrics.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
    }
}