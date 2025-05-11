// j2sc#2302c.cs: D��me ortalama ve �entikkutulu yaz�stilleme �rne�i.

using System;
using System.Windows.Forms; 
using System.Drawing;
namespace Bile�enler {
    class Form1: Form {
        public Form1() {//Kurucu
            ClientSize = new Size (240, 80);
            Text = "Form1: Ortalanan D��me";
            BackColor=Color.SkyBlue;
            Button d��me1 = new Button();
            d��me1.Parent = this;
            d��me1.Text = "G�ZEL ORTALANDI!";
            d��me1.BackColor=Color.Violet;
            d��me1.Size = new Size (17 * 5, 14); //(85, 14)
            d��me1.Location = new Point ((ClientSize.Width - d��me1.Width) / 2, (ClientSize.Height - d��me1.Height) / 2); //((240-17*4)/2, (80-14)/2)=(86, 33)
            AutoScaleDimensions = new Size (4, 8);
            AutoScaleMode = AutoScaleMode.Font;
        }
    }
    class Form2: Form {
        public Form2() {//Kurucu
            //Size = new Size (240, 80);
            Text = "Form2: D��me Metni Uzunlu�u";
            BackColor=Color.Tan;
            MesajD��mesi2 mesajD��mesi2 = new MesajD��mesi2();
            mesajD��mesi2.Parent = this;
            mesajD��mesi2.Text = "Metnin uzunlu�u?";
            mesajD��mesi2.BackColor=Color.Thistle;
            mesajD��mesi2.MesajKutusuMetni = "Bu d��me metni 3 krk'den fazla m�?!..";
            mesajD��mesi2.Location = new Point (100, 90);
            mesajD��mesi2.AutoSize = true;
        }
    }
    class MesajD��mesi2: Button {
        string dizge;
        public MesajD��mesi2() {Enabled = false;} //Kurucu: pasif
        public string MesajKutusuMetni {
            set {dizge = value; Enabled = value != null && value.Length > 3;} //3 krk'den fazla veriyle d��me etkinle�ir
            get {return (dizge + ": " + dizge.Length).ToString();}
        }
        protected override void OnClick (EventArgs argm) {MessageBox.Show (MesajKutusuMetni, Text);}
    }
    class Form3: Form {
        public Form3() {//Kurucu
            int fonBoyu = Font.Height; //Varsay�l� yaz�fonu y�ksekli�ini atar
            Text = "Form3: Fonboyuna Orant�l� Pencere&D��me";
            ClientSize = new Size (fonBoyu * 30, fonBoyu * 10); //�rn. PencereEbat=(12*30, 12*10)=(360, 120)
            BackColor=Color.Tomato;
            Button d��me3 = new Button();
            d��me3.Parent = this;
            d��me3.Text = "M.N�HAT YAVA�";
            d��me3.BackColor=Color.Yellow;
            d��me3.Size = new Size (17 * fonBoyu / 2, 7 * fonBoyu / 4); // D��meEbat=(17*12/2, 7*12/4)=(102, 21)
            d��me3.Location = new Point ((ClientSize.Width - d��me3.Width) / 2, (ClientSize.Height - d��me3.Height) / 2); //((360-102)/2, (120-21)/2)=(129, 49.5)
        }
    }
    public class Form4: Form {
        Label etiket4;
        Panel panel4;
        FontStyle[] stiller;
        public Form4() {//Kurucu
            Text = "Form4: Se�ilenle Metnin Stillenmasi";
            Size = new Size (300, 250);
            BackColor=Color.SeaGreen;
            //etiket4
            etiket4 = new Label();
            etiket4.Parent = this;
            etiket4.Text = "Mahmut Nihat Yava�";
            etiket4.Location = new Point (0, 0);
            etiket4.AutoSize = true;
            etiket4.BackColor=Color.Salmon;
            etiket4.BorderStyle = BorderStyle.Fixed3D;
            int etiket4Y = etiket4.Height + 10;
            //stiller
            FontStyle stilNo = new FontStyle();
            stiller = (FontStyle[])Enum.GetValues (stilNo.GetType());
            //panel4
            panel4 = new Panel();
            panel4.Parent = this;
            panel4.Location = new Point (0, etiket4Y);
            panel4.BackColor=Color.SandyBrown;
            panel4.Size = new Size (150, (stiller.Length + 1) * etiket4Y);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            //�entikKutu4
            int i = 1;
            CheckBox �entikKutu4;
            foreach (FontStyle stil in stiller) {
                �entikKutu4 = new CheckBox();
                �entikKutu4.Parent = panel4;
                �entikKutu4.Location = new Point (25, (etiket4Y * (i - 1)) + 10);
                �entikKutu4.Size = new Size (75, 20);
                �entikKutu4.Text = stil.ToString();
                �entikKutu4.Tag = stil;
                �entikKutu4.CheckedChanged += new EventHandler (�entikKutu4_De�i�ti);
                if (�entikKutu4.Text == "Regular") �entikKutu4.Checked = true;
                i++;
            }
        }
        private void �entikKutu4_De�i�ti (object k, EventArgs o) {
            FontStyle fsNo = 0;
            for (int i = 0; i < panel4.Controls.Count; i++) {
                CheckBox �entikKutu4 = (CheckBox)panel4.Controls [i];
                if (�entikKutu4.Checked) fsNo |= (FontStyle)�entikKutu4.Tag;
                if (((CheckBox)panel4.Controls [i]).Checked) fsNo |= (FontStyle)((CheckBox)panel4.Controls [i]).Tag;
            }
            etiket4.Font = new Font (etiket4.Font, fsNo);
        }
    }
    public partial class Form5: Form {
        public Form5() {Bile�eniBa�lat();} //Kurucu
        protected override void OnLoad (EventArgs o) {
            base.OnLoad (o);
            string[] g�dalar = {"Armut", "Bal", "Ceviz", "Dut", "Elma", "F�nd�k", "Gazoz", "H�yar", "Ispanak", "Japon Eri�i"};
            SuspendLayout();
            int tepeKonum = 10;
            foreach (string g�da in g�dalar) {
                CheckBox �k5 = new CheckBox();
                �k5.Top = tepeKonum;
                �k5.Left = 10;
                �k5.Text = g�da;
                tepeKonum += 35;
                panel5.Controls.Add (�k5);
            }
            ResumeLayout();
        }
    }
    partial class Form5 {
        #region Form5 kodlamas�
        private Panel panel5;
        private void Bile�eniBa�lat() {
            // Form5
            //AutoScaleDimensions = new SizeF (6F, 13F);
            //AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (150, 250);
            Name = "Form5";
            Text = "Form5: Alaca��n G�dalar� Se�";
            Size = new Size (300, 250);
            BackColor=Color.DarkKhaki;
            panel5 = new Panel();
            SuspendLayout();
            // panel5
            panel5.AutoScroll = true; //Ta�arsa sadece paneli dikey-yatay kayd�r�r
            //panel5.Dock = DockStyle.Fill; //Panel pencereyi doldurur
            panel5.Location = new Point (10, 10);
            panel5.Name = "panel5";
            panel5.Size = new Size (150, 200);
            panel5.BackColor=Color.Khaki;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.TabIndex = 0;
            Controls.Add (panel5);
            ResumeLayout(false);
        }
        #endregion
    }
    class Form6: Form {
        public Form6() {//Kurucu
            Text = "Form6: 5 Farkl� Stil Se�imi";
            Size = new Size (300, 250);
            BackColor=Color.Violet;
            CheckBox[] �k6  = new CheckBox [5];
            int �kBoy = Font.Height;
            int �kEn = �kBoy / 2;
            string[] �kMetin = {"Bold/Koyu", "Italic/Yat�k", "Underline/Alt��izgili", "Strikeout/�zeri�izgili", "Regular/D�zenli"};
            for (int i = 0; i < 5; i++) {
                �k6 [i] = new CheckBox();
                �k6 [i].Text = �kMetin [i];
                �k6 [i].Location = new Point (2 * �kEn, (4 + 4 * i) * �kBoy / 2);
                �k6[i].Size = new Size (20 * �kEn, �kBoy);
                �k6[i].CheckedChanged += new EventHandler (�K_De�i�ti);
            }
            Controls.AddRange (�k6);
        }
        void �K_De�i�ti (object k, EventArgs o) {Invalidate (false);}
        FontStyle[] stiller = {FontStyle.Bold, FontStyle.Italic, FontStyle.Underline, FontStyle.Strikeout, FontStyle.Regular};
        FontStyle stil = 0;     
        protected override void OnPaint (PaintEventArgs o) {
            Graphics g = o.Graphics;
            for (int i = 0; i < 5; i++) {
                if (((CheckBox) Controls [i]).Checked) stil = stiller [i];
                else stil =0;
            g.DrawString (Text, new Font (Font, stil), new SolidBrush (ForeColor), 0, 0);
            }
        }
    }
    class Label_Button3_CheckBox {
        static void Main() {
            Console.Write ("�entikkutulu yaz�stilleri metni stil/siz/lemede kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�entikkutulu yaz�stilleri metni stil/siz/lemede kullan�labilir:");
            int ts=0;
       ba�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Form1 Pencereyi ortalayan d��me");
            Console.WriteLine ("2: Form2 Metnin uzunlu�unu hesaplayan d��me");
            Console.WriteLine ("3: Form3 Fonboyuna orant�l� d��me");
            Console.WriteLine ("4: Form4 �entikle metnin stillenmesi");
            Console.WriteLine ("5: Form5 �oklu �entikkutulu g�dalar");
            Console.WriteLine ("6: Form6 Pencere metnini de/stilleme");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto ba�;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 6) goto ba�;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //D��me1 ilk a��l��ta pencereyi yatay-dikey ortalar
                case 2: Application.Run (new Form2()); break; //Verili d��me metnini hesaplay�p d�nd�r�r
                case 3: Application.Run (new Form3()); break; //D��me konum ve ebat� pencere ve yaz�fonu boyuyla orant�lanabilir
                case 4: Application.Run (new Form4()); break; //�entiklenen stille metin g�ncellenir
                case 5: Application.Run (new Form5()); break; //Pencere panelindeki �oklu �entikkutulu g�da se�imleri
                case 6: Application.Run (new Form6()); break; //Pencere metni se�ilenle de/stillenir
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}