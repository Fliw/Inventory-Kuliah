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
using System.Windows;
using System.Windows.Controls;
using Inventory.controller;

namespace Inventory.view
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private LoginController controller;

        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            txtUsername.Focus();
            //2. instance ke class contrl
            controller = new LoginController(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            controller.HasilLogin();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            register registerPage = new register();
            registerPage.Show();
            this.Close();
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            register registerPage = new register();
            registerPage.Show();
            this.Close();
        }
    }
}
