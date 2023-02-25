// jtpc#2101i.cs: Renk diyaloðunda seçilen renk kodunun sunulmasý örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class RenkDiyaloðu {
        public static void Main() {
            var renkPaleti = new ColorDialog();
            renkPaleti.AnyColor = true;
            //renkPaleti.ShowHelp = true;
            var aktüelRenk = Color.BlueViolet;
            if (renkPaleti.ShowDialog() != DialogResult.Cancel)  {
                aktüelRenk = renkPaleti.Color;
                string seçilenRenk = renkPaleti.Color.ToString();
                MessageBox.Show ("Seçilen renk: " + seçilenRenk);
            }
        }
    }
}