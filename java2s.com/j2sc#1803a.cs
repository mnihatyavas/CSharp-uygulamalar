// j2sc#1803a.cs: SoysalS�n�f<T1,T2> ve SoysalMetot<T>(T prm) �rne�i.

using System;
using System.Collections.Generic; //EqualityComparer, Stack<T> i�in
using System.Collections; //Stack i�in
using System.Reflection; //MethodInfo i�in
namespace SoysalS�n�f {
    class Soysal1<T> {
        T ns;
        public Soysal1 (T n) {ns = n;} //Kurucu
        public T nsAl() {return ns;}
        public void tipG�ster() {Console.Write ("T'nin tipi: {0,-14}", typeof (T));}
    }
    class Soysal2<T1, T2> {
        T1 ns1;
        T2 ns2;
        public Soysal2 (T1 n1, T2 n2) {ns1 = n1; ns2 = n2;} //Kurucu
        public void tipG�ster() {Console.Write ("Tip&De�er(ns1, ns2): ({0}, {1}) = ", typeof (T1), typeof (T2));}
        public T1 ns1Al() {return ns1;}
        public T2 ns2Al() {return ns2;}
    }
    public sealed class Soysal�ift<T�lk, T�kinci>: IEquatable<Soysal�ift<T�lk, T�kinci>> {
        private readonly T�lk ilk; readonly T�kinci ikinci;
        public Soysal�ift (T�lk ilk, T�kinci ikinci) {this.ilk = ilk; this.ikinci = ikinci;} //Kurucu
        public T�lk �lk {get {return ilk;}}
        public T�kinci �kinci {get {return ikinci;}}
        public bool E�itMi (Soysal�ift<T�lk, T�kinci> �u) {
            if (�u == null) return false;
            return EqualityComparer<T�lk>.Default.Equals (this.�lk, �u.�lk) && EqualityComparer<T�kinci>.Default.Equals (this.�kinci, �u.�kinci);
        }
        //public override bool Equals (object ns) {return true;} //Gereksiz
        public bool Equals (Soysal�ift<T�lk, T�kinci> �u) {return true;} //Varsay�l�
        //public override int GetHashCode() {return EqualityComparer<T�lk>.Default.GetHashCode (ilk) * 37 + EqualityComparer<T�kinci>.Default.GetHashCode (ikinci);} //Gereksiz
    }
    class DiziEbatlar� {public static bool EbatB�y�kM�<T> (T[] dz1, T[] dz2) {if (dz1.Length > dz2.Length) return true; return false;}}
    class DiziyiYaz {  
        public static void yaz<T>(T tek, T[] dizi) {
            string sonu�=typeof (T) + "(" + tek;
            for(int i= 0;i<dizi.Length;i++) sonu�+=" "+dizi [i]; sonu�+=")";
            Console.WriteLine (sonu�);
        }
    }
    class SoysalT {
        static string Arg�man�D�nd�r<T> (T prm) {return typeof (T) + ": " + prm;}
        static void Soysals�zY���n�G�ster (Stack y���n) {foreach (object ns in y���n) {Console.Write ((int)ns + " ");} Console.WriteLine();}
        static void SoysalY���n�G�ster (Stack<int> y���n) {foreach (int n in y���n) {Console.Write (n + " ");} Console.WriteLine();}
        static List<T> ListeYap<T> (T str1, T str2, T str3, T str4, T str5) {
            List<T> liste = new List<T>();
            liste.Add (str1); liste.Add (str2); liste.Add (str3); liste.Add (str4); liste.Add (str5);
            return liste;
        }
        public static void TipBeyan�<T>() {Console.WriteLine (typeof (T));}
        static void TipiniYaz<T> (T prm1, T prm2) {Console.WriteLine ("\t"+typeof(T));}
        static void Main() {
            Console.Write ("Soysal s�n�f, koleksiyon ve metotla her tip veriyle i�lem yap�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal1<T> s�n�f alan�na int, string, double, bool, long de�erler atama:");
            Soysal1<int> intNesne = new Soysal1<int> (20240717);
            intNesne.tipG�ster();
            Console.WriteLine ("\tDe�er: " + intNesne.nsAl());
            Soysal1<string> stringNesne = new Soysal1<string> ("M.Nihat Yava�.");
            stringNesne.tipG�ster();
            Console.WriteLine ("\tDe�er: " + stringNesne.nsAl());
            Soysal1<double> doubleNesne = new Soysal1<double> (20240717.0701d);
            doubleNesne.tipG�ster();
            Console.WriteLine ("\tDe�er: " + doubleNesne.nsAl());
            Soysal1<bool> boolNesne = new Soysal1<bool> (true);
            boolNesne.tipG�ster();
            Console.WriteLine ("\tDe�er: " + boolNesne.nsAl());
            Soysal1<long> longNesne = new Soysal1<long> (long.MaxValue);
            longNesne.tipG�ster();
            Console.WriteLine ("\tDe�er: " + longNesne.nsAl());

            Console.WriteLine ("\nSoysal2<T1,T2> s�n�f ikili alan�na ayn�/farkl� veriler atama:");
            Soysal2<int,long> intLongNesne = new Soysal2<int,long> (20240717, 202407170745);
            intLongNesne.tipG�ster();
            Console.WriteLine ("({0}, {1})", intLongNesne.ns1Al(), intLongNesne.ns2Al());
            Soysal2<double,float> doubleFloatNesne = new Soysal2<double,float> (240717.0746d, 240717.0747f);
            doubleFloatNesne.tipG�ster();
            Console.WriteLine ("({0}, {1})", doubleFloatNesne.ns1Al(), doubleFloatNesne.ns2Al());
            Soysal2<string,bool> stringBoolNesne = new Soysal2<string,bool> ("Z.Nihal Candan", false);
            stringBoolNesne.tipG�ster();
            Console.WriteLine ("({0}, {1})", stringBoolNesne.ns1Al(), stringBoolNesne.ns2Al());
            Soysal2<char,char> charCharNesne = new Soysal2<char,char> ('A', 'z');
            charCharNesne.tipG�ster();
            Console.WriteLine ("({0}, {1})", charCharNesne.ns1Al(), charCharNesne.ns2Al());

            Console.WriteLine ("\n2 farkl� tiplemeli Soysal�ift<T�lk,T�kinci>'nin e�itlik kontrolu:");
            Soysal�ift<int,long> s�1a = new Soysal�ift<int,long> (20240721, 202407210156);
            Soysal�ift<int,long> s�1b = new Soysal�ift<int,long> (20240721, 202407210156);
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", s�1a.�lk, s�1a.�kinci, s�1b.�lk, s�1b.�kinci, s�1a.E�itMi (s�1b)?"E��T":"E��T DE��L");
            Soysal�ift<double,float> s�2a = new Soysal�ift<double,float> (202407210225.59486d, 20240721.0225f);
            Soysal�ift<double,float> s�2b = new Soysal�ift<double,float> (202407210225.59487d, 20240721.0225f);
            Console.WriteLine ("({0},{1}) == ({2},{3})? {4}", s�2a.�lk, s�2a.�kinci, s�2b.�lk, s�2b.�kinci, s�2a.E�itMi (s�2b)?"E��T":"E��T DE��L");
            Soysal�ift<string,bool> s�3a = new Soysal�ift<string,bool> ("Z.Nihal Candan", true);
            Soysal�ift<string,bool> s�3b = new Soysal�ift<string,bool> ("M.Nihat Yava�", false);
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", s�3a.�lk, s�3a.�kinci, s�3b.�lk, s�3b.�kinci, s�3a.E�itMi (s�3b)?"E��T":"E��T DE��L");
            Soysal�ift<char,char> s�4a = new Soysal�ift<char,char> ('A', 'A');
            Soysal�ift<char,char> s�4b = new Soysal�ift<char,char> ('A', 'A');
            Console.WriteLine ("({0}, {1}) == ({2}, {3})? {4}", s�4a.�lk, s�4a.�kinci, s�4b.�lk, s�4b.�kinci, s�4a.E�itMi (s�4b)?"E��T":"E��T DE��L");

            Console.WriteLine ("\nSoysal tipli metotla farkl� tipte dizi ebat b�y�kl�k kontrolu:");
            int[] intDizi1 = {1881, 1919, 1920, 1923, 1938};
            int[] intDizi2 = new int [10];
            Console.WriteLine ("DiziEbat({0} > {1})? {2}", intDizi1.Length, intDizi2.Length, DiziEbatlar�.EbatB�y�kM� (intDizi1, intDizi2));
            string[] strDizi1 = {"Cumhurba�kan�", "Gazi", "Mustafa", "Kemal", "Atat�rk"};
            string[] strDizi2 = {"Gazi", "Mustafa", "Kemal", "Pa�a"};
            Console.WriteLine ("DiziEbat({0} > {1})? {2}", strDizi1.Length, strDizi2.Length, DiziEbatlar�.EbatB�y�kM� (strDizi1, strDizi2));

            Console.WriteLine ("\nSoysal metotun parametre tip ve de�erini geri d�nd�rmesi:");
            Console.WriteLine (Arg�man�D�nd�r<int> (20240721));
            Console.WriteLine (Arg�man�D�nd�r<string> ("M.Nihat Yava�"));
            Console.WriteLine (Arg�man�D�nd�r<double> (20240721033845.389));
            Console.WriteLine (Arg�man�D�nd�r<byte> (111));
            Console.WriteLine (Arg�man�D�nd�r<bool> (true));

            Console.WriteLine ("\nTek ve dizi elemanlar�n� ve tipini d�k�mleyen soysal metot:");
            int[] y�llar = new int [1938-1881];
            int i, ts;
            for(i= 0;i<y�llar.Length;i++) y�llar [i] = i+1882;
            DiziyiYaz.yaz (1881, y�llar);
            string[] kelimeler = {"genel", "soysal", "tipli", "metot", "�ok", "g��l�d�r."};
            DiziyiYaz.yaz ("C#'daki", kelimeler);

            Console.WriteLine ("\nSoysals�z (int)Y���n1 ve soysal Y���n2<int> d�k�mleri:");
            Stack y���n1 = new Stack();
            var r=new Random();
            Console.Write ("Y���n1 Peek: ");
            for(i=0;i<5;i++) {
                ts=r.Next(1881,1939); y���n1.Push (ts);
                Console.Write ((int)y���n1.Peek() + " ");
            } Console.WriteLine();
            Console.Write ("Y���n1 foreach: "); Soysals�zY���n�G�ster (y���n1);
            Console.Write ("Y���n2<int> Peek: ");
            Stack<int> y���n2 = new Stack<int>();
            for(i=0;i<5;i++) {
                ts=r.Next(1881,1939); y���n2.Push (ts);
                Console.Write (y���n2.Peek() + " ");
            } Console.WriteLine();
            Console.Write ("Y���n2<int> foreach: ");SoysalY���n�G�ster (y���n2);

            Console.WriteLine ("\nListe1<string> ve Liste2<int> liste yapma ve d�k�m:");
            List<string> liste1 = ListeYap<string> ("Atat�rk-1881", "Atat�rk-1919", "Atat�rk-1920", "Atat�rk-1923", "Atat�rk-1938");
            Console.Write ("Liste1<string> foreach: ");
            foreach (string x in liste1) Console.Write (x+" "); Console.WriteLine();
            List<int> liste2 = ListeYap<int> (1881, 1919, 1920, 1923, 1938);
            Console.Write ("Liste2<int> foreach: ");
            foreach (int x in liste2) Console.Write (x+" "); Console.WriteLine();

            Console.WriteLine ("\ntypeof(T) ile metot parametre tipini saptama:");
            Type tip = typeof (SoysalT);
            MethodInfo mi = tip.GetMethod ("TipBeyan�");
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}