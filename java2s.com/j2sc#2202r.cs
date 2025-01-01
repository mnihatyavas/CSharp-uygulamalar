// j2sc#2202r.cs: Sorgularda endeks, ��kar�m, ilk�rnek ve s�n�rlama �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; //Select i�in
namespace LinqMetot {
    class Ki�i {
        int _dy�l;
        string _soyad;
        string _ad;
        public int Dy�l {get {return _dy�l;} set {_dy�l = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    public class Kitap {
        public String Yazar {get; set;}
        public String Ad {get; set;}
        public override String ToString() {return Yazar+": "+Ad;}
    }
    class Bayii {
        public string No {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro;
        public override string ToString() {return "No: " + No + " �ehir: " + �ehir + " �lke: " + �lke + " K�ta: " + K�ta + " Ciro: " + Ciro;}
    }
    class Endeks {
        static public Kitap[] Kitaplar = {
            new Kitap {Yazar="Atat�rk", Ad="Nutuk"},
            new Kitap {Yazar="F.R.Atay", Ad="�ankaya"},
            new Kitap {Yazar="A.M.�nan", Ad="Atat�rk'�n Not Defterler"},
            new Kitap {Yazar="Lord Kinross", Ad="Atat�rk, Bir Milletin Do�u�u"}
        };
        static void Main() {
            Console.Write ("Sorgu lambda'n�n '(k,endeks)=>' 2.ci parametresi otomatikmen taranan�n endeksidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sorgu lambda'n�n 2.ci parametresi otomatikmen taranan�n endeksidir:");
            List<Ki�i> ki�iler = new List<Ki�i> {
                new Ki�i {Dy�l = 1891, Ad = "Fatma", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1899, Ad = "Bekir", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1931, Ad = "Han�m", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1934, Ad = "Memet", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1951, Ad = "Hatice", Soyad = "Ka�ar"},
                new Ki�i {Dy�l = 1953, Ad = "S�heyla", Soyad = "�zbay"},
                new Ki�i {Dy�l = 1955, Ad = "Zeliha", Soyad = "Candan"},
                new Ki�i {Dy�l = 1957, Ad = "M.Nihat", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1959, Ad = "Song�l", Soyad = "G�kyi�it"},
                new Ki�i {Dy�l = 1961, Ad = "M.Nedim", Soyad = "Yava�"},
                new Ki�i {Dy�l = 1963, Ad = "Sevim", Soyad = "Yava�"}
            };
            var sorgu1 = ki�iler.Select ((k, endeks) => new {Konum = endeks, k.Ad, k.Soyad, k.Dy�l});
            Console.WriteLine ("-->{0} adet ki�iler: ", sorgu1.Count());
            foreach (var k in sorgu1) Console.WriteLine (k);

            Console.WriteLine ("\nPeygamberlerden 'p.Length <= e' �art�n� sa�layanlar� se�me:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.Write ("-->{0} adet t�m peygamberler (uzn, end): ", peygamberler.Length);
            int i; for(i=0;i<peygamberler.Length;i++) Console.Write ("{0}({1},{2}) ", peygamberler [i], peygamberler [i].Length, i); Console.WriteLine();
            Console.WriteLine ("-->'p.Length <= e' �artl� peygamber:");
            //var sorgu2 = peygamberler.Where ((p, e) => p.Length <= e).Select ((p, e) => new {Peygamber = p, Uzunluk = p.Length, Endeks = e});
            for(i=0;i<peygamberler.Length;i++) if(peygamberler [i].Length <= i) Console.WriteLine ("Peygamber={0,-10}\tUzunluk={1}\tEndeks={2}", peygamberler [i], peygamberler [i].Length, i);

            Console.WriteLine ("\nKitaplar� konum-no'lu ve A->Z ad-s�ral� sunma:");
            var kitaplar = Kitaplar
                .Select ((kitap, end) => new {end, kitap.Yazar, kitap.Ad})
                .OrderBy (k => k.Ad);
            Console.WriteLine ("-->{0} adet orijinal endeksli ve ad-s�ral� kitaplar: ", kitaplar.Count());
            foreach (var k in kitaplar) Console.WriteLine (k);

            Console.WriteLine ("\nEldeki mevcut y�llardan sorguyla yeni y�llar ��kar�mlama:");
            var y�llar = Enumerable.Range (2025-58, 58);
            Console.Write ("-->T�m {0} adet y�llar: ", y�llar.Count());
            foreach (var y in y�llar) Console.Write (y+" "); Console.WriteLine();
            var sorgu3 =
                from y�l in y�llar
                select y�l-86;
            Console.Write ("-->Y�llar - 86: ");
            foreach (var y�l in sorgu3) Console.Write (y�l+" "); Console.WriteLine();

            Console.WriteLine ("\nYukardaki ki�iler listesini HAYATTA/M�TEVEFFA �eklinde ��kar�mlama:");
            var sorgu4 = ki�iler.ConvertAll (delegate (Ki�i k) {return new {k.Ad, k.Soyad, k.Dy�l, Ya��yorMu = (k.Dy�l >= 1950)};});
            foreach (var k in sorgu4) Console.WriteLine ("{0}: {1}", k.Ya��yorMu?"HAYATTA":"M�TEVEFFA", k);

            Console.WriteLine ("\nT�m k�ta bayilerinden Asya'dakilerin ��kar�mlanmas�:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", �ehir="Tahran", �lke="�ran", K�ta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("-->T�m k�talardaki {0} adet bayiler: ", bayiler.Count());
            foreach (var b in bayiler) Console.WriteLine (b);
            var sorgu5 =
                from b in bayiler
                where b.K�ta == "Asya"
                select new {b.�ehir, b.�lke, b.Ciro};
            Console.WriteLine ("-->Sadece {0} k�tas�ndaki {1} adet bayiler: ", "Asya", sorgu5.Count());
            foreach (var b in sorgu5) Console.WriteLine (b);

            Console.WriteLine ("\nPeygamber ad, uzunluk ve endeksleriyle sorgular:");
            IEnumerable<string> sorgu6 = peygamberler.Where ((p, e) => (e % 2) == 0);
            Console.Write ("-->�ift endeksli {0} adet peygamberler: ", sorgu6.Count());
            foreach (string pey in sorgu6) Console.Write ("{0} ", pey); Console.WriteLine();
            IEnumerable<string> sorgu7 = peygamberler.Where ((p, e) => (e & 1) == 1);
            Console.Write ("-->Tek endeksli {0} adet peygamberler: ", sorgu7.Count());
            foreach (string pey in sorgu7) Console.Write ("{0} ", pey); Console.WriteLine();
            var sorgu8 = peygamberler.Select ((p,e) => new {p, p.Length, e});
            Console.WriteLine ("-->T�m {0} adet peygamberler, ad-uzunluklar� ve endeksleri: ", sorgu8.Count());
            foreach (var p in sorgu8) Console.WriteLine (p);
            var sorgu9 = peygamberler.Select ((p,e) => new {Ad=p, Uzunluk=p.Length, Konum=e});
            Console.WriteLine ("-->T�m {0} adet a��klamal� peygamberler: ", sorgu9.Count());
            foreach (var p in sorgu9) Console.WriteLine ("Konum={0,2}\tUzunluk={1}\tAd={2}", p.Konum+1, p.Uzunluk, p.Ad);
            var sorgu10 = from p in peygamberler where p.Length <= 5 select p;
            Console.Write ("-->Ad.Length<=5 ile s�n�rl� {0} adet peygamberler: ", sorgu10.Count());
            foreach (var p in sorgu10) Console.Write (p+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}