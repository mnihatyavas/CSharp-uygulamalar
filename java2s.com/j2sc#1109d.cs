// j2sc#1109d.cs: �zelle�tirilen IEnumerable ve IEnumerator'la dizi/liste tarama �rne�i.

using System;
using System.Collections; //IEnumerator ve IEnumerable i�in
using System.Collections.Generic; //IEnumerable<T> ve LinkedList<int> i�in
namespace VeriYap�lar� {
    class S�n�f1 { 
        char[] harfler = new char[52];
        public S�n�f1() {//Parametresiz kurucuyla tiplemede ilkde�erleme
            for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);
            for(int i=0;i<26;i++) harfler [i+26]=(char)('a'+i);
        }
        //Tiplemeyle varsay�l� koleksiyonu �retme
        public IEnumerator GetEnumerator() {foreach(char hrf in harfler) yield return hrf;}
    }
    class S�n�f2 {
        char harf;
        public IEnumerator GetEnumerator() {
            harf='A'; for(int i=0;i<26; i++) yield return (char)(harf + i);
            yield return '-';
            harf='a'; for(int i=0;i<26; i++) yield return (char)(harf + i);
        }
    }
    class S�n�f3 {
        public IEnumerator GetEnumerator() {
            for(int i=0;i<26; i++) yield return (char)('A' + i);
            yield return '-';
            for(int i=0;i<26; i++) yield return (char)('a' + i);
        }
    }
    class S�n�f4 {
        public IEnumerable Tarat�c� (int ilk, int son) {for(int i=ilk;i<=son;i++) yield return i;}
    }
    class S�n�f5 : IEnumerator, IEnumerable {
        char[] harfler = new char[26];
        int endeks = -1;
        public S�n�f5() {for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);}
        public S�n�f5(int n) {
            if (n==0) {for(int i=0;i<26;i++) harfler [i]=(char)('A'+i);}
            else if (n==1) {for(int i=0;i<26;i++) harfler [i]=(char)('a'+25-i);}
            else {for(int i=0;i<26;i++) harfler [i]=(char)0;}
        }
        //IEnumerable y�r�t�m� i�in
        public IEnumerator GetEnumerator() {return this;}
        //IEnumerator y�r�t�m� i�in 
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
        int saya� = 0;
        int kontrol = 0;
        public void Ekle (int ts) {
            if (saya� + 1 > atanan) return;
            tsDizi [saya�] = ts;
            saya�++;
            kontrol++;
        }
        public int Saya� {get {return(saya�);}}
        void EndeksKontrolu (int endeks) {
            if (endeks >= saya�) throw new ArgumentOutOfRangeException ("Endeks kapsam d��� hatas� yapt�...");
        }
        public int this [int endeks] {
            get {EndeksKontrolu (endeks); return(tsDizi [endeks]);}
            set {EndeksKontrolu (endeks); tsDizi [endeks] = value; kontrol++;}
        }
        public IEnumerator GetEnumerator() {return (new TsListeSay�c� (this));}
        internal int Kontrol {get {return(kontrol);}}
    }
    class TsListeSay�c�: IEnumerator {
        TsListe tsListe;
        int kontrol;
        int endeks;
        internal TsListeSay�c� (TsListe tsListe) {this.tsListe = tsListe; Reset();}
        public bool MoveNext() {
            endeks++;
            if (endeks >= tsListe.Saya�) return(false);
            else return(true);
        }
        public object Current {
            get {
                if (kontrol != tsListe.Kontrol) 
                    try {throw new InvalidOperationException ("Tarama esnas�nda koleksiyonnu de�i�tirme hatas� olu�tu...");
                    }catch (Exception h){Console.WriteLine (h.Message); }
                return(tsListe [endeks]);
            }
        }
        public void Reset() {endeks = -1; kontrol = tsListe.Kontrol;}
    }
    class KelimeSay�c� : IEnumerator {//MoveNext(), Current ve Reset() arar
        string[] klmDizi;
        int konum = -1;
        public KelimeSay�c� (string[] klmDizim) {//Kurucu
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
        public IEnumerator GetEnumerator() {return new KelimeSay�c� (klmDizi);}
    }
    public class DevridaimTarama<T> : IEnumerable<T> {
        private IEnumerator<T> say�c�;
        private Type say�c�Tipi;
        public DevridaimTarama (LinkedList<T> liste, LinkedListNode<T> ilk) {//Kurucu
            say�c� = Say�c�Yarat (liste, ilk, false).GetEnumerator();
            say�c�Tipi = say�c�.GetType();
        }
        public void Dur() {say�c�Tipi.GetField ("son").SetValue (say�c�, true);}
        private IEnumerable<T> Say�c�Yarat (LinkedList<T> lst, LinkedListNode<T> ilk, bool son) {
            LinkedListNode<T> cari = null;
            do {
                if (cari == null) {cari = ilk; //�lk ba�lang��
                }else {
                    cari = cari.Next;
                    if (cari == null) {cari = ilk;} //Sonunda "!son" ise devridaime devam 
                }
                yield return cari.Value;
            }while (!son);
        }
        public IEnumerator<T> GetEnumerator() {return say�c�;}
        IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class VeriYap�s�9D {
        static void Main() {
            Console.Write ("IENumerable i�in GetEnumerator(), IENumerator i�inse MoveNext(), Current, Reset() �zelle�tirilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tiplemede ilkde�erlenen diziden IEnumerator'la varsay�l� koleksiyon �retme:");
            S�n�f1 klk1 = new S�n�f1();
            Console.Write ("Harfler: "); foreach (char k in klk1) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nVarsay�l� 'IEnumerator GetEnumerator()'la harf koleksiyonu �retme:");
            S�n�f2 klk2 = new S�n�f2();
            Console.Write ("Harfler: "); foreach (char k in klk2) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nYal�n 'yield return 'krk'le IEnumerator koleksiyonu �retme:");
            S�n�f3 klk3 = new S�n�f3();
            Console.Write ("Harfler: "); foreach (char k in klk3) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nGetEnumerator() yerine �ift parametreli metotla y�llar �retme:");
            S�n�f4 klk4 = new S�n�f4();
            Console.Write ("Y�llar: "); foreach(int y�l in klk4.Tarat�c� (1881, 1938)) Console.Write (y�l + " "); Console.WriteLine();

            Console.WriteLine ("\nMovenext() ve Reset()'le koleksiyonlar� tekrarl� taratma:");
            S�n�f5 klk5 = new S�n�f5 (0); Console.Write ("A-Z harfler: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            Console.Write ("A-Z harfler tiplemesiz tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new S�n�f5 (1); Console.Write ("z-a harfler: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            Console.Write ("z-a harfler tiplemesiz tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new S�n�f5 (2024); Console.Write ("Hi�: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new S�n�f5 (1); Console.Write ("z-a harfler tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new S�n�f5 (1880); Console.Write ("Hi� tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();
            klk5 = new S�n�f5 (0); Console.Write ("A-Z harfler tiplemeli tekrar: "); foreach (char k in klk5) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nDizi listele�tirilirken endeks ta�ma ve ebat de�i�tirme kontrolu:");
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

            ts1=r.Next(2, 50); Console.WriteLine ("\nListele�tirilen klmDizi[{0}]'nin kuruculu rasgele ebat ve ilkde�erlenmesi:", ts1);
            KelimeListesi klst = new KelimeListesi (ts1);
            foreach (string k in klst) Console.Write ("{0}:{1} ", k, k.Length); Console.WriteLine();

            ts1=r.Next(2, 50); Console.WriteLine ("\nTekrarlamal� [1919,1923] {0} adet y�l sonunda duracakt�r:", ts1);
            LinkedList<int> ba�l�Liste = new LinkedList<int>();
            for(i = 1919; i <= 1923; ++i) ba�l�Liste.AddLast (i);
            DevridaimTarama<int> tara = new DevridaimTarama<int> (ba�l�Liste, ba�l�Liste.First); //Liste ba��ndan tarama ba�lar
            j = 0;
            foreach (int y�l in tara) {
                Console.Write (y�l+" ");
                if (j++ == ts1) tara.Dur();
            } Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}