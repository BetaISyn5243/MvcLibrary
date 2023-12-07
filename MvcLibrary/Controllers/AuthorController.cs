using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    [RoutePrefix("Admin")]

    public class AuthorController : Controller
    {
        // GET: Author
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [Authorize]
        [Route("Author")]

        public ActionResult Index()
        {
            var values = db.TBLAUTHORs.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("Author/AddAuthor")]

        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("Author/AddAuthor")]

        public ActionResult AddAuthor(TBLAUTHOR p)
        {
            db.TBLAUTHORs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Author/DeleteBook/{id}")]

        public ActionResult DeleteAuthor(int id)
        {
            var author = db.TBLAUTHORs.Find(id);
            db.TBLAUTHORs.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Author/GetAuthor/{id}")]

        public ActionResult GetAuthor(int id) {

            var author = db.TBLAUTHORs.Find(id);
            return View("GetAuthor",author);
        }
        [Route("Author/GetAuthorsBooks/{id}")]

        public ActionResult GetAuthorsBooks(int id) {

            ViewBag.y1 = db.TBLAUTHORs.Find(id).NAME+" "+ db.TBLAUTHORs.Find(id).SURNAME;
            var values = db.TBLBOOKs.Where(b=>b.ISDELETED==false).Where(b => b.TBLAUTHOR.ID == id).ToList();
            return View(values);
        }
        [Route("Author/UpdateAuthor")]

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