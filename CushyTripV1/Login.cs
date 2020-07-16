using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {   
                try
                {
                    if (new Ping().Send("www.google.com.mx").Status == IPStatus.Success)
                    {
                        label1.Text = "Connected";

                    }
                }
                catch (Exception)
                {

                    label1.Text = "Not Connected";
                } 
        }

        public static object LoginAdmin(string email, string password)
        {
            object functionReturnValue = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                string url = "http://www.cushytrip.tk/agencylogin.php";
                parameter.Add("email", email);
                parameter.Add("password", password);
                dynamic rpb = client.UploadValues(url, "POST", parameter);
                functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
            }
            return functionReturnValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                Dashboard d = new Dashboard("111");

                this.Hide();
                d.ShowDialog();

                this.Close();

          
        }
    }
}
