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

        public int GetQuantity(Item ItemType)
        {
            return InventoryDB.GetQuantity(ItemType);
        }

        // Return Item of ItemID
        public Item GetItem(String ItemID)
        {
            return InventoryDB.GetItem(ItemID);
        }

        public void SetQuantity(Item ItemType, int Quantity)
        {
            InventoryDB.SetItemQuantity(ItemType, Quantity);
        }

        public void PrintInventory()
        {
            if (InventoryDB != null)
                Console.WriteLine(InventoryDB.ToString());
            else
                Console.WriteLine("Company Does not have inventory database setup.");
        }
    }
}