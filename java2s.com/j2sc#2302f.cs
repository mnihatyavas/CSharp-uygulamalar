// j2sc#2302f.cs: Maskeli ve zengin metinkutusu ile durumçubuðu örneði.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.ComponentModel; //CancelEventHandler
using System.Drawing.Printing; //PrintPageEventArgs için
using System.IO; //File, FileInfo için
namespace Bileþenler {
    public class AnaMenü: Form {
        public int seç=0;
        private TextBox metinKutu1;
        private TextBox metinKutu2;
        private Button düðme;
        public AnaMenü() {//Kurucu
            metinKutu1 = new TextBox();
            metinKutu2 = new TextBox();
            düðme = new Button();
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
            metinKutu1.Text = "1: Editör ve dosya menüsü\r\n"+
                "2: MaskeliMetinkutu'ya veri giriþleri\r\n"+
                "3: RichTextBox .rtf editör ve dosyalar\r\n"+
                "4: ZenginMetinKutu stiller\r\n"+
                "5: RTF düzenle biçimle\r\n"+
                "6: RTF dosya biçim yardým\r\n"+
                "7: Durumçubuklu panel\r\n"+
                "8: Anamenü ve durumçubuðu\r\n"+
                "9: Menüsüz durumçubuðu\r\n"+
                "Seçiminiz [1-9] (SON=-99):";
            //metinKutu2
            metinKutu2.Location = new Point (50, 220);
            metinKutu2.Name = "metinKutu2";
            metinKutu2.Text = "";
            metinKutu2.Size = new Size (30, 22);
            metinKutu2.TabIndex = 0;
            //metinKutu2.Focus();
            metinKutu2.ForeColor=Color.Yellow;
            metinKutu2.BackColor=Color.DarkRed;
            //düðme
            düðme.Location = new Point (90, 220);
            düðme.Name = "düðme";
            düðme.Size = new Size (80, 22);
            düðme.Text = "Týkla-Kapat";
            düðme.TabIndex = 2;
            düðme.ForeColor=Color.White;
            düðme.BackColor=Color.Black;
            düðme.Click += new EventHandler (düðme_Týklandý);
            //AnaMenü
            ClientSize = new Size (290, 250);
            Controls.Add (metinKutu1);
            Controls.Add (metinKutu2);
            Controls.Add (düðme);
            Text = "Ana Menü: Bir Form Seçimi";
            BackColor=Color.DarkSlateBlue;
            CenterToScreen();
        }
        private void düðme_Týklandý (object k, EventArgs o) {
            try {seç = int.Parse (metinKutu2.Text);
                if (seç == -99) Application.Exit();
                else if (seç < 1 | seç > 9) {seç=0; MessageBox.Show ("[1, 10] arasý bir seçenek girmelisiniz.");}
            }catch (Exception hata) {MessageBox.Show ("HATA: [" + hata.Message + "]");}
            metinKutu2.Text = "";
        }
    }
//------------------ Form1 --------------------------------------
    public class Form1: Form {
        private TextBox metinKutu;
        private MenuStrip anaMenü;
        private ToolStripMenuItem dosya;
        private ToolStripMenuItem yeni;
        private ToolStripMenuItem aç;
        private ToolStripMenuItem kaydet;
        private ToolStripMenuItem farklýKaydet;
        private ToolStripSeparator ayraç1;
        private ToolStripMenuItem yaz;
        private ToolStripMenuItem yazýlanýGör;
        private ToolStripMenuItem sayfaAyarý;
        private ToolStripSeparator ayraç2;
        private ToolStripMenuItem çýk;
        private OpenFileDialog açDiyaloðu;
        private SaveFileDialog kaydetDiyaloðu;
        private PageSetupDialog ayarDiyaloðu;
        private PrintDialog yazDiyaloðu;
        private PrintPreviewDialog görDiyaloðu;
        private PrintPreviewControl görKontrolu;
        private PrintDocument belgeyiYaz;
        private string dosyaAdý = "Adsýz";
        private string[] satýrlar;
        private int yazýlanSatýrlar;
        public Form1() {//Kurucu
            BileþeniBaþlat();
            if (dosyaAdý != null) {
                dosyaAdý = "j2sc#2318.cs";
                DosyayýAç();
            }        
        }
        private void BileþeniBaþlat() {
            metinKutu = new TextBox();
            anaMenü = new MenuStrip();
            dosya = new ToolStripMenuItem();
            yeni = new ToolStripMenuItem();
            aç = new ToolStripMenuItem();
            kaydet = new ToolStripMenuItem();
            farklýKaydet = new ToolStripMenuItem();
            açDiyaloðu = new OpenFileDialog();
            kaydetDiyaloðu = new SaveFileDialog();
            ayraç1 = new ToolStripSeparator();
            yaz = new ToolStripMenuItem();
            yazýlanýGör = new ToolStripMenuItem();
            sayfaAyarý = new ToolStripMenuItem();
            ayraç2 = new ToolStripSeparator();
            çýk = new ToolStripMenuItem();
            belgeyiYaz = new PrintDocument();
            ayarDiyaloðu = new PageSetupDialog();
            yazDiyaloðu = new PrintDialog();
            görDiyaloðu = new PrintPreviewDialog();
            görKontrolu = new PrintPreviewControl();
            anaMenü.SuspendLayout();
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
            //anaMenü
            anaMenü.Items.Add (dosya);
            anaMenü.Location = new Point (0, 0);
            anaMenü.Size = new Size (546, 24);
            anaMenü.Text = "Ana Menü";
            dosya.DropDownItems.AddRange (new ToolStripItem[] {yeni, aç, kaydet, farklýKaydet, ayraç1, yaz, yazýlanýGör, sayfaAyarý, ayraç2, çýk});
            dosya.Size = new Size (38, 20);
            dosya.Text = "&Dosya"; //Alt-d
            // 
            yeni.Size = new Size (159, 22);
            yeni.Text = "&Yeni"; //Alt-y
            yeni.Click += new EventHandler (Dosya_Yeni);
            // 
            aç.Size = new Size (159, 22);
            aç.Text = "&Aç...";
            aç.Click += new EventHandler (Dosya_Aç);
            // 
            kaydet.Size = new Size (159, 22);
            kaydet.Text = "&Kaydet";
            kaydet.Click += new EventHandler (Dosya_Kaydet);
            // 
            farklýKaydet.Size = new Size (159, 22);
            farklýKaydet.Text = "&Farklý Kaydet";
            farklýKaydet.Click += new EventHandler (Dosya_FarklýKaydet);
            // açDiyaloðu
            açDiyaloðu.Filter = "Metin Belgeleri (*.txt)|*.txt|Wrox Belgeler (*.wroxtext)|*.wroxtext|Tüm Dosyalar|*.*";
            // kaydetDiyaloðu
            kaydetDiyaloðu.FileName = "Adsýz";
            kaydetDiyaloðu.Filter = "Metin Belgesi (*.txt)|*.txt|Wrox Belge (*.wroxtext)|*.wroxtext";
            kaydetDiyaloðu.FilterIndex = 2;
            ayraç1.Size = new Size (156, 6);
            // 
            yaz.Size = new Size (159, 22);
            yaz.Text = "Yaz&..."; //Alt-z
            yaz.Click += new EventHandler (Dosya_Yaz);
            // yazýlanýGör
            yazýlanýGör.Name = "yazýlanýGör";
            yazýlanýGör.Size = new Size (159, 22);
            yazýlanýGör.Text = "&Gör...";
            yazýlanýGör.Click += new EventHandler (Dosya_Gör);
            // sayfaAyarý
            sayfaAyarý.Name = "sayfaAyarý";
            sayfaAyarý.Size = new Size (159, 22);
            sayfaAyarý.Text = "Ayar&..."; //Alt-r
            sayfaAyarý.Click += new EventHandler (Dosya_Ayar);
            ayraç2.Size = new Size (156, 6);
            // çýk
            çýk.Name = "çýk";
            çýk.Size = new Size (159, 22);
            çýk.Text = "&Çýk";
            // belgeyiYaz
            belgeyiYaz.PrintPage += new PrintPageEventHandler (Yaz_Sayfa);
            belgeyiYaz.BeginPrint += new PrintEventHandler (Yaz_Baþla);
            belgeyiYaz.EndPrint += new PrintEventHandler (Yaz_Bitir);
            // ayarDiyaloðu
            ayarDiyaloðu.Document = belgeyiYaz;
            ayarDiyaloðu.ShowHelp = true;
            // yazDiyaloðu
            yazDiyaloðu.Document = belgeyiYaz;
            yazDiyaloðu.UseEXDialog = true;
            // görDiyaloðu
            görDiyaloðu.AutoScrollMargin = new Size (0, 0);
            görDiyaloðu.AutoScrollMinSize = new Size (0, 0);
            görDiyaloðu.ClientSize = new Size (400, 300);
            görDiyaloðu.Document = belgeyiYaz;
            görDiyaloðu.Enabled = true;
            görDiyaloðu.Name = "görDiyaloðu";
            görDiyaloðu.Visible = false;
            // görKontrolu
            görKontrolu.Dock = DockStyle.Fill;
            görKontrolu.Document = belgeyiYaz;
            görKontrolu.Location = new Point (0, 24);
            görKontrolu.Name = "görKontrolu";
            görKontrolu.Size = new Size (546, 203);
            görKontrolu.TabIndex = 2;
            görKontrolu.Visible = false;
            // Form1
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (546, 227);
            Controls.Add (anaMenü);
            Controls.Add (metinKutu);
            Controls.Add (görKontrolu);
            MainMenuStrip = anaMenü;
            Name = "Form1";
            Text = "Form1: Basit Ýþlevsel Editör";
            anaMenü.ResumeLayout (false);
            anaMenü.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void DosyayýAç() {
            try {
                metinKutu.Clear();
                metinKutu.Text = File.ReadAllText (dosyaAdý);
            }catch (IOException ht) {MessageBox.Show (ht.Message, "Basit Editör", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
        }
        private void Dosya_Yeni (object k, EventArgs o) {
            dosyaAdý = "Adsýz";
            FormBaþlýðý();
            metinKutu.Clear();
        }
        private void Dosya_Aç (object k, EventArgs o) {
            if (açDiyaloðu.ShowDialog() == DialogResult.OK) {
                dosyaAdý = açDiyaloðu.FileName;
                FormBaþlýðý();
                DosyayýAç();
            }
        }
        private void DosyayýKaydet() {
            try {File.WriteAllText (dosyaAdý, metinKutu.Text);
            }catch (IOException ht) {MessageBox.Show (ht.Message, "Basit Editör", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
        }
        private void Dosya_Kaydet (object k, EventArgs o) {
            if (dosyaAdý == "Adsýz") {Dosya_FarklýKaydet (k, o);
            }else {DosyayýKaydet();}
        }
        private void FormBaþlýðý() {
            FileInfo fi = new FileInfo (dosyaAdý);
            Text = fi.Name + " - Basit Editör";
        }
        private void Dosya_FarklýKaydet (object k, EventArgs o) {
            if (kaydetDiyaloðu.ShowDialog() == DialogResult.OK) {
                dosyaAdý = kaydetDiyaloðu.FileName;
                FormBaþlýðý();
                DosyayýKaydet();
            }
        }
        private void Yaz_Sayfa (object k, PrintPageEventArgs o) {
            int x = o.MarginBounds.Left;
            int y = o.MarginBounds.Top;
            while (yazýlanSatýrlar < satýrlar.Length) {
                o.Graphics.DrawString (satýrlar [yazýlanSatýrlar++], new Font("Arial", 10), Brushes.Black, x, y);
                y += 25;
                if (y >= o.MarginBounds.Bottom) {
                    o.HasMorePages = true;
                    return;
                }
            }
            yazýlanSatýrlar = 0;
            o.HasMorePages = false;
        }
        private void Dosya_Yaz (object k, EventArgs o) {
            try {
                if (metinKutu.SelectedText != "") {yazDiyaloðu.AllowSelection = true;}
                if (yazDiyaloðu.ShowDialog() == DialogResult.OK) {belgeyiYaz.Print();}
            }catch (InvalidPrinterException ht) {MessageBox.Show (ht.Message, "Basit Editör", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void Yaz_Baþla (object k, PrintEventArgs o) {
            char[] param = {'\n'};
            if (yazDiyaloðu.PrinterSettings.PrintRange == PrintRange.Selection) {satýrlar = metinKutu.SelectedText.Split (param);
            }else {satýrlar = metinKutu.Text.Split (param);}
            int i = 0;
            char[] trimParam = {'\r'};
            foreach (string s in satýrlar) {satýrlar [i++] = s.TrimEnd (trimParam);}
        }
        private void Yaz_Bitir (object k, PrintEventArgs o) {satýrlar = null;}
        private void Dosya_Ayar (object k, EventArgs o) {ayarDiyaloðu.ShowDialog();}
        private void Dosya_Gör (object k, EventArgs o) {görDiyaloðu.ShowDialog();}
    }
//---------------------- Form2 ----------------------------------
    public partial class Form2: Form {
        public Form2() {BileþeniBaþlat();} //Kurucu
        private void düðme2a_Týklandý (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00:00:00";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void düðme2b_Týklandý (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00000-9999";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void düðme2c_Týklandý (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "$00.00";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void düðme2d_Týklandý (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = ">LCCC 9LL";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void düðme2e_Týklandý(object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "00/00/0000";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
        private void düðme2f_Týklandý (object k, EventArgs o) {
            maskeliMetinKutu.UseSystemPasswordChar = false;
            maskeliMetinKutu.Mask = "000-000-000";
            maskeliMetinKutu.Text = maskeliMetinKutu.Mask;
            maskeliMetinKutu.Focus();
        }
    }
    partial class Form2 {
        private MaskedTextBox maskeliMetinKutu;
        private Label fiþ2a;
        private Label fiþ2b;
        private Button düðme2a;
        private Button düðme2b;
        private Button düðme2c;
        private Button düðme2d;
        private Button düðme2e;
        private Button düðme2f;
        private void BileþeniBaþlat() {
            maskeliMetinKutu = new MaskedTextBox();
            fiþ2a = new Label();
            fiþ2b = new Label();
            düðme2a = new Button();
            düðme2b = new Button();
            düðme2c = new Button();
            düðme2d = new Button();
            düðme2e = new Button();
            düðme2f = new Button();
            SuspendLayout();
            //fiþ2a
            fiþ2a.AutoSize = true;
            fiþ2a.Location = new Point (12, 10);
            fiþ2a.Name = "fiþ2a";
            fiþ2a.Size = new Size (94, 13);
            fiþ2a.TabIndex = 1;
            fiþ2a.Font = new Font ("Microsoft Sans Serif", 12F);
            fiþ2a.Text = "Aktif girdi maskesi:";
            //fiþ2b
            fiþ2b.AutoSize = true;
            fiþ2b.Location = new Point (150, 10);
            fiþ2b.Name = "fiþ2b";
            fiþ2b.Size = new Size (51, 13);
            fiþ2b.TabIndex = 2;
            fiþ2b.Font = new Font ("Microsoft Sans Serif", 15F);
            fiþ2b.Text = "Veri gir";
            //maskeliMetinKutu
            maskeliMetinKutu.BeepOnError = true;
            maskeliMetinKutu.Location = new Point (15, 41);
            maskeliMetinKutu.Name = "maskeliMetinKutu";
            maskeliMetinKutu.Size = new Size (265, 20);
            maskeliMetinKutu.TabIndex = 0;
            maskeliMetinKutu.BackColor=Color.Orange;
            maskeliMetinKutu.ForeColor=Color.MediumBlue;
            //düðme2a
            düðme2a.Location = new Point (15, 85);
            düðme2a.Name = "düðme2a";
            düðme2a.Size = new Size (83, 23);
            düðme2a.TabIndex = 3;
            düðme2a.Text = "24-saatlý zaman";
            düðme2a.UseVisualStyleBackColor = true;
            düðme2a.Click += new EventHandler (düðme2a_Týklandý);
            //düðme2b
            düðme2b.Location = new Point (15, 130);
            düðme2b.Name = "düðme2b";
            düðme2b.Size = new Size (83, 23);
            düðme2b.TabIndex = 4;
            düðme2b.Text = "ABD PK";
            düðme2b.UseVisualStyleBackColor = true;
            düðme2b.Click += new EventHandler (düðme2b_Týklandý);
            //düðme2c
            düðme2c.Location = new Point (104, 85);
            düðme2c.Name = "düðme2c";
            düðme2c.Size = new Size (87, 23);
            düðme2c.TabIndex = 5;
            düðme2c.Text = "Para";
            düðme2c.UseVisualStyleBackColor = true;
            düðme2c.Click += new EventHandler (düðme2c_Týklandý);
            //düðme2d
            düðme2d.Location = new Point (104, 130);
            düðme2d.Name = "düðme2d";
            düðme2d.Size = new Size (87, 23);
            düðme2d.TabIndex = 6;
            düðme2d.Text = "BK PK";
            düðme2d.UseVisualStyleBackColor = true;
            düðme2d.Click += new EventHandler (düðme2d_Týklandý);
            //düðme2e
            düðme2e.Location = new Point (197, 85);
            düðme2e.Name = "düðme2e";
            düðme2e.Size = new Size (83, 23);
            düðme2e.TabIndex = 7;
            düðme2e.Text = "Kýsa Tarih";
            düðme2e.UseVisualStyleBackColor = true;
            düðme2e.Click += new EventHandler (düðme2e_Týklandý);
            //düðme2f
            düðme2f.Location = new Point (197, 130);
            düðme2f.Name = "düðme2f";
            düðme2f.Size = new Size (83, 23);
            düðme2f.TabIndex = 8;
            düðme2f.Text = "Gizli PIN";
            düðme2f.UseVisualStyleBackColor = true;
            düðme2f.Click += new EventHandler (düðme2f_Týklandý);
            //Form2
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 196);
            Controls.AddRange (new Control[] {düðme2f, düðme2e, düðme2d, düðme2c, düðme2b, düðme2a, fiþ2b, fiþ2a, maskeliMetinKutu});
            Name = "Form2";
            Text = "Form2: MasklýMetinKutu'ya Veri Giriþleri";
            BackColor=Color.SteelBlue;
            ForeColor=Color.Red;
            ResumeLayout (false);
            PerformLayout();
        }
    }
//---------------------- Form3 ----------------------------------
    public class Form3: Form {
        private MenuStrip menüÞeridi;
        private ToolStripMenuItem menüBirimi3a;
        private ToolStripMenuItem menüBirimi3a1;
        private ToolStripMenuItem menüBirimi3a2;
        private ToolStripSeparator ayraç3a1;
        private ToolStripMenuItem menüBirimi3a3;
        private ToolStripMenuItem menüBirimi3a4;
        private ToolStripSeparator ayraç3a2;
        private ToolStripMenuItem menüBirimi3a5;
        private ToolStripMenuItem menüBirimi3a6;
        private ToolStripSeparator ayraç3a3;
        private ToolStripMenuItem menüBirimi3a7;
        private ToolStripMenuItem menüBirimi3b;
        private ToolStripMenuItem menüBirimi3b1;
        private ToolStripMenuItem menüBirimi3c;
        private ToolStripMenuItem menüBirimi3c1;
        private ToolStripMenuItem menüBirimi3c2;
        private ToolStripMenuItem menüBirimi3c3;
        private ToolStripSeparator ayraç3c1;
        private ToolStripMenuItem menüBirimi3c4;
        private RichTextBox zenginMetinKutu;
        public Form3() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            menüÞeridi = new MenuStrip();
            menüBirimi3a = new ToolStripMenuItem();
            menüBirimi3a1 = new ToolStripMenuItem();
            menüBirimi3a2 = new ToolStripMenuItem();
            ayraç3a1 = new ToolStripSeparator();
            menüBirimi3a3 = new ToolStripMenuItem();
            menüBirimi3a4 = new ToolStripMenuItem();
            ayraç3a2 = new ToolStripSeparator();
            menüBirimi3a5 = new ToolStripMenuItem();
            menüBirimi3a6 = new ToolStripMenuItem();
            ayraç3a3 = new ToolStripSeparator();
            menüBirimi3a7 = new ToolStripMenuItem();
            menüBirimi3b = new ToolStripMenuItem();
            menüBirimi3b1 = new ToolStripMenuItem();
            menüBirimi3c = new ToolStripMenuItem();
            menüBirimi3c1 = new ToolStripMenuItem();
            menüBirimi3c2 = new ToolStripMenuItem();
            menüBirimi3c3 = new ToolStripMenuItem();
            ayraç3c1 = new ToolStripSeparator();
            menüBirimi3c4 = new ToolStripMenuItem();
            zenginMetinKutu = new RichTextBox();
            menüÞeridi.SuspendLayout();
            SuspendLayout();
            //menüÞeridi
            menüÞeridi.Items.AddRange (new ToolStripItem[] {menüBirimi3a, menüBirimi3b, menüBirimi3c});
            menüÞeridi.Location = new Point (0, 0);
            menüÞeridi.Name = "menüÞeridi";
            menüÞeridi.Size = new Size (602, 24);
            menüÞeridi.TabIndex = 0;
            menüÞeridi.Text = "menüÞeridi";
            //menüBirimi3a
            menüBirimi3a.DropDownItems.AddRange (new ToolStripItem[] {
                menüBirimi3a1,
                menüBirimi3a2,
                ayraç3a1,
                menüBirimi3a3,
                menüBirimi3a4,
                ayraç3a2,
                menüBirimi3a5,
                menüBirimi3a6,
                ayraç3a3,
                menüBirimi3a7});
            menüBirimi3a.Name = "menüBirimi3a";
            menüBirimi3a.Size = new Size (35, 20);
            menüBirimi3a.Text = "&Dosya"; //Alt-d
            //menüBirimi3a1
            menüBirimi3a1.Name = "menüBirimi3a1";
            menüBirimi3a1.ShortcutKeys = ((Keys)((Keys.Control | Keys.Y)));
            menüBirimi3a1.Size = new Size (151, 22);
            menüBirimi3a1.Text = "&Yeni";
            menüBirimi3a1.Click += new EventHandler (menüBirimi3a1_Týklandý);
            //menüBirimi3a2
            menüBirimi3a2.Name = "menüBirimi3a2";
            menüBirimi3a2.ShortcutKeys = ((Keys)((Keys.Control | Keys.A)));
            menüBirimi3a2.Size = new Size (151, 22);
            menüBirimi3a2.Text = "&Aç";
            menüBirimi3a2.Click += new EventHandler (menüBirimi3a2_Týklandý);
            //ayraç3a1
            ayraç3a1.Name = "ayraç3a1";
            ayraç3a1.Size = new Size (148, 6);
            //menüBirimi3a3
            menüBirimi3a3.Name = "menüBirimi3a3";
            menüBirimi3a3.ShortcutKeys = ((Keys)((Keys.Control | Keys.K)));
            menüBirimi3a3.Size = new Size (151, 22);
            menüBirimi3a3.Text = "&Kaydet";
            menüBirimi3a3.Click += new EventHandler (menüBirimi3a3_Týklandý);
            //menüBirimi3a4
            menüBirimi3a4.ShortcutKeys = ((Keys)((Keys.Control | Keys.F)));
            menüBirimi3a4.Name = "menüBirimi3a4";
            menüBirimi3a4.Size = new Size (151, 22);
            menüBirimi3a4.Text = "&Farklý Kaydet";
            //ayraç3a2
            ayraç3a2.Name = "ayraç3a2";
            ayraç3a2.Size = new Size (148, 6);
            //menüBirimi3a5
            menüBirimi3a5.Name = "menüBirimi3a5";
            menüBirimi3a5.ShortcutKeys = ((Keys)((Keys.Control | Keys.Z)));
            menüBirimi3a5.Size = new Size (151, 22);
            menüBirimi3a5.Text = "Yaz&";
            //menüBirimi3a6
            menüBirimi3a6.Name = "menüBirimi3a6";
            menüBirimi3a6.ShortcutKeys = ((Keys)((Keys.Control | Keys.G)));
            menüBirimi3a6.Size = new Size (151, 22);
            menüBirimi3a6.Text = "Yazýlaný &Gör";
            //ayraç3a3
            ayraç3a3.Name = "ayraç3a3";
            ayraç3a3.Size = new Size (148, 6);
            //menüBirimi3a7
            menüBirimi3a7.Name = "menüBirimi3a7";
            menüBirimi3a7.Size = new Size(151, 22);
            menüBirimi3a7.Text = "&Çýk"; //Alt-ç
            //menüBirimi3b
            menüBirimi3b.DropDownItems.AddRange (new ToolStripItem[] {menüBirimi3b1});
            menüBirimi3b.Name = "menüBirimi3b";
            menüBirimi3b.Size = new Size (53, 20);
            menüBirimi3b.Text = "&Biçim";
            //menüBirimi3b1
            menüBirimi3b1.Checked = true;
            menüBirimi3b1.CheckOnClick = true;
            menüBirimi3b1.CheckState = CheckState.Checked;
            menüBirimi3b1.Name = "menüBirimi3b1";
            menüBirimi3b1.Size = new Size (164, 22);
            menüBirimi3b1.Text = "Yardým Menüsünü Göster";
            menüBirimi3b1.Click += new EventHandler (menüBirimi3b1_Týklandý);
            //menüBirimi3c
            menüBirimi3c.DropDownItems.AddRange (new ToolStripItem[] {
                menüBirimi3c1,
                menüBirimi3c2,
                menüBirimi3c3,
                ayraç3c1,
                menüBirimi3c4});
            menüBirimi3c.Name = "menüBirimi3c";
            menüBirimi3c.Size = new Size (40, 20);
            menüBirimi3c.Text = "&Yardým";
            //menüBirimi3c1
            menüBirimi3c1.Name = "menüBirimi3c1";
            menüBirimi3c1.Size = new Size (129, 22);
            menüBirimi3c1.Text = "Ýçerikler";
            //menüBirimi3c2
            menüBirimi3c2.Name = "menüBirimi3c2";
            menüBirimi3c2.Size = new Size (129, 22);
            menüBirimi3c2.Text = "Dizin";
            //menüBirimi3c3
            menüBirimi3c3.Name = "menüBirimi3c3";
            menüBirimi3c3.Size = new Size (129, 22);
            menüBirimi3c3.Text = "Araþtýr";
            //ayraç3c1
            ayraç3c1.Name = "ayraç3c1";
            ayraç3c1.Size = new Size (126, 6);
            //menüBirimi3c4
            menüBirimi3c4.Name = "menüBirimi3c4";
            menüBirimi3c4.Size = new Size (129, 22);
            menüBirimi3c4.Text = "Hakkýnda";
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
            Controls.Add (menüÞeridi);
            Controls.Add (zenginMetinKutu);
            Text="Form3: ZenginMetinKutusu (.rtf)";
            MainMenuStrip = menüÞeridi;
            menüÞeridi.ResumeLayout (false);
            menüÞeridi.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void menüBirimi3b1_Týklandý (object k, EventArgs o) {
            ToolStripMenuItem birim = (ToolStripMenuItem)k;
            menüBirimi3c.Visible = birim.Checked;
        }
        private void menüBirimi3a1_Týklandý (object k, EventArgs o) {zenginMetinKutu.Text = "\n\n\nM.Nihat Yavaþ, Toroslar-Mersin\r\n21.05.2025 00:57";}
        private void menüBirimi3a2_Týklandý (object k, EventArgs o) {zenginMetinKutu.LoadFile (@"j2sc#2302f.rtf");}
        private void menüBirimi3a3_Týklandý (object k, EventArgs o) {zenginMetinKutu.SaveFile (@"mny1.rtf");}
    }
//---------------------- Form4 ----------------------------------
    class Form4: Form {
        private Button düðme4a;
        private Button düðme4b;
        private Button düðme4c;
        private Button düðme4d;
        private Button düðme4e;
        private Button düðme4f;
        private Label fiþ;
        private TextBox metinKutu;
        private RichTextBox zenginMetinKutu;
        public Form4() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            düðme4a = new Button();
            düðme4b = new Button();
            düðme4c = new Button();
            düðme4d = new Button();
            düðme4e = new Button();
            düðme4f = new Button();
            fiþ = new Label();
            metinKutu = new TextBox();
            zenginMetinKutu = new RichTextBox();
            SuspendLayout();
            //düðme4a
            düðme4a.Anchor = AnchorStyles.Top;
            düðme4a.Location = new Point (187, 13);
            düðme4a.Margin = new Padding (3, 3, 3, 1);
            düðme4a.Name = "düðme4a";
            düðme4a.Size = new Size (82, 23);
            düðme4a.TabIndex = 0;
            düðme4a.Text = "Koyu";
            düðme4a.BackColor=Color.Salmon;
            düðme4a.Click += new EventHandler (düðme4a_Týklandý);
            //düðme4b
            düðme4b.Anchor = AnchorStyles.Top;
            düðme4b.Location = new Point (276, 13);
            düðme4b.Margin = new Padding (3, 3, 3, 1);
            düðme4b.Name = "düðme4b";
            düðme4b.Size = new Size (82, 23);
            düðme4b.TabIndex = 1;
            düðme4b.Text = "Altçizgi";
            düðme4b.BackColor=Color.Salmon;
            düðme4b.Click += new EventHandler (düðme4b_Týklandý);
            //düðme4c
            düðme4c.Anchor = AnchorStyles.Top;
            düðme4c.Location = new Point (365, 13);
            düðme4c.Margin = new Padding (3, 3, 3, 1);
            düðme4c.Name = "düðme4c";
            düðme4c.Size = new Size (82, 23);
            düðme4c.TabIndex = 2;
            düðme4c.Text = "Yatýk";
            düðme4c.BackColor=Color.Salmon;
            düðme4c.Click += new EventHandler (düðme4c_Týklandý);
            //düðme4d
            düðme4d.Anchor = AnchorStyles.Top;
            düðme4d.Location = new Point (454, 13);
            düðme4d.Margin = new Padding (3, 3, 3, 1);
            düðme4d.Name = "düðme4d";
            düðme4d.Size = new Size (82, 23);
            düðme4d.TabIndex = 3;
            düðme4d.Text = "Ortala";
            düðme4d.BackColor=Color.Salmon;
            düðme4d.Click += new EventHandler (düðme4d_Týklandý);
            //düðme4e
            düðme4e.Anchor = AnchorStyles.Bottom;
            düðme4e.Location = new Point (276, 309);
            düðme4e.Margin = new Padding (3, 0, 3, 3);
            düðme4e.Name = "düðme4e";
            düðme4e.Size = new Size(82, 23);
            düðme4e.TabIndex = 5;
            düðme4e.Text = "Yükle";
            düðme4e.BackColor=Color.Salmon;
            düðme4e.Click += new EventHandler (düðme4e_Týklandý);
            //düðme4bf
            düðme4f.Anchor = AnchorStyles.Bottom;
            düðme4f.Location = new Point (365, 309);
            düðme4f.Margin = new Padding(3, 0, 3, 3);
            düðme4f.Name = "düðme4f";
            düðme4f.Size = new Size (82, 23);
            düðme4f.TabIndex = 4;
            düðme4f.Text = "Kaydet";
            düðme4f.BackColor=Color.Salmon;
            düðme4f.Click += new EventHandler (düðme4f_Týklandý);
            //fiþ
            fiþ.Anchor = AnchorStyles.Top;
            fiþ.AutoSize = true;
            fiþ.Location = new Point (295, 46);
            fiþ.Name = "fiþ";
            fiþ.Size = new Size (26, 14);
            fiþ.TabIndex = 6;
            fiþ.Text = "Ebat";
            //metinKutu
            metinKutu.Anchor = AnchorStyles.Top;
            metinKutu.Location = new Point (328, 43);
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (25, 16);
            metinKutu.TabIndex = 7;
            metinKutu.Text = "10";
            metinKutu.BackColor=Color.Lime;
            metinKutu.ForeColor=Color.DarkRed;
            metinKutu.Validating += new CancelEventHandler (metinKutu_Geçerliyor);
            metinKutu.KeyPress += new KeyPressEventHandler (metinKutu_TuþBasýldý);
            //
            zenginMetinKutu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            zenginMetinKutu.Location = new Point (13, 70);
            zenginMetinKutu.Name = "zenginMetinKutu";
            zenginMetinKutu.Size = new Size (686, 232);
            zenginMetinKutu.TabIndex = 8;
            zenginMetinKutu.Text = "\n\n\nM.Nihat Yavaþ, Toroslar-Mersin\r\n21.05.2025 02:03";
            zenginMetinKutu.BackColor=Color.SkyBlue;
            zenginMetinKutu.ForeColor=Color.Sienna;
            zenginMetinKutu.LinkClicked += new LinkClickedEventHandler (zenginMetinKutu_BaðTýklandý);
            //
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (722, 341);
            Controls.AddRange (new Control[] {düðme4a, düðme4b, düðme4c, düðme4d, düðme4e, düðme4f, fiþ, metinKutu, zenginMetinKutu});
            MinimumSize = new Size (730, 368);
            Name = "Form4";
            Text = "Form4: ZenginMetinKutu Stiller";
            BackColor=Color.DarkKhaki;
            ForeColor=Color.DarkGreen;
            ResumeLayout (false);
            PerformLayout();
        }
        private void düðme4a_Týklandý (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Bold) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Bold);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Bold);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void düðme4b_Týklandý (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Underline) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Underline);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Underline);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void düðme4c_Týklandý (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            eskiFon = zenginMetinKutu.SelectionFont;
            if (eskiFon.Italic) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Italic);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Italic);
            zenginMetinKutu.SelectionFont = yeniFon;
            zenginMetinKutu.Focus();
        }
        private void düðme4d_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionAlignment == HorizontalAlignment.Center) zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Left;
            else zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Center;
            zenginMetinKutu.Focus();
        }
        private void metinKutu_TuþBasýldý (object k, KeyPressEventArgs o) {
            if ((o.KeyChar < 48 || o.KeyChar > 57) && o.KeyChar != 8 && o.KeyChar != 13) {o.Handled = true;
            }else if (o.KeyChar == 13) {
                TextBox mk = (TextBox)k;
                if (mk.Text.Length > 0) EbatýMetneUygula (mk.Text);
                o.Handled = true;
                zenginMetinKutu.Focus();
            }
        }
        private void metinKutu_Geçerliyor(object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            EbatýMetneUygula (mk.Text);
            zenginMetinKutu.Focus();
        }
        private void EbatýMetneUygula (string metin) {
            float yeniEbat = Convert.ToSingle (metin);
            FontFamily fonAilesi;
            Font yeniFon;
            fonAilesi = zenginMetinKutu.SelectionFont.FontFamily;
            yeniFon = new Font (fonAilesi, yeniEbat);
            zenginMetinKutu.SelectionFont = yeniFon;
        }
        private void zenginMetinKutu_BaðTýklandý (object k, LinkClickedEventArgs o) {System.Diagnostics.Process.Start (o.LinkText);}
        private void düðme4e_Týklandý (object k, EventArgs o) {
            try {zenginMetinKutu.LoadFile ("j2sc#2302f.rtf");
            }catch (FileNotFoundException) {MessageBox.Show ("Yüklenecek bu adda dosya bulunamadý");}
        }
        private void düðme4f_Týklandý (object k, EventArgs o) {
            try {zenginMetinKutu.SaveFile ("mny1.rtf");
            }catch (Exception ht) {MessageBox.Show (ht.Message);}
        }
    }
//---------------------- Form5 ----------------------------------
    public class Form5: Form {
        RichTextBox zenginMetinKutu;
        public Form5() {//Kurucu
            Size = new Size (400, 500);
            Text = "Form5: ZenginMetinKutu Düzenle Biçimle";
            //zenginMetinKutu
            zenginMetinKutu = new RichTextBox();
            zenginMetinKutu.Parent = this;
            zenginMetinKutu.Text = "\n\n\nM.Nihat Yavaþ, Toroslar-Mersin\r\n21.05.2025 03:48";
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
            //menüBirim5a
            MenuItem menüBirim5a1 = new MenuItem ("&Ýthal",new EventHandler (menüBirim5a1_Týklandý));
            MenuItem menüBirim5a = new MenuItem ("&Dosya", new MenuItem[] {menüBirim5a1});
            //menüBirim5b
            MenuItem menüBirim5b1 = new MenuItem ("&Gerial", new EventHandler (menüBirim5b1_Týklandý), Shortcut.CtrlG);
            MenuItem menüBirim5b2 = new MenuItem ("-");
            MenuItem menüBirim5b3 = new MenuItem ("&Kes",  new EventHandler (menüBirim5b3_Týklandý),  Shortcut.CtrlK);
            MenuItem menüBirim5b4 = new MenuItem ("Kop&yala", new EventHandler (menüBirim5b4_Týklandý), Shortcut.CtrlP);
            MenuItem menüBirim5b5 = new MenuItem ("&Rtf Kopyala",  new EventHandler (menüBirim5b5_Týklandý));
            MenuItem menüBirim5b6 = new MenuItem ("&Yapýþtýr", new EventHandler (menüBirim5b6_Týklandý), Shortcut.CtrlY);
            MenuItem menüBirim5b7 = new MenuItem ("&Sil", new EventHandler (menüBirim5b7_Týklandý));
            MenuItem menüBirim5b8 = new MenuItem ("-");
            MenuItem menüBirim5b9 = new MenuItem ("&Tümünü Seç",  new EventHandler (menüBirim5b9_Týklandý), Shortcut.CtrlT);
            MenuItem menüBirim5b10 = new MenuItem ("Ýlk &5 Krk Seç", new EventHandler (menüBirim5b10_Týklandý), Shortcut.Ctrl5);
            MenuItem menüBirim5b11 = new MenuItem ("Temiz&le", new EventHandler (menüBirim5b11_Týklandý));
            MenuItem menüBirim5b = new MenuItem ("Düze&n", new MenuItem[] {menüBirim5b1, menüBirim5b2, menüBirim5b3, menüBirim5b4, menüBirim5b5, menüBirim5b6, menüBirim5b7, menüBirim5b8, menüBirim5b9, menüBirim5b10, menüBirim5b11});
            //menüBirim5c
            MenuItem menüBirim5c1 = new MenuItem ("Ýmlece &Kaydýr", new EventHandler (menüBirim5c1_Týklandý));
            MenuItem menüBirim5c = new MenuItem ("&Gör", new MenuItem[] {menüBirim5c1});
            //menüBirim5d
            MenuItem menüBirim5d1 = new MenuItem ("&Bilye", new EventHandler (menüBirim5d1_Týklandý));
            MenuItem menüBirim5d2a = new MenuItem("&Sola Yanaþtýr", new EventHandler (menüBirim5d2a_Týklandý));
            MenuItem menüBirim5d2b = new MenuItem("Sa&ða Yanaþtýr", new EventHandler (menüBirim5d2b_Týklandý));
            MenuItem menüBirim5d2c = new MenuItem("&Ortala", new EventHandler (menüBirim5d2c_Týklandý));
            MenuItem menüBirim5d2 = new MenuItem ("&Hizala", new MenuItem[] {menüBirim5d2a, menüBirim5d2b, menüBirim5d2c});
            MenuItem menüBirim5d3 = new MenuItem ("&Kýrmýzý", new EventHandler (menüBirim5d3_Týklandý));
            MenuItem menüBirim5d4 = new MenuItem ("Ko&yu", new EventHandler (menüBirim5d4_Týklandý));
            MenuItem menüBirim5d5 = new MenuItem ("As&kýlý Girinti", new EventHandler (menüBirim5d5_Týklandý));
            MenuItem menüBirim5d6 = new MenuItem ("Gir&inti", new EventHandler (menüBirim5d6_Týklandý));
            MenuItem menüBirim5d7 = new MenuItem ("Saðd&an Girinti",  new EventHandler (menüBirim5d7_Týklandý));
            MenuItem menüBirim5d = new MenuItem ("&Biçim", new MenuItem[] {menüBirim5d1, menüBirim5d2, menüBirim5d3, menüBirim5d4, menüBirim5d5, menüBirim5d6, menüBirim5d7});
            //Menü
            Menu = new MainMenu (new MenuItem[] {menüBirim5a, menüBirim5b, menüBirim5c, menüBirim5d});
        }
        private void menüBirim5a1_Týklandý (object k, EventArgs o) {
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
        private void menüBirim5b1_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.CanUndo == true) {
                zenginMetinKutu.Undo();
                zenginMetinKutu.ClearUndo();
            }
        }
        private void menüBirim5b3_Týklandý (object k, EventArgs o) {if (zenginMetinKutu.SelectedText != "") zenginMetinKutu.Cut();}
        private void menüBirim5b4_Týklandý (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) zenginMetinKutu.Copy();}
        private void menüBirim5b5_Týklandý (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) Clipboard.SetDataObject (zenginMetinKutu.SelectedRtf);}
        private void menüBirim5b6_Týklandý (object k, EventArgs o) {
            if (Clipboard.GetDataObject().GetDataPresent (DataFormats.Text) == true) {
                if (zenginMetinKutu.CanUndo == true) {
                    if (zenginMetinKutu.SelectionLength > 0) {
                        if (MessageBox.Show ("Mevcut seçilen metnin üzerine yazmak istiyor musun?",  "Kes & Yapýþtýr", MessageBoxButtons.YesNo) == DialogResult.No) zenginMetinKutu.SelectionStart = zenginMetinKutu.SelectionStart + zenginMetinKutu.SelectionLength;
                    }
                    zenginMetinKutu.Paste();
                }
            }
        }
        private void menüBirim5b7_Týklandý (object k, EventArgs o) {if (zenginMetinKutu.SelectionLength > 0) zenginMetinKutu.SelectedText = "";}
        private void menüBirim5b9_Týklandý (object k, EventArgs o) {zenginMetinKutu.SelectAll();}
        private void menüBirim5b10_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.Text.Length >= 5) {zenginMetinKutu.Select (0,5);
            }else {zenginMetinKutu.Select (0,zenginMetinKutu.Text.Length);}
        }
        private void menüBirim5b11_Týklandý (object k, EventArgs o) {zenginMetinKutu.Clear();}
        private void menüBirim5c1_Týklandý (object k, EventArgs o) {zenginMetinKutu.ScrollToCaret();}
        private void menüBirim5d1_Týklandý (object k, EventArgs o) {zenginMetinKutu.SelectionBullet = !zenginMetinKutu.SelectionBullet;}
        private void menüBirim5d2a_Týklandý (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Left;}
        private void menüBirim5d2b_Týklandý (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Right;}
        private void menüBirim5d2c_Týklandý (object k, EventArgs o) {zenginMetinKutu.SelectionAlignment = HorizontalAlignment.Center;}
        private void menüBirim5d3_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionColor == Color.Red) zenginMetinKutu.SelectionColor = Color.Black;
            else zenginMetinKutu.SelectionColor = Color.Red;
        }
        private void menüBirim5d4_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionFont.Bold) zenginMetinKutu.SelectionFont = new Font (zenginMetinKutu.SelectionFont, FontStyle.Regular);
            else zenginMetinKutu.SelectionFont = new Font (zenginMetinKutu.SelectionFont, FontStyle.Bold);
        }
        private void menüBirim5d5_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionHangingIndent == 10) zenginMetinKutu.SelectionHangingIndent = 0;
            else zenginMetinKutu.SelectionHangingIndent = 10;
        }
        private void menüBirim5d6_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionIndent == 10) zenginMetinKutu.SelectionIndent = 0;
            else zenginMetinKutu.SelectionIndent = 10;
        }
        private void menüBirim5d7_Týklandý (object k, EventArgs o) {
            if (zenginMetinKutu.SelectionRightIndent == 50) zenginMetinKutu.SelectionRightIndent = 0;
            else zenginMetinKutu.SelectionRightIndent = 50;
        }
    }
