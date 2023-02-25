// jtpc#2101k.cs: Etiket, metinkutusu ve olaylý düðme týklama örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class OlaylýButon: Form {
        Label etiket1;
        TextBox metinkutusu1;
        Button düðme1;
        Button düðme2;
        public OlaylýButon() {
            etiket1 = new Label();
            metinkutusu1 = new TextBox();
            düðme1 = new Button();
            düðme2 = new Button();
            etiket1.UseMnemonic = true;
            etiket1.Text = "Ýsminizi &Girin:";
            etiket1.Location = new Point (15, 15);
            etiket1.BackColor = Color.Pink;
            etiket1.ForeColor = Color.Maroon;
            etiket1.BorderStyle = BorderStyle.FixedSingle;
            etiket1.Size = new Size (etiket1.PreferredWidth, etiket1.PreferredHeight + 2);
            metinkutusu1.Text = "M.Nihat Yavaþ";
            metinkutusu1.Location = new Point (15 + etiket1.PreferredWidth + 5, 15);
            metinkutusu1.BorderStyle = BorderStyle.FixedSingle;
            metinkutusu1.BackColor = Color.SlateGray;
            metinkutusu1.ForeColor = Color.Maroon;
            metinkutusu1.Size = new Size (120, 20);
            düðme1.Text = "&Tamam";
            düðme1.Location = new Point (15 + metinkutusu1.Location.X + metinkutusu1.Size.Width, 15);
            düðme1.Size = new Size (80, 20);
            düðme2.Text = "&Son";
            düðme1.BackColor = Color.Green;
            düðme2.Location = new Point (150, 150);
            düðme2.Size = new Size (90, 20);
            düðme2.BackColor = Color.Maroon;
            düðme2.ForeColor = Color.White;
            this.BackColor = Color.DarkKhaki;
            this.Text = "Olaylý Buton Kontrollarý";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.AutoScaleBaseSize = new Size (5, 13);
            this.ClientSize = new Size (350, 200);//Baþlýk yüksekliði hariç
            //this.MinTrackSize = new Size (300, (200 + SystemInformation.CaptionHeight));
            this.AutoScroll = true;
            this.MaximizeBox = false;
            this.Controls.Add (etiket1);
            this.Controls.Add (metinkutusu1);
            this.Controls.Add (düðme1);
            this.Controls.Add (düðme2);
            düðme1.Click += new System.EventHandler (AdgirTýklandý);
            düðme2.Click += new System.EventHandler (SonTýklandý);
        }  
        public void AdgirTýklandý (object n, System.EventArgs o) {  
            if (metinkutusu1.Text == "M.Nihat Yavaþ") MessageBox.Show ("Yeni isim girmediniz", "Uyarý");
            else MessageBox.Show ("Selam!!! " + metinkutusu1.Text, "Nihat");
        }  
        public void SonTýklandý (object n, System.EventArgs o) {
            MessageBox.Show ("Program kapanýyor...", "SON");
            Application.Exit();
        }  
        public static void Main() {Application.Run (new OlaylýButon());}
    }
}