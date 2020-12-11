using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using Inventory.model;
using System.Windows;

namespace Inventory.controller
{
    class PetugasController
    {
        private Window1 login;
        private PetugasModel model;
        private register registerPage;

        public PetugasController(register registerPage) 
        {
            this.model = new PetugasModel();
            this.registerPage = registerPage;
            model.Nama = registerPage.txtName.Text;
            model.Password = registerPage.txtPassword.Password;
            model.RegisterPetugas();
        }
        

        public PetugasController(Window1 login)
        {
            this.login = login;
            model = new model.PetugasModel();
        }

        public void LoginCheck()
        {
            model.Nama = login.txtUsername.Text;
            model.Password = login.txtPassword.Password;

            bool result = model.LoginCheck();
            if (result)
            {
                MenuUtama home = new MenuUtama();
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
