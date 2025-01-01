// j2sc#2203a.cs: Taranabilirlerin ToArray<T> array-dizi'ye d�n���m� �rne�i.

using System;
using System.Linq; //OfType() i�in
using System.Collections.Generic; //List<> i�in
namespace To_D�n���mler {
    class Ki�i {
        int _dy�l;
        string _soyad;
        string _ad;
        public int Dy�l {get {return _dy�l;} set {_dy�l = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    class Araba {
        public string Ad�;
        public string Rengi;
        public int H�z�;
        public string Markas�;
        public override string ToString() {return string.Format ("Markas�={0}, Rengi={1}, H�z�={2}, Ad�={3}", Markas�, Rengi, H�z�, Ad�);}
    }
    class ToArray {
        static void Main() {
            Console.Write ("'dizi.OfType<T>().ToArray()' veya 'Linq.sorgu.ToArray()' ile taranabilirler array diziye d�n��t�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'peygamberler.ToArray()' ve 'Linq.sorgu.ToList()' d�n���mleri:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            string[] inisiyeler = peygamberler.OfType<string>().ToArray();
            Console.Write ("-->T�m {0} adet peygamberler array'i: ", inisiyeler.Length);
            foreach (string ad in inisiyeler) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("peygamberler.GetType(): {0}\tinisiyeler.GetType(): {1}", peygamberler.GetType(), inisiyeler.GetType());
            var liste1 = (from p in peygamberler orderby p select p).ToList();
            Console.Write ("-->T�m {0} adet A->Z ARTAN s�ral� peygamberler listesi: ", liste1.Count());
            foreach (var p in liste1) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 'dbDizi.ToArray()' azalan ve artan d�n���mleri:");
            int i; double ds; var r=new Random();
            double[] dbDizi = new double[10];
            for(i=0;i<dbDizi.Length;i++) {ds=r.Next(1881,1939)+r.Next(1,10000)/10000d; dbDizi [i]=ds;}
            Console.Write ("-->T�m {0} adet rasgele double say�lar: ", dbDizi.Length);
            foreach (double d in dbDizi) Console.Write (d+" "); Console.WriteLine();
            var array1 = (from d in dbDizi orderby d descending select d).ToArray();
            Console.Write ("-->T�m {0} adet rasgele double 9->0 AZALAN say�lar: ", array1.Length);
            foreach (double d in array1) Console.Write (d+" "); Console.WriteLine();
            Console.Write ("-->T�m {0} adet rasgele double 0->9 ARTAN say�lar: ", array1.Length);
            for(i=array1.Length-1;i>=0;i--) Console.Write (array1 [i]+" "); Console.WriteLine();

            Console.WriteLine ("\nList<Ki�i> listesinden y�l ve soyad'la se�ili ToArray() d�n���mler:");
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
            var array2 = ki�iler
                .Where (k => k.Dy�l >= 1951)
                .Select (k => new {k.Ad, k.Soyad, k.Dy�l})
                .OrderBy (k => k.Ad).ToArray();
            Console.WriteLine ("-->T�m {0} adet ad(A->Z ARTAN) 'Dy�l>=1951' �artl� ki�iler array'i: ", array2.Length);
            foreach (var k in array2) Console.WriteLine (k);
            var array3 = ki�iler
                .Where (k => k.Soyad != "Yava�")
                .Select (k => new {k.Ad, k.Soyad, k.Dy�l})
                .OrderByDescending (k => k.Soyad).ToArray();
            Console.WriteLine ("-->T�m {0} adet soyad(Z->A AZALAN) 'Soyad!=Yava�' �artl� ki�iler array'i: ", array3.Length);
            foreach (var k in array3) Console.WriteLine (k);

            Console.WriteLine ("\nArabalar dizisi h�z �artl� sorguyla ToArray<Araba>()'ya d�n��mektedir:");
            Araba[] arabalar = new [] {
                new Araba {Ad� = "Beng�", Rengi = "G�m��", H�z� = 180, Markas� = "BMW"},
                new Araba {Ad� = "Ven�s", Rengi = "Siyah", H�z� = 155, Markas� = "VW"},
                new Araba {Ad� = "Ferda", Rengi = "Beyaz", H�z� = 173, Markas� = "Ford"}
            };
            var array4 = (from a in arabalar where a.H�z� < 180 select a).ToArray<Araba>();
            Console.WriteLine ("-->T�m {0} adet 'a.H�z�<180' �artl� arabalar array'i: ", array4.Length);
            foreach (var a in array4)  Console.WriteLine (a);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}