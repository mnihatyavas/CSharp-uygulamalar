// j2sc#2204e.cs: Dizi.Where().Select() ile sorgulu se�imler �rne�i.

using System;
using System.Linq; //Where i�in
using System.Collections.Generic; //Dictionary<> i�in
namespace Query_Sorgu {
    class Araba {
        public string Ad�;
        public string Rengi;
        public int H�z�;
        public string Markas�;
        public override string ToString() {return string.Format ("Markas�={0}, Rengi={1}, H�z�={2}, Ad�={3}", Markas�, Rengi, H�z�, Ad�);}
    }
    class Select {
        public static bool Filitre (string p) {return p.Length > 4;}
        public static string Peygamber (string p) {return p;}
        static double Kare�ki (double n) {return Math.Pow (n, 2);}
        static double Kare�kibu�uk (double n) {return Math.Pow (n, 2.5);}
        static void Main() {
            Console.Write ("'from a in dizi select a' veya 'dizi.Where(=>).Select(=>)' kal�pl� filitreleme sorgularla se�im yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin �e�itli kriterli se�ilme sorgular�:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Zerd��t", "Buda", "Brahman", "Konfi�yus"};
            Console.Write ("-->T�m {0} adet artan s�ral� peygamberler: ", peygamberler.Length);
            foreach (var p in peygamberler) Console.Write (p+" "); Console.WriteLine();
            var sorgu1a = (String.Join (" ", peygamberler)).Where (k => Char.IsLetter (k)).Count();
            Console.WriteLine ("-->T�m peygamberlerin harf say�s�: " + sorgu1a);
            var sorgu1b = (String.Join (" ", peygamberler)).Where (k => !Char.IsLetter (k)).Count();
            Console.WriteLine ("-->T�m peygamberler adlar� aras�ndaki bo�luklar�n say�s�: " + sorgu1b);
            var sorgu1c = from p in peygamberler
                select new {B�y�k = p.ToUpper(), K���k = p.ToLower()};
            Console.WriteLine ("-->T�m {0} adet peygamberlerin b�y�k&k���k-harflisi: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.WriteLine (p);
            Func<string, bool> filitrele = new Func<string, bool>(Filitre);
            Func<string, string> nebi = new Func<string,string>(Peygamber);
            var sorgu1d = peygamberler.Where (filitrele).OrderBy (nebi).Select (nebi);
            Console.Write ("-->{0} adet 'uzn > 4' peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            Dictionary<int, string> peygamberS�zl��� = new Dictionary<int, string>();
            int i; for(i=0;i<peygamberler.Length;i++) peygamberS�zl���.Add (10*i+peygamberler [i].Length, peygamberler [i]);
            var sorgu1e = from birim in peygamberS�zl���
                where (birim.Key % 2) == 0
                select new {birim.Key, birim.Value};
            Console.Write ("-->{0} adet '�ift uzn' peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            var sorgu1f = from birim in peygamberS�zl���
                where (birim.Key % 2) != 0
                select new {birim.Key, birim.Value};
            Console.Write ("-->{0} adet 'tek uzn' peygamberler: ", sorgu1f.Count());
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            List<string> peyListe = new List<string>();
            for(i=0;i<peygamberler.Length;i++) peyListe.Add (i+":"+peygamberler [i]+"("+peygamberler [i].Length+")");
            var sorgu1g = peyListe.Where ((p, e) => e%2 == 0).Select (p=>p);
            Console.Write ("-->{0} adet '�ift endeksli' peygamberler(Length): ", sorgu1g.Count());
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            var sorgu1h = peyListe.Where ((p, e) => e%2 != 0).Select (p=>p);
            Console.Write ("-->{0} adet 'tek endeksli' peygamberler(Length): ", sorgu1h.Count());
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nOrijinal dizi de�i�ikli�i, aynen kullan�lan sorgular� etkiler:");
            int[] tsDizi = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var sorgu2a = from n in tsDizi select Kare�ki (n);
            Console.Write ("-->{0} adet 1-->10 kareleri: ", sorgu2a.Count());
            foreach (var n in sorgu2a) Console.Write (n+" "); Console.WriteLine();
            var sorgu2b = from n in tsDizi select Kare�kibu�uk (n);
            Console.Write ("-->{0} adet 1-->10 n**2.5: ", sorgu2b.Count());
            foreach (var n in sorgu2b) Console.Write ("{0:0.00} ", n); Console.WriteLine();
            for (i = 0; i < tsDizi.Length; i++) tsDizi [i] +=100; //De�i�iklik aynen sorgulara da yans�r
            Console.Write ("-->{0} adet 100+(1-->10) kareleri: ", sorgu2a.Count());
            foreach (var n in sorgu2a) Console.Write (n+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 100+(1-->10) n**2.5: ", sorgu2b.Count());
            foreach (var n in sorgu2b) Console.Write ("{0:0.00} ", n); Console.WriteLine();

            Console.WriteLine ("\nArabalar s�n�fl� diziyle tam ve istenen alanl� listeler:");
            Araba[] arabalar = new [] {
                new Araba {Ad� = "Beng�", Rengi = "G�m��", H�z� = 180, Markas� = "BMW"},
                new Araba {Ad� = "Ven�s", Rengi = "Siyah", H�z� = 155, Markas� = "VW"},
                new Araba {Ad� = "Ferda", Rengi = "Beyaz", H�z� = 173, Markas� = "Ford"}
            };
            var sorgu3a = from a in arabalar select a;
            Console.WriteLine ("-->T�m {0} adet arabalar�n listesi-1:", sorgu3a.Count());
            foreach(var a in sorgu3a) Console.WriteLine (a);
            var sorgu3b = from a in arabalar select a.Rengi+"i "+a.Ad�+" "+a.Markas�;
            Console.WriteLine ("-->T�m {0} adet arabalar�n listesi-2:", sorgu3b.Count());
            foreach(var a in sorgu3b) Console.WriteLine (a);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}