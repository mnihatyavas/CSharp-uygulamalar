// j2sc#1109b.cs: IComparer ebeveynli Compare()'le d�z/ters s�ralama �rne�i.

using System;
using System.Collections;
using System.Collections.Generic;
namespace VeriYap�lar� {
    public class ��g�ren : IComparable {
        private int i�gNo;
        private string i�gAd;
        public int ��gNo {get{return i�gNo;} set{i�gNo = value;}} //�zellik
        public string ��gAd {get{return i�gAd;} set{i�gAd = value;}} //�zellik
        public ��g�ren(){} //Kurucu-1
        public ��g�ren (int no, string ad) {i�gNo = no; i�gAd = ad;} //Kurucu-2
        public override string ToString() {return String.Format ("{0}: {1}",i�gNo, i�gAd);}
        int IComparable.CompareTo (object ns) {// Varsay�l� i�gNo'yla artan s�ral� Sort() i�in
            if (this.i�gNo > ((��g�ren)ns).i�gNo) return 1;
            if (this.i�gNo < ((��g�ren)ns).i�gNo) return -1;
            return 0;
        }
        private class S�ralamaYard�mc�s� : IComparer {// Varsay�l� i�gAd'la artan s�ral� Sort() i�in
            int IComparer.Compare (object ns1, object ns2) {return String.Compare (((��g�ren)ns1).��gAd, ((��g�ren)ns2).��gAd);}
        }
        public static IComparer ��gAdlaS�rala {get {return (IComparer)new S�ralamaYard�mc�s�();}} //�stteki yard�mc�n�n �zelli�i
    }
    public class K�yasc�: IComparer<string> {
        public int Compare (string x, string y) {//Uzunu b�y�k, e�uzunsa artan s�ral�
            if (x == null | y == null) {return -1; //null'lar� c�mleye dahil etme
            }else {
                int uzn = x.Length.CompareTo (y.Length);
                if (uzn != 0) {return uzn; //Uzunu artan s�rala
                }else {return x.CompareTo (y);} //Ayn� uzunlar� normal a-z s�rala
                
            }
        }
    }
    public class TersK�yas: IComparer<string> {//Sadece y k�yaslay�c� �n�ne konur
        public int Compare (string x, string y) {return y.CompareTo(x);}
    }
    class TersK�yas2 : IComparer {//Sadece y k�yaslay�c� �nce konur
        int IComparer.Compare (Object x, Object y) {return((new CaseInsensitiveComparer()).Compare (y, x));}
   }
    class VeriYap�s�9B {
        private static void G�ster (List<string> liste) {
            foreach (string klm in liste) {Console.Write (klm+" ");} Console.WriteLine();
        }
        private static void AraVeSok (List<string> liste, string sok, K�yasc� kys) {//Yeni kelimeyi uygun artan s�ral� endeksine sok
            int endeks = liste.BinarySearch (sok, kys);
            if (endeks < 0) liste.Insert (~endeks, sok);
        }
        public static void EndeksliDe�erYaz (String[] dizi) {
            for (int i = 0; i < dizi.Length; i++) Console.Write ("[{0}]:{1} ", i, dizi [i]); Console.WriteLine();
        }
        static void Main() {
            Console.Write ("IComparable ebeveyn IComparable.CompareTo()'yu, IComparer ise IComparer.Compare()'i ister. Ters s�ralamada sadece ilk ve ikinci k�yaslanacak parametreler yerde�i�tirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��g�ren diziyi ad'a ve no'ya g�re s�ralama:");
            int i, j, ts1, ts2; string ad; var r=new Random();
            ��g�ren[] i�gDizi1 = new ��g�ren [10]; ��g�ren[] i�gDizi2 = new ��g�ren [10]; ��g�ren[] i�gDizi3 = new ��g�ren [10];
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1000,10000);
                i�gDizi1 [i]=new ��g�ren (ts1, ad); i�gDizi2 [i]=new ��g�ren (ts1, ad); i�gDizi3 [i]=new ��g�ren (ts1, ad);
            }
            Array.Sort (i�gDizi2);
            Array.Sort (i�gDizi3, ��g�ren.��gAdlaS�rala);
            Console.WriteLine ("\tRasgele, no'yla ve ad'la artan s�ral� i�gDizi:");
            for(i=0;i<i�gDizi1.Length;i++) Console.WriteLine ("{0}\t{1}\t{2}", i�gDizi1 [i], i�gDizi2 [i], i�gDizi3 [i]);
            Console.WriteLine ("\t<, <=, >, >=, ==, != k�yaslamalar:");
            for(i=0;i<i�gDizi1.Length;i++) {
                Console.WriteLine ("{0} < {1}? {2,-10}>? {3,-10}==? {4,-10}!=? {5,-10}", i�gDizi2 [i].��gNo, i�gDizi3 [i].��gNo,
                    i�gDizi2 [i].��gNo < i�gDizi3 [i].��gNo,
                    i�gDizi2 [i].��gNo > i�gDizi3 [i].��gNo,
                    i�gDizi2 [i].��gNo == i�gDizi3 [i].��gNo,
                    i�gDizi2 [i].��gNo != i�gDizi3 [i].��gNo);
            }

