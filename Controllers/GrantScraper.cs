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
    private XmlReader xmlDocument = XmlReader.Create(grantGovRSSFeed);
    private List<Grant> grants = new List<Grant>();

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


        // Create variables here.
        List<string> grantTitles = new List<string>();
        List<string> grantLinks = new List<string>();
        List<string> grantPubDates = new List<string>();
        List<string> rawContent = new List<string>();
        
        // Read the XML document for relevant infomation and store that info 
        // in the corresponding list.
        while (xmlDocument.Read())
        {
            // Add the info to the corresponding list.
            if (xmlDocument.Name.Equals("title"))
            {
                grantTitles.Add(xmlDocument.ReadInnerXml());
            }
            else if (xmlDocument.Name.Equals("link"))
            {
                grantLinks.Add(xmlDocument.ReadInnerXml());
            }
            else if (xmlDocument.Name.Equals("pubDate"))
            {
                grantPubDates.Add(xmlDocument.ReadInnerXml());
            }
            else if (xmlDocument.Name.Equals("content:encoded"))
            {
                rawContent.Add(xmlDocument.ReadInnerXml());
            }
        }

        // When finished with the XML document, we close it to free up resources.
        xmlDocument.Close();

        // Now we use the lists to create a list of grants.
        grants = GetAllGrants(grantTitles, grantLinks, grantPubDates, rawContent);


        
        // Create local functions here.
        List<Grant> GetAllGrants(List<string> titleNodes, List<string> linkNodes, List<string> pubDateNodes, List<string> rawContentNodes)
        {
            // Create variables here.
            List<Grant> _ = new List<Grant>();
            (List<string> descriptionNodes, List<string> grantAmountNodes, List<string> grantDueDateNodes) = ParseXMLEncodedContent(rawContentNodes);

            // Add values to a grant list.
            for (int i = 0; i < rawContentNodes.Count; i++)
            {
                _.Add(new Grant(titleNodes[i + 1], linkNodes[i + 1], pubDateNodes[i], descriptionNodes[i], rawContent[i], grantAmountNodes[i], grantDueDateNodes[i]));
            }

            // Return the newly formed list of grants.
            return _;
        }

        (List<string>, List<string>, List<string>) ParseXMLEncodedContent(List<string> contentNodes)
        {
            // Create variables here.
            const string regexReplaceSequence = @"(<.+?>)|(]]>)";
            const string regexSplitSequence = @"~+";
            const string regexAmountMatchSequence = @"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$";
            const string regexDateMatchSequence = "[0-9]+";
            List<string> descriptionList = new List<string>();
            List<string> grantAmountList = new List<string>(); 
            List<string> grantDueDateList = new List<string>();


            // Iterate through every encoded content section of grant.gov's RSS feed.
            for (int i = 0; i < contentNodes.Count; i++)
            {
                // Create local variables here.
                string content = Regex.Replace(contentNodes[i], regexReplaceSequence, "~"); 
                List<string> splitContent = new List<string>(Regex.Split(content, regexSplitSequence)); // We're splitting the string on ~. Update if better regex is found.

                // Remove empty strings from the list.
                splitContent.RemoveAll(removeCharacters);

                // Display an error message if the description could not be found
                // in the array. Otherwise, add the description to the description
                // list.
                try
                {
                    // Store the description, grant amount, and grant due date index for evaluation.
                    int descriptionIndex = splitContent.IndexOf("Description:");
                    int grantAmountIndex = splitContent.IndexOf("Award Ceiling:");
                    int grantDueDateIndex = splitContent.IndexOf("Close Date:");

                    // Adjust the grant amount and due dates for the cases where we failed to find a number.
                    splitContent[grantAmountIndex + 1] = Regex.IsMatch(splitContent[grantAmountIndex + 1], regexAmountMatchSequence) ? splitContent[grantAmountIndex + 1] : "N/A";
                    splitContent[grantDueDateIndex + 1] = Regex.IsMatch(splitContent[grantDueDateIndex + 1], regexDateMatchSequence) ? splitContent[grantDueDateIndex + 1] : "N/A";

                    // Once adjusted, add the corresponding values to their respective lists.
                    descriptionList.Add(splitContent[descriptionIndex + 1]);
                    grantAmountList.Add(splitContent[grantAmountIndex + 1]);
                    grantDueDateList.Add(splitContent[grantDueDateIndex + 1]);
                }
                catch (System.Exception)
                {
                    throw new Exception("Couldn't find a description, grant amount, or grant due date!");
                }
            }

            // Return our newly formed description, grant amount, and grant due date lists.
            return (descriptionList, grantAmountList, grantDueDateList);


            // Create local functions here.
            bool removeCharacters(string _)
            {
                return _.Equals("") ? true : _.Equals(" ") ? true : false;
            }
        }
    }

    // Create functions here.
    public List<Grant> getGrants(FilterModel model)
    {
        // Search for specific keywords and dwindle the list down if no matches for a user
        // chosen filter is found.
        GetOnlyRelevantGrants();

        // Sorts the grant by Score.
        grants.Sort();

        // Then send back the trimmed list.
        return grants;

        // Create local variables here.
        void GetOnlyRelevantGrants()
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
            List<Grant> relevantGrantList = new List<Grant>();


            // Traverse the list of grants.
            foreach (var grant in grants.ToList())
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
                bool removeGrant = false;

                // NOTE: The idea is we increase the corresponding score variable if there's a match. 
                // If any of the scores are 0, and the search list wasn't 0, omit the grant. This should 
                // help weed out irrelevant grants.
                if (companyAgeSearchList.Count > 0)
                {
                    foreach (var item in companyAgeSearchList)
                    {
                        casList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = casList == 0 ? true : removeGrant;
                }
                // TODO Might need to adjust education subfilters? Make them essentially another set of filters?
                if (grantTypeSearchList.Count > 0)
                {
                    foreach (var item in grantTypeSearchList)
                    {   
                        gtsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = gtsList == 0 ? true : removeGrant;
                }

                if (locationSearchList.Count > 0)
                {
                    foreach (var item in locationSearchList)
                    {
                        lsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = lsList == 0 ? true : removeGrant;
                }

                if (raceSearchList.Count > 0)
                {
                    foreach (var item in raceSearchList)
                    {
                        rsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = rsList == 0 ? true : removeGrant;
                }

                if (religiousAffiliationSearchList.Count > 0)
                {
                    foreach (var item in religiousAffiliationSearchList)
                    {
                        rasList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = rasList == 0 ? true : removeGrant;
                }

                if (grantDueDateSearchList.Count > 0)
                {
                    foreach (var item in grantDueDateSearchList)
                    {
                        gddsList += Regex.Matches(grant.GrantDueDate, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = gddsList == 0 ? true : removeGrant;
                }

                if (grantAmountSearchList.Count > 0)
                {
                    foreach (var item in grantAmountSearchList)
                    {
                        // Create any variables here.
                        int award = 0;
                        string[] num = item.Split(' ');
                                                
                        // Strip all the alphabetic values from the grant amount, then try and parse it. If
                        // it succeeds, store the new value in the award integer. Otherwise, assign -1 to the
                        // award integer. 
                        if (!int.TryParse(Regex.Replace(grant.GrantAmount, "[^0-9.]", string.Empty), out award))
                        {
                            award = -1;
                        }
                        
                        // If the award integer is between the specified brackets, increment the gasList variable. 
                        if (num.Length == 2)
                        {
                            if (award >= int.Parse(num[0]) && award < int.Parse(num[1]))
                            {
                                gasList++;
                            }
                        }
                        else if (num.Length == 1)
                        {
                            if (award >= int.Parse(num[0]))
                            {
                                gasList++;
                            }
                        }
                        //gasList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = gasList == 0 ? true : removeGrant;
                }

                if (type501c3SearchList.Count > 0)
                {
                    foreach (var item in type501c3SearchList)
                    {
                        tcsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = tcsList == 0 ? true : removeGrant;
                }

                // NOTE: This doesn't really work with grants.gov.
                if (financialInfoRequiredSearchList.Count > 0)
                {
                    foreach (var item in financialInfoRequiredSearchList)
                    {
                        firsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = firsList == 0 ? true : removeGrant;
                }

                // NOTE: This doesn't really work with grants.gov.
                if (revenueRangeRequiredSearchList.Count > 0)
                {
                    foreach (var item in revenueRangeRequiredSearchList) // NOTE: Working as intended. There are no hits for "revenue range". 
                    {
                        rrrsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = rrrsList == 0 ? true : removeGrant;
                }

                // NOTE: This doesn't really work with grants.gov.
                if (fundingDueDateSearchList.Count > 0)
                {
                    foreach (var item in fundingDueDateSearchList)
                    {
                        fddsList += Regex.Matches(grant.RawText, item, RegexOptions.IgnoreCase).Count;
                    }

                    removeGrant = fddsList == 0 ? true : removeGrant;
                }

                // If at any point, the filters in use fail to find a grant with matches,
                // we remove the grant from the list due to irrelevency. Otherwise, add
                // up the grant's score.
                if (removeGrant)
                {
                    grants.Remove(grant);
                }
                else
                {
                    // Add up the grant's score for sorting later.
                    grant.Score = casList + gtsList + lsList + rsList + rasList + gddsList + gasList + tcsList + firsList + rrrsList + fddsList;
                }
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
