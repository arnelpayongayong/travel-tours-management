using CushyTripV1.Class;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        List<SoldPackageReport> soldPackageReports = null;
        public Dashboard(string memberID)
        {
            InitializeComponent();
            this.memberID = memberID;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            FillDashboard();
            btnTravelPackages.Tag = 1;
            btnWalkIn.Tag = 2;
            btnLogout.Tag = 3;
            btnNotification.Tag = 4;

            btnTravelPackages.Click += Button_Click;
            btnWalkIn.Click += Button_Click;
            btnLogout.Click += Button_Click;
            btnNotification.Click += Button_Click;
            


            
            chart4.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards1.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards2.BackColor = Color.FromArgb(70, 69, 69, 69);
            bunifuCards3.BackColor = Color.FromArgb(70, 69, 69, 69);
            btnTravelPackages.BackColor = Color.FromArgb(70, 69, 69, 69);
            btnWalkIn.BackColor = Color.FromArgb(70, 69, 69, 69);
            soldPackageReports = GetSoldPackageReports();
            FillCharts();


        }

        private void FillDashboard()
        {
            lblRevenue.Text = GetRevenue().ToString();
            lblTourPackage.Text = GetTotalPackages().ToString();
            lblSoldPackage.Text = GetSoldPackages().ToString();

        }
        private int[] FilterSalesEveryMonth()
        {
            int[] data = new int[]{0,0,0,0,0,0,0,0,0,0,0,0 };
            foreach(var d in soldPackageReports)
            {
                switch(d.reservedDate.Substring(5,2))
                {
                    case "01":
                        data[0] += Int32.Parse(d.quantity);
                        break;
                    case "02":
                        data[1] += Int32.Parse(d.quantity);
                        break;
                    case "03":
                        data[2] += Int32.Parse(d.quantity);
                        break;
                    case "04":
                        data[3] += Int32.Parse(d.quantity);
                        break;
                    case "05":
                        data[4] += Int32.Parse(d.quantity);
                        break;
                    case "06":
                        data[5] += Int32.Parse(d.quantity);
                        break;
                    case "07":
                        data[6] += Int32.Parse(d.quantity);
                        break;
                    case "08":
                        data[7] += Int32.Parse(d.quantity);
                        break;
                    case "09":
                        data[8] += Int32.Parse(d.quantity);
                        break;
                    case "10":
                        data[9] += Int32.Parse(d.quantity);
                        break;
                    case "11":
                        data[10] += Int32.Parse(d.quantity);
                        break;
                    case "12":
                        data[11] += Int32.Parse(d.quantity);
                        break;
                }
            }
            return data;
        }
        private object GetRevenue()
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/getrevenue.php";
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }

        private object GetSoldPackages()
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/getsoldpackage.php";
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }

        private object GetTotalPackages()
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/gettotalpackage.php";
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
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
            int[] x = FilterSalesEveryMonth();
            chart4.Titles.Add("PIE");

            chart4.Series["Series1"].Points.AddXY("January", x[0].ToString());
            chart4.Series["Series1"].Points.AddXY("February", x[1].ToString());
            chart4.Series["Series1"].Points.AddXY("March", x[2].ToString());
            chart4.Series["Series1"].Points.AddXY("April", x[3].ToString());
            chart4.Series["Series1"].Points.AddXY("May", x[4].ToString());
            chart4.Series["Series1"].Points.AddXY("June", x[5].ToString());
            chart4.Series["Series1"].Points.AddXY("July", x[6].ToString());
            chart4.Series["Series1"].Points.AddXY("August", x[7].ToString());
            chart4.Series["Series1"].Points.AddXY("September", x[8].ToString());
            chart4.Series["Series1"].Points.AddXY("October", x[9].ToString());
            chart4.Series["Series1"].Points.AddXY("November", x[10].ToString());
            chart4.Series["Series1"].Points.AddXY("December", x[11].ToString());
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ExportTeamRooster();
        }

        public string GetJSONReport()
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://cushytrip.tk/getsoldpackagereport.php";
                parameter.Add("agencyID", memberID);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue.ToString();


        }
        private List<SoldPackageReport> GetSoldPackageReports()
        {
          
            string json = GetJSONReport();
            object data = JsonConvert.DeserializeObject<List<SoldPackageReport>>(json);

            soldPackageReports = data as List<SoldPackageReport>;


            return soldPackageReports;
        }
        public void ExportTeamRooster()
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            wsSheet1.Cells.Style.Font.Name = "Courier New";
            wsSheet1.Cells.Style.Font.Size = 11;

            //Title Of tournament
            wsSheet1.Cells["A" + 1].Value = "Sold Packages Report";
            wsSheet1.Cells["A1"].Style.Font.Size = 20;
            wsSheet1.Cells["A1"].Style.Font.Bold = true;

            //Date of tournament
            wsSheet1.Cells["A2"].Style.Font.Size = 14;
            wsSheet1.Cells["E2"].Style.Font.Size = 14;
            wsSheet1.Cells["I2"].Style.Font.Size = 14;
            wsSheet1.Cells["L2"].Style.Font.Size = 14;
            wsSheet1.Cells["A2"].Style.Font.Bold = true;
            wsSheet1.Cells["E2"].Style.Font.Bold = true;
            wsSheet1.Cells["I2"].Style.Font.Bold = true;
            wsSheet1.Cells["L2"].Style.Font.Bold = true;
            wsSheet1.Cells["A" + 2].Value = "Full Name";
            wsSheet1.Cells["E" + 2].Value = "Package Name";
            wsSheet1.Cells["I" + 2].Value = "Travel Date";
            wsSheet1.Cells["L" + 2].Value = "Quantity";

            //GET DATA
            List<SoldPackageReport> soldPackageReports = GetSoldPackageReports();

            int counter = 3;
            //PRINTING DATA
            foreach(var d in soldPackageReports)
            {
                wsSheet1.Cells["A" + counter].Value = d.firstname + " " + d.middlename + " " + d.lastname;
                wsSheet1.Cells["E" + counter].Value = d.packageName;
                wsSheet1.Cells["I" + counter].Value = d.reservedDate;
                wsSheet1.Cells["L" + counter].Value = d.quantity;
                counter++;
            }
            //Header of Tournament

            string fileName = @"E:\" + wsSheet1.Cells["A" + 1].Value.ToString() + ".xls";

    
            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            ExcelPkg.SaveAs(new FileInfo(fileName));

            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists)
            {

                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                new MessageBox("Successfully Export the Report").ShowDialog();
            }
        }
    }
}
