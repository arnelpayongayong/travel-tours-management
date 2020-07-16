using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CushyTripV1.Class;

namespace CushyTripV1
{
    public partial class USCTourPackage : UserControl
    {
        RegularPackage regular = new RegularPackage();
        public USCTourPackage(string img,string name,string details,string id,string price,List<string> images,string accomodation,string inclusion,List<string> iterinary)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
           

            regular.details = details;
            regular.packageName = name;
            regular.images = images;
            regular.regularPackageID = id;
            regular.price = price;
            regular.accomodation = accomodation;
            regular.inclusions = inclusion;
            regular.iterinary = iterinary;
            lblID.Text = id;
            WebRequest request = null;

            try
            {
                if (images.Count == 0)
                    request = WebRequest.Create("http://cushytrip.tk/tourpackageimage/blank.jpg");
                else
                    request = WebRequest.Create("http://cushytrip.tk/tourpackageimage/" + images[0]);
            }
            catch
            {

            }
         


            

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }


            label1.Text = name;
            textBox1.Text = details;
            

        }

        private void USCTourPackage_Load(object sender, EventArgs e)
        {
            

       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (Form f = new CreateTourPackage("1",regular))
            {
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;

            if(DialogResult.OK != new MessageBox("Do you really want to delete?").ShowDialog())
            {
                return;
            }
            
            try
            {
                isDeleted = bool.Parse(DeletePackage(regular.regularPackageID).ToString());

                var message = new SucessNotif();
                message.ShowDialog();

                this.Dispose();
            }
            catch
            {
                var message = new ErrorNotif();
                message.ShowDialog();
            
            }

        }

        private object DeletePackage(string id)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/deletepackage.php";
                parameter.Add("regularpackageID", id);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }
    }
}
