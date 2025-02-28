// j2sc#2301b.cs: Form, kurucusu, ko�turulmas�, bile�enleri �rne�i.

using System;
using System.Windows.Forms; //:Form i�in
using System.Drawing; //Color i�in
using System.Threading; //Thread.Sleep i�in
namespace Formlar {
    class Form1: Form {}
    class Form2: Form {
        public Form2() {
            Text = "System.Windows.Form Mirasland�";
            BackColor = Color.Cyan;
            Size = new Size (500, 300); //en,boy
        }
    }
    class Form3: Form {
        public Form3() {//Kurucu
            Text = "'Merhaba D�nya' Formu";
            BackColor = Color.Lime;
            Size = new Size (500, 300);
        }
        protected override void OnPaint (PaintEventArgs boya) {
            Graphics grafik = boya.Graphics;
            grafik.DrawString ("Merhaba, Windows Formlar�!", Font, Brushes.Black, 0, 0);
        }
    }
    class Form4: Form {
        private Label etiket1;
        private TextBox metinKutusu1;
        private Button d��me1;
        public Form4() {
            this.etiket1 = new Label();
            this.metinKutusu1 = new TextBox();
            this.d��me1 = new Button();
            this.SuspendLayout();
            //etiket1 bile�eni
            this.etiket1.Location = new Point (16, 36); //(yatay,dikey) ba�lama noktas�
            this.etiket1.Name = "etiket1"; //De�i�ken ad�
            this.etiket1.Size = new Size (128, 16);
            this.etiket1.TabIndex = 0; //Tab'la odaklanma s�ras�
            this.etiket1.Text = "L�tfen ismini gir:"; 
            //metinKutusu1 bile�eni
            this.metinKutusu1.Location = new Point (152, 32);
            this.metinKutusu1.Name = "metinKutusu1";
            this.metinKutusu1.TabIndex = 1;
            this.metinKutusu1.Text = "";
            //d��me1 bile�eni
            this.d��me1.Location = new Point (109, 80);
            this.d��me1.Name = "d��me1";
            this.d��me1.TabIndex = 2;
            this.d��me1.Text = "Gir";
            this.d��me1.Click += new EventHandler (this.d��me1_T�kla);
            //Son r�tu�lar
            this.ClientSize = new Size (292, 126);
            this.Controls.Add (this.d��me1);
            this.Controls.Add (this.metinKutusu1);
            this.Controls.Add (this.etiket1);
            this.Name = "form4";
            this.Text = "Visual C#";
            //SuspendLayout() iptali
            this.ResumeLayout (false);
        }
        private void d��me1_T�kla (object g�nderen, EventArgs olay) {
            Console.WriteLine ("Kullan�c�n�n girdi�i ad: " + metinKutusu1.Text);
            MessageBox.Show ("Ho�geldin, " + metinKutusu1.Text + "!..", "Visual C#");
        }
    }
    class Form5: Form {
        private TextBox metinKutusu2 = new TextBox(); 
        private Button d��me2 = new Button();
        public Form5() {//Kurucu
            //metinKutusu2
            metinKutusu2.Text = "Metin";
            metinKutusu2.Size = new Size (150, 50);
            metinKutusu2.Location = new Point (10, 10);
            this.Controls.Add (metinKutusu2);
            //d��me2
            d��me2.Text = "T�kla beni!";
            d��me2.Size = new Size (90, 90);
            d��me2.Location = new Point (10, 70);
            d��me2.Click += new EventHandler (d��me2_T�kland�);
            this.Controls.Add(d��me2);
            //Form5 ekran� ortalas�n
            CenterToScreen();
        }
        protected void d��me2_T�kland� (object kim, EventArgs olay) {
            Control.ControlCollection kontrollar = this.Controls;
            foreach (Control k in kontrollar) {
                if(k != null) Console.WriteLine (string.Format ("Endeks: {0}, A��klama: {1}", kontrollar.GetChildIndex (k, false), k.Text));
            }
            MessageBox.Show ("Mesaj", "Herbir kontrolun endeks ve metni");
        }
    }
    public class Form6: Form {
        private Button d��me6a;
        private Button d��me6b;
        protected Label etiket6;
        public Form6() {//Kurucu
            //d��me6a
            d��me6a = new Button();
            d��me6a.Location = new Point (25, 100);
            d��me6a.Size = new Size (100, 25);
            d��me6a.Text = "&Kapat"; //Alt-K
            d��me6a.Click += new EventHandler (d��me6a_T�kland�);
            //d��me6b
            d��me6b = new Button();
            d��me6b.Location = new Point (200, 100);
            d��me6b.Size = new Size (150, 25);
            d��me6b.Text = "&Form6 Uygulamas�"; //Alt-F
            d��me6b.Click += new EventHandler(d��me6b_T�kland�);
            //etiket6
            etiket6 = new Label();
            etiket6.Location = new Point (25, 25);
            etiket6.Size = new Size (150, 25);
            etiket6.Text = "Form6 ET�KETL� BA�LIK";
            //Kontrollar
            Controls.AddRange (new Control[]{etiket6, d��me6a, d��me6b});
        }
        private void d��me6a_T�kland� (object kim, EventArgs olay) {Application.Exit();} //T�m j2sc#2301b.exe kapan�r
        private void d��me6b_T�kland� (object kim, EventArgs oly) {
            MessageBox.Show ("Bu Form6 Uygulamas�d�r.");
            BirMetot();
        }
        protected virtual void BirMetot(){MessageBox.Show ("Bu, Form6'dan �a�r�lan BirMetot()'dur.");}
    }
    class FormA {
        static void Main() {
            Console.Write ("Do�rudan 'Application.Run(new Form1())', yada 'Form1 form1 = new Form1()' ve 'Application.Run(form1)' ile ko�turulur. Form bile�enleri genelde kurucuyla tesis edilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli form, kurucusu, ko�turulmas�, bile�enler, kontrollar ve t�klama:");
            Form1 form1 = new Form1(); //Kurucusuz
            Application.Run (new System.Windows.Forms.Form()); //Varsay�l� bo� form
            form1.Text = "System.Windows.Form Mirasland�";
            form1.BackColor = Color.Cyan;
            form1.Size = new Size (500, 300);
            Application.Run (form1);
            Application.Run (new Form2()); //Kuruculu
            Application.Run (new Form3());
            Application.EnableVisualStyles();
            Application.Run (new Form4());
            Form form2 = new Form();
            form2.Show(); //Varsay�l� bo� form
            Application.Run (form2);
            Form form3 = new Form();
            form3.Show(); Application.Run (form3);
            Thread.Sleep (1000);
            form3.Text = "Ukulu Form";
            Thread.Sleep (1000);
            Form form4 = new Form();
            form4.Text = "Yanl�� fikir...";
            form4.Visible = true;
            Application.Run (form4); //form4 kontrolu Main'e d�ner, yoksa hatayla k�rar
            Form form5a = new Form();
            Form form5b = new Form();
            form5a.Text = "Run()'la ko�an form5a";
            form5b.Text = "Show()'la g�sterilen form5b";
            form5b.Show();
            Application.Run (form5a);
            MessageBox.Show ("Application.Run() heriki formun da kontrolunu Main'e d�nd�r�r.", "Form5a ve 5b");
            Application.Run (new Form5());
            Form6 form6 = new Form6(); //Kurucusuz
            form6.Text = "Form6 Uygulamas�";
            form6.BackColor = Color.Pink;
            form6.Size = new Size (400, 300);
            Application.Run (form6);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}