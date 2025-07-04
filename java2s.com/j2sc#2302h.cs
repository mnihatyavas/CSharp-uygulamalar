// j2sc#2302h.cs: Metinkutu, listekutu ve çentikliListekutu örneği.

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization; //GregorianCalendar() için
using System.Collections; //ArrayList için
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader için
namespace Bileşenler {
    class ListBox_CheckedListBox {
        [STAThread]
        static void Main() {
            Console.Write ("Anamenüde bir form-no gir ve düğmeyi tıkla.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault (false);
       baş: AnaMenü anamenü=new AnaMenü(); Application.Run (anamenü);
            switch (anamenü.seç) {
                case 1: Application.Run (new Form1()); break; //Her tıklamada güncel yıl 1 azalıp alta kayar
                case 2: Application.Run (new Form2()); break; //Metinkutuya girilen, düğme tklanınca listekutuya eklenir
                case 3: Application.Run (new Form3()); break; //Metinkutudakini listekutuya Ekle, listeyi sağtuşla seç sağtuş menü seçeneğini tıkla, Kapat
                case 4: Application.Run (new Form4()); break; //Listekutuya kurucuyla altalta tarih (Add ve AddRange) ekleme
                case 5: Application.Run (new Form5()); break; //Listekutu eleman tek, tek-çoklu veya çoklu-ardışık seçilmesi
                case 6: Application.Run (new Form6()); break; //Radyodüğme seçenekli yöneticiler veya işgörenler listesi
                case 7: Application.Run (new Form7()); break; //Metinkutudan düğmeyle listekutuya ekleme
                case 8: Application.Run (new Form8()); break; //ÇentikliListeKutu'da seç, çentikle, çentikliyi karasızla/kararlıla, baştan al
                case 9: Application.Run (new Form9()); break; //Çentiklenen kayıtlar düğme tıklanınca temizlenen listekutuya taşınır
                default: goto son;
            } goto baş;
       son: Console.Write ("\nTuş..."); Console.ReadKey();
        }// Main() sonu
    }// class sonu
//==================================================================
    public class AnaMenü: Form {
        public int seç=0;
        private Label fiş;
        private TextBox metinKutu;
        private Button düğme;
        public AnaMenü() {//Kurucu
            fiş = new Label();
            metinKutu = new TextBox();
            düğme = new Button();
            // fiş
            fiş.Location = new Point (15, 15);
            fiş.Margin = new Padding (4, 4, 4, 4);
            fiş.Name = "fiş";
            fiş.Size = new Size (250, 200);
            fiş.TabIndex = 1;
            fiş.Font = new Font ("Microsoft Sans Serif", 9F);
            fiş.ForeColor=Color.LightCyan;
            fiş.BackColor=Color.Black;
            fiş.Text = "1: Listekutuda azalan yıllar\n"+
                "2: Metinkutudan listekutuya ekleme\n"+
                "3: Ekle, sağtuşmenüyü seç, kapat\n "+
                "4: Listekutuyu yıllarla taşırma\n "+
                "5: Listekutudan tek, çoklu, ardışık seçim\n "+
                "6: Yöneticiler veya işgörenler listesi\n "+
                "7: Metni düğmeyle listeye ekle\n "+
                "8: ÇentikliListeKutuda seç çentikle\n "+
                "9: Çentiklikutudan listekutuya\n \n "+
                "Seçiminiz [1-9] (SON=-99):";
            //metinKutu
            metinKutu.Location = new Point (50, 220);
            metinKutu.Name = "metinKutu";
            metinKutu.Text = "";
            metinKutu.Size = new Size (30, 22);
            metinKutu.TabIndex = 0;
            //metinKutu.Focus();
            metinKutu.ForeColor=Color.Yellow;
            metinKutu.BackColor=Color.DarkRed;
            //düğme
            düğme.Location = new Point (90, 220);
            düğme.Name = "düğme";
            düğme.Size = new Size (80, 22);
            düğme.Text = "Seç-Tıkla";
            düğme.TabIndex = 2;
            düğme.ForeColor=Color.White;
            düğme.BackColor=Color.Black;
            düğme.Click += new EventHandler (düğme_Tıklandı);
            //AnaMenü
            ClientSize = new Size (290, 250);
            Controls.Add (fiş);
            Controls.Add (metinKutu);
            Controls.Add (düğme);
            Text = "Ana Menü: Bir Form Seçimi";
            BackColor=Color.DarkSlateBlue;
            CenterToScreen();
        }
        private void düğme_Tıklandı (object k, EventArgs o) {
            try {seç = int.Parse (metinKutu.Text);
                metinKutu.Text = "";
                if (seç == -99) Application.Exit();
                else if (seç < 1 | seç > 9) {seç=0; MessageBox.Show ("[1, 10] arası bir seçenek girmelisiniz.");}
                else Close();
            }catch (Exception hata) {MessageBox.Show ("HATA: [" + hata.Message + "]");}
            metinKutu.Text = "";
        }
    }
//------------------ Form1 --------------------------------------
    public partial class Form1: Form {
        static DateTime tarih = DateTime.Now;
        private int yıl=new GregorianCalendar().GetYear (tarih) +1;
        public Form1() {BileşeniBaşlat();} //Kurucu
        private void düğme_Tıklandı (object k, EventArgs o) {
            yıl--;
            listeKutu.Items.Add ("Yıl: " + yıl.ToString());
            listeKutu.TopIndex = listeKutu.Items.Count - 1;
            listeKutu.SelectedIndex = listeKutu.Items.Count - 1;
        }
    }
    partial class Form1 {
        private ListBox listeKutu;
        private Button düğme;
        private void BileşeniBaşlat(){
            listeKutu = new ListBox();
            düğme = new Button();
            SuspendLayout();
            //listeKutu
            listeKutu.FormattingEnabled = true;
            listeKutu.Location = new Point (20, 5);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (248, 200);
            listeKutu.TabIndex = 0;
            listeKutu.BackColor=Color.Tan;
            listeKutu.ForeColor=Color.DeepPink;
            listeKutu.Font = new Font ("Arial", 14F);
            //düğme
            düğme.Location = new Point (170, 200);
            düğme.Name = "düğme";
            düğme.Size = new Size (100, 30);
            düğme.TabIndex = 1;
            düğme.Text = "Tıkla";
            düğme.BackColor=Color.Cyan;
            düğme.ForeColor=Color.Red;
            düğme.Click += new EventHandler (düğme_Tıklandı);
            //
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 246);
            Controls.Add (düğme);
            Controls.Add (listeKutu);
            Name = "Form1";
            Text = "Form1: Aşağıya gerileyen Yıllar";
            BackColor=Color.Navy;
            ResumeLayout (false);
        }
    }
//------------------ Form2 --------------------------------------
    public class Form2: Form {
        private Button düğme;
        private TextBox metinKutu;
        private ListBox listeKutu;
        public Form2() {BileşeniBaşlat();} //Kurucu
        private void BileşeniBaşlat() {
            düğme = new Button();
            metinKutu = new TextBox();
            listeKutu = new ListBox();
            SuspendLayout();
            //düğme
            düğme.Font = new Font ("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
            düğme.Location = new Point (10, 10);
            düğme.Name = "düğme";
            düğme.Size = new Size (150, 32);
            düğme.TabIndex = 0;
            düğme.Text = "Listeye Ekle";
            düğme.BackColor = Color.Pink;
            düğme.Click += new EventHandler (düğme_Tıklandı);
            // metinKutu
            metinKutu.AutoSize = false;
            metinKutu.Location = new Point (170, 12);
            metinKutu.Name = "metinKutu";
            metinKutu.Size = new Size (150, 28);
            metinKutu.TabIndex = 1;
            metinKutu.Text = "M.Nihat Yavaş";
            metinKutu.BackColor = Color.Lime;
            // listeKutu
            listeKutu.BackColor = Color.DarkRed;
            listeKutu.ForeColor = SystemColors.HighlightText;
            listeKutu.Location = new Point (10, 50);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (310, 260);
            listeKutu.Font = new Font ("Arial", 14F);
            listeKutu.TabIndex = 2;
            // Form2
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (328, 318);
            Controls.AddRange (new Control[] {listeKutu, metinKutu, düğme});
            Name = "Form2";
            Text = "Form2: Metinkutuyu Listekutuya Ekleme";
            BackColor = Color.Olive;
            ResumeLayout (false);
        }
        private void düğme_Tıklandı (object k, EventArgs o) {listeKutu.Items.Add (metinKutu.Text);}
    }

//------------------ Form3 --------------------------------------
    public class Form3 : Form {
        private Button düğmeA;
        private Button düğmeB;
        private ListBox listeKutu;
        private TextBox metinKutu;
        private ContextMenu sağtuşMenü;
        private MenuItem menüBirimA;
        private MenuItem menüBirimB;
        private MenuItem menüBirimC;
        private MenuItem menüBirimD;
        public Form3() {BileşeniBaşlat();} //Kurucu
        #region Pencere Form Tasarımcının ürettiği kodlama
        private void BileşeniBaşlat() {
            düğmeA = new Button();
            düğmeB = new Button();
            listeKutu = new ListBox();
            metinKutu = new TextBox();
            sağtuşMenü = new ContextMenu();
            menüBirimA = new MenuItem();
            menüBirimB = new MenuItem();
            menüBirimC = new MenuItem();
            menüBirimD = new MenuItem();
            SuspendLayout();
            // düğmeA
            düğmeA.Location = new Point (208, 16);
            düğmeA.Name = "düğmeA";
            düğmeA.TabIndex = 3;
            düğmeA.Text = "Kapat";
            düğmeA.ForeColor = Color.Yellow;
            düğmeA.Click += new EventHandler (düğmeA_Tıklandı);
            // düğmeB
            düğmeB.Location = new Point (16, 120);
            düğmeB.Name = "düğmeB";
            düğmeB.TabIndex = 1;
            düğmeB.Text = "Ekle";
            düğmeB.ForeColor = Color.Yellow;
            düğmeB.Click += new EventHandler (düğmeB_Tıklandı);
            // listeKutu
            listeKutu.ContextMenu = sağtuşMenü;
            listeKutu.Location = new Point (16, 8);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (120, 69);
            listeKutu.TabIndex = 2;
            listeKutu.BackColor = Color.Aqua;
            // metinKutu
            metinKutu.Location = new Point (16, 88);
            metinKutu.Name = "metinKutu";
            metinKutu.TabIndex = 0;
            metinKutu.Text = "";
            metinKutu.BackColor = Color.AliceBlue;
            // sağtuşMenü
            sağtuşMenü.MenuItems.AddRange (new MenuItem[] {menüBirimA, menüBirimB, menüBirimC, menüBirimD});
            // menüBirimA
            menüBirimA.Index = 0;
            menüBirimA.Text = "Biralta Taşı";
            menüBirimA.Click += new EventHandler (sağtuşMenü_Tıklandı);
            // menüBirimB
            menüBirimB.Index = 1;
            menüBirimB.Text = "Birüste Taşı";
            menüBirimB.Click += new EventHandler (sağtuşMenü_Tıklandı);
            // menüBirimC
            menüBirimC.Index = 2;
            menüBirimC.Text = "Sil";
            menüBirimC.Click += new EventHandler (sağtuşMenü_Tıklandı);
            // menüBirimD
            menüBirimD.Index = 3;
            menüBirimD.Text = "Çiftle";
            menüBirimD.Click += new EventHandler (sağtuşMenü_Tıklandı);
            // Form3            // 
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 150);
            Controls.AddRange (new Control[] {düğmeA, düğmeB, listeKutu, metinKutu});
            Name = "Form3";
            Text = "Form3: Metinkutuyu Listekutuya Ekle ve Kapat";
            BackColor = Color.Teal;
            ResumeLayout (false);
        }
        #endregion
        private void düğmeA_Tıklandı (object k, EventArgs o) {Close();}
        private void düğmeB_Tıklandı (object k, EventArgs o) {
            listeKutu.Items.Add (metinKutu.Text);
            metinKutu.Text = "";
        }
        private void sağtuşMenü_Tıklandı (object k, EventArgs o) {
            if (listeKutu.SelectedIndex != -1) {
                MenuItem mb = (MenuItem) k;
                MessageBox.Show (listeKutu.SelectedItem + " üzerinde " + mb.Text, "Sağtuş Menüsü", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else {MessageBox.Show ("Lütfen soltuşla listebirimi, sağtuşla sağtuşMenüsü, tekrar soltuşla menübirimi tıkla", "Sağtuş Menüsü", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);} //else erişilmez
        }
    }
//------------------ Form4 --------------------------------------
    public class Form4: Form {
        ListBox listeKutu;
        public Form4() {//Kurucu
            Size = new Size (310, 400);
            Text = "Form4: Listekutuya Veriler Ekleme";
            BackColor = Color.MidnightBlue;
            //listeKutu
            listeKutu = new ListBox();
            listeKutu.Parent = this;
            listeKutu.Location = new Point (10, 10);
            listeKutu.Size = new Size (ClientSize.Width - 20, Height - 45);
            listeKutu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            listeKutu.BorderStyle = BorderStyle.Fixed3D;
            listeKutu.Font = new Font ("Arial", 14F);
            listeKutu.BackColor = Color.Green;
            listeKutu.ForeColor = Color.DeepPink;
            //BeginUpdate
            listeKutu.BeginUpdate();
            string dizge="";
            for (int i = 1881; i <= 1938; i++) {
                if(i%5==0) {listeKutu.Items.Add (dizge); dizge="";}
                dizge +=i+" ";
            }
            listeKutu.Items.Add (dizge);
            listeKutu.Items.Add ("");
            string[] yıllar=new string [1938-1881+1];
            for (int i = 0; i<=57; i++) {yıllar [i]=(i+1881) +" ";}
            listeKutu.Items.AddRange (yıllar);
            listeKutu.Items.Add ("");
            listeKutu.Items.Add ("20250613");
            listeKutu.Items.Add ("19381110");
            listeKutu.EndUpdate();
        }
    }
//------------------ Form5 --------------------------------------
    public class Form5 : Form {
        ListBox listeKutu;
        GroupBox grupKutu;
        RadioButton radyoDüğmeA;
        RadioButton radyoDüğmeB;
        RadioButton radyoDüğmeC;
        Panel panel;
        Label fiş;
        TextBox metinKutu;
        Button düğme;
        public Form5() {//Kurucu
            int xEbat, yEbat;
            Text = "Form5: Listekutudan Çoklu Seçimler";
            BackColor = Color.Purple;
            ForeColor = Color.Orange;
            Size = new Size (300, 400);
            //listeKutu
            listeKutu = new ListBox();
            listeKutu.Parent = this;
            listeKutu.Location = new Point (10, 10);
            listeKutu.Size = new Size (ClientSize.Width - 20, Height - 200);
            listeKutu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            listeKutu.BorderStyle = BorderStyle.Fixed3D;
            listeKutu.MultiColumn = true;
            listeKutu.ScrollAlwaysVisible = true;
            listeKutu.Font = new Font ("Arial", 14F);
            listeKutu.BackColor = Color.Aqua;
            listeKutu.ForeColor = Color.Teal;
            //grupKutu
            grupKutu = new GroupBox();
            grupKutu.Parent = this;
            grupKutu.Text = "ÇokluSeçim";
            grupKutu.Location = new Point (listeKutu.Left, listeKutu.Bottom + 25);
            grupKutu.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            //radyoDüğmeC
            radyoDüğmeC = new RadioButton();
            radyoDüğmeC.Parent = grupKutu;
            radyoDüğmeC.Text = "Tek";
            radyoDüğmeC.Tag = SelectionMode.One;
            radyoDüğmeC.Checked = true;
            radyoDüğmeC.Location = new Point (10, 15);
            radyoDüğmeC.CheckedChanged += new EventHandler (radyoDüğme_ÇentikDeğişti);
            //radyoDüğmeB
            radyoDüğmeB = new RadioButton();
            radyoDüğmeB.Parent = grupKutu;
            radyoDüğmeB.Text = "Çoklu-Tek";
            radyoDüğmeB.Tag = SelectionMode.MultiSimple;
            radyoDüğmeB.Location = new Point (10, radyoDüğmeC.Bottom);
            radyoDüğmeB.CheckedChanged += new  EventHandler (radyoDüğme_ÇentikDeğişti);
            //radyoDüğmeA
            radyoDüğmeA = new RadioButton();
            radyoDüğmeA.Parent = grupKutu;
            radyoDüğmeA.Text = "Çoklu-Ardışık";
            radyoDüğmeA.Tag = SelectionMode.MultiExtended;
            radyoDüğmeA.Location = new Point (10, radyoDüğmeB.Bottom);
            radyoDüğmeA.CheckedChanged += new EventHandler (radyoDüğme_ÇentikDeğişti);
            //grupKutu
            xEbat = (int)(Font.Height * 0.75) * radyoDüğmeA.Text.Length;
            yEbat = ((int)radyoDüğmeC.Height * 3) + 20;
            grupKutu.Size = new Size (xEbat, yEbat);
            grupKutu.BackColor = Color.Silver;
            //panel
            panel = new Panel();
            panel.Parent = this;
            panel.Location = new Point (listeKutu.Left, grupKutu.Bottom + 10);
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            //fiş
            fiş = new Label();
            fiş.Parent = panel;
            fiş.Text = "Üst endeks: ";
            xEbat = ((int)(Font.Height * .5) * fiş.Text.Length);
            fiş.Size = new Size (xEbat, Font.Height + 10);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = panel;
            metinKutu.Location = new Point (fiş.Right, fiş.Top);
            metinKutu.Text = listeKutu.TopIndex.ToString();
            metinKutu.Size = new Size ((int)(Font.Height * 0.75) * 3, Font.Height + 10);
            metinKutu.BackColor = Color.Pink;
            //düğme
            düğme = new Button();
            düğme.Parent = panel;
            düğme.Text = "Üstendeks";
            düğme.Location = new Point (metinKutu.Right + 10, metinKutu.Top);
            düğme.Click += new EventHandler (düğme_Tıklandı);
            //listeKutu
            listeKutu.Items.Add ("Ya hepberaber, ya hiçbirimiz");
            listeKutu.Items.Add ("202506170648");
            listeKutu.Items.Add ("193811100905");
            listeKutu.Items.Add ("M.Nihat Yavaş");      
            listeKutu.Items.Add ("Toroslar - Mersn");            
        }
        private void radyoDüğme_ÇentikDeğişti (object k, EventArgs o) {
            RadioButton rd = (RadioButton)k;
            listeKutu.SelectionMode = (SelectionMode)rd.Tag;
        }
        private void düğme_Tıklandı (object k, EventArgs o) {metinKutu.Text = listeKutu.TopIndex.ToString();}
    }
//------------------ Form6 --------------------------------------
    public class İşgören {
        public string TCNo;
        public string İsim ;
        public  İşgören (string isim, string tcno) {//Kurucu
            TCNo = tcno;
            İsim = isim;
        }
        public override string ToString() {return TCNo + ": " + İsim;}
    }
    public class Form6: Form {
        private ListBox listeKutu;
        private GroupBox grupKutu;
        private RadioButton radyoDüğmeA;
        private RadioButton radyoDüğmeB;
        private ArrayList işgörenler = new ArrayList();
        public Form6() {//Kurucu
            BileşeniBaşlat();
            //İlk Yöneticiler listesi
            listeKutu.Items.Add ("Fatma Yavaş");
            listeKutu.Items.Add ("Bekir Yavaş");
            listeKutu.Items.Add ("Hanım Yavaş");
            listeKutu.Items.Add ("Memet Yavaş");
            listeKutu.SelectedIndex = 0;
            //Sonraki işgörenler listesi
            işgörenler.Add (new İşgören ("Hatice Y.Kaçar", "1951"));
            işgörenler.Add (new İşgören ("Süheyla Y.Özbay", "1953")); 
            işgörenler.Add (new İşgören ("Zeliha Y.Candan", "1955"));
            işgörenler.Add (new İşgören ("M.Nihat Yavaş", "1957"));
            işgörenler.Add (new İşgören ("Songül Y.Göktürk", "1959"));
            işgörenler.Add (new İşgören ("M.Nedim Yavaş", "1961"));
            işgörenler.Add (new İşgören ("Sevim Yavaş", "1963"));
        }
        private void BileşeniBaşlat() {
            listeKutu = new ListBox();
            grupKutu = new GroupBox();
            radyoDüğmeA = new RadioButton();
            radyoDüğmeB = new RadioButton();
            grupKutu.SuspendLayout();
            SuspendLayout();
            // listeKutu
            listeKutu.Location = new Point (16, 8);
            listeKutu.Name = "listeKutu";
            listeKutu.Size = new Size (232, 212);
            listeKutu.TabIndex = 0;
            listeKutu.Font = new Font ("Modern", 15);
            listeKutu.BackColor = Color.Bisque;
            listeKutu.ForeColor = Color.BlueViolet;
            listeKutu.DisplayMemberChanged += new EventHandler (lk_GörünenÜyeDeğişti);
            listeKutu.ValueMemberChanged += new EventHandler (lk_DeğerliÜyeDeğişti);
            listeKutu.DataSourceChanged += new EventHandler (lk_VeriKaynağıDeğişti);
            listeKutu.SelectedValueChanged += new EventHandler (lk_SeçiliDeğerDeğişti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_SeçiliEndeksDeğişti);
            // grupKutu
            grupKutu.Controls.AddRange (new Control[] {radyoDüğmeA, radyoDüğmeB});
            grupKutu.Location = new Point (16, 240);
            grupKutu.Name = "grupKutu";
            grupKutu.TabIndex = 1;
            grupKutu.TabStop = false;
            grupKutu.Text = "Veri Kaynağı";
            grupKutu.BackColor = Color.DarkGray;
            // radyoDüğmeA
            radyoDüğmeA.Checked = true;
            radyoDüğmeA.Location = new Point (24, 32);
            radyoDüğmeA.Name = "radyoDüğmeA";
            radyoDüğmeA.TabIndex = 0;
            radyoDüğmeA.TabStop = true;
            radyoDüğmeA.Text = "Yöneticiler";
            radyoDüğmeA.CheckedChanged += new EventHandler (rd_ÇentikDeğişti);
            // radyoDüğmeB
            radyoDüğmeB.Location = new Point (24, 56);
            radyoDüğmeB.Name = "radyoDüğmeB";
            radyoDüğmeB.TabIndex = 1;
            radyoDüğmeB.Text = "İşgörenler";
            radyoDüğmeB.CheckedChanged += new EventHandler (rd_ÇentikDeğişti);
            // Form6
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (264, 360);
            Controls.AddRange (new Control[] {grupKutu, listeKutu});
            Name = "Form6";
            Text = "Form6: Listekutuda İşgörenler veya Yöneticiler";
            BackColor = Color.Brown;
            ForeColor = Color.Yellow;
            Load += new EventHandler (Form6_Yüklendi);
            grupKutu.ResumeLayout (false);
            ResumeLayout (false);
        }
        private void rd_ÇentikDeğişti (object k, EventArgs o) {//İşgören'den tekrar Yönetici listeye kodlanmadığından dönüş yok...
            listeKutu.DataSource = işgörenler;
            listeKutu.DisplayMember = "İsim";
            listeKutu.ValueMember = "TCNo";
        }
        private void lk_SeçiliEndeksDeğişti (object k, EventArgs o) {MessageBox.Show (listeKutu.SelectedIndex.ToString()+ "\n" + listeKutu.GetItemText (listeKutu.SelectedItem), "lk_SeçiliEndeksDeğişti");}
        private void lk_SeçiliDeğerDeğişti (object k, EventArgs o) {MessageBox.Show (listeKutu.GetItemText (listeKutu.SelectedItem), "lk_SeçiliDeğerDeğişti");}
        private void lk_VeriKaynağıDeğişti (object k, EventArgs o) {MessageBox.Show (listeKutu.DataSource.ToString(), "lk_VeriKaynağıDeğişti");}
        private void lk_GörünenÜyeDeğişti (object k, EventArgs o) {MessageBox.Show (listeKutu.DisplayMember.ToString(), "lk_GörünenÜyeDeğişti");}
        private void lk_DeğerliÜyeDeğişti (object k, EventArgs o) {MessageBox.Show (listeKutu.ValueMember.ToString(), "lk_DeğerliÜyeDeğişti");}
        private void Form6_Yüklendi (object k, EventArgs o) {
            listeKutu.SelectedValueChanged += new EventHandler (lk_SeçiliDeğerDeğişti);
            listeKutu.SelectedIndexChanged += new EventHandler (lk_SeçiliEndeksDeğişti);
        }
    }
//------------------ Form7 --------------------------------------
    public class Form7: Form {
        private Label fiş;
        private TextBox metinKutu;
        private Button düğme;
        private ListBox listeKutu;
        public Form7() {//Kurucu
            Size = new Size (400, 360);
            Text = "Form7: Düğmeyle Metinkutudan Listekutuya";
            BackColor = Color.Chocolate;
            ForeColor = Color.Azure;
            //fiş
            fiş = new Label();
            fiş.Parent = this;
            fiş.Text = "Listeye eklenecek metni gir:";
            fiş.AutoSize = true;
            fiş.Location = new Point (10, 10);
            //metinKutu
            metinKutu = new TextBox();
            metinKutu.Parent = this;
            metinKutu.Size = new Size (200, 2 * Font.Height);
            metinKutu.Location = new Point (10, 35);
            metinKutu.BackColor = Color.DarkCyan;
            metinKutu.ForeColor = Color.White;
            //düğme
            düğme = new Button();
            düğme.Parent = this;
            düğme.Text = "Listeye Ekle";
            düğme.Location = new Point (235,32);
            düğme.Size = new Size (9 * Font.Height, 2 * Font.Height);
            düğme.BackColor = Color.Black;
            düğme.ForeColor = Color.Red;
            düğme.Click += new EventHandler (Düğme_Tıklandı);
            //listeKutu
            listeKutu = new ListBox();
            listeKutu.Parent = this;
            listeKutu.Location = new Point (10, 65);
            listeKutu.Size = new Size (350, 20 * Font.Height);
            listeKutu.Font = new Font ("Segoe Script", 18);
            listeKutu.BackColor = Color.AliceBlue;
            listeKutu.ForeColor = Color.Crimson;
        }
        void Düğme_Tıklandı (object k, EventArgs o) {
            listeKutu.Items.Add (metinKutu.Text);
            metinKutu.Clear();
        }
    }
//------------------ Form8 --------------------------------------
    public class Form8 : Form {
        private CheckedListBox çentikliLK;
        private Button düğmeA;
        private Button düğmeB;
        private String dizge;
        public Form8() {//Kurucu
            Size = new Size (300, 400);
            Text = "Form7: ÇentikliListekutuyu Seç Çentikle";
            BackColor = Color.DarkGreen;
            Load += new EventHandler (this_Yüklendi);
            //çentikliLK
            çentikliLK = new CheckedListBox();
            çentikliLK.Parent = this;
            çentikliLK.Location = new Point (10, 10);
            çentikliLK.Size = new Size (ClientSize.Width - 20, Height - 140);
            çentikliLK.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            çentikliLK.BorderStyle = BorderStyle.Fixed3D;
            çentikliLK.MultiColumn = false;
            çentikliLK.ScrollAlwaysVisible = true;
            çentikliLK.ThreeDCheckBoxes = true;  
            çentikliLK.CheckOnClick = true;
            çentikliLK.Font = new Font ("Verdana", 18);
            çentikliLK.BackColor = Color.AliceBlue;
            çentikliLK.ForeColor = Color.Crimson;
            çentikliLK.ItemCheck += new ItemCheckEventHandler (çentikliLK_ÇentikKontrol);
            çentikliLK.Items.Add ("1881");
            çentikliLK.Items.Add ("1918");
            çentikliLK.Items.Add ("1920.04.23");
            çentikliLK.Items.Add ("1922.08.30");
            çentikliLK.Items.Add ("1923.10.29");
            çentikliLK.Items.Add ("1938.11.10 9:05");
            //düğmeA
            düğmeA = new Button();
            düğmeA.Parent = this;
            düğmeA.Text = "Belirli<-->Belirsiz";
            düğmeA.Size = new Size ((int)(Font.Height * .75) * düğmeA.Text.Length, Font.Height + 10);
            düğmeA.Location = new Point (çentikliLK.Left, çentikliLK.Bottom + 10);
            düğmeA.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            düğmeA.BackColor = Color.Lime;
            düğmeA.ForeColor = Color.Red;
            düğmeA.Click += new EventHandler (düğmeA_Tıklandı);
            //düğmeB
            düğmeB = new Button();
            düğmeB.Parent = this;
            düğmeB.Text = "Çentikler İptal";
            düğmeB.Size = new Size ((int)(Font.Height * 0.75) * düğmeB.Text.Length, Font.Height + 10);
            düğmeB.Location = new Point (düğmeA.Left, düğmeA.Bottom + 10);
            düğmeB.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            düğmeB.BackColor = Color.DarkRed;
            düğmeB.ForeColor = Color.Yellow;
            düğmeB.Click += new EventHandler (düğmeB_Tıklandı);            
        }  
        private void this_Yüklendi (object k, EventArgs o) {çentikliLK.SelectedIndexChanged += new EventHandler (çentikliLK_SeçiliEndeksDeğişti);}
        private void çentikliLK_SeçiliEndeksDeğişti (object k, EventArgs p) {
            dizge=""; dizge +="Seçili eleman sayısı: " + çentikliLK.SelectedItems.Count.ToString();
            dizge +="\nÇentikli sayısı: " + çentikliLK.CheckedItems.Count.ToString();
            MessageBox.Show (dizge, "çentikliLK_SeçiliEndeksDeğişti");
            Console.WriteLine("Seçili eleman sayısı: " + çentikliLK.SelectedItems.Count.ToString());
            Console.WriteLine("Çentikli sayısı: " + çentikliLK.CheckedItems.Count.ToString());
        }
        private void çentikliLK_ÇentikKontrol (object k, ItemCheckEventArgs o) {
            dizge=""; dizge +="Cari eleman: " + çentikliLK.GetItemText (çentikliLK.Items [o.Index]);
            dizge +="\nCari endeks: " + o.Index.ToString();
            dizge +="\nÖnceki çentik durumu: " + o.CurrentValue.ToString();
            dizge +="\nSon çentik durumu: " + o.NewValue.ToString();
            MessageBox.Show (dizge, "çentikliLK_ÇentikKontrol");
            Console.WriteLine ("Cari eleman: " + çentikliLK.GetItemText (çentikliLK.Items [o.Index]));
            Console.WriteLine ("Cari endeks: " + o.Index.ToString() );
            Console.WriteLine ("Önceki çentik durumu: " + o.CurrentValue.ToString() );
            Console.WriteLine ("Son çentik durumu: " + o.NewValue.ToString() );
        }
        private void düğmeA_Tıklandı (object k, EventArgs o) {
            for (int i = 0; i <= (çentikliLK.Items.Count - 1); i++) {
                if (çentikliLK.GetItemCheckState (i) == CheckState.Checked) {çentikliLK.SetItemCheckState (i, CheckState.Indeterminate);  
                }else if (çentikliLK.GetItemCheckState (i) == CheckState.Indeterminate) {çentikliLK.SetItemCheckState (i, CheckState.Checked);}
            }  
        }
        private void düğmeB_Tıklandı (object k, EventArgs o) {
            çentikliLK.ClearSelected(); //Seçili mavililer iptal
            for (int i = 0; i <= (çentikliLK.Items.Count - 1); i++) çentikliLK.SetItemChecked (i, false); //Çentikler iptal
        }
    }
//------------------ Form9 --------------------------------------
    class Form9 : Form {
        private CheckedListBox çentikliLK;
        private Button düğme;
        private ListBox listeKutu;
        public Form9() {//Kurucu
            BileşeniBaşlat();
            çentikliLK.Items.Add ("Bayram Küçükbay");
        }
        private void BileşeniBaşlat() {
            çentikliLK = new CheckedListBox();
            düğme = new Button();
            listeKutu = new ListBox();
            SuspendLayout();
            //çentikliLK
            çentikliLK.CheckOnClick = true;
            çentikliLK.FormattingEnabled = true;
            çentikliLK.Items.AddRange (new object[] {
                "Nihat Kaçar",
                "Adil Özbay",
                "Hamza Candan",
                "Sefer Göktürk",
                "Nur Küçükbay",
                "Yücel Küçükbay",
                "Serap Küçükbay",
                "Sema Özbay",
                "Selda Özbay",
                "Fatih Özbay",
                "Canan Candan",
                "Zafer N.Candan",
                "Belkıs Candan",
                "Hilal Göktürk",
                "Atilla Göktürk"});
            çentikliLK.Location = new Point(13, 13);
            çentikliLK.Name = "çentikliLK";
            çentikliLK.Size = new Size(187, 242);
            çentikliLK.BackColor = Color.Beige;
            çentikliLK.ForeColor = Color.Green;
            //düğme
            düğme.Location = new Point (207, 129);
            düğme.Text = "Taşı";
            düğme.BackColor = Color.Khaki;
            düğme.ForeColor = Color.Magenta;
            düğme.Click += new EventHandler (düğme_Tıklandı);
            //listeKutu
            listeKutu.FormattingEnabled = true;
            listeKutu.Location = new Point (288, 13);
            listeKutu.SelectionMode = SelectionMode.MultiExtended;
            listeKutu.Size = new Size (187, 238);
            listeKutu.BackColor = Color.Bisque;
            listeKutu.ForeColor = Color.Blue;
            listeKutu.Font = new Font ("Modern", 18);
            //this
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (492, 273);
            Controls.Add (listeKutu);
            Controls.Add (düğme);
            Controls.Add (çentikliLK);
            Text = "Form9: Çentikliden Listekutuya";
            BackColor = Color.CadetBlue;
            ResumeLayout(false);
        }
        private void düğme_Tıklandı (object k, EventArgs o) {
            if (çentikliLK.CheckedItems.Count > 0) {
                listeKutu.Items.Clear();
                foreach (string kayıt in çentikliLK.CheckedItems) {listeKutu.Items.Add (kayıt.ToString());}
                for (int i = 0; i < çentikliLK.Items.Count; i++) çentikliLK.SetItemChecked (i, false);
            }
        }
    }
}// namespace sonu