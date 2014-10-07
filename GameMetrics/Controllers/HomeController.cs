using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMetrics.dalGameMetricContext;
using GameMetrics.ViewModels;

namespace GameMetrics.Controllers
{
    public class HomeController : Controller
    {
        private GameMetricContext db = new GameMetricContext();
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult GameArpu()
        {
            /*
             SELECT 
	            SUM(Purchase.Price) / count(DISTINCT Purchase.PlayerID) as ARPU,Game.Title as Game
            FROM
	            Purchase 
            INNER JOIN Game ON Purchase.GameID = Game.GameID 
            group by Game.Title
             */
            var data = from game in db.Games
                       join purch in db.Purchases on game.GameID equals purch.GameID into g
                       select new GameArpu()
                       {
                           Arpu = g.Sum(y => y.Price) / g.Select(y => y.PlayerID).Distinct().Count(),
                           GameName = game.Title
                       }; 
           

            return View(data);
        }
        public ActionResult GameDetail(string GameName)
        {
            var data = from purch in db.Purchases
                       join player in db.Players on purch.PlayerID equals player.PlayerID
                       join game in db.Games on purch.GameID equals game.GameID
                       select new PlayerHistory()
                       {
                           PlayerName = player.PlayerName,
                           GameName = game.Title,
                           Price = purch.Price
                       };
            data = data.Where(p => p.GameName == GameName);
            return View(data);
        }

        public ActionResult PlayerGameMoney()
        {
            /*
             SELECT 
             Player.PlayerName ,COUNT(Engagement.Achievement), Player.StartDate,SUM(Purchase.Price),Game.Title 
             FROM
             Purchase 
             INNER JOIN Player ON Purchase.PlayerID = Player.PlayerID 
             INNER JOIN Game ON Purchase.GameID = Game.GameID 
             LEFT JOIN Engagement ON  Purchase.PlayerID = Engagement.PlayerID and Purchase.GameID = Engagement.GameID
             group by Game.Title,Player.PlayerName , Player.StartDate
             */


            var data = from purch in db.Purchases
                       join player in db.Players on purch.PlayerID equals player.PlayerID
                       join game in db.Games on purch.GameID equals game.GameID
                       join engage in db.Engagements on new { purch.PlayerID, purch.GameID } equals new { engage.PlayerID, engage.GameID }
                       into engroup
                       from item in engroup.DefaultIfEmpty()
                       select new PlayerGameMoney()
                       {
                           PlayerName = player.PlayerName,
                           StartDate = player.StartDate,
                           Game = game.Title,
                           PlayCount = item.Achievement,
                           TotalSpend = purch.Price
                       } into foo
                       group foo by new { foo.PlayerName, foo.StartDate, foo.Game,  } into grp
                       select new PlayerGameMoney()
                       {
                           PlayerName = grp.Key.PlayerName,
                           StartDate = grp.Key.StartDate,
                           Game = grp.Key.Game,
                           PlayCount = grp.Select(y => y.PlayCount).Count(),
                           TotalSpend = grp.Sum(y => y.TotalSpend)
                       };
                       
            
            return View(data);
        }

        public ActionResult Historic(string PlayerName)
        {
            var data = from purch in db.Purchases
                       join player in db.Players on purch.PlayerID equals player.PlayerID
                       join game in db.Games on purch.GameID equals game.GameID
                       select new PlayerHistory()
                       {
                           PlayerName = player.PlayerName,
                           GameName = game.Title,
                           Price = purch.Price
                       };
            data = data.Where(p => p.PlayerName == PlayerName);
            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
