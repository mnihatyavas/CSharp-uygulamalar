// j2sc#2202g.cs: All ve Any'yle diziyi t�mden yada enazbir ile irdeleme �rne�i.

using System;
using System.Linq; //All() ve Any() i�in
using System.Collections.Generic; //List<> i�in
namespace LinqMetot {
    class Bayii {
        public string No {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro;
    }
    class All_Any {
        static void Main() {
            Console.Write ("bool dizi.All()/Any() dizideki t�m yada herhangibir true/false kriterini irdeler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Adlar�n hepsine ve herhangi birine dair true/false kriter:");
            string[] adlar = {"Fatma", "Bekir", "Han�m", "Memet", "Hatice", "S�heyla", "Zeliha", "Nihat", "Song�l", "Nedim", "Sevim"};
            foreach(var ad in adlar) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("T�m adlar�n uzunlu�u == 5 mi? : " + adlar.All (a => a.Length == 5));
            Console.WriteLine ("Herhangi bir ad�n uzunlu�u == 5 mi? : " + adlar.Any (a => a.Length == 5));

            Console.WriteLine ("\nVerili y�llar�n hepsinin veya herhangibirinin tek/�ift say� kriteri:");
            int[] y�llar = {1881, 1914, 1919, 1920, 1923, 1938};
            foreach(var y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("Y�llar�n hepsi �iftsay� m�? {0}", y�llar.All (y => y % 2 == 0) ? "Evet" : "Hay�r");
            Console.WriteLine ("Y�llar�n hepsi teksay� m�? {0}", y�llar.All (y => y % 2 == 01) ? "Evet" : "Hay�r");
            Console.WriteLine ("Y�llar�n herhangi biri �iftsay� m�? {0}", y�llar.Any (y => y % 2 == 0) ? "Evet" : "Hay�r");
            Console.WriteLine ("Y�llar�n herhangi biri teksay� m�? {0}", y�llar.Any (y => y % 2 == 01) ? "Evet" : "Hay�r");

            Console.WriteLine ("\nBayiler listesine dair k�ta ve ciro kriterleri:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", �ehir="Tahran", �lke="�ran", K�ta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("T�m bayiler Asya'da m�? {0}", bayiler.All (k => k.K�ta == "Asya")?"EVET":"HAYIR");
            Console.WriteLine ("Herhangibir bayii Asya'da m�? {0}", bayiler.Any (k => k.K�ta == "Asya")?"EVET":"HAYIR");
            Console.WriteLine ("T�m bayilerin cirosu > $2000 m�? {0}", bayiler.All (k => k.Ciro > 2000m)?"EVET":"HAYIR");
            Console.WriteLine ("Herhangibir bayinin cirosu > $10000 m�? {0}", bayiler.Any (k => k.Ciro > 10000m)?"EVET":"HAYIR");

            Console.WriteLine ("\nAny() ile birka� potpori:");
            Console.WriteLine ("Adlar�n herhangibiri 'at' ibaresi i�eriyor mu? {0}", adlar.Any (a => a.Contains ("at"))?"Evet":"Hay�r");
            Console.WriteLine ("Adlar�n herhangibiri 'ze' ibaresiyle ba�l�yor mu? {0}", adlar.Any (a => a.ToLower().StartsWith ("ze"))?"Evet":"Hay�r");
            Console.WriteLine ("Y�llar dizisinin hi� eleman� var m�? {0}", y�llar.Any()?"Evet":"Hay�r");
            Console.WriteLine ("Bayilerin �lkeinde hi� 'ABD' var m�? {0}", bayiler.Any (b => b.�lke == "ABD")?"Evet":"Hay�r");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}