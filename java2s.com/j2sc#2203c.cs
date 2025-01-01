// j2sc#2203c.cs: Soysal ToList<>() ve �oklu anahtarl� ToLookup() �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; //ToList() i�in
using System.Collections; //ArrayList i�in
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
    class ToList_Lookup {
        static void Main() {
            Console.Write ("ArtayList soysal olmad���ndan Cast<���i>() ile d�n��mekte, ���i[] dizi do�rudan soysal ToList<���i>()'ye d�n��mektedir. ToDictionary() sadece yegane anahtarlar� sorgularken, ToLookup() �oklu benzer anahtarl� kay�tlar� da sorgular.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'string[] peygamberler.ToList()' d�n���m�:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            List<string> liste1 = peygamberler.ToList();
            Console.Write ("-->T�m {0} adet peygamberler: ", liste1.Count());
            foreach (string ad in liste1) Console.Write (ad+" "); Console.WriteLine();

            Console.WriteLine ("\n'List<> liste'den liste.ToList() Linq sorguya d�n���m:");
            var y�llar = new List<int>();
            int i;
            for(i=1881;i<=1938;i++) y�llar.Add (i);
            Console.Write ("-->T�m {0} adet y�llar: ", y�llar.Count());
            foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            List<int> liste2 = y�llar.Select (n => 2024 - n).ToList();
            y�llar.Clear(); Console.WriteLine ("Y�llar listesi {0} adet.", y�llar.Count);
            Console.Write ("-->T�m {0} adet liste2: ", liste2.Count());
            foreach (int y�l in liste2) Console.Write (y�l+":"+(2024 - y�l)+" "); Console.WriteLine();

            Console.WriteLine ("\nArrayList-->Cast<���i> ve ���i[]-->ToList<���i> d�n���mleri:");
            ArrayList i��iler = ���i.���iListesiniAl();
            Console.WriteLine ("i��iler.GetType(): " + i��iler.GetType());
            var s�ra = i��iler.Cast<���i>();
            Console.WriteLine ("s�ra.GetType(): " + s�ra.GetType());
            var sorgu1 = s�ra.OrderByDescending (i� => i�.y�l);
            Console.WriteLine ("-->{0} adet 9->0 azalan-y�l s�ral� sorgu:", sorgu1.Count());
            foreach (���i i� in sorgu1) Console.WriteLine ("{0} {1}, {2}", i�.ad, i�.soyad, i�.y�l);
            var s�ra2 = ���i.���iDizisiniAl().ToList<���i>();
            var sorgu2 = from i� in s�ra2
                where i�.soyad.Length > 5
                select new {�sim = i�.soyad + " " + i�.ad, Y�l = i�.y�l};
            Console.WriteLine ("-->{0} adet soyad.Length>5 i��iler:", sorgu2.Count());
            foreach (var i� in sorgu2) Console.WriteLine (i�);

            Console.WriteLine ("\n�oklu benzer anahtar kay�tlar�n� ara�t�ran ToLookup():");
            string[] soyadlar = {"G�kyi�it", "�zbay", "Ka�ar", "Candan", "Yava�"};
            ILookup<string, ���i> g�zat1 = ���i.���iDizisiniAl().ToLookup (anh => anh.soyad);
            IEnumerable<���i> sorgu3 = g�zat1 ["Yava�"];
            Console.WriteLine ("==>Tek sorgu3'le {0} (adet soyad=='Yava�') i��iler: ", sorgu3.Count());
            foreach (var i� in sorgu3) Console.WriteLine ("{0} {1}, {2}", i�.ad, i�.soyad, i�.y�l);
            Console.WriteLine ("==>T�m {0} adet soyadlar'la i��iler: ", soyadlar.Length);
            foreach(string sad in soyadlar) {
                sorgu3 = g�zat1 [sad];
                Console.WriteLine ("-->{0} (adet soyad=='{1}') i��iler: ", sorgu3.Count(), sad);
                foreach (var i� in sorgu3) Console.WriteLine ("{0} {1}, {2}", i�.ad, i�.soyad, i�.y�l);
            }
            var soy = (from i� in s�ra select i�.soyad).Distinct();
            Console.WriteLine ("==>T�m {0} adet soy'la i��iler: ", soy.Count());
            foreach(string sad in soy) {
                sorgu3 = g�zat1 [sad];
                Console.WriteLine ("-->{0} (adet soyad=='{1}') i��iler: ", sorgu3.Count(), sad);
                foreach (var i� in sorgu3) Console.WriteLine ("{0} {1}, {2}", i�.ad, i�.soyad, i�.y�l);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}