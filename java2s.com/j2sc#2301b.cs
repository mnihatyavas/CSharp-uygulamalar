// j2sc#2301b.cs: Form, kurucusu, koþturulmasý, bileþenleri örneði.

using System;
using System.Windows.Forms; //:Form için
using System.Drawing; //Color için
using System.Threading; //Thread.Sleep için
namespace Formlar {
    class Form1: Form {}
    class Form2: Form {
        public Form2() {
            Text = "System.Windows.Form Miraslandý";
            BackColor = Color.Cyan;
            Size = new Size (500, 300); //en,boy
        }
    }
    class Form3: Form {
        public Form3() {//Kurucu
            Text = "'Merhaba Dünya' Formu";
            BackColor = Color.Lime;
            Size = new Size (500, 300);
        }
        protected override void OnPaint (PaintEventArgs boya) {
            Graphics grafik = boya.Graphics;
            grafik.DrawString ("Merhaba, Windows Formlarý!", Font, Brushes.Black, 0, 0);
        }
    }
    class Form4: Form {
        private Label etiket1;
        private TextBox metinKutusu1;
        private Button düðme1;
        public Form4() {
            this.etiket1 = new Label();
            this.metinKutusu1 = new TextBox();
            this.düðme1 = new Button();
            this.SuspendLayout();
            //etiket1 bileþeni
            this.etiket1.Location = new Point (16, 36); //(yatay,dikey) baþlama noktasý
            this.etiket1.Name = "etiket1"; //Deðiþken adý
            this.etiket1.Size = new Size (128, 16);
            this.etiket1.TabIndex = 0; //Tab'la odaklanma sýrasý
            this.etiket1.Text = "Lütfen ismini gir:"; 
            //metinKutusu1 bileþeni
            this.metinKutusu1.Location = new Point (152, 32);
            this.metinKutusu1.Name = "metinKutusu1";
            this.metinKutusu1.TabIndex = 1;
            this.metinKutusu1.Text = "";
            //düðme1 bileþeni
            this.düðme1.Location = new Point (109, 80);
            this.düðme1.Name = "düðme1";
            this.düðme1.TabIndex = 2;
            this.düðme1.Text = "Gir";
            this.düðme1.Click += new EventHandler (this.düðme1_Týkla);
            //Son rötuþlar
            this.ClientSize = new Size (292, 126);
            this.Controls.Add (this.düðme1);
            this.Controls.Add (this.metinKutusu1);
            this.Controls.Add (this.etiket1);
            this.Name = "form4";
            this.Text = "Visual C#";
            //SuspendLayout() iptali
            this.ResumeLayout (false);
        }
        private void düðme1_Týkla (object gönderen, EventArgs olay) {
            Console.WriteLine ("Kullanýcýnýn girdiði ad: " + metinKutusu1.Text);
            MessageBox.Show ("Hoþgeldin, " + metinKutusu1.Text + "!..", "Visual C#");
        }
    }
    class Form5: Form {
        private TextBox metinKutusu2 = new TextBox(); 
        private Button düðme2 = new Button();
        public Form5() {//Kurucu
            //metinKutusu2
            metinKutusu2.Text = "Metin";
            metinKutusu2.Size = new Size (150, 50);
            metinKutusu2.Location = new Point (10, 10);
            this.Controls.Add (metinKutusu2);
            //düðme2
            düðme2.Text = "Týkla beni!";
            düðme2.Size = new Size (90, 90);
            düðme2.Location = new Point (10, 70);
            düðme2.Click += new EventHandler (düðme2_Týklandý);
            this.Controls.Add(düðme2);
            //Form5 ekraný ortalasýn
            CenterToScreen();
        }
        protected void düðme2_Týklandý (object kim, EventArgs olay) {
            Control.ControlCollection kontrollar = this.Controls;
            foreach (Control k in kontrollar) {
                if(k != null) Console.WriteLine (string.Format ("Endeks: {0}, Açýklama: {1}", kontrollar.GetChildIndex (k, false), k.Text));
            }
            MessageBox.Show ("Mesaj", "Herbir kontrolun endeks ve metni");
        }
    }
    public class Form6: Form {
        private Button düðme6a;
        private Button düðme6b;
        protected Label etiket6;
        public Form6() {//Kurucu
            //düðme6a
            düðme6a = new Button();
            düðme6a.Location = new Point (25, 100);
            düðme6a.Size = new Size (100, 25);
            düðme6a.Text = "&Kapat"; //Alt-K
            düðme6a.Click += new EventHandler (düðme6a_Týklandý);
            //düðme6b
            düðme6b = new Button();
            düðme6b.Location = new Point (200, 100);
            düðme6b.Size = new Size (150, 25);
            düðme6b.Text = "&Form6 Uygulamasý"; //Alt-F
            düðme6b.Click += new EventHandler(düðme6b_Týklandý);
            //etiket6
            etiket6 = new Label();
            etiket6.Location = new Point (25, 25);
            etiket6.Size = new Size (150, 25);
            etiket6.Text = "Form6 ETÝKETLÝ BAÞLIK";
            //Kontrollar
            Controls.AddRange (new Control[]{etiket6, düðme6a, düðme6b});
        }
        private void düðme6a_Týklandý (object kim, EventArgs olay) {Application.Exit();} //Tüm j2sc#2301b.exe kapanýr
        private void düðme6b_Týklandý (object kim, EventArgs oly) {
            MessageBox.Show ("Bu Form6 Uygulamasýdýr.");
            BirMetot();
        }
        protected virtual void BirMetot(){MessageBox.Show ("Bu, Form6'dan çaðrýlan BirMetot()'dur.");}
    }
    class FormA {
        static void Main() {
            Console.Write ("Doðrudan 'Application.Run(new Form1())', yada 'Form1 form1 = new Form1()' ve 'Application.Run(form1)' ile koþturulur. Form bileþenleri genelde kurucuyla tesis edilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli form, kurucusu, koþturulmasý, bileþenler, kontrollar ve týklama:");
            Form1 form1 = new Form1(); //Kurucusuz
            Application.Run (new System.Windows.Forms.Form()); //Varsayýlý boþ form
            form1.Text = "System.Windows.Form Miraslandý";
            form1.BackColor = Color.Cyan;
            form1.Size = new Size (500, 300);
            Application.Run (form1);
            Application.Run (new Form2()); //Kuruculu
            Application.Run (new Form3());
            Application.EnableVisualStyles();
            Application.Run (new Form4());
            Form form2 = new Form();
            form2.Show(); //Varsayýlý boþ form
            Application.Run (form2);
            Form form3 = new Form();
            form3.Show(); Application.Run (form3);
            Thread.Sleep (1000);
            form3.Text = "Ukulu Form";
            Thread.Sleep (1000);
            Form form4 = new Form();
            form4.Text = "Yanlýþ fikir...";
            form4.Visible = true;
            Application.Run (form4); //form4 kontrolu Main'e döner, yoksa hatayla kýrar
            Form form5a = new Form();
            Form form5b = new Form();
            form5a.Text = "Run()'la koþan form5a";
            form5b.Text = "Show()'la gösterilen form5b";
            form5b.Show();
            Application.Run (form5a);
            MessageBox.Show ("Application.Run() heriki formun da kontrolunu Main'e döndürür.", "Form5a ve 5b");
            Application.Run (new Form5());
            Form6 form6 = new Form6(); //Kurucusuz
            form6.Text = "Form6 Uygulamasý";
            form6.BackColor = Color.Pink;
            form6.Size = new Size (400, 300);
            Application.Run (form6);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}