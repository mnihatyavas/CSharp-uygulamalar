// j2sc#2201b.cs: Var, let, Func/Action, var new[]{} anonim iþlemler örneði.
using System;
using System.Linq; //from-select sonuç yansýtmasý için
using System.Collections.Generic; //List<> için
using System.Diagnostics; //Process için
namespace LokalTip {
    class Tablet {
        public Int32 ÝpNo {get; set;}
        public Int64 ÝþNo {get; set;}
        public String SüreçAdý {get; set;}
    }
    class Araba {
        public string Adý;
        public string Rengi;
        public int Hýzý;
        public string Markasý;
        public override string ToString() {return string.Format ("Markasý={0}, Rengi={1}, Hýzý={2}, Adý={3}", Markasý, Rengi, Hýzý, Adý);}
    }
    class Let_1 {
        static void Main() {
            Console.Write ("'var' genel, 'let' içerildiði bloða özeldir. Func<,> veya Action<,>'la delegeli deðiþken ad-metotla anlýk iþlemler yapýlýr/döndürülür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sorgu'yla for[i-10](diziA)*f0r[j-10](diziB) > 1,770,049 seçilmeleri:");
            Int32[] diziA = new int [10];
            Int32[] diziB = new int [10];
            var r=new Random(); int i, ts;
            for(i=0;i<10;i++) {
                ts=r.Next(1881,1939); diziA [i] = ts;
                ts=r.Next(1881,1939); diziB [i] = ts;
            }
            var kareler = from birimA in diziA //içiçe for-i * for-j gibi çarpýmlar
                from birimB in diziB
                let kare = birimA * birimB
                where kare > 1881*(1881+1938)/2
                select new {birimA, birimB, kare};
            /* Console.WriteLine (kare): Derleme hatasý [The name 'kare' does not exist in the current context] */
            Console.Write ("-->Tüm eþendeksli kareler: ");
            for(i=0;i<10;i++) Console.Write ("{0}*{1}={2:#,0}  ", diziA [i], diziB [i], diziA [i] * diziB [i]); Console.WriteLine();
            Console.Write ("-->Kareler > 1,770,049: "); ts=0;
            foreach (var k in kareler) Console.Write ("{0}*{1}={2:#,0}  ", k.birimA, k.birimB, k.kare); Console.WriteLine();

            Console.WriteLine ("\nAnonim fonksiyonla dizgelerin uzunluklarýný döndürme:");
            string[] þehirler = {"ÞanlýUrfa", "Mersin", "Bursa", "Malatya", "Van", "Ýstanbul", "Ankara", "Ýzmir", "KahramanMaraþ"};
            Func<string, int> uzn = delegate (string dizge) {return dizge.Length;};
            for(i=0;i<þehirler.Length;i++) Console.WriteLine ("Uzunluk ({0}) = {1}", þehirler [i], uzn (þehirler [i]));

            Console.WriteLine ("\nAnonim new[]{new{},...} diziyle çoklu özellikli kiþi'leri sunma:");
            var kiþiler = new []{new {ad = "Nihat", yaþ = 2024-1957, meslek ="Emekli"}, new {ad = "Belkýs", yaþ = 2024-1981, meslek ="Hostes"}, new {ad = "Yücel", yaþ = 2024-1973, meslek ="Ototamirci"}, new {ad = "Sema", yaþ = 2024-1975, meslek ="Öðretmen"}, new {ad = "Atilla", yaþ = 2024-1984, meslek ="Doktor"}};
            ts=0; foreach(var kiþi in kiþiler) {Console.WriteLine("{0}: {1}, {2} yaþýndadýr.", kiþi.meslek, kiþi.ad, kiþi.yaþ); ts+=kiþi.yaþ;}
            Console.WriteLine ("Anonim dizideki {0} kiþinin toplam yaþý: {1} ve yaþ ortalamasý: {2}'dir.", kiþiler.Length, ts, ts/kiþiler.Length);

            Console.WriteLine ("\nBilgisar belleðindeki aktif iþ'lerin detay bilgileri:");
            var süreçler = new List<Tablet>();
            foreach(var süreç in Process.GetProcesses()) {süreçler.Add (new Tablet {ÝpNo = süreç.Id, SüreçAdý = süreç.ProcessName, ÝþNo = süreç.WorkingSet64});}
            foreach(var süreç in süreçler) Console.WriteLine ("Süreç adý: {0,-22}Sicim no: {1,5}\tÝþ no: {2,9}", süreç.SüreçAdý, süreç.ÝpNo, süreç.ÝþNo);

            Console.WriteLine ("\nAraba sýnýflý anonim diziyi from-select sorgulatýp seçme:");
            Araba[] arabalar = new [] {
                new Araba {Adý = "Bengü", Rengi = "Gümüþ", Hýzý = 180, Markasý = "BMW"},
                new Araba {Adý = "Venüs", Rengi = "Siyah", Hýzý = 155, Markasý = "VW"},
                new Araba {Adý = "Ferda", Rengi = "Beyaz", Hýzý = 173, Markasý = "Ford"}
            };
            var renkliMarka = from araba in arabalar select new {araba.Markasý, araba.Rengi};
            foreach (var a in arabalar) Console.WriteLine (a);
            foreach (var arb in renkliMarka) Console.WriteLine (arb.ToString());
            var adlýMarka = from araba in arabalar select new {araba.Adý, araba.Markasý};
            foreach (var ar in adlýMarka) Console.WriteLine (ar);

            Console.WriteLine ("\nDelegeli anonim Func/Action'la parametrik dizgeyi tersleme:");
            Action<string> tersten = delegate (string dzg) {
                char[] krkDizi = dzg.ToCharArray();
                Array.Reverse (krkDizi);
                Console.WriteLine (new string (krkDizi));
            };
            string metin="Merhaba Dünya"; Console.Write (metin+"-->"); tersten (metin);
            metin="M.Nihat Yavaþ"; Console.Write (metin+"-->"); tersten (metin);
            metin="Hatice Yavaþ Kaçar"; Console.Write (metin+"-->"); tersten (metin);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}