using Newtonsoft.Json;
using ServiceRest_041_MuhammadMiqdadGhifar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Exercise2_041_MuhammadMiqdadGhifar
{
    class ClassData
    {
        string baseUrl = "http://localhost:1907";

        public void insertMahasiswa(string nama, string nim, string prodi, string angkatan)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nama = nama;
            mhs.nim = nim;
            mhs.prodi = prodi;
            mhs.angkatan = angkatan;

            var data = JsonConvert.SerializeObject(mhs); //Convert to Json
            var postData = new WebClient();
            postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postData.UploadString(baseUrl + "CreateMahasiswa", data);


        }

        public Mahasiswa search(string nim)
        {
            var json = new WebClient().DownloadString("http://localhost:3139/Mahasiswa/" + nim);
            var data = JsonConvert.DeserializeObject<Mahasiswa>(json);
            return data;
        }

        public List<Mahasiswa> getAllData()
        {
            var json = new WebClient().DownloadString("http://localhost:3139/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            return data;
        }

        public bool updateDatabase(Mahasiswa mhs)
        {
            bool updated = false;
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            return updated;
        }

        public bool deleteMahasiswa(string nim)
        {
            bool deleted = false;
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            return deleted;
        }
    }
}
