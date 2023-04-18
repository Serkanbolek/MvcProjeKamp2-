using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Inbox()
        {
            var messagelist = mm.ListInbox();
            return View(messagelist);
        }
        public ActionResult GetInbox(int id)
        {
            var messagelist = mm.GetByID(id);
            return View(messagelist);

        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.ListSendbox();
            return View(messagelist);
        }public ActionResult GetSendbox(int id)
        {
            var messagelist = mm.GetByID(id);
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            MessageValidator messagevalidator = new MessageValidator();
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
            if (Messagevalue.MessageReadStatus == false)
            {
            }
            else
            {
                Messagevalue.MessageReadStatus = false;
            }
            mm.MessageDelete(Messagevalue);
            return RedirectToAction("/GetInbox/"+id);
        }
    }
}