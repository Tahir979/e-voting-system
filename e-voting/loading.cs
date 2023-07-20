using System;

namespace e_voting
{
    public partial class loading : MetroFramework.Forms.MetroForm
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
            if (lang.Default.language == Localization.turkce)
            {
                Localization.Culture = new System.Globalization.CultureInfo(Localization.tr);
                lblinfowithload.Text = Localization.lblinfowithload;
                this.Refresh(); //that's work
            }
            else if (lang.Default.language == Localization.english)
            {
                Localization.Culture = new System.Globalization.CultureInfo(Localization.en);
                lblinfowithload.Text = Localization.lblinfowithload;
                this.Refresh(); //that's work
            }
        }
    }
}
