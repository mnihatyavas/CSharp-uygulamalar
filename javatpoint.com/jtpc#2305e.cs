// jtpc#2305e.cs: 'set'siz oto ilkdeðerlemeyle deðitirilemez özellik örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        public string Ýsim {get; set;} //csc-5 set'siz ilk deðer atamýyor
        public string Eposta {get;set;}
        public Öðrenci() {Ýsim = "M.Nihat Yavaþ"; Eposta = "mnihatyavas@gmail.com";}
    }
    class SetsizÖzellik {
        static void Main() {
            Console.Write ("Sýnýf deðiþken özelliðini set'siz kýlarak ilkdeðerleme harici deðiþtirilemezliði saðlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Öðrenci nesne = new Öðrenci(); Console.WriteLine ("Ýsim ve eposta: [{0} - {1}]", nesne.Ýsim, nesne.Eposta);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}