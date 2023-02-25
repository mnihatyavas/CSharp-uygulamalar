// jtpc#2101e.cs: Paneldeki çentik kutusuyla form baþlýðýný deðiþtirme örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class ÇentikKutusu: Form {
        public  ÇentikKutusu() {Baþlat();}
        private void Baþlat() {
            Text = "Çentik Kutusu";
            ClientSize = new Size (220, 100);
            CenterToScreen();
            var panel = new FlowLayoutPanel();
            var çk = new CheckBox();
            çk.Margin = new Padding (20);
            çk.Parent = this;
            çk.Text = "Form baþlýðýný göster";
            çk.AutoSize = true;
            //çk.Checked = true;
            if (çk.Checked == true) {Text = "Çentik Kutusu";}
            else {Text = "";}
            çk.CheckedChanged +=(a,b)=>{if (çk.Checked) {Text = "Çentik Kutusu";} else {Text = "";} };
            panel.Controls.Add (çk);
            Controls.Add (panel);
        }
        static void Main() {Application.Run (new ÇentikKutusu());}
    }
}