// j2sc#1110.cs: Collection/Dictionary/ReadOnly-base, klk-olay ve kabarc�k/h�zl� s�ralama �rne�i.

using System;
using System.Collections; //CollectionBase i�in
using System.Collections.ObjectModel; //Collection<T> i�in
namespace VeriYap�lar� {
    public class Listem<T> : Collection<T> {
        public event EventHandler<EklenenEndeksliKay�t<T>> Kay�tEklemeOlay�;
        protected override void InsertItem (int endeks, T kay�t) {
            EventHandler<EklenenEndeksliKay�t<T>> olayY�netimi = Kay�tEklemeOlay�;
            if (olayY�netimi != null) {olayY�netimi (this, new EklenenEndeksliKay�t<T> (endeks, kay�t));}
            base.InsertItem (endeks, kay�t);
        }
    }
    public class EklenenEndeksliKay�t<T> : EventArgs {
        public int Endeks;
        public T Kay�t;
        public EklenenEndeksliKay�t (int endeks, T kay�t) {//Kurucu
            this.Endeks = endeks;
            this.Kay�t = kay�t;
        }
    }
    public abstract class Hayvan {
        protected string ad, yemek, �r�n;
        public string Ad {get {return ad;} set {ad = value;}} //�zellik
        public string Yemek {get {return yemek;} set {yemek = value;}} //�zellik
        public string �r�n {get {return �r�n;} set {�r�n = value;}} //�zellik
        public Hayvan() {ad = "Ads�z hayvan";} //Kurucu-1
        public Hayvan (string a, string y, string �) {ad = a; yemek=y; �r�n=�;} //Kurucu-2
        public void Besle() {Console.WriteLine ("{0} {1} ile beslenir.", ad, yemek);}
        public void �r�nAl() {Console.WriteLine ("\t{0} {1} verir.", ad, �r�n);}
    }
    public class Tavuk : Hayvan {public Tavuk (string ad, string yemek, string �r�n): base (ad, yemek, �r�n){}}
    public class �nek : Hayvan {public �nek (string ad, string yemek, string �r�n): base (ad, yemek, �r�n){}}
    public class Koyun : Hayvan {public Koyun (string ad, string yemek, string �r�n): base (ad, yemek, �r�n){}}
    public class Ar� : Hayvan {public Ar� (string ad, string yemek, string �r�n): base (ad, yemek, �r�n){}}
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
        public void �r�nAl() {Console.WriteLine ("\t{0} {1} verir.", "Tavuk", "yumurta");}
    }
    public class �nek2 : Hayvan2 {
        public �nek2(){}
        public �nek2 (string ad, string yemek): base (ad, yemek){}
        public void �r�nAl() {Console.WriteLine ("\t{0} {1} verir.", "�nek", "s�t");}
    }
    public class Koyun2 : Hayvan2 {
        public Koyun2(){}
        public Koyun2 (string ad, string yemek): base (ad, yemek){}
        public void �r�nAl() {Console.WriteLine ("\t{0} {1} verir.", "Koyun", "et, s�t ve y�n");}
    }
    public class Ar�2 : Hayvan2 {
        public Ar�2(){}
        public Ar�2 (string ad, string yemek): base (ad, yemek){}
        public void �r�nAl() {Console.WriteLine ("\t{0} {1} verir.", "Ar�", "bal");}
    }
    public class M��teriler : ReadOnlyCollectionBase {
        public M��teriler() {M��terileriOku();} //Kurucu
        public M��teri this [int endeks] {get {return (M��teri)InnerList [endeks];}}
        private void M��terileriOku() {
            int i, j, ts1, ts2; string ad, gsm; Random r=new Random();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,11); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                gsm="("; for(j=0;j<3;j++) {ts1=r.Next(0,10); gsm+=ts1;} gsm+=") "; for(j=0;j<3;j++) {ts1=r.Next(0,10); gsm+=ts1;} gsm+=" "; for(j=0;j<4;j++) {ts1=r.Next(0,10); gsm+=ts1;}
                InnerList.Add (new M��teri (ad, gsm));
            }
        }
    }
    public class M��teri {
        public string Ad, GSM;
        public M��teri (string ad, string gsm) {Ad = ad; GSM = gsm;} //Kurucu
    }
    delegate bool K�yasla (object ns1, object ns2);
    class ��g�ren {
        private string isim;
        private decimal maa�;
        public ��g�ren (string isim, decimal maa�) {this.isim = isim; this.maa� = maa�;} //Kurucu
        public override string ToString() {return string.Format ("{0,-14}: {1:#,0.00}TL", isim, maa�);}
        public static bool Ns2B�y�kMaa� (object ns1, object ns2) {return (((��g�ren)ns2).maa� > ((��g�ren)ns1).maa�) ? true : false;}
        public static bool Ns2B�y�kAd (object ns2, object ns1) {return ((int)((��g�ren)ns2).isim[0] > (int)((��g�ren)ns1).isim[0]) ? true : false;}
    }
    class Kabarc�kS�ralay�c� {
        static public void Sort (object[] s�ralanacakDizi, K�yasla metoduAl) {
            for (int i = 0; i < s�ralanacakDizi.Length; i++) {
                for (int j = i + 1; j < s�ralanacakDizi.Length; j++) {
                    if (metoduAl (s�ralanacakDizi [j], s�ralanacakDizi [i])) {
                        object arac� = s�ralanacakDizi [i];
                        s�ralanacakDizi [i] = s�ralanacakDizi [j];
                        s�ralanacakDizi [j] = arac�;
                    }
                }
            }
        }
    }
    class H�zl�S�ralama<T> where T : IComparable {
        public T[] veri;
        public H�zl�S�ralama (T[] dizi) {veri = dizi;} //Kurucu
        public void Sort() {
            int uz = veri.Length;
            if (uz < 2) return;
            s�rala (0, veri.Length - 1);
        }
        private void s�rala (int ilk, int son) {
            if (ilk == son) {return;}
            else {
                int eksen = ekseniAl (ilk, son);
                if (eksen > ilk) s�rala (ilk, eksen - 1);
                if (eksen < son) s�rala (eksen + 1, son);
            }
        }
        private int ekseniAl (int ilk, int son) {
            int eksen = ilk;
            int ba�la = ilk;  
            int bitir = son;
            if (son - ilk >= 1) {
                while (bitir > ba�la) {
                    while (veri [eksen].CompareTo (veri [ba�la]) >= 0 && ba�la <= son && bitir > ba�la) ba�la++;
                    while (veri [eksen].CompareTo (veri [bitir]) <= 0 && bitir >= ilk && bitir >= ba�la) bitir--;
                    if (bitir > ba�la) takas (ba�la, bitir);
                }
                takas (ilk, bitir);
                s�rala (ilk, bitir - 1);
            }
            return bitir;
        }
        private void takas (int konum1, int konum2) {
            T arac�;
            arac� = veri [konum1];
            veri [konum1] = veri [konum2];
            veri [konum2] = arac�;
        }
    }
    class VeriYap�s�10 {
        static void Main() {
            Console.Write ("listem.Insert(ts1,ts2) endeks'li kay�t giri�i olay y�netimine delege'lenip girilen endeks ve de�er duyurulabilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("listem.Insert(ts1,ts2) ile listeye ts1 adet ts2 rasgele de�er girme:");
            int i, ts1, ts2; var r=new Random();
            Listem<int> listem = new Listem<int>();
            listem.Kay�tEklemeOlay� += delegate (object ns, EklenenEndeksliKay�t<int> arg�manlar) {
                Console.Write ("listem[{0}]={1} ", arg�manlar.Endeks, arg�manlar.Kay�t);
            };
            ts1=r.Next(1,102);
            for(i=0;i<ts1;i++) {ts2=r.Next(1881,1939); listem.Insert (i, ts2);} Console.WriteLine();

            Console.WriteLine ("\nHayvan koleksiyonlar� ekleme, besleme, �r�nalma:");
            Hayvanlar hyvnKlsn = new Hayvanlar();
            hyvnKlsn.Ekle (new �nek ("�nek", "yal", "s�t"));
            hyvnKlsn.Ekle (new Tavuk ("Tavuk", "tohum", "yumurta"));
            hyvnKlsn.Ekle (new Koyun ("Koyun", "ot", "et, s�t ve y�n"));
            hyvnKlsn.Ekle (new Ar� ("Ar�", "�i�ek �z�", "bal"));
            foreach (Hayvan h in hyvnKlsn) {h.Besle(); h.�r�nAl();}

            Console.WriteLine ("\nHayvanlar�, no ve adlar�yla s�zl��e ekleme ve sunumlar:");
            Hayvanlar2 hyvnS�zl�k = new Hayvanlar2();
            hyvnS�zl�k.Ekle (1957, new �nek2 ("�nek", "yal"));
            hyvnS�zl�k.Ekle (2024, new Tavuk2 ("Tavuk", "tohum"));
            hyvnS�zl�k.Ekle (2000, new Koyun2 ("Koyun", "ot"));
            hyvnS�zl�k.Ekle (1919, new Ar�2 ("Ar�", "�i�ek�z�"));
            foreach (Hayvan2 h in hyvnS�zl�k) {//No ile azalan d�k�m
                Console.WriteLine ("\t"+h.ToString());
                Console.WriteLine (h.Ad);
                h.Besle(); 
            }
            new Tavuk2().�r�nAl(); new �nek2().�r�nAl(); new Koyun2().�r�nAl(); new Ar�2().�r�nAl();

            Console.WriteLine ("\n10 m��teriye 'sadece-okunabilir' rasgele ad ve tlf de�erleri atay�p sunma:");
            M��teriler m��teriler = new M��teriler();
            foreach (M��teri m�� in m��teriler) Console.WriteLine ("{0,-10}: {1}", m��.Ad, m��.GSM);

            Console.WriteLine ("\n��g�renleri maa� ve isimle kabarc�ks�ralama y�ntemiyle sunma:");
            ��g�ren[] i�g�renler = {
                new ��g�ren ("M.Nihat Yava�", 10773.78M),
                new ��g�ren ("Adil �zbay", 15795.67M),
                new ��g�ren ("Hamza Candan", 28361.97m),
                new ��g�ren ("Sefer G�kyi�it", 98365.38m),
                new ��g�ren ("Canan Candan", 63987.25m),
                new ��g�ren ("Y�cel K���kbay", 54673.50m)};
            Console.WriteLine ("\tArtan maa�'la s�ral�:");
            K�yasla i�gK�yas = new K�yasla (��g�ren.Ns2B�y�kMaa�);
            Kabarc�kS�ralay�c�.Sort (i�g�renler, i�gK�yas);
            for(i=0;i<i�g�renler.Length;i++) Console.WriteLine (i�g�renler [i]);
            Console.WriteLine ("\tAzalan isim'le s�ral�:");
            i�gK�yas = new K�yasla (��g�ren.Ns2B�y�kAd);
            Kabarc�kS�ralay�c�.Sort (i�g�renler, i�gK�yas);
            for(i=0;i<i�g�renler.Length;i++) Console.WriteLine (i�g�renler [i]);

            ts1=r.Next(2,200); Console.WriteLine ("\nRasgele [1881,1938] de�erli tsDizi[{0}]'yi yegane artan h�zl�-s�ralama:", ts1);
            int[] tsDizi= new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(1881,1940); tsDizi [i]=ts2;}
            H�zl�S�ralama<int> h�zl�S�ra = new H�zl�S�ralama<int> (tsDizi);
            h�zl�S�ra.Sort();
            for(i=0;i<h�zl�S�ra.veri.Length-1;i++) if (h�zl�S�ra.veri [i] != h�zl�S�ra.veri [i+1]) Console.Write (h�zl�S�ra.veri [i]+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}