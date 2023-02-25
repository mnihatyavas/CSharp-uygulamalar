// jtpc#2101h.cs: Buton týklama olayýnýn metinkutusu ve mesajkutusunda duyurulmasý örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class ButonTýklama: Form {
        private int i = 0;
        private Button düðme;
        private TextBox metinKutusu;
        private ButonTýklama() {
            Text = "Buton Týklama Olayý";
            CenterToScreen();
            BackColor = Color.Black;
            düðme = new Button();
            metinKutusu = new TextBox();
            // Düðme özellikleri
            düðme.Location = new Point (10, 20);
            //düðme.Name = "Düðme";
            düðme.Size = new Size (100, 30);
            //düðme.TabIndex = 0;
            düðme.Text = "Beni Týkla";
            düðme.BackColor = Color.Maroon;
            düðme.ForeColor = Color.Yellow;
            // Metinkutusu özellikleri
            metinKutusu.Location = new Point (10, 100);
            //metinKutusu.Name = "MetinKutusu";
            metinKutusu.Size = new Size (250, 30);
            metinKutusu.Font = new Font ("Arial", 13);
            //metinKutusu.TabIndex = 1;
            metinKutusu.Text = "Metin Kutusu";
            metinKutusu.BackColor = Color.Navy;
            metinKutusu.ForeColor = Color.Yellow;
            // düðme ve metinKutusu'nu form'a ek
            Controls.AddRange (new Control[] {metinKutusu, düðme});
            //Controls.Add (düðme);
            //Controls.Add (metinKutusu);
            düðme.Click += new System.EventHandler (düðmeyiTýkla); //"System." gerekli
        }
        private void düðmeyiTýkla (object a, System.EventArgs b) {//"System." gerekli
            metinKutusu.Text = "Düðmeyi " + ++i + ".inci kez týkladýnýz...";
            MessageBox.Show ("Düðme " + i + ".inci kez týklandý!..");
        }
        public static void Main() {Application.Run (new ButonTýklama());}
    }
}