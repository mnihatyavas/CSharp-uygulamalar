// j2sc#2301c.cs: Form, d��me, etiket, men�, ��pe, imle� �rne�i.

using System;
using System.Windows.Forms; //:Form i�in
using System.Drawing; //Color i�in
using System.Drawing.Drawing2D; //GraphicsPath i�in
using System.ComponentModel; //Container i�in
namespace Formlar {
    public class Form1: Form {
        private Button d��me1a;
        private Button d��me1b;
        protected Label etiket1;
        public Form1() {//Kurucu
            d��me1a = new Button();
            d��me1a.Location = new Point (25, 100);
            d��me1a.Size = new Size (100, 25);
            d��me1a.Text = "&��k"; //Alt-�
            d��me1a.Click += new EventHandler (d��me1a_T�kland�);
            d��me1b = new Button();
            d��me1b.Location = new Point (200, 100);
            d��me1b.Size = new Size (150, 25);
            d��me1b.Text = "&Uygula"; //Alt-u
            d��me1b.Click += new EventHandler (d��me1b_T�kland�);
            etiket1 = new Label();
            etiket1.Location = new Point (25, 25);
            etiket1.Size = new Size (150, 25);
            etiket1.Text = "Form1'in a��klama etiketi";
            Controls.AddRange (new Control[]{etiket1, d��me1a, d��me1b});
            BackColor = Color.Magenta;
        }
        private void d��me1a_T�kland� (object kim, EventArgs oly) {Application.Exit();}
        private void d��me1b_T�kland� (object kim, EventArgs oly) {
            MessageBox.Show ("Bu, Form1 uygulamas�d�r.");
            BirMetot();
        }
        protected virtual void BirMetot() {MessageBox.Show ("Bu, Form1'den �a�r�lan BirMetot()'dur.");}
    }
    public class Form2: Form1 {
        private Button d��me2;
        public Form2() {//Kurucu
            d��me2 = new Button();
            d��me2.Location = new Point (25, 150);
            d��me2.Size = new Size (125, 25);
            d��me2.Text = "��&k"; //Alt-k
            d��me2.Click += new EventHandler (d��me2_T�kland�);
            Controls.Add (d��me2);
            etiket1.Text = "Form2'deki etiket";
            BackColor = Color.LightBlue;
        }
        private void d��me2_T�kland� (object k, EventArgs o) {Application.Exit();}
        protected override void BirMetot() {MessageBox.Show ("Bu, Form1'dekini ge�ersizleyen Form2'deki BirMetot()'dur.");}
    }
    public class Form3: Form {
        private Button d��me3= new Button();
        private Label etiket3 = new Label();
        private bool s�r�kleniyorMu;
        private Point t�klananNokta;
        public Form3() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            SuspendLayout();
            d��me3.Location = new Point (102, 215);
            d��me3.Name = "d��me3";
            d��me3.Size = new Size (76, 20);
            d��me3.TabIndex = 5;
            d��me3.Text = "&Kapat";
            d��me3.Click += new EventHandler (d��me3_T�kland�); 
            etiket3.BackColor = Color.Navy;
            etiket3.BorderStyle = BorderStyle.Fixed3D;
            etiket3.Font = new Font ("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            etiket3.ForeColor = Color.Red;
            etiket3.Location = new Point (74, 167);
            etiket3.Name = "etiket3";
            etiket3.Size = new Size (140, 36);
            etiket3.TabIndex = 4;
            etiket3.Text = "Formu s�r�klemek i�in buray� SOL bas�l� tut!";
            etiket3.MouseDown += new MouseEventHandler (etiket3_FareBas�l�);
            etiket3.MouseMove += new MouseEventHandler(etiket3_FareTa��n�yor);
            etiket3.MouseUp += new MouseEventHandler (etiket3_FareSerbest);
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            ControlBox = false;
            Controls.Add (d��me3);
            Controls.Add (etiket3);
            Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ResumeLayout (false);
            BackColor = Color.Pink;
        }
        private void d��me3_T�kland� (object k, EventArgs o) {Close();}
        private void etiket3_FareBas�l� (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Left) {
                s�r�kleniyorMu = true;
                t�klananNokta = new Point (o.X, o.Y);
            }else s�r�kleniyorMu = false;
        }
        private void etiket3_FareTa��n�yor (object k, MouseEventArgs o) {
            if (s�r�kleniyorMu){
                Point ta��=PointToScreen (new Point (o.X, o.Y));
                ta��.Offset (-t�klananNokta.X, -t�klananNokta.Y);
                Location = ta��;
            }   
        }
        private void etiket3_FareSerbest (object k, MouseEventArgs o) {s�r�kleniyorMu = false;}  
    }
    public class Form4: Form {
        private Button d��me4;
        public Form4() {//Kurucu
            d��me4 = new Button();
            //SuspendLayout();
            d��me4.Location = new Point (94, 231);
            d��me4.Size = new Size (75, 23);
            d��me4.Text = "&Kapat";
            d��me4.UseVisualStyleBackColor = true;
            d��me4.Click += new EventHandler (d��me4_T�kland�);
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (295, 270);
            Controls.Add (d��me4);
            Text = "K�r�k Form";
            Load += new EventHandler (Form4_Y�klendi);
            //ResumeLayout(false);
            BackColor = Color.DeepPink;
        }
        private void d��me4_T�kland� (object k, EventArgs o) {Close();}
        private void Form4_Y�klendi (object k, EventArgs o) {
            GraphicsPath k�r�kGrafik = new GraphicsPath();
            Point[] noktalar = new Point[]{
                new Point (0, 0),
                new Point (40, 60),
                new Point (Width - 100, 10),
                new Point (Width - 40, Height - 60), 
                new Point (Width, Height),
                new Point (10, Height)
            };
            k�r�kGrafik.AddCurve (noktalar);
            k�r�kGrafik.CloseAllFigures();
            Region = new Region (k�r�kGrafik);
        }
    }
    class Form5: Form {
        MainMenu AnaMen� = new MainMenu();
        public Form5() {//Kurucu
            Text = "Ana Men� Olu�turma";
            MenuItem mb1 = new MenuItem ("Dosya");
            AnaMen�.MenuItems.Add (mb1);
            MenuItem mb2 = new MenuItem ("Ara�lar1");
            AnaMen�.MenuItems.Add (mb2);
            MenuItem mb3 = new MenuItem ("Ara�lar2");
            AnaMen�.MenuItems.Add (mb3);
            MenuItem altmb11 = new MenuItem ("A�");
            mb1.MenuItems.Add (altmb11);
            MenuItem altmb12 = new MenuItem ("Kapat");
            mb1.MenuItems.Add (altmb12);
            MenuItem altmb13 = new MenuItem ("��k");
            mb1.MenuItems.Add (altmb13);
            MenuItem altmb21 = new MenuItem ("Kordinatlar");
            mb2.MenuItems.Add (altmb21);
            MenuItem altmb22 = new MenuItem ("Ebat De�i�tir");
            mb2.MenuItems.Add (altmb22);
            MenuItem altmb23 = new MenuItem ("Yenile");
            mb2.MenuItems.Add (altmb23);
            MenuItem altmb31 = new MenuItem ("Kordinatlar");
            mb3.MenuItems.Add (altmb31);
            MenuItem altmb32 = new MenuItem ("Ebat De�i�tir");
            mb3.MenuItems.Add (altmb32);
            MenuItem altmb33 = new MenuItem ("Yenile");
            mb3.MenuItems.Add (altmb33);
            altmb11.Click += A�T�kland�;
            altmb12.Click += KapatT�kland�;
            altmb13.Click += ��kT�kland�;
            altmb21.Click += KordinatlarT�kland�1; 
            altmb22.Click += EbatDe�i�tirT�kland�1;
            altmb23.Click += YenileT�kland�1;
            altmb31.Click += KordinatlarT�kland�2; 
            altmb32.Click += EbatDe�i�tirT�kland�2;
            altmb33.Click += YenileT�kland�2;
            Menu = AnaMen�;
            BackColor = Color.Khaki;
        }
        protected void A�T�kland� (object k, EventArgs o) {Console.WriteLine ("A� T�kland�");}
        protected void KapatT�kland� (object k, EventArgs o) {Console.WriteLine ("Kapat T�kland�");}
        protected void ��kT�kland� (object k, EventArgs o) {Console.WriteLine ("��k T�kland�");}
        protected void KordinatlarT�kland�1 (object k, EventArgs o){}
        protected void EbatDe�i�tirT�kland�1 (object k, EventArgs o){}
        protected void YenileT�kland�1 (object k, EventArgs o){}
        protected void KordinatlarT�kland�2 (object kim, EventArgs olay) {
            Console.WriteLine ("�st:"+Top);
            Console.WriteLine ("Sol:"+Left);
            Console.WriteLine ("Alt:"+Bottom);
            Console.WriteLine ("Sa�:"+Right);
        }
        protected void EbatDe�i�tirT�kland�2 (object k, EventArgs o) {Width = Height = 200;}
        protected void YenileT�kland�2 (object k, EventArgs o) {Width = Height = 300;}
    }
    public class Form6: Form {
        private Label yafta6;
        private Container kab = null;
        public Form6() {Bile�eniBa�lat();} //Kurucu
        protected override void Dispose (bool ��peAt) {
            if (��peAt) {
                if (kab != null) kab.Dispose();
            }
            base.Dispose (��peAt);
        }
        private void Bile�eniBa�lat() {
            yafta6 = new Label();
            //SuspendLayout();
            yafta6.Font = new System.Drawing.Font ("Microsoft Sans Serif", 24F);
            yafta6.Location = new Point (16, 16);
            yafta6.Name = "yafta6";
            yafta6.Size = new Size (676, 424);
            yafta6.TabIndex = 0;
            yafta6.Text = "Tabii ki Size(676,424) ebat i�in kayd�rma�ubuklar� gerekiyor!";
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
        private MesajFilitresi msgS�zgeci = new MesajFilitresi();
        public Form7() {//Kurucu
            Application.ApplicationExit += new EventHandler (Sa�T�kland�);
            Application.AddMessageFilter (msgS�zgeci);
            BackColor = Color.Black;
        }
        private void Sa�T�kland� (object k, EventArgs o) {Application.RemoveMessageFilter (msgS�zgeci);}
    }
    public class MesajFilitresi: IMessageFilter {
        public bool PreFilterMessage (ref Message m) {
            //Sol fare t�klamas�n� beyanla
            if (m.Msg == 513) {Console.WriteLine ("WM_LBUTTONDOWN: " + m.Msg); return true;}
            return false;
        }
    }
    public class Form8: Form {
        private Container kab = null;
        public Form8() {Bile�eniBa�lat();} //Kurucu
        protected override void Dispose (bool ��pe) {
            MessageBox.Show ("Form8 ��pe at�l�yor...");
            if(��pe) if(kab != null) kab.Dispose();
            base.Dispose (��pe);    
        }
        private void Bile�eniBa�lat() {
            kab = new Container();
            Size = new Size (300, 300);
            Text = "Form8";
            BackColor = Color.DarkGray;
        }
    }
    public class Form9: Form {
        private Container kab = null;
        public Form9() {//Kurucu
            Bile�eniBa�lat();
            Cursor = Cursors.WaitCursor; //Yuvarlak d�nen (bekleme) halka
            Paint += new PaintEventHandler (Form9_Boyan�yor);
        }
        protected override void Dispose (bool ��pe) {//Form9 kapan��ta ��pe
            if(��pe) if(kab != null) kab.Dispose();
            base.Dispose (��pe);
        }
        private void Bile�eniBa�lat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (392, 173);
            Text = "Form9";
            BackColor = Color.Maroon;
        }
        private void Form9_Boyan�yor (object kim, PaintEventArgs olay) {
            Graphics g = olay.Graphics;
            g.DrawString ("D�nen halkal� Bekleme_�mleci...", new Font ("Times New Roman", 20), new SolidBrush (Color.Yellow), 10, 70);
        }
    }
    public class Form10: Form {
        int i=0;
        public Form10() {//Kurucu
            Button d��me10 = new Button();
            Text = "Buton Testi";
            d��me10.Location = new Point (25, 50);
            d��me10.Size = new Size (100, 50);
            d��me10.Text = "T�kla Beni";
            d��me10.BackColor = Color.Red;
            d��me10.ForeColor = Color.Yellow;
            d��me10.Click += new EventHandler (d��me10_T�kland�);
            Controls.Add (d��me10);
            BackColor = Color.DarkSlateGray;
        }
        public void d��me10_T�kland� (object k, EventArgs o) {MessageBox.Show ("D��me " + ++i + ".kez t�kland�.");}
    }
    class FormB {
        [STAThread]
        static void Main() {
            Console.Write ("Close() sadece ilgili formu kapat�rken Application.Exit() t�m programdan ��kar. Buton t�klamak yerine '&x: Alt-x' tu� bile�eni de kullan�labilir. Formu s�r�klemek i�in fare sol bask�l� 'Location=PointToScreen.Offset(o.X,o.Y)' tan�mlanmal�. K�r�k grafik i�in Point[] konumlar tan�mlan�p AddCurve hatlar �izilip Region yarat�lmal�. Form kapat�ld���nda otomatikmen Dispose/��pe at�l�r, ancak 'override void Dispose()' ile �zelle�tirilebilinir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli formlar kurma ve Application.Run'la ko�turma:");
            //Application.SetCompatibleTextRenderingDefault (false); //�lk formu yaratmadan �nce
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}