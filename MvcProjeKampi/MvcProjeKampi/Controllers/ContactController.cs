using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context _Context = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList().OrderByDescending(X=>X.ContactDate).ToList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactPartial()
        {
            var receiverMail = _Context.Messages.Where(x =>x.MessageReadStatus == true).Count(x => x.ReceiverMail == "Serkanblk3452@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;
            var senderMail = _Context.Messages.Where(x => x.MessageReadStatus == true).Count(x => x.SenderMail == "Serkanblk3452@gmail.com").ToString();
            ViewBag.senderMail = senderMail;

            var contact = _Context.Contacts.Where(x=>x.ReadStatus==true).Count().ToString();
            ViewBag.contact = contact;
            return PartialView();
        }
        public ActionResult ContactUpdate(int id)
        {
            var contactvalue = cm.GetByID(id);
            if (contactvalue.ReadStatus == true)
            {
                contactvalue.ReadStatus = false;
            }
            cm.ContactUpdate(contactvalue);
            return RedirectToAction("/GetContactDetails/" + id);
        }
    }
}