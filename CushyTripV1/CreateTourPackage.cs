using CushyTripV1.Class;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class CreateTourPackage : Form
    {
        string memberID = "";
  
        List<string> FileName = new List<string>();
        List<string> fullName = new List<string>();
        RegularPackage regular = null;
        public CreateTourPackage(string memberID,RegularPackage regular = null)
        {
            InitializeComponent();
            this.regular = regular;
            this.memberID = memberID;
            
        }

        private void CreateTourPackage_Load(object sender, EventArgs e)
        {
            //bunifuDatepicker1.Hide();
            if (regular != null)
            {
                txtName.Text = regular.packageName;
                txtDetails.Text = regular.details;
                numPrice.Value = decimal.Parse(regular.price);
                txtInclusion.Text = regular.inclusions;
                txtAccomodation.Text = regular.accomodation;
                FillImages();
                FillIterinary();
                //rbJoiner.Visible = false;
                //rbRegular.Visible = false;
            }
        }

     
        private void FillIterinary()
        {
            int counter = 0;
            foreach(var x in regular.iterinary)
            {
                USCItenary itinerary = new USCItenary(++counter);
                itinerary.textBox1.Text = x;
                flowLayoutPanel2.Controls.Add(itinerary);
            }
        }
        public void FillImages()
        {
            WebRequest request = null;

            foreach (var image in regular.images)
            {
                request = WebRequest.Create("http://cushytrip.tk/tourpackageimage/" + image);

                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        PictureBox p = new PictureBox
                        {
                            Image = Bitmap.FromStream(stream),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(284, 284)
                        };
                        flowLayoutPanel1.Controls.Add(p);

                    }
                }
                
            }
            
        }

       
       
        public object UpdateTourPackage(RegularPackage r)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/updateregularpackage.php";
                parameter.Add("details", txtDetails.Text);
                parameter.Add("packageName", txtName.Text);
                parameter.Add("price", numPrice.Value.ToString());
                parameter.Add("regularPackageID", r.regularPackageID);
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }
        
        public void CreateTourPackages()
        {
            string tourpackageID = DateTime.Now.ToString("ddMMyyyyHHmmss") + this.memberID;
            string details = txtDetails.Text;
            string packageName = txtName.Text;
            string accomodation = txtAccomodation.Text;
            string inclusion = txtInclusion.Text;
            decimal price = numPrice.Value;
  
            SaveTourPackages(details,packageName,price,tourpackageID,accomodation,inclusion);
            CreateItenary(tourpackageID);
            UploadImages(tourpackageID);
        }
        public void CreateItenary(string tourpackageID)
        {
            int counter = 0;
            foreach(var x in flowLayoutPanel2.Controls.OfType<USCItenary>())
            {

                SaveItenary(x.textBox1.Text, tourpackageID, ++counter);
            }
        }

        public void SaveItenary(string text,string regularPackageID, int counter)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/saveitenary.php";
                parameter.Add("details", text);
                parameter.Add("regularPackageID", regularPackageID);
                parameter.Add("counter", counter.ToString());
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            
        }
        public object SaveTourPackages(string details,string packageName,decimal price,string regularPackageID,string accomodation,string inclusion)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/savetourpackage.php";
                parameter.Add("details", details );
                parameter.Add("packageName", packageName);
                parameter.Add("price", price.ToString());
                parameter.Add("accomodation", accomodation);
                parameter.Add("inclusion", inclusion);
                parameter.Add("regularPackageID", regularPackageID);
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
                }
            return functionReturnValue;
        }
        public object SaveImages(string regularPackageID,string imageName)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/saveimage.php";
                parameter.Add("imageName", imageName);
                parameter.Add("regularPackageID", regularPackageID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }
        public void UploadImages(string regularPackageID)
        {
           for(int i = 0; i < FileName.Count; i++)
            {
                string Username = "arneljoshuapayongayong";
                string Password = "136756485";
                string Server = "ftp://files.000webhost.com/public_html/tourpackageimage";


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, FileName[i])));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Username, Password);
                Stream ftpStream = request.GetRequestStream();
                FileStream fs = File.OpenRead(fullName[i]);
                byte[] buffer = new byte[1024];
                double total = (double)fs.Length;

                int byteRead = 0;
                do
                {
                    byteRead = fs.Read(buffer, 0, 1024);
                    ftpStream.Write(buffer, 0, byteRead);


                } while (byteRead != 0);
                fs.Close();
                ftpStream.Close();

                SaveImages(regularPackageID, FileName[i]);
                
            }

            
        }

        private void rbRegular_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbJoiner.Checked)
            //{
            //    bunifuDatepicker1.Show();
            //}
            //else
            //{
            //    bunifuDatepicker1.Hide();
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tourpackageID = DateTime.Now.ToString("ddMMyyyyHHmmss") + this.memberID;

            using (OpenFileDialog f = new OpenFileDialog())
            {
                f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PictureBox p = new PictureBox
                    {
                        Image = Image.FromFile(f.FileName),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(284, 284)
                    };
                    FileInfo fi = new FileInfo(f.FileName);
                    FileName.Add(tourpackageID + ".jpg");
                    fullName.Add(fi.FullName);
                    flowLayoutPanel1.Controls.Add(p);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (regular != null)
                UpdateTourPackage(regular);
            else
                CreateTourPackages();
            using (Form f = new Sucess())
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDetails_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            int counter = flowLayoutPanel2.Controls.Count;
            USCItenary itenary = new USCItenary(counter+1);
            flowLayoutPanel2.Controls.Add(itenary);
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
