// jtpc#0207.cs: ��lemi gruplar�, sembolleri, �ncelikleri ve y�nleri �rne�i.

using System;
namespace CSE�itimi {
    class ��lemcler {
        static void Main () {
            Console.Write ("��lemciler �e�itli i�lemleri yapan sembollerdir. Bunlar: aritmetik (+, -, *, /, %), ili�kisel (<, <=, >, >=, ==, !=), mant�ksal (&&, ||, !), bitsel (&, |, <<, >>, ~, ^), atama (=, +=, -=, *=, /=, %=), birli (++, --), ��l� (?:), di�er.\n��lemci �nceli�i (artan �nem ve BS/Ba�tanSona yada SB): birli (+ - ! ~ ++ -- (type)* & sizeof, SB), toplam (+ -, BS), �arp (% / *, BS), ili�ki (< > <= >=, BS), kayd�r (<< >>, BS), e�itlik (== !=, SB), mant�ksal ve-veya-farkl�ysa (& | ^, BS), �art ve-veya (&& ||, BS), hi�e ��k (??, BS), ��l� (?:, SB), atama (= *= /= %= += - = <<= >>= &= ^= |= =>, SB).\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}