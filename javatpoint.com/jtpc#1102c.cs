// jtpc#1102c.cs: Internal belirteçli deðiþken ve fonksiyona tiplemeyle eriþim örneði.

using System;
using InternalAduzam;
namespace InternalAduzam {
   class InternalEriþim {
        internal string isim = "M.Nihat Yavaþ";
        internal void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
}
namespace Aduzamlar {
    class EriþimDeðiþtireçleri3 {
        static void Main() {
            Console.Write ("Internal/iç üyeye public gibi fakat sadece aktüel uygulama içinden ve tiplemeyle eriþilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            InternalEriþim ie = new InternalEriþim();
            Console.WriteLine ("Merhabalar " + ie.isim); //internal deðiþkene tiplemeyle eriþim
            ie.Mesaj ("Zafer N.Candan"); //internal fonksiyona tiplemeyle eriþim
            ie.Mesaj ("Atilla Göktürk");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}