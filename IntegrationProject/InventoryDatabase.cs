using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class InventoryDatabase : Database
    {

        private List<Item> AllItems = new ArrayList<Item>();    // List of all Items in Inventory

        // Super Constructor
        public InventoryDatabase(String ServerName, String DatabaseName, String TableName) : base(ServerName, DatabaseName, TableName) { }

        public bool CheckAvaliability(NewOrder no)
        {
            return true;
        }

        public bool CheckAvaliability(Item i, int quantity)
        {
            if (GetQuantity(i) >= quantity)
            {
                Conn.Close();
                return true;
            }
            Conn.Close();
            return false;
        }

        // Checks if amount reqested is availible in inventory and removes "quantity" number of items
        public bool RemoveItem(Item i, int quantity)
        {
            // Remove Item From Inventory
            if (quantity > 0)
            {
                if (CheckAvaliability(i, quantity) == true)
                {
                    ChangeItemQuantity(i, -quantity);
                    return true;
                }
                else
                {
                    Console.WriteLine("Reqested to remove more " + i.ItemName + " than are in inventory.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid Quantity Number to remove");
            }
            return false;
        }

        public void DeleteItem(Item i)
        {
            // Completely Remove Item from Database
        }

        public bool AddExistingItem(Item i, int quantity)
        {
            if (quantity > 0)
            {
                ChangeItemQuantity(i, quantity);
                return true;
            }
            Console.WriteLine("Invalid Quantity Number to Add.");
                return false;
        }

        public void AddNewItem(Item i, int quantity)
        {
            // Insert new Item entry into inventory
        }

        private void ChangeItemQuantity(Item i, int quantity)
        {
            // Add or removes item from inventory without checking current quantity
            String SqlCommandString = "UPDATE " + TableName + " SET Quantity = Quantity + " + quantity.ToString() +
                " WHERE ID = " + FormattedSqlString( i.InventoryID );
            RunSingleSqlCommand(SqlCommandString);
        }

        public void SetItemQuantity(Item i, int quantity)
        {
            // Set Quantity of item to "quantity"
            String SqlCommandString = "UPDATE " + TableName + " SET Quantity = " + quantity.ToString() +
                " WHERE ID = " + FormattedSqlString(i.InventoryID);
            RunSingleSqlCommand(SqlCommandString);
        }

        public int GetQuantity(Item i)
        {
            return GetInt("ID", i.InventoryID, "Quantity");
        }

        public bool ItemExists(Item i)
        {
            // Call overloaded method
            return ItemExists(i.InventoryID);
        }

        public bool ItemExists(String ID)
        {
            SqlDataReader ReadCmd = null;
            try
            {
                String SqlCommandString = "SELECT ItemName FROM " + TableName + " where ID = " + FormattedSqlString(ID);
                ReadCmd = SetupDataReader(SqlCommandString);
                if (ReadCmd.Read())    // Item Exists in database
                {
                    ReadCmd.Close();
                    return true;
                }
            }
            catch(Exception e)  { }
            finally
            {
                if (ReadCmd != null)
                    ReadCmd.Close();
                Conn.Close();
            }
            return false;
        }

        List<String> GetItemIDFromName(String ItemName)
        {
            List<String> IDList = new List<String>();
            SqlDataReader ReadCmd = null;
            try
            {
                int i = 0;
                String SqlCommandString = "SELECT ID FROM " + TableName + " where  ItemName  = " + FormattedSqlString(ItemName);
                ReadCmd = SetupDataReader(SqlCommandString);
                while (ReadCmd.Read())
                {
                    IDList.Add(ReadCmd.GetString(0));
                }
                return IDList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                if (ReadCmd != null)
                    ReadCmd.Close();
                Conn.Close();
            }
        }

        private Item SqlToItemObject(SqlDataReader reader)
        {
            try
            {
                String ItemName = reader["ItemName"].ToString().Trim();
                String ID = reader["ID"].ToString().Trim();
                String Description = reader["Description"].ToString().Trim();
                decimal Price = (decimal)reader["Price"];

                return new Item(ItemName, ID, Description, Price);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Format Sql Line to Item Object");
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public override void PrintDatabase()
        {
            String SqlCommandString = "SELECT * FROM " + TableName; ;
            SqlDataReader ReadCmd = SetupDataReader(SqlCommandString);
            while(ReadCmd.Read())
            {
                Console.WriteLine(PrintInventoryItem(ReadCmd));
            }
            Conn.Close();
            ReadCmd.Close();
        }

        private String PrintInventoryItem(SqlDataReader r)
        {
            if (!r.IsDBNull(0))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID:          " + r["ID"].ToString());
                sb.AppendLine("Item Name:   " + r["ItemName"].ToString());
                sb.AppendLine("Price:       $" + r["Price"].ToString());
                sb.AppendLine("Description: " + r["Description"].ToString().Substring(0, ProgramSettings.PrintDescriptionLength));
                sb.AppendLine("Quantity:    " + r["Quantity"].ToString() + "\n");

                return sb.ToString();
            }
            else
            {
                Console.WriteLine("Tried to read null value from Inventory");
                return null;
            }
        }
        
        public Item GetItem(String ID)
        {
            SqlDataReader ReadCmd = null;
            try
            {
                String SqlCommandString = "SELECT * FROM " + TableName + " WHERE ID = " + FormattedSqlString(ID);
                ReadCmd = SetupDataReader(SqlCommandString);
                ReadCmd.Read();
                Item i = SqlToItemObject(ReadCmd);

                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Finding Item ID " + ID);
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if(ReadCmd != null)
                    ReadCmd.Close();
                Conn.Close();
            }
            return null;
        }
    }
}
