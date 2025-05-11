// j2sc#2302b.cs: Düðme çeþitleri, týklama yönetimi ve resimli düðmeler örneði.

using System;
using System.Windows.Forms; 
using System.Drawing;
namespace Bileþenler {
    public class Form1: Form {
        private Button düðme1;
        public Form1() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            düðme1 = new Button();
            SuspendLayout();
            //düðme1
            düðme1.Location = new Point (109, 122);
            düðme1.Name = "düðme1";
            düðme1.TabIndex = 0;
            düðme1.Text = "Merhaba de!";
            düðme1.BackColor=Color.Aqua;
            düðme1.Click += new EventHandler (düðme1_Týklandý);
            //Kontrol
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 266);
            Controls.Add (düðme1);
            Name = "Form1";
            Text = "Form1: Button bileþeni";
            BackColor=Color.Blue;
            ResumeLayout (false);
        }
        private void düðme1_Týklandý (object k, EventArgs o) {MessageBox.Show (this, "Herkese Merhabalar!.." );}
    }
    public class Form2: Form {
        private Button düðme2a;
        private Button düðme2b;
        private Button düðme2c;
        private Button düðme2d;
        ContentAlignment formKonumu = ContentAlignment.MiddleCenter; //Formu ekranda ortalat
        int konumNo = 0;
        public Form2() {//Kurucu
            BileþeniBaþlat();
            AcceptButton = düðme2b; //Varsayýlý düðme
            CenterToScreen(); //Form2 ortalansýn
        }
        #region Form2 tasarým kodlamasý
        private void BileþeniBaþlat() {
            düðme2a = new Button();
            düðme2b = new Button();
            düðme2c = new Button();
            düðme2d = new Button();
            SuspendLayout();
            // düðme2a: resimli düðme
            düðme2a.BackgroundImage = new Bitmap ("resim/resim2a.jpg");
            düðme2a.Font = new Font ("Microsoft Sans Serif", 20F, FontStyle.Bold);
            düðme2a.ForeColor = Color.Black;
            düðme2a.Location = new Point (16, 192);
            düðme2a.Name = "düðme2a";
            düðme2a.Size = new Size (250, 250);
            düðme2a.TabIndex = 3;
            düðme2a.Text = "Resim Düðmesi";
            düðme2a.TextAlign = ContentAlignment.TopCenter;
            // düðme2b: standart düðme
            düðme2b.Font = new Font ("Microsoft Sans Serif", 12F);
            düðme2b.ForeColor = SystemColors.ControlText;
            düðme2b.BackColor=Color.Lime;
            düðme2b.Location = new Point (16, 80);
            düðme2b.Name = "düðme2b";
            düðme2b.Size = new Size (312, 88);
            düðme2b.TabIndex = 2;
            düðme2b.Text = "Ben standart metin düðmesiyim";
            düðme2b.Click += new EventHandler (düðme2b_Týklandý);
            // düðme2c: açýlýrmenü düðmesi
            düðme2c.FlatStyle = FlatStyle.Popup;
            düðme2c.ForeColor = SystemColors.ControlText;
            düðme2c.BackColor=Color.Yellow;
            düðme2c.Location = new Point (176, 24);
            düðme2c.Name = "düðme2c";
            düðme2c.Size = new Size (152, 32);
            düðme2c.TabIndex = 1;
            düðme2c.Text = "Ben AçýlýrMenü düðmesiyim!";
            // düðme2d
            düðme2d.FlatStyle = FlatStyle.Flat;
            düðme2d.ForeColor = Color.Green;
            düðme2d.BackColor=Color.Fuchsia;
            düðme2d.Location = new Point (16, 24);
            düðme2d.Name = "düðme2d";
            düðme2d.Size = new Size (152, 32);
            düðme2d.TabIndex = 0;
            düðme2d.Text = "Yayýlan düðmeyim";
            // Form2
            AcceptButton = düðme2b;
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (340, 450);
            //Controls.Add (düðme2a); Controls.Add (düðme2b); Controls.Add (düðme2c); Controls.Add (düðme2d);
            Controls.AddRange (new Control[] {düðme2a, düðme2b, düðme2c, düðme2d});
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form2";
            Text = "Form2: 4 Farklý Düðme";
            BackColor=Color.Navy;
            ResumeLayout (false);
        }
        #endregion
        protected void düðme2b_Týklandý (object k, EventArgs o) {      
            Array konumDeðerleri = Enum.GetValues (formKonumu.GetType());
            konumNo++;
            if (konumNo >= konumDeðerleri.Length) konumNo = 0;
            formKonumu = (ContentAlignment)ContentAlignment.Parse (formKonumu.GetType(), konumDeðerleri.GetValue (konumNo).ToString());
            düðme2b.TextAlign = formKonumu;
            düðme2b.Text = formKonumu.ToString();
            düðme2a.ImageAlign = formKonumu;
        }
    }
    public class Form3: Form {
        Button düðme3a;
        Button düðme3b;
        public Form3() {//Kurucu
            Size = new Size (200, 100);
            BackColor=Color.Black;
            Text = "Form3: 2 Olaylý Düðme";
            //düðme3a
            düðme3a = new Button();
            düðme3a.Parent = this; //"Controls.Add(düðme)" yerine
            düðme3a.Text = "1.Düðme";
            düðme3a.BackColor=Color.Pink;
            düðme3a.Location = new Point (10, 10);
            düðme3a.Click += new EventHandler (düðme3a_Týklandý);
            //düðme3b
            düðme3b = new Button();
            düðme3b.Parent = this;
            düðme3b.Text = "2.Düðme";
            düðme3b.ForeColor=Color.Yellow;
            düðme3b.BackColor=Color.Purple;
            düðme3b.Location = new Point (100, 10);
            düðme3b.Click += new EventHandler (düðme3b_Týklandý);
        }
        private void düðme3a_Týklandý (object k, EventArgs o) {
            MessageBox.Show ("Düðme-1 Týklandý.");
            düðme3b.PerformClick(); //düðme3b_Týklandý'yý çaðýrýr
        }
        private void düðme3b_Týklandý (object k, EventArgs o) {MessageBox.Show ("Düðme-2 Týklandý.");}
    }
    public class Form4: Form {
        Button düðme4;
        int i = 1;
        FlatStyle[] düzStiller;
        Image resim;
        public Form4() {//Kurucu
            Text = "Form4: Düz Stiller";
            Size = new Size (600, 550);
            BackColor=Color.Maroon;
            resim = Image.FromFile ("resim/resim2b.jpg");
            //düðme4
            düðme4 = new Button();
            düðme4.Parent = this;
            düðme4.Text = düðme4.FlatStyle.ToString();
            düðme4.Location = new Point (10, 10);
            düðme4.BackColor=Color.Aqua;
            düðme4.Click += new EventHandler (düðme4_Týklandý);
            düðme4.Image = resim;
            DüðmeEbatý (düðme4);
            //
            FlatStyle stilNo = new FlatStyle();
            düzStiller = (FlatStyle[])Enum.GetValues (stilNo.GetType());
        }
        private void düðme4_Týklandý (object k, EventArgs o) {
            Button düðme = (Button)k;
            düðme.FlatStyle = düzStiller [i];
            düðme.Text = düðme.FlatStyle.ToString();
            DüðmeEbatý (düðme);
            if (i < düzStiller.Length - 1) i++;
            else i = 0;
        }
        private void DüðmeEbatý (Button düðme) {
            int xEbat = ((int)(Font.Height * .75) * düðme.Text.Length) + (resim.Width * 2);
            int yEbat = resim.Height * 2;
            düðme.Size = new Size (xEbat, yEbat);
        }
    }
    public class Form5: Form {
        int i=0, j=0;
        Button düðme5;
        public Form5() {//Kurucu
            Text = "Form5: Deðiþken Düðme Ebatý";
            Size = new Size (300, 200);
            BackColor=Color.Sienna;
            //düðme5
            düðme5 = new Button();
            düðme5.Parent = this;
            düðme5.Text = "Týkla";
            düðme5.BackColor=Color.Cyan;
            düðme5.Location = new Point (10, 10);
            düðme5.Click += new EventHandler (düðme5_Týklandý);
        }
        private void düðme5_Týklandý (object k, EventArgs o) {
            Button düðme = (Button)k;
            düðme5_Ebat (düðme);
        }
        private void düðme5_Ebat (Button düðme) {
            if (++i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            düðme.Size = new Size (x, y);
            düðme.Text = i + ".Týklama";
        }
    }
    public class Form6: Form {
        int i=0, j=0;
        Button düðme6;
        public Form6() {//Kurucu
            Text = "Form6: Rasgele Deðiþken Düðme Rengi";
            Size = new Size (300, 200);
            BackColor=Color.Black;
            //düðme6
            düðme6 = new Button();
            düðme6.Parent = this;
            düðme6.Text = "Týkla";
            düðme6.BackColor=Color.DeepPink;
            düðme6.Location = new Point (20, 20);
            düðme6.Size = new Size (250, 130);
            düðme6.Click += new EventHandler (düðme6_Týklandý);
        }
        private void düðme6_Týklandý (object k, EventArgs o) {
            Button düðme = (Button)k;
            düðme.Text = ++i + ".Týklama";
            int kr, yþ, mv;
            Random r = new Random();
            kr = r.Next (0, 255); yþ = r.Next (0, 255); mv = r.Next (0, 255);
            düðme.BackColor = Color.FromArgb (kr, yþ, mv);
            BackColor = Color.FromArgb (255-kr, 255-yþ, 255-mv);
            if (i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            düðme.Size = new Size (x, y);
        }
    }
    public class Form7: Form {
        int i=0, j=0;
        Button düðme7;
        public Form7() {//Kurucu
            Text = "Form7: Düðmeli Renk ve Ebat";
            Size = new Size (350, 200);
            BackColor=Color.DarkGray;
            //düðme7
            düðme7 = new Button();
            düðme7.Parent = this;
            düðme7.Text = "M.Nihat Yavaþ";
            düðme7.Location = new Point (10,10);
            düðme7.Size = new Size (100, 50);
            düðme7.BackColor = Color.LightGreen;
            düðme7.TextAlign = ContentAlignment.MiddleLeft;
            düðme7.Click += new EventHandler (düðme7_Týklandý);
        }
        private void düðme7_Týklandý (object k, EventArgs o) {
            int kr, yþ, mv;
            Random r = new Random();
            kr = r.Next (0, 255); yþ = r.Next (0, 255); mv = r.Next (0, 255);
            düðme7.BackColor = Color.FromArgb (kr, yþ, mv);
            BackColor = Color.FromArgb (255-kr, 255-yþ, 255-mv);
            if (++i % 15 == 0) j=0;
            int x = 55 + (++j * 15);
            int y = 50 + (j * 5);
            düðme7.Size = new Size (x, y);
            düðme7.Text = i + ".Týklama";
        }
    }
    public class Form8: Form {
        Button düðme8;
        Image resim8;
        ImageList resimListesi8;
        int i=0, j=0;
        public Form8() {//Kurucu
            Text = "Form8: Ebat Deðiþtiren Resimli Düðme";
            Size = new Size (300, 300);
            BackColor=Color.SteelBlue;
            resim8 = Image.FromFile ("resim/resim2c.jpg");
            resimListesi8 = new ImageList();
            resimListesi8.Images.Add (resim8);
            //düðme8
            düðme8 = new Button();
            düðme8.Parent = this;
            düðme8.Location = new Point (10, 10);
            düðme8.Size = new Size (150, 150);
            resimListesi8.ImageSize = new Size (150, 150);
            düðme8.ImageList = resimListesi8;
            düðme8.ImageIndex = 0;
            düðme8.Click += new EventHandler (düðme8_Týklandý);
        }
        private void düðme8_Týklandý (object k, EventArgs o) {
            if (++i % 10 == 0) j=0;
            int x = 150 + (++j * 10);
            int y = 150 + (j * 10);
            düðme8.Size = new Size (x, y);
            resimListesi8.ImageSize = new Size (x, y);
            resimListesi8.Images.Add (resim8);
            düðme8.ImageList = resimListesi8;
            düðme8.ImageIndex = j; //Her yeni Images.Add ile endeks'te (azami 10) artýrýlmalýdýr
        }
    }
    public class Form9: Form {
        Button düðme9;
        Image resim9;
        ImageList resimListesi9;
        PictureBox resimKutusu;
        public Form9() {
            Size = new Size (300, 300);
            Text = "Form9: Resimkutusu ve Resimli Düðme";
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
            //düðme9
            düðme9 = new Button();
            düðme9.Parent = this;
            düðme9.Location = new Point (50, 50);
            düðme9.Size = new Size (200, 200);
            düðme9.ImageList = resimListesi9;
            düðme9.ImageIndex = 0;
            resimListesi9.ImageSize = new Size (200, 200);
        }
    }
    class Label_Button2 {
        static void Main() {
            Console.Write ("Düðme içi resim ebatý deðiþimi 'ImageList.ImageSize=new Size(x,y)' ile ayarlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Menülü etiket-düðme-resim bileþenli formlar:");
            int ts=0;
       baþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Form1 Düðmeli mesajkutusu");
            Console.WriteLine ("2: Form2 4 farklý düðme");
            Console.WriteLine ("3: Form3 2 olaylý düðme");
            Console.WriteLine ("4: Form4 Resim ve System düzstiller");
            Console.WriteLine ("5: Form5 Týklanýnca artan düðme ebatý");
            Console.WriteLine ("6: Form6 Týklanýnca deðiþen zemin ve düðme rengi");
            Console.WriteLine ("7: Form7 Týklanýnca deðiþen renk ve ebat");
            Console.WriteLine ("8: Form8 Düðme ve resim ebatý deðiþmesi");
            Console.WriteLine ("9: Form9 Resimkutusu ve resimli düðme");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto baþ;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 9) goto baþ;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Düðme1 týklanýnca mesaj kutusundan selamlama
                case 2: Application.Run (new Form2()); break; //Flat, Popup, Standart ve Image düðmeleri
                case 3: Application.Run (new Form3()); break; //Birdiðerini de çaðýran 2 olaylý düðme
                case 4: Application.Run (new Form4()); break; //2 resim ve 1 metin düzstilli düðme
                case 5: Application.Run (new Form5()); break; //Her týklamada ebatý artan düðme
                case 6: Application.Run (new Form6()); break; //Týklanýnca zeminin ve düðmenin rengi rasgele deðiþir
                case 7: Application.Run (new Form7()); break; //Týklanýnca renk ve ebat deðiþtiren düðme
                case 8: Application.Run (new Form8()); break; //Týklanýnca düðme ve resim ebatýnýn uyumlu deðiþimi
                case 9: Application.Run (new Form9()); break; //Resim ebatý ayarlanabilir resimkutusu ve resimlidüðme
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}