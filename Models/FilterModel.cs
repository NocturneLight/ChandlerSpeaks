using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChandlerSpeaks.Models
{
    // A filter object that will contain the user's choices
    // they made on Index.cshtml.
    public class FilterModel
    {
        // Create variables here.
        private readonly string[] CompanyAgeNames = { "Less than 1", "1 to 3", "4 to 6", "7 to 9", "10 to 12", "More than 12" };
        private readonly string[] GrantTypeNames = { "All", "Type 1", "Type 2", "Type 3", "Type 4", "Type 5" };
        private readonly string[] LocationNames = { "All", "Carrollton", "Coppell", "Dallas", "Fort Worth", "Flower Mound", "Grapevine", "Irving", "Lewisville", "Plano", "Richardson", "Frisco", "Arlington", "Southlake" };
        private readonly string[] RaceNames = { "African American", "Asian", "Caucasian", "Hispanic", "Middle Eastern", "American Indian" };
        private readonly string[] ReligiousAffiliationNames = { "Yes", "No" };
        private readonly string[] ReligiousIdentificationNames = { "Christian", "Catholic", "Hindu", "Muslim", "Buddhist", "Sikh", "Jewish", "Other" };
        private readonly string[] DueDatesNames = { "All", "1 Week", "2 Weeks", "1 Month", "2 Months", "Greater Than 2 Months" };

        public List<string> companyAgeSelections = new List<string>();
        public List<string> grantTypeSelections = new List<string>();
        public List<string> locationSelections = new List<string>();
        public List<string> raceSelections = new List<string>();
        public List<string> religiousSelections = new List<string>();
        public List<string> dueDateSelections = new List<string>();


        // Create lists for storing each section's choice's truth values.
        // Each checkbox on the main page gets one area of the list.
        // In other words, checkbox 1 of the Company Age section gets "CompanyAge[0],
        // checkbox 2 gets "CompanyAge[1]" and so on.
        public List<bool> CompanyAge {get; set;}
        public List<bool> GrantType {get; set;}
        public List<bool> Location {get; set;}
        public List<bool> Race {get; set;}
        public string ReligiousAffiliation {get; set;}
        public List<bool> ReligiousIdentification {get; set;}
        public List<bool> DueDates {get; set;}
        public List<bool> GrantAmount {get; set;}
        public string Type501c3 {get; set;}
        public string FinancialInfoRequired {get; set;}
        public string RevenueRangeRequired {get; set;}
        public List<bool> GrantDueDate {get; set;}
        public List<bool> FundingDueDate {get; set;}
        public String endURL;

        //list array that stores the values selected by user
        private List<string> AllLocations = new List<string>();
        private List<string> AllRaces = new List<string>();


        public List<string> getAllLocations()
        {
            return AllLocations;
        }

        public List<string> getAllRaces()
        {
            return AllRaces;
        }

        // Create other functions here.
        public string getCompanyAgeName(int Index)
        {
            return CompanyAgeNames[Index];
        }

        public string getGrantTypeNames(int Index)
        {
            return GrantTypeNames[Index];
        }

        public string getLocationNames(int Index)
        {
            return LocationNames[Index];
        }

        public string getRaceNames(int Index)
        {
            return RaceNames[Index];
        }

        public string getReligiousAffiliationNames(int Index)
        {
            return ReligiousAffiliationNames[Index];
        }

        public string getReligiousIdentificationNames(int Index)
        {
            return ReligiousIdentificationNames[Index];
        }

        public string getDueDatesNames(int Index)
        {
            return DueDatesNames[Index];
        }


        public void DisplayAllValues()
        {
            // Check if there are values in the CompanyAge list.
            if (CompanyAge != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Company Age Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < CompanyAge.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + CompanyAge[i]);

                }
            }

            // Check if there are values in the GrantType list.
            if (GrantType != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Grant Type Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < GrantType.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + GrantType[i]);

                }
            }

            // Check if there are values in the Location list.
            if (Location != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Location Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < Location.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + Location[i]);
                }
            }

            // Check if there are values in the Race list.
            if (Race != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Race Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < Race.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + Race[i]);
                }
            }

            // Check if there are values in the Religious Affiliation list.
            if (ReligiousAffiliation != null)
            {
                Debug.WriteLine("User has religious affiliation? " + ReligiousAffiliation.ToUpper());
            }

            // Check if there are values in the Religious Identification list.
            if (ReligiousIdentification != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Religious Identification Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < ReligiousIdentification.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + ReligiousIdentification[i]);
                }
            }

            // Check if there are values in the Religious Identification list.
            if (DueDates != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Due Dates Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < DueDates.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + DueDates[i]);
                }
            }

            // Check if there are values in the Grant Amount list.
            if (GrantAmount != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Grant Amount Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < GrantAmount.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + GrantAmount[i]);
                }
            }

            // Check if there are values in the 501c3 designation.
            if (Type501c3 != null)
            {
                Debug.WriteLine("Are you a designated 501c3? " + Type501c3.ToUpper());
            }

            // Check if there are values in the financial information requirements.
            if (FinancialInfoRequired != null)
            {
                Debug.WriteLine("Is financial information required? " + FinancialInfoRequired.ToUpper());
            }

            // Check if there are values in the revenue range requirement list.
            if (RevenueRangeRequired != null)
            {
                Debug.WriteLine("Is the revenue range required? " + RevenueRangeRequired.ToUpper());
            }

            // Check if there are values in the Grant Due Date list.
            if (GrantDueDate != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Grant Due Date Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < GrantDueDate.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + GrantDueDate[i]);
                }
            }

            // Check if there are values in the Funding Due Date section.
            if (FundingDueDate != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Funding Due Date Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < FundingDueDate.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + FundingDueDate[i]);
                }
            }

        }

        public void createURLend()
        {
            String LocationURL=null;
            String RaceURL=null;
            String ReligionURL=null;

            // Check if there are values in the Location list.
            if (Location != null && Location.Contains(true))
            {                
                LocationURL="in+";              //add in once

                // Iterate through the list and collect location search terms for URL
                for (int i = 0; i < Location.Count; i++)
                {
                    if (Location[i]){
                        LocationURL += getLocationNames(i) +"+";

                        AllLocations.Add(getLocationNames(i));          //save selected location array
                    }
                }
            }

            // Check if there are values in the Race list.
            if (Race != null)
            {

                // Iterate through the list and collect race search terms for URL
                for (int i = 0; i < Race.Count; i++)
                {
                    if (Race[i]){
                        RaceURL += getRaceNames(i) +"+";

                        AllRaces.Add(getRaceNames(i));          //save selected location array
                    }
                }
            }

            // Check if there are values in the Religious Identification list.
            if (ReligiousIdentification != null)
            {
                // Iterate through the list and collect search terms for URL
                for (int i = 0; i < ReligiousIdentification.Count; i++)
                {
                    if (ReligiousIdentification[i]){
                        ReligionURL += getReligiousIdentificationNames(i) +"+";
                    }
                }
            }
            
            //complete URL search terms
            endURL = ReligionURL+ RaceURL+ LocationURL;
            Debug.WriteLine(endURL);
        }

        //DESCRIPTION: This section is for querying against RSSFeeds. If the grant/source/xml being examined contains any of the 
        //resulting strings that are a result of what the user selects in the filter setion on the left of the page
        public void getListOfSelections()
        {
            // Check if there are values in the CompanyAge list.
            if (CompanyAge != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Company Age Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < CompanyAge.Count; i++)
                {
                    if(CompanyAge[i]==true)
                    {
                        companyAgeSelections.Add(CompanyAgeNames[i]);
                    } 
                }

                // Check if there are values in the GrantType list.
                if (GrantType != null)
                {
                    // Display to the user which filter section is
                    // being looked at.
                    Debug.WriteLine("Grant Type Section:");

                    // Iterate through the list and display each boolean.
                    for (int i = 0; i < GrantType.Count; i++)
                    {
                        if (GrantType[i] == true)
                        {
                            grantTypeSelections.Add(GrantTypeNames[i]);
                        }
                    }
                }

                // Check if there are values in the Location list.
                if (Location != null)
                {
                    // Display to the user which filter section is
                    // being looked at.
                    Debug.WriteLine("Location Section:");

                    // Iterate through the list and display each boolean.
                    for (int i = 0; i < Location.Count; i++)
                    {
                        if (Location[i] == true)
                        {
                            locationSelections.Add(LocationNames[i]);
                        }
                    }
                }

                // Check if there are values in the Race list.
                if (Race != null)
                {
                    // Display to the user which filter section is
                    // being looked at.
                    Debug.WriteLine("Race Section:");

                    // Iterate through the list and display each boolean.
                    for (int i = 0; i < Race.Count; i++)
                    {
                        if (Race[i] == true)
                        {
                            raceSelections.Add(RaceNames[i]);
                        }
                        if (RaceNames[i] == "Hispanic")
                        {
                            raceSelections.Add("hispanic");
                            raceSelections.Add("latin");
                            raceSelections.Add("Latin");
                            raceSelections.Add("mexican");
                            raceSelections.Add("central");
                            raceSelections.Add("Central America");
                            raceSelections.Add("South America");
                        }
                        if (RaceNames[i] == "African-American")
                        {
                            raceSelections.Add("African");
                            raceSelections.Add("african");
                            raceSelections.Add("Black");
                            raceSelections.Add("black");
                        }
                        if (RaceNames[i] == "Asian")
                        {
                            raceSelections.Add("Asian");
                            raceSelections.Add("Chinese");
                            raceSelections.Add("Japan");
                            raceSelections.Add("Japanese");
                            raceSelections.Add("Korean");
                            raceSelections.Add("korean");
                            raceSelections.Add("Taiwan");
                            raceSelections.Add("taiwan");
                            raceSelections.Add("Vietnam");
                            raceSelections.Add("vietnam");
                        }
                    }
                }

                // Check if there are values in the Religious Identification list.
                if (ReligiousIdentification != null)
                {
                    // Display to the user which filter section is
                    // being looked at.
                    Debug.WriteLine("Religious Identification Section:");

                    // Iterate through the list and display each boolean.
                    for (int i = 0; i < ReligiousIdentification.Count; i++)
                    {
                        if (ReligiousIdentification[i] == true)
                        {
                            religiousSelections.Add(ReligiousIdentificationNames[i]);
                        }
                    }
                }

                // Check if there are values in the Religious Identification list.
                if (DueDates != null)
                {
                    // Display to the user which filter section is
                    // being looked at.
                    Debug.WriteLine("Due Dates Section:");

                    // Iterate through the list and display each boolean.
                    for (int i = 0; i < DueDates.Count; i++)
                    {
                        if (DueDates[i] == true)
                        {
                            dueDateSelections.Add(DueDatesNames[i]);
                        }
                    }
                }
            }
        }
    }
}