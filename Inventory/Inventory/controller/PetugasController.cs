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
        
        private Window1 login;
        private model.PetugasModel petugas;

        public PetugasController(Window1 login)
        {
            this.login = login;
            petugas = new model.PetugasModel();
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
