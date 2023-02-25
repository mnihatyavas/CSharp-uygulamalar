// jtpc#230207.cs: Sýnýf özelliklerine 'get-set'le deðer atama-okuma örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ýsim {get; set;}
        public string GSM; // get-set protokolsüz de olabilir
        public string Eposta {get; set;}
    }
    class AlKoyÖzellikler {
        static void Main() {
            Console.Write ("Eriþilebilir sýnýf üye deðiþkenlerine yalýn 'get; set;' anahtarkelimeli özellik atfederek kolayca deðer atama-okuma yürütme kazandýrýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðr = new Öðrenci();
            öðr.No = 1047; öðr.Ýsim = "M.Nihat Yavaþ"; öðr.Eposta = "mnihatyavas@gmail.com"; öðr.GSM = "+90-551-555-95-65";
            Console.WriteLine ("GSM'i {0} olan {1} öðrenci no'lu {2}'ýn eposta adresi: {3}", öðr.GSM, öðr.No, öðr.Ýsim, öðr.Eposta);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}