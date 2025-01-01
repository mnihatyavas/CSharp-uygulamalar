// j2sc#2202q.cs: Enumerable.Repeat/Where/Empty, uzant�, filitre �rne�i.

using System;
using System.Linq; //Enumerable i�in
using System.Collections.Generic; //IEnumerable<> i�in
using System.Diagnostics; //Process i�in
using System.Collections; //ArrayList i�in
namespace LinqMetot {
    public static class Uzant�l�S�n�f {
        public static string Bo�lu�aAlt�izgi (this string t�mce) {
            char[] krkDizi = t�mce.ToCharArray();
            string sonu� = "";
            foreach (char krk in krkDizi) {
                if (Char.IsWhiteSpace (krk)) sonu� += "_";
                else sonu� += krk;
            }
            return sonu�;
        }
    }
    class S�n�f1 {}
    class S�n�f2 {public void Metot1 (string dz) {Console.WriteLine ("S�n�f2.Metot1");}}
    class S�n�f3 {public void Metot1 (object ns, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", "S�n�f3", ns, i);}}
    class S�n�f4 {public void Metot1 (object ns, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", "S�n�f4", ns, i);}}
    class LapTop {
        public Int32 No {get; set;}
        public Int64 Bellek {get; set;}
        public String Ad {get; set;}
    }
    public class ���i {
        public int y�l;
        public string ad;
        public string soyad;
        public static List<���i> ���iListesiniAl() {
            List<���i> liste = new List<���i>();
            liste.Add (new ���i {y�l = 1891, ad = "Fatma", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1899, ad = "Bekir", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1931, ad = "Han�m", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1934, ad = "Memet", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1951, ad = "Hatice", soyad = "Ka�ar"});
            liste.Add (new ���i {y�l = 1953, ad = "S�heyla", soyad = "�zbay"});
            liste.Add (new ���i {y�l = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new ���i {y�l = 1957, ad = "M.Nihat", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1959, ad = "Song�l", soyad = "G�kyi�it"});
            liste.Add (new ���i {y�l = 1961, ad = "M.Nedim", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1963, ad = "Sevim", soyad = "Yava�"});
            return (liste);
        }
    }
    public delegate bool IntFilitreMi (int i);
    static class Enumerable_Filitre {//Uzant�l� metot s�n�f� "static" olmal�d�r
        public static long Temele�evrim (this int i, int �evrimTemeli) {
            if (�evrimTemeli < 2 || �evrimTemeli > 10) throw new ArgumentException ("Verili " + i + " say�s� " + �evrimTemeli + " temeline �evrilemez");
            long sonu� = 0;
            int on�st� = 0, kalan;
            do {kalan = i % �evrimTemeli;
                sonu� += kalan * (long)Math.Pow (10, on�st�);
                on�st�++;
                i /= �evrimTemeli;
            } while (i != 0);
            return sonu�;
        }
        static public void Metot1 (this object ns1, object ns2, int i) {Console.WriteLine ("{0}.Metot1 ({1}, {2})", ns1, ns2, i);}
        public static bool TekMi (int i) {return ((i & 1) == 1);} //Tek ise true'la
        public static bool �iftMi (int i) {return (i%2 == 0);} //�ift ise true'la
        public static int[] Y�llar�Filitrele (int[] y�llar, IntFilitreMi y�lM�) {
            ArrayList aListe = new ArrayList();
            foreach (int y in y�llar) {if (y�lM� (y)) aListe.Add (y);} //Se�ileni aListe'ye ekle
            return ((int[])aListe.ToArray (typeof (int))); //aListe'yi "�nt[] dizi"ye �evir
        }
        static void Main() {
            Console.Write ("'Enumerable.Repeat(n,m)' n say�s�n� m kez aynen tekrarlar. Nokta uzant�l� de�er.Metot(arg2), static s�n�fta olmal�, tan�m�: Metot(this type de�er, type prm2) olmal�d�r. Where(filitre) filitresi anl�k lambda ifadeyle yada harici delegelenmeyle s�zge�lenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Enumerable.Repeat(y�l, adet) ile adet kere tekrarlanan y�llar:");
            var y�llar1 = Enumerable.Repeat (1919, 10);
            Console.Write ("-->{0}'u {1} kez tekrarla: ", 1919, 10);
            foreach (var y�l in y�llar1) Console.Write (y�l+" "); Console.WriteLine();
            IEnumerable<int> y�llar2 = Enumerable.Repeat (1923, 10);
            Console.Write ("-->{0}'u {1} kez tekrarla: ", 1923, 10);
            foreach (var y�l in y�llar2) Console.Write (y�l+" "); Console.WriteLine();

            Console.WriteLine ("\nEnumerable.Where/OrderByDescending/Select(�art) ile �artl� peygamberler:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> filitreli = Enumerable.Where (peygamberler, p => p.Contains ("u"));
            IEnumerable<string> s�ral� = Enumerable.OrderByDescending (filitreli, p => p.Length);
            IEnumerable<string> b�y�kharfli = Enumerable.Select (s�ral�, p => p.ToUpper());
            Console.Write ("-->{0} adet t�m peygamberler: ", peygamberler.Length);
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' i�eren peygamberler: ", filitreli.Count());
            foreach (string pey in filitreli) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' i�eren ve k�salan peygamberler: ", s�ral�.Count());
            foreach (string pey in s�ral�) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->{0} adet 'u' i�eren ve k�salan b�y�kharfli peygamberler: ", b�y�kharfli.Count());
            foreach (string pey in b�y�kharfli) Console.Write (pey+" "); Console.WriteLine();

            Console.WriteLine ("\nEnumerable.Empty<>() tipli elemans�z bo� taranabilen:");
            IEnumerable<string> dizgeler = Enumerable.Empty<string>();
            Console.WriteLine ("-->{0} adet t�m 'Enumerable.Empty<string>()' dizgeler: ", dizgeler.Count());
            if (dizgeler.Count() == 0) {Console.WriteLine ("Hi� eleman yok...");
            }else {foreach (string d in dizgeler) Console.WriteLine (d);}
            Console.WriteLine ("Taray�c� tipi: " + dizgeler.GetType());

            Console.WriteLine ("\nDefaultIfEmpty(mesaj) ile �nceki �art sa�lanmam��sa mesaj d�nd�r�l�r:");
            Console.WriteLine ("'{0}' harfiyle ba�layan ilk peygamber: {1}", "M", peygamberler.Where (p => p.StartsWith("M")).DefaultIfEmpty ("NAMEVCUT").First());
            Console.WriteLine ("'{0}' harfiyle ba�layan son peygamber: {1}", "M", peygamberler.Where (p => p.StartsWith("M")).DefaultIfEmpty ("NAMEVCUT").Last());
            Console.WriteLine ("'{0}' harfiyle ba�layan ilk peygamber: {1}", "�", peygamberler.Where (p => p.StartsWith("�")).DefaultIfEmpty ("NAMEVCUT").First());
            string buda = peygamberler.Where (p => p.Equals ("Buda")).First();
            if (buda != null) Console.WriteLine ("{0} peygamber dizide MEVCUT", "Buda");
            else  Console.WriteLine ("{0} peygamber dizide NAMEVCUT", "Buda");
            Console.Write ("{0} peygamber: ", "Budala"); try {Console.Write (peygamberler.Where (p => p.Equals ("Budala")).First()!=null?"MEVCUT":"");}catch {Console.Write ("NAMEVCUT");} Console.WriteLine();

            Console.WriteLine ("\nNokta uzant�l� metotun �n de�eri ts-->(this int i) i�indir:");
            var r=new Random(); int ts=r.Next(1881,1938), i; ts*=ts;
            for (i = 1; i <= 11; i++) {
                try {Console.WriteLine ("10 tabanl� {0} say�s�n�n {1} tabanl� kar��l���: {2}", ts, i, ts.Temele�evrim (i));
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            }

            Console.WriteLine ("\nKelime aras� bo�luklar� alt�izgileyen nokta uzant�l� metot:");
            string dzg = "M. Nihat Yava�,  Toroslar / Mersin,   TR";
            Console.WriteLine ("Orijinal: [{0}]\nBo�luk alt�izgili: [{1}]", dzg, dzg.Bo�lu�aAlt�izgi());

            Console.WriteLine ("\nS�n�f1 ve S�n�f2 yetersiz arg�manla, uzant�l� Main.Metot1'i kullan�r:");
            ts=r.Next(1881,1938); new S�n�f1().Metot1 (ts, 20241210); // Extensions.Metot1 is called
            ts=r.Next(1881,1938); new S�n�f2().Metot1 (ts, 20241210); // Extensions.Metot1 is called
            ts=r.Next(1881,1938); new S�n�f3().Metot1 (ts, 20241210); // S�n�f3.Metot1 is called
            ts=r.Next(1881,1938); new S�n�f4().Metot1 (ts, 20241210); // S�n�f4.Metot1 is called

            Console.WriteLine ("\nUzant�l� Process.GetProcesses() haz�r metotla bellekteki s�re�ler:");
            var s�re�ler = new List<LapTop>();
            foreach (var s�re� in Process.GetProcesses()) s�re�ler.Add (new LapTop {No = s�re�.Id, Ad = s�re�.ProcessName, Bellek = s�re�.WorkingSet64});
            foreach (var s�re� in s�re�ler) Console.WriteLine ("S�re� no = {0}\tBellek = {1,9} Byte\tAd� = {2}", s�re�.No, s�re�.Bellek, s�re�.Ad);

            Console.WriteLine ("\nT�m i��ilerden �artl�<bool> filitreli se�ilenler:");
            List<���i> i��iler = ���i.���iListesiniAl();
            Console.WriteLine ("-->T�m {0} adet i��iler: ", i��iler.Count());
            foreach (var i� in i��iler) Console.WriteLine ("(isim, dy�l) = ({0} {1}, {2})", i�.ad, i�.soyad, i�.y�l);
            Func<���i, bool> filitre = delegate (���i i�) {return i�.y�l >= 1957 & i�.y�l <= 1961;};
            var sorgu1 = i��iler
                    .Where (filitre)
                    .Select (i� => new {i�.ad, i�.soyad, i�.y�l});
            Console.WriteLine ("-->{0} adet filitreli (y�l >= 1957 & y�l <= 1961) i��iler: ", sorgu1.Count());
            foreach (var i� in sorgu1) Console.WriteLine ("(isim, dy�l) = ({0} {1}, {2})", i�.ad, i�.soyad, i�.y�l);
            var sorgu2 = i��iler
                    .Where (i�=>i�.soyad=="Yava�")
                    .OrderBy (i�=>i�.ad)
                    .Select (i� => new {i�.ad, i�.soyad, i�.y�l});
            Console.WriteLine ("-->{0} adet �artl� (i�.soyad=='Yava�') ad'la A-Z s�ral� i��iler: ", sorgu2.Count());
            foreach (var i� in sorgu2) Console.WriteLine ("(isim, dy�l) = ({0} {1}, {2})", i�.ad, i�.soyad, i�.y�l);
            var sorgu3 = i��iler
                    .Where (i�=>i�.soyad=="Yava�")
                    .OrderBy (i�=>i�.y�l)
                    .Select (i� => new {i�.ad, i�.soyad, i�.y�l});
            Console.WriteLine ("-->{0} adet �artl� (i�.soyad=='Yava�') y�l'la 0-9 s�ral� i��iler: ", sorgu3.Count());
            foreach (var i� in sorgu3) Console.WriteLine ("(isim, dy�l) = ({0} {1}, {2})", i�.ad, i�.soyad, i�.y�l);

            Console.WriteLine ("\n[1881,1938] y�ldizi'si tek/�ift-y�ldizi'ye filitrelenip sunulur:");
            int[] y�llar3 = new int[58]; for(i=0;i<y�llar3.Length;i++) y�llar3 [i]=i+1881;
            Console.Write ("-->T�m {0} adet y�llar: ", y�llar3.Length);
            foreach (int y in y�llar3) Console.Write (y+" "); Console.WriteLine();
            int[] tekY�llar = Y�llar�Filitrele (y�llar3, TekMi);
            Console.Write ("-->{0} adet TEK y�llar: ", tekY�llar.Length);
            foreach (int y in tekY�llar) Console.Write (y+" "); Console.WriteLine();
            int[] �iftY�llar = Y�llar�Filitrele (y�llar3, �iftMi);
            Console.Write ("-->{0} adet ��FT y�llar: ", �iftY�llar.Length);
            foreach (int y in �iftY�llar) Console.Write (y+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}