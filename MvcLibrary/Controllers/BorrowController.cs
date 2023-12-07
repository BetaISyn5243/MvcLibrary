using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    [RoutePrefix("Admin")]

    public class BorrowController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [Authorize]
        [Route("Borrow")]

        // GET: Borrow
        public ActionResult Index()
        {

            var values = db.TBLACTIONs.Where(x=>!x.ISCOMPLATED.Value).ToList();
            return View(values);
        }
        [HttpGet]
        [Route("Borrow/Borrow")]
        public ActionResult Borrow()
        {
            ViewBag.memberList =  ( from x in db.TBLMEMBERS.ToList() select new SelectListItem { Text= x.NAME+" "+x.SURNAME ,Value= x.ID.ToString() }).ToList();
            ViewBag.bookList = (from x in db.TBLBOOKs.Where(b=>b.ISDELETED==false).Where(b=>b.STATUS==true).ToList() select new SelectListItem { Text= x.NAME ,Value= x.ID.ToString() }).ToList();
            ViewBag.staffList = ( from x in db.TBLSTAFFs.ToList() select new SelectListItem { Text= x.STAFF ,Value= x.ID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        [Route("Borrow/Borrow")]
        public ActionResult Borrow(TBLACTION p)
        {
            if (db.TBLBOOKs.Find(p.BOOK).STATUS == true) return View();
            p.ISCOMPLATED = false;
            db.TBLBOOKs.Find(p.BOOK).STATUS = false;
            db.TBLACTIONs.Add(p);
            db.SaveChanges();
            return View();
        }
        [Route("Borrow/Borrowed")]

        public ActionResult Borrowed()
        {
            var values = db.TBLACTIONs.ToList();
            return View(values);
        }
        [HttpGet]
        [Route("Borrow/Return/{id}")]
        public ActionResult Return(
            int id)
        {   
            var values = db.TBLACTIONs.Find(id);
            return View(values);
        }
        [HttpPost]
        [Route("Borrow/Return")]
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