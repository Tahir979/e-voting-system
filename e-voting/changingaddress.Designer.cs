
namespace e_voting
{
    partial class changingaddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changingaddress));
            this.btn_sendingcode = new MetroFramework.Controls.MetroTile();
            this.btn_acceptnewaddress = new MetroFramework.Controls.MetroTile();
            this.btn_verifycode = new MetroFramework.Controls.MetroTile();
            this.lbl_mainaddress = new MetroFramework.Controls.MetroLabel();
            this.lbl_title = new MetroFramework.Controls.MetroLabel();
            this.lbl_line3 = new MetroFramework.Controls.MetroLabel();
            this.lbl_line2 = new MetroFramework.Controls.MetroLabel();
            this.txt_enteringcode = new MetroFramework.Controls.MetroTextBox();
            this.lbl_titlecode = new MetroFramework.Controls.MetroLabel();
            this.txt_sendingcode = new MetroFramework.Controls.MetroTextBox();
            this.txt_mailaddress = new MetroFramework.Controls.MetroTextBox();
            this.lbl_titleaddress = new MetroFramework.Controls.MetroLabel();
            this.lbl_line1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btn_sendingcode
            // 
            this.btn_sendingcode.ActiveControl = null;
            this.btn_sendingcode.Location = new System.Drawing.Point(45, 59);
            this.btn_sendingcode.Name = "btn_sendingcode";
            this.btn_sendingcode.Size = new System.Drawing.Size(384, 40);
            this.btn_sendingcode.TabIndex = 34;
            this.btn_sendingcode.Text = "Adreste Düzenleme Yapabilmek için Doğrulama Kodu Gönder";
            this.btn_sendingcode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_sendingcode.UseSelectable = true;
            this.btn_sendingcode.Click += new System.EventHandler(this.btn_sendingcode_Click);
            // 
            // btn_acceptnewaddress
            // 
            this.btn_acceptnewaddress.ActiveControl = null;
            this.btn_acceptnewaddress.Enabled = false;
            this.btn_acceptnewaddress.Location = new System.Drawing.Point(290, 221);
            this.btn_acceptnewaddress.Name = "btn_acceptnewaddress";
            this.btn_acceptnewaddress.Size = new System.Drawing.Size(152, 35);
            this.btn_acceptnewaddress.TabIndex = 33;
            this.btn_acceptnewaddress.Text = "Yeni Adresi Onaylıyorum";
            this.btn_acceptnewaddress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_acceptnewaddress.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.btn_acceptnewaddress.UseSelectable = true;
            this.btn_acceptnewaddress.Click += new System.EventHandler(this.btn_acceptnewaddress_Click);
            // 
            // btn_verifycode
            // 
            this.btn_verifycode.ActiveControl = null;
            this.btn_verifycode.Enabled = false;
            this.btn_verifycode.Location = new System.Drawing.Point(290, 155);
            this.btn_verifycode.Name = "btn_verifycode";
            this.btn_verifycode.Size = new System.Drawing.Size(152, 35);
            this.btn_verifycode.TabIndex = 32;
            this.btn_verifycode.Text = "Kodu Onaylıyorum";
            this.btn_verifycode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_verifycode.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.btn_verifycode.UseSelectable = true;
            this.btn_verifycode.Click += new System.EventHandler(this.btn_verifycode_Click);
            // 
            // lbl_mainaddress
            // 
            this.lbl_mainaddress.AutoSize = true;
            this.lbl_mainaddress.Location = new System.Drawing.Point(166, 33);
            this.lbl_mainaddress.Name = "lbl_mainaddress";
            this.lbl_mainaddress.Size = new System.Drawing.Size(143, 19);
            this.lbl_mainaddress.TabIndex = 31;
            this.lbl_mainaddress.Text = "huptsecim@gmail.com";
            this.lbl_mainaddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(185, 11);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(104, 19);
            this.lbl_title.TabIndex = 29;
            this.lbl_title.Text = "Current Address";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_line3
            // 
            this.lbl_line3.AutoSize = true;
            this.lbl_line3.Location = new System.Drawing.Point(23, 188);
            this.lbl_line3.Name = "lbl_line3";
            this.lbl_line3.Size = new System.Drawing.Size(429, 19);
            this.lbl_line3.TabIndex = 28;
            this.lbl_line3.Text = "______________________________________________________________________";
            this.lbl_line3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_line2
            // 
            this.lbl_line2.AutoSize = true;
            this.lbl_line2.Location = new System.Drawing.Point(23, 123);
            this.lbl_line2.Name = "lbl_line2";
            this.lbl_line2.Size = new System.Drawing.Size(429, 19);
            this.lbl_line2.TabIndex = 27;
            this.lbl_line2.Text = "______________________________________________________________________";
            this.lbl_line2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_enteringcode
            // 
            // 
            // 
            // 
            this.txt_enteringcode.CustomButton.Image = null;
            this.txt_enteringcode.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_enteringcode.CustomButton.Location = new System.Drawing.Point(143, 2);
            this.txt_enteringcode.CustomButton.Name = "";
            this.txt_enteringcode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_enteringcode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_enteringcode.CustomButton.TabIndex = 1;
            this.txt_enteringcode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_enteringcode.CustomButton.UseSelectable = true;
            this.txt_enteringcode.CustomButton.Visible = false;
            this.txt_enteringcode.Enabled = false;
            this.txt_enteringcode.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_enteringcode.Lines = new string[0];
            this.txt_enteringcode.Location = new System.Drawing.Point(117, 159);
            this.txt_enteringcode.MaxLength = 32767;
            this.txt_enteringcode.Name = "txt_enteringcode";
            this.txt_enteringcode.PasswordChar = '\0';
            this.txt_enteringcode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_enteringcode.SelectedText = "";
            this.txt_enteringcode.SelectionLength = 0;
            this.txt_enteringcode.SelectionStart = 0;
            this.txt_enteringcode.ShortcutsEnabled = true;
            this.txt_enteringcode.Size = new System.Drawing.Size(167, 26);
            this.txt_enteringcode.TabIndex = 26;
            this.txt_enteringcode.UseSelectable = true;
            this.txt_enteringcode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_enteringcode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_titlecode
            // 
            this.lbl_titlecode.AutoSize = true;
            this.lbl_titlecode.Enabled = false;
            this.lbl_titlecode.Location = new System.Drawing.Point(84, 162);
            this.lbl_titlecode.Name = "lbl_titlecode";
            this.lbl_titlecode.Size = new System.Drawing.Size(35, 19);
            this.lbl_titlecode.TabIndex = 25;
            this.lbl_titlecode.Text = "Kod:";
            this.lbl_titlecode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_sendingcode
            // 
            // 
            // 
            // 
            this.txt_sendingcode.CustomButton.Image = null;
            this.txt_sendingcode.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_sendingcode.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txt_sendingcode.CustomButton.Name = "";
            this.txt_sendingcode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_sendingcode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_sendingcode.CustomButton.TabIndex = 1;
            this.txt_sendingcode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_sendingcode.CustomButton.UseSelectable = true;
            this.txt_sendingcode.CustomButton.Visible = false;
            this.txt_sendingcode.Lines = new string[0];
            this.txt_sendingcode.Location = new System.Drawing.Point(401, 14);
            this.txt_sendingcode.MaxLength = 32767;
            this.txt_sendingcode.Name = "txt_sendingcode";
            this.txt_sendingcode.PasswordChar = '\0';
            this.txt_sendingcode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_sendingcode.SelectedText = "";
            this.txt_sendingcode.SelectionLength = 0;
            this.txt_sendingcode.SelectionStart = 0;
            this.txt_sendingcode.ShortcutsEnabled = true;
            this.txt_sendingcode.Size = new System.Drawing.Size(75, 23);
            this.txt_sendingcode.TabIndex = 24;
            this.txt_sendingcode.UseSelectable = true;
            this.txt_sendingcode.Visible = false;
            this.txt_sendingcode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_sendingcode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_mailaddress
            // 
            // 
            // 
            // 
            this.txt_mailaddress.CustomButton.Image = null;
            this.txt_mailaddress.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_mailaddress.CustomButton.Location = new System.Drawing.Point(143, 2);
            this.txt_mailaddress.CustomButton.Name = "";
            this.txt_mailaddress.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_mailaddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_mailaddress.CustomButton.TabIndex = 1;
            this.txt_mailaddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_mailaddress.CustomButton.UseSelectable = true;
            this.txt_mailaddress.CustomButton.Visible = false;
            this.txt_mailaddress.Enabled = false;
            this.txt_mailaddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_mailaddress.Lines = new string[0];
            this.txt_mailaddress.Location = new System.Drawing.Point(117, 225);
            this.txt_mailaddress.MaxLength = 32767;
            this.txt_mailaddress.Name = "txt_mailaddress";
            this.txt_mailaddress.PasswordChar = '\0';
            this.txt_mailaddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_mailaddress.SelectedText = "";
            this.txt_mailaddress.SelectionLength = 0;
            this.txt_mailaddress.SelectionStart = 0;
            this.txt_mailaddress.ShortcutsEnabled = true;
            this.txt_mailaddress.Size = new System.Drawing.Size(167, 26);
            this.txt_mailaddress.TabIndex = 23;
            this.txt_mailaddress.UseSelectable = true;
            this.txt_mailaddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_mailaddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_titleaddress
            // 
            this.lbl_titleaddress.AutoSize = true;
            this.lbl_titleaddress.Enabled = false;
            this.lbl_titleaddress.Location = new System.Drawing.Point(31, 228);
            this.lbl_titleaddress.Name = "lbl_titleaddress";
            this.lbl_titleaddress.Size = new System.Drawing.Size(88, 19);
            this.lbl_titleaddress.TabIndex = 22;
            this.lbl_titleaddress.Text = "Mail Address:";
            this.lbl_titleaddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_line1
            // 
            this.lbl_line1.AutoSize = true;
            this.lbl_line1.Location = new System.Drawing.Point(182, 14);
            this.lbl_line1.Name = "lbl_line1";
            this.lbl_line1.Size = new System.Drawing.Size(111, 19);
            this.lbl_line1.TabIndex = 30;
            this.lbl_line1.Text = "_________________";
            // 
            // changingaddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 273);
            this.Controls.Add(this.btn_sendingcode);
            this.Controls.Add(this.btn_acceptnewaddress);
            this.Controls.Add(this.btn_verifycode);
            this.Controls.Add(this.lbl_mainaddress);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_line3);
            this.Controls.Add(this.lbl_line2);
            this.Controls.Add(this.txt_enteringcode);
            this.Controls.Add(this.lbl_titlecode);
            this.Controls.Add(this.txt_sendingcode);
            this.Controls.Add(this.txt_mailaddress);
            this.Controls.Add(this.lbl_titleaddress);
            this.Controls.Add(this.lbl_line1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "changingaddress";
            this.Load += new System.EventHandler(this.changingaddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btn_sendingcode;
        private MetroFramework.Controls.MetroTile btn_acceptnewaddress;
        private MetroFramework.Controls.MetroTile btn_verifycode;
        private MetroFramework.Controls.MetroLabel lbl_mainaddress;
        private MetroFramework.Controls.MetroLabel lbl_title;
        private MetroFramework.Controls.MetroLabel lbl_line3;
        private MetroFramework.Controls.MetroLabel lbl_line2;
        private MetroFramework.Controls.MetroTextBox txt_enteringcode;
        private MetroFramework.Controls.MetroLabel lbl_titlecode;
        private MetroFramework.Controls.MetroTextBox txt_sendingcode;
        private MetroFramework.Controls.MetroTextBox txt_mailaddress;
        private MetroFramework.Controls.MetroLabel lbl_titleaddress;
        private MetroFramework.Controls.MetroLabel lbl_line1;
    }
}