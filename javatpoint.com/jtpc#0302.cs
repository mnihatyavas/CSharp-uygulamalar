// jtpc#0302.cs: switch-case-default ile say�n�n tespiti �rne�i.

using System;
namespace Control�fadeleri {
    class Switch {
        static void D��me (int n) {
            switch (n) {// B�y�kharfle ba�layan anahtarkelimeler kullan�labilir
                default:
                    if (n < 0) Console.WriteLine ("Say� < 0: {0}", n);
                    else if (n < 11) Console.WriteLine ("6 <= Say� <= 10: {0}", n);
                    else Console.WriteLine ("6 <= Say�: {0}", n);
                    break;
                case 0: Console.WriteLine ("Say�: {0}", n); break;
                case 1: Console.WriteLine ("Say�: {0}", n); break;
                case 2: Console.WriteLine ("Say�: {0}", n); break;
                case 3: Console.WriteLine ("Say�: {0}", n); break;
                case 4: Console.WriteLine ("Say�: {0}", n); break;
                case 5: Console.WriteLine ("Say�: {0}", n); break;
            }
        }
        static void Main () {
            Console.Write ("switch-case-default ifadesinin i�leyi�i if-else if...-else'e benzer. Default sona gelmek zorunda de�ildir ve sonda da olsa 'break' gereklidir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int r, tsay�=0;
            for (int i=0; i < 11; i++) {r = rasgele.Next (0, 11); D��me (r);}

            Console.Write ("\nHerhangi bir -+tamsay� gir: ");
            try {tsay� = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            D��me (tsay�);

            son: Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}