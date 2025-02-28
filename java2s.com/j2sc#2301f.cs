// j2sc#2301f.cs: Formun kurucu, bileþenler, olaylar, ebat-konum özellikleri örneði.

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel; //Container için
namespace Formlar {
    public class Form1: Form {
        private Button düðme1a;
        private Button düðme1b;
        private Label yafta1;
        public Form1() {//Kurucu
            BackColor = Color.LightBlue;
            ForeColor = Color.DarkBlue;
            Text="Form1";
            ClientSize = new Size (350, 100); //en,boy
            //Width = 350; Height = 100;
            düðme1a = new Button();
            düðme1a.Location = new Point (50, 50); //x,y
            düðme1a.Size = new Size (100, 23);
            düðme1a.Text = "Göster";
            düðme1a.Click += new EventHandler (düðme1a_Týklandý);
            //düðme1a.Parent = this; //Kontrol yerine
            düðme1b = new Button();
            düðme1b.Location = new Point (200, 50);
            düðme1b.Size = new Size (100, 23);
            düðme1b.Text = "Deðiþtir";
            düðme1b.Click += new EventHandler (düðme1b_Týklandý);
            //düðme1b.Parent = this;
            yafta1 = new Label();
            yafta1.Text = "Ebat ve Konum Kontrolu";
            yafta1.Size = new Size (400, 25);
            //yafta1.Parent = this;
            Controls.Add (düðme1a);
            Controls.AddRange (new Control[]{yafta1, düðme1b});
        }
        private void düðme1a_Týklandý (object kim, EventArgs olay) {
            Console.WriteLine ("Düðme1a Üst (y1): " + düðme1a.Top.ToString());
            Console.WriteLine ("Düðme1a Alt (y2): " + düðme1a.Bottom);
            Console.WriteLine ("Düðme1a Sol (x1): " + düðme1a.Left);
            Console.WriteLine ("Düðme1a Sað (x2): " + düðme1a.Right);
            Console.WriteLine ("Düðme1a Konum (x1,y1): " + düðme1a.Location);
            Console.WriteLine ("Düðme1a En (x2 - x1): " + düðme1a.Width); 
            Console.WriteLine ("Düðme1a Boy (y2 - y1) :" + düðme1a.Height);
            Console.WriteLine ("Düðme1a Ebat (x2-x1, y2-y1): " + düðme1a.Size);
            Console.WriteLine ("Düðme1a MüþteriEbat: " + düðme1a.ClientSize);
            Console.WriteLine ("Form1 Ebat: " + Size);
            Console.WriteLine ("Form MüþteriEbat: " + ClientSize);
            Console.WriteLine();
        }
        private void düðme1b_Týklandý (object k, EventArgs o) {
            Random r=new Random(); int en, boy;
            en=r.Next(100,1700); boy=r.Next(100,700);
            Size = new Size (en, boy);
        }
    }
    public class Form3: Form {
        public Form3() {//Kurucu
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            BackColor = Color.Blue;
            Text="Form3";
        }
    }
    public class Form4: Form {
        private Button düðme4= new Button();
        private Label etiket4 = new Label();
        private bool sürükleniyorMu;
        private Point týklananNokta;
        private Point taþý;
        public Form4() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            SuspendLayout();
            Text="Form4";
            düðme4.Location = new Point (102, 215);
            düðme4.Name = "düðme4";
            düðme4.Size = new Size (76, 20);
            düðme4.TabIndex = 5;
            düðme4.BackColor=Color.Cyan;
            düðme4.Text = "&Kapat";
            düðme4.Click += new EventHandler (düðme4_Týklandý); 
            etiket4.BackColor = Color.Navy;
            etiket4.BorderStyle = BorderStyle.Fixed3D;
            etiket4.Font = new Font ("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            etiket4.ForeColor = Color.Red;
            etiket4.Location = new Point (74, 167);
            etiket4.Name = "etiket4";
            etiket4.Size = new Size (140, 46);
            etiket4.TabIndex = 4;
            etiket4.Text = "Formu sürüklemek için burayý SOL basýlý tut!";
            etiket4.MouseDown += new MouseEventHandler (etiket4_FareBasýlý);
            etiket4.MouseMove += new MouseEventHandler(etiket4_FareTaþýnýyor);
            etiket4.MouseUp += new MouseEventHandler (etiket4_FareSerbest);
            //AutoScaleDimensions = new SizeF (6F, 14F);
            //AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            ControlBox = false;
            Controls.Add (düðme4);
            Controls.Add (etiket4);
            //Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ResumeLayout (false);
            BackColor = Color.DeepPink;
        }
        private void düðme4_Týklandý (object k, EventArgs o) {Close();}
        private void etiket4_FareBasýlý (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Left) {
                sürükleniyorMu = true;
                týklananNokta = new Point (o.X, o.Y);
            }else sürükleniyorMu = false;
        }
        private void etiket4_FareTaþýnýyor (object k, MouseEventArgs o) {
            if (sürükleniyorMu){
                taþý=PointToScreen (new Point (o.X, o.Y));
                taþý.Offset (-týklananNokta.X, -týklananNokta.Y);
                Location = taþý;
            }   
        }
        private void etiket4_FareSerbest (object k, MouseEventArgs o) {sürükleniyorMu = false;}  
    }
    public class Form5: Form {
        private Container kab=null;
        public Form5() {//Kurucu
            BileþeniBaþlat();
            BackColor = Color.LemonChiffon;
            CenterToScreen(); //Kurucu içinden
        }
        private void BileþeniBaþlat() {
            Text="Form5";
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            Resize += new EventHandler (Form5_TkrEbatla);
            Paint += new PaintEventHandler (Form5_Boya);
        }
        private void Form5_TkrEbatla (object k, EventArgs o) {
            Invalidate();
            Console.Write ("YenidenEbatlanýyor ");
        }
        private void Form5_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yavaþ", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Navy), 
                DisplayRectangle);    
        }
        protected override void Dispose (bool çöpe) {
            if(çöpe) if (kab != null) kab.Dispose();
            else base.Dispose (çöpe);
        }
    }
    public class Form9: Form {
        private Button düðme9a;
        public Form9() {
            BileþeniBaþlat();
            SetStyle (ControlStyles.ResizeRedraw, true);
            BackColor = Color.DarkSlateGray;
        }
        private void BileþeniBaþlat() {
            düðme9a = new Button();
            düðme9a.Location = new Point (24, 64);
            düðme9a.Size = new Size (160, 23);
            düðme9a.TabIndex = 0;
            düðme9a.Text = "Form9 Stillerini Al";
            düðme9a.BackColor = Color.DarkCyan;
            düðme9a.ForeColor = Color.White;
            düðme9a.Click += new EventHandler (düðme9a_Týklandý);
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (211, 104);
            Controls.Add (düðme9a);
            Text = "Form9";
        }
        private void düðme9a_Týklandý (object k, System.EventArgs o) {
            MessageBox.Show (GetStyle (ControlStyles.ResizeRedraw).ToString(), "ResizeRedraw varmý?");
        }
    }
    public class Form10: Form {
        public Form10() {//Kurucu
            Top = 100; //Location
            Left = 75;
            Height = 100; //Size
            Width = 500;
            MessageBox.Show (Bounds.ToString(), "Ebat ve Konum");
            BileþeniBaþlat(); //Son Size geçerli
        }
        private void BileþeniBaþlat() {
            Size = new Size (300, 300);
            Text = "Form10";
            BackColor = Color.SteelBlue;
            Opacity = 0.5d; //%50 þeffaf
            Paint += new PaintEventHandler (Form10_Boya);
        }
        private void Form10_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yavaþ", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Magenta), 
                DisplayRectangle);    
        }
    }
    class Form11: Form {
        public Form11() {//Kurucu
            Menu = new MainMenu();
            Menu.MenuItems.Add ("&Diyalog!", new EventHandler (Diyalog_Týklandý));
            BackColor = Color.SkyBlue;
            Text = "Form11";
        }
        void Diyalog_Týklandý (object k, EventArgs o) {
            Form11_DiyalogKutusu dylg = new Form11_DiyalogKutusu();
            dylg.ShowDialog();
            Console.WriteLine (dylg.DialogResult);
        }
    }
    class Form11_DiyalogKutusu: Form {
        public Form11_DiyalogKutusu() {//Kurucu
            Text = "Basiy Diyalog Kutusu";
            BackColor = Color.Purple;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            Button düðme = new Button(); //Tamam düðmesi
            düðme.ForeColor = Color.White;
            düðme.Parent = this;
            düðme.Text = "Tamam";
            düðme.Location = new Point (50, 50);
            düðme.Size = new Size (10 * Font.Height, 2 * Font.Height);
            düðme.Click   += new EventHandler(TamamTýklandý);
            düðme = new Button(); //Ýptal düðmesi
            düðme.ForeColor = Color.Red;
            düðme.Parent = this;
            düðme.Text = "Ýptal";
            düðme.Location = new Point (50, 100);
            düðme.Size = new Size (10 * Font.Height, 2 * Font.Height);
            düðme.Click += new EventHandler (ÝptalTýklandý);
        }
        void TamamTýklandý (object k, EventArgs o) {DialogResult = DialogResult.OK;}
        void ÝptalTýklandý (object k, EventArgs o) {DialogResult = DialogResult.Cancel;}
    }
    class FormÖzellikleri {
        [STAThread]
        static void Main() {
            Console.Write ("Olaylarýn düðme týklanmasýna baðlanmasý 'düðme.Click += new EventHandler(DüðmeTýklandý)' ile ve çaðrýlan 'void DüðmeTýklandý(object kim, EventArgs olay){...}' ile kodlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli form özelliklerini kurma:");
            Application.Run (new Form1());
            Form form2 = new Form();
            form2.BackColor = Color.DarkSlateBlue; form2.Text="Form2";
            form2.StartPosition = FormStartPosition.CenterScreen;
            Application.Run (form2);
            Application.Run (new Form3());
            Application.Run (new Form4());
            Application.Run (new Form5()); Console.WriteLine();
            Form form6 = new Form();
            form6.Height /= 2;
            form6.BackColor = Color.Olive; form6.Text="Form6";
            Application.Run (form6);
            Form form7 = new Form();
            form7.Height *= 2;
            form7.BackColor = Color.Navy; form7.Text="Form7";
            Application.Run (form7);
            Form form8 = new Form();
            form8.FormBorderStyle = FormBorderStyle.Fixed3D; //FixedSingle
            form8.BackColor = Color.Teal; form8.Text="Form8";
            Application.Run (form8);
            Application.Run (new Form9());
            Application.Run (new Form10());
            Application.Run (new Form11());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}