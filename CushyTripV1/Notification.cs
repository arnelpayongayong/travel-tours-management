using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 50;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            pictureBox2.Region = new Region(gp);
            pictureBox3.Region = new Region(gp);
            pictureBox4.Region = new Region(gp);
            pictureBox5.Region = new Region(gp);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
