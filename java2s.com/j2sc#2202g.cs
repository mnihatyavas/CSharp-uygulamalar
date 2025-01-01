// j2sc#2202g.cs: All ve Any'yle diziyi tümden yada enazbir ile irdeleme örneði.

using System;
using System.Linq; //All() ve Any() için
using System.Collections.Generic; //List<> için
namespace LinqMetot {
    class Bayii {
        public string No {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro;
    }
    class All_Any {
        static void Main() {
            Console.Write ("bool dizi.All()/Any() dizideki tüm yada herhangibir true/false kriterini irdeler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Adlarýn hepsine ve herhangi birine dair true/false kriter:");
            string[] adlar = {"Fatma", "Bekir", "Haným", "Memet", "Hatice", "Süheyla", "Zeliha", "Nihat", "Songül", "Nedim", "Sevim"};
            foreach(var ad in adlar) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("Tüm adlarýn uzunluðu == 5 mi? : " + adlar.All (a => a.Length == 5));
            Console.WriteLine ("Herhangi bir adýn uzunluðu == 5 mi? : " + adlar.Any (a => a.Length == 5));

            Console.WriteLine ("\nVerili yýllarýn hepsinin veya herhangibirinin tek/çift sayý kriteri:");
            int[] yýllar = {1881, 1914, 1919, 1920, 1923, 1938};
            foreach(var yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("Yýllarýn hepsi çiftsayý mý? {0}", yýllar.All (y => y % 2 == 0) ? "Evet" : "Hayýr");
            Console.WriteLine ("Yýllarýn hepsi teksayý mý? {0}", yýllar.All (y => y % 2 == 01) ? "Evet" : "Hayýr");
            Console.WriteLine ("Yýllarýn herhangi biri çiftsayý mý? {0}", yýllar.Any (y => y % 2 == 0) ? "Evet" : "Hayýr");
            Console.WriteLine ("Yýllarýn herhangi biri teksayý mý? {0}", yýllar.Any (y => y % 2 == 01) ? "Evet" : "Hayýr");

            Console.WriteLine ("\nBayiler listesine dair kýta ve ciro kriterleri:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", Þehir="Tahran", Ülke="Ýran", Kýta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("Tüm bayiler Asya'da mý? {0}", bayiler.All (k => k.Kýta == "Asya")?"EVET":"HAYIR");
            Console.WriteLine ("Herhangibir bayii Asya'da mý? {0}", bayiler.Any (k => k.Kýta == "Asya")?"EVET":"HAYIR");
            Console.WriteLine ("Tüm bayilerin cirosu > $2000 mý? {0}", bayiler.All (k => k.Ciro > 2000m)?"EVET":"HAYIR");
            Console.WriteLine ("Herhangibir bayinin cirosu > $10000 mý? {0}", bayiler.Any (k => k.Ciro > 10000m)?"EVET":"HAYIR");

            Console.WriteLine ("\nAny() ile birkaç potpori:");
            Console.WriteLine ("Adlarýn herhangibiri 'at' ibaresi içeriyor mu? {0}", adlar.Any (a => a.Contains ("at"))?"Evet":"Hayýr");
            Console.WriteLine ("Adlarýn herhangibiri 'ze' ibaresiyle baþlýyor mu? {0}", adlar.Any (a => a.ToLower().StartsWith ("ze"))?"Evet":"Hayýr");
            Console.WriteLine ("Yýllar dizisinin hiç elemaný var mý? {0}", yýllar.Any()?"Evet":"Hayýr");
            Console.WriteLine ("Bayilerin ülkeinde hiç 'ABD' var mý? {0}", bayiler.Any (b => b.Ülke == "ABD")?"Evet":"Hayýr");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}