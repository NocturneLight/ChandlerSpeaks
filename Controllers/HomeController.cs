using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;
//using IronPython.Hosting;

namespace ChandlerSpeaks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Create variables here.
        //dynamic testVariable;

        // Create functions here.
        [HttpPost]
        public IActionResult Index(FilterModel model)
        {
            model.DisplayAllValues();

            // Create an instance of the Python engine.
            //var pythonEngine = Python.CreateEngine();

            // Create an instance of the scope.
            //var pythonScope = pythonEngine.CreateScope();

            // Create an instance of an operation.
            //var operation = pythonEngine.Operations;

            // Compile and execute the Python program.
            //var pythonScript = pythonEngine.CreateScriptSourceFromFile("HelloWorld.py").Compile().Execute(pythonScope);
            //var pythonScript = pythonEngine.ExecuteFile("HelloWorld.py", pythonScope);

            // Retrieve the Python program's list from the scope instance.
            //IronPython.Runtime.List pythonList = pythonScope.GetVariable("testDiction");
            
            // Retrieve an instance of the object.
            //object foobarTest = pythonScope.GetVariable("fooTest");

            //Func<string> sayHello = pythonEngine.Operations.GetMember<Func<string>>(foobarTest, "f");
            //Func<int> sayAge = pythonEngine.Operations.GetMember<Func<int>>(foobarTest, "getAge");
            //Func<List<string>> Hi = pythonEngine.Operations.GetMember<Func<List<string>>>(foobarTest, "");

            //string result = sayHello();
            //int age = sayAge();

            //Debug.WriteLine(result);
            //Debug.WriteLine(age);    

            /*
            foreach (var item in model.CompanyAge)
            {
                Debug.WriteLine(item);
            }
            */

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
