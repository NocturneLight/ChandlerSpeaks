using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;
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
    // Create variables here.
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;

        // Create functions here.
        [HttpPost]
        public IActionResult Index(FilterModel model)
        {
            //model.DisplayAllValues();

            model.createURLend();
            
            
            
            Console.WriteLine("Calling google scraper");

            Console.WriteLine("Getting grants from grants.gov");
            ViewData["Grants"] = returnGrantsGovRSSGrants(model); // Jesses Code to store grants in dictionary

            //GoogleScrap(model);

            //Test Scrapers seperately 
            //HTMLDoc_RssFinder("https://www.studentdebtrelief.us/scholarships/scholarships-grants-african-american-students/");
            //HTMLDoc_SourceSearcher("https://www.studentdebtrelief.us/scholarships/scholarships-grants-african-american-students/", model);

            // Create an instance of the Python engine.
            //var pythonEngine = Python.CreateEngine();


            //string path = @"..\ChandlerSpeaks\Lib\site-packages";

            //var paths = pythonEngine.GetSearchPaths();
            //paths.Add(path);
            //pythonEngine.SetSearchPaths(paths);


            ViewData["Test"] = testList;

            model.DisplayAllValues();


            //return Content("Hi! The size is: ");

            return View("Index");
        }

        
	    public void GoogleScrap(FilterModel model){
        
            var starturl="http://www.google.com/search?q=\"grants\"+for+"+model.endURL+"&num=100";
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
                            
                            //HTMLDoc_RssFinder(s);    //uncomment to run rss finder
                            
                            HTMLDoc_SourceSearcher(s, model);   //looks through source of each link for info on grants
                            
                        }
                }

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

        //Pulls Grants from Grants.Gov, gets the filter selections the user made, grabs the relevant info and queries
        //those terms against the grant results list, granting a score to the grants in the grants list and displaying them back
        //in sorted order
        public List<Grant> returnGrantsGovRSSGrants(FilterModel model)
        {
            List<Grant> grantsList = new List<Grant>(GrantsGovRSSGet.GetGrantGovList());
            if (model.raceSelections != null) //If there are race selectors
            {
                foreach (Grant grant in grantsList) // for each grant in the grant list
                {
                    foreach (string selection in model.raceSelections) // for each selection in the race selections
                    {
                        if (grant.Content.Contains(selection)) // if the grant contains those keywords
                        {
                            grant.Score++; //increase the score of the grant
                        }
                    }
                    foreach (string selection in model.religiousSelections) { // for each selection in the religious preferences selection
                        if (grant.Content.Contains(selection)) // if the grant contains those keywords 
                        {
                            grant.Score++; // increase the score of the grant
                        }
                    }
                }
            }
            //Call function that sorts the grantsList
            GrantsGovRSSGet.SortListByMatches(grantsList);
            foreach(Grant grant in grantsList) {
                Console.WriteLine("Grant Title: " + grant.Title + " Grant Score: " + grant.Score);
            }
            return grantsList;
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
