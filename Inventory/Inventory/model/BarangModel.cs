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
                query = "INSERT INTO barang (`Nama_Barang`,`ID_Kategori`,`ID_Faktur`,`ID_Rak`,`Satuan`,`Stock`) VALUES('" + namabarang + "'," + idkategori + "," + idrak + ",'" + satuan + "'," + stock + ")";
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

        public Boolean updateBarang()
        {
            status = false;
            try
            {
                query = "UPDATE barang SET Nama_Barang  = '" + namabarang + "',ID_Kategori = " + idkategori + ",ID_Rak = " + idrak + ",Satuan = '" + satuan + "',Stock = " + stock + " WHERE ID_Barang = "+idbarang;
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
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

        public Boolean deleteBarang()
        {
            status = false;
            try
            {
                query = "DELETE FROM barang WHERE ID_Barang = " + idbarang;
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
        public int maxPK()
        {
            int kode = 0;
            try
            {
                query = "SELECT MAX(ID_Barang) FROM barang";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetByte(0).ToString()) + 1;
                }
                koneksi.Close();
            }
            catch(MySqlException)
            {
                kode = 0;
            }
            return kode;
        }
    }
}
