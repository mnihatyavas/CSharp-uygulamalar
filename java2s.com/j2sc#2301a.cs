// j2sc#2301a.cs: Form, Text, Size Button, TextBox, Click, Controls.Add �rne�i.

using System;
using System.Windows.Forms; //Form i�in
using System.Drawing; //Size i�in
namespace Formlar {
    class Giri�1: Form {
        public Giri�1(){} //Kurucu1
    }
    class Giri�2: Form {
        public Giri�2() {Bile�eniBa�lat();} //Kurucu2
        private void Bile�eniBa�lat() {
            this.Size = new Size (300, 300);
            this.Text = "�lk Pencerem";
        }
    }
    class Giri�3: Form {
        public Giri�3() {Text = "Bir Pencere �skeleti";} //Kurucu3
    }
    class Giri�4: Form {
        Button ��k��D��mesi;
        public Giri�4() {//Kurucu4
            Text = "Bir ��k��D��mesi Ekleme";
            ��k��D��mesi = new Button();
            ��k��D��mesi.Text = "��k";
            ��k��D��mesi.Location = new Point (100, 100);
            ��k��D��mesi.Click += ��k��D��mesiniT�kla; 
            Controls.Add (��k��D��mesi);
        }
        protected void ��k��D��mesiniT�kla (object kim, EventArgs olay) {Application.Exit();}
    }
    class Giri�5: Form {
        private Button d��me1;
        private TextBox metinKutusu1;
        public Giri�5() {//Kurucu5
            Text = "Metinkutulu D��me";
            ForeColor = Color.Sienna;
            d��me1 = new Button();
            metinKutusu1 = new TextBox();
            // d��me1'in kontrolu ve �zellikleri
            d��me1.Location = new Point (8, 32);
            d��me1.Name = "d��me1";
            d��me1.Size = new Size (104, 32);
            d��me1.TabIndex = 0;
            d��me1.Text = "T�kla beni";
            // metinKutusu1'in kontrolu ve �zellikleri
            metinKutusu1.Location = new Point (24, 104);
            metinKutusu1.Name = "metinKutusu1";
            metinKutusu1.Size = new Size (184, 20);
            metinKutusu1.TabIndex = 1;
            metinKutusu1.Text = "Metin Kutusu";
            // Kontrollar� frm'a ekle
            Controls.AddRange (new Control[] {metinKutusu1, d��me1});
            d��me1.Click += new EventHandler (d��me1_T�kland�);
        }
        private void d��me1_T�kland� (object g�nderen, EventArgs olay) {
            metinKutusu1.Text = "D��me t�kland�";
            MessageBox.Show ("D��meyi t�klad�n�z");
        }
    }
    class Giri� {
        [STAThread]
        static void Main() {
            Console.Write ("'Application.Run(new Giri�())' ile kurucuyla haz�rlanan form aktif k�l�n�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 farkl� kuruculu form yaratma y�ntemleri:");
            Application.Run (new Giri�1());
            Application.Run (new Giri�2());
            Giri�3 iskelet1 = new Giri�3();
            Application.Run (iskelet1);
            Application.Run (new Giri�4());
            Application.Run (new Giri�5());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}