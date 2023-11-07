using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        public ActionResult Index()
        {
            ViewBag.dgr1 = db.TBLMEMBERS.Count();
            ViewBag.dgr2 = db.TBLBOOKs.Count();
            ViewBag.dgr3 = db.TBLBOOKs.Where(x => x.STATUS==false).Count();
            ViewBag.dgr4 = db.TBLPENALTies.Sum(x=>x.MONEY);
            return View();
        }
        public ActionResult Weather() { return View(); }
        public ActionResult WeatherCarts() {  return View(); }
        public ActionResult Gallery() {  return View(); }   
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file) {
            if (file == null) { string filepath = Path.Combine(Server.MapPath("~/web2/resimler"),Path.GetFileName(file.FileName)); file.SaveAs(filepath); return RedirectToAction("Gallery"); }
            
            return View(); }
    }
}