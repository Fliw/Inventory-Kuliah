using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Inventory.model
{
    class LoginModel
    {
        private MySqlConnection connection;
        private string query;
        private bool result;
        private MySqlCommand command;

        //2.konstruktor memanggil koneksi
        public LoginModel()
        {
            connection = DBConnect.GetConnection();
        }

        //3. deklarasikan variabel (enkapsulasi)
        //a. information tersembunyi
        //hak access private
        private int petugasId;
        private string nama, password, status;
        //b. interface untuk access data
        public int PetugasId { get { return petugasId; } set { petugasId = value; } }
        public string Nama { get { return nama; } set { nama = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Status { get { return status; } set { status = value; } }
        //4. function check login
        public bool LoginCheck()
        {
            //siapkan query
            query = "SELECT Nama_Petugas, Password_Petugas FROM petugas WHERE Nama_Petugas = '" + nama + "' AND Password_Petugas = '" + password + "'";
            //opendb
            connection.Open();
            //Execute query
            command = connection.CreateCommand();
            command.CommandText = query;
            //data
            MySqlDataReader datareader = command.ExecuteReader();
            //read data
            while (datareader.Read())
            {
                if (datareader.GetString(0).ToString() == nama &&
                    datareader.GetString(1).ToString() == password)
                {
                    
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            connection.Close();
            return result;

        }

     
    }
}

