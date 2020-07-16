using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class MessageBox : Form
    {
        public MessageBox(string message = "")
        {
            InitializeComponent();
            if (message != "")  label1.Text = message;
        }
        
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
