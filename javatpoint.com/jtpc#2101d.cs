// jtpc#2101d.cs: Formu þiirli etiket ebeveyni olarak kullanma örneði.

using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    public class Etiket: Form {
        public Etiket() {Baþlat();}
        private void Baþlat() {
            string metin = @"
Vaktimi harcýyorum
Geçen günleri seyrediyorum
Çok az hissediyorum, duvara bakarak
Senin beni düþünmeni umuyorum
Vaktimi harcýyorum

Telefon etsem ne diyeceðimi bilmiyorum
Telesekreterine bir buse býrakýyorum
Oh, lütfen yardým eecek kimse yok mu
Beni bu rüyadan uyandýracak?
";
            var þiir = new Label();
            þiir.Parent = this;
            þiir.Text = metin;
            þiir.Font = new Font ("Serif", 10);
            þiir.Location = new Point (10, 10);
            þiir.AutoSize = true;
            Text = "Güfteli Etiket";
            ClientSize = new Size (300, 200);
            //AutoSize = true;
            CenterToScreen();
        }
        static void Main() {Application.Run (new Etiket());}
    }
}