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
    public partial class JoinerPackage : UserControl
    {
        public JoinerPackage(string img, string name, string details)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(img);

            label1.Text = name;
            textBox1.Text = details;
        }
    }
}