//---------------------- Form6 ----------------------------------
    public class Form6: Form {
        private MenuStrip menüÞeridi;
        private ToolStripMenuItem menüBirimi6a;
        private ToolStripMenuItem menüBirimi6a1;
        private ToolStripMenuItem menüBirimi6a2;
        private ToolStripSeparator ayraç6a1;
        private ToolStripMenuItem menüBirimi6a3;
        private ToolStripMenuItem menüBirimi6a4;
        private ToolStripSeparator ayraç6a2;
        private ToolStripMenuItem menüBirimi6a5;
        private ToolStripMenuItem menüBirimi6a6;
        private ToolStripSeparator ayraç6a3;
        private ToolStripMenuItem menüBirimi6a7;
        private ToolStripMenuItem menüBirimi6b;
        private ToolStripMenuItem menüBirimi6b1;
        private ToolStripMenuItem menüBirimi6b2;
        private ToolStripMenuItem menüBirimi6b3;
        private ToolStripMenuItem menüBirimi6c;
        private ToolStripMenuItem menüBirimi6c1;
        private ToolStripMenuItem menüBirimi6c2;
        private ToolStripMenuItem menüBirimi6c3;
        private ToolStripSeparator ayraç6c1;
        private ToolStripMenuItem menüBirimi6c4;
        private ToolStrip araçÞeridi;
        private ToolStripButton araçÞeritDüðmesi6a1;
        private ToolStripButton araçÞeritDüðmesi6a2;
        private ToolStripButton araçÞeritDüðmesi6a3;
        private ToolStripButton araçÞeritDüðmesi6a4;
        private ToolStripSeparator araçÞeritAyraç1;
        private ToolStripButton araçÞeritDüðmesi6b1;
        private ToolStripButton araçÞeritDüðmesi6b2;
        private ToolStripButton araçÞeritDüðmesi6b3;
        private ToolStripSeparator araçÞeritAyraç2;
        private ToolStripComboBox araçÞeritTaraklýKutu;
        private ToolStripSeparator araçÞeritAyraç3;
        private ToolStripButton araçÞeritDüðmesi6c;
        private RichTextBox zenginMetinKutusu;
        private StatusStrip durumÞeridi;
        private ToolStripStatusLabel araçÞeritDurumFiþi6a;
        private ToolStripStatusLabel araçÞeritDurumFiþi6b;
        private ToolStripStatusLabel araçÞeritDurumFiþi6c;
        private ToolStripStatusLabel araçÞeritDurumFiþi6d;
        public Form6() {//Kurucu
            BileþeniBaþlat();
            araçÞeritTaraklýKutu.SelectedIndex = 0;
        }
        private void BileþeniBaþlat() {
            menüÞeridi = new MenuStrip();
            menüBirimi6a = new ToolStripMenuItem();
            menüBirimi6a1 = new ToolStripMenuItem();
            menüBirimi6a2 = new ToolStripMenuItem();
            ayraç6a1 = new ToolStripSeparator();
            menüBirimi6a3 = new ToolStripMenuItem();
            menüBirimi6a4 = new ToolStripMenuItem();
            ayraç6a2 = new ToolStripSeparator();
            menüBirimi6a5 = new ToolStripMenuItem();
            menüBirimi6a6 = new ToolStripMenuItem();
            ayraç6a3 = new ToolStripSeparator();
            menüBirimi6a7 = new ToolStripMenuItem();
            menüBirimi6b = new ToolStripMenuItem();
            menüBirimi6b1 = new ToolStripMenuItem();
            menüBirimi6b2 = new ToolStripMenuItem();
            menüBirimi6b3 = new ToolStripMenuItem();
            menüBirimi6c = new ToolStripMenuItem();
            menüBirimi6c1 = new ToolStripMenuItem();
            menüBirimi6c2 = new ToolStripMenuItem();
            menüBirimi6c3 = new ToolStripMenuItem();
            ayraç6c1 = new ToolStripSeparator();
            menüBirimi6c4 = new ToolStripMenuItem();
            araçÞeridi = new ToolStrip();
            araçÞeritDüðmesi6a1 = new ToolStripButton();
            araçÞeritDüðmesi6a2 = new ToolStripButton();
            araçÞeritDüðmesi6a3 = new ToolStripButton();
            araçÞeritDüðmesi6a4 = new ToolStripButton();
            araçÞeritAyraç1 = new ToolStripSeparator();
            araçÞeritDüðmesi6b1 = new ToolStripButton();
            araçÞeritDüðmesi6b2 = new ToolStripButton();
            araçÞeritDüðmesi6b3 = new ToolStripButton();
            araçÞeritAyraç2 = new ToolStripSeparator();
            araçÞeritTaraklýKutu = new ToolStripComboBox();
            araçÞeritAyraç3 = new ToolStripSeparator();
            araçÞeritDüðmesi6c = new ToolStripButton();
            zenginMetinKutusu = new RichTextBox();
            durumÞeridi = new StatusStrip();
            araçÞeritDurumFiþi6a = new ToolStripStatusLabel();
            araçÞeritDurumFiþi6b = new ToolStripStatusLabel();
            araçÞeritDurumFiþi6c = new ToolStripStatusLabel();
            araçÞeritDurumFiþi6d = new ToolStripStatusLabel();
            menüÞeridi.SuspendLayout();
            araçÞeridi.SuspendLayout();
            durumÞeridi.SuspendLayout();
            SuspendLayout();
            //menüÞeridi
            menüÞeridi.Items.AddRange (new ToolStripItem[] {menüBirimi6a, menüBirimi6b, menüBirimi6c});
            menüÞeridi.Location = new Point (0, 0);
            menüÞeridi.Size = new Size (454, 24);
            menüÞeridi.TabIndex = 1;
            menüÞeridi.Text = "menüÞeridi";
            //menüBirimi6a
            menüBirimi6a.DropDownItems.AddRange (new ToolStripItem[] {menüBirimi6a1, menüBirimi6a2, ayraç6a1, menüBirimi6a3, menüBirimi6a4,
                ayraç6a2, menüBirimi6a5, menüBirimi6a6, ayraç6a3, menüBirimi6a7});
            menüBirimi6a.Name = "menüBirimi6a";
            menüBirimi6a.Size = new Size (37, 20);
            menüBirimi6a.Text = "&Dosya"; //Alt-d
            //menüBirimi6a1
            menüBirimi6a1.Name = "menüBirimi6a1";
            menüBirimi6a1.ShortcutKeys = ((Keys)((Keys.Control | Keys.Y)));
            menüBirimi6a1.Size = new Size (146, 22);
            menüBirimi6a1.Text = "&Yeni";
            menüBirimi6a1.Click += new EventHandler (menüBirimi6a1_Týklandý);
            //menüBirimi6a2
            menüBirimi6a2.Name = "menüBirimi6a2";
            menüBirimi6a2.ShortcutKeys = ((Keys)((Keys.Control | Keys.A)));
            menüBirimi6a2.Size = new Size (146, 22);
            menüBirimi6a2.Text = "&Aç";
            menüBirimi6a2.Click += new EventHandler (menüBirimi6a2_Týklandý);
            //ayraç6a1
            ayraç6a1.Name = "ayraç6a1";
            ayraç6a1.Size = new Size (143, 6);
            //menüBirimi6a3
            menüBirimi6a3.Name = "menüBirimi6a3";
            menüBirimi6a3.ShortcutKeys = ((Keys)((Keys.Control | Keys.K)));
            menüBirimi6a3.Size = new Size (146, 22);
            menüBirimi6a3.Text = "&Kaydet";
            menüBirimi6a3.Click += new EventHandler (menüBirimi6a3_Týklandý);
            //menüBirimi6a4
            menüBirimi6a4.Name = "menüBirimi6a4";
            menüBirimi6a4.Size = new Size (146, 22);
            menüBirimi6a4.Text = "&Farklý Kaydet";
            //ayraç6a1
            ayraç6a2.Name = "ayraç6a2";
            ayraç6a2.Size = new Size (143, 6);
            //menüBirimi6a5
            menüBirimi6a5.Name = "menüBirimi6a5";
            menüBirimi6a5.ShortcutKeys = ((Keys)((Keys.Control | Keys.Z)));
            menüBirimi6a5.Size = new Size (146, 22);
            menüBirimi6a5.Text = "Ya&z";
            //menüBirimi6a5
            menüBirimi6a6.Name = "menüBirimi6a6";
            menüBirimi6a6.Size = new Size (146, 22);
            menüBirimi6a6.Text = "Yazýlaný Gör";
            //ayraç6a1
            ayraç6a3.Name = "ayraç6a3";
            ayraç6a3.Size = new Size (143, 6);
            //menüBirimi6a7
            menüBirimi6a7.Name = "menüBirimi6a7";
            menüBirimi6a7.Size = new Size (146, 22);
            menüBirimi6a7.Text = "&Çýk";
            //menüBirimi6b
            menüBirimi6b.DropDownItems.AddRange (new ToolStripItem[] {menüBirimi6b1, menüBirimi6b2, menüBirimi6b3});
            menüBirimi6b.Name = "menüBirimi6b";
            menüBirimi6b.Size = new Size (57, 20);
            menüBirimi6b.Text = "&Biçim";
            //menüBirimi6b1
            menüBirimi6b1.CheckOnClick = true;
            menüBirimi6b1.Name = "menüBirimi6b1";
            menüBirimi6b1.Size = new Size (125, 22);
            menüBirimi6b1.Text = "&Koyu";
            menüBirimi6b1.CheckedChanged += new EventHandler (menüBirimi6b1_ÇentikDeðiþti);
            //menüBirimi6b2
            menüBirimi6b2.CheckOnClick = true;
            menüBirimi6b2.Name = "menüBirimi6b2";
            menüBirimi6b2.Size = new Size (125, 22);
            menüBirimi6b2.Text = "&Yatýk";
            menüBirimi6b2.CheckedChanged += new EventHandler (menüBirimi6b2_ÇentikDeðiþti);
            //menüBirimi6b3
            menüBirimi6b3.CheckOnClick = true;
            menüBirimi6b3.Name = "menüBirimi6b3";
            menüBirimi6b3.Size = new Size (125, 22);
            menüBirimi6b3.Text = "&Altçizgi";
            menüBirimi6b3.CheckedChanged += new EventHandler (menüBirimi6b3_ÇentikDeðiþti);
            //menüBirimi6c
            menüBirimi6c.DropDownItems.AddRange (new ToolStripItem[] {menüBirimi6c1, menüBirimi6c2, menüBirimi6c3, ayraç6c1, menüBirimi6c4});
            menüBirimi6c.Name = "menüBirimi6c";
            menüBirimi6c.Size = new Size (44, 20);
            menüBirimi6c.Text = "Yardý&m";
            //menüBirimi6c1
            menüBirimi6c1.Name = "menüBirimi6c1";
            menüBirimi6c1.Size = new Size (122, 22);
            menüBirimi6c1.Text = "Ýçerik";
            //menüBirimi6c2
            menüBirimi6c2.Name = "menüBirimi6c2";
            menüBirimi6c2.Size = new Size (122, 22);
            menüBirimi6c2.Text = "Dizin";
            //menüBirimi6c3
            menüBirimi6c3.Name = "menüBirimi6c3";
            menüBirimi6c3.Size = new Size (122, 22);
            menüBirimi6c3.Text = "Araþtýr";
            //ayraç6c1
            ayraç6c1.Name = "ayraç6c1";
            ayraç6c1.Size = new Size (119, 6);
            //menüBirimi6c4
            menüBirimi6c4.Name = "menüBirimi6c4";
            menüBirimi6c4.Size = new Size (122, 22);
            menüBirimi6c4.Text = "Hakkýnda";
            // araçÞeridi
            araçÞeridi.Items.AddRange (new ToolStripItem[] {araçÞeritDüðmesi6a1, araçÞeritDüðmesi6a2, araçÞeritDüðmesi6a3, araçÞeritDüðmesi6a4, araçÞeritAyraç1,
                araçÞeritDüðmesi6b1, araçÞeritDüðmesi6b2, araçÞeritDüðmesi6b3, araçÞeritAyraç2, araçÞeritTaraklýKutu, araçÞeritAyraç3, araçÞeritDüðmesi6c});
            araçÞeridi.Location = new Point (0, 24);
            araçÞeridi.Name = "araçÞeridi";
            araçÞeridi.Size = new Size (454, 25);
            araçÞeridi.TabIndex = 2;
            araçÞeridi.Text = "araçÞeridi";
            // araçÞeritDüðmesi6a1
            araçÞeritDüðmesi6a1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6a1.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6a1.Name = "araçÞeritDüðmesi6a1";
            araçÞeritDüðmesi6a1.Size = new Size (23, 22);
            araçÞeritDüðmesi6a1.Text = "&Yeni";
            araçÞeritDüðmesi6a1.Click += new EventHandler (menüBirimi6a1_Týklandý);
            // araçÞeritDüðmesi6a2
            araçÞeritDüðmesi6a2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6a2.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6a2.Name = "araçÞeritDüðmesi6a2";
            araçÞeritDüðmesi6a2.Size = new Size (23, 22);
            araçÞeritDüðmesi6a2.Text = "&Aç";
            araçÞeritDüðmesi6a2.Click += new EventHandler (menüBirimi6a2_Týklandý);
            // araçÞeritDüðmesi6a3
            araçÞeritDüðmesi6a3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6a3.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6a3.Name = "araçÞeritDüðmesi6a3";
            araçÞeritDüðmesi6a3.Size = new Size (23, 22);
            araçÞeritDüðmesi6a3.Text = "&Kaydet";
            araçÞeritDüðmesi6a3.Click += new EventHandler (menüBirimi6a3_Týklandý);
            // araçÞeritDüðmesi6a4
            araçÞeritDüðmesi6a4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6a4.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6a4.Name = "araçÞeritDüðmesi6a4";
            araçÞeritDüðmesi6a4.Size = new Size (23, 22);
            araçÞeritDüðmesi6a4.Text = "Ya&z";
            // araçÞeritAyraç1
            araçÞeritAyraç1.Name = "araçÞeritAyraç1";
            araçÞeritAyraç1.Size = new Size (6, 25);
            // araçÞeritDüðmesi6b1
            araçÞeritDüðmesi6b1.CheckOnClick = true;
            araçÞeritDüðmesi6b1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6b1.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6b1.Name = "araçÞeritDüðmesi6b1";
            araçÞeritDüðmesi6b1.Size = new Size (23, 22);
            araçÞeritDüðmesi6b1.Text = "Düðme1";
            araçÞeritDüðmesi6b1.CheckedChanged += new EventHandler (araçÞeritDüðmesi6b1_ÇentikDeðiþti);
            // araçÞeritDüðmesi6b2
            araçÞeritDüðmesi6b2.CheckOnClick = true;
            araçÞeritDüðmesi6b2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6b2.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6b2.Name = "araçÞeritDüðmesi6b2";
            araçÞeritDüðmesi6b2.Size = new Size (23, 22);
            araçÞeritDüðmesi6b2.Text = "Düðme2";
            araçÞeritDüðmesi6b2.CheckedChanged += new EventHandler (araçÞeritDüðmesi6b2_ÇentikDeðiþti);
            // araçÞeritDüðmesi6b3
            araçÞeritDüðmesi6b3.CheckOnClick = true;
            araçÞeritDüðmesi6b3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6b3.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6b3.Name = "araçÞeritDüðmesi6b3";
            araçÞeritDüðmesi6b3.Size = new Size (23, 22);
            araçÞeritDüðmesi6b3.Text = "Düðme3";
            araçÞeritDüðmesi6b3.CheckedChanged += new EventHandler (araçÞeritDüðmesi6b3_ÇentikDeðiþti);
            // araçÞeritAyraç2
            araçÞeritAyraç2.Name = "araçÞeritAyraç2";
            araçÞeritAyraç2.Size = new Size (6, 25);
            // araçÞeritTaraklýKutu
            araçÞeritTaraklýKutu.DropDownStyle = ComboBoxStyle.DropDownList;
            araçÞeritTaraklýKutu.Items.AddRange (new object[] {"MS Sans Serif", "Times New Roman", "Verdana", "Segoe Script"});
            araçÞeritTaraklýKutu.Name = "araçÞeritTaraklýKutu";
            araçÞeritTaraklýKutu.Size = new Size (121, 25);
            araçÞeritTaraklýKutu.SelectedIndexChanged += new EventHandler (araçÞeritTaraklýKutu_EndeksDeðiþti);
            // araçÞeritAyraç3
            araçÞeritAyraç3.Name = "araçÞeritAyraç3";
            araçÞeritAyraç3.Size = new Size (6, 25);
            // araçÞeritDüðmesi6c
            araçÞeritDüðmesi6c.DisplayStyle = ToolStripItemDisplayStyle.Image;
            araçÞeritDüðmesi6c.ImageTransparentColor = Color.Magenta;
            araçÞeritDüðmesi6c.Name = "araçÞeritDüðmesi6c";
            araçÞeritDüðmesi6c.Size = new Size (23, 22);
            araçÞeritDüðmesi6c.Text = "Yardý&m";
            araçÞeritDüðmesi6c.CheckedChanged += new EventHandler (araçÞeritDüðmesi6c_ÇentikDeðiþti);
            //zenginMetinKutusu
            zenginMetinKutusu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            zenginMetinKutusu.Location = new Point (0, 52);
            zenginMetinKutusu.Name = "zenginMetinKutusu";
            zenginMetinKutusu.Size = new Size (454, 212);
            zenginMetinKutusu.TabIndex = 0;
            zenginMetinKutusu.Text = "";
            zenginMetinKutusu.BackColor=Color.Khaki;
            zenginMetinKutusu.ForeColor=Color.Navy;
            zenginMetinKutusu.TextChanged += new EventHandler (zenginMetinKutusu_MetinDeðiþti);
            // durumÞeridi
            durumÞeridi.Items.AddRange (new ToolStripItem[] {araçÞeritDurumFiþi6a, araçÞeritDurumFiþi6b, araçÞeritDurumFiþi6c, araçÞeritDurumFiþi6d});
            durumÞeridi.Location = new Point (0, 242);
            durumÞeridi.Name = "durumÞeridi";
            durumÞeridi.Size = new Size (454, 22);
            durumÞeridi.TabIndex = 3;
            durumÞeridi.Text = "durumÞeridi";
            // araçÞeritDurumFiþi6a
            araçÞeritDurumFiþi6a.AutoSize = false;
            araçÞeritDurumFiþi6a.DisplayStyle = ToolStripItemDisplayStyle.Text;
            araçÞeritDurumFiþi6a.Font = new Font ("Arial", 8.25F, FontStyle.Bold);
            araçÞeritDurumFiþi6a.Name = "araçÞeritDurumFiþi6a";
            araçÞeritDurumFiþi6a.Size = new Size (259, 17);
            araçÞeritDurumFiþi6a.TextAlign = ContentAlignment.MiddleLeft;
            // araçÞeritDurumFiþi6b
            araçÞeritDurumFiþi6b.AutoSize = false;
            araçÞeritDurumFiþi6b.DoubleClickEnabled = true;
            araçÞeritDurumFiþi6b.Enabled = false;
            araçÞeritDurumFiþi6b.Font = new Font ("Arial", 8.25F);
            araçÞeritDurumFiþi6b.Name = "araçÞeritDurumFiþi6b";
            araçÞeritDurumFiþi6b.Size = new Size (47, 17);
            araçÞeritDurumFiþi6b.Text = "Koyu";
            araçÞeritDurumFiþi6b.Click += new EventHandler (araçÞeritDurumFiþi6b_Týklandý);
            // araçÞeritDurumFiþi6c
            araçÞeritDurumFiþi6c.AutoSize = false;
            araçÞeritDurumFiþi6c.DoubleClickEnabled = true;
            araçÞeritDurumFiþi6c.Enabled = false;
            araçÞeritDurumFiþi6c.Font = new Font ("Arial", 8.25F);
            araçÞeritDurumFiþi6c.Name = "araçÞeritDurumFiþi6c";
            araçÞeritDurumFiþi6c.Size = new Size (48, 17);
            araçÞeritDurumFiþi6c.Text = "Yatýk";
            araçÞeritDurumFiþi6c.Click += new EventHandler (araçÞeritDurumFiþi6c_Týklandý);
            // araçÞeritDurumFiþi6d
            araçÞeritDurumFiþi6d.AutoSize = false;
            araçÞeritDurumFiþi6d.DoubleClickEnabled = true;
            araçÞeritDurumFiþi6d.Enabled = false;
            araçÞeritDurumFiþi6d.Font = new Font ("Arial", 8.25F);
            araçÞeritDurumFiþi6d.Name = "araçÞeritDurumFiþi6d";
            araçÞeritDurumFiþi6d.Size = new Size (76, 17);
            araçÞeritDurumFiþi6d.Text = "Altçizgi";
            araçÞeritDurumFiþi6d.Click += new EventHandler (araçÞeritDurumFiþi6d_Týklandý);
            // Form6
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (454, 264);
            Controls.Add (durumÞeridi); //Add sýrasý deðiþirse bozuyor: menüÞeridi, araçÞeridi, zenginMetinKutusu, durumÞeridi
            Controls.Add (araçÞeridi);
            Controls.Add (zenginMetinKutusu);
            Controls.Add (menüÞeridi);
            Text="Form6: RTF, Menü, AraçÇubuðu, DurumÇubuðu";
            MainMenuStrip = menüÞeridi;
            menüÞeridi.ResumeLayout (false);
            menüÞeridi.PerformLayout();
            araçÞeridi.ResumeLayout (false);
            araçÞeridi.PerformLayout();
            durumÞeridi.ResumeLayout (false);
            durumÞeridi.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
        private void menüBirimi6a1_Týklandý (object k, EventArgs o) {zenginMetinKutusu.Text = "\n\n\nM.Nihat Yavaþ, Toroslar-Mersin\r\n22.05.2025 02:54";}
        private void menüBirimi6a2_Týklandý (object k, EventArgs o) {zenginMetinKutusu.LoadFile ("j2sc#2302f.rtf");}
        private void menüBirimi6a3_Týklandý (object k, EventArgs o) {zenginMetinKutusu.SaveFile ("mny1.rtf");}
        private void menüBirimi6b1_ÇentikDeðiþti (object k, EventArgs o) {araçÞeritDüðmesi6b1.Checked = menüBirimi6b1.Checked;}
        private void menüBirimi6b2_ÇentikDeðiþti (object k, EventArgs o) {araçÞeritDüðmesi6b2.Checked = menüBirimi6b2.Checked;}
        private void menüBirimi6b3_ÇentikDeðiþti (object k, EventArgs o) {araçÞeritDüðmesi6b3.Checked = menüBirimi6b3.Checked;}
        private void araçÞeritDüðmesi6b1_ÇentikDeðiþti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool çentikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!çentikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Bold);
            else yeniFon = new Font (eskiFon, eskiFon.Style | FontStyle.Bold);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            menüBirimi6b1.CheckedChanged -= new EventHandler (menüBirimi6b1_ÇentikDeðiþti);
            menüBirimi6b1.Checked = çentikliMi;
            menüBirimi6b1.CheckedChanged += new EventHandler (menüBirimi6b1_ÇentikDeðiþti);
            if (!çentikliMi) araçÞeritDurumFiþi6b.Font = new Font (araçÞeritDurumFiþi6b.Font, araçÞeritDurumFiþi6b.Font.Style & ~FontStyle.Bold);
            else araçÞeritDurumFiþi6b.Font = new Font (araçÞeritDurumFiþi6b.Font, araçÞeritDurumFiþi6b.Font.Style | FontStyle.Bold);
        }
        private void araçÞeritDüðmesi6b2_ÇentikDeðiþti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool çentikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!çentikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Italic);
            else yeniFon = new Font(eskiFon, eskiFon.Style | FontStyle.Italic);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            menüBirimi6b2.CheckedChanged -= new EventHandler (menüBirimi6b2_ÇentikDeðiþti);
            menüBirimi6b2.Checked = çentikliMi;
            menüBirimi6b2.CheckedChanged += new EventHandler (menüBirimi6b2_ÇentikDeðiþti);
            if (!çentikliMi) araçÞeritDurumFiþi6c.Font = new Font (araçÞeritDurumFiþi6c.Font, araçÞeritDurumFiþi6c.Font.Style & ~FontStyle.Italic);
            else araçÞeritDurumFiþi6c.Font = new Font (araçÞeritDurumFiþi6c.Font, araçÞeritDurumFiþi6c.Font.Style | FontStyle.Italic);
        }
        private void araçÞeritDüðmesi6b3_ÇentikDeðiþti (object k, EventArgs o) {
            Font eskiFon;
            Font yeniFon;
            bool çentikliMi = ((ToolStripButton)k).Checked;
            eskiFon = zenginMetinKutusu.SelectionFont;
            if (!çentikliMi) yeniFon = new Font (eskiFon, eskiFon.Style & ~FontStyle.Underline);
            else yeniFon = new Font(eskiFon, eskiFon.Style | FontStyle.Underline);
            zenginMetinKutusu.SelectionFont = yeniFon;
            zenginMetinKutusu.Focus();
            menüBirimi6b3.CheckedChanged -= new EventHandler (menüBirimi6b3_ÇentikDeðiþti);
            menüBirimi6b3.Checked = çentikliMi;
            menüBirimi6b3.CheckedChanged += new EventHandler (menüBirimi6b3_ÇentikDeðiþti);
            araçÞeritDurumFiþi6d.Enabled = çentikliMi;
            if (!çentikliMi) araçÞeritDurumFiþi6d.Font = new Font (araçÞeritDurumFiþi6d.Font, araçÞeritDurumFiþi6d.Font.Style & ~FontStyle.Underline);
            else araçÞeritDurumFiþi6d.Font = new Font (araçÞeritDurumFiþi6d.Font, araçÞeritDurumFiþi6d.Font.Style | FontStyle.Underline);
        }
        private void araçÞeritDüðmesi6c_ÇentikDeðiþti (object k, EventArgs o) {
            ToolStripMenuItem birim = (ToolStripMenuItem)k;
            menüBirimi6c.Visible = birim.Checked;
        }
        private void araçÞeritTaraklýKutu_EndeksDeðiþti (object k, EventArgs o) {
            string metin = ((ToolStripComboBox)k).SelectedItem.ToString();
            Font yeniFon = null;
            if (zenginMetinKutusu.SelectionFont == null) yeniFon = new Font (metin, zenginMetinKutusu.Font.Size);
            else yeniFon = new Font (metin, zenginMetinKutusu.SelectionFont.Size, zenginMetinKutusu.SelectionFont.Style);
            zenginMetinKutusu.SelectionFont = yeniFon;
        }
        private void zenginMetinKutusu_MetinDeðiþti (object k, EventArgs o) {araçÞeritDurumFiþi6a.Text = "Toplam krk sayýsý: " + zenginMetinKutusu.Text.Length;}
        private void araçÞeritDurumFiþi6b_Týklandý (object k, EventArgs o) {araçÞeritDüðmesi6b1.Checked = !menüBirimi6b1.Checked;}
        private void araçÞeritDurumFiþi6c_Týklandý (object k, EventArgs o) {araçÞeritDüðmesi6b2.Checked = !menüBirimi6b2.Checked;}
        private void araçÞeritDurumFiþi6d_Týklandý (object k, EventArgs o) {araçÞeritDüðmesi6b3.Checked = !menüBirimi6b3.Checked;}
    }
