// j2sc#1109b.cs: IComparer ebeveynli Compare()'le düz/ters sýralama örneði.

using System;
using System.Collections;
using System.Collections.Generic;
namespace VeriYapýlarý {
    public class Ýþgören : IComparable {
        private int iþgNo;
        private string iþgAd;
        public int ÝþgNo {get{return iþgNo;} set{iþgNo = value;}} //Özellik
        public string ÝþgAd {get{return iþgAd;} set{iþgAd = value;}} //Özellik
        public Ýþgören(){} //Kurucu-1
        public Ýþgören (int no, string ad) {iþgNo = no; iþgAd = ad;} //Kurucu-2
        public override string ToString() {return String.Format ("{0}: {1}",iþgNo, iþgAd);}
        int IComparable.CompareTo (object ns) {// Varsayýlý iþgNo'yla artan sýralý Sort() için
            if (this.iþgNo > ((Ýþgören)ns).iþgNo) return 1;
            if (this.iþgNo < ((Ýþgören)ns).iþgNo) return -1;
            return 0;
        }
        private class SýralamaYardýmcýsý : IComparer {// Varsayýlý iþgAd'la artan sýralý Sort() için
            int IComparer.Compare (object ns1, object ns2) {return String.Compare (((Ýþgören)ns1).ÝþgAd, ((Ýþgören)ns2).ÝþgAd);}
        }
        public static IComparer ÝþgAdlaSýrala {get {return (IComparer)new SýralamaYardýmcýsý();}} //Üstteki yardýmcýnýn özelliði
    }
    public class Kýyascý: IComparer<string> {
        public int Compare (string x, string y) {//Uzunu büyük, eþuzunsa artan sýralý
            if (x == null | y == null) {return -1; //null'larý cümleye dahil etme
            }else {
                int uzn = x.Length.CompareTo (y.Length);
                if (uzn != 0) {return uzn; //Uzunu artan sýrala
                }else {return x.CompareTo (y);} //Ayný uzunlarý normal a-z sýrala
                
            }
        }
    }
    public class TersKýyas: IComparer<string> {//Sadece y kýyaslayýcý önüne konur
        public int Compare (string x, string y) {return y.CompareTo(x);}
    }
    class TersKýyas2 : IComparer {//Sadece y kýyaslayýcý önce konur
        int IComparer.Compare (Object x, Object y) {return((new CaseInsensitiveComparer()).Compare (y, x));}
   }
    class VeriYapýsý9B {
        private static void Göster (List<string> liste) {
            foreach (string klm in liste) {Console.Write (klm+" ");} Console.WriteLine();
        }
        private static void AraVeSok (List<string> liste, string sok, Kýyascý kys) {//Yeni kelimeyi uygun artan sýralý endeksine sok
            int endeks = liste.BinarySearch (sok, kys);
            if (endeks < 0) liste.Insert (~endeks, sok);
        }
        public static void EndeksliDeðerYaz (String[] dizi) {
            for (int i = 0; i < dizi.Length; i++) Console.Write ("[{0}]:{1} ", i, dizi [i]); Console.WriteLine();
        }
        static void Main() {
            Console.Write ("IComparable ebeveyn IComparable.CompareTo()'yu, IComparer ise IComparer.Compare()'i ister. Ters sýralamada sadece ilk ve ikinci kýyaslanacak parametreler yerdeðiþtirir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýþgören diziyi ad'a ve no'ya göre sýralama:");
            int i, j, ts1, ts2; string ad; var r=new Random();
            Ýþgören[] iþgDizi1 = new Ýþgören [10]; Ýþgören[] iþgDizi2 = new Ýþgören [10]; Ýþgören[] iþgDizi3 = new Ýþgören [10];
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1000,10000);
                iþgDizi1 [i]=new Ýþgören (ts1, ad); iþgDizi2 [i]=new Ýþgören (ts1, ad); iþgDizi3 [i]=new Ýþgören (ts1, ad);
            }
            Array.Sort (iþgDizi2);
            Array.Sort (iþgDizi3, Ýþgören.ÝþgAdlaSýrala);
            Console.WriteLine ("\tRasgele, no'yla ve ad'la artan sýralý iþgDizi:");
            for(i=0;i<iþgDizi1.Length;i++) Console.WriteLine ("{0}\t{1}\t{2}", iþgDizi1 [i], iþgDizi2 [i], iþgDizi3 [i]);
            Console.WriteLine ("\t<, <=, >, >=, ==, != kýyaslamalar:");
            for(i=0;i<iþgDizi1.Length;i++) {
                Console.WriteLine ("{0} < {1}? {2,-10}>? {3,-10}==? {4,-10}!=? {5,-10}", iþgDizi2 [i].ÝþgNo, iþgDizi3 [i].ÝþgNo,
                    iþgDizi2 [i].ÝþgNo < iþgDizi3 [i].ÝþgNo,
                    iþgDizi2 [i].ÝþgNo > iþgDizi3 [i].ÝþgNo,
                    iþgDizi2 [i].ÝþgNo == iþgDizi3 [i].ÝþgNo,
                    iþgDizi2 [i].ÝþgNo != iþgDizi3 [i].ÝþgNo);
            }

