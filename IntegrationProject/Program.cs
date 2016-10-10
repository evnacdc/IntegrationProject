using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class Program
    {

        private InventoryDatabase GreatCoInventoryDatabase;
        private InventoryDatabase WidgetsCoInventoryDatabase;
        private InventoryDatabase GadgetsCoInventoryDatabase;

        private CustomerDatabase GreatCoCustomerDatabase;

        private RetailCompany GreatCo;

        private SupplyCompany WidgetsCo;
        private SupplyCompany GadgetsCo;


        static void Main(string[] args)
        {
            Program p = new Program();
        }

        public Program()
        {
            //////////////////////
            // START OF PROGRAM //
            //////////////////////

            Init();

            //Simulation.TestCustomerDatabase(GreatCoCustomerDatabase);
            //Simulation.TestSupplyInventoryDatabase(WidgetsCoInventoryDatabase);
            Simulation.TestRetailCompany(GreatCo);


            ////////////////////
            // END OF PROGRAM //
            ////////////////////
            Console.ReadKey();
        }

        private void Init()
        {
            InitDatabases();
            InitCompanies();
        }

        private void InitDatabases()
        {
            // Inventory Databases
            GreatCoInventoryDatabase   = new InventoryDatabase(ProgramSettings.DatabaseServerName, ProgramSettings.GreatCoDatabaseName,   ProgramSettings.InventoryTableName);
            WidgetsCoInventoryDatabase = new InventoryDatabase(ProgramSettings.DatabaseServerName, ProgramSettings.WidgetsCoDatabaseName, ProgramSettings.InventoryTableName);
            GadgetsCoInventoryDatabase = new InventoryDatabase(ProgramSettings.DatabaseServerName, ProgramSettings.GadgetsCoDatabaseName, ProgramSettings.InventoryTableName);

            // Customer Database
            GreatCoCustomerDatabase    = new CustomerDatabase(ProgramSettings.DatabaseServerName, ProgramSettings.GreatCoDatabaseName, ProgramSettings.CustomerTableName);
        }

        private void InitCompanies()
        {
            // Supply Companies
            WidgetsCo = new SupplyCompany("WidgetsCo", WidgetsCoInventoryDatabase, ProgramSettings.WidgetsCoPrefix);
            GadgetsCo = new SupplyCompany("GadgetsCo", GadgetsCoInventoryDatabase, ProgramSettings.GadgetsCoPrefix);

            // Retail Company
            List<SupplyCompany> SupplyCompanies = new List<SupplyCompany>();
            SupplyCompanies.Add(WidgetsCo);
            SupplyCompanies.Add(GadgetsCo);
            GreatCo = new RetailCompany("GreatCo", GreatCoInventoryDatabase, GreatCoCustomerDatabase, SupplyCompanies);
        }
    }
}
