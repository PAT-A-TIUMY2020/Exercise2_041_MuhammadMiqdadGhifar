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
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace Exercise2_041_MuhammadMiqdadGhifar
{
    public partial class ServerForm : Form
    {

        ServiceHost hostObject;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            hostObject = null;

            try
            {
                Task.Factory.StartNew(() =>
                {
                    hostObject = new ServiceHost(typeof(TI_UMY));
                    hostObject.Open();
                });
                label1.Text = "Server ON";
                label2.Text = "Klik OFF untuk mematikan server";
                buttonOn.Enabled = false;
                buttonOff.Enabled = true;
                
            }
            catch (Exception ex)
            {
                hostObject = null;
                label2.Text = "Server Error";
            }

        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            try
            {
                hostObject.Abort();
                label1.Text = "Server OFF";
                label2.Text = "Klik ON untuk menghidupkan server";
                buttonOff.Enabled = false;
                buttonOn.Enabled = true;

            }
            catch (Exception ex)
            {
                buttonOn.Enabled = false;
                buttonOff.Enabled = true;
                label2.Text = "Server Error";
            }
        }
    }
}
