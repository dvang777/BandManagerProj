﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BandManager.Models;
using Microsoft.AspNet.Identity;

namespace BandManager.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
            var evt = db.Events.Where(b => b.band.ID == mgr.BandId).Select(b => b);

            var EventInfoModelViewList = db.Events.Where(x => x.BandId == mgr.BandId).Join(db.ItemsSold, e => e.ID, i => i.EventID, (e, i) => new
            {
                Events = e,
                QuantitySold = i.QuantitySold,
                Price = i.Price,
                TotalSold = i.TotalSold,
                TotalRevenue = i.TotalRevenue,
                i.InventoryID
            }).Join(db.Inventories, a => a.InventoryID, b => b.ID, (a, b) => new EventInfoViewModel
            {
                Events = a.Events,
                //{
                //    Name = a.Events.Name,
                //    Attendance = a.Events.Attendance,
                //    City = a.Events.City,
                //    State = a.Events.State
                //},
                QuantitySold = a.QuantitySold,
                Price = a.Price,
                TotalSold = a.TotalSold,
                TotalRevenue = a.TotalRevenue,
                Inventories = b
                //    {
                //    Name = b.Name,
                //    Description = b.Description,
                //    Size = b.Size,
                //    Quantity = b.Quantity
                //}
            }).ToList();

            var sold = db.Events.Select(a => a.TotalItemSold).ToArray();
            var rev = db.Events.Select(b => b.TotalRevenue).ToArray();
            var Evt = db.Events.Select(c => c.Name).ToList();
            var att = db.Events.Select(d => d.Attendance).ToArray();

            ViewBag.SoldArray = sold;
            ViewBag.RevArray = rev;
            ViewBag.EvtArray = Evt;
            ViewBag.AttArray = att;

            return View(evt.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Begin,End,City,State,Attendance,TotalItemSold,TotalRevenue")] Event @event)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
                @event.BandId = mgr.BandId;

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Begin,End,City,State,Attendance,TotalItemSold,TotalRevenue")] Event @event)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
                @event.BandId = mgr.BandId;

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
