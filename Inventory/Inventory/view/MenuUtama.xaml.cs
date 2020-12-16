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
using LiveCharts;
using LiveCharts.Wpf;
using Inventory.view;

namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for MenuUtama.xaml
    /// </summary>
    public partial class MenuUtama : Window
    {

        /*
        ###### CONSTRUCTOR ######
        */

        public MenuUtama()
        {
            InitializeComponent();
            SeriesCollection series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 3, 5, 7, 4 }
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal> { 5, 6, 2, 7 }
                }
            };
        }

        /*
        ###### NAVIGASI ######
        */

        //navigasi barang
        private void btnBarang_Click(object sender, RoutedEventArgs e)
        {
            DataBarang dataBarangPage = new DataBarang();
            dataBarangPage.Show();
            this.Close();
        }

        //navigasi barang
        private void btnDataBarang_Click(object sender, RoutedEventArgs e)
        {
            DataBarang dataBarangPage = new DataBarang();
            dataBarangPage.Show();
            this.Close();
        }

        //navigasi logout
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginPage = new Window1();
            loginPage.Show();
            this.Hide();
        }

        //navigasi kategori
        private void btnKategori_Click(object sender, RoutedEventArgs e)
        {
            KategoriBarang view = new KategoriBarang();
            view.Show();
            this.Close();
        }
    }
}
