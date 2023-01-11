// jtpc#0302.cs: switch-case-default ile sayýnýn tespiti örneði.

using System;
namespace ControlÝfadeleri {
    class Switch {
        static void Düðme (int n) {
            switch (n) {// Büyükharfle baþlayan anahtarkelimeler kullanýlabilir
                default:
                    if (n < 0) Console.WriteLine ("Sayý < 0: {0}", n);
                    else if (n < 11) Console.WriteLine ("6 <= Sayý <= 10: {0}", n);
                    else Console.WriteLine ("6 <= Sayý: {0}", n);
                    break;
                case 0: Console.WriteLine ("Sayý: {0}", n); break;
                case 1: Console.WriteLine ("Sayý: {0}", n); break;
                case 2: Console.WriteLine ("Sayý: {0}", n); break;
                case 3: Console.WriteLine ("Sayý: {0}", n); break;
                case 4: Console.WriteLine ("Sayý: {0}", n); break;
                case 5: Console.WriteLine ("Sayý: {0}", n); break;
            }
        }
        static void Main () {
            Console.Write ("switch-case-default ifadesinin iþleyiþi if-else if...-else'e benzer. Default sona gelmek zorunda deðildir ve sonda da olsa 'break' gereklidir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int r, tsayý=0;
            for (int i=0; i < 11; i++) {r = rasgele.Next (0, 11); Düðme (r);}

            Console.Write ("\nHerhangi bir -+tamsayý gir: ");
            try {tsayý = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            Düðme (tsayý);

            son: Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}