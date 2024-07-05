// j2sc#1801a.cs: Soysal List<T> ile listeye farkl� tip elemanlar ekleme �rne�i.

using System;
using System.Collections.Generic; //List i�in
namespace SoysalListe {
    class Soysals�z {  
        private object nesne;
        public Soysals�z (object ns) {nesne = ns;} //Kurucu
        public object nesneAl() {return nesne;}  
        public void tipiG�ster() {Console.WriteLine ("\tTip (nesne) = " + nesne.GetType());}  
    }
    class S�n�fA {public override string ToString() {return "A s�n�f�m";}}
    class Mam�l {
        string ad;
        double maliyet;
        int stok;
        public Mam�l (string a, double m, int s) {ad = a; maliyet = m; stok = s;}
        public override string ToString() {return String.Format ("{0,-10}Maliyet: {1,8:#,0.00} TL\tStok: {2,3}\tTutar: {3,10:#,0.00} TL", ad, maliyet, stok, maliyet*stok);}
    }
    class Liste {
        static IEnumerable<T> TersTaray�c�<T>(IList<T> liste) {
            int k = liste.Count;
            for(int i = k-1; i >= 0; --i) yield return liste [i];
        }
        static void Main() {
            Console.Write ("Soysal liste de�i�ebilen eleman tipli List<T> olarak yarat�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysals�z s�n�f�n nesnel de�i�kenine farkl� tip de�er atama:");
            Soysals�z snfNsn = new Soysals�z (20240617);  
            snfNsn.tipiG�ster(); 
            int i = (int) snfNsn.nesneAl();  
            Console.WriteLine ("De�er (nesne) = " + i);
            snfNsn = new Soysals�z (true);
            snfNsn.tipiG�ster();
            bool b = (bool) snfNsn.nesneAl();
            Console.WriteLine ("De�er (nesne) = " + b);
            snfNsn = new Soysals�z ("Soysals�z s�n�f�n farkl� tip de�erli 'nesne' de�i�keni");
            snfNsn.tipiG�ster();
            String dizge = (string) snfNsn.nesneAl();
            Console.WriteLine ("De�er (nesne) = " + dizge);
            snfNsn = new Soysals�z (DateTime.Now);
            snfNsn.tipiG�ster();
            DateTime tarih = (DateTime) snfNsn.nesneAl();
            Console.WriteLine ("De�er (nesne) = " + tarih);
/*
            Console.WriteLine ("\nSoysal liste tip ve tiplemesi yaratma:");
            string liste = "System.Collections.Generic.List";
            Type listeTipi = Type.GetType (liste);
            Type adlaKapal�Tip = Type.GetType (liste + "[System.String]");
            Type tipleKapal�Tip = typeof (List<string>);
            Console.WriteLine ("adlaKapal�Tip == tipleKapal�Tip? {0}", adlaKapal�Tip == tipleKapal�Tip);
            Type tipleTan�ml�Tip = typeof (List<>);
            Console.WriteLine ("listeTipi == tipleTan�ml�Tip? {0}", listeTipi == tipleTan�ml�Tip);
*/
            Console.WriteLine ("\nS�n�fA tipli 5 liste eleman� kaydetme ve sunma:");
            List<S�n�fA> liste = new List<S�n�fA>();
            for(i=0;i<5;i++) liste.Add (new S�n�fA());
            S�n�fA snfA;
            for(i=0;i<5;i++) {
                snfA = liste [i];
                Console.WriteLine ("Liste [{0}] = {1}", i, snfA);
            }

            Console.WriteLine ("\nListenin [1881,1938] tamsay� elemanlar�n� tersten d�k�mleme:");
            //var r=new Random(); int ts;
            List<int> tsListe = new List<int>();
            for(i=1881;i<=1938;i++) tsListe.Add (i);
            foreach (int y�l in TersTaray�c� (tsListe)) Console.Write (y�l+" ");

            Console.WriteLine ("\n\nListenin [A,Z] ve [a,z] harflerini d�z/ters d�k�mleme:");
            List<char> krkListe = new List<char>();
            Console.WriteLine ("\t==>Listedeki ilk harf say�s�: " + krkListe.Count);
            Console.WriteLine ("[A,Z] ve [a,z] harfler ekleniyor...");
            for(char k='A';k<='Z';k++) krkListe.Add (k);
            for(char k='a';k<='z';k++) krkListe.Add (k);  
            Console.WriteLine ("\t==>Listedeki harf say�s�: " + krkListe.Count);
            Console.Write ("A'dan z'ye: "); for(i=0; i < krkListe.Count; i++) Console.Write (krkListe [i]);
            Console.Write ("\nz'den A'ya: "); for(i=1; i <= krkListe.Count; i++) Console.Write (krkListe [krkListe.Count - i]);
            Console.WriteLine ("\n[A,Z] harfler siliniyor...");
            for(char k='A'; k<='Z'; k++) krkListe.Remove (k);
            Console.WriteLine ("\t==>Listedeki harf say�s�: " + krkListe.Count);
            Console.Write ("a'dan z'ye: "); foreach(char k in krkListe) Console.Write (k);
            Console.WriteLine ("\nX, Y, Z harfler ba�takilerle de�i�tiriliyor...");
            krkListe [0] = 'X'; krkListe [1] = 'Y'; krkListe [2] = 'Z';
            Console.WriteLine ("\t==>Listedeki harf say�s�: " + krkListe.Count);
            Console.Write ("X'den z'ye: "); foreach(char k in krkListe) Console.Write (k);

            Console.WriteLine ("\n\nListeye ad, fiyat ve stok'lu mam�l ekleme ve d�k�mleme:");
            List<Mam�l> envanter = new List<Mam�l>();
            envanter.Add (new Mam�l ("Kalem", 25.93, 350));
            envanter.Add (new Mam�l ("Defter", 78.25, 250));
            envanter.Add (new Mam�l ("Silgi", 8.52, 400));
            envanter.Add (new Mam�l ("�anta", 567.98, 80));
            envanter.Add (new Mam�l ("Forma", 1235.75, 90));
            Console.WriteLine ("==>Stoktaki mam�llerin y�lsonu envanteri:");
            foreach (Mam�l m in envanter) Console.WriteLine (m);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}