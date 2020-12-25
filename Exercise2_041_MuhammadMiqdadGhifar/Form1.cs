using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceRest_041_MuhammadMiqdadGhifar;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace Exercise2_041_MuhammadMiqdadGhifar
{
    public partial class Form1 : Form
    {

        ClassData classData = new ClassData();
        public Form1()
        {
            InitializeComponent();
        }

        Mahasiswa mhs = new Mahasiswa();
        string baseUrl = "http://localhost:1907";

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string nim = textBoxNim.Text;
                string nama = textBoxNama.Text;
                string prodi = textBoxProdi.Text;
                string angkatan = textBoxAngkatan.Text;
                classData.insertMahasiswa(nim, nama, prodi, angkatan);
                Clear();
                dataGridMahasiswa.DataSource = classData.getAllData();
                MessageBox.Show("Data successfuly inserted");
            }
            catch (Exception ex)
            {
                
            }


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.nim = textBoxNim.Text;
                mhs.nama = textBoxNama.Text;
                mhs.prodi = textBoxProdi.Text;
                mhs.angkatan = textBoxAngkatan.Text;

                ClassData classData = new ClassData();
                classData.updateDatabase(mhs);
                MessageBox.Show("Data successfuly updated");
                Clear();
                dataGridMahasiswa.DataSource = classData.getAllData();
            }
            catch
            {
                
            }




        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                ClassData classData = new ClassData();
                classData.deleteMahasiswa(textBoxNim.Text);
                Clear();
                dataGridMahasiswa.DataSource = classData.getAllData();
                MessageBox.Show("Data successfuly deleted");
            }
            catch (Exception ex)
            {
                
            }




        }

        public void TampilData()
        {
            List<Mahasiswa> maha = new List<Mahasiswa>();
            dataGridMahasiswa.DataSource = maha;
        }

        public void Clear()
        {
            textBoxNama.Clear();
            textBoxNim.Clear();
            textBoxProdi.Clear();
            textBoxAngkatan.Clear();

            textBoxNim.Enabled = true;
            textBoxNama.Enabled = true;

            buttonSimpan.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;

            textBoxNama.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridMahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBoxNama.Text = Convert.ToString(dataGridMahasiswa.Rows[e.RowIndex].Cells[0].Value);
            textBoxNim.Text = Convert.ToString(dataGridMahasiswa.Rows[e.RowIndex].Cells[1].Value);
            textBoxProdi.Text = Convert.ToString(dataGridMahasiswa.Rows[e.RowIndex].Cells[2].Value);
            textBoxAngkatan.Text = Convert.ToString(dataGridMahasiswa.Rows[e.RowIndex].Cells[3].Value);

            

            buttonUpdate.Enabled = true;
            buttonHapus.Enabled = true;

            buttonSimpan.Enabled = false;
            textBoxNama.Enabled = false;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridMahasiswa.DataSource = classData.getAllData();
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxNim.Text != "")
            {
                string nim = textBoxNim.Text;
                List<Mahasiswa> mhs = new List<Mahasiswa>();
                mhs.Add(classData.search(nim));
                Clear();
                dataGridMahasiswa.DataSource = mhs;
            }

        }
    }
}
