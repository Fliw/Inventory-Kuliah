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
        private int petugasId;
        private string nama, password, status;
        public int PetugasId { get { return petugasId; } set { petugasId = value; } }
        public string Nama { get { return nama; } set { nama = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Status { get { return status; } set { status = value; } }
        public MySqlConnection koneksi;
        private string query;
        private bool result;
        private MySqlCommand command;
        public PetugasModel()
        {
            this.koneksi = DBConnect.GetConnection();
        }
        public void RegisterPetugas()
        {
            this.koneksi.Open();
            MySqlCommand query = new MySqlCommand("INSERT INTO `PETUGAS` (`Nama_Petugas`,`Password_Petugas`,`Status_Petugas`) VALUES ('" + nama + "','" + password + "','"+status+"')",koneksi);
            query.ExecuteNonQuery();
            MessageBox.Show("Hai " +nama+ "!, Selamat akunmu telah berhasil dibuat!");
        }
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
    }
}
