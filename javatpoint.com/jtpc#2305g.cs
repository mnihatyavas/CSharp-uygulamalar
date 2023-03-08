// jtpc#2305g.cs: '?' sembollü doðrudan null nesne kontrolu örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ýsim {get; set;}
        public string Eposta {get; set;}
    }
    class SoruSembolü {
        static void Main() {
            Console.Write ("Nesne null ise eriþim hata vermemesi ya if-null önkontrolu yada ? sembolüyle otomatik açýklama atamalý kontrol yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new Öðrenci() {No=101, Ýsim="Sevim Yavaþ", Eposta = "seyavas@gmail.com"};
            var öðrenci2 = new Öðrenci() {No=102, Ýsim="Songül Yavaþ", Eposta = "soyavas@gmail.com"};
            var öðrenci3 = new Öðrenci();
            if (öðrenci1.Ýsim != null) Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci1.No, öðrenci1.Ýsim.ToUpper(), öðrenci1.Eposta);
            if (öðrenci2.Ýsim != null) Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci2.No, öðrenci2.Ýsim.ToUpper(), öðrenci2.Eposta);
            if (öðrenci3.Ýsim != null) Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci3.No, öðrenci3.Ýsim.ToUpper(), öðrenci3.Eposta);

            //Console.WriteLine ("\n{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci1?.No? ??"Numarasýz", öðrenci1?.Ýsim?.ToUpper() ??"Ýsimsiz", öðrenci1?.Eposta? ??"Epostasýz");
            //Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci2?.No? ??"Numarasýz", öðrenci2?.Ýsim?.ToUpper() ??"Ýsimsiz", öðrenci2?.Eposta? ??"Epostasýz");
            //Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðrenci3?.No? ??"Numarasýz", öðrenci3?.Ýsim?.ToUpper() ??"Ýsimsiz", öðrenci3?.Eposta? ??"Epostasýz");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}