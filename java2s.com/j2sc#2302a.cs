// j2sc#2302a.cs: Form pencerede etiket ve düðme bileþenleri örneði.

using System;
using System.Windows.Forms; //Form, Label, TextBox için
using System.Drawing; //Size, Point, Image için
namespace Bileþenler {
    public class Form1: Form {
        Label etiket1a;
        TextBox metinkutu1;
        public Form1() {//Kurucu
            Size = new Size (1000, 700);
            BackColor=Color.YellowGreen;
            Text = "Form1: Metin ve Resim";
            //
            etiket1a = new Label();
            etiket1a.Parent = this;
            etiket1a.Text = "Girilen metin burada yansýr";
            etiket1a.Location = new Point (0, 0);
            etiket1a.AutoSize = true;
            etiket1a.BorderStyle = BorderStyle.Fixed3D;
            int y1 = etiket1a.Height + 10;
            //
            Image resim1 = Image.FromFile ("resim\\resim1a.jpg");
            Label etiket1b = new Label();
            etiket1b.Parent = this;
            etiket1b.Location = new Point (10, -180);
            etiket1b.Image = resim1;
            etiket1b.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            etiket1b.Size = new Size (resim1.Width, resim1.Height);
            //
            Label etiket1c = new Label();
            etiket1c.Parent = this;
            etiket1c.Text = "&Metni gir: ";
            etiket1c.Size = new Size (etiket1c.PreferredWidth, etiket1c.PreferredHeight);
            etiket1c.Location = new Point (0, y1);
            etiket1c.BorderStyle = BorderStyle.FixedSingle;
            //
            metinkutu1 = new TextBox();
            metinkutu1.Parent = this;
            metinkutu1.Size = new Size (100, 23);
            metinkutu1.Location = new Point (etiket1c.Width + 5, y1);
            metinkutu1.TextChanged += new EventHandler (metinkutu1_MetinDeðiþti);
        }
        private void metinkutu1_MetinDeðiþti (object k, EventArgs o) {etiket1a.Text = metinkutu1.Text;}
    }
    public class Form2: Form {
        ImageList resimListesi2a;
        Label etiket2a;
        LinkLabel baðlantýEtiket2a;
        Button düðme2a;
        public Form2() {//Kurucu
            Size = new Size (500,700);
            Text = "Form2: Altalta 3 Resim";
            BackColor=Color.Tan;
            resimListesi2a = new ImageList();
            Image resim2a;
            String[] resimDizisi = {"resim\\resim2a.jpg", "resim/resim2b.jpg", "resim\\resim2c.jpg"};
            for (int i = 0; i < resimDizisi.Length; i++) {
                resim2a = Image.FromFile (resimDizisi [i]);
                resimListesi2a.Images.Add (resim2a);
            }
            resimListesi2a.ImageSize = new Size (150, 150); //Dizideki tüm resimler bu ölçeðe ebatlanýr
            etiket2a = new Label();
            etiket2a.Parent = this;
            etiket2a.Text = "Label=Etiket:  ";
            etiket2a.Location = new Point (0, 0);
            etiket2a.Size = new Size (etiket2a.PreferredWidth + 2 + resimListesi2a.ImageSize.Width, resimListesi2a.ImageSize.Height + 10);
            etiket2a.BorderStyle = BorderStyle.Fixed3D;
            etiket2a.ImageList = resimListesi2a;
            etiket2a.ImageAlign = ContentAlignment.MiddleRight;
            int y2 = etiket2a.Height + 10;
            //
            baðlantýEtiket2a = new LinkLabel();
            baðlantýEtiket2a.Parent = this;
            baðlantýEtiket2a.Text = "LinkLabel=BaðlantýEtiketi:  ";
            baðlantýEtiket2a.Size = new Size (baðlantýEtiket2a.PreferredWidth + 1 + resimListesi2a.ImageSize.Width, resimListesi2a.ImageSize.Height + 10);
            baðlantýEtiket2a.Location = new Point (0, y2);
            baðlantýEtiket2a.ImageList = resimListesi2a;
            baðlantýEtiket2a.ImageAlign = ContentAlignment.MiddleRight;
            //
            düðme2a = new Button();
            düðme2a.Parent = this;
            düðme2a.BackColor=Color.Black;
            düðme2a.ImageList = resimListesi2a;
            //düðme2a.ImageIndex = resimListesi2a.Images.Count - 1;
            düðme2a.Location = new Point (0, 2 * y2);
            düðme2a.Size = new Size (3 * resimListesi2a.ImageSize.Width, 2 * resimListesi2a.ImageSize.Height);
            //
            etiket2a.ImageIndex = 1;
            baðlantýEtiket2a.ImageIndex = 0;
            düðme2a.ImageIndex = 2;

        }
    }
    public class Form3: Form {
        private Label etiket3a;
        public Form3() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            etiket3a = new Label();
            SuspendLayout();
            // etiket3a
            etiket3a.Location = new Point (40, 25);
            etiket3a.Name = "etiket3a";
            etiket3a.Size = new Size (150, 35);
            etiket3a.TabIndex = 0;
            etiket3a.Text = "\n   Týklanan Etiket Olayý";
            etiket3a.BackColor=Color.DarkRed;
            etiket3a.ForeColor=Color.Yellow;
            etiket3a.Click += new EventHandler (TýklamaOlayYönetimi);
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (242, 173);
            Text = "Form3: Etiketi Týklama Olayý";
            BackColor=Color.SteelBlue;
            Controls.Add (etiket3a);
            ResumeLayout (false);
        }
        private void TýklamaOlayYönetimi (object k, EventArgs o) {MessageBox.Show ("Týklama olay yönetiminin mesaj kutusu", "Etiketin Týklanma Olayý");}
    }
    class Form4: Form {
        Button düðme4 = new Button();
        public Form4() {//Kurucu
            Text = "Form4: Olaysýz Düðme";
            BackColor=Color.Wheat;
            düðme4 = new Button();
            düðme4.Text = "Duyarsýz Týkla!";
            düðme4.Location = new Point (60, 100);
            düðme4.Size = new Size (150, 50);
            düðme4.BackColor=Color.YellowGreen;
            Controls.Add (düðme4);
        }
    }
    class Form5: Form {
        Button düðme5 = new Button();
        int i=0;
        public Form5() {//Kurucu
            Text = "Form5: Olaylý Düðme";
            BackColor=Color.YellowGreen;
            düðme5.Text = "Duyarlý Týkla!";
            düðme5.Location = new Point (60, 100);
            düðme5.Size = new Size (150, 50);
            düðme5.BackColor=Color.Wheat;
            Controls.Add (düðme5);
            düðme5.Click += düðme5_Týklandý;
            Controls.Add (düðme5);
        }
        protected void düðme5_Týklandý (object k, EventArgs o) {Console.WriteLine ("{0}.kez týklandý.", ++i);}
    }
    class Form6: Form {
        Button düðme6 = new Button(); 
        public Form6() {//Kurucu
            Text = "Form6: Renk&Konum Olaylý Düðme";
            BackColor=Color.Violet;
            düðme6.Text = "Renk&Konum Týkla!";
            düðme6.Location = new Point (60, 100);
            düðme6.Size = new Size (200, 80);
            düðme6.BackColor=Color.Thistle;
            Controls.Add (düðme6);
            düðme6.Click += düðme6_Týklandý;
            Controls.Add (düðme6); 
        }
        protected void düðme6_Týklandý (object k, EventArgs o) {
            int kr, yþ, mv;
            Random r = new Random();
            kr = r.Next (0, 255); yþ = r.Next (0, 255); mv = r.Next (0, 255);
            düðme6.BackColor = Color.FromArgb (kr, yþ, mv); //(kýrmýzý,yeþil,mavi)
            Console.WriteLine ("Yeni RGB renk: ({0}, {1}, {2}", kr, yþ, mv);
            düðme6.Location = new Point (kr, yþ);
        } 
    }
    class Form7: Form {
        Button düðme7a = new Button();
        Button düðme7b = new Button();
        public Form7() {//Kurucu
            Text = "Form7: Kapa&Çýk Olaylý Düðmeler";
            BackColor=Color.Sienna;
            düðme7a.Text = "Pencereyi Kapat";
            düðme7a.Location = new Point (50, 50);
            düðme7a.Size = new Size (150, 30);
            düðme7a.BackColor=Color.Lime;
            Controls.Add (düðme7a);
            düðme7a.Click += düðme7a_Týklandý;
            düðme7b.Text = "Uygulamadan Çýk";
            düðme7b.Location = new Point (50, 150);
            düðme7b.Size = new Size (150, 30);
            düðme7b.BackColor=Color.Red;
            Controls.Add (düðme7b);
            düðme7b.Click += düðme7b_Týklandý;
            Controls.Add (düðme7b);
        }
        protected void düðme7a_Týklandý (object k, EventArgs o) {this.Close();}
        protected void düðme7b_Týklandý (object k, EventArgs o) {Application.Exit();}
    }
    partial class Form8: Form {
        private Button düðme8a;
        private Button düðme8b;
        public Form8() {BileþeniBaþlat();}
        private void düðme8a_FareÜstte (object k, EventArgs o) {düðme8a.Text = "Fare üzerimde";}
        private void düðme8a_FareDýþta (object k, EventArgs o) {düðme8a.Text = "Fare üstümde deðil";}
        private void düðme_Týklandý (object k, EventArgs o) {
            Button týklandý = k as Button;
            if (týklandý != null) {týklandý.Text = "Beni týklattýn!";}
        }
    }
    partial class Form8 {
        private void BileþeniBaþlat() {
            düðme8a = new Button();
            düðme8b = new Button();
            SuspendLayout();
            // düðme8a
            düðme8a.Location = new Point (86, 89);
            düðme8a.Name = "düðme8a";
            düðme8a.Size = new Size (150, 100);
            düðme8a.TabIndex = 0;
            düðme8a.Text = "Fare olaylý düðme";
            düðme8a.BackColor=Color.Cyan;
            düðme8a.MouseEnter += new EventHandler (düðme8a_FareÜstte);
            düðme8a.MouseLeave += new EventHandler (düðme8a_FareDýþta);
            düðme8a.Click += new EventHandler (düðme_Týklandý);
            // düðme8b: Olaysýz düðme
            düðme8b.Location = new Point (86, 25);
            düðme8b.Name = "düðme8b";
            düðme8b.Size = new Size (150, 25);
            düðme8b.TabIndex = 1;
            düðme8b.Text = "Fare olaysýz düðme";
            düðme8b.BackColor=Color.SkyBlue;
            düðme8b.Click += new EventHandler (düðme_Týklandý);
            // Form8
            //AutoScaleBaseSize = new Size (6, 15);
            ClientSize = new Size (292, 266);
            Controls.Add (düðme8b);
            Controls.Add (düðme8a);
            Name = "Form8";
            Text = "Form8: Olaylý&Olaysýz Düðmeler";
            BackColor=Color.Maroon;
            ResumeLayout (false);
        }
    }
    public class Form9: Form {
        private Label etiket9;
        private TextBox metinKutusu9;
        private Button düðme9;
        public Form9() {BileþeniBaþlat();} //Kurucu
        #region Form penceresi tasarým kodlamasý
        private void BileþeniBaþlat() {
            etiket9 = new Label();
            metinKutusu9 = new TextBox();
            düðme9 = new Button();
            SuspendLayout();
            //
            etiket9.Location = new Point (20, 24);
            etiket9.Size = new Size (150, 20);
            etiket9.Name = "etiket9";
            etiket9.TabIndex = 0;
            etiket9.Text = "Merhaba, ben etiket!";
            etiket9.BackColor=Color.Yellow;
            //
            metinKutusu9.Location = new Point (20, 110);
            metinKutusu9.Size = new Size (250, 20);
            metinKutusu9.Name = "metinKutusu9";
            metinKutusu9.TabIndex = 1;
            metinKutusu9.Text = "Girilen düðme týklanýnca etikette yansýr";
            metinKutusu9.BackColor=Color.Pink;
            //
            düðme9.Location = new Point (20, 188);
            düðme9.Size = new Size (150, 30);
            düðme9.Name = "düðme9";
            düðme9.TabIndex = 2;
            düðme9.Text = "Merhaba, ben düðme!";
            düðme9.BackColor=Color.Purple;
            düðme9.Click += new EventHandler (düðme9_Týklandý);
            //
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 266);
            Controls.AddRange (new Control[] {düðme9, etiket9, metinKutusu9});
            Name = "Form9";
            Text = "Form9: Etiket, Düðme ve Metinkutusu";
            BackColor=Color.SeaGreen;
            ResumeLayout (false);
        }
        #endregion
        private void düðme9_Týklandý (object k, EventArgs o) {etiket9.Text = "Merhaba " + metinKutusu9.Text;}
    }
    class Label_Button {
        [STAThread]
        static void Main() {
            Console.Write ("Switch-case-break-default menü yapýsýyla pencereler tekrar koþturulabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Menülü etiket-düðme bileþenli formlar:");
            int ts=0;
       baþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Form1 Tek resimli metin");
            Console.WriteLine ("2: Form2 Çoklu resim");
            Console.WriteLine ("3: Form3 Etiket týklama olayý");
            Console.WriteLine ("4: Form4 Duyarsýz bir düðme");
            Console.WriteLine ("5: Form5 Duyarlý bir düðme");
            Console.WriteLine ("6: Form6 Renk&Konum'lu düðme");
            Console.WriteLine ("7: Form7 Kapat&Çýk'lý düðmeler");
            Console.WriteLine ("8: Form8 Fare&Týkla'lý düðmeler");
            Console.WriteLine ("9: Form9 Etiket&Düðme&Metinkutusu");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto baþ;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 9) goto baþ;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Metni girebilmek için pencereyi sað kenarýndan geniþletin
                case 2: Application.Run (new Form2()); break; //Altalta etiket, baðlantýEtiketi ve düðme'li 3 resim sunulur
                case 3: Application.Run (new Form3()); break; //Etiket içi týklama olay yönetimi
                case 4: Application.Run (new Form4()); break; //Olaysýz tek düðme
                case 5: Application.Run (new Form5()); break; //Olaylý tek düðme
                case 6: Application.Run (new Form6()); break; //Týklanýnca düðmenin renk ve konumu rasgele deðiþir
                case 7: Application.Run (new Form7()); break; //Üst düðme pencereyi kapar, alt düðme tüm uygulamadan çýkar
                case 8: Application.Run (new Form8()); break; //Fare olaylý tek ve týklama olaylý çift düðme
                case 9: Application.Run (new Form9()); break; //Týklanan düðmeyle, metinkutusundaki etikette yansýr
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}