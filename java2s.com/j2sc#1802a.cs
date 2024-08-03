// j2sc#1802a.cs: IEnumerator<T> ve IEnumerable<T> ile taramalar �rne�i.

using System;
using System.Collections.Generic; //IEnumerable<T> i�in
using System.Collections; //IEnumerator i�in
namespace SoysalD�k�mleyici {
    class SoysalS�n�f<T> {
        T[] dizi;
        public SoysalS�n�f (T[] d) {dizi = d;} //Kurucu
        public IEnumerator<T> GetEnumerator() {foreach(T ns in dizi) yield return ns;}
    }
    class DizgeTaray�c� : IEnumerator<string> {
        string[] dizgeler;
        int konum = -1;
        public string Current {get {return dizgeler [konum];}}
        object IEnumerator.Current {get {return dizgeler [konum];}}
        public bool MoveNext() {
            if (konum < dizgeler.Length - 1) {konum++; return true;}
            else return false;
        }
        public void Reset() {konum = -1;}
        public void Dispose() {}
        public DizgeTaray�c� (string[] Dizgeler) {//Kurucu
            dizgeler = new string [Dizgeler.Length];
            for (int i = 0; i < Dizgeler.Length; i++) dizgeler [i] = Dizgeler [i];
        }
    }
    class DizgelerS�n�f� : IEnumerable<string> {
        string[] dizgeler = {"Hatice Yava� Ka�ar", "S�heyla Yava� �zbay", "Zeliha Yava� Candan", "Song�l Yava� G�kyi�it", "Sevim Yava�"};
        public IEnumerator<string> GetEnumerator() {return new DizgeTaray�c� (dizgeler);}
        IEnumerator IEnumerable.GetEnumerator() {return new DizgeTaray�c� (dizgeler);}
    }
    public class KapS�n�f�<T> : IEnumerable<T> {
        private List<T> liste = new List<T>();
        public void Ekle (T kay�t) {liste.Add (kay�t);}
        public void Ekle<R> (KapS�n�f�<R> kap2, Converter<R, T> �evirici) {foreach (R kay�t in kap2) {liste.Add (�evirici (kay�t));}}
        public IEnumerator<T> GetEnumerator() {foreach(T kay�t in liste) {yield return kay�t;}}
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class SoysalTaray�c� {
        static long int_long (int i) {return i;}
        static void Main() {
            Console.Write ("Ebeveyn IEnumerator'un zorunlu tan�mlar�: Current, MoveNext(), Reset() ve Dispose()'dur. Taramal� kullan�mlar�: 'IEnumerator<T> GetEnumerator(){foreach...}' ve 'IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}' �eklindedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IEnumerable<T> taranabilir ve IEnumerator<T> taray�c� ile d�k�mleme:");
            IEnumerable<string> taranabilir = new string[] {"Zafer Candan", "Y�cel K���kbay", "Atilla G�kt�rk", "Sevim Yava�", "Fatih �zbay"};
            int i=0;
            foreach (string ad in taranabilir) Console.WriteLine ("{0}.isim: {1}", ++i, ad);
            IEnumerator<string> taray�c� = taranabilir.GetEnumerator();
            i=0; while (taray�c�.MoveNext()) {Console.WriteLine ("\t{0}.isim: {1}", ++i, taray�c�.Current);}

            Console.WriteLine ("\nSoysalS�n�f<T>'nin tipli dizisin IEnumerator'la tarama:");
            int[] y�llar=new int [1938-1881+1];
            for(i=1881;i<=1938;i++) y�llar [i-1881]=i;
            SoysalS�n�f<int> ss1 = new SoysalS�n�f<int> (y�llar);
            Console.Write ("Tamsay� y�llar: ");
            foreach(int x in ss1) Console.Write (x + " "); Console.WriteLine();
            string[] adlar = new string [1938-1919+1];
            for(i=1919;i<=1938;i++) adlar [i-1919]="Atat�rk-"+i;
            SoysalS�n�f<string> ss2 = new SoysalS�n�f<string> (adlar);
            Console.Write ("Dizge y�llar: ");
            foreach(string x in ss2) Console.Write (x + " "); Console.WriteLine();

            Console.WriteLine ("\n'IEnumerator<T> GetEnumerator(){}' ve 'IEnumerator IEnumerable.GetEnumerator(){}':");
            DizgelerS�n�f� ds = new DizgelerS�n�f�();
            i=0; foreach (string ad in ds) Console.WriteLine ("{0}.k�zkarde�: {1}", ++i, ad);

            Console.WriteLine ("\nKapS�n�f�<T>'ye int ve long girip, int'den long'a �evirme:");
            KapS�n�f�<long> longKap = new KapS�n�f�<long>();
            KapS�n�f�<int> intKap = new KapS�n�f�<int>();
            longKap.Ekle (long.MaxValue);
            longKap.Ekle (long.MaxValue-1);
            longKap.Ekle (long.MinValue);
            longKap.Ekle (long.MinValue+1);
            intKap.Ekle (int.MaxValue);
            intKap.Ekle (int.MaxValue-1);
            intKap.Ekle (int.MinValue);
            intKap.Ekle (int.MinValue+1);
            longKap.Ekle (intKap, SoysalTaray�c�.int_long);
            foreach(long ls in longKap) Console.WriteLine ("{0,26:#,#}", ls);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}