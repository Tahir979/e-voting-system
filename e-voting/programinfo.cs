using System;

namespace e_voting
{
    public partial class programinfo : MetroFramework.Forms.MetroForm
    {
        public programinfo()
        {
            InitializeComponent();
        }

        private void programinfo_Load(object sender, EventArgs e)
        {
            if (lang.Default.language == Localization.turkce)
            {
                Localization.Culture = new System.Globalization.CultureInfo(Localization.tr);
                lblinfoprogramme.Text = Localization.lblinfoprogramme;
                this.Text = Localization._programmeinfo;
                this.Refresh(); //that's work
            }
            else if (lang.Default.language == Localization.english)
            {
                Localization.Culture = new System.Globalization.CultureInfo(Localization.en);
                lblinfoprogramme.Text = Localization.lblinfoprogramme;
                this.Text = Localization._programmeinfo;
                this.Refresh(); //that's work
            }
        }
    }
}
