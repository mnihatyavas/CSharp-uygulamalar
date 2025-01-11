// j2sc#2204c.cs: Linq.Where()/where sorgu filitresi �rne�i.

using System;
using System.Collections.Generic; //IEnumerable<> i�in
using System.Linq; //Where i�in
namespace Query_Sorgu {
    static class �zelWhere {
        public static IEnumerable<TipKaynak> Where<TipKaynak>(this IEnumerable<TipKaynak> kaynak) {
          int Ebat = kaynak.Count<TipKaynak>();
          TipKaynak[] Birimler = new TipKaynak [Ebat];
          Birimler.Initialize();
          int endeks = 0;
          foreach (TipKaynak birim in kaynak) {
             if (birim.ToString().Length > 4) {
                Birimler [endeks] = birim;
                endeks++;
             }
          }
          return Birimler;
       }
    }
    public class ���i {
        public int _y�l;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
    }
    class Maa� {
        int _no;
        int _y�l;
        double _maa�;
        public int MeslekNo {get {return _no;} set {_no = value;}}
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
        public double Maa�� {get {return _maa�;} set {_maa� = value;}}
    }
    class �r�n : IComparable<�r�n> {
        public int �r�nNo {get; set;}
        public string �r�nAd� {get; set;}
        public string Katagori {get; set;}
        public int BirimFiyat {get; set;}
        public int StoktaKalan {get; set;}
        public DateTime Sipari�Tarihi {get; set;}
        public override string ToString() {return String.Format ("�r�n no: {0}, �r�n ad�: {1} , Katagori: {3}", this.�r�nNo, this.�r�nAd�, this.Katagori);}
        int IComparable<�r�n>.CompareTo (�r�n �u) {
            if (�u == null) return 1;
            if (this.�r�nNo > �u.�r�nNo) return 1;
            if (this.�r�nNo < �u.�r�nNo) return -1;
            return 0;
        }
    }
    class Where {
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nNo = 1881, �r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, StoktaKalan = 1500, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1914, �r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, StoktaKalan = 130, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1919, �r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, StoktaKalan = 8, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1920, �r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, StoktaKalan = 10, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1923, �r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, StoktaKalan = 1600, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1930, �r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, StoktaKalan = 0, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1938, �r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, StoktaKalan = 285, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return �r�nListesi;
        }
        static void Main() {
            Console.Write ("Sorguda 'where/.Where()' se�ilmek istenenlerin k�stas filitresidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nPeygamberler dizisini where sorgularla se�me:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Brahman", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> sorgu1a = peygamberler.Where (p => p.StartsWith ("B"));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1a.Count(), "B");
            foreach (string p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1b = peygamberler
                .Where (p => p.Length < 6)
                .Select (p => p);
            Console.Write ("-->{0} adet 'uzn < 6' nebiler: ", sorgu1b.Count());
            foreach (string p in sorgu1b) Console.Write ("{0} ", p); Console.WriteLine();
            IEnumerable<string> sorgu1c = from p in peygamberler
                where p.Length >= 6
                select p;
            Console.Write ("-->{0} adet 'uzn >= 6' nebiler: ", sorgu1c.Count());
            foreach (string p in sorgu1c) Console.Write ("{0} ", p); Console.WriteLine();
            string pey = peygamberler.Where (p => p.StartsWith ("M")).Last();
            Console.Write ("-->{0} adet {1} ilkharfli son nebi: ", 1, "M");
            Console.Write (pey); Console.WriteLine();
            var sorgu1d = peygamberler.Where (p => p.StartsWith ("M")).First();
            Console.Write ("-->{0} adet {1} ilkharfli ilk nebi: ", 1, "M");
            foreach (var p in sorgu1d) Console.Write (p); Console.WriteLine();
            peygamberler [1]="nuh"; peygamberler [peygamberler.Length-1]="zerd��t";
            IEnumerable<string> sorgu1e = peygamberler.Where (p => Char.IsLower (p [0]));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1e.Count(), "k���k");
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1f = peygamberler.Where (p => Char.IsUpper (p [0]));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1f.Count(), "b�y�k");
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            var sorgu1g = from p in peygamberler
                where p.EndsWith ("a")
                select p;
            Console.Write ("-->{0} adet {1} sonharfli nebiler: ", sorgu1g.Count(), "a");
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            var sorgu1h = (from p in peygamberler
                where p [1] == 'u'
                select p).Reverse();
            Console.Write ("-->{0} adet {1} 2.harfli nebiler (ters): ", sorgu1h.Count(), "u");
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<char> sesliler = "ae�io�u�"; char sesli;
            IEnumerator<char> taray�c� = sesliler.GetEnumerator();
            IEnumerable<char> sorgu1i = String.Join (" ", peygamberler);
            while (taray�c�.MoveNext()) {
                sesli = taray�c�.Current;
                sorgu1i = sorgu1i.Where (k => k != sesli);
                Console.Write ("-->{0} harfi silinen nebiler: ", sesli);
                foreach (var p in sorgu1i) Console.Write (p); Console.WriteLine();
            }
            foreach (char ses in "Aae��io�u�") {
                char arac� = ses;
                sorgu1i = sorgu1i.Where (k => k != arac�);
            }
            Console.Write ("-->T�m {0} harfleri silinen nebiler: ", "sesli");
            foreach (var p in sorgu1i) Console.Write (p); Console.WriteLine();
            IEnumerable<char> sorgu1j = from k in string.Join ("", peygamberler) where Char.IsUpper (k) select k;
            Console.Write ("-->Sadece b�y�kharfleri al�nan nebiler: ");
            foreach (var k in sorgu1j) Console.Write (k+" "); Console.WriteLine();
            var sorgu1k = from p in peygamberler
                let endeks = p.Substring (0, 1)
                where Convert.ToChar (endeks) >= 'A'
                orderby endeks
                select new {p, endeks};
            Console.WriteLine ("-->�lk endeks harfle s�ral� {0} adet t�m nebiler: ", sorgu1k.Count());
            foreach (var p in sorgu1k) Console.WriteLine (p);
            var sorgu1l = from p in peygamberler
                where p.Length >= 3
                select p;
            Console.Write ("-->{0} adet 'Uzn>=3' nebiler: ", sorgu1l.Count());
            foreach (var p in sorgu1l) Console.Write (p+" "); Console.WriteLine();
            var sorgu1m = �zelWhere.Where (peygamberler);
            Console.Write ("-->{0} adet 'Uzn > 4' �zel nebiler: ", sorgu1m.Count());
            foreach (var p in sorgu1m) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\n���i-Maa� kay�tlar�na dair sorgular:");
            List<���i> i��iler = new List<���i> {
                new ���i {Y�l = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yava�"},
                new ���i {Y�l = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yava�"},
                new ���i {Y�l = 1931, MeslekNo = 1, Ad = "Han�m", Soyad = "Yava�"},
                new ���i {Y�l = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yava�"},
                new ���i {Y�l = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Ka�ar"},
                new ���i {Y�l = 1953, MeslekNo = 2, Ad = "S�heyla", Soyad = "�zbay"},
                new ���i {Y�l = 1955, MeslekNo = 2, Ad = "Zeliha", Soyad = "Candan"},
                new ���i {Y�l = 1957, MeslekNo = 2, Ad = "M.Nihat", Soyad = "Yava�"},
                new ���i {Y�l = 1959, MeslekNo = 2, Ad = "Song�l", Soyad = "G�kyi�it"},
                new ���i {Y�l = 1961, MeslekNo = 2, Ad = "M.Nedim", Soyad = "Yava�"},
                new ���i {Y�l = 1963, MeslekNo = 2, Ad = "Sevim", Soyad = "Yava�"}
            };
            var sorgu2a = i��iler.Where ((i�, endeks) => i�.Y�l >= endeks+1947).Select (i�=>new{i�.Ad, i�.Soyad, i�.Y�l});
            Console.WriteLine ("-->{0} adet 'Y�l >= endeks+1947' i��iler:", sorgu2a.Count());
            foreach (var i� in sorgu2a) Console.WriteLine (i�);
            var sorgu2b = i��iler.Where ((i�, endeks) => i�.Y�l < endeks+1947).Select (i�=>new{i�.Ad, i�.Soyad, i�.Y�l});
            Console.WriteLine ("-->{0} adet 'Y�l < endeks+1947' y�neticiler:", sorgu2b.Count());
            foreach (var i� in sorgu2b) Console.WriteLine (i�);
            List<Maa�> maa�lar = new List<Maa�> {
                new Maa� {MeslekNo = 1, Y�l = 2024, Maa�� = 1612987.54},
                new Maa� {MeslekNo = 2, Y�l = 2024, Maa�� = 355783.76}
            };
            var sorgu2c = from i� in i��iler
                                where i�.MeslekNo == 1
                                from m in maa�lar
                                where m.MeslekNo == i�.MeslekNo
                                select new {i�.Ad, i�.Soyad, m.Y�l, m.Maa��};
            Console.WriteLine ("-->{0} adet 'Y�netici' y�ll�k maa�lar�:", sorgu2c.Count());
            foreach (var i� in sorgu2c) Console.WriteLine (i�);
            var sorgu2d = from i� in i��iler
                                where i�.MeslekNo == 2
                                from m in maa�lar
                                where m.MeslekNo == i�.MeslekNo
                                select new {i�.Ad, i�.Soyad, m.Y�l, m.Maa��};
            Console.WriteLine ("-->{0} adet '���i' y�ll�k maa�lar�:", sorgu2d.Count());
            foreach (var i� in sorgu2d) Console.WriteLine (i�);

            Console.WriteLine ("\n�r�n fiyat� ve stok miktar�na dair sorgular:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            var sorgu3a =
                from � in �r�nler
                where �.StoktaKalan > 0 && �.BirimFiyat > 400
                select new {�.�r�nAd�, �.BirimFiyat, �.StoktaKalan};
            Console.WriteLine ("-->{0} adet '400TL �st� mevcut' �r�nler:", sorgu3a.Count());
            foreach (var � in sorgu3a) Console.WriteLine (�);
            var sorgu3b =
                from � in �r�nler
                where �.StoktaKalan <= 10
                select new {�.�r�nAd�, �.BirimFiyat, �.StoktaKalan};
            Console.WriteLine ("-->{0} adet '10 adetten az' �r�nler:", sorgu3b.Count());
            foreach (var � in sorgu3b) Console.WriteLine (�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}