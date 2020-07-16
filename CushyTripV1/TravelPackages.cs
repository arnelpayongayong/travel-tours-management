using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Net;
using CushyTripV1.Class;
using Newtonsoft.Json;

namespace CushyTripV1
{
    public partial class TravelPackages : Form
    {
        string memberID;
        public TravelPackages(string memberID)
        {
            InitializeComponent();
            this.memberID = memberID;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

        }

        private void TravelPackages_Load(object sender, EventArgs e)
        {
            //this.DoubleBuffered = true;
            //flowLayoutPanel1.VerticalScroll.Enabled = false;
            //flowLayoutPanel1.BackColor = Color.FromArgb(0, 0, 0, 0);
        
            
            
            List<RegularPackage> regularPackages;

            object functionReturnValue = null;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://cushytrip.tk/regularpackage.php";
                parameter.Add("agencyID","1");
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
                string json = functionReturnValue.ToString();

                object result = JsonConvert.DeserializeObject<List<RegularPackage>>(json);
                regularPackages = result as List<RegularPackage>;
            }
            

            //using (WebClient client = new WebClient())
            //{
            //    string json = client.DownloadString("http://cushytrip.tk/regularpackage.php");

            //    object result = JsonConvert.DeserializeObject<List<RegularPackage>>(json);

            //    regularPackages = result as List<RegularPackage>;
            //}


            foreach (var r in regularPackages)
            {
                
                string image = "";

                if (!(r.images.Count == 0)) image = r.images[0];

                USCTourPackage uc = new USCTourPackage(image, r.packageName, r.details,r.regularPackageID,r.price,r.images,r.accomodation,r.inclusions,r.iterinary);

                flowLayoutPanel1.Controls.Add(uc);
            }
            
            //flowLayoutPanel1.HorizontalScroll.Maximum = 0;
        }

        static int slide = 0;
        private void slider_ValueChanged(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.AutoScrollPosition = new Point(0,slide+=20);

        }
        int currentPage = 1;
       

        

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            
            if (bunifuSwitch1.Value == true) flowLayoutPanel1.Visible = true;

            else flowLayoutPanel1.Visible = false;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            using (Form f = new CreateTourPackage(memberID))
            {
                f.ShowDialog();
            }
        }

      

     
        
    }
}
