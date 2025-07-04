// j2sc#2302f.cs: Maskeli ve zengin metinkutusu ile durum�ubu�u �rne�i.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.ComponentModel; //CancelEventHandler
using System.Drawing.Printing; //PrintPageEventArgs i�in
using System.IO; //File, FileInfo i�in
namespace Bile�enler {
    public class AnaMen�: Form {
        public int se�=0;
        private TextBox metinKutu1;
        private TextBox metinKutu2;
        private Button d��me;
        public AnaMen�() {//Kurucu
            metinKutu1 = new TextBox();
            metinKutu2 = new TextBox();
            d��me = new Button();
            // metinKutu1
            metinKutu1.Location = new Point (15, 15);
            metinKutu1.Margin = new Padding (4, 4, 4, 4);
            metinKutu1.Name = "metinKutu1";
            metinKutu1.Size = new Size (250, 200);
            metinKutu1.TabIndex = 1;
            metinKutu1.Font = new Font ("Microsoft Sans Serif", 9F);
            metinKutu1.ForeColor=Color.LightCyan;
            metinKutu1.BackColor=Color.Black;
            metinKutu1.Multiline = true;
            metinKutu1.Text = "1: Edit�r ve dosya men�s�\r\n"+
                "2: MaskeliMetinkutu'ya veri giri�leri\r\n"+
                "3: RichTextBox .rtf edit�r ve dosyalar\r\n"+
                "4: ZenginMetinKutu stiller\r\n"+
                "5: RTF d�zenle bi�imle\r\n"+
                "6: RTF dosya bi�im yard�m\r\n"+
                "7: Durum�ubuklu panel\r\n"+
                "8: Anamen� ve durum�ubu�u\r\n"+
                "9: Men�s�z durum�ubu�u\r\n"+
                "Se�iminiz [1-9] (SON=-99):";
            //metinKutu2
            metinKutu2.Location = new Point (50, 220);
            metinKutu2.Name = "metinKutu2";
            metinKutu2.Text = "";
            metinKutu2.Size = new Size (30, 22);
            metinKutu2.TabIndex = 0;
            //metinKutu2.Focus();
            metinKutu2.ForeColor=Color.Yellow;
            metinKutu2.BackColor=Color.DarkRed;
            //d��me
            d��me.Location = new Point (90, 220);
            d��me.Name = "d��me";
            d��me.Size = new Size (80, 22);
            d��me.Text = "T�kla-Kapat";
            d��me.TabIndex = 2;
            d��me.ForeColor=Color.White;
            d��me.BackColor=Color.Black;
            d��me.Click += new EventHandler (d��me_T�kland�);
            //AnaMen�
            ClientSize = new Size (290, 250);
            Controls.Add (metinKutu1);
            Controls.Add (metinKutu2);
            Controls.Add (d��me);
            Text = "Ana Men�: Bir Form Se�imi";
            BackColor=Color.DarkSlateBlue;
            CenterToScreen();
        }
        private void d��me_T�kland� (object k, EventArgs o) {
            try {se� = int.Parse (metinKutu2.Text);
                if (se� == -99) Application.Exit();
                else if (se� < 1 | se� > 9) {se�=0; MessageBox.Show ("[1, 10] aras� bir se�enek girmelisiniz.");}
            }catch (Exception hata) {MessageBox.Show ("HATA: [" + hata.Message + "]");}
            metinKutu2.Text = "";
        }
    }
//------------------ Form1 --------------------------------------
    public class Form1: Form {
        private TextBox metinKutu;
        private MenuStrip anaMen�;
        private ToolStripMenuItem dosya;
        private ToolStripMenuItem yeni;
        private ToolStripMenuItem a�;
        private ToolStripMenuItem kaydet;
        private ToolStripMenuItem farkl�Kaydet;
        private ToolStripSeparator ayra�1;
        private ToolStripMenuItem yaz;
        private ToolStripMenuItem yaz�lan�G�r;
        private ToolStripMenuItem sayfaAyar�;
        private ToolStripSeparator ayra�2;
        private ToolStripMenuItem ��k;
        private OpenFileDialog a�Diyalo�u;
        private SaveFileDialog kaydetDiyalo�u;
        private PageSetupDialog ayarDiyalo�u;
        private PrintDialog yazDiyalo�u;
        private PrintPreviewDialog g�rDiyalo�u;
        private PrintPreviewControl g�rKontrolu;
        private PrintDocument belgeyiYaz;
        private string dosyaAd� = "Ads�z";
        private string[] sat�rlar;
        private int yaz�lanSat�rlar;
        public Form1() {//Kurucu
            Bile�eniBa�lat();
            if (dosyaAd� != null) {
                dosyaAd� = "j2sc#2318.cs";
                Dosyay�A�();
            }        
        }
        private void Bile�eniBa�lat() {
            metinKutu = new TextBox();
            anaMen� = new MenuStrip();
            dosya = new ToolStripMenuItem();
            yeni = new ToolStripMenuItem();
            a� = new ToolStripMenuItem();
            kaydet = new ToolStripMenuItem();
            farkl�Kaydet = new ToolStripMenuItem();
            a�Diyalo�u = new OpenFileDialog();
            kaydetDiyalo�u = new SaveFileDialog();
            ayra�1 = new ToolStripSeparator();
            yaz = new ToolStripMenuItem();
            yaz�lan�G�r = new ToolStripMenuItem();
            sayfaAyar� = new ToolStripMenuItem();
            ayra�2 = new ToolStripSeparator();
            ��k = new ToolStripMenuItem();
            belgeyiYaz = new PrintDocument();
            ayarDiyalo�u = new PageSetupDialog();
            yazDiyalo�u = new PrintDialog();
            g�rDiyalo�u = new PrintPreviewDialog();
            g�rKontrolu = new PrintPreviewControl();
            anaMen�.SuspendLayout();
            SuspendLayout();
            //metinKutu
            metinKutu.AcceptsReturn = true;
            metinKutu.AcceptsTab = true;
            metinKutu.Dock = DockStyle.Fill;
            metinKutu.Location = new Point (0, 24);
            metinKutu.Multiline = true;
            metinKutu.Name = "metinKutu";
            metinKutu.ScrollBars = ScrollBars.Both;
            metinKutu.Size = new Size (546, 203);
            metinKutu.BackColor=Color.Salmon;
            metinKutu.ForeColor=Color.Navy;
            //anaMen�
            anaMen�.Items.Add (dosya);
            anaMen�.Location = new Point (0, 0);
            anaMen�.Size = new Size (546, 24);
            anaMen�.Text = "Ana Men�";
            dosya.DropDownItems.AddRange (new ToolStripItem[] {yeni, a�, kaydet, farkl�Kaydet, ayra�1, yaz, yaz�lan�G�r, sayfaAyar�, ayra�2, ��k});
            dosya.Size = new Size (38, 20);
            dosya.Text = "&Dosya"; //Alt-d
            // 
            yeni.Size = new Size (159, 22);
            yeni.Text = "&Yeni"; //Alt-y
            yeni.Click += new EventHandler (Dosya_Yeni);
            // 
            a�.Size = new Size (159, 22);
            a�.Text = "&A�...";
            a�.Click += new EventHandler (Dosya_A�);
            // 
            kaydet.Size = new Size (159, 22);
            kaydet.Text = "&Kaydet";
            kaydet.Click += new EventHandler (Dosya_Kaydet);
            // 
            farkl�Kaydet.Size = new Size (159, 22);
            farkl�Kaydet.Text = "&Farkl� Kaydet";
            farkl�Kaydet.Click += new EventHandler (Dosya_Farkl�Kaydet);
            // a�Diyalo�u
            a�Diyalo�u.Filter = "Metin Belgeleri (*.txt)|*.txt|Wrox Belgeler (*.wroxtext)|*.wroxtext|T�m Dosyalar|*.*";
            // kaydetDiyalo�u
            kaydetDiyalo�u.FileName = "Ads�z";
            kaydetDiyalo�u.Filter = "Metin Belgesi (*.txt)|*.txt|Wrox Belge (*.wroxtext)|*.wroxtext";
            kaydetDiyalo�u.FilterIndex = 2;
            ayra�1.Size = new Size (156, 6);
            // 
            yaz.Size = new Size (159, 22);
            yaz.Text = "Yaz&..."; //Alt-z
            yaz.Click += new EventHandler (Dosya_Yaz);
            // yaz�lan�G�r
            yaz�lan�G�r.Name = "yaz�lan�G�r";
            yaz�lan�G�r.Size = new Size (159, 22);
            yaz�lan�G�r.Text = "&G�r...";
            yaz�lan�G�r.Click += new EventHandler (Dosya_G�r);
            // sayfaAyar�
            sayfaAyar�.Name = "sayfaAyar�";
            sayfaAyar�.Size = new Size (159, 22);
            sayfaAyar�.Text = "Ayar&..."; //Alt-r
            sayfaAyar�.Click += new EventHandler (Dosya_Ayar);
            ayra�2.Size = new Size (156, 6);
            // ��k
            ��k.Name = "��k";
            ��k.Size = new Size (159, 22);
            ��k.Text = "&��k";
            // belgeyiYaz
            belgeyiYaz.PrintPage += new PrintPageEventHandler (Yaz_Sayfa);
            belgeyiYaz.BeginPrint += new PrintEventHandler (Yaz_Ba�la);
            belgeyiYaz.EndPrint += new PrintEventHandler (Yaz_Bitir);
            // ayarDiyalo�u
            ayarDiyalo�u.Document = belgeyiYaz;
            ayarDiyalo�u.ShowHelp = true;
            // yazDiyalo�u
            yazDiyalo�u.Document = belgeyiYaz;
            yazDiyalo�u.UseEXDialog = true;
            // g�rDiyalo�u
            g�rDiyalo�u.AutoScrollMargin = new Size (0, 0);
            g�rDiyalo�u.AutoScrollMinSize = new Size (0, 0);
            g�rDiyalo�u.ClientSize = new Size (400, 300);
            g�rDiyalo�u.Document = belgeyiYaz;
            g�rDiyalo�u.Enabled = true;
            g�rDiyalo�u.Name = "g�rDiyalo�u";
            g�rDiyalo�u.Visible = false;
            // g�rKontrolu
            g�rKontrolu.Dock = DockStyle.Fill;
            g�rKontrolu.Document = belgeyiYaz;
            g�rKontrolu.Location = new Point (0, 24);
            g�rKontrolu.Name = "g�rKontrolu";
            g�rKontrolu.Size = new Size (546, 203);
            g�rKontrolu.TabIndex = 2;
            g�rKontrolu.Visible = false;
            // Form1
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (546, 227);
            Controls.Add (anaMen�);
            Controls.Add (metinKutu);
            Controls.Add (g�rKontrolu);
            MainMenuStrip = anaMen�;
            Name = "Form1";
            Text = "Form1: Basit ��levsel Edit�r";
            anaMen�.ResumeLayout (false);
            anaMen�.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void Dosyay�A�() {
            try {
                metinKutu.Clear();
                metinKutu.Text = File.ReadAllText (dosyaAd�);
            }catch (IOException ht) {MessageBox.Show (ht.Message, "Basit Edit�r", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
        }
        private void Dosya_Yeni (object k, EventArgs o) {
            dosyaAd� = "Ads�z";
            FormBa�l���();
            metinKutu.Clear();
        }
        private void Dosya_A� (object k, EventArgs o) {
            if (a�Diyalo�u.ShowDialog() == DialogResult.OK) {
                dosyaAd� = a�Diyalo�u.FileName;
                FormBa�l���();
                Dosyay�A�();
            }
        }
        private void Dosyay�Kaydet() {
            try {File.WriteAllText (dosyaAd�, metinKutu.Text);
            }catch (IOException ht) {MessageBox.Show (ht.Message, "Basit Edit�r", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
        }
        private void Dosya_Kaydet (object k, EventArgs o) {
            if (dosyaAd� == "Ads�z") {Dosya_Farkl�Kaydet (k, o);
            }else {Dosyay�Kaydet();}
        }
        private void FormBa�l���() {
            FileInfo fi = new FileInfo (dosyaAd�);
            Text = fi.Name + " - Basit Edit�r";
        }
        private void Dosya_Farkl�Kaydet (object k, EventArgs o) {
            if (kaydetDiyalo�u.ShowDialog() == DialogResult.OK) {
                dosyaAd� = kaydetDiyalo�u.FileName;
                FormBa�l���();
                Dosyay�Kaydet();
            }
        }
        private void Yaz_Sayfa (object k, PrintPageEventArgs o) {
            int x = o.MarginBounds.Left;
            int y = o.MarginBounds.Top;
            while (yaz�lanSat�rlar < sat�rlar.Length) {
                o.Graphics.DrawString (sat�rlar [yaz�lanSat�rlar++], new Font("Arial", 10), Brushes.Black, x, y);
                y += 25;
                if (y >= o.MarginBounds.Bottom) {
                    o.HasMorePages = true;
                    return;
                }
            }
            yaz�lanSat�rlar = 0;
            o.HasMorePages = false;
        }
        private void Dosya_Yaz (object k, EventArgs o) {
            try {
                if (metinKutu.SelectedText != "") {yazDiyalo�u.AllowSelection = true;}
                if (yazDiyalo�u.ShowDialog() == DialogResult.OK) {belgeyiYaz.Print();}
            }catch (InvalidPrinterException ht) {MessageBox.Show (ht.Message, "Basit Edit�r", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void Yaz_Ba�la (object k, PrintEventArgs o) {
            char[] param = {'\n'};
            if (yazDiyalo�u.PrinterSettings.PrintRange == PrintRange.Selection) {sat�rlar = metinKutu.SelectedText.Split (param);
            }else {sat�rlar = metinKutu.Text.Split (param);}
            int i = 0;
            char[] trimParam = {'\r'};
            foreach (string s in sat�rlar) {sat�rlar [i++] = s.TrimEnd (trimParam);}
        }
        private void Yaz_Bitir (object k, PrintEventArgs o) {sat�rlar = null;}
        private void Dosya_Ayar (object k, EventArgs o) {ayarDiyalo�u.ShowDialog();}
        private void Dosya_G�r (object k, EventArgs o) {g�rDiyalo�u.ShowDialog();}
    }
//---------------------- Form2 ----------------------------------
    public partial class Form2: Form {
        public Form2() {Bile�eniBa�lat();} //Kurucu
        private void d��me2a_T�kland� (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00:00:00";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void d��me2b_T�kland� (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00000-9999";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void d��me2c_T�kland� (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "$00.00";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void d��me2d_T�kland� (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = ">LCCC 9LL";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void d��me2e_T�kland�(object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00/00/0000";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void d��me2f_T�kland� (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "000-000-000";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
    }
    partial class Form2 {
        private MaskedTextBox maskeliMetinKutu;
        private Label fi�2a;
        private Label fi�2b;
        private Button d��me2a;
        private Button d��me2b;
        private Button d��me2c;
        private Button d��me2d;
        private Button d��me2e;
        private Button d��me2f;
        private void Bile�eniBa�lat() {
            maskeliMetinKutu = new MaskedTextBox();
            fi�2a = new Label();
            fi�2b = new Label();
            d��me2a = new Button();
            d��me2b = new Button();
            d��me2c = new Button();
            d��me2d = new Button();
            d��me2e = new Button();
            d��me2f = new Button();
            SuspendLayout();
            //fi�2a
            fi�2a.AutoSize = true;
            fi�2a.Location = new Point (12, 10);
            fi�2a.Name = "fi�2a";
            fi�2a.Size = new Size (94, 13);
            fi�2a.TabIndex = 1;
            fi�2a.Font = new Font ("Microsoft Sans Serif", 12F);
            fi�2a.Text = "Aktif girdi maskesi:";
            //fi�2b
            fi�2b.AutoSize = true;
            fi�2b.Location = new Point (150, 10);
            fi�2b.Name = "fi�2b";
            fi�2b.Size = new Size (51, 13);
            fi�2b.TabIndex = 2;
            fi�2b.Font = new Font ("Microsoft Sans Serif", 15F);
            fi�2b.Text = "Veri gir";
            //maskeliMetinKutu
            maskeliMetinKutu.BeepOnError = true;
            maskeliMetinKutu.Location = new Point (15, 41);
            maskeliMetinKutu.Name = "maskeliMetinKutu";
            maskeliMetinKutu.Size = new Size (265, 20);
            maskeliMetinKutu.TabIndex = 0;
            maskeliMetinKutu.BackColor=Color.Orange;
            maskeliMetinKutu.ForeColor=Color.MediumBlue;
            //d��me2a
            d��me2a.Location = new Point (15, 85);
            d��me2a.Name = "d��me2a";
            d��me2a.Size = new Size (83, 23);
            d��me2a.TabIndex = 3;
            d��me2a.Text = "24-saatl� zaman";
            d��me2a.UseVisualStyleBackColor = true;
            d��me2a.Click += new EventHandler (d��me2a_T�kland�);
            //d��me2b
            d��me2b.Location = new Point (15, 130);
            d��me2b.Name = "d��me2b";
            d��me2b.Size = new Size (83, 23);
            d��me2b.TabIndex = 4;
            d��me2b.Text = "ABD PK";
            d��me2b.UseVisualStyleBackColor = true;
            d��me2b.Click += new EventHandler (d��me2b_T�kland�);
            //d��me2c
            d��me2c.Location = new Point (104, 85);
            d��me2c.Name = "d��me2c";
            d��me2c.Size = new Size (87, 23);
            d��me2c.TabIndex = 5;
            d��me2c.Text = "Para";
            d��me2c.UseVisualStyleBackColor = true;
            d��me2c.Click += new EventHandler (d��me2c_T�kland�);
            //d��me2d
            d��me2d.Location = new Point (104, 130);
            d��me2d.Name = "d��me2d";
            d��me2d.Size = new Size (87, 23);
            d��me2d.TabIndex = 6;
            d��me2d.Text = "BK PK";
            d��me2d.UseVisualStyleBackColor = true;
            d��me2d.Click += new EventHandler (d��me2d_T�kland�);
            //d��me2e
            d��me2e.Location = new Point (197, 85);
            d��me2e.Name = "d��me2e";
            d��me2e.Size = new Size (83, 23);
            d��me2e.TabIndex = 7;
            d��me2e.Text = "K�sa Tarih";
            d��me2e.UseVisualStyleBackColor = true;
            d��me2e.Click += new EventHandler (d��me2e_T�kland�);
            //d��me2f
            d��me2f.Location = new Point (197, 130);
            d��me2f.Name = "d��me2f";
            d��me2f.Size = new Size (83, 23);
            d��me2f.TabIndex = 8;
            d��me2f.Text = "Gizli PIN";
            d��me2f.UseVisualStyleBackColor = true;
            d��me2f.Click += new EventHandler (d��me2f_T�kland�);
            //Form2
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 196);
            Controls.AddRange (new Control[] {d��me2f, d��me2e, d��me2d, d��me2c, d��me2b, d��me2a, fi�2b, fi�2a, maskeliMetinKutu});
            Name = "Form2";
            Text = "Form2: Maskl�MetinKutu'ya Veri Giri�leri";
            BackColor=Color.SteelBlue;
            ForeColor=Color.Red;
            ResumeLayout (false);
            PerformLayout();
        }
    }
//---------------------- Form3 ----------------------------------
    public class Form3: Form {
        private MenuStrip men��eridi;
        private ToolStripMenuItem men�Birimi3a;
        private ToolStripMenuItem men�Birimi3a1;
        private ToolStripMenuItem men�Birimi3a2;
        private ToolStripSeparator ayra�3a1;
        private ToolStripMenuItem men�Birimi3a3;
        private ToolStripMenuItem men�Birimi3a4;
        private ToolStripSeparator ayra�3a2;
        private ToolStripMenuItem men�Birimi3a5;
        private ToolStripMenuItem men�Birimi3a6;
        private ToolStripSeparator ayra�3a3;
        private ToolStripMenuItem men�Birimi3a7;
        private ToolStripMenuItem men�Birimi3b;
        private ToolStripMenuItem men�Birimi3b1;
        private ToolStripMenuItem men�Birimi3c;
        private ToolStripMenuItem men�Birimi3c1;
        private ToolStripMenuItem men�Birimi3c2;
        private ToolStripMenuItem men�Birimi3c3;
        private ToolStripSeparator ayra�3c1;
        private ToolStripMenuItem men�Birimi3c4;
        private RichTextBox zenginMetinKutu;
        public Form3() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            men��eridi = new MenuStrip();
            men�Birimi3a = new ToolStripMenuItem();
            men�Birimi3a1 = new ToolStripMenuItem();
            men�Birimi3a2 = new ToolStripMenuItem();
            ayra�3a1 = new ToolStripSeparator();
            men�Birimi3a3 = new ToolStripMenuItem();
            men�Birimi3a4 = new ToolStripMenuItem();
            ayra�3a2 = new ToolStripSeparator();
            men�Birimi3a5 = new ToolStripMenuItem();
            men�Birimi3a6 = new ToolStripMenuItem();
            ayra�3a3 = new ToolStripSeparator();
            men�Birimi3a7 = new ToolStripMenuItem();
            men�Birimi3b = new ToolStripMenuItem();
            men�Birimi3b1 = new ToolStripMenuItem();
            men�Birimi3c = new ToolStripMenuItem();
            men�Birimi3c1 = new ToolStripMenuItem();
            men�Birimi3c2 = new ToolStripMenuItem();
            men�Birimi3c3 = new ToolStripMenuItem();
            ayra�3c1 = new ToolStripSeparator();
            men�Birimi3c4 = new ToolStripMenuItem();
            zenginMetinKutu = new RichTextBox();
            men��eridi.SuspendLayout();
            SuspendLayout();
            //men��eridi
            men��eridi.Items.AddRange (new ToolStripItem[] {men�Birimi3a, men�Birimi3b, men�Birimi3c});
            men��eridi.Location = new Point (0, 0);
            men��eridi.Name = "men��eridi";
            men��eridi.Size = new Size (602, 24);
            men��eridi.TabIndex = 0;
            men��eridi.Text = "men��eridi";
            //men�Birimi3a
            men�Birimi3a.DropDownItems.AddRange (new ToolStripItem[] {
                men�Birimi3a1,
                men�Birimi3a2,
                ayra�3a1,
                men�Birimi3a3,
                men�Birimi3a4,
                ayra�3a2,
                men�Birimi3a5,
                men�Birimi3a6,
                ayra�3a3,
                men�Birimi3a7});
            men�Birimi3a.Name = "men�Birimi3a";
            men�Birimi3a.Size = new Size (35, 20);
            men�Birimi3a.Text = "&Dosya"; //Alt-d
            //men�Birimi3a1
            men�Birimi3a1.Name = "men�Birimi3a1";
            men�Birimi3a1.ShortcutKeys = ((Keys)((Keys.Control | Keys.Y)));
            men�Birimi3a1.Size = new Size (151, 22);
            men�Birimi3a1.Text = "&Yeni";
            men�Birimi3a1.Click += new EventHandler (men�Birimi3a1_T�kland�);
            //men�Birimi3a2
            men�Birimi3a2.Name = "men�Birimi3a2";
            men�Birimi3a2.ShortcutKeys = ((Keys)((Keys.Control | Keys.A)));
            men�Birimi3a2.Size = new Size (151, 22);
            men�Birimi3a2.Text = "&A�";
            men�Birimi3a2.Click += new EventHandler (men�Birimi3a2_T�kland�);
            //ayra�3a1
            ayra�3a1.Name = "ayra�3a1";
            ayra�3a1.Size = new Size (148, 6);
            //men�Birimi3a3
            men�Birimi3a3.Name = "men�Birimi3a3";
            men�Birimi3a3.ShortcutKeys = ((Keys)((Keys.Control | Keys.K)));
            men�Birimi3a3.Size = new Size (151, 22);
            men�Birimi3a3.Text = "&Kaydet";
            men�Birimi3a3.Click += new EventHandler (men�Birimi3a3_T�kland�);
            //men�Birimi3a4
            men�Birimi3a4.ShortcutKeys = ((Keys)((Keys.Control | Keys.F)));
            men�Birimi3a4.Name = "men�Birimi3a4";
            men�Birimi3a4.Size = new Size (151, 22);
            men�Birimi3a4.Text = "&Farkl� Kaydet";
            //ayra�3a2
            ayra�3a2.Name = "ayra�3a2";
            ayra�3a2.Size = new Size (148, 6);
            //men�Birimi3a5
            men�Birimi3a5.Name = "men�Birimi3a5";
            men�Birimi3a5.ShortcutKeys = ((Keys)((Keys.Control | Keys.Z)));
            men�Birimi3a5.Size = new Size (151, 22);
            men�Birimi3a5.Text = "Yaz&";
            //men�Birimi3a6
            men�Birimi3a6.Name = "men�Birimi3a6";
            men�Birimi3a6.ShortcutKeys = ((Keys)((Keys.Control | Keys.G)));
            men�Birimi3a6.Size = new Size (151, 22);
            men�Birimi3a6.Text = "Yaz�lan� &G�r";
            //ayra�3a3
            ayra�3a3.Name = "ayra�3a3";
            ayra�3a3.Size = new Size (148, 6);
            //men�Birimi3a7
            men�Birimi3a7.Name = "men�Birimi3a7";
            men�Birimi3a7.Size = new Size(151, 22);
            men�Birimi3a7.Text = "&��k"; //Alt-�
            //men�Birimi3b
            men�Birimi3b.DropDownItems.AddRange (new ToolStripItem[] {men�Birimi3b1});
            men�Birimi3b.Name = "men�Birimi3b";
            men�Birimi3b.Size = new Size (53, 20);
            men�Birimi3b.Text = "&Bi�im";
            //men�Birimi3b1
            men�Birimi3b1.Checked = true;
            men�Birimi3b1.CheckOnClick = true;
            men�Birimi3b1.CheckState = CheckState.Checked;
            men�Birimi3b1.Name = "men�Birimi3b1";
            men�Birimi3b1.Size = new Size (164, 22);
            men�Birimi3b1.Text = "Yard�m Men�s�n� G�ster";
            men�Birimi3b1.Click += new EventHandler (men�Birimi3b1_T�kland�);
            //men�Birimi3c
            men�Birimi3c.DropDownItems.AddRange (new ToolStripItem[] {
                men�Birimi3c1,
                men�Birimi3c2,
                men�Birimi3c3,
                ayra�3c1,
                men�Birimi3c4});
            men�Birimi3c.Name = "men�Birimi3c";
            men�Birimi3c.Size = new Size (40, 20);
            men�Birimi3c.Text = "&Yard�m";
            //men�Birimi3c1
            men�Birimi3c1.Name = "men�Birimi3c1";
            men�Birimi3c1.Size = new Size (129, 22);
            men�Birimi3c1.Text = "��erikler";
            //men�Birimi3c2
            men�Birimi3c2.Name = "men�Birimi3c2";
            men�Birimi3c2.Size = new Size (129, 22);
            men�Birimi3c2.Text = "Dizin";
            //men�Birimi3c3
            men�Birimi3c3.Name = "men�Birimi3c3";
            men�Birimi3c3.Size = new Size (129, 22);
            men�Birimi3c3.Text = "Ara�t�r";
            //ayra�3c1
            ayra�3c1.Name = "ayra�3c1";
            ayra�3c1.Size = new Size (126, 6);
            //men�Birimi3c4
            men�Birimi3c4.Name = "men�Birimi3c4";
            men�Birimi3c4.Size = new Size (129, 22);
            men�Birimi3c4.Text = "Hakk�nda";
            //zenginMetinKutu
            zenginMetinKutu.Dock = DockStyle.Fill;
            zenginMetinKutu.Location = new Point (0, 24);
            zenginMetinKutu.Name = "\n\nzenginMetinKutu";
            zenginMetinKutu.Size = new Size (602, 242);
            zenginMetinKutu.TabIndex = 1;
            zenginMetinKutu.Text = "Zengin metin kutusu";
            zenginMetinKutu.BackColor=Color.Bisque;
            zenginMetinKutu.ForeColor=Color.Navy;
            //Form3
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (602, 266);
            Controls.Add (men��eridi);
            Controls.Add (zenginMetinKutu);
            Text="Form3: ZenginMetinKutusu (.rtf)";
            MainMenuStrip = men��eridi;
            men��eridi.ResumeLayout (false);
            men��eridi.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void men�Birimi3b1_T�kland� (object k, EventArgs o) {
            ToolStripMenuItem birim = (ToolStripMenuItem)k;
            men�Birimi3c.Visible = birim.Checked;
        }
        private void men�Birimi3a1_T�kland� (object k, EventArgs o) {zenginMetinKutu.Text = "\n\n\nM.Nihat Yava�, Toroslar-Mersin\r\n21.05.2025 00:57";}
        private void men�Birimi3a2_T�kland� (object k, EventArgs o) {zenginMetinKutu.LoadFile (@"j2sc#2302f.rtf");}
        private void men�Birimi3a3_T�kland� (object k, EventArgs o) {zenginMetinKutu.SaveFile (@"mny1.rtf");}
    }
//---------------------- Form4 ----------------------------------
    class Form4: Form {
        private Button d��me4a;
        private Button d��me4b;
        private Button d��me4c;
        private Button d��me4d;
        private Button d��me4e;
        private Button d��me4f;
        private Label fi�;
        private TextBox metinKutu;
        private RichTextBox zenginMetinKutu;
        public Form4() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            d��me4a = new Button();
            d��me4b = new Button();
            d��me4c = new Button();
            d��me4d = new Button();
            d��me4e = new Button();
            d��me4f = new Button();
            fi� = new Label();
            metinKutu = new TextBox();
            zenginMetinKutu = new RichTextBox();
            SuspendLayout();
            //d��me4a
            d��me4a.Anchor = AnchorStyles.Top;
            d��me4a.Location = new Point (187, 13);
            d��me4a.Margin = new Padding (3, 3, 3, 1);
            d��me4a.Name = "d��me4a";
            d��me4a.Size = new Size (82, 23);
            d��me4a.TabIndex = 0;
            d��me4a.Text = "Koyu";
            d��me4a.BackColor=Color.Salmon;
            d��me4a.Click += new EventHandler (d��me4a_T�kland�);
            //d��me4b
            d��me4b.Anchor = AnchorStyles.Top;
            d��me4b.Location = new Point (276, 13);
            d��me4b.Margin = new Padding (3, 3, 3, 1);
            d��me4b.Name = "d��me4b";
            d��me4b.Size = new Size (82, 23);
            d��me4b.TabIndex = 1;
            d��me4b.Text = "Alt�izgi";
            d��me4b.BackColor=Color.Salmon;
            d��me4b.Click += new EventHandler (d��me4b_T�kland�);
            //d��me4c
            d��me4c.Anchor = AnchorStyles.Top;
            d��me4c.Location = new Point (365, 13);
            d��me4c.Margin = new Padding (3, 3, 3, 1);
            d��me4c.Name = "d��me4c";
            d��me4c.Size = new Size (82, 23);
            d��me4c.TabIndex = 2;
            d��me4c.Text = "Yat�k";
            d��me4c.BackColor=Color.Salmon;
            d��me4c.Click += new EventHandler (d��me4c_T�kland�);
            //d��me4d
            d��me4d.Anchor = AnchorStyles.Top;
            d��me4d.Location = new Point (454, 13);
            d��me4d.Margin = new Padding (3, 3, 3, 1);
            d��me4d.Name = "d��me4d";
            d��me4d.Size = new Size (82, 23);
            d��me4d.TabIndex = 3;
            d��me4d.Text = "Ortala";
            d��me4d.BackColor=Color.Salmon;
            d��me4d.Click += new EventHandler (d��me4d_T�kland�);
            //d��me4e
            d��me4e.Anchor = AnchorStyles.Bottom;
            d��me4e.Location = new Point (276, 309);
            d��me4e.Margin = new Padding (3, 0, 3, 3);
            d��me4e.Name = "d��me4e";
            d��me4e.Size = new Size(82, 23);
            d��me4e.TabIndex = 5;
            d��me4e.Text = "Y�kle";
            d��me4e.BackColor=Color.Salmon;
            d��me4e.Click += new EventHandler (d��me4e_T�kland�);
            //d��me4bf
            d��me4f.Anchor = AnchorStyles.Bottom;
            d��me4f.Location = new Point (365, 309);
            d��me4f.Margin = new Padding(3, 0, 3, 3);
            d��me4f.Name = "d��me4f";
            d��me4f.Size = new Size (82, 23);
            d��me4f.TabIndex = 4;
            d��me4f.Text = "Kaydet";
            d��me4f.BackColor=Color.Salmon;
            d��me4f.Click += new EventHandler (d��me4f_T�kland�);
            //fi�
            fi�.Anchor = AnchorStyles.Top;
            fi�.AutoSize = true;
            fi�.Location = new Point (295, 46);
            fi�.Name = "fi�";
            fi�.Size = new Size (26, 14);
            fi�.TabIndex = 6;
            fi�.Text = "Ebat";
            //metinKutu
            metinKutu.Anchor = AnchorStyles.Top;
            metinKutu.Location = new Point (328, 43);
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (25, 16);
            metinKutu.TabIndex = 7;
            metinKutu.Text = "10";
            metinKutu.BackColor=Color.Lime;
            metinKutu.ForeColor=Color.DarkRed;
            metinKutu.Validating += new CancelEventHandler (metinKutu_Ge�erliyor);
            metinKutu.KeyPress += new KeyPressEventHandler (metinKutu_Tu�Bas�ld�);
            //
            zenginMetinKutu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            zenginMetinKutu.Location = new Point (13, 70);
            zenginMetinKutu.Name = "zenginMetinKutu";
            zenginMetinKutu.Size = new Size (686, 232);
            zenginMetinKutu.TabIndex = 8;
            zenginMetinKutu.Text = "\n\n\nM.Nihat Yava�, Toroslar-Mersin\r\n21.05.2025 02:03";
            zenginMetinKutu.BackColor=Color.SkyBlue;
            zenginMetinKutu.ForeColor=Color.Sienna;
            zenginMetinKutu.LinkClicked += new LinkClickedEventHandler (zenginMetinKutu_Ba�T�kland�);
            //
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (722, 341);
            Controls.AddRange (new Control[] {d��me4a, d��me4b, d��me4c, d��me4d, d��me4e, d��me4f, fi�, metinKutu, zenginMetinKutu});
            MinimumSize = new Size (730, 368);
            Name = "Form4";
            Text = "Form4: ZenginMetinKutu Stiller";
            BackColor=Color.DarkKhaki;
            ForeColor=Color.DarkGreen;
            ResumeLayout (false);
            PerformLayout();
        }
        private void d��me4a_T�kland� (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Bold) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Bold);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Bold);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void d��me4b_T�kland� (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Underline) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Underline);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Underline);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void d��me4c_T�kland� (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Italic) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Italic);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Italic);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void d��me4d_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionAlignment == HorizontalAlignment.Center) zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Left;
            else zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Center;
            zenginMetinKutu.Focus();
        }
        private void metinKutu_Tu�Bas�ld� (object k, KeyPressEventArgs o) {
            if ((o.KeyChar < 48 || o.KeyChar > 57) && o.KeyChar != 8 && o.KeyChar != 13) {o.Handled = true;
            }else if (o.KeyChar == 13) {
                TextBox mk = (TextBox)k;
                if (mk.Text.Length > 0) Ebat�MetneUygula (mk.Text);
                o.Handled = true;
                zenginMetinKutu.Focus();
            }
        }
        private void metinKutu_Ge�erliyor(object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            Ebat�MetneUygula (mk.Text);
            zenginMetinKutu.Focus();
        }
        private void Ebat�MetneUygula (string metin) {
            float yeniEbat = Convert.ToSingle (metin);
            FontFamily fonAilesi;
            Font yeniFon;
            fonAilesi = zenginMetinKutu.SelectionFont.FontFamily;
            yeniFon = new Font (fonAilesi, yeniEbat);
            zenginMetinKutu.SelectionFont = yeniFon;
        }
        private void zenginMetinKutu_Ba�T�kland� (object k, LinkClickedEventArgs o) {System.Diagnostics.Process.Start (o.LinkText);}
        private void d��me4e_T�kland� (object k, EventArgs o) {
            try {zenginMetinKutu.LoadFile ("j2sc#2302f.rtf");
            }catch (FileNotFoundException) {MessageBox.Show ("Y�klenecek bu adda dosya bulunamad�");}
        }
        private void d��me4f_T�kland� (object k, EventArgs o) {
            try {zenginMetinKutu.SaveFile ("mny1.rtf");
            }catch (Exception ht) {MessageBox.Show (ht.Message);}
        }
    }
//---------------------- Form5 ----------------------------------
    public class Form5: Form {
        RichTextBox zenginMetinKutu;
        public Form5() {//Kurucu
            Size = new Size (400, 500);
            Text = "Form5: ZenginMetinKutu D�zenle Bi�imle";
            //zenginMetinKutu
            zenginMetinKutu = new RichTextBox();
            zenginMetinKutu.Parent = this;
            zenginMetinKutu.Text = "\n\n\nM.Nihat Yava�, Toroslar-Mersin\r\n21.05.2025 03:48";
            zenginMetinKutu.Multiline = true;
            zenginMetinKutu.BorderStyle = BorderStyle.Fixed3D;
            zenginMetinKutu.ScrollBars = RichTextBoxScrollBars.ForcedBoth;  
            zenginMetinKutu.Dock = DockStyle.Fill;
            zenginMetinKutu.DetectUrls = true;               
            zenginMetinKutu.AutoWordSelection = true;  
            zenginMetinKutu.BulletIndent = 10;
            zenginMetinKutu.ShowSelectionMargin = true;
            zenginMetinKutu.BackColor=Color.Wheat;
            zenginMetinKutu.ForeColor=Color.DarkGreen;
            //men�Birim5a
            MenuItem men�Birim5a1 = new MenuItem ("&�thal",new EventHandler (men�Birim5a1_T�kland�));
            MenuItem men�Birim5a = new MenuItem ("&Dosya", new MenuItem[] {men�Birim5a1});
            //men�Birim5b
            MenuItem men�Birim5b1 = new MenuItem ("&Gerial", new EventHandler (men�Birim5b1_T�kland�), Shortcut.CtrlG);
            MenuItem men�Birim5b2 = new MenuItem ("-");
            MenuItem men�Birim5b3 = new MenuItem ("&Kes",  new EventHandler (men�Birim5b3_T�kland�),  Shortcut.CtrlK);
            MenuItem men�Birim5b4 = new MenuItem ("Kop&yala", new EventHandler (men�Birim5b4_T�kland�), Shortcut.CtrlP);
            MenuItem men�Birim5b5 = new MenuItem ("&Rtf Kopyala",  new EventHandler (men�Birim5b5_T�kland�));
            MenuItem men�Birim5b6 = new MenuItem ("&Yap��t�r", new EventHandler (men�Birim5b6_T�kland�), Shortcut.CtrlY);
            MenuItem men�Birim5b7 = new MenuItem ("&Sil", new EventHandler (men�Birim5b7_T�kland�));
            MenuItem men�Birim5b8 = new MenuItem ("-");
            MenuItem men�Birim5b9 = new MenuItem ("&T�m�n� Se�",  new EventHandler (men�Birim5b9_T�kland�), Shortcut.CtrlT);
            MenuItem men�Birim5b10 = new MenuItem ("�lk &5 Krk Se�", new EventHandler (men�Birim5b10_T�kland�), Shortcut.Ctrl5);
            MenuItem men�Birim5b11 = new MenuItem ("Temiz&le", new EventHandler (men�Birim5b11_T�kland�));
            MenuItem men�Birim5b = new MenuItem ("D�ze&n", new MenuItem[] {men�Birim5b1, men�Birim5b2, men�Birim5b3, men�Birim5b4, men�Birim5b5, men�Birim5b6, men�Birim5b7, men�Birim5b8, men�Birim5b9, men�Birim5b10, men�Birim5b11});
            //men�Birim5c
            MenuItem men�Birim5c1 = new MenuItem ("�mlece &Kayd�r", new EventHandler (men�Birim5c1_T�kland�));
            MenuItem men�Birim5c = new MenuItem ("&G�r", new MenuItem[] {men�Birim5c1});
            //men�Birim5d
            MenuItem men�Birim5d1 = new MenuItem ("&Bilye", new EventHandler (men�Birim5d1_T�kland�));
            MenuItem men�Birim5d2a = new MenuItem("&Sola Yana�t�r", new EventHandler (men�Birim5d2a_T�kland�));
            MenuItem men�Birim5d2b = new MenuItem("Sa&�a Yana�t�r", new EventHandler (men�Birim5d2b_T�kland�));
            MenuItem men�Birim5d2c = new MenuItem("&Ortala", new EventHandler (men�Birim5d2c_T�kland�));
            MenuItem men�Birim5d2 = new MenuItem ("&Hizala", new MenuItem[] {men�Birim5d2a, men�Birim5d2b, men�Birim5d2c});
            MenuItem men�Birim5d3 = new MenuItem ("&K�rm�z�", new EventHandler (men�Birim5d3_T�kland�));
            MenuItem men�Birim5d4 = new MenuItem ("Ko&yu", new EventHandler (men�Birim5d4_T�kland�));
            MenuItem men�Birim5d5 = new MenuItem ("As&k�l� Girinti", new EventHandler (men�Birim5d5_T�kland�));
            MenuItem men�Birim5d6 = new MenuItem ("Gir&inti", new EventHandler (men�Birim5d6_T�kland�));
            MenuItem men�Birim5d7 = new MenuItem ("Sa�d&an Girinti",  new EventHandler (men�Birim5d7_T�kland�));
            MenuItem men�Birim5d = new MenuItem ("&Bi�im", new MenuItem[] {men�Birim5d1, men�Birim5d2, men�Birim5d3, men�Birim5d4, men�Birim5d5, men�Birim5d6, men�Birim5d7});
            //Men�
            Menu = new MainMenu (new MenuItem[] {men�Birim5a, men�Birim5b, men�Birim5c, men�Birim5d});
        }
        private void men�Birim5a1_T�kland� (object k, EventArgs o) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"c:\";
            ofd.Filter = "RTF files (*.rtf)|*.rtf|" + "All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK) {
                try {
                    StreamReader sr = new StreamReader (ofd.FileName);
                    zenginMetinKutu.Rtf = sr.ReadToEnd();
                    sr.Close();
                }catch (Exception ht) {
                    MessageBox.Show (ht.Message);
                    return;
                }
            }
        }
        private void men�Birim5b1_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.CanUndo == true) {
                zenginMetinKutu.Undo();
                zenginMetinKutu.ClearUndo();
            }
        }
        private void men�Birim5b3_T�kland� (object k, EventArgs o) {if (zenginMetinKutu.SelectedText != "") zenginMetinKutu.Cut();}
        private void men�Birim5b4_T�kland� (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) zenginMetinKutu.Copy();}
        private void men�Birim5b5_T�kland� (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) Clipboard.SetDataObject (zenginMetinKutu.SelectedRtf);}
        private void men�Birim5b6_T�kland� (object k, EventArgs o) {
            if (Clipboard.GetDataObject().GetDataPresent (DataFormats.Text) == true) {
                if (zenginMetinKutu.CanUndo == true) {
                    if (zenginMetinKutu.SelectionLength > 0) {
                        if (MessageBox.Show ("Mevcut se�ilen metnin �zerine yazmak istiyor musun?",  "Kes & Yap��t�r", MessageBoxButtons.YesNo) == DialogResult.No) zenginMetinKutu.SelectionStart = zenginMetinKutu.SelectionStart + zenginMetinKutu.SelectionLength;
                    }
                    zenginMetinKutu.Paste();
                }
            }
        }
        private void men�Birim5b7_T�kland� (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) zenginMetinKutu.SelectedText = "";}
        private void men�Birim5b9_T�kland� (object k, EventArgs o) {zenginMetinKutu.SelectAll();}
        private void men�Birim5b10_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.Text.Length >= 5) {zenginMetinKutu.Select (0,5);
            }else {zenginMetinKutu.Select (0,zenginMetinKutu.Text.Length);}
        }
        private void men�Birim5b11_T�kland� (object k, EventArgs o) {zenginMetinKutu.Clear();}
        private void men�Birim5c1_T�kland� (object k, EventArgs o) {zenginMetinKutu.ScrollToCaret();}
        private void men�Birim5d1_T�kland� (object k, EventArgs o) {zenginMetinKutu.SelectionBullet = !zenginMetinKutu.SelectionBullet;}
        private void men�Birim5d2a_T�kland� (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Left;}
        private void men�Birim5d2b_T�kland� (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Right;}
        private void men�Birim5d2c_T�kland� (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Center;}
        private void men�Birim5d3_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionColor == Color.Red) zenginMetinKutu.SelectionColor = Color.Black;
            else zenginMetinKutu.SelectionColor = Color.Red;
        }
        private void men�Birim5d4_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionFont.Bold) zenginMetinKutu.SelectionFont = new Font (zenginMetinKutu.SelectionFont, FontStyle.Regular);
            else zenginMetinKutu.SelectionFont = new Font (zenginMetinKutu.SelectionFont, FontStyle.Bold);
        }
        private void men�Birim5d5_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionHangingIndent == 10) zenginMetinKutu.SelectionHangingIndent = 0;
            else zenginMetinKutu.SelectionHangingIndent = 10;
        }
        private void men�Birim5d6_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionIndent == 10) zenginMetinKutu.SelectionIndent = 0;
            else zenginMetinKutu.SelectionIndent = 10;
        }
        private void men�Birim5d7_T�kland� (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionRightIndent == 50) zenginMetinKutu.SelectionRightIndent = 0;
            else zenginMetinKutu.SelectionRightIndent = 50;
        }
    }
