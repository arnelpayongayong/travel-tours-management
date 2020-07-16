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
    public partial class FamilyPackageQuantity : Form
    {
        public FamilyPackageQuantity()
        {
            InitializeComponent();
        }
        public int quantity { get; set; }
        private void FamilyPackageQuantity_Load(object sender, EventArgs e)
        {
            btnOK.Tag = 1;
            btnCancel.Tag = 2;

            btnOK.Click += Button_Click;
            btnCancel.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch(btn.Tag)
            {
                case 1:
                    quantity = (int)numericUpDown1.Value;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;

            }
        }
    }
}
