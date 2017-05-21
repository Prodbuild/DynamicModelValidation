using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicModelValidation.Models;

namespace DynamicModelValidation.Controllers
{
    public class DynamicModelSampleController : Controller
    {
        // GET: DynamicModelSample
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student insStudent)
        {
            if (ModelState.IsValid)
            {
                return new EmptyResult();
            }

            return View(insStudent);
        }
    }
}