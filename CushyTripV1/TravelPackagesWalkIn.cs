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
    public partial class TravelPackagesWalkIn : Form
    {
        public TravelPackagesWalkIn()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            custom1.BackColor = Color.FromArgb(70, 59, 59, 59);
        }

        private void TravelPackagesWalkIn_Load(object sender, EventArgs e)
        {
            string[] name = { "Boracay", "Palawan", "Koui Beach", "Enchanted Kingdom", "Star City", "Pooop" };
            string detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                 " Cras aliquam dolor et purus semper tincidunt. Sed a erat eget leo" +
                 " porta dictum sit amet id nisi. Sed euismod maximus eros, vitae luctus magna." +
                 " Ut consectetur ipsum vitae odio dignissim tempus. Etiam sollicitudin posuere " +
                 "laoreet. Integer nec est mi. Etiam tempor vehicula volutpat. Maecenas egestas " +
                 "sapien sem, vel vehicula sem gravida non. Sed et dui id dolor viverra condimentum. " +
                 "Vivamus ac sapien non nisl auctor ullamcorper nec sit amet eros. Morbi consequat ac velit nec accumsan.";
            for (int i = 1; i <= 6; i++)
            {
                string img = @"E:\Download\" + i + ".jpg";
          
                USCBuyTravelPackage uc = new USCBuyTravelPackage(img,name[i-1], detail);

                custom1.Controls.Add(uc);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            custom1.Controls.Clear();

            string[] name = { "Boracay", "Palawan", "Koui Beach", "Enchanted Kingdom", "Star City", "Pooop" };
            string detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                 " Cras aliquam dolor et purus semper tincidunt. Sed a erat eget leo" +
                 " porta dictum sit amet id nisi. Sed euismod maximus eros, vitae luctus magna." +
                 " Ut consectetur ipsum vitae odio dignissim tempus. Etiam sollicitudin posuere " +
                 "laoreet. Integer nec est mi. Etiam tempor vehicula volutpat. Maecenas egestas " +
                 "sapien sem, vel vehicula sem gravida non. Sed et dui id dolor viverra condimentum. " +
                 "Vivamus ac sapien non nisl auctor ullamcorper nec sit amet eros. Morbi consequat ac velit nec accumsan.";
            for (int i = 1; i <= 6; i++)
            {
                string img = @"E:\Download\" + i + ".jpg";

                JoinerPackage uc = new JoinerPackage(img, name[i - 1], detail);

                custom1.Controls.Add(uc);
            }
        }
    }
}
