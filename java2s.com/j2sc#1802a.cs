// j2sc#1802a.cs: IEnumerator<T> ve IEnumerable<T> ile taramalar örneði.

using System;
using System.Collections.Generic; //IEnumerable<T> için
using System.Collections; //IEnumerator için
namespace SoysalDökümleyici {
    class SoysalSýnýf<T> {
        T[] dizi;
        public SoysalSýnýf (T[] d) {dizi = d;} //Kurucu
        public IEnumerator<T> GetEnumerator() {foreach(T ns in dizi) yield return ns;}
    }
    class DizgeTarayýcý : IEnumerator<string> {
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
        public DizgeTarayýcý (string[] Dizgeler) {//Kurucu
            dizgeler = new string [Dizgeler.Length];
            for (int i = 0; i < Dizgeler.Length; i++) dizgeler [i] = Dizgeler [i];
        }
    }
    class DizgelerSýnýfý : IEnumerable<string> {
        string[] dizgeler = {"Hatice Yavaþ Kaçar", "Süheyla Yavaþ Özbay", "Zeliha Yavaþ Candan", "Songül Yavaþ Gökyiðit", "Sevim Yavaþ"};
        public IEnumerator<string> GetEnumerator() {return new DizgeTarayýcý (dizgeler);}
        IEnumerator IEnumerable.GetEnumerator() {return new DizgeTarayýcý (dizgeler);}
    }
    public class KapSýnýfý<T> : IEnumerable<T> {
        private List<T> liste = new List<T>();
        public void Ekle (T kayýt) {liste.Add (kayýt);}
        public void Ekle<R> (KapSýnýfý<R> kap2, Converter<R, T> çevirici) {foreach (R kayýt in kap2) {liste.Add (çevirici (kayýt));}}
        public IEnumerator<T> GetEnumerator() {foreach(T kayýt in liste) {yield return kayýt;}}
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class SoysalTarayýcý {
        static long int_long (int i) {return i;}
        static void Main() {
            Console.Write ("Ebeveyn IEnumerator'un zorunlu tanýmlarý: Current, MoveNext(), Reset() ve Dispose()'dur. Taramalý kullanýmlarý: 'IEnumerator<T> GetEnumerator(){foreach...}' ve 'IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}' þeklindedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IEnumerable<T> taranabilir ve IEnumerator<T> tarayýcý ile dökümleme:");
            IEnumerable<string> taranabilir = new string[] {"Zafer Candan", "Yücel Küçükbay", "Atilla Göktürk", "Sevim Yavaþ", "Fatih Özbay"};
            int i=0;
            foreach (string ad in taranabilir) Console.WriteLine ("{0}.isim: {1}", ++i, ad);
            IEnumerator<string> tarayýcý = taranabilir.GetEnumerator();
            i=0; while (tarayýcý.MoveNext()) {Console.WriteLine ("\t{0}.isim: {1}", ++i, tarayýcý.Current);}

            Console.WriteLine ("\nSoysalSýnýf<T>'nin tipli dizisin IEnumerator'la tarama:");
            int[] yýllar=new int [1938-1881+1];
            for(i=1881;i<=1938;i++) yýllar [i-1881]=i;
            SoysalSýnýf<int> ss1 = new SoysalSýnýf<int> (yýllar);
            Console.Write ("Tamsayý yýllar: ");
            foreach(int x in ss1) Console.Write (x + " "); Console.WriteLine();
            string[] adlar = new string [1938-1919+1];
            for(i=1919;i<=1938;i++) adlar [i-1919]="Atatürk-"+i;
            SoysalSýnýf<string> ss2 = new SoysalSýnýf<string> (adlar);
            Console.Write ("Dizge yýllar: ");
            foreach(string x in ss2) Console.Write (x + " "); Console.WriteLine();

            Console.WriteLine ("\n'IEnumerator<T> GetEnumerator(){}' ve 'IEnumerator IEnumerable.GetEnumerator(){}':");
            DizgelerSýnýfý ds = new DizgelerSýnýfý();
            i=0; foreach (string ad in ds) Console.WriteLine ("{0}.kýzkardeþ: {1}", ++i, ad);

            Console.WriteLine ("\nKapSýnýfý<T>'ye int ve long girip, int'den long'a çevirme:");
            KapSýnýfý<long> longKap = new KapSýnýfý<long>();
            KapSýnýfý<int> intKap = new KapSýnýfý<int>();
            longKap.Ekle (long.MaxValue);
            longKap.Ekle (long.MaxValue-1);
            longKap.Ekle (long.MinValue);
            longKap.Ekle (long.MinValue+1);
            intKap.Ekle (int.MaxValue);
            intKap.Ekle (int.MaxValue-1);
            intKap.Ekle (int.MinValue);
            intKap.Ekle (int.MinValue+1);
            longKap.Ekle (intKap, SoysalTarayýcý.int_long);
            foreach(long ls in longKap) Console.WriteLine ("{0,26:#,#}", ls);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}