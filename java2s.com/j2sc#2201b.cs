// j2sc#2201b.cs: Var, let, Func/Action, var new[]{} anonim i�lemler �rne�i.
using System;
using System.Linq; //from-select sonu� yans�tmas� i�in
using System.Collections.Generic; //List<> i�in
using System.Diagnostics; //Process i�in
namespace LokalTip {
    class Tablet {
        public Int32 �pNo {get; set;}
        public Int64 ��No {get; set;}
        public String S�re�Ad� {get; set;}
    }
    class Araba {
        public string Ad�;
        public string Rengi;
        public int H�z�;
        public string Markas�;
        public override string ToString() {return string.Format ("Markas�={0}, Rengi={1}, H�z�={2}, Ad�={3}", Markas�, Rengi, H�z�, Ad�);}
    }
    class Let_1 {
        static void Main() {
            Console.Write ("'var' genel, 'let' i�erildi�i blo�a �zeldir. Func<,> veya Action<,>'la delegeli de�i�ken ad-metotla anl�k i�lemler yap�l�r/d�nd�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sorgu'yla for[i-10](diziA)*f0r[j-10](diziB) > 1,770,049 se�ilmeleri:");
            Int32[] diziA = new int [10];
            Int32[] diziB = new int [10];
            var r=new Random(); int i, ts;
            for(i=0;i<10;i++) {
                ts=r.Next(1881,1939); diziA [i] = ts;
                ts=r.Next(1881,1939); diziB [i] = ts;
            }
            var kareler = from birimA in diziA //i�i�e for-i * for-j gibi �arp�mlar
                from birimB in diziB
                let kare = birimA * birimB
                where kare > 1881*(1881+1938)/2
                select new {birimA, birimB, kare};
            /* Console.WriteLine (kare): Derleme hatas� [The name 'kare' does not exist in the current context] */
            Console.Write ("-->T�m e�endeksli kareler: ");
            for(i=0;i<10;i++) Console.Write ("{0}*{1}={2:#,0}  ", diziA [i], diziB [i], diziA [i] * diziB [i]); Console.WriteLine();
            Console.Write ("-->Kareler > 1,770,049: "); ts=0;
            foreach (var k in kareler) Console.Write ("{0}*{1}={2:#,0}  ", k.birimA, k.birimB, k.kare); Console.WriteLine();

            Console.WriteLine ("\nAnonim fonksiyonla dizgelerin uzunluklar�n� d�nd�rme:");
            string[] �ehirler = {"�anl�Urfa", "Mersin", "Bursa", "Malatya", "Van", "�stanbul", "Ankara", "�zmir", "KahramanMara�"};
            Func<string, int> uzn = delegate (string dizge) {return dizge.Length;};
            for(i=0;i<�ehirler.Length;i++) Console.WriteLine ("Uzunluk ({0}) = {1}", �ehirler [i], uzn (�ehirler [i]));

            Console.WriteLine ("\nAnonim new[]{new{},...} diziyle �oklu �zellikli ki�i'leri sunma:");
            var ki�iler = new []{new {ad = "Nihat", ya� = 2024-1957, meslek ="Emekli"}, new {ad = "Belk�s", ya� = 2024-1981, meslek ="Hostes"}, new {ad = "Y�cel", ya� = 2024-1973, meslek ="Ototamirci"}, new {ad = "Sema", ya� = 2024-1975, meslek ="��retmen"}, new {ad = "Atilla", ya� = 2024-1984, meslek ="Doktor"}};
            ts=0; foreach(var ki�i in ki�iler) {Console.WriteLine("{0}: {1}, {2} ya��ndad�r.", ki�i.meslek, ki�i.ad, ki�i.ya�); ts+=ki�i.ya�;}
            Console.WriteLine ("Anonim dizideki {0} ki�inin toplam ya��: {1} ve ya� ortalamas�: {2}'dir.", ki�iler.Length, ts, ts/ki�iler.Length);

            Console.WriteLine ("\nBilgisar belle�indeki aktif i�'lerin detay bilgileri:");
            var s�re�ler = new List<Tablet>();
            foreach(var s�re� in Process.GetProcesses()) {s�re�ler.Add (new Tablet {�pNo = s�re�.Id, S�re�Ad� = s�re�.ProcessName, ��No = s�re�.WorkingSet64});}
            foreach(var s�re� in s�re�ler) Console.WriteLine ("S�re� ad�: {0,-22}Sicim no: {1,5}\t�� no: {2,9}", s�re�.S�re�Ad�, s�re�.�pNo, s�re�.��No);

            Console.WriteLine ("\nAraba s�n�fl� anonim diziyi from-select sorgulat�p se�me:");
            Araba[] arabalar = new [] {
                new Araba {Ad� = "Beng�", Rengi = "G�m��", H�z� = 180, Markas� = "BMW"},
                new Araba {Ad� = "Ven�s", Rengi = "Siyah", H�z� = 155, Markas� = "VW"},
                new Araba {Ad� = "Ferda", Rengi = "Beyaz", H�z� = 173, Markas� = "Ford"}
            };
            var renkliMarka = from araba in arabalar select new {araba.Markas�, araba.Rengi};
            foreach (var a in arabalar) Console.WriteLine (a);
            foreach (var arb in renkliMarka) Console.WriteLine (arb.ToString());
            var adl�Marka = from araba in arabalar select new {araba.Ad�, araba.Markas�};
            foreach (var ar in adl�Marka) Console.WriteLine (ar);

            Console.WriteLine ("\nDelegeli anonim Func/Action'la parametrik dizgeyi tersleme:");
            Action<string> tersten = delegate (string dzg) {
                char[] krkDizi = dzg.ToCharArray();
                Array.Reverse (krkDizi);
                Console.WriteLine (new string (krkDizi));
            };
            string metin="Merhaba D�nya"; Console.Write (metin+"-->"); tersten (metin);
            metin="M.Nihat Yava�"; Console.Write (metin+"-->"); tersten (metin);
            metin="Hatice Yava� Ka�ar"; Console.Write (metin+"-->"); tersten (metin);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}