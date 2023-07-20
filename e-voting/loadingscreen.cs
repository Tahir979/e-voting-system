using System;
using System.Threading.Tasks;

namespace e_voting
{
    public partial class loadingscreen : MetroFramework.Forms.MetroForm
    {
        public Action Worker { get; set; }
        public loadingscreen(Action worker)
        {
            InitializeComponent();
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void loadingscreen_Load(object sender, EventArgs e)
        {
            if (Settings.Default.text == Localization.loading)
            {
                text.Text = Localization.loading;
            }

            else if (Settings.Default.text == Localization.checking)
            {
                text.Text = Localization.checking;
            }

            else if (Settings.Default.text == Localization.preparing)
            {
                text.Text = Localization.preparing;
            }
        }
    }
}
