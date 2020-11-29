using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;

namespace Inventory.Model
{
    class LoginModel
    {
        private bool hasil;

        public bool GetHasil()
        {
            return hasil;
        }

        public void CheckLogin(string username, string password)
        {
            if (username == "Inventory" && password == "pabrik")
            {
                hasil = true;
            }
            else
            {
                hasil = false;
            }
        }
    }
}

