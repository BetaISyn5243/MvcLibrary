using MvcLibrary.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();

        public ActionResult Index(string p,int page=1)
        {
            var member = from k in db.TBLMEMBERS select k;
            if (!string.IsNullOrEmpty(p))
            {
                member = member.Where(m => m.NAME.Contains(p));
                ViewBag.p= p;
            }

            return View(member.ToList().ToPagedList(page,3));
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(TBLMEMBER p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMember(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            db.TBLMEMBERS.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetMember(int id)
        {

            var member = db.TBLMEMBERS.Find(id);
            return View("GetMember", member);
        }
        public ActionResult UpdateMember(TBLMEMBER p)
        {
            var member = db.TBLMEMBERS.Find(p.ID);
            member.NAME = p.NAME;
            member.USERNAME = p.USERNAME;
            member.MAIL = p.MAIL;
            member.USERNAME = p.USERNAME;
            member.PASSWORD = p.PASSWORD;
            member.PHOTO = p.PHOTO;
            member.PHONE = p.PHONE;
            member.SCHOOL = p.SCHOOL;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}