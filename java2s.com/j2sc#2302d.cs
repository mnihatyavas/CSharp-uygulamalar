// j2sc#2302d.cs: Çoklu taraklýkutu birimleri ve tek radyodüðmesi seçimi örneði.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.Collections; //ArrayList için
using System.ComponentModel; //CancelEventHandler
using System.Data.SqlClient; //Sql... için
//using System.Data;
namespace Bileþenler {
    public class Form1: Form {
        ComboBox taraklýKutu;
        Button düðme1a;
        Button düðme1b;
        Button düðme1c;
        Label fiþ;
        TextBox metinKutusu;
        Boolean deðiþtiMi = false;
        Boolean iþlendiMi = false;
        public Form1() {//Kurucu
            Text = "Form1: Taraklý Kutu";
            BackColor=Color.Magenta;
            Size = new Size(300,400);
            Load += new EventHandler(bu_Yükle);
            //taraklýKutu
            taraklýKutu = new ComboBox();
            taraklýKutu.Parent = this;
            taraklýKutu.Location = new Point (10, 10);
            taraklýKutu.Size = new Size (ClientSize.Width / 2, Height - 200);
            taraklýKutu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            taraklýKutu.DropDownStyle = ComboBoxStyle.DropDown;    
            taraklýKutu.DropDownStyle = ComboBoxStyle.Simple;
            taraklýKutu.DropDownWidth = (int)(taraklýKutu.Width * 1.5);
            taraklýKutu.MaxDropDownItems = 12;
            taraklýKutu.MaxLength = 20;
            taraklýKutu.BackColor = Color.Pink;
            taraklýKutu.Items.Add ("Fatma Yavaþ");
            taraklýKutu.Items.Add ("Bekir Yavaþ");
            taraklýKutu.Items.Add ("Haným Yavaþ");
            taraklýKutu.Items.Add ("Memet Yavaþ");
            taraklýKutu.Items.Add ("Hatice Yavaþ Kaçar");
            taraklýKutu.Items.Add ("Süheyla Y.Özbay");
            taraklýKutu.Items.Add ("Zeliha Y.Candan");
            taraklýKutu.Items.Add ("M.Nihat Yavaþ");
            taraklýKutu.Items.Add ("Songül Y.Göktürk");
            taraklýKutu.Items.Add ("M.Nedim Yavaþ");
            taraklýKutu.Items.Add ("Sevim Yavaþ");
            taraklýKutu.SelectedIndex = 0;
            taraklýKutu.SelectionChangeCommitted += new EventHandler (taraklýKutu_SeçiliDeðiþimTamalandý);
            taraklýKutu.Leave += new EventHandler (taraklýKutu_Ayrýl);
            //fiþ
            fiþ = new Label();
            fiþ.Parent = this;
            fiþ.BorderStyle = BorderStyle.Fixed3D;
            fiþ.Location = new Point (taraklýKutu.Left, taraklýKutu.Bottom + 10);
            fiþ.BackColor = Color.LightGray;
            fiþ.Text = "";
            fiþ.Size = new Size (taraklýKutu.DropDownWidth, Font.Height * 2);
            //düðme1a
            düðme1a = new Button();
            düðme1a.Parent = this;
            düðme1a.Text = "Adlarý &Göster";
            düðme1a.Size = new Size ((int)(Font.Height * .75) * düðme1a.Text.Length, taraklýKutu.Height);
            düðme1a.Location = new Point (fiþ.Left, fiþ.Bottom + 10);
            düðme1a.BackColor = Color.Violet;
            düðme1a.Click += new EventHandler (düðme1a_Týklandý);
            //düðme1b
            düðme1b = new Button();
            düðme1b.Parent = this;
            düðme1b.Text = "&Adý Ekle";
            düðme1b.Size = new Size ((int)(Font.Height * .75) * düðme1b.Text.Length, taraklýKutu.Height);
            düðme1b.Location = new Point (taraklýKutu.Right + 10, taraklýKutu.Top);
            düðme1b.BackColor = Color.Cyan;
            düðme1b.Click += new EventHandler (düðme1b_Týklandý);
            //düðme1c
            düðme1c = new Button();
            düðme1c.Parent = this;
            düðme1c.Text = "&Seç";
            düðme1c.Size = new Size ((int)(Font.Height * .75) * düðme1c.Text.Length, taraklýKutu.Height);
            düðme1c.Location = new Point (düðme1a.Right + 10, düðme1a.Top);
            düðme1c.BackColor = Color.Thistle;
            düðme1c.Click += new EventHandler (düðme1c_Týklandý);
            //metinKutusu
            metinKutusu = new TextBox();
            metinKutusu.Parent = this;
            metinKutusu.Location = new Point (düðme1a.Left, düðme1a.Bottom + 10);
            metinKutusu.Multiline = true;
            metinKutusu.ReadOnly = true;
            metinKutusu.BackColor = Color.Lime;
            metinKutusu.ScrollBars = ScrollBars.Vertical;
            metinKutusu.Text = "";
            metinKutusu.Size = new Size (taraklýKutu.DropDownWidth, 200);
        }
        private void bu_Yükle (object k, EventArgs o) {
            taraklýKutu.TextChanged += new EventHandler (taraklýKutu_MetinDeðiþti);
            taraklýKutu.SelectedIndexChanged += new EventHandler (taraklýKutu_SeçiliEndeksDeðiþti);
        }
        private void taraklýKutu_MetinDeðiþti (object k, EventArgs o) {
            if (!iþlendiMi) fiþ.Text = taraklýKutu.Text;
            deðiþtiMi = true;
        }    
        private void taraklýKutu_SeçiliEndeksDeðiþti (object k, EventArgs o) {
            if (deðiþtiMi) {
                deðiþtiMi = false;
                iþlendiMi = false;
            }
        }
        private void taraklýKutu_SeçiliDeðiþimTamalandý (object k, EventArgs o) {if (deðiþtiMi) DeðiþikliðiÝþle();}
        private void taraklýKutu_Ayrýl (object k, EventArgs o) {
            if (deðiþtiMi) {
                DeðiþikliðiÝþle();
                deðiþtiMi = false;
            }
        }    
        private void DeðiþikliðiÝþle() {
            fiþ.Text = "Deðiþen: " + taraklýKutu.Text;
            iþlendiMi = true;
        }
        private void düðme1a_Týklandý (object k, EventArgs o) {//Göster
            string dizge = DateTime.Now.ToString() + "\r\n";
            foreach (object ad in taraklýKutu.Items) {dizge += ad.ToString() + "\r\n";}
            metinKutusu.Text = dizge;
        }
        private void düðme1b_Týklandý (object k, EventArgs o) {//Ad ekle
            if (taraklýKutu.FindStringExact (taraklýKutu.Text) != -1) {
                MessageBox.Show ("'" + taraklýKutu.Text + "' listede mevcut.\r\n" +
                "Ayný ad tekrar girilemez.",
                "Farklý bir ad girin!");
            }else if (taraklýKutu.Text == "") {MessageBox.Show ("Eklenecek ad girilmemiþ.", "Ad kutusu boþ");
            }else {taraklýKutu.Items.Add (taraklýKutu.Text);}
        }
        private void düðme1c_Týklandý (object k, EventArgs o) {taraklýKutu.Select (0, 3);}
    }
    public class Form2: Form {
        private ComboBox taraklýKutu2a = new ComboBox();
        private Label fiþ2a = new Label();
        private ComboBox taraklýKutu2b = new ComboBox();
        private Label fiþ2b = new Label();
        ArrayList renkDizi = new ArrayList();
        ArrayList fonDizi = new ArrayList();
        public Form2() {//Kurucu
            SuspendLayout();
            //taraklýKutu2a
            taraklýKutu2a.DrawMode = DrawMode.OwnerDrawVariable;
            taraklýKutu2a.ItemHeight = 25;
            taraklýKutu2a.Location = new Point (16, 40);
            taraklýKutu2a.Size = new Size (264, 31);
            taraklýKutu2a.BackColor = Color.Plum;
            taraklýKutu2a.SelectedIndexChanged += new EventHandler (SeçilenBirim);
            taraklýKutu2a.MeasureItem += new MeasureItemEventHandler (taraklýKutu2a_BirimÖlçeði);
            taraklýKutu2a.DrawItem += new DrawItemEventHandler (taraklýKutu2a_BirimiYaz);
            //fiþ2a
            fiþ2a.Location = new Point (16, 16);
            fiþ2a.Size = new Size (100, 16);
            fiþ2a.Text = "Fon Taraklý Kutu";
            fiþ2a.BackColor = Color.RosyBrown;
            //taraklýKutu2b
            taraklýKutu2b.DrawMode = DrawMode.OwnerDrawFixed;
            taraklýKutu2b.DropDownStyle = ComboBoxStyle.DropDownList;
            taraklýKutu2b.ItemHeight = 20;
            taraklýKutu2b.Location = new Point (16, 104);
            taraklýKutu2b.Size = new Size (264, 26);
            taraklýKutu2b.BackColor = Color.Plum;
            taraklýKutu2b.SelectedIndexChanged += new EventHandler (SeçilenBirim);
            taraklýKutu2b.MeasureItem += new MeasureItemEventHandler (taraklýKutu2b_BirimÖlçeði);
            taraklýKutu2b.DrawItem += new DrawItemEventHandler (taraklýKutu2b_BirimiYaz);
            //fiþ2b
            fiþ2b.Location = new Point (24, 80);
            fiþ2b.Text = "Renk Taraklý Kutu";
            fiþ2b.BackColor = Color.RosyBrown;
            //form2
            Text = "Form2: Renkli ve Fonlu Taraklý Kutu";
            BackColor=Color.RoyalBlue;
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (312, 157);
            Controls.AddRange (new Control[] {fiþ2a, fiþ2b, taraklýKutu2a, taraklýKutu2b});
            Load += new EventHandler (Form2_Yükle);
            ResumeLayout (false);
        }
        private void Form2_Yükle (object k, EventArgs o) {
            //Yazýfonu, ebatý, stili
            fonDizi.Add (new Font ("Ariel", 15, FontStyle.Bold));
            fonDizi.Add (new Font ("Courier", 12, FontStyle.Italic));
            fonDizi.Add (new Font ("Veranda", 14, FontStyle.Bold));
            fonDizi.Add (new Font ("System", 10, FontStyle.Strikeout));
            fonDizi.Add (new Font ("Century SchoolBook", 15, FontStyle.Underline));
            //taraklýKutu2a birimleri
            taraklýKutu2a.Items.Add ("Hatice Yavaþ Kaçar");
            taraklýKutu2a.Items.Add ("Süheyla Y.Özbay");
            taraklýKutu2a.Items.Add ("Zeliha Y.Candan");
            taraklýKutu2a.Items.Add ("Songül Y.Göktürk");
            taraklýKutu2a.Items.Add ("Sevim Yavaþ");
            //Her birimin rengi
            renkDizi.Add (new SolidBrush (Color.Yellow));
            renkDizi.Add (new SolidBrush (Color.Black));
            renkDizi.Add (new SolidBrush (Color.Azure));
            renkDizi.Add (new SolidBrush (Color.Firebrick));
            renkDizi.Add (new SolidBrush (Color.DarkMagenta));
            //taraklýKutu2b birimleri
            taraklýKutu2b.Items.Add ("Nur Küçükbay");
            taraklýKutu2b.Items.Add ("Canan Candan");
            taraklýKutu2b.Items.Add ("Sema Özbay");
            taraklýKutu2b.Items.Add ("Hilal Göktürk");
            taraklýKutu2b.Items.Add ("Belkýs Candan");
        }
        private void SeçilenBirim (object k, EventArgs o) {
            ComboBox tk = null;
            if (k.Equals (taraklýKutu2a)) tk = taraklýKutu2a;
            else tk = taraklýKutu2b;
            int x = tk.SelectedIndex;
            if (k.Equals (taraklýKutu2a)) {Console.WriteLine ("Seçilen birim = " + (string)tk.Items [x]);
            }else {SolidBrush br = (SolidBrush)renkDizi [x]; Console.WriteLine ("Seçilen renk = " + br.Color.Name);}
        }
        private void taraklýKutu2a_BirimÖlçeði (object k, MeasureItemEventArgs o) {
            if (o.Index % 2 == 0) {o.ItemHeight = 45; o.ItemWidth = 20;}
            else {o.ItemHeight = 25; o.ItemWidth = 10;}
        }
        private void taraklýKutu2b_BirimÖlçeði (object k, MeasureItemEventArgs o) {
            if (o.Index % 1 == 0) {o.ItemHeight = 45; o.ItemWidth = 20;}
            else {o.ItemHeight = 25; o.ItemWidth = 10;}
        }
        private void taraklýKutu2a_BirimiYaz (object k, DrawItemEventArgs o) {
            Graphics g = o.Graphics;
            Rectangle r = o.Bounds;
            Font fn = null;
            if (o.Index >= 0) {
                fn = (Font)fonDizi [o.Index];
                string dzg = (string)taraklýKutu2a.Items [o.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                o.Graphics.DrawRectangle (new Pen (new SolidBrush (Color.Black), 2), r);
                if (o.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect)) {
                    o.Graphics.FillRectangle (new SolidBrush (Color.White), r);
                    o.Graphics.DrawString (dzg, fn, new SolidBrush (Color.Black), r, sf);
                    o.DrawFocusRectangle();
                }else {
                    o.Graphics.FillRectangle (new SolidBrush(Color.LightBlue), r);
                    o.Graphics.DrawString (dzg, fn, new SolidBrush (Color.Red), r, sf);
                    o.DrawFocusRectangle();
                }
            }
        }
/*      private void taraklýKutu2b_BirimiYaz(object sender, DrawItemEventArgs e) {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            if (e.Index >= 0) {
                Rectangle rd = r;
                rd.Width = 100;
                Rectangle rt = r;
                SolidBrush b = (SolidBrush)renkDizi[e.Index];
                g.FillRectangle(b, rd);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                Console.WriteLine(e.State.ToString());
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), r);
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect)) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), r);
                    e.Graphics.DrawString(b.Color.Name, new Font("Ariel", 8, FontStyle.Bold), new SolidBrush(Color.Black), r, sf);
                    e.DrawFocusRectangle();
                }else {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), r);
                    e.Graphics.DrawString(b.Color.Name, new Font("Veranda", 12, FontStyle.Bold), new SolidBrush(Color.Red), r, sf);
                    e.DrawFocusRectangle();
                }
            }
        }
*/
        private void taraklýKutu2b_BirimiYaz (object k, DrawItemEventArgs o) {
            Graphics g = o.Graphics;
            Rectangle r = o.Bounds;
            Font fn = null;
            if (o.Index >= 0) {
                fn = (Font)fonDizi [o.Index];
                string dzg = (string)taraklýKutu2b.Items [o.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                o.Graphics.DrawRectangle (new Pen (new SolidBrush (Color.Black), 2), r);
                if (o.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect)) {
                    o.Graphics.FillRectangle (new SolidBrush (Color.White), r);
                    o.Graphics.DrawString (dzg, fn, new SolidBrush (Color.Black), r, sf);
                    o.DrawFocusRectangle();
                }else {
                    o.Graphics.FillRectangle (new SolidBrush(Color.LightBlue), r);
                    o.Graphics.DrawString (dzg, fn, new SolidBrush (Color.Red), r, sf);
                    o.DrawFocusRectangle();
                }
            }
        }
    }
    public partial class Form3 : Form {
        public Form3() {//Kurucu
            SuspendLayout();
            //AutoScaleDimensions = new SizeF (6F, 13F);
            //AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Name = "Form3";
            Text = "Form3: Taraklýkutu ve Birimleri";
            BackColor=Color.SlateBlue;
            ResumeLayout (false);
        }
        protected override void OnLoad (EventArgs o) {
            base.OnLoad (o);
            //tk3
            TaraklýKutu3 tk3 = new TaraklýKutu3();
            tk3.Location = new Point (10, 10);
            tk3.BackColor = Color.YellowGreen;
            Controls.Add (tk3);
            tk3.Items.Add ("Hatice Yavaþ Kaçar");
            tk3.Items.Add ("Süheyla Y.Özbay");
            tk3.Items.Add ("Zeliha Y.Candan");
            tk3.Items.Add ("Songül Y.Göktürk");
            tk3.Items.Add ("Sevim Yavaþ");
            tk3.Items.Add ("M.Nihat Yavaþ");
            tk3.Items.Add ("M.Nedim Yavaþ");
        }
    }
    public class TaraklýKutu3 : ComboBox {
        private bool kontrolTuþuMu = false;
        protected override void OnKeyPress (KeyPressEventArgs o) {
            base.OnKeyPress (o);
            if (o.KeyChar == (int)Keys.Escape) {
                SelectedIndex = -1;
                Text = "";
                kontrolTuþuMu = true;
            }else if (Char.IsControl (o.KeyChar)) {kontrolTuþuMu = true;
            }else {kontrolTuþuMu = false;}
        }
        protected override void OnTextChanged (EventArgs o) {
            base.OnTextChanged (o);
            if (Text != "" && !kontrolTuþuMu) {
                string dzg = Text;
                int end = FindString (dzg);
                if (end != -1) {
                    SelectedIndex = end;
                    SelectionStart = dzg.Length;
                    SelectionLength = Text.Length - SelectionStart;
                }
            }
        }
    }
    public partial class Form4: Form {
        string biletSýnýfý;
        public Form4() {BileþeniBaþlat();}
        private void düðme4_Týklandý (object k, EventArgs o) {MessageBox.Show (biletSýnýfý);}
        private void BiletTipiDeðiþti (object k, EventArgs o) {
            RadioButton rd = (RadioButton)k;
            if (rd.Checked) biletSýnýfý = rd.Text;
        }
    }
    partial class Form4 {
        private Label fiþ4;
        private RadioButton radyoDüðmesi4a;
        private RadioButton radyoDüðmesi4b;
        private RadioButton radyoDüðmesi4c;
        private RadioButton radyoDüðmesi4d;
        private RadioButton radyoDüðmesi4e;
        private Button düðme4;
        private void BileþeniBaþlat() {
            //bileþenleri yarat
            fiþ4 = new Label();
            radyoDüðmesi4a = new RadioButton();
            radyoDüðmesi4b = new RadioButton();
            radyoDüðmesi4c = new RadioButton();
            radyoDüðmesi4d = new RadioButton();
            radyoDüðmesi4e = new RadioButton();
            düðme4 = new Button();
            SuspendLayout();
            // fiþ4
            fiþ4.AutoSize = true;
            fiþ4.Location = new Point (12, 9);
            fiþ4.Name = "fiþ4";
            //fiþ4.Size = new Size (168, 13);
            fiþ4.TabIndex = 0;
            fiþ4.Text = " Ýstediðiniz kabin sýnýfýný seçin... ";
            fiþ4.BackColor = Color.MidnightBlue;
            fiþ4.ForeColor = Color.Yellow;
            // radyoDüðmesi4a
            //radyoDüðmesi4a.AutoSize = true;
            radyoDüðmesi4a.Location = new Point (46, 44);
            radyoDüðmesi4a.Name = "radyoDüðmesi4a";
            radyoDüðmesi4a.Size = new Size (65, 17);
            radyoDüðmesi4a.TabIndex = 1;
            radyoDüðmesi4a.Text = "Ekonomi";
            radyoDüðmesi4a.CheckedChanged += new EventHandler (BiletTipiDeðiþti);
            // radyoDüðmesi4b
            //radyoDüðmesi4b.AutoSize = true;
            radyoDüðmesi4b.Location = new Point (46, 68);
            radyoDüðmesi4b.Name = "radyoDüðmesi4b";
            radyoDüðmesi4b.Size = new Size (108, 17);
            radyoDüðmesi4b.TabIndex = 2;
            radyoDüðmesi4b.Text = "Primli Ekonomi";
            radyoDüðmesi4b.CheckedChanged += new EventHandler (BiletTipiDeðiþti);
            // radyoDüðmesi4c
            radyoDüðmesi4c.AutoSize = true;
            radyoDüðmesi4c.Location = new Point (46, 92);
            radyoDüðmesi4c.Name = "radyoDüðmesi4c";
            //radyoDüðmesi4c.Size = new Size (90, 17);
            radyoDüðmesi4c.TabIndex = 3;
            radyoDüðmesi4c.Text = "Ýþadamý Sýnýfý";
            radyoDüðmesi4c.CheckedChanged += new EventHandler (BiletTipiDeðiþti);
            // radyoDüðmesi4d
            radyoDüðmesi4d.AutoSize = true;
            radyoDüðmesi4d.Location = new Point (46, 116);
            radyoDüðmesi4d.Name = "radyoDüðmesi4d";
            //radyoDüðmesi4d.Size = new Size (123, 17);
            radyoDüðmesi4d.TabIndex = 4;
            radyoDüðmesi4d.Text = "Üst Ýþadamý Sýnýfý";
            radyoDüðmesi4d.CheckedChanged += new EventHandler (BiletTipiDeðiþti);
            // radyoDüðmesi4e
            //radyoDüðmesi4e.AutoSize = true;
            radyoDüðmesi4e.Location = new Point (46, 140);
            radyoDüðmesi4e.Name = "radyoDüðmesi4e";
            radyoDüðmesi4e.Size = new Size (67, 17);
            radyoDüðmesi4e.TabIndex = 5;
            radyoDüðmesi4e.Text = "VÝP Sýnýfý";
            radyoDüðmesi4e.CheckedChanged += new EventHandler (BiletTipiDeðiþti);
            // düðme4
            düðme4.Location = new Point (212, 194);
            düðme4.Name = "düðme4";
            düðme4.Size = new Size (75, 23);
            düðme4.TabIndex = 6;
            düðme4.Text = "Tamam";
            düðme4.BackColor = Color.Black;
            düðme4.ForeColor = Color.Red;
            düðme4.Click += new System.EventHandler (düðme4_Týklandý);
            // Form4
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (299, 229);
            Controls.Add (düðme4);
            Controls.Add (radyoDüðmesi4e);
            Controls.Add (radyoDüðmesi4d);
            Controls.Add (radyoDüðmesi4c);
            Controls.Add (radyoDüðmesi4b);
            Controls.Add (radyoDüðmesi4a);
            Controls.Add (fiþ4);
            Name = "Form4";
            Text = "Form4: Uçak Bileti Sýnýflarý";
            BackColor=Color.Orange;
            ForeColor=Color.Purple;
            ResumeLayout (false);
            PerformLayout();
        }
    }
    class Form5 : Form {
        private Button düðme5a;
        private Button düðme5b;
        private CheckBox çentikliKutu5;
        private GroupBox radyoGrup;
        private RadioButton radyoDüðmesi5a, radyoDüðmesi5b, radyoDüðmesi5c;
        public int Radyo;
        public bool ÇentikliMi {get {return çentikliKutu5.Checked;} set {çentikliKutu5.Checked = value;}}
        void RadyoTýklandý (Object k, EventArgs o) {
            int n=0;
            foreach (Object ns in radyoGrup.Controls) {
                if(ns is RadioButton) {
                    RadioButton rd=(RadioButton)ns;
                    if(rd.Checked) Radyo=++n;
                    n++;
                }
            }
        }
        public Form5() {//Kurucu
            Size = new Size (400, 300);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Form5: Diyalog testi";
            BackColor=Color.Sienna;
            ForeColor=Color.Cyan;
            //düðme5a
            düðme5a = new Button();    
            düðme5a.DialogResult = DialogResult.OK;
            düðme5a.Location = new Point (20, 230);
            düðme5a.Size = new Size (80, 25);
            düðme5a.Text = "TAMAM";
            Controls.Add (düðme5a);
            //düðme5b
            düðme5b = new Button();
            düðme5b.Location = new Point (300, 230);
            düðme5b.Size = new Size (80,25);
            düðme5b.Text = "ÝPTAL";
            düðme5b.DialogResult = DialogResult.Cancel;
            Controls.Add (düðme5b);
            //çentikliKutu5
            çentikliKutu5 = new CheckBox();
            çentikliKutu5.Location = new Point (20, 30);
            çentikliKutu5.Size = new Size (300, 25);
            çentikliKutu5.Text = "Çentikli Kutu";
            Controls.Add (çentikliKutu5);
            //radyoGrup
            radyoGrup = new GroupBox();
            radyoGrup.Text = "Radyo Düðmeleri";
            radyoGrup.Location = new Point (10, 60);
            radyoGrup.Size = new Size (380, 110);
            radyoGrup.BackColor=Color.Peru;
            Controls.Add (radyoGrup);
            //radyoDüðmesi5a
            radyoDüðmesi5a = new RadioButton();
            radyoDüðmesi5a.Location = new Point (10, 15); 
            radyoDüðmesi5a.Size = new Size (360, 25);
            radyoDüðmesi5a.Click += new EventHandler (RadyoTýklandý);
            radyoDüðmesi5a.Text = "Radyo Düðmesi #1";
            radyoGrup.Controls.Add (radyoDüðmesi5a);
            //radyoDüðmesi5b
            radyoDüðmesi5b = new RadioButton();
            radyoDüðmesi5b.Location = new Point (10, 40); 
            radyoDüðmesi5b.Size = new Size (360, 25);
            radyoDüðmesi5b.Click += new EventHandler (RadyoTýklandý);
            radyoDüðmesi5b.Text = "Radyo Düðmesi #2";
            radyoGrup.Controls.Add (radyoDüðmesi5b);
            //radyoDüðmesi5a
            radyoDüðmesi5c = new RadioButton();
            radyoDüðmesi5c.Location = new Point (10, 70); 
            radyoDüðmesi5c.Size = new Size (360, 25);
            radyoDüðmesi5c.Click += new EventHandler (RadyoTýklandý);
            radyoDüðmesi5c.Text = "Radyo Düðmesi #3";
            radyoGrup.Controls.Add (radyoDüðmesi5c);
        }
    }
    class Form6: Form {
        private Button düðme6a;
        private Button düðme6b;
        private NumericUpDown sayaç;
        private Label fiþ6;
        public int Sayaç {get {return (int)sayaç.Value;} set {sayaç.Value = (int)value;}}
        public Form6() {//Kurucu
            Size = new Size (400, 100);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Form6: Mesajkutulu Diyalog";
            BackColor=Color.LightSlateGray;
            ForeColor=Color.Lime;
            //düðme6a
            düðme6a = new Button();        
            düðme6a.DialogResult = DialogResult.OK;
            düðme6a.Location = new Point (20, 28);
            düðme6a.Size = new Size (80, 25);
            düðme6a.Text = "TAMAM";
            düðme6a.BackColor=Color.ForestGreen;
            Controls.Add (düðme6a);
            //düðme6b
            düðme6b = new Button();
            düðme6b.Location = new Point (300, 28);
            düðme6b.Size = new Size (80, 25);
            düðme6b.Text = "ÝPTAL";
            düðme6b.DialogResult = DialogResult.Cancel;
            düðme6b.BackColor=Color.DarkRed;
            Controls.Add (düðme6b);
            //fiþ6
            fiþ6 = new Label();
            fiþ6.Text = "10-->100 Sayaç";
            fiþ6.Location = new Point (20, 5);
            fiþ6.Size = new Size (120, 25);
            Controls.Add (fiþ6);
            //sayaç
            sayaç = new NumericUpDown();
            sayaç.Location = new Point (140, 5);
            sayaç.Size = new Size (80, 25);
            sayaç.Minimum = (int)10;
            sayaç.Maximum = (int)100;
            sayaç.Value = (int)10;
            sayaç.BackColor=Color.Gold;
            sayaç.Validating+=new CancelEventHandler (Geçerliyor);
            sayaç.Validated+=new EventHandler (Geçerledi);
            Controls.Add (sayaç);
        }
        void Geçerliyor (Object k, CancelEventArgs o) {MessageBox.Show ("Sayaç deðeri geçerlileniyor...");}
        void Geçerledi (Object k, EventArgs o) {MessageBox.Show ("Sayaç deðeri geçerlilendi.");}
    }
    public class Form7: Form {
        ListBox listeKutusu;
        GroupBox radyoGrubu;
        RadioButton radyoDüðme7a;
        RadioButton radyoDüðme7b;
        RadioButton radyoDüðme7c;
        Panel panel;
        Label fiþ;
        TextBox metinKutu;
        Button düðme;
        public Form7() {//Kurucu
            int en, boy;
            Size = new Size (250, 400);
            Text = "Form7: Listekutudan Seçmeler";
            BackColor=Color.Indigo;
            ForeColor=Color.Khaki;
            //listeKutusu
            listeKutusu = new ListBox();
            listeKutusu.Parent = this;
            listeKutusu.Location = new Point (10, 10);
            listeKutusu.Size = new Size (ClientSize.Width - 20, Height - 200);
            //listeKutusu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            listeKutusu.BorderStyle = BorderStyle.Fixed3D;
            listeKutusu.MultiColumn = true;
            listeKutusu.ScrollAlwaysVisible = true;
            listeKutusu.BackColor=Color.Pink;
            //radyoGrubu
            radyoGrubu = new GroupBox();
            radyoGrubu.Parent = this;
            radyoGrubu.Text = "Çoklu Seçim";
            radyoGrubu.Location = new Point (listeKutusu.Left, listeKutusu.Bottom + 25);
            //radyoGrubu.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            radyoGrubu.BackColor=Color.HotPink;
            //radyoDüðme7a
            radyoDüðme7a = new RadioButton();
            radyoDüðme7a.Parent = radyoGrubu;
            radyoDüðme7a.Text = "Tek Seçim";
            radyoDüðme7a.Tag = SelectionMode.One;
            radyoDüðme7a.Checked = true;
            radyoDüðme7a.Location = new Point (10, 15);
            radyoDüðme7a.Size = new Size (150, 25);
            radyoDüðme7a.CheckedChanged += new EventHandler (radyoDeðiþti);
            //radyoDüðme7b
            radyoDüðme7b = new RadioButton();
            radyoDüðme7b.Parent = radyoGrubu;
            radyoDüðme7b.Text = "Çoklu-Tek Seçim";
            radyoDüðme7b.Tag = SelectionMode.MultiSimple;
            radyoDüðme7b.Location = new Point (10, radyoDüðme7a.Bottom);
            radyoDüðme7b.Size = new Size (150, 25);
            radyoDüðme7b.CheckedChanged += new EventHandler (radyoDeðiþti);
            //radyoDüðme7c
            radyoDüðme7c = new RadioButton();
            radyoDüðme7c.Parent = radyoGrubu;
            radyoDüðme7c.Text = "Çoklu-Ardýþýk Seçim";
            radyoDüðme7c.Tag = SelectionMode.MultiExtended;
            radyoDüðme7c.Location = new Point (10, radyoDüðme7b.Bottom);
            radyoDüðme7c.Size = new Size (150, 25);
            radyoDüðme7c.CheckedChanged += new EventHandler (radyoDeðiþti);
            //radyoGrubu
            en = (int)(Font.Height * .75) * radyoDüðme7c.Text.Length;
            boy = ((int)radyoDüðme7b.Height * 3) + 20;
            radyoGrubu.Size = new Size (en, boy);
            //panel
            panel = new Panel();
            panel.Parent = this;
            panel.Location = new Point (listeKutusu.Left, radyoGrubu.Bottom + 10);
            //panel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            panel.BackColor=Color.IndianRed;
            //fiþ
            fiþ = new Label();
            fiþ.Parent = panel;
            fiþ.Text = "ÜstEndeksNo: ";
            en = ((int)(Font.Height * 0.5) * fiþ.Text.Length);
            fiþ.Size = new Size (en, Font.Height + 10);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = panel;
            metinKutu.Location = new Point (fiþ.Right, fiþ.Top);
            metinKutu.Text = listeKutusu.TopIndex.ToString();
            metinKutu.Size = new Size ((int)(Font.Height * 0.75) * 3, Font.Height + 10);
            //düðme
            düðme = new Button();
            düðme.Parent = panel;
            düðme.Text = "Güncelle";
            düðme.Location = new Point (metinKutu.Right + 10, metinKutu.Top);
            düðme.BackColor=Color.Black;
            düðme.ForeColor=Color.Yellow;
            düðme.Click += new EventHandler (düðme_Týklandý);
            //listeKutusu
            listeKutusu.Items.Add ("Fatma Yavaþ");
            listeKutusu.Items.Add ("Bekir Yavaþ");
            listeKutusu.Items.Add ("Haným Yavaþ");
            listeKutusu.Items.Add ("Memet Yavaþ");
            listeKutusu.Items.Add ("Hatice Yavaþ Kaçar");
            listeKutusu.Items.Add ("Süheyla Y.Özbay");
            listeKutusu.Items.Add ("Zeliha Y.Candan");
            listeKutusu.Items.Add ("M.Nihat Yavaþ");
            listeKutusu.Items.Add ("Songül Y.Göktürk");
            listeKutusu.Items.Add ("M.Nedim Yavaþ");
            listeKutusu.Items.Add ("Sevim Yavaþ");
            listeKutusu.Items.Add ("Nur Küçükbay");
            listeKutusu.Items.Add ("Yücel Küçükbay");
            listeKutusu.Items.Add ("Serap Küçükbay");
            listeKutusu.Items.Add ("Sema Özbay");
            listeKutusu.Items.Add ("Fatih Özbay");
            listeKutusu.Items.Add ("Selda Özbay");
            listeKutusu.Items.Add ("Canan Candan");
            listeKutusu.Items.Add ("Zafer N.Candan");
            listeKutusu.Items.Add ("Belkýs Candan");
            listeKutusu.Items.Add ("Hilal Göktürk");
            listeKutusu.Items.Add ("Atilla Göktürk");
            listeKutusu.Items.Add ("Bayram Küçükbay");
            listeKutusu.Items.Add ("Nihat Kaçar");
            listeKutusu.Items.Add ("Adil Özbay");
            listeKutusu.Items.Add ("Hamza Candan");
            listeKutusu.Items.Add ("Sefer Göktürk");
        } 
        private void radyoDeðiþti (object k, EventArgs o) {
            RadioButton rd = (RadioButton)k;
            listeKutusu.SelectionMode = (SelectionMode)rd.Tag;
        }
        private void düðme_Týklandý (object k, EventArgs o) {metinKutu.Text = listeKutusu.TopIndex.ToString();}
    }
    public class Form8a {
        public int No;
        public string Ýsim;
        public  Form8a (string isim, int no) {No = no; Ýsim = isim;} //Kurucu
        public override string ToString() {return No + ": " + Ýsim;}
    }
    public class Form8b: Form {
        private GroupBox grupKutu;
        private RadioButton radyoDüðme8a;
        private RadioButton radyoDüðme8b;
        private ListBox listeKutu;
        private ArrayList iþgörenler = new ArrayList();
        public Form8b() {//Kurucu
            BileþeniBaþlat();
            listeKutu.Items.Add ("Hatice Y.Kaçar");
            listeKutu.Items.Add ("Süheyla Y.Özbay");
            listeKutu.Items.Add ("Zeliha Y.Candan");
            listeKutu.Items.Add ("M.Nihat Yavaþ");
            listeKutu.Items.Add ("Songül Y.Göktürk");
            listeKutu.Items.Add ("M.Nedim Yavaþ");
            listeKutu.Items.Add ("Sevim Yavaþ");
            listeKutu.SelectedIndex = 0;
            // Ýþgörenler dizi-listesi
            iþgörenler.Add(new Form8a ("Hatice Y.Kaçar", 19510101));
            iþgörenler.Add (new Form8a ("Süheyla Y.Özbay", 19510101)); 
            iþgörenler.Add (new Form8a ("Zeliha Y.Candan", 19550807));
            iþgörenler.Add (new Form8a ("M.Nihat Yavaþ", 19570417));
            iþgörenler.Add (new Form8a ("Songül Y.Göktürk", 19590101));
            iþgörenler.Add (new Form8a ("M.Nedim Yavaþ", 19610414));
            iþgörenler.Add (new Form8a ("Sevim Yavaþ", 19630101));
        }
        private void BileþeniBaþlat() {
            listeKutu = new ListBox();
            grupKutu = new GroupBox();
            radyoDüðme8b = new RadioButton();
            radyoDüðme8a = new RadioButton();
            grupKutu.SuspendLayout();
            SuspendLayout();
            // listeKutu
            listeKutu.Location = new Point (16, 8);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (232, 212);
            listeKutu.TabIndex = 0;
            listeKutu.BackColor=Color.DarkCyan;
            listeKutu.ForeColor=Color.Yellow;
            listeKutu.DisplayMemberChanged += new EventHandler (lk_GörünenÜyeDeðiþti);
            listeKutu.ValueMemberChanged += new EventHandler (lk_ÜyeDeðeriDeðiþti);
            listeKutu.DataSourceChanged += new EventHandler (lk_VeriKaynaðýDeðiþti);
            listeKutu.SelectedValueChanged += new EventHandler (lk_SeçilenDeðerDeðiþti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_SeçilenEndeksDeðiþti);
            // grupKutu
            grupKutu.Controls.AddRange (new Control[] {radyoDüðme8b, radyoDüðme8a});
            grupKutu.Location = new Point (16, 240);
            grupKutu.Name = "grupKutu";
            grupKutu.TabIndex = 1;
            grupKutu.TabStop = false;
            grupKutu.Text = "Veri Kaynaðý";
            grupKutu.ForeColor=Color.DarkBlue;
            grupKutu.BackColor=Color.DarkOrange;
            // radyoDüðme8b
            radyoDüðme8b.Location = new Point (24, 56);
            radyoDüðme8b.Name = "radyoDüðme8b";
            radyoDüðme8b.TabIndex = 1;
            radyoDüðme8b.Text = "Ýþgörenler";
            radyoDüðme8b.CheckedChanged += new EventHandler (rd_SeçimDeðiþti);
            // radyoDüðme8a
            radyoDüðme8a.Checked = true;
            radyoDüðme8a.Location = new Point (24, 32);
            radyoDüðme8a.Name = "radyoDüðme8a";
            radyoDüðme8a.TabIndex = 0;
            radyoDüðme8a.TabStop = true;
            radyoDüðme8a.Text = "Yöneticiler";
            radyoDüðme8a.CheckedChanged += new EventHandler (rd_SeçimDeðiþti);
            // Form8b
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (264, 389);
            Controls.AddRange (new Control[] {grupKutu, listeKutu});
            Name = "Form8b";
            Text = "Form8: Ýþgörenler&Yöneticiler Listesi";
            BackColor=Color.DarkOliveGreen;
            Load += new EventHandler (Form8b_Yüklendi);
            grupKutu.ResumeLayout (false);
            this.ResumeLayout (false);
        }
        private void rd_SeçimDeðiþti (object k, EventArgs o) {
            listeKutu.DataSource = iþgörenler;
            listeKutu.DisplayMember = "Ýsim";
            listeKutu.ValueMember = "No";
        }
        private void lk_SeçilenEndeksDeðiþti (object k, EventArgs o) {MessageBox.Show (listeKutu.SelectedIndex.ToString()+ "\n" + listeKutu.GetItemText (listeKutu.SelectedItem), "lk_SeçilenEndeksDeðiþti");}
        private void lk_SeçilenDeðerDeðiþti (object k, EventArgs o) {MessageBox.Show (listeKutu.GetItemText (listeKutu.SelectedItem), "lk_SeçilenDeðerDeðiþti");}
        private void lk_VeriKaynaðýDeðiþti (object k, EventArgs o) {MessageBox.Show (listeKutu.DataSource.ToString(), "lk_VeriKaynaðýDeðiþti");}
        private void lk_GörünenÜyeDeðiþti (object k, EventArgs o) {MessageBox.Show (listeKutu.DisplayMember.ToString(), "lk_GörünenÜyeDeðiþti");}
        private void lk_ÜyeDeðeriDeðiþti (object k, EventArgs o) {MessageBox.Show (listeKutu.ValueMember.ToString(), "lk_ÜyeDeðeriDeðiþti");}
        private void Form8b_Yüklendi (object k, EventArgs o) {
            listeKutu.SelectedValueChanged += new EventHandler (lk_SeçilenDeðerDeðiþti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_SeçilenEndeksDeðiþti);
        }
    }
    public class Form9: Form {
        private TextBox metinKutu;
        private ListBox listeKutu;
        public Form9() {//Kurucu
            Size = new Size (400, 380);
            Text = "Form9: Girilenlerin Listeye Eklenmesi";
            BackColor=Color.DarkGreen;
            ForeColor=Color.Yellow;
            //fiþ
            Label fiþ = new Label();
            fiþ.Parent = this;
            fiþ.Text = "Ýsim gir ve sað düðmeyi týkla:";
            fiþ.AutoSize = true;
            fiþ.Location = new Point (10, 10);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Size = new Size (200, 2 * Font.Height);
            metinKutu.Location = new Point (10, 35);
            metinKutu.BackColor=Color.Cyan;
            //listeKutu
            listeKutu = new ListBox();
            listeKutu.Parent = this;
            listeKutu.Location = new  Point (10, 65);
            listeKutu.Size = new Size(350, 20 * Font.Height);
            listeKutu.BackColor=Color.Lime;
            //düðme
            Button düðme = new Button();
            düðme.Parent = this;
            düðme.Text = "Listeye Ekle";
            düðme.Location = new Point (235, 32);
            düðme.Size = new Size (8 * Font.Height, 2 * Font.Height);
            düðme.Click += new EventHandler (DüðmeTýklandý);
        }
        void DüðmeTýklandý (object k, EventArgs o) {
            listeKutu.Items.Add (metinKutu.Text);
            metinKutu.Clear();
        }
    }
    public class Form10: Form {
        private ListBox listeKutu;
        private string baðlantýProtokolu = "Data Source=localhost:8000;Initial Catalog=Northwind;Integrated Security=SSPI";
        public Form10() {//Kurucu
            listeKutu = new ListBox();
            listeKutu.Dock = DockStyle.Fill;
            listeKutu.BackColor=Color.DarkOrchid;
            Controls.Add (listeKutu);
            Text = "Form10: Localhost:8000 Giriþlerin Listeye Eklenmesi";
            BackColor=Color.DarkSalmon;
            Load += new EventHandler (Form10_Yükle);
        }
        private void Form10_Yükle (object k, System.EventArgs o) {
            MessageBox.Show ("Çalýþabilmesi için 'localhost:8000 yerel çevrimiçi.\r\n" +
                "aktiflenip, DOS penceresi verigiriþi okunarak listeye eklenmelidir");
            return;
            string SQL = "SELECT ContactName FROM Customers";
            SqlConnection con = new SqlConnection (baðlantýProtokolu);
            SqlCommand cmd = new SqlCommand (SQL, con);
            SqlDataReader r = null;
            con.Open();
            r = cmd.ExecuteReader();
            while (r.Read()) {listeKutu.Items.Add (r["ContactName"]);}
            con.Close();
        }
    }
    class ComboBox_RadioButton {
        static void Main() {
            Console.Write ("Listekutudan SelectionMode.One/MultiSimple/MultiExtended seçmeler. Radyodüðmeyle yegane seçimler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Aþaðýsarkan taraklýkutu birimlerini seçme, ekleme, silme, deðiþtirme:");
            Application.EnableVisualStyles();
            int ts=0;
       baþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Form1 TarakkKutuya ad gir");
            Console.WriteLine ("2: Form2 Çift taraklýkutuda fon ve renk");
            Console.WriteLine ("3: Form3 Kontroltuþlu taraklýkutu");
            Console.WriteLine ("4: Form4 Radyodüðmeli bilet sýnýflarý");
            Console.WriteLine ("5: Form5 Radyodüðmeler ve çentiklikutu");
            Console.WriteLine ("6: Form6 Artan/azalan sayaç");
            Console.WriteLine ("7: Form7 Listekutudan seçim kipleri");
            Console.WriteLine ("8: Form8 Ýþgörenler&Yöneticiler Listesi");
            Console.WriteLine ("9: Form9 Girilenin Listeye eklenmesi");
            Console.WriteLine ("10: Form10 Localhost:8000 griþini listeye ekleme");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto baþ;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 10) goto baþ;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //3 düðme kontrollu adlar gir, deðiþtir, göster
                case 2: Application.Run (new Form2()); break; //Fon ve renk taraklý kutular
                case 3: Application.Run (new Form3()); break; //Tümden sarkan taraklý birimler ve kontrol krk denetimi
                case 4: Application.Run (new Form4()); break; //Radyodüðmesinden sadece biri seçilebilir
                case 5: Form5 form5 = new Form5();
                        DialogResult sonuç5=form5.ShowDialog();
                        if(sonuç5==DialogResult.OK) {
                            Console.WriteLine ("Radyodüðme no: " + form5.Radyo);
                            Console.WriteLine ("Çentikli mi? {0}", form5.ÇentikliMi?"EVET":"HAYIR");}
                        break; //Çentiklikutu için EVET/HAYIR, radyodüðmesi için 0/1/2/3 yazar
                case 6: Form6 form6 = new Form6();
                        if(form6.ShowDialog()==DialogResult.OK) Console.WriteLine ("Geçerli sayaç no: " + form6.Sayaç);
                        break; //10-->100 arasý geçerlenen sayaç no
                case 7: Application.Run (new Form7()); break; //Listekutu elemanlarý tek, çoklu-tek veya çoklu-ardýþýk seçmeler
                case 8: Application.Run (new Form8b()); break; //Radyodüðme seçimiyle yöneticiler/iþgörenler listesi
                case 9: Application.Run (new Form9()); break; //Girilen metin, düðme týklanýnca listeye eklenir
                case 10: Application.Run (new Form10()); break; //Localhost:8000 giriþlerinin listeye eklenmesi
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}