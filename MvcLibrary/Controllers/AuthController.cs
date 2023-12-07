using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        //public ActionResult Index()
        //{
        //    return View();
        //}

       DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLMEMBER p)
        {   
            var values = db.TBLMEMBERS.FirstOrDefault(x=>(x.MAIL ==p.MAIL)&&x.PASSWORD==p.PASSWORD);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MAIL, false);
                Session["Mail"] = values.MAIL.ToString();
                //TempData["ID"] = values.ID.ToString();
                //TempData["NAME"] = values.NAME.ToString();
                //TempData["SURNAME"] = values.SURNAME.ToString();
                //TempData["USERNAME"] = values.USERNAME.ToString();
                //TempData["PASSWORD"] = values.PASSWORD.ToString();
                //TempData["PHOTO"] = values.PHOTO.ToString();
                //TempData["SCHOOL"] = values.SCHOOL.ToString();
                if(values.ISADMIN != null && (bool)values.ISADMIN) return RedirectToAction("Index", "Admin/Home");
                return RedirectToAction("Index","Student/Panel");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TBLMEMBER p)
        {
            p.ISADMIN = false;
            p.PHOTO = "";
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Login", "Auth");

        }
    }
}