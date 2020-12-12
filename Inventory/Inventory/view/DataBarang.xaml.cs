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
        public DataBarang()
        {
            InitializeComponent();
            cmbKategori.Items.Add("Buku");
            cmbKategori.Items.Add("Baju");
            cmbKategori.Items.Add("Kain");

            cmbRak.Items.Add("201");
            cmbRak.Items.Add("404");
            cmbRak.Items.Add("305");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginPage = new Window1();
            loginPage.Show();
            this.Hide();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
