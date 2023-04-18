using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                adminmanager.adminAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult AdminDelete(int id)
        {
            var adminyvalue = adminmanager.GetByID(id);
            adminmanager.adminDelete(adminyvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminyvalue = adminmanager.GetByID(id);
            return View(adminyvalue);

        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            p.Status = true;
            adminmanager.adminUpdate(p);
            return RedirectToAction("Index");

        }
        public ActionResult statusAdmin(int id)
        {
            var Adminvalue = adminmanager.GetByID(id);
            if (Adminvalue.Status == false)
            {
                Adminvalue.Status = true;
            }
            else
            {
                Adminvalue.Status = false;
            }
            adminmanager.adminUpdate(Adminvalue);
            return RedirectToAction("Index");
        }
    }
}