// jtpc#2101e.cs: Paneldeki �entik kutusuyla form ba�l���n� de�i�tirme �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class �entikKutusu: Form {
        public  �entikKutusu() {Ba�lat();}
        private void Ba�lat() {
            Text = "�entik Kutusu";
            ClientSize = new Size (220, 100);
            CenterToScreen();
            var panel = new FlowLayoutPanel();
            var �k = new CheckBox();
            �k.Margin = new Padding (20);
            �k.Parent = this;
            �k.Text = "Form ba�l���n� g�ster";
            �k.AutoSize = true;
            //�k.Checked = true;
            if (�k.Checked == true) {Text = "�entik Kutusu";}
            else {Text = "";}
            �k.CheckedChanged +=(a,b)=>{if (�k.Checked) {Text = "�entik Kutusu";} else {Text = "";} };
            panel.Controls.Add (�k);
            Controls.Add (panel);
        }
        static void Main() {Application.Run (new �entikKutusu());}
    }
}