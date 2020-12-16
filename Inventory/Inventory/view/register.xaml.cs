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
using Inventory.controller;
namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        private PetugasController controller;

        /*
        ###### CONSTRUCTOR ######
        */
        public register()
        {
            InitializeComponent();
            PetugasController controller = new PetugasController(this);
            this.controller = controller;
        }
        /*
        ###### OPERASI ######
        */
        private void btnLetsgo_Click(object sender, RoutedEventArgs e)
        {
            this.controller.Register();
        }
        /*
        ###### NAVIGASI ######
        */
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window1 loginpage = new Window1();
            this.Close();
            loginpage.Show();
        }
    }
}
