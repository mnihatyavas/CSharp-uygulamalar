// j2sc#2203b.cs: ToDictionary() ile yegane anahtarla kay�tlara eri�im �rne�i.

using System;
using System.Linq; //GetMethods() ve group by i�in
using System.Collections.Generic; //Dictionary<> i�in
using System.Collections; //ArrayList ii�in
namespace To_D�n���mler {
    public class ���i {
        public int y�l;
        public string ad;
        public string soyad;
        public static ArrayList ���iListesiniAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new ���i {y�l = 1891, ad = "Fatma", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1899, ad = "Bekir", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1931, ad = "Han�m", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1934, ad = "Memet", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1951, ad = "Hatice", soyad = "Ka�ar"});
            liste.Add (new ���i {y�l = 1953, ad = "S�heyla", soyad = "�zbay"});
            liste.Add (new ���i {y�l = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new ���i {y�l = 1957, ad = "M.Nihat", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1959, ad = "Song�l", soyad = "G�kyi�it"});
            liste.Add (new ���i {y�l = 1961, ad = "M.Nedim", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1963, ad = "Sevim", soyad = "Yava�"});
            return (liste);
        }
        public static ���i[] ���iDizisiniAl() {return ((���i[])���iListesiniAl().ToArray (typeof (���i)));} //Liste<���i>, ���i[] dizi'ye �evrilip al�nmakta
    }
    class ToDictionary {
        static void Main() {
            Console.Write ("ToDictionary d�n���m s�zl�k anahtarlar�na 'ICollection s�zl�k.Keys' ile eri�ilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�m ar�iv int ve string metotlar�n�n ayn� adl� grup listeleri:");
            var sorgu1 = from mt in typeof (int).GetMethods()
                group mt by mt.Name into grup
                select grup;
            Dictionary<string, int> s�zl�k1 = sorgu1.ToDictionary (k => k.Key, k => k.Count());
            Console.WriteLine ("-->{0} adet 'typeof(int).GetMethods()' farkl� tamsay� metot ad ve say�lar�:", s�zl�k1.Count());
            foreach(var s in s�zl�k1) Console.WriteLine (s);
            var sorgu2 = (from m in typeof (string).GetMethods() group m by m.Name into gr select gr).ToDictionary (k => k.Key, k=>k.Count());
            Console.WriteLine ("-->{0} adet 'typeof(string).GetMethods()' dizgesel metotlar�:", sorgu2.Count());
            foreach(var m in sorgu2) Console.WriteLine (m);

            Console.WriteLine ("\nArrayList-->���i[] dizi-->Dictionary(k=>k.alan) d�n���mleri:");
            ���i[] i��iDizi = ���i.���iDizisiniAl();
            Console.WriteLine ("-->{0} adet i��i dizisi:", i��iDizi.Length);
            foreach(var i� in i��iDizi) Console.WriteLine ("{0} {1}, {2}", i�.ad, i�.soyad, i�.y�l);
            Dictionary<int, string> s�zl�k2a = ���i.���iDizisiniAl().ToDictionary (anh => anh.y�l, isim => string.Format ("{0} {1}", isim.ad, isim.soyad));
            ICollection<int> ik1 = s�zl�k2a.Keys;
            Console.WriteLine ("-->{0} adet y�l anahtarl� i��i s�zl���:", ik1.Count());
            foreach(int y�l in ik1) Console.WriteLine ("Y�l: {0},\t�sim: {1}", y�l, s�zl�k2a [y�l]);
            Console.WriteLine ("���i(Y�l==1957: {0}", s�zl�k2a [1957]);
            try {Console.WriteLine ("���i(Y�l==1958: {0}", s�zl�k2a [1958]);} catch {Console.WriteLine ("���i(Y�l==1958): S�zl�kte NAMEVCUT");}
            Dictionary<int, ���i> s�zl�k2b = ���i.���iDizisiniAl().ToDictionary (anh => anh.y�l);
            Console.WriteLine ("���i(Y�l==1891: {0} {1}", s�zl�k2b [1891].ad, s�zl�k2b [1891].soyad);
            Dictionary<string, int> s�zl�k2c = ���i.���iDizisiniAl().ToDictionary (a => a.soyad+" "+a.ad, y=>y.y�l);
            ICollection<string> ik2 = s�zl�k2c.Keys;
            Console.WriteLine ("-->{0} adet soyad+ad anahtarl� i��i s�zl���:", ik2.Count());
            foreach(string ism in ik2) Console.WriteLine ("�sim: {0},\tDy�l: {1}", ism, s�zl�k2c [ism]);
            Console.WriteLine ("���i(�sim==Yava� Sevim: {0}", s�zl�k2c ["Yava� Sevim"]);
            try {Console.WriteLine ("���i(�sim==Yava� Sevil: {0}", s�zl�k2c ["Yava� Sevil"]);} catch {Console.WriteLine ("���i('Yava� Sevil'): S�zl�kte NAMEVCUT");}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}