//---------------------- Form6 ----------------------------------
    public class Form6: Form {
        private MenuStrip men��eridi;
        private ToolStripMenuItem men�Birimi6a;
        private ToolStripMenuItem men�Birimi6a1;
        private ToolStripMenuItem men�Birimi6a2;
        private ToolStripSeparator ayra�6a1;
        private ToolStripMenuItem men�Birimi6a3;
        private ToolStripMenuItem men�Birimi6a4;
        private ToolStripSeparator ayra�6a2;
        private ToolStripMenuItem men�Birimi6a5;
        private ToolStripMenuItem men�Birimi6a6;
        private ToolStripSeparator ayra�6a3;
        private ToolStripMenuItem men�Birimi6a7;
        private ToolStripMenuItem men�Birimi6b;
        private ToolStripMenuItem men�Birimi6b1;
        private ToolStripMenuItem men�Birimi6b2;
        private ToolStripMenuItem men�Birimi6b3;
        private ToolStripMenuItem men�Birimi6c;
        private ToolStripMenuItem men�Birimi6c1;
        private ToolStripMenuItem men�Birimi6c2;
        private ToolStripMenuItem men�Birimi6c3;
        private ToolStripSeparator ayra�6c1;
        private ToolStripMenuItem men�Birimi6c4;
        private ToolStrip ara��eridi;
        private ToolStripButton ara��eritD��mesi6a1;
        private ToolStripButton ara��eritD��mesi6a2;
        private ToolStripButton ara��eritD��mesi6a3;
        private ToolStripButton ara��eritD��mesi6a4;
        private ToolStripSeparator ara��eritAyra�1;
        private ToolStripButton ara��eritD��mesi6b1;
        private ToolStripButton ara��eritD��mesi6b2;
        private ToolStripButton ara��eritD��mesi6b3;
        private ToolStripSeparator ara��eritAyra�2;
        private ToolStripComboBox ara��eritTarakl�Kutu;
        private ToolStripSeparator ara��eritAyra�3;
        private ToolStripButton ara��eritD��mesi6c;
        private RichTextBox zenginMetinKutusu;
        private StatusStrip durum�eridi;
        private ToolStripStatusLabel ara��eritDurumFi�i6a;
        private ToolStripStatusLabel ara��eritDurumFi�i6b;
        private ToolStripStatusLabel ara��eritDurumFi�i6c;
        private ToolStripStatusLabel ara��eritDurumFi�i6d;
        public Form6() {//Kurucu
            Bile�eniBa�lat();
            ara��eritTarakl�Kutu.SelectedIndex = 0;
        }
        private void Bile�eniBa�lat() {
            men��eridi = new MenuStrip();
            men�Birimi6a = new ToolStripMenuItem();
            men�Birimi6a1 = new ToolStripMenuItem();
            men�Birimi6a2 = new ToolStripMenuItem();
            ayra�6a1 = new ToolStripSeparator();
            men�Birimi6a3 = new ToolStripMenuItem();
            men�Birimi6a4 = new ToolStripMenuItem();
            ayra�6a2 = new ToolStripSeparator();
            men�Birimi6a5 = new ToolStripMenuItem();
            men�Birimi6a6 = new ToolStripMenuItem();
            ayra�6a3 = new ToolStripSeparator();
            men�Birimi6a7 = new ToolStripMenuItem();
            men�Birimi6b = new ToolStripMenuItem();
            men�Birimi6b1 = new ToolStripMenuItem();
            men�Birimi6b2 = new ToolStripMenuItem();
            men�Birimi6b3 = new ToolStripMenuItem();
            men�Birimi6c = new ToolStripMenuItem();
            men�Birimi6c1 = new ToolStripMenuItem();
            men�Birimi6c2 = new ToolStripMenuItem();
            men�Birimi6c3 = new ToolStripMenuItem();
            ayra�6c1 = new ToolStripSeparator();
            men�Birimi6c4 = new ToolStripMenuItem();
            ara��eridi = new ToolStrip();
            ara��eritD��mesi6a1 = new ToolStripButton();
            ara��eritD��mesi6a2 = new ToolStripButton();
            ara��eritD��mesi6a3 = new ToolStripButton();
            ara��eritD��mesi6a4 = new ToolStripButton();
            ara��eritAyra�1 = new ToolStripSeparator();
            ara��eritD��mesi6b1 = new ToolStripButton();
            ara��eritD��mesi6b2 = new ToolStripButton();
            ara��eritD��mesi6b3 = new ToolStripButton();
            ara��eritAyra�2 = new ToolStripSeparator();
            ara��eritTarakl�Kutu = new ToolStripComboBox();
            ara��eritAyra�3 = new ToolStripSeparator();
            ara��eritD��mesi6c = new ToolStripButton();
            zenginMetinKutusu = new RichTextBox();
            durum�eridi = new StatusStrip();
            ara��eritDurumFi�i6a = new ToolStripStatusLabel();
            ara��eritDurumFi�i6b = new ToolStripStatusLabel();
            ara��eritDurumFi�i6c = new ToolStripStatusLabel();
            ara��eritDurumFi�i6d = new ToolStripStatusLabel();
            men��eridi.SuspendLayout();
            ara��eridi.SuspendLayout();
            durum�eridi.SuspendLayout();
            SuspendLayout();
            //men��eridi
            men��eridi.Items.AddRange (new ToolStripItem[] {men�Birimi6a, men�Birimi6b, men�Birimi6c});
            men��eridi.Location = new Point (0, 0);
            men��eridi.Size = new Size (454, 24);
            men��eridi.TabIndex = 1;
            men��eridi.Text = "men��eridi";
            //men�Birimi6a
            men�Birimi6a.DropDownItems.AddRange (new ToolStripItem[] {men�Birimi6a1, men�Birimi6a2, ayra�6a1, men�Birimi6a3, men�Birimi6a4,
                ayra�6a2, men�Birimi6a5, men�Birimi6a6, ayra�6a3, men�Birimi6a7});
            men�Birimi6a.Name = "men�Birimi6a";
            men�Birimi6a.Size = new Size (37, 20);
            men�Birimi6a.Text = "&Dosya"; //Alt-d
            //men�Birimi6a1
            men�Birimi6a1.Name = "men�Birimi6a1";
            men�Birimi6a1.ShortcutKeys = ((Keys)((Keys.Control | Keys.Y)));
            men�Birimi6a1.Size = new Size (146, 22);
            men�Birimi6a1.Text = "&Yeni";
            men�Birimi6a1.Click += new EventHandler (men�Birimi6a1_T�kland�);
            //men�Birimi6a2
            men�Birimi6a2.Name = "men�Birimi6a2";
            men�Birimi6a2.ShortcutKeys = ((Keys)((Keys.Control | Keys.A)));
            men�Birimi6a2.Size = new Size (146, 22);
            men�Birimi6a2.Text = "&A�";
            men�Birimi6a2.Click += new EventHandler (men�Birimi6a2_T�kland�);
            //ayra�6a1
            ayra�6a1.Name = "ayra�6a1";
            ayra�6a1.Size = new Size (143, 6);
            //men�Birimi6a3
            men�Birimi6a3.Name = "men�Birimi6a3";
            men�Birimi6a3.ShortcutKeys = ((Keys)((Keys.Control | Keys.K)));
            men�Birimi6a3.Size = new Size (146, 22);
            men�Birimi6a3.Text = "&Kaydet";
            men�Birimi6a3.Click += new EventHandler (men�Birimi6a3_T�kland�);
            //men�Birimi6a4
            men�Birimi6a4.Name = "men�Birimi6a4";
            men�Birimi6a4.Size = new Size (146, 22);
            men�Birimi6a4.Text = "&Farkl� Kaydet";
            //ayra�6a1
            ayra�6a2.Name = "ayra�6a2";
            ayra�6a2.Size = new Size (143, 6);
            //men�Birimi6a5
            men�Birimi6a5.Name = "men�Birimi6a5";
            men�Birimi6a5.ShortcutKeys = ((Keys)((Keys.Control | Keys.Z)));
            men�Birimi6a5.Size = new Size (146, 22);
            men�Birimi6a5.Text = "Ya&z";
            //men�Birimi6a5
            men�Birimi6a6.Name = "men�Birimi6a6";
            men�Birimi6a6.Size = new Size (146, 22);
            men�Birimi6a6.Text = "Yaz�lan� G�r";
            //ayra�6a1
            ayra�6a3.Name = "ayra�6a3";
            ayra�6a3.Size = new Size (143, 6);
            //men�Birimi6a7
            men�Birimi6a7.Name = "men�Birimi6a7";
            men�Birimi6a7.Size = new Size (146, 22);
            men�Birimi6a7.Text = "&��k";
            //men�Birimi6b
            men�Birimi6b.DropDownItems.AddRange (new ToolStripItem[] {men�Birimi6b1, men�Birimi6b2, men�Birimi6b3});
            men�Birimi6b.Name = "men�Birimi6b";
            men�Birimi6b.Size = new Size (57, 20);
            men�Birimi6b.Text = "&Bi�im";
            //men�Birimi6b1
            men�Birimi6b1.CheckOnClick = true;
            men�Birimi6b1.Name = "men�Birimi6b1";
            men�Birimi6b1.Size = new Size (125, 22);
            men�Birimi6b1.Text = "&Koyu";
            men�Birimi6b1.CheckedChanged += new EventHandler (men�Birimi6b1_�entikDe�i�ti);
            //men�Birimi6b2
            men�Birimi6b2.CheckOnClick = true;
            men�Birimi6b2.Name = "men�Birimi6b2";
            men�Birimi6b2.Size = new Size (125, 22);
            men�Birimi6b2.Text = "&Yat�k";
            men�Birimi6b2.CheckedChanged += new EventHandler (men�Birimi6b2_�entikDe�i�ti);
            //men�Birimi6b3
            men�Birimi6b3.CheckOnClick = true;
            men�Birimi6b3.Name = "men�Birimi6b3";
            men�Birimi6b3.Size = new Size (125, 22);
            men�Birimi6b3.Text = "&Alt�izgi";
            men�Birimi6b3.CheckedChanged += new EventHandler (men�Birimi6b3_�entikDe�i�ti);
            //men�Birimi6c
            men�Birimi6c.DropDownItems.AddRange (new ToolStripItem[] {men�Birimi6c1, men�Birimi6c2, men�Birimi6c3, ayra�6c1, men�Birimi6c4});
            men�Birimi6c.Name = "men�Birimi6c";
            men�Birimi6c.Size = new Size (44, 20);
            men�Birimi6c.Text = "Yard�&m";
            //men�Birimi6c1
            men�Birimi6c1.Name = "men�Birimi6c1";
            men�Birimi6c1.Size = new Size (122, 22);
            men�Birimi6c1.Text = "��erik";
            //men�Birimi6c2
            men�Birimi6c2.Name = "men�Birimi6c2";
            men�Birimi6c2.Size = new Size (122, 22);
            men�Birimi6c2.Text = "Dizin";
            //men�Birimi6c3
            men�Birimi6c3.Name = "men�Birimi6c3";
            men�Birimi6c3.Size = new Size (122, 22);
            men�Birimi6c3.Text = "Ara�t�r";
            //ayra�6c1
            ayra�6c1.Name = "ayra�6c1";
            ayra�6c1.Size = new Size (119, 6);
            //men�Birimi6c4
            men�Birimi6c4.Name = "men�Birimi6c4";
            men�Birimi6c4.Size = new Size (122, 22);
            men�Birimi6c4.Text = "Hakk�nda";
            // ara��eridi
            ara��eridi.Items.AddRange (new ToolStripItem[] {ara��eritD��mesi6a1, ara��eritD��mesi6a2, ara��eritD��mesi6a3, ara��eritD��mesi6a4, ara��eritAyra�1,
                ara��eritD��mesi6b1, ara��eritD��mesi6b2, ara��eritD��mesi6b3, ara��eritAyra�2, ara��eritTarakl�Kutu, ara��eritAyra�3, ara��eritD��mesi6c});
            ara��eridi.Location = new Point (0, 24);
            ara��eridi.Name = "ara��eridi";
            ara��eridi.Size = new Size (454, 25);
            ara��eridi.TabIndex = 2;
            ara��eridi.Text = "ara��eridi";
            // ara��eritD��mesi6a1
            ara��eritD��mesi6a1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6a1.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6a1.Name = "ara��eritD��mesi6a1";
            ara��eritD��mesi6a1.Size = new Size (23, 22);
            ara��eritD��mesi6a1.Text = "&Yeni";
            ara��eritD��mesi6a1.Click += new EventHandler (men�Birimi6a1_T�kland�);
            // ara��eritD��mesi6a2
            ara��eritD��mesi6a2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6a2.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6a2.Name = "ara��eritD��mesi6a2";
            ara��eritD��mesi6a2.Size = new Size (23, 22);
            ara��eritD��mesi6a2.Text = "&A�";
            ara��eritD��mesi6a2.Click += new EventHandler (men�Birimi6a2_T�kland�);
            // ara��eritD��mesi6a3
            ara��eritD��mesi6a3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6a3.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6a3.Name = "ara��eritD��mesi6a3";
            ara��eritD��mesi6a3.Size = new Size (23, 22);
            ara��eritD��mesi6a3.Text = "&Kaydet";
            ara��eritD��mesi6a3.Click += new EventHandler (men�Birimi6a3_T�kland�);
            // ara��eritD��mesi6a4
            ara��eritD��mesi6a4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6a4.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6a4.Name = "ara��eritD��mesi6a4";
            ara��eritD��mesi6a4.Size = new Size (23, 22);
            ara��eritD��mesi6a4.Text = "Ya&z";
            // ara��eritAyra�1
            ara��eritAyra�1.Name = "ara��eritAyra�1";
            ara��eritAyra�1.Size = new Size (6, 25);
            // ara��eritD��mesi6b1
            ara��eritD��mesi6b1.CheckOnClick = true;
            ara��eritD��mesi6b1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6b1.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6b1.Name = "ara��eritD��mesi6b1";
            ara��eritD��mesi6b1.Size = new Size (23, 22);
            ara��eritD��mesi6b1.Text = "D��me1";
            ara��eritD��mesi6b1.CheckedChanged += new EventHandler (ara��eritD��mesi6b1_�entikDe�i�ti);
            // ara��eritD��mesi6b2
            ara��eritD��mesi6b2.CheckOnClick = true;
            ara��eritD��mesi6b2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6b2.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6b2.Name = "ara��eritD��mesi6b2";
            ara��eritD��mesi6b2.Size = new Size (23, 22);
            ara��eritD��mesi6b2.Text = "D��me2";
            ara��eritD��mesi6b2.CheckedChanged += new EventHandler (ara��eritD��mesi6b2_�entikDe�i�ti);
            // ara��eritD��mesi6b3
            ara��eritD��mesi6b3.CheckOnClick = true;
            ara��eritD��mesi6b3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6b3.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6b3.Name = "ara��eritD��mesi6b3";
            ara��eritD��mesi6b3.Size = new Size (23, 22);
            ara��eritD��mesi6b3.Text = "D��me3";
            ara��eritD��mesi6b3.CheckedChanged += new EventHandler (ara��eritD��mesi6b3_�entikDe�i�ti);
            // ara��eritAyra�2
            ara��eritAyra�2.Name = "ara��eritAyra�2";
            ara��eritAyra�2.Size = new Size (6, 25);
            // ara��eritTarakl�Kutu
            ara��eritTarakl�Kutu.DropDownStyle = ComboBoxStyle.DropDownList;
            ara��eritTarakl�Kutu.Items.AddRange (new object[] {"MS Sans Serif", "Times New Roman", "Verdana", "Segoe Script"});
            ara��eritTarakl�Kutu.Name = "ara��eritTarakl�Kutu";
            ara��eritTarakl�Kutu.Size = new Size (121, 25);
            ara��eritTarakl�Kutu.SelectedIndexChanged += new EventHandler (ara��eritTarakl�Kutu_EndeksDe�i�ti);
            // ara��eritAyra�3
            ara��eritAyra�3.Name = "ara��eritAyra�3";
            ara��eritAyra�3.Size = new Size (6, 25);
            // ara��eritD��mesi6c
            ara��eritD��mesi6c.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ara��eritD��mesi6c.ImageTransparentColor = Color.Magenta;
            ara��eritD��mesi6c.Name = "ara��eritD��mesi6c";
            ara��eritD��mesi6c.Size = new Size (23, 22);
            ara��eritD��mesi6c.Text = "Yard�&m";
            ara��eritD��mesi6c.CheckedChanged += new EventHandler (ara��eritD��mesi6c_�entikDe�i�ti);
            //zenginMetinKutusu
            zenginMetinKutusu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            zenginMetinKutusu.Location = new Point (0, 52);
            zenginMetinKutusu.Name = "zenginMetinKutusu";
            zenginMetinKutusu.Size = new Size (454, 212);
            zenginMetinKutusu.TabIndex = 0;
            zenginMetinKutusu.Text = "";
            zenginMetinKutusu.BackColor=Color.Khaki;
            zenginMetinKutusu.ForeColor=Color.Navy;
            zenginMetinKutusu.TextChanged += new EventHandler (zenginMetinKutusu_MetinDe�i�ti);
            // durum�eridi
            durum�eridi.Items.AddRange (new ToolStripItem[] {ara��eritDurumFi�i6a, ara��eritDurumFi�i6b, ara��eritDurumFi�i6c, ara��eritDurumFi�i6d});
            durum�eridi.Location = new Point (0, 242);
            durum�eridi.Name = "durum�eridi";
            durum�eridi.Size = new Size (454, 22);
            durum�eridi.TabIndex = 3;
            durum�eridi.Text = "durum�eridi";
            // ara��eritDurumFi�i6a
            ara��eritDurumFi�i6a.AutoSize = false;
            ara��eritDurumFi�i6a.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ara��eritDurumFi�i6a.Font = new Font ("Arial", 8.25F, FontStyle.Bold);
            ara��eritDurumFi�i6a.Name = "ara��eritDurumFi�i6a";
            ara��eritDurumFi�i6a.Size = new Size (259, 17);
            ara��eritDurumFi�i6a.TextAlign = ContentAlignment.MiddleLeft;
            // ara��eritDurumFi�i6b
            ara��eritDurumFi�i6b.AutoSize = false;
            ara��eritDurumFi�i6b.DoubleClickEnabled = true;
            ara��eritDurumFi�i6b.Enabled = false;
            ara��eritDurumFi�i6b.Font = new Font ("Arial", 8.25F);
            ara��eritDurumFi�i6b.Name = "ara��eritDurumFi�i6b";
            ara��eritDurumFi�i6b.Size = new Size (47, 17);
            ara��eritDurumFi�i6b.Text = "Koyu";
            ara��eritDurumFi�i6b.Click += new EventHandler (ara��eritDurumFi�i6b_T�kland�);
            // ara��eritDurumFi�i6c
            ara��eritDurumFi�i6c.AutoSize = false;
            ara��eritDurumFi�i6c.DoubleClickEnabled = true;
            ara��eritDurumFi�i6c.Enabled = false;
            ara��eritDurumFi�i6c.Font = new Font ("Arial", 8.25F);
            ara��eritDurumFi�i6c.Name = "ara��eritDurumFi�i6c";
            ara��eritDurumFi�i6c.Size = new Size (48, 17);
            ara��eritDurumFi�i6c.Text = "Yat�k";
            ara��eritDurumFi�i6c.Click += new EventHandler (ara��eritDurumFi�i6c_T�kland�);
            // ara��eritDurumFi�i6d
            ara��eritDurumFi�i6d.AutoSize = false;
            ara��eritDurumFi�i6d.DoubleClickEnabled = true;
            ara��eritDurumFi�i6d.Enabled = false;
            ara��eritDurumFi�i6d.Font = new Font ("Arial", 8.25F);
            ara��eritDurumFi�i6d.Name = "ara��eritDurumFi�i6d";
            ara��eritDurumFi�i6d.Size = new Size (76, 17);
            ara��eritDurumFi�i6d.Text = "Alt�izgi";
            ara��eritDurumFi�i6d.Click += new EventHandler (ara��eritDurumFi�i6d_T�kland�);
            // Form6
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (454, 264);
            Controls.Add (durum�eridi); //Add s�ras� de�i�irse bozuyor: men��eridi, ara��eridi, zenginMetinKutusu, durum�eridi
            Controls.Add (ara��eridi);
            Controls.Add (zenginMetinKutusu);
            Controls.Add (men��eridi);
            Text="Form6: RTF, Men�, Ara��ubu�u, Durum�ubu�u";
            MainMenuStrip = men��eridi;
            men��eridi.ResumeLayout (false);
            men��eridi.PerformLayout();
            ara��eridi.ResumeLayout (false);
            ara��eridi.PerformLayout();
            durum�eridi.ResumeLayout (false);
            durum�eridi.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void men�Birimi6a1_T�kland� (object k, EventArgs o) {zenginMetinKutusu.Text = "\n\n\nM.Nihat Yava�, Toroslar-Mersin\r\n22.05.2025 02:54";}
        private void men�Birimi6a2_T�kland� (object k, EventArgs o) {zenginMetinKutusu.LoadFile ("j2sc#2302f.rtf");}
        private void men�Birimi6a3_T�kland� (object k, EventArgs o) {zenginMetinKutusu.SaveFile ("mny1.rtf");}
        private void men�Birimi6b1_�entikDe�i�ti (object k, EventArgs o) {ara��eritD��mesi6b1.Checked = men�Birimi6b1.Checked;}
        private void men�Birimi6b2_�entikDe�i�ti (object k, EventArgs o) {ara��eritD��mesi6b2.Checked = men�Birimi6b2.Checked;}
        private void men�Birimi6b3_�entikDe�i�ti (object k, EventArgs o) {ara��eritD��mesi6b3.Checked = men�Birimi6b3.Checked;}
        private void ara��eritD��mesi6b1_�entikDe�i�ti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool �entikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!�entikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Bold);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Bold);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            men�Birimi6b1.CheckedChanged -= new EventHandler (men�Birimi6b1_�entikDe�i�ti);
            men�Birimi6b1.Checked = �entikliMi;
            men�Birimi6b1.CheckedChanged += new EventHandler (men�Birimi6b1_�entikDe�i�ti);
            if (!�entikliMi) ara��eritDurumFi�i6b.Font = new Font (ara��eritDurumFi�i6b.Font, ara��eritDurumFi�i6b.Font.Style & ~FontStyle.Bold);
            else ara��eritDurumFi�i6b.Font = new Font (ara��eritDurumFi�i6b.Font, ara��eritDurumFi�i6b.Font.Style | FontStyle.Bold);
        }
        private void ara��eritD��mesi6b2_�entikDe�i�ti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool �entikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!�entikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Italic);
            else yeniFon = new Font(eskiFon, eskiFon.Style | FontStyle.Italic);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            men�Birimi6b2.CheckedChanged -= new EventHandler (men�Birimi6b2_�entikDe�i�ti);
            men�Birimi6b2.Checked = �entikliMi;
            men�Birimi6b2.CheckedChanged += new EventHandler (men�Birimi6b2_�entikDe�i�ti);
            if (!�entikliMi) ara��eritDurumFi�i6c.Font = new Font (ara��eritDurumFi�i6c.Font, ara��eritDurumFi�i6c.Font.Style & ~FontStyle.Italic);
            else ara��eritDurumFi�i6c.Font = new Font (ara��eritDurumFi�i6c.Font, ara��eritDurumFi�i6c.Font.Style | FontStyle.Italic);
        }
        private void ara��eritD��mesi6b3_�entikDe�i�ti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool �entikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!�entikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Underline);
            else yeniFon = new Font(eskiFon, eskiFon.Style | FontStyle.Underline);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            men�Birimi6b3.CheckedChanged -= new EventHandler (men�Birimi6b3_�entikDe�i�ti);
            men�Birimi6b3.Checked = �entikliMi;
            men�Birimi6b3.CheckedChanged += new EventHandler (men�Birimi6b3_�entikDe�i�ti);
            ara��eritDurumFi�i6d.Enabled = �entikliMi;
            if (!�entikliMi) ara��eritDurumFi�i6d.Font = new Font (ara��eritDurumFi�i6d.Font, ara��eritDurumFi�i6d.Font.Style & ~FontStyle.Underline);
            else ara��eritDurumFi�i6d.Font = new Font (ara��eritDurumFi�i6d.Font, ara��eritDurumFi�i6d.Font.Style | FontStyle.Underline);
        }
        private void ara��eritD��mesi6c_�entikDe�i�ti (object k, EventArgs o) {
            ToolStripMenuItem birim = (ToolStripMenuItem)k;
            men�Birimi6c.Visible = birim.Checked;
        }
        private void ara��eritTarakl�Kutu_EndeksDe�i�ti (object k, EventArgs o) {
            string metin = ((ToolStripComboBox)k).SelectedItem.ToString();
            Font yeniFon = null;
            if (zenginMetinKutusu.SelectionFont == null) yeniFon = new Font (metin, zenginMetinKutusu.Font.Size);
            else yeniFon = new Font (metin, zenginMetinKutusu.SelectionFont.Size, zenginMetinKutusu.SelectionFont.Style);
            zenginMetinKutusu.SelectionFont = yeniFon;
        }
        private void zenginMetinKutusu_MetinDe�i�ti (object k, EventArgs o) {ara��eritDurumFi�i6a.Text = "Toplam krk say�s�: " + zenginMetinKutusu.Text.Length;}
        private void ara��eritDurumFi�i6b_T�kland� (object k, EventArgs o) {ara��eritD��mesi6b1.Checked = !men�Birimi6b1.Checked;}
        private void ara��eritDurumFi�i6c_T�kland� (object k, EventArgs o) {ara��eritD��mesi6b2.Checked = !men�Birimi6b2.Checked;}
        private void ara��eritDurumFi�i6d_T�kland� (object k, EventArgs o) {ara��eritD��mesi6b3.Checked = !men�Birimi6b3.Checked;}
    }
