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
        private Window1 LoginPage;

        public PetugasController(register registerPage) 
        {
            this.model = new PetugasModel();
            this.registerPage = registerPage;
            model.Nama = registerPage.txtName.Text;
            model.Password = registerPage.txtPassword.Password;
            model.RegisterPetugas();
        }
        public PetugasController(Window1 LoginPage)
        {
            this.model = new PetugasModel();
        }
    }
}
