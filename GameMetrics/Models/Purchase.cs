using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMetrics.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public Decimal Price { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}