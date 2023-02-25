// jtpc#2101j.cs: �� se�enekli mesajkutu sonu�lar�n� i�leme �rne�i.

using System.Windows.Forms;
namespace Formlar {
    public class MesajKutusu {
        public static void Main() {
            var cevap = MessageBox.Show (
                "Yeni bir dosya yaratmak istiyor musun?",
                "Mesaj Kutusu",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) {MessageBox.Show ("Dosyan�z yarat�l�yor...");
            }else if (cevap == DialogResult.No) {MessageBox.Show ("Dosyan�z yarat�lm�yor.");
            }else {MessageBox.Show ("��lem iptal edildi.");}
        }
    }
}