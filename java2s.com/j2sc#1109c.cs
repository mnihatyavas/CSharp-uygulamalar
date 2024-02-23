// j2sc#1109c.cs: IEnumerable/IEnumerator ve yield-return'la koleksiyonlar üretme örneði.

using System;
using System.Collections; //IEnumerator için
using System.Collections.Generic; //IEnumerator<T> için
using System.Linq; //where...select için
namespace VeriYapýlarý {
    class Sýnýf1 : IEnumerable<string> {
        int i;
        IEnumerator<string> Harf {get {//A-z harfler üreten/yield özellik
            for(i=0;i<26;i++) yield return ((char)('A'+i)).ToString(); yield return "-";
            for(i=0;i<26;i++) yield return ((char)('a'+i)).ToString();
            }
        }
        public IEnumerator<string> GetEnumerator() {return Harf;} //Sýnýf1 tiplemesinin varsayýlý koleksiyonu
        IEnumerator IEnumerable.GetEnumerator() {return null;} //null yerine Harf gerekmez, sadece protokol
    }
    public class Ýþgören {
        public string ad, ünvan;
        public Ýþgören (string a, string ü) {ad = a; ünvan = ü;} //Kurucu
        public override string ToString() {return string.Format ("{0}({1})", ad, ünvan);}
    }
    public class ÝþgListe {
        private List<Ýþgören> iþLs = new List<Ýþgören>();
        public IEnumerator<Ýþgören> GetEnumerator() {foreach (Ýþgören ig in iþLs) yield return ig;} //Varsayýlý GetEnumerator() metodu
        public IEnumerable<Ýþgören> Ters {get {for(int i=iþLs.Count-1;i>=0;i--) yield return iþLs[i];}} //Özellik
        public IEnumerable<Ýþgören> ÝlkBeþ {get {int i=0; foreach (Ýþgören ig in iþLs) {if (i>=4) yield break; else {i++; yield return ig;}}}} //Özellik
        public void ÝþgörenEkle (Ýþgören üye) {iþLs.Add (üye);} //Metot
    }
    class IEnumerableSayacý : IEnumerable<int> {
        int ilk, son;
        public IEnumerableSayacý (int n1, int n2) {ilk=n1-1; son=n2;}
        public IEnumerator<int> GetEnumerator() {return new IEnumeratorSayacý (ilk, son);}
        IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class IEnumeratorSayacý : IEnumerator<int> {
        private int yýl1, yýl2;
        public IEnumeratorSayacý (int n1, int n2) {yýl1=n1; yýl2=n2;}
        public bool MoveNext() {return yýl1++ < yýl2;}
        public int Current {get {return yýl1;}}
        object IEnumerator.Current {get {return Current;}}
        public void Reset() {throw new NotSupportedException();}
        public void Dispose(){}
    }
    class VeriYapýsý9C {
        static public IEnumerable<int> ÝkininÜsleri (int ilk, int son) {for(int i=ilk;i<=son;++i) yield return (int)Math.Pow (2,i);}
        string[] harfler;
        int endeks;
        public VeriYapýsý9C (string[] h, int e) {harfler=h; endeks=e;}
        public IEnumerator GetEnumerator() {
            for(int i=0;i<harfler.Length;i++) yield return harfler [(i + endeks) % harfler.Length];
        }
        static void Main() {
            Console.Write ("IEnumerable/IEnumerator ve yield-return'le standart listeler dýþýnda her tip ve sýralamada koleksiyonlar üretilebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf1 tiplemesinin varsayýlý A-z üretilen koleksiyonu:");
            Sýnýf1 s1 = new Sýnýf1();
            foreach (string hrf in s1) Console.Write ("{0}", hrf); Console.WriteLine();

            Console.WriteLine ("\nVarsayýlý IEnumerator ve IEnumerable'la ÝlkBeþ ile Ters listeler:");
            int i, j, ts1, ts2; string ad, ünvan; var r=new Random();
            ÝþgListe iþgListe = new ÝþgListe();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ünvan=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ünvan+=(char)(97+ts2);}
                iþgListe.ÝþgörenEkle (new Ýþgören (ad, ünvan));
            }
            Console.Write ("\tVarsayýlý IEnumerator: "); foreach (Ýþgören üye in iþgListe) Console.Write (üye.ToString()+" "); Console.WriteLine();
            Console.Write ("\tIEnumerable'la ÝlkBeþ: "); foreach (Ýþgören üye in iþgListe.ÝlkBeþ) Console.Write (üye.ToString()+" "); Console.WriteLine();
            Console.Write ("\tIEnumerable'la Ters: "); foreach (Ýþgören üye in iþgListe.Ters) Console.Write (üye.ToString()+" "); Console.WriteLine();

