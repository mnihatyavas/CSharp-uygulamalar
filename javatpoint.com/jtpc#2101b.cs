// jtpc#2101b.cs: Form i�i bile�enlere aletipu�lar� yans�tma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Alet�pu�lar�: Form {
        private FlowLayoutPanel ak��Paneli;
        public Alet�pu�lar�() {Ba�lat();}
        private void Ba�lat() {
            Text = "Alet�pu�lar�"; //Ortalanan form ba�l�k ve ebat�
            ClientSize = new Size (300, 150);
            CenterToScreen();

            ak��Paneli = new FlowLayoutPanel(); //Panelin yarat�lmas�
            new ToolTip().SetToolTip (ak��Paneli, "Bu, form �st� Ak��SerilimPaneli'dir");
            ak��Paneli.Dock = DockStyle.Fill;
            ak��Paneli.BorderStyle = BorderStyle.FixedSingle;

            var buton1 = new Button(); //Butonun yarat�lmas�
            buton1.Text = "�lk D��me"; //Buton�st� ba�l�k
            buton1.AutoSize = true;
            new ToolTip().SetToolTip (buton1, "Bu, ilk buton kontroludur"); //Buton alet-ipucu

            var buton2 = new Button();
            buton2.Text = "�kinci D��me";
            buton2.AutoSize = true;
            new ToolTip().SetToolTip (buton2, "Bu, ikinci buton kontroludur");

            ak��Paneli.Controls.Add (buton1); //D��meler panele eklenir
            ak��Paneli.Controls.Add (buton2);
            Controls.Add (ak��Paneli); //Panel forma eklenir
        }
        static void Main() {Application.Run (new Alet�pu�lar�());}
    }
}