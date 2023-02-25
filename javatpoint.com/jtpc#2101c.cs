// jtpc#2101c.cs: Form içi buton týklamayla formu kapatma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class Çýkýþ: Form {
        private FlowLayoutPanel panel;
        public Çýkýþ() {BileþenleriBaþlat();}
        private void BileþenleriBaþlat() {
            Text = "Çýkýþ Düðmesi"; //Form
            ClientSize = new Size (200, 100);
            CenterToScreen();

            panel = new FlowLayoutPanel(); //Panel
            panel.Dock = DockStyle.Fill;
            panel.BorderStyle = BorderStyle.FixedSingle;

            var çýkýþDüðmesi = new Button(); //Düðme
            çýkýþDüðmesi.Margin = new Padding (60,30, 0,0); //Paneldeki konumu (Sol,üst, sað,alt)
            çýkýþDüðmesi.Text = "Çýk";
            çýkýþDüðmesi.AutoSize = true;
            çýkýþDüðmesi.Click += (a,b)=>Close();

            panel.Controls.Add (çýkýþDüðmesi);
            this.Controls.Add (panel);
        }
        static void Main() {Application.Run (new Çýkýþ());}
    }
}