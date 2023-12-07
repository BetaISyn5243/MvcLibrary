using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1 ();
        public ActionResult Index()
        {
            var values = db.TBLANNOUNCEMENTS.ToList ();
            return View(values);
        }
        public ActionResult NewAnnouncements(TBLANNOUNCEMENT p)
        {
            db.TBLANNOUNCEMENTS.Add (p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncements(int id)
        {
            var announcement = db.TBLANNOUNCEMENTS.Find(id);
            db.TBLANNOUNCEMENTS.Remove(announcement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailAnnouncements(TBLANNOUNCEMENT p)
        {

            var values = db.TBLANNOUNCEMENTS.Find(p.ID);
            return View("DetailAnnouncements", values);
        }
        public ActionResult UpdateAnnouncements(TBLANNOUNCEMENT p)
        {
            var values = db.TBLANNOUNCEMENTS.Find(p.ID);
            values.CATEGORY = p.CATEGORY;
            values.CONTENTS = p.CONTENTS;
            values.DATE = p.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }

}