// j2sc#1106b.cs: List<T> s�rala, ekle/sil/gir/al, Capacity/Count ve delege �rne�i.

using System;
using System.Collections.Generic; // List<T> i�in
namespace VeriYap�lar� {
    public class ��g�ren : IComparable<��g�ren> {
        private int i�gNo;
        public ��g�ren (int n) {i�gNo = n;}
        public override string ToString() {return i�gNo.ToString();}
        //public bool Equals (��g�ren �u) {if (this.i�gNo == �u.i�gNo) {return true;} else {return false;}}
        public int CompareTo (��g�ren �u) {return �u.i�gNo.CompareTo (this.i�gNo);} //�u-->this: azalan s�ralama
    }
    class VeriYap�s�6B {
        static double KareK�k (int x) {return Math.Sqrt (x);}
        public static bool Bul (int n) {return n.Equals (79);}
        private static void Yaz (string ad) {Console.Write (ad+" ");}
        static void Main() {
            Console.Write ("Liste azalan s�ralama i�in CompareTo(�u-->bu) de�i�imi yeterlidir. Sunumlar foreach, ForEach ile dahili, delegeli veya harici metotla yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Int32/artan ve ��g�ren/azalan tipli listeleri kurma, s�ralama ve sunma:");
            int i, ts1; var r=new Random();
            List<��g�ren> i�g1 = new List<��g�ren>();
            List<Int32> tl1 = new List<Int32>();
            for(i = 0;i<15;i++) {
                ts1=r.Next(1000,10000);
                i�g1.Add (new ��g�ren (ts1));
                tl1.Add (ts1);
            }
            tl1.Sort(); for(i = 0;i<tl1.Count;i++) Console.Write ("{0} ", tl1 [i].ToString()); Console.WriteLine();
            i�g1.Sort(); for(i = 0;i<i�g1.Count;i++) Console.Write ("{0} ", i�g1 [i].ToString()); Console.WriteLine();

            Console.WriteLine ("\nSadece 1 ve kendiyle b�l�nebilen asal say�lar (<500) listesi:");
            List<int> say�lar = new List<int>();
            for(i=2;i<=500;i++) say�lar.Add (i); //T�m 2-->1000 say�lar listesi
            for(i=2;i<=10;i++) say�lar.RemoveAll (delegate (int x) {return x>i && x%i==0;}); //2-->10'a b�l�nebilenleri listeden sil
            say�lar.ForEach (delegate (int asal) {Console.Write (asal+" ");}); Console.WriteLine();
            Console.WriteLine ("\tAsal say�lar�n Math.Sqrt ile karek�kleri:");
            say�lar.ForEach (delegate (int n) {Console.Write ("{0:0.00} ", Math.Sqrt (n));}); Console.WriteLine();
            Console.WriteLine ("\tAsal say�lar�n int-->double �evici'yle karek�kleri:");
            Converter<int, double> �evirici = KareK�k;
            List<double> dl1 = say�lar.ConvertAll<double> (�evirici);
            foreach (double d in dl1) Console.Write ("{0:0.00} ", d); Console.WriteLine();
            Console.WriteLine ("Listede \"79\" mevcut mu? {0}", say�lar.Contains (79)?"Evet":"Hay�r");
            Console.WriteLine ("Listede \"79\" mevcut mu? {0}", say�lar.Find (Bul)==79?"Evet":"Hay�r");
            Console.WriteLine ("Normalde: [Kapasite={0},\tSay�={1}]", dl1.Capacity, dl1.Count);
            dl1.Add (Math.Sqrt(501)); dl1.Remove (Math.Sqrt(501));
            Console.WriteLine ("1 ekle/Add, 1 sil/Remove sonras�: [Kapasite={0},\tSay�={1}]", dl1.Capacity, dl1.Count);
            dl1.TrimExcess();
            Console.WriteLine ("TrimExcess()/Fazlay�K�rp sonras�: [Kapasite={0},\tSay�={1}]", dl1.Capacity, dl1.Count);
            dl1.Clear();
            Console.WriteLine ("Clear()/Temizle sonras�: [Kapasite={0},\tSay�={1}]", dl1.Capacity, dl1.Count);

            Console.WriteLine ("\nListe kurma, erimli ekleme/silme/girme, par�a kopyalama ve sunumlar�:");
            string[] adlar = {"Nihat","Ahmet","Sevim","Mustafa","Tangut"};
            List<string> adListe = new List<string> (adlar);
            Console.Write ("==>Orijinal: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adListe.AddRange (adlar);
            Console.Write ("==>AddRange (adlar) sonras�: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adListe.RemoveRange (2, 3);
            Console.Write ("==>RemoveRange(2,3) sonras�: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            adlar = new string[] {"Cemal","Naif","Elif"};
            adListe.InsertRange (3, adlar);
            Console.Write ("==>InsertRange(3,adlar) sonras�: "); foreach (string ad in adListe) Console.Write (ad+" "); Console.WriteLine();
            string[] adlar2 = adListe.GetRange (2, 3).ToArray();
            Console.Write ("==>adListe.GetRange (2, 3).ToArray() sonras�: "); foreach (string ad in adlar2) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("==>Metotlu sunum: "); adListe.ForEach (Yaz); Console.WriteLine();
            Console.Write ("==>Delegeli sunum: "); adListe.ForEach (delegate (String ad) {Console.Write (ad+" ");}); Console.WriteLine();
            Console.WriteLine ("�lk, orta, son adlar: " + adListe [0] + ", " + adListe [adListe.Count/2] + ", " + adListe [adListe.Count-1]);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}