using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class SupplyCompany:Company
    {

        String CompanyName;
        InventoryDatabase InventoryDB;
        public String InventoryPrefix;

        public SupplyCompany(String CompanyName, InventoryDatabase InventoryDB, String InventoryPrefix) : base(CompanyName,InventoryDB)
        {
            this.InventoryPrefix = InventoryPrefix;
        }


        // Override Methods from Super
        protected override bool RemoveItemFromInventory(Item ItemType)
        {

            return true; //FIXME 
        }

        protected override bool AddItemToInventory(Item ItemType)
        {

            return true; //FIXME
        }

        protected override bool CheckAvaliability(Item ItemType, int Quantity)
        {
            throw new NotImplementedException();
        }
    }
}
