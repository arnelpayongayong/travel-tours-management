using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class Dashboard : Form
    {
        string memberID;
        public Dashboard(string memberID)
        {
            InitializeComponent();
            this.memberID = memberID;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            btnTravelPackages.Tag = 1;
            btnWalkIn.Tag = 2;
            btnLogout.Tag = 3;
            btnNotification.Tag = 4;

            btnTravelPackages.Click += Button_Click;
            btnWalkIn.Click += Button_Click;
            btnLogout.Click += Button_Click;
            btnNotification.Click += Button_Click;
            FillCharts();


            panel1.BackColor = Color.FromArgb(70, 69, 69, 69);
            
            chart4.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards1.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards2.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards3.BackColor = Color.FromArgb(70, 69, 69, 69);
            btnTravelPackages.BackColor = Color.FromArgb(70, 69, 69, 69);
            btnWalkIn.BackColor = Color.FromArgb(70, 69, 69, 69);
            
        }
   
        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as Bunifu.Framework.UI.BunifuFlatButton;

            switch(btn.Tag)
            {
                case 1:
                    OpenTravelPackages();
                    break;
                case 2:
                    OpenWalkIn();
                    break;
                case 3:
                    CloseApp();
                    break;
                case 4:
                    OpenNotification();
                    break;
            }
        }
       
        private void OpenNotification()
        {
            using (Form f = new Notification())
            {
                f.ShowDialog();
            }
        }
        
        private void CloseApp()
        {
            using (MessageBox f = new MessageBox())
            {
                
                if(f.ShowDialog() == DialogResult.OK)
                {
                    ActiveForm.Close();
                    this.Close();
                    
                }
               
            }
        }

        private void OpenWalkIn()
        {
            using (TravelPackagesWalkIn t = new TravelPackagesWalkIn())
            {
                t.ShowDialog();
            }
        }

        private void OpenTravelPackages()
        {
            using (TravelPackages t = new TravelPackages(memberID))
            {
                t.ShowDialog();
            }
        }

        private void FillCharts()
        {
       

            chart2.Series["Series1"].Points.AddXY("BORACAY", "30");
            chart2.Series["Series1"].Points.AddXY("CARAMOAN", "50");
            chart2.Series["Series1"].Points.AddXY("PALAWAN", "20");
            chart2.Series["Series1"].Points.AddXY("MAYON", "30");
            chart2.Series["Series1"].Points.AddXY("SINGAPORE", "50");
            chart2.Series["Series1"].Points.AddXY("6", "20");

            chart2.ChartAreas["Series1"].Area3DStyle.Enable3D = true;
         

            chart2.Series["Series1"].CustomProperties = "PieLabelStyle=Outside";


          

            chart1.Series["Series1"].Points.AddXY("BORACAY", "30");
            chart1.Series["Series1"].Points.AddXY("CARAMOAN", "50");
            chart1.Series["Series1"].Points.AddXY("PALAWAN", "20");
            chart1.Series["Series1"].Points.AddXY("MAYON", "30");
            chart1.Series["Series1"].Points.AddXY("SINGAPORE", "50");
            chart1.Series["Series1"].Points.AddXY("6", "20");
            
            chart1.ChartAreas["Series1"].Area3DStyle.Enable3D = true;


            chart1.Series["Series1"].CustomProperties = "PieLabelStyle=Outside";




            chart3.Series["Series1"].Points.AddXY("BORACAY", "30");
            chart3.Series["Series1"].Points.AddXY("CARAMOAN", "50");
            chart3.Series["Series1"].Points.AddXY("PALAWAN", "20");
            chart3.Series["Series1"].Points.AddXY("MAYON", "30");
            chart3.Series["Series1"].Points.AddXY("SINGAPORE", "50");
            chart3.Series["Series1"].Points.AddXY("6", "20");

            chart3.ChartAreas["Series1"].Area3DStyle.Enable3D = true;


            chart3.Series["Series1"].CustomProperties = "PieLabelStyle=Outside";


            chart4.Titles.Add("PIE");

            chart4.Series["Series1"].Points.AddXY("January", "30");
            chart4.Series["Series1"].Points.AddXY("February", "50");
            chart4.Series["Series1"].Points.AddXY("March", "20");
            chart4.Series["Series1"].Points.AddXY("April", "30");
            chart4.Series["Series1"].Points.AddXY("June", "50");
            chart4.Series["Series1"].Points.AddXY("July", "20");
            chart4.Series["Series1"].Points.AddXY("August", "30");
            chart4.Series["Series1"].Points.AddXY("September", "50");
            chart4.Series["Series1"].Points.AddXY("October", "20");
            chart4.Series["Series1"].Points.AddXY("November", "30");
            chart4.Series["Series1"].Points.AddXY("December", "50");
            chart4.Series["Series1"].Color = Color.White;
            chart4.Series["Series1"].MarkerColor = Color.White;





            chart4.Series["Series1"].CustomProperties = "PieLabelStyle=Outside";
        }
        private void RenderLine()
        {
           

        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
         
        }

     

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
