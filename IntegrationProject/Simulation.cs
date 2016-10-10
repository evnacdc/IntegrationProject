using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    // Simulate real-world conditions and testing methods
    class Simulation
    {
        public static void TestCustomerDatabase(CustomerDatabase cd)
        {

            int NumCustomers = 5;
            Customer[] CustomerList = new Customer[NumCustomers];

            for (int i = 0; i < NumCustomers; i++)
            {
                CustomerList[i] = Customer.GenerateRandomCustomer();
                cd.AddCustomer(CustomerList[i]);
            }

            Console.WriteLine("Index 7 is \n\n" + cd.GetCustomer(7).ToString());
        }

        public static void TestSupplyInventoryDatabase(InventoryDatabase id)
        {
            //id.PrintDatabase();

            String RouterID = id.GetString("ItemName", "Router", "ID").Trim();
            id.PrintDatabase();
            Item Router = id.GetItem(RouterID);
            Console.WriteLine("Removing Routers");
            //while(id.RemoveItem(Router,1) == true)
            //{
            //    Console.WriteLine("There are now {0} routers", id.GetQuantity(Router) );
            //}

            id.PrintDatabase();

            //Console.WriteLine("Number of Routers : " + id.GetInt("ItemName", "Router" , "Quantity"));
        }

        public static void TestRetailCompany(RetailCompany rc)
        {
            Console.WriteLine(rc.ToString());
        }
    }
}