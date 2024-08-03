// j2sc#1801d.cs: Queue<T>, Dictionary/SortedDictionary<T,T> ve SortedList örneði.

using System;
using System.Collections.Generic;
using System.Collections; //<T>'siz SortedList için
namespace SoysalListe {
    class Sýnýfým {
        int no;
        public Sýnýfým (int i) {no=i;} //Kurucu
        public override string ToString() {return no+".Sýnýf";}
    }
    class KuyrukSözlükSýralý {
        static void Main() {
            Console.Write ("Stack/yýðýna ilk giren son çýkarken Queue/kuyruða ilk giren ilk çýkar ve Peek yýðýnda songireni görürken kuyrukta daima ilkgireni görür. Sözlük anahtar-deðer çifti foreach'le sözcük=KeyValuePair<T,T>, sözcük.Key ve sözcük.Value olarak eriþilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Enqueue, Dequeue ve Peek'le Queue/kuyruk kayýtlarý:");
            Queue<double> kuyruk = new Queue<double>();
            Console.WriteLine ("==>Kuyruktaki ilk kayýt sayýsý: "+kuyruk.Count);
            var r=new Random(); int i, j, ts; double ds1, ds2, toplam;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,1000)+r.Next(10,100)/100d;
                kuyruk.Enqueue (ds1);
                Console.WriteLine ("Kuyruða eklenen {0}.duble sayý: {1,6:0.00}\tPeek: {2,6:0.00}", i+1, ds1, kuyruk.Peek());
            }
            Console.WriteLine ("==>Kuyruða Enqueue sonrasý kayýt sayýsý: "+kuyruk.Count);
            toplam=0; i=0;
            while(kuyruk.Count > 0) {
                ds1=kuyruk.Peek();
                ds2 = kuyruk.Dequeue();
                Console.WriteLine ("Kuyruktan çýkarýlan {0}.sayý: {1,6:0.00}\tPeek: {2,6:0.00}", ++i, ds2, ds1);
                toplam += ds2;
            }
            Console.WriteLine ("==>Kuyruktan Dequeue sonrasý kayýt sayýsý: "+kuyruk.Count);
            Console.WriteLine ("Kuyruktaki duble sayýlar toplamý: {0:#,0.00}", toplam);


            Console.WriteLine ("\nSýrasýz ve sýralý sözlüklerin anahtar-kelime çiftli kayýtlarý:");
            Dictionary <string, Sýnýfým> sözlük = new Dictionary <string, Sýnýfým>();
            string sözcük, ad;
            for(i=0;i<5;i++) {
                sözcük="";
                for(j=0;j<5;j++) {ts=r.Next(65,91); sözcük+=(char)ts;}
                sözlük.Add (sözcük, new Sýnýfým (i+1));
            }
            Console.WriteLine ("\t==>Sýrasýz Dictionary listesi dökümleniyor:"); i=0;
            foreach (var kayýt in sözlük) {Console.WriteLine (++i + ".[anahtar, deðer] = " + kayýt);}
            i=0; foreach (KeyValuePair<string, Sýnýfým> kayýt in sözlük) {Console.WriteLine ("\t{0}.nci sözcük: {1}={2}", ++i, kayýt.Key, kayýt.Value);}
            //Sýnýfým myClass = sözlük["Crypto"]; Console.WriteLine("Got from dictionary: {0}", myClass);
            SortedDictionary <string, Sýnýfým> sýralýSözlük = new SortedDictionary <string, Sýnýfým>();
            for(i=0;i<5;i++) {
                sözcük="";
                for(j=0;j<5;j++) {ts=r.Next(65,91); sözcük+=(char)ts;}
                sýralýSözlük.Add (sözcük, new Sýnýfým (i+1));
            }
            Console.WriteLine ("\t==>Sýralý Dictionary listesi dökümleniyor:"); i=0;
            foreach (var kayýt in sýralýSözlük) {Console.WriteLine (++i + ".[anahtar, deðer] = " + kayýt);}
            i=0; foreach (KeyValuePair<string, Sýnýfým> kayýt in sýralýSözlük) {Console.WriteLine ("\t{0}.nci sözcük: {1}={2}", ++i, kayýt.Key, kayýt.Value);}

            Console.WriteLine ("\nSýralý listeyle <ad,maaþ> çift kayýtlarýn ad'la artan sýralanmasý:");
            SortedList <string, double> sl1 = new SortedList <string, double>();
            for(i=0;i<10;i++) {
                ad="";
                for(j=0;j<6;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds1=r.Next(1000,200000)+r.Next(10,100)/100d;
                sl1.Add (ad, ds1);
            }
            ICollection <string> klk = sl1.Keys;
            foreach (string anh in klk) Console.WriteLine ("{0}'ýn maaþý = {1,10 :#,0.00} TL", anh, sl1 [anh]);

            Console.WriteLine ("\nAsoysal SortedList KeyValuePair<T,T> yerine 'anh in sl2.Keys' ve 'sl2[anh]' kullanýr:");
            SortedList sl2 = new SortedList();
            sl2.Add ("NY", "New York"); sl2.Add ("FL", "Florida"); sl2.Add ("AL", "Alabama"); sl2.Add ("WY", "Wyoming"); sl2.Add("CA", "California");
            i=0; foreach (string anh in sl2.Keys) Console.WriteLine ("{0}.anahtar = {1}", ++i, anh);
            i=0; foreach (string dðr in sl2.Values) Console.WriteLine ("\t{0}.deðer = {1}", ++i, dðr);
            i=0; foreach(string anh in sl2.Keys) Console.WriteLine ("{0}.kayýt = ({1}, {2})", ++i, anh, sl2 [anh]);
            if (sl2.ContainsKey ("FL")) Console.WriteLine ("\tsl2 'FL' anahtarýný içeriyor");
            Console.WriteLine ("\tSýralýListe 'ANK' anahtarýný içeriyor mu? {0}", sl2.ContainsKey ("ANK")?"EVET":"HAYIR");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}