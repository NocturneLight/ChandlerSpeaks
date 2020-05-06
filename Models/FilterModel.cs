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
        // Create enums here.
        public enum GrantTypeNames { All, Arts, Business, Community, Education, Environment, Health, Law, Technology, Sciences, Special_Ed, Research, Training, STEM }
        public enum LocationNames { All, Carrollton, Coppell, Dallas, Fort_Worth, Flower_Mound, Grapevine, Irving, Lewisville, Plano, Richardson, Frisco, Arlington, Southlake }
        public enum RaceNames { African_American, Asian, Caucasian, Hispanic, Middle_Eastern, American_Indian }
        public enum ReligiousAffiliationNames { Yes, No }
        public enum ReligiousIdentificationNames { Christian, Catholic, Hindu, Muslim, Buddhist, Sikh, Jewish, Other }
        public enum GrantDueDateNames { All, January, February, March, April, May, June, July, August, September, October, November, December }
        public enum GrantAmountNames { All, Less_Than_Thousand, Thousand_To_TenThousand, TenThousandOne_To_TwentyFiveThousand, TwentyFiveThousandOne_To_FiftyThousand, Greater_Than_FiftyThousand }
        public enum Type501c3DesignationNames { Yes, No }


        // Create lists for storing each section's choice's truth values.
        // Each checkbox on the main page gets one area of the list.
        // In other words, checkbox 1 of the Company Age section gets "GrantType[0],
        // checkbox 2 gets "GrantType[1]" and so on.
        public List<bool> GrantType { get; set; }
        public List<bool> Location { get; set; }
        public List<bool> Race { get; set; }
        public string ReligiousAffiliation { get; set; }
        public List<bool> ReligiousIdentification { get; set; }
        public List<bool> GrantDueDate { get; set; }
        public List<bool> GrantAmount { get; set; }
        public string Type501c3 { get; set; }

        // Create functions here.
        public bool grantTypeContains(bool truthVal)
        {
            return GrantType.Contains(truthVal);
        }

        public bool locationContains(bool truthVal)
        {
            return Location.Contains(truthVal);
        }

        public bool raceContains(bool truthVal)
        {
            return Race.Contains(truthVal);
        }

        public bool religiousAffiliationContains(string yesVal)
        {
            return ReligiousAffiliation != null && ReligiousAffiliation.Contains(yesVal);
        }

        public bool religiousIdentificationContains(bool truthVal)
        {
            return ReligiousIdentification.Contains(truthVal);
        }

        public bool grantDueDateContains(bool truthVal)
        {
            return GrantDueDate.Contains(truthVal);
        }

        public bool grantAmountContains(bool truthVal)
        {
            return GrantAmount.Contains(truthVal);
        }

        public bool type501c3Contains(string yesVal)
        {
            return Type501c3 != null && Type501c3.Contains(yesVal);
        }

        public List<string> GetType501c3FilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();

            // The 501c3 designation filter check.
            if (Type501c3 != null && Type501c3.Equals(Type501c3DesignationNames.Yes.ToString().ToLower()))
            {
                filterSearchList.Add("501c3");
                filterSearchList.Add(@"501\(c\)\(3\)");
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetGrantAmountFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> GrantAmountList = new List<string> { 
                "0 1000", "1000 10000", "10000 25000", "25000 50000", "50000"
            };

            // The grant amount filter check.
            if (!GrantAmount[(int)GrantAmountNames.All])
            {
                if (GrantAmount[(int)GrantAmountNames.Less_Than_Thousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("0 1000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.Thousand_To_TenThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("1000 10000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.TenThousandOne_To_TwentyFiveThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("10000 25000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.TwentyFiveThousandOne_To_FiftyThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("25000 50000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.Greater_Than_FiftyThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("50000")]);
                }
            }
            else
            {
                filterSearchList.AddRange(GrantAmountList);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetGrantDueDateFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> GrantDueDateList = new List<string> {
                "january", "jan", "february", "feb", "march", "mar", "april", "apr", "may", "june", "jun", "july", "jul", "august", "aug", "september",
                "sept", "sep", "october", "oct", "november", "nov", "december", "dec"
            };

            // The grant due date filter check.
            if (!GrantDueDate[(int)GrantDueDateNames.All])
            {
                if (GrantDueDate[(int)GrantDueDateNames.January])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("january")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("jan")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.February])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("february")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("feb")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.March])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("march")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("mar")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.April])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("april")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("apr")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.May])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("may")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.June])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("june")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("jun")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.July])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("july")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("jul")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.August])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("august")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("aug")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.September])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("september")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("sept")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("sep")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.October])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("october")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("oct")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.November])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("november")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("nov")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.December])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("december")]);
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("dec")]);
                }
            }
            else
            {
                filterSearchList.AddRange(GrantDueDateList);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetReligiousAffiliationFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> ReligiousIdentificationList = new List<string> {
                "christian", "catholic", "hindu", "muslim", "buddhist", "sikh", "jewish", "religion"
            };

            // The religious affiliation and religious identification filter check.
            if (ReligiousAffiliation != null && ReligiousAffiliation.Equals(ReligiousAffiliationNames.Yes.ToString().ToLower()))
            {
                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Christian])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("christian")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Catholic])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("catholic")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Hindu])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("hindu")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Muslim])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("muslim")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Buddhist])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("buddhist")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Sikh])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("sikh")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Jewish])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("jewish")]);
                }

                if (ReligiousIdentification[(int)ReligiousIdentificationNames.Other])
                {
                    filterSearchList.Add(ReligiousIdentificationList[ReligiousIdentificationList.IndexOf("religion")]);
                }
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetRaceFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> RaceList = new List<string> {
                "black", "african american", "asian", "asian american", "caucasian", "hispanic",
                "latin", "middle east", "american indian", "native american"
            };

            // The race filter check.
            if (Race[(int)RaceNames.African_American])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("african american")]);
                filterSearchList.Add(RaceList[RaceList.IndexOf("black")]);
            }

            if (Race[(int)RaceNames.Asian])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("asian")]);
                filterSearchList.Add(RaceList[RaceList.IndexOf("asian american")]);
            }

            if (Race[(int)RaceNames.Caucasian])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("caucasian")]);
            }

            if (Race[(int)RaceNames.Hispanic])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("hispanic")]);
                filterSearchList.Add(RaceList[RaceList.IndexOf("latin")]);
            }

            if (Race[(int)RaceNames.Middle_Eastern])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("middle east")]);
            }

            if (Race[(int)RaceNames.American_Indian])
            {
                filterSearchList.Add(RaceList[RaceList.IndexOf("american indian")]);
                filterSearchList.Add(RaceList[RaceList.IndexOf("native american")]);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetLocationFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> LocationList = new List<string> {
                "carrollton", "coppell", "dallas", "fort worth", "flower mound", "grapevine",
                "irving", "lewisville", "plano", "richardson", "frisco", "arlington", "southlake"
            };

            // The Location filter check.
            if (!Location[(int)LocationNames.All])
            {
                if (Location[(int)LocationNames.Carrollton])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("carrollton")]);
                }

                if (Location[(int)LocationNames.Coppell])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("coppell")]);
                }

                if (Location[(int)LocationNames.Dallas])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("dallas")]);
                }

                if (Location[(int)LocationNames.Fort_Worth])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("fort worth")]);
                }

                if (Location[(int)LocationNames.Flower_Mound])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("flower mound")]);
                }

                if (Location[(int)LocationNames.Grapevine])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("grapevine")]);
                }

                if (Location[(int)LocationNames.Irving])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("irving")]);
                }

                if (Location[(int)LocationNames.Lewisville])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("lewisville")]);
                }

                if (Location[(int)LocationNames.Plano])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("plano")]);
                }

                if (Location[(int)LocationNames.Richardson])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("richardson")]);
                }

                if (Location[(int)LocationNames.Frisco])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("frisco")]);
                }

                if (Location[(int)LocationNames.Arlington])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("arlington")]);
                }

                if (Location[(int)LocationNames.Southlake])
                {
                    filterSearchList.Add(LocationList[LocationList.IndexOf("southlake")]);
                }
            }
            else
            {
                filterSearchList.AddRange(LocationList);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetGrantTypeFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> GrantTypeList = new List<string> {
                "arts", "business", "occupation", "community", "education", "teach",
                "school", "learn", "environment", "habitat", "health", "mental health",
                "law", "technology", "computer", "machine", "science", "special education",
                "research", "training", "stem education"
            };

            // The GrantType filter check.
            if (!GrantType[(int)GrantTypeNames.All])
            {
                if (GrantType[(int)GrantTypeNames.Arts])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("arts")]);
                }

                if (GrantType[(int)GrantTypeNames.Business])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("business")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("occupation")]);
                }

                if (GrantType[(int)GrantTypeNames.Community])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("community")]);
                }

                if (GrantType[(int)GrantTypeNames.Education])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("education")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("teach")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("school")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("learn")]);

                    // Add the following if any of the subfilters are true.
                    if (GrantType[(int)GrantTypeNames.Sciences])
                    {
                        filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("science")]);
                    }

                    if (GrantType[(int)GrantTypeNames.Special_Ed])
                    {
                        filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("special education")]);
                    }

                    if (GrantType[(int)GrantTypeNames.Research])
                    {
                        filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("research")]);
                    }

                    if (GrantType[(int)GrantTypeNames.Training])
                    {
                        filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("training")]);
                    }

                    if (GrantType[(int)GrantTypeNames.STEM])
                    {
                        filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("stem education")]);
                    }
                }

                if (GrantType[(int)GrantTypeNames.Environment])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("environment")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("habitat")]);
                }

                if (GrantType[(int)GrantTypeNames.Health])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("health")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("mental health")]);
                }

                if (GrantType[(int)GrantTypeNames.Law])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("law")]);
                }

                if (GrantType[(int)GrantTypeNames.Technology])
                {
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("technology")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("computer")]);
                    filterSearchList.Add(GrantTypeList[GrantTypeList.IndexOf("machine")]);
                }
            }
            else
            {
                filterSearchList.AddRange(GrantTypeList);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public void DisplayAllValues() // A debug function.
        {
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
            if (GrantDueDate != null)
            {
                // Display to the user which filter section is
                // being looked at.
                Debug.WriteLine("Due Dates Section:");

                // Iterate through the list and display each boolean.
                for (int i = 0; i < GrantDueDate.Count; i++)
                {
                    Debug.WriteLine("[" + i + "] - " + GrantDueDate[i]);
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
        }
    }
}