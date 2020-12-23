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

namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for petugas.xaml
    /// </summary>
    public partial class petugas : Window
    {
        public petugas()
        {
            InitializeComponent();
        }

        private void txtID_Kategori_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (txtIdPetugas.Text == "" || txtIdPetugas.Text == "ID")
            {
                MessageBox.Show("MOHON ISI ID PETUGAS", "ERROR!");
            }
            //kurang UPDATE 
        }

        private void btnHapus1_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBeranda_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnBeranda1_Click(object sender, RoutedEventArgs e)
        {
            MenuUtama menu = new MenuUtama();
            menu.Show();
            this.Close();
        }
    }
}
