// jtpc#1102d.cs: ProtectedInternal belirteçli deðiþken ve fonksiyona tiplemeyle eriþim örneði.

using System;
namespace Aduzamlar {
   class ProtectedInternalEriþim {
        protected internal string isim = "M.Nihat Yavaþ";
        protected internal void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class EriþimDeðiþtireçleri4 {
        static void Main() {
            Console.Write ("ProtectedInternal/KorumalýÝç üyeye public gibi fakat sadece aktüel uygulama içinden veya harici uygulamadaysa miraslamayla eriþilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ProtectedInternalEriþim pie = new ProtectedInternalEriþim();
            Console.WriteLine ("Merhabalar " + pie.isim); //protected internal deðiþkene tiplemeyle eriþim
            pie.Mesaj ("Fatih Özbay"); //protected internal fonksiyona tiplemeyle eriþim
            pie.Mesaj ("Atilla Göktürk");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}