// jtpc#2101f.cs: Form üstüne Dosya->Kapa (Ctrl-K) menü seçeneklerini kurma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Menü: Form {
        public  Menü() {
            Text = "Basit Menü";
            var ms = new MenuStrip();
            ms.Parent = this;
            var dosya = new ToolStripMenuItem ("&Dosya");
            var çýk = new ToolStripMenuItem ("&Kapa", null, (a,b)=> Close() );
            çýk.ShortcutKeys = Keys.Control | Keys.K;
            dosya.DropDownItems.Add (çýk);
            ms.Items.Add (dosya);
            MainMenuStrip = ms;
            ClientSize = new Size (200, 100);
            CenterToScreen();
        }
        static void Main() {Application.Run (new Menü());}
    }
}