// jtpc#2101g.cs: Form �st�ne grafikle 9 boyal� dikd�rtgen koyma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Dikdortgenler: Form {
        public Dikdortgenler() {Ba�lat();}
        private void Ba�lat() {
            Text = "Boyal� Dikd�rtgenler";
            Paint += new PaintEventHandler (Boyamal�Kutular);
            ClientSize = new Size (360, 280);
            CenterToScreen();
        }
        void Boyamal�Kutular (object g�nderen, PaintEventArgs olay) {
            Graphics g = olay.Graphics;
            g.FillRectangle (Brushes.Sienna, 10, 15, 90, 60); //(renk, x1,y1, +x,+y)
            g.FillRectangle (Brushes.Green, 130, 15, 90, 60);
            g.FillRectangle (Brushes.Maroon, 250, 15, 90, 60);
            g.FillRectangle (Brushes.Chocolate, 10, 105, 90, 60);
            g.FillRectangle (Brushes.Gray, 130, 105, 90, 60);
            g.FillRectangle (Brushes.Coral, 250, 105, 90, 60);
            g.FillRectangle (Brushes.Brown, 10, 195, 90, 60);
            g.FillRectangle (Brushes.Teal, 130, 195, 90, 60);
            g.FillRectangle (Brushes.Goldenrod, 250, 195, 90, 60);
        }
        static void Main() {Application.Run (new Dikdortgenler() );}
    }
}