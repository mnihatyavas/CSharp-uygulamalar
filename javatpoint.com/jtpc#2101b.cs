// jtpc#2101b.cs: Form içi bileþenlere aletipuçlarý yansýtma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class AletÝpuçlarý: Form {
        private FlowLayoutPanel akýþPaneli;
        public AletÝpuçlarý() {Baþlat();}
        private void Baþlat() {
            Text = "AletÝpuçlarý"; //Ortalanan form baþlýk ve ebatý
            ClientSize = new Size (300, 150);
            CenterToScreen();

            akýþPaneli = new FlowLayoutPanel(); //Panelin yaratýlmasý
            new ToolTip().SetToolTip (akýþPaneli, "Bu, form üstü AkýþSerilimPaneli'dir");
            akýþPaneli.Dock = DockStyle.Fill;
            akýþPaneli.BorderStyle = BorderStyle.FixedSingle;

            var buton1 = new Button(); //Butonun yaratýlmasý
            buton1.Text = "Ýlk Düðme"; //Butonüstü baþlýk
            buton1.AutoSize = true;
            new ToolTip().SetToolTip (buton1, "Bu, ilk buton kontroludur"); //Buton alet-ipucu

            var buton2 = new Button();
            buton2.Text = "Ýkinci Düðme";
            buton2.AutoSize = true;
            new ToolTip().SetToolTip (buton2, "Bu, ikinci buton kontroludur");

            akýþPaneli.Controls.Add (buton1); //Düðmeler panele eklenir
            akýþPaneli.Controls.Add (buton2);
            Controls.Add (akýþPaneli); //Panel forma eklenir
        }
        static void Main() {Application.Run (new AletÝpuçlarý());}
    }
}