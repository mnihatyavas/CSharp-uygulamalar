// j2sc#2302e.cs: Metinkutu �e�itleri ve maskeli metinkutusu-1 �rne�i.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.Collections; //ArrayList i�in
using System.ComponentModel; //CancelEventHandler
using System.Text; //StringBuilder i�in
using System.Text.RegularExpressions; //Regex i�in
namespace Bile�enler {
    class Form1: Form {
        private Label fi�;
        private TextBox metinKutu;
        private Button d��me;
        public Form1() {//Kurucu
            fi� = new Label();
            metinKutu = new TextBox();
            d��me = new Button();
            SuspendLayout();
            //fi�
            fi�.Location = new Point (16, 36);
            //fi�.Name = "fi�";
            fi�.Size = new Size (128, 16);
            //fi�.TabIndex = 0;
            fi�.Text = "L�tfen ad�n�z� girin:";
            fi�.BackColor=Color.SlateBlue;
            //metinKutu
            metinKutu.Location = new Point (152, 32);
            metinKutu.Name = "metinKutu";
            metinKutu.TabIndex = 1;
            metinKutu.Text = "";
            metinKutu.BackColor=Color.Cyan;
            //d��me
            d��me.Location = new Point (109, 80);
            //d��me.Name = "d��me";
            //d��me.TabIndex = 2;
            d��me.Text = "T�kla";
            d��me.BackColor=Color.SteelBlue;
            d��me.Click += new EventHandler (d��me_T�kland�);
            //this
            ClientSize = new Size (292, 126);
            Controls.Add (d��me);
            Controls.Add (metinKutu);
            Controls.Add (fi�);
            Name = "form1";
            Text = "Form1: MetinKutu Veri Giri�i";
            BackColor=Color.Tan;
            ForeColor=Color.DeepPink;
            ResumeLayout (false);    
        }
        private void d��me_T�kland� (object k, EventArgs o) {
            Console.WriteLine ("Ad: {0}", metinKutu.Text);
            MessageBox.Show ("Merhaba: " + metinKutu.Text);
        }
    }
    class Form2: Form {
        private Label fi�2a;
        private Label fi�2b;
        private Label fi�2c;
        private Label fi�2d;
        private TextBox metinKutu2a;
        private TextBox metinKutu2b;
        private TextBox metinKutu2c;
        private TextBox metinKutu2d;
        private Button d��me2a;
        private Button d��me2b;
        private GroupBox grupKutu;
        private RadioButton radyoD��me2a;
        private RadioButton radyoD��me2b;
        private CheckBox �entikKutu;
        public Form2() {//Kurucu
            Bile�eniBa�lat();
            d��me2a.Enabled = false;
            metinKutu2a.Tag = false;
            metinKutu2b.Tag = false;
            metinKutu2c.Tag = false;
            metinKutu2a.Validating += new CancelEventHandler (bo�MetinKutu_Ge�erliyor);
            metinKutu2b.Validating += new CancelEventHandler (bo�MetinKutu_Ge�erliyor);
            metinKutu2c.Validating += new CancelEventHandler (bo�MetinKutu_Ge�erliyor);
            metinKutu2a.TextChanged += new EventHandler (metinKutu_MetinDe�i�ti);
            metinKutu2b.TextChanged += new EventHandler (metinKutu_MetinDe�i�ti);
            metinKutu2c.TextChanged += new EventHandler (metinKutu_MetinDe�i�ti);
        }
        private void bo�MetinKutu_Ge�erliyor (object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            if (mk.Text.Length == 0) {
                mk.BackColor = Color.Red;
                mk.Tag = false;
            }else {
                mk.BackColor = SystemColors.Window;
                mk.Tag = true;
            }
            Ge�erlemeTamam();
        }
        private void metinKutu_MetinDe�i�ti (object k, EventArgs o) {
            TextBox mk = (TextBox)k;
            if (mk.Text.Length == 0) {
                mk.Tag = false;
                mk.BackColor = Color.Red;
            }else {
                mk.Tag = true;
                mk.BackColor = SystemColors.Window;
            }
            Ge�erlemeTamam();
        }
        private void Ge�erlemeTamam() {d��me2a.Enabled = ((bool)(metinKutu2b.Tag) && (bool)(metinKutu2c.Tag) && (bool)(metinKutu2a.Tag));}
        private void d��me2a_T�kland� (object k, EventArgs o) {metinKutu2d.Text = "Tamam d��mesi\r\nTIKLANDI";}
        private void d��me2b_T�kland� (object k, EventArgs o) {metinKutu2d.Text = "Fatma Yava�\r\nBekir Yava�\r\nHan�m Yava�\r\nMemet Yava�\\Hatice Yava� Ka�ar\r\nS�heyla Y.�zbay\r\nZeliha Y.Candan\r\nM.Nihat Yava�\r\nSong�l Y.G�kt�rk\r\nM.Nedim Yava�\r\nSevim Yava�";}
        private void metinKutu2c_Tu�Bas�ld� (object k, KeyPressEventArgs o) {if ((o.KeyChar < 48 || o.KeyChar > 57) && o.KeyChar != 8) {o.Handled = true; o.KeyChar=' ';}} //Say�sal d��� girilenin iptali
        private void Bile�eniBa�lat() {
            fi�2a = new Label();
            fi�2b = new Label();
            fi�2c = new Label();
            fi�2d = new Label();
            metinKutu2a = new TextBox();
            metinKutu2b = new TextBox();
            metinKutu2c = new TextBox();
            metinKutu2d = new TextBox();
            d��me2a = new Button();
            d��me2b = new Button();
            grupKutu = new GroupBox();
            radyoD��me2b = new RadioButton();
            radyoD��me2a = new RadioButton();
            �entikKutu = new CheckBox();
            SuspendLayout();
            grupKutu.SuspendLayout();
            //fi�2a
            //fi�2a.AutoSize = true;
            fi�2a.Location = new Point (13, 16);
            //fi�2a.Name = "fi�2a";
            fi�2a.Size = new Size (50, 14);
            //fi�2a.TabIndex = 0;
            fi�2a.Text = "�sim gir";
            //metinKutu2a
            metinKutu2a.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            metinKutu2a.Location = new Point (106, 13);
            //metinKutu2a.Name = "metinKutu2a";
            metinKutu2a.Size = new Size (225, 20);
            metinKutu2a.TabIndex = 2;
            metinKutu2a.BackColor=Color.Wheat;
            //d��me2a
            d��me2a.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            d��me2a.Location = new Point (338, 13);
            //d��me2a.Name = "d��me2a";
            d��me2a.TabIndex = 8;
            d��me2a.Text = "Tamam";
            d��me2a.Click += new EventHandler (d��me2a_T�kland�);
            //fi�2b
            //fi�2b.AutoSize = true;
            fi�2b.Location = new Point (13, 43);
            //fi�2b.Name = "fi�2b";
            fi�2b.Size = new Size (50, 14);
            //fi�2b.TabIndex = 1;
            fi�2b.Text = "Adres gir";
            //metinKutu2b
            metinKutu2b.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            //metinKutu2b.AutoSize = false;
            metinKutu2b.Location = new Point (106, 40);
            metinKutu2b.Multiline = true;
            //metinKutu2b.Name = "metinKutu2b";
            metinKutu2b.ScrollBars = ScrollBars.Vertical;
            metinKutu2b.Size = new Size (225, 80);
            metinKutu2b.TabIndex = 3;
            metinKutu2b.BackColor=Color.Wheat;
            //d��me2b
            d��me2b.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            d��me2b.CausesValidation = false;
            d��me2b.Location = new Point (338, 43);
            //d��me2b.Name = "d��me2b";
            //d��me2b.TabIndex = 9;
            d��me2b.Text = "Yard�m";
            d��me2b.Click += new EventHandler (d��me2b_T�kland�);
            //�entikKutu
            //�entikKutu.AutoSize = true;
            �entikKutu.Checked = true;
            �entikKutu.CheckState = CheckState.Checked;
            �entikKutu.Location = new Point (13, 128);
            //�entikKutu.Name = "�entikKutu";
            �entikKutu.Size = new Size (78, 17);
            �entikKutu.TabIndex = 13;
            �entikKutu.Text = "Programc�";
            //grupKutu
            grupKutu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            grupKutu.Controls.Add (radyoD��me2a);
            grupKutu.Controls.Add (radyoD��me2b);
            grupKutu.Location = new Point (13, 152);
            //grupKutu.Name = "grupKutu";
            grupKutu.Size = new Size (318, 50);
            //grupKutu.TabIndex = 12;
            //grupKutu.TabStop = false;
            grupKutu.Text = "Cinsiyet";
            //radyoD��me2a
            //radyoD��me2a.AutoSize = true;
            radyoD��me2a.Checked = true;
            radyoD��me2a.Location = new Point (44, 20);
            //radyoD��me2a.Name = "radyoD��me2a";
            radyoD��me2a.Size = new Size (55, 17);
            radyoD��me2a.TabIndex = 0;
            radyoD��me2a.Text = "Kad�n";
            //radyoD��me2a
            //radyoD��me2b.AutoSize = true;
            radyoD��me2b.Location = new Point (182, 20);
            //radyoD��me2b.Name = "radyoD��me2b";
            radyoD��me2b.Size = new Size (55, 17);
            radyoD��me2b.TabIndex = 1;
            radyoD��me2b.Text = "Erkek";
            //fi�2c
            fi�2c.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //fi�2c.AutoSize = true;
            fi�2c.Location = new Point (13, 212);
            //fi�2c.Name = "fi�2c";
            fi�2c.Size = new Size (50, 14);
            fi�2c.TabIndex = 10;
            fi�2c.Text = "Ya� gir";
            //metinKutu2c
            metinKutu2c.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            metinKutu2c.Location = new Point (106, 209);
            metinKutu2c.MaxLength = 3;
            //metinKutu2c.Name = "metinKutu2c";
            metinKutu2c.TabIndex = 11;
            metinKutu2c.BackColor=Color.Wheat;
            metinKutu2c.KeyPress += new KeyPressEventHandler (metinKutu2c_Tu�Bas�ld�);
            //fi�2d
            fi�2d.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //fi�2d.AutoSize = true;
            fi�2d.Location = new Point (13, 233);
            //fi�2d.Name = "fi�2d";
            fi�2d.Size = new Size (50, 14);
            //fi�2d.TabIndex = 6;
            fi�2d.Text = "��kt�:";
            //metinKutu2d
            metinKutu2d.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //metinKutu2d.AutoSize = false;
            metinKutu2d.Location = new Point (13, 254);
            metinKutu2d.Multiline = true;
            //metinKutu2d.Name = "metinKutu2d";
            metinKutu2d.ReadOnly = true;
            metinKutu2d.ScrollBars = ScrollBars.Vertical;
            metinKutu2d.Size = new Size (318, 116);
            //metinKutu2d.TabIndex = 14;
            metinKutu2d.BackColor=Color.Wheat;
            //this
            //AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (422, 382);
            Controls.AddRange (new Control[] {fi�2a, fi�2b, fi�2c, fi�2d, metinKutu2a, metinKutu2b, metinKutu2c, metinKutu2d, d��me2a, d��me2b, �entikKutu, grupKutu});
            //MinimumSize = new Size (430, 328);
            Text = "Form2: Ge�erlilemeli MetinKutular";
            BackColor=Color.Lime;
            ForeColor=Color.Tomato;
            grupKutu.ResumeLayout (false);
            grupKutu.PerformLayout();
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public class Form3: Form {
        TextBox metinKutu;
        string �ncekiDizge;
        public Form3() {//Kurucu
            Text = "Form3: �oklusat�r Metinkutu Dizgesi";
            BackColor=Color.Sienna;
            ForeColor=Color.Purple;
            Size = new Size (300, 375);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Text = "M.Nihat Yava�";
            metinKutu.Size = new Size (ClientSize.Width - 20, ClientSize.Height - 100);
            metinKutu.Location = new Point (10, 10);
            metinKutu.Multiline = true;
            metinKutu.BorderStyle = BorderStyle.Fixed3D;
            metinKutu.ScrollBars = ScrollBars.Vertical;
            metinKutu.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            metinKutu.BackColor=Color.Pink;
            �ncekiDizge = metinKutu.Text;
        }
    }
    public class Form4: Form {
        TextBox metinKutu;
        string �ncekiDizge;
        public Form4() {//Kurucu
            Text = "Form3: De�i�en Metinkutu Dizgesi";
            BackColor=Color.Sienna;
            ForeColor=Color.Purple;
            Size = new Size (300, 375);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Text = "M.Nihat Yava�";
            metinKutu.Size = new Size (ClientSize.Width - 20, ClientSize.Height - 100);
            metinKutu.Location = new Point (10, 10);
            metinKutu.TextChanged += new EventHandler (metinKutu_MetinDe�i�ti);
            metinKutu.Multiline = true;
            metinKutu.BorderStyle = BorderStyle.Fixed3D;
            metinKutu.ScrollBars = ScrollBars.Vertical;
            metinKutu.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            metinKutu.BackColor=Color.Pink;
            �ncekiDizge = metinKutu.Text;
        }
        private void metinKutu_MetinDe�i�ti (object k, EventArgs o) {
            if (�ncekiDizge == metinKutu.Text) metinKutu.Modified = false;
            else metinKutu.Modified = true;
            if (metinKutu.Modified) MessageBox.Show ("Metin DE���T�");
            //else MessageBox.Show ("Metin DE���MED�");
        }
    }
    public class Form5: Form {
        private Label fi�5a;
        private TextBox metinKutu;
        private Label fi�5b;
        private Label fi�5bb;
        private Label fi�5c;
        private Label fi�5cc;
        private Label fi�5d;
        public Form5() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            fi�5a = new Label();
            metinKutu = new TextBox();
            fi�5b = new Label();
            fi�5bb = new Label();
            fi�5c = new Label();
            fi�5cc = new Label();
            fi�5d = new Label();
            SuspendLayout();
            // fi�5a
            fi�5a.Font = new Font ("Tahoma", 14.25F, (FontStyle.Bold | FontStyle.Italic), GraphicsUnit.Point, ((System.Byte)(0)));
            fi�5a.Location = new Point (48, 16);
            fi�5a.Name = "fi�5a";
            fi�5a.Size = new Size (176, 23);
            fi�5a.TabIndex = 0;
            fi�5a.Text = "ISBN Ge�erleme";
            // metinKutu
            metinKutu.Location = new Point (72, 64);
            metinKutu.Name = "metinKutu";
            metinKutu.TabIndex = 1;
            metinKutu.Text = "0551-5559464";
            metinKutu.BackColor=Color.Plum;
            metinKutu.KeyPress += new KeyPressEventHandler (metinKutu_Tu�Bas�ld�);
            metinKutu.Validating += new CancelEventHandler (pencereyiKapatY�net);
            // fi�5b
            fi�5b.Location = new Point (24, 104);
            fi�5b.Name = "fi�5b";
            fi�5b.Size = new Size (80, 23);
            fi�5b.TabIndex = 2;
            fi�5b.Text = "Do�ru Say�:";
            // fi�5bb
            fi�5bb.BorderStyle = BorderStyle.Fixed3D;
            fi�5bb.Location = new Point (112, 104);
            fi�5bb.Name = "fi�5bb";
            fi�5bb.TabIndex = 3;
            fi�5bb.BackColor=Color.SeaGreen;
            // fi�5c
            fi�5c.Location = new Point (32, 152);
            fi�5c.Name = "fi�5c";
            fi�5c.Size = new Size (80, 23);
            fi�5c.TabIndex = 4;
            fi�5c.Text = "Kontrol Rakam:";
            // fi�5cc
            fi�5cc.BorderStyle = BorderStyle.Fixed3D;
            fi�5cc.Location = new Point (112, 152);
            fi�5cc.Name = "fi�5cc";
            fi�5cc.TabIndex = 5;
            fi�5cc.BackColor=Color.SeaGreen;
            // fi�5d
            fi�5d.Location = new Point (56, 212);
            fi�5d.Name = "fi�5d";
            fi�5d.Size = new Size (152, 24);
            fi�5d.TabIndex = 8;
            // Form5
            Text = "Form5: Do�ru ISBN Giri�i";
            BackColor=Color.Purple;
            ForeColor=Color.Orange;
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (264, 293);
            Controls.AddRange (new Control[] {fi�5a, metinKutu, fi�5b, fi�5bb, fi�5c, fi�5cc, fi�5d});
            ResumeLayout (false);
        }
        private void metinKutu_Tu�Bas�ld� (object k, KeyPressEventArgs o) {
            char tu�Krk;
            tu�Krk = o.KeyChar;
            if (!Char.IsDigit (tu�Krk)      // 0 - 9
                && tu�Krk != 8             // backspace
                && tu�Krk != 13            // enter
                && tu�Krk != 'x'
                && tu�Krk != 45             //  dash/minus/-
            ) o.Handled = true;
        }
        private void pencereyiKapatY�net (object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            string dizge = mk.Text;
            Console.WriteLine (dizge); //DOS pencere
            fi�5bb.Text = dizge;       //Say�
            fi�5cc.Text = dizge;       //Rakam
            fi�5d.Text = "ISBN: " + dizge; //Sonu�
            MessageBox.Show ("Ge�erli ISBN: " + dizge); //Mesajkutusu
        }
    }
    public partial class Form6: Form {
        public Form6() {Bile�eniBa�lat();} //Kurucu
        private void d��me6a_T�kland� (object k, EventArgs o) {
            StringBuilder sb = new StringBuilder();
            sb.Append ("Metinkutuda toplam " + metinKutu.Lines.Length.ToString() + " sat�r var:\n\n");
            foreach (string str in metinKutu.Lines) {sb.Append (str + "\n");}
            MessageBox.Show (sb.ToString());
        }
        private void d��me6b_T�kland� (object k, EventArgs o) {
            if (metinKutu.SelectionLength == 0) {MessageBox.Show ("�ncelikle metinkutudan se�ilen olmal�d�r.");
            }else {
                StringBuilder sb = new StringBuilder();
                sb.Append (String.Format ("T�m metin: [{0}]\n\n", metinKutu.Text));
                sb.Append (String.Format ("{0}.krk'den ba�layarak {1} adet krk se�ilmi�tir.\n", metinKutu.SelectionStart, metinKutu.SelectionLength));
                sb.Append (String.Format ("Se�ilen metin: [{0}]", metinKutu.SelectedText));
                MessageBox.Show (sb.ToString());
            }
        }
    }
    partial class Form6 {
        private TextBox metinKutu;
        private Button d��me6a;
        private Button d��me6b;
        private void Bile�eniBa�lat() {
            metinKutu = new TextBox();
            d��me6a = new Button();
            d��me6b = new Button();
            SuspendLayout();
            // metinKutu
            metinKutu.Location = new Point (12, 12);
            metinKutu.Multiline = true;
            metinKutu.ScrollBars = ScrollBars.Vertical;
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (268, 213);
            metinKutu.TabIndex = 0;
            metinKutu.BackColor=Color.Navy;
            metinKutu.ForeColor=Color.Yellow;
            // d��me6a
            d��me6a.Location = new Point (185, 231);
            d��me6a.Name = "d��me6a";
            d��me6a.Size = new Size (95, 23);
            d��me6a.TabIndex = 1;
            d��me6a.Text = "Sat�rlar� G�ster";
            d��me6a.BackColor=Color.MediumBlue;
            d��me6a.Click += new EventHandler (d��me6a_T�kland�);
            // d��me6b
            d��me6b.Location = new Point (75, 231);
            d��me6b.Name = "d��me6b";
            d��me6b.Size = new Size (95, 23);
            d��me6b.TabIndex = 2;
            d��me6b.Text = "Se�ileni G�ster";
            d��me6b.BackColor=Color.DodgerBlue;
            d��me6b.Click += new EventHandler (d��me6b_T�kland�);
            // Form6
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (d��me6a);
            Controls.Add (d��me6b);
            Controls.Add (metinKutu);
            Name = "Form6";
            Text = "Form6: Metinkutuyu Mesajkutuda Sunma";
            BackColor=Color.MidnightBlue;
            ForeColor=Color.Orange;
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public partial class Form7: Form {
        public Form7() {Bile�eniBa�lat();} //Kurucu
        private void metinKutu_Ge�erliyor (object k, CancelEventArgs o) {
            try {
                int y�l = int.Parse (metinKutu.Text);
                if (y�l < 1881 || y�l > 1938) {
                    o.Cancel = true;
                    MessageBox.Show ("[1881, 1938] aras� bir y�l girmelisiniz.");
                }
            }catch (Exception hata) {
                o.Cancel = true;
                MessageBox.Show ("HATA: [" + hata.Message + "]");
            }
        }
        private void metinKutu_Ge�erledi (object k, EventArgs o) {MessageBox.Show ("Pekala, ge�erli bir y�l girdiniz.");}
        private void d��me_T�kland� (object k, EventArgs o) {Close();}
    }
    partial class Form7 {
        private TextBox metinKutu;
        private Label fi�;
        private Button d��me;
        private MaskedTextBox maskeliMetinKutu;
        private void Bile�eniBa�lat() {
            metinKutu = new TextBox();
            fi� = new Label();
            d��me = new Button();
            maskeliMetinKutu = new MaskedTextBox();
            SuspendLayout();
            // fi�
            fi�.AutoSize = true;
            fi�.Location = new Point (16, 18);
            fi�.Margin = new Padding (4, 0, 4, 0);
            fi�.Name = "fi�";
            fi�.Size = new Size (201, 16);
            fi�.TabIndex = 1;
            fi�.Text = "1881 ve 1938 aras� bir y�l gir:";
            // metinKutu
            metinKutu.Location = new Point (243, 15);
            metinKutu.Margin = new Padding (4, 4, 4, 4);
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (57, 22);
            metinKutu.TabIndex = 0;
            metinKutu.BackColor=Color.LightCyan;
            metinKutu.Validating += new CancelEventHandler (metinKutu_Ge�erliyor);
            metinKutu.Validated += new EventHandler (metinKutu_Ge�erledi);
            // d��me
            d��me.Location = new Point (335, 11);
            d��me.Margin = new Padding (4, 4, 4, 4);
            d��me.Name = "d��me";
            d��me.Size = new Size (100, 28);
            d��me.TabIndex = 2;
            d��me.Text = "TAMAM";
            d��me.BackColor=Color.DarkSlateGray;
            d��me.Click += new EventHandler (d��me_T�kland�);
            // maskeliMetinKutu
            maskeliMetinKutu.Location = new Point (100, 200);
            maskeliMetinKutu.Name = "maskeliMetinKutu";
            maskeliMetinKutu.Text = "Ge�erli y�l gir, OK-->Mesaj, OK-->�IK";
            maskeliMetinKutu.Size = new Size (250, 23);
            maskeliMetinKutu.TabIndex = 3;
            maskeliMetinKutu.BackColor=Color.LightBlue;
            //maskeliMetinKutu.Enabled=false;
            // Form7
            AutoScaleDimensions = new SizeF (8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (453, 246);
            Controls.Add (fi�);
            Controls.Add (metinKutu);
            Controls.Add (d��me);
            Controls.Add (maskeliMetinKutu);
            Margin = new Padding (4, 4, 4, 4);
            Name = "Form7";
            Text = "Form7: Metinkutuya 1881-->1938 Y�l Girme";
            BackColor=Color.DarkSlateGray;
            ForeColor=Color.Tomato;
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public class Form8: Form {
        private MainMenu anaMen�;
        private MenuItem men�Birim8a;
        private MenuItem men�Birim8b;
        private MenuItem men�Birim8c;
        private MenuItem men�Birim8d;
        private MenuItem men�Birim8e;
        private MenuItem men�Birim8f;
        private MenuItem men�Birim8g;
        private MenuItem men�Birim8h;
        private TextBox metinKutu;
        //private IContainer kap = null;
        public Form8() {//Kurucu
            Bile�eniBa�lat();
            ContextMenu men�Kap = new ContextMenu();
            foreach (MenuItem men�Birim in men�Birim8a.MenuItems) {men�Kap.MenuItems.Add (men�Birim.CloneMenu());}
            foreach (MenuItem men�Birim in men�Birim8e.MenuItems) {men�Kap.MenuItems.Add (men�Birim.CloneMenu());}
            metinKutu.ContextMenu = men�Kap;
        }
        private void Bile�eniBa�lat() {
            //kap = new Container();
            anaMen� = new MainMenu (/*kap*/);
            men�Birim8a = new MenuItem();
            men�Birim8b = new MenuItem();
            men�Birim8c = new MenuItem();
            men�Birim8d = new MenuItem();
            men�Birim8e = new MenuItem();
            men�Birim8f = new MenuItem();
            men�Birim8g = new MenuItem();
            men�Birim8h = new MenuItem();
            metinKutu = new TextBox();
            SuspendLayout();
            // anaMen�
            anaMen�.MenuItems.AddRange (new MenuItem[] {men�Birim8a, men�Birim8e});
            // men�Birim8a
            men�Birim8a.Index = 0;
            men�Birim8a.MenuItems.AddRange (new MenuItem[] {men�Birim8b, men�Birim8c, men�Birim8d});
            men�Birim8a.Text = "Dosya";
            // men�Birim8b
            men�Birim8b.Index = 0;
            men�Birim8b.Text = "A�";
            men�Birim8b.Click += new EventHandler (men�Birim8b_T�kland�);
            // men�Birim8c
            men�Birim8c.Index = 1;
            men�Birim8c.Text = "Sakla";
            men�Birim8c.Click += new EventHandler (men�Birim8c_T�kland�);
            // men�Birim8d
            men�Birim8d.Index = 2;
            men�Birim8d.Text = "��k";
            men�Birim8d.Click += new EventHandler (men�Birim8d_T�kland�);
            // men�Birim8e
            men�Birim8e.Index = 1;
            men�Birim8e.MenuItems.AddRange (new MenuItem[] {men�Birim8f, men�Birim8g, men�Birim8h});
            men�Birim8e.Text = "D�zenle";
            // men�Birim8f
            men�Birim8f.Index = 0;
            men�Birim8f.Text = "Kes";
            men�Birim8f.Click += new EventHandler (men�Birim8f_T�kland�);
            // men�Birim8g
            men�Birim8g.Index = 1;
            men�Birim8g.Text = "Kopyala";
            men�Birim8g.Click += new EventHandler (men�Birim8g_T�kland�);
            // men�Birim8h
            men�Birim8h.Index = 2;
            men�Birim8h.Text = "Yap��t�r";
            men�Birim8h.Click += new EventHandler (men�Birim8h_T�kland�);
            // metinKutu
            metinKutu.Location = new Point (44, 56);
            metinKutu.Multiline = true;
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (180, 88);
            metinKutu.TabIndex = 1;
            metinKutu.BackColor=Color.Khaki;
            metinKutu.ForeColor=Color.Blue;
            metinKutu.Text = "Dosya men� birimlerini g�rmek i�in sa�, D�zenle men� birimleri i�in �ift t�kla.";
            metinKutu.MouseDown += new MouseEventHandler (metinKutu_FareSa�);
            // Form8
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (metinKutu);
            Menu = anaMen�;
            Text = "Form8: Metinkutu ve Men�ler";
            BackColor=Color.Peru;
            ResumeLayout (false);
            PerformLayout();
        }
        private void metinKutu_FareSa� (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Right) {metinKutu.ContextMenu.Show (metinKutu, new Point (o.X, o.Y));}
        }
        private void men�Birim8b_T�kland� (object k, EventArgs o) {MessageBox.Show ("Dosya-->A�");}
        private void men�Birim8c_T�kland� (object k, EventArgs o) {MessageBox.Show ("Dosya-->Sakla");}
        private void men�Birim8d_T�kland� (object k, EventArgs o) {MessageBox.Show ("Dosya-->��k");}
        private void men�Birim8f_T�kland� (object k, EventArgs o) {MessageBox.Show ("D�zenle-->Kes");}
        private void men�Birim8g_T�kland� (object k, EventArgs o) {MessageBox.Show ("D�zenle-->Kopyala");}
        private void men�Birim8h_T�kland� (object k, EventArgs o) {MessageBox.Show ("D�zenle-->Yap��t�r");}
    }
    public class Form9: Form {
        private Button d��me;
        private ErrorProvider hataTeminci;
        private Label etiket;
        private TextBox metinKutu;
        //private IContainer kab = null;
        public Form9() {//Kurucu
            //kab = new Container();
            d��me = new Button();
            hataTeminci = new ErrorProvider (/*kab*/);
            etiket = new Label();
            metinKutu = new TextBox();
            ((ISupportInitialize)(hataTeminci)).BeginInit();
            SuspendLayout();
            //d��me
            d��me.Location = new Point (212, 80);
            d��me.Name = "d��me";
            d��me.Size = new Size (76, 24);
            d��me.TabIndex = 12;
            d��me.Text = "TAMAM";
            d��me.Click += new EventHandler (d��me_T�kland�);
            //hataTeminci
            hataTeminci.ContainerControl = this;
            hataTeminci.DataMember = "";
            //etiket
            etiket.Location = new Point (24, 24);
            etiket.Size = new Size (42, 16);
            etiket.Text = "Eposta:";
            //metinKutu
            metinKutu.Location = new Point (70, 20);
            metinKutu.Size = new Size(220, 21);
            metinKutu.BackColor=Color.Sienna;
            metinKutu.ForeColor=Color.Lime;
            metinKutu.Leave += new EventHandler (metinKutu_Terk);
            //this
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (328, 126);
            Controls.Add (etiket);
            Controls.Add (metinKutu);
            Controls.Add (d��me);
            Text = "Form9: Epostan�n Regex Kontrolu";
            BackColor=Color.Purple;
            ForeColor=Color.Pink;
            Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ((ISupportInitialize)(hataTeminci)).EndInit();
            ResumeLayout (false);
            PerformLayout();
        }
        private void metinKutu_Terk (object k, EventArgs o) {
            Regex d�zif;
            d�zif = new Regex (@"^[\w-]+@([\w-]+\.)+[\w-]+$");
            Control kontrol = (Control)k;
            if (kontrol.Text == "") {MessageBox.Show ("Bu bo� bir epostad�r.");
            }else if (d�zif.IsMatch (kontrol.Text)) {
                hataTeminci.SetError (kontrol, "");
                MessageBox.Show ("Bu ge�erli bir epostad�r.");
            }else {hataTeminci.SetError (kontrol, "Bu ge�erli bir eposta de�il.");}
        }
        private void d��me_T�kland� (object k, EventArgs o) {
            string hatalar = "";
            foreach (Control kontrol in Controls) {
                if (hataTeminci.GetError (kontrol) != "") {hatalar += "   * " + hataTeminci.GetError (kontrol) + "\n";}
                MessageBox.Show ("HATALAR:" + hatalar, "Ge�ersiz Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    public class Form10: Form {
        private Container kab = null;
        private Label fi�10a;
        private TextBox metinKutu10a;
        private Button d��me10a;
        private Label fi�10b;
        private TextBox metinKutu10b;
        private Label fi�10c;
        private TextBox metinKutu10c;
        private Button d��me10c;
        public Form10() {//Kurucu
            Bile�eniBa�lat();
            CenterToScreen();
        }
        protected override void Dispose (bool ��peMi) {
            if(��peMi) if(kab != null) kab.Dispose();
            base.Dispose (��peMi);
        }
        private void Bile�eniBa�lat() {
            fi�10a = new Label();
            fi�10b = new Label();
            fi�10c = new Label();
            metinKutu10a = new TextBox();
            metinKutu10b = new TextBox();
            metinKutu10c = new TextBox();
            d��me10a = new Button();
            d��me10c = new Button();
            SuspendLayout();
            // fi�10a
            fi�10a.Font = new Font ("Microsoft Sans Serif", 10F);
            fi�10a.Location = new Point (8, 8);
            fi�10a.Name = "fi�10a";
            fi�10a.Size = new Size (136, 56);
            fi�10a.TabIndex = 1;
            fi�10a.Text = "Sekme ve Gir tu�lar�n� kabul eden �oksat�rl� metinkutu";
            fi�10a.BackColor=Color.Sienna;
            fi�10a.ForeColor=Color.Orchid;
            // metinKutu10a
            metinKutu10a.AcceptsReturn = true;
            metinKutu10a.AcceptsTab = true;
            metinKutu10a.Multiline = true;
            metinKutu10a.Location = new Point (152, 8);
            metinKutu10a.Name = "metinKutu10a";
            metinKutu10a.ScrollBars = ScrollBars.Vertical;
            metinKutu10a.Size = new Size (240, 104);
            metinKutu10a.TabIndex = 0;
            metinKutu10a.Text = "Metin girin (Sekme ve Gir tu�lar� da dahil...)";
            metinKutu10a.BackColor=Color.OldLace;
            metinKutu10a.ForeColor=Color.Magenta;
            // d��me10a
            d��me10a.Location = new Point (13, 72);
            d��me10a.Name = "d��me10a";
            d��me10a.Size = new Size (120, 32);
            d��me10a.TabIndex = 2;
            d��me10a.Text = "Metni Al";
            d��me10a.BackColor=Color.Red;
            d��me10a.ForeColor=Color.Yellow;
            d��me10a.Click += new EventHandler (d��me10a_T�kland�);
            // fi�10b
            fi�10b.Font = new Font ("Comic Sans MS", 12F);
            fi�10b.Location = new Point (14, 144);
            fi�10b.Name = "fi�10b";
            fi�10b.Size = new Size (120, 24);
            fi�10b.TabIndex = 4;
            fi�10b.Text = "B�y�kharfli";
            fi�10b.BackColor=Color.Sienna;
            fi�10b.ForeColor=Color.Orchid;
            // metinKutu10b
            metinKutu10b.CharacterCasing = CharacterCasing.Upper;
            metinKutu10b.Location = new Point (14, 176);
            metinKutu10b.Name = "metinKutu10b";
            metinKutu10b.Size = new Size (120, 20);
            metinKutu10b.TabIndex = 3;
            metinKutu10b.Text = "";
            metinKutu10b.BackColor=Color.OldLace;
            metinKutu10b.ForeColor=Color.Magenta;
            // fi�10c
            fi�10c.Font = new Font ("Comic Sans MS", 12F);
            fi�10c.Location = new Point (160, 136);
            fi�10c.Name = "fi�10c";
            fi�10c.Size = new Size (120, 24);
            fi�10c.TabIndex = 6;
            fi�10c.Text = "�ifre gir";
            fi�10c.BackColor=Color.Sienna;
            fi�10c.ForeColor=Color.Orchid;
            // metinKutu10c
            metinKutu10c.Location = new Point (160, 176);
            metinKutu10c.Name = "metinKutu10c";
            metinKutu10c.PasswordChar = '*';
            metinKutu10c.Size = new Size (232, 20);
            metinKutu10c.TabIndex = 5;
            metinKutu10c.Text = "mnyavas33mersin";
            metinKutu10c.BackColor=Color.OldLace;
            metinKutu10c.ForeColor=Color.Magenta;
            // d��me10c
            d��me10c.Location = new Point (280, 144);
            d��me10c.Name = "d��me10c";
            d��me10c.Size = new Size (112, 24);
            d��me10c.TabIndex = 7;
            d��me10c.Text = "�ifreyi ��z";
            d��me10c.BackColor=Color.Red;
            d��me10c.ForeColor=Color.Yellow;
            d��me10c.Click += new EventHandler (d��me10c_T�kland�);
            // Form10
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (408, 221);
            Controls.AddRange (new Control[] {fi�10a, fi�10b, fi�10c, metinKutu10a, metinKutu10b, metinKutu10c, d��me10a, d��me10c});
            Name = "Form10";
            Text = "Form10: Metinkutu Tipleri";
            BackColor=Color.Purple;
            ForeColor=Color.Pink;
            ResumeLayout (false);
        }
        protected void d��me10a_T�kland� (object k, EventArgs o) {MessageBox.Show (metinKutu10a.Text, "Tam metnin: ");}
        protected void d��me10c_T�kland� (object k, EventArgs o) {MessageBox.Show (metinKutu10c.Text, "�ifrenin ��z�m�: ");}
    }
    class Masked_TextBox1 {
        [STAThread]
        static void Main() {
            Console.Write ("Metinkutu �e�itleri ve maskeli metinkutu.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("A�a��sarkan tarakl�kutu birimlerini se�me, ekleme, silme, de�i�tirme:");
            Application.EnableVisualStyles();
            int ts=0;
       ba�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Form1 MetinKutuya ad gir");
            Console.WriteLine ("2: Form2 �oklu metinkutu ge�erleme");
            Console.WriteLine ("3: Form3 �oklusat�r metinkutu mesaj�");
            Console.WriteLine ("4: Form4 De�i�en metinkutu mesaj�");
            Console.WriteLine ("5: Form5 ISBN no ge�erleme");
            Console.WriteLine ("6: Form6 Metinkutuyu/se�ileni mesajkutuda sunma");
            Console.WriteLine ("7: Form7 Ge�erli y�l giri�i");
            Console.WriteLine ("8: Form8 Men�ler ve metinkutusu");
            Console.WriteLine ("9: Form9 Eposta hata kontrolu");
            Console.WriteLine ("10: Form10 �� tip metinkutusu");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto ba�;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 10) goto ba�;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Metinkutuya ad gir, d��meyi t�kla, mesajkutuyu ve dos pencereye bak
                case 2: Application.Run (new Form2()); break; //�oklu metinkutularda bo�, rakam, ReadOnly ge�erlemeler
                case 3: Application.Run (new Form3()); break; //Metinkutusuna �oklusat�rl� (dikey kayd�ra�l�) veri giri�i
                case 4: Application.Run (new Form4()); break; //Metinkutusundaki her krk de�i�ikli�in mesajlanmas�
                case 5: Application.Run (new Form5()); break; //Rakam, x, -, gerSil, Enter tu�lar�n kabul�
                case 6: Application.Run (new Form6()); break; //Metinkutuya girilen �oklusat�rlar veya se�ilenler t�klan�nca mesajkutuyla sunulur
                case 7: Application.Run (new Form7()); break; //[1881, 1938] y�l gir, OK-->Mesaj ge�erliyse OK-->��k
                case 8: Application.Run (new Form8()); break; //Metinkutu sa�t�kla ve men�birimleri t�klama mesajlar�
                case 9: Application.Run (new Form9()); break; //Girilen epostaya "!" sinyalli "ge�ersiz" demiyorsa ge�erlidir
                case 10: Application.Run (new Form10()); break; //�oklusat�r, b�y�kharfli ve �ifreli metinkutular�
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto ba�;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}