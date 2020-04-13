using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
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

            //Test Scrapers seperately 
            //HTMLDoc_RssFinder("https://www.studentdebtrelief.us/scholarships/scholarships-grants-african-american-students/");
            //HTMLDoc_SourceSearcher("https://www.studentdebtrelief.us/scholarships/scholarships-grants-african-american-students/", model);

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

        
	    public List<Grant> GoogleScrap(FilterModel model){
        
            var starturl="http://www.google.com/search?q=\"grants\"+for+"+model.endURL+"&num=100";
            var webGet = new HtmlWeb();
            //Jesse'sCode///////////////////////////////////////
            List<Grant> grantsList = new List<Grant>(GrantsGovRSSGet.GetGrantGovList());

            //End Jesse's Code//////////////////////////////////
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
                            
                            //HTMLDoc_RssFinder(s);    //uncomment to run rss finder
                            
                            HTMLDoc_SourceSearcher(s, model);   //looks through source of each link for info on grants
                            
                        }
                }
            foreach(Grant grant in grantsList) {
                Console.WriteLine(grant.Title);
            }
            return grantsList;
        }

        //search collected links for RSS
        public void HTMLDoc_RssFinder(String url){
            var webGet = new HtmlWeb();

            try{

                if (webGet.Load(url) is HtmlDocument document){
                    
                    foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//a[@href] | //link[@href]")){
                        
                        String href= link.GetAttributeValue("href");

                        if (href.Contains(".") && !href.Contains("comments") && !href.Contains("feedback") && !href.Contains("facebook") && (href.Contains("/rss") || href.Contains("-rss") || href.Contains("/feed") || href.Contains("-feed"))){                //if link has has rss or feed in it return it
                            Console.WriteLine("URL: "+ href);
                        }

                        /*if (!href.Contains(".") && (href.Contains("/rss") || href.Contains("-rss") || href.Contains("/feed") || href.Contains("-feed"))){
                            Console.WriteLine("URL: "+url+ href);     //some links arent the full rss
                        }*/

                    }
                }
            }
            catch(Exception E){
                Console.WriteLine(E);
            }
        }
	
        public void HTMLDoc_SourceSearcher(String url, FilterModel model){
            var webGet = new HtmlWeb();

            try{
                if (webGet.Load(url) is HtmlDocument document){
                    foreach (HtmlAgilityPack.HtmlNode block in document.DocumentNode.SelectNodes("//h2 | //p | //article")){
                        
                        String words = block.InnerText;

                        //Console.WriteLine(words);

                        if(words.Contains("grant")){
                            //Console.WriteLine("MENTIONS GRANT \n"+url);
                            HTMLNode_GrantExtrator(url);
                            break;
                        }

                        /*if((model.getAllRaces().Any(words.Contains)){
                            Console.WriteLine("MENTIONS ONE OF RACES \n"+ words);
                        }*/
                        
                        /*if((model.getAllLocations()).Any(words.Contains)){      //testing if site mentions location
                            Console.WriteLine("MENTIONS ONE OF LOCATIONS \n"+ words);
                        }*/

                        /*if(words.Contains("age.") || words.Contains("age ") ||words.Contains("age:")){
                            Console.WriteLine("MENTIONS AGE \n"+ words);
                        }*/
                    } 

                }

            }catch(Exception E){
                Console.WriteLine(E);
            }
        }

        //an attempt to get grant related urls off site
        public void HTMLNode_GrantExtrator(String url){
            var webGet = new HtmlWeb();

             if (webGet.Load(url) is HtmlDocument document){
                 foreach (HtmlAgilityPack.HtmlNode block in document.DocumentNode.SelectNodes("//a[@href]")){
                    
                    String blockword = block.InnerText;

                    if(blockword.Contains("grant")){                        //checks to see if url/url title has the word grant in it
                        String href= block.GetAttributeValue("href");
                        Console.WriteLine("Grant Urls: "+href);
                    }
                    

                    
                }
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
