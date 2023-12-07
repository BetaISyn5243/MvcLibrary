using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcLibrary.Controllers
{
    [RoutePrefix("Student")]
    public class MessageController : Controller
    {
        DBLIBRARYEntities1 db = new DBLIBRARYEntities1();
        [Authorize]

        [Route("Message")]
        // GET: Message
        public ActionResult Index()
        {
            String membersMail = Session["Mail"].ToString();
            var values = db.TBLMESSAGES.Where(x => x.SENDER == membersMail).ToList();
            return View(values);
        }
        [HttpGet]
        [Route("Message/Send")]
        // GET: Message
        public ActionResult Send()
        {
            return View();
        }
        // GET: Message
        [HttpPost]
        [Route("Message/Send")]

        public ActionResult Send(TBLMESSAGE p)
        {
            p.SENDER = Session["Mail"].ToString();
            p.DATE = DateTime.Now;
            db.TBLMESSAGES.Add(p);
            db.SaveChanges();
            return RedirectToAction("Sended");
        }
        [Route("Message/Sended")]

        public ActionResult Sended()
        {
            String memberMail = Session["Mail"].ToString();
            var values = db.TBLMESSAGES.Where(x => x.RECEIVER == memberMail).ToList();

            return View(values);
        }
    }
}