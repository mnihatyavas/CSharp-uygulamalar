// jtpc#230203.cs: LINQ sorgu ifadesiyle tikel say�lar� ve ��rencileri filitreleme �rne�i.

using System;
using System.Linq;
using System.Collections.Generic;
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string �sim {get; set;}
        public string Eposta {get; set;}
        public static List<��renci> ��rencileriAl() {
            List<��renci> ��renciler = new List<��renci>();
            var ��renci1 = new ��renci {No = 101, �sim = "Hatice Yava�", Eposta = "htyavas@misal.com"};
            var ��renci2 = new ��renci {No = 102, �sim = "S�leyha Yava�", Eposta = "slyavas@misal.com"};
            var ��renci3 = new ��renci {No = 103, �sim = "Nihal Yava�", Eposta = "nhyavas@misal.com"};
            var ��renci4 = new ��renci {No = 104, �sim = "Song�l Yava�", Eposta = "snyavas@misal.com"};
            var ��renci5 = new ��renci {No = 105, �sim = "Sevim Yava�", Eposta = "svyavas@misal.com"};
            ��renciler.Add (��renci1); ��renciler.Add (��renci2); ��renciler.Add (��renci3); ��renciler.Add (��renci4); ��renciler.Add (��renci5);
            return ��renciler;
        }
    }
    class Sorgu�fadesi {
        static void Main() {
            Console.Write ("LINQ/LanguageIntegratedQuery/EntegreSorguDili ifadesi SQL/SearchQueryLanquage/SorguDiliAramas�'na benzer, from'la ba�lar ve select veya group'la biter. IEnumerable tip de�i�keniyle foreach taramas� yapar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int[] tamsay�Dizi = new int [50];
            var r = new Random();
            for (int i=0; i  < tamsay�Dizi.Length; i++) tamsay�Dizi [i] = r.Next (-10000, 10000);
            IEnumerable<int> tikeller = //Sorgu ifadesi
                from se� in tamsay�Dizi
                where (se� % 2) != 0
                select se�;
            Console.WriteLine ("{0} -+rasgele say�dan tek say�l�lar:", tamsay�Dizi.Length);
            int j=0; foreach (int tikel in tikeller) {Console.Write ("{0}:[{1}], ", ++j, tikel);}

            IEnumerable<string> sorgu1 =
                from ��r in ��renci.��rencileriAl()
                where ��r.�sim [0].Equals ('S')
                select (��r.No + " ��renci no'lu " + ��r.�sim + "'�n epostas�: " + ��r.Eposta);
            Console.WriteLine ("\n\n5 ��renci i�inde adlar� 'S' ile ba�layanlar:");
            foreach (var � in sorgu1) Console.WriteLine (�);

            IEnumerable<string> sorgu2 =
                from ��r in ��renci.��rencileriAl()
                where (��r.�sim [0].Equals ('H') | ��r.�sim [0].Equals ('N'))
                select (��r.No + " ��renci no'lu " + ��r.�sim + "'�n epostas�: " + ��r.Eposta);
            Console.WriteLine ("\n5 ��renci i�inde adlar� 'H' veya 'N' ile ba�layanlar:");
            foreach (var � in sorgu2) Console.WriteLine (�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}