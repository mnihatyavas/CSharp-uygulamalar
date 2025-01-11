// j2sc#2204e.cs: Dizi.Where().Select() ile sorgulu seçimler örneði.

using System;
using System.Linq; //Where için
using System.Collections.Generic; //Dictionary<> için
namespace Query_Sorgu {
    class Araba {
        public string Adý;
        public string Rengi;
        public int Hýzý;
        public string Markasý;
        public override string ToString() {return string.Format ("Markasý={0}, Rengi={1}, Hýzý={2}, Adý={3}", Markasý, Rengi, Hýzý, Adý);}
    }
    class Select {
        public static bool Filitre (string p) {return p.Length > 4;}
        public static string Peygamber (string p) {return p;}
        static double KareÝki (double n) {return Math.Pow (n, 2);}
        static double KareÝkibuçuk (double n) {return Math.Pow (n, 2.5);}
        static void Main() {
            Console.Write ("'from a in dizi select a' veya 'dizi.Where(=>).Select(=>)' kalýplý filitreleme sorgularla seçim yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin çeþitli kriterli seçilme sorgularý:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Zerdüþt", "Buda", "Brahman", "Konfiçyus"};
            Console.Write ("-->Tüm {0} adet artan sýralý peygamberler: ", peygamberler.Length);
            foreach (var p in peygamberler) Console.Write (p+" "); Console.WriteLine();
            var sorgu1a = (String.Join (" ", peygamberler)).Where (k => Char.IsLetter (k)).Count();
            Console.WriteLine ("-->Tüm peygamberlerin harf sayýsý: " + sorgu1a);
            var sorgu1b = (String.Join (" ", peygamberler)).Where (k => !Char.IsLetter (k)).Count();
            Console.WriteLine ("-->Tüm peygamberler adlarý arasýndaki boþluklarýn sayýsý: " + sorgu1b);
            var sorgu1c = from p in peygamberler
                select new {Büyük = p.ToUpper(), Küçük = p.ToLower()};
            Console.WriteLine ("-->Tüm {0} adet peygamberlerin büyük&küçük-harflisi: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.WriteLine (p);
            Func<string, bool> filitrele = new Func<string, bool>(Filitre);
            Func<string, string> nebi = new Func<string,string>(Peygamber);
            var sorgu1d = peygamberler.Where (filitrele).OrderBy (nebi).Select (nebi);
            Console.Write ("-->{0} adet 'uzn > 4' peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            Dictionary<int, string> peygamberSözlüðü = new Dictionary<int, string>();
            int i; for(i=0;i<peygamberler.Length;i++) peygamberSözlüðü.Add (10*i+peygamberler [i].Length, peygamberler [i]);
            var sorgu1e = from birim in peygamberSözlüðü
                where (birim.Key % 2) == 0
                select new {birim.Key, birim.Value};
            Console.Write ("-->{0} adet 'çift uzn' peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            var sorgu1f = from birim in peygamberSözlüðü
                where (birim.Key % 2) != 0
                select new {birim.Key, birim.Value};
            Console.Write ("-->{0} adet 'tek uzn' peygamberler: ", sorgu1f.Count());
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            List<string> peyListe = new List<string>();
            for(i=0;i<peygamberler.Length;i++) peyListe.Add (i+":"+peygamberler [i]+"("+peygamberler [i].Length+")");
            var sorgu1g = peyListe.Where ((p, e) => e%2 == 0).Select (p=>p);
            Console.Write ("-->{0} adet 'çift endeksli' peygamberler(Length): ", sorgu1g.Count());
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            var sorgu1h = peyListe.Where ((p, e) => e%2 != 0).Select (p=>p);
            Console.Write ("-->{0} adet 'tek endeksli' peygamberler(Length): ", sorgu1h.Count());
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nOrijinal dizi deðiþikliði, aynen kullanýlan sorgularý etkiler:");
            int[] tsDizi = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var sorgu2a = from n in tsDizi select KareÝki (n);
            Console.Write ("-->{0} adet 1-->10 kareleri: ", sorgu2a.Count());
            foreach (var n in sorgu2a) Console.Write (n+" "); Console.WriteLine();
            var sorgu2b = from n in tsDizi select KareÝkibuçuk (n);
            Console.Write ("-->{0} adet 1-->10 n**2.5: ", sorgu2b.Count());
            foreach (var n in sorgu2b) Console.Write ("{0:0.00} ", n); Console.WriteLine();
            for (i = 0; i < tsDizi.Length; i++) tsDizi [i] +=100; //Deðiþiklik aynen sorgulara da yansýr
            Console.Write ("-->{0} adet 100+(1-->10) kareleri: ", sorgu2a.Count());
            foreach (var n in sorgu2a) Console.Write (n+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 100+(1-->10) n**2.5: ", sorgu2b.Count());
            foreach (var n in sorgu2b) Console.Write ("{0:0.00} ", n); Console.WriteLine();

            Console.WriteLine ("\nArabalar sýnýflý diziyle tam ve istenen alanlý listeler:");
            Araba[] arabalar = new [] {
                new Araba {Adý = "Bengü", Rengi = "Gümüþ", Hýzý = 180, Markasý = "BMW"},
                new Araba {Adý = "Venüs", Rengi = "Siyah", Hýzý = 155, Markasý = "VW"},
                new Araba {Adý = "Ferda", Rengi = "Beyaz", Hýzý = 173, Markasý = "Ford"}
            };
            var sorgu3a = from a in arabalar select a;
            Console.WriteLine ("-->Tüm {0} adet arabalarýn listesi-1:", sorgu3a.Count());
            foreach(var a in sorgu3a) Console.WriteLine (a);
            var sorgu3b = from a in arabalar select a.Rengi+"i "+a.Adý+" "+a.Markasý;
            Console.WriteLine ("-->Tüm {0} adet arabalarýn listesi-2:", sorgu3b.Count());
            foreach(var a in sorgu3b) Console.WriteLine (a);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}