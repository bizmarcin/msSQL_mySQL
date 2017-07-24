using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace pspConnectionConsoleApp
{
    public class MsSQLConnections
    {

        private SqlConnection connection { get; set; }

        public MsSQLConnections(SqlConnection connection)

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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Number);
                Console.ReadKey();
                switch (ex.Number)
                {
                    case -2:
                        Console.WriteLine("Connection time out");
                        break;

                    case 20:
                        Console.WriteLine("Encryption capability mismatch");
                        break;
                    default:
                        Console.WriteLine(ex);
                        break;
                }
                return false;
            }
        }

        public void ReadData(string querry)
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(querry, connection);
                myReader = myCommand.ExecuteReader();
                var counter = 0;
                while (myReader.Read())
                {
                    counter++;
                    Console.WriteLine($"{counter}- {myReader["ID_NO"].ToString()} " +
                                      $"{myReader["TIME_STAMP"].ToString()} " +
                                      $"{myReader["SRC_NODE"].ToString()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
