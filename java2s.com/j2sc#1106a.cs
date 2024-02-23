// j2sc#1106a.cs: List<T> ve select-from ile listeleri süzgeçleme/sýralama örneði.

using System;
using System.Collections.Generic; // List<T> için
using System.Collections.ObjectModel; // ReadOnlyCollection<T> için
using System.Text; //StringBuilder için
using System.Linq; //from-select için
namespace VeriYapýlarý {
    public static class VektörDelegeleri {
        public static int Kýyasla (Vektör x, Vektör y) {
            if (x.Yç > y.Yç) {return 1;
            }else if (x.Yç < y.Yç) {return -1;}
            return 0;
        }
        public static bool ÜstSaðÇeyrekMi (Vektör vektör) {
            if (vektör.Açý >= 0.0 && vektör.Açý <= 90.0) {return true;
            }else {return false;}
        }
    }
    public class Vektörler : List<Vektör> {
        public Vektörler() {} //Kurucu-1
        public Vektörler (IEnumerable<Vektör> vektörler) {//Kurucu-2
            foreach (Vektör vektör in vektörler) {Add (vektör);}
        }
        public string Toplam() {
            StringBuilder sb = new StringBuilder();
            Vektör aktüelNokta = new Vektör (0.0, 0.0);
            sb.Append ("==>(0.0, 0.0)");
            foreach (Vektör vektör in this) {
                sb.AppendFormat (" + {0}", vektör);
                aktüelNokta += vektör;
            }
            sb.AppendFormat (" = {0}", aktüelNokta);
            return sb.ToString();
        }
    }
    public class Vektör {
        public double? Yç = null;
        public double? Açý = null;
        public double? RadyanAçý {get {return (Açý * Math.PI / 180.0);}}
        public Vektör (double? y, double? açý) {//Kurucu
            if (y < 0) {y = -y; açý += 180;}
            açý = açý % 360;
            Yç = y;
            Açý = açý;
        }
        public static Vektör operator +(Vektör iþ1, Vektör iþ2) {
            try {
                double yeniX = iþ1.Yç.Value * Math.Sin (iþ1.RadyanAçý.Value) + iþ2.Yç.Value * Math.Sin (iþ2.RadyanAçý.Value);
                double yeniY = iþ1.Yç.Value * Math.Cos (iþ1.RadyanAçý.Value) + iþ2.Yç.Value * Math.Cos (iþ2.RadyanAçý.Value);
                double yeniYç = Math.Sqrt (yeniX * yeniX + yeniY * yeniY);
                double yeniAçý = Math.Atan2 (yeniX, yeniY) * 180.0 / Math.PI;
                return new Vektör (yeniYç, yeniAçý);
            }catch {return new Vektör (null, null);}
        }
/*      //"-yç-->+yç, açý+=180" olduðundan örnekte -operator kullanýlmýyor.
        public static Vektör operator -(Vektör iþ1) {return new Vektör (-iþ1.Yç, iþ1.Açý);}
        public static Vektör operator -(Vektör iþ1, Vektör iþ2) {return iþ1 + (-iþ2);}
*/
        public override string ToString() {
            string yçDzg = Yç.HasValue ? Yç.ToString() : "null";
            string açýDzg = Açý.HasValue ? Açý.ToString() : "null";
            return string.Format ("({0}, {1})", yçDzg, açýDzg);
        }
    }
    public class Ürün {
        string ad;
        decimal fiyat;
        public string Ad {get {return ad;}}
        public decimal Fiyat {get {return fiyat;}}
        public Ürün (string a, decimal f) {ad = a; fiyat = f;} //Kurucu
        public override string ToString() {return string.Format ("{0}={1:#,0.00}TL ", ad, fiyat);}
    }
    class ÜrünadýKýyascý : IComparer<Ürün> {public int Compare (Ürün ü1, Ürün ü2) {return ü2.Ad.CompareTo (ü1.Ad);}}
    class KodluÜrün {
        public string Ad {get; private set;}
        public decimal Fiyat {get; private set;}
        public int ToptancýKodu {get; private set;}
        public KodluÜrün (string a, decimal f) {Ad = a; Fiyat = f;} //Kurucu-1
        KodluÜrün(){} //Kurucu-2
        public static List<KodluÜrün> ÜrünleriAl() {
            return new List<KodluÜrün> {
                new KodluÜrün {Ad="Ca", Fiyat= 9.99m, ToptancýKodu=1},
                new KodluÜrün {Ad="Ab", Fiyat=14.99m, ToptancýKodu=2},
                new KodluÜrün {Ad="Fc", Fiyat=13.99m, ToptancýKodu=1},
                new KodluÜrün {Ad="Sd", Fiyat=10.99m, ToptancýKodu=3},
                new KodluÜrün {Ad="Se", Fiyat=17.99m, ToptancýKodu=4},
                new KodluÜrün {Ad="Kf", Fiyat=11.99m, ToptancýKodu=1},
                new KodluÜrün {Ad="Kf", Fiyat=10.99m, ToptancýKodu=1},
                new KodluÜrün {Ad="Lg", Fiyat=15.99m, ToptancýKodu=5}
            };
        }
        public override string ToString() {return string.Format ("{0}={1}TL ", Ad, Fiyat);}
    }
    class Toptancý {
        public string Ad {get; private set;}
        public int ToptancýKodu {get; private set;}
        Toptancý(){} //Kurucu
        public static List<Toptancý> ToptancýleriAl() {
            return new List<Toptancý> {
                new Toptancý {Ad="Sa", ToptancýKodu=1},
                new Toptancý {Ad="Cb", ToptancýKodu=2},
                new Toptancý {Ad="Bc", ToptancýKodu=3},
                new Toptancý {Ad="De", ToptancýKodu=4}
            };
        }
    }
    class VeriYapýsý6A {
        private static int DizgedenTamsayýya (string liste) {
            int sonuç;
            if (!int.TryParse (liste, out sonuç)) sonuç = -1;
            return sonuç;
        }
        public static List<Ürün> ÜrünleriAl() {
            int i, j, ts; decimal m; string a; var r=new Random();
            List<Ürün> liste = new List<Ürün>();
            for(i=0;i<10;i++) {
               a=""; for(j=0;j<5;j++) {ts=r.Next(0,26); a+=(char)(ts+65);}
               m=r.Next(10,1500)+r.Next(10,100)/100M;
               liste.Add (new Ürün (a, m));
            }
            return liste;
        }
        static void Main() {
            Console.Write ("List<Sýnýf> ile her çeþit (vektör, ürün, iþgören vb) sýnýf/yapý liste elemaný olabilmektedir. Linq-->from-select filitresiyle þartý saðlayan liste elemanlarý alt-listeye dönüþebilmektedir. Liste<T>.OrderBy/orderby ile select-from veya foreach-liste istenilen tek/çok anahtarla sýralanabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Önce List<T> ve delegesi, sonra kopyasý ReadOnlyCollection<T> liste sunumlarý:");
            int i, ts1; var r=new Random();
            List<int> lst1 = new List<int>();
            for(i=0;i<18;i++) {ts1=r.Next(-100,1000); lst1.Add (ts1);}
            for(i=0;i<lst1.Count;i++) Console.Write (lst1 [i] + " "); Console.WriteLine();
            lst1.ForEach (delegate (int x) {Console.Write (x+" "); }); Console.WriteLine();
            ReadOnlyCollection<int> sol1 = lst1.AsReadOnly();
            for(i=0;i<sol1.Count;i++) Console.Write (sol1 [i] + " "); Console.WriteLine();
            Console.WriteLine ("\tListeyi önce dizgeye sonra tekrar tamsayýya çevirme:");
            List<string> lst1a = lst1.ConvertAll<string> (Convert.ToString);
            for(i=0;i<lst1a.Count;i++) Console.Write (lst1a [i] + " "); Console.WriteLine();
            List<int> lst1b = lst1a.ConvertAll<int> (Convert.ToInt32);
            for(i=0;i<lst1b.Count;i++) Console.Write (lst1b [i] + " "); Console.WriteLine();
            List<int> lst1c = lst1a.ConvertAll<int> (DizgedenTamsayýya);
            for(i=0;i<lst1c.Count;i++) Console.Write (lst1c [i] + " "); Console.WriteLine();

            Console.WriteLine ("\n(yç,açý)'lý List<Vektör>'leri normal/sýralý ve ilkçeyrektekileri toplama:");
            double ds1, ds2;
            Vektörler vektörler = new Vektörler();
            for(i=0;i<10;i++) {
                ds1=r.Next(-10,10)+r.Next(10,100)/100D; ds2=r.Next(0,1000)+r.Next(10,100)/100D;
                vektörler.Add (new Vektör (ds1, ds2));
            }
            Console.WriteLine (vektörler.Toplam()); //Tüm vektörlerin normal toplamý
            Comparison<Vektör> sýralayýcý = new Comparison<Vektör> (VektörDelegeleri.Kýyasla);
            vektörler.Sort (sýralayýcý);
            Console.WriteLine (vektörler.Toplam()); //Tüm vektörlerin yarýçap'la artan sýralý toplamý
            Predicate<Vektör> arayýcý = new Predicate<Vektör> (VektörDelegeleri.ÜstSaðÇeyrekMi);
            Vektörler ilkçeyrekVektörler = new Vektörler (vektörler.FindAll (arayýcý));
             Console.WriteLine (ilkçeyrekVektörler.Toplam());

            Console.WriteLine ("\nTüm ürünlerin ve seçilenlerin ad=fiyat'lý sunumlarý:");
            List<Ürün> ürünler = ÜrünleriAl();
            var seçilenler = from Ürün ü in ürünler
                    where ü.Fiyat > 755
                    select ü;
            Console.Write ("==>Tüm ürünler: "); foreach (Ürün ü in ürünler) Console.Write (ü); Console.WriteLine();
            Console.Write ("==>Ad'la sýralý tüm ürünler: "); foreach (Ürün ü in ürünler.OrderBy (ü => ü.Ad)) Console.Write (ü); Console.WriteLine();
            Console.Write ("==>Fiyat'la sýralý tüm ürünler: "); foreach (Ürün ü in ürünler.OrderBy (ü => ü.Fiyat)) Console.Write (ü); Console.WriteLine();
            Console.Write ("==>Fiyat > 755 ürünler: "); foreach (Ürün ü in seçilenler) Console.Write (ü); Console.WriteLine();
            Console.Write ("==>Ad'la sýralý, fiyat > 755 ürünler: "); foreach (Ürün ü in seçilenler.OrderBy (s => s.Ad)) Console.Write (ü); Console.WriteLine();
            Console.Write ("==>Fiyat'la sýralý, fiyat > 755 ürünler: "); foreach (Ürün ü in seçilenler.OrderBy (s => s.Fiyat)) Console.Write (ü); Console.WriteLine();
            Console.WriteLine ("\tPredicate-filitre ve Action-delege'yle seçilen (fyt>1000) sunma:");
            Predicate<Ürün> test = delegate (Ürün ü) {return ü.Fiyat > 1000m;};
            List<Ürün> uyan = ürünler.FindAll (test);
            Action<Ürün> yaz = delegate (Ürün ü) {Console.Write (ü+" ");};
            uyan.ForEach (yaz); Console.WriteLine();
            Console.WriteLine ("\tDelegeli FindAll ve ForEach'le seçilen (f>500 && f < 1000) sunma:");
            ürünler.FindAll (delegate (Ürün ü) {return ü.Fiyat > 500 && ü.Fiyat < 1000;})
                    .ForEach (delegate (Ürün ü) {Console.Write (ü+" ");}); Console.WriteLine();
            Console.WriteLine ("\tDoðrudn foreach-where ile seçilen (f < 500) sunma:");
            foreach (Ürün ürn in ürünler.Where (ü => ü.Fiyat < 500)) Console.Write (ürn+" "); Console.WriteLine();
            Console.WriteLine ("\tÖzelleþen Sort'la seçilen (f < 1000) azalan sýralý sunma:");
            ürünler.Sort (new ÜrünadýKýyascý());
            foreach (Ürün ü in ürünler.Where (ü => ü.Fiyat < 1000)) Console.Write (ü+" "); Console.WriteLine();
            Console.WriteLine ("\tDelegeli Sort'la seçilen (f < 1000) artan sýralý sunma:");
            ürünler.Sort (delegate (Ürün ü1, Ürün ü2) {return ü1.Ad.CompareTo (ü2.Ad);});
            foreach (Ürün ür in ürünler.Where (ü => ü.Fiyat < 1000)) Console.Write (ür+" "); Console.WriteLine();

            Console.WriteLine ("\nÜrünler ve toptancýlardan fiyat ve kod kriterli seçilenlerin sýralý listesi:");
            List<KodluÜrün> ürünler2 = KodluÜrün.ÜrünleriAl();
            List<Toptancý> tedarikçiler = Toptancý.ToptancýleriAl();
            var seçilenler2 = from ü in ürünler2
                    join t in tedarikçiler
                    on ü.ToptancýKodu equals t.ToptancýKodu
                    where ü.Fiyat > 10
                    orderby t.Ad, ü.Ad, ü.Fiyat //Artan sýralama anahtarlarý: kod+ad+fiyat
                    select new {
                        ToptancýKodu = t.ToptancýKodu,
                        ToptancýAdý = t.Ad,
                        ÜrünAdý = ü.Ad,
                        ÜrünFiyatý = ü.Fiyat
                    };
            foreach (var s in seçilenler2) Console.WriteLine ("ToptancýAdý={0}; ÜrünAdý={1}; TedarikçiKodu={2}; ÜrünFiyatý={3}TL",
                    s.ToptancýAdý, s.ÜrünAdý, s.ToptancýKodu, s.ÜrünFiyatý);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}