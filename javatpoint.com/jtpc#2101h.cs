// jtpc#2101h.cs: Buton t�klama olay�n�n metinkutusu ve mesajkutusunda duyurulmas� �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class ButonT�klama: Form {
        private int i = 0;
        private Button d��me;
        private TextBox metinKutusu;
        private ButonT�klama() {
            Text = "Buton T�klama Olay�";
            CenterToScreen();
            BackColor = Color.Black;
            d��me = new Button();
            metinKutusu = new TextBox();
            // D��me �zellikleri
            d��me.Location = new Point (10, 20);
            //d��me.Name = "D��me";
            d��me.Size = new Size (100, 30);
            //d��me.TabIndex = 0;
            d��me.Text = "Beni T�kla";
            d��me.BackColor = Color.Maroon;
            d��me.ForeColor = Color.Yellow;
            // Metinkutusu �zellikleri
            metinKutusu.Location = new Point (10, 100);
            //metinKutusu.Name = "MetinKutusu";
            metinKutusu.Size = new Size (250, 30);
            metinKutusu.Font = new Font ("Arial", 13);
            //metinKutusu.TabIndex = 1;
            metinKutusu.Text = "Metin Kutusu";
            metinKutusu.BackColor = Color.Navy;
            metinKutusu.ForeColor = Color.Yellow;
            // d��me ve metinKutusu'nu form'a ek
            Controls.AddRange (new Control[] {metinKutusu, d��me});
            //Controls.Add (d��me);
            //Controls.Add (metinKutusu);
            d��me.Click += new System.EventHandler (d��meyiT�kla); //"System." gerekli
        }
        private void d��meyiT�kla (object a, System.EventArgs b) {//"System." gerekli
            metinKutusu.Text = "D��meyi " + ++i + ".inci kez t�klad�n�z...";
            MessageBox.Show ("D��me " + i + ".inci kez t�kland�!..");
        }
        public static void Main() {Application.Run (new ButonT�klama());}
    }
}