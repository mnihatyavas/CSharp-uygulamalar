// j2sc#1108.cs: IEnumerble Liste() metodunun yield-return'le çoklu deðer üretmesi örneði.

using System;
using System.Collections; //IEnumerator için
using System.Collections.Generic; //IEnumerable<T> için
using System.Threading; //Thread.Sleep için
namespace VeriYapýlarý {
    class Sýnýf1 {
        char krk;
        public IEnumerator GetEnumerator() {
            krk='A';
            for (int i=0; i < 26; i++) { 
                //if (i == 10) yield break; //döngüden erken çýkýþ istenirse
                yield return (char) (krk + i);
            } yield return ' ';
            krk='a';
            for (int i=0; i < 26; i++) yield return (char) (krk + i);
        }
        public IEnumerable<char> Harfler() {
            krk='A';
            for (int i=0; i < 26; i++) { 
                //if (i == 10) yield break; //döngüden erken çýkýþ istenirse
                yield return (char) (krk + i);
            } yield return ' ';
            krk='a';
            for (int i=0; i < 26; i++) yield return (char) (krk + i);
        }
    }
    class Adlar {
        string[] adlar = {"Nihat", "Nihal", "Yücel", "Nur", "Sema"};
        public IEnumerable<string> Üret() {for (int i = 0; i < adlar.Length; i++) yield return adlar [i];}
    }
    class VeriYapýsý8 {
        static IEnumerable<int> Sayaç (DateTime son) {
            try {
                for (int i = 1; i <= 5000; i++) {
                    if (DateTime.Now >= son) yield break;
                    yield return i;
                }
            } finally {Console.WriteLine (" ==>Sayaç sonlandýrýlýyor!");}
        }
        public static IEnumerable Liste() {
            int i, j, ts1, ts2; string ad; var r=new Random();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                yield return ad;
            }
        }
        static void Main() {
            Console.Write ("'yield return deðer' IEnumerator'la sýnýf içi üretilenleri sýnýf-tiplemeli liste elemanlarý olarak foreach'le sunar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf1 tiplemesinde GetEnumerator()/yield-return'la üretilen harfler:");
            Sýnýf1 snf1 = new Sýnýf1(); 
            foreach (char krk in snf1) Console.Write (krk); Console.WriteLine();
            foreach (char krk in snf1.Harfler()) Console.Write (krk); Console.WriteLine();

            Console.WriteLine ("\nAdlar sýnýfýnda 'IEnumerable<string> Üret()'/yield-return'la üretilen adlar:");
            Adlar ad = new Adlar();
            foreach (string a in ad.Üret()) Console.Write (a+" "); Console.WriteLine();
            IEnumerable<string> ie1 = ad.Üret();
            IEnumerator<string> ie1a = ie1.GetEnumerator();
            while (ie1a.MoveNext()) Console.Write (ie1a.Current+" "); Console.WriteLine();

            Console.WriteLine ("\n10*100mS*10=10sn'de 100 sayý üretip sonlanan saat sayacý:");
            DateTime dur = DateTime.Now.AddSeconds (10); Console.Write ("10*10=100'de sonlanacak==> ");
            foreach (int i in Sayaç (dur)) {Console.Write (i+" ");  Thread.Sleep (100);}

            Console.WriteLine ("\n10 rasgele ad üreten IEnumerable liste:");
            foreach (string a in Liste()) Console.Write (a+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}