using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        public ActionResult Index(string p)
        {
            var books = from k in db.TBLBOOK select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.NAME.Contains(p));
            }
            return View(books.Where(b=>b.ISDELETED==false).ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList() select new SelectListItem { Text = i.NAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList() select new SelectListItem { Text = i.NAME+" "+i.SURNAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val2 = value2;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(TBLBOOK p)
        {
            p.ISDELETED = false;
            p.TBLCATEGORY = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            p.TBLAUTHOR = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.STATUS = true;
            db.TBLBOOK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            book.ISDELETED = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBook(int id)
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList() select new SelectListItem { Text = i.NAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList() select new SelectListItem { Text = i.NAME + " " + i.SURNAME, Value = i.ID.ToString() }).ToList();
            ViewBag.val2 = value2;
            var book = db.TBLBOOK.Find(id);
            return View("GetBook", book);
        }
        public ActionResult UpdateBook(TBLBOOK p)
        {
            var book = db.TBLBOOK.Find(p.ID);
            book.NAME = p.NAME;
            book.TBLAUTHOR = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            book.TBLCATEGORY = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            book.PUBLICATIONYEAR = p.PUBLICATIONYEAR;
            book.PRINTINGHOUSE = p.PRINTINGHOUSE;
            book.STATUS = p.STATUS;
            book.PAGE = p.PAGE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}