// j2sc#2302g.cs: ResimKutusu, KaydıraçÇubukları ve Ayraçlar örneği.

using System;
using System.Windows.Forms; 
using System.Drawing;
using System.ComponentModel; //CancelEventHandler
using System.Drawing.Printing; //PrintPageEventArgs için
using System.IO; //File, FileInfo için
namespace Bileşenler {
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
            fiş.Text = "1: Normalebatlı resimli kutu\n"+
                "2: Otoebatlı resimkutusu\n"+
                "3: Ortalaebatlı 2 resimkutusu\n "+
                "4: Esnekebatlı 2 resimkutusu\n "+
                "5: Form, panel ve resimkutu\n "+
                "6: Resmi kutuya sürüle\n "+
                "7: Resmi kaydıraçlarla kaydır\n "+
                "8: Kaydıraçları konumlandırma\n "+
                "9: Dolgu rıhtım ve ayraçları\n \n "+
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
    public class Form1: Form {
        public Form1() {//Kurucu
            Size = new Size (400, 350);
            AutoScroll = true;
            BackColor=Color.Violet;
            Text="Form1: Normal Resimkutuda Çiçek";
            //resim
            Image resim = Image.FromFile ("resim/çiçek.jpg");
            //fiş
            Label fiş = new Label();
            fiş.Parent = this;
            fiş.Location = new Point (0, 20);
            fiş.Size = new Size (80, 25);
            fiş.TextAlign = ContentAlignment.MiddleRight;
            fiş.Text = "NORMAL:  ";
            //
            PictureBox resimKutusu = new PictureBox();
            resimKutusu.Parent = this;
            resimKutusu.Size = new Size (200, 150); //Gerçek ebat: 250x250
            resimKutusu.Location = new Point (80, 20);
            resimKutusu.BorderStyle = BorderStyle.FixedSingle;
            resimKutusu.SizeMode = PictureBoxSizeMode.Normal; //Resim normal ebatıyla kutusuna kesintili/bol yerleşir
            resimKutusu.Image = resim;
        }
    }
//------------------ Form2 --------------------------------------
    public class Form2: Form {
        public Form2() {//Kurucu
            Size = new Size (400, 350);
            AutoScroll = true;
            BackColor=Color.Thistle;
            Text="Form2: OtoEbatlı Resimkutuda Çiçek";
            //resim
            Image resim = Image.FromFile ("resim/çiçek.jpg");
            //fiş
            Label fiş = new Label();
            fiş.Parent = this;
            fiş.Location = new Point (0, 20);
            fiş.Size = new Size (80, 25);
            fiş.TextAlign = ContentAlignment.MiddleRight;
            fiş.Text = "AUTOSIZE: ";
            //resimKutusu
            PictureBox resimKutusu = new PictureBox();
            resimKutusu.Parent = this;
            //resimKutusu.Size = new Size (150, 150); //Bu ebatlamaya değil, resmin gerçek ebatına uyar
            resimKutusu.Location = new Point (80, 20);
            resimKutusu.BorderStyle = BorderStyle.FixedSingle;
            resimKutusu.SizeMode = PictureBoxSizeMode.AutoSize; //Resim normal ebatıyla kutusuna kesintili/bol yerleşir
            resimKutusu.Image = resim;
        }
    }
//------------------ Form3 --------------------------------------
    public class Form3: Form {
        public Form3() {//Kurucu
            Size = new Size (750, 450);
            AutoScroll = true;
            BackColor=Color.Wheat;
            Text="Form2: OrtalaEbatlı Resimkutuda Çiçek";
            //resim
            Image resim = Image.FromFile ("resim/çiçek.jpg");
            //fiş
            Label fiş = new Label();
            fiş.Parent = this;
            fiş.Location = new Point (0, 20);
            fiş.Size = new Size (100, 25);
            fiş.TextAlign = ContentAlignment.MiddleRight;
            fiş.Text = "CENTERIMAGE: ";
            //resimKutusu
            PictureBox resimKutusuA = new PictureBox();
            resimKutusuA.Parent = this;
            resimKutusuA.Size = new Size (350, 350); //Kutu ebattan büyükse kenar boşluklu ortalanır
            resimKutusuA.Location = new Point (100, 20);
            resimKutusuA.BorderStyle = BorderStyle.FixedSingle;
            resimKutusuA.SizeMode = PictureBoxSizeMode.CenterImage;
            resimKutusuA.BackColor=Color.Lime;
            resimKutusuA.Image = resim;
            //resimKutusuB
            PictureBox resimKutusuB = new PictureBox();
            resimKutusuB.Parent = this;
            resimKutusuB.Size = new Size (260, 200); //Kutu ebattan küçükse resim kenarları kırpılarak ortalanır
            resimKutusuB.Location = new Point (460, 20);
            resimKutusuB.BorderStyle = BorderStyle.FixedSingle;
            resimKutusuB.SizeMode = PictureBoxSizeMode.CenterImage;
            resimKutusuB.BackColor=Color.Cyan;
            resimKutusuB.Image = resim;
        }
    }
//------------------ Form4 --------------------------------------
    public class Form4: Form {
        public Form4() {//Kurucu
            Size = new Size (650, 450);
            AutoScroll = true;
            BackColor=Color.Pink;
            Text="Form2: EsnetEbatlı Resimkutuda Çiçek";
            //resim
            Image resim = Image.FromFile ("resim/çiçek.jpg");
            //fiş
            Label fiş = new Label();
            fiş.Parent = this;
            fiş.Location = new Point (0, 20);
            fiş.Size = new Size (100, 25);
            fiş.TextAlign = ContentAlignment.MiddleRight;
            fiş.Text = "STRETCHIMAGE: ";
            //resimKutusu
            PictureBox resimKutusuA = new PictureBox();
            resimKutusuA.Parent = this;
            resimKutusuA.Size = new Size (350, 350); //Resmin tamamı kendini verili kutuebatına esnetir
            resimKutusuA.Location = new Point (100, 20);
            resimKutusuA.BorderStyle = BorderStyle.FixedSingle;
            resimKutusuA.SizeMode = PictureBoxSizeMode.StretchImage;
            resimKutusuA.Image = resim;
            //resimKutusuB
            PictureBox resimKutusuB = new PictureBox();
            resimKutusuB.Parent = this;
            resimKutusuB.Size = new Size (150, 300); //Resmin tamamı kendini verili kutuebatına esnetir
            resimKutusuB.Location = new Point (460, 20);
            resimKutusuB.BorderStyle = BorderStyle.FixedSingle;
            resimKutusuB.SizeMode = PictureBoxSizeMode.StretchImage;
            resimKutusuB.Image = resim;
        }
    }
//------------------ Form5 --------------------------------------
    public class Form5 : Form {
        private Panel panel;
        private PictureBox resimKutu;
        public Form5() {//Kurucu
            panel = new Panel();
            resimKutu = new PictureBox();
            panel.SuspendLayout();
            ((ISupportInitialize)(resimKutu)).BeginInit();
            SuspendLayout();
            //panel
            panel.AutoScroll = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add (resimKutu);
            panel.Location = new Point (10, 10);
            panel.Size = new Size (260, 240);
            panel.BackColor=Color.Lime;
            //resimKutu
            resimKutu.Location = new Point (70, 60);
            resimKutu.Size = new Size (110, 140);
            resimKutu.TabStop = false;
            //this
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (290, 270);
            BackColor=Color.DarkKhaki;
            Text="Form5: Form5, Panel ve Resimkutu";
            Controls.Add (panel); //Haki Form5, yeşilimsi panel, kiremitimsi resimkutu içiçe
            panel.ResumeLayout (false);
            ((ISupportInitialize)(resimKutu)).EndInit();
            ResumeLayout (false);
            //resimKutu'daki yazı
            string dizge = "M.Nihat Yavaş\nToroslar-Mersin/TR";
            Font yazı = new Font ("Tahoma", 20);
            Bitmap bm = new Bitmap (600, 600);
            using (Graphics gr = Graphics.FromImage (bm)) {
                gr.FillRectangle (Brushes.Sienna, new Rectangle (0,0,  bm.Width,bm.Height));
                gr.DrawString (dizge, yazı, Brushes.Yellow, 50, 60);
            }
            resimKutu.BackgroundImage = bm;
            resimKutu.Size = bm.Size;
        }
    }
//------------------ Form6 --------------------------------------
    public class Form6: Form {
        private bool sürükleniyorMu = false;
        private int eskiX, eskiY;
        Rectangle kutu = new Rectangle (100,100, 150,150);
        private PictureBox resimKutu = new PictureBox();
        public Form6() {//Kurucu
            BileşeniBaşlat();
            CenterToScreen();
            //resimKutu
            resimKutu.SizeMode = PictureBoxSizeMode.StretchImage;
            resimKutu.Location = new Point (64, 32);
            resimKutu.Size = new Size (70, 50); //Resim(250x250) yeni ebatına(70x50) esner
            resimKutu.Image = new Bitmap ("resim/pelikan.jpg");
            resimKutu.MouseDown += new MouseEventHandler (resimKutu_FareBasıldı);
            resimKutu.MouseUp += new MouseEventHandler (resimKutu_FareÇekildi);
            resimKutu.MouseMove += new MouseEventHandler (resimKutu_FareTaşıyor);
            resimKutu.Cursor = Cursors.Hand; //El imleciyle taşıma
            Controls.Add (resimKutu);
        }
        private void BileşeniBaşlat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            Name = "Form6";
            Text = "Form6: Resmi Kutuya Sürükle";
            BackColor=Color.Olive;
            Paint += new PaintEventHandler (KutuyaYaz);
        }
        private void resimKutu_FareBasıldı(object k, MouseEventArgs o) {
            sürükleniyorMu = true;
            eskiX = o.X;
            eskiY = o.Y;
        }
        private void resimKutu_FareTaşıyor (object k, MouseEventArgs o) {
            if (sürükleniyorMu) {
                resimKutu.Top = resimKutu.Top + (o.Y - eskiY);
                resimKutu.Left = resimKutu.Left + (o.X - eskiX);
            }
        }
        private void resimKutu_FareÇekildi(object k, MouseEventArgs o) {
            sürükleniyorMu = false;
            if (kutu.Contains (resimKutu.Bounds)) MessageBox.Show ("Resim kutuda", "Mesaj");
        }
        private void KutuyaYaz (object k, PaintEventArgs o) {
            Graphics gr = o.Graphics;
            gr.FillRectangle (Brushes.Purple, kutu);
            gr.DrawString ("Resmi buraya bırak...", new Font ("Times New Roman", 25), Brushes.Yellow, kutu);
        }
    }
