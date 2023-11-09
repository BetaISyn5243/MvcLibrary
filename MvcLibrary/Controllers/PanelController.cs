using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    public class PanelController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();

        // GET: Panel
        [Authorize]

        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var values = db.TBLMEMBERS.FirstOrDefault(y => y.MAIL == mail);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePassword(TBLMEMBER p)
        {
            var mail = (string)Session["Mail"];

            var values = db.TBLMEMBERS.FirstOrDefault(y => y.MAIL == mail);
            values.PASSWORD = p.PASSWORD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooks()
        {
            var member = Session["Mail"];
            var id = db.TBLMEMBERS.Where(x => x.MAIL == member.ToString()).Select(z => z.ID).FirstOrDefault();
            var values = db.TBLACTIONs.Where(x => x.MEMBER == id).ToList();
            return View(values);
        }
        public ActionResult Announcement()
        {
            var announcementList = db.TBLANNOUNCEMENTS.ToList();

            return View(announcementList);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Auth");
        }

    }
}