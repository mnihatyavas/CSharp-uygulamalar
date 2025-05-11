// j2sc#2302b.cs: D��me �e�itleri, t�klama y�netimi ve resimli d��meler �rne�i.

using System;
using System.Windows.Forms; 
using System.Drawing;
namespace Bile�enler {
    public class Form1: Form {
        private Button d��me1;
        public Form1() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            d��me1 = new Button();
            SuspendLayout();
            //d��me1
            d��me1.Location = new Point (109, 122);
            d��me1.Name = "d��me1";
            d��me1.TabIndex = 0;
            d��me1.Text = "Merhaba de!";
            d��me1.BackColor=Color.Aqua;
            d��me1.Click += new EventHandler (d��me1_T�kland�);
            //Kontrol
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 266);
            Controls.Add (d��me1);
            Name = "Form1";
            Text = "Form1: Button bile�eni";
            BackColor=Color.Blue;
            ResumeLayout (false);
        }
        private void d��me1_T�kland� (object k, EventArgs o) {MessageBox.Show (this, "Herkese Merhabalar!.." );}
    }
    public class Form2: Form {
        private Button d��me2a;
        private Button d��me2b;
        private Button d��me2c;
        private Button d��me2d;
        ContentAlignment formKonumu = ContentAlignment.MiddleCenter; //Formu ekranda ortalat
        int konumNo = 0;
        public Form2() {//Kurucu
            Bile�eniBa�lat();
            AcceptButton = d��me2b; //Varsay�l� d��me
            CenterToScreen(); //Form2 ortalans�n
        }
        #region Form2 tasar�m kodlamas�
        private void Bile�eniBa�lat() {
            d��me2a = new Button();
            d��me2b = new Button();
            d��me2c = new Button();
            d��me2d = new Button();
            SuspendLayout();
            // d��me2a: resimli d��me
            d��me2a.BackgroundImage = new Bitmap ("resim/resim2a.jpg");
            d��me2a.Font = new Font ("Microsoft Sans Serif", 20F, FontStyle.Bold);
            d��me2a.ForeColor = Color.Black;
            d��me2a.Location = new Point (16, 192);
            d��me2a.Name = "d��me2a";
            d��me2a.Size = new Size (250, 250);
            d��me2a.TabIndex = 3;
            d��me2a.Text = "Resim D��mesi";
            d��me2a.TextAlign = ContentAlignment.TopCenter;
            // d��me2b: standart d��me
            d��me2b.Font = new Font ("Microsoft Sans Serif", 12F);
            d��me2b.ForeColor = SystemColors.ControlText;
            d��me2b.BackColor=Color.Lime;
            d��me2b.Location = new Point (16, 80);
            d��me2b.Name = "d��me2b";
            d��me2b.Size = new Size (312, 88);
            d��me2b.TabIndex = 2;
            d��me2b.Text = "Ben standart metin d��mesiyim";
            d��me2b.Click += new EventHandler (d��me2b_T�kland�);
            // d��me2c: a��l�rmen� d��mesi
            d��me2c.FlatStyle = FlatStyle.Popup;
            d��me2c.ForeColor = SystemColors.ControlText;
            d��me2c.BackColor=Color.Yellow;
            d��me2c.Location = new Point (176, 24);
            d��me2c.Name = "d��me2c";
            d��me2c.Size = new Size (152, 32);
            d��me2c.TabIndex = 1;
            d��me2c.Text = "Ben A��l�rMen� d��mesiyim!";
            // d��me2d
            d��me2d.FlatStyle = FlatStyle.Flat;
            d��me2d.ForeColor = Color.Green;
            d��me2d.BackColor=Color.Fuchsia;
            d��me2d.Location = new Point (16, 24);
            d��me2d.Name = "d��me2d";
            d��me2d.Size = new Size (152, 32);
            d��me2d.TabIndex = 0;
            d��me2d.Text = "Yay�lan d��meyim";
            // Form2
            AcceptButton = d��me2b;
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (340, 450);
            //Controls.Add (d��me2a); Controls.Add (d��me2b); Controls.Add (d��me2c); Controls.Add (d��me2d);
            Controls.AddRange (new Control[] {d��me2a, d��me2b, d��me2c, d��me2d});
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form2";
            Text = "Form2: 4 Farkl� D��me";
            BackColor=Color.Navy;
            ResumeLayout (false);
        }
        #endregion
        protected void d��me2b_T�kland� (object k, EventArgs o) {      
            Array konumDe�erleri = Enum.GetValues (formKonumu.GetType());
            konumNo++;
            if (konumNo >= konumDe�erleri.Length) konumNo = 0;
            formKonumu = (ContentAlignment)ContentAlignment.Parse (formKonumu.GetType(), konumDe�erleri.GetValue (konumNo).ToString());
            d��me2b.TextAlign = formKonumu;
            d��me2b.Text = formKonumu.ToString();
            d��me2a.ImageAlign = formKonumu;
        }
    }
    public class Form3: Form {
        Button d��me3a;
        Button d��me3b;
        public Form3() {//Kurucu
            Size = new Size (200, 100);
            BackColor=Color.Black;
            Text = "Form3: 2 Olayl� D��me";
            //d��me3a
            d��me3a = new Button();
            d��me3a.Parent = this; //"Controls.Add(d��me)" yerine
            d��me3a.Text = "1.D��me";
            d��me3a.BackColor=Color.Pink;
            d��me3a.Location = new Point (10, 10);
            d��me3a.Click += new EventHandler (d��me3a_T�kland�);
            //d��me3b
            d��me3b = new Button();
            d��me3b.Parent = this;
            d��me3b.Text = "2.D��me";
            d��me3b.ForeColor=Color.Yellow;
            d��me3b.BackColor=Color.Purple;
            d��me3b.Location = new Point (100, 10);
            d��me3b.Click += new EventHandler (d��me3b_T�kland�);
        }
        private void d��me3a_T�kland� (object k, EventArgs o) {
            MessageBox.Show ("D��me-1 T�kland�.");
            d��me3b.PerformClick(); //d��me3b_T�kland�'y� �a��r�r
        }
        private void d��me3b_T�kland� (object k, EventArgs o) {MessageBox.Show ("D��me-2 T�kland�.");}
    }
    public class Form4: Form {
        Button d��me4;
        int i = 1;
        FlatStyle[] d�zStiller;
        Image resim;
        public Form4() {//Kurucu
            Text = "Form4: D�z Stiller";
            Size = new Size (600, 550);
            BackColor=Color.Maroon;
            resim = Image.FromFile ("resim/resim2b.jpg");
            //d��me4
            d��me4 = new Button();
            d��me4.Parent = this;
            d��me4.Text = d��me4.FlatStyle.ToString();
            d��me4.Location = new Point (10, 10);
            d��me4.BackColor=Color.Aqua;
            d��me4.Click += new EventHandler (d��me4_T�kland�);
            d��me4.Image = resim;
            D��meEbat� (d��me4);
            //
            FlatStyle stilNo = new FlatStyle();
            d�zStiller = (FlatStyle[])Enum.GetValues (stilNo.GetType());
        }
        private void d��me4_T�kland� (object k, EventArgs o) {
            Button d��me = (Button)k;
            d��me.FlatStyle = d�zStiller [i];
            d��me.Text = d��me.FlatStyle.ToString();
            D��meEbat� (d��me);
            if (i < d�zStiller.Length - 1) i++;
            else i = 0;
        }
        private void D��meEbat� (Button d��me) {
            int xEbat = ((int)(Font.Height * .75) * d��me.Text.Length) + (resim.Width * 2);
            int yEbat = resim.Height * 2;
            d��me.Size = new Size (xEbat, yEbat);
        }
    }
    public class Form5: Form {
        int i=0, j=0;
        Button d��me5;
        public Form5() {//Kurucu
            Text = "Form5: De�i�ken D��me Ebat�";
            Size = new Size (300, 200);
            BackColor=Color.Sienna;
            //d��me5
            d��me5 = new Button();
            d��me5.Parent = this;
            d��me5.Text = "T�kla";
            d��me5.BackColor=Color.Cyan;
            d��me5.Location = new Point (10, 10);
            d��me5.Click += new EventHandler (d��me5_T�kland�);
        }
        private void d��me5_T�kland� (object k, EventArgs o) {
            Button d��me = (Button)k;
            d��me5_Ebat (d��me);
        }
        private void d��me5_Ebat (Button d��me) {
            if (++i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            d��me.Size = new Size (x, y);
            d��me.Text = i + ".T�klama";
        }
    }
    public class Form6: Form {
        int i=0, j=0;
        Button d��me6;
        public Form6() {//Kurucu
            Text = "Form6: Rasgele De�i�ken D��me Rengi";
            Size = new Size (300, 200);
            BackColor=Color.Black;
            //d��me6
            d��me6 = new Button();
            d��me6.Parent = this;
            d��me6.Text = "T�kla";
            d��me6.BackColor=Color.DeepPink;
            d��me6.Location = new Point (20, 20);
            d��me6.Size = new Size (250, 130);
            d��me6.Click += new EventHandler (d��me6_T�kland�);
        }
        private void d��me6_T�kland� (object k, EventArgs o) {
            Button d��me = (Button)k;
            d��me.Text = ++i + ".T�klama";
            int kr, y�, mv;
            Random r = new Random();
            kr = r.Next (0, 255); y� = r.Next (0, 255); mv = r.Next (0, 255);
            d��me.BackColor = Color.FromArgb (kr, y�, mv);
            BackColor = Color.FromArgb (255-kr, 255-y�, 255-mv);
            if (i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            d��me.Size = new Size (x, y);
        }
    }
    public class Form7: Form {
        int i=0, j=0;
        Button d��me7;
        public Form7() {//Kurucu
            Text = "Form7: D��meli Renk ve Ebat";
            Size = new Size (350, 200);
            BackColor=Color.DarkGray;
            //d��me7
            d��me7 = new Button();
            d��me7.Parent = this;
            d��me7.Text = "M.Nihat Yava�";
            d��me7.Location = new Point (10,10);
            d��me7.Size = new Size (100, 50);
            d��me7.BackColor = Color.LightGreen;
            d��me7.TextAlign = ContentAlignment.MiddleLeft;
            d��me7.Click += new EventHandler (d��me7_T�kland�);
        }
        private void d��me7_T�kland� (object k, EventArgs o) {
            int kr, y�, mv;
            Random r = new Random();
            kr = r.Next (0, 255); y� = r.Next (0, 255); mv = r.Next (0, 255);
            d��me7.BackColor = Color.FromArgb (kr, y�, mv);
            BackColor = Color.FromArgb (255-kr, 255-y�, 255-mv);
            if (++i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            d��me7.Size = new Size (x, y);
            d��me7.Text = i + ".T�klama";
        }
    }
    public class Form8: Form {
        Button d��me8;
        Image resim8;
        ImageList resimListesi8;
        int i=0, j=0;
        public Form8() {//Kurucu
            Text = "Form8: Ebat De�i�tiren Resimli D��me";
            Size = new Size (300, 300);
            BackColor=Color.SteelBlue;
            resim8 = Image.FromFile ("resim/resim2c.jpg");
            resimListesi8 = new ImageList();
            resimListesi8.Images.Add (resim8);
            //d��me8
            d��me8 = new Button();
            d��me8.Parent = this;
            d��me8.Location = new Point (10, 10);
            d��me8.Size = new Size (150, 150);
            resimListesi8.ImageSize = new Size (150, 150);
            d��me8.ImageList = resimListesi8;
            d��me8.ImageIndex = 0;
            d��me8.Click += new EventHandler (d��me8_T�kland�);
        }
        private void d��me8_T�kland� (object k, EventArgs o) {
            if (++i % 10 == 0) j=0;
            int x = 150 + (++j * 10);
            int y = 150 + (j * 10);
            d��me8.Size = new Size (x, y);
            resimListesi8.ImageSize = new Size (x, y);
            resimListesi8.Images.Add (resim8);
            d��me8.ImageList = resimListesi8;
            d��me8.ImageIndex = j; //Her yeni Images.Add ile endeks'te (azami 10) art�r�lmal�d�r
        }
    }
    public class Form9: Form {
        Button d��me9;
        Image resim9;
        ImageList resimListesi9;
        PictureBox resimKutusu;
        public Form9() {
            Size = new Size (300, 300);
            Text = "Form9: Resimkutusu ve Resimli D��me";
            BackColor=Color.SlateBlue;
            resim9 = Image.FromFile ("resim/resim2b.jpg");
            resimListesi9 = new ImageList();
            resimListesi9.Images.Add (resim9);
            //resimKutusu
            resimKutusu = new PictureBox();
            resimKutusu.Parent = this;
            resimKutusu.Size = new Size (50, 50);
            resimKutusu.Location = new Point (10, 10);
            resimKutusu.BorderStyle = BorderStyle.FixedSingle;
            resimKutusu.SizeMode = PictureBoxSizeMode.StretchImage;
            resimKutusu.Image = resim9;
            //d��me9
            d��me9 = new Button();
            d��me9.Parent = this;
            d��me9.Location = new Point (50, 50);
            d��me9.Size = new Size (200, 200);
            d��me9.ImageList = resimListesi9;
            d��me9.ImageIndex = 0;
            resimListesi9.ImageSize = new Size (200, 200);
        }
    }
    class Label_Button2 {
        static void Main() {
            Console.Write ("D��me i�i resim ebat� de�i�imi 'ImageList.ImageSize=new Size(x,y)' ile ayarlanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Men�l� etiket-d��me-resim bile�enli formlar:");
            int ts=0;
       ba�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Form1 D��meli mesajkutusu");
            Console.WriteLine ("2: Form2 4 farkl� d��me");
            Console.WriteLine ("3: Form3 2 olayl� d��me");
            Console.WriteLine ("4: Form4 Resim ve System d�zstiller");
            Console.WriteLine ("5: Form5 T�klan�nca artan d��me ebat�");
            Console.WriteLine ("6: Form6 T�klan�nca de�i�en zemin ve d��me rengi");
            Console.WriteLine ("7: Form7 T�klan�nca de�i�en renk ve ebat");
            Console.WriteLine ("8: Form8 D��me ve resim ebat� de�i�mesi");
            Console.WriteLine ("9: Form9 Resimkutusu ve resimli d��me");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto ba�;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 9) goto ba�;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //D��me1 t�klan�nca mesaj kutusundan selamlama
                case 2: Application.Run (new Form2()); break; //Flat, Popup, Standart ve Image d��meleri
                case 3: Application.Run (new Form3()); break; //Birdi�erini de �a��ran 2 olayl� d��me
                case 4: Application.Run (new Form4()); break; //2 resim ve 1 metin d�zstilli d��me
                case 5: Application.Run (new Form5()); break; //Her t�klamada ebat� artan d��me
                case 6: Application.Run (new Form6()); break; //T�klan�nca zeminin ve d��menin rengi rasgele de�i�ir
                case 7: Application.Run (new Form7()); break; //T�klan�nca renk ve ebat de�i�tiren d��me
                case 8: Application.Run (new Form8()); break; //T�klan�nca d��me ve resim ebat�n�n uyumlu de�i�imi
                case 9: Application.Run (new Form9()); break; //Resim ebat� ayarlanabilir resimkutusu ve resimlid��me
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}