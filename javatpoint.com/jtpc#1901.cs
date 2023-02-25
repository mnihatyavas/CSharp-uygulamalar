// jtpc#1901.cs: Parametreli ve parametresiz anonim delegeli fonksiyonlar �rne�i.

using System;
namespace AnonimFonksiyon {
    class Anonimfonksiyon {
        delegate int Kare (int n);
        delegate void Selam();
        static void Main() {
            Console.Write ("Ad� olmayan fonksiyona anonim fonksiyon denir. �ki t�r� vard�r: Lambda ifadesi, anonim metod.\nDelege tipli lambda ifadesiyle yerel de�i�ken arg�man olarak ge�irilir.\nAnonim metod da labda gibidir, ancak parametresizdir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Kare KaresiniHesapla = x => x * x; //Lambda ifadesi
            Console.WriteLine ("{0}'in karesi = {1}", 5, KaresiniHesapla (5));
            Console.WriteLine ("{0}'un karesi = {1}", 579, KaresiniHesapla (579));

            Selam Mesaj = delegate() {Console.WriteLine ("\nParametresiz anonim fonksiyondan selamlar!");};
            Mesaj();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}