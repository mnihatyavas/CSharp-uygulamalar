// jtpc#1101.cs: Beþ farklý aduzamýn ayný/farklý adlý sýnýf ve metodunu çaðýrma örneði.

using System;
using DördüncüAduzam;
using BeþinciAduzam;

namespace ÝlkAduzam {public class Selam {public void selamla() {System.Console.WriteLine ("Merhaba ÝlkAduzam");}} } // Ayný sýnýf adlarý
namespace ÝkinciAduzam {public class Selam {public void selamla() {Console.WriteLine ("Merhaba ÝkinciAduzam");}} }
namespace ÜçüncüAduzam {public class Selam {public void selamla() {Console.WriteLine ("Merhaba ÜçüncüAduzam");}} }

namespace DördüncüAduzam {public class Selam4 {public void selamla() {Console.WriteLine ("\nMerhaba DördüncüAduzam");}} } // Farklý sýnýf adlarý
namespace BeþinciAduzam {public class Selam5 {public void selamla() {Console.WriteLine ("Merhaba BeþinciAduzam");}} }

namespace Aduzamlar {
    class Aduzam {
        static void Main() {
            Console.Write ("Aduzam, sýnýflarýn organizasyonunda kullanýlýr. 'using' anahtarkelimesiyle belirtilen aduzamýn artýk sýnýfýnýn baþýnda bulunmasý gerekmez. 'system' .net Framework'ün global aduzamýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ÝlkAduzam.Selam s1 = new ÝlkAduzam.Selam();
            ÝkinciAduzam.Selam s2 = new ÝkinciAduzam.Selam();
            ÜçüncüAduzam.Selam s3 = new ÜçüncüAduzam.Selam();
            s1.selamla(); s2.selamla(); s3.selamla();

            Selam4 s4 = new Selam4();
            Selam5 s5 = new Selam5();
            s4.selamla(); s5.selamla();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}