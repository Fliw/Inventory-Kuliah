using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

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

        //metode untuk mengisi datagridview
        public DataSet selectPetugas()
        {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM petugas";
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                sda.Fill(ds, "petugas");
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return ds;
        }
        //metode untuk get value berdasarkan referensi id
        public List<string> getDataUpdateById()
        {
            List<string> data = new List<string>();
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM petugas WHERE ID_Petugas = " + petugasId;
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();
                int kolom = 0;
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        data.Add(reader.GetString(kolom));
                        kolom++;
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
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
        /*
         ###### METHOD FOR UPDATING DATA ######
         */


        public Boolean updateKategori()
        {
            result = false;
            try
            {
                query = "UPDATE petugas SET `Nama_Petugas` = '" + nama + "', `Password_Petugas` = '"+password+"', `Status_Petugas` = 'petugas' WHERE `ID_Kategori` = " + petugasId;
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                result = false;
            }
            return result;
        }

        /*
         ###### METHOD FOR DELETING DATA ######
         */


        public Boolean deleteKategori()
        {
            result = false;
            try
            {
                query = "DELETE FROM petugas WHERE ID_Petugas = " + petugasId;
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
                koneksi.Close();
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
