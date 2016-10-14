using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class SupplyCompany:Company
    {

        InventoryDatabase InventoryDB;
        public String InventoryPrefix;

        public SupplyCompany(String CompanyName, InventoryDatabase InventoryDB, String InventoryPrefix) : base(CompanyName,InventoryDB)
        {
            this.InventoryPrefix = InventoryPrefix;
        }

        // Override Methods from Super
        public bool RemoveItemsFromInventory(Item ItemType, int Quantity)
        {
            return true; //FIXME 
        }

        public bool AddItemsToInventory(Item ItemType, int Quantity)
        {
            return true; //FIXME
        }

        public bool CheckAvaliability(Item ItemType, int Quantity)
        {
            return InventoryDB.CheckAvaliability(ItemType, Quantity);
        }
    }
}
