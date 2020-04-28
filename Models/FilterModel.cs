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
        public enum CompanyAgeNames
        {
            Less_Than_One,
            One_To_Three,
            Four_To_Six,
            Seven_To_Nine,
            Ten_To_Twelve,
            More_Than_Twelve
        }

        public enum GrantTypeNames
        {
           All, 
           Arts, 
           Business, 
           Community, 
           Education, 
           Environment, 
           Health, 
           Law, 
           Technology,
           Sciences,
           Special_Ed,
           Research,
           Training,
           STEM
        }

        public enum LocationNames
        {
            All,
            Carrollton,
            Coppell,
            Dallas,
            Fort_Worth,
            Flower_Mound,
            Grapevine,
            Irving,
            Lewisville,
            Plano,
            Richardson,
            Frisco,
            Arlington,
            Southlake
        }

        public enum RaceNames
        {
            African_American,
            Asian,
            Caucasian,
            Hispanic,
            Middle_Eastern,
            American_Indian
        }

        public enum ReligiousAffiliationNames
        {
            Yes,
            No
        }

        public enum ReligiousIdentificationNames
        {
            Christian,
            Catholic,
            Hindu,
            Muslim,
            Buddhist,
            Sikh,
            Jewish,
            Other
        }

        public enum GrantDueDateNames
        {
            All,
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public enum GrantAmountNames
        {
            All,
            Less_Than_Thousand,
            Thousand_To_TenThousand,
            TenThousandOne_To_TwentyFiveThousand,
            TwentyFiveThousandOne_To_FiftyThousand,
            Greater_Than_FiftyThousand
        }

        public enum Type501c3DesignationNames
        {
            Yes,
            No
        }

        public enum FinancialInformationRequiredNames
        {
            Yes,
            No
        }

        public enum RevenueRangeRequiredNames
        {
            Yes,
            No
        }

        public enum FundingDueDateNames
        {
            All,
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }


        /*
        // TODO Adjust/Remove these.
        private readonly string[] CompanyAgeNames = { "Less than 1", "1 to 3", "4 to 6", "7 to 9", "10 to 12", "More than 12" };
        private readonly string[] GrantTypeNames = { "All", "Type 1", "Type 2", "Type 3", "Type 4", "Type 5" };
        private readonly string[] LocationNames = { "All", "Carrollton", "Coppell", "Dallas", "Fort Worth", "Flower Mound", "Grapevine", "Irving", "Lewisville", "Plano", "Richardson", "Frisco", "Arlington", "Southlake" };
        private readonly string[] RaceNames = { "African American", "Asian", "Caucasian", "Hispanic", "Middle Eastern", "American Indian" };
        private readonly string[] ReligiousAffiliationNames = { "Yes", "No" };
        private readonly string[] ReligiousIdentificationNames = { "Christian", "Catholic", "Hindu", "Muslim", "Buddhist", "Sikh", "Jewish", "Other" };
        private readonly string[] DueDatesNames = { "All", "1 Week", "2 Weeks", "1 Month", "2 Months", "Greater Than 2 Months" };
        */

        /*
        public List<string> companyAgeSelections = new List<string>();
        public List<string> grantTypeSelections = new List<string>();
        public List<string> locationSelections = new List<string>();
        public List<string> raceSelections = new List<string>();
        public List<string> religiousSelections = new List<string>();
        public List<string> dueDateSelections = new List<string>();
        */


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
        public List<bool> GrantDueDate {get; set;}
        public List<bool> GrantAmount {get; set;}
        public string Type501c3 {get; set;}
        public string FinancialInfoRequired {get; set;}
        public string RevenueRangeRequired {get; set;}
        public List<bool> FundingDueDate {get; set;}
        public String endURL;


        /*
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
        */

        // Create functions here.
        public List<string> GetCompanyAgeFilterSearchList()
        {
            // TODO Figure out what to do with company age.

            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> CompanyAgeList = new List<string> {
                "less than one", "<1", "one to three", "1-3", "four to six", "4-6", "seven to nine",
                "7-9", "ten to twelve", "10-12", "more than twelve", ">12"
            };

            // The company age filter check.
            if (CompanyAge[(int)CompanyAgeNames.Less_Than_One])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("less than one")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("<1")]);
            }

            if (CompanyAge[(int)CompanyAgeNames.One_To_Three])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("one to three")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("1-3")]);
            }

            if (CompanyAge[(int)CompanyAgeNames.Four_To_Six])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("four to six")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("4-6")]);
            }

            if (CompanyAge[(int)CompanyAgeNames.Seven_To_Nine])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("seven to nine")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("7-9")]);
            }

            if (CompanyAge[(int)CompanyAgeNames.Ten_To_Twelve])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("ten to twelve")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("10-12")]);
            }

            if (CompanyAge[(int)CompanyAgeNames.More_Than_Twelve])
            {
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf("more than twelve")]);
                filterSearchList.Add(CompanyAgeList[CompanyAgeList.IndexOf(">12")]);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetFundingDueDateFilterSearchList()
        {
            // TODO Figure out how to handle the funding due date filter check.

            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> FundingDueDateList = new List<string> {
                "january", "february", "march", "april", "may", "june", "july", "august", "september",
                "october", "november", "december"
            };

            // The funding due date filter check.
            if (!FundingDueDate[(int)FundingDueDateNames.All])
            {
                if (FundingDueDate[(int)FundingDueDateNames.January])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("january")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.February])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("february")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.March])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("march")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.April])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("april")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.May])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("may")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.June])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("june")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.July])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("july")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.August])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("august")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.September])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("september")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.October])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("october")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.November])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("november")]);
                }

                if (FundingDueDate[(int)FundingDueDateNames.December])
                {
                    filterSearchList.Add(FundingDueDateList[FundingDueDateList.IndexOf("december")]);
                }
            }
            else
            {
                filterSearchList.AddRange(FundingDueDateList);
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetRevenueRangeRequiredFilterSearchList()
        {
            // TODO Figure out how to handle the revenue range required filter check.

            // Create variables here.
            List<string> filterSearchList = new List<string>();

            // The get revenue range required filter check. 
            if (RevenueRangeRequired != null && RevenueRangeRequired.Equals(RevenueRangeRequiredNames.Yes.ToString().ToLower()))
            {
                filterSearchList.Add("revenue range");
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetFinancialInfoRequiredFilterSearchList()
        {
            // TODO Figure out how to handle the financial information required filter check.

            // Create variables here.
            List<string> filterSearchList = new List<string>();

            // The financial info filter check.
            if (FinancialInfoRequired != null && FinancialInfoRequired.Equals(FinancialInformationRequiredNames.Yes.ToString().ToLower()))
            {
                filterSearchList.Add("financial information");
                filterSearchList.Add("financial info");
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetType501c3FilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();

            // The 501c3 designation filter check.
            if (Type501c3 != null && Type501c3.Equals(Type501c3DesignationNames.Yes.ToString().ToLower()))
            {
                filterSearchList.Add("501c3");
                filterSearchList.Add("501(c)(3)");
            }

            // Return our newly formed search list.
            return filterSearchList;
        }

        public List<string> GetGrantAmountFilterSearchList()
        {
            // Create variables here.
            List<string> filterSearchList = new List<string>();
            List<string> GrantAmountList = new List<string> {
                "less than 1000", "<1000", "1000-10000", "1000 to 10000", "10001-25000",
                "10001 to 25000", "25001-50000", "25001 to 50000", ">50000", "greater than 50000"
            };

            // The grant amount filter check.
            if (!GrantAmount[(int)GrantAmountNames.All])
            {
                if (GrantAmount[(int)GrantAmountNames.Less_Than_Thousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("less than 1000")]);
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("<1000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.Thousand_To_TenThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("1000-10000")]);
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("1000 to 10000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.TenThousandOne_To_TwentyFiveThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("10001-25000")]);
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("10001 to 25000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.TwentyFiveThousandOne_To_FiftyThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("25001-50000")]);
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("25001 to 50000")]);
                }

                if (GrantAmount[(int)GrantAmountNames.Greater_Than_FiftyThousand])
                {
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf(">50000")]);
                    filterSearchList.Add(GrantAmountList[GrantAmountList.IndexOf("greater than 50000")]);
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
                "january", "february", "march", "april", "may", "june", "july", "august", "september",
                "october", "november", "december"
            };

            // TODO Figure out what to do with grant due date. The grant due date filter check.
            if (!GrantDueDate[(int)GrantDueDateNames.All])
            {
                if (GrantDueDate[(int)GrantDueDateNames.January])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("january")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.February])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("february")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.March])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("march")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.April])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("april")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.May])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("may")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.June])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("june")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.July])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("july")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.August])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("august")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.September])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("september")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.October])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("october")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.November])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("november")]);
                }

                if (GrantDueDate[(int)GrantDueDateNames.December])
                {
                    filterSearchList.Add(GrantDueDateList[GrantDueDateList.IndexOf("december")]);
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

            // TODO Gray out the religious identification choices when religious affiliation is set to no.
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
        /*
        public void createURLend()
        {
            // Create variables here.
            String LocationURL = null;
            String RaceURL = null;
            String ReligionURL = null;

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
        */

        /*
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
        */
    }
}