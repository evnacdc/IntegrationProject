using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class CustomerDatabase : Database
    {
        // Sql Commands
        SqlCommand GetCustomerCmd;
        SqlCommand AddCustomerCmd;

        // Sql Readers
        SqlDataReader GetCustomerReader;

        // Super Constructor
        public CustomerDatabase(String ServerName, String DatabaseName, String TableName) : base(ServerName, DatabaseName, TableName)
        {
            // New Customers ID value will start at last used ID value
            if(GetLastID() != ProgramSettings.CustomerIDStartValue)
                Customer.SetCustomerIDCounter(GetLastID()+1);
        }

        public bool ExistingCustomer(Customer c)
        {
            return true;
        }

        public Customer GetCustomer(int cid)
        {
            // Returns Customer for given ID
            Customer c = null;
            String CommandString = "SELECT * FROM " + TableName + " where ID = " + cid;
            SqlDataReader rdr = SetupDataReader(CommandString);

            if(rdr.Read())
                c = SqlToCustomerObject(rdr);
            Conn.Close();

            return c;
        }

        private Customer SqlToCustomerObject(SqlDataReader reader)
        {
            try 
            {
                int ID = (int)reader["ID"];
                String FirstName = reader["FirstName"].ToString().Trim() ;
                String LastName = reader["LastName"].ToString().Trim();
                String UserName = reader["UserName"].ToString().Trim();
                String Password = reader["Password"].ToString().Trim();
                String EmailAddress = reader["EmailAddress"].ToString().Trim();
                String City = reader["City"].ToString().Trim();
                String State = reader["State"].ToString().Trim();
                String Address = reader["Address"].ToString().Trim();
                int ZipCode = (int)reader["ZipCode"];

                return new Customer(ID, FirstName, LastName,
                    new Address(State, City, ZipCode, Address), UserName, Password, EmailAddress, 0);
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to Format Sql Line to Customer Object");
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        // Return the highest ID value from database
        public int GetLastID()
        {
            int ID = ProgramSettings.CustomerIDStartValue;
            String SqlCommandString = "SELECT MAX(ID) FROM " + TableName;

            SqlDataReader rdr = SetupDataReader(SqlCommandString);

            //There exists ID in table
            if (rdr.Read())
                if(!rdr.IsDBNull(0))
                    ID = (int)rdr.GetSqlInt32(0);

            Conn.Close();

            return ID;
        }

        public int[] GetCustomerIDList()
        {

            return null;
        }

        public bool AddCustomer(Customer c)
        {

            String SqlParamString = "INSERT INTO " + TableName + " (ID, FirstName, LastName, UserName, Password, EmailAddress, City, State, Address, ZipCode ) VALUES (@ID, @FirstName, @LastName, @UserName, @Password, @EmailAddress, @City, @State, @Address, @ZipCode )";

            AddCustomerCmd = new SqlCommand(SqlParamString);

            AddCustomerCmd.Connection = Conn;
            AddCustomerCmd.Parameters.AddWithValue("@ID"          , c.CustomerID);
            AddCustomerCmd.Parameters.AddWithValue("@FirstName"   , c.FirstName);
            AddCustomerCmd.Parameters.AddWithValue("@LastName"    , c.LastName);
            AddCustomerCmd.Parameters.AddWithValue("@UserName"    , c.UserName);
            AddCustomerCmd.Parameters.AddWithValue("@Password"    , c.Password);
            AddCustomerCmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);
            AddCustomerCmd.Parameters.AddWithValue("@City"        , c.CustomerAddress.City);
            AddCustomerCmd.Parameters.AddWithValue("@State"       , c.CustomerAddress.State);
            AddCustomerCmd.Parameters.AddWithValue("@Address"     , c.CustomerAddress.StreetAddress);
            AddCustomerCmd.Parameters.AddWithValue("@ZipCode"     , c.CustomerAddress.Zip);

            try
            {
                Conn.Open();
                AddCustomerCmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to add customer to Database");
                Console.WriteLine(e.ToString() + "\n");
            }

            return true;
        }

        public bool RemoveCustomer(Customer c)
        {
            return true;
        }

        public override void PrintDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
