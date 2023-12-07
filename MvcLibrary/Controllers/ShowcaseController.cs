using MvcLibrary.Models.Classes;
using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class ShowcaseController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        // GET: Showcase
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLBOOKs.ToList();
            cs.Deger2 = db.TBLABOUTs.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLCONTACT p)
        {
           
            db.TBLCONTACTs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}