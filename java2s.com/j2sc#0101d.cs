// j2sc#0101d.cs: C# '.dll' kütüphaneleriyle derleme örneði.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace DilTemelleri {
    class Giriþ4: Form {
        public Giriþ4(){
            Text = "Boþ Form";
            BackColor = Color.Black;
            CenterToScreen();
        }
        public static void Main() {
            Console.Write ("Detaylý komut satýrý: 'csc /r:System.DLL /r:System.Windows.Forms.DLL /r:System.Drawing.DLL j2sc#0101d.cs' yada kýsaca 'csc j2sc#0101d.cs' yeterlidir. Program varsayýlý path ile kütüphaneleri kendisi otomatikmen bulur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bu bir basit 'Boþ Form' yaratma programýdýr.");
            Application.Run (new Giriþ4() );

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}