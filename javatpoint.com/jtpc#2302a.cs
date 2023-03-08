// jtpc#2302a.cs: Anonim tipli kayýtlara deðer atama veya koleksiyon sorgusunda kullanma örneði.

using System;
using System.Collections.Generic;
using System.Linq; //Sorgu (from-select) gerektirir
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ýsim {get; set;}
        public string Eposta {get; set;}
    }
    class AnonimTip {
        static void Main() {
            Console.Write ("Anonim tip 'new' anahtarkelimesiyle yaratýlan bir nesne olup, doðrudan özellik=deðer atamalarý yapýlabilir. Koleksiyon sorgularýnda da kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new {No = 101, Ýsim = "Hatice Yavaþ", Eposta = "htyavas@misal.com"}; //Anonim tip
            var öðrenci2 = new {No = 102, Ýsim = "Süleyha Yavaþ", Eposta = "slyavas@misal.com"};
            var öðrenci3 = new {No = 103, Ýsim = "Nihal Yavaþ", Eposta = "nhyavas@misal.com"};
            var öðrenci4 = new {No = 104, Ýsim = "Songül Yavaþ", Eposta = "snyavas@misal.com"};
            var öðrenci5 = new {No = 105, Ýsim = "Sevim Yavaþ", Eposta = "svyavas@misal.com"};
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]", öðrenci1.No, öðrenci1.Ýsim, öðrenci1.Eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]", öðrenci2.No, öðrenci2.Ýsim, öðrenci2.Eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]", öðrenci3.No, öðrenci3.Ýsim, öðrenci3.Eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]", öðrenci4.No, öðrenci4.Ýsim, öðrenci4.Eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]\n", öðrenci5.No, öðrenci5.Ýsim, öðrenci5.Eposta);

            var öðrenciler = new List<Öðrenci> {
                new  Öðrenci {No=401, Ýsim="Fatma Yavaþ", Eposta="ftyavas@misal.com"},
                new  Öðrenci {No=402, Ýsim="Bekir Yavaþ", Eposta="bkyavas@misal.com"},
                new  Öðrenci {No=301, Ýsim="Haným Yavaþ", Eposta="hnyavas@misal.com"},
                new  Öðrenci {No=302, Ýsim="Memet Yavaþ", Eposta="mmyavas@misal.com"},
                new  Öðrenci {No=201, Ýsim="M.Nihat Yavaþ", Eposta="niyavas@misal.com"},
                new  Öðrenci {No=202, Ýsim="M.Nedim Yavaþ", Eposta="neyavas@misal.com"},
            };
            var sorgu =
                from öðrenci in öðrenciler
                select new {öðrenci.No, öðrenci.Ýsim, öðrenci.Eposta}; //Anonim tip
            foreach (var öðr in sorgu) {Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: [{2}]", öðr.No, öðr.Ýsim, öðr.Eposta);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}