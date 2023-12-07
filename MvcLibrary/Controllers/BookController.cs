using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Admin.Controllers
{
    [RoutePrefix("Admin")]
    public class BookController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [Authorize]

        [Route("Book")]
        public ActionResult Index(string p)
        {
            var books = from k in db.TBLBOOKs select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.NAME.Contains(p));
            }
            return View(books.Where(b=>b.ISDELETED==false).ToList());
        }

        [HttpGet]
        [Route("Book/AddBook")]

        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORies.ToList() select new SelectListItem { Text = i.NAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHORs.ToList() select new SelectListItem { Text = i.NAME+" "+i.SURNAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val2 = value2;
            return View();
        }

        [HttpPost]
        [Route("Book/AddBook")]

        public ActionResult AddBook(TBLBOOK p)
        {
            p.ISDELETED = false;
            p.TBLCATEGORY = db.TBLCATEGORies.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            p.TBLAUTHOR = db.TBLAUTHORs.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.STATUS = true;
            db.TBLBOOKs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Book/DeleteBook/{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = db.TBLBOOKs.Find(id);
            book.ISDELETED = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Book/GetBook/{id}")]
        public ActionResult GetBook(int id)
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORies.ToList() select new SelectListItem { Text = i.NAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHORs.ToList() select new SelectListItem { Text = i.NAME + " " + i.SURNAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val2 = value2;
            var book = db.TBLBOOKs.Find(id);
            return View("GetBook", book);
        }
        [Route("Book/UpdateBook/{id}")]

        public ActionResult UpdateBook(TBLBOOK p)
        {
            var book = db.TBLBOOKs.Find(p.ID);
            book.NAME = p.NAME;
            book.TBLAUTHOR = db.TBLAUTHORs.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            book.TBLCATEGORY = db.TBLCATEGORies.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            book.PUBLICATIONYEAR = p.PUBLICATIONYEAR;
            book.PRINTINGHOUSE = p.PRINTINGHOUSE;
            book.STATUS = p.STATUS;
            book.PAGE = p.PAGE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}