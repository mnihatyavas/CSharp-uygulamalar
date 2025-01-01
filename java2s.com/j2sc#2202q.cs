// j2sc#2202q.cs: Enumerable.Repeat/Where/Empty, uzantý, filitre örneði.

using System;
using System.Linq; //Enumerable için
using System.Collections.Generic; //IEnumerable<> için
using System.Diagnostics; //Process için
using System.Collections; //ArrayList için
namespace LinqMetot {
    public static class UzantýlýSýnýf {
        public static string BoþluðaAltçizgi (this string tümce) {
            char[] krkDizi = tümce.ToCharArray();
            string sonuç = "";
            foreach (char krk in krkDizi) {
                if (Char.IsWhiteSpace (krk)) sonuç += "_";
                else sonuç += krk;
            }
            return sonuç;
        }
    }
    class Sýnýf1 {}
    class Sýnýf2 {public void Metot1 (string dz) {Console.WriteLine ("Sýnýf2.Metot1");}}
    class Sýnýf3 {public void Metot1 (object ns, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", "Sýnýf3", ns, i);}}
    class Sýnýf4 {public void Metot1 (object ns, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", "Sýnýf4", ns, i);}}
    class LapTop {
        public Int32 No {get; set;}
        public Int64 Bellek {get; set;}
        public String Ad {get; set;}
    }
    public class Ýþçi {
        public int yýl;
        public string ad;
        public string soyad;
        public static List<Ýþçi> ÝþçiListesiniAl() {
            List<Ýþçi> liste = new List<Ýþçi>();
            liste.Add (new Ýþçi {yýl = 1891, ad = "Fatma", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1899, ad = "Bekir", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1931, ad = "Haným", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1934, ad = "Memet", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1951, ad = "Hatice", soyad = "Kaçar"});
            liste.Add (new Ýþçi {yýl = 1953, ad = "Süheyla", soyad = "Özbay"});
            liste.Add (new Ýþçi {yýl = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new Ýþçi {yýl = 1957, ad = "M.Nihat", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1959, ad = "Songül", soyad = "Gökyiðit"});
            liste.Add (new Ýþçi {yýl = 1961, ad = "M.Nedim", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1963, ad = "Sevim", soyad = "Yavaþ"});
            return (liste);
        }
    }
    public delegate bool IntFilitreMi (int i);
    static class Enumerable_Filitre {//Uzantýlý metot sýnýfý "static" olmalýdýr
        public static long TemeleÇevrim (this int i, int çevrimTemeli) {
            if (çevrimTemeli < 2 || çevrimTemeli > 10) throw new ArgumentException ("Verili " + i + " sayýsý " + çevrimTemeli + " temeline çevrilemez");
            long sonuç = 0;
            int onüstü = 0, kalan;
            do {kalan = i % çevrimTemeli;
                sonuç += kalan * (long)Math.Pow (10, onüstü);
                onüstü++;
                i /= çevrimTemeli;
            } while (i != 0);
            return sonuç;
        }
        static public void Metot1 (this object ns1, object ns2, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", ns1, ns2, i);}
        public static bool TekMi (int i) {return ((i & 1) == 1);} //Tek ise true'la
        public static bool ÇiftMi (int i) {return (i%2 == 0);} //Çift ise true'la
        public static int[] YýllarýFilitrele (int[] yýllar, IntFilitreMi yýlMý) {
            ArrayList aListe = new ArrayList();
            foreach (int y in yýllar) {if (yýlMý (y)) aListe.Add (y);} //Seçileni aListe'ye ekle
            return ((int[])aListe.ToArray (typeof (int))); //aListe'yi "Ýnt[] dizi"ye çevir
        }
        static void Main() {
            Console.Write ("'Enumerable.Repeat(n,m)' n sayýsýný m kez aynen tekrarlar. Nokta uzantýlý deðer.Metot(arg2), static sýnýfta olmalý, tanýmý: Metot(this type deðer, type prm2) olmalýdýr. Where(filitre) filitresi anlýk lambda ifadeyle yada harici delegelenmeyle süzgeçlenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Enumerable.Repeat(yýl, adet) ile adet kere tekrarlanan yýllar:");
            var yýllar1 = Enumerable.Repeat (1919, 10);
            Console.Write ("-->{0}'u {1} kez tekrarla: ", 1919, 10);
            foreach (var yýl in yýllar1) Console.Write (yýl+" "); Console.WriteLine();
            IEnumerable<int> yýllar2 = Enumerable.Repeat (1923, 10);
            Console.Write ("-->{0}'u {1} kez tekrarla: ", 1923, 10);
            foreach (var yýl in yýllar2) Console.Write (yýl+" "); Console.WriteLine();

            Console.WriteLine ("\nEnumerable.Where/OrderByDescending/Select(þart) ile þartlý peygamberler:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> filitreli = Enumerable.Where (peygamberler, p => p.Contains ("u"));
            IEnumerable<string> sýralý = Enumerable.OrderByDescending (filitreli, p => p.Length);
            IEnumerable<string> büyükharfli = Enumerable.Select (sýralý, p => p.ToUpper());
            Console.Write ("-->{0} adet tüm peygamberler: ", peygamberler.Length);
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' içeren peygamberler: ", filitreli.Count());
            foreach (string pey in filitreli) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' içeren ve kýsalan peygamberler: ", sýralý.Count());
            foreach (string pey in sýralý) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' içeren ve kýsalan büyükharfli peygamberler: ", büyükharfli.Count());
            foreach (string pey in büyükharfli) Console.Write (pey+" "); Console.WriteLine();

            Console.WriteLine ("\nEnumerable.Empty<>() tipli elemansýz boþ taranabilen:");
            IEnumerable<string> dizgeler = Enumerable.Empty<string>();
            Console.WriteLine ("-->{0} adet tüm 'Enumerable.Empty<string>()' dizgeler: ", dizgeler.Count());
            if (dizgeler.Count() == 0) {Console.WriteLine ("Hiç eleman yok...");
            }else {foreach (string d in dizgeler) Console.WriteLine (d);}
            Console.WriteLine ("Tarayýcý tipi: " + dizgeler.GetType());

            Console.WriteLine ("\nDefaultIfEmpty(mesaj) ile önceki þart saðlanmamýþsa mesaj döndürülür:");
            Console.WriteLine ("'{0}' harfiyle baþlayan ilk peygamber: {1}", "M", peygamberler.Where (p => p.StartsWith("M")).DefaultIfEmpty ("NAMEVCUT").First());
            Console.WriteLine ("'{0}' harfiyle baþlayan son peygamber: {1}", "M", peygamberler.Where (p => p.StartsWith("M")).DefaultIfEmpty ("NAMEVCUT").Last());
            Console.WriteLine ("'{0}' harfiyle baþlayan ilk peygamber: {1}", "Þ", peygamberler.Where (p => p.StartsWith("Þ")).DefaultIfEmpty ("NAMEVCUT").First());
            string buda = peygamberler.Where (p => p.Equals ("Buda")).First();
            if (buda != null) Console.WriteLine ("{0} peygamber dizide MEVCUT", "Buda");
            else  Console.WriteLine ("{0} peygamber dizide NAMEVCUT", "Buda");
            Console.Write ("{0} peygamber: ", "Budala"); try {Console.Write (peygamberler.Where (p => p.Equals ("Budala")).First()!=null?"MEVCUT":"");}catch {Console.Write ("NAMEVCUT");} Console.WriteLine();

            Console.WriteLine ("\nNokta uzantýlý metotun ön deðeri ts-->(this int i) içindir:");
            var r=new Random(); int ts=r.Next(1881,1938), i; ts*=ts;
            for (i = 1; i <= 11; i++) {
                try {Console.WriteLine ("10 tabanlý {0} sayýsýnýn {1} tabanlý karþýlýðý: {2}", ts, i, ts.TemeleÇevrim (i));
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            }

            Console.WriteLine ("\nKelime arasý boþluklarý altçizgileyen nokta uzantýlý metot:");
            string dzg = "M. Nihat Yavaþ,  Toroslar / Mersin,   TR";
            Console.WriteLine ("Orijinal: [{0}]\nBoþluk altçizgili: [{1}]", dzg, dzg.BoþluðaAltçizgi());

            Console.WriteLine ("\nSýnýf1 ve Sýnýf2 yetersiz argümanla, uzantýlý Main.Metot1'i kullanýr:");
            ts=r.Next(1881,1938); new Sýnýf1().Metot1 (ts, 20241210); // Extensions.Metot1 is called
            ts=r.Next(1881,1938); new Sýnýf2().Metot1 (ts, 20241210); // Extensions.Metot1 is called
            ts=r.Next(1881,1938); new Sýnýf3().Metot1 (ts, 20241210); // Sýnýf3.Metot1 is called
            ts=r.Next(1881,1938); new Sýnýf4().Metot1 (ts, 20241210); // Sýnýf4.Metot1 is called

            Console.WriteLine ("\nUzantýlý Process.GetProcesses() hazýr metotla bellekteki süreçler:");
            var süreçler = new List<LapTop>();
            foreach (var süreç in Process.GetProcesses()) süreçler.Add (new LapTop {No = süreç.Id, Ad = süreç.ProcessName, Bellek = süreç.WorkingSet64});
            foreach (var süreç in süreçler) Console.WriteLine ("Süreç no = {0}\tBellek = {1,9} Byte\tAdý = {2}", süreç.No, süreç.Bellek, süreç.Ad);

            Console.WriteLine ("\nTüm iþçilerden þartlý<bool> filitreli seçilenler:");
            List<Ýþçi> iþçiler = Ýþçi.ÝþçiListesiniAl();
            Console.WriteLine ("-->Tüm {0} adet iþçiler: ", iþçiler.Count());
            foreach (var iþ in iþçiler) Console.WriteLine ("(isim, dyýl) = ({0} {1}, {2})", iþ.ad, iþ.soyad, iþ.yýl);
            Func<Ýþçi, bool> filitre = delegate (Ýþçi iþ) {return iþ.yýl >= 1957 & iþ.yýl <= 1961;};
            var sorgu1 = iþçiler
                    .Where (filitre)
                    .Select (iþ => new {iþ.ad, iþ.soyad, iþ.yýl});
            Console.WriteLine ("-->{0} adet filitreli (yýl >= 1957 & yýl <= 1961) iþçiler: ", sorgu1.Count());
            foreach (var iþ in sorgu1) Console.WriteLine ("(isim, dyýl) = ({0} {1}, {2})", iþ.ad, iþ.soyad, iþ.yýl);
            var sorgu2 = iþçiler
                    .Where (iþ=>iþ.soyad=="Yavaþ")
                    .OrderBy (iþ=>iþ.ad)
                    .Select (iþ => new {iþ.ad, iþ.soyad, iþ.yýl});
            Console.WriteLine ("-->{0} adet þartlý (iþ.soyad=='Yavaþ') ad'la A-Z sýralý iþçiler: ", sorgu2.Count());
            foreach (var iþ in sorgu2) Console.WriteLine ("(isim, dyýl) = ({0} {1}, {2})", iþ.ad, iþ.soyad, iþ.yýl);
            var sorgu3 = iþçiler
                    .Where (iþ=>iþ.soyad=="Yavaþ")
                    .OrderBy (iþ=>iþ.yýl)
                    .Select (iþ => new {iþ.ad, iþ.soyad, iþ.yýl});
            Console.WriteLine ("-->{0} adet þartlý (iþ.soyad=='Yavaþ') yýl'la 0-9 sýralý iþçiler: ", sorgu3.Count());
            foreach (var iþ in sorgu3) Console.WriteLine ("(isim, dyýl) = ({0} {1}, {2})", iþ.ad, iþ.soyad, iþ.yýl);

            Console.WriteLine ("\n[1881,1938] yýldizi'si tek/çift-yýldizi'ye filitrelenip sunulur:");
            int[] yýllar3 = new int[58]; for(i=0;i<yýllar3.Length;i++) yýllar3 [i]=i+1881;
            Console.Write ("-->Tüm {0} adet yýllar: ", yýllar3.Length);
            foreach (int y in yýllar3) Console.Write (y+" "); Console.WriteLine();
            int[] tekYýllar = YýllarýFilitrele (yýllar3, TekMi);
            Console.Write ("-->{0} adet TEK yýllar: ", tekYýllar.Length);
            foreach (int y in tekYýllar) Console.Write (y+" "); Console.WriteLine();
            int[] çiftYýllar = YýllarýFilitrele (yýllar3, ÇiftMi);
            Console.Write ("-->{0} adet ÇÝFT yýllar: ", çiftYýllar.Length);
            foreach (int y in çiftYýllar) Console.Write (y+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}