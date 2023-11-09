using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class MessageController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        // GET: Message
        public ActionResult Index()
        {
            var values = db.TBLMESSAGES.ToList();
            return View(values);
        }
        [HttpGet]

        // GET: Message
        public ActionResult Send()
        {
            return View();
        }
        // GET: Message
  
        [HttpPost]
        public ActionResult Send(TBLMESSAGE p)
        {
            p.SENDER = Session["Mail"].ToString();
            p.DATE = DateTime.Now;
            db.TBLMESSAGES.Add(p);
            db.SaveChanges();
            return RedirectToAction("Sended");
        }
        public ActionResult Sended()
        {
            String memberMail = Session["Mail"].ToString();
            var values = db.TBLMESSAGES.Where(x => x.RECEIVER == memberMail).ToList();

            return View(values);
        }
    }
}