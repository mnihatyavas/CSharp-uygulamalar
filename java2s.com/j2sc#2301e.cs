// j2sc#2301e.cs: EventHandler(metot) ile olaylarýn yönetilmesi-2 örneði.

using System;
using System.Windows.Forms; //Form, Button, Label için
using System.Drawing; //Size için
using System.ComponentModel; //CancelEventArgs için
namespace Formlar {
    public class Form2: Form {
        private Container kab = null;
        public Form2() {//Kurucu
            MouseUp += new MouseEventHandler (FareYukarý);
            BileþeniBaþlat();
        }
        protected override void Dispose (bool çöpeMi) {
            if(çöpeMi) if (kab != null) kab.Dispose();
            base.Dispose (çöpeMi);    
        }
        private void BileþeniBaþlat() {
            kab = new Container();
            Size = new Size (300, 300);
            Text = "Fare Yukarý";
            BackColor = Color.Navy;
        }
        protected void FareYukarý (object k, MouseEventArgs o) {
            // Hangi fara düðmesi týkladý?
            if(o.Button == MouseButtons.Left) MessageBox.Show ("Sok týkladý!");
            else if(o.Button == MouseButtons.Right)  MessageBox.Show ("Sað Týkladý!");
            else if(o.Button == MouseButtons.Middle) MessageBox.Show ("Orta týkladý!");
        }
    }
    public class Form3: Form {
        public Form3() {MouseMove += new MouseEventHandler (FareKonumu); BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            Size = new Size (300, 300);
            Text = "Fare Konumu";
            BackColor = Color.Olive;
        }
        protected void FareKonumu (object k, MouseEventArgs o) {Text = "Aktüel konum: (" + o.X + ", " + o.Y + ")";}

    }
    public class Fare4: Form {
        public Fare4() {//Kurucu
            KeyUp += new KeyEventHandler (TuþYukarý);
            BileþeniBaþlat();
            CenterToScreen();
        }
        private void BileþeniBaþlat() {
            Size = new Size (300, 300);
            Text = "Tuþlara Bas";
            BackColor = Color.Green;
        }
        public void TuþYukarý (object k, KeyEventArgs o) {MessageBox.Show (o.KeyCode + " Tuþa basýldý!");}
    }
    public class Form5: Form {
        public Form5() {//Kurucu
            BileþeniBaþlat();
            Load += new EventHandler (Form5_Yükle);
            Closing += new CancelEventHandler (Form5_Kapanýyor);
            Closed += new EventHandler (Form5_Kapandý);
            Activated += new EventHandler (Form5_Aktiflendi);
            Deactivate += new EventHandler (Form5_Aktifsiz);
        }
        private void BileþeniBaþlat() {
            AutoScaleBaseSize = new Size (5, 13);
            //ClientSize = new Size (280, 177);
            BackColor = Color.Fuchsia;
        }
        private void Form5_Yükle (object k, EventArgs o) {Console.WriteLine ("Yükle olayý");}
        private void Form5_Aktiflendi (object k, EventArgs o) {Console.WriteLine ("Aktiflendi olayý");}
        private void Form5_Kapanýyor (object k, CancelEventArgs o) {Console.WriteLine ("Kapanýyor olayý");}
        private void Form5_Kapandý (object k, EventArgs o) {Console.WriteLine ("Kapandý olayý");}
        private void Form5_Aktifsiz (object k, EventArgs o) {Console.WriteLine ("Akktifsizleme olayý");}
    }
    public class Form6: Form {
        public Form6() {
            BileþeniBaþlat();
            Closing += new CancelEventHandler (Form6_Kapanýyor);
        }
        private void BileþeniBaþlat() {
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (280, 177);
            BackColor = Color.DarkSlateBlue;
        }
        private void Form6_Kapanýyor (object k, CancelEventArgs o) {
            DialogResult cevap = MessageBox.Show ("Kapatmak istediðinden emin misin?", "Kapanýyor olayý!", MessageBoxButtons.YesNo);
            if(cevap == DialogResult.No) o.Cancel = true;
            else o.Cancel = false;    
        }
    }
    class FormEventB {
        static void BoyaYönetimi1 (object kim, PaintEventArgs olay) {
            Form form = (Form)kim;
            Graphics gr = olay.Graphics;
            gr.DrawString ("Ýlk Boya Olayý Yönetimi", form.Font, Brushes.Lime, 0, 0); //x,y
        }
        static void BoyaYönetimi2 (object k, PaintEventArgs o) {
            Form form = (Form)k;
            Graphics gr = o.Graphics;
            gr.DrawString ("Ýkinci Boya Olayý Yönetimi", form.Font, Brushes.Yellow, 0, 100);
        }
        static void BoyaYönetimi3 (object k, PaintEventArgs o) {
            Form form = (Form)k;
            Graphics gr = o.Graphics;
            gr.DrawString ("Üçüncü Boya Olayý Yönetimi", form.Font, Brushes.Pink, 0, 200);
        }
        [STAThread]
        static void Main() {
            Console.Write ("Formun hayat döngüsü: Load, Activated, Closing, Closed, Deactivate. Kapanýyor olayý yakalanýp yönetilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Forma dair olaylarýn '+=EventHandler(metot)'la yakalanýp yönetilmesi:");
                Form form1 = new Form();
                form1.Text = "Üç Boya Yönetimi";
                form1.BackColor = Color.Blue;
                form1.Paint += new PaintEventHandler (BoyaYönetimi1);
                form1.Paint += new PaintEventHandler (BoyaYönetimi2);
                form1.Paint += new PaintEventHandler (BoyaYönetimi3);
                Application.Run (form1);
                Application.Run (new Form2());
                Application.Run (new Form3());
                Application.Run (new Fare4());
                Application.Run (new Form5());
                Application.Run (new Form6());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}