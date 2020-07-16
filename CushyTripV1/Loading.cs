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
    public partial class Loading : Form
    {
        public Action Worker { get; set; }
        public Loading(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentNullException();
            timer1.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        string loading = "Loading....";
        string[] color = { "#34495e", "#9b59b6", "#2ecc71", "#f1c40f", "#e67e22", "#e74c3c", "#95a5a6", "#34495e", "#9b59b6", "#34495e", "#9b59b6", "#2ecc71", "#f1c40f", "#e67e22", "#e74c3c", "#95a5a6", "#34495e", "#9b59b6" };
        int sec = 0;
        int repeat = 0;
        private void loadingTick(object sender, EventArgs e)
        {
            if (repeat > 3)
            {
                this.Hide();
                this.Close();
            }
            sec++;
            
            if (sec >= loading.Length - 1)
            {
                label1.Text = "";
                sec = 0;
                repeat++;
            }

            label1.Text += loading[sec];
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(color[sec]);

        }
    }
}
