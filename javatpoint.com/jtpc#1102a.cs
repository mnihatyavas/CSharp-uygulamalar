// jtpc#1102a.cs: Public belirteçli deðiþken ve fonksiyona eriþim örneði.

using System;
namespace Aduzamlar {
   class PublicEriþim {
        public string isim = "M.Nihat Yavaþ";
        public void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class EriþimDeðiþtireçleri1 {
        static void Main() {
            Console.Write ("Deðiþtireç veya belirteçler, deðiþken ve fonksiyonlarýn nasýl eriþilebilirliðini ve kapsamýný saptar. Enazdan ençok sýnýrlanana doðru 5 farklý belirteç: public/genel, protected/korunan, internal/iç, protected internal, private/özel. Public sýnýrsýz eriþilebilirliði gösterir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            PublicEriþim pe = new PublicEriþim();
            Console.WriteLine ("Merhabalar " + pe.isim); //public deðiþkene eriþim
            pe.Mesaj ("Atilla Göktürk"); //public fonksiyona eriþim
            pe.Mesaj ("Fatih Özbay");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}