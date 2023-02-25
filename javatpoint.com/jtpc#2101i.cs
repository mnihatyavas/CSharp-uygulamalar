// jtpc#2101i.cs: Renk diyalo�unda se�ilen renk kodunun sunulmas� �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class RenkDiyalo�u {
        public static void Main() {
            var renkPaleti = new ColorDialog();
            renkPaleti.AnyColor = true;
            //renkPaleti.ShowHelp = true;
            var akt�elRenk = Color.BlueViolet;
            if (renkPaleti.ShowDialog() != DialogResult.Cancel)  {
                akt�elRenk = renkPaleti.Color;
                string se�ilenRenk = renkPaleti.Color.ToString();
                MessageBox.Show ("Se�ilen renk: " + se�ilenRenk);
            }
        }
    }
}