//------------------ Form7 --------------------------------------
    public class Form7: Form {
        Panel panel;
        PictureBox resimKutu;
        HScrollBar yatayÇubuk;
        VScrollBar dikeyÇubuk;
        Image resim;
        public Form7() {//Kurucu
            //this
            Size = new Size (480, 300);
            Text = "Form7: Resim ve KaydırmaÇubukları";
            BackColor=Color.ForestGreen;
            //panel
            panel = new Panel();
            panel.Parent = this;
            panel.Size = new Size (400, 200);
            panel.Location = new Point (10, 10);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor=Color.SteelBlue;
            //resim
            resim = Image.FromFile ("resim/pelikan.jpg");
            //resimKutu
            resimKutu = new PictureBox();
            resimKutu.Parent = panel;
            resimKutu.Size = new Size (resim.Size.Width, resim.Size.Height);
            resimKutu.Location = new Point ((panel.Size.Width / 2) - (resimKutu.Size.Width / 2), (panel.Size.Height / 2) - (resimKutu.Size.Height / 2));
            resimKutu.SizeMode = PictureBoxSizeMode.CenterImage;
            resimKutu.Image = resim;
            //yatayÇubuk
            yatayÇubuk = new HScrollBar();
            yatayÇubuk.Parent = this;
            yatayÇubuk.Location = new Point (panel.Left, panel.Bottom);
            yatayÇubuk.Size = new Size (panel.Width, 25);
            yatayÇubuk.Minimum = 0;
            yatayÇubuk.Maximum = 100;
            yatayÇubuk.SmallChange = 1;
            yatayÇubuk.LargeChange = 10;
            yatayÇubuk.Value = (yatayÇubuk.Maximum - yatayÇubuk.Minimum) / 2;
            yatayÇubuk.ValueChanged += new EventHandler (yatayÇubuk_Kaydırıldı);
            //dikeyÇubuk
            dikeyÇubuk = new VScrollBar();
            dikeyÇubuk.Parent = this;
            dikeyÇubuk.Location = new Point (panel.Right, panel.Top);
            dikeyÇubuk.Size = new Size (25, panel.Height);
            dikeyÇubuk.Minimum = 0;
            dikeyÇubuk.Maximum = 100;
            dikeyÇubuk.SmallChange = 1;
            dikeyÇubuk.LargeChange = 10;
            dikeyÇubuk.Value = (dikeyÇubuk.Maximum - dikeyÇubuk.Minimum) / 2;
            dikeyÇubuk.ValueChanged += new EventHandler (dikeyÇubuk_Kaydırıldı);
        }
        private void yatayÇubuk_Kaydırıldı (object k, EventArgs o) {resimKutu.Location = new Point ((panel.Size.Width - resim.Size.Width) * (yatayÇubuk.Value) / (yatayÇubuk.Maximum - yatayÇubuk.LargeChange + 1), resimKutu.Top);}
        private void dikeyÇubuk_Kaydırıldı (object k, EventArgs o) {resimKutu.Location = new Point (resimKutu.Left, (panel.Size.Height - resim.Size.Height) * dikeyÇubuk.Value / (dikeyÇubuk.Maximum - dikeyÇubuk.LargeChange + 1));}
    }
