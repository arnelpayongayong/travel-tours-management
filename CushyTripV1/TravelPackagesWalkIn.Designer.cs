namespace CushyTripV1
{
    partial class TravelPackagesWalkIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.custom1 = new CushyTripV1.Custom();
            this.SuspendLayout();
            // 
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Sofia Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.Black;
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.Gray;
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.Silver;
            this.bunifuMaterialTextbox1.LineThickness = 5;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(21, 44);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(509, 58);
            this.bunifuMaterialTextbox1.TabIndex = 9;
            this.bunifuMaterialTextbox1.Text = "Search City/Province";
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // custom1
            // 
            this.custom1.AutoScroll = true;
            this.custom1.Location = new System.Drawing.Point(22, 112);
            this.custom1.Name = "custom1";
            this.custom1.Size = new System.Drawing.Size(1519, 858);
            this.custom1.TabIndex = 0;
            // 
            // TravelPackagesWalkIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(54)))), ((int)(((byte)(101)))));
            this.ClientSize = new System.Drawing.Size(1552, 1061);
            this.Controls.Add(this.bunifuMaterialTextbox1);
            this.Controls.Add(this.custom1);
            this.Name = "TravelPackagesWalkIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelPackagesWalkIn";
            this.Load += new System.EventHandler(this.TravelPackagesWalkIn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Custom custom1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
    }
}