using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class RetailCompany:Company
    {
        // Main Company that sells Items. The company supply companies that supply
        // the inventory and a list of customers. 

        CustomerDatabase CustomerDB;
        private List<SupplyCompany> SupplyCompanies = new List<SupplyCompany>();
        private InventoryDatabase InventoryDB;

        public RetailCompany(String CompanyName, InventoryDatabase InventoryDB, CustomerDatabase CustomerDB, List<SupplyCompany> SupplyCompanies) : base(CompanyName, InventoryDB)
        {
            this.CustomerDB = CustomerDB;
            this.SupplyCompanies = SupplyCompanies;
            this.InventoryDB = InventoryDB;
        }

        public void AddSupplyCompany(SupplyCompany sc)
        {
            SupplyCompanies.Add(sc);
        }

        // Return Supply company matching prefix of inventory ID
        private SupplyCompany GetSupplyCompanyFromInventoryID(String ID)
        {
            foreach (SupplyCompany sc in SupplyCompanies)
                if (ID.StartsWith(sc.InventoryPrefix))
                    return sc;

            return null;
        }

        public void UpdateInventory()
        {
            // Update Inventory from retail vendor databases
        }

        public bool ProcessSale()
        {
            // Remove items from inventory and send product request to vendor

            return true;
        }

        private bool UpdateItem(Item i)
        {
            // Update Item information from vendor database

            return true;
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

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This is the Retail Company " + CompanyName + ".");
            sb.AppendLine("Retailers: ");
            foreach (SupplyCompany sc in SupplyCompanies)
                sb.AppendLine("    --" + sc.CompanyName);


            return sb.ToString();
        }
    }
}
