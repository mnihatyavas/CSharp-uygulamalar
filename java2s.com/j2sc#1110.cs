// j2sc#1110.cs: Collection/Dictionary/ReadOnly-base, klk-olay ve kabarcýk/hýzlý sýralama örneði.

using System;
using System.Collections; //CollectionBase için
using System.Collections.ObjectModel; //Collection<T> için
namespace VeriYapýlarý {
    public class Listem<T> : Collection<T> {
        public event EventHandler<EklenenEndeksliKayýt<T>> KayýtEklemeOlayý;
        protected override void InsertItem (int endeks, T kayýt) {
            EventHandler<EklenenEndeksliKayýt<T>> olayYönetimi = KayýtEklemeOlayý;
            if (olayYönetimi != null) {olayYönetimi (this, new EklenenEndeksliKayýt<T> (endeks, kayýt));}
            base.InsertItem (endeks, kayýt);
        }
    }
    public class EklenenEndeksliKayýt<T> : EventArgs {
        public int Endeks;
        public T Kayýt;
        public EklenenEndeksliKayýt (int endeks, T kayýt) {//Kurucu
            this.Endeks = endeks;
            this.Kayýt = kayýt;
        }
    }
    public abstract class Hayvan {
        protected string ad, yemek, ürün;
        public string Ad {get {return ad;} set {ad = value;}} //Özellik
        public string Yemek {get {return yemek;} set {yemek = value;}} //Özellik
        public string Ürün {get {return ürün;} set {ürün = value;}} //Özellik
        public Hayvan() {ad = "Adsýz hayvan";} //Kurucu-1
        public Hayvan (string a, string y, string ü) {ad = a; yemek=y; ürün=ü;} //Kurucu-2
        public void Besle() {Console.WriteLine ("{0} {1} ile beslenir.", ad, yemek);}
        public void ÜrünAl() {Console.WriteLine ("\t{0} {1} verir.", ad, ürün);}
    }
    public class Tavuk : Hayvan {public Tavuk (string ad, string yemek, string ürün): base (ad, yemek, ürün){}}
    public class Ýnek : Hayvan {public Ýnek (string ad, string yemek, string ürün): base (ad, yemek, ürün){}}
    public class Koyun : Hayvan {public Koyun (string ad, string yemek, string ürün): base (ad, yemek, ürün){}}
    public class Arý : Hayvan {public Arý (string ad, string yemek, string ürün): base (ad, yemek, ürün){}}
    public class Hayvanlar : CollectionBase {
        public void Ekle (Hayvan hayvan) {List.Add (hayvan);}
        public Hayvanlar(){} //Kurucu
        public Hayvan this [int endeks] {get {return (Hayvan)List [endeks];} set {List [endeks] = value;}}
    }
     public class Hayvanlar2 : DictionaryBase {
        public void Ekle (int no, Hayvan2 h2) {Dictionary.Add (no, h2);}
        public Hayvanlar2(){} //Kurucu
        public Hayvan2 this[int no] {get{return (Hayvan2)Dictionary [no];} set{Dictionary [no] = value;}}
        public new IEnumerator GetEnumerator() {foreach (object havan in Dictionary.Values)yield return (Hayvan2)havan;}
    }
    public abstract class Hayvan2 {
        protected string ad, yemek;
        public string Ad {get{return ad;} set{ad = value;}}
        public string Yemek {get{return yemek;} set{ad = value;}}
        public Hayvan2(){}
        public Hayvan2 (string a, string y) {ad = a; yemek=y;} //Kurucu
        public void Besle() {Console.WriteLine ("{0} {1} ile beslenir.", ad, yemek);}
    }
    public class Tavuk2 : Hayvan2 {
        public Tavuk2(){}
        public Tavuk2 (string ad, string yemek): base (ad, yemek){}
        public void ÜrünAl() {Console.WriteLine ("\t{0} {1} verir.", "Tavuk", "yumurta");}
    }
    public class Ýnek2 : Hayvan2 {
        public Ýnek2(){}
        public Ýnek2 (string ad, string yemek): base (ad, yemek){}
        public void ÜrünAl() {Console.WriteLine ("\t{0} {1} verir.", "Ýnek", "süt");}
    }
    public class Koyun2 : Hayvan2 {
        public Koyun2(){}
        public Koyun2 (string ad, string yemek): base (ad, yemek){}
        public void ÜrünAl() {Console.WriteLine ("\t{0} {1} verir.", "Koyun", "et, süt ve yün");}
    }
    public class Arý2 : Hayvan2 {
        public Arý2(){}
        public Arý2 (string ad, string yemek): base (ad, yemek){}
        public void ÜrünAl() {Console.WriteLine ("\t{0} {1} verir.", "Arý", "bal");}
    }
    public class Müþteriler : ReadOnlyCollectionBase {
        public Müþteriler() {MüþterileriOku();} //Kurucu
        public Müþteri this [int endeks] {get {return (Müþteri)InnerList [endeks];}}
        private void MüþterileriOku() {
            int i, j, ts1, ts2; string ad, gsm; Random r=new Random();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,11); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                gsm="("; for(j=0;j<3;j++) {ts1=r.Next(0,10); gsm+=ts1;} gsm+=") "; for(j=0;j<3;j++) {ts1=r.Next(0,10); gsm+=ts1;} gsm+=" "; for(j=0;j<4;j++) {ts1=r.Next(0,10); gsm+=ts1;}
                InnerList.Add (new Müþteri (ad, gsm));
            }
        }
    }
    public class Müþteri {
        public string Ad, GSM;
        public Müþteri (string ad, string gsm) {Ad = ad; GSM = gsm;} //Kurucu
    }
    delegate bool Kýyasla (object ns1, object ns2);
    class Ýþgören {
        private string isim;
        private decimal maaþ;
        public Ýþgören (string isim, decimal maaþ) {this.isim = isim; this.maaþ = maaþ;} //Kurucu
        public override string ToString() {return string.Format ("{0,-14}: {1:#,0.00}TL", isim, maaþ);}
        public static bool Ns2BüyükMaaþ (object ns1, object ns2) {return (((Ýþgören)ns2).maaþ > ((Ýþgören)ns1).maaþ) ? true : false;}
        public static bool Ns2BüyükAd (object ns2, object ns1) {return ((int)((Ýþgören)ns2).isim[0] > (int)((Ýþgören)ns1).isim[0]) ? true : false;}
    }
    class KabarcýkSýralayýcý {
        static public void Sort (object[] sýralanacakDizi, Kýyasla metoduAl) {
            for (int i = 0; i < sýralanacakDizi.Length; i++) {
                for (int j = i + 1; j < sýralanacakDizi.Length; j++) {
                    if (metoduAl (sýralanacakDizi [j], sýralanacakDizi [i])) {
                        object aracý = sýralanacakDizi [i];
                        sýralanacakDizi [i] = sýralanacakDizi [j];
                        sýralanacakDizi [j] = aracý;
                    }
                }
            }
        }
    }
    class HýzlýSýralama<T> where T : IComparable {
        public T[] veri;
        public HýzlýSýralama (T[] dizi) {veri = dizi;} //Kurucu
        public void Sort() {
            int uz = veri.Length;
            if (uz < 2) return;
            sýrala (0, veri.Length - 1);
        }
        private void sýrala (int ilk, int son) {
            if (ilk == son) {return;}
            else {
                int eksen = ekseniAl (ilk, son);
                if (eksen > ilk) sýrala (ilk, eksen - 1);
                if (eksen < son) sýrala (eksen + 1, son);
            }
        }
        private int ekseniAl (int ilk, int son) {
            int eksen = ilk;
            int baþla = ilk;  
            int bitir = son;
            if (son - ilk >= 1) {
                while (bitir > baþla) {
                    while (veri [eksen].CompareTo (veri [baþla]) >= 0 && baþla <= son && bitir > baþla) baþla++;
                    while (veri [eksen].CompareTo (veri [bitir]) <= 0 && bitir >= ilk && bitir >= baþla) bitir--;
                    if (bitir > baþla) takas (baþla, bitir);
                }
                takas (ilk, bitir);
                sýrala (ilk, bitir - 1);
            }
            return bitir;
        }
        private void takas (int konum1, int konum2) {
            T aracý;
            aracý = veri [konum1];
            veri [konum1] = veri [konum2];
            veri [konum2] = aracý;
        }
    }
    class VeriYapýsý10 {
        static void Main() {
            Console.Write ("listem.Insert(ts1,ts2) endeks'li kayýt giriþi olay yönetimine delege'lenip girilen endeks ve deðer duyurulabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("listem.Insert(ts1,ts2) ile listeye ts1 adet ts2 rasgele deðer girme:");
            int i, ts1, ts2; var r=new Random();
            Listem<int> listem = new Listem<int>();
            listem.KayýtEklemeOlayý += delegate (object ns, EklenenEndeksliKayýt<int> argümanlar) {
                Console.Write ("listem[{0}]={1} ", argümanlar.Endeks, argümanlar.Kayýt);
            };
            ts1=r.Next(1,102);
            for(i=0;i<ts1;i++) {ts2=r.Next(1881,1939); listem.Insert (i, ts2);} Console.WriteLine();

            Console.WriteLine ("\nHayvan koleksiyonlarý ekleme, besleme, ürünalma:");
            Hayvanlar hyvnKlsn = new Hayvanlar();
            hyvnKlsn.Ekle (new Ýnek ("Ýnek", "yal", "süt"));
            hyvnKlsn.Ekle (new Tavuk ("Tavuk", "tohum", "yumurta"));
            hyvnKlsn.Ekle (new Koyun ("Koyun", "ot", "et, süt ve yün"));
            hyvnKlsn.Ekle (new Arý ("Arý", "çiçek özü", "bal"));
            foreach (Hayvan h in hyvnKlsn) {h.Besle(); h.ÜrünAl();}

            Console.WriteLine ("\nHayvanlarý, no ve adlarýyla sözlüðe ekleme ve sunumlar:");
            Hayvanlar2 hyvnSözlük = new Hayvanlar2();
            hyvnSözlük.Ekle (1957, new Ýnek2 ("Ýnek", "yal"));
            hyvnSözlük.Ekle (2024, new Tavuk2 ("Tavuk", "tohum"));
            hyvnSözlük.Ekle (2000, new Koyun2 ("Koyun", "ot"));
            hyvnSözlük.Ekle (1919, new Arý2 ("Arý", "çiçeközü"));
            foreach (Hayvan2 h in hyvnSözlük) {//No ile azalan döküm
                Console.WriteLine ("\t"+h.ToString());
                Console.WriteLine (h.Ad);
                h.Besle(); 
            }
            new Tavuk2().ÜrünAl(); new Ýnek2().ÜrünAl(); new Koyun2().ÜrünAl(); new Arý2().ÜrünAl();

            Console.WriteLine ("\n10 müþteriye 'sadece-okunabilir' rasgele ad ve tlf deðerleri atayýp sunma:");
            Müþteriler müþteriler = new Müþteriler();
            foreach (Müþteri müþ in müþteriler) Console.WriteLine ("{0,-10}: {1}", müþ.Ad, müþ.GSM);

            Console.WriteLine ("\nÝþgörenleri maaþ ve isimle kabarcýksýralama yöntemiyle sunma:");
            Ýþgören[] iþgörenler = {
                new Ýþgören ("M.Nihat Yavaþ", 10773.78M),
                new Ýþgören ("Adil Özbay", 15795.67M),
                new Ýþgören ("Hamza Candan", 28361.97m),
                new Ýþgören ("Sefer Gökyiðit", 98365.38m),
                new Ýþgören ("Canan Candan", 63987.25m),
                new Ýþgören ("Yücel Küçükbay", 54673.50m)};
            Console.WriteLine ("\tArtan maaþ'la sýralý:");
            Kýyasla iþgKýyas = new Kýyasla (Ýþgören.Ns2BüyükMaaþ);
            KabarcýkSýralayýcý.Sort (iþgörenler, iþgKýyas);
            for(i=0;i<iþgörenler.Length;i++) Console.WriteLine (iþgörenler [i]);
            Console.WriteLine ("\tAzalan isim'le sýralý:");
            iþgKýyas = new Kýyasla (Ýþgören.Ns2BüyükAd);
            KabarcýkSýralayýcý.Sort (iþgörenler, iþgKýyas);
            for(i=0;i<iþgörenler.Length;i++) Console.WriteLine (iþgörenler [i]);

            ts1=r.Next(2,200); Console.WriteLine ("\nRasgele [1881,1938] deðerli tsDizi[{0}]'yi yegane artan hýzlý-sýralama:", ts1);
            int[] tsDizi= new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(1881,1940); tsDizi [i]=ts2;}
            HýzlýSýralama<int> hýzlýSýra = new HýzlýSýralama<int> (tsDizi);
            hýzlýSýra.Sort();
            for(i=0;i<hýzlýSýra.veri.Length-1;i++) if (hýzlýSýra.veri [i] != hýzlýSýra.veri [i+1]) Console.Write (hýzlýSýra.veri [i]+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}