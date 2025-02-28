// j2sc#2301c.cs: Form, düðme, etiket, menü, çöpe, imleç örneði.

using System;
using System.Windows.Forms; //:Form için
using System.Drawing; //Color için
using System.Drawing.Drawing2D; //GraphicsPath için
using System.ComponentModel; //Container için
namespace Formlar {
    public class Form1: Form {
        private Button düðme1a;
        private Button düðme1b;
        protected Label etiket1;
        public Form1() {//Kurucu
            düðme1a = new Button();
            düðme1a.Location = new Point (25, 100);
            düðme1a.Size = new Size (100, 25);
            düðme1a.Text = "&Çýk"; //Alt-ç
            düðme1a.Click += new EventHandler (düðme1a_Týklandý);
            düðme1b = new Button();
            düðme1b.Location = new Point (200, 100);
            düðme1b.Size = new Size (150, 25);
            düðme1b.Text = "&Uygula"; //Alt-u
            düðme1b.Click += new EventHandler (düðme1b_Týklandý);
            etiket1 = new Label();
            etiket1.Location = new Point (25, 25);
            etiket1.Size = new Size (150, 25);
            etiket1.Text = "Form1'in açýklama etiketi";
            Controls.AddRange (new Control[]{etiket1, düðme1a, düðme1b});
            BackColor = Color.Magenta;
        }
        private void düðme1a_Týklandý (object kim, EventArgs oly) {Application.Exit();}
        private void düðme1b_Týklandý (object kim, EventArgs oly) {
            MessageBox.Show ("Bu, Form1 uygulamasýdýr.");
            BirMetot();
        }
        protected virtual void BirMetot() {MessageBox.Show ("Bu, Form1'den çaðrýlan BirMetot()'dur.");}
    }
    public class Form2: Form1 {
        private Button düðme2;
        public Form2() {//Kurucu
            düðme2 = new Button();
            düðme2.Location = new Point (25, 150);
            düðme2.Size = new Size (125, 25);
            düðme2.Text = "Çý&k"; //Alt-k
            düðme2.Click += new EventHandler (düðme2_Týklandý);
            Controls.Add (düðme2);
            etiket1.Text = "Form2'deki etiket";
            BackColor = Color.LightBlue;
        }
        private void düðme2_Týklandý (object k, EventArgs o) {Application.Exit();}
        protected override void BirMetot() {MessageBox.Show ("Bu, Form1'dekini geçersizleyen Form2'deki BirMetot()'dur.");}
    }
    public class Form3: Form {
        private Button düðme3= new Button();
        private Label etiket3 = new Label();
        private bool sürükleniyorMu;
        private Point týklananNokta;
        public Form3() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            SuspendLayout();
            düðme3.Location = new Point (102, 215);
            düðme3.Name = "düðme3";
            düðme3.Size = new Size (76, 20);
            düðme3.TabIndex = 5;
            düðme3.Text = "&Kapat";
            düðme3.Click += new EventHandler (düðme3_Týklandý); 
            etiket3.BackColor = Color.Navy;
            etiket3.BorderStyle = BorderStyle.Fixed3D;
            etiket3.Font = new Font ("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            etiket3.ForeColor = Color.Red;
            etiket3.Location = new Point (74, 167);
            etiket3.Name = "etiket3";
            etiket3.Size = new Size (140, 36);
            etiket3.TabIndex = 4;
            etiket3.Text = "Formu sürüklemek için burayý SOL basýlý tut!";
            etiket3.MouseDown += new MouseEventHandler (etiket3_FareBasýlý);
            etiket3.MouseMove += new MouseEventHandler(etiket3_FareTaþýnýyor);
            etiket3.MouseUp += new MouseEventHandler (etiket3_FareSerbest);
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            ControlBox = false;
            Controls.Add (düðme3);
            Controls.Add (etiket3);
            Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ResumeLayout (false);
            BackColor = Color.Pink;
        }
        private void düðme3_Týklandý (object k, EventArgs o) {Close();}
        private void etiket3_FareBasýlý (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Left) {
                sürükleniyorMu = true;
                týklananNokta = new Point (o.X, o.Y);
            }else sürükleniyorMu = false;
        }
        private void etiket3_FareTaþýnýyor (object k, MouseEventArgs o) {
            if (sürükleniyorMu){
                Point taþý=PointToScreen (new Point (o.X, o.Y));
                taþý.Offset (-týklananNokta.X, -týklananNokta.Y);
                Location = taþý;
            }   
        }
        private void etiket3_FareSerbest (object k, MouseEventArgs o) {sürükleniyorMu = false;}  
    }
    public class Form4: Form {
        private Button düðme4;
        public Form4() {//Kurucu
            düðme4 = new Button();
            //SuspendLayout();
            düðme4.Location = new Point (94, 231);
            düðme4.Size = new Size (75, 23);
            düðme4.Text = "&Kapat";
            düðme4.UseVisualStyleBackColor = true;
            düðme4.Click += new EventHandler (düðme4_Týklandý);
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (295, 270);
            Controls.Add (düðme4);
            Text = "Kýrýk Form";
            Load += new EventHandler (Form4_Yüklendi);
            //ResumeLayout(false);
            BackColor = Color.DeepPink;
        }
        private void düðme4_Týklandý (object k, EventArgs o) {Close();}
        private void Form4_Yüklendi (object k, EventArgs o) {
            GraphicsPath kýrýkGrafik = new GraphicsPath();
            Point[] noktalar = new Point[]{
                new Point (0, 0),
                new Point (40, 60),
                new Point (Width - 100, 10),
                new Point (Width - 40, Height - 60), 
                new Point (Width, Height),
                new Point (10, Height)
            };
            kýrýkGrafik.AddCurve (noktalar);
            kýrýkGrafik.CloseAllFigures();
            Region = new Region (kýrýkGrafik);
        }
    }
    class Form5: Form {
        MainMenu AnaMenü = new MainMenu();
        public Form5() {//Kurucu
            Text = "Ana Menü Oluþturma";
            MenuItem mb1 = new MenuItem ("Dosya");
            AnaMenü.MenuItems.Add (mb1);
            MenuItem mb2 = new MenuItem ("Araçlar1");
            AnaMenü.MenuItems.Add (mb2);
            MenuItem mb3 = new MenuItem ("Araçlar2");
            AnaMenü.MenuItems.Add (mb3);
            MenuItem altmb11 = new MenuItem ("Aç");
            mb1.MenuItems.Add (altmb11);
            MenuItem altmb12 = new MenuItem ("Kapat");
            mb1.MenuItems.Add (altmb12);
            MenuItem altmb13 = new MenuItem ("Çýk");
            mb1.MenuItems.Add (altmb13);
            MenuItem altmb21 = new MenuItem ("Kordinatlar");
            mb2.MenuItems.Add (altmb21);
            MenuItem altmb22 = new MenuItem ("Ebat Deðiþtir");
            mb2.MenuItems.Add (altmb22);
            MenuItem altmb23 = new MenuItem ("Yenile");
            mb2.MenuItems.Add (altmb23);
            MenuItem altmb31 = new MenuItem ("Kordinatlar");
            mb3.MenuItems.Add (altmb31);
            MenuItem altmb32 = new MenuItem ("Ebat Deðiþtir");
            mb3.MenuItems.Add (altmb32);
            MenuItem altmb33 = new MenuItem ("Yenile");
            mb3.MenuItems.Add (altmb33);
            altmb11.Click += AçTýklandý;
            altmb12.Click += KapatTýklandý;
            altmb13.Click += ÇýkTýklandý;
            altmb21.Click += KordinatlarTýklandý1; 
            altmb22.Click += EbatDeðiþtirTýklandý1;
            altmb23.Click += YenileTýklandý1;
            altmb31.Click += KordinatlarTýklandý2; 
            altmb32.Click += EbatDeðiþtirTýklandý2;
            altmb33.Click += YenileTýklandý2;
            Menu = AnaMenü;
            BackColor = Color.Khaki;
        }
        protected void AçTýklandý (object k, EventArgs o) {Console.WriteLine ("Aç Týklandý");}
        protected void KapatTýklandý (object k, EventArgs o) {Console.WriteLine ("Kapat Týklandý");}
        protected void ÇýkTýklandý (object k, EventArgs o) {Console.WriteLine ("Çýk Týklandý");}
        protected void KordinatlarTýklandý1 (object k, EventArgs o){}
        protected void EbatDeðiþtirTýklandý1 (object k, EventArgs o){}
        protected void YenileTýklandý1 (object k, EventArgs o){}
        protected void KordinatlarTýklandý2 (object kim, EventArgs olay) {
            Console.WriteLine ("Üst:"+Top);
            Console.WriteLine ("Sol:"+Left);
            Console.WriteLine ("Alt:"+Bottom);
            Console.WriteLine ("Sað:"+Right);
        }
        protected void EbatDeðiþtirTýklandý2 (object k, EventArgs o) {Width = Height = 200;}
        protected void YenileTýklandý2 (object k, EventArgs o) {Width = Height = 300;}
    }
    public class Form6: Form {
        private Label yafta6;
        private Container kab = null;
        public Form6() {BileþeniBaþlat();} //Kurucu
        protected override void Dispose (bool çöpeAt) {
            if (çöpeAt) {
                if (kab != null) kab.Dispose();
            }
            base.Dispose (çöpeAt);
        }
        private void BileþeniBaþlat() {
            yafta6 = new Label();
            //SuspendLayout();
            yafta6.Font = new System.Drawing.Font ("Microsoft Sans Serif", 24F);
            yafta6.Location = new Point (16, 16);
            yafta6.Name = "yafta6";
            yafta6.Size = new Size (676, 424);
            yafta6.TabIndex = 0;
            yafta6.Text = "Tabii ki Size(676,424) ebat için kaydýrmaçubuklarý gerekiyor!";
            AutoScaleBaseSize = new Size (5, 13);
            AutoScroll = true;
            AutoScrollMinSize = new Size (300, 300);
            ClientSize = new Size (319, 136);
            Controls.Add (yafta6);
            Name = "Form6";
            Text = "Form6";
            //ResumeLayout (false);
            BackColor = Color.DarkKhaki;
        }
    }
    public class Form7: Form {
        private MesajFilitresi msgSüzgeci = new MesajFilitresi();
        public Form7() {//Kurucu
            Application.ApplicationExit += new EventHandler (SaðTýklandý);
            Application.AddMessageFilter (msgSüzgeci);
            BackColor = Color.Black;
        }
        private void SaðTýklandý (object k, EventArgs o) {Application.RemoveMessageFilter (msgSüzgeci);}
    }
    public class MesajFilitresi: IMessageFilter {
        public bool PreFilterMessage (ref Message m) {
            //Sol fare týklamasýný beyanla
            if (m.Msg == 513) {Console.WriteLine ("WM_LBUTTONDOWN: " + m.Msg); return true;}
            return false;
        }
    }
    public class Form8: Form {
        private Container kab = null;
        public Form8() {BileþeniBaþlat();} //Kurucu
        protected override void Dispose (bool çöpe) {
            MessageBox.Show ("Form8 çöpe atýlýyor...");
            if(çöpe) if(kab != null) kab.Dispose();
            base.Dispose (çöpe);    
        }
        private void BileþeniBaþlat() {
            kab = new Container();
            Size = new Size (300, 300);
            Text = "Form8";
            BackColor = Color.DarkGray;
        }
    }
    public class Form9: Form {
        private Container kab = null;
        public Form9() {//Kurucu
            BileþeniBaþlat();
            Cursor = Cursors.WaitCursor; //Yuvarlak dönen (bekleme) halka
            Paint += new PaintEventHandler (Form9_Boyanýyor);
        }
        protected override void Dispose (bool çöpe) {//Form9 kapanýþta çöpe
            if(çöpe) if(kab != null) kab.Dispose();
            base.Dispose (çöpe);
        }
        private void BileþeniBaþlat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (392, 173);
            Text = "Form9";
            BackColor = Color.Maroon;
        }
        private void Form9_Boyanýyor (object kim, PaintEventArgs olay) {
            Graphics g = olay.Graphics;
            g.DrawString ("Dönen halkalý Bekleme_Ýmleci...", new Font ("Times New Roman", 20), new SolidBrush (Color.Yellow), 10, 70);
        }
    }
    public class Form10: Form {
        int i=0;
        public Form10() {//Kurucu
            Button düðme10 = new Button();
            Text = "Buton Testi";
            düðme10.Location = new Point (25, 50);
            düðme10.Size = new Size (100, 50);
            düðme10.Text = "Týkla Beni";
            düðme10.BackColor = Color.Red;
            düðme10.ForeColor = Color.Yellow;
            düðme10.Click += new EventHandler (düðme10_Týklandý);
            Controls.Add (düðme10);
            BackColor = Color.DarkSlateGray;
        }
        public void düðme10_Týklandý (object k, EventArgs o) {MessageBox.Show ("Düðme " + ++i + ".kez týklandý.");}
    }
    class FormB {
        [STAThread]
        static void Main() {
            Console.Write ("Close() sadece ilgili formu kapatýrken Application.Exit() tüm programdan çýkar. Buton týklamak yerine '&x: Alt-x' tuþ bileþeni de kullanýlabilir. Formu sürüklemek için fare sol baskýlý 'Location=PointToScreen.Offset(o.X,o.Y)' tanýmlanmalý. Kýrýk grafik için Point[] konumlar tanýmlanýp AddCurve hatlar çizilip Region yaratýlmalý. Form kapatýldýðýnda otomatikmen Dispose/Çöpe atýlýr, ancak 'override void Dispose()' ile özelleþtirilebilinir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli formlar kurma ve Application.Run'la koþturma:");
            //Application.SetCompatibleTextRenderingDefault (false); //Ýlk formu yaratmadan önce
            Form1 form1=new Form1(); form1.Size=new Size (400, 300); Application.Run (form1);
            Form2 form2=new Form2(); form2.Size=new Size (400, 300); Application.Run (form2);
            Application.Run (new Form3());
            Application.EnableVisualStyles(); Application.Run (new Form4());
            Form5 form5 = new Form5(); Application.Run (form5);
            Application.Run (new Form6());
            Application.Run (new Form7());
            Application.Run (new Form8());
            Application.Run (new Form9());
            Form10 form10 = new Form10(); Application.Run (form10);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}