//---------------------- Form7 ----------------------------------
    class Form7: Form {
        Panel panel;
        StatusBar durumÇubuðu;
        Label fiþ;
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
            //durumÇubuðu
            durumÇubuðu = new StatusBar();
            durumÇubuðu.Parent = this;
            durumÇubuðu.Text = "Durum çubuðu: M.Nihat Yavaþ";
            //fiþ
            fiþ = new Label();
            fiþ.Parent = panel;
            fiþ.Text = "Sol-Üst";
            fiþ.Location = new Point (0, 0);
            fiþ.AutoSize = true;
            fiþ = new Label();
            fiþ.Parent = panel;
            fiþ.Text = "Sað-Alt";
            fiþ.Location = new Point (250, 250);
            fiþ.AutoSize = true;
            //Form7
            Text="Form7: Panelli Form ve Statüçubuðu";
        }
    }
//---------------------- Form8 ----------------------------------
    public class Form8: Form {
        private StatusBar durumÇubuðu = new StatusBar();
        private StatusBarPanel durumÇubukPaneliA = new StatusBarPanel();
        private StatusBarPanel durumÇubukPaneliB = new StatusBarPanel();
        private Timer zamanlayýcý = new Timer();
        private MainMenu anaMenü;
        public Form8() {//Kurucu
            BileþeniBaþlat();
            zamanlayýcý.Interval = 1000; //1000mS=1S
            zamanlayýcý.Enabled = true;
            zamanlayýcý.Tick += new EventHandler (zamanlayýcý_Tikledi);
            MenuComplete += new EventHandler (DurumÇubuðu_Hazýr);
            AnamenüyüKur();
            DurumçubuðunuKur();
        }
        private void BileþeniBaþlat() {
            Size = new Size (300, 300);
            Text = "Form8: Anamenü ve Durumçubuðu";
            BackColor = Color.Tan;
        }
        private void zamanlayýcý_Tikledi (object k, EventArgs o) {
            DateTime tarih = DateTime.Now;
            string zaman = tarih.ToLongTimeString();
            durumÇubukPaneliB.Text = zaman;    
        }
        private void DurumÇubuðu_Hazýr (object k, EventArgs o) {durumÇubukPaneliA.Text = "Hazýr";}
        private void AnamenüyüKur() {
            anaMenü = new MainMenu();
            MenuItem menüBirimiA = anaMenü.MenuItems.Add ("&Dosya");
            menüBirimiA.MenuItems.Add (new MenuItem ("Çý&k", new EventHandler (Çýk_Týklandý), Shortcut.CtrlK)); //Önce Add, sonra [0] seç...
            menüBirimiA.MenuItems [0].Select += new EventHandler (Çýk_Seçildi);
            MenuItem menüBirimiB = anaMenü.MenuItems.Add ("&Yardm");
            menüBirimiB.MenuItems.Add (new MenuItem ("&Hakkýnda", new EventHandler (Hakkýnda_Týklandý),Shortcut.CtrlH)); //Önce Add, sonra [0] seç...
            menüBirimiB.MenuItems [0].Select += new EventHandler (Hakkýnda_Seçildi);
            Menu = anaMenü;      
        }
        private void Çýk_Seçildi (object k, EventArgs o) {durumÇubukPaneliA.Text = "Bu uygulamayý kapatýr";}
        private void Çýk_Týklandý(object k, EventArgs o) {Close();}
        private void Hakkýnda_Seçildi (object k, EventArgs o) {durumÇubukPaneliA.Text = "Uygulama açýklamasýný gösterir";}
        private void Hakkýnda_Týklandý (object k, EventArgs o) {durumÇubukPaneliA.Text = "Yardým";}
        private void DurumçubuðunuKur() {
            durumÇubuðu.ShowPanels = true;
            durumÇubuðu.Panels.AddRange (new StatusBarPanel[] {durumÇubukPaneliA, durumÇubukPaneliB});
            durumÇubukPaneliA.BorderStyle = StatusBarPanelBorderStyle.None;
            durumÇubukPaneliA.AutoSize = StatusBarPanelAutoSize.Spring;
            durumÇubukPaneliA.Width = 62;
            durumÇubukPaneliA.Text = "Hazýr";
            Icon ikon = new Icon ("resim/favikon.ico"); //Sadece ".ico" kabul edilmekte
            durumÇubukPaneliA.Icon = ikon;
            durumÇubukPaneliB.Alignment = HorizontalAlignment.Right;
            durumÇubukPaneliB.Width = 76;
            Controls.Add (durumÇubuðu);  
        }
    }
