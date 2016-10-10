using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    abstract class Company
    {
        InventoryDatabase InventoryDB = null;
        public String CompanyName;
        int CompanyID;
        private static int CompanyIDCounter = 1;

        public Company(String CompanyName, InventoryDatabase InventoryDB)
        {
            this.CompanyName = CompanyName;
            this.InventoryDB = InventoryDB;
            this.CompanyID = CompanyIDCounter++;
        }

        // Check if item is in stock. For retailers, first check vendor avaliability
        protected abstract bool CheckAvaliability(Item ItemType, int Quantity);

        // Remove Item From Database and Send Notification to other Databases
        protected abstract bool RemoveItemFromInventory(Item ItemType);

        // Add Item to Database and Send Notification to other Databases
        protected abstract bool AddItemToInventory(Item ItemType);

        public void PrintInventory()
        {
            if (InventoryDB != null)
                Console.WriteLine(InventoryDB.ToString());
            else
                Console.WriteLine("Company Does not have inventory database setup.");
        }
    }
}