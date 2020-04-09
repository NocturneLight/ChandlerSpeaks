using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;

namespace ChandlerSpeaks.Controllers
{
    // Create variables here.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Create functions here.
        [HttpPost]
        public IActionResult Index(FilterModel model)
        {
            List<string> testList = new List<string>() {"This", "is", "a", "test."};

            ViewData["Test"] = testList;

            model.DisplayAllValues();


            //return Content("Hi! The size is: ");
            return View("Index");
        }

        

        // Prebuilt functions.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