            Console.WriteLine ("\nKelimeleri uzunluða ve aynýlarsa a-z sýralayan kýyascý:");
            List<string> kelimeler = new List<string>();
            kelimeler.Add ("M"); kelimeler.Add ("Nihat"); kelimeler.Add ("Yavaþ"); kelimeler.Add ("Akbelen"); kelimeler.Add ("Mersin"); kelimeler.Add ("tr");
            Console.Write ("Orijinal cümle: "); Göster (kelimeler);
            Kýyascý kýyas = new Kýyascý();
            kelimeler.Sort (kýyas);
            Console.Write ("Uzunluða artan sýralý cümle: "); Göster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, kýyas);
            Console.Write ("'{0}' ilaveli sýralý cümle: ", ad); Göster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, kýyas);
            Console.Write ("'{0}' ilaveli sýralý cümle: ", ad); Göster (kelimeler);
            ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
            AraVeSok (kelimeler, ad, kýyas);
            Console.Write ("'{0}' ilaveli sýralý cümle: ", ad); Göster (kelimeler);
            AraVeSok (kelimeler, null, kýyas);
            Console.Write ("'null' ilaveli sýralý cümle: ", ad); Göster (kelimeler);

            Console.WriteLine ("\nMallar[10]:kilolar[10] dizilerinin çeþitli sýralý sunumlarý:");
            string[] mallar = new string [10];
            int[] kilolar = new int [mallar.Length];
            for(i=0;i<mallar.Length;i++) {
                ad=""; ts1=r.Next(1,5); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1,50);
                mallar [i]=ad;
                kilolar [i]=ts1;
            }
            Console.Write ("Ýlk: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar);
            Console.Write ("AZ: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            TersKýyas tk = new TersKýyas();
            Array.Sort (mallar, kilolar, tk);
            Console.Write ("ZA: "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar, 5, 5);
            Console.Write ("AZ(5,5): "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();
            Array.Sort (mallar, kilolar, 3, 5, tk);
            Console.Write ("ZA(3,5): "); for(i=0;i<mallar.Length;i++) Console.Write ("{0}:{1} ", mallar [i], kilolar [i]); Console.WriteLine();

            Console.WriteLine ("\nKelimeleri normal artan ve byk/kçk-duyarsýz azalan tam/altkümeli sýralamalar:");
            String[] dzgDizi = {"M", "nihat", "Yavaþ", "Mersin", "tr", "33", "Ýçel", "0324"};
            Console.Write ("Ýlk: "); EndeksliDeðerYaz (dzgDizi);
            Array.Sort (dzgDizi); Console.Write ("Az: "); EndeksliDeðerYaz (dzgDizi);
            IComparer tk2 = new TersKýyas2(); Array.Sort (dzgDizi, tk2); Console.Write ("zA: "); EndeksliDeðerYaz (dzgDizi);
            Array.Sort (dzgDizi, 3, 5); Console.Write ("Az(3,5): "); EndeksliDeðerYaz (dzgDizi);
            Array.Sort (dzgDizi, 3, 5, tk2); Console.Write ("zA(3,5): "); EndeksliDeðerYaz (dzgDizi);
            Array.Sort (dzgDizi); Console.Write ("Az: "); EndeksliDeðerYaz (dzgDizi);
            Array.Sort (dzgDizi, tk2); Console.Write ("zA: "); EndeksliDeðerYaz (dzgDizi);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}