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
    public partial class ViewingTourPackage : Form
    {
        public ViewingTourPackage()
        {
            InitializeComponent();
            custom2.BackColor = Color.FromArgb(60, 59, 59, 59);
            FillFlowLayout();
        }

        private void FillFlowLayout()
        {
            for(int i = 1;i <= 4;i++)
            {
                PictureBox p = new PictureBox
                {
                    Image = Image.FromFile(@"E:\Download\s" + i + ".jpg"),
                    Name = @"E:\Download\s" + i + ".jpg",
                    Size = new Size(81, 80),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p.MouseHover += Picture_Hover;
                custom2.Controls.Add(p);
            }
        }

        private void Picture_Hover(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;



            pictureBox1.Image = p.Image;
        }

        private void custom1_Click(object sender, EventArgs e)
        {
            
        }

    

        

        private void btnSolo_Click(object sender, EventArgs e)
        {
            using (Form f = new Walk_In())
            {
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void btnFamily_Click(object sender, EventArgs e)
        {
            using (FamilyPackageQuantity f = new FamilyPackageQuantity())
            {

                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (Form f2 = new Walk_In())
                    {
                        f2.ShowDialog();
                        this.Close();
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void custom2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
