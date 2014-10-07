using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GameMetrics.ViewModels
{
    public class GameArpu
    {
        public string GameName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? Arpu { get; set; }
    }
}