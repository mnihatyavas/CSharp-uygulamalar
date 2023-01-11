// jtpc#0207.cs: Ýþlemi gruplarý, sembolleri, öncelikleri ve yönleri örneði.

using System;
namespace CSEðitimi {
    class Ýþlemcler {
        static void Main () {
            Console.Write ("Ýþlemciler çeþitli iþlemleri yapan sembollerdir. Bunlar: aritmetik (+, -, *, /, %), iliþkisel (<, <=, >, >=, ==, !=), mantýksal (&&, ||, !), bitsel (&, |, <<, >>, ~, ^), atama (=, +=, -=, *=, /=, %=), birli (++, --), üçlü (?:), diðer.\nÝþlemci önceliði (artan önem ve BS/BaþtanSona yada SB): birli (+ - ! ~ ++ -- (type)* & sizeof, SB), toplam (+ -, BS), çarp (% / *, BS), iliþki (< > <= >=, BS), kaydýr (<< >>, BS), eþitlik (== !=, SB), mantýksal ve-veya-farklýysa (& | ^, BS), þart ve-veya (&& ||, BS), hiçe çök (??, BS), üçlü (?:, SB), atama (= *= /= %= += - = <<= >>= &= ^= |= =>, SB).\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}