using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class BorrowController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();

        // GET: Borrow
        public ActionResult Index()
        {

            var values = db.TBLACTIONs.Where(x=>!x.ISCOMPLATED.Value).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Borrow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Borrow(
            TBLACTION p)
        {
            if (db.TBLBOOKs.Find(p.BOOK).STATUS == false) return View();
            p.ISCOMPLATED = false;
            db.TBLBOOKs.Find(p.BOOK).STATUS = false;
            db.TBLACTIONs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Borrowed()
        {
            var values = db.TBLACTIONs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Return(
            int id)
        {   
            var values = db.TBLACTIONs.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Return(
            TBLACTION b)
        {
            var action = db.TBLACTIONs.Find(b.ID);
            action.TBLBOOK.STATUS = true;
            action.RETURNDATE = b.RETURNDATE;
            action.ISCOMPLATED= true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}