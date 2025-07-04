// j2sc#2302e.cs: Metinkutu çeþitleri ve maskeli metinkutusu-1 örneði.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.Collections; //ArrayList için
using System.ComponentModel; //CancelEventHandler
using System.Text; //StringBuilder için
using System.Text.RegularExpressions; //Regex için
namespace Bileþenler {
    class Form1: Form {
        private Label fiþ;
        private TextBox metinKutu;
        private Button düðme;
        public Form1() {//Kurucu
            fiþ = new Label();
            metinKutu = new TextBox();
            düðme = new Button();
            SuspendLayout();
            //fiþ
            fiþ.Location = new Point (16, 36);
            //fiþ.Name = "fiþ";
            fiþ.Size = new Size (128, 16);
            //fiþ.TabIndex = 0;
            fiþ.Text = "Lütfen adýnýzý girin:";
            fiþ.BackColor=Color.SlateBlue;
            //metinKutu
            metinKutu.Location = new Point (152, 32);
            metinKutu.Name = "metinKutu";
            metinKutu.TabIndex = 1;
            metinKutu.Text = "";
            metinKutu.BackColor=Color.Cyan;
            //düðme
            düðme.Location = new Point (109, 80);
            //düðme.Name = "düðme";
            //düðme.TabIndex = 2;
            düðme.Text = "Týkla";
            düðme.BackColor=Color.SteelBlue;
            düðme.Click += new EventHandler (düðme_Týklandý);
            //this
            ClientSize = new Size (292, 126);
            Controls.Add (düðme);
            Controls.Add (metinKutu);
            Controls.Add (fiþ);
            Name = "form1";
            Text = "Form1: MetinKutu Veri Giriþi";
            BackColor=Color.Tan;
            ForeColor=Color.DeepPink;
            ResumeLayout (false);    
        }
        private void düðme_Týklandý (object k, EventArgs o) {
            Console.WriteLine ("Ad: {0}", metinKutu.Text);
            MessageBox.Show ("Merhaba: " + metinKutu.Text);
        }
    }
    class Form2: Form {
        private Label fiþ2a;
        private Label fiþ2b;
        private Label fiþ2c;
        private Label fiþ2d;
        private TextBox metinKutu2a;
        private TextBox metinKutu2b;
        private TextBox metinKutu2c;
        private TextBox metinKutu2d;
        private Button düðme2a;
        private Button düðme2b;
        private GroupBox grupKutu;
        private RadioButton radyoDüðme2a;
        private RadioButton radyoDüðme2b;
        private CheckBox çentikKutu;
        public Form2() {//Kurucu
            BileþeniBaþlat();
            düðme2a.Enabled = false;
            metinKutu2a.Tag = false;
            metinKutu2b.Tag = false;
            metinKutu2c.Tag = false;
            metinKutu2a.Validating += new CancelEventHandler (boþMetinKutu_Geçerliyor);
            metinKutu2b.Validating += new CancelEventHandler (boþMetinKutu_Geçerliyor);
            metinKutu2c.Validating += new CancelEventHandler (boþMetinKutu_Geçerliyor);
            metinKutu2a.TextChanged += new EventHandler (metinKutu_MetinDeðiþti);
            metinKutu2b.TextChanged += new EventHandler (metinKutu_MetinDeðiþti);
            metinKutu2c.TextChanged += new EventHandler (metinKutu_MetinDeðiþti);
        }
        private void boþMetinKutu_Geçerliyor (object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            if (mk.Text.Length == 0) {
                mk.BackColor = Color.Red;
                mk.Tag = false;
            }else {
                mk.BackColor = SystemColors.Window;
                mk.Tag = true;
            }
            GeçerlemeTamam();
        }
        private void metinKutu_MetinDeðiþti (object k, EventArgs o) {
            TextBox mk = (TextBox)k;
            if (mk.Text.Length == 0) {
                mk.Tag = false;
                mk.BackColor = Color.Red;
            }else {
                mk.Tag = true;
                mk.BackColor = SystemColors.Window;
            }
            GeçerlemeTamam();
        }
        private void GeçerlemeTamam() {düðme2a.Enabled = ((bool)(metinKutu2b.Tag) && (bool)(metinKutu2c.Tag) && (bool)(metinKutu2a.Tag));}
        private void düðme2a_Týklandý (object k, EventArgs o) {metinKutu2d.Text = "Tamam düðmesi\r\nTIKLANDI";}
        private void düðme2b_Týklandý (object k, EventArgs o) {metinKutu2d.Text = "Fatma Yavaþ\r\nBekir Yavaþ\r\nHaným Yavaþ\r\nMemet Yavaþ\\Hatice Yavaþ Kaçar\r\nSüheyla Y.Özbay\r\nZeliha Y.Candan\r\nM.Nihat Yavaþ\r\nSongül Y.Göktürk\r\nM.Nedim Yavaþ\r\nSevim Yavaþ";}
        private void metinKutu2c_TuþBasýldý (object k, KeyPressEventArgs o) {if ((o.KeyChar < 48 || o.KeyChar > 57) && o.KeyChar != 8) {o.Handled = true; o.KeyChar=' ';}} //Sayýsal dýþý girilenin iptali
        private void BileþeniBaþlat() {
            fiþ2a = new Label();
            fiþ2b = new Label();
            fiþ2c = new Label();
            fiþ2d = new Label();
            metinKutu2a = new TextBox();
            metinKutu2b = new TextBox();
            metinKutu2c = new TextBox();
            metinKutu2d = new TextBox();
            düðme2a = new Button();
            düðme2b = new Button();
            grupKutu = new GroupBox();
            radyoDüðme2b = new RadioButton();
            radyoDüðme2a = new RadioButton();
            çentikKutu = new CheckBox();
            SuspendLayout();
            grupKutu.SuspendLayout();
            //fiþ2a
            //fiþ2a.AutoSize = true;
            fiþ2a.Location = new Point (13, 16);
            //fiþ2a.Name = "fiþ2a";
            fiþ2a.Size = new Size (50, 14);
            //fiþ2a.TabIndex = 0;
            fiþ2a.Text = "Ýsim gir";
            //metinKutu2a
            metinKutu2a.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            metinKutu2a.Location = new Point (106, 13);
            //metinKutu2a.Name = "metinKutu2a";
            metinKutu2a.Size = new Size (225, 20);
            metinKutu2a.TabIndex = 2;
            metinKutu2a.BackColor=Color.Wheat;
            //düðme2a
            düðme2a.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            düðme2a.Location = new Point (338, 13);
            //düðme2a.Name = "düðme2a";
            düðme2a.TabIndex = 8;
            düðme2a.Text = "Tamam";
            düðme2a.Click += new EventHandler (düðme2a_Týklandý);
            //fiþ2b
            //fiþ2b.AutoSize = true;
            fiþ2b.Location = new Point (13, 43);
            //fiþ2b.Name = "fiþ2b";
            fiþ2b.Size = new Size (50, 14);
            //fiþ2b.TabIndex = 1;
            fiþ2b.Text = "Adres gir";
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
            //düðme2b
            düðme2b.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            düðme2b.CausesValidation = false;
            düðme2b.Location = new Point (338, 43);
            //düðme2b.Name = "düðme2b";
            //düðme2b.TabIndex = 9;
            düðme2b.Text = "Yardým";
            düðme2b.Click += new EventHandler (düðme2b_Týklandý);
            //çentikKutu
            //çentikKutu.AutoSize = true;
            çentikKutu.Checked = true;
            çentikKutu.CheckState = CheckState.Checked;
            çentikKutu.Location = new Point (13, 128);
            //çentikKutu.Name = "çentikKutu";
            çentikKutu.Size = new Size (78, 17);
            çentikKutu.TabIndex = 13;
            çentikKutu.Text = "Programcý";
            //grupKutu
            grupKutu.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            grupKutu.Controls.Add (radyoDüðme2a);
            grupKutu.Controls.Add (radyoDüðme2b);
            grupKutu.Location = new Point (13, 152);
            //grupKutu.Name = "grupKutu";
            grupKutu.Size = new Size (318, 50);
            //grupKutu.TabIndex = 12;
            //grupKutu.TabStop = false;
            grupKutu.Text = "Cinsiyet";
            //radyoDüðme2a
            //radyoDüðme2a.AutoSize = true;
            radyoDüðme2a.Checked = true;
            radyoDüðme2a.Location = new Point (44, 20);
            //radyoDüðme2a.Name = "radyoDüðme2a";
            radyoDüðme2a.Size = new Size (55, 17);
            radyoDüðme2a.TabIndex = 0;
            radyoDüðme2a.Text = "Kadýn";
            //radyoDüðme2a
            //radyoDüðme2b.AutoSize = true;
            radyoDüðme2b.Location = new Point (182, 20);
            //radyoDüðme2b.Name = "radyoDüðme2b";
            radyoDüðme2b.Size = new Size (55, 17);
            radyoDüðme2b.TabIndex = 1;
            radyoDüðme2b.Text = "Erkek";
            //fiþ2c
            fiþ2c.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //fiþ2c.AutoSize = true;
            fiþ2c.Location = new Point (13, 212);
            //fiþ2c.Name = "fiþ2c";
            fiþ2c.Size = new Size (50, 14);
            fiþ2c.TabIndex = 10;
            fiþ2c.Text = "Yaþ gir";
            //metinKutu2c
            metinKutu2c.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            metinKutu2c.Location = new Point (106, 209);
            metinKutu2c.MaxLength = 3;
            //metinKutu2c.Name = "metinKutu2c";
            metinKutu2c.TabIndex = 11;
            metinKutu2c.BackColor=Color.Wheat;
            metinKutu2c.KeyPress += new KeyPressEventHandler (metinKutu2c_TuþBasýldý);
            //fiþ2d
            fiþ2d.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            //fiþ2d.AutoSize = true;
            fiþ2d.Location = new Point (13, 233);
            //fiþ2d.Name = "fiþ2d";
            fiþ2d.Size = new Size (50, 14);
            //fiþ2d.TabIndex = 6;
            fiþ2d.Text = "Çýktý:";
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
            Controls.AddRange (new Control[] {fiþ2a, fiþ2b, fiþ2c, fiþ2d, metinKutu2a, metinKutu2b, metinKutu2c, metinKutu2d, düðme2a, düðme2b, çentikKutu, grupKutu});
            //MinimumSize = new Size (430, 328);
            Text = "Form2: Geçerlilemeli MetinKutular";
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
        string öncekiDizge;
        public Form3() {//Kurucu
            Text = "Form3: Çoklusatýr Metinkutu Dizgesi";
            BackColor=Color.Sienna;
            ForeColor=Color.Purple;
            Size = new Size (300, 375);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Text = "M.Nihat Yavaþ";
            metinKutu.Size = new Size (ClientSize.Width - 20, ClientSize.Height - 100);
            metinKutu.Location = new Point (10, 10);
            metinKutu.Multiline = true;
            metinKutu.BorderStyle = BorderStyle.Fixed3D;
            metinKutu.ScrollBars = ScrollBars.Vertical;
            metinKutu.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            metinKutu.BackColor=Color.Pink;
            öncekiDizge = metinKutu.Text;
        }
    }
    public class Form4: Form {
        TextBox metinKutu;
        string öncekiDizge;
        public Form4() {//Kurucu
            Text = "Form3: Deðiþen Metinkutu Dizgesi";
            BackColor=Color.Sienna;
            ForeColor=Color.Purple;
            Size = new Size (300, 375);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Text = "M.Nihat Yavaþ";
            metinKutu.Size = new Size (ClientSize.Width - 20, ClientSize.Height - 100);
            metinKutu.Location = new Point (10, 10);
            metinKutu.TextChanged += new EventHandler (metinKutu_MetinDeðiþti);
            metinKutu.Multiline = true;
            metinKutu.BorderStyle = BorderStyle.Fixed3D;
            metinKutu.ScrollBars = ScrollBars.Vertical;
            metinKutu.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            metinKutu.BackColor=Color.Pink;
            öncekiDizge = metinKutu.Text;
        }
        private void metinKutu_MetinDeðiþti (object k, EventArgs o) {
            if (öncekiDizge == metinKutu.Text) metinKutu.Modified = false;
            else metinKutu.Modified = true;
            if (metinKutu.Modified) MessageBox.Show ("Metin DEÐÝÞTÝ");
            //else MessageBox.Show ("Metin DEÐÝÞMEDÝ");
        }
    }
    public class Form5: Form {
        private Label fiþ5a;
        private TextBox metinKutu;
        private Label fiþ5b;
        private Label fiþ5bb;
        private Label fiþ5c;
        private Label fiþ5cc;
        private Label fiþ5d;
        public Form5() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            fiþ5a = new Label();
            metinKutu = new TextBox();
            fiþ5b = new Label();
            fiþ5bb = new Label();
            fiþ5c = new Label();
            fiþ5cc = new Label();
            fiþ5d = new Label();
            SuspendLayout();
            // fiþ5a
            fiþ5a.Font = new Font ("Tahoma", 14.25F, (FontStyle.Bold | FontStyle.Italic), GraphicsUnit.Point, ((System.Byte)(0)));
            fiþ5a.Location = new Point (48, 16);
            fiþ5a.Name = "fiþ5a";
            fiþ5a.Size = new Size (176, 23);
            fiþ5a.TabIndex = 0;
            fiþ5a.Text = "ISBN Geçerleme";
            // metinKutu
            metinKutu.Location = new Point (72, 64);
            metinKutu.Name = "metinKutu";
            metinKutu.TabIndex = 1;
            metinKutu.Text = "0551-5559464";
            metinKutu.BackColor=Color.Plum;
            metinKutu.KeyPress += new KeyPressEventHandler (metinKutu_TuþBasýldý);
            metinKutu.Validating += new CancelEventHandler (pencereyiKapatYönet);
            // fiþ5b
            fiþ5b.Location = new Point (24, 104);
            fiþ5b.Name = "fiþ5b";
            fiþ5b.Size = new Size (80, 23);
            fiþ5b.TabIndex = 2;
            fiþ5b.Text = "Doðru Sayý:";
            // fiþ5bb
            fiþ5bb.BorderStyle = BorderStyle.Fixed3D;
            fiþ5bb.Location = new Point (112, 104);
            fiþ5bb.Name = "fiþ5bb";
            fiþ5bb.TabIndex = 3;
            fiþ5bb.BackColor=Color.SeaGreen;
            // fiþ5c
            fiþ5c.Location = new Point (32, 152);
            fiþ5c.Name = "fiþ5c";
            fiþ5c.Size = new Size (80, 23);
            fiþ5c.TabIndex = 4;
            fiþ5c.Text = "Kontrol Rakam:";
            // fiþ5cc
            fiþ5cc.BorderStyle = BorderStyle.Fixed3D;
            fiþ5cc.Location = new Point (112, 152);
            fiþ5cc.Name = "fiþ5cc";
            fiþ5cc.TabIndex = 5;
            fiþ5cc.BackColor=Color.SeaGreen;
            // fiþ5d
            fiþ5d.Location = new Point (56, 212);
            fiþ5d.Name = "fiþ5d";
            fiþ5d.Size = new Size (152, 24);
            fiþ5d.TabIndex = 8;
            // Form5
            Text = "Form5: Doðru ISBN Giriþi";
            BackColor=Color.Purple;
            ForeColor=Color.Orange;
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (264, 293);
            Controls.AddRange (new Control[] {fiþ5a, metinKutu, fiþ5b, fiþ5bb, fiþ5c, fiþ5cc, fiþ5d});
            ResumeLayout (false);
        }
        private void metinKutu_TuþBasýldý (object k, KeyPressEventArgs o) {
            char tuþKrk;
            tuþKrk = o.KeyChar;
            if (!Char.IsDigit (tuþKrk)      // 0 - 9
                && tuþKrk != 8             // backspace
                && tuþKrk != 13            // enter
                && tuþKrk != 'x'
                && tuþKrk != 45             //  dash/minus/-
            ) o.Handled = true;
        }
        private void pencereyiKapatYönet (object k, CancelEventArgs o) {
            TextBox mk = (TextBox)k;
            string dizge = mk.Text;
            Console.WriteLine (dizge); //DOS pencere
            fiþ5bb.Text = dizge;       //Sayý
            fiþ5cc.Text = dizge;       //Rakam
            fiþ5d.Text = "ISBN: " + dizge; //Sonuç
            MessageBox.Show ("Geçerli ISBN: " + dizge); //Mesajkutusu
        }
    }
    public partial class Form6: Form {
        public Form6() {BileþeniBaþlat();} //Kurucu
        private void düðme6a_Týklandý (object k, EventArgs o) {
            StringBuilder sb = new StringBuilder();
            sb.Append ("Metinkutuda toplam " + metinKutu.Lines.Length.ToString() + " satýr var:\n\n");
            foreach (string str in metinKutu.Lines) {sb.Append (str + "\n");}
            MessageBox.Show (sb.ToString());
        }
        private void düðme6b_Týklandý (object k, EventArgs o) {
            if (metinKutu.SelectionLength == 0) {MessageBox.Show ("Öncelikle metinkutudan seçilen olmalýdýr.");
            }else {
                StringBuilder sb = new StringBuilder();
                sb.Append (String.Format ("Tüm metin: [{0}]\n\n", metinKutu.Text));
                sb.Append (String.Format ("{0}.krk'den baþlayarak {1} adet krk seçilmiþtir.\n", metinKutu.SelectionStart, metinKutu.SelectionLength));
                sb.Append (String.Format ("Seçilen metin: [{0}]", metinKutu.SelectedText));
                MessageBox.Show (sb.ToString());
            }
        }
    }
    partial class Form6 {
        private TextBox metinKutu;
        private Button düðme6a;
        private Button düðme6b;
        private void BileþeniBaþlat() {
            metinKutu = new TextBox();
            düðme6a = new Button();
            düðme6b = new Button();
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
            // düðme6a
            düðme6a.Location = new Point (185, 231);
            düðme6a.Name = "düðme6a";
            düðme6a.Size = new Size (95, 23);
            düðme6a.TabIndex = 1;
            düðme6a.Text = "Satýrlarý Göster";
            düðme6a.BackColor=Color.MediumBlue;
            düðme6a.Click += new EventHandler (düðme6a_Týklandý);
            // düðme6b
            düðme6b.Location = new Point (75, 231);
            düðme6b.Name = "düðme6b";
            düðme6b.Size = new Size (95, 23);
            düðme6b.TabIndex = 2;
            düðme6b.Text = "Seçileni Göster";
            düðme6b.BackColor=Color.DodgerBlue;
            düðme6b.Click += new EventHandler (düðme6b_Týklandý);
            // Form6
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (düðme6a);
            Controls.Add (düðme6b);
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
        public Form7() {BileþeniBaþlat();} //Kurucu
        private void metinKutu_Geçerliyor (object k, CancelEventArgs o) {
            try {
                int yýl = int.Parse (metinKutu.Text);
                if (yýl < 1881 || yýl > 1938) {
                    o.Cancel = true;
                    MessageBox.Show ("[1881, 1938] arasý bir yýl girmelisiniz.");
                }
            }catch (Exception hata) {
                o.Cancel = true;
                MessageBox.Show ("HATA: [" + hata.Message + "]");
            }
        }
        private void metinKutu_Geçerledi (object k, EventArgs o) {MessageBox.Show ("Pekala, geçerli bir yýl girdiniz.");}
        private void düðme_Týklandý (object k, EventArgs o) {Close();}
    }
    partial class Form7 {
        private TextBox metinKutu;
        private Label fiþ;
        private Button düðme;
        private MaskedTextBox maskeliMetinKutu;
        private void BileþeniBaþlat() {
            metinKutu = new TextBox();
            fiþ = new Label();
            düðme = new Button();
            maskeliMetinKutu = new MaskedTextBox();
            SuspendLayout();
            // fiþ
            fiþ.AutoSize = true;
            fiþ.Location = new Point (16, 18);
            fiþ.Margin = new Padding (4, 0, 4, 0);
            fiþ.Name = "fiþ";
            fiþ.Size = new Size (201, 16);
            fiþ.TabIndex = 1;
            fiþ.Text = "1881 ve 1938 arasý bir yýl gir:";
            // metinKutu
            metinKutu.Location = new Point (243, 15);
            metinKutu.Margin = new Padding (4, 4, 4, 4);
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (57, 22);
            metinKutu.TabIndex = 0;
            metinKutu.BackColor=Color.LightCyan;
            metinKutu.Validating += new CancelEventHandler (metinKutu_Geçerliyor);
            metinKutu.Validated += new EventHandler (metinKutu_Geçerledi);
            // düðme
            düðme.Location = new Point (335, 11);
            düðme.Margin = new Padding (4, 4, 4, 4);
            düðme.Name = "düðme";
            düðme.Size = new Size (100, 28);
            düðme.TabIndex = 2;
            düðme.Text = "TAMAM";
            düðme.BackColor=Color.DarkSlateGray;
            düðme.Click += new EventHandler (düðme_Týklandý);
            // maskeliMetinKutu
            maskeliMetinKutu.Location = new Point (100, 200);
            maskeliMetinKutu.Name = "maskeliMetinKutu";
            maskeliMetinKutu.Text = "Geçerli yýl gir, OK-->Mesaj, OK-->ÇIK";
            maskeliMetinKutu.Size = new Size (250, 23);
            maskeliMetinKutu.TabIndex = 3;
            maskeliMetinKutu.BackColor=Color.LightBlue;
            //maskeliMetinKutu.Enabled=false;
            // Form7
            AutoScaleDimensions = new SizeF (8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (453, 246);
            Controls.Add (fiþ);
            Controls.Add (metinKutu);
            Controls.Add (düðme);
            Controls.Add (maskeliMetinKutu);
            Margin = new Padding (4, 4, 4, 4);
            Name = "Form7";
            Text = "Form7: Metinkutuya 1881-->1938 Yýl Girme";
            BackColor=Color.DarkSlateGray;
            ForeColor=Color.Tomato;
            ResumeLayout (false);
            PerformLayout();
        }
    }
    public class Form8: Form {
        private MainMenu anaMenü;
        private MenuItem menüBirim8a;
        private MenuItem menüBirim8b;
        private MenuItem menüBirim8c;
        private MenuItem menüBirim8d;
        private MenuItem menüBirim8e;
        private MenuItem menüBirim8f;
        private MenuItem menüBirim8g;
        private MenuItem menüBirim8h;
        private TextBox metinKutu;
        //private IContainer kap = null;
        public Form8() {//Kurucu
            BileþeniBaþlat();
            ContextMenu menüKap = new ContextMenu();
            foreach (MenuItem menüBirim in menüBirim8a.MenuItems) {menüKap.MenuItems.Add (menüBirim.CloneMenu());}
            foreach (MenuItem menüBirim in menüBirim8e.MenuItems) {menüKap.MenuItems.Add (menüBirim.CloneMenu());}
            metinKutu.ContextMenu = menüKap;
        }
        private void BileþeniBaþlat() {
            //kap = new Container();
            anaMenü = new MainMenu (/*kap*/);
            menüBirim8a = new MenuItem();
            menüBirim8b = new MenuItem();
            menüBirim8c = new MenuItem();
            menüBirim8d = new MenuItem();
            menüBirim8e = new MenuItem();
            menüBirim8f = new MenuItem();
            menüBirim8g = new MenuItem();
            menüBirim8h = new MenuItem();
            metinKutu = new TextBox();
            SuspendLayout();
            // anaMenü
            anaMenü.MenuItems.AddRange (new MenuItem[] {menüBirim8a, menüBirim8e});
            // menüBirim8a
            menüBirim8a.Index = 0;
            menüBirim8a.MenuItems.AddRange (new MenuItem[] {menüBirim8b, menüBirim8c, menüBirim8d});
            menüBirim8a.Text = "Dosya";
            // menüBirim8b
            menüBirim8b.Index = 0;
            menüBirim8b.Text = "Aç";
            menüBirim8b.Click += new EventHandler (menüBirim8b_Týklandý);
            // menüBirim8c
            menüBirim8c.Index = 1;
            menüBirim8c.Text = "Sakla";
            menüBirim8c.Click += new EventHandler (menüBirim8c_Týklandý);
            // menüBirim8d
            menüBirim8d.Index = 2;
            menüBirim8d.Text = "Çýk";
            menüBirim8d.Click += new EventHandler (menüBirim8d_Týklandý);
            // menüBirim8e
            menüBirim8e.Index = 1;
            menüBirim8e.MenuItems.AddRange (new MenuItem[] {menüBirim8f, menüBirim8g, menüBirim8h});
            menüBirim8e.Text = "Düzenle";
            // menüBirim8f
            menüBirim8f.Index = 0;
            menüBirim8f.Text = "Kes";
            menüBirim8f.Click += new EventHandler (menüBirim8f_Týklandý);
            // menüBirim8g
            menüBirim8g.Index = 1;
            menüBirim8g.Text = "Kopyala";
            menüBirim8g.Click += new EventHandler (menüBirim8g_Týklandý);
            // menüBirim8h
            menüBirim8h.Index = 2;
            menüBirim8h.Text = "Yapýþtýr";
            menüBirim8h.Click += new EventHandler (menüBirim8h_Týklandý);
            // metinKutu
            metinKutu.Location = new Point (44, 56);
            metinKutu.Multiline = true;
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (180, 88);
            metinKutu.TabIndex = 1;
            metinKutu.BackColor=Color.Khaki;
            metinKutu.ForeColor=Color.Blue;
            metinKutu.Text = "Dosya menü birimlerini görmek için sað, Düzenle menü birimleri için çift týkla.";
            metinKutu.MouseDown += new MouseEventHandler (metinKutu_FareSað);
            // Form8
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (metinKutu);
            Menu = anaMenü;
            Text = "Form8: Metinkutu ve Menüler";
            BackColor=Color.Peru;
            ResumeLayout (false);
            PerformLayout();
        }
        private void metinKutu_FareSað (object k, MouseEventArgs o) {
            if (o.Button == MouseButtons.Right) {metinKutu.ContextMenu.Show (metinKutu, new Point (o.X, o.Y));}
        }
        private void menüBirim8b_Týklandý (object k, EventArgs o) {MessageBox.Show ("Dosya-->Aç");}
        private void menüBirim8c_Týklandý (object k, EventArgs o) {MessageBox.Show ("Dosya-->Sakla");}
        private void menüBirim8d_Týklandý (object k, EventArgs o) {MessageBox.Show ("Dosya-->Çýk");}
        private void menüBirim8f_Týklandý (object k, EventArgs o) {MessageBox.Show ("Düzenle-->Kes");}
        private void menüBirim8g_Týklandý (object k, EventArgs o) {MessageBox.Show ("Düzenle-->Kopyala");}
        private void menüBirim8h_Týklandý (object k, EventArgs o) {MessageBox.Show ("Düzenle-->Yapýþtýr");}
    }
    public class Form9: Form {
        private Button düðme;
        private ErrorProvider hataTeminci;
        private Label etiket;
        private TextBox metinKutu;
        //private IContainer kab = null;
        public Form9() {//Kurucu
            //kab = new Container();
            düðme = new Button();
            hataTeminci = new ErrorProvider (/*kab*/);
            etiket = new Label();
            metinKutu = new TextBox();
            ((ISupportInitialize)(hataTeminci)).BeginInit();
            SuspendLayout();
            //düðme
            düðme.Location = new Point (212, 80);
            düðme.Name = "düðme";
            düðme.Size = new Size (76, 24);
            düðme.TabIndex = 12;
            düðme.Text = "TAMAM";
            düðme.Click += new EventHandler (düðme_Týklandý);
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
            Controls.Add (düðme);
            Text = "Form9: Epostanýn Regex Kontrolu";
            BackColor=Color.Purple;
            ForeColor=Color.Pink;
            Font = new Font ("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ((ISupportInitialize)(hataTeminci)).EndInit();
            ResumeLayout (false);
            PerformLayout();
        }
        private void metinKutu_Terk (object k, EventArgs o) {
            Regex düzif;
            düzif = new Regex (@"^[\w-]+@([\w-]+\.)+[\w-]+$");
            Control kontrol = (Control)k;
            if (kontrol.Text == "") {MessageBox.Show ("Bu boþ bir epostadýr.");
            }else if (düzif.IsMatch (kontrol.Text)) {
                hataTeminci.SetError (kontrol, "");
                MessageBox.Show ("Bu geçerli bir epostadýr.");
            }else {hataTeminci.SetError (kontrol, "Bu geçerli bir eposta deðil.");}
        }
        private void düðme_Týklandý (object k, EventArgs o) {
            string hatalar = "";
            foreach (Control kontrol in Controls) {
                if (hataTeminci.GetError (kontrol) != "") {hatalar += "   * " + hataTeminci.GetError (kontrol) + "\n";}
                MessageBox.Show ("HATALAR:" + hatalar, "Geçersiz Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    public class Form10: Form {
        private Container kab = null;
        private Label fiþ10a;
        private TextBox metinKutu10a;
        private Button düðme10a;
        private Label fiþ10b;
        private TextBox metinKutu10b;
        private Label fiþ10c;
        private TextBox metinKutu10c;
        private Button düðme10c;
        public Form10() {//Kurucu
            BileþeniBaþlat();
            CenterToScreen();
        }
        protected override void Dispose (bool çöpeMi) {
            if(çöpeMi) if(kab != null) kab.Dispose();
            base.Dispose (çöpeMi);
        }
        private void BileþeniBaþlat() {
            fiþ10a = new Label();
            fiþ10b = new Label();
            fiþ10c = new Label();
            metinKutu10a = new TextBox();
            metinKutu10b = new TextBox();
            metinKutu10c = new TextBox();
            düðme10a = new Button();
            düðme10c = new Button();
            SuspendLayout();
            // fiþ10a
            fiþ10a.Font = new Font ("Microsoft Sans Serif", 10F);
            fiþ10a.Location = new Point (8, 8);
            fiþ10a.Name = "fiþ10a";
            fiþ10a.Size = new Size (136, 56);
            fiþ10a.TabIndex = 1;
            fiþ10a.Text = "Sekme ve Gir tuþlarýný kabul eden çoksatýrlý metinkutu";
            fiþ10a.BackColor=Color.Sienna;
            fiþ10a.ForeColor=Color.Orchid;
            // metinKutu10a
            metinKutu10a.AcceptsReturn = true;
            metinKutu10a.AcceptsTab = true;
            metinKutu10a.Multiline = true;
            metinKutu10a.Location = new Point (152, 8);
            metinKutu10a.Name = "metinKutu10a";
            metinKutu10a.ScrollBars = ScrollBars.Vertical;
            metinKutu10a.Size = new Size (240, 104);
            metinKutu10a.TabIndex = 0;
            metinKutu10a.Text = "Metin girin (Sekme ve Gir tuþlarý da dahil...)";
            metinKutu10a.BackColor=Color.OldLace;
            metinKutu10a.ForeColor=Color.Magenta;
            // düðme10a
            düðme10a.Location = new Point (13, 72);
            düðme10a.Name = "düðme10a";
            düðme10a.Size = new Size (120, 32);
            düðme10a.TabIndex = 2;
            düðme10a.Text = "Metni Al";
            düðme10a.BackColor=Color.Red;
            düðme10a.ForeColor=Color.Yellow;
            düðme10a.Click += new EventHandler (düðme10a_Týklandý);
            // fiþ10b
            fiþ10b.Font = new Font ("Comic Sans MS", 12F);
            fiþ10b.Location = new Point (14, 144);
            fiþ10b.Name = "fiþ10b";
            fiþ10b.Size = new Size (120, 24);
            fiþ10b.TabIndex = 4;
            fiþ10b.Text = "Büyükharfli";
            fiþ10b.BackColor=Color.Sienna;
            fiþ10b.ForeColor=Color.Orchid;
            // metinKutu10b
            metinKutu10b.CharacterCasing = CharacterCasing.Upper;
            metinKutu10b.Location = new Point (14, 176);
            metinKutu10b.Name = "metinKutu10b";
            metinKutu10b.Size = new Size (120, 20);
            metinKutu10b.TabIndex = 3;
            metinKutu10b.Text = "";
            metinKutu10b.BackColor=Color.OldLace;
            metinKutu10b.ForeColor=Color.Magenta;
            // fiþ10c
            fiþ10c.Font = new Font ("Comic Sans MS", 12F);
            fiþ10c.Location = new Point (160, 136);
            fiþ10c.Name = "fiþ10c";
            fiþ10c.Size = new Size (120, 24);
            fiþ10c.TabIndex = 6;
            fiþ10c.Text = "Þifre gir";
            fiþ10c.BackColor=Color.Sienna;
            fiþ10c.ForeColor=Color.Orchid;
            // metinKutu10c
            metinKutu10c.Location = new Point (160, 176);
            metinKutu10c.Name = "metinKutu10c";
            metinKutu10c.PasswordChar = '*';
            metinKutu10c.Size = new Size (232, 20);
            metinKutu10c.TabIndex = 5;
            metinKutu10c.Text = "mnyavas33mersin";
            metinKutu10c.BackColor=Color.OldLace;
            metinKutu10c.ForeColor=Color.Magenta;
            // düðme10c
            düðme10c.Location = new Point (280, 144);
            düðme10c.Name = "düðme10c";
            düðme10c.Size = new Size (112, 24);
            düðme10c.TabIndex = 7;
            düðme10c.Text = "Þifreyi Çöz";
            düðme10c.BackColor=Color.Red;
            düðme10c.ForeColor=Color.Yellow;
            düðme10c.Click += new EventHandler (düðme10c_Týklandý);
            // Form10
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (408, 221);
            Controls.AddRange (new Control[] {fiþ10a, fiþ10b, fiþ10c, metinKutu10a, metinKutu10b, metinKutu10c, düðme10a, düðme10c});
            Name = "Form10";
            Text = "Form10: Metinkutu Tipleri";
            BackColor=Color.Purple;
            ForeColor=Color.Pink;
            ResumeLayout (false);
        }
        protected void düðme10a_Týklandý (object k, EventArgs o) {MessageBox.Show (metinKutu10a.Text, "Tam metnin: ");}
        protected void düðme10c_Týklandý (object k, EventArgs o) {MessageBox.Show (metinKutu10c.Text, "Þifrenin çözümü: ");}
    }
    class Masked_TextBox1 {
        [STAThread]
        static void Main() {
            Console.Write ("Metinkutu çeþitleri ve maskeli metinkutu.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Aþaðýsarkan taraklýkutu birimlerini seçme, ekleme, silme, deðiþtirme:");
            Application.EnableVisualStyles();
            int ts=0;
       baþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Form1 MetinKutuya ad gir");
            Console.WriteLine ("2: Form2 Çoklu metinkutu geçerleme");
            Console.WriteLine ("3: Form3 Çoklusatýr metinkutu mesajý");
            Console.WriteLine ("4: Form4 Deðiþen metinkutu mesajý");
            Console.WriteLine ("5: Form5 ISBN no geçerleme");
            Console.WriteLine ("6: Form6 Metinkutuyu/seçileni mesajkutuda sunma");
            Console.WriteLine ("7: Form7 Geçerli yýl giriþi");
            Console.WriteLine ("8: Form8 Menüler ve metinkutusu");
            Console.WriteLine ("9: Form9 Eposta hata kontrolu");
            Console.WriteLine ("10: Form10 Üç tip metinkutusu");
            Console.WriteLine ("-99: SON");
            try {ts = int.Parse (Console.ReadLine());}catch {goto baþ;}
            if (ts == -99) goto son;
            else if (ts < 1 | ts > 10) goto baþ;
            switch (ts) {
                case 1: Application.Run (new Form1()); break; //Metinkutuya ad gir, düðmeyi týkla, mesajkutuyu ve dos pencereye bak
                case 2: Application.Run (new Form2()); break; //Çoklu metinkutularda boþ, rakam, ReadOnly geçerlemeler
                case 3: Application.Run (new Form3()); break; //Metinkutusuna çoklusatýrlý (dikey kaydýraçlý) veri giriþi
                case 4: Application.Run (new Form4()); break; //Metinkutusundaki her krk deðiþikliðin mesajlanmasý
                case 5: Application.Run (new Form5()); break; //Rakam, x, -, gerSil, Enter tuþlarýn kabulü
                case 6: Application.Run (new Form6()); break; //Metinkutuya girilen çoklusatýrlar veya seçilenler týklanýnca mesajkutuyla sunulur
                case 7: Application.Run (new Form7()); break; //[1881, 1938] yýl gir, OK-->Mesaj geçerliyse OK-->Çýk
                case 8: Application.Run (new Form8()); break; //Metinkutu saðtýkla ve menübirimleri týklama mesajlarý
                case 9: Application.Run (new Form9()); break; //Girilen epostaya "!" sinyalli "geçersiz" demiyorsa geçerlidir
                case 10: Application.Run (new Form10()); break; //Çoklusatýr, büyükharfli ve þifreli metinkutularý
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto baþ;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}