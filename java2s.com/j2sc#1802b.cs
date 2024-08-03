// j2sc#1802b.cs: IComparable<T> ve IComparer<T> ile k�yasl� artan/azalan s�ralama �rne�i.

using System;
using System.Collections.Generic;
using System.Collections; //<T>'siz Comparer koleksiyon ��g�ren i�in
namespace SoysalD�k�mleyici {
    public class ��g�ren : IComparable<��g�ren> {
        private int i�gNo;
        private int hizmetY�l� = 1;
        public ��g�ren (int i�gNo) {this.i�gNo = i�gNo;} //Kurucu-1
        public ��g�ren (int i�gNo, int hizmetY�l�) {this.i�gNo = i�gNo; this.hizmetY�l� = hizmetY�l�;} //Kurucu-2
        public override string ToString() {return "(No, Y�l) = (" + i�gNo + ", " + hizmetY�l� + ")";}
        public static ��gK�yas K�yasc�y�Al() {return new ��g�ren.��gK�yas();}
        public int CompareTo (��g�ren �u) {return 0;} //(Varsay�l�) Esas� bir alttaki
        public int CompareTo (��g�ren �u, ��g�ren.��gK�yas.K�yasAlan� alan) {
            switch (alan) {
                case ��g�ren.��gK�yas.K�yasAlan�.��gNo: return this.i�gNo.CompareTo (�u.i�gNo);
                case ��g�ren.��gK�yas.K�yasAlan�.HY�l: return this.hizmetY�l�.CompareTo (�u.hizmetY�l�);
            }
            return 0;
        }
        public class ��gK�yas : IComparer<��g�ren> {
            public enum K�yasAlan� {��gNo, HY�l};
            public int Compare (��g�ren bu, ��g�ren �u) {return bu.CompareTo (�u, ��gK�yasAlan�);}
            public ��g�ren.��gK�yas.K�yasAlan� ��gK�yasAlan� {get; set;}
        }
    }
    class Stoklar: IComparable<Stoklar> {
        string ad;
        double maliyet;
        int mevcut;
        public Stoklar (string a, double m, int v) {ad = a; maliyet = m; mevcut = v;} //Kurucu
        public override string ToString() {return String.Format ("{0,-8}Maliyet: {1,8:#,0.00} TL  Mevcut: {2,6:#,0}", ad, maliyet, mevcut);}
        public int CompareTo (Stoklar �u) {return 0;} //(Varsay�l�) Esas� bir alttaki
        public int CompareTo (Stoklar �u, Stoklar.K�yasc�.K�yasAlan� alan) {
            switch (alan) {
                case Stoklar.K�yasc�.K�yasAlan�.Ad: return this.ad.CompareTo (�u.ad);
                case Stoklar.K�yasc�.K�yasAlan�.Maliyet: return this.maliyet.CompareTo (�u.maliyet);
                case Stoklar.K�yasc�.K�yasAlan�.Mevcut: return this.mevcut.CompareTo (�u.mevcut);
            }
            return 0;
        }
        public int CompareTo (Stoklar �u, Stoklar.K�yasc�2.K�yasAlan� alan) {
            switch (alan) {
                case Stoklar.K�yasc�2.K�yasAlan�.Ad: return this.ad.CompareTo (�u.ad);
                case Stoklar.K�yasc�2.K�yasAlan�.Maliyet: return this.maliyet.CompareTo (�u.maliyet);
                case Stoklar.K�yasc�2.K�yasAlan�.Mevcut: return this.mevcut.CompareTo (�u.mevcut);
            }
            return 0;
        }
        public static K�yasc� K�yasc�y�Al() {return new Stoklar.K�yasc�();}
        public class K�yasc� : IComparer<Stoklar> {
            public enum K�yasAlan� {Ad, Maliyet, Mevcut};
            public int Compare (Stoklar bu, Stoklar �u) {return bu.CompareTo (�u, StokK�yasAlan�);}
            public Stoklar.K�yasc�.K�yasAlan� StokK�yasAlan� {get; set;}
        }
        public static K�yasc�2 K�yasc�y�Al2() {return new Stoklar.K�yasc�2();}
        public class K�yasc�2 : IComparer<Stoklar> {
            public enum K�yasAlan� {Ad, Maliyet, Mevcut};
            //Azalan s�ralama i�in sadece "return �u...bu" de�i�ir
            public int Compare (Stoklar bu, Stoklar �u) {return �u.CompareTo (bu, StokK�yasAlan�);}
            public Stoklar.K�yasc�2.K�yasAlan� StokK�yasAlan� {get; set;}
        }
    }
    class Y�llar : IComparable<Y�llar> {
        public int y�l;
        public Y�llar (int y) {y�l = y;} //Kurucu
        public int CompareTo (Y�llar y) {return y�l - y.y�l;} //Artan s�ralama
    }
    class �r�n {
        public string ad;
        public double fiyat;
        public int mevcut;
        public �r�n (string a, double f, int m) {ad = a; fiyat = f; mevcut = m;} //Kurucu
        public override string ToString() {return String.Format ("{0,-8}Fiyat: {1,8:#,0.00} TL  Mevcut: {2,6:#,0}", ad, fiyat, mevcut);}
    }
    class �r�nAdK�yas1<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns1.ad.CompareTo (ns2.ad);}} //Artan
    class �r�nAdK�yas2<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns2.ad.CompareTo (ns1.ad);}} //Azalan
    class �r�nFiyatK�yas1<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns1.fiyat.CompareTo (ns2.fiyat);}} //Artan
    class �r�nFiyatK�yas2<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns2.fiyat.CompareTo (ns1.fiyat);}} //Azalan
    class �r�nMevcutK�yas1<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns1.mevcut.CompareTo (ns2.mevcut);}} //Artan
    class �r�nMevcutK�yas2<T>: IComparer<T> where T: �r�n {public int Compare (T ns1, T ns2) {return ns2.mevcut.CompareTo (ns1.mevcut);}} //Azalan
    public class ��g�ren2: IComparable {
        string ad;
        int no;
        double maa�;
        public ��g�ren2 (string a, int n, double m) {ad = a; no = n; maa�=m;} //Kurucu
        public override string ToString() {return string.Format ("{0}({1}) = {2,11:#,00.00} TL", ad, no, maa�);}
        public int CompareTo (object ns) {return(0);} //Ebeveyn varsay�l�
        public static IComparer AdlaArtanS�rala {get {return ((IComparer) new AdArtanS�ral�());}}
        public static IComparer NoylaArtanS�rala {get {return ((IComparer) new NoArtanS�ral�());}}
        public static IComparer Maa�laArtanS�rala {get {return ((IComparer) new Maa�ArtanS�ral�());}}
        public static IComparer AdlaAzalanS�rala {get {return ((IComparer) new AdAzalanS�ral�());}}
        public static IComparer NoylaAzalanS�rala {get {return ((IComparer) new NoAzalanS�ral�());}}
        public static IComparer Maa�laAzalanS�rala {get {return ((IComparer) new Maa�AzalanS�ral�());}}
        class AdArtanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns1).ad.CompareTo (((��g�ren2)ns2).ad);}}
        class AdAzalanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns2).ad.CompareTo (((��g�ren2)ns1).ad);}}
        class NoArtanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns1).no.CompareTo (((��g�ren2)ns2).no);}}
        class NoAzalanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns2).no.CompareTo (((��g�ren2)ns1).no);}}
        class Maa�ArtanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns1).maa�.CompareTo (((��g�ren2)ns2).maa�);}}
        class Maa�AzalanS�ral�: IComparer {public int Compare (object ns1, object ns2) {return ((��g�ren2)ns2).maa�.CompareTo (((��g�ren2)ns1).maa�);}}
    }
    public class �anta<T> {
        private List<T> �antalar = new List<T>();
        public void Ekle (T �anta) {�antalar.Add (�anta);}
        public T Sil() {
            T �anta = default (T);
            if (�antalar.Count != 0) {�anta = �antalar [0]; �antalar.RemoveAt (0);}
            return �anta;
        }
        public T[] T�m�n�Sil() {
            T[] i = �antalar.ToArray();
            �antalar.Clear();
            return i;
        }
        public int Ebat() {return �antalar.Count;}
        public void S�rala() {�antalar.Sort();}
        public void TersS�rala() {�antalar.Sort(); �antalar.Reverse();}
        public void G�ster() {foreach(T � in �antalar) Console.Write (�+" ");}
    }
    class SoysalK�yasc� {
        static internal void TipiniG�ster<X> (X veri) {
            Console.WriteLine ("De�er: {0}", veri);
            Console.WriteLine ("typeof(X): "+typeof(X));
            Console.WriteLine ("typeof(List<X>): "+typeof(List<X>));
            Console.WriteLine ("typeof(Dictionary<string, X>): "+typeof(Dictionary<string, X>));
            Console.WriteLine ("typeof(List<long>): "+typeof(List<long>));
            Console.WriteLine ("typeof(Dictionary<long, Guid>): "+typeof(Dictionary<long, Guid>));
        }
        static void Main() {
            Console.Write ("Soysal List<Stoklar> i�in t�m alanlara g�re artan ve azalan s�ralama yap�lm��t�r. ��g�ren2[] dizi kay�tlar�n�n ad-no-maa� alanlar� artan ve azalan k�yasc�larla s�ralanm��t�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��g�ren listesini i�gNo ve hy�l'a g�re artan s�ralama:");
            List<��g�ren> i�gListe  = new List<��g�ren>();
            var r=new Random(); int i, j, ts; double ds; string ad;
            for(i=0;i<5;i++) {i�gListe.Add (new ��g�ren (1100-i, r.Next (20)));}
            ��g�ren.��gK�yas k�yasc� = ��g�ren.K�yasc�y�Al();
            k�yasc�.��gK�yasAlan� = ��g�ren.��gK�yas.K�yasAlan�.��gNo;
            i�gListe.Sort (k�yasc�);
            for(i=0;i<i�gListe.Count;i++) Console.WriteLine (i�gListe [i]);
            k�yasc�.��gK�yasAlan� = ��g�ren.��gK�yas.K�yasAlan�.HY�l;
            i�gListe.Sort (k�yasc�);
            for(i=0;i<i�gListe.Count;i++) Console.WriteLine ("\t"+i�gListe [i]);

            Console.WriteLine ("\nStok envanterini ad/maliyet/mevcut'la artan/azalan s�ralama:");
            List<Stoklar> env = new List<Stoklar>();
            for(i=0;i<5;i++) {
                ad=""; for(j=0;j<5;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds=r.Next(1,2000)+r.Next(10,100)/100d;
                ts=r.Next(0,10000);
                env.Add (new Stoklar (ad, ds, ts));
            }
            Console.WriteLine ("\t==>S�ralama �ncesi stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            //Ad, Maliyet, Mevcut'la artan s�ralamalar
            Stoklar.K�yasc� k�yas�� = Stoklar.K�yasc�y�Al();
            k�yas��.StokK�yasAlan� = Stoklar.K�yasc�.K�yasAlan�.Ad;
            env.Sort(k�yas��);
            Console.WriteLine ("\t==>Ad'la artan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            k�yas��.StokK�yasAlan� = Stoklar.K�yasc�.K�yasAlan�.Maliyet;
            env.Sort(k�yas��);
            Console.WriteLine ("\t==>Maliyet'le artan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            k�yas��.StokK�yasAlan� = Stoklar.K�yasc�.K�yasAlan�.Mevcut;
            env.Sort(k�yas��);
            Console.WriteLine ("\t==>Mevcut'la artan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            //Ad, Maliyet, Mevcut'la azalan s�ralamalar
            Stoklar.K�yasc�2 k�yas��2 = Stoklar.K�yasc�y�Al2();
            k�yas��2.StokK�yasAlan� = Stoklar.K�yasc�2.K�yasAlan�.Ad;
            env.Sort(k�yas��2);
            Console.WriteLine ("\t==>Ad'la azalan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            k�yas��2.StokK�yasAlan� = Stoklar.K�yasc�2.K�yasAlan�.Maliyet;
            env.Sort(k�yas��2);
            Console.WriteLine ("\t==>Maliyet'le azalan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            k�yas��2.StokK�yasAlan� = Stoklar.K�yasc�2.K�yasAlan�.Mevcut;
            env.Sort(k�yas��2);
            Console.WriteLine ("\t==>Mevcut'la azalan s�ralama sonras� stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);

            Console.WriteLine ("\nY�llar s�n�f dizisine 100 adet y�l kaydedip, artan/azalan s�ralama:");
            Y�llar[] y�llar = new Y�llar [100];
            for(i=0;i<100;i++) {ts=r.Next(1938, 2025); y�llar [i] = new Y�llar (ts);}   
            Console.Write ("==>S�ras�z y�llar: ");
            foreach (Y�llar y�l in y�llar) Console.Write (y�l.y�l + " "); Console.WriteLine();
            Array.Sort (y�llar); 
            Console.Write ("==>Artan s�ral� y�llar: ");
            i=0;foreach (Y�llar y�l in y�llar) Console.Write ("{0}:{1} ", i++, y�l.y�l); Console.WriteLine();
            Y�llar y = new Y�llar (1985);
            ts = Array.BinarySearch (y�llar, y);
            Console.WriteLine ("\t==>Y�llar(1985)'in (ilk) endeksi: {0}", ts>-1?ts:-1);
            Console.Write ("==>Azalan s�ral� y�llar: ");
            for(i=0;i<y�llar.Length;i++) Console.Write (y�llar [99-i].y�l + " "); Console.WriteLine();

            Console.WriteLine ("\n�r�nlerin ad-fiyat-mevcut'la artan-azalan s�ralamalar�:");
            �r�nAdK�yas1<�r�n> adArtan = new �r�nAdK�yas1<�r�n>();
            �r�nAdK�yas2<�r�n> adAzalan = new �r�nAdK�yas2<�r�n>();
            �r�nFiyatK�yas1<�r�n> fiyatArtan = new �r�nFiyatK�yas1<�r�n>();
            �r�nFiyatK�yas2<�r�n> fiyatAzalan = new �r�nFiyatK�yas2<�r�n>();
            �r�nMevcutK�yas1<�r�n> mevcutArtan = new �r�nMevcutK�yas1<�r�n>();
            �r�nMevcutK�yas2<�r�n> mevcutAzalan = new �r�nMevcutK�yas2<�r�n>();
            List<�r�n> stok = new List<�r�n>();
            for(i=0;i<5;i++) {
                ad=""; for(j=0;j<5;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds=r.Next(1,2000)+r.Next(10,100)/100d;
                ts=r.Next(0,10000);
                stok.Add (new �r�n (ad, ds, ts));
            }
            Console.WriteLine ("\t==>S�ralama �ncesi �r�nler sto�u:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (adArtan);
            Console.WriteLine ("\t==>Ad'la artan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (adAzalan);
            Console.WriteLine ("\t==>Ad'la azalan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (fiyatArtan);
            Console.WriteLine ("\t==>Fiyat'la artan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (fiyatAzalan);
            Console.WriteLine ("\t==>Fiyat'la azalan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (mevcutArtan);
            Console.WriteLine ("\t==>Mevcut'la artan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);
            stok.Sort (mevcutAzalan);
            Console.WriteLine ("\t==>Mevcut'la azalan s�ralama sonras� �r�nler:");
            foreach(�r�n st in stok) Console.WriteLine (st);

            Console.WriteLine ("\ni�gDizi'nin ad-no-maa�'la artan ve azalan s�ral� sunumlar�:");
            ��g�ren2[] i�gDizi = new ��g�ren2 [5]; int ts1, ts2;
            for(i=0;i<i�gDizi.Length;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ds=r.Next(1,200000)+r.Next(10,100)/100d;
                i�gDizi [i] = new ��g�ren2 (ad, 1100-i, ds);
            }
            Console.WriteLine ("\t==>S�ralamas�z i�gDizi:");
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>Ad'la artan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.AdlaArtanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>Ad'la azalan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.AdlaAzalanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>No'yla artan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.NoylaArtanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>No'yla azalan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.NoylaAzalanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>Maa�'la artan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.Maa�laArtanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);
            Console.WriteLine ("\t==>Maa�'la azalan s�ral� i�gDizi:");
            Array.Sort (i�gDizi, ��g�ren2.Maa�laAzalanS�rala);
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine (i�g);

            Console.WriteLine ("\nSoysal �anta<T> i�in ekle, +-s�rala, teksil, t�msil, ebat, g�ster:");
            �anta<string> �antam = new �anta<string>();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(1,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                �antam.Ekle (ad);
            }
            Console.Write ("==>S�ras�z: "); �antam.G�ster(); Console.WriteLine();
            Console.Write ("==>+S�ral�: "); �antam.S�rala(); �antam.G�ster(); Console.WriteLine();
            Console.Write ("==>-S�ral�: "); �antam.TersS�rala(); �antam.G�ster(); Console.WriteLine();
            Console.WriteLine ("==>Ebat: "+�antam.Ebat());
            for(i=0;i<7;i++) Console.WriteLine ("Silinen �antam[{0}] = {1}\tEbat: {2}", i, �antam.Sil(), �antam.Ebat());
            string[] t�msil = �antam.T�m�n�Sil(); ad=""; for(i=0;i<t�msil.Length;i++) ad+=t�msil [i] + " ";
            Console.WriteLine ("Silinenler: {0}\tEbat: {1}", ad, �antam.Ebat());

            Console.WriteLine ("\nDe�erin tipini soysal <T> arg�manla detayland�rma:");
            ts=int.MaxValue;
            TipiniG�ster<int>(ts);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}