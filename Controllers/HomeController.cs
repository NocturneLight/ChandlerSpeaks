using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;
using IronPython.Hosting;

namespace ChandlerSpeaks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Create functions here.
        [HttpPost]
        public IActionResult Index(FormModel model)
        {
            // Create an instance of the Python engine.
            var pythonEngine = Python.CreateEngine();

            // Create an instance of the scope.
            var pythonScope = pythonEngine.CreateScope();

            // Compile and execute the Python program.
            var pythonScript = pythonEngine.CreateScriptSourceFromFile("HelloWorld.py").Compile().Execute(pythonScope);

            // Retrieve the Python program's dictionary from the scope instance.
            IronPython.Runtime.PythonDictionary diction = pythonScope.GetVariable("stringList");

            // Display the dictionary's contents.
            foreach (var item in diction)
            {
                Debug.WriteLine(item.Key + " : " + item.Value);
            }
            

            
            
            /*
            foreach (var item in model.CompanyAge)
            {
                Debug.WriteLine(item);
            }
            */
            
            

            
            


            //return Content("Hi! The size is: ");
            return View("Index");
        }
        

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

    public class FormModel
    {
        // Create variables for storing each section's choice's truth values.
        public List<bool> CompanyAge {get; set;}
        public List<bool> GrantType {get; set;}
        public List<bool> Location {get; set;}
        public List<bool> Race {get; set;}
        public List<bool> ReligiousAffiliation {get; set;}
        public List<bool> ReligiousIdentification {get; set;}
        public List<bool> DueDates {get; set;}
    }
}
