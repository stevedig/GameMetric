using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameMetrics.ViewModels
{
    public class PlayerHistory
    {
        [DataType(DataType.Date)]
        public string PlayerName { get; set; }
        public string GameName { get; set; }
        public decimal Price { get; set; }
    }
}