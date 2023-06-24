// j2sc#0208.cs: Tamsayýnýn ondalýk, hexa, parasal, üslü, küsürlü, virgüllü ve yüzde biçimlenme örneði.

using System;
using System.Globalization;
namespace VeriTipleri {
    class TamsayýBiçim {
        static void Main() {
            Console.Write ("Tamsayý biçimlenme -+ çeþitleri D:Decimal/Ondalýk, H:Hexadecimal/Onaltýlýk, C:Currency/Parasal, E:Exponent/Üslü, F:Float/Küsüratlý, N:NoktaAyraçlý ve P:Percent/Yüzde kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random(); int ts;
            Console.WriteLine ("D:Ondalýk, X:Hexa, C:Parasal, E:Üslü, F:Küsürlü, N:Virgüllü, P:Yüzde\n{0}", "--------------------------------------------------------------------------");
            for (int i=0; i<10; i++) {
                ts=r.Next (-10000, 10000);
                Console.WriteLine ("{0:D}; {1:X}; {2:C}; {3:E3}; {4:F}; {5:N}; {6:P0}", ts, ts, ts.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")), ts, ts, ts, ts);
            }

            ts=r.Next (-10000, 10000);
            string dzg = ts.ToString ("X"); Console.WriteLine ("\nHexa 'X' dizgeye çevrilen tamsayý: " + dzg);
            dzg = ts.ToString ("D12"); Console.WriteLine ("Decimal 'D12' dizgeye çevrilen tamsayý: " + dzg);
            
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}