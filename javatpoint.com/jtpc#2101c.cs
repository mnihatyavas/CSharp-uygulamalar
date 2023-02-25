// jtpc#2101c.cs: Form i�i buton t�klamayla formu kapatma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class ��k��: Form {
        private FlowLayoutPanel panel;
        public ��k��() {Bile�enleriBa�lat();}
        private void Bile�enleriBa�lat() {
            Text = "��k�� D��mesi"; //Form
            ClientSize = new Size (200, 100);
            CenterToScreen();

            panel = new FlowLayoutPanel(); //Panel
            panel.Dock = DockStyle.Fill;
            panel.BorderStyle = BorderStyle.FixedSingle;

            var ��k��D��mesi = new Button(); //D��me
            ��k��D��mesi.Margin = new Padding (60,30, 0,0); //Paneldeki konumu (Sol,�st, sa�,alt)
            ��k��D��mesi.Text = "��k";
            ��k��D��mesi.AutoSize = true;
            ��k��D��mesi.Click += (a,b)=>Close();

            panel.Controls.Add (��k��D��mesi);
            this.Controls.Add (panel);
        }
        static void Main() {Application.Run (new ��k��());}
    }
}