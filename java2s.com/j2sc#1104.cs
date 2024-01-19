// j2sc#1104.cs: ICollection, IDictionary ve SortedDictionary örneði.

using System;
using System.Collections.Generic; //Dictionary<T1,T2> ve ICollection<T> için
using System.Text.RegularExpressions; //Regex için
namespace VeriYapýlarý {
    class VeriYapýsý4 {
        static Dictionary<string,int> KelimeleriSay (string dzg) {
            Dictionary<string,int> sýklýk = new Dictionary<string,int>();
            string[] kelimeler = Regex.Split (dzg, @"\W+");
            foreach (string kelime in kelimeler) {
                if (sýklýk.ContainsKey (kelime)) sýklýk [kelime]++;
                else sýklýk [kelime] = 1;
            }
            return sýklýk;
        }
        static void Main() {
            Console.Write ("Dictionary ikili anahtar/Key-deðer/Value çiftinden/KeyValuePair oluþur. Ýlki anahtar, ikincisi deðerdir; her tipte tanýmlanabilirler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sözlük kayýtlarýna ilk isim anahtarý endeksleriyle eriþme:");
            int i, j; double ds1; var r=new Random();
            string[] adlar= new string[] {"M.Nihat Yavaþ", "Zafer N.Candan", "Hilal Gökyiðit", "Serap Küçükbay", "Selda Özbay"};
            Dictionary<string, double> sözlük1 = new Dictionary<string, double>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                sözlük1.Add (adlar [i], ds1);
            }
            ICollection<string> ik1 = sözlük1.Keys;
            foreach(string ad in ik1) Console.WriteLine ("{0},\tMaaþ: {1,9:#,0.00} TL", ad, sözlük1 [ad]);

            Console.WriteLine ("\nSözlük kayýtlarýna ilk maaþ anahtarý endeksleriyle eriþme:");
            Dictionary<double, string> sözlük2 = new Dictionary<double, string>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                sözlük2.Add (ds1, adlar [i]);
            }
            ICollection<double> ik2 = sözlük2.Keys;
            foreach(double maaþ in ik2) Console.WriteLine ("{0},\tMaaþ: {1,9:#,0.00} TL", sözlük2 [maaþ], maaþ);

            Console.WriteLine ("\nDizgedeki kelimeleri tekrar sýklýðýyla içeren sözlük:");
            string tekerleme = "Þu köþe yaz köþesi þu köþe kýþ köþesi bu köþe bahar köþesi bu köþe güz köþesi";
            Console.WriteLine (tekerleme);
            Dictionary<string, int> sýklýk = KelimeleriSay (tekerleme);
            foreach (KeyValuePair<string, int> çift in sýklýk) Console.WriteLine ("{0}: {1}", çift.Key, çift.Value);

            Console.WriteLine ("\nIDictionary ile isim-maaþ çiftli anahtar-deðer'lerin sunumu:");
            decimal m1;
            IDictionary<string, decimal> bordro = new Dictionary<string, decimal>();
            for(i=0;i<adlar.Length;i++) {
                m1=r.Next(7500,100000)+r.Next(0,100)/100M;
                bordro.Add (adlar [i], m1);
            }
            foreach (KeyValuePair<string, decimal> çift in bordro) Console.WriteLine ("{0},\tMaaþ: {1,9:#,0.00} TL", çift.Key, çift.Value);
            Console.WriteLine ("Ýþgören sayýsý: {0}", bordro.Count);
            m1=r.Next(7500,100000)+r.Next(0,100)/100M; bordro.Add ("Hamza Candan", m1);
            m1=r.Next(7500,100000)+r.Next(0,100)/100M; bordro.Add ("Sevim Yavaþ", m1);
            Console.WriteLine ("2 ilaveli iþgören sayýsý: {0}", bordro.Count);
            bordro.Remove ("Hamza Candan"); bordro.Remove ("Sevim Yavaþ");
            Console.WriteLine ("2 eksiltmeli iþgören sayýsý: {0}", bordro.Count);
            Console.WriteLine ("Bordroda Selda Özbay var mý? {0}", bordro.ContainsKey ("Selda Özbay")==true? "Evet" : "Hayýr");
            Console.WriteLine ("Bordroda Sema Özbay var mý? {0}", bordro.ContainsKey ("Sema Özbay")==true? "Evet" : "Hayýr");
            m1=0; foreach (decimal m in bordro.Values) m1+=m;
            Console.WriteLine ("Maaþlarýn toplamý: {0,9:#,0.00} TL,\tOrtalamasý: {1,9:#,0.00} TL", m1, m1/bordro.Count);

            Console.WriteLine ("\nIDictionary veri çiftini List'e aktarýp görüntüleme:");
            IDictionary<string, DateTime> tarih = new Dictionary<string, DateTime>();
            for(i=0;i<5;i++) {tarih.Add ((i+1)+".tarih", DateTime.Now); for(j=0;j<50000000;j++){}}
            List<KeyValuePair<string, DateTime>> tliste = new List<KeyValuePair<string, DateTime>>(tarih);
            foreach (KeyValuePair<string, DateTime> çift in tliste) Console.WriteLine ("{0}: {1}:{2}", çift.Key, çift.Value, çift.Value.Millisecond);

            Console.WriteLine ("\nAd'a ve maaþ'a göre sýralý bordro kurma ve sunma:");
            SortedDictionary<string, double> sýralýBordro1 = new SortedDictionary<string, double>();
            SortedDictionary<double, string> sýralýBordro2 = new SortedDictionary<double, string>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                sýralýBordro1.Add (adlar [i], ds1);
                sýralýBordro2.Add (ds1, adlar [i]);
            }
            Console.WriteLine ("\tAd'a göre artan sýralý:");
            foreach (KeyValuePair<string, double> çift in sýralýBordro1) Console.WriteLine ("{0},\tMaaþ: {1,9:#,0.00} TL", çift.Key, çift.Value);
            Console.WriteLine ("\tMaaþ'a göre artan sýralý:");
            foreach (KeyValuePair<double, string> çift in sýralýBordro2) Console.WriteLine ("{0},\tMaaþ: {1,9:#,0.00} TL", çift.Value, çift.Key);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}