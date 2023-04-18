using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        Context _Context = new Context();
        MessageManager mm = new MessageManager(new EfMessageDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Inbox()
        {
            string Mail = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(Mail).OrderByDescending(X => X.MessageDate).ToList();
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string Mail = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(Mail).OrderByDescending(X => X.MessageDate).ToList();
            return View(messagelist);
        }
        public ActionResult GetInbox(int id)
        {
            var messagelist = mm.GetByID(id);
            return View(messagelist);

        }
        public ActionResult GetSendbox(int id)
        {
            var messagelist = mm.GetByID(id);
            return View(messagelist);
        }
        public ActionResult NewMessage(Message p)
        {
            MessageValidator messagevalidator = new MessageValidator();
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = (string)Session["WriterMail"].ToString();
                p.MessageReadStatus = true;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MessageDelete(int id)
        {
            var Messagevalue = mm.GetByID(id);
            if (Messagevalue.MessageReadStatus == true) 
            {
                Messagevalue.MessageReadStatus = false;
            }
            mm.MessageDelete(Messagevalue);
            return RedirectToAction("/GetInbox/" + id);
        }
        public PartialViewResult MessagePartial()
        {
            var mail = (string)Session["WriterMail"].ToString();
            var receiverMail = _Context.Messages.Where(x => x.MessageReadStatus == true).Count(x => x.ReceiverMail == mail.ToString()).ToString();
            ViewBag.receiverMail = receiverMail;
            var senderMail = _Context.Messages.Where(x => x.MessageReadStatus == true).Count(x => x.SenderMail == mail.ToString()).ToString();
            ViewBag.senderMail = senderMail;
            return PartialView();
        }
    }
}