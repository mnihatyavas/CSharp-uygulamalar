// j2sc#2302a.cs: Form pencerede etiket ve d��me bile�enleri �rne�i.

using System;
using System.Windows.Forms; //Form, Label, TextBox i�in
using System.Drawing; //Size, Point, Image i�in
namespace Bile�enler {
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
            etiket1a.Text = "Girilen metin burada yans�r";
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
            metinkutu1.TextChanged += new EventHandler (metinkutu1_MetinDe�i�ti);
        }
        private void metinkutu1_MetinDe�i�ti (object k, EventArgs o) {etiket1a.Text = metinkutu1.Text;}
    }
    public class Form2: Form {
        ImageList resimListesi2a;
        Label etiket2a;
        LinkLabel ba�lant�Etiket2a;
        Button d��me2a;
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
            resimListesi2a.ImageSize = new Size (150, 150); //Dizideki t�m resimler bu �l�e�e ebatlan�r
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
            ba�lant�Etiket2a = new LinkLabel();
            ba�lant�Etiket2a.Parent = this;
            ba�lant�Etiket2a.Text = "LinkLabel=Ba�lant�Etiketi:  ";
            ba�lant�Etiket2a.Size = new Size (ba�lant�Etiket2a.PreferredWidth + 1 + resimListesi2a.ImageSize.Width, resimListesi2a.ImageSize.Height + 10);
            ba�lant�Etiket2a.Location = new Point (0, y2);
            ba�lant�Etiket2a.ImageList = resimListesi2a;
            ba�lant�Etiket2a.ImageAlign = ContentAlignment.MiddleRight;
            //
            d��me2a = new Button();
            d��me2a.Parent = this;
            d��me2a.BackColor=Color.Black;
            d��me2a.ImageList = resimListesi2a;
            //d��me2a.ImageIndex = resimListesi2a.Images.Count - 1;
            d��me2a.Location = new Point (0, 2 * y2);
            d��me2a.Size = new Size (3 * resimListesi2a.ImageSize.Width, 2 * resimListesi2a.ImageSize.Height);
            //
            etiket2a.ImageIndex = 1;
            ba�lant�Etiket2a.ImageIndex = 0;
            d��me2a.ImageIndex = 2;

        }
    }
    public class Form3: Form {
        private Label etiket3a;
        public Form3() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            etiket3a = new Label();
            SuspendLayout();
            // etiket3a
            etiket3a.Location = new Point (40, 25);
            etiket3a.Name = "etiket3a";
            etiket3a.Size = new Size (150, 35);
            etiket3a.TabIndex = 0;
            etiket3a.Text = "\n   T�klanan Etiket Olay�";
            etiket3a.BackColor=Color.DarkRed;
            etiket3a.ForeColor=Color.Yellow;
            etiket3a.Click += new EventHandler (T�klamaOlayY�netimi);
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (242, 173);
            Text = "Form3: Etiketi T�klama Olay�";
            BackColor=Color.SteelBlue;
            Controls.Add (etiket3a);
            ResumeLayout (false);
        }
        private void T�klamaOlayY�netimi (object k, EventArgs o) {MessageBox.Show ("T�klama olay y�netiminin mesaj kutusu", "Etiketin T�klanma Olay�");}
    }
    class Form4: Form {
        Button d��me4 = new Button();
        public Form4() {//Kurucu
            Text = "Form4: Olays�z D��me";
            BackColor=Color.Wheat;
            d��me4 = new Button();
            d��me4.Text = "Duyars�z T�kla!";
            d��me4.Location = new Point (60, 100);
            d��me4.Size = new Size (150, 50);
            d��me4.BackColor=Color.YellowGreen;
            Controls.Add (d��me4);
        }
    }
    class Form5: Form {
        Button d��me5 = new Button();
        int i=0;
        public Form5() {//Kurucu
            Text = "Form5: Olayl� D��me";
            BackColor=Color.YellowGreen;
            d��me5.Text = "Duyarl� T�kla!";
            d��me5.Location = new Point (60, 100);
            d��me5.Size = new Size (150, 50);
            d��me5.BackColor=Color.Wheat;
            Controls.Add (d��me5);
            d��me5.Click += d��me5_T�kland�;
            Controls.Add (d��me5);
        }
        protected void d��me5_T�kland� (object k, EventArgs o) {Console.WriteLine ("{0}.kez t�kland�.", ++i);}
    }
    class Form6: Form {
        Button d��me6 = new Button(); 
        public Form6() {//Kurucu
            Text = "Form6: Renk&Konum Olayl� D��me";
            BackColor=Color.Violet;
            d��me6.Text = "Renk&Konum T�kla!";
            d��me6.Location = new Point (60, 100);
            d��me6.Size = new Size (200, 80);
            d��me6.BackColor=Color.Thistle;
            Controls.Add (d��me6);
            d��me6.Click += d��me6_T�kland�;
            Controls.Add (d��me6); 
        }
        protected void d��me6_T�kland� (object k, EventArgs o) {
            int kr, y�, mv;
            Random r = new Random();
            kr = r.Next (0, 255); y� = r.Next (0, 255); mv = r.Next (0, 255);
            d��me6.BackColor = Color.FromArgb (kr, y�, mv); //(k�rm�z�,ye�il,mavi)
            Console.WriteLine ("Yeni RGB renk: ({0}, {1}, {2}", kr, y�, mv);
            d��me6.Location = new Point (kr, y�);
        } 
    }
    class Form7: Form {
        Button d��me7a = new Button();
        Button d��me7b = new Button();
        public Form7() {//Kurucu
            Text = "Form7: Kapa&��k Olayl� D��meler";
            BackColor=Color.Sienna;
            d��me7a.Text = "Pencereyi Kapat";
            d��me7a.Location = new Point (50, 50);
            d��me7a.Size = new Size (150, 30);
            d��me7a.BackColor=Color.Lime;
            Controls.Add (d��me7a);
            d��me7a.Click += d��me7a_T�kland�;
            d��me7b.Text = "Uygulamadan ��k";
            d��me7b.Location = new Point (50, 150);
            d��me7b.Size = new Size (150, 30);
            d��me7b.BackColor=Color.Red;
            Controls.Add (d��me7b);
            d��me7b.Click += d��me7b_T�kland�;
            Controls.Add (d��me7b);
        }
        protected void d��me7a_T�kland� (object k, EventArgs o) {this.Close();}
        protected void d��me7b_T�kland� (object k, EventArgs o) {Application.Exit();}
    }
    partial class Form8: Form {
        private Button d��me8a;
        private Button d��me8b;
        public Form8() {Bile�eniBa�lat();}
        private void d��me8a_Fare�stte (object k, EventArgs o) {d��me8a.Text = "Fare �zerimde";}
        private void d��me8a_FareD��ta (object k, EventArgs o) {d��me8a.Text = "Fare �st�mde de�il";}
        private void d��me_T�kland� (object k, EventArgs o) {
            Button t�kland� = k as Button;
            if (t�kland� != null) {t�kland�.Text = "Beni t�klatt�n!";}
        }
    }
    partial class Form8 {
        private void Bile�eniBa�lat() {
            d��me8a = new Button();
            d��me8b = new Button();
            SuspendLayout();
            // d��me8a
            d��me8a.Location = new Point (86, 89);
            d��me8a.Name = "d��me8a";
            d��me8a.Size = new Size (150, 100);
            d��me8a.TabIndex = 0;
            d��me8a.Text = "Fare olayl� d��me";
            d��me8a.BackColor=Color.Cyan;
            d��me8a.MouseEnter += new EventHandler (d��me8a_Fare�stte);
            d��me8a.MouseLeave += new EventHandler (d��me8a_FareD��ta);
            d��me8a.Click += new EventHandler (d��me_T�kland�);
            // d��me8b: Olays�z d��me
            d��me8b.Location = new Point (86, 25);
            d��me8b.Name = "d��me8b";
            d��me8b.Size = new Size (150, 25);
            d��me8b.TabIndex = 1;
            d��me8b.Text = "Fare olays�z d��me";
            d��me8b.BackColor=Color.SkyBlue;
            d��me8b.Click += new EventHandler (d��me_T�kland�);
            // Form8
            //AutoScaleBaseSize = new Size (6, 15);
            ClientSize = new Size (292, 266);
            Controls.Add (d��me8b);
            Controls.Add (d��me8a);
            Name = "Form8";
            Text = "Form8: Olayl�&Olays�z D��meler";
            BackColor=Color.Maroon;
            ResumeLayout (false);
        }
    }
    public class Form9: Form {
        private Label etiket9;
        private TextBox metinKutusu9;
        private Button d��me9;
        public Form9() {Bile�eniBa�lat();} //Kurucu
        #region Form penceresi tasar�m kodlamas�
        private void Bile�eniBa�lat() {
            etiket9 = new Label();
            metinKutusu9 = new TextBox();
            d��me9 = new Button();
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
            metinKutusu9.Text = "Girilen d��me t�klan�nca etikette yans�r";
            metinKutusu9.BackColor=Color.Pink;
            //
            d��me9.Location = new Point (20, 188);
            d��me9.Size = new Size (150, 30);
            d��me9.Name = "d��me9";
            d��me9.TabIndex = 2;
            d��me9.Text = "Merhaba, ben d��me!";
            d��me9.BackColor=Color.Purple;
            d��me9.Click += new EventHandler (d��me9_T�kland�);
            //
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 266);
            Controls.AddRange (new Control[] {d��me9, etiket9, metinKutusu9});
            Name = "Form9";
            Text = "Form9: Etiket, D��me ve Metinkutusu";
            BackColor=Color.SeaGreen;
            ResumeLayout (false);
        }
        #endregion
        private void d��me9_T�kland� (object k, EventArgs o) {etiket9.Text = "Merhaba " + metinKutusu9.Text;}
    }
    class Label_Button {
        [STAThread]
        static void Main() {
            Console.Write ("Switch-case-break-default men� yap�s�yla pencereler tekrar ko�turulabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Men�l� etiket-d��me bile�enli formlar:");
            int ts=0;
       ba�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Form1 Tek resimli metin");
            Console.WriteLine ("2: Form2 �oklu resim");
            Console.WriteLine ("3: Form3 Etiket t�klama olay�");
            Console.WriteLine ("4: Form4 Duyars�z bir d��me");
            Console.WriteLine ("5: Form5 Duyarl� bir d��me");
            Console.WriteLine ("6: Form6 Renk&Konum'lu d��me");
            Console.WriteLine ("7: Form7 Kapat&��k'l� d��meler");
            Console.WriteLine ("8: Form8 Fare&T�kla'l� d��meler");
            Console.WriteLine ("9: Form9 Etiket&D��me&Metinkutusu");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto ba�;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 9) goto ba�;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Metni girebilmek i�in pencereyi sa� kenar�ndan geni�letin
                case 2: Application.Run (new Form2()); break; //Altalta etiket, ba�lant�Etiketi ve d��me'li 3 resim sunulur
                case 3: Application.Run (new Form3()); break; //Etiket i�i t�klama olay y�netimi
                case 4: Application.Run (new Form4()); break; //Olays�z tek d��me
                case 5: Application.Run (new Form5()); break; //Olayl� tek d��me
                case 6: Application.Run (new Form6()); break; //T�klan�nca d��menin renk ve konumu rasgele de�i�ir
                case 7: Application.Run (new Form7()); break; //�st d��me pencereyi kapar, alt d��me t�m uygulamadan ��kar
                case 8: Application.Run (new Form8()); break; //Fare olayl� tek ve t�klama olayl� �ift d��me
                case 9: Application.Run (new Form9()); break; //T�klanan d��meyle, metinkutusundaki etikette yans�r
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}