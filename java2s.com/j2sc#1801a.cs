// j2sc#1801a.cs: Soysal List<T> ile listeye farklý tip elemanlar ekleme örneði.

using System;
using System.Collections.Generic; //List için
namespace SoysalListe {
    class Soysalsýz {  
        private object nesne;
        public Soysalsýz (object ns) {nesne = ns;} //Kurucu
        public object nesneAl() {return nesne;}  
        public void tipiGöster() {Console.WriteLine ("\tTip (nesne) = " + nesne.GetType());}  
    }
    class SýnýfA {public override string ToString() {return "A sýnýfým";}}
    class Mamül {
        string ad;
        double maliyet;
        int stok;
        public Mamül (string a, double m, int s) {ad = a; maliyet = m; stok = s;}
        public override string ToString() {return String.Format ("{0,-10}Maliyet: {1,8:#,0.00} TL\tStok: {2,3}\tTutar: {3,10:#,0.00} TL", ad, maliyet, stok, maliyet*stok);}
    }
    class Liste {
        static IEnumerable<T> TersTarayýcý<T>(IList<T> liste) {
            int k = liste.Count;
            for(int i = k-1; i >= 0; --i) yield return liste [i];
        }
        static void Main() {
            Console.Write ("Soysal liste deðiþebilen eleman tipli List<T> olarak yaratýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysalsýz sýnýfýn nesnel deðiþkenine farklý tip deðer atama:");
            Soysalsýz snfNsn = new Soysalsýz (20240617);  
            snfNsn.tipiGöster(); 
            int i = (int) snfNsn.nesneAl();  
            Console.WriteLine ("Deðer (nesne) = " + i);
            snfNsn = new Soysalsýz (true);
            snfNsn.tipiGöster();
            bool b = (bool) snfNsn.nesneAl();
            Console.WriteLine ("Deðer (nesne) = " + b);
            snfNsn = new Soysalsýz ("Soysalsýz sýnýfýn farklý tip deðerli 'nesne' deðiþkeni");
            snfNsn.tipiGöster();
            String dizge = (string) snfNsn.nesneAl();
            Console.WriteLine ("Deðer (nesne) = " + dizge);
            snfNsn = new Soysalsýz (DateTime.Now);
            snfNsn.tipiGöster();
            DateTime tarih = (DateTime) snfNsn.nesneAl();
            Console.WriteLine ("Deðer (nesne) = " + tarih);
/*
            Console.WriteLine ("\nSoysal liste tip ve tiplemesi yaratma:");
            string liste = "System.Collections.Generic.List";
            Type listeTipi = Type.GetType (liste);
            Type adlaKapalýTip = Type.GetType (liste + "[System.String]");
            Type tipleKapalýTip = typeof (List<string>);
            Console.WriteLine ("adlaKapalýTip == tipleKapalýTip? {0}", adlaKapalýTip == tipleKapalýTip);
            Type tipleTanýmlýTip = typeof (List<>);
            Console.WriteLine ("listeTipi == tipleTanýmlýTip? {0}", listeTipi == tipleTanýmlýTip);
*/
            Console.WriteLine ("\nSýnýfA tipli 5 liste elemaný kaydetme ve sunma:");
            List<SýnýfA> liste = new List<SýnýfA>();
            for(i=0;i<5;i++) liste.Add (new SýnýfA());
            SýnýfA snfA;
            for(i=0;i<5;i++) {
                snfA = liste [i];
                Console.WriteLine ("Liste [{0}] = {1}", i, snfA);
            }

            Console.WriteLine ("\nListenin [1881,1938] tamsayý elemanlarýný tersten dökümleme:");
            //var r=new Random(); int ts;
            List<int> tsListe = new List<int>();
            for(i=1881;i<=1938;i++) tsListe.Add (i);
            foreach (int yýl in TersTarayýcý (tsListe)) Console.Write (yýl+" ");

            Console.WriteLine ("\n\nListenin [A,Z] ve [a,z] harflerini düz/ters dökümleme:");
            List<char> krkListe = new List<char>();
            Console.WriteLine ("\t==>Listedeki ilk harf sayýsý: " + krkListe.Count);
            Console.WriteLine ("[A,Z] ve [a,z] harfler ekleniyor...");
            for(char k='A';k<='Z';k++) krkListe.Add (k);
            for(char k='a';k<='z';k++) krkListe.Add (k);  
            Console.WriteLine ("\t==>Listedeki harf sayýsý: " + krkListe.Count);
            Console.Write ("A'dan z'ye: "); for(i=0; i < krkListe.Count; i++) Console.Write (krkListe [i]);
            Console.Write ("\nz'den A'ya: "); for(i=1; i <= krkListe.Count; i++) Console.Write (krkListe [krkListe.Count - i]);
            Console.WriteLine ("\n[A,Z] harfler siliniyor...");
            for(char k='A'; k<='Z'; k++) krkListe.Remove (k);
            Console.WriteLine ("\t==>Listedeki harf sayýsý: " + krkListe.Count);
            Console.Write ("a'dan z'ye: "); foreach(char k in krkListe) Console.Write (k);
            Console.WriteLine ("\nX, Y, Z harfler baþtakilerle deðiþtiriliyor...");
            krkListe [0] = 'X'; krkListe [1] = 'Y'; krkListe [2] = 'Z';
            Console.WriteLine ("\t==>Listedeki harf sayýsý: " + krkListe.Count);
            Console.Write ("X'den z'ye: "); foreach(char k in krkListe) Console.Write (k);

            Console.WriteLine ("\n\nListeye ad, fiyat ve stok'lu mamül ekleme ve dökümleme:");
            List<Mamül> envanter = new List<Mamül>();
            envanter.Add (new Mamül ("Kalem", 25.93, 350));
            envanter.Add (new Mamül ("Defter", 78.25, 250));
            envanter.Add (new Mamül ("Silgi", 8.52, 400));
            envanter.Add (new Mamül ("Çanta", 567.98, 80));
            envanter.Add (new Mamül ("Forma", 1235.75, 90));
            Console.WriteLine ("==>Stoktaki mamüllerin yýlsonu envanteri:");
            foreach (Mamül m in envanter) Console.WriteLine (m);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}