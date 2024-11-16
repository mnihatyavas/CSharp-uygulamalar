// j2sc#2202a.cs: Ling from-select sorgular�n�n foreach'le sunumu �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; //Where i�in
using System.Collections; //ArrayList i�in
namespace LinqMetot {
    class M��teri : IComparable<M��teri> {
        public int M��teriNo {get; set;}
        public string �irketAd� {get; set;}
        public string Adresi {get; set;}
        public List<�r�n> Sipari�ler {get; set;}
        public override string ToString() {return String.Format ("M��teri no: {0}, �irket ad�: {1}, Adresi: {3}", this.M��teriNo, this.�irketAd�, this.Adresi);}
        int IComparable<M��teri>.CompareTo (M��teri �u) {
            if (�u == null) return 1;
            if (this.M��teriNo > �u.M��teriNo) return 1;
            if (this.M��teriNo < �u.M��teriNo) return -1;
            return 0;
        }
    }
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
    class Araba {
        public string �of�rAd�;
        public string Markas�;
        public string Rengi;
        public int Akt�elH�z�;
        public override string ToString() {return string.Format ("Marka={0}, Renk={1}, �uanki h�z�={2}, S�r�c� ad�={3}", Markas�, Rengi, Akt�elH�z�, �of�rAd�);
        }
    }
    public class Fihrist {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public string Eposta {get; set;}
        public override string ToString() {return string.Format ("�sim: [{0} {1}]\tEposta: [{2}]", Ad, Soyad, Eposta);}
    }
    class Foreach {
        static List<M��teri> M��teriListesiniAl() {
        List<�r�n> �r�nListesi = new List<�r�n>();
        �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
        �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
        �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
        �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
        �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
        �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
        List<M��teri> m��teriListesi = new List<M��teri>();
        m��teriListesi.Add (new M��teri {�irketAd� = "Abdulkerim Ltd", Adresi = "Rize", Sipari�ler = �r�nListesi, M��teriNo = 10});
        m��teriListesi.Add (new M��teri {�irketAd� = "Ziyadede A�", Adresi = "Kayseri", Sipari�ler = �r�nListesi, M��teriNo = 4});
        m��teriListesi.Add (new M��teri {�irketAd� = "P�narba�� Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 25});
        m��teriListesi.Add (new M��teri {�irketAd� = "Billiruye A�", Adresi = "Zonguldak", Sipari�ler = �r�nListesi, M��teriNo = 93});
        m��teriListesi.Add (new M��teri {�irketAd� = "�emseddinpa�a A�", Adresi = "Kars", Sipari�ler = �r�nListesi, M��teriNo = 64});
        m��teriListesi.Add (new M��teri {�irketAd� = "Ke�i�ren Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 164});
        return m��teriListesi;
    }
        static void Main() {
            Console.Write ("Liste veya dizi i�i sorgular 'var' veya IEnumerable<T> referansl� from-where-orderby-select'le yap�l�p sonu�lar foreach'le d�k�mlenir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�m farkl� �ehir m��teri firmalar �reticiye faraza ayn� sipari�i versin:");
            List<M��teri> m��teriler = M��teriListesiniAl();
            var m��teriSorgusu = from m�� in m��teriler
                where m��.Adresi == "Ankara"
                select m��;
            foreach (var m�� in m��teriSorgusu) {
                Console.WriteLine ("M��teri [{0}: {1} - {2}]", m��.M��teriNo, m��.�irketAd�, m��.Adresi);
                foreach (var sipari� in m��.Sipari�ler) Console.WriteLine ("\tSipari� [{0}: {1}]", sipari�.�r�nNo, sipari�.�r�nAd�, sipari�.Sipari�Tarihi);
            }

            Console.WriteLine ("\nForeach-var'la aylar�n sorgulu ve s�ral� d�k�mleri:");
            string[] aylar = {"Ocak", "�ubat", "Mart", "Nisan","May�s", "Haziran", "Temmuz", "A�ustos", "Eyl�l", "Ekim","Kas�m", "Aral�k"};
            var aySorgusu = from ay in aylar where ay.Length > 5 orderby ay select ay;
            Console.WriteLine ("-->Ay.Length > 5 aylar�n artan s�ral�lar�:");
            foreach (var ay in aySorgusu) Console.Write (ay+" "); Console.WriteLine();
            aySorgusu = from ay in aylar where ay.Length <= 5 orderby ay select ay;
            Console.WriteLine ("-->Ay.Length <= 5 aylar�n artan s�ral�lar�:");
            foreach (var ay in aySorgusu) Console.Write (ay+" "); Console.WriteLine();

            Console.WriteLine ("\nS�r�c�lerin akt�el radarla araba s�r�� h�zlar�n�n tespiti:");
            ArrayList arabalar = new ArrayList();  
            arabalar.Add (new Araba {�of�rAd� = "Sevim", Rengi = "Beyaz", Akt�elH�z� = 160, Markas� = "BMW"});
            arabalar.Add (new Araba {�of�rAd� = "Canan", Rengi = "Ye�il", Akt�elH�z� = 95, Markas� = "Wolvo"});
            arabalar.Add (new Araba {�of�rAd� = "Belk�s", Rengi = "Mavi", Akt�elH�z� = 68, Markas� = "Ford"});
            IEnumerable<Araba> arabalarEnum = arabalar.OfType<Araba>();
            var arabaSorgusu = from araba in arabalarEnum where araba.Akt�elH�z� > 90 select araba;
            foreach (var oto in arabaSorgusu) Console.WriteLine ("{0}, {1}-{2} arabas�n� h�zl� (>90) s�r�yor!", oto.�of�rAd�, oto.Rengi, oto.Markas�);
            arabaSorgusu = from araba in arabalarEnum where araba.Akt�elH�z� <= 90 select araba;
            foreach (var oto in arabaSorgusu) Console.WriteLine ("{0}, {1}-{2} arabas�n� normal (<=90) s�r�yor.", oto.�of�rAd�, oto.Rengi, oto.Markas�);

            Console.WriteLine ("\n�st �rne�in ArrayList yerine Araba[] dizili benzeri:");
            Araba[] arabalar2 = new []{
                new Araba {�of�rAd� = "Sevim", Rengi = "Beyaz", Akt�elH�z� = 160, Markas� = "BMW"},
                new Araba {�of�rAd� = "Belk�s", Rengi = "Mavi", Akt�elH�z� = 138, Markas� = "Ford"},
                new Araba {�of�rAd� = "Canan", Rengi = "Ye�il", Akt�elH�z� = 95, Markas� = "Wolvo"}
            };
            var arabaSorgusu2 = from araba in arabalar2 where araba.Akt�elH�z� > 90 orderby araba.�of�rAd� descending select araba;
            Console.WriteLine ("-->Akt�elH�z� > 90 azalan ad s�rada:");
            foreach (Araba oto in arabaSorgusu2) Console.WriteLine (oto);
            arabaSorgusu2 = from araba in arabalar2 where araba.Akt�elH�z� > 100 orderby araba.�of�rAd� select araba;
            Console.WriteLine ("-->Akt�elH�z� > 100 aran ad s�rada:");
            foreach (Araba oto in arabaSorgusu2) Console.WriteLine (oto);

            Console.WriteLine ("\nAdlar�n >M ve <=M k�stasl� artan s�ral� se�ili d�k�mleri:");
            string[] adlar = {"Fatma", "Bekir", "Han�m", "Memet", "Hatice", "S�heyla", "Zeliha", "Nihat", "Song�l", "Nedim", "Sevim"};
            IEnumerable<string> adSorgusu = from ad in adlar where (byte)ad[0] > 77 orderby ad select ad;
            Console.Write ("Artan s�ral� ad[0] > \"M\": ");
            foreach (var ad in adSorgusu) Console.Write (ad+" "); Console.WriteLine();
            adSorgusu = from ad in adlar where (byte)ad[0] <= 77 orderby ad select ad;
            Console.Write ("Artan s�ral� ad[0] <= \"M\": ");
            foreach (var ad in adSorgusu) Console.Write (ad+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 20 y�l� ortancadan k���k/b�y�k artan s�ral� se�ili d�kme:");
            int[] y�llar = new int[20]; int i, ts; var r=new Random();
            for(i=0;i<20;i++) {ts=r.Next(1881,1939); y�llar [i]=ts;}
            var y�lSorgusu = from y�l in y�llar where y�l < (1881+1938)/2 orderby y�l select y�l;
            Console.Write ("+S�ral� y�l < 1909: ");
            foreach(var y�l in y�lSorgusu) Console.Write (y�l+" "); Console.WriteLine();
            y�lSorgusu = from y�l in y�llar where y�l >= (1881+1938)/2 orderby y�l descending select y�l;
            Console.Write ("-S�ral� y�l >= 1909: ");
            foreach(var y�l in y�lSorgusu) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("y�lSorgusu'nun tip ad�: [{0}]", y�lSorgusu.GetType().Name);
            Console.WriteLine ("y�lSorgusu'nun tip kurgusu: [{0}]", y�lSorgusu.GetType().Assembly);

            Console.WriteLine ("\nSoysal List<Fihrist> i�inde ad ve ad.Length'e g�re azalan/artan sorgular:");
            List<Fihrist> ki�iler = new List<Fihrist>{
                new Fihrist {Ad = "H�seyin", Soyad = "Kurt", Eposta = "hkurt@gmail.com"},
                new Fihrist {Ad = "Fatih", Soyad = "Kaplan", Eposta = "fkaplan@gmail.com"},
                new Fihrist {Ad = "Selim", Soyad = "Dikel", Eposta = "sdikel@gmail.com"},
                new Fihrist {Ad = "H�lya", Soyad = "Piray", Eposta = "hpiray@gmail.com"},
                new Fihrist {Ad = "�zg�r", Soyad = "Aslan", Eposta = "oaslan@gmail.com"},
                new Fihrist {Ad = "Ali", Soyad = "Eralp", Eposta = "aeralp@gmail.com"},
                new Fihrist {Ad = "�zg�r", Soyad = "�zel", Eposta = "oozel@gmail.com"}
            };
            IEnumerable<Fihrist> ki�iSorgusu = from ki�i in ki�iler where ki�i.Ad == "�zg�r" orderby ki�i.Soyad descending select ki�i;
            Console.WriteLine ("-->Ad == \"�zg�r\" azalan soyad sorgu:");
            foreach (Fihrist ki�i in ki�iSorgusu) Console.WriteLine (ki�i);
            ki�iSorgusu = from ki�i in ki�iler where ki�i.Ad.Length < 6 orderby ki�i.Soyad select ki�i;
            Console.WriteLine ("-->AdLength < 6 artan soyad sorgu:");
            foreach (Fihrist ki�i in ki�iSorgusu) Console.WriteLine (ki�i);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}