using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class ProgramSettings
    {
        // Customer.cs
        public static int MinimumAcceptableCredit = 5;
        public static double DefaultCreditCardNumber = 0;
        public static String DefaultUserName = "user";
        public static String DefaultPassword = "password";
        public static String DefaultEmailAddress = "reallyGoodEmailAddress420@email.edu";
        public static String[] FirstNameBank =
            {"Evan","Sean","Jacob","Ashley","Arda","John","Adam","Alexis","Bernie","Jacquelline",
            "Sarah", "Becky", "Ross", "Xavier", "Jesus", "Juan", "Allison", "Jamie", "Chris" };
        public static String[] LastNameBank =
            {"Wetherington","Smith","Burke","Cole","Chaguay","Proulx","Whitfield","Adams","Lee",
            "Stortz","Looper","Jacobson","Baker","Trump","Waugh" };
        public static String[] StreetNameBank =
            {"Johnson Pt Rd", "Melrose Valley Cir", "Smith St", "Main St", "Hillsborrough St", "Western Bvld",
            "Gorman St", "5th St"};
        public static String[] CityNameBank =
            {"Raleigh", "New Bern", "Havelock", "New York", "Greenville", "Las Vegas", "San Francisco", "Houston"};
        public static String[] StateNameBank = { "NC", "VA", "CA", "NY", "FL", "NJ", "TX" };

        // Database.cs
        public static String GreatCoDatabaseName   = "GreatCoDatabase";
        public static String GadgetsCoDatabaseName = "GadgetsCoDatabase";
        public static String WidgetsCoDatabaseName = "WidgetsCoDatabase";
        public static String DatabaseServerName    = "(local)";
        public static String InventoryTableName    = "Inventory";
        public static String CustomerTableName     = "Customers";
        public static int CustomerIDStartValue     = 1;
        public static int EntryDoesNotExist        = -1;

        // Inventory Database
        public static int MaxDescriptionLength = 400;
        public static int PrintDescriptionLength = 50;

        // Company.cs
        public static String GadgetsCoPrefix = "GC";
        public static String WidgetsCoPrefix = "WC";
    }
}
