// j2sc#1109d.cs: Özelleþtirilen IEnumerable ve IEnumerator'la dizi/liste tarama örneði.

using System;
using System.Collections; //IEnumerator ve IEnumerable için
using System.Collections.Generic; //IEnumerable<T> ve LinkedList<int> için
namespace VeriYapýlarý {
    class Sýnýf1 { 
        char[] harfler = new char[52];
        public Sýnýf1() {//Parametresiz kurucuyla tiplemede ilkdeðerleme
            for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);
            for(int i=0;i<26;i++) harfler [i+26]=(char)('a'+i);
        }
        //Tiplemeyle varsayýlý koleksiyonu üretme
        public IEnumerator GetEnumerator() {foreach(char hrf in harfler) yield return hrf;}
    }
    class Sýnýf2 {
        char harf;
        public IEnumerator GetEnumerator() {
            harf='A'; for(int i=0;i<26; i++) yield return (char)(harf + i);
            yield return '-';
            harf='a'; for(int i=0;i<26; i++) yield return (char)(harf + i);
        }
    }
    class Sýnýf3 {
        public IEnumerator GetEnumerator() {
            for(int i=0;i<26; i++) yield return (char)('A' + i);
            yield return '-';
            for(int i=0;i<26; i++) yield return (char)('a' + i);
        }
    }
    class Sýnýf4 {
        public IEnumerable Taratýcý (int ilk, int son) {for(int i=ilk;i<=son;i++) yield return i;}
    }
    class Sýnýf5 : IEnumerator, IEnumerable {
        char[] harfler = new char[26];
        int endeks = -1;
        public Sýnýf5() {for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);}
        public Sýnýf5(int n) {
            if (n==0) {for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);}
            else if (n==1) {for(int i=0;i<26;i++) harfler [i]=(char)('a'+25-i);}
            else {for(int i=0;i<26;i++) harfler [i]=(char)0;}
        }
        //IEnumerable yürütümü için
        public IEnumerator GetEnumerator() {return this;}
        //IEnumerator yürütümü için 
        public object Current {get {return harfler [endeks];}}
        public bool MoveNext() {
            if(endeks == harfler.Length-1) {Reset(); return false;}
            endeks++;
            return true;
        }
        public void Reset(){endeks=-1;}
    }
    public class TsListe: IEnumerable {
        int[] tsDizi = new int[10];
        int atanan = 10;
        int sayaç = 0;
        int kontrol = 0;
        public void Ekle (int ts) {
            if (sayaç + 1 > atanan) return;
            tsDizi [sayaç] = ts;
            sayaç++;
            kontrol++;
        }
        public int Sayaç {get {return(sayaç);}}
        void EndeksKontrolu (int endeks) {
            if (endeks >= sayaç) throw new ArgumentOutOfRangeException ("Endeks kapsam dýþý hatasý yaptý...");
        }
        public int this [int endeks] {
            get {EndeksKontrolu (endeks); return(tsDizi [endeks]);}
            set {EndeksKontrolu (endeks); tsDizi [endeks] = value; kontrol++;}
        }
        public IEnumerator GetEnumerator() {return (new TsListeSayýcý (this));}
        internal int Kontrol {get {return(kontrol);}}
    }
    class TsListeSayýcý: IEnumerator {
        TsListe tsListe;
        int kontrol;
        int endeks;
        internal TsListeSayýcý (TsListe tsListe) {this.tsListe = tsListe; Reset();}
        public bool MoveNext() {
            endeks++;
            if (endeks >= tsListe.Sayaç) return(false);
            else return(true);
        }
        public object Current {
            get {
                if (kontrol != tsListe.Kontrol) 
                    try {throw new InvalidOperationException ("Tarama esnasýnda koleksiyonnu deðiþtirme hatasý oluþtu...");
                    }catch (Exception h){Console.WriteLine (h.Message); }
                return(tsListe [endeks]);
            }
        }
        public void Reset() {endeks = -1; kontrol = tsListe.Kontrol;}
    }
    class KelimeSayýcý : IEnumerator {//MoveNext(), Current ve Reset() arar
        string[] klmDizi;
        int konum = -1;
        public KelimeSayýcý (string[] klmDizim) {//Kurucu
            klmDizi = new string [klmDizim.Length];
            for (int i = 0; i < klmDizim.Length; i++) klmDizi [i] = klmDizim [i];
        }
        public bool MoveNext() {
            if (konum < klmDizi.Length - 1) {konum++; return true;}
            else return false;
        }
        public object Current {get {return klmDizi [konum];}}
        public void Reset() {konum = -1;}
    }
    class KelimeListesi : IEnumerable {//GetEnumerator() arar
        string[] klmDizi;
        int i, j, ts1, ts2 ; Random r=new Random(); string a;
        public KelimeListesi (int uz) {//Kurucu
            klmDizi=new string [uz];
            for(i=0;i<klmDizi.Length;i++) {
                a=""; ts1=r.Next(1,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); a+=(char)(65+ts2);}
                klmDizi [i]=a;
            }
        }
        public IEnumerator GetEnumerator() {return new KelimeSayýcý (klmDizi);}
    }
    public class DevridaimTarama<T> : IEnumerable<T> {
        private IEnumerator<T> sayýcý;
        private Type sayýcýTipi;
        public DevridaimTarama (LinkedList<T> liste, LinkedListNode<T> ilk) {//Kurucu
            sayýcý = SayýcýYarat (liste, ilk, false).GetEnumerator();
            sayýcýTipi = sayýcý.GetType();
        }
        public void Dur() {sayýcýTipi.GetField ("son").SetValue (sayýcý, true);}
        private IEnumerable<T> SayýcýYarat (LinkedList<T> lst, LinkedListNode<T> ilk, bool son) {
            LinkedListNode<T> cari = null;
            do {
                if (cari == null) {cari = ilk; //Ýlk baþlangýç
                }else {
                    cari = cari.Next;
                    if (cari == null) {cari = ilk;} //Sonunda "!son" ise devridaime devam 
                }
                yield return cari.Value;
            }while (!son);
        }
        public IEnumerator<T> GetEnumerator() {return sayýcý;}
        IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class VeriYapýsý9D {
        static void Main() {
            Console.Write ("IENumerable için GetEnumerator(), IENumerator içinse MoveNext(), Current, Reset() özelleþtirilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tiplemede ilkdeðerlenen diziden IEnumerator'la varsayýlý koleksiyon üretme:");
            Sýnýf1 klk1 = new Sýnýf1();
            Console.Write ("Harfler: "); foreach (char k in klk1) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nVarsayýlý 'IEnumerator GetEnumerator()'la harf koleksiyonu üretme:");
            Sýnýf2 klk2 = new Sýnýf2();
            Console.Write ("Harfler: "); foreach (char k in klk2) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nYalýn 'yield return 'krk'le IEnumerator koleksiyonu üretme:");
            Sýnýf3 klk3 = new Sýnýf3();
            Console.Write ("Harfler: "); foreach (char k in klk3) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nGetEnumerator() yerine çift parametreli metotla yýllar üretme:");
            Sýnýf4 klk4 = new Sýnýf4();
            Console.Write ("Yýllar: "); foreach(int yýl in klk4.Taratýcý (1881, 1938)) Console.Write (yýl + " "); Console.WriteLine();

            Console.WriteLine ("\nMovenext() ve Reset()'le koleksiyonlarý tekrarlý taratma:");
            Sýnýf5 klk5 = new Sýnýf5 (0); Console.Write ("A-Z harfler: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            Console.Write ("A-Z harfler tiplemesiz tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new Sýnýf5 (1); Console.Write ("z-a harfler: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            Console.Write ("z-a harfler tiplemesiz tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new Sýnýf5 (2024); Console.Write ("Hiç: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new Sýnýf5 (1); Console.Write ("z-a harfler tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new Sýnýf5 (1880); Console.Write ("Hiç tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new Sýnýf5 (0); Console.Write ("A-Z harfler tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nDizi listeleþtirilirken endeks taþma ve ebat deðiþtirme kontrolu:");
            int i, j, ts1; var r=new Random();
            TsListe tsListe = new TsListe();
            for(i=0;i<5;i++) {ts1=r.Next(-100, 1000); tsListe.Ekle (ts1);}
            foreach (int ts in tsListe) Console.Write (ts+" "); Console.WriteLine();
            foreach (int ts in tsListe) {
                Console.Write ("\t"+ts+" ");
                ts1=r.Next(-100, 1000);
                tsListe.Ekle (ts1);
            } Console.WriteLine();
            for(i=0;i<2024;i++) {ts1=r.Next(-100, 1000); tsListe.Ekle (ts1);}
            foreach (int ts in tsListe) Console.Write (ts+" "); Console.WriteLine();

            ts1=r.Next(2, 50); Console.WriteLine ("\nListeleþtirilen klmDizi[{0}]'nin kuruculu rasgele ebat ve ilkdeðerlenmesi:", ts1);
            KelimeListesi klst = new KelimeListesi (ts1);
            foreach (string k in klst) Console.Write ("{0}:{1} ", k, k.Length); Console.WriteLine();

            ts1=r.Next(2, 50); Console.WriteLine ("\nTekrarlamalý [1919,1923] {0} adet yýl sonunda duracaktýr:", ts1);
            LinkedList<int> baðlýListe = new LinkedList<int>();
            for(i = 1919; i <= 1923; ++i) baðlýListe.AddLast (i);
            DevridaimTarama<int> tara = new DevridaimTarama<int> (baðlýListe, baðlýListe.First); //Liste baþýndan tarama baþlar
            j = 0;
            foreach (int yýl in tara) {
                Console.Write (yýl+" ");
                if (j++ == ts1) tara.Dur();
            } Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}