            Console.WriteLine ("\nIEnumerable'la 2^[ilk,son] 2'nin üslerini üretme:");
            IEnumerable<int> ikininÜsleri = ÝkininÜsleri (0, 30); //int için azamisi 2**30'dur
            i=0; foreach (int sonuç in ikininÜsleri) Console.Write ("2^{0}={1:#,0} ", i++, sonuç); Console.WriteLine();

            Console.WriteLine ("\n100 adet [-1000,1000] rasgele sayý üretip from-select'le süzgeçleme:");
            int[] tsDizi = new int [100];
            for(i=0;i<tsDizi.Length;i++) {ts1=r.Next(-1000,1000); tsDizi [i]=ts1;}
            Console.Write ("\tTüm rasgele sayýlar: "); foreach (int n in tsDizi) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> sýfýrÜstüArtan = from sayýlar in tsDizi where sayýlar >= 0 orderby sayýlar select sayýlar;
            Console.Write ("\tArtan sayýlar >= 0: "); foreach (int n in sýfýrÜstüArtan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> sýfýrAltýAzalan = from sayýlar in tsDizi where sayýlar <= 0 orderby -sayýlar select sayýlar;
            Console.Write ("\tAzalan sayýlar <= 0: "); foreach (int n in sýfýrAltýAzalan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> TümArtan = from sayýlar in tsDizi orderby sayýlar select sayýlar;
            Console.Write ("\tTüm sayýlar artan: "); foreach (int n in TümArtan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> TümAzalan = from sayýlar in tsDizi orderby -sayýlar select sayýlar;
            Console.Write ("\tTüm sayýlar azalan: "); foreach (int n in TümAzalan) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\nHarfleri verili endeks'ten sona ve tekar baþtan endeks'e sýralama:");
            string[] dzgDizi = "a b c ç d e f g ð h ý i j k l m n o ö p r s þ t u ü v y z A B C Ç D E F G Ð H I Ý J K L M N O Ö P R S Þ T U Ü V Y Z q w x Q W X".Split(' ');
            VeriYapýsý9C koleksiyon = new VeriYapýsý9C (dzgDizi, dzgDizi.Length/4);
            Console.Write ("\tEndeks=dzgDizi.Length/4 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            koleksiyon = new VeriYapýsý9C (dzgDizi, dzgDizi.Length/2);
            Console.Write ("\tEndeks=dzgDizi.Length/2 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            koleksiyon = new VeriYapýsý9C (dzgDizi, dzgDizi.Length*3/4);
            Console.Write ("\tEndeks=dzgDizi.Length*3/4 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            ts1=r.Next(0,dzgDizi.Length);
            koleksiyon = new VeriYapýsý9C (dzgDizi, ts1);
            Console.Write ("\tEndeks=rasgele({0})ile sunum: ", ts1); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();

            Console.WriteLine ("\nIEnumerable/IEnumerator sayaçla [ilk,son] arasý sayaç yürütme:");
            IEnumerableSayacý sayaç = new IEnumerableSayacý (1881, 1938);
            Console.Write ("\tYýllar=[1881,1938]: "); foreach (int n in sayaç) Console.Write (n+" "); Console.WriteLine();
            sayaç = new IEnumerableSayacý (1957, 2024);
            Console.Write ("\tYýllar=[1957,2024]: "); foreach (int n in sayaç) Console.Write (n+" "); Console.WriteLine();
            sayaç = new IEnumerableSayacý (2000, 2100);
            Console.Write ("\tYýllar=[1957,2024]: "); foreach (int n in sayaç) Console.Write (n+" "); Console.WriteLine();
            sayaç = new IEnumerableSayacý (-2024, -1957);
            Console.Write ("\tYýllar=[2024,1957] ters: "); foreach (int n in sayaç) Console.Write (-n+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}