//---------------------- Form9 ----------------------------------
    class Form9: Form {
        StatusBarPanel durumçubukPaneliA, durumçubukPaneliB, durumçubukPaneliC;
        public Form9() {//Kurucu
            Size = new Size (300, 300);
            Text = "Form9: Yardým, Tarih ve Saat";
            BackColor = Color.Thistle;
            //durumçubukPaneliA
            durumçubukPaneliA = new StatusBarPanel();
            durumçubukPaneliA.Text = "Yardým menüsüne tahsisen...";
            durumçubukPaneliA.BorderStyle = StatusBarPanelBorderStyle.None;
            durumçubukPaneliA.AutoSize = StatusBarPanelAutoSize.Spring;
            //durumçubukPaneliB
            durumçubukPaneliB = new StatusBarPanel();
            durumçubukPaneliB.AutoSize = StatusBarPanelAutoSize.Contents;
            durumçubukPaneliB.ToolTipText = "Güncel tarih";
            //durumçubukPaneliC
            durumçubukPaneliC = new StatusBarPanel();
            durumçubukPaneliC.AutoSize = StatusBarPanelAutoSize.Contents;
            durumçubukPaneliC.ToolTipText = "Güncel zaman";
            //durumÇubuk
            StatusBar durumÇubuk = new StatusBar();
            durumÇubuk.Parent = this;
            durumÇubuk.ShowPanels = true;
            durumÇubuk.Panels.AddRange (new StatusBarPanel[] {durumçubukPaneliA, durumçubukPaneliB, durumçubukPaneliC});
            //zamanlayýcý
            Timer zamanlayýcý = new Timer();
            zamanlayýcý.Tick += new EventHandler (TikliZaman);
            zamanlayýcý.Interval = 1000; //1000mS=1S
            zamanlayýcý.Start();
        }
        void TikliZaman (object k, EventArgs o) {
            DateTime tarih = DateTime.Now;
            durumçubukPaneliB.Text = tarih.ToShortDateString();
            durumçubukPaneliC.Text = tarih.ToLongTimeString();
        }
    }
