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
        private MySqlConnection koneksi;
        private int IDKategori;
        private string NamaKategori;
        public int idkategori { get { return IDKategori; } set { IDKategori = value; } }
        public string namakategori { get { return NamaKategori;} set { NamaKategori = value; } }
        private MySqlCommand command;
        private string query;
        private Boolean status;
        public KategoriModel()
        {
            koneksi = DBConnect.GetConnection();
        }
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
