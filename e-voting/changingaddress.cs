using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Drawing;

namespace e_voting
{
    public partial class changingaddress : MetroFramework.Forms.MetroForm
    {
        public changingaddress()
        {
            InitializeComponent();
        }

        void generatecode()
        {
            string GuvenlikKodu;
            GuvenlikKodu = "";
            int harf, bykharf, hangisi;
            Random Rharf = new Random();
            Random Rsayi = new Random();
            Random Rbykharf = new Random();
            Random Rhangisi = new Random();

            for (int b = 0; b < 6; b++)
            {
                int a = 0;
                hangisi = Rhangisi.Next(1, 3);
                if (hangisi == 1)
                {
                    GuvenlikKodu += Rsayi.Next(0, 10).ToString();
                }
                if (hangisi == 2)
                {
                    harf = Rharf.Next(1, 27);
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        a++;
                        if (a == harf)
                        {
                            bykharf = Rbykharf.Next(1, 3);
                            if (bykharf == 1)
                            {
                                GuvenlikKodu += i;
                            }
                            if (bykharf == 2)
                            {
                                GuvenlikKodu += i.ToString().ToUpper();
                            }
                        }
                    }
                }

            }

            txt_sendingcode.Text = GuvenlikKodu;
        }
        void sendcode()
        {
            SmtpClient sc = new SmtpClient
            {
                Port = 587,
                Timeout = 3600000,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential(Settings.Default.mail_yeni.ToString(), Settings.Default.sifre_yeni.ToString())
            };
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("huptsecim@gmail.com", "Hacettepe Üniversitesi Psikoloji Topluluğu (HÜPT)")
            };
            mail.To.Add(Settings.Default.mail_yeni.ToString());
            mail.Subject = "HÜPT - Kod Gönderecek Hesapta Düzenleme için Doğrulama Kodu"; mail.IsBodyHtml = true; mail.Body = "Merhaba sevgili HÜPT YK Üyesi/Üyeleri," + " <br/> <br/> " + "Doğrulama kodu gönderecek olan hesapta düzenleme yapabilmeniz için gereken doğrulama kodu: " + txt_sendingcode.Text + " <br/> <br/> " + "Bu kodu lütfen boş olarak görmüş olduğunuz " + @" ""Kod"" " + " kutucuğuna yazarak " + @" ""Girdiğim Kodu Onaylıyorum"" " + " butonuna basarak kod gönderecek olan hesapta düzenleme işleminizi gerçekleştirebilirsiniz." + " <br/> <br/> " + "İyi Günler/Akşamlar Dilerim";
            sc.Send(mail);
        }
        void view()
        {
            if (lang.Default.language == "TR")
            {
                Localization.Culture = new System.Globalization.CultureInfo("tr-TR");
            }
            else if (lang.Default.language == "EN")
            {
                Localization.Culture = new System.Globalization.CultureInfo("en-US");
            }

            lbl_title.Text = Localization.changingaddress_lbl_title;
            lbl_titlecode.Text = Localization.changingaddress_lbl_titlecode;
            lbl_titleaddress.Text = Localization.changingaddress_lbl_titleaddress;
            btn_acceptnewaddress.Text = Localization.changingaddress_btn_acceptnewaddress;
            btn_verifycode.Text = Localization.changingaddress_btn_verifycode;
            btn_sendingcode.Text = Localization.changingaddress_btn_sendingcode;
            this.Refresh(); //that's work
        }
        void enform()
        {
            lbl_titleaddress.Location = new Point(31, 227);
            lbl_titleaddress.Size = new Size(88, 19);

            lbl_titlecode.Location = new Point(75, 162);
            lbl_titlecode.Size = new Size(44, 19);

            lbl_line1.Location = new Point(182, 14);
            lbl_line1.Text = "_________________";

            lbl_title.Location = new Point(185, 11);
            lbl_title.Size = new Size(104, 19);
        }
        void trform()
        {
            lbl_titleaddress.Location = new Point(40, 227);
            lbl_titleaddress.Size = new Size(78, 19);

            lbl_titlecode.Location = new Point(84, 162);
            lbl_titlecode.Size = new Size(35, 19);

            lbl_line1.Location = new Point(191, 14);
            lbl_line1.Text = "______________";

            lbl_title.Location = new Point(193, 11);
            lbl_title.Size = new Size(89, 19);
        }

        private void changingaddress_Load(object sender, EventArgs e)
        {
            lbl_mainaddress.Text = Settings.Default.mail_yeni.ToString();

            if (lang.Default.language == Localization.turkce)
            {
                view();
                trform();
            }
            else if (lang.Default.language == Localization.english)
            {
                view();
                enform();
            }
        }
        private void btn_acceptnewaddress_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(Localization.messsagestart, Localization.messagemailto, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Settings.Default.mail_yeni = txt_mailaddress.Text;
                Settings.Default.Save();

                btn_sendingcode.Enabled = false;
                btn_verifycode.Enabled = false;
                btn_acceptnewaddress.Enabled = false;
                lbl_titleaddress.Enabled = false;
                lbl_titlecode.Enabled = false;
                txt_enteringcode.Enabled = false;
                txt_mailaddress.Enabled = false;

                lbl_mainaddress.Text = Settings.Default.mail_yeni.ToString();

                MessageBox.Show(Localization.messagesuccesspart1 + txt_mailaddress.Text + Localization.messagesuccesspart2, Localization.messagemailto, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Localization.messagecancel, Localization.messagemailto, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_verifycode_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(Localization.messsagestart, Localization.messageconfirmcode, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                string a_bosluksuz = txt_enteringcode.Text.Trim();
                txt_enteringcode.Text = a_bosluksuz;

                if (txt_enteringcode.Text == txt_sendingcode.Text)
                {
                    MessageBox.Show(Localization.messagesuccessverify, Localization.messageconfirmcode, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btn_sendingcode.Enabled = false;
                    btn_verifycode.Enabled = false;
                    btn_acceptnewaddress.Enabled = true;
                    lbl_titleaddress.Enabled = true;
                    lbl_titlecode.Enabled = false;
                    txt_enteringcode.Enabled = false;
                    txt_mailaddress.Enabled = true;
                }
                else
                {
                    MessageBox.Show(Localization.messageerrorcode, Localization.messageconfirmcode, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Localization.messagecancel, Localization.messageconfirmcode, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_sendingcode_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(Localization.messsagestart, Localization.messagesendingcode, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                generatecode();
                sendcode();

                lbl_titlecode.Enabled = true;
                txt_enteringcode.Enabled = true;
                btn_sendingcode.Enabled = false;
                btn_verifycode.Enabled = true;

                MessageBox.Show(Localization.messagesuccesssending, Localization.messagesendingcode, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Localization.messagecancel, Localization.messagesendingcode, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
