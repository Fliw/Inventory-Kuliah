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
        //properti sesuai kolom di tabel
        private int IDBarang, IDKategori, IDFaktur, IDRak, Stock, Petugas;
        private string NamaBarang, Satuan,Tanggal;
        //properti mysql
        private MySqlConnection koneksi;
        private MySqlCommand command;
        private string query;
        //properti custom
        private Boolean status;

        //setter & getter untuk semua kolom tabel
        public int idbarang { get { return IDBarang; } set { IDBarang = value; } }
        public int idfaktur { get { return IDFaktur; } set { IDFaktur = value; } }
        public int idkategori { get { return IDKategori; } set { IDKategori = value; } }
        public int idrak { get { return IDRak; } set { IDRak = value; } }
        public int stock { get { return Stock; } set { Stock = value; } }
        public int petugas { get { return Petugas; } set { Petugas = value; } }
        public string namabarang { get { return NamaBarang; } set { NamaBarang = value; } }
        public string satuan { get { return Satuan; } set { Satuan = value; } }
        public string tanggal { get { return Tanggal; } set { Tanggal = value; } }


        /*
         ###### CONSTRUCTOR ######
         */

        public BarangModel() {
            this.koneksi = DBConnect.GetConnection();
        }

        /*
         ###### METHOD FOR SELECTING DATA ######
         */

        //metode untuk mengisi datagrid view
        public DataSet selectBarang() {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                command              = new MySqlCommand();
                command.Connection   = koneksi;
                command.CommandType  = CommandType.Text;
                command.CommandText  = "SELECT barang.ID_Barang AS `Nomor Barang`, " +
                    "barang.Nama_Barang AS `Nama Barang`," +
                    "rak.Nama_Rak AS `Nama Rak`, " +
                    "kategori.Nama_Kategori AS `Nama Kategori`,  " +
                    "petugas.Nama_Petugas AS `Petugas Bertanggung Jawab`, " +
                    "barang.Satuan,barang.Stock,barang.Tanggal FROM barang " +
                    "INNER JOIN rak ON barang.ID_Rak = rak.ID_Rak " +
                    "INNER JOIN kategori ON barang.ID_Kategori = kategori.ID_Kategori " +
                    "INNER JOIN barangkeluar ON barang.ID_Faktur_Keluar = barangkeluar.ID_Faktur_Keluar " +
                    "INNER JOIN petugas on barangkeluar.ID_Petugas = petugas.ID_Petugas " +
                    "GROUP BY barang.ID_Barang " +
                    "ORDER BY barang.ID_Barang ASC";
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand    = command;
                sda.Fill(ds, "barang");
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return ds;
        }

        //metode untuk mengisi combobox rak
        public List<string> fillComboRak()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT Nama_Rak FROM rak";
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            comboArrayList.Add("Null");
                        else
                            comboArrayList.Add(reader[i].ToString());
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

            return comboArrayList;
        }
        
        //metode untuk mengisi combobox petugas
        public List<string> fillComboPetugas()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT Nama_Petugas FROM petugas";
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            comboArrayList.Add("Null");
                        else
                            comboArrayList.Add(reader[i].ToString());
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

            return comboArrayList;
        }

        //metode untuk mengisi combobox kategori
        public List<string> fillComboKategori()
        {
            List<string> comboArrayList = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT Nama_Kategori FROM kategori";
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            comboArrayList.Add("Null");
                        else
                            comboArrayList.Add(reader[i].ToString());
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

            return comboArrayList;
        }

        //metode untuk mengambil MAX PK dari faktur
        public int maxPKFaktur()
        {
            int kode = 0;
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT MAX(ID_Faktur_keluar) FROM barangkeluar";
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var ii = reader.FieldCount;
                    for (int i = 0; i < ii; i++)
                    {
                        if (reader[i] is DBNull)
                            kode = 0;
                        else
                            kode = Int16.Parse(reader.GetString(0).ToString());
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException)
            {
                kode = 0;
            }
            return kode;
        }

        //metode untuk mencari data kategori berdasarkan id yang direferensikan
        public int searchKategoriID(string nama)
        {
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT ID_Kategori FROM kategori WHERE Nama_Kategori = '" + nama + "' LIMIT 1";
                command.Connection = koneksi;
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0] is DBNull)
                        this.idkategori = 0;
                    else
                        this.idkategori = reader.GetInt32(0);
                }
                koneksi.Close();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

            return this.idkategori;
        }

        //metode untuk mencari data rak berdasarkan id yang direferensikan
        public int searchRakID(string nama)
        {
            try
            {
                koneksi.Open();
                {
                    MySqlCommand command = new MySqlCommand();
                    command.CommandText = "SELECT ID_Rak FROM rak WHERE Nama_Rak = '" + nama + "' LIMIT 1";
                    command.Connection = koneksi;
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[0] is DBNull)
                            this.idrak = 0;
                        else
                            this.idrak = reader.GetInt32(0);
                    }
                }
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            koneksi.Close();
            return this.idrak;
        }

        //metode untuk mencari data petugas berdasarkan id yang direferensikan
        public int searchPetugasID(string nama)
        {
            try
            {
                koneksi.Open();
                {
                    MySqlCommand command = new MySqlCommand();
                    command.CommandText = "SELECT ID_Petugas FROM petugas WHERE Nama_Petugas = '" + nama + "' LIMIT 1";
                    command.Connection = koneksi;
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[0] is DBNull)
                            this.idrak = 0;
                        else
                            this.idrak = reader.GetInt32(0);
                    }
                }
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            koneksi.Close();
            return this.idrak;
        }
        //metode untuk mencari data barang berdasarkan id yang direferensikan
        public List<string> getDataUpdateById()
        {
            List<string> data = new List<string>();
            try
            {
                koneksi.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT barang.ID_Barang AS `Nomor Barang`,barang.Nama_Barang AS `Nama Barang`,rak.Nama_Rak AS `Nama Rak`,kategori.Nama_Kategori AS `Nama Kategori`,petugas.Nama_Petugas AS `Petugas Bertanggung Jawab`,barang.Satuan,barang.Stock,barang.Tanggal FROM barang INNER JOIN rak ON barang.ID_Rak = rak.ID_Rak INNER JOIN kategori ON barang.ID_Kategori = kategori.ID_Kategori INNER JOIN barangkeluar ON barang.ID_Faktur_Keluar = barangkeluar.ID_Faktur_Keluar INNER JOIN petugas on barangkeluar.ID_Faktur_Keluar = petugas.Nama_Petugas WHERE barang.ID_Barang =" + idbarang;
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


        public Boolean insertBarang() {
            status = false;
            try
            {
                query = "INSERT INTO barang (`Nama_Barang`,`ID_Kategori`,`ID_Faktur_Keluar`,`ID_Rak`,`Satuan`,`Stock`,`Tanggal`) VALUES('" + namabarang + "'," + idkategori + "," + idfaktur + "," + idrak + ",'" + satuan + "'," + stock + ",'"+tanggal+"')";
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


        public Boolean updateBarang()
        {
            status = false;
            try
            {
                query = "UPDATE barang as b " +
                    "INNER JOIN barangkeluar as bk ON b.ID_Faktur_Keluar = bk.ID_Faktur_Keluar " +
                    "INNER JOIN petugas as p ON bk.ID_Petugas = p.ID_Petugas " +
                    "SET b.Nama_Barang = '"+namabarang+"' ," +
                    "b.ID_Kategori = "+idkategori+" ," +
                    "b.ID_Rak = "+idrak+"," +
                    "b.Satuan = '"+satuan+"'," +
                    "b.Stock = "+stock+"," +
                    "b.ID_Faktur_Keluar = "+idfaktur+"," +
                    "bk.ID_Petugas = "+petugas+" " +
                    "WHERE b.ID_Barang = "+idbarang;
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
    }
}
