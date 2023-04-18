using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        Context Context = new Context(); 
        public ActionResult HeadingPieChart()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> categoryCharts = new List<CategoryClass>();
            using (var context = new Context())
            {
                categoryCharts = context.Categories.Select(c => new CategoryClass
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }

            return categoryCharts;
        }
    }
}