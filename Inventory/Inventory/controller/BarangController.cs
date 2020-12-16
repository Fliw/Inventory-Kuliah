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

        /*
         ###### CONSTRUCTOR ######
         */

        public BarangController(view.DataBarang view)
        {
            this.view = view;
            model = new model.BarangModel();
            this.fillComboRak();
            this.fillComboKategori();
            this.fillComboPetugas();
        }



        /*
         ###### METHOD FOR SELECTING DATA ######
         */




        //method untuk set kode faktur ke primary key tertinggi / terbaru
        public void setKode()
        {
            view.txtFaktur.Text = model.maxPKFaktur().ToString();
        }

        //method untuk mengisi combobox rak
        public void fillComboRak()
        {
            List<string> dataRak = model.fillComboRak();
            view.cmbRak.ItemsSource = dataRak;
        }

        //method untuk mengisi combobox kategori
        public void fillComboKategori()
        {
            List<string> dataKategori = model.fillComboKategori();
            view.cmbKategori.ItemsSource = dataKategori;
        }

        //method untuk mengisi combobox petugas
        public void fillComboPetugas()
        {
            List<string> dataPetugas = model.fillComboPetugas();
            view.cmbPetugas.ItemsSource = dataPetugas;
        }

        //method untuk meminta data barang untuk ditampilkan
        public void selectBarang()
        {
            DataSet data = model.selectBarang();
            view.dgBarang.ItemsSource = data.Tables[0].DefaultView;
        }

        //method untuk mengisi value form berdasarkan id referensi
        public List<string> GetDataUpdateById()
        {
            int idBar = Int32.Parse(view.txtIdBarang.Text);
            model.idbarang = idBar;
            List<string> dataBarang = new List<string>();
            dataBarang = model.getDataUpdateById();
            return dataBarang;
        }




        /*
        ###### METHOD FOR INSERTING DATA ######
        */



        public Boolean insertBarang()
        {
            DateTime dateAndTime = new DateTime();
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



        /*
        ###### METHOD FOR UPDATING DATA ######
        */


        public Boolean updateBarang()
        {
            model.idbarang = Int16.Parse(view.txtIdBarang.Text);
            model.namabarang = view.txtNamaBarang.Text;
            model.idfaktur = Int16.Parse(view.txtFaktur.Text);
            model.petugas = model.searchPetugasID(view.cmbPetugas.SelectedItem.ToString());
            model.idkategori = model.searchKategoriID(view.cmbKategori.SelectedItem.ToString());
            model.idrak = model.searchRakID(view.cmbRak.SelectedItem.ToString());
            model.satuan = view.txtSatuan.Text;
            model.stock = Int16.Parse(view.txtStock.Text);
            hasil = model.updateBarang();
            return hasil;
        }


        /*
        ###### METHOD FOR DELETING DATA ######
        */


        public Boolean deleteBarang()
        {
            model.idbarang = Int16.Parse(view.txtIdBarang.Text);
            hasil = model.deleteBarang();
            return hasil;
        }
        
        
    }
}
