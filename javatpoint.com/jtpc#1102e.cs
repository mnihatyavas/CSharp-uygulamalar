// jtpc#1102e.cs: Private belirteçli deðiþken ve fonksiyona sýnýfiçi tiplemeyle eriþim örneði.

using System;
namespace Aduzamlar {
    class EriþimDeðiþtireçleri5 {
        private string isim = "M.Nihat Yavaþ";
        private void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
        static void Main() {
            Console.Write ("Private/özel üyeye sadece ayný sýnýf içi tiplemeyle eriþilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            EriþimDeðiþtireçleri5 pe = new EriþimDeðiþtireçleri5();
            Console.WriteLine ("Merhabalar " + pe.isim); //private deðiþkene ayný sýnýfta tiplemeyle eriþim
            pe.Mesaj ("Yücel Küçükbay"); //private fonksiyona ayný sýnýfta tiplemeyle eriþim
            pe.Mesaj ("Fatih Özbay");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}