            Console.WriteLine ("\nKelimeleri uzunlu�a ve ayn�larsa a-z s�ralayan k�yasc�:");
            List<string> kelimeler = new List<string>();
            kelimeler.Add ("M"); kelimeler.Add ("Nihat"); kelimeler.Add ("Yava�"); kelimeler.Add ("Akbelen"); kelimeler.Add ("Mersin"); kelimeler.Add ("tr");
            Console.Write ("Orijinal c�mle: "); G�ster (kelimeler);
            K�yasc� k�yas = new K�yasc�();
            kelimeler.Sort (k�yas);
            Console.Write ("Uzunlu�a artan s�ral� c�mle: "); G�ster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, k�yas);
            Console.Write ("'{0}' ilaveli s�ral� c�mle: ", ad); G�ster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, k�yas);
            Console.Write ("'{0}' ilaveli s�ral� c�mle: ", ad); G�ster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, k�yas);
            Console.Write ("'{0}' ilaveli s�ral� c�mle: ", ad); G�ster (kelimeler);
            AraVeSok (kelimeler, null, k�yas);
            Console.Write ("'null' ilaveli s�ral� c�mle: ", ad); G�ster (kelimeler);

            Console.WriteLine ("\nMallar[10]:kilolar[10] dizilerinin �e�itli s�ral� sunumlar�:");
            string[] mallar = new string [10];
            int[] kilolar = new int [mallar.Length];
            for(i=0;i<mallar.Length;i++) {
                ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1,50);
                mallar [i]=ad;
                kilolar [i]=ts1;
            }
            Console.Write ("�lk: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar);
            Console.Write ("AZ: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            TersK�yas tk = new TersK�yas();
            Array.Sort (mallar, kilolar, tk);
            Console.Write ("ZA: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar, 5, 5);
            Console.Write ("AZ(5,5): "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar, 3, 5, tk);
            Console.Write ("ZA(3,5): "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();

            Console.WriteLine ("\nKelimeleri normal artan ve byk/k�k-duyars�z azalan tam/altk�meli s�ralamalar:");
            String[] dzgDizi = {"M", "nihat", "Yava�", "Mersin", "tr", "33", "��el", "0324"};
            Console.Write ("�lk: "); EndeksliDe�erYaz (dzgDizi);
            Array.Sort (dzgDizi); Console.Write ("Az: "); EndeksliDe�erYaz (dzgDizi);
            IComparer tk2 = new TersK�yas2(); Array.Sort (dzgDizi, tk2); Console.Write ("zA: "); EndeksliDe�erYaz (dzgDizi);
            Array.Sort (dzgDizi, 3, 5); Console.Write ("Az(3,5): "); EndeksliDe�erYaz (dzgDizi);
            Array.Sort (dzgDizi, 3, 5, tk2); Console.Write ("zA(3,5): "); EndeksliDe�erYaz (dzgDizi);
            Array.Sort (dzgDizi); Console.Write ("Az: "); EndeksliDe�erYaz (dzgDizi);
            Array.Sort (dzgDizi, tk2); Console.Write ("zA: "); EndeksliDe�erYaz (dzgDizi);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}