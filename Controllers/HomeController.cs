using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChandlerSpeaks.Models;
using System.Linq;
using System;
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
            // Pull the grants from grants.gov, get the ones relevant to 
            // the user's choices, and then sort them by score.
            GrantScraper generator = new GrantScraper(model);

            // If the user pressed any buttons, send a list of grants relevant
            // to the choices they made.
            if (getFilterBoolStates())
            {
                // Send the grants to the webpage.
                ViewData["Grants"] = generator.getGrants(model);
            }
            
            // Return to the webpage.
            return View("Index");



            // Create local functions here.
            bool getFilterBoolStates()
            {
                return  model.companyAgeContains(true) || model.grantTypeContains(true) || model.locationContains(true) || 
                        model.raceContains(true) || model.religiousAffiliationContains("yes") || model.religiousIdentificationContains(true) || 
                        model.grantDueDateContains(true) || model.grantAmountContains(true) || model.type501c3Contains("yes") || 
                        model.financialInfoRequiredContains("yes") || model.revenueRangeRequiredContains("yes") || model.fundingDueDateContains(true);
            }
        }

	    public void GoogleScrap(FilterModel model)
        {
            var starturl="http://www.google.com/search?q=\"grants\"+for+"+model.endURL+"&num=100";
            var webGet = new HtmlWeb();

            if (webGet.Load(starturl) is HtmlDocument document)
            {   
                //var nodes = document.DocumentNode.CssSelect("#item-search-results li").ToList();  
                        
                var nodes = document.DocumentNode.CssSelect("#rso .g").ToList();
                Debug.WriteLine(nodes.Count());

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
        public void HTMLDoc_RssFinder(String url)
        {
            var webGet = new HtmlWeb();

            try
            {
                if (webGet.Load(url) is HtmlDocument document)
                {
                    foreach (HtmlAgilityPack.HtmlNode link in document.DocumentNode.SelectNodes("//a[@href] | //link[@href]"))
                    {
                        String href= link.GetAttributeValue("href");

                        if (href.Contains(".") && !href.Contains("comments") && !href.Contains("feedback") && !href.Contains("facebook") && (href.Contains("/rss") || href.Contains("-rss") || href.Contains("/feed") || href.Contains("-feed")))
                        {                
                            //if link has has rss or feed in it return it
                            Console.WriteLine("URL: "+ href);
                        }

                        /*if (!href.Contains(".") && (href.Contains("/rss") || href.Contains("-rss") || href.Contains("/feed") || href.Contains("-feed"))){
                            Console.WriteLine("URL: "+url+ href);     //some links arent the full rss
                        }*/
                    }
                }
            }
            catch (Exception E)
            {
                Debug.WriteLine(E);
            }
        }
	
        public void HTMLDoc_SourceSearcher(String url, FilterModel model){
            var webGet = new HtmlWeb();

            try
            {
                if (webGet.Load(url) is HtmlDocument document)
                {
                    foreach (HtmlAgilityPack.HtmlNode block in document.DocumentNode.SelectNodes("//h2 | //p | //article"))
                    {
                        
                        String words = block.InnerText;

                        //Console.WriteLine(words);

                        if (words.Contains("grant"))
                        {
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
            }
            catch (Exception E)
            {
                Debug.WriteLine(E);
            }
        }

        //an attempt to get grant related urls off site
        public void HTMLNode_GrantExtrator(String url)
        {
            var webGet = new HtmlWeb();

             if (webGet.Load(url) is HtmlDocument document)
             {
                 foreach (HtmlAgilityPack.HtmlNode block in document.DocumentNode.SelectNodes("//a[@href]"))
                 {
                    String blockword = block.InnerText;

                    if (blockword.Contains("grant"))
                    {                        
                        //checks to see if url/url title has the word grant in it
                        String href= block.GetAttributeValue("href");

                        Debug.WriteLine("Grant Urls: "+href);
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