//==================================================================
    class Masked_RichTextBox_StatusBar {
        [STAThread]
        static void Main() {
            Console.Write ("Anamenüde seçimi girip, düðmeye týklatarak tamsayý çözümleme yapýp, seçilen forma geçiþ için anamenü saðüst X düðmeyle kapatýlmalýdýr.\nMaskelimetinkutusu öncelikle atanana kalýba uygun verigiriþini zorlar; örn.zaman için: 00:00:00, abd-pk için: 00000-9999, usd$ için: $00.00, ing-pk için: LCCC 9LL, tarih için: 00/00/0000, pin-kod için: 000-000-000 vb.\nRTF Controls.Add için: 'menü, araççubuðu, zenginmetin, durumçubuðu' sýralamasý bozuyor.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Application.EnableVisualStyles();
       baþ: AnaMenü anamenü=new AnaMenü(); Application.Run (anamenü);
            switch (anamenü.seç) {
                case 1: Application.Run (new Form1()); break; //Verili metin dosyayý basit editörle düzenler, kaydeder, yazdýrýr
                case 2: Application.Run (new Form2()); break; //MaskeliMetinKutuya düðme týklamalý çeþitli verigiriþleri
                case 3: Application.Run (new Form3()); break; //RichTextBox .rtf/RichTextFormat dosyalar yaratma, açma, kaydetme. Kontrol için ilk açýlýþ Kaydet (mny1.rtf), Yeni-->Kaydet (mny1.rtf), Aç-->Kaydet (mny1.rtf)
                case 4: Application.Run (new Form4()); break; //ZenginMetinKutu'ya dosya yükle-kaydet, stille (koyu, altçizgi, yatýk, ortala, ebatla)
                case 5: Application.Run (new Form5()); break; //RTF ithalet, düzenle, biçimle, imlece kaydýr
                case 6: Application.Run (new Form6()); break; //RTF, menü, araççubuðu ve durumçubuðu
                case 7: Application.Run (new Form7()); break; //Panel, kaydýrmaçubuklarý ve durumçubuðu
                case 8: Application.Run (new Form8()); break; //Anamenü: Dosya-Çýk, Yardým-Hakkýnda; durumçubuðu: ikonlu statüler ve zaman
                case 9: Application.Run (new Form9()); break; //Durumçubukta yardým, tarih ve saat bilgileri
                default: goto son;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}