using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using System.Windows;

namespace Inventory.controller
{
    class LoginController
    {
        private Window1 login;
        private model.LoginModel petugas;

        public LoginController(Window1 login)
        {
            this.login = login;
            petugas = new model.LoginModel();
        }

        public void LoginCheck()
        {
            petugas.Nama = login.txtUsername.Text;
            petugas.Password = login.txtPassword.Password;

            bool result = petugas.LoginCheck();
            if (result)
            {
                view.MenuUtama home = new view.MenuUtama();
                home.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Login Error, Cek Kembali Username dan Password");
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
            }
        }
    }
}
