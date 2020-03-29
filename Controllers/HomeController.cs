using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

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
            //model.DisplayAllValues();

            model.createURLend();
	        GoogleScrap(model);
            //HTMLDoc_RssFinder("https://affluentblacksofdallas.com/education/college-scholarships/");


            // Create an instance of the Python engine.
            //var pythonEngine = Python.CreateEngine();


            //string path = @"..\ChandlerSpeaks\Lib\site-packages";

            //var paths = pythonEngine.GetSearchPaths();
            //paths.Add(path);
            //pythonEngine.SetSearchPaths(paths);





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

        
	    public void GoogleScrap(FilterModel model){
          
		    //var starturl = "https://tipidpc.com/catalog.php?cat=0&sec=s";
            //var starturl = "https://www.google.com/search?rlz=1C1AVFC_enUS767US767&sxsrf=ALeKk03LDTXH_tYzqxYh1zlQj06FFmLmcg%3A1584489656289&ei=uGRxXqmmEYOGsAWr55mIAQ&q=501c3+grants+in+texas&oq=501c3+grants+in+texas&gs_l=psy-ab.3..33i299.4233.5674..5827...0.2..0.89.680.9......0....1..gws-wiz.......0i71j35i39j0j0i22i30j38j33i22i29i30.UOY7E93wTIs&ved=0ahUKEwip4vP426LoAhUDA6wKHatzBhEQ4dUDCAs&uact=5";
        
            var starturl="http://www.google.com/search?q=grants+for+"+model.endURL;
           
        	var webGet = new HtmlWeb();

        	if (webGet.Load(starturl) is HtmlDocument document)
        	{   
            		//var nodes = document.DocumentNode.CssSelect("#item-search-results li").ToList();  
            		
                    var nodes = document.DocumentNode.CssSelect("#rso .g").ToList();
                    Console.WriteLine(nodes.Count());

                    foreach (var node in nodes)
            		{
                        //Console.WriteLine("URL: " + node.CssSelect("h2 a").Single().GetAttributeValue("href"));

                        String s = node.CssSelect(".rc .r a").Single().GetAttributeValue("href");

                        
                        //Console.WriteLine("----"); 
                		//Console.WriteLine("URL: " + node.CssSelect(".rc .r a").Single().GetAttributeValue("href"));
                        
                        //Console.WriteLine("Link sent: "+s);
                        HTMLDoc_RssFinder(s);
                        
                		
            		}
        	}
        	
	    }

        //search collected links for RSS
        public void HTMLDoc_RssFinder(String url){
            var webGet = new HtmlWeb();

            try{

                if (webGet.Load(url) is HtmlDocument document){
                    
                    foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]")){
                        //var RSS_link = doc.DocumentNode.SelectSingleNode("//a[text()='RSS']").Attributes["href"].Value;
                        
                        String href= link.GetAttributeValue("href");

                        if (href.Contains("http") && (href.Contains("rss") || href.Contains("feed"))){                //if link has has rss or feed in it return it
                            Console.WriteLine("URL: "+ href);
                        }
                    }
                }
            }
            catch(Exception E){
                Console.WriteLine(E);
            }
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
