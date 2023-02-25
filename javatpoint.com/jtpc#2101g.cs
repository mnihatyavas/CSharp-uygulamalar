// jtpc#2101g.cs: Form üstüne grafikle 9 boyalý dikdörtgen koyma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Dikdortgenler: Form {
        public Dikdortgenler() {Baþlat();}
        private void Baþlat() {
            Text = "Boyalý Dikdörtgenler";
            Paint += new PaintEventHandler (BoyamalýKutular);
            ClientSize = new Size (360, 280);
            CenterToScreen();
        }
        void BoyamalýKutular (object gönderen, PaintEventArgs olay) {
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