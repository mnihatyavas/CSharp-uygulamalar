// jtpc#2101f.cs: Form �st�ne Dosya->Kapa (Ctrl-K) men� se�eneklerini kurma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Men�: Form {
        public  Men�() {
            Text = "Basit Men�";
            var ms = new MenuStrip();
            ms.Parent = this;
            var dosya = new ToolStripMenuItem ("&Dosya");
            var ��k = new ToolStripMenuItem ("&Kapa", null, (a,b)=> Close() );
            ��k.ShortcutKeys = Keys.Control | Keys.K;
            dosya.DropDownItems.Add (��k);
            ms.Items.Add (dosya);
            MainMenuStrip = ms;
            ClientSize = new Size (200, 100);
            CenterToScreen();
        }
        static void Main() {Application.Run (new Men�());}
    }
}