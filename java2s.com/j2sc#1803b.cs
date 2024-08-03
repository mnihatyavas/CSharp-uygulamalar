// j2sc#1803b.cs: Soysal parametre, delege, varsayýlý deðer ve where ref örneði.

using System;
using System.Collections.Generic; //List<T> için
namespace SoysalSýnýf {
    class SýnýfA {}
    class SýnýfB : SýnýfA {}
    class GenelSýnýf<T1, T2> where T1: SýnýfA where T2: SýnýfB {}
    public class Çanta<T> {
        public T[] dizi;
        public Çanta() {//Kurucu
            dizi = new T [1939-1881];
            for(int i = 1881; i < 1939; ++i) {dizi [i-1881] = default (T);}
        }
        public bool HiçMi (int i) {
            if (i < 0 || i >= dizi.Length) {throw new ArgumentOutOfRangeException();}
            if (Object.Equals (dizi [i], default (T)) ) {return true;
            }else {return false;}
        }
    }
    delegate T SoysalDelege1<T> (T prm1, T prm2);
    public delegate void SoysalDelege2<T> (T r);
    public delegate void ObjectDelege (object k);
    class SýnýfC {} 
    class SýnýfD<T> {
        public T alan;
        public SýnýfD() {alan = default (T);} //alanýn tipi soysal T, deðeriyse tipin varsayýlý deðeridir
    }
    class SýnýfE<T1, T2> where T1: class where T2: struct {
        public T1 alan1;
        public T2 alan2;
        public SýnýfE (T1 p1, T2 p2) {alan1 = p1; alan2 = p2;} //Kurucu
    }
    public class SýnýfF<T> where T: struct {
        public List<T> liste = new List<T>();
        public void Ekle (T p) {liste.Add (p);}
    }
    class SýnýfT {
        static int topla (int a, int b) {return a+b;}
        static string ekle (string a, string b) {return a+" "+b;}
        static void ObjMetot (object prm) {
            if (prm is double) {Console.WriteLine ("Çember(yç, uzn) = ({0}, {1})", prm, 2*Math.PI*(double)prm);}
            if (prm is string) {Console.WriteLine ("Büyükharf({0}): {1}", prm, ((string)prm).ToUpper());}
        }
        static void büyükharf (string prm) {Console.WriteLine ("büyükharf({0}): {1}", prm, prm.ToUpper());}
        static void çember (double prm) {Console.WriteLine ("çember(yç, uzn) = ({0}, {1})", prm, 2*Math.PI*prm);}
        static bool ReferanslarýEþitMi<T> (T prm1, T prm2) where T: class {return prm1 == prm2;}
        static void Main() {
            Console.Write ("where ref'ler class, struct, object, string olabilir. Varsayýlý tip deðerleri sýnýf, object, string için null; sayý için 0; bool için false'tur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SoysalSýnýf tipleme parametre uyumu/uyumsuzluðu:");
            GenelSýnýf<SýnýfA, SýnýfB> genelAB = new GenelSýnýf<SýnýfA, SýnýfB>(); Console.WriteLine ("Tipleme (genelAB) = {0}", genelAB);
            //GenelSýnýf<SýnýfB, SýnýfA> genelBA = new GenelSýnýf<SýnýfB, SýnýfA>(); Console.WriteLine ("Tipleme (genelBA) = {0}", genelBA); //HATA: T2 uyumsuz
            //GenelSýnýf<SýnýfA, SýnýfA> genelAA = new GenelSýnýf<SýnýfA, SýnýfA>(); Console.WriteLine ("Tipleme (genelAA) = {0}", genelAA); //HATA: T2 uyumsuz
            GenelSýnýf<SýnýfB, SýnýfB> genelBB = new GenelSýnýf<SýnýfB, SýnýfB>(); Console.WriteLine ("Tipleme (genelBB) = {0}", genelBB);

            Console.WriteLine ("\nSoysal<T> dizi T[]=new dizi[58] endeks aþým hatalarý:");
            Çanta<int> intÇanta = new Çanta<int>();
            Çanta<object> objÇanta = new Çanta<object>();
            Çanta<string> strÇanta = new Çanta<string>();
            Çanta<double> dblÇanta = new Çanta<double>();
            Çanta<bool> boolÇanta = new Çanta<bool>();
            Console.WriteLine ("intÇanta.HiçMi ({0})? {1}", 0, intÇanta.HiçMi (0));
            Console.WriteLine ("objÇanta.HiçMi ({0})? {1}", 28, objÇanta.HiçMi (28));
            Console.WriteLine ("strÇanta.HiçMi ({0})? {1}", 29, strÇanta.HiçMi (29));
            Console.WriteLine ("dblÇanta.HiçMi ({0})? {1}", 32, dblÇanta.HiçMi (32));
            Console.WriteLine ("boolÇanta.HiçMi ({0})? {1}", 57, boolÇanta.HiçMi (57));
            try {Console.WriteLine ("intÇanta.HiçMi ({0})? {1}", -5, intÇanta.HiçMi (-5));} catch (Exception h) {Console.WriteLine ("Hata: [{0}]", h.Message);}
            try {Console.WriteLine ("intÇanta.HiçMi ({0})? {1}", 58, intÇanta.HiçMi (58));} catch (Exception h) {Console.WriteLine ("Hata: [{0}]", h.Message);}

            Console.WriteLine ("\nSoysal delegeyle farklý tip ve içerkli metotlarý çaðýrma:");
            SoysalDelege1<int> intDlg = topla; Console.WriteLine ("int topla(1957,67) = {0}", intDlg (1957, 67));
            SoysalDelege1<string> strDlg = ekle; Console.WriteLine ("string ekle(\"Merhaba\",\"nasýlsýn?\" = {0}", strDlg ("Merhaba,", "nasýlsýn?"));

            Console.WriteLine ("\nObject ve soysal<T> delegelerle, çember uzunluðu ve büyük harf:");
            ObjectDelege nd = new ObjectDelege (ObjMetot);
            nd ("M.Nihat Yavaþ");
            nd (25.38);
            SoysalDelege2<string> bh = new SoysalDelege2<string> (büyükharf); bh ("M.Kemal Kýlýçdaroðlu");
            SoysalDelege2<double> çu = new SoysalDelege2<double> (çember); çu (38.25);

            Console.WriteLine ("\n'alan = default (T)' soysal tipli alanýn varsayýlý deðeri:");
            SýnýfD<SýnýfC> snfD1 = new SýnýfD<SýnýfC>(); Console.WriteLine ("SýnýfC tipli alan'ýn varsayýlý deðeri 'null' mu?: {0}", snfD1.alan==null);
            SýnýfD<string> snfD2 = new SýnýfD<string>(); Console.WriteLine ("String tipli alan'ýn varsayýlý deðeri 'null' mu?: {0}", snfD2.alan==null);
            SýnýfD<bool> snfD3 = new SýnýfD<bool>(); Console.WriteLine ("Bool tipli alan'ýn varsayýlý deðeri 'false' mu?: {0}", snfD3.alan==false);
            SýnýfD<int> snfD4 = new SýnýfD<int>(); Console.WriteLine ("Int tipli alan'ýn varsayýlý deðeri '0' mý?: {0}", snfD4.alan==0);
            Console.WriteLine ("IntÇanta.dizi[5]'ýn varsayýlý deðeri '0' mý?: {0}", intÇanta.dizi [5]==0);
            Console.WriteLine ("ObjÇanta.dizi[5]'ýn varsayýlý deðeri 'null' mu?: {0}", objÇanta.dizi [5]==null);
            Console.WriteLine ("StrÇanta.dizi[5]'ýn varsayýlý deðeri '' mu?: {0}", strÇanta.dizi [5]=="");
            Console.WriteLine ("BoolÇanta.dizi[5]'ýn varsayýlý deðeri 'true' mu?: {0}", boolÇanta.dizi [5]==true);

            Console.WriteLine ("\n'Sýnýf<T1,T2> where T1 : class where T2 : struct' tiplere referans tanýmlama:");
            string ad = "M.Nihat Yavaþ";
            string kiþi1 = "Benim adým: " + ad;
            string kiþi2 = "Benim adým: " + ad;
            Console.WriteLine ("kiþi1 == kiþi2? {0}", (kiþi1 == kiþi2)?"Evet":"Hayýr");
            Console.WriteLine ("ReferanslarýEþitMi (kiþi1, kiþi2)? {0}", ReferanslarýEþitMi (kiþi1, kiþi2)?"Evet":"Hayýr");
            SýnýfE<string, int> snfE1 = new SýnýfE<string, int>("M.Nihat Yavaþ", 20240725); Console.WriteLine (snfE1.alan1+": "+snfE1.alan2);
            SýnýfE<object, int> snfE2 = new SýnýfE<object, int>("Hatice Y.Kaçar", 20240725); Console.WriteLine (snfE2.alan1+": "+snfE2.alan2);
            //SýnýfE<bool, int> snfE3 = new SýnýfE<bool, int>(true, 20240725); Console.WriteLine (snfE3.alan1+": "+snfE3.alan2); //T1 class ref için bool olmaz
            SýnýfE<string, bool> snfE3 = new SýnýfE<string, bool>("M.Nedim Yavaþ", false); Console.WriteLine (snfE3.alan1+": "+snfE3.alan2);
            SýnýfF<int> intListe = new SýnýfF<int>();
            intListe.Ekle (1881); Console.WriteLine (intListe.liste [0]);
            intListe.Ekle (1938); Console.WriteLine (intListe.liste [1]);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}