//---------------------- Form7 ----------------------------------
    class Form7: Form {
        Panel panel;
        StatusBar durum�ubu�u;
        Label fi�;
        public Form7() {//Kurucu
            //panel
            panel = new Panel();
            panel.Parent = this;
            panel.BackColor = Color.Olive;
            panel.ForeColor = Color.Orange;
            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Font = new Font ("Verdana", 19F);
            //durum�ubu�u
            durum�ubu�u = new StatusBar();
            durum�ubu�u.Parent = this;
            durum�ubu�u.Text = "Durum �ubu�u: M.Nihat Yava�";
            //fi�
            fi� = new Label();
            fi�.Parent = panel;
            fi�.Text = "Sol-�st";
            fi�.Location = new Point (0, 0);
            fi�.AutoSize = true;
            fi� = new Label();
            fi�.Parent = panel;
            fi�.Text = "Sa�-Alt";
            fi�.Location = new Point (250, 250);
            fi�.AutoSize = true;
            //Form7
            Text="Form7: Panelli Form ve Stat��ubu�u";
        }
    }
//---------------------- Form8 ----------------------------------
    public class Form8: Form {
        private StatusBar durum�ubu�u = new StatusBar();
        private StatusBarPanel durum�ubukPaneliA = new StatusBarPanel();
        private StatusBarPanel durum�ubukPaneliB = new StatusBarPanel();
        private Timer zamanlay�c� = new Timer();
        private MainMenu anaMen�;
        public Form8() {//Kurucu
            Bile�eniBa�lat();
            zamanlay�c�.Interval = 1000; //1000mS=1S
            zamanlay�c�.Enabled = true;
            zamanlay�c�.Tick += new EventHandler (zamanlay�c�_Tikledi);
            MenuComplete += new EventHandler (Durum�ubu�u_Haz�r);
            Anamen�y�Kur();
            Durum�ubu�unuKur();
        }
        private void Bile�eniBa�lat() {
            Size = new Size (300, 300);
            Text = "Form8: Anamen� ve Durum�ubu�u";
            BackColor = Color.Tan;
        }
        private void zamanlay�c�_Tikledi (object k, EventArgs o) {
            DateTime tarih = DateTime.Now;
            string zaman = tarih.ToLongTimeString();
            durum�ubukPaneliB.Text = zaman;    
        }
        private void Durum�ubu�u_Haz�r (object k, EventArgs o) {durum�ubukPaneliA.Text = "Haz�r";}
        private void Anamen�y�Kur() {
            anaMen� = new MainMenu();
            MenuItem men�BirimiA = anaMen�.MenuItems.Add ("&Dosya");
            men�BirimiA.MenuItems.Add (new MenuItem ("��&k", new EventHandler (��k_T�kland�), Shortcut.CtrlK)); //�nce Add, sonra [0] se�...
            men�BirimiA.MenuItems [0].Select += new EventHandler (��k_Se�ildi);
            MenuItem men�BirimiB = anaMen�.MenuItems.Add ("&Yardm");
            men�BirimiB.MenuItems.Add (new MenuItem ("&Hakk�nda", new EventHandler (Hakk�nda_T�kland�),Shortcut.CtrlH)); //�nce Add, sonra [0] se�...
            men�BirimiB.MenuItems [0].Select += new EventHandler (Hakk�nda_Se�ildi);
            Menu = anaMen�;      
        }
        private void ��k_Se�ildi (object k, EventArgs o) {durum�ubukPaneliA.Text = "Bu uygulamay� kapat�r";}
        private void ��k_T�kland�(object k, EventArgs o) {Close();}
        private void Hakk�nda_Se�ildi (object k, EventArgs o) {durum�ubukPaneliA.Text = "Uygulama a��klamas�n� g�sterir";}
        private void Hakk�nda_T�kland� (object k, EventArgs o) {durum�ubukPaneliA.Text = "Yard�m";}
        private void Durum�ubu�unuKur() {
            durum�ubu�u.ShowPanels = true;
            durum�ubu�u.Panels.AddRange (new StatusBarPanel[] {durum�ubukPaneliA, durum�ubukPaneliB});
            durum�ubukPaneliA.BorderStyle = StatusBarPanelBorderStyle.None;
            durum�ubukPaneliA.AutoSize = StatusBarPanelAutoSize.Spring;
            durum�ubukPaneliA.Width = 62;
            durum�ubukPaneliA.Text = "Haz�r";
            Icon ikon = new Icon ("resim/favikon.ico"); //Sadece ".ico" kabul edilmekte
            durum�ubukPaneliA.Icon = ikon;
            durum�ubukPaneliB.Alignment = HorizontalAlignment.Right;
            durum�ubukPaneliB.Width = 76;
            Controls.Add (durum�ubu�u);  
        }
    }
