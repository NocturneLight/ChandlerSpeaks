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
        private readonly string[] CompanyAgeNames = {"Less than 1", "1 to 3", "4 to 6", "7 to 9", "10 to 12", "More than 12"};
        private readonly string[] GrantTypeNames = {"All", "Type 1", "Type 2", "Type 3", "Type 4", "Type 5"};
        private readonly string[] LocationNames = {"All", "Carrollton", "Coppell", "Dallas", "Fort Worth", "Flower Mound", "Grapevine", "Irving", "Lewisville", "Plano", "Richardson", "Frisco", "Arlington", "Southlake"};
        private readonly string[] RaceNames = {"African American", "Asian", "Caucasian", "Hispanic", "Middle Eastern", "American Indian"};
        private readonly string[] ReligiousAffiliationNames = {"Yes", "No"};
        private readonly string[] ReligiousIdentificationNames = {"Christian", "Catholic", "Hindu", "Muslim", "Buddhist", "Sikh", "Jewish", "Other"};
        private readonly string[] DueDatesNames = {"All", "1 Week", "2 Weeks", "1 Month", "2 Months", "Greater Than 2 Months"};

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
        public String endURL;

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
                Debug.WriteLine("User has religious affiliation? " + ReligiousAffiliation.ToUpper ());
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

        } 

        public void createURLend(){
            String LocationURL=null;
            String RaceURL=null;
            String ReligionURL=null;

            // Check if there are values in the Location list.
            if (Location != null)
            {
                LocationURL="in+";
                // Iterate through the list and collect location search terms for URL
                for (int i = 0; i < Location.Count; i++)
                {
                    if (Location[i]){
                        LocationURL += getLocationNames(i) +"+";
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
    }
}