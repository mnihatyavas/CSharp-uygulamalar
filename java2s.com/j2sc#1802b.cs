// j2sc#1802b.cs: IComparable<T> ve IComparer<T> ile kýyaslý artan/azalan sýralama örneði.

using System;
using System.Collections.Generic;
using System.Collections; //<T>'siz Comparer koleksiyon Ýþgören için
namespace SoysalDökümleyici {
    public class Ýþgören : IComparable<Ýþgören> {
        private int iþgNo;
        private int hizmetYýlý = 1;
        public Ýþgören (int iþgNo) {this.iþgNo = iþgNo;} //Kurucu-1
        public Ýþgören (int iþgNo, int hizmetYýlý) {this.iþgNo = iþgNo; this.hizmetYýlý = hizmetYýlý;} //Kurucu-2
        public override string ToString() {return "(No, Yýl) = (" + iþgNo + ", " + hizmetYýlý + ")";}
        public static ÝþgKýyas KýyascýyýAl() {return new Ýþgören.ÝþgKýyas();}
        public int CompareTo (Ýþgören þu) {return 0;} //(Varsayýlý) Esasý bir alttaki
        public int CompareTo (Ýþgören þu, Ýþgören.ÝþgKýyas.KýyasAlaný alan) {
            switch (alan) {
                case Ýþgören.ÝþgKýyas.KýyasAlaný.ÝþgNo: return this.iþgNo.CompareTo (þu.iþgNo);
                case Ýþgören.ÝþgKýyas.KýyasAlaný.HYýl: return this.hizmetYýlý.CompareTo (þu.hizmetYýlý);
            }
            return 0;
        }
        public class ÝþgKýyas : IComparer<Ýþgören> {
            public enum KýyasAlaný {ÝþgNo, HYýl};
            public int Compare (Ýþgören bu, Ýþgören þu) {return bu.CompareTo (þu, ÝþgKýyasAlaný);}
            public Ýþgören.ÝþgKýyas.KýyasAlaný ÝþgKýyasAlaný {get; set;}
        }
    }
    class Stoklar: IComparable<Stoklar> {
        string ad;
        double maliyet;
        int mevcut;
        public Stoklar (string a, double m, int v) {ad = a; maliyet = m; mevcut = v;} //Kurucu
        public override string ToString() {return String.Format ("{0,-8}Maliyet: {1,8:#,0.00} TL  Mevcut: {2,6:#,0}", ad, maliyet, mevcut);}
        public int CompareTo (Stoklar þu) {return 0;} //(Varsayýlý) Esasý bir alttaki
        public int CompareTo (Stoklar þu, Stoklar.Kýyascý.KýyasAlaný alan) {
            switch (alan) {
                case Stoklar.Kýyascý.KýyasAlaný.Ad: return this.ad.CompareTo (þu.ad);
                case Stoklar.Kýyascý.KýyasAlaný.Maliyet: return this.maliyet.CompareTo (þu.maliyet);
                case Stoklar.Kýyascý.KýyasAlaný.Mevcut: return this.mevcut.CompareTo (þu.mevcut);
            }
            return 0;
        }
        public int CompareTo (Stoklar þu, Stoklar.Kýyascý2.KýyasAlaný alan) {
            switch (alan) {
                case Stoklar.Kýyascý2.KýyasAlaný.Ad: return this.ad.CompareTo (þu.ad);
                case Stoklar.Kýyascý2.KýyasAlaný.Maliyet: return this.maliyet.CompareTo (þu.maliyet);
                case Stoklar.Kýyascý2.KýyasAlaný.Mevcut: return this.mevcut.CompareTo (þu.mevcut);
            }
            return 0;
        }
        public static Kýyascý KýyascýyýAl() {return new Stoklar.Kýyascý();}
        public class Kýyascý : IComparer<Stoklar> {
            public enum KýyasAlaný {Ad, Maliyet, Mevcut};
            public int Compare (Stoklar bu, Stoklar þu) {return bu.CompareTo (þu, StokKýyasAlaný);}
            public Stoklar.Kýyascý.KýyasAlaný StokKýyasAlaný {get; set;}
        }
        public static Kýyascý2 KýyascýyýAl2() {return new Stoklar.Kýyascý2();}
        public class Kýyascý2 : IComparer<Stoklar> {
            public enum KýyasAlaný {Ad, Maliyet, Mevcut};
            //Azalan sýralama için sadece "return þu...bu" deðiþir
            public int Compare (Stoklar bu, Stoklar þu) {return þu.CompareTo (bu, StokKýyasAlaný);}
            public Stoklar.Kýyascý2.KýyasAlaný StokKýyasAlaný {get; set;}
        }
    }
    class Yýllar : IComparable<Yýllar> {
        public int yýl;
        public Yýllar (int y) {yýl = y;} //Kurucu
        public int CompareTo (Yýllar y) {return yýl - y.yýl;} //Artan sýralama
    }
    class Ürün {
        public string ad;
        public double fiyat;
        public int mevcut;
        public Ürün (string a, double f, int m) {ad = a; fiyat = f; mevcut = m;} //Kurucu
        public override string ToString() {return String.Format ("{0,-8}Fiyat: {1,8:#,0.00} TL  Mevcut: {2,6:#,0}", ad, fiyat, mevcut);}
    }
    class ÜrünAdKýyas1<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns1.ad.CompareTo (ns2.ad);}} //Artan
    class ÜrünAdKýyas2<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns2.ad.CompareTo (ns1.ad);}} //Azalan
    class ÜrünFiyatKýyas1<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns1.fiyat.CompareTo (ns2.fiyat);}} //Artan
    class ÜrünFiyatKýyas2<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns2.fiyat.CompareTo (ns1.fiyat);}} //Azalan
    class ÜrünMevcutKýyas1<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns1.mevcut.CompareTo (ns2.mevcut);}} //Artan
    class ÜrünMevcutKýyas2<T>: IComparer<T> where T: Ürün {public int Compare (T ns1, T ns2) {return ns2.mevcut.CompareTo (ns1.mevcut);}} //Azalan
    public class Ýþgören2: IComparable {
        string ad;
        int no;
        double maaþ;
        public Ýþgören2 (string a, int n, double m) {ad = a; no = n; maaþ=m;} //Kurucu
        public override string ToString() {return string.Format ("{0}({1}) = {2,11:#,00.00} TL", ad, no, maaþ);}
        public int CompareTo (object ns) {return(0);} //Ebeveyn varsayýlý
        public static IComparer AdlaArtanSýrala {get {return ((IComparer) new AdArtanSýralý());}}
        public static IComparer NoylaArtanSýrala {get {return ((IComparer) new NoArtanSýralý());}}
        public static IComparer MaaþlaArtanSýrala {get {return ((IComparer) new MaaþArtanSýralý());}}
        public static IComparer AdlaAzalanSýrala {get {return ((IComparer) new AdAzalanSýralý());}}
        public static IComparer NoylaAzalanSýrala {get {return ((IComparer) new NoAzalanSýralý());}}
        public static IComparer MaaþlaAzalanSýrala {get {return ((IComparer) new MaaþAzalanSýralý());}}
        class AdArtanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns1).ad.CompareTo (((Ýþgören2)ns2).ad);}}
        class AdAzalanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns2).ad.CompareTo (((Ýþgören2)ns1).ad);}}
        class NoArtanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns1).no.CompareTo (((Ýþgören2)ns2).no);}}
        class NoAzalanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns2).no.CompareTo (((Ýþgören2)ns1).no);}}
        class MaaþArtanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns1).maaþ.CompareTo (((Ýþgören2)ns2).maaþ);}}
        class MaaþAzalanSýralý: IComparer {public int Compare (object ns1, object ns2) {return ((Ýþgören2)ns2).maaþ.CompareTo (((Ýþgören2)ns1).maaþ);}}
    }
    public class Çanta<T> {
        private List<T> çantalar = new List<T>();
        public void Ekle (T çanta) {çantalar.Add (çanta);}
        public T Sil() {
            T çanta = default (T);
            if (çantalar.Count != 0) {çanta = çantalar [0]; çantalar.RemoveAt (0);}
            return çanta;
        }
        public T[] TümünüSil() {
            T[] i = çantalar.ToArray();
            çantalar.Clear();
            return i;
        }
        public int Ebat() {return çantalar.Count;}
        public void Sýrala() {çantalar.Sort();}
        public void TersSýrala() {çantalar.Sort(); çantalar.Reverse();}
        public void Göster() {foreach(T ç in çantalar) Console.Write (ç+" ");}
    }
    class SoysalKýyascý {
        static internal void TipiniGöster<X> (X veri) {
            Console.WriteLine ("Deðer: {0}", veri);
            Console.WriteLine ("typeof(X): "+typeof(X));
            Console.WriteLine ("typeof(List<X>): "+typeof(List<X>));
            Console.WriteLine ("typeof(Dictionary<string, X>): "+typeof(Dictionary<string, X>));
            Console.WriteLine ("typeof(List<long>): "+typeof(List<long>));
            Console.WriteLine ("typeof(Dictionary<long, Guid>): "+typeof(Dictionary<long, Guid>));
        }
        static void Main() {
            Console.Write ("Soysal List<Stoklar> için tüm alanlara göre artan ve azalan sýralama yapýlmýþtýr. Ýþgören2[] dizi kayýtlarýnýn ad-no-maaþ alanlarý artan ve azalan kýyascýlarla sýralanmýþtýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýþgören listesini iþgNo ve hyýl'a göre artan sýralama:");
            List<Ýþgören> iþgListe  = new List<Ýþgören>();
            var r=new Random(); int i, j, ts; double ds; string ad;
            for(i=0;i<5;i++) {iþgListe.Add (new Ýþgören (1100-i, r.Next (20)));}
            Ýþgören.ÝþgKýyas kýyascý = Ýþgören.KýyascýyýAl();
            kýyascý.ÝþgKýyasAlaný = Ýþgören.ÝþgKýyas.KýyasAlaný.ÝþgNo;
            iþgListe.Sort (kýyascý);
            for(i=0;i<iþgListe.Count;i++) Console.WriteLine (iþgListe [i]);
            kýyascý.ÝþgKýyasAlaný = Ýþgören.ÝþgKýyas.KýyasAlaný.HYýl;
            iþgListe.Sort (kýyascý);
            for(i=0;i<iþgListe.Count;i++) Console.WriteLine ("\t"+iþgListe [i]);

            Console.WriteLine ("\nStok envanterini ad/maliyet/mevcut'la artan/azalan sýralama:");
            List<Stoklar> env = new List<Stoklar>();
            for(i=0;i<5;i++) {
                ad=""; for(j=0;j<5;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds=r.Next(1,2000)+r.Next(10,100)/100d;
                ts=r.Next(0,10000);
                env.Add (new Stoklar (ad, ds, ts));
            }
            Console.WriteLine ("\t==>Sýralama öncesi stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            //Ad, Maliyet, Mevcut'la artan sýralamalar
            Stoklar.Kýyascý kýyasçý = Stoklar.KýyascýyýAl();
            kýyasçý.StokKýyasAlaný = Stoklar.Kýyascý.KýyasAlaný.Ad;
            env.Sort(kýyasçý);
            Console.WriteLine ("\t==>Ad'la artan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            kýyasçý.StokKýyasAlaný = Stoklar.Kýyascý.KýyasAlaný.Maliyet;
            env.Sort(kýyasçý);
            Console.WriteLine ("\t==>Maliyet'le artan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            kýyasçý.StokKýyasAlaný = Stoklar.Kýyascý.KýyasAlaný.Mevcut;
            env.Sort(kýyasçý);
            Console.WriteLine ("\t==>Mevcut'la artan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            //Ad, Maliyet, Mevcut'la azalan sýralamalar
            Stoklar.Kýyascý2 kýyasçý2 = Stoklar.KýyascýyýAl2();
            kýyasçý2.StokKýyasAlaný = Stoklar.Kýyascý2.KýyasAlaný.Ad;
            env.Sort(kýyasçý2);
            Console.WriteLine ("\t==>Ad'la azalan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            kýyasçý2.StokKýyasAlaný = Stoklar.Kýyascý2.KýyasAlaný.Maliyet;
            env.Sort(kýyasçý2);
            Console.WriteLine ("\t==>Maliyet'le azalan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);
            kýyasçý2.StokKýyasAlaný = Stoklar.Kýyascý2.KýyasAlaný.Mevcut;
            env.Sort(kýyasçý2);
            Console.WriteLine ("\t==>Mevcut'la azalan sýralama sonrasý stoklar:");
            foreach(Stoklar st in env) Console.WriteLine (st);

            Console.WriteLine ("\nYýllar sýnýf dizisine 100 adet yýl kaydedip, artan/azalan sýralama:");
            Yýllar[] yýllar = new Yýllar [100];
            for(i=0;i<100;i++) {ts=r.Next(1938, 2025); yýllar [i] = new Yýllar (ts);}   
            Console.Write ("==>Sýrasýz yýllar: ");
            foreach (Yýllar yýl in yýllar) Console.Write (yýl.yýl + " "); Console.WriteLine();
            Array.Sort (yýllar); 
            Console.Write ("==>Artan sýralý yýllar: ");
            i=0;foreach (Yýllar yýl in yýllar) Console.Write ("{0}:{1} ", i++, yýl.yýl); Console.WriteLine();
            Yýllar y = new Yýllar (1985);
            ts = Array.BinarySearch (yýllar, y);
            Console.WriteLine ("\t==>Yýllar(1985)'in (ilk) endeksi: {0}", ts>-1?ts:-1);
            Console.Write ("==>Azalan sýralý yýllar: ");
            for(i=0;i<yýllar.Length;i++) Console.Write (yýllar [99-i].yýl + " "); Console.WriteLine();

            Console.WriteLine ("\nÜrünlerin ad-fiyat-mevcut'la artan-azalan sýralamalarý:");
            ÜrünAdKýyas1<Ürün> adArtan = new ÜrünAdKýyas1<Ürün>();
            ÜrünAdKýyas2<Ürün> adAzalan = new ÜrünAdKýyas2<Ürün>();
            ÜrünFiyatKýyas1<Ürün> fiyatArtan = new ÜrünFiyatKýyas1<Ürün>();
            ÜrünFiyatKýyas2<Ürün> fiyatAzalan = new ÜrünFiyatKýyas2<Ürün>();
            ÜrünMevcutKýyas1<Ürün> mevcutArtan = new ÜrünMevcutKýyas1<Ürün>();
            ÜrünMevcutKýyas2<Ürün> mevcutAzalan = new ÜrünMevcutKýyas2<Ürün>();
            List<Ürün> stok = new List<Ürün>();
            for(i=0;i<5;i++) {
                ad=""; for(j=0;j<5;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                ds=r.Next(1,2000)+r.Next(10,100)/100d;
                ts=r.Next(0,10000);
                stok.Add (new Ürün (ad, ds, ts));
            }
            Console.WriteLine ("\t==>Sýralama öncesi ürünler stoðu:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (adArtan);
            Console.WriteLine ("\t==>Ad'la artan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (adAzalan);
            Console.WriteLine ("\t==>Ad'la azalan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (fiyatArtan);
            Console.WriteLine ("\t==>Fiyat'la artan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (fiyatAzalan);
            Console.WriteLine ("\t==>Fiyat'la azalan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (mevcutArtan);
            Console.WriteLine ("\t==>Mevcut'la artan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);
            stok.Sort (mevcutAzalan);
            Console.WriteLine ("\t==>Mevcut'la azalan sýralama sonrasý ürünler:");
            foreach(Ürün st in stok) Console.WriteLine (st);

            Console.WriteLine ("\niþgDizi'nin ad-no-maaþ'la artan ve azalan sýralý sunumlarý:");
            Ýþgören2[] iþgDizi = new Ýþgören2 [5]; int ts1, ts2;
            for(i=0;i<iþgDizi.Length;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ds=r.Next(1,200000)+r.Next(10,100)/100d;
                iþgDizi [i] = new Ýþgören2 (ad, 1100-i, ds);
            }
            Console.WriteLine ("\t==>Sýralamasýz iþgDizi:");
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>Ad'la artan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.AdlaArtanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>Ad'la azalan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.AdlaAzalanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>No'yla artan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.NoylaArtanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>No'yla azalan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.NoylaAzalanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>Maaþ'la artan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.MaaþlaArtanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);
            Console.WriteLine ("\t==>Maaþ'la azalan sýralý iþgDizi:");
            Array.Sort (iþgDizi, Ýþgören2.MaaþlaAzalanSýrala);
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine (iþg);

            Console.WriteLine ("\nSoysal Çanta<T> için ekle, +-sýrala, teksil, tümsil, ebat, göster:");
            Çanta<string> çantam = new Çanta<string>();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(1,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                çantam.Ekle (ad);
            }
            Console.Write ("==>Sýrasýz: "); çantam.Göster(); Console.WriteLine();
            Console.Write ("==>+Sýralý: "); çantam.Sýrala(); çantam.Göster(); Console.WriteLine();
            Console.Write ("==>-Sýralý: "); çantam.TersSýrala(); çantam.Göster(); Console.WriteLine();
            Console.WriteLine ("==>Ebat: "+çantam.Ebat());
            for(i=0;i<7;i++) Console.WriteLine ("Silinen çantam[{0}] = {1}\tEbat: {2}", i, çantam.Sil(), çantam.Ebat());
            string[] tümsil = çantam.TümünüSil(); ad=""; for(i=0;i<tümsil.Length;i++) ad+=tümsil [i] + " ";
            Console.WriteLine ("Silinenler: {0}\tEbat: {1}", ad, çantam.Ebat());

            Console.WriteLine ("\nDeðerin tipini soysal <T> argümanla detaylandýrma:");
            ts=int.MaxValue;
            TipiniGöster<int>(ts);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}