using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ChandlerSpeaks.Models
{
    // A filter object that will contain the user's choices
    // they made on Index.cshtml.
    public class FilterModel
    {
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


        // Create other functions here.
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
    }
}