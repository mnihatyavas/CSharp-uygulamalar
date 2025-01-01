// j2sc#2202e.cs: ��eren Linq-->dizi.Contains() ve ortalama dizi.Average() �rne�i.

using System;
using System.Linq; //Contains() i�in
using System.Collections.Generic; //IEqualityComparer<>, List<> i�in
namespace LinqMetot {
    public class S�n�fA : IEqualityComparer<string> {
        public bool Equals (string x, string y) {return (Int32.Parse (x) == Int32.Parse (y));}
        public int GetHashCode (string obj) {return 20241114;}
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
    class Maa� {
        int _no, _y�l;
        double _maa�;
        public int No {get {return _no;} set {_no = value;}}
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
        public double Maa�� {get {return _maa�;} set {_maa� = value;}}
    }
    class ���i {
        int _no, _bran�;
        string _soyad, _ad;
        public int No {get {return _no;} set {_no = value;}}
        public int Bran�� {get {return _bran�;} set {_bran� = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
/*  class Bran� {
        int _no;
        string rol;
        public int No {get {return _no;} set {_no = value;}}
        public string Rol {get {return rol;} set {rol = value;}}
    }
*/
    class Contains_Average {
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasiye", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasiye", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasiye", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasiye", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 3265, Sipari�Adedi = 120, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 3278, Sipari�Adedi = 85, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            return �r�nListesi;
        }
        static void Main() {
            Console.Write ("��eriyorsa 'dizi.Contains(arg)' true d�nd�r�r. Double 'dizi.Average()' say�sal elemanlar�n ortalamas�n� d�nd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Linq-Contains bool tip olup, dizide aranan haizse 'true' d�nd�r�r:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            bool haiz = peygamberler.Contains ("Buda"); Console.WriteLine ("peygamberler.Contains(\"Buda\")? {0}", haiz?"Evet":"Hay�r");
            haiz = peygamberler.Contains ("Budala"); Console.WriteLine ("peygamberler.Contains(\"Budala\")? {0}", haiz?"Evet":"Hay�r");

            Console.WriteLine ("\n'dizi.Contains(arg, k�yas)' i�in �zel k�yaslama kullan�labilir:");
            string[] y�lDizge = new string[30];
            int i, ts; var r=new Random();
            for(i=0;i<30;i++) {ts=r.Next(1881,1939); y�lDizge [i]="00" + ts.ToString();}
            ts=r.Next(1881,1939);
            Array.Sort (y�lDizge);
            Console.Write ("Rasgele dizgesel-y�llar: "); foreach(var y�l in y�lDizge) Console.Write (y�l+" "); Console.WriteLine();
            haiz=y�lDizge.Contains (ts.ToString(), new S�n�fA());
            Console.WriteLine ("'{0}' y�lDizge dizisinde mevcut mu? {1}", ts, haiz?"Mevcut":"Namevcut");

            Console.WriteLine ("\nBelirtilen harfe haiz, azalan uzunlukta sorgu kelimeleri:");
            IEnumerable<string> adSorgusu =
                from ad in peygamberler
                where ad.Contains ("u")
                orderby ad.Length descending
                select ad.ToUpper();
            Console.Write ("Sorgu adlar� i�inde 'u' bulunanlar: "); foreach (var ad in adSorgusu) Console.Write (ad + "  ");

            Console.WriteLine ("\nVerili say�sal dizilerin Linq-->Average ile ortalamalar�:");
            double ortalama1 = y�lDizge.Average (y�l => Int32.Parse (y�l));
            Console.WriteLine ("-->�nceki y�lDizge[30]'nin ortalamas�: " + ortalama1);
            IEnumerable<int> tsKapsam = Enumerable.Range (1881, 58);
            Console.Write ("-->Range (1881, 58): "); foreach (int n in tsKapsam) Console.Write (n+" "); Console.WriteLine();
            ortalama1 = tsKapsam.Average();
            Console.WriteLine ("tsKapsam(1881,58)'in ortalamas�: " + ortalama1);
            var y�lSorgu = from n in tsKapsam where n > 1919 select n;
            Console.Write ("-->y�lSorgu where n > 1919: "); foreach (int n in y�lSorgu) Console.Write (n+" "); Console.WriteLine();
            ortalama1 = y�lSorgu.Average();
            Console.WriteLine ("y�lSorgu'nun ortalamas�: " + ortalama1);
            tsKapsam = Enumerable.Range (-2024, 2024+2024);
            Console.WriteLine ("tsKapsam(-2024,4048)'in ortalamas�: " + tsKapsam.Average());
            ortalama1 = peygamberler.Average (pey => pey.Length);
            Console.WriteLine ("-->�nceki peygamberler[{0}] kelime uzunluklar� ortalamas�: {1} harf.", peygamberler.Length, ortalama1);

            Console.WriteLine ("\n�r�n kategori gruplar�n�n fiyat ortalamalar�:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            var katagoriSorgu =
                from �rn in �r�nler
                group �rn by �rn.Katagori into grup
                select new {Katagori = grup.Key, OrtalamaFiyat = grup.Average (�r => �r.BirimFiyat)};
            foreach(var kat in katagoriSorgu) Console.WriteLine (kat);

            Console.WriteLine ("\nBran�� 3=Vardiya'l� y�ll�k maa�lar�n ortalamas�:");
            List<���i> i��iler = new List<���i> {
                new ���i {No = 1951, Bran�� = 1, Soyad = "Ka�ar", Ad = "Hatice"},
                new ���i {No = 1953, Bran�� = 3, Soyad = "�zbay", Ad = "S�heyla"},
                new ���i {No = 1955, Bran�� = 2, Soyad = "Candan", Ad = "Zeliha"},
                new ���i {No = 1957, Bran�� = 3, Soyad = "Yava�", Ad = "M.Nihat"},
                new ���i {No = 1959, Bran�� = 3, Soyad = "G�kyi�it", Ad = "Song�l"},
                new ���i {No = 1961, Bran�� = 2, Soyad = "Yava�", Ad = "M.Nedim"},
                new ���i {No = 1963, Bran�� = 1, Soyad = "Yava�", Ad = "Sevim"}
            };
/*          List<Bran�> roller = new List<Bran�> {
                new Bran� {No = 1, Rol = "Y�netim"},
                new Bran� {No = 2, Rol = "Muhasebe"},
                new Bran� {No = 3, Rol = "Vardiya"}
            };
*/
            List<Maa�> maa�lar = new List<Maa�> {
                new Maa� {No = 1951, Y�l = 2024, Maa�� = 120675.87},
                new Maa� {No = 1953, Y�l = 2024, Maa�� = 105302.15},
                new Maa� {No = 1955, Y�l = 2024, Maa�� = 118765.54},
                new Maa� {No = 1957, Y�l = 2024, Maa�� = 165674.43},
                new Maa� {No = 1959, Y�l = 2024, Maa�� = 218765.43},
                new Maa� {No = 1961, Y�l = 2024, Maa�� = 146734.17},
                new Maa� {No = 1963, Y�l = 2024, Maa�� = 215458.98}
            };
            var bran�Maa�Sorgu = from i� in i��iler
                    join m� in maa�lar on i�.No equals m�.No
                    where i�.Bran�� == 3
                    select m�.Maa��;
            foreach(var se� in bran�Maa�Sorgu) Console.WriteLine ("Maa� = {0,14:#,0.00} TL", se�);
            Console.WriteLine ("Ortalama = {0:#,0.00} TL", bran�Maa�Sorgu.Average());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}