using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Inventory.model
{
    class KategoriModel
    {
        //properti mysql
        private MySqlConnection koneksi;
        private MySqlCommand command;
        private string query;
        //properti custom
        private Boolean status;
        //properti berdasarkan kolom
        private int IDKategori;
        private string NamaKategori;

        //setter & getter untuk kolom tabel
        public int idkategori { get { return IDKategori; } set { IDKategori = value; } }
        public string namakategori { get { return NamaKategori;} set { NamaKategori = value; } }


        /*
         ###### CONSTRUCTOR ######
         */


        public KategoriModel()
        {
            koneksi = DBConnect.GetConnection();
        }

        /*
         ###### METHOD FOR SELECTING DATA ######
         */

        //metode untuk mengisi datagridview
        public DataSet selectKategori()
        {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM kategori";
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                sda.Fill(ds, "kategori");
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
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
                command.CommandText = "SELECT * FROM kategori WHERE ID_Kategori = " + idkategori;
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
                System.Windows.MessageBox.Show(e.Message);
            }
            return data;
        }


        /*
         ###### METHOD FOR INSERTING DATA ######
         */


        public Boolean insertKategori()
        {
            status = false;
            try
            {
                query = "INSERT INTO kategori (`Nama_Kategori`) VALUES ('"+namakategori+"')";
                koneksi.Open();
                command = new MySqlCommand();
                command.CommandText = query;
                command.Connection = koneksi;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                status = false;
            }
            return status;
        }


        /*
         ###### METHOD FOR UPDATING DATA ######
         */


        public Boolean updateKategori()
        {
            status = false;
            try
            {
                query = "UPDATE kategori SET `Nama_Kategori` = '" + namakategori + "' WHERE `ID_Kategori` = "+idkategori;
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                status = false;
            }
            return status; 
        }

        /*
         ###### METHOD FOR DELETING DATA ######
         */


        public Boolean deleteKategori()
        {
            status = false;
            try
            {
                query = "DELETE FROM kategori WHERE ID_Kategori = " + idkategori;
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
