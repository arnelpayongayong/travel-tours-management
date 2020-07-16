using Bunifu.Framework.UI;
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

namespace CushyTripV1
{
    public partial class Walk_In : Bunifu.Framework.UI.BunifuForm
    {
        public Walk_In()
        {
            InitializeComponent();
        }

        private void Walk_In_Load(object sender, EventArgs e)
        {
            bunifuFlatButton1.Tag = 1;

            bunifuFlatButton1.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as BunifuFlatButton;

            switch (btn.Tag)
            {
                case 1:
                    this.Close();
                    break;
            }
        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPayment_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                int sum = Int32.Parse(btnTotal.Text);
                int change = Int32.Parse(btnPayment.Text) - sum;
                btnChange.Text = change.ToString();
            }
            catch 
            {

            }
          
        }
    }
}
