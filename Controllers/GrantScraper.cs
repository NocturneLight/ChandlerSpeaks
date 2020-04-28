using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;
using ChandlerSpeaks.Models;

// TODO Get working!
class GrantScraper
{
    // Create variables here.
    private const string grantGovRSSFeed = "https://www.grants.gov/rss/GG_NewOppByAgency.xml";
    private readonly XmlDocument Xdoc = new XmlDocument();
    private List<Grant> grantsList = new List<Grant>();

    //EXPLAINER: This constructor, GrantScraper, pulls and parses grants from RSS feed on grants.gov only 
    //if they are qualified for 501c3 nonprofits and have a category of health or education
    //public List<Grant> GetGrantGovList(FilterModel model)
    public GrantScraper(FilterModel model)
    {
        //-----------------JESSE ALOTTOS CODE HERE---------------------------------------------------------------------------
        //Plan: 1. Get a bunch of URls
        //  2. Place the URLs into a grant object
        //  3. Query keywords against the grants that match firstly keywords like health and children and childcare and speech development so on
        //  secondly query against the grants that match the demographic information laid out in the selections from the filterModel
        //  4. Sort the grants by their scores from max to min and display them in that order to the user on the website
        // CURRENT PROGRESS: Get it done in grants.gov, then get a bunch of other rss feeds. Create a separate process to parse each of them

        // Grants.gov -------------------///////////////

        // Load in Grant.gov's RSS feed.
        Xdoc.Load(grantGovRSSFeed);

        // Get an unfiltered list of grants.
        List<Grant> grants = GetAllGrants(Xdoc.GetElementsByTagName("title"), Xdoc.GetElementsByTagName("link"), Xdoc.GetElementsByTagName("pubDate"), Xdoc.GetElementsByTagName("content:encoded"));
        
        // Sort the grants based on the website filters.
        grantsList.AddRange(GetOnlyRelevantGrants());

        
        

        
        /*
        for (int i = 0; i < contentNodes.Count; i++)
        {
            Debug.WriteLine(titleNodes.Item(i).InnerText + "\n" + contentNodes[i]);
        }
        */

        

        /*
        for (int i = 0; i < links.Count - 1; i++)
        {
            if (content.Item(i).InnerXml.Contains("<br>Nonprofits having a 501(c)(3) status with the IRS, other than institutions of higher education")
            && (content.Item(i).InnerXml.ToLower().Contains("health") || content.Item(i).InnerXml.ToLower().Contains("education")))  // Only get grants that have 501c3 and health or education in the eligibility section
            {
                grantsList.Add(new Grant(titles.Item(i + 1).InnerXml, links.Item(i).InnerXml, pubDates.Item(i).InnerXml, content.Item(i).InnerXml));
            }
        }
        */
        
        //return grantsList;


        // Create local functions here.
        List<Grant> GetOnlyRelevantGrants()
        {
            // Create variables here. All synonyms gotten from https://www.lexico.com/en/definition/
            List<string> companyAgeSearchList = model.GetCompanyAgeFilterSearchList();
            List<string> grantTypeSearchList = model.GetGrantTypeFilterSearchList();
            List<string> locationSearchList = model.GetLocationFilterSearchList();
            List<string> raceSearchList = model.GetRaceFilterSearchList();
            List<string> religiousAffiliationSearchList = model.GetReligiousAffiliationFilterSearchList();
            List<string> grantDueDateSearchList = model.GetGrantDueDateFilterSearchList();
            List<string> grantAmountSearchList = model.GetGrantAmountFilterSearchList();
            List<string> type501c3SearchList = model.GetType501c3FilterSearchList();
            List<string> financialInfoRequiredSearchList = model.GetFinancialInfoRequiredFilterSearchList();
            List<string> revenueRangeRequiredSearchList = model.GetRevenueRangeRequiredFilterSearchList();
            List<string> fundingDueDateSearchList = model.GetFundingDueDateFilterSearchList();


            // TODO Give each grant a score based on the number of occurences
            // of the keywords. If the size is of a list is 0, 

            // Traverse the list of grants.
            foreach (var grant in grants)
            {
                // Create local variables here.
                int casList = 0;
                int gtsList = 0;
                int lsList = 0;
                int rsList = 0;
                int rasList = 0;
                int gddsList = 0;
                int gasList = 0;
                int tcsList = 0;
                int firsList = 0;
                int rrrsList = 0;
                int fddsList = 0;

                // NOTE: The idea is we increase the corresponding score variable if there's a match. 
                // If any of the scores are 0, and the search list wasn't 0, omit the grant. This should 
                // help weed out useless variables.
                if (companyAgeSearchList.Count > 0)
                {
                    foreach (var item in companyAgeSearchList)
                    {
                        casList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (grantTypeSearchList.Count > 0)
                {
                    foreach (var item in grantTypeSearchList)
                    {   
                        gtsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (locationSearchList.Count > 0)
                {
                    foreach (var item in locationSearchList)
                    {
                        lsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (raceSearchList.Count > 0)
                {
                    foreach (var item in raceSearchList)
                    {
                        rsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (religiousAffiliationSearchList.Count > 0)
                {
                    foreach (var item in religiousAffiliationSearchList)
                    {
                        rasList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (grantDueDateSearchList.Count > 0)
                {
                    foreach (var item in grantDueDateSearchList)
                    {
                        gddsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (grantAmountSearchList.Count > 0)
                {
                    foreach (var item in grantAmountSearchList)
                    {
                        gasList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (type501c3SearchList.Count > 0)
                {
                    foreach (var item in type501c3SearchList)
                    {
                        tcsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (financialInfoRequiredSearchList.Count > 0)
                {
                    foreach (var item in financialInfoRequiredSearchList)
                    {
                        firsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (revenueRangeRequiredSearchList.Count > 0)
                {
                    foreach (var item in revenueRangeRequiredSearchList)
                    {
                        rrrsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                if (fundingDueDateSearchList.Count > 0)
                {
                    foreach (var item in fundingDueDateSearchList)
                    {
                        fddsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }
                }

                // TODO Implement the portion of the score system where we add a grant if all valid score integers
                // are not 0 and the corresponding filter list was also not 0. 
                // IN OTHER WORDS, if any of the filter lists were not 0, and the corresponding score integer still came up 0, 
                // omit the grant.

                //Debug.WriteLine(grant.Title + " | " + casList + ", " + gtsList + ", " + lsList + ", " + rsList + ", " + rasList + ", " + gddsList + ", " + gasList + ", " + tcsList + ", " + firsList + ", " + rrrsList + ", " + fddsList);
            }



            return new List<Grant>();
        }

        List<Grant> GetAllGrants(XmlNodeList titleNodes, XmlNodeList linkNodes, XmlNodeList pubDateNodes, XmlNodeList rawContentNodes)
        {
            // Create variables here.
            List<Grant> _ = new List<Grant>();
            List<string> contentNodes = ParseXMLEncodedContent(rawContentNodes);

            // Add values to a grant list.
            for (int i = 0; i < rawContentNodes.Count; i++)
            {
                _.Add(new Grant(titleNodes.Item(i + 1).InnerText, linkNodes.Item(i + 1).InnerText, pubDateNodes.Item(i).InnerText, contentNodes[i], rawContentNodes.Item(i).InnerText));
            }

            // Return the newly formed list of grants.
            return _;
        }

        List<string> ParseXMLEncodedContent(XmlNodeList contentNodes)
        {
            // Create variable here.
            const string regexSequence = @"(</?[aA-zZ]*>)";
            List<string> descriptionList = new List<string>();

            // Iterate through every encoded content section of grant.gov's RSS feed.
            for (int i = 0; i < contentNodes.Count; i++)
            {
                // Create local variables here.
                string content = contentNodes.Item(i).InnerText;
                List<string> splitContent = new List<string>(Regex.Split(content, regexSequence)); // We're splitting the string on tags. Update if better regex is found.

                // Remove unimportant information such as empty strings and tags from the list.
                splitContent.RemoveAll(removeCharacters);

                // Store the description index for evaluation.
                int descriptionIndex = splitContent.IndexOf("Description:");

                // Display an error message if the description could not be found
                // in the array. Otherwise, add the description to the description
                // list.
                try
                {
                    descriptionList.Add(splitContent[descriptionIndex + 1]);
                }
                catch (System.Exception)
                {
                    throw new Exception("Couldn't find a description!");
                }
            }

            // Return our newly formed list of descriptions.
            return descriptionList;


            // Create local functions here.
            bool removeCharacters(string _)
            {
                return _.Equals("") ? true : Regex.Match(_, regexSequence).Success ? true : false;
            }
        }
    }

    /*
    // Pulls Grants from Grants.Gov, gets the filter selections the user made, grabs the relevant info and queries
    // those terms against the grant results list, granting a score to the grants in the grants list and displaying them back
    // in sorted order.
    public List<Grant> returnGrantsGovRSSGrants(FilterModel model)
    {
        // Create variables here.
        //List<Grant> grantsList = new List<Grant>(GetGrantGovList(model));

            
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

                    foreach (string selection in model.religiousSelections) 
                    { 
                        // for each selection in the religious preferences selection
                        if (grant.Content.Contains(selection)) // if the grant contains those keywords 
                        {
                            grant.Score++; // increase the score of the grant
                        }
                    }
                }
            }
            

        // Function that sorts the grantsList.
        //GrantScraper.SortListByMatches(grantsList);

        
        // Debug statements to display the sorted list.
        Debug.WriteLine("\nNow sorting the grant list:\n");

        foreach (Grant grant in grantsList) 
        {
            Debug.WriteLine("Grant Title: " + grant.Title + " Grant Score: " + grant.Score);
        }

        Debug.WriteLine("\nFinished sorting.\n");
        

        // We return the sorted list now.
        //return grantsList;
        return new List<Grant>();
    }
    */

    // EXPLAINER: This method, SortListByMatches, takes the grantsList that results from GrantsGovRSSGet and increments a score 
    // based on how many keywords related to child speech development that the content section of the grant matches against. It 
    // then returns the list sorted with the highest scoring entries first. This can then be loaded into the results area
    // after further incrementing the score counter based on demographic, location, etc, information to get the highest scoring matches first.
    public static List<Grant> SortListByMatches(List<Grant> grantsList) 
    {
        // Create variables here.
        string[] keywordBankForChildSpeechRelatedGrants = { "child", "speech", "learning", "disab", "patho", "impedi", "education", "therapy", "talk", "kid", "audi" };
        
        // Calculates the score.
        foreach (Grant grant in grantsList)
        {
            foreach (string keyword in keywordBankForChildSpeechRelatedGrants)
            {
                if (grant.Content.Contains(keyword))
                {
                    grant.Score++;
                }
            }
        }

        /*
        // Debug lines to the console to see all grants and their associated score
        Debug.WriteLine("\nNow displaying the unsorted list of grants.\n");

        foreach (Grant grant in grantsList)
        {
            Console.WriteLine(grant.Title + " | " + grant.Score);
        }

        Debug.WriteLine("\nDisplaying of the unsorted grants has ended.\n");
        */
        
        // Sorts the list based on score.
        grantsList.Sort();

        // Returns the sorted list.
        return grantsList;
    }
}
