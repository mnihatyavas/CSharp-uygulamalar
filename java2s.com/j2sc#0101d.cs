// j2sc#0101d.cs: C# '.dll' k�t�phaneleriyle derleme �rne�i.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace DilTemelleri {
    class Giri�4: Form {
        public Giri�4(){
            Text = "Bo� Form";
            BackColor = Color.Black;
            CenterToScreen();
        }
        public static void Main() {
            Console.Write ("Detayl� komut sat�r�: 'csc /r:System.DLL /r:System.Windows.Forms.DLL /r:System.Drawing.DLL j2sc#0101d.cs' yada k�saca 'csc j2sc#0101d.cs' yeterlidir. Program varsay�l� path ile k�t�phaneleri kendisi otomatikmen bulur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bu bir basit 'Bo� Form' yaratma program�d�r.");
            Application.Run (new Giri�4() );

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}