//------------------ Form8 --------------------------------------
    public class Form8: Form {
        HScrollBar yatayÇubuk;
        VScrollBar dikeyÇubuk;
        public Form8() {//Kurucu
            Size = new Size (480, 500);
            Text = "Form8: Yatay/Dikey KaydırmaÇubukları";
            BackColor=Color.MediumOrchid;
            //yatayÇubuk
            yatayÇubuk = new HScrollBar();
            yatayÇubuk.Parent = this;
            yatayÇubuk.Location = new Point (Left, Bottom - 60);
            yatayÇubuk.Size = new Size (Width-12, 25);
            yatayÇubuk.Minimum = 25;
            yatayÇubuk.Maximum = 400;
            yatayÇubuk.SmallChange = 10;
            yatayÇubuk.LargeChange = 100;
            yatayÇubuk.Value = Width - yatayÇubuk.LargeChange;
            yatayÇubuk.ValueChanged += new EventHandler (yatayÇubuk_Kaydırıldı);
            //dikeyÇubuk
            dikeyÇubuk = new VScrollBar();
            dikeyÇubuk.Parent = this;
            dikeyÇubuk.Location = new Point (Right-40, Top);
            dikeyÇubuk.Size = new Size (25, Height-40);
            dikeyÇubuk.Minimum = 25;
            dikeyÇubuk.Maximum = 400;
            dikeyÇubuk.SmallChange = 10;
            dikeyÇubuk.LargeChange = 100;
            dikeyÇubuk.Value = Height - dikeyÇubuk.LargeChange;
            dikeyÇubuk.ValueChanged += new EventHandler (dikeyÇubuk_Kaydırıldı);
        } 
        private void yatayÇubuk_Kaydırıldı (object k, EventArgs o) {Console.Write ("yatay: " + yatayÇubuk.Value + "\t");}
        private void dikeyÇubuk_Kaydırıldı (object k, EventArgs o) {Console.Write ("dikey: " + dikeyÇubuk.Value + "\t");}
    }
