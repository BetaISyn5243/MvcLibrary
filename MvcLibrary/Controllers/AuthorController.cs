using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        public ActionResult Index()
        {
            var values = db.TBLAUTHOR.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(TBLAUTHOR p)
        {
            db.TBLAUTHOR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.TBLAUTHOR.Find(id);
            db.TBLAUTHOR.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAuthor(int id) {

            var author = db.TBLAUTHOR.Find(id);
            return View("GetAuthor",author);
        }
        public ActionResult GetAuthorsBooks(int id) {

            ViewBag.y1 = db.TBLAUTHOR.Find(id).NAME+" "+ db.TBLAUTHOR.Find(id).SURNAME;
            var values = db.TBLBOOK.Where(b=>b.ISDELETED==false).Where(b => b.TBLAUTHOR.ID == id).ToList();
            return View(values);
        }
        public ActionResult UpdateAuthor(TBLAUTHOR p) {
            var author = db.TBLAUTHOR.Find(p.ID);
            author.NAME = p.NAME;
            author.SURNAME = p.SURNAME;
            author.DETAIL = p.DETAIL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}