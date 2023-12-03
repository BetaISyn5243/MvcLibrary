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

            var values = db.TBLACTION.Where(x=>!x.ISCOMPLATED.Value).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Borrow()
        {
            ViewBag.memberList =  ( from x in db.TBLMEMBERS.ToList() select new SelectListItem { Text= x.NAME+" "+x.SURNAME ,Value= x.ID.ToString() }).ToList();
            ViewBag.bookList = (from x in db.TBLBOOK.Where(b=>b.ISDELETED==false).Where(b=>b.STATUS==true).ToList() select new SelectListItem { Text= x.NAME ,Value= x.ID.ToString() }).ToList();
            ViewBag.staffList = ( from x in db.TBLSTAFF.ToList() select new SelectListItem { Text= x.STAFF ,Value= x.ID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Borrow(
            TBLACTION p)
        {
            if (db.TBLBOOK.Find(p.BOOK).STATUS == false) return View();
            p.ISCOMPLATED = false;
            db.TBLBOOK.Find(p.BOOK).STATUS = false;
            db.TBLACTION.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Borrowed()
        {
            var values = db.TBLACTION.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Return(
            int id)
        {   
            var values = db.TBLACTION.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Return(
            TBLACTION b)
        {
            var action = db.TBLACTION.Find(b.ID);
            action.TBLBOOK.STATUS = true;
            action.RETURNDATE = b.RETURNDATE;
            action.ISCOMPLATED= true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}