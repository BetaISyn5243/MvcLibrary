using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult UpdatePassword(TBLMEMBER p)
        {
            var mail = (string)Session["Mail"];

            var values = db.TBLMEMBERS.FirstOrDefault( y => y.MAIL == mail);
            values.PASSWORD = p.PASSWORD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}