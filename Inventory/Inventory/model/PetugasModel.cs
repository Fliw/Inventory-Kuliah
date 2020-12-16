using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Inventory.model
{
    class PetugasModel
    {
        //properti mysql
        public MySqlConnection koneksi;
        private MySqlCommand command;
        private string query;
        //properti custom
        private bool result;
        //properti kolom tabel
        private int petugasId;
        private string nama, password, status;
        //setter & getter kolom tabel
        public int PetugasId { get { return petugasId; } set { petugasId = value; } }
        public string Nama { get { return nama; } set { nama = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Status { get { return status; } set { status = value; } }
       
      

        /*
         ###### CONSTRUCTOR ######
         */

        public PetugasModel()

        {
            this.koneksi = DBConnect.GetConnection();
        }

        /*
         ###### METHOD FOR SELECTING DATA ######
         */

        public bool LoginCheck()
        {
            query = "SELECT Nama_Petugas, Password_Petugas FROM petugas WHERE Nama_Petugas = '" + nama + "' AND Password_Petugas = '" + password + "'";
            koneksi.Open();
            command = koneksi.CreateCommand();
            command.CommandText = query;
            MySqlDataReader datareader = command.ExecuteReader();
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
            koneksi.Close();
            return result;

        }


        /*
         ###### METHOD FOR INSERTING DATA ######
         */


        public void RegisterPetugas()
        {
            this.koneksi.Open();
            MySqlCommand query = new MySqlCommand("INSERT INTO `PETUGAS` (`Nama_Petugas`,`Password_Petugas`,`Status_Petugas`) VALUES ('" + nama + "','" + password + "','" + status + "')", koneksi);
            query.ExecuteNonQuery();
            MessageBox.Show("Hai " + nama + "!, Selamat akunmu telah berhasil dibuat!");
        }
    }
}
