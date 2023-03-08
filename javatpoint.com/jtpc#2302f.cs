// jtpc#2302f.cs: Ýlk yaratým deðerlemesiyle nesne ve koleksiyon kayýtlarý atama örneði.

using System;
using System.Collections.Generic;
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ýsim {get; set;}
        public string Eposta {get; set;}
    }
    class NesneKoleksiyonÝlkdeðerleme {
        static void Main() {
            Console.Write ("Nesne ilkdeðerleyici, sýnýf üye deðiþkenlerine ilk yaratýmda deðer atar. Keza koleksiyon elemanlarý da 'add' ile deðil ilk yaratým deðerlemeleriyle ardýþýk eklenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new Öðrenci {No = 101, Ýsim = "Hatice Yavaþ", Eposta = "htyavas@misal.com"};
            var öðrenci2 = new Öðrenci {No = 102, Ýsim = "Süleyha Yavaþ", Eposta = "slyavas@misal.com"};
            Console.WriteLine ("{0} öðrenci no'lu {1}'ýn eposta adresi: {2}", öðrenci1.No, öðrenci1.Ýsim, öðrenci1.Eposta);
            Console.WriteLine ("{0} öðrenci no'lu {1}'ýn eposta adresi: {2}\n", öðrenci2.No, öðrenci2.Ýsim, öðrenci2.Eposta);

            var öðrenciler = new List<Öðrenci> {
                new Öðrenci {No = 103, Ýsim = "Nihal Yavaþ", Eposta = "nhyavas@misal.com"},
                new Öðrenci {No = 104, Ýsim = "Songül Yavaþ", Eposta = "snyavas@misal.com"},
                new Öðrenci {No = 105, Ýsim = "Sevim Yavaþ", Eposta = "svyavas@misal.com"}
            };
            foreach (Öðrenci ö in öðrenciler) {Console.WriteLine ("{0} öðrenci no'lu {1}'ýn eposta adresi: {2}", ö.No, ö.Ýsim, ö.Eposta);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}