// jtpc#2101k.cs: Etiket, metinkutusu ve olayl� d��me t�klama �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class Olayl�Buton: Form {
        Label etiket1;
        TextBox metinkutusu1;
        Button d��me1;
        Button d��me2;
        public Olayl�Buton() {
            etiket1 = new Label();
            metinkutusu1 = new TextBox();
            d��me1 = new Button();
            d��me2 = new Button();
            etiket1.UseMnemonic = true;
            etiket1.Text = "�sminizi &Girin:";
            etiket1.Location = new Point (15, 15);
            etiket1.BackColor = Color.Pink;
            etiket1.ForeColor = Color.Maroon;
            etiket1.BorderStyle = BorderStyle.FixedSingle;
            etiket1.Size = new Size (etiket1.PreferredWidth, etiket1.PreferredHeight + 2);
            metinkutusu1.Text = "M.Nihat Yava�";
            metinkutusu1.Location = new Point (15 + etiket1.PreferredWidth + 5, 15);
            metinkutusu1.BorderStyle = BorderStyle.FixedSingle;
            metinkutusu1.BackColor = Color.SlateGray;
            metinkutusu1.ForeColor = Color.Maroon;
            metinkutusu1.Size = new Size (120, 20);
            d��me1.Text = "&Tamam";
            d��me1.Location = new Point (15 + metinkutusu1.Location.X + metinkutusu1.Size.Width, 15);
            d��me1.Size = new Size (80, 20);
            d��me2.Text = "&Son";
            d��me1.BackColor = Color.Green;
            d��me2.Location = new Point (150, 150);
            d��me2.Size = new Size (90, 20);
            d��me2.BackColor = Color.Maroon;
            d��me2.ForeColor = Color.White;
            this.BackColor = Color.DarkKhaki;
            this.Text = "Olayl� Buton Kontrollar�";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.AutoScaleBaseSize = new Size (5, 13);
            this.ClientSize = new Size (350, 200);//Ba�l�k y�ksekli�i hari�
            //this.MinTrackSize = new Size (300, (200 + SystemInformation.CaptionHeight));
            this.AutoScroll = true;
            this.MaximizeBox = false;
            this.Controls.Add (etiket1);
            this.Controls.Add (metinkutusu1);
            this.Controls.Add (d��me1);
            this.Controls.Add (d��me2);
            d��me1.Click += new System.EventHandler (AdgirT�kland�);
            d��me2.Click += new System.EventHandler (SonT�kland�);
        }  
        public void AdgirT�kland� (object n, System.EventArgs o) {  
            if (metinkutusu1.Text == "M.Nihat Yava�") MessageBox.Show ("Yeni isim girmediniz", "Uyar�");
            else MessageBox.Show ("Selam!!! " + metinkutusu1.Text, "Nihat");
        }  
        public void SonT�kland� (object n, System.EventArgs o) {
            MessageBox.Show ("Program kapan�yor...", "SON");
            Application.Exit();
        }  
        public static void Main() {Application.Run (new Olayl�Buton());}
    }
}