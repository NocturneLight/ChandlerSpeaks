using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;


class GrantsGovRSSGet
{


    //EXPLAINER: This method, GetGrantGovList, pulls and parses grants from RSS feed on grants.gov only if they are qualified for 501c3 nonprofits and have a category of health or education
    public static List<Grant> GetGrantGovList()
    {
        //-----------------JESSE ALOTTOS CODE HERE---------------------------------------------------------------------------
        //Plan: 1. Get a bunch of URls
        //  2. Place the URLs into a grant object
        //  3. Query keywords against the grants that match firstly keywords like health and children and childcare and speech development so on
        //  secondly query against the grants that match the demographic information laid out in the selections from the filterModel
        //  4. Sort the grants by their scores from max to min and display them in that order to the user on the website
        // CURRENT PROGRESS: Get it done in grants.gov, then get a bunch of other rss feeds. Create a separate process to parse each of them

        // Grants.gov -------------------///////////////
        var grantsGovRSSURL = "https://www.grants.gov/rss/GG_NewOppByAgency.xml";
        List<Grant> grantsList = new List<Grant>();
        XmlDocument Xdoc = new XmlDocument();
        Xdoc.Load(grantsGovRSSURL);
        XmlNodeList titles = Xdoc.GetElementsByTagName("title");
        XmlNodeList links = Xdoc.GetElementsByTagName("link");
        XmlNodeList content = Xdoc.GetElementsByTagName("content:encoded");
        XmlNodeList pubDates = Xdoc.GetElementsByTagName("pubDate");
        for (int i = 0; i < links.Count-1; i++)
        {
            if (content.Item(i).InnerXml.Contains("<br>Nonprofits having a 501(c)(3) status with the IRS, other than institutions of higher education")
            && (content.Item(i).InnerXml.ToLower().Contains("health") || content.Item(i).InnerXml.ToLower().Contains("education")))  // Only get grants that have 501c3 and health or education in the eligibility section
            {
                grantsList.Add(new Grant(titles.Item(i + 1).InnerXml,
                                                links.Item(i).InnerXml,
                                                pubDates.Item(i).InnerXml,
                                                content.Item(i).InnerXml));
            }
        }

        /*-----------------------------------Code that displays resulting grants------------------------
        foreach (Grant grant in grantsList)
        {
            Console.WriteLine(grant.Title + " | " + grant.Link + " | " + grant.Content);
            Console.WriteLine(" -----------------------------------------------");
        }
        //-----------------------------------------------------------------------------------------------
        */
        return grantsList;

    }

    //EXPLAINER: This method, SortListByMatches, takes the grantsList that results from GrantsGovRSSGet and increments a score based on how many keywords related to child speech
    // development that the content section of the grant matches against. It then returns the list sorted with the highest scoring entries first. This can then be loaded into the results area
    // after further incrementing the score counter based on demographic/location/etc. information to get the highest scoring matches first
    public static List<Grant> SortListByMatches(List<Grant> grantsList) {
        string[] keywordBankForChildSpeechRelatedGrants = { "child", "speech", "learning", "disab", "patho", "impedi", "education", "therapy", "talk", "kid", "audi" };
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

        // Debug line to the console to see all grants and their associated score
        foreach (Grant grant in grantsList)
        {
            Console.WriteLine(grant.Title + " | " + grant.Score);
        }

        grantsList.Sort();
        return grantsList;
        
    }
}
