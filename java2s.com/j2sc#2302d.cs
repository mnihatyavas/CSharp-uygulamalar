// j2sc#2302d.cs: �oklu tarakl�kutu birimleri ve tek radyod��mesi se�imi �rne�i.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.Collections; //ArrayList i�in
using System.ComponentModel; //CancelEventHandler
using System.Data.SqlClient; //Sql... i�in
//using System.Data;
namespace Bile�enler {
    public class Form1: Form {
        ComboBox tarakl�Kutu;
        Button d��me1a;
        Button d��me1b;
        Button d��me1c;
        Label fi�;
        TextBox metinKutusu;
        Boolean de�i�tiMi = false;
        Boolean i�lendiMi = false;
        public Form1() {//Kurucu
            Text = "Form1: Tarakl� Kutu";
            BackColor=Color.Magenta;
            Size = new Size(300,400);
            Load += new EventHandler(bu_Y�kle);
            //tarakl�Kutu
            tarakl�Kutu = new ComboBox();
            tarakl�Kutu.Parent = this;
            tarakl�Kutu.Location = new Point (10, 10);
            tarakl�Kutu.Size = new Size (ClientSize.Width / 2, Height - 200);
            tarakl�Kutu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            tarakl�Kutu.DropDownStyle = ComboBoxStyle.DropDown;    
            tarakl�Kutu.DropDownStyle = ComboBoxStyle.Simple;
            tarakl�Kutu.DropDownWidth = (int)(tarakl�Kutu.Width * 1.5);
            tarakl�Kutu.MaxDropDownItems = 12;
            tarakl�Kutu.MaxLength = 20;
            tarakl�Kutu.BackColor = Color.Pink;
            tarakl�Kutu.Items.Add ("Fatma Yava�");
            tarakl�Kutu.Items.Add ("Bekir Yava�");
            tarakl�Kutu.Items.Add ("Han�m Yava�");
            tarakl�Kutu.Items.Add ("Memet Yava�");
            tarakl�Kutu.Items.Add ("Hatice Yava� Ka�ar");
            tarakl�Kutu.Items.Add ("S�heyla Y.�zbay");
            tarakl�Kutu.Items.Add ("Zeliha Y.Candan");
            tarakl�Kutu.Items.Add ("M.Nihat Yava�");
            tarakl�Kutu.Items.Add ("Song�l Y.G�kt�rk");
            tarakl�Kutu.Items.Add ("M.Nedim Yava�");
            tarakl�Kutu.Items.Add ("Sevim Yava�");
            tarakl�Kutu.SelectedIndex = 0;
            tarakl�Kutu.SelectionChangeCommitted += new EventHandler (tarakl�Kutu_Se�iliDe�i�imTamaland�);
            tarakl�Kutu.Leave += new EventHandler (tarakl�Kutu_Ayr�l);
            //fi�
            fi� = new Label();
            fi�.Parent = this;
            fi�.BorderStyle = BorderStyle.Fixed3D;
            fi�.Location = new Point (tarakl�Kutu.Left, tarakl�Kutu.Bottom + 10);
            fi�.BackColor = Color.LightGray;
            fi�.Text = "";
            fi�.Size = new Size (tarakl�Kutu.DropDownWidth, Font.Height * 2);
            //d��me1a
            d��me1a = new Button();
            d��me1a.Parent = this;
            d��me1a.Text = "Adlar� &G�ster";
            d��me1a.Size = new Size ((int)(Font.Height * .75) * d��me1a.Text.Length, tarakl�Kutu.Height);
            d��me1a.Location = new Point (fi�.Left, fi�.Bottom + 10);
            d��me1a.BackColor = Color.Violet;
            d��me1a.Click += new EventHandler (d��me1a_T�kland�);
            //d��me1b
            d��me1b = new Button();
            d��me1b.Parent = this;
            d��me1b.Text = "&Ad� Ekle";
            d��me1b.Size = new Size ((int)(Font.Height * .75) * d��me1b.Text.Length, tarakl�Kutu.Height);
            d��me1b.Location = new Point (tarakl�Kutu.Right + 10, tarakl�Kutu.Top);
            d��me1b.BackColor = Color.Cyan;
            d��me1b.Click += new EventHandler (d��me1b_T�kland�);
            //d��me1c
            d��me1c = new Button();
            d��me1c.Parent = this;
            d��me1c.Text = "&Se�";
            d��me1c.Size = new Size ((int)(Font.Height * .75) * d��me1c.Text.Length, tarakl�Kutu.Height);
            d��me1c.Location = new Point (d��me1a.Right + 10, d��me1a.Top);
            d��me1c.BackColor = Color.Thistle;
            d��me1c.Click += new EventHandler (d��me1c_T�kland�);
            //metinKutusu
            metinKutusu = new TextBox();
            metinKutusu.Parent = this;
            metinKutusu.Location = new Point (d��me1a.Left, d��me1a.Bottom + 10);
            metinKutusu.Multiline = true;
            metinKutusu.ReadOnly = true;
            metinKutusu.BackColor = Color.Lime;
            metinKutusu.ScrollBars = ScrollBars.Vertical;
            metinKutusu.Text = "";
            metinKutusu.Size = new Size (tarakl�Kutu.DropDownWidth, 200);
        }
        private void bu_Y�kle (object k, EventArgs o) {
            tarakl�Kutu.TextChanged += new EventHandler (tarakl�Kutu_MetinDe�i�ti);
            tarakl�Kutu.SelectedIndexChanged += new EventHandler (tarakl�Kutu_Se�iliEndeksDe�i�ti);
        }
        private void tarakl�Kutu_MetinDe�i�ti (object k, EventArgs o) {
            if (!i�lendiMi) fi�.Text = tarakl�Kutu.Text;
            de�i�tiMi = true;
        }    
        private void tarakl�Kutu_Se�iliEndeksDe�i�ti (object k, EventArgs o) {
            if (de�i�tiMi) {
                de�i�tiMi = false;
                i�lendiMi = false;
            }
        }
        private void tarakl�Kutu_Se�iliDe�i�imTamaland� (object k, EventArgs o) {if (de�i�tiMi) De�i�ikli�i��le();}
        private void tarakl�Kutu_Ayr�l (object k, EventArgs o) {
            if (de�i�tiMi) {
                De�i�ikli�i��le();
                de�i�tiMi = false;
            }
        }    
        private void De�i�ikli�i��le() {
            fi�.Text = "De�i�en: " + tarakl�Kutu.Text;
            i�lendiMi = true;
        }
        private void d��me1a_T�kland� (object k, EventArgs o) {//G�ster
            string dizge = DateTime.Now.ToString() + "\r\n";
            foreach (object ad in tarakl�Kutu.Items) {dizge += ad.ToString() + "\r\n";}
            metinKutusu.Text = dizge;
        }
        private void d��me1b_T�kland� (object k, EventArgs o) {//Ad ekle
            if (tarakl�Kutu.FindStringExact (tarakl�Kutu.Text) != -1) {
                MessageBox.Show ("'" + tarakl�Kutu.Text + "' listede mevcut.\r\n" +
                "Ayn� ad tekrar girilemez.",
                "Farkl� bir ad girin!");
            }else if (tarakl�Kutu.Text == "") {MessageBox.Show ("Eklenecek ad girilmemi�.", "Ad kutusu bo�");
            }else {tarakl�Kutu.Items.Add (tarakl�Kutu.Text);}
        }
        private void d��me1c_T�kland� (object k, EventArgs o) {tarakl�Kutu.Select (0, 3);}
    }
    public class Form2: Form {
        private ComboBox tarakl�Kutu2a = new ComboBox();
        private Label fi�2a = new Label();
        private ComboBox tarakl�Kutu2b = new ComboBox();
        private Label fi�2b = new Label();
        ArrayList renkDizi = new ArrayList();
        ArrayList fonDizi = new ArrayList();
        public Form2() {//Kurucu
            SuspendLayout();
            //tarakl�Kutu2a
            tarakl�Kutu2a.DrawMode = DrawMode.OwnerDrawVariable;
            tarakl�Kutu2a.ItemHeight = 25;
            tarakl�Kutu2a.Location = new Point (16, 40);
            tarakl�Kutu2a.Size = new Size (264, 31);
            tarakl�Kutu2a.BackColor = Color.Plum;
            tarakl�Kutu2a.SelectedIndexChanged += new EventHandler (Se�ilenBirim);
            tarakl�Kutu2a.MeasureItem += new MeasureItemEventHandler (tarakl�Kutu2a_Birim�l�e�i);
            tarakl�Kutu2a.DrawItem += new DrawItemEventHandler (tarakl�Kutu2a_BirimiYaz);
            //fi�2a
            fi�2a.Location = new Point (16, 16);
            fi�2a.Size = new Size (100, 16);
            fi�2a.Text = "Fon Tarakl� Kutu";
            fi�2a.BackColor = Color.RosyBrown;
            //tarakl�Kutu2b
            tarakl�Kutu2b.DrawMode = DrawMode.OwnerDrawFixed;
            tarakl�Kutu2b.DropDownStyle = ComboBoxStyle.DropDownList;
            tarakl�Kutu2b.ItemHeight = 20;
            tarakl�Kutu2b.Location = new Point (16, 104);
            tarakl�Kutu2b.Size = new Size (264, 26);
            tarakl�Kutu2b.BackColor = Color.Plum;
            tarakl�Kutu2b.SelectedIndexChanged += new EventHandler (Se�ilenBirim);
            tarakl�Kutu2b.MeasureItem += new MeasureItemEventHandler (tarakl�Kutu2b_Birim�l�e�i);
            tarakl�Kutu2b.DrawItem += new DrawItemEventHandler (tarakl�Kutu2b_BirimiYaz);
            //fi�2b
            fi�2b.Location = new Point (24, 80);
            fi�2b.Text = "Renk Tarakl� Kutu";
            fi�2b.BackColor = Color.RosyBrown;
            //form2
            Text = "Form2: Renkli ve Fonlu Tarakl� Kutu";
            BackColor=Color.RoyalBlue;
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (312, 157);
            Controls.AddRange (new Control[] {fi�2a, fi�2b, tarakl�Kutu2a, tarakl�Kutu2b});
            Load += new EventHandler (Form2_Y�kle);
            ResumeLayout (false);
        }
        private void Form2_Y�kle (object k, EventArgs o) {
            //Yaz�fonu, ebat�, stili
            fonDizi.Add (new Font ("Ariel", 15, FontStyle.Bold));
            fonDizi.Add (new Font ("Courier", 12, FontStyle.Italic));
            fonDizi.Add (new Font ("Veranda", 14, FontStyle.Bold));
            fonDizi.Add (new Font ("System", 10, FontStyle.Strikeout));
            fonDizi.Add (new Font ("Century SchoolBook", 15, FontStyle.Underline));
            //tarakl�Kutu2a birimleri
            tarakl�Kutu2a.Items.Add ("Hatice Yava� Ka�ar");
            tarakl�Kutu2a.Items.Add ("S�heyla Y.�zbay");
            tarakl�Kutu2a.Items.Add ("Zeliha Y.Candan");
            tarakl�Kutu2a.Items.Add ("Song�l Y.G�kt�rk");
            tarakl�Kutu2a.Items.Add ("Sevim Yava�");
            //Her birimin rengi
            renkDizi.Add (new SolidBrush (Color.Yellow));
            renkDizi.Add (new SolidBrush (Color.Black));
            renkDizi.Add (new SolidBrush (Color.Azure));
            renkDizi.Add (new SolidBrush (Color.Firebrick));
            renkDizi.Add (new SolidBrush (Color.DarkMagenta));
            //tarakl�Kutu2b birimleri
            tarakl�Kutu2b.Items.Add ("Nur K���kbay");
            tarakl�Kutu2b.Items.Add ("Canan Candan");
            tarakl�Kutu2b.Items.Add ("Sema �zbay");
            tarakl�Kutu2b.Items.Add ("Hilal G�kt�rk");
            tarakl�Kutu2b.Items.Add ("Belk�s Candan");
        }
        private void Se�ilenBirim (object k, EventArgs o) {
            ComboBox tk = null;
            if (k.Equals (tarakl�Kutu2a)) tk = tarakl�Kutu2a;
            else tk = tarakl�Kutu2b;
            int x = tk.SelectedIndex;
            if (k.Equals (tarakl�Kutu2a)) {Console.WriteLine ("Se�ilen birim = " + (string)tk.Items [x]);
            }else {SolidBrush br = (SolidBrush)renkDizi [x]; Console.WriteLine ("Se�ilen renk = " + br.Color.Name);}
        }
        private void tarakl�Kutu2a_Birim�l�e�i (object k, MeasureItemEventArgs o) {
            if (o.Index % 2 == 0) {o.ItemHeight = 45; o.ItemWidth = 20;}
            else {o.ItemHeight = 25; o.ItemWidth = 10;}
        }
        private void tarakl�Kutu2b_Birim�l�e�i (object k, MeasureItemEventArgs o) {
            if (o.Index % 1 == 0) {o.ItemHeight = 45; o.ItemWidth = 20;}
            else {o.ItemHeight = 25; o.ItemWidth = 10;}
        }
        private void tarakl�Kutu2a_BirimiYaz (object k, DrawItemEventArgs o) {
            Graphics g = o.Graphics;
            Rectangle r = o.Bounds;
            Font fn = null;
            if (o.Index >= 0) {
                fn = (Font)fonDizi [o.Index];
                string dzg = (string)tarakl�Kutu2a.Items [o.Index];
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
/*      private void tarakl�Kutu2b_BirimiYaz(object sender, DrawItemEventArgs e) {
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
        private void tarakl�Kutu2b_BirimiYaz (object k, DrawItemEventArgs o) {
            Graphics g = o.Graphics;
            Rectangle r = o.Bounds;
            Font fn = null;
            if (o.Index >= 0) {
                fn = (Font)fonDizi [o.Index];
                string dzg = (string)tarakl�Kutu2b.Items [o.Index];
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
            Text = "Form3: Tarakl�kutu ve Birimleri";
            BackColor=Color.SlateBlue;
            ResumeLayout (false);
        }
        protected override void OnLoad (EventArgs o) {
            base.OnLoad (o);
            //tk3
            Tarakl�Kutu3 tk3 = new Tarakl�Kutu3();
            tk3.Location = new Point (10, 10);
            tk3.BackColor = Color.YellowGreen;
            Controls.Add (tk3);
            tk3.Items.Add ("Hatice Yava� Ka�ar");
            tk3.Items.Add ("S�heyla Y.�zbay");
            tk3.Items.Add ("Zeliha Y.Candan");
            tk3.Items.Add ("Song�l Y.G�kt�rk");
            tk3.Items.Add ("Sevim Yava�");
            tk3.Items.Add ("M.Nihat Yava�");
            tk3.Items.Add ("M.Nedim Yava�");
        }
    }
    public class Tarakl�Kutu3 : ComboBox {
        private bool kontrolTu�uMu = false;
        protected override void OnKeyPress (KeyPressEventArgs o) {
            base.OnKeyPress (o);
            if (o.KeyChar == (int)Keys.Escape) {
                SelectedIndex = -1;
                Text = "";
                kontrolTu�uMu = true;
            }else if (Char.IsControl (o.KeyChar)) {kontrolTu�uMu = true;
            }else {kontrolTu�uMu = false;}
        }
        protected override void OnTextChanged (EventArgs o) {
            base.OnTextChanged (o);
            if (Text != "" && !kontrolTu�uMu) {
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
        string biletS�n�f�;
        public Form4() {Bile�eniBa�lat();}
        private void d��me4_T�kland� (object k, EventArgs o) {MessageBox.Show (biletS�n�f�);}
        private void BiletTipiDe�i�ti (object k, EventArgs o) {
            RadioButton rd = (RadioButton)k;
            if (rd.Checked) biletS�n�f� = rd.Text;
        }
    }
    partial class Form4 {
        private Label fi�4;
        private RadioButton radyoD��mesi4a;
        private RadioButton radyoD��mesi4b;
        private RadioButton radyoD��mesi4c;
        private RadioButton radyoD��mesi4d;
        private RadioButton radyoD��mesi4e;
        private Button d��me4;
        private void Bile�eniBa�lat() {
            //bile�enleri yarat
            fi�4 = new Label();
            radyoD��mesi4a = new RadioButton();
            radyoD��mesi4b = new RadioButton();
            radyoD��mesi4c = new RadioButton();
            radyoD��mesi4d = new RadioButton();
            radyoD��mesi4e = new RadioButton();
            d��me4 = new Button();
            SuspendLayout();
            // fi�4
            fi�4.AutoSize = true;
            fi�4.Location = new Point (12, 9);
            fi�4.Name = "fi�4";
            //fi�4.Size = new Size (168, 13);
            fi�4.TabIndex = 0;
            fi�4.Text = " �stedi�iniz kabin s�n�f�n� se�in... ";
            fi�4.BackColor = Color.MidnightBlue;
            fi�4.ForeColor = Color.Yellow;
            // radyoD��mesi4a
            //radyoD��mesi4a.AutoSize = true;
            radyoD��mesi4a.Location = new Point (46, 44);
            radyoD��mesi4a.Name = "radyoD��mesi4a";
            radyoD��mesi4a.Size = new Size (65, 17);
            radyoD��mesi4a.TabIndex = 1;
            radyoD��mesi4a.Text = "Ekonomi";
            radyoD��mesi4a.CheckedChanged += new EventHandler (BiletTipiDe�i�ti);
            // radyoD��mesi4b
            //radyoD��mesi4b.AutoSize = true;
            radyoD��mesi4b.Location = new Point (46, 68);
            radyoD��mesi4b.Name = "radyoD��mesi4b";
            radyoD��mesi4b.Size = new Size (108, 17);
            radyoD��mesi4b.TabIndex = 2;
            radyoD��mesi4b.Text = "Primli Ekonomi";
            radyoD��mesi4b.CheckedChanged += new EventHandler (BiletTipiDe�i�ti);
            // radyoD��mesi4c
            radyoD��mesi4c.AutoSize = true;
            radyoD��mesi4c.Location = new Point (46, 92);
            radyoD��mesi4c.Name = "radyoD��mesi4c";
            //radyoD��mesi4c.Size = new Size (90, 17);
            radyoD��mesi4c.TabIndex = 3;
            radyoD��mesi4c.Text = "��adam� S�n�f�";
            radyoD��mesi4c.CheckedChanged += new EventHandler (BiletTipiDe�i�ti);
            // radyoD��mesi4d
            radyoD��mesi4d.AutoSize = true;
            radyoD��mesi4d.Location = new Point (46, 116);
            radyoD��mesi4d.Name = "radyoD��mesi4d";
            //radyoD��mesi4d.Size = new Size (123, 17);
            radyoD��mesi4d.TabIndex = 4;
            radyoD��mesi4d.Text = "�st ��adam� S�n�f�";
            radyoD��mesi4d.CheckedChanged += new EventHandler (BiletTipiDe�i�ti);
            // radyoD��mesi4e
            //radyoD��mesi4e.AutoSize = true;
            radyoD��mesi4e.Location = new Point (46, 140);
            radyoD��mesi4e.Name = "radyoD��mesi4e";
            radyoD��mesi4e.Size = new Size (67, 17);
            radyoD��mesi4e.TabIndex = 5;
            radyoD��mesi4e.Text = "V�P S�n�f�";
            radyoD��mesi4e.CheckedChanged += new EventHandler (BiletTipiDe�i�ti);
            // d��me4
            d��me4.Location = new Point (212, 194);
            d��me4.Name = "d��me4";
            d��me4.Size = new Size (75, 23);
            d��me4.TabIndex = 6;
            d��me4.Text = "Tamam";
            d��me4.BackColor = Color.Black;
            d��me4.ForeColor = Color.Red;
            d��me4.Click += new System.EventHandler (d��me4_T�kland�);
            // Form4
            //AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (299, 229);
            Controls.Add (d��me4);
            Controls.Add (radyoD��mesi4e);
            Controls.Add (radyoD��mesi4d);
            Controls.Add (radyoD��mesi4c);
            Controls.Add (radyoD��mesi4b);
            Controls.Add (radyoD��mesi4a);
            Controls.Add (fi�4);
            Name = "Form4";
            Text = "Form4: U�ak Bileti S�n�flar�";
            BackColor=Color.Orange;
            ForeColor=Color.Purple;
            ResumeLayout (false);
            PerformLayout();
        }
    }
    class Form5 : Form {
        private Button d��me5a;
        private Button d��me5b;
        private CheckBox �entikliKutu5;
        private GroupBox radyoGrup;
        private RadioButton radyoD��mesi5a, radyoD��mesi5b, radyoD��mesi5c;
        public int Radyo;
        public bool �entikliMi {get {return �entikliKutu5.Checked;} set {�entikliKutu5.Checked = value;}}
        void RadyoT�kland� (Object k, EventArgs o) {
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
            //d��me5a
            d��me5a = new Button();    
            d��me5a.DialogResult = DialogResult.OK;
            d��me5a.Location = new Point (20, 230);
            d��me5a.Size = new Size (80, 25);
            d��me5a.Text = "TAMAM";
            Controls.Add (d��me5a);
            //d��me5b
            d��me5b = new Button();
            d��me5b.Location = new Point (300, 230);
            d��me5b.Size = new Size (80,25);
            d��me5b.Text = "�PTAL";
            d��me5b.DialogResult = DialogResult.Cancel;
            Controls.Add (d��me5b);
            //�entikliKutu5
            �entikliKutu5 = new CheckBox();
            �entikliKutu5.Location = new Point (20, 30);
            �entikliKutu5.Size = new Size (300, 25);
            �entikliKutu5.Text = "�entikli Kutu";
            Controls.Add (�entikliKutu5);
            //radyoGrup
            radyoGrup = new GroupBox();
            radyoGrup.Text = "Radyo D��meleri";
            radyoGrup.Location = new Point (10, 60);
            radyoGrup.Size = new Size (380, 110);
            radyoGrup.BackColor=Color.Peru;
            Controls.Add (radyoGrup);
            //radyoD��mesi5a
            radyoD��mesi5a = new RadioButton();
            radyoD��mesi5a.Location = new Point (10, 15); 
            radyoD��mesi5a.Size = new Size (360, 25);
            radyoD��mesi5a.Click += new EventHandler (RadyoT�kland�);
            radyoD��mesi5a.Text = "Radyo D��mesi #1";
            radyoGrup.Controls.Add (radyoD��mesi5a);
            //radyoD��mesi5b
            radyoD��mesi5b = new RadioButton();
            radyoD��mesi5b.Location = new Point (10, 40); 
            radyoD��mesi5b.Size = new Size (360, 25);
            radyoD��mesi5b.Click += new EventHandler (RadyoT�kland�);
            radyoD��mesi5b.Text = "Radyo D��mesi #2";
            radyoGrup.Controls.Add (radyoD��mesi5b);
            //radyoD��mesi5a
            radyoD��mesi5c = new RadioButton();
            radyoD��mesi5c.Location = new Point (10, 70); 
            radyoD��mesi5c.Size = new Size (360, 25);
            radyoD��mesi5c.Click += new EventHandler (RadyoT�kland�);
            radyoD��mesi5c.Text = "Radyo D��mesi #3";
            radyoGrup.Controls.Add (radyoD��mesi5c);
        }
    }
    class Form6: Form {
        private Button d��me6a;
        private Button d��me6b;
        private NumericUpDown saya�;
        private Label fi�6;
        public int Saya� {get {return (int)saya�.Value;} set {saya�.Value = (int)value;}}
        public Form6() {//Kurucu
            Size = new Size (400, 100);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Form6: Mesajkutulu Diyalog";
            BackColor=Color.LightSlateGray;
            ForeColor=Color.Lime;
            //d��me6a
            d��me6a = new Button();        
            d��me6a.DialogResult = DialogResult.OK;
            d��me6a.Location = new Point (20, 28);
            d��me6a.Size = new Size (80, 25);
            d��me6a.Text = "TAMAM";
            d��me6a.BackColor=Color.ForestGreen;
            Controls.Add (d��me6a);
            //d��me6b
            d��me6b = new Button();
            d��me6b.Location = new Point (300, 28);
            d��me6b.Size = new Size (80, 25);
            d��me6b.Text = "�PTAL";
            d��me6b.DialogResult = DialogResult.Cancel;
            d��me6b.BackColor=Color.DarkRed;
            Controls.Add (d��me6b);
            //fi�6
            fi�6 = new Label();
            fi�6.Text = "10-->100 Saya�";
            fi�6.Location = new Point (20, 5);
            fi�6.Size = new Size (120, 25);
            Controls.Add (fi�6);
            //saya�
            saya� = new NumericUpDown();
            saya�.Location = new Point (140, 5);
            saya�.Size = new Size (80, 25);
            saya�.Minimum = (int)10;
            saya�.Maximum = (int)100;
            saya�.Value = (int)10;
            saya�.BackColor=Color.Gold;
            saya�.Validating+=new CancelEventHandler (Ge�erliyor);
            saya�.Validated+=new EventHandler (Ge�erledi);
            Controls.Add (saya�);
        }
        void Ge�erliyor (Object k, CancelEventArgs o) {MessageBox.Show ("Saya� de�eri ge�erlileniyor...");}
        void Ge�erledi (Object k, EventArgs o) {MessageBox.Show ("Saya� de�eri ge�erlilendi.");}
    }
    public class Form7: Form {
        ListBox listeKutusu;
        GroupBox radyoGrubu;
        RadioButton radyoD��me7a;
        RadioButton radyoD��me7b;
        RadioButton radyoD��me7c;
        Panel panel;
        Label fi�;
        TextBox metinKutu;
        Button d��me;
        public Form7() {//Kurucu
            int en, boy;
            Size = new Size (250, 400);
            Text = "Form7: Listekutudan Se�meler";
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
            radyoGrubu.Text = "�oklu Se�im";
            radyoGrubu.Location = new Point (listeKutusu.Left, listeKutusu.Bottom + 25);
            //radyoGrubu.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            radyoGrubu.BackColor=Color.HotPink;
            //radyoD��me7a
            radyoD��me7a = new RadioButton();
            radyoD��me7a.Parent = radyoGrubu;
            radyoD��me7a.Text = "Tek Se�im";
            radyoD��me7a.Tag = SelectionMode.One;
            radyoD��me7a.Checked = true;
            radyoD��me7a.Location = new Point (10, 15);
            radyoD��me7a.Size = new Size (150, 25);
            radyoD��me7a.CheckedChanged += new EventHandler (radyoDe�i�ti);
            //radyoD��me7b
            radyoD��me7b = new RadioButton();
            radyoD��me7b.Parent = radyoGrubu;
            radyoD��me7b.Text = "�oklu-Tek Se�im";
            radyoD��me7b.Tag = SelectionMode.MultiSimple;
            radyoD��me7b.Location = new Point (10, radyoD��me7a.Bottom);
            radyoD��me7b.Size = new Size (150, 25);
            radyoD��me7b.CheckedChanged += new EventHandler (radyoDe�i�ti);
            //radyoD��me7c
            radyoD��me7c = new RadioButton();
            radyoD��me7c.Parent = radyoGrubu;
            radyoD��me7c.Text = "�oklu-Ard���k Se�im";
            radyoD��me7c.Tag = SelectionMode.MultiExtended;
            radyoD��me7c.Location = new Point (10, radyoD��me7b.Bottom);
            radyoD��me7c.Size = new Size (150, 25);
            radyoD��me7c.CheckedChanged += new EventHandler (radyoDe�i�ti);
            //radyoGrubu
            en = (int)(Font.Height * .75) * radyoD��me7c.Text.Length;
            boy = ((int)radyoD��me7b.Height * 3) + 20;
            radyoGrubu.Size = new Size (en, boy);
            //panel
            panel = new Panel();
            panel.Parent = this;
            panel.Location = new Point (listeKutusu.Left, radyoGrubu.Bottom + 10);
            //panel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            panel.BackColor=Color.IndianRed;
            //fi�
            fi� = new Label();
            fi�.Parent = panel;
            fi�.Text = "�stEndeksNo: ";
            en = ((int)(Font.Height * 0.5) * fi�.Text.Length);
            fi�.Size = new Size (en, Font.Height + 10);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = panel;
            metinKutu.Location = new Point (fi�.Right, fi�.Top);
            metinKutu.Text = listeKutusu.TopIndex.ToString();
            metinKutu.Size = new Size ((int)(Font.Height * 0.75) * 3, Font.Height + 10);
            //d��me
            d��me = new Button();
            d��me.Parent = panel;
            d��me.Text = "G�ncelle";
            d��me.Location = new Point (metinKutu.Right + 10, metinKutu.Top);
            d��me.BackColor=Color.Black;
            d��me.ForeColor=Color.Yellow;
            d��me.Click += new EventHandler (d��me_T�kland�);
            //listeKutusu
            listeKutusu.Items.Add ("Fatma Yava�");
            listeKutusu.Items.Add ("Bekir Yava�");
            listeKutusu.Items.Add ("Han�m Yava�");
            listeKutusu.Items.Add ("Memet Yava�");
            listeKutusu.Items.Add ("Hatice Yava� Ka�ar");
            listeKutusu.Items.Add ("S�heyla Y.�zbay");
            listeKutusu.Items.Add ("Zeliha Y.Candan");
            listeKutusu.Items.Add ("M.Nihat Yava�");
            listeKutusu.Items.Add ("Song�l Y.G�kt�rk");
            listeKutusu.Items.Add ("M.Nedim Yava�");
            listeKutusu.Items.Add ("Sevim Yava�");
            listeKutusu.Items.Add ("Nur K���kbay");
            listeKutusu.Items.Add ("Y�cel K���kbay");
            listeKutusu.Items.Add ("Serap K���kbay");
            listeKutusu.Items.Add ("Sema �zbay");
            listeKutusu.Items.Add ("Fatih �zbay");
            listeKutusu.Items.Add ("Selda �zbay");
            listeKutusu.Items.Add ("Canan Candan");
            listeKutusu.Items.Add ("Zafer N.Candan");
            listeKutusu.Items.Add ("Belk�s Candan");
            listeKutusu.Items.Add ("Hilal G�kt�rk");
            listeKutusu.Items.Add ("Atilla G�kt�rk");
            listeKutusu.Items.Add ("Bayram K���kbay");
            listeKutusu.Items.Add ("Nihat Ka�ar");
            listeKutusu.Items.Add ("Adil �zbay");
            listeKutusu.Items.Add ("Hamza Candan");
            listeKutusu.Items.Add ("Sefer G�kt�rk");
        } 
        private void radyoDe�i�ti (object k, EventArgs o) {
            RadioButton rd = (RadioButton)k;
            listeKutusu.SelectionMode = (SelectionMode)rd.Tag;
        }
        private void d��me_T�kland� (object k, EventArgs o) {metinKutu.Text = listeKutusu.TopIndex.ToString();}
    }
    public class Form8a {
        public int No;
        public string �sim;
        public  Form8a (string isim, int no) {No = no; �sim = isim;} //Kurucu
        public override string ToString() {return No + ": " + �sim;}
    }
    public class Form8b: Form {
        private GroupBox grupKutu;
        private RadioButton radyoD��me8a;
        private RadioButton radyoD��me8b;
        private ListBox listeKutu;
        private ArrayList i�g�renler = new ArrayList();
        public Form8b() {//Kurucu
            Bile�eniBa�lat();
            listeKutu.Items.Add ("Hatice Y.Ka�ar");
            listeKutu.Items.Add ("S�heyla Y.�zbay");
            listeKutu.Items.Add ("Zeliha Y.Candan");
            listeKutu.Items.Add ("M.Nihat Yava�");
            listeKutu.Items.Add ("Song�l Y.G�kt�rk");
            listeKutu.Items.Add ("M.Nedim Yava�");
            listeKutu.Items.Add ("Sevim Yava�");
            listeKutu.SelectedIndex = 0;
            // ��g�renler dizi-listesi
            i�g�renler.Add(new Form8a ("Hatice Y.Ka�ar", 19510101));
            i�g�renler.Add (new Form8a ("S�heyla Y.�zbay", 19510101)); 
            i�g�renler.Add (new Form8a ("Zeliha Y.Candan", 19550807));
            i�g�renler.Add (new Form8a ("M.Nihat Yava�", 19570417));
            i�g�renler.Add (new Form8a ("Song�l Y.G�kt�rk", 19590101));
            i�g�renler.Add (new Form8a ("M.Nedim Yava�", 19610414));
            i�g�renler.Add (new Form8a ("Sevim Yava�", 19630101));
        }
        private void Bile�eniBa�lat() {
            listeKutu = new ListBox();
            grupKutu = new GroupBox();
            radyoD��me8b = new RadioButton();
            radyoD��me8a = new RadioButton();
            grupKutu.SuspendLayout();
            SuspendLayout();
            // listeKutu
            listeKutu.Location = new Point (16, 8);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (232, 212);
            listeKutu.TabIndex = 0;
            listeKutu.BackColor=Color.DarkCyan;
            listeKutu.ForeColor=Color.Yellow;
            listeKutu.DisplayMemberChanged += new EventHandler (lk_G�r�nen�yeDe�i�ti);
            listeKutu.ValueMemberChanged += new EventHandler (lk_�yeDe�eriDe�i�ti);
            listeKutu.DataSourceChanged += new EventHandler (lk_VeriKayna��De�i�ti);
            listeKutu.SelectedValueChanged += new EventHandler (lk_Se�ilenDe�erDe�i�ti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_Se�ilenEndeksDe�i�ti);
            // grupKutu
            grupKutu.Controls.AddRange (new Control[] {radyoD��me8b, radyoD��me8a});
            grupKutu.Location = new Point (16, 240);
            grupKutu.Name = "grupKutu";
            grupKutu.TabIndex = 1;
            grupKutu.TabStop = false;
            grupKutu.Text = "Veri Kayna��";
            grupKutu.ForeColor=Color.DarkBlue;
            grupKutu.BackColor=Color.DarkOrange;
            // radyoD��me8b
            radyoD��me8b.Location = new Point (24, 56);
            radyoD��me8b.Name = "radyoD��me8b";
            radyoD��me8b.TabIndex = 1;
            radyoD��me8b.Text = "��g�renler";
            radyoD��me8b.CheckedChanged += new EventHandler (rd_Se�imDe�i�ti);
            // radyoD��me8a
            radyoD��me8a.Checked = true;
            radyoD��me8a.Location = new Point (24, 32);
            radyoD��me8a.Name = "radyoD��me8a";
            radyoD��me8a.TabIndex = 0;
            radyoD��me8a.TabStop = true;
            radyoD��me8a.Text = "Y�neticiler";
            radyoD��me8a.CheckedChanged += new EventHandler (rd_Se�imDe�i�ti);
            // Form8b
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (264, 389);
            Controls.AddRange (new Control[] {grupKutu, listeKutu});
            Name = "Form8b";
            Text = "Form8: ��g�renler&Y�neticiler Listesi";
            BackColor=Color.DarkOliveGreen;
            Load += new EventHandler (Form8b_Y�klendi);
            grupKutu.ResumeLayout (false);
            this.ResumeLayout (false);
        }
        private void rd_Se�imDe�i�ti (object k, EventArgs o) {
            listeKutu.DataSource = i�g�renler;
            listeKutu.DisplayMember = "�sim";
            listeKutu.ValueMember = "No";
        }
        private void lk_Se�ilenEndeksDe�i�ti (object k, EventArgs o) {MessageBox.Show (listeKutu.SelectedIndex.ToString()+ "\n" + listeKutu.GetItemText (listeKutu.SelectedItem), "lk_Se�ilenEndeksDe�i�ti");}
        private void lk_Se�ilenDe�erDe�i�ti (object k, EventArgs o) {MessageBox.Show (listeKutu.GetItemText (listeKutu.SelectedItem), "lk_Se�ilenDe�erDe�i�ti");}
        private void lk_VeriKayna��De�i�ti (object k, EventArgs o) {MessageBox.Show (listeKutu.DataSource.ToString(), "lk_VeriKayna��De�i�ti");}
        private void lk_G�r�nen�yeDe�i�ti (object k, EventArgs o) {MessageBox.Show (listeKutu.DisplayMember.ToString(), "lk_G�r�nen�yeDe�i�ti");}
        private void lk_�yeDe�eriDe�i�ti (object k, EventArgs o) {MessageBox.Show (listeKutu.ValueMember.ToString(), "lk_�yeDe�eriDe�i�ti");}
        private void Form8b_Y�klendi (object k, EventArgs o) {
            listeKutu.SelectedValueChanged += new EventHandler (lk_Se�ilenDe�erDe�i�ti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_Se�ilenEndeksDe�i�ti);
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
            //fi�
            Label fi� = new Label();
            fi�.Parent = this;
            fi�.Text = "�sim gir ve sa� d��meyi t�kla:";
            fi�.AutoSize = true;
            fi�.Location = new Point (10, 10);
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
            //d��me
            Button d��me = new Button();
            d��me.Parent = this;
            d��me.Text = "Listeye Ekle";
            d��me.Location = new Point (235, 32);
            d��me.Size = new Size (8 * Font.Height, 2 * Font.Height);
            d��me.Click += new EventHandler (D��meT�kland�);
        }
        void D��meT�kland� (object k, EventArgs o) {
            listeKutu.Items.Add (metinKutu.Text);
            metinKutu.Clear();
        }
    }
    public class Form10: Form {
        private ListBox listeKutu;
        private string ba�lant�Protokolu = "Data Source=localhost:8000;Initial Catalog=Northwind;Integrated Security=SSPI";
        public Form10() {//Kurucu
            listeKutu = new ListBox();
            listeKutu.Dock = DockStyle.Fill;
            listeKutu.BackColor=Color.DarkOrchid;
            Controls.Add (listeKutu);
            Text = "Form10: Localhost:8000 Giri�lerin Listeye Eklenmesi";
            BackColor=Color.DarkSalmon;
            Load += new EventHandler (Form10_Y�kle);
        }
        private void Form10_Y�kle (object k, System.EventArgs o) {
            MessageBox.Show ("�al��abilmesi i�in 'localhost:8000 yerel �evrimi�i.\r\n" +
                "aktiflenip, DOS penceresi verigiri�i okunarak listeye eklenmelidir");
            return;
            string SQL = "SELECT ContactName FROM Customers";
            SqlConnection con = new SqlConnection (ba�lant�Protokolu);
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
            Console.Write ("Listekutudan SelectionMode.One/MultiSimple/MultiExtended se�meler. Radyod��meyle yegane se�imler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("A�a��sarkan tarakl�kutu birimlerini se�me, ekleme, silme, de�i�tirme:");
            Application.EnableVisualStyles();
            int ts=0;
       ba�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Form1 TarakkKutuya ad gir");
            Console.WriteLine ("2: Form2 �ift tarakl�kutuda fon ve renk");
            Console.WriteLine ("3: Form3 Kontroltu�lu tarakl�kutu");
            Console.WriteLine ("4: Form4 Radyod��meli bilet s�n�flar�");
            Console.WriteLine ("5: Form5 Radyod��meler ve �entiklikutu");
            Console.WriteLine ("6: Form6 Artan/azalan saya�");
            Console.WriteLine ("7: Form7 Listekutudan se�im kipleri");
            Console.WriteLine ("8: Form8 ��g�renler&Y�neticiler Listesi");
            Console.WriteLine ("9: Form9 Girilenin Listeye eklenmesi");
            Console.WriteLine ("10: Form10 Localhost:8000 gri�ini listeye ekleme");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto ba�;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 10) goto ba�;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //3 d��me kontrollu adlar gir, de�i�tir, g�ster
                case 2: Application.Run (new Form2()); break; //Fon ve renk tarakl� kutular
                case 3: Application.Run (new Form3()); break; //T�mden sarkan tarakl� birimler ve kontrol krk denetimi
                case 4: Application.Run (new Form4()); break; //Radyod��mesinden sadece biri se�ilebilir
                case 5: Form5 form5 = new Form5();
                        DialogResult sonu�5=form5.ShowDialog();
                        if(sonu�5==DialogResult.OK) {
                            Console.WriteLine ("Radyod��me no: " + form5.Radyo);
                            Console.WriteLine ("�entikli mi? {0}", form5.�entikliMi?"EVET":"HAYIR");}
                        break; //�entiklikutu i�in EVET/HAYIR, radyod��mesi i�in 0/1/2/3 yazar
                case 6: Form6 form6 = new Form6();
                        if(form6.ShowDialog()==DialogResult.OK) Console.WriteLine ("Ge�erli saya� no: " + form6.Saya�);
                        break; //10-->100 aras� ge�erlenen saya� no
                case 7: Application.Run (new Form7()); break; //Listekutu elemanlar� tek, �oklu-tek veya �oklu-ard���k se�meler
                case 8: Application.Run (new Form8b()); break; //Radyod��me se�imiyle y�neticiler/i�g�renler listesi
                case 9: Application.Run (new Form9()); break; //Girilen metin, d��me t�klan�nca listeye eklenir
                case 10: Application.Run (new Form10()); break; //Localhost:8000 giri�lerinin listeye eklenmesi
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}