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
        public Boolean insertKategori()
        {
            model.namakategori = view.txtNamaKategori.Text;
            hasil = model.insertKategori();
            return hasil;
        }
        public List<string> GetDataUpdateById()
        {
            int idKat = Int32.Parse(view.txtIdKategori.Text);
            model.idkategori = idKat;
            List<string> dataKategori = new List<string>();
            dataKategori = model.getDataUpdateById();
            return dataKategori;
        }
        public Boolean updateKategori()
        {
            model.idkategori = Int16.Parse(view.txtIdKategori.Text);
            model.namakategori = view.txtNamaKategori.Text;
            hasil = model.updateKategori();
            return hasil;
        }
    }
}
