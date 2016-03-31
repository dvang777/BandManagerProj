using BandManager.Models;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using BandManager.CustomFilters;

namespace BandManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            int[] test = { 3, 5, 6, 7, 8, 10, 11 };

            ViewBag.intArray = test;

            return View();
        }

        [AuthLog (Roles = "Manager")]
        public ActionResult DashBoard()
        {
            var quantity = db.Inventories.Select(x => x.SoldQuantity).ToArray();
            var invent = db.Inventories.Select(z => z.Name).ToList();
            var Isold = db.Inventories.Select(a => a.TotalSold).ToArray();
            var ord = db.Inventories.Select(b => b.QuantityIncoming).ToArray();

            ViewBag.InvSoldArray = Isold;
            ViewBag.QuantityArray = quantity;
            ViewBag.InventArray = invent;
            ViewBag.OrdArray = ord;

            var Sold = db.Events.Select(a => a.TotalItemSold).ToArray();
            var rev = db.Events.Select(b => b.TotalRevenue).ToArray();
            var Evt = db.Events.Select(c => c.Name).ToList();
            var att = db.Events.Select(d => d.Attendance).ToArray();

            ViewBag.SoldArray = Sold;
            ViewBag.RevArray = rev;
            ViewBag.EvtArray = Evt;
            ViewBag.AttArray = att;
            return View();
        }

        [AuthLog(Roles = "Manager")]
        public ActionResult Calendar()
        {
           // Appointment appt = new Appointment();
           // var userID = User.Identity.GetUserId();
            //var mgr = db.Managers.Where(a=> a.ManagerID == userID).Select(a => a).Single();
            //var appts = db.Appointments.Where(b => b.ManagerID == mgr.ManagerID).Select(b => b);
            //appt.ManagerID = mgr.ManagerID;
            

            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 1;
            scheduler.Config.last_hour = 24;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var apps = db.Appointments.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            Appointment appt = new Appointment();
            var userID = User.Identity.GetUserId();
            var mgr = db.Managers.Where(a => a.ManagerID == userID).Select(a => a).Single();
            var appts = db.Appointments.Where(b => b.ManagerID == mgr.ManagerID).Select(b => b);


            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Appointment>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        
                        db.Appointments.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        appt.ManagerID = mgr.ManagerID;
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:
                        appt.ManagerID = mgr.ManagerID;
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}