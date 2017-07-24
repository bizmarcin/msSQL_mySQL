using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pspConnectionConsoleApp
{
    public class MySQLConnection
    {

        public static MySqlConnection Connection()
        {
            //var connectionString = "Server = APLSWEB; Database = psp2; Uid = root; Pwd = Flatron300; ";
            var connectionString = "Server=172.27.38.90;UID=root;Pwd=Flatron300;database=psp2;";
            var connection = new MySqlConnection(connectionString);
            return connection;
            
        }

        public static bool OpenConnection(MySqlConnection connection)
        {

            Console.WriteLine("3");
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Number);
                Console.ReadKey();
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public static bool CloseConnection(MySqlConnection connection)
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

        public static void Insert(MySqlConnection connection, bool connectionStatus)
        {
            Console.WriteLine("6");
            string query = "CREATE TABLE testMK(" +
                "user_id INT(6) UNSIGNED NOT_NULL AUTO_INCREMENT PRIMARY KEY," +
                "user_name VARCHAR(20) NOT NULL) ENGINE = InnoDB;";

            //open connection
            if (connectionStatus == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                Console.WriteLine("7");
            }
        }
    }
}
