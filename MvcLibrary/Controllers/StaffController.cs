using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    [RoutePrefix("Admin")]
    public class StaffController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1 ();
        [Authorize]

        // GET: Staff
        [Route("Staff")]
        public ActionResult Index()
        {
            var values = db.TBLSTAFFs.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("Staff/AddStaff")]

        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        [Route("Staff/AddStaff")]
        public ActionResult AddStaff(TBLSTAFF p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaff");
            }
            db.TBLSTAFFs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Staff/DeleteStaff/{id}")]

        public ActionResult DeleteStaff(int id)
        {
            var staff = db.TBLSTAFFs.Find(id);
            db.TBLSTAFFs.Remove(staff);
            staff.ISDELETED = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Staff/GetStaff/{id}")]

        public ActionResult GetStaff(int id)
        {

            var staff = db.TBLSTAFFs.Find(id);
            return View("GetStaff", staff);
        }
        [Route("Staff/UpdateStaff")]

        public ActionResult UpdateStaff(TBLSTAFF p)
        {
            var staff = db.TBLSTAFFs.Find(p.ID);
            staff.STAFF = p.STAFF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}