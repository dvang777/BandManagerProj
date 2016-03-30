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
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userid).Single();
            var con = db.Contact.Where(b => b.ManagerID == mgr.ManagerID);

            return View(con.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Address,City,ZipCode,PhoneNumber,ManagerID,Notes")] Contacts contacts)
        {
            var userid = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userid).Single();
            var con = db.Contact.Where(b => b.ManagerID == mgr.ManagerID);
            contacts.ManagerID = mgr.ManagerID;

            if (ModelState.IsValid)
            {
                db.Contact.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            var userid = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userid).Single();
            var con = db.Contact.Where(b => b.ManagerID == mgr.ManagerID);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Address,City,ZipCode,PhoneNumber,ManagerID,Notes")] Contacts contacts)
        {
            var userid = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userid).Single();
            var con = db.Contact.Where(b => b.ManagerID == mgr.ManagerID);

            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contact.Find(id);
            db.Contact.Remove(contacts);
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
