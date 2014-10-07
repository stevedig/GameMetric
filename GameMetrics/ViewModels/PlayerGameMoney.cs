using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameMetrics.ViewModels
{
    public class PlayerGameMoney
    {
        public string PlayerName { get; set; }
        public string Game { get; set; }
        public int PlayCount { get; set; }
        public Decimal TotalSpend { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}