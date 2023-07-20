
namespace e_voting
{
    partial class loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loading));
            this.lblinfowithload = new MetroFramework.Controls.MetroLabel();
            this.pict_congrats = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pict_congrats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblinfowithload
            // 
            this.lblinfowithload.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblinfowithload.Location = new System.Drawing.Point(181, 430);
            this.lblinfowithload.Name = "lblinfowithload";
            this.lblinfowithload.Size = new System.Drawing.Size(427, 24);
            this.lblinfowithload.Style = MetroFramework.MetroColorStyle.Black;
            this.lblinfowithload.TabIndex = 5;
            this.lblinfowithload.Text = "Tüm Doğrulama Kodları Başarı Bir Şekilde Gönderildi :))";
            this.lblinfowithload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblinfowithload.UseStyleColors = true;
            // 
            // pict_congrats
            // 
            this.pict_congrats.Image = global::e_voting.Properties.Resources.purplehead;
            this.pict_congrats.Location = new System.Drawing.Point(23, 23);
            this.pict_congrats.Name = "pict_congrats";
            this.pict_congrats.Size = new System.Drawing.Size(742, 395);
            this.pict_congrats.TabIndex = 4;
            this.pict_congrats.TabStop = false;
            // 
            // loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 477);
            this.Controls.Add(this.lblinfowithload);
            this.Controls.Add(this.pict_congrats);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loading";
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Load += new System.EventHandler(this.loading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pict_congrats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblinfowithload;
        private System.Windows.Forms.PictureBox pict_congrats;
    }
}