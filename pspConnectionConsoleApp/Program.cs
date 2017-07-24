using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pspConnectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var msSQLConnection = new SqlConnection("server=UNFSQL;" +
                                       "Trusted_Connection=yes;" +
                                       "database=PHDAPP; " +
                                       "connection timeout=30");

            var msSQLconn = new MsSQLConnections(msSQLConnection);
            msSQLconn.OpenConnection();

            var startTime = String.Format("{0:u}", DateTime.Now.AddHours(-1)).Replace("Z", "");
            var endTime = String.Format("{0:u}", DateTime.Now).Replace("Z", "");

            var msSQLQuerry = $"SELECT * FROM [PHDAPP].[EA].[IP_VW_EJC_PRCSS_ALARM] WHERE [TIME_STAMP]>'{startTime}' and [TIME_STAMP]<'{endTime}'";
            msSQLconn.ReadData(msSQLQuerry);

            //var mySQLconnectionString = "Server=localhost;UID=root;database=test;";
            //var connection = new MySqlConnection(mySQLConnectionString);

            //var MySqlConn = new MySQLConnections(connection);
            //var connectionStatus= MySqlConn.OpenConnection();
            //MySqlConn.Insert(connectionStatus);
            //MySqlConn.CloseConnection();
        }
    }
}
