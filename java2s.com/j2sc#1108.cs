// j2sc#1108.cs: IEnumerble Liste() metodunun yield-return'le �oklu de�er �retmesi �rne�i.

using System;
using System.Collections; //IEnumerator i�in
using System.Collections.Generic; //IEnumerable<T> i�in
using System.Threading; //Thread.Sleep i�in
namespace VeriYap�lar� {
    class S�n�f1 {
        char krk;
        public IEnumerator GetEnumerator() {
            krk='A';
            for (int i=0; i < 26; i++) { 
                //if (i == 10) yield break; //d�ng�den erken ��k�� istenirse
                yield return (char) (krk + i);
            } yield return ' ';
            krk='a';
            for (int i=0; i < 26; i++) yield return (char) (krk + i);
        }
        public IEnumerable<char> Harfler() {
            krk='A';
            for (int i=0; i < 26; i++) { 
                //if (i == 10) yield break; //d�ng�den erken ��k�� istenirse
                yield return (char) (krk + i);
            } yield return ' ';
            krk='a';
            for (int i=0; i < 26; i++) yield return (char) (krk + i);
        }
    }
    class Adlar {
        string[] adlar = {"Nihat", "Nihal", "Y�cel", "Nur", "Sema"};
        public IEnumerable<string> �ret() {for (int i = 0; i < adlar.Length; i++) yield return adlar [i];}
    }
    class VeriYap�s�8 {
        static IEnumerable<int> Saya� (DateTime son) {
            try {
                for (int i = 1; i <= 5000; i++) {
                    if (DateTime.Now >= son) yield break;
                    yield return i;
                }
            } finally {Console.WriteLine (" ==>Saya� sonland�r�l�yor!");}
        }
        public static IEnumerable Liste() {
            int i, j, ts1, ts2; string ad; var r=new Random();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                yield return ad;
            }
        }
        static void Main() {
            Console.Write ("'yield return de�er' IEnumerator'la s�n�f i�i �retilenleri s�n�f-tiplemeli liste elemanlar� olarak foreach'le sunar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f1 tiplemesinde GetEnumerator()/yield-return'la �retilen harfler:");
            S�n�f1 snf1 = new S�n�f1(); 
            foreach (char krk in snf1) Console.Write (krk); Console.WriteLine();
            foreach (char krk in snf1.Harfler()) Console.Write (krk); Console.WriteLine();

            Console.WriteLine ("\nAdlar s�n�f�nda 'IEnumerable<string> �ret()'/yield-return'la �retilen adlar:");
            Adlar ad = new Adlar();
            foreach (string a in ad.�ret()) Console.Write (a+" "); Console.WriteLine();
            IEnumerable<string> ie1 = ad.�ret();
            IEnumerator<string> ie1a = ie1.GetEnumerator();
            while (ie1a.MoveNext()) Console.Write (ie1a.Current+" "); Console.WriteLine();

            Console.WriteLine ("\n10*100mS*10=10sn'de 100 say� �retip sonlanan saat sayac�:");
            DateTime dur = DateTime.Now.AddSeconds (10); Console.Write ("10*10=100'de sonlanacak==> ");
            foreach (int i in Saya� (dur)) {Console.Write (i+" ");  Thread.Sleep (100);}

            Console.WriteLine ("\n10 rasgele ad �reten IEnumerable liste:");
            foreach (string a in Liste()) Console.Write (a+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}