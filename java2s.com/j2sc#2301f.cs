// j2sc#2301f.cs: Formun kurucu, bile�enler, olaylar, ebat-konum �zellikleri �rne�i.

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel; //Container i�in
namespace Formlar {
    public class Form1: Form {
        private Button d��me1a;
        private Button d��me1b;
        private Label yafta1;
        public Form1() {//Kurucu
            BackColor = Color.LightBlue;
            ForeColor = Color.DarkBlue;
            Text="Form1";
            ClientSize = new Size (350, 100); //en,boy
            //Width = 350; Height = 100;
            d��me1a = new Button();
            d��me1a.Location = new Point (50, 50); //x,y
            d��me1a.Size = new Size (100, 23);
            d��me1a.Text = "G�ster";
            d��me1a.Click += new EventHandler (d��me1a_T�kland�);
            //d��me1a.Parent = this; //Kontrol yerine
            d��me1b = new Button();
            d��me1b.Location = new Point (200, 50);
            d��me1b.Size = new Size (100, 23);
            d��me1b.Text = "De�i�tir";
            d��me1b.Click += new EventHandler (d��me1b_T�kland�);
            //d��me1b.Parent = this;
            yafta1 = new Label();
            yafta1.Text = "Ebat ve Konum Kontrolu";
            yafta1.Size = new Size (400, 25);
            //yafta1.Parent = this;
            Controls.Add (d��me1a);
            Controls.AddRange (new Control[]{yafta1, d��me1b});
        }
        private void d��me1a_T�kland� (object kim, EventArgs olay) {
            Console.WriteLine ("D��me1a �st (y1): " + d��me1a.Top.ToString());
            Console.WriteLine ("D��me1a Alt (y2): " + d��me1a.Bottom);
            Console.WriteLine ("D��me1a Sol (x1): " + d��me1a.Left);
            Console.WriteLine ("D��me1a Sa� (x2): " + d��me1a.Right);
            Console.WriteLine ("D��me1a Konum (x1,y1): " + d��me1a.Location);
            Console.WriteLine ("D��me1a En (x2 - x1): " + d��me1a.Width); 
            Console.WriteLine ("D��me1a Boy (y2 - y1) :" + d��me1a.Height);
            Console.WriteLine ("D��me1a Ebat (x2-x1, y2-y1): " + d��me1a.Size);
            Console.WriteLine ("D��me1a M��teriEbat: " + d��me1a.ClientSize);
            Console.WriteLine ("Form1 Ebat: " + Size);
            Console.WriteLine ("Form M��teriEbat: " + ClientSize);
            Console.WriteLine();
        }
        private void d��me1b_T�kland� (object k, EventArgs o) {
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
        private Button d��me4= new Button();
        private Label etiket4 = new Label();
        private bool s�r�kleniyorMu;
        private Point t�klananNokta;
        private Point ta��;
        public Form4() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            SuspendLayout();
            Text="Form4";
            d��me4.Location = new Point (102, 215);
            d��me4.Name = "d��me4";
            d��me4.Size = new Size (76, 20);
            d��me4.TabIndex = 5;
            d��me4.BackColor=Color.Cyan;
            d��me4.Text = "&Kapat";
            d��me4.Click += new EventHandler (d��me4_T�kland�); 
            etiket4.BackColor = Color.Navy;
            etiket4.BorderStyle = BorderStyle.Fixed3D;
            etiket4.Font = new Font ("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            etiket4.ForeColor = Color.Red;
            etiket4.Location = new Point (74, 167);
            etiket4.Name = "etiket4";
            etiket4.Size = new Size (140, 46);
            etiket4.TabIndex = 4;
            etiket4.Text = "Formu s�r�klemek i�in buray� SOL bas�l� tut!";
            etiket4.MouseDown += new MouseEventHandler (etiket4_FareBas�l�);
            etiket4.MouseMove += new MouseEventHandler(etiket4_FareTa��n�yor);
            etiket4.MouseUp += new MouseEventHandler (etiket4_FareSerbest);
            //AutoScaleDimensions = new SizeF (6F, 14F);
            //AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            ControlBox = false;
            Controls.Add (d��me4);
            Controls.Add (etiket4);
            //Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ResumeLayout (false);
            BackColor = Color.DeepPink;
        }
        private void d��me4_T�kland� (object k, EventArgs o) {Close();}
        private void etiket4_FareBas�l� (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Left) {
                s�r�kleniyorMu = true;
                t�klananNokta = new Point (o.X, o.Y);
            }else s�r�kleniyorMu = false;
        }
        private void etiket4_FareTa��n�yor (object k, MouseEventArgs o) {
            if (s�r�kleniyorMu){
                ta��=PointToScreen (new Point (o.X, o.Y));
                ta��.Offset (-t�klananNokta.X, -t�klananNokta.Y);
                Location = ta��;
            }   
        }
        private void etiket4_FareSerbest (object k, MouseEventArgs o) {s�r�kleniyorMu = false;}  
    }
    public class Form5: Form {
        private Container kab=null;
        public Form5() {//Kurucu
            Bile�eniBa�lat();
            BackColor = Color.LemonChiffon;
            CenterToScreen(); //Kurucu i�inden
        }
        private void Bile�eniBa�lat() {
            Text="Form5";
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            Resize += new EventHandler (Form5_TkrEbatla);
            Paint += new PaintEventHandler (Form5_Boya);
        }
        private void Form5_TkrEbatla (object k, EventArgs o) {
            Invalidate();
            Console.Write ("YenidenEbatlan�yor ");
        }
        private void Form5_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yava�", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Navy), 
                DisplayRectangle);    
        }
        protected override void Dispose (bool ��pe) {
            if(��pe) if (kab != null) kab.Dispose();
            else base.Dispose (��pe);
        }
    }
    public class Form9: Form {
        private Button d��me9a;
        public Form9() {
            Bile�eniBa�lat();
            SetStyle (ControlStyles.ResizeRedraw, true);
            BackColor = Color.DarkSlateGray;
        }
        private void Bile�eniBa�lat() {
            d��me9a = new Button();
            d��me9a.Location = new Point (24, 64);
            d��me9a.Size = new Size (160, 23);
            d��me9a.TabIndex = 0;
            d��me9a.Text = "Form9 Stillerini Al";
            d��me9a.BackColor = Color.DarkCyan;
            d��me9a.ForeColor = Color.White;
            d��me9a.Click += new EventHandler (d��me9a_T�kland�);
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (211, 104);
            Controls.Add (d��me9a);
            Text = "Form9";
        }
        private void d��me9a_T�kland� (object k, System.EventArgs o) {
            MessageBox.Show (GetStyle (ControlStyles.ResizeRedraw).ToString(), "ResizeRedraw varm�?");
        }
    }
    public class Form10: Form {
        public Form10() {//Kurucu
            Top = 100; //Location
            Left = 75;
            Height = 100; //Size
            Width = 500;
            MessageBox.Show (Bounds.ToString(), "Ebat ve Konum");
            Bile�eniBa�lat(); //Son Size ge�erli
        }
        private void Bile�eniBa�lat() {
            Size = new Size (300, 300);
            Text = "Form10";
            BackColor = Color.SteelBlue;
            Opacity = 0.5d; //%50 �effaf
            Paint += new PaintEventHandler (Form10_Boya);
        }
        private void Form10_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yava�", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Magenta), 
                DisplayRectangle);    
        }
    }
    class Form11: Form {
        public Form11() {//Kurucu
            Menu = new MainMenu();
            Menu.MenuItems.Add ("&Diyalog!", new EventHandler (Diyalog_T�kland�));
            BackColor = Color.SkyBlue;
            Text = "Form11";
        }
        void Diyalog_T�kland� (object k, EventArgs o) {
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
            Button d��me = new Button(); //Tamam d��mesi
            d��me.ForeColor = Color.White;
            d��me.Parent = this;
            d��me.Text = "Tamam";
            d��me.Location = new Point (50, 50);
            d��me.Size = new Size (10 * Font.Height, 2 * Font.Height);
            d��me.Click   += new EventHandler(TamamT�kland�);
            d��me = new Button(); //�ptal d��mesi
            d��me.ForeColor = Color.Red;
            d��me.Parent = this;
            d��me.Text = "�ptal";
            d��me.Location = new Point (50, 100);
            d��me.Size = new Size (10 * Font.Height, 2 * Font.Height);
            d��me.Click += new EventHandler (�ptalT�kland�);
        }
        void TamamT�kland� (object k, EventArgs o) {DialogResult = DialogResult.OK;}
        void �ptalT�kland� (object k, EventArgs o) {DialogResult = DialogResult.Cancel;}
    }
    class Form�zellikleri {
        [STAThread]
        static void Main() {
            Console.Write ("Olaylar�n d��me t�klanmas�na ba�lanmas� 'd��me.Click += new EventHandler(D��meT�kland�)' ile ve �a�r�lan 'void D��meT�kland�(object kim, EventArgs olay){...}' ile kodlan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli form �zelliklerini kurma:");
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}