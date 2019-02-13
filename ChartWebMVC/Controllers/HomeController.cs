using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChartWebMVC.Models;

namespace ChartWebMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DataPoints = DataService.GetValues();
            return View();
        }

        //[HttpPost, Route("values")]
        //public ActionResult SetPoints([FromBody] ChartData values)
        //{
        //    DataService.DefineFunction(values);
        //    return NoContent();

        //}

        [HttpPost, Route("values")]
        public ActionResult Index(int higherCoef, int lowerCoef, int freeCoef, int minRange, int maxRange)
        {
            DataService.DefineFunction(higherCoef, lowerCoef, freeCoef, minRange, maxRange);
            return (ActionResult)Index();

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
