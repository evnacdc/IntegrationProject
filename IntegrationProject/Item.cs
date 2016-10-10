using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class Item
    {

        public String ItemName;
        public String InventoryID;
        public decimal Price;
        // Put image processing here
        public String Description;

        public Item(String ItemName, String InventoryID, String Description, decimal Price)
        {
            this.ItemName = ItemName;
            this.InventoryID = InventoryID;
            this.Description = Description;
            this.Price = Price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID:          " + this.InventoryID);
            sb.AppendLine("Item Name:   " + this.ItemName);
            sb.AppendLine("Price:       $" + this.Price);
            sb.AppendLine("Description: " + this.Description);

            return sb.ToString();
        }

    }
}
