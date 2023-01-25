// jtpc#1102b.cs: Protected belirteçli deðiþken ve fonksiyona miraslamayla eriþim örneði.

using System;
namespace Aduzamlar {
   class ProtectedEriþim {
        protected string isim = "M.Nihat Yavaþ";
        protected void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class EriþimDeðiþtireçleri2: ProtectedEriþim {//Miraslamayla eriþim
        static void Main() {
            Console.Write ("Protected/korumalý üyeye sadece tanýmlý sýnýf ve altsýnýflarý içinden veya miraslanmayla eriþilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            EriþimDeðiþtireçleri2 pe = new EriþimDeðiþtireçleri2();
            Console.WriteLine ("Merhabalar " + pe.isim); //protected deðiþkene miraslamayla eriþim
            pe.Mesaj ("Zafer N.Candan"); //protected fonksiyona miraslamayla eriþim
            pe.Mesaj ("Yücel Küçükbay");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}