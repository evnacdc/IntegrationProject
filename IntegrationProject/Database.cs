using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    abstract class Database
    {

        public String ServerName;
        public String DatabaseName;
        public String TableName;

        protected SqlConnection Conn;
        protected SqlCommand EraseDatabaseCommand;

        private bool Connected = false;


        public Database(String ServerName, String DatabaseName, String TableName)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.TableName = TableName;
            SetupConnection();
        }

        // Methods
        private bool SetupConnection()
        {
            Connected = false;
            try
            {
                Conn = new SqlConnection("Server=" + ServerName +
                        ";Database=" + DatabaseName + ";Integrated Security=true");
                Connected = true;
                Console.WriteLine("Connected to " + DatabaseName);
                return Connected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Connected;
        }

        private bool Disconnect()
        {
            try
            {
                Conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }

        protected SqlDataReader SetupDataReader(String SqlCommand)
        {
            try
            {
                SqlCommand ReadCmd = new SqlCommand(SqlCommand, Conn);
                Conn.Open();
                SqlDataReader rdr = ReadCmd.ExecuteReader();
                return rdr;
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to create sql reader");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        // Returns String at Column "ReturnKey" where (String)Index == Search Key
        public String GetString(String SearchKey, String Index, String ReturnKey)
        {
            SqlDataReader ReadCmd = null;
            try
            {
                String SqlCommandString = "SELECT " + ReturnKey + " FROM " + TableName + " where " + SearchKey + " = " + FormattedSqlString(Index);
                ReadCmd = SetupDataReader(SqlCommandString);
                ReadCmd.Read();
                return ReadCmd.GetString(0).ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to Search for " + ReturnKey + " where " + SearchKey + " = " + FormattedSqlString(Index));
                return null;
            }
            finally
            {
                if (ReadCmd != null)
                    ReadCmd.Close();
                Conn.Close();
            }
        }

        // Returns String at Column "ReturnKey" where (int)Index == Search Key
        public String GetString(String SearchKey, int Index, String ReturnKey)
        {
            // Cast Index to String and call overloaded method
            return GetString(SearchKey, Index.ToString(), ReturnKey);
        }

        // Returns Int at Column "ReturnKey" where (String)Index == Search Key
        public int GetInt(String SearchKey, String Index, String ReturnKey)
        {
            SqlDataReader ReadCmd = null;
            try
            {
                String SqlCommandString = "SELECT " + ReturnKey + " FROM " + TableName + " where " + SearchKey + " = " + FormattedSqlString(Index);
                ReadCmd = SetupDataReader(SqlCommandString);
                ReadCmd.Read();
                return (int)ReadCmd.GetInt32(0);
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to Search for " + ReturnKey + " where " + SearchKey + " = " + FormattedSqlString(Index));
                return ProgramSettings.EntryDoesNotExist;
            }
            finally
            {
                if (ReadCmd != null)
                    ReadCmd.Close();
                Conn.Close();
            }
        }

        // Returns Int at Column "ReturnKey" where (int)Index == Search Key
        public int GetInt(String SearchKey, int Index, String ReturnKey)
        {
            // Cast Index to String and call overloaded method
            return GetInt(SearchKey, Index.ToString(), ReturnKey);
        }

        // Add single quotes around String
        protected String FormattedSqlString(String s)
        {
            return new StringBuilder().Append("'").Append(s).Append("'").ToString();
        }

        protected void RunSingleSqlCommand(String SqlCommandString)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(SqlCommandString,Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to run sql command");
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Conn.Close();
            }
        }

        public void EraseDatabase()
        {
            // Put Stuff Here
        }

        public abstract void PrintDatabase();

    }
}
