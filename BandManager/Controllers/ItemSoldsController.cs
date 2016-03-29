using System;
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
    public class ItemSoldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemSolds
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.BandId == userId).Single();

            var itemsSold = db.ItemsSold.Include(i => i.events).Include(i => i.Inventories);
            return View(itemsSold.ToList());
        }

        // GET: ItemSolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSold itemSold = db.ItemsSold.Find(id);
            if (itemSold == null)
            {
                return HttpNotFound();
            }
            return View(itemSold);
        }

        // GET: ItemSolds/Create
        public ActionResult Create()
        {
            var userid = User.Identity.GetUserId();
            List<Inventory> inventory = new List<Inventory> { };
            inventory = db.Inventories.Where(a => a.BandId == userid).Select(a => a).ToList();
            ViewBag.EventID = new SelectList(db.Events, "ID", "Name");
            ViewBag.InventoryID = new SelectList(inventory, "ID", "Name");

            return View();
        }

        // POST: ItemSolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuantitySold,Price,TotalRevenue,TotalSold,EventID,InventoryID")] ItemSold itemSold)
        {
            if (ModelState.IsValid)
            {
                db.ItemsSold.Add(itemSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "ID", "Name", itemSold.EventID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "Name", itemSold.InventoryID);
            return View(itemSold);
        }

        // GET: ItemSolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSold itemSold = db.ItemsSold.Find(id);
            if (itemSold == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "Name", itemSold.EventID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "Name", itemSold.InventoryID);
            return View(itemSold);
        }

        // POST: ItemSolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuantitySold,Price,TotalRevenue,TotalSold,EventID,InventoryID")] ItemSold itemSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "ID", "Name", itemSold.EventID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "ID", "Name", itemSold.InventoryID);
            return View(itemSold);
        }

        // GET: ItemSolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSold itemSold = db.ItemsSold.Find(id);
            if (itemSold == null)
            {
                return HttpNotFound();
            }
            return View(itemSold);
        }

        // POST: ItemSolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSold itemSold = db.ItemsSold.Find(id);
            db.ItemsSold.Remove(itemSold);
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
