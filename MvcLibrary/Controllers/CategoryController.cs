using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Catergory
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1 ();
        public ActionResult Index()
        {
            var values = db.TBLCATEGORY.Where(c=>c.ISDELETED ==false).ToList ();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddCategory(TBLCATEGORY p)
        {
            p.ISDELETED = false;
            db.TBLCATEGORY.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        public ActionResult UpdateCategory(TBLCATEGORY p)
        {

            var category = db.TBLCATEGORY.Find(p.ID);
            category.NAME = p.NAME;
            db.SaveChanges ();
            return RedirectToAction("Index");

        }
        public ActionResult GetCategory(int id)
        {

            var category = db.TBLCATEGORY.Find(id);
            return View("GetCategory", category);

        }

        public ActionResult DeleteCategory(int id)
        {
            var category = db.TBLCATEGORY.Find(id);
            category.ISDELETED = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}   