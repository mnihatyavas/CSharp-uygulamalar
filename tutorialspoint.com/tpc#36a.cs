// tpc#36a.cs: Soysal sýnýf tiplemesiyle tamsayý, krk ve dizge diziler iþleme örneði.

using System;
using System.Collections.Generic;
namespace Soysallar {
    public class SoysalDizi<Tip> {
        private Tip[] dizi;
        public SoysalDizi (int ebat) {dizi = new Tip [ebat + 1];}
        public Tip diziElemanýnýAl (int endeks) {return dizi [endeks];}
        public void diziElemanýnýKoy (int endeks, Tip deðer) {dizi [endeks] = deðer;}
    }
    class SoysalSýnýf {
        static void Main() {
            Console.Write ("Soysal<Tip>, sýnýf veya metod tipinin (ve diziyse ebatýnýn) program çalýþmasý esnasýnda çoklu-farklý tanýmlanýp, tanýmlanan tipine uygun verilerin iþlenmesine imkan tanýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            SoysalDizi<int> tamsayýDizi = new SoysalDizi<int> (5); // Tamsayý dizi beyaný
            for (int i = 0; i < 5; i++) {tamsayýDizi.diziElemanýnýKoy (i, i * 5);} // Tamsayý dizi elamanlarý koyma
            Console.Write ("Tamsayý dizi elemanlarý: ");
            for (int i = 0; i < 5; i++) {Console.Write (tamsayýDizi.diziElemanýnýAl (i) + " ");} // Tamsayý dizi elamanlarý alma

            Console.Write ("\nKarakter dizi elemanlarý: ");
            SoysalDizi<char> krkDizi = new SoysalDizi<char> (10);
            for (int i = 0; i < 10; i++) {krkDizi.diziElemanýnýKoy (i, (char)(i+97));}
            for (int i = 0; i< 10; i++) {Console.Write (krkDizi.diziElemanýnýAl (i) + " ");}

            Console.Write ("\nDizge dizi elemanlarý: ");
            SoysalDizi<string> dizgeDizi = new SoysalDizi<string> (4);
            for (int i = 0; i < 4; i++) {dizgeDizi.diziElemanýnýKoy (i, "mny"+i);}
            for (int i = 0; i< 4; i++) {Console.Write (dizgeDizi.diziElemanýnýAl (i) + " ");}

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    }
}