
namespace e_voting
{
    partial class programinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(programinfo));
            this.lblinfoprogramme = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblinfoprogramme
            // 
            this.lblinfoprogramme.Location = new System.Drawing.Point(23, 60);
            this.lblinfoprogramme.Name = "lblinfoprogramme";
            this.lblinfoprogramme.Size = new System.Drawing.Size(754, 632);
            this.lblinfoprogramme.TabIndex = 2;
            this.lblinfoprogramme.Text = resources.GetString("lblinfoprogramme.Text");
            this.lblinfoprogramme.WrapToLine = true;
            // 
            // programinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 712);
            this.Controls.Add(this.lblinfoprogramme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "programinfo";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Program Hakkında";
            this.Load += new System.EventHandler(this.programinfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblinfoprogramme;
    }
}