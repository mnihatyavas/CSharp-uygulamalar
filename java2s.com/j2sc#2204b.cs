// j2sc#2204b.cs: ��i�e sorgular, nesnel sorgu alanlar�, Split.First/Last �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; //Where i�in
namespace Query_Sorgu {
    public class Hanehalk� {
        public int _y�l;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
    }
    class Rol {
        int _meslekNo;
        string meslek;
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Meslek {get {return meslek;} set {meslek = value;}}
    }
    public class Kitap {
        public String Yazar {get; set;}
        public String Ad {get; set;}
        public override String ToString() {return Yazar+": "+Ad;}
    }
    class Sorgu2 {
        static void Main() {
            Console.Write ("enum.Split().First() bo�luklu ismin ilk ad�n�, enum.Split().Last() sonuncu soyad�n� al�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hanehalk�-->meslekno ile roller-->meslek ili�kili i�i�e sorgu:");
            List<Hanehalk�> hanehalk� = new List<Hanehalk�> {
                new Hanehalk� {Y�l = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1931, MeslekNo = 1, Ad = "Han�m", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Ka�ar"},
                new Hanehalk� {Y�l = 1953, MeslekNo = 2, Ad = "S�heyla", Soyad = "�zbay"},
                new Hanehalk� {Y�l = 1955, MeslekNo = 2, Ad = "Zeliha", Soyad = "Candan"},
                new Hanehalk� {Y�l = 1957, MeslekNo = 2, Ad = "M.Nihat", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1959, MeslekNo = 2, Ad = "Song�l", Soyad = "G�kyi�it"},
                new Hanehalk� {Y�l = 1961, MeslekNo = 2, Ad = "M.Nedim", Soyad = "Yava�"},
                new Hanehalk� {Y�l = 1963, MeslekNo = 2, Ad = "Sevim", Soyad = "Yava�"}
            };
            List<Rol> roller = new List<Rol> {
                new Rol {MeslekNo = 1, Meslek = "Y�netici"},
                new Rol {MeslekNo = 2, Meslek = "��g�ren"}
            };
            var sorgu1a = hanehalk�
                .Where (hh => hh.MeslekNo == 1)
                .SelectMany (hh => roller
                    .Where (r => r.MeslekNo == hh.MeslekNo)
                    .Select (r => new {r.Meslek, hh.Ad, hh.Soyad, hh.Y�l}));
            Console.WriteLine ("-->{0} adet {1} listesi:", sorgu1a.Count(), "Y�netici");
            foreach (var h in sorgu1a) Console.WriteLine (h);
            var sorgu1b = hanehalk�
                .Where (hh => hh.MeslekNo == 2)
                .SelectMany (hh => roller
                    .Where (r => r.MeslekNo == hh.MeslekNo)
                    .Select (r => new {r.Meslek, hh.Ad, hh.Soyad, hh.Y�l}));
            Console.WriteLine ("-->{0} adet {1} listesi:", sorgu1b.Count(), "��g�ren");
            foreach (var h in sorgu1b) Console.WriteLine (h);
            var sorgu1c = from h in hanehalk� select h; //Console.WriteLine (h) object/nesnedir, ya "h.Alan" yada "new {h.Alan}" gerekir
            Console.Write ("-->T�m {0} adet hanehalk� adlar�: ", sorgu1c.Count());
            foreach (var h in sorgu1c) Console.Write (h.Ad+" "); Console.WriteLine();
            var sorgu1d = from h in hanehalk�
                where h.Soyad == "Yava�"
                select h;
            Console.Write ("-->{0} adet soyad='Yava�' hanehalk� adlar�: ", sorgu1d.Count());
            foreach (var h in sorgu1d) Console.Write (h.Ad+" "); Console.WriteLine();
            var sorgu1e = hanehalk�
                .Where (h => h.MeslekNo == 1)
                .Select (h => new {h.Ad, h.Soyad});
            Console.WriteLine ("-->{0} adet meslek='Y�netici' hanehalk� isimleri:", sorgu1e.Count());
            foreach (var h in sorgu1e) Console.WriteLine (h);

            Console.WriteLine ("\nPeygamberler dizisini �e�itli i�i�e IEnumerable<> sorgularla se�me:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> sorgu2a = Enumerable.Select (
                Enumerable.OrderBy (
                    Enumerable.Where (peygamberler, p => p.Contains ("a")
                ), p => p.Length
            ), p => p.ToUpper());
            Console.Write ("-->{0} adet {1} harfi-i�eren ve artan-uzunlukla s�ral�, b�y�kharfli nebiler: ", sorgu2a.Count(), "a");
            foreach (var p in sorgu2a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu2b = Enumerable.Select (
                Enumerable.OrderByDescending (
                    Enumerable.Where (peygamberler, p => p.Contains("u")||p.Contains("�")
                ), p => p.Length
            ), p => p.ToLower());
            Console.Write ("-->{0} adet {1} harfi-i�eren ve azalan-uzunlukla s�ral�, k���kharfli nebiler: ", sorgu2b.Count(), "a|�");
            foreach (var p in sorgu2b) Console.Write (p+" "); Console.WriteLine();
            for(int i=0;i<peygamberler.Length;i++) peygamberler [i] = "Hazreti " + peygamberler [i];
            IEnumerable<string> sorgu2c = peygamberler.OrderBy (p => p.Split().First());
            Console.Write ("-->{0} adet ilk �nvanla s�ral� nebiler: ", sorgu2c.Count());
            foreach (var p in sorgu2c) Console.Write (p.Split().Last()+" "); Console.WriteLine();
            IEnumerable<string> sorgu2d = peygamberler.OrderByDescending (p => p.Split().Last());
            Console.Write ("-->{0} adet son adla azalan s�ral� nebiler: ", sorgu2d.Count());
            foreach (var p in sorgu2d) Console.Write ("\"{0}\" ", p); Console.WriteLine();

            Console.WriteLine ("\nKitap sorgu d�k�m�n� 'new{}' veya 'override String ToString(){}' ile yapma:");
            Kitap[] kitaplar = {
                new Kitap {Yazar="Atat�rk", Ad="Nutuk"},
                new Kitap {Yazar="F.R.Atay", Ad="�ankaya"},
                new Kitap {Yazar="A.M.�nan", Ad="Atat�rk'�n Not Defterler"},
                new Kitap {Yazar="Lord Kinross", Ad="Atat�rk, Bir Milletin Do�u�u"}
            };
            var sorgu3a = kitaplar
                .Where (k => k.Ad.Contains("a")&&k.Ad.Contains("�"))
                .Select (k => new {k.Yazar, k.Ad});
            Console.WriteLine ("-->{0} adet kitapad�({1}) kitap listesi:", sorgu3a.Count(), "a&�");
            foreach (var k in sorgu3a) Console.WriteLine (k);
            var sorgu3b = kitaplar
                .Where (k => k.Ad.Equals ("�ankaya"))
                .Select (k => k);
            Console.WriteLine ("-->{0} adet kitapad�({1}) kitap listesi:", sorgu3b.Count(), "�ankaya");
            foreach (var k in sorgu3b) Console.WriteLine (k);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}