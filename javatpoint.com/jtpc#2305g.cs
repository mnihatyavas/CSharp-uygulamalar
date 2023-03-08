// jtpc#2305g.cs: '?' semboll� do�rudan null nesne kontrolu �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string �sim {get; set;}
        public string Eposta {get; set;}
    }
    class SoruSembol� {
        static void Main() {
            Console.Write ("Nesne null ise eri�im hata vermemesi ya if-null �nkontrolu yada ? sembol�yle otomatik a��klama atamal� kontrol yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new ��renci() {No=101, �sim="Sevim Yava�", Eposta = "seyavas@gmail.com"};
            var ��renci2 = new ��renci() {No=102, �sim="Song�l Yava�", Eposta = "soyavas@gmail.com"};
            var ��renci3 = new ��renci();
            if (��renci1.�sim != null) Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci1.No, ��renci1.�sim.ToUpper(), ��renci1.Eposta);
            if (��renci2.�sim != null) Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci2.No, ��renci2.�sim.ToUpper(), ��renci2.Eposta);
            if (��renci3.�sim != null) Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci3.No, ��renci3.�sim.ToUpper(), ��renci3.Eposta);

            //Console.WriteLine ("\n{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci1?.No? ??"Numaras�z", ��renci1?.�sim?.ToUpper() ??"�simsiz", ��renci1?.Eposta? ??"Epostas�z");
            //Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci2?.No? ??"Numaras�z", ��renci2?.�sim?.ToUpper() ??"�simsiz", ��renci2?.Eposta? ??"Epostas�z");
            //Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��renci3?.No? ??"Numaras�z", ��renci3?.�sim?.ToUpper() ??"�simsiz", ��renci3?.Eposta? ??"Epostas�z");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}