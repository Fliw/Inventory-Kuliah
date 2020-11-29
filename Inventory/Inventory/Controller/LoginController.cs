using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using System.Windows;

namespace Inventory.Controller
{
    class LoginController
    {
        private LoginModel model;
        private Window1 view;

        public LoginController(Window1 view)
        {
            this.view = view;
            model = new LoginModel();
        }

        public void HasilLogin()
        {
            model.CheckLogin(view.txtUsername.Text, view.txtPassword.Text);
            bool hasil = model.GetHasil();
            if (hasil)
            {
                MenuUtama home = new MenuUtama();
                home.Show();
                view.Close();
            }
            else
            {
                MessageBox.Show("Username/password salah !");
                view.txtUsername.Text = "username";
                view.txtPassword.Text = "password";
                view.txtUsername.Focus();
            }
        }
    }
}

