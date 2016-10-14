using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class Customer
    {

        // Customer Info
        public String FirstName {  get; set; }
        public String LastName { get; set; }
        public int CustomerID { get; set; }
        public Address CustomerAddress { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String EmailAddress { get; set; }
        public double CreditCardNumber { get; set; }
        public int CreditCardScore { get; set; }

        private static int CustomerIDCounter = ProgramSettings.CustomerIDStartValue; 

        // Make New Customer with Unique ID
        public Customer(String FirstName, String LastName, Address CustomerAddress, String UserName, String Password, String EmailAddress, double CreditCardNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CustomerAddress = CustomerAddress;
            this.UserName = UserName;
            this.Password = Password;
            this.EmailAddress = EmailAddress;
            this.CreditCardNumber = CreditCardNumber;
            this.CreditCardScore = this.RunCreditReport();
            this.CustomerID = CustomerIDCounter++;      //Put in better solution in future so that ID Counter does not reset every time program restarts
        }

        // Make object of Customer with existing ID
        public Customer(int CustomerID, String FirstName, String LastName, Address CustomerAddress, String UserName, String Password, String EmailAddress, double CreditCardNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CustomerAddress = CustomerAddress;
            this.UserName = UserName;
            this.Password = Password;
            this.EmailAddress = EmailAddress;
            this.CreditCardNumber = CreditCardNumber;
            this.CreditCardScore = this.RunCreditReport();
            this.CustomerID = CustomerID;
        }

        // Minimum Constructor
        public Customer(String FirstName, String LastName, Address CustomerAddress)
            : this(FirstName, LastName, CustomerAddress, ProgramSettings.DefaultUserName, ProgramSettings.DefaultPassword, ProgramSettings.DefaultEmailAddress, ProgramSettings.DefaultCreditCardNumber) { }


        // Methods
        public int RunCreditReport()
        {
            this.CreditCardScore = (int)this.CreditCardNumber % 100;    // Score is 0-100
            return this.CreditCardScore;
        }

        public static void SetCustomerIDCounter(int counter)
        {
            CustomerIDCounter = counter;
        }

        public bool IsCreditGood()
        {
            if (this.RunCreditReport() > ProgramSettings.MinimumAcceptableCredit)
                return true;
            else
                return false;
        }

        public static Customer GenerateRandomCustomer()
        {
            String State      = UsefulMethods.GetRandomString(ProgramSettings.StateNameBank);
            String City       = UsefulMethods.GetRandomString(ProgramSettings.CityNameBank);
            String Street     = UsefulMethods.GetRandomNumber(100,9999).ToString() + ' ' +  UsefulMethods.GetRandomString(ProgramSettings.StreetNameBank);
            String FirstName  = UsefulMethods.GetRandomString(ProgramSettings.FirstNameBank);
            String LastName   = UsefulMethods.GetRandomString(ProgramSettings.LastNameBank);

            int Zip = UsefulMethods.GetRandomNumber(10000, 99999);

            Address addr = new Address(State, City, Zip, Street);
            Customer c = new Customer(FirstName, LastName, addr);
            c.EmailAddress = FirstName + LastName + "@email.net";
            return c;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name:    " + this.FirstName + " "  + this.LastName);
            sb.AppendLine("ID#:     " + this.CustomerID.ToString());
            sb.AppendLine(this.CustomerAddress.ToString() + "\n");

            return sb.ToString();
        }
    }
}
