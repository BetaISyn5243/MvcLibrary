using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    [RoutePrefix("Admin")]
    public class CategoryController : Controller
    {
        // GET: Catergory
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1 ();
        [Authorize]

        [Authorize]
        [Route("Category")]
        public ActionResult Index()
        {
            var values = db.TBLCATEGORies.Where(c=>c.ISDELETED ==false).ToList ();
            return View(values);
        }

        [HttpPost]
        [Route("Category/AddCategory")]
        public ActionResult AddCategory(TBLCATEGORY p)
        {
            p.ISDELETED = false;
            db.TBLCATEGORies.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Category/AddCategory")]


        public ActionResult AddCategory()
        {
            return View();
        }
        [Route("Category/UpdateCategory")]

        public ActionResult UpdateCategory(TBLCATEGORY p)
        {

            var category = db.TBLCATEGORies.Find(p.ID);
            category.NAME = p.NAME;
            db.SaveChanges ();
            return RedirectToAction("Index");

        }
        [Route("Category/GetCategory/{id}")]

        public ActionResult GetCategory(int id)
        {

            var category = db.TBLCATEGORies.Find(id);
            return View("GetCategory", category);

        }
        
        [Route("Category/DeleteCategory/{id}")]

        public ActionResult DeleteCategory(int id)
        {
            var category = db.TBLCATEGORies.Find(id);
            category.ISDELETED = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}   