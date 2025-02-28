// j2sc#2301g.cs: Paint'le yazma ve MDI'yla basamakl�-dikey-yatay serilimler �rne�i.

using System;
using System.Windows.Forms; //:Form i�in
using System.Drawing; //PaintEventArgs i�in
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
            g.DrawString ("M.Nihat Yava�", new Font ("Times New Roman", 30), Brushes.Brown, 50, 60);
        }
    }
    public class Form2: Form {
        private Button d��me2;
        public Form2() {//Kurucu
            Size = new Size (500, 200);
            BackColor=Color.YellowGreen;
            Text = "Form2: Saat";
            d��me2 = new Button();
            d��me2.Parent = this; //'Controls.Add(d��me2)' yerine
            d��me2.Location = new Point (200, 25);
            d��me2.Text = "Saat ka�?";
            d��me2.BackColor=Color.Wheat;
            d��me2.Click += new EventHandler (d��me2_T�kland�);
        }
        protected override void OnPaint (PaintEventArgs o) {//Form OnPaint Override
            base.OnPaint (o);
            Graphics g = o.Graphics;
            String tarih = "\nG�ncel saat: " + DateTime.Now.ToLongTimeString();
            g.DrawString (tarih, new Font ("Times New Roman", 30), Brushes.DarkRed, 50, 65);
        }
        private void d��me2_T�kland� (object k, EventArgs o) {Invalidate();}
    }
    public class Form3a: Form {//Yavru formlar t�klan�nca renk de�i�tirir
        public Form3a() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {Click += new EventHandler (Form3a_T�kland�);}
        private void Form3a_T�kland� (object k, EventArgs o) {
            int kr, y�, mv;
            Random r = new Random();
            kr = r.Next (0, 255);
            y� = r.Next (0, 255);
            mv = r.Next (0, 255);
            Color yeniRenk = Color.FromArgb (kr, y�, mv); //(k�rm�z�,ye�il,mavi)
            BackColor = yeniRenk;
            Text = yeniRenk.ToString();
        }
    }
    public class Form3b: Form {//MDI:MenuDevelopementInterface
        private MenuStrip men��eriti;
        private ToolStripMenuItem tsmi_Dosya;
        private ToolStripMenuItem tsmi_Yeni;
        private ToolStripMenuItem tsmi_��k;
        private ToolStripMenuItem tsmi_Pencereler;
        private ToolStripMenuItem tsmi_D�zenle;
        private ToolStripMenuItem tsmi_Basamakl�;
        private ToolStripMenuItem tsmi_Dikey;
        private ToolStripMenuItem tsmi_Yatay;
        public Form3b() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            men��eriti = new MenuStrip();
            tsmi_Dosya = new ToolStripMenuItem();
            tsmi_Yeni = new ToolStripMenuItem();
            tsmi_��k = new ToolStripMenuItem();
            tsmi_Pencereler = new ToolStripMenuItem();
            tsmi_D�zenle = new ToolStripMenuItem();
            tsmi_Basamakl� = new ToolStripMenuItem();
            tsmi_Dikey = new ToolStripMenuItem();
            tsmi_Yatay = new ToolStripMenuItem();
            men��eriti.SuspendLayout();
            SuspendLayout();
            // men��eriti
            men��eriti.Items.AddRange (new ToolStripItem[] {tsmi_Dosya, tsmi_Pencereler, tsmi_D�zenle});
            men��eriti.Location = new Point (0, 0);
            men��eriti.MdiWindowListItem = tsmi_Pencereler;
            men��eriti.Name = "men��eriti";
            men��eriti.Size = new Size (440, 24);
            men��eriti.TabIndex = 2;
            men��eriti.Text = "men��eriti";
            // tsmi_Dosya 
            tsmi_Dosya.DropDownItems.AddRange (new ToolStripItem[] {tsmi_Yeni,tsmi_��k});
            tsmi_Dosya.Name = "tsmi_Dosya";
            tsmi_Dosya.Text = "&Dosya";
            tsmi_Yeni.Name = "tsmi_Yeni";
            tsmi_Yeni.Text = "&Yeni Pencere";
            tsmi_Yeni.Click += new EventHandler (tsmi_Yeni_T�kland�);
            tsmi_��k.Name = "tsmi_��k";
            tsmi_��k.Text = "&��k"; //T�m program� kapar
            tsmi_��k.Click += new EventHandler (tsmi_��k_T�kland�);
            // tsmi_Pencereler
            tsmi_Pencereler.Name = "tsmi_Pencereler";
            tsmi_Pencereler.Text = "&Pencereler";
            // tsmi_D�zenle 
            tsmi_D�zenle.DropDownItems.AddRange (new ToolStripItem[] {tsmi_Basamakl�, tsmi_Dikey, tsmi_Yatay});
            tsmi_D�zenle.Name = "tsmi_D�zenle";
            tsmi_D�zenle.Text = "Pen&cereleri D�zenle";
            tsmi_Basamakl�.Name = "tsmi_Basamakl�";
            tsmi_Basamakl�.Text = "&Basamakl�";
            tsmi_Basamakl�.Click += new EventHandler (tsmi_Basamakl�_T�kland�); 
            tsmi_Dikey.Name = "tsmi_Dikey";
            tsmi_Dikey.Text = "Di&key";
            tsmi_Dikey.Click += new EventHandler (tsmi_Dikey_T�kland�);
            tsmi_Yatay.Name = "tsmi_Yatay";
            tsmi_Yatay.Text = "Ya&tay";
            tsmi_Yatay.Click += new EventHandler (tsmi_Yatay_T�kland�);
            // Form3b
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (440, 238);
            Controls.Add (men��eriti);
            IsMdiContainer = true;
            Name = "Form3b";
            Text = "MDI Uygulamas�";
            men��eriti.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
            //BackColor=Color.Indigo; //MDI bukomutu takm�yor
        }
        private void tsmi_Yeni_T�kland� (object k, EventArgs o) {
            Form3a yavruPencere = new Form3a();
            yavruPencere.MdiParent = this;
            yavruPencere.Show();
        }
        private void tsmi_��k_T�kland� (object k, EventArgs o) {Application.Exit();}
        private void tsmi_Basamakl�_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.Cascade);}
        private void tsmi_Dikey_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.TileVertical);}
        private void tsmi_Yatay_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.TileHorizontal);}
    }
    class Form4a: Form {//Ebeveyn
        public Form4a() {//Kurucu
            Bile�eniBa�lat();
            Form4b yavru = new Form4b (this);
            yavru.Show();
        }
        private void Bile�eniBa�lat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            //BackColor=Color.Indigo; //MDI bukomutu takm�yor
            IsMdiContainer = true;
            Name = "Form4a";
            Text = "Form4a";
            WindowState = FormWindowState.Maximized; //B�y�k MDI ebeveyn pencere i�inde k���k hotpink yavru pencere
        }
    }
    class Form4b: Form {//Yavru
        public Form4b (Form4a ebeveyn) {//Kurucu
            Bile�eniBa�lat();
            MdiParent = ebeveyn;
        }
        private void Bile�eniBa�lat() {
            Text = "Form4b";
            BackColor=Color.DeepPink;
        }
    }
    public partial class Form5a: Form {//Yavru
        public Form5a() {Bile�eniBa�lat();} //Kurucu
        private void k�rm�z�Zemin_T�kland� (object k, EventArgs o) {BackColor = Color.Red;}
        private void maviZemin_T�kland� (object k, EventArgs o) {BackColor = Color.Blue;}
        private void ye�ilZemin_T�kland� (object k, EventArgs o) {BackColor = Color.Green;}
        public void Sakla() {MessageBox.Show ("Veriler sakland�!");} //Form5b men�birimi
    }
    partial class Form5a {
        private MenuStrip men��eridi;
        private ToolStripMenuItem �zel;
        private ToolStripMenuItem k�rm�z�Zemin;
        private ToolStripMenuItem maviZemin;
        private ToolStripMenuItem ye�ilZemin;
        private void Bile�eniBa�lat() {
            men��eridi = new MenuStrip();
            �zel = new ToolStripMenuItem();
            k�rm�z�Zemin = new ToolStripMenuItem();
            maviZemin = new ToolStripMenuItem();
            ye�ilZemin = new ToolStripMenuItem();
            men��eridi.SuspendLayout();
            SuspendLayout();
            // men��eridi
            men��eridi.Items.AddRange (new ToolStripItem[] {�zel});
            men��eridi.Location = new Point (0, 0);
            men��eridi.Name = "men��eridi";
            men��eridi.Size = new Size (534, 24);
            men��eridi.TabIndex = 0;
            men��eridi.Text = "men��eridi";
            // �zel
            �zel.DropDownItems.AddRange (new ToolStripItem[] {
                k�rm�z�Zemin,
                maviZemin,
                ye�ilZemin});
            �zel.Name = "�zel";
            �zel.Text = "&�zel";
            // k�rm�z�Zemin
            //k�rm�z�Zemin.ImageTransparentColor = Color.Magenta;
            k�rm�z�Zemin.Name = "k�rm�z�Zemin";
            k�rm�z�Zemin.Text = "K�rm�z�ya Boya";
            k�rm�z�Zemin.Click += new EventHandler (k�rm�z�Zemin_T�kland�);
            // maviZemin
            //maviZemin.ImageTransparentColor = Color.Magenta;
            maviZemin.Name = "maviZemin";
            maviZemin.Text = "Maviye Boya";
            maviZemin.Click += new EventHandler (maviZemin_T�kland�);
            // ye�ilZemin
            //ye�ilZemin.ImageTransparentColor = Color.Magenta;
            ye�ilZemin.Name = "ye�ilZemin";
            ye�ilZemin.Text = "Ye�ile Boya";
            ye�ilZemin.Click += new EventHandler (ye�ilZemin_T�kland�);
            // Form5a
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (534, 541);
            Controls.Add (men��eridi);
            MainMenuStrip = men��eridi;
            Name = "Form5a";
            Text = "Form5a";
            men��eridi.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public partial class Form5b: Form {//Ebeveyn
        public Form5b() {Bile�eniBa�lat();} //Kurucu
        private void dosya_SarkanMen� (object k, EventArgs o) {
            if (MdiChildren.Length == 0) sakla.Enabled = false;
            else sakla.Enabled = true;
        }
        private void yeni_T�kland� (object k, EventArgs o) {
            Form5a yavru = new Form5a();
            yavru.MdiParent = this;
            yavru.Show();
        }
        private void sakla_T�kland� (object k, EventArgs o) {
            Form5a sakla = (Form5a)ActiveMdiChild;
            sakla.Sakla(); //Metot Form5a i�inde
        }
    }
    partial class Form5b {
        private MenuStrip men��eridi;
        private ToolStripMenuItem dosya;
        private ToolStripMenuItem yeni;
        private ToolStripMenuItem sakla;
        private ToolStripSeparator yatayAyra�;
        private ToolStripMenuItem ��k;
        private void Bile�eniBa�lat() {
            men��eridi = new MenuStrip();
            dosya = new ToolStripMenuItem();
            yatayAyra� = new ToolStripSeparator();
            yeni = new ToolStripMenuItem();
            sakla = new ToolStripMenuItem();
            ��k = new ToolStripMenuItem();
            men��eridi.SuspendLayout();
            SuspendLayout();
            // men��eridi
            men��eridi.Items.AddRange (new ToolStripItem[] {dosya});
            men��eridi.Location = new Point (0, 0);
            men��eridi.Name = "men��eridi";
            men��eridi.Size = new Size (576, 24);
            men��eridi.TabIndex = 0;
            men��eridi.Text = "men��eridi";
            // dosya
            dosya.DropDownItems.AddRange (new ToolStripItem[] {
                yeni,
                sakla,
                yatayAyra�,
                ��k});
            dosya.Name = "dosya";
            dosya.Text = "&Dosya";
            dosya.DropDownOpening += new EventHandler (dosya_SarkanMen�);
            // yatayAyra�
            yatayAyra�.Name = "yatayAyra�";
            // yeni
            //yeni.ImageTransparentColor = Color.Magenta;
            yeni.Name = "yeni";
            yeni.Text = "&Yeni";
            yeni.Click += new EventHandler (yeni_T�kland�);
            // sakla
            //sakla.ImageTransparentColor = Color.Magenta;
            sakla.Name = "sakla";
            sakla.Text = "&Sakla";
            sakla.Click += new EventHandler (sakla_T�kland�);
            // ��k
            //��k.ImageTransparentColor = Color.Magenta;
            ��k.Name = "��k";
            ��k.Text = "&��k"; //��k t�klama olay's�z
            // Form5b
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (576, 438);
            Controls.Add (men��eridi);
            IsMdiContainer = true;
            MainMenuStrip = men��eridi;
            Name = "Form5b";
            Text = "Form5b MDI";
            men��eridi.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public class Form6a: Form {//Ebeveyn
        private MainMenu anaMen�;
        private MenuItem dosya;
        private MenuItem yeni;
        private MenuItem ��k;
        private MenuItem pencere;
        private MenuItem d�zenle;
        private MenuItem basamakl�;
        private MenuItem dikey;
        private MenuItem yatay;
        //
        public Form6a() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            anaMen� = new MainMenu();
            dosya = new MenuItem();
            yeni = new MenuItem();
            ��k = new MenuItem();
            pencere = new MenuItem();
            d�zenle = new MenuItem();
            basamakl� = new MenuItem();
            dikey = new MenuItem();
            yatay = new MenuItem();
            // 
            anaMen�.MenuItems.AddRange (new MenuItem[] {dosya, pencere, d�zenle});
            // 
            dosya.Index = 0;
            dosya.MenuItems.AddRange (new MenuItem[] {yeni, ��k});
            dosya.Text = "&Dosya";
            // 
            yeni.Index = 0;
            yeni.Text = "&Yeni";
            yeni.Click += new EventHandler (yeni_T�kland�);
            // 
            ��k.Index = 1;
            ��k.Text = "&��k";
            ��k.Click += new EventHandler (��k_T�kland�);
            // 
            pencere.Index = 1;
            pencere.MdiList = true;
            pencere.Text = "&Pencere";
            // 
            d�zenle.Index = 2;
            d�zenle.MenuItems.AddRange (new MenuItem[] {basamakl�, dikey, yatay});
            d�zenle.Text = "Pencere D�&zeni";
            // 
            basamakl�.Index = 0;
            basamakl�.Text = "&Basamakl�";
            basamakl�.Click += new EventHandler (basamakl�_T�kland�);
            // 
            dikey.Index = 1;
            dikey.Text = "&Dikey";
            dikey.Click += new EventHandler (dikey_T�kland�);
            // 
            yatay.Index = 2;
            yatay.Text = "&Yatay";
            yatay.Click += new EventHandler (yatay_T�kland�);
            // 
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 269);
            IsMdiContainer = true;
            Menu = anaMen�;
            Name = "Form6a";
            Text = "Form6b MDI";
        }
        private void ��k_T�kland� (object k, EventArgs o) {Close();}
        private void basamakl�_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.Cascade);}
        private void dikey_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.TileVertical);}
        private void yatay_T�kland� (object k, EventArgs o) {LayoutMdi (MdiLayout.TileHorizontal);}
        private void yeni_T�kland� (object k, EventArgs o) {
            Form6b yavru = new Form6b();
            yavru.MdiParent = this;
            yavru.Show();    
        }
    }
    public class Form6b: Form {//Yavru
        public Form6b() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 269);
        }
    }
    class Paint_MDI {
        static void Main() {
            Console.Write ("'override void OnPaint(PaintEventArgs olay){...}' Form'u �zelle�tirir; d��me t�klamal� 'Invalidate()' �ncekini ge�ersizleyip g�ncel OnPaint �al��t�r�r. 'LayoutMdi (MdiLayout.Cascade/TileVertical/TileHorizontal)' mevcut t�m yavru pencereleri basamakl�/dikey/yatay serimler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Pant'le yazma, MDI'yla �oklu pencere serilimleri:");
            Application.Run (new Form1());
            Application.Run (new Form2());
            Application.EnableVisualStyles(); Application.Run (new Form3b());
            Application.Run (new Form4a());
            Application.Run (new Form5b());
            Application.Run (new Form6a());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}