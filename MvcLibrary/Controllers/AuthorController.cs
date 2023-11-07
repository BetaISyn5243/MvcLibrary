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
            var values = db.TBLAUTHORs.ToList();
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
            db.TBLAUTHORs.Add(p);
            db.SaveChanges();
            return View();
        }   
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.TBLAUTHORs.Find(id);
            db.TBLAUTHORs.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAuthor(int id) {

            var author = db.TBLAUTHORs.Find(id);
            return View("GetAuthor",author);
        }
        public ActionResult UpdateAuthor(TBLAUTHOR p) {
            var author = db.TBLAUTHORs.Find(p.ID);
            author.NAME = p.NAME;
            author.SURNAME = p.SURNAME;
            author.DETAIL = p.DETAIL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}