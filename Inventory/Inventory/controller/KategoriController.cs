using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Inventory.controller
{
    class KategoriController
    {
        view.KategoriBarang view;
        model.KategoriModel model;
        private Boolean hasil;
        public KategoriController(view.KategoriBarang view)
        {
            this.view = view;
            model = new model.KategoriModel();
        }
        public void selectKategori()
        {
            DataSet data = model.selectKategori();
            view.dgKategori.ItemsSource = data.Tables[0].DefaultView;
        }
    }
}
