using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Azure_Cloud_Service_Calculator.Models;

namespace Azure_Cloud_Service_Calculator.Controllers
{
    public class AzureServiceCalculatorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.InstanceSize = new SelectList(AzureServiceCalculator.InstanceSizeDescriptions);
            return View(new AzureServiceCalculator() { NoOfInstances = 2 });
        }


        [HttpPost]
        public ActionResult Calculate(AzureServiceCalculator service)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", service);
            }
            else
            {
                ViewBag.InstanceSize = new SelectList(AzureServiceCalculator.InstanceSizeDescriptions);
                return View(service);
            }
        }


        public ActionResult Confirm(AzureServiceCalculator service)
        {
            return View(service);
        }
        
    }
}
