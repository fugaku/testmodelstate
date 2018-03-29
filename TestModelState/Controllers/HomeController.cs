using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestModelState.Models;

namespace TestModelState.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [ImportModelState]
        public ActionResult Index()
        {
            MyModel model = new MyModel();
            return View(model);
        }

        [HttpPost]
        [ExportModelState]
        public ActionResult Index(MyModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Success", new { start = model.StartDate, end = model.EndDate });
            }
        }

        [HttpGet]
        public ActionResult Success(DateTime? start, DateTime? end)
        {
            var model = new MyModel
            {
                StartDate = start,
                EndDate = end
            };
            return View(model);
        }
    }
}
