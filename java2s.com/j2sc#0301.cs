// j2sc#0301.cs: Tüm c# iþlemcileri, sembolleri ve çeþitleri örneði.

using System;
namespace Ýþlemciler {
    class TümÝþlemciler {
        static void Main() {
            Console.Write ("Tüm iþlemciler ismen: aritmetik, mantýksal, dizgesel ekleme, birartan ve bireksilen, bitsel sola/saða kaydýrma, kýyas, atama, üye eriþimi, endeksleme, taksimleme, üçlemeli þart, delege ekleme çýkarma, nesne yaratma, tip bilgisi, taþma istisna kontrolu, dolaylama adres, aduzam arma, hiç çökertme iþlemcileridir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm iþlemciler özetle: 1)Aritmetik (+-*/%), 2)Mantýksal (&|^~&&||!), 3)Dizgesel ekleme (+), 4)Birartan bireksilen (++ --), 5)Bitsel kaydýrma (<< >>), 6)Kýyas (== != <> <= >=), 7)Atama (= += -= *= /= %= &= |= ^= <<= >>=), 8)Üye eriþimi (.), 9)Endeksleme ([]), 10)Taksimleme ('()'), 11)Üçlemeli þart (?:), 12)Delege ekleme çýkarma (+-), 13)Nesne yaratma (new), 14)Tip bilgisi (sizeof is typeof as), 15)Taþma istisna kontrolu (checked unchecked), 16)Dolaylama adres (*->& []), 17)Aduzam arma (::), 18)Hiç çökertme (??)");
            Console.WriteLine ("\nKýsakesek iþlemciler ve eþdeðerleri: 1) x++, ++x, x=x+1; 2) x--, --x, x=x-1; 3) x+=y, x=x+y; 4) x-=y, x=x-y; 5) x*=y, x=x*y; 6) x/=y, x=x/y; 7) x%=y, x=x%y; 8) x>>=y, x=x>>y; 9) x<<=y, x=x<<y; 10) x&=y, x=x&y; 11) x|=y, x=x|y; 12) x^=y, x=x^y");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}