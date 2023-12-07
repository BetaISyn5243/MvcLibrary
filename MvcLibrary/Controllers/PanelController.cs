using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    [RoutePrefix("Student")]
    public class PanelController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [Authorize]
        // GET: Panel
        [Route("Panel")]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var values = db.TBLMEMBERS.FirstOrDefault(y => y.MAIL == mail);
            return View(values);
        }
        [HttpPost]
        [Route("Panel/UpdatePassword")]

        public ActionResult UpdatePassword(TBLMEMBER p)
        {
            var mail = (string)Session["Mail"];

            var values = db.TBLMEMBERS.FirstOrDefault(y => y.MAIL == mail);
            values.PASSWORD = p.PASSWORD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Panel/MyBooks")]

        public ActionResult MyBooks()
        {
            var member = Session["Mail"];
            var id = db.TBLMEMBERS.Where(x => x.MAIL == member.ToString()).Select(z => z.ID).FirstOrDefault();
            var values = db.TBLACTIONs.Where(x => x.MEMBER == id).ToList();
            return View(values);
        }
        [Route("Panel/Announcement")]

        public ActionResult Announcement()
        {
            var announcementList = db.TBLANNOUNCEMENTS.ToList();

            return View(announcementList);
        }
       

    }
}