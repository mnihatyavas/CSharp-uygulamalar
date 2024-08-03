// j2sc#1803a.cs: SoysalSýnýf<T1,T2> ve SoysalMetot<T>(T prm) örneði.

using System;
using System.Collections.Generic; //EqualityComparer, Stack<T> için
using System.Collections; //Stack için
using System.Reflection; //MethodInfo için
namespace SoysalSýnýf {
    class Soysal1<T> {
        T ns;
        public Soysal1 (T n) {ns = n;} //Kurucu
        public T nsAl() {return ns;}
        public void tipGöster() {Console.Write ("T'nin tipi: {0,-14}", typeof (T));}
    }
    class Soysal2<T1, T2> {
        T1 ns1;
        T2 ns2;
        public Soysal2 (T1 n1, T2 n2) {ns1 = n1; ns2 = n2;} //Kurucu
        public void tipGöster() {Console.Write ("Tip&Deðer(ns1, ns2): ({0}, {1}) = ", typeof (T1), typeof (T2));}
        public T1 ns1Al() {return ns1;}
        public T2 ns2Al() {return ns2;}
    }
    public sealed class SoysalÇift<TÝlk, TÝkinci>: IEquatable<SoysalÇift<TÝlk, TÝkinci>> {
        private readonly TÝlk ilk; readonly TÝkinci ikinci;
        public SoysalÇift (TÝlk ilk, TÝkinci ikinci) {this.ilk = ilk; this.ikinci = ikinci;} //Kurucu
        public TÝlk Ýlk {get {return ilk;}}
        public TÝkinci Ýkinci {get {return ikinci;}}
        public bool EþitMi (SoysalÇift<TÝlk, TÝkinci> þu) {
            if (þu == null) return false;
            return EqualityComparer<TÝlk>.Default.Equals (this.Ýlk, þu.Ýlk) && EqualityComparer<TÝkinci>.Default.Equals (this.Ýkinci, þu.Ýkinci);
        }
        //public override bool Equals (object ns) {return true;} //Gereksiz
        public bool Equals (SoysalÇift<TÝlk, TÝkinci> þu) {return true;} //Varsayýlý
        //public override int GetHashCode() {return EqualityComparer<TÝlk>.Default.GetHashCode (ilk) * 37 + EqualityComparer<TÝkinci>.Default.GetHashCode (ikinci);} //Gereksiz
    }
    class DiziEbatlarý {public static bool EbatBüyükMü<T> (T[] dz1, T[] dz2) {if (dz1.Length > dz2.Length) return true; return false;}}
    class DiziyiYaz {  
        public static void yaz<T>(T tek, T[] dizi) {
            string sonuç=typeof (T) + "(" + tek;
            for(int i= 0;i<dizi.Length;i++) sonuç+=" "+dizi [i]; sonuç+=")";
            Console.WriteLine (sonuç);
        }
    }
    class SoysalT {
        static string ArgümanýDöndür<T> (T prm) {return typeof (T) + ": " + prm;}
        static void SoysalsýzYýðýnýGöster (Stack yýðýn) {foreach (object ns in yýðýn) {Console.Write ((int)ns + " ");} Console.WriteLine();}
        static void SoysalYýðýnýGöster (Stack<int> yýðýn) {foreach (int n in yýðýn) {Console.Write (n + " ");} Console.WriteLine();}
        static List<T> ListeYap<T> (T str1, T str2, T str3, T str4, T str5) {
            List<T> liste = new List<T>();
            liste.Add (str1); liste.Add (str2); liste.Add (str3); liste.Add (str4); liste.Add (str5);
            return liste;
        }
        public static void TipBeyaný<T>() {Console.WriteLine (typeof (T));}
        static void TipiniYaz<T> (T prm1, T prm2) {Console.WriteLine ("\t"+typeof(T));}
        static void Main() {
            Console.Write ("Soysal sýnýf, koleksiyon ve metotla her tip veriyle iþlem yapýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal1<T> sýnýf alanýna int, string, double, bool, long deðerler atama:");
            Soysal1<int> intNesne = new Soysal1<int> (20240717);
            intNesne.tipGöster();
            Console.WriteLine ("\tDeðer: " + intNesne.nsAl());
            Soysal1<string> stringNesne = new Soysal1<string> ("M.Nihat Yavaþ.");
            stringNesne.tipGöster();
            Console.WriteLine ("\tDeðer: " + stringNesne.nsAl());
            Soysal1<double> doubleNesne = new Soysal1<double> (20240717.0701d);
            doubleNesne.tipGöster();
            Console.WriteLine ("\tDeðer: " + doubleNesne.nsAl());
            Soysal1<bool> boolNesne = new Soysal1<bool> (true);
            boolNesne.tipGöster();
            Console.WriteLine ("\tDeðer: " + boolNesne.nsAl());
            Soysal1<long> longNesne = new Soysal1<long> (long.MaxValue);
            longNesne.tipGöster();
            Console.WriteLine ("\tDeðer: " + longNesne.nsAl());

            Console.WriteLine ("\nSoysal2<T1,T2> sýnýf ikili alanýna ayný/farklý veriler atama:");
            Soysal2<int,long> intLongNesne = new Soysal2<int,long> (20240717, 202407170745);
            intLongNesne.tipGöster();
            Console.WriteLine ("({0}, {1})", intLongNesne.ns1Al(), intLongNesne.ns2Al());
            Soysal2<double,float> doubleFloatNesne = new Soysal2<double,float> (240717.0746d, 240717.0747f);
            doubleFloatNesne.tipGöster();
            Console.WriteLine ("({0}, {1})", doubleFloatNesne.ns1Al(), doubleFloatNesne.ns2Al());
            Soysal2<string,bool> stringBoolNesne = new Soysal2<string,bool> ("Z.Nihal Candan", false);
            stringBoolNesne.tipGöster();
            Console.WriteLine ("({0}, {1})", stringBoolNesne.ns1Al(), stringBoolNesne.ns2Al());
            Soysal2<char,char> charCharNesne = new Soysal2<char,char> ('A', 'z');
            charCharNesne.tipGöster();
            Console.WriteLine ("({0}, {1})", charCharNesne.ns1Al(), charCharNesne.ns2Al());

            Console.WriteLine ("\n2 farklý tiplemeli SoysalÇift<TÝlk,TÝkinci>'nin eþitlik kontrolu:");
            SoysalÇift<int,long> sç1a = new SoysalÇift<int,long> (20240721, 202407210156);
            SoysalÇift<int,long> sç1b = new SoysalÇift<int,long> (20240721, 202407210156);
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", sç1a.Ýlk, sç1a.Ýkinci, sç1b.Ýlk, sç1b.Ýkinci, sç1a.EþitMi (sç1b)?"EÞÝT":"EÞÝT DEÐÝL");
            SoysalÇift<double,float> sç2a = new SoysalÇift<double,float> (202407210225.59486d, 20240721.0225f);
            SoysalÇift<double,float> sç2b = new SoysalÇift<double,float> (202407210225.59487d, 20240721.0225f);
            Console.WriteLine ("({0},{1}) == ({2},{3})? {4}", sç2a.Ýlk, sç2a.Ýkinci, sç2b.Ýlk, sç2b.Ýkinci, sç2a.EþitMi (sç2b)?"EÞÝT":"EÞÝT DEÐÝL");
            SoysalÇift<string,bool> sç3a = new SoysalÇift<string,bool> ("Z.Nihal Candan", true);
            SoysalÇift<string,bool> sç3b = new SoysalÇift<string,bool> ("M.Nihat Yavaþ", false);
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", sç3a.Ýlk, sç3a.Ýkinci, sç3b.Ýlk, sç3b.Ýkinci, sç3a.EþitMi (sç3b)?"EÞÝT":"EÞÝT DEÐÝL");
            SoysalÇift<char,char> sç4a = new SoysalÇift<char,char> ('A', 'A');
            SoysalÇift<char,char> sç4b = new SoysalÇift<char,char> ('A', 'A');
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", sç4a.Ýlk, sç4a.Ýkinci, sç4b.Ýlk, sç4b.Ýkinci, sç4a.EþitMi (sç4b)?"EÞÝT":"EÞÝT DEÐÝL");

            Console.WriteLine ("\nSoysal tipli metotla farklý tipte dizi ebat büyüklük kontrolu:");
            int[] intDizi1 = {1881, 1919, 1920, 1923, 1938};
            int[] intDizi2 = new int [10];
            Console.WriteLine ("DiziEbat({0} > {1})? {2}", intDizi1.Length, intDizi2.Length, DiziEbatlarý.EbatBüyükMü (intDizi1, intDizi2));
            string[] strDizi1 = {"Cumhurbaþkaný", "Gazi", "Mustafa", "Kemal", "Atatürk"};
            string[] strDizi2 = {"Gazi", "Mustafa", "Kemal", "Paþa"};
            Console.WriteLine ("DiziEbat({0} > {1})? {2}", strDizi1.Length, strDizi2.Length, DiziEbatlarý.EbatBüyükMü (strDizi1, strDizi2));

            Console.WriteLine ("\nSoysal metotun parametre tip ve deðerini geri döndürmesi:");
            Console.WriteLine (ArgümanýDöndür<int> (20240721));
            Console.WriteLine (ArgümanýDöndür<string> ("M.Nihat Yavaþ"));
            Console.WriteLine (ArgümanýDöndür<double> (20240721033845.389));
            Console.WriteLine (ArgümanýDöndür<byte> (111));
            Console.WriteLine (ArgümanýDöndür<bool> (true));

            Console.WriteLine ("\nTek ve dizi elemanlarýný ve tipini dökümleyen soysal metot:");
            int[] yýllar = new int [1938-1881];
            int i, ts;
            for(i= 0;i<yýllar.Length;i++) yýllar [i] = i+1882;
            DiziyiYaz.yaz (1881, yýllar);
            string[] kelimeler = {"genel", "soysal", "tipli", "metot", "çok", "güçlüdür."};
            DiziyiYaz.yaz ("C#'daki", kelimeler);

            Console.WriteLine ("\nSoysalsýz (int)Yýðýn1 ve soysal Yýðýn2<int> dökümleri:");
            Stack yýðýn1 = new Stack();
            var r=new Random();
            Console.Write ("Yýðýn1 Peek: ");
            for(i=0;i<5;i++) {
                ts=r.Next(1881,1939); yýðýn1.Push (ts);
                Console.Write ((int)yýðýn1.Peek() + " ");
            } Console.WriteLine();
            Console.Write ("Yýðýn1 foreach: "); SoysalsýzYýðýnýGöster (yýðýn1);
            Console.Write ("Yýðýn2<int> Peek: ");
            Stack<int> yýðýn2 = new Stack<int>();
            for(i=0;i<5;i++) {
                ts=r.Next(1881,1939); yýðýn2.Push (ts);
                Console.Write (yýðýn2.Peek() + " ");
            } Console.WriteLine();
            Console.Write ("Yýðýn2<int> foreach: ");SoysalYýðýnýGöster (yýðýn2);

            Console.WriteLine ("\nListe1<string> ve Liste2<int> liste yapma ve döküm:");
            List<string> liste1 = ListeYap<string> ("Atatürk-1881", "Atatürk-1919", "Atatürk-1920", "Atatürk-1923", "Atatürk-1938");
            Console.Write ("Liste1<string> foreach: ");
            foreach (string x in liste1) Console.Write (x+" "); Console.WriteLine();
            List<int> liste2 = ListeYap<int> (1881, 1919, 1920, 1923, 1938);
            Console.Write ("Liste2<int> foreach: ");
            foreach (int x in liste2) Console.Write (x+" "); Console.WriteLine();

            Console.WriteLine ("\ntypeof(T) ile metot parametre tipini saptama:");
            Type tip = typeof (SoysalT);
            MethodInfo mi = tip.GetMethod ("TipBeyaný");
            MethodInfo kurulan;
            kurulan = mi.MakeGenericMethod (typeof (string));
            kurulan.Invoke (null, null);
            kurulan = mi.MakeGenericMethod (typeof (long));
            kurulan.Invoke (null, null);
            kurulan = mi.MakeGenericMethod (typeof (double));
            kurulan.Invoke (null, null);
            kurulan = mi.MakeGenericMethod (typeof (byte));
            kurulan.Invoke (null, null);
            TipiniYaz (1923, new object());
            TipiniYaz (1923, 1938);
            TipiniYaz (1923, 1938F);
            TipiniYaz (true, false);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}