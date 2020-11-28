using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
namespace Inventory.model
{
    class DBConnect
    {
        public static MySqlConnection GetConnection()
        {
            string strConnect = "SERVER = localhost;" + "PORT = 3306;" + "UID = root;" + "PWD = ;" + "DATABASE = pemograman";
            return new MySqlConnection(strConnect);
        }
    }
}
