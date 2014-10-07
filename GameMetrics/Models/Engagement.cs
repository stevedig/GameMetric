using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMetrics.Models
{
    public class Engagement
    {
        public int EngagementID { get; set; }
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int Achievement { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<Engagement> Engagements { get; set; }
    }
}