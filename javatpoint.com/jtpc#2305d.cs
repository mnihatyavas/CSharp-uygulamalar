// jtpc#2305d.cs: Oto ilkdeðerlemeyle özelliðe kurucusuz deðer atama örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci1 {public string Ýsim {get; set;} /*= "Mahmut Nihat Yavaþ";*/}
    class Öðrenci2 {public string Ýsim {get; private set;} public void adKoy(){Ýsim="Mehmet Nihat Yavaþ";}}
    class OtoÝlkdeðerleme {
        public string Ýsim {get; set;}
        OtoÝlkdeðerleme() {Ýsim = "M.Nihat Yavaþ";}
        static void Main() {
            Console.Write ("Önceden sýnýf özellik ilkdeðerleme ayný adlý kurucu metodla yapýlýrken, oto ilkdeðerleme kurucu gerektirmez, hatta private get-set'le harici müdahele de sýnýrlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new OtoÝlkdeðerleme(); Console.WriteLine ("Kuruculu ilkdeðerlemeli isim: [{0}]", nesne1.Ýsim);
            var nesne2 = new Öðrenci1(); nesne2.Ýsim = "Mahmut Nihat Yavaþ"; Console.WriteLine ("Kurucusuz atamalý isim: [{0}]", nesne2.Ýsim);
            var nesne3 = new Öðrenci2(); /*nesne3.Ýsim = "Mehmet Nihat Yavaþ";*/ nesne3.adKoy(); Console.WriteLine ("Kurucusuz ilkdeðerlemeli isim: [{0}]", nesne3.Ýsim);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}