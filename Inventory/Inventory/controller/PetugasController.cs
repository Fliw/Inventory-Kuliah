using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using Inventory.model;
using System.Windows;
using System.Data;

namespace Inventory.controller
{
    class PetugasController
    {
        private Window1 login;
        private PetugasModel model;
        private register registerPage;
        private petugas Petugas;
        private Boolean hasil;


        /*
         ###### CONSTRUCTOR ######
         */

        //constructor if view was registerpage
        public PetugasController(register registerPage)
        {
            model = new PetugasModel();
            this.registerPage = registerPage;
        }
        //constructor if view was loginpage
        public PetugasController(Window1 login)
        {
            model = new PetugasModel();
            this.login = login;
        }
        public PetugasController(petugas petugas)
        {
            model = new PetugasModel();
            this.Petugas = petugas;
        }

        /*
         ###### METHOD FOR SELECTING DATA ######
         */

        //method untuk mengisi datagrid kategori
        public void selectPetugas()
        {
            DataSet data = model.selectPetugas();
            Petugas.dgPetugas.ItemsSource = data.Tables[0].DefaultView;
        }
        //method untuk mengisi value update berdasarkan id yang direferensikan
        public List<string> GetDataUpdateById()
        {
            int idPet = Int32.Parse(Petugas.txtIdPetugas.Text);
            model.PetugasId = idPet;
            List<string> dataPetugas = new List<string>();
            dataPetugas = model.getDataUpdateById();
            return dataPetugas;
        }


        //method for check if data was exist
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



        /*
         ###### METHOD FOR INSERTING DATA ######
         */


        //methodfor registering new petugas
        public void Register()
        {
            model.Nama = registerPage.txtName.Text;
            model.Password = registerPage.txtPassword.Password;
            model.insertPetugas();
        }

        public Boolean insertPetugas()
        {
            model.Nama = Petugas.txtNamaPetugas.Text;
            model.Password = Petugas.txtPassswordPetugas.Password;
            hasil = model.insertPetugas();
            return hasil;
        }

        /*
         ###### METHOD FOR UPDATING DATA ######
         */


        public Boolean updatePetugas()
        {
            model.PetugasId = Int16.Parse(Petugas.txtIdPetugas.Text);
            model.Nama = Petugas.txtNamaPetugas.Text;
            model.Password = Petugas.txtPassswordPetugas.Password;
            hasil = model.updatePetugas();
            return hasil;
        }

        /*
         ###### METHOD FOR DELETING DATA ######
         */


        public Boolean deletePetugas()
        {
            model.PetugasId = Int16.Parse(Petugas.txtIdPetugas.Text);
            hasil = model.deletePetugas();
            return hasil;
        }
    }
}
