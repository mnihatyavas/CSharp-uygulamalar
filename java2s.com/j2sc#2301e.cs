// j2sc#2301e.cs: EventHandler(metot) ile olaylar�n y�netilmesi-2 �rne�i.

using System;
using System.Windows.Forms; //Form, Button, Label i�in
using System.Drawing; //Size i�in
using System.ComponentModel; //CancelEventArgs i�in
namespace Formlar {
    public class Form2: Form {
        private Container kab = null;
        public Form2() {//Kurucu
            MouseUp += new MouseEventHandler (FareYukar�);
            Bile�eniBa�lat();
        }
        protected override void Dispose (bool ��peMi) {
            if(��peMi) if (kab != null) kab.Dispose();
            base.Dispose (��peMi);    
        }
        private void Bile�eniBa�lat() {
            kab = new Container();
            Size = new Size (300, 300);
            Text = "Fare Yukar�";
            BackColor = Color.Navy;
        }
        protected void FareYukar� (object k, MouseEventArgs o) {
            // Hangi fara d��mesi t�klad�?
            if(o.Button == MouseButtons.Left) MessageBox.Show ("Sok t�klad�!");
            else if(o.Button == MouseButtons.Right)  MessageBox.Show ("Sa� T�klad�!");
            else if(o.Button == MouseButtons.Middle) MessageBox.Show ("Orta t�klad�!");
        }
    }
    public class Form3: Form {
        public Form3() {MouseMove += new MouseEventHandler (FareKonumu); Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            Size = new Size (300, 300);
            Text = "Fare Konumu";
            BackColor = Color.Olive;
        }
        protected void FareKonumu (object k, MouseEventArgs o) {Text = "Akt�el konum: (" + o.X + ", " + o.Y + ")";}

    }
    public class Fare4: Form {
        public Fare4() {//Kurucu
            KeyUp += new KeyEventHandler (Tu�Yukar�);
            Bile�eniBa�lat();
            CenterToScreen();
        }
        private void Bile�eniBa�lat() {
            Size = new Size (300, 300);
            Text = "Tu�lara Bas";
            BackColor = Color.Green;
        }
        public void Tu�Yukar� (object k, KeyEventArgs o) {MessageBox.Show (o.KeyCode + " Tu�a bas�ld�!");}
    }
    public class Form5: Form {
        public Form5() {//Kurucu
            Bile�eniBa�lat();
            Load += new EventHandler (Form5_Y�kle);
            Closing += new CancelEventHandler (Form5_Kapan�yor);
            Closed += new EventHandler (Form5_Kapand�);
            Activated += new EventHandler (Form5_Aktiflendi);
            Deactivate += new EventHandler (Form5_Aktifsiz);
        }
        private void Bile�eniBa�lat() {
            AutoScaleBaseSize = new Size (5, 13);
            //ClientSize = new Size (280, 177);
            BackColor = Color.Fuchsia;
        }
        private void Form5_Y�kle (object k, EventArgs o) {Console.WriteLine ("Y�kle olay�");}
        private void Form5_Aktiflendi (object k, EventArgs o) {Console.WriteLine ("Aktiflendi olay�");}
        private void Form5_Kapan�yor (object k, CancelEventArgs o) {Console.WriteLine ("Kapan�yor olay�");}
        private void Form5_Kapand� (object k, EventArgs o) {Console.WriteLine ("Kapand� olay�");}
        private void Form5_Aktifsiz (object k, EventArgs o) {Console.WriteLine ("Akktifsizleme olay�");}
    }
    public class Form6: Form {
        public Form6() {
            Bile�eniBa�lat();
            Closing += new CancelEventHandler (Form6_Kapan�yor);
        }
        private void Bile�eniBa�lat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (280, 177);
            BackColor = Color.DarkSlateBlue;
        }
        private void Form6_Kapan�yor (object k, CancelEventArgs o) {
            DialogResult cevap = MessageBox.Show ("Kapatmak istedi�inden emin misin?", "Kapan�yor olay�!", MessageBoxButtons.YesNo);
            if(cevap == DialogResult.No) o.Cancel = true;
            else o.Cancel = false;    
        }
    }
    class FormEventB {
        static void BoyaY�netimi1 (object kim, PaintEventArgs olay) {
            Form form = (Form)kim;
            Graphics gr = olay.Graphics;
            gr.DrawString ("�lk Boya Olay� Y�netimi", form.Font, Brushes.Lime, 0, 0); //x,y
        }
        static void BoyaY�netimi2 (object k, PaintEventArgs o) {
            Form form = (Form)k;
            Graphics gr = o.Graphics;
            gr.DrawString ("�kinci Boya Olay� Y�netimi", form.Font, Brushes.Yellow, 0, 100);
        }
        static void BoyaY�netimi3 (object k, PaintEventArgs o) {
            Form form = (Form)k;
            Graphics gr = o.Graphics;
            gr.DrawString ("���nc� Boya Olay� Y�netimi", form.Font, Brushes.Pink, 0, 200);
        }
        [STAThread]
        static void Main() {
            Console.Write ("Formun hayat d�ng�s�: Load, Activated, Closing, Closed, Deactivate. Kapan�yor olay� yakalan�p y�netilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Forma dair olaylar�n '+=EventHandler(metot)'la yakalan�p y�netilmesi:");
                Form form1 = new Form();
                form1.Text = "�� Boya Y�netimi";
                form1.BackColor = Color.Blue;
                form1.Paint += new PaintEventHandler (BoyaY�netimi1);
                form1.Paint += new PaintEventHandler (BoyaY�netimi2);
                form1.Paint += new PaintEventHandler (BoyaY�netimi3);
                Application.Run (form1);
                Application.Run (new Form2());
                Application.Run (new Form3());
                Application.Run (new Fare4());
                Application.Run (new Form5());
                Application.Run (new Form6());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}