using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CushyTripV1
{
    public partial class USCBuyTravelPackage : UserControl
    {
        public USCBuyTravelPackage(string img, string name, string details)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            //pictureBox1.Image = Image.FromFile(img);

            label1.Text = name;
            textBox1.Text = details;
        }

        private void USCBuyTravelPackage_Load(object sender, EventArgs e)
        {
            
            btnFamily.Tag = 1;
            btnSolo.Tag = 2;
            btnViewing.Tag = 3;

            btnFamily.Click += Button_Click;
            btnSolo.Click += Button_Click;
            btnViewing.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as Bunifu.Framework.UI.BunifuFlatButton;

            switch(btn.Tag)
            {
                case 1:
                    FamilyPackage();
                    break;

                case 3:
                    Viewing();
                    break;

            }
        }

        private void FamilyPackage()
        {
            using (FamilyPackageQuantity f = new FamilyPackageQuantity())
            {
                if(f.ShowDialog() == DialogResult.OK)
                {
                    
                    using (var payment = new Walk_In())
                    {
                        payment.ShowDialog();
                    }
                }
            }
        }

        private void Viewing()
        {
            using (ViewingTourPackage f = new ViewingTourPackage())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {

                   
                }
            }
        }
    }
}
