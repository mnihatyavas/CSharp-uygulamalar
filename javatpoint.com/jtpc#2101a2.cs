// jtpc#2101a2.cs: Windows.Forms ile ekrana ba�l�kl� ortalanm�� bir form kondurma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class FormumB: Form {
        public FormumB() {Ba�lat();}
        private void Ba�lat() {
            Text = "�lk form uygulamas�";
            ClientSize = new Size (400, 150);
            CenterToScreen();
        }
        static void Main() {Application.Run (new FormumB());}
    }
}