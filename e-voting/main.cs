using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace e_voting
{
    public partial class main : MetroFramework.Forms.MetroForm
    {
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();
        DataTable table4 = new DataTable();
        DataTable table5 = new DataTable();
        DataTable table6 = new DataTable();
        DataTable table8 = new DataTable();
        DataTable table9 = new DataTable();
        DataTable dt = new DataTable();

        public main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        void spottheerror()
        {
            if (grid_invisible1.Rows.Count == 0)
            {
                btn_sendcode.Enabled = false;
            }
            else
            {
                btn_sendcode.Enabled = true;
            }

            string[] cikartilacak2 = new string[lst_errorlist.Items.Count];
            for (int g = 0; g < lst_errorlist.Items.Count; g++)
            {
                cikartilacak2[g] = lst_errorlist.Items[g].ToString();
            }

            lst_errorlist.Items.Clear();

            string[] cikartilacak = cikartilacak2.Distinct().ToArray(); //buradaki distinctte bir sorun yok çünkü tek başına çalışıyor sadece

            for (int l = 0; l < cikartilacak.Length; l++)
            {
                lst_errorlist.Items.Add(cikartilacak[l].ToString());
            }

            int n = lst_errorlist.Items.Count;

            if (lst_errorlist.Items.Count == 0)
            {
                lst_errorlist.Items.Add(Localization.lst_errorlist1);
            }
            else if (lst_errorlist.Items.Count == 1)
            {
                lst_errorlist.Items.Add(Localization.symbol);
                lst_errorlist.Items.Add(Localization.lst_errorlist2);
            }
            else
            {
                lst_errorlist.Items.Add(Localization.symbol);
                lst_errorlist.Items.Add(n.ToString() + Localization.lst_errorlist3);
            }

            grid_validatemail.ClearSelection();
            int satir = grid_validatemail.Rows.Count;
            int toplam = n + satir;
            lbl_peoplecount.Text = toplam.ToString();
            lbl_validatingpeoplecount.Text = satir.ToString();
            lbl_peoplecount.Visible = true;
            lbl_validatingpeoplecount.Visible = true;

            if (lbl_validatingpeoplecount.Text == Localization.number)
            {
                MessageBox.Show(Localization.mb_error, Localization.mb_hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void design2()
        {
            grid_invisible4.Columns[0].HeaderText = Localization.name;
            grid_invisible4.Columns[1].HeaderText = Localization.mail;
            grid_invisible4.Columns[0].Width = 137;
            grid_invisible4.Columns[1].Width = 180;
        }
        void check1()
        {
            OleDbCommand komut;
            OleDbCommand komut2;
            string vtyolu = Localization.oledbconveri;
            OleDbConnection baglanti = new OleDbConnection(vtyolu);

            for (int a = 0; a < grid_invisible4.Rows.Count; a++)
            {
                string isim = grid_invisible4.Rows[a].Cells[0].Value.ToString();
                string e_mail = grid_invisible4.Rows[a].Cells[1].Value.ToString();


                baglanti.Open();
                string ekle = Localization.addveri;
                komut = new OleDbCommand(ekle, baglanti);
                komut.Parameters.AddWithValue(Localization.name_, isim.ToString());
                komut.Parameters.AddWithValue(Localization.mail_, e_mail.ToString());
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                //tamam şu an veriler accesse eklendi artık, silinmesi gerekenler hala orada duruyor
            }

            for (int b = 0; b < lst_errorlist.Items.Count; b++)
            {
                string h = lst_errorlist.Items[b].ToString();

                baglanti.Open();
                string sil = Localization.deletemail;
                komut2 = new OleDbCommand(sil, baglanti);
                komut2.Parameters.AddWithValue(Localization.mail_, h);
                komut2.ExecuteNonQuery();
                komut2.Dispose();
                baglanti.Close();
                //tamam şu an veriler silindi 
            }

            string pathconn = Localization.oledbconveri;
            OleDbConnection conn = new OleDbConnection(pathconn);
            OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter(Localization.selectveri, conn);
            DataTable dt2 = new DataTable();
            MyDataAdapter.Fill(dt2);
            grid_invisible4.DataSource = dt2;
            design2();

            baglanti.Open();
            string sil2 = Localization.deleteveri;
            komut2 = new OleDbCommand(sil2, baglanti);
            komut2.ExecuteNonQuery();
            komut2.Dispose();
            baglanti.Close();
        }
        void check2()
        {
            for (int i = 0; i < grid_invisible4.Rows.Count; i++)
            {
                lst_invisible1.Items.Add(grid_invisible4.Rows[i].Cells[0].Value.ToString());
                lst_invisible2.Items.Add(grid_invisible4.Rows[i].Cells[1].Value.ToString());
            }

            int x = grid_invisible4.Rows.Count;

            //tabi ya, arama yaptığı için tek bir tane satır kalıyor metrogridde sonra programda datagridde tek satır kaldığını düşünerek ve tek satır ilettiği 
            //için zaten işleyişi durduruyor; bundan dolayı bu rows.count'ı for içine yazmak yerine önce bir değerini almak lazım ardından değişkenin sahip olduğu 
            //değer kadar döndürmesini istemeyeliyiz döngüyü aramadan kaynaklı olarak datagrid'in satırının azalmasından bağımsız olarak
            for (int i = 0; i < x; i++)
            {
                //vay amq ulan çok saçma ama bu durum; abi yetersiz kod yazıyorsunuz sonra ben uğraşıyorum. Ne demek lan datagridi yenilememek
                //özellikle altta yenile demişim aq ben ne yapayım abi ya Allah aşkına daha
                //ulan her yerde hata olabilir diye test ettim aq en aklıma gelmeyen yerden çıktı hata iyi mi
                string a = lst_invisible1.Items[i].ToString();
                string b = lst_invisible2.Items[i].ToString();
                (grid_invisible4.DataSource as DataTable).DefaultView.RowFilter = string.Format("mail LIKE '{0}%'", b);

                if (grid_invisible4.Rows.Count == 1) //
                {
                    table5.Rows.Add(a, b);
                }

                table6.Rows.Clear();
                for (int g = 0; g < x; g++)
                {
                    DataRow dr = table6.NewRow();
                    dr[Localization.name] = lst_invisible1.Items[g].ToString();
                    dr[Localization.mail] = lst_invisible2.Items[g].ToString();
                    table6.Rows.Add(dr);
                }
                grid_invisible4.DataSource = table6;
            }
            grid_invisible11.DataSource = table5;
            grid_invisible11.Columns[0].Width = 137;
            grid_invisible11.Columns[1].Width = 180;

            grid_invisible1.ColumnCount = 2;

            grid_invisible1.Columns[0].Name = Localization.name;
            grid_invisible1.Columns[0].HeaderText = Localization.name;
            grid_invisible1.Columns[0].Width = 137;

            grid_invisible1.Columns[1].Name = Localization.mail;
            grid_invisible1.Columns[1].HeaderText = Localization.mail;
            grid_invisible1.Columns[1].Width = 180;

            for (int i = 0; i < grid_invisible11.Rows.Count; i++)
            {
                int idx = grid_invisible1.Rows.Add();
                grid_invisible1.Rows[idx].Cells[0].Value = grid_invisible11.Rows[i].Cells[0].Value.ToString();
                grid_invisible1.Rows[idx].Cells[1].Value = grid_invisible11.Rows[i].Cells[1].Value.ToString(); //value yazmadan neden cell'i bi tuhaf alıyor ki acaba ilginç gerçekten, nasıl bir amacı varsa artık c#'ı yazan kişiler için
            }
        }
        void check3()
        {
            try
            {
                for (int i = 0; i < grid_invisible1.Rows.Count; i++)
                {
                    string a = grid_invisible1.Rows[i].Cells[0].Value.ToString();
                    string b = grid_invisible1.Rows[i].Cells[1].Value.ToString();
                    (grid_invisible5.DataSource as DataTable).DefaultView.RowFilter = string.Format("mail LIKE '{0}%'", b);

                    if (grid_invisible5.Rows.Count == 0)
                    {
                        table4.Rows.Add(a, b);
                    }
                }

                grid_validatemail.DataSource = table4;
                grid_validatemail.Columns[0].Width = 137;
                grid_validatemail.Columns[1].Width = 180;
            }
            catch (Exception)
            {
                return;
            }
        }
        void addingtoaccess()
        {
            OleDbCommand komut;
            string vtyolu = Localization.oledbconcode;
            OleDbConnection baglanti = new OleDbConnection(vtyolu);

            for (int a = 0; a < lst_codes.Items.Count; a++)
            {
                string isim = lst_names.Items[a].ToString();
                string mail = lst_mails.Items[a].ToString();
                string kod = lst_codes.Items[a].ToString();

                baglanti.Open();
                string ekle = Localization.addcode;
                komut = new OleDbCommand(ekle, baglanti);
                komut.Parameters.AddWithValue(Localization.name_, isim.ToString());
                komut.Parameters.AddWithValue(Localization.mail_, mail.ToString());
                komut.Parameters.AddWithValue(Localization.code_, kod.ToString());
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
            }
        }
        void fillgrids()
        {
            OleDbConnection con;
            OleDbDataAdapter da;
            DataSet ds;
            con = new OleDbConnection(Localization.oledbconcode);
            da = new OleDbDataAdapter(Localization.codeselect, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, Localization.code);
            grid_invisible5.DataSource = ds.Tables[Localization.code];
            con.Close();
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

            txt_code.Text = GuvenlikKodu;
            lst_codes.Items.Add(txt_code.Text.ToString());
        }
        void sendingcode()
        {
            SmtpClient sc = new SmtpClient
            {
                Port = 587,
                Timeout = 3600000,
                Host = Localization.smtp,
                EnableSsl = true,
                Credentials = new NetworkCredential(Settings.Default.mail_yeni, Settings.Default.sifre_yeni)
            };
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(Settings.Default.mail_yeni, Localization.hupt_title)
            };
            mail.To.Add(txt_email.Text.ToString());
            mail.Subject = Localization.hupt_title2; mail.IsBodyHtml = true; mail.Body = Localization.hupt_title3 + txt_name.Text.ToString() + "," + " <br/> <br/> " + Localization.hupt_title4 + txt_code.Text + " <br/> <br/> " + Localization.hupt_title5;
            sc.Send(mail);
            lst_names.Items.Add(txt_name.Text.ToString());
            lst_mails.Items.Add(txt_email.Text.ToString());
        }
        void view()
        {
            lbl_programinfo.Text = Localization.lbl_programinfo;
            lbl_editingaddress.Text = Localization.lbl_editingaddress;
            lbl_showerrorlist.Text = Localization.showerrorlist;
            lbl_tier1.Text = Localization.lbl_tier1;
            lbl_tier2.Text = Localization.lbl_tier2;
            lbl_tier3.Text = Localization.lbl_tier3;
            lbl_shownotvalidcode.Text = Localization.hidenotvalidcode;
            btn_getmaillist.Text = Localization.btn_getmaillist;
            btn_sendcode.Text = Localization.btn_sendcode;
            btn_showinfo.Text = Localization.btn_showinfo;
            btn_getcode.Text = Localization.btn_getcode;
            btn_letsvote.Text = Localization.btn_letsvote;
            lbl_sendcodeinfo.Text = Localization.lbl_sendcodeinfo;
            lbl_totalpeople.Text = Localization.lbl_totalpeople;
            lbl_totalvalidatepeople.Text = Localization.lbl_totalvalidatepeople;
            lbl_info.Text = Localization.lbl_info;
            lbl_totalpeoplereceivecode.Text = Localization.lbl_totalpeoplereceivecode;
            lbl_totalpeoplereceivecodewithvalid.Text = Localization.lbl_totalpeoplereceivecodewithvalid;
            lbl_votecount.Text = Localization.lbl_votecount;
            btn_newvotecount.Text = Localization.btn_newvotecount;
            lbl_votefinaltable.Text = Localization.lbl_votefinaltable;
            this.Refresh(); //that's work
        }
        void enform()
        {
            lbl_totalpeople.Size = new Size(241, 19);
            lbl_totalpeople.Location = new Point(235, 432);

            lbl_totalvalidatepeople.Size = new Size(183, 19);
            lbl_totalvalidatepeople.Location = new Point(289, 451);

            lbl_votefinaltable.Size = new Size(102, 19);
            lbl_votefinaltable.Location = new Point(1440, 38);

            lbl_line4.Size = new Size(87, 19);
            lbl_line4.Location = new Point(1437, 42);
            lbl_line4.Text = "_____________";

            lbl_editingaddress.Size = new Size(325, 23);
            lbl_editingaddress.Location = new Point(301, 5);

            lbl_peoplecount.Size = new Size(16, 19);
            lbl_peoplecount.Location = new Point(466, 433);

            lbl_validatingpeoplecount.Size = new Size(16, 19);
            lbl_validatingpeoplecount.Location = new Point(466, 452);

            lbl_tier3.Size = new Size(151, 19);
            lbl_tier3.Location = new Point(1002, 41);

            lbl_totalpeoplereceivecode.Size = new Size(244, 19);
            lbl_totalpeoplereceivecode.Location = new Point(235, 972);

            lbl_totalpeoplereceivecodewithvalid.Size = new Size(183, 19);
            lbl_totalpeoplereceivecodewithvalid.Location = new Point(296, 991);

            lbl_countcode.Size = new Size(16, 19);
            lbl_countcode.Location = new Point(473, 973);

            lbl_countvalidcode.Size = new Size(16, 19);
            lbl_countvalidcode.Location = new Point(473, 992);
        }
        void trform()
        {
            lbl_totalpeople.Size = new Size(241, 19);
            lbl_totalpeople.Location = new Point(235, 432);

            lbl_totalvalidatepeople.Size = new Size(156, 19);
            lbl_totalvalidatepeople.Location = new Point(319, 451);

            lbl_votefinaltable.Size = new Size(102, 19);
            lbl_votefinaltable.Location = new Point(1429, 38);

            lbl_line4.Size = new Size(111, 19);
            lbl_line4.Location = new Point(1425, 42);
            lbl_line4.Text = "_________________";

            lbl_editingaddress.Size = new Size(325, 23);
            lbl_editingaddress.Location = new Point(300, 5);

            lbl_peoplecount.Size = new Size(16, 19);
            lbl_peoplecount.Location = new Point(469, 433);

            lbl_validatingpeoplecount.Size = new Size(16, 19);
            lbl_validatingpeoplecount.Location = new Point(469, 452);

            lbl_tier3.Size = new Size(161, 19);
            lbl_tier3.Location = new Point(997, 41);

            lbl_totalpeoplereceivecode.Size = new Size(179, 19);
            lbl_totalpeoplereceivecode.Location = new Point(235, 972);

            lbl_totalpeoplereceivecodewithvalid.Size = new Size(156, 19);
            lbl_totalpeoplereceivecodewithvalid.Location = new Point(258, 991);

            lbl_countcode.Size = new Size(16, 19);
            lbl_countcode.Location = new Point(408, 973);

            lbl_countvalidcode.Size = new Size(16, 19);
            lbl_countvalidcode.Location = new Point(408, 992);
        }
        void countvote()
        {
            grid_votetable.ClearSelection();

            grid_votetable.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_votetable.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (table.Columns.Count == 0)
            {
                table.Columns.Add(Localization.name, typeof(string));
                table.Columns.Add(Localization.vote, typeof(string));
            }

            for (int i = 0; i < lst_notspacing.Items.Count; i++)
            {
                table.Rows.Add("", lst_notspacing.Items[i].ToString());
            }

            grid_invisible8.DataSource = table;

            if (table2.Columns.Count == 0)
            {
                table2.Columns.Add(Localization.candidates, typeof(string));
                table2.Columns.Add(Localization.votecounts, typeof(int));
            }
            grid_votefinaltable.DataSource = table2;
            grid_votefinaltable.Columns[0].Width = 156;
            grid_votefinaltable.Columns[1].Width = 83;

            grid_votefinaltable.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_votefinaltable.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grid_votefinaltable.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid_votefinaltable.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            btn_getmaillist.Enabled = false;
            btn_sendcode.Enabled = false;
            btn_getcode.Enabled = false;
            btn_letsvote.Enabled = false;

            lbl_votecountnumber.Text = grid_votetable.Rows.Count.ToString();
            lbl_votecount.Visible = true;
            lbl_votecountnumber.Visible = true;

            grid_votetable.Visible = true;
            grid_votetable.ClearSelection();

            grid_votefinaltable.Visible = true;
            grid_votefinaltable.ClearSelection();
        }

        void loading()
        {
            Excel.Application oXL = new Excel.Application(); //hmm demek nuget paketten bulmak gerekiyormuş seni ve sonrada öyle using Excel diyerek kullanmak gerekiyormuş

            lst_invisible1.Items.Clear();
            lst_invisible2.Items.Clear();
            grid_invisible1.Rows.Clear();
            table4.Rows.Clear();
            table5.Rows.Clear();
            table6.Rows.Clear();

            Excel.Workbook oWB = oXL.Workbooks.Open(txt_invisible1.Text); // hata burada oluşuyor demek

            List<string> liste = new List<string>();
            foreach (Excel.Worksheet oSheet in oWB.Worksheets)
            {
                liste.Add(oSheet.Name);
            }
            oWB.Close();
            oXL.Quit();
            oWB = null;
            oXL = null;
            grid_invisible2.DataSource = liste.Select(x => new { SayfaAdi = x }).ToList();
            txt_invisible2.Text = grid_invisible2.Rows[0].Cells[0].Value.ToString();

            OleDbCommand komut = new OleDbCommand();
            string pathconn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + txt_invisible1.Text + ";Extended Properties=\"Excel 8.0;HDR= yes;\";";
            OleDbConnection conn = new OleDbConnection(pathconn);
            OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter("Select * from [" + txt_invisible2.Text + "$]", conn);
            DataTable dt3 = new DataTable();
            MyDataAdapter.Fill(dt3);
            grid_invisible4.DataSource = dt3;
            design2();

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@hacettepe.edu.tr$");

            lst_errorlist.Items.Clear();

            string[] email = new string[grid_invisible4.Rows.Count];
            for (int i = 0; i < grid_invisible4.Rows.Count; i++)
            {
                email[i] = grid_invisible4.Rows[i].Cells[1].Value.ToString();
                string y = email[i].Trim(); //iyi oldu bu ya güzel işe yarıyor
                email[i] = y.ToString();

                grid_invisible4.Rows[i].Cells[1].Value = email[i];

                bool İsValidEmail = regex.IsMatch(email[i]);

                if (!İsValidEmail)
                {
                    lst_errorlist.Items.Add(email[i].ToString());
                }
            }

            grid_invisible1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grid_validatemail.BorderStyle = System.Windows.Forms.BorderStyle.None;

            if (lbl_showerrorlist.Text == Localization.hideerrorlist)
            {
                lst_errorlist.Visible = true;
            }
            else if (lbl_showerrorlist.Text == Localization.showerrorlist)
            {
                lst_errorlist.Visible = false;
            }

            check1(); //hatalı mail çıkarımı
            check2(); //ismi iki kere yazanların çıkarımı
            check3(); //önceden kod almış olanların çıkarımı
            spottheerror();

            txt_invisible1.Clear();
            txt_invisible2.Clear();
            lst_names.Items.Clear();
            lst_mails.Items.Clear();
            lst_codes.Items.Clear();
            btn_getcode.Enabled = false;
            fillgrids();
            grid_validatemail.ClearSelection();
        }
        void checking()
        {
            Excel.Application oXL = new Excel.Application(); //hmm demek nuget paketten bulmak gerekiyormuş seni ve sonrada öyle using Excel diyerek kullanmak gerekiyormuş

            dt.Rows.Clear();
            dt.Columns.Clear();
            table3.Rows.Clear();
            table8.Rows.Clear();
            table9.Rows.Clear();

            Excel.Workbook oWB = oXL.Workbooks.Open(txt_invisible1.Text); // hata burada oluşuyor demek

            List<string> liste = new List<string>();
            foreach (Excel.Worksheet oSheet in oWB.Worksheets)
            {
                liste.Add(oSheet.Name);
            }
            oWB.Close();
            oXL.Quit();
            oWB = null;
            oXL = null;
            grid_invisible2.DataSource = liste.Select(x => new { SayfaAdi = x }).ToList();
            txt_invisible2.Text = grid_invisible2.Rows[0].Cells[0].Value.ToString();

            OleDbCommand komut = new OleDbCommand();
            string pathconn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + txt_invisible1.Text + ";Extended Properties=\"Excel 8.0;HDR= yes;\";";
            OleDbConnection conn = new OleDbConnection(pathconn);
            OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter("Select * from [" + txt_invisible2.Text + "$]", conn);
            MyDataAdapter.Fill(dt);
            grid_invisible3.DataSource = dt;

            if (lbl_shownotvalidcode.Text == Localization.hidenotvalidcode)
            {
                lst_notvalidcode.Visible = false;
            }
            else if (lbl_shownotvalidcode.Text == Localization.shownotvalidcode)
            {
                lst_notvalidcode.Visible = true;
            }

            grid_info.BorderStyle = System.Windows.Forms.BorderStyle.None;

            lst_notvalidcode.Items.Clear();


            OleDbCommand komut2;
            string vtyolu2 = Localization.oledbcontile3;
            OleDbConnection baglanti2 = new OleDbConnection(vtyolu2);
            baglanti2.Open();
            string sil = Localization.deletetile3;
            komut2 = new OleDbCommand(sil, baglanti2);
            komut2.ExecuteNonQuery();
            komut2.Dispose();
            baglanti2.Close();

            string[] kod_gonderilen = new string[lst_codes.Items.Count];
            string[] isim_gonderilen = new string[lst_codes.Items.Count];
            string[] kod_alinan = new string[grid_invisible3.Rows.Count];
            string[] isim_alinan = new string[grid_invisible3.Rows.Count];
            string[] oy1 = new string[grid_invisible3.Rows.Count];
            for (int i = 0; i < lst_codes.Items.Count; i++)
            {
                kod_gonderilen[i] = lst_codes.Items[i].ToString();
                isim_gonderilen[i] = lst_names.Items[i].ToString();
            }
            for (int h = 0; h < grid_invisible3.Rows.Count; h++)
            {
                kod_alinan[h] = grid_invisible3.Rows[h].Cells[1].Value.ToString();
                string bosluksuz = kod_alinan[h].Trim();
                kod_alinan[h] = bosluksuz.ToString();

                isim_alinan[h] = grid_invisible3.Rows[h].Cells[0].Value.ToString();
                oy1[h] = grid_invisible3.Rows[h].Cells[2].Value.ToString();
            }
            //kod alınan > kod gonderilen aslında ya da maks eşit olurlar birbirlerine

            for (int k = 0; k < lst_codes.Items.Count; k++)
            {
                for (int l = 0; l < grid_invisible3.Rows.Count; l++)
                {
                    if (kod_alinan[l].Contains(kod_gonderilen[k].ToString()) == true)
                    {
                        lst_validcode.Items.Add(kod_gonderilen[k].ToString());
                        lst_validname.Items.Add(isim_gonderilen[k].ToString());
                        lst_validvote.Items.Add(oy1[l].ToString()); //sorun buymuş demek, k yı l diye düzeltince sorun çözüldü
                    }
                }
            }

            OleDbCommand komut3;
            string vtyolu = Localization.oledbcontile3;
            OleDbConnection baglanti = new OleDbConnection(vtyolu);

            for (int a = 0; a < lst_validcode.Items.Count; a++)
            {
                string isim = lst_validname.Items[a].ToString();
                string kod = lst_validcode.Items[a].ToString();
                string oy = lst_validvote.Items[a].ToString();


                baglanti.Open();
                string ekle = Localization.addtile3;
                komut3 = new OleDbCommand(ekle, baglanti);
                komut3.Parameters.AddWithValue(Localization.name_, isim.ToString());
                komut3.Parameters.AddWithValue(Localization.code_, kod.ToString());
                komut3.Parameters.AddWithValue(Localization.vote_, oy.ToString());
                komut3.ExecuteNonQuery();
                komut3.Dispose();
                baglanti.Close();
            }

            OleDbConnection con;
            OleDbDataAdapter da;
            DataSet ds5;
            con = new OleDbConnection(Localization.oledbcontile3);
            da = new OleDbDataAdapter(Localization.selecttile3, con);
            ds5 = new DataSet();
            con.Open();
            da.Fill(ds5, Localization.tile3);
            searching.DataSource = ds5.Tables[Localization.tile3];
            con.Close();

            string[] duzgunkod_hepsi = new string[lst_validcode.Items.Count];
            for (int j = 0; j < lst_validcode.Items.Count; j++)
            {
                duzgunkod_hepsi[j] = lst_validcode.Items[j].ToString();
            }

            string[] tekrarsiz = duzgunkod_hepsi.Distinct().ToArray(); //buradaki distinctte bir sorun yok çünkü tek başına çalışıyor sadece


            if (table3.Columns.Count == 0)
            {
                table3.Columns.Add(Localization.name, typeof(string));
                table3.Columns.Add(Localization.code, typeof(string));
                table3.Columns.Add(Localization.vote, typeof(string));
            }

            for (int b = 0; b < tekrarsiz.Length; b++)
            {
                DataView dv = ds5.Tables[Localization.tile3].DefaultView;
                dv.RowFilter = "kod LIKE '" + tekrarsiz[b].ToString() + "%'";
                searching.DataSource = dv;

                table3.Rows.Add(searching.Rows[0].Cells[0].Value.ToString(), searching.Rows[0].Cells[1].Value.ToString(), searching.Rows[0].Cells[2].Value.ToString());
            }
            grid_info.DataSource = table3;
            grid_info.Columns[0].Width = 183;
            grid_info.Columns[1].Width = 148;
            grid_info.Columns[2].Width = 104;

            string[] cikar2 = new string[grid_invisible3.Rows.Count];
            for (int t = 0; t < grid_invisible3.Rows.Count; t++)
            {
                cikar2[t] = grid_invisible3.Rows[t].Cells[1].Value.ToString();
            }
            string[] cikar = cikar2.Distinct().ToArray(); //buradaki distinctte bir sorun yok çünkü tek başına çalışıyor sadece

            for (int i = 0; i < grid_info.Rows.Count; i++)
            {
                lst_invisible6.Items.Add(grid_info.Rows[i].Cells[1].Value.ToString());
            }

            for (int a = 0; a < cikar.Length; a++)
            {
                if (lst_invisible6.Items.Contains(cikar[a]) == false)
                {
                    lst_notvalidcode.Items.Add(cikar[a]);
                }
            }

            string[] bozuklar = new string[lst_notvalidcode.Items.Count];

            for (int i = 0; i < lst_notvalidcode.Items.Count; i++)
            {
                bozuklar[i] = lst_notvalidcode.Items[i].ToString();
            }

            lst_notvalidcode.Items.Clear();

            for (int y = 0; y < bozuklar.Length; y++)
            {
                if (bozuklar[y] == "") //hmm, boşluk değillermiş demek direkt olarak boş değerlermiş
                {

                }
                else
                {
                    lst_notvalidcode.Items.Add(bozuklar[y].ToString());
                }
            }

            int n = lst_notvalidcode.Items.Count;

            if (lst_notvalidcode.Items.Count == 0)
            {
                lst_notvalidcode.Items.Add(Localization.lst_notvalidcode1);
            }
            else if (lst_notvalidcode.Items.Count == 1)
            {
                lst_notvalidcode.Items.Add(Localization.symbol);
                lst_notvalidcode.Items.Add(Localization.lst_notvalidcode2);
            }
            else
            {
                lst_notvalidcode.Items.Add(Localization.symbol);
                lst_notvalidcode.Items.Add(n.ToString() + Localization.lst_notvalidcode3);
            }

            int satir = grid_info.Rows.Count;
            lbl_countvalidcode.Text = satir.ToString();
            int toplam = n + satir;
            lbl_countcode.Text = toplam.ToString();

            lbl_countcode.Visible = false;
            lbl_countvalidcode.Visible = false;

            if (lbl_countvalidcode.Text == Localization.number)
            {
                MessageBox.Show(Localization.mb_error, Localization.mb_hata, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_letsvote.Enabled = false;
            }
            else
            {
                btn_letsvote.Enabled = true;

                txt_invisible1.Clear();
                txt_invisible2.Clear();
                lst_validname.Items.Clear();
                lst_validcode.Items.Clear();
                lst_validvote.Items.Clear();
                lst_invisible6.Items.Clear();
                btn_getmaillist.Enabled = false;
                btn_sendcode.Enabled = false;

                if (table8.Columns.Count == 0)
                {
                    table8.Columns.Add(Localization.wordname, typeof(string));
                }

                for (int i = 0; i < grid_invisible2.Rows.Count; i++)
                {
                    table8.Rows.Add(grid_invisible2.Rows[i].Cells[0].Value.ToString());
                }

                grid_invisible2.DataSource = table8;

                if (table9.Columns.Count == 0)
                {
                    table9.Columns.Add(Localization.name, typeof(string));
                    table9.Columns.Add(Localization.mail, typeof(string));
                    table9.Columns.Add(Localization.code, typeof(string));
                }

                for (int i = 0; i < searching.Rows.Count; i++)
                {
                    table9.Rows.Add(searching.Rows[i].Cells[0].Value.ToString(), searching.Rows[i].Cells[1].Value.ToString(), searching.Rows[i].Cells[2].Value.ToString());
                }

                searching.DataSource = table9;
                grid_info.ClearSelection();
            }
        }
        void preparing()
        {

        }

        private void btn_getmaillist_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog
                {
                    Filter = Localization.excelfilter,
                    Title = Localization.exceltitle
                };
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txt_invisible1.Text = openfile1.FileName;
                }

                if (txt_invisible1.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    Settings.Default.text = Localization.loading;
                    Settings.Default.Save();

                    using (loadingscreen frm = new loadingscreen(loading))
                    {
                        frm.ShowDialog(this);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void lbl_showerrorlist_Click(object sender, EventArgs e)
        {
            if (lst3box.Items.Count == 0)
            {
                int butonabasissayisi = 0;
                butonabasissayisi++;
                lst3box.Items.Add(butonabasissayisi.ToString());

                if (butonabasissayisi % 2 == 0)
                {
                    lbl_showerrorlist.Text = Localization.showerrorlist;
                    lst_errorlist.Visible = false;
                }
                else
                {
                    lbl_showerrorlist.Text = Localization.hideerrorlist;
                    lst_errorlist.Visible = true;
                    if (lst_errorlist.Items.Count == 0)
                    {
                        lst_errorlist.Items.Add(Localization.couldntfindmailaddress);
                    }
                }
            }
            else
            {
                int yeni = Convert.ToInt32(lst3box.Items.Count.ToString());
                yeni++;
                lst3box.Items.Add(yeni.ToString());

                if (yeni % 2 == 0)
                {
                    lbl_showerrorlist.Text = Localization.showerrorlist;
                    lst_errorlist.Visible = false;
                }
                else
                {
                    lbl_showerrorlist.Text = Localization.hideerrorlist;
                    lst_errorlist.Visible = true;
                    if (lst_errorlist.Items.Count == 0)
                    {
                        lst_errorlist.Items.Add(Localization.couldntfindmailaddress);
                    }
                }
            }
        }
        private void btn_sendcode_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(Localization.sendingcodemessage, Localization.controlofcode, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                lbl_percent.Visible = true;
                progresbar.Visible = true;
                lbl_sendcodeinfo.Visible = true;

                lst_names.Items.Clear();
                lst_mails.Items.Clear();
                lst_codes.Items.Clear();

                if (grid_validatemail.Rows.Count == 1)
                {
                    progresbar.Value = 10;
                    lbl_percent.Text = Localization.tenpercentage;
                }
                this.Refresh();

                for (int i = 0; i <= grid_validatemail.Rows.Count; i++)
                {
                    if (i == grid_validatemail.Rows.Count)
                    {
                        decimal yuzde = ((decimal)(i) / (decimal)grid_validatemail.Rows.Count) * 100;
                        Application.DoEvents();
                        progresbar.Value = (int)yuzde;
                        yuzde = Math.Round(yuzde, 2);
                        lbl_percent.Text = "%" + yuzde.ToString();
                    }
                    else
                    {
                        txt_name.Text = grid_validatemail.Rows[i].Cells[0].Value.ToString();
                        txt_email.Text = grid_validatemail.Rows[i].Cells[1].Value.ToString();

                        generatecode();
                        sendingcode();

                        decimal yuzde = ((decimal)(i + 1) / (decimal)grid_validatemail.Rows.Count) * 100;
                        Application.DoEvents();
                        progresbar.Value = (int)yuzde;
                        yuzde = Math.Round(yuzde, 2);
                        lbl_percent.Text = "%" + yuzde.ToString();
                    }
                }

                lbl_sendcodeinfo.Visible = false;

                loading x = new loading();
                x.Show();

                addingtoaccess();
                fillgrids();
                btn_getcode.Enabled = true;
            }

            else
            {
                MessageBox.Show(Localization.errormail, Localization.errorprocess, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pict_changelang_Click(object sender, EventArgs e)
        {
            if (lang.Default.language == Localization.turkce)
            {
                pict_changelang.Image = Properties.Resources.en;
                Localization.Culture = new System.Globalization.CultureInfo(Localization.en);
                lang.Default.language = Localization.english;
                lang.Default.Save();
                enform();
                view();
            }
            else if (lang.Default.language == Localization.english)
            {
                pict_changelang.Image = Properties.Resources.tr;
                Localization.Culture = new System.Globalization.CultureInfo(Localization.tr);
                lang.Default.language = Localization.turkce;
                lang.Default.Save();
                trform();
                view();
            }
        }
        private void btn_getcode_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile1 = new OpenFileDialog
            {
                Filter = Localization.excelfilter,
                Title = Localization.exceltitle
            };
            if (openfile1.ShowDialog() == DialogResult.OK)
            {
                this.txt_invisible1.Text = openfile1.FileName;
            }

            if (txt_invisible1.Text == string.Empty)
            {
                return;
            }
            else
            {
                Settings.Default.text = Localization.checking;
                Settings.Default.Save();

                using (loadingscreen frm = new loadingscreen(checking))
                {
                    frm.ShowDialog(this);
                }

                MessageBox.Show(Localization.votetime, Localization.timeofcount, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lbl_shownotvalidcode_Click(object sender, EventArgs e)
        {
            //Güzel sistem oldu
            //haha ulan listbox açıkken eklendiği zaman "hatalı kod bulunamadı" yazısını da eleman olarak kabul ediyor lan eğer açık kalıyorsa, kapalı kalıyorsa etmiyor adsgsd
            if (lst4box.Items.Count == 0)
            {
                int butonabasissayisi = 0;
                butonabasissayisi++;
                lst4box.Items.Add(butonabasissayisi.ToString());

                lbl_shownotvalidcode.Text = Localization.shownotvalidcode;
                lst_notvalidcode.Visible = false;
            }
            else
            {
                int yeni = Convert.ToInt32(lst4box.Items.Count.ToString());
                yeni++;
                lst4box.Items.Add(yeni.ToString());

                if (yeni % 2 == 0)
                {
                    lbl_shownotvalidcode.Text = Localization.hidenotvalidcode;
                    lst_notvalidcode.Visible = true;
                    if (lst_notvalidcode.Items.Count == 0)
                    {
                        lst_notvalidcode.Items.Add(Localization.couldntfindvalidcode);
                    }
                }
                else
                {
                    lbl_shownotvalidcode.Text = Localization.shownotvalidcode;
                    lst_notvalidcode.Visible = false;
                }
            }
        }
        private void btn_showinfo_Click(object sender, EventArgs e)
        {
            lbl_shownotvalidcode.Visible = true;
            lst_notvalidcode.Visible = true;
            lbl_countcode.Visible = true;
            lbl_countvalidcode.Visible = true;
            lbl_totalpeoplereceivecode.Visible = true;
            lbl_totalpeoplereceivecodewithvalid.Visible = true;
            //dt_soncikis.Visible = true;
            lbl_info.Visible = false;
            btn_showinfo.Visible = false;

            //önce o gridi başka bir gride aktarayım
            DataTable aktarilacak = new DataTable();

            aktarilacak.Columns.Add(Localization.name, typeof(string));
            aktarilacak.Columns.Add(Localization.verificationcode, typeof(string));
            aktarilacak.Columns.Add(Localization.vote, typeof(string));

            for (int i = 0; i < grid_info.Rows.Count; i++)
            {
                aktarilacak.Rows.Add(grid_info.Rows[i].Cells[0].Value.ToString(), grid_info.Rows[i].Cells[1].Value.ToString(), grid_info.Rows[i].Cells[2].Value.ToString());
            }

            grid_lastprocessreminder.DataSource = aktarilacak;

            //sonra da değerleri yıldızlı yapayım
            for (int g = 0; g < grid_info.Rows.Count; g++)
            {
                grid_info.Rows[g].Cells[0].Value = "*";
            }

            grid_info.Visible = true;
        }
        private void btn_letsvote_Click(object sender, EventArgs e)
        {
            //Settings.Default.text = Localization.preparing;
            //Settings.Default.Save();

            //using (loadingscreen frm = new loadingscreen(preparing))
            //{
              //  frm.ShowDialog(this);
            //}

            grid_votetable.ColumnCount = 1;

            grid_votetable.Columns[0].Name = Localization.votes;
            grid_votetable.Columns[0].HeaderText = Localization.votes;
            grid_votetable.Columns[0].Width = 450;

            for (int i = 0; i < grid_info.Rows.Count; i++)
            {
                string oylar = grid_info.Rows[i].Cells[2].Value.ToString();
                string[] oy = oylar.Split(',');
                foreach (string yaz in oy)
                {
                    lst_temporarymemory.Items.Add(yaz);
                    lst_permanentmemory.Items.Add(yaz);
                }

                for (int t = 0; t < lst_temporarymemory.Items.Count; t++)
                {
                    int idx = grid_votetable.Rows.Add();
                    grid_votetable.Rows[idx].Cells[0].Value = "*";
                }

                lst_temporarymemory.Items.Clear();
            }

            for (int g = 0; g < lst_permanentmemory.Items.Count; g++)
            {
                string d = lst_permanentmemory.Items[g].ToString();
                if (d.Contains(" ") == true)
                {
                    string kontrol = lst_permanentmemory.Items[g].ToString();
                    string oy = kontrol.Substring(1);
                    lst_notspacing.Items.Add(oy);
                }
                else
                {
                    lst_notspacing.Items.Add(d);
                }
            }

            countvote();
        }
        private void btn_newvotecount_Click(object sender, EventArgs e)
        {
            grid_votetable.Rows.Clear();
            table3.Rows.Clear();
            grid_info.DataSource = table3;
            table2.Rows.Clear();
            grid_votefinaltable.DataSource = table2;

            lst_invisible1.Items.Clear();
            lst_invisible2.Items.Clear();
            lst_errorlist.Items.Clear();
            lst_notvalidcode.Items.Clear();
            lst_invisible5.Items.Clear();
            lst_invisible6.Items.Clear();
            lst_invisible7.Items.Clear();
            lst_validname.Items.Clear();
            lst_validcode.Items.Clear();
            lst_validvote.Items.Clear();
            lst_notvalidname.Items.Clear();
            lst_notvalidcodewt.Items.Clear();
            lst_notvalidvote.Items.Clear();
            lst_notclick.Items.Clear();
            lst3box.Items.Clear();
            lst4box.Items.Clear();
            lst_permanentmemory.Items.Clear();
            lst_notspacing.Items.Clear();

            lbl_votecount.Visible = false;
            lbl_countcode.Text = Localization.number;
            lbl_countcode.Visible = false;
            lbl_countvalidcode.Text = Localization.number;
            lbl_countvalidcode.Visible = false;
            lbl_votecountnumber.Text = Localization.number;
            lbl_votecountnumber.Visible = false;

            btn_getmaillist.Enabled = false;
            btn_sendcode.Enabled = false;
            btn_getcode.Enabled = true;
            btn_letsvote.Enabled = false;
            btn_newvotecount.Visible = false;
            grid_votetable.Visible = false;
            grid_votefinaltable.Visible = false;

            //acaba yeni oylamada eski kodlar sıfırlanmış olacak mı???

            MessageBox.Show(Localization.votemessage, Localization.information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void grid_votetable_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(grid_votetable.CurrentRow.Index.ToString());
                grid_votetable.Rows[x].Cells[0].Value = lst_notspacing.Items[x].ToString();

                if (lst_notclick.Items.Contains(x.ToString()) == true)
                {

                }
                else
                {
                    DataView dv = table.DefaultView;
                    dv.RowFilter = "Oy LIKE '" + grid_votetable.Rows[x].Cells[0].Value.ToString() + "%'";
                    grid_invisible8.DataSource = dv;

                    lst_invisible5.Items.Clear();
                    for (int i = 0; i < grid_votefinaltable.Rows.Count; i++)
                    {
                        lst_invisible5.Items.Add(grid_votefinaltable.Rows[i].Cells[0].Value.ToString()); ;
                    }

                    if (lst_invisible5.Items.Contains(grid_invisible8.Rows[0].Cells[1].Value.ToString()) == false) //
                    {
                        string y = "1";
                        int ceviri = Convert.ToInt32(y);
                        table2.Rows.Add(grid_votetable.Rows[x].Cells[0].Value.ToString(), ceviri);
                    }
                    else
                    {
                        for (int i = 0; i < grid_votefinaltable.Rows.Count; i++)
                        {
                            if (grid_invisible8.Rows[0].Cells[1].Value.ToString() == grid_votefinaltable.Rows[i].Cells[0].Value.ToString())
                            {
                                int arttirilacak = Convert.ToInt32(grid_votefinaltable.Rows[i].Cells[1].Value.ToString());
                                arttirilacak++;
                                grid_votefinaltable.Rows[i].Cells[1].Value = arttirilacak;
                            }
                        }
                    }

                    grid_votefinaltable.Sort(grid_votefinaltable.Columns[1], ListSortDirection.Descending);
                    grid_votefinaltable.ClearSelection();
                    lst_notclick.Items.Add(x.ToString());

                    if (lst_notclick.Items.Count == grid_votetable.Rows.Count)
                    {
                        MessageBox.Show(Localization.votecountinfo, Localization.voteinfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_newvotecount.Visible = true;
                        btn_newvotecount.Enabled = true;
                    }

                }
                grid_votefinaltable.ClearSelection();
            }
            catch
            {
                return;
            }
        }
        private void lbl_programinfo_Click(object sender, EventArgs e)
        {
            programinfo x = new programinfo();
            x.Show();
        }
        private void lbl_editingaddress_Click(object sender, EventArgs e)
        {
            changingaddress x = new changingaddress();
            x.Show();
        }
        private void main_Load(object sender, EventArgs e)
        {
            table4.Columns.Add(Localization.name, typeof(string));
            table4.Columns.Add(Localization.mail, typeof(string));

            table5.Columns.Add(Localization.name, typeof(string));
            table5.Columns.Add(Localization.mail, typeof(string));

            table6.Columns.Add(Localization.name, typeof(string));
            table6.Columns.Add(Localization.mail, typeof(string));
            //evet bu ikisini buraya koyunca düzeldi çünkü ben void3'e her tıkladığımda yeni sütun ekliyordu ve bu yüzden de
            //yeni satır eklemesini sağlatamadık ondan hata veriyordu program, artık hata vermiyor şu an

            fillgrids();
            if (grid_invisible5.Rows.Count != 0)
            {
                for (int i = 0; i < grid_invisible5.Rows.Count; i++)
                {
                    lst_names.Items.Add(grid_invisible5.Rows[i].Cells[0].Value.ToString());
                    lst_mails.Items.Add(grid_invisible5.Rows[i].Cells[1].Value.ToString());
                    lst_codes.Items.Add(grid_invisible5.Rows[i].Cells[2].Value.ToString());
                }
            }

            grid_info.Visible = false;
            lbl_shownotvalidcode.Visible = false;
            lst_notvalidcode.Visible = false;
            lbl_countcode.Visible = false;
            lbl_countvalidcode.Visible = false;
            lbl_totalpeoplereceivecode.Visible = false;
            lbl_totalpeoplereceivecodewithvalid.Visible = false;

            if (lang.Default.language == Localization.turkce)
            {
                pict_changelang.Image = Properties.Resources.tr;
                Localization.Culture = new System.Globalization.CultureInfo(Localization.tr);
                lang.Default.language = Localization.turkce;
                lang.Default.Save();
                view();
                trform();
            }
            else if (lang.Default.language == Localization.english)
            {
                pict_changelang.Image = Properties.Resources.en;
                Localization.Culture = new System.Globalization.CultureInfo(Localization.en);
                lang.Default.language = Localization.english;
                lang.Default.Save();
                view();
                enform();
            }
        }
    }
}
