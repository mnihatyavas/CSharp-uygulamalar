// j2sc#2301a.cs: Form, Text, Size Button, TextBox, Click, Controls.Add örneði.

using System;
using System.Windows.Forms; //Form için
using System.Drawing; //Size için
namespace Formlar {
    class Giriþ1: Form {
        public Giriþ1(){} //Kurucu1
    }
    class Giriþ2: Form {
        public Giriþ2() {BileþeniBaþlat();} //Kurucu2
        private void BileþeniBaþlat() {
            this.Size = new Size (300, 300);
            this.Text = "Ýlk Pencerem";
        }
    }
    class Giriþ3: Form {
        public Giriþ3() {Text = "Bir Pencere Ýskeleti";} //Kurucu3
    }
    class Giriþ4: Form {
        Button ÇýkýþDüðmesi;
        public Giriþ4() {//Kurucu4
            Text = "Bir ÇýkýþDüðmesi Ekleme";
            ÇýkýþDüðmesi = new Button();
            ÇýkýþDüðmesi.Text = "Çýk";
            ÇýkýþDüðmesi.Location = new Point (100, 100);
            ÇýkýþDüðmesi.Click += ÇýkýþDüðmesiniTýkla; 
            Controls.Add (ÇýkýþDüðmesi);
        }
        protected void ÇýkýþDüðmesiniTýkla (object kim, EventArgs olay) {Application.Exit();}
    }
    class Giriþ5: Form {
        private Button düðme1;
        private TextBox metinKutusu1;
        public Giriþ5() {//Kurucu5
            Text = "Metinkutulu Düðme";
            ForeColor = Color.Sienna;
            düðme1 = new Button();
            metinKutusu1 = new TextBox();
            // düðme1'in kontrolu ve özellikleri
            düðme1.Location = new Point (8, 32);
            düðme1.Name = "düðme1";
            düðme1.Size = new Size (104, 32);
            düðme1.TabIndex = 0;
            düðme1.Text = "Týkla beni";
            // metinKutusu1'in kontrolu ve özellikleri
            metinKutusu1.Location = new Point (24, 104);
            metinKutusu1.Name = "metinKutusu1";
            metinKutusu1.Size = new Size (184, 20);
            metinKutusu1.TabIndex = 1;
            metinKutusu1.Text = "Metin Kutusu";
            // Kontrollarý frm'a ekle
            Controls.AddRange (new Control[] {metinKutusu1, düðme1});
            düðme1.Click += new EventHandler (düðme1_Týklandý);
        }
        private void düðme1_Týklandý (object gönderen, EventArgs olay) {
            metinKutusu1.Text = "Düðme týklandý";
            MessageBox.Show ("Düðmeyi týkladýnýz");
        }
    }
    class Giriþ {
        [STAThread]
        static void Main() {
            Console.Write ("'Application.Run(new Giriþ())' ile kurucuyla hazýrlanan form aktif kýlýnýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 farklý kuruculu form yaratma yöntemleri:");
            Application.Run (new Giriþ1());
            Application.Run (new Giriþ2());
            Giriþ3 iskelet1 = new Giriþ3();
            Application.Run (iskelet1);
            Application.Run (new Giriþ4());
            Application.Run (new Giriþ5());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}