//---------------------- Form9 ----------------------------------
    class Form9: Form {
        StatusBarPanel durum�ubukPaneliA, durum�ubukPaneliB, durum�ubukPaneliC;
        public Form9() {//Kurucu
            Size = new Size (300, 300);
            Text = "Form9: Yard�m, Tarih ve Saat";
            BackColor = Color.Thistle;
            //durum�ubukPaneliA
            durum�ubukPaneliA = new StatusBarPanel();
            durum�ubukPaneliA.Text = "Yard�m men�s�ne tahsisen...";
            durum�ubukPaneliA.BorderStyle = StatusBarPanelBorderStyle.None;
            durum�ubukPaneliA.AutoSize = StatusBarPanelAutoSize.Spring;
            //durum�ubukPaneliB
            durum�ubukPaneliB = new StatusBarPanel();
            durum�ubukPaneliB.AutoSize = StatusBarPanelAutoSize.Contents;
            durum�ubukPaneliB.ToolTipText = "G�ncel tarih";
            //durum�ubukPaneliC
            durum�ubukPaneliC = new StatusBarPanel();
            durum�ubukPaneliC.AutoSize = StatusBarPanelAutoSize.Contents;
            durum�ubukPaneliC.ToolTipText = "G�ncel zaman";
            //durum�ubuk
            StatusBar durum�ubuk = new StatusBar();
            durum�ubuk.Parent = this;
            durum�ubuk.ShowPanels = true;
            durum�ubuk.Panels.AddRange (new StatusBarPanel[] {durum�ubukPaneliA, durum�ubukPaneliB, durum�ubukPaneliC});
            //zamanlay�c�
            Timer zamanlay�c� = new Timer();
            zamanlay�c�.Tick += new EventHandler (TikliZaman);
            zamanlay�c�.Interval = 1000; //1000mS=1S
            zamanlay�c�.Start();
        }
        void TikliZaman (object k, EventArgs o) {
            DateTime tarih = DateTime.Now;
            durum�ubukPaneliB.Text = tarih.ToShortDateString();
            durum�ubukPaneliC.Text = tarih.ToLongTimeString();
        }
    }
