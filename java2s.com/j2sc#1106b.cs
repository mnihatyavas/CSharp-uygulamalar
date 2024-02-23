// j2sc#1106b.cs: List<T> sýrala, ekle/sil/gir/al, Capacity/Count ve delege örneði.

using System;
using System.Collections.Generic; // List<T> için
namespace VeriYapýlarý {
    public class Ýþgören : IComparable<Ýþgören> {
        private int iþgNo;
        public Ýþgören (int n) {iþgNo = n;}
        public override string ToString() {return iþgNo.ToString();}
        //public bool Equals (Ýþgören þu) {if (this.iþgNo == þu.iþgNo) {return true;} else {return false;}}
        public int CompareTo (Ýþgören þu) {return þu.iþgNo.CompareTo (this.iþgNo);} //þu-->this: azalan sýralama
    }
    class VeriYapýsý6B {
        static double KareKök (int x) {return Math.Sqrt (x);}
        public static bool Bul (int n) {return n.Equals (79);}
        private static void Yaz (string ad) {Console.Write (ad+" ");}
        static void Main() {
            Console.Write ("Liste azalan sýralama için CompareTo(þu-->bu) deðiþimi yeterlidir. Sunumlar foreach, ForEach ile dahili, delegeli veya harici metotla yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Int32/artan ve Ýþgören/azalan tipli listeleri kurma, sýralama ve sunma:");
            int i, ts1; var r=new Random();
            List<Ýþgören> iþg1 = new List<Ýþgören>();
            List<Int32> tl1 = new List<Int32>();
            for(i = 0;i<15;i++) {
                ts1=r.Next(1000,10000);
                iþg1.Add (new Ýþgören (ts1));
                tl1.Add (ts1);
            }
            tl1.Sort(); for(i = 0;i<tl1.Count;i++) Console.Write ("{0} ", tl1 [i].ToString()); Console.WriteLine();
            iþg1.Sort(); for(i = 0;i<iþg1.Count;i++) Console.Write ("{0} ", iþg1 [i].ToString()); Console.WriteLine();

            Console.WriteLine ("\nSadece 1 ve kendiyle bölünebilen asal sayýlar (<500) listesi:");
            List<int> sayýlar = new List<int>();
            for(i=2;i<=500;i++) sayýlar.Add (i); //Tüm 2-->1000 sayýlar listesi
            for(i=2;i<=10;i++) sayýlar.RemoveAll (delegate (int x) {return x>i && x%i==0;}); //2-->10'a bölünebilenleri listeden sil
            sayýlar.ForEach (delegate (int asal) {Console.Write (asal+" ");}); Console.WriteLine();
            Console.WriteLine ("\tAsal sayýlarýn Math.Sqrt ile karekökleri:");
            sayýlar.ForEach (delegate (int n) {Console.Write ("{0:0.00} ", Math.Sqrt (n));}); Console.WriteLine();
            Console.WriteLine ("\tAsal sayýlarýn int-->double çevici'yle karekökleri:");
            Converter<int, double> çevirici = KareKök;
            List<double> dl1 = sayýlar.ConvertAll<double> (çevirici);
            foreach (double d in dl1) Console.Write ("{0:0.00} ", d); Console.WriteLine();
            Console.WriteLine ("Listede \"79\" mevcut mu? {0}", sayýlar.Contains (79)?"Evet":"Hayýr");
            Console.WriteLine ("Listede \"79\" mevcut mu? {0}", sayýlar.Find (Bul)==79?"Evet":"Hayýr");
            Console.WriteLine ("Normalde: [Kapasite={0},\tSayý={1}]", dl1.Capacity, dl1.Count);
            dl1.Add (Math.Sqrt(501)); dl1.Remove (Math.Sqrt(501));
            Console.WriteLine ("1 ekle/Add, 1 sil/Remove sonrasý: [Kapasite={0},\tSayý={1}]", dl1.Capacity, dl1.Count);
            dl1.TrimExcess();
            Console.WriteLine ("TrimExcess()/FazlayýKýrp sonrasý: [Kapasite={0},\tSayý={1}]", dl1.Capacity, dl1.Count);
            dl1.Clear();
            Console.WriteLine ("Clear()/Temizle sonrasý: [Kapasite={0},\tSayý={1}]", dl1.Capacity, dl1.Count);

            Console.WriteLine ("\nListe kurma, erimli ekleme/silme/girme, parça kopyalama ve sunumlarý:");
            string[] adlar = {"Nihat","Ahmet","Sevim","Mustafa","Tangut"};
            List<string> adListe = new List<string> (adlar);
            Console.Write ("==>Orijinal: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adListe.AddRange (adlar);
            Console.Write ("==>AddRange (adlar) sonrasý: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adListe.RemoveRange (2, 3);
            Console.Write ("==>RemoveRange(2,3) sonrasý: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adlar = new string[] {"Cemal","Naif","Elif"};
            adListe.InsertRange (3, adlar);
            Console.Write ("==>InsertRange(3,adlar) sonrasý: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            string[] adlar2 = adListe.GetRange (2, 3).ToArray();
            Console.Write ("==>adListe.GetRange (2, 3).ToArray() sonrasý: "); foreach (string ad in adlar2) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("==>Metotlu sunum: "); adListe.ForEach (Yaz); Console.WriteLine();
            Console.Write ("==>Delegeli sunum: "); adListe.ForEach (delegate (String ad) {Console.Write (ad+" ");}); Console.WriteLine();
            Console.WriteLine ("Ýlk, orta, son adlar: " + adListe [0] + ", " + adListe [adListe.Count/2] + ", " + adListe [adListe.Count-1]);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}