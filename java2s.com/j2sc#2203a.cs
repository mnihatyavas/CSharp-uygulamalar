// j2sc#2203a.cs: Taranabilirlerin ToArray<T> array-dizi'ye dönüþümü örneði.

using System;
using System.Linq; //OfType() için
using System.Collections.Generic; //List<> için
namespace To_Dönüþümler {
    class Kiþi {
        int _dyýl;
        string _soyad;
        string _ad;
        public int Dyýl {get {return _dyýl;} set {_dyýl = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    class Araba {
        public string Adý;
        public string Rengi;
        public int Hýzý;
        public string Markasý;
        public override string ToString() {return string.Format ("Markasý={0}, Rengi={1}, Hýzý={2}, Adý={3}", Markasý, Rengi, Hýzý, Adý);}
    }
    class ToArray {
        static void Main() {
            Console.Write ("'dizi.OfType<T>().ToArray()' veya 'Linq.sorgu.ToArray()' ile taranabilirler array diziye dönüþtürülür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'peygamberler.ToArray()' ve 'Linq.sorgu.ToList()' dönüþümleri:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            string[] inisiyeler = peygamberler.OfType<string>().ToArray();
            Console.Write ("-->Tüm {0} adet peygamberler array'i: ", inisiyeler.Length);
            foreach (string ad in inisiyeler) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("peygamberler.GetType(): {0}\tinisiyeler.GetType(): {1}", peygamberler.GetType(), inisiyeler.GetType());
            var liste1 = (from p in peygamberler orderby p select p).ToList();
            Console.Write ("-->Tüm {0} adet A->Z ARTAN sýralý peygamberler listesi: ", liste1.Count());
            foreach (var p in liste1) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 'dbDizi.ToArray()' azalan ve artan dönüþümleri:");
            int i; double ds; var r=new Random();
            double[] dbDizi = new double[10];
            for(i=0;i<dbDizi.Length;i++) {ds=r.Next(1881,1939)+r.Next(1,10000)/10000d; dbDizi [i]=ds;}
            Console.Write ("-->Tüm {0} adet rasgele double sayýlar: ", dbDizi.Length);
            foreach (double d in dbDizi) Console.Write (d+" "); Console.WriteLine();
            var array1 = (from d in dbDizi orderby d descending select d).ToArray();
            Console.Write ("-->Tüm {0} adet rasgele double 9->0 AZALAN sayýlar: ", array1.Length);
            foreach (double d in array1) Console.Write (d+" "); Console.WriteLine();
            Console.Write ("-->Tüm {0} adet rasgele double 0->9 ARTAN sayýlar: ", array1.Length);
            for(i=array1.Length-1;i>=0;i--) Console.Write (array1 [i]+" "); Console.WriteLine();

            Console.WriteLine ("\nList<Kiþi> listesinden yýl ve soyad'la seçili ToArray() dönüþümler:");
            List<Kiþi> kiþiler = new List<Kiþi> {
                new Kiþi {Dyýl = 1891, Ad = "Fatma", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1899, Ad = "Bekir", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1931, Ad = "Haným", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1934, Ad = "Memet", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1951, Ad = "Hatice", Soyad = "Kaçar"},
                new Kiþi {Dyýl = 1953, Ad = "Süheyla", Soyad = "Özbay"},
                new Kiþi {Dyýl = 1955, Ad = "Zeliha", Soyad = "Candan"},
                new Kiþi {Dyýl = 1957, Ad = "M.Nihat", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1959, Ad = "Songül", Soyad = "Gökyiðit"},
                new Kiþi {Dyýl = 1961, Ad = "M.Nedim", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1963, Ad = "Sevim", Soyad = "Yavaþ"}
            };
            var array2 = kiþiler
                .Where (k => k.Dyýl >= 1951)
                .Select (k => new {k.Ad, k.Soyad, k.Dyýl})
                .OrderBy (k => k.Ad).ToArray();
            Console.WriteLine ("-->Tüm {0} adet ad(A->Z ARTAN) 'Dyýl>=1951' þartlý kiþiler array'i: ", array2.Length);
            foreach (var k in array2) Console.WriteLine (k);
            var array3 = kiþiler
                .Where (k => k.Soyad != "Yavaþ")
                .Select (k => new {k.Ad, k.Soyad, k.Dyýl})
                .OrderByDescending (k => k.Soyad).ToArray();
            Console.WriteLine ("-->Tüm {0} adet soyad(Z->A AZALAN) 'Soyad!=Yavaþ' þartlý kiþiler array'i: ", array3.Length);
            foreach (var k in array3) Console.WriteLine (k);

            Console.WriteLine ("\nArabalar dizisi hýz þartlý sorguyla ToArray<Araba>()'ya dönüþmektedir:");
            Araba[] arabalar = new [] {
                new Araba {Adý = "Bengü", Rengi = "Gümüþ", Hýzý = 180, Markasý = "BMW"},
                new Araba {Adý = "Venüs", Rengi = "Siyah", Hýzý = 155, Markasý = "VW"},
                new Araba {Adý = "Ferda", Rengi = "Beyaz", Hýzý = 173, Markasý = "Ford"}
            };
            var array4 = (from a in arabalar where a.Hýzý < 180 select a).ToArray<Araba>();
            Console.WriteLine ("-->Tüm {0} adet 'a.Hýzý<180' þartlý arabalar array'i: ", array4.Length);
            foreach (var a in array4)  Console.WriteLine (a);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}