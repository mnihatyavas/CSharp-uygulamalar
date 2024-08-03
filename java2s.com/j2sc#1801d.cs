// j2sc#1801d.cs: Queue<T>, Dictionary/SortedDictionary<T,T> ve SortedList �rne�i.

using System;
using System.Collections.Generic;
using System.Collections; //<T>'siz SortedList i�in
namespace SoysalListe {
    class S�n�f�m {
        int no;
        public S�n�f�m (int i) {no=i;} //Kurucu
        public override string ToString() {return no+".S�n�f";}
    }
    class KuyrukS�zl�kS�ral� {
        static void Main() {
            Console.Write ("Stack/y���na ilk giren son ��karken Queue/kuyru�a ilk giren ilk ��kar ve Peek y���nda songireni g�r�rken kuyrukta daima ilkgireni g�r�r. S�zl�k anahtar-de�er �ifti foreach'le s�zc�k=KeyValuePair<T,T>, s�zc�k.Key ve s�zc�k.Value olarak eri�ilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Enqueue, Dequeue ve Peek'le Queue/kuyruk kay�tlar�:");
            Queue<double> kuyruk = new Queue<double>();
            Console.WriteLine ("==>Kuyruktaki ilk kay�t say�s�: "+kuyruk.Count);
            var r=new Random(); int i, j, ts; double ds1, ds2, toplam;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,1000)+r.Next(10,100)/100d;
                kuyruk.Enqueue (ds1);
                Console.WriteLine ("Kuyru�a eklenen {0}.duble say�: {1,6:0.00}\tPeek: {2,6:0.00}", i+1, ds1, kuyruk.Peek());
            }
            Console.WriteLine ("==>Kuyru�a Enqueue sonras� kay�t say�s�: "+kuyruk.Count);
            toplam=0; i=0;
            while(kuyruk.Count > 0) {
                ds1=kuyruk.Peek();
                ds2 = kuyruk.Dequeue();
                Console.WriteLine ("Kuyruktan ��kar�lan {0}.say�: {1,6:0.00}\tPeek: {2,6:0.00}", ++i, ds2, ds1);
                toplam += ds2;
            }
            Console.WriteLine ("==>Kuyruktan Dequeue sonras� kay�t say�s�: "+kuyruk.Count);
            Console.WriteLine ("Kuyruktaki duble say�lar toplam�: {0:#,0.00}", toplam);


            Console.WriteLine ("\nS�ras�z ve s�ral� s�zl�klerin anahtar-kelime �iftli kay�tlar�:");
            Dictionary <string, S�n�f�m> s�zl�k = new Dictionary <string, S�n�f�m>();
            string s�zc�k, ad;
            for(i=0;i<5;i++) {
                s�zc�k="";
                for(j=0;j<5;j++) {ts=r.Next(65,91); s�zc�k+=(char)ts;}
                s�zl�k.Add (s�zc�k, new S�n�f�m (i+1));
            }
            Console.WriteLine ("\t==>S�ras�z Dictionary listesi d�k�mleniyor:"); i=0;
            foreach (var kay�t in s�zl�k) {Console.WriteLine (++i + ".[anahtar, de�er] = " + kay�t);}
            i=0; foreach (KeyValuePair<string, S�n�f�m> kay�t in s�zl�k) {Console.WriteLine ("\t{0}.nci s�zc�k: {1}={2}", ++i, kay�t.Key, kay�t.Value);}
            //S�n�f�m myClass = s�zl�k["Crypto"]; Console.WriteLine("Got from dictionary: {0}", myClass);
            SortedDictionary <string, S�n�f�m> s�ral�S�zl�k = new SortedDictionary <string, S�n�f�m>();
            for(i=0;i<5;i++) {
                s�zc�k="";
                for(j=0;j<5;j++) {ts=r.Next(65,91); s�zc�k+=(char)ts;}
                s�ral�S�zl�k.Add (s�zc�k, new S�n�f�m (i+1));
            }
            Console.WriteLine ("\t==>S�ral� Dictionary listesi d�k�mleniyor:"); i=0;
            foreach (var kay�t in s�ral�S�zl�k) {Console.WriteLine (++i + ".[anahtar, de�er] = " + kay�t);}
            i=0; foreach (KeyValuePair<string, S�n�f�m> kay�t in s�ral�S�zl�k) {Console.WriteLine ("\t{0}.nci s�zc�k: {1}={2}", ++i, kay�t.Key, kay�t.Value);}

            Console.WriteLine ("\nS�ral� listeyle <ad,maa�> �ift kay�tlar�n ad'la artan s�ralanmas�:");
            SortedList <string, double> sl1 = new SortedList <string, double>();
            for(i=0;i<10;i++) {
                ad="";
                for(j=0;j<6;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds1=r.Next(1000,200000)+r.Next(10,100)/100d;
                sl1.Add (ad, ds1);
            }
            ICollection <string> klk = sl1.Keys;
            foreach (string anh in klk) Console.WriteLine ("{0}'�n maa�� = {1,10 :#,0.00} TL", anh, sl1 [anh]);

            Console.WriteLine ("\nAsoysal SortedList KeyValuePair<T,T> yerine 'anh in sl2.Keys' ve 'sl2[anh]' kullan�r:");
            SortedList sl2 = new SortedList();
            sl2.Add ("NY", "New York"); sl2.Add ("FL", "Florida"); sl2.Add ("AL", "Alabama"); sl2.Add ("WY", "Wyoming"); sl2.Add("CA", "California");
            i=0; foreach (string anh in sl2.Keys) Console.WriteLine ("{0}.anahtar = {1}", ++i, anh);
            i=0; foreach (string d�r in sl2.Values) Console.WriteLine ("\t{0}.de�er = {1}", ++i, d�r);
            i=0; foreach(string anh in sl2.Keys) Console.WriteLine ("{0}.kay�t = ({1}, {2})", ++i, anh, sl2 [anh]);
            if (sl2.ContainsKey ("FL")) Console.WriteLine ("\tsl2 'FL' anahtar�n� i�eriyor");
            Console.WriteLine ("\tS�ral�Liste 'ANK' anahtar�n� i�eriyor mu? {0}", sl2.ContainsKey ("ANK")?"EVET":"HAYIR");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}