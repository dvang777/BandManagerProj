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
    public class InventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventories
        public ActionResult Index(string sortOrder)
        {
            var userID = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
            var inv = db.Inventories.Where(b => b.band.ID == mgr.BandId).Select(b => b);

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";
            ViewBag.QuantitySoldSortParm = sortOrder == "QuantitySold" ? "QuantitySold_desc" : "QuantitySold";
            ViewBag.QuantityIncomingSortParm = sortOrder == "QuantityIncoming" ? "QuantityIncoming_desc" : "QuantityIncoming";
            var inventory = from s in db.Inventories
                            select s;
            switch (sortOrder)
            {
                case "name_desc":
                    inventory = inventory.OrderByDescending(s => s.Name);
                    break;
                case "Description":
                    inventory = inventory.OrderBy(s => s.Description);
                    break;
                case "Description_desc":
                    inventory = inventory.OrderByDescending(s => s.Description);
                    break;
                case "Quantity":
                    inventory = inventory.OrderBy(s => s.Quantity);
                    break;
                case "Quantity_desc":
                    inventory = inventory.OrderByDescending(s => s.Quantity);
                    break;
                case "QuantityIncoming":
                    inventory = inventory.OrderBy(s => s.QuantityIncoming);
                    break;
                case "QuantityIncoming_desc":
                    inventory = inventory.OrderByDescending(s => s.QuantityIncoming);
                    break;
                    
            }
            var quantity = db.Inventories.Select(x => x.Quantity).ToArray();
            var invent = db.Inventories.Select(z => z.Name).ToList();
            var sold = db.Inventories.Select(a => a.TotalSold).ToArray();
            var ord = db.Inventories.Select(b => b.QuantityIncoming).ToArray();

            ViewBag.SoldArray = sold;
            ViewBag.QuantityArray = quantity;
            ViewBag.InventArray = invent;
            ViewBag.OrdArray = ord;
            return View(inv.ToList());
        }

        public ActionResult AdminView()
        {
            return View();
        }
        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Size,Quantity,BandId,SoldQuantity,Price,TotalSold,QuantityIncoming,OrderedYTD")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
                inventory.BandId = mgr.BandId;

                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Size,Quantity,BandId,SoldQuantity,Price,TotalSold,QuantityIncoming,OrderedYTD")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var mgr = db.Managers.Where(a => a.ManagerID == userID).Single();
                inventory.BandId = mgr.BandId;

                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
