﻿using System;
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
    public class EngagementController : Controller
    {
        private GameMetricContext db = new GameMetricContext();

        //
        // GET: /Engagement/

        public ActionResult Index()
        {
            var engagements = db.Engagements.Include(e => e.Game).Include(e => e.Player);
            return View(engagements.ToList());
        }

        //
        // GET: /Engagement/Details/5

        public ActionResult Details(int id = 0)
        {
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        //
        // GET: /Engagement/Create

        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title");
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName");
            return View();
        }

        //
        // POST: /Engagement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Engagements.Add(engagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", engagement.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", engagement.PlayerID);
            return View(engagement);
        }

        //
        // GET: /Engagement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", engagement.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", engagement.PlayerID);
            return View(engagement);
        }

        //
        // POST: /Engagement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Engagement engagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", engagement.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", engagement.PlayerID);
            return View(engagement);
        }

        //
        // GET: /Engagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Engagement engagement = db.Engagements.Find(id);
            if (engagement == null)
            {
                return HttpNotFound();
            }
            return View(engagement);
        }

        //
        // POST: /Engagement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engagement engagement = db.Engagements.Find(id);
            db.Engagements.Remove(engagement);
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