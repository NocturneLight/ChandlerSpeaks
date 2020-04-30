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
            GrantScraperModel generator = new GrantScraperModel(model);

            // If the user pressed any buttons, send a list of grants relevant
            // to the choices they made.
            if (getFilterBoolStates())
            {
                // Send the grants to the webpage.
                ViewData["Grants"] = generator.getGrants(model);
            }
            
            // Return to the webpage.
            return View(model);



            // Create local functions here.
            bool getFilterBoolStates()
            {
                return  model.companyAgeContains(true) || model.grantTypeContains(true) || model.locationContains(true) || 
                        model.raceContains(true) || (model.religiousAffiliationContains("yes") && model.religiousIdentificationContains(true)) || 
                        model.grantDueDateContains(true) || model.grantAmountContains(true) || model.type501c3Contains("yes") || 
                        model.financialInfoRequiredContains("yes") || model.revenueRangeRequiredContains("yes") || model.fundingDueDateContains(true);
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