//==================================================================
    class Masked_RichTextBox_StatusBar {
        [STAThread]
        static void Main() {
            Console.Write ("Anamen�de se�imi girip, d��meye t�klatarak tamsay� ��z�mleme yap�p, se�ilen forma ge�i� i�in anamen� sa��st X d��meyle kapat�lmal�d�r.\nMaskelimetinkutusu �ncelikle atanana kal�ba uygun verigiri�ini zorlar; �rn.zaman i�in: 00:00:00, abd-pk i�in: 00000-9999, usd$ i�in: $00.00, ing-pk i�in: LCCC 9LL, tarih i�in: 00/00/0000, pin-kod i�in: 000-000-000 vb.\nRTF Controls.Add i�in: 'men�, ara��ubu�u, zenginmetin, durum�ubu�u' s�ralamas� bozuyor.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Application.EnableVisualStyles();
       ba�: AnaMen� anamen�=new AnaMen�(); Application.Run (anamen�);
            switch (anamen�.se�) {
                case 1: Application.Run (new Form1()); break; //Verili metin dosyay� basit edit�rle d�zenler, kaydeder, yazd�r�r
                case 2: Application.Run (new Form2()); break; //MaskeliMetinKutuya d��me t�klamal� �e�itli verigiri�leri
                case 3: Application.Run (new Form3()); break; //RichTextBox .rtf/RichTextFormat dosyalar yaratma, a�ma, kaydetme. Kontrol i�in ilk a��l�� Kaydet (mny1.rtf), Yeni-->Kaydet (mny1.rtf), A�-->Kaydet (mny1.rtf)
                case 4: Application.Run (new Form4()); break; //ZenginMetinKutu'ya dosya y�kle-kaydet, stille (koyu, alt�izgi, yat�k, ortala, ebatla)
                case 5: Application.Run (new Form5()); break; //RTF ithalet, d�zenle, bi�imle, imlece kayd�r
                case 6: Application.Run (new Form6()); break; //RTF, men�, ara��ubu�u ve durum�ubu�u
                case 7: Application.Run (new Form7()); break; //Panel, kayd�rma�ubuklar� ve durum�ubu�u
                case 8: Application.Run (new Form8()); break; //Anamen�: Dosya-��k, Yard�m-Hakk�nda; durum�ubu�u: ikonlu stat�ler ve zaman
                case 9: Application.Run (new Form9()); break; //Durum�ubukta yard�m, tarih ve saat bilgileri
                default: goto son;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}