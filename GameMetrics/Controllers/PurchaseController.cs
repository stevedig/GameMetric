using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMetrics.Models;
using GameMetrics.dalGameMetricContext;

namespace GameMetrics.Controllers
{
    public class PurchaseController : Controller
    {
        private GameMetricContext db = new GameMetricContext();

        //
        // GET: /Purchase/

        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Game).Include(p => p.Player);
            return View(purchases.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ActionResult Details(int id = 0)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title");
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName");
            return View();
        }

        //
        // POST: /Purchase/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", purchase.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", purchase.PlayerID);
            return View(purchase);
        }

        //
        // GET: /Purchase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", purchase.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", purchase.PlayerID);
            return View(purchase);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", purchase.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", purchase.PlayerID);
            return View(purchase);
        }

        //
        // GET: /Purchase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}