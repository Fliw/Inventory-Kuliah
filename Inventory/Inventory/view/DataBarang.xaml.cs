using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Inventory.view;


namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class DataBarang : Window
    {
        private string proses;
        private Boolean hasil;
        private controller.BarangController controller;

        /*
        ###### CONSTRUCTOR ######
        */
        public DataBarang()
        {
            InitializeComponent();
            controller = new controller.BarangController(this);
            tampilData();
            ComboProps();

        }

        /*
       ###### OPERASI ######
       */

        //Operasi Ambil data
        public void tampilData()
        {
            controller.selectBarang();
            aturButton(true);
        }

        //Operasi tambah
        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            proses = "INSERT";
            txtIdBarang.Text = "TIDAK BISA DIEDIT";
            txtIdBarang.IsReadOnly = true;
            controller.setKode();
            txtFaktur.IsReadOnly = true;
            txtNamaBarang.Text = "";
            txtNamaBarang.Focus();
            txtSatuan.Text = "";
            txtStock.Text = "";
            cmbKategori.IsEnabled = true;
            cmbPetugas.IsEnabled = true;
            cmbRak.IsEnabled = true;
            aturButton(false);
        }

        //operasi edit
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(txtIdBarang.Text == "" || txtIdBarang.Text == "ID")
            {
                MessageBox.Show("MOHON ISI ID BARANG", "ERROR!");
            }
            else
            {
                proses = "UPDATE";
                aturButton(false);
                List<string> dataBarang = new List<string>();
                dataBarang = controller.GetDataUpdateById();
                txtIdBarang.Text = dataBarang[0];
                txtIdBarang.IsReadOnly = true;
                controller.setKode();
                txtFaktur.IsReadOnly = true;
                txtNamaBarang.Text = dataBarang[1];
                cmbRak.SelectedItem = dataBarang[2];
                cmbKategori.SelectedItem = dataBarang[3];
                cmbPetugas.SelectedItem = dataBarang[4];
                txtSatuan.Text = dataBarang[5];
                txtStock.Text = dataBarang[6];
            }
            
        }

        //operasi hapus
        private void btnHapus1_Click(object sender, RoutedEventArgs e)
        {
            txtFaktur.Text = "TIDAK BISA DIEDIT";
            txtFaktur.IsReadOnly = true;
            txtNamaBarang.Text = "TIDAK BISA DIEDIT";
            txtNamaBarang.IsReadOnly = true;
            txtSatuan.Text = "TIDAK BISA DIEDIT";
            txtSatuan.IsReadOnly = true;
            txtStock.Text = "TIDAK BISA DIEDIT";
            txtStock.IsReadOnly = true;
            cmbKategori.IsEnabled = false;
            cmbPetugas.IsEnabled = false;
            cmbRak.IsEnabled = false;
            txtIdBarang.Text = "";
            txtIdBarang.Focus();
            proses = "DELETE";
            aturButton(false);
        }
        //operasi batal
        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {

            clearAll();
            tampilData();
        }

        //operasi Simpan
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (proses == "INSERT")
            {

                if (!checkNull()) hasil = controller.insertBarang();
                clearAll();
            }
            else if (proses == "UPDATE")
            {
                if (!checkNull()) hasil = controller.updateBarang();
                clearAll();

            }
            else if (proses == "DELETE")
            {
                hasil = controller.deleteBarang();
                clearAll();

            }
            if (hasil == true)
            {
                MessageBox.Show("Berhasil!");
            }
            else
            {
                MessageBox.Show("Gagal Menyimpan");
            }
            tampilData();
        }

        /*
        ###### NAVIGASI ######
        */

        //navigasi ke logout
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginPage = new Window1();
            loginPage.Show();
            this.Hide();
        }

        //navigasi ke beranda
        private void btnBeranda_Click(object sender, RoutedEventArgs e)
        {
            view.MenuUtama menu = new view.MenuUtama();
            menu.Show();
            this.Close();
        }

        //navigasi ke kategori
        private void btnKategori_Click(object sender, RoutedEventArgs e)
        {
            KategoriBarang kategori = new KategoriBarang();
            kategori.Show();
            this.Close();
        }

        /*
        ###### Fungsi Helper ######
        */

        //check apakah ada form kosong
        private Boolean checkNull()
        {
            bool kosong;
            kosong = false;
            if (txtFaktur.Text == "" || txtIdBarang.Text == "" || txtNamaBarang.Text == "" || txtSatuan.Text == "" || txtStock.Text =="")
            {
                MessageBox.Show("ANDA HARUS MENGISI SEMUA FIELD!", "ERROR!");
                kosong = true;
            }
            return kosong;
        }

        //metode untuk mengosongkan semua field
        private void clearAll()
        {
            txtFaktur.IsReadOnly = false;
            txtFaktur.Text = "";
            txtIdBarang.IsReadOnly = false;
            txtIdBarang.Text = "";
            txtNamaBarang.IsEnabled = true;
            txtNamaBarang.Text = "";
            txtSatuan.IsEnabled = true;
            txtSatuan.Text = "";
            txtStock.IsEnabled = true;
            txtStock.Text = "";
            cmbKategori.SelectedIndex = 0;
            cmbPetugas.SelectedIndex = 0;
            cmbRak.SelectedIndex = 0;
        }

        //metode untuk membuat combobox searchable
        private void ComboProps()
        {
            cmbKategori.IsEditable = true;
            cmbPetugas.IsEditable = true;
            cmbRak.IsEditable = true;
            cmbKategori.IsTextSearchEnabled = true;
            cmbPetugas.IsTextSearchEnabled = true;
            cmbRak.IsTextSearchEnabled = true;
        }

       //metode untuk disable button dalam kondisi tertentu
        public void aturButton(Boolean status)
        {
            btnTambah.IsEnabled = status;
            btnEdit.IsEnabled = status;
            btnHapus.IsEnabled = status;
            btnSave.IsEnabled = !status;
            btnBatal.IsEnabled = !status;
        }
    }
}
