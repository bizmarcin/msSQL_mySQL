using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pspConnectionConsoleApp
{
    public class MySQLConnections
    {
        private MySqlConnection connection { get; set; }
        
        public MySQLConnections(MySqlConnection connection)

        {
            this.connection = connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                    default:
                        Console.WriteLine(ex);
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Create(bool connectionStatus)
        {
            string query = "CREATE TABLE testMK(" +
                "user_id INT(6) UNSIGNED," +
                "user_name VARCHAR(20) NOT NULL) ENGINE = InnoDB;";

            if (connectionStatus == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
