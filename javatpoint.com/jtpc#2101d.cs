// jtpc#2101d.cs: Formu �iirli etiket ebeveyni olarak kullanma �rne�i.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Etiket: Form {
        public Etiket() {Ba�lat();}
        private void Ba�lat() {
            string metin = @"
Vaktimi harc�yorum
Ge�en g�nleri seyrediyorum
�ok az hissediyorum, duvara bakarak
Senin beni d���nmeni umuyorum
Vaktimi harc�yorum

Telefon etsem ne diyece�imi bilmiyorum
Telesekreterine bir buse b�rak�yorum
Oh, l�tfen yard�m eecek kimse yok mu
Beni bu r�yadan uyand�racak?
";
            var �iir = new Label();
            �iir.Parent = this;
            �iir.Text = metin;
            �iir.Font = new Font ("Serif", 10);
            �iir.Location = new Point (10, 10);
            �iir.AutoSize = true;
            Text = "G�fteli Etiket";
            ClientSize = new Size (300, 200);
            //AutoSize = true;
            CenterToScreen();
        }
        static void Main() {Application.Run (new Etiket());}
    }
}