// jtpc#230204.cs: Kısmi sınıflardaki kısmi metodla mesajlar yansıtma örneği.

using System;
namespace YeniÖzellikler {
    partial class KısmiMetod {partial void mesajıGöster (string mesaj);}
    partial class KısmiMetod {partial void mesajıGöster (String m) {Console.WriteLine (m);}
        static void Main() {
            Console.Write ("Kısmi metod iki ayrı (aynı adlı) kısmi sınıfta tanımlanır; ilkinde sadece imzası, ikincide bütün tanımlaması yapılır. Dönen 'void' olup erişimi içsel 'private'dir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            new KısmiMetod().mesajıGöster ("www.javatpoint.com'a hoşgeldiniz.");
            new KısmiMetod().mesajıGöster ("Kısmi metodla mesaj beyanını görmektesiniz.");
            new KısmiMetod().mesajıGöster ("Bir sonraki derste görüşmek üzere, hoşçakalın.");

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    }
}