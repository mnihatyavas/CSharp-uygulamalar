// j2sc#0208.cs: Tamsay�n�n ondal�k, hexa, parasal, �sl�, k�s�rl�, virg�ll� ve y�zde bi�imlenme �rne�i.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Tamsay�Bi�im {
        static void Main() {
            Console.Write ("Tamsay� bi�imlenme -+ �e�itleri D:Decimal/Ondal�k, H:Hexadecimal/Onalt�l�k, C:Currency/Parasal, E:Exponent/�sl�, F:Float/K�s�ratl�, N:NoktaAyra�l� ve P:Percent/Y�zde kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random(); int ts;
            Console.WriteLine ("D:Ondal�k, X:Hexa, C:Parasal, E:�sl�, F:K�s�rl�, N:Virg�ll�, P:Y�zde\n{0}", "--------------------------------------------------------------------------");
            for (int i=0; i<10; i++) {
                ts=r.Next (-10000, 10000);
                Console.WriteLine ("{0:D}; {1:X}; {2:C}; {3:E3}; {4:F}; {5:N}; {6:P0}", ts, ts, ts.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")), ts, ts, ts, ts);
            }

            ts=r.Next (-10000, 10000);
            string dzg = ts.ToString ("X"); Console.WriteLine ("\nHexa 'X' dizgeye �evrilen tamsay�: " + dzg);
            dzg = ts.ToString ("D12"); Console.WriteLine ("Decimal 'D12' dizgeye �evrilen tamsay�: " + dzg);
            
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}