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
    }
}
