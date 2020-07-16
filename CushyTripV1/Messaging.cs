using CushyTripV1.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace CushyTripV1
{
    public partial class Messaging : Form
    {
        public Messaging()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class.Message message = new Class.Message()
            {
                message = textBox1.Text,
                guestId = 1002,
                agencyId = 1005,
                sender = 1005
            };

            string json = JsonConvert.SerializeObject(message);
            MessageUtility.SendMessage(json, "POST");

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Messaging_Load(object sender, EventArgs e)
        {
            
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("http://192.168.1.20:3000/api/chat/allChat");

                object table = JsonConvert.DeserializeObject<Chatlogs>(json);

            }
             

        }
    }
}
