// j2sc#2202i.cs: ElementAt, ElementAtOrDefault, Equals, SequenceEqual �rne�i.

using System;
using System.Linq; //ElementAt() i�in
using System.Collections; //ArrayList i�in
using System.Collections.Generic; //IEqualityComparer<> i�in
namespace LinqMetot {
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
        public static ���i[] ListeyiAl() {return ((���i[])���iListesiniAl().ToArray (typeof(���i)));}
    }
    public class S�n�fA : IEqualityComparer<string> {
        public bool Equals (string x, string y) {return (Int32.Parse (x) == Int32.Parse (y));}
        public int GetHashCode (string nesne) {return Int32.Parse (nesne).ToString().GetHashCode();}
    }
    class ElementAt_Equals {
        static void Main() {
            Console.Write ("'dizi.ElementAt(4)' 4.endeks eleman�n� se�er. 'dizi.ElementAtOrDefault(14)' endeks mevcutsa eleman�, kapsam d���ysa hata de�il 0/null d�nd�r�r. Equals e�itli�i referans adresle, SequenceEqual ise i�erik eleman de�erleriyle k�yaslar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Rasgele [1881,1938] y�llarda ElementAt(endeks) y�l�:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[10];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("T�m y�llar: "); foreach(var y in y�llar) Console.Write (y+" "); Console.WriteLine();
            ts=r.Next(0,y�llar.Length);
            Console.WriteLine ("y�llar.ElementAt({0}) = {1}", ts, y�llar.ElementAt (ts));
            Console.WriteLine ("y�llar.First() = {0}", y�llar.First());
            Console.WriteLine ("y�llar.Last() = {0}", y�llar.Last());
            Console.WriteLine ("K���k y�l = {0}", y�llar.OrderBy (y=>y).First());
            Console.WriteLine ("B�y�k y�l = {0}", y�llar.OrderBy (y=>y).Last());
            Console.WriteLine ("Ortanca y�l = {0}", y�llar.OrderBy (y=>y).ElementAt (y�llar.Length/2));
            int y�l1 = (
                from y in y�llar
                where y > (1881+1939)/2
                select y).ElementAt (1);
            Console.WriteLine ("y�llar(y>1910)[1] = {0}", y�l1);

            Console.WriteLine ("\n���i[] liste dizisinin ElementAt() ile tersten d�k�m�:");
            ���i[] i��iler = ���i.ListeyiAl();
            for(i=i��iler.Length-1;i>0;i--) Console.WriteLine ("�sim: {0} {1}\tD.y�l�: {2}", i��iler.ElementAt (i).ad, i��iler.ElementAt (i).soyad, i��iler.ElementAt (i).y�l);
            Console.WriteLine ("�lk i��i: {0} {1}", i��iler.First().ad, i��iler.First().soyad);
            Console.WriteLine ("Son i��i: {0} {1}", i��iler.Last().ad, i��iler.Last().soyad);
            Console.WriteLine ("Ortanca i��i: {0} {1}", i��iler.ElementAt (i��iler.Length/2).ad, i��iler.ElementAt (i��iler.Length/2).soyad);

            Console.WriteLine ("\nElementAt i�in endeks ta�ma hatas�n� ElementAtOrDefault �nler:");
            Console.WriteLine ("y�llar.ElementAtOrDefault(2024) = {0}\ty�llar.ElementAtOrDefault (2) = {1}", y�llar.ElementAtOrDefault (2024), y�llar.ElementAtOrDefault (2));
            try {Console.WriteLine ("y�llar.ElementAt(2024) = {0}\ty�llar.ElementAt(2) = {1}", y�llar.ElementAt (2024), y�llar.ElementAt (2));} catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            ���i i��i = ���i.ListeyiAl().ElementAtOrDefault (3);
            Console.WriteLine ("���i[{0}]'nin ismi: {1}", 3, i��i == null ? "NULL" : string.Format (i��i.ad + " " + i��i.soyad));
            i��i = ���i.ListeyiAl().ElementAtOrDefault (i��iler.Length+1);
            Console.WriteLine ("���i[{0}]'nin ismi: {1}", i��iler.Length+1, i��i == null ? "NULL" : string.Format (i��i.ad + " " + i��i.soyad));

            Console.WriteLine ("\nAtanan nesneler e�it, fakat yeniden yarat�lan ayn� nesneler e�it de�ildir:");
            ���i[] i��iler1 = ���i.ListeyiAl();
            ���i[] i��iler2 = ���i.ListeyiAl();
            ���i[] i��iler3 = i��iler1;
            Console.WriteLine ("i��iler1.Equals(i��iler2)? {0}", i��iler1.Equals (i��iler2));
            Console.WriteLine ("i��iler1.Equals(i��iler1)? {0}", i��iler1.Equals (i��iler1));
            Console.WriteLine ("i��iler1.Equals(i��iler3)? {0}", i��iler1.Equals (i��iler3));
            Console.WriteLine ("i��iler2.Equals(i��iler3)? {0}", i��iler2.Equals (i��iler3));

            Console.WriteLine ("\nYeni yarat�lan ayn� elemanl� 2 nesne Equals=false fakat SequenceEqual=true:");
            string[] peygamberler1 = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            string[] peygamberler2 = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.WriteLine ("peygamberler1.Equals(peygamberler2? {0}", peygamberler1.Equals (peygamberler2));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler2)? {0}", peygamberler1.SequenceEqual (peygamberler2));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler1.Take(peygamberler1.Count()))? {0}", peygamberler1.SequenceEqual (peygamberler1.Take (peygamberler1.Count())));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler1.Take(5).Concat(peygamberler1.Skip(5)))? {0}", peygamberler1.SequenceEqual (peygamberler1.Take (5).Concat (peygamberler1.Skip (5))));
            string[] y�llar1 = new string [y�llar.Length]; for(i=0;i<y�llar1.Length;i++) y�llar1 [i]=y�llar [i].ToString();
            string[] y�llar2 = y�llar1;
            Console.WriteLine ("y�llar1.SequenceEqual(y�llar2,new S�n�fA())? {0}", y�llar1.SequenceEqual (y�llar2, new S�n�fA()));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}