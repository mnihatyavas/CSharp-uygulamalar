// jtpc#2101j.cs: Üç seçenekli mesajkutu sonuçlarýný iþleme örneði.

using System.Windows.Forms;
namespace Formlar {
    public class MesajKutusu {
        public static void Main() {
            var cevap = MessageBox.Show (
                "Yeni bir dosya yaratmak istiyor musun?",
                "Mesaj Kutusu",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) {MessageBox.Show ("Dosyanýz yaratýlýyor...");
            }else if (cevap == DialogResult.No) {MessageBox.Show ("Dosyanýz yaratýlmýyor.");
            }else {MessageBox.Show ("Ýþlem iptal edildi.");}
        }
    }
}