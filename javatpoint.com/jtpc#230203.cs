// jtpc#230203.cs: LINQ sorgu ifadesiyle tikel sayýlarý ve öðrencileri filitreleme örneði.

using System;
using System.Linq;
using System.Collections.Generic;
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ýsim {get; set;}
        public string Eposta {get; set;}
        public static List<Öðrenci> ÖðrencileriAl() {
            List<Öðrenci> öðrenciler = new List<Öðrenci>();
            var öðrenci1 = new Öðrenci {No = 101, Ýsim = "Hatice Yavaþ", Eposta = "htyavas@misal.com"};
            var öðrenci2 = new Öðrenci {No = 102, Ýsim = "Süleyha Yavaþ", Eposta = "slyavas@misal.com"};
            var öðrenci3 = new Öðrenci {No = 103, Ýsim = "Nihal Yavaþ", Eposta = "nhyavas@misal.com"};
            var öðrenci4 = new Öðrenci {No = 104, Ýsim = "Songül Yavaþ", Eposta = "snyavas@misal.com"};
            var öðrenci5 = new Öðrenci {No = 105, Ýsim = "Sevim Yavaþ", Eposta = "svyavas@misal.com"};
            öðrenciler.Add (öðrenci1); öðrenciler.Add (öðrenci2); öðrenciler.Add (öðrenci3); öðrenciler.Add (öðrenci4); öðrenciler.Add (öðrenci5);
            return öðrenciler;
        }
    }
    class SorguÝfadesi {
        static void Main() {
            Console.Write ("LINQ/LanguageIntegratedQuery/EntegreSorguDili ifadesi SQL/SearchQueryLanquage/SorguDiliAramasý'na benzer, from'la baþlar ve select veya group'la biter. IEnumerable tip deðiþkeniyle foreach taramasý yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int[] tamsayýDizi = new int [50];
            var r = new Random();
            for (int i=0; i  < tamsayýDizi.Length; i++) tamsayýDizi [i] = r.Next (-10000, 10000);
            IEnumerable<int> tikeller = //Sorgu ifadesi
                from seç in tamsayýDizi
                where (seç % 2) != 0
                select seç;
            Console.WriteLine ("{0} -+rasgele sayýdan tek sayýlýlar:", tamsayýDizi.Length);
            int j=0; foreach (int tikel in tikeller) {Console.Write ("{0}:[{1}], ", ++j, tikel);}

            IEnumerable<string> sorgu1 =
                from öðr in Öðrenci.ÖðrencileriAl()
                where öðr.Ýsim [0].Equals ('S')
                select (öðr.No + " öðrenci no'lu " + öðr.Ýsim + "'ýn epostasý: " + öðr.Eposta);
            Console.WriteLine ("\n\n5 öðrenci içinde adlarý 'S' ile baþlayanlar:");
            foreach (var ö in sorgu1) Console.WriteLine (ö);

            IEnumerable<string> sorgu2 =
                from öðr in Öðrenci.ÖðrencileriAl()
                where (öðr.Ýsim [0].Equals ('H') | öðr.Ýsim [0].Equals ('N'))
                select (öðr.No + " öðrenci no'lu " + öðr.Ýsim + "'ýn epostasý: " + öðr.Eposta);
            Console.WriteLine ("\n5 öðrenci içinde adlarý 'H' veya 'N' ile baþlayanlar:");
            foreach (var ö in sorgu2) Console.WriteLine (ö);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}