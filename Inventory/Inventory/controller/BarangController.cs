using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Inventory.controller
{
    class BarangController
    {
        view.DataBarang view;
        model.BarangModel model;
        private Boolean hasil;
        public BarangController(view.DataBarang view)
        {
            this.view = view;
            model = new model.BarangModel();
            this.fillComboRak();
            this.fillComboKategori();
            this.fillComboPetugas();
        }

        public void selectBarang()
        {
            DataSet data = model.selectBarang();
            view.dgBarang.ItemsSource = data.Tables[0].DefaultView;
        }
        public Boolean insertBarang()
        {
            DateTime dateAndTime = new DateTime();
            
            model.idbarang = Int16.Parse(view.txtIdBarang.Text);
            model.namabarang = view.txtNamaBarang.Text;
            model.idkategori = model.searchKategoriID(view.cmbKategori.SelectedItem.ToString());
            model.idrak = model.searchRakID(view.cmbRak.SelectedItem.ToString());
            model.idfaktur = Int16.Parse(view.txtFaktur.Text);
            model.petugas = model.searchPetugasID(view.cmbPetugas.SelectedItem.ToString());
            model.satuan = view.txtSatuan.Text;
            model.stock = Int16.Parse(view.txtStock.Text);
            model.tanggal = DateTime.Now.ToString();
            hasil = model.insertBarang();
            return hasil;
        }

        public Boolean updateBarang()
        {
            model.idbarang = Int16.Parse(view.txtIdBarang.Text);
            model.namabarang = view.txtNamaBarang.Text;
            model.idkategori = Int16.Parse(view.cmbKategori.SelectedItem.ToString());
            model.idrak = Int16.Parse(view.cmbRak.SelectedItem.ToString());
            model.satuan = view.txtSatuan.Text;
            model.stock = Int16.Parse(view.txtStock.Text);
            hasil = model.updateBarang();
            return hasil;
        }

        public Boolean deleteBarang()
        {
            model.idbarang = Int16.Parse(view.txtIdBarang.Text);
            hasil = model.deleteBarang();
            return hasil;
        }
        public void setKode()
        {
            view.txtIdBarang.Text = model.maxPK().ToString();
            view.txtFaktur.Text = model.maxPKFaktur().ToString();
        }
        public void fillComboRak()
        {
            List<string> dataRak = model.fillComboRak();
            view.cmbRak.ItemsSource = dataRak;
        }
        public void fillComboKategori()
        {
            List<string> dataKategori = model.fillComboKategori();
            view.cmbKategori.ItemsSource = dataKategori;
        }
        public void fillComboPetugas()
        {
            List<string> dataPetugas = model.fillComboPetugas();
            view.cmbPetugas.ItemsSource = dataPetugas;
        }
    }
}
