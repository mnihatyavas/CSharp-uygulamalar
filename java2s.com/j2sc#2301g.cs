// j2sc#2301g.cs: Paint'le yazma ve MDI'yla basamaklý-dikey-yatay serilimler örneði.

using System;
using System.Windows.Forms; //:Form için
using System.Drawing; //PaintEventArgs için
namespace Formlar {
    public class Form1: Form {
        public Form1() {//Kurucu
            Text = "Form1: Boya";
            Size = new Size (400, 200);
            BackColor=Color.Fuchsia;
        }
        protected override void OnPaint (PaintEventArgs o) {//Form OnPaint Override
            base.OnPaint (o);
            Graphics g = o.Graphics;
            g.DrawString ("www.java2s.com", Font, Brushes.Blue, 50, 30);
            g.DrawString ("M.Nihat Yavaþ", new Font ("Times New Roman", 30), Brushes.Brown, 50, 60);
        }
    }
    public class Form2: Form {
        private Button düðme2;
        public Form2() {//Kurucu
            Size = new Size (500, 200);
            BackColor=Color.YellowGreen;
            Text = "Form2: Saat";
            düðme2 = new Button();
            düðme2.Parent = this; //'Controls.Add(düðme2)' yerine
            düðme2.Location = new Point (200, 25);
            düðme2.Text = "Saat kaç?";
            düðme2.BackColor=Color.Wheat;
            düðme2.Click += new EventHandler (düðme2_Týklandý);
        }
        protected override void OnPaint (PaintEventArgs o) {//Form OnPaint Override
            base.OnPaint (o);
            Graphics g = o.Graphics;
            String tarih = "\nGüncel saat: " + DateTime.Now.ToLongTimeString();
            g.DrawString (tarih, new Font ("Times New Roman", 30), Brushes.DarkRed, 50, 65);
        }
        private void düðme2_Týklandý (object k, EventArgs o) {Invalidate();}
    }
    public class Form3a: Form {//Yavru formlar týklanýnca renk deðiþtirir
        public Form3a() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {Click += new EventHandler (Form3a_Týklandý);}
        private void Form3a_Týklandý (object k, EventArgs o) {
            int kr, yþ, mv;
            Random r = new Random();
            kr = r.Next (0, 255);
            yþ = r.Next (0, 255);
            mv = r.Next (0, 255);
            Color yeniRenk = Color.FromArgb (kr, yþ, mv); //(kýrmýzý,yeþil,mavi)
            BackColor = yeniRenk;
            Text = yeniRenk.ToString();
        }
    }
    public class Form3b: Form {//MDI:MenuDevelopementInterface
        private MenuStrip menüÞeriti;
        private ToolStripMenuItem tsmi_Dosya;
        private ToolStripMenuItem tsmi_Yeni;
        private ToolStripMenuItem tsmi_Çýk;
        private ToolStripMenuItem tsmi_Pencereler;
        private ToolStripMenuItem tsmi_Düzenle;
        private ToolStripMenuItem tsmi_Basamaklý;
        private ToolStripMenuItem tsmi_Dikey;
        private ToolStripMenuItem tsmi_Yatay;
        public Form3b() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            menüÞeriti = new MenuStrip();
            tsmi_Dosya = new ToolStripMenuItem();
            tsmi_Yeni = new ToolStripMenuItem();
            tsmi_Çýk = new ToolStripMenuItem();
            tsmi_Pencereler = new ToolStripMenuItem();
            tsmi_Düzenle = new ToolStripMenuItem();
            tsmi_Basamaklý = new ToolStripMenuItem();
            tsmi_Dikey = new ToolStripMenuItem();
            tsmi_Yatay = new ToolStripMenuItem();
            menüÞeriti.SuspendLayout();
            SuspendLayout();
            // menüÞeriti
            menüÞeriti.Items.AddRange (new ToolStripItem[] {tsmi_Dosya, tsmi_Pencereler, tsmi_Düzenle});
            menüÞeriti.Location = new Point (0, 0);
            menüÞeriti.MdiWindowListItem = tsmi_Pencereler;
            menüÞeriti.Name = "menüÞeriti";
            menüÞeriti.Size = new Size (440, 24);
            menüÞeriti.TabIndex = 2;
            menüÞeriti.Text = "menüÞeriti";
            // tsmi_Dosya 
            tsmi_Dosya.DropDownItems.AddRange (new ToolStripItem[] {tsmi_Yeni,tsmi_Çýk});
            tsmi_Dosya.Name = "tsmi_Dosya";
            tsmi_Dosya.Text = "&Dosya";
            tsmi_Yeni.Name = "tsmi_Yeni";
            tsmi_Yeni.Text = "&Yeni Pencere";
            tsmi_Yeni.Click += new EventHandler (tsmi_Yeni_Týklandý);
            tsmi_Çýk.Name = "tsmi_Çýk";
            tsmi_Çýk.Text = "&Çýk"; //Tüm programý kapar
            tsmi_Çýk.Click += new EventHandler (tsmi_Çýk_Týklandý);
            // tsmi_Pencereler
            tsmi_Pencereler.Name = "tsmi_Pencereler";
            tsmi_Pencereler.Text = "&Pencereler";
            // tsmi_Düzenle 
            tsmi_Düzenle.DropDownItems.AddRange (new ToolStripItem[] {tsmi_Basamaklý, tsmi_Dikey, tsmi_Yatay});
            tsmi_Düzenle.Name = "tsmi_Düzenle";
            tsmi_Düzenle.Text = "Pen&cereleri Düzenle";
            tsmi_Basamaklý.Name = "tsmi_Basamaklý";
            tsmi_Basamaklý.Text = "&Basamaklý";
            tsmi_Basamaklý.Click += new EventHandler (tsmi_Basamaklý_Týklandý); 
            tsmi_Dikey.Name = "tsmi_Dikey";
            tsmi_Dikey.Text = "Di&key";
            tsmi_Dikey.Click += new EventHandler (tsmi_Dikey_Týklandý);
            tsmi_Yatay.Name = "tsmi_Yatay";
            tsmi_Yatay.Text = "Ya&tay";
            tsmi_Yatay.Click += new EventHandler (tsmi_Yatay_Týklandý);
            // Form3b
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (440, 238);
            Controls.Add (menüÞeriti);
            IsMdiContainer = true;
            Name = "Form3b";
            Text = "MDI Uygulamasý";
            menüÞeriti.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
            //BackColor=Color.Indigo; //MDI bukomutu takmýyor
        }
        private void tsmi_Yeni_Týklandý (object k, EventArgs o) {
            Form3a yavruPencere = new Form3a();
            yavruPencere.MdiParent = this;
            yavruPencere.Show();
        }
        private void tsmi_Çýk_Týklandý (object k, EventArgs o) {Application.Exit();}
        private void tsmi_Basamaklý_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.Cascade);}
        private void tsmi_Dikey_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.TileVertical);}
        private void tsmi_Yatay_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.TileHorizontal);}
    }
    class Form4a: Form {//Ebeveyn
        public Form4a() {//Kurucu
            BileþeniBaþlat();
            Form4b yavru = new Form4b (this);
            yavru.Show();
        }
        private void BileþeniBaþlat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            //BackColor=Color.Indigo; //MDI bukomutu takmýyor
            IsMdiContainer = true;
            Name = "Form4a";
            Text = "Form4a";
            WindowState = FormWindowState.Maximized; //Büyük MDI ebeveyn pencere içinde küçük hotpink yavru pencere
        }
    }
    class Form4b: Form {//Yavru
        public Form4b (Form4a ebeveyn) {//Kurucu
            BileþeniBaþlat();
            MdiParent = ebeveyn;
        }
        private void BileþeniBaþlat() {
            Text = "Form4b";
            BackColor=Color.DeepPink;
        }
    }
    public partial class Form5a: Form {//Yavru
        public Form5a() {BileþeniBaþlat();} //Kurucu
        private void kýrmýzýZemin_Týklandý (object k, EventArgs o) {BackColor = Color.Red;}
        private void maviZemin_Týklandý (object k, EventArgs o) {BackColor = Color.Blue;}
        private void yeþilZemin_Týklandý (object k, EventArgs o) {BackColor = Color.Green;}
        public void Sakla() {MessageBox.Show ("Veriler saklandý!");} //Form5b menübirimi
    }
    partial class Form5a {
        private MenuStrip menüþeridi;
        private ToolStripMenuItem özel;
        private ToolStripMenuItem kýrmýzýZemin;
        private ToolStripMenuItem maviZemin;
        private ToolStripMenuItem yeþilZemin;
        private void BileþeniBaþlat() {
            menüþeridi = new MenuStrip();
            özel = new ToolStripMenuItem();
            kýrmýzýZemin = new ToolStripMenuItem();
            maviZemin = new ToolStripMenuItem();
            yeþilZemin = new ToolStripMenuItem();
            menüþeridi.SuspendLayout();
            SuspendLayout();
            // menüþeridi
            menüþeridi.Items.AddRange (new ToolStripItem[] {özel});
            menüþeridi.Location = new Point (0, 0);
            menüþeridi.Name = "menüþeridi";
            menüþeridi.Size = new Size (534, 24);
            menüþeridi.TabIndex = 0;
            menüþeridi.Text = "menüþeridi";
            // özel
            özel.DropDownItems.AddRange (new ToolStripItem[] {
                kýrmýzýZemin,
                maviZemin,
                yeþilZemin});
            özel.Name = "özel";
            özel.Text = "&Özel";
            // kýrmýzýZemin
            //kýrmýzýZemin.ImageTransparentColor = Color.Magenta;
            kýrmýzýZemin.Name = "kýrmýzýZemin";
            kýrmýzýZemin.Text = "Kýrmýzýya Boya";
            kýrmýzýZemin.Click += new EventHandler (kýrmýzýZemin_Týklandý);
            // maviZemin
            //maviZemin.ImageTransparentColor = Color.Magenta;
            maviZemin.Name = "maviZemin";
            maviZemin.Text = "Maviye Boya";
            maviZemin.Click += new EventHandler (maviZemin_Týklandý);
            // yeþilZemin
            //yeþilZemin.ImageTransparentColor = Color.Magenta;
            yeþilZemin.Name = "yeþilZemin";
            yeþilZemin.Text = "Yeþile Boya";
            yeþilZemin.Click += new EventHandler (yeþilZemin_Týklandý);
            // Form5a
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (534, 541);
            Controls.Add (menüþeridi);
            MainMenuStrip = menüþeridi;
            Name = "Form5a";
            Text = "Form5a";
            menüþeridi.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public partial class Form5b: Form {//Ebeveyn
        public Form5b() {BileþeniBaþlat();} //Kurucu
        private void dosya_SarkanMenü (object k, EventArgs o) {
            if (MdiChildren.Length == 0) sakla.Enabled = false;
            else sakla.Enabled = true;
        }
        private void yeni_Týklandý (object k, EventArgs o) {
            Form5a yavru = new Form5a();
            yavru.MdiParent = this;
            yavru.Show();
        }
        private void sakla_Týklandý (object k, EventArgs o) {
            Form5a sakla = (Form5a)ActiveMdiChild;
            sakla.Sakla(); //Metot Form5a içinde
        }
    }
    partial class Form5b {
        private MenuStrip menüþeridi;
        private ToolStripMenuItem dosya;
        private ToolStripMenuItem yeni;
        private ToolStripMenuItem sakla;
        private ToolStripSeparator yatayAyraç;
        private ToolStripMenuItem çýk;
        private void BileþeniBaþlat() {
            menüþeridi = new MenuStrip();
            dosya = new ToolStripMenuItem();
            yatayAyraç = new ToolStripSeparator();
            yeni = new ToolStripMenuItem();
            sakla = new ToolStripMenuItem();
            çýk = new ToolStripMenuItem();
            menüþeridi.SuspendLayout();
            SuspendLayout();
            // menüþeridi
            menüþeridi.Items.AddRange (new ToolStripItem[] {dosya});
            menüþeridi.Location = new Point (0, 0);
            menüþeridi.Name = "menüþeridi";
            menüþeridi.Size = new Size (576, 24);
            menüþeridi.TabIndex = 0;
            menüþeridi.Text = "menüþeridi";
            // dosya
            dosya.DropDownItems.AddRange (new ToolStripItem[] {
                yeni,
                sakla,
                yatayAyraç,
                çýk});
            dosya.Name = "dosya";
            dosya.Text = "&Dosya";
            dosya.DropDownOpening += new EventHandler (dosya_SarkanMenü);
            // yatayAyraç
            yatayAyraç.Name = "yatayAyraç";
            // yeni
            //yeni.ImageTransparentColor = Color.Magenta;
            yeni.Name = "yeni";
            yeni.Text = "&Yeni";
            yeni.Click += new EventHandler (yeni_Týklandý);
            // sakla
            //sakla.ImageTransparentColor = Color.Magenta;
            sakla.Name = "sakla";
            sakla.Text = "&Sakla";
            sakla.Click += new EventHandler (sakla_Týklandý);
            // çýk
            //çýk.ImageTransparentColor = Color.Magenta;
            çýk.Name = "çýk";
            çýk.Text = "&Çýk"; //Çýk týklama olay'sýz
            // Form5b
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (576, 438);
            Controls.Add (menüþeridi);
            IsMdiContainer = true;
            MainMenuStrip = menüþeridi;
            Name = "Form5b";
            Text = "Form5b MDI";
            menüþeridi.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public class Form6a: Form {//Ebeveyn
        private MainMenu anaMenü;
        private MenuItem dosya;
        private MenuItem yeni;
        private MenuItem çýk;
        private MenuItem pencere;
        private MenuItem düzenle;
        private MenuItem basamaklý;
        private MenuItem dikey;
        private MenuItem yatay;
        //
        public Form6a() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            anaMenü = new MainMenu();
            dosya = new MenuItem();
            yeni = new MenuItem();
            çýk = new MenuItem();
            pencere = new MenuItem();
            düzenle = new MenuItem();
            basamaklý = new MenuItem();
            dikey = new MenuItem();
            yatay = new MenuItem();
            // 
            anaMenü.MenuItems.AddRange (new MenuItem[] {dosya, pencere, düzenle});
            // 
            dosya.Index = 0;
            dosya.MenuItems.AddRange (new MenuItem[] {yeni, çýk});
            dosya.Text = "&Dosya";
            // 
            yeni.Index = 0;
            yeni.Text = "&Yeni";
            yeni.Click += new EventHandler (yeni_Týklandý);
            // 
            çýk.Index = 1;
            çýk.Text = "&Çýk";
            çýk.Click += new EventHandler (çýk_Týklandý);
            // 
            pencere.Index = 1;
            pencere.MdiList = true;
            pencere.Text = "&Pencere";
            // 
            düzenle.Index = 2;
            düzenle.MenuItems.AddRange (new MenuItem[] {basamaklý, dikey, yatay});
            düzenle.Text = "Pencere Dü&zeni";
            // 
            basamaklý.Index = 0;
            basamaklý.Text = "&Basamaklý";
            basamaklý.Click += new EventHandler (basamaklý_Týklandý);
            // 
            dikey.Index = 1;
            dikey.Text = "&Dikey";
            dikey.Click += new EventHandler (dikey_Týklandý);
            // 
            yatay.Index = 2;
            yatay.Text = "&Yatay";
            yatay.Click += new EventHandler (yatay_Týklandý);
            // 
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 269);
            IsMdiContainer = true;
            Menu = anaMenü;
            Name = "Form6a";
            Text = "Form6b MDI";
        }
        private void çýk_Týklandý (object k, EventArgs o) {Close();}
        private void basamaklý_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.Cascade);}
        private void dikey_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.TileVertical);}
        private void yatay_Týklandý (object k, EventArgs o) {LayoutMdi (MdiLayout.TileHorizontal);}
        private void yeni_Týklandý (object k, EventArgs o) {
            Form6b yavru = new Form6b();
            yavru.MdiParent = this;
            yavru.Show();    
        }
    }
    public class Form6b: Form {//Yavru
        public Form6b() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 269);
        }
    }
    class Paint_MDI {
        static void Main() {
            Console.Write ("'override void OnPaint(PaintEventArgs olay){...}' Form'u özelleþtirir; düðme týklamalý 'Invalidate()' öncekini geçersizleyip güncel OnPaint çalýþtýrýr. 'LayoutMdi (MdiLayout.Cascade/TileVertical/TileHorizontal)' mevcut tüm yavru pencereleri basamaklý/dikey/yatay serimler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Pant'le yazma, MDI'yla çoklu pencere serilimleri:");
            Application.Run (new Form1());
            Application.Run (new Form2());
            Application.EnableVisualStyles(); Application.Run (new Form3b());
            Application.Run (new Form4a());
            Application.Run (new Form5b());
            Application.Run (new Form6a());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}