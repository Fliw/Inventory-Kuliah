using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Inventory.model
{
    
    class BarangModel
    {
        private MySqlConnection koneksi;
        private int IDBarang, IDKategori, IDFaktur, IDRak, Stock;
        private string NamaBarang, Satuan;
        private int idbarang { get { return IDBarang; } set { IDBarang = value; } }
        private int idfaktur { get { return IDFaktur; } set { IDFaktur = value; } }
        private int idkategori { get { return IDKategori; } set { IDKategori = value; } }
        private int idrak { get { return IDRak; } set { IDRak = value; } }
        private int stock { get { return Stock; } set { Stock = value; } }
        private string namabarang { get { return NamaBarang; } set { NamaBarang = value; } }
        private string satuan { get { return Satuan; } set { Satuan = value; } }

        private MySqlCommand command;
        private string query;
        private Boolean status;
        public BarangModel() {
            this.koneksi = DBConnect.GetConnection();
        }

        public DataSet selectBarang() {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM barang";
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.Fill(ds, "barang");
                koneksi.Close();
            }
            catch (MySqlException)
            {

            }
            return ds;
        }

        public Boolean insertBarang() {
            status = false;
            try
            {
                query = "INSERT INTO barang VALUES(" + idbarang + ",'" + namabarang + "'," + idkategori + "," + idrak + ",'" + satuan + "'," + stock + ")";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException)
            {
                status = false;
            }
            return status;
        }
    }
}