//------------------ Form9 --------------------------------------
    public class Form9: Form {
        public Form9() {
            Size = new Size (500, 200);
            Text = "Form9: Üç Dolgu Rıhtım ve Ayraçlar";
            BackColor=Color.Orchid;
            //grupKutuA
            GroupBox grupKutuA = new GroupBox();
            grupKutuA.Parent = this;
            grupKutuA.Dock = DockStyle.Fill;
            grupKutuA.Text = "Dolgu Rıhtım-A";
            grupKutuA.BackColor=Color.MediumOrchid;
            //ayraç1
            Splitter ayraç1 = new Splitter();
            ayraç1.Parent = this;
            ayraç1.Dock = DockStyle.Left;
            //grupKutuB
            GroupBox grupKutuB = new GroupBox();
            grupKutuB.Parent = this;
            grupKutuB.Dock = DockStyle.Left;
            grupKutuB.Text = "Sol Rıhtım-B";
            grupKutuB.BackColor=Color.LightSteelBlue;
            //ayraç2
            Splitter ayraç2 = new Splitter();
            ayraç2.Parent = this;
            ayraç2.Dock = DockStyle.Right;
            //grupKutuC
            GroupBox grupKutuC = new GroupBox();
            grupKutuC.Parent = this;
            grupKutuC.Dock = DockStyle.Right;
            grupKutuC.Text = "Sağ Rıhtım-C";
            grupKutuC.BackColor=Color.LightSeaGreen;
        }
    }
//==================================================================
    class PictureBox_ScrollBar_Splitter {
        [STAThread]
        static void Main() {
            Console.Write ("Tekboşluk:ensp=' ', Çiftboşluk:emsp=' '\nAnamenüde bir form-no gir ve düğmeyi tıkla.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault (false);
       baş: AnaMenü anamenü=new AnaMenü(); Application.Run (anamenü);
            switch (anamenü.seç) {
                case 1: Application.Run (new Form1()); break; //Etiket sağındaki "Normal" resim kutusuna konan çiçek
                case 2: Application.Run (new Form2()); break; //Etiket sağındaki "AutoSize" resim kutusuna konan çiçek
                case 3: Application.Run (new Form3()); break; //Etiket sağındaki 2 adet geniş ve dar "CenterImage" resim kutularına konan çiçekler
                case 4: Application.Run (new Form4()); break; //Etiket sağındaki 2 adet farklıebatlı "StretchImage" resim kutularına esnetilen çiçekler
                case 5: Application.Run (new Form5()); break; //İçiçe Form5, kaydıraçlı Panel ve dizgeli PictureBox
                case 6: Application.Run (new Form6()); break; //Küçültülen ebatlı resmi kutuya taşı
                case 7: Application.Run (new Form7()); break; //Panel, resimkutusu ve kaydıraçlarla resmi kaydırma
                case 8: Application.Run (new Form8()); break; //Yatay/dikeyçbukların konumu, ebatı, tutamaç uzunluk
                case 9: Application.Run (new Form9()); break; //Rıhtımlar: Dock.Left/Fill/Right ve ayraçları
                default: goto son;
            } goto baş;

       son: Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}