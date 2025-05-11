// j2sc#2302c.cs: Düðme ortalama ve çentikkutulu yazýstilleme örneði.

using System;
using System.Windows.Forms; 
using System.Drawing;
namespace Bileþenler {
    class Form1: Form {
        public Form1() {//Kurucu
            ClientSize = new Size (240, 80);
            Text = "Form1: Ortalanan Düðme";
            BackColor=Color.SkyBlue;
            Button düðme1 = new Button();
            düðme1.Parent = this;
            düðme1.Text = "GÜZEL ORTALANDI!";
            düðme1.BackColor=Color.Violet;
            düðme1.Size = new Size (17 * 5, 14); //(85, 14)
            düðme1.Location = new Point ((ClientSize.Width - düðme1.Width) / 2, (ClientSize.Height - düðme1.Height) / 2); //((240-17*4)/2, (80-14)/2)=(86, 33)
            AutoScaleDimensions = new Size (4, 8);
            AutoScaleMode = AutoScaleMode.Font;
        }
    }
    class Form2: Form {
        public Form2() {//Kurucu
            //Size = new Size (240, 80);
            Text = "Form2: Düðme Metni Uzunluðu";
            BackColor=Color.Tan;
            MesajDüðmesi2 mesajDüðmesi2 = new MesajDüðmesi2();
            mesajDüðmesi2.Parent = this;
            mesajDüðmesi2.Text = "Metnin uzunluðu?";
            mesajDüðmesi2.BackColor=Color.Thistle;
            mesajDüðmesi2.MesajKutusuMetni = "Bu düðme metni 3 krk'den fazla mý?!..";
            mesajDüðmesi2.Location = new Point (100, 90);
            mesajDüðmesi2.AutoSize = true;
        }
    }
    class MesajDüðmesi2: Button {
        string dizge;
        public MesajDüðmesi2() {Enabled = false;} //Kurucu: pasif
        public string MesajKutusuMetni {
            set {dizge = value; Enabled = value != null && value.Length > 3;} //3 krk'den fazla veriyle düðme etkinleþir
            get {return (dizge + ": " + dizge.Length).ToString();}
        }
        protected override void OnClick (EventArgs argm) {MessageBox.Show (MesajKutusuMetni, Text);}
    }
    class Form3: Form {
        public Form3() {//Kurucu
            int fonBoyu = Font.Height; //Varsayýlý yazýfonu yüksekliðini atar
            Text = "Form3: Fonboyuna Orantýlý Pencere&Düðme";
            ClientSize = new Size (fonBoyu * 30, fonBoyu * 10); //Örn. PencereEbat=(12*30, 12*10)=(360, 120)
            BackColor=Color.Tomato;
            Button düðme3 = new Button();
            düðme3.Parent = this;
            düðme3.Text = "M.NÝHAT YAVAÞ";
            düðme3.BackColor=Color.Yellow;
            düðme3.Size = new Size (17 * fonBoyu / 2, 7 * fonBoyu / 4); // DüðmeEbat=(17*12/2, 7*12/4)=(102, 21)
            düðme3.Location = new Point ((ClientSize.Width - düðme3.Width) / 2, (ClientSize.Height - düðme3.Height) / 2); //((360-102)/2, (120-21)/2)=(129, 49.5)
        }
    }
    public class Form4: Form {
        Label etiket4;
        Panel panel4;
        FontStyle[] stiller;
        public Form4() {//Kurucu
            Text = "Form4: Seçilenle Metnin Stillenmasi";
            Size = new Size (300, 250);
            BackColor=Color.SeaGreen;
            //etiket4
            etiket4 = new Label();
            etiket4.Parent = this;
            etiket4.Text = "Mahmut Nihat Yavaþ";
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
            //çentikKutu4
            int i = 1;
            CheckBox çentikKutu4;
            foreach (FontStyle stil in stiller) {
                çentikKutu4 = new CheckBox();
                çentikKutu4.Parent = panel4;
                çentikKutu4.Location = new Point (25, (etiket4Y * (i - 1)) + 10);
                çentikKutu4.Size = new Size (75, 20);
                çentikKutu4.Text = stil.ToString();
                çentikKutu4.Tag = stil;
                çentikKutu4.CheckedChanged += new EventHandler (çentikKutu4_Deðiþti);
                if (çentikKutu4.Text == "Regular") çentikKutu4.Checked = true;
                i++;
            }
        }
        private void çentikKutu4_Deðiþti (object k, EventArgs o) {
            FontStyle fsNo = 0;
            for (int i = 0; i < panel4.Controls.Count; i++) {
                CheckBox çentikKutu4 = (CheckBox)panel4.Controls [i];
                if (çentikKutu4.Checked) fsNo |= (FontStyle)çentikKutu4.Tag;
                if (((CheckBox)panel4.Controls [i]).Checked) fsNo |= (FontStyle)((CheckBox)panel4.Controls [i]).Tag;
            }
            etiket4.Font = new Font (etiket4.Font, fsNo);
        }
    }
    public partial class Form5: Form {
        public Form5() {BileþeniBaþlat();} //Kurucu
        protected override void OnLoad (EventArgs o) {
            base.OnLoad (o);
            string[] gýdalar = {"Armut", "Bal", "Ceviz", "Dut", "Elma", "Fýndýk", "Gazoz", "Hýyar", "Ispanak", "Japon Eriði"};
            SuspendLayout();
            int tepeKonum = 10;
            foreach (string gýda in gýdalar) {
                CheckBox çk5 = new CheckBox();
                çk5.Top = tepeKonum;
                çk5.Left = 10;
                çk5.Text = gýda;
                tepeKonum += 35;
                panel5.Controls.Add (çk5);
            }
            ResumeLayout();
        }
    }
    partial class Form5 {
        #region Form5 kodlamasý
        private Panel panel5;
        private void BileþeniBaþlat() {
            // Form5
            //AutoScaleDimensions = new SizeF (6F, 13F);
            //AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (150, 250);
            Name = "Form5";
            Text = "Form5: Alacaðýn Gýdalarý Seç";
            Size = new Size (300, 250);
            BackColor=Color.DarkKhaki;
            panel5 = new Panel();
            SuspendLayout();
            // panel5
            panel5.AutoScroll = true; //Taþarsa sadece paneli dikey-yatay kaydýrýr
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
            Text = "Form6: 5 Farklý Stil Seçimi";
            Size = new Size (300, 250);
            BackColor=Color.Violet;
            CheckBox[] çk6  = new CheckBox [5];
            int çkBoy = Font.Height;
            int çkEn = çkBoy / 2;
            string[] çkMetin = {"Bold/Koyu", "Italic/Yatýk", "Underline/Altýçizgili", "Strikeout/Üzeriçizgili", "Regular/Düzenli"};
            for (int i = 0; i < 5; i++) {
                çk6 [i] = new CheckBox();
                çk6 [i].Text = çkMetin [i];
                çk6 [i].Location = new Point (2 * çkEn, (4 + 4 * i) * çkBoy / 2);
                çk6[i].Size = new Size (20 * çkEn, çkBoy);
                çk6[i].CheckedChanged += new EventHandler (ÇK_Deðiþti);
            }
            Controls.AddRange (çk6);
        }
        void ÇK_Deðiþti (object k, EventArgs o) {Invalidate (false);}
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
            Console.Write ("Çentikkutulu yazýstilleri metni stil/siz/lemede kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çentikkutulu yazýstilleri metni stil/siz/lemede kullanýlabilir:");
            int ts=0;
       baþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Form1 Pencereyi ortalayan düðme");
            Console.WriteLine ("2: Form2 Metnin uzunluðunu hesaplayan düðme");
            Console.WriteLine ("3: Form3 Fonboyuna orantýlý düðme");
            Console.WriteLine ("4: Form4 Çentikle metnin stillenmesi");
            Console.WriteLine ("5: Form5 Çoklu çentikkutulu gýdalar");
            Console.WriteLine ("6: Form6 Pencere metnini de/stilleme");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto baþ;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 6) goto baþ;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Düðme1 ilk açýlýþta pencereyi yatay-dikey ortalar
                case 2: Application.Run (new Form2()); break; //Verili düðme metnini hesaplayýp döndürür
                case 3: Application.Run (new Form3()); break; //Düðme konum ve ebatý pencere ve yazýfonu boyuyla orantýlanabilir
                case 4: Application.Run (new Form4()); break; //Çentiklenen stille metin güncellenir
                case 5: Application.Run (new Form5()); break; //Pencere panelindeki çoklu çentikkutulu gýda seçimleri
                case 6: Application.Run (new Form6()); break; //Pencere metni seçilenle de/stillenir
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}