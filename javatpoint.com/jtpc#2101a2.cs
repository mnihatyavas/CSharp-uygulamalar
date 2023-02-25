// jtpc#2101a2.cs: Windows.Forms ile ekrana baþlýklý ortalanmýþ bir form kondurma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class FormumB: Form {
        public FormumB() {Baþlat();}
        private void Baþlat() {
            Text = "Ýlk form uygulamasý";
            ClientSize = new Size (400, 150);
            CenterToScreen();
        }
        static void Main() {Application.Run (new FormumB());}
    }
}