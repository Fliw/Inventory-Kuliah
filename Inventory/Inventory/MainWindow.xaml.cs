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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection conn;
        public MainWindow()
        {
            conn = model.DBConnect.GetConnection();
            try
            {
                conn.Open();
            }
            catch(MySqlException se)
            {
                MessageBox.Show("Koneksi Gagal!" + se);
            }
            InitializeComponent();
            view.Window1 init = new view.Window1();
            init.Show();
            this.Close();
        }
    }
}
