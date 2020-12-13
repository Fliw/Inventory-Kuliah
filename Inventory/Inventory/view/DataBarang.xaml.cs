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
        public DataBarang()
        {
            InitializeComponent();
            controller = new controller.BarangController(this);
            tampilData();
        }

        public void aturButton(Boolean status)
        {
            btnTambah.IsEnabled = status;
            btnEdit.IsEnabled = status;
            btnHapus1.IsEnabled = status;
            btnSimpan.IsEnabled = !status;
            btnCancel.IsEnabled = !status;
        }

        public void tampilData()
        {
            controller.selectBarang();
            aturButton(true);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginPage = new Window1();
            loginPage.Show();
            this.Hide();
        }
        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            proses = "INSERT";
            aturButton(false);
            txtIdBarang.Text = "";
            controller.setKode();
            txtNamaBarang.Text = "";
            txtNamaBarang.Focus();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            proses = "UPDATE";
            aturButton(false);
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if(proses == "INSERT")
            {
                hasil = controller.insertBarang();
            }
            else if (proses == "UPDATE")
            {
                hasil = controller.updateBarang();
            }
            if(hasil == true)
            {
                MessageBox.Show("Berhasil!");
            }
            else
            {
                MessageBox.Show("Gagal Menyimpan");
            }
            tampilData();
        }

        private void btnHapus1_Click(object sender, RoutedEventArgs e)
        {
            hasil = controller.deleteBarang();
            if(hasil == true)
            {
                MessageBox.Show("Data Berhasil Dihapus");
            }
            else
            {
                MessageBox.Show("Hapus Data Gagal!");
            }
            tampilData();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tampilData();
        }
    }
}
