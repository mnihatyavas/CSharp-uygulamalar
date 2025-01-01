// j2sc#2202n.cs: Yegane Distinct ve say�sal toplam Sum metotlar� �rne�i.

using System;
using System.Linq; //Distinct() i�in
using System.Collections.Generic; //List<> i�in
using System.Collections; //ArrayList ii�in
namespace LinqMetot {
    class �r�n : IComparable<�r�n> {
        public int �r�nNo {get; set;}
        public string �r�nAd� {get; set;}
        public string Katagori {get; set;}
        public int BirimFiyat {get; set;}
        public int Sipari�Adedi {get; set;}
        public DateTime Sipari�Tarihi {get; set;}
        public override string ToString() {return String.Format ("�r�n no: {0}, �r�n ad�: {1} , Katagori: {3}", this.�r�nNo, this.�r�nAd�, this.Katagori);}
        int IComparable<�r�n>.CompareTo (�r�n �u) {
            if (�u == null) return 1;
            if (this.�r�nNo > �u.�r�nNo) return 1;
            if (this.�r�nNo < �u.�r�nNo) return -1;
            return 0;
        }
    }
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
        public static ���i[] ��ListeAl() {return ((���i[])���iListesiniAl().ToArray (typeof(���i)));}
    }
    public class Maa� {
        public int y�l;
        public decimal maa�;
        public static ArrayList Maa�ListesiniAl() {
            Random r=new Random(); decimal dc;
            ArrayList liste = new ArrayList();
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1891, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1899, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1931, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1934, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1951, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1953, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1955, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1957, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1959, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1961, maa�=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maa� {y�l = 1963, maa�=dc});
            return (liste);
        }
        public static Maa�[] MListeAl() {return ((Maa�[])Maa�ListesiniAl().ToArray (typeof(Maa�)));}
    }
    public class D�zen<D���m>: IEnumerable<D���m> where D���m: IComparable<D���m>{
        public D���m Veri {get; set;}
        public D�zen<D���m> Sola {get; set;}
        public D�zen<D���m> Sa�a {get; set;}
        public D�zen (D���m de�er) {this.Veri = de�er; this.Sola = null; this.Sa�a = null;} //Kurucu
        public void Sok (D���m �u) {
            D���m akt�el = this.Veri;
            if (akt�el.CompareTo (�u) > 0) {
                if (this.Sola == null) {this.Sola = new D�zen<D���m>(�u);
                }else {this.Sola.Sok (�u);}
            }else {
                if (this.Sa�a == null) { this.Sa�a = new D�zen<D���m>(�u);
                }else {this.Sa�a.Sok (�u);}
            }
        }
        public void Dola�() {
            if (this.Sola != null) {this.Sola.Dola�();}
            Console.WriteLine (this.Veri.ToString());
            if (this.Sa�a != null) {this.Sa�a.Dola�();}
        }
        IEnumerator<D���m> IEnumerable<D���m>.GetEnumerator() {
            if (this.Sola != null) {foreach (D���m birim in this.Sola) {yield return birim;}}
            yield return this.Veri;
            if (this.Sa�a != null) {foreach (D���m birim in this.Sa�a) {yield return birim;}}
        }
        IEnumerator IEnumerable.GetEnumerator() {throw new NotImplementedException();}
    }
    class ���i2: IComparable<���i2> {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public string Bran� {get; set;}
        public int No {get; set;}
        public decimal Ayl�k {get; set;}
        public override string ToString() {return String.Format ("No: {0}, �sim: {1} {2}, Bran�: {3}, Maa�: {4:#,0.00} TL", this.No, this.Ad, this.Soyad, this.Bran�, this.Ayl�k);}
        int IComparable<���i2>.CompareTo (���i2 �u) {
            if (�u == null) return 1;
            if (this.Ayl�k > �u.Ayl�k) return 1;
            if (this.Ayl�k < �u.Ayl�k) return -1;
            return 0;
        }
    }
    class Distinct_Sum {
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nNo = 1881, �r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1500, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1914, �r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 130, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1919, �r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 680, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1920, �r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 700, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1923, �r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, Sipari�Adedi = 1600, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1930, �r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1938, �r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 285, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return �r�nListesi;
        }
        static void Main() {
            Console.Write ("'dizi.Distinct()' dizi elemanlar�n�n tekrars�z yeganelerini s�zer. 'dizi.Sum()' say�sal dizi elemanlar�n�n toplam�n� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("50 adet rasgele y�llar, yeganeleri, se�imli sorgu ve toplamlar�:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[50];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("-->T�m rasgele {0} adet y�llar: ", y�llar.Length);
            foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            var yegane1 = y�llar.Distinct();
            Console.Write ("-->Yegane {0} y�l: ", yegane1.Count());
            foreach (var y�l in yegane1) Console.Write (y�l+ " "); Console.WriteLine();
            Console.WriteLine ("-->Rasgele {0} y�l�n toplam�: {1},\tOrtalamas�: {2}", y�llar.Length, y�llar.Sum(), y�llar.Sum() / y�llar.Length);
            ts=r.Next(0,y�llar.Length);
            var sorgu1 = (from y�l in y�llar where y�l > y�llar [ts] select y�l).Distinct();
            Console.Write ("-->{0}'den b�y�k {1} adet yegane y�llar: ", y�llar [ts], sorgu1.Count());
            foreach (int y�l in sorgu1) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("-->Se�ili y�llar�n toplam�: {0},\tOrtalamas�: {1}", sorgu1.Sum(), sorgu1.Sum() / sorgu1.Count());

            Console.WriteLine ("\n�r�nleri, yegane katagorileri, toplam fatura tutar�n� sunma:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            Console.WriteLine ("-->T�m {0} adet �r�nler (no, ad, katagori, birimFiyat, sipari�Adedi): ", �r�nler.Count());
            foreach (var � in �r�nler) Console.WriteLine ("({0}, {1}, {2}, {3}, {4})", �.�r�nNo, �.�r�nAd�, �.Katagori, �.BirimFiyat, �.Sipari�Adedi);
            var sorgu2 = (from �rn in �r�nler select �rn.Katagori).Distinct();
            Console.Write ("-->Yegane katagori adlar�: ");
            foreach (var ad in sorgu2) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("-->Yegane katagori adlar�n�n uzunlu�u: {0}", sorgu2.Sum (ad => ad.Length));
            var sorgu3 =
                from � in �r�nler
                group � by �.Katagori into gr
                select new {Katagori = gr.Key, ToplamSipari� = gr.Sum (� => �.Sipari�Adedi)};
            foreach (var sip in sorgu3) Console.WriteLine (sip);
            var sorgu4 = from � in �r�nler select �.BirimFiyat * �.Sipari�Adedi;
            Console.WriteLine ("-->Toplam(BirimFiyat * Sipari�Adedi) fatura tutar�: {0:#,0.00} TL", sorgu4.Sum());

            Console.WriteLine ("\n���i ve Maa� liste birle�imi, maa� toplam�, yegane soyadlar:");
            ���i[] i��iler = ���i.��ListeAl();
            Maa�[] maa�lar = Maa�.MListeAl();
            var sorgu5 = from i� in i��iler
                join m in maa�lar on i�.y�l equals m.y�l
                select new {no=i�.y�l, ad=i�.ad, soyad=i�.soyad, maa�=m.maa�};
            Console.WriteLine ("-->T�m {0} adet i��iler ve maa�lar�:", sorgu5.Count());
            foreach (var im in sorgu5) Console.WriteLine (im);
            Console.WriteLine ("-->Maa�lar�n toplam�: {0:#,0.00} TL\tOrtalamas�: {1:#,0.00} TL", sorgu5.Sum (m=>m.maa�), sorgu5.Sum (m=>m.maa�) / sorgu5.Count());
            Console.Write ("-->Yegane soyadlar: "); foreach (var sa in (from i� in i��iler select i�.soyad).Distinct()) Console.Write (sa+" "); Console.WriteLine();

            Console.WriteLine ("\n�e�itli bran�l� personel listesi, yegane bran�lar, maa�lar toplam� ve ortalamas�:");
            decimal dc; dc=r.Next(10000,150000)+r.Next(10,100)/100m;
            D�zen<���i2> personel = new D�zen<���i2>(new ���i2 {No = 1975, Ad = "Canan", Soyad = "Candan", Bran� = "Ziraat", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1951, Bran� = "Muhasebe", Soyad = "Ka�ar", Ad = "Hatice", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1953, Bran� = "Vardiya", Soyad = "�zbay", Ad = "S�heyla", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1955, Bran� = "A���", Soyad = "Candan", Ad = "Zeliha", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1957, Bran� = "Vardiya", Soyad = "Yava�", Ad = "M.Nihat", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1959, Bran� = "E�itim", Soyad = "G�kyi�it", Ad = "Song�l", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1961, Bran� = "Sat��", Soyad = "Yava�", Ad = "M.Nedim", Ayl�k = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new ���i2 {No = 1963, Bran� = "�n�aat", Soyad = "Yava�", Ad = "Sevim", Ayl�k = dc});
            Console.WriteLine ("-->T�m {0} ki�ilik artan-maa�l� personel listesi:", personel.Count()); foreach (var p in personel) Console.WriteLine (p);
            var sorgu6 = (from b in personel select b.Bran�).Distinct();
            Console.Write ("-->Yegane {0} departman: ", sorgu6.Count()); foreach (var b in sorgu6) Console.Write (b+" "); Console.WriteLine();
            Console.WriteLine ("-->Maa�lar�n toplam�: {0:#,0.00} TL\tOrtalamas�: {1:#,0.00} TL", personel.Sum (m=>m.Ayl�k), personel.Sum (m=>m.Ayl�k) / personel.Count());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}