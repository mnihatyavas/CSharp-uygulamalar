// j2sc#1803b.cs: Soysal parametre, delege, varsay�l� de�er ve where ref �rne�i.

using System;
using System.Collections.Generic; //List<T> i�in
namespace SoysalS�n�f {
    class S�n�fA {}
    class S�n�fB : S�n�fA {}
    class GenelS�n�f<T1, T2> where T1: S�n�fA where T2: S�n�fB {}
    public class �anta<T> {
        public T[] dizi;
        public �anta() {//Kurucu
            dizi = new T [1939-1881];
            for(int i = 1881; i < 1939; ++i) {dizi [i-1881] = default (T);}
        }
        public bool Hi�Mi (int i) {
            if (i < 0 || i >= dizi.Length) {throw new ArgumentOutOfRangeException();}
            if (Object.Equals (dizi [i], default (T)) ) {return true;
            }else {return false;}
        }
    }
    delegate T SoysalDelege1<T> (T prm1, T prm2);
    public delegate void SoysalDelege2<T> (T r);
    public delegate void ObjectDelege (object k);
    class S�n�fC {} 
    class S�n�fD<T> {
        public T alan;
        public S�n�fD() {alan = default (T);} //alan�n tipi soysal T, de�eriyse tipin varsay�l� de�eridir
    }
    class S�n�fE<T1, T2> where T1: class where T2: struct {
        public T1 alan1;
        public T2 alan2;
        public S�n�fE (T1 p1, T2 p2) {alan1 = p1; alan2 = p2;} //Kurucu
    }
    public class S�n�fF<T> where T: struct {
        public List<T> liste = new List<T>();
        public void Ekle (T p) {liste.Add (p);}
    }
    class S�n�fT {
        static int topla (int a, int b) {return a+b;}
        static string ekle (string a, string b) {return a+" "+b;}
        static void ObjMetot (object prm) {
            if (prm is double) {Console.WriteLine ("�ember(y�, uzn) = ({0}, {1})", prm, 2*Math.PI*(double)prm);}
            if (prm is string) {Console.WriteLine ("B�y�kharf({0}): {1}", prm, ((string)prm).ToUpper());}
        }
        static void b�y�kharf (string prm) {Console.WriteLine ("b�y�kharf({0}): {1}", prm, prm.ToUpper());}
        static void �ember (double prm) {Console.WriteLine ("�ember(y�, uzn) = ({0}, {1})", prm, 2*Math.PI*prm);}
        static bool Referanslar�E�itMi<T> (T prm1, T prm2) where T: class {return prm1 == prm2;}
        static void Main() {
            Console.Write ("where ref'ler class, struct, object, string olabilir. Varsay�l� tip de�erleri s�n�f, object, string i�in null; say� i�in 0; bool i�in false'tur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SoysalS�n�f tipleme parametre uyumu/uyumsuzlu�u:");
            GenelS�n�f<S�n�fA, S�n�fB> genelAB = new GenelS�n�f<S�n�fA, S�n�fB>(); Console.WriteLine ("Tipleme (genelAB) = {0}", genelAB);
            //GenelS�n�f<S�n�fB, S�n�fA> genelBA = new GenelS�n�f<S�n�fB, S�n�fA>(); Console.WriteLine ("Tipleme (genelBA) = {0}", genelBA); //HATA: T2 uyumsuz
            //GenelS�n�f<S�n�fA, S�n�fA> genelAA = new GenelS�n�f<S�n�fA, S�n�fA>(); Console.WriteLine ("Tipleme (genelAA) = {0}", genelAA); //HATA: T2 uyumsuz
            GenelS�n�f<S�n�fB, S�n�fB> genelBB = new GenelS�n�f<S�n�fB, S�n�fB>(); Console.WriteLine ("Tipleme (genelBB) = {0}", genelBB);

            Console.WriteLine ("\nSoysal<T> dizi T[]=new dizi[58] endeks a��m hatalar�:");
            �anta<int> int�anta = new �anta<int>();
            �anta<object> obj�anta = new �anta<object>();
            �anta<string> str�anta = new �anta<string>();
            �anta<double> dbl�anta = new �anta<double>();
            �anta<bool> bool�anta = new �anta<bool>();
            Console.WriteLine ("int�anta.Hi�Mi ({0})? {1}", 0, int�anta.Hi�Mi (0));
            Console.WriteLine ("obj�anta.Hi�Mi ({0})? {1}", 28, obj�anta.Hi�Mi (28));
            Console.WriteLine ("str�anta.Hi�Mi ({0})? {1}", 29, str�anta.Hi�Mi (29));
            Console.WriteLine ("dbl�anta.Hi�Mi ({0})? {1}", 32, dbl�anta.Hi�Mi (32));
            Console.WriteLine ("bool�anta.Hi�Mi ({0})? {1}", 57, bool�anta.Hi�Mi (57));
            try {Console.WriteLine ("int�anta.Hi�Mi ({0})? {1}", -5, int�anta.Hi�Mi (-5));} catch (Exception h) {Console.WriteLine ("Hata: [{0}]", h.Message);}
            try {Console.WriteLine ("int�anta.Hi�Mi ({0})? {1}", 58, int�anta.Hi�Mi (58));} catch (Exception h) {Console.WriteLine ("Hata: [{0}]", h.Message);}

            Console.WriteLine ("\nSoysal delegeyle farkl� tip ve i�erkli metotlar� �a��rma:");
            SoysalDelege1<int> intDlg = topla; Console.WriteLine ("int topla(1957,67) = {0}", intDlg (1957, 67));
            SoysalDelege1<string> strDlg = ekle; Console.WriteLine ("string ekle(\"Merhaba\",\"nas�ls�n?\" = {0}", strDlg ("Merhaba,", "nas�ls�n?"));

            Console.WriteLine ("\nObject ve soysal<T> delegelerle, �ember uzunlu�u ve b�y�k harf:");
            ObjectDelege nd = new ObjectDelege (ObjMetot);
            nd ("M.Nihat Yava�");
            nd (25.38);
            SoysalDelege2<string> bh = new SoysalDelege2<string> (b�y�kharf); bh ("M.Kemal K�l��daro�lu");
            SoysalDelege2<double> �u = new SoysalDelege2<double> (�ember); �u (38.25);

            Console.WriteLine ("\n'alan = default (T)' soysal tipli alan�n varsay�l� de�eri:");
            S�n�fD<S�n�fC> snfD1 = new S�n�fD<S�n�fC>(); Console.WriteLine ("S�n�fC tipli alan'�n varsay�l� de�eri 'null' mu?: {0}", snfD1.alan==null);
            S�n�fD<string> snfD2 = new S�n�fD<string>(); Console.WriteLine ("String tipli alan'�n varsay�l� de�eri 'null' mu?: {0}", snfD2.alan==null);
            S�n�fD<bool> snfD3 = new S�n�fD<bool>(); Console.WriteLine ("Bool tipli alan'�n varsay�l� de�eri 'false' mu?: {0}", snfD3.alan==false);
            S�n�fD<int> snfD4 = new S�n�fD<int>(); Console.WriteLine ("Int tipli alan'�n varsay�l� de�eri '0' m�?: {0}", snfD4.alan==0);
            Console.WriteLine ("Int�anta.dizi[5]'�n varsay�l� de�eri '0' m�?: {0}", int�anta.dizi [5]==0);
            Console.WriteLine ("Obj�anta.dizi[5]'�n varsay�l� de�eri 'null' mu?: {0}", obj�anta.dizi [5]==null);
            Console.WriteLine ("Str�anta.dizi[5]'�n varsay�l� de�eri '' mu?: {0}", str�anta.dizi [5]=="");
            Console.WriteLine ("Bool�anta.dizi[5]'�n varsay�l� de�eri 'true' mu?: {0}", bool�anta.dizi [5]==true);

            Console.WriteLine ("\n'S�n�f<T1,T2> where T1 : class where T2 : struct' tiplere referans tan�mlama:");
            string ad = "M.Nihat Yava�";
            string ki�i1 = "Benim ad�m: " + ad;
            string ki�i2 = "Benim ad�m: " + ad;
            Console.WriteLine ("ki�i1 == ki�i2? {0}", (ki�i1 == ki�i2)?"Evet":"Hay�r");
            Console.WriteLine ("Referanslar�E�itMi (ki�i1, ki�i2)? {0}", Referanslar�E�itMi (ki�i1, ki�i2)?"Evet":"Hay�r");
            S�n�fE<string, int> snfE1 = new S�n�fE<string, int>("M.Nihat Yava�", 20240725); Console.WriteLine (snfE1.alan1+": "+snfE1.alan2);
            S�n�fE<object, int> snfE2 = new S�n�fE<object, int>("Hatice Y.Ka�ar", 20240725); Console.WriteLine (snfE2.alan1+": "+snfE2.alan2);
            //S�n�fE<bool, int> snfE3 = new S�n�fE<bool, int>(true, 20240725); Console.WriteLine (snfE3.alan1+": "+snfE3.alan2); //T1 class ref i�in bool olmaz
            S�n�fE<string, bool> snfE3 = new S�n�fE<string, bool>("M.Nedim Yava�", false); Console.WriteLine (snfE3.alan1+": "+snfE3.alan2);
            S�n�fF<int> intListe = new S�n�fF<int>();
            intListe.Ekle (1881); Console.WriteLine (intListe.liste [0]);
            intListe.Ekle (1938); Console.WriteLine (intListe.liste [1]);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}