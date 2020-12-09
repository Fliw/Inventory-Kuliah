using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.view;
using Inventory.model;

namespace Inventory.controller
{
    class PetugasController
    {
        private PetugasModel model;
        private register registerPage;

        public PetugasController() 
        {
            this.model = new PetugasModel();
        }
        public void RegisterPage(register registerPage) {
            this.registerPage = registerPage;
            model.Nama = registerPage.txtName.Text;
            model.Password = registerPage.txtPassword.Password;
            model.RegisterPetugas();
        }
    }
}
