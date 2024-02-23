// j2sc#1109c.cs: IEnumerable/IEnumerator ve yield-return'la koleksiyonlar �retme �rne�i.

using System;
using System.Collections; //IEnumerator i�in
using System.Collections.Generic; //IEnumerator<T> i�in
using System.Linq; //where...select i�in
namespace VeriYap�lar� {
    class S�n�f1 : IEnumerable<string> {
        int i;
        IEnumerator<string> Harf {get {//A-z harfler �reten/yield �zellik
            for(i=0;i<26;i++) yield return ((char)('A'+i)).ToString(); yield return "-";
            for(i=0;i<26;i++) yield return ((char)('a'+i)).ToString();
            }
        }
        public IEnumerator<string> GetEnumerator() {return Harf;} //S�n�f1 tiplemesinin varsay�l� koleksiyonu
        IEnumerator IEnumerable.GetEnumerator() {return null;} //null yerine Harf gerekmez, sadece protokol
    }
    public class ��g�ren {
        public string ad, �nvan;
        public ��g�ren (string a, string �) {ad = a; �nvan = �;} //Kurucu
        public override string ToString() {return string.Format ("{0}({1})", ad, �nvan);}
    }
    public class ��gListe {
        private List<��g�ren> i�Ls = new List<��g�ren>();
        public IEnumerator<��g�ren> GetEnumerator() {foreach (��g�ren ig in i�Ls) yield return ig;} //Varsay�l� GetEnumerator() metodu
        public IEnumerable<��g�ren> Ters {get {for(int i=i�Ls.Count-1;i>=0;i--) yield return i�Ls[i];}} //�zellik
        public IEnumerable<��g�ren> �lkBe� {get {int i=0; foreach (��g�ren ig in i�Ls) {if (i>=4) yield break; else {i++; yield return ig;}}}} //�zellik
        public void ��g�renEkle (��g�ren �ye) {i�Ls.Add (�ye);} //Metot
    }
    class IEnumerableSayac� : IEnumerable<int> {
        int ilk, son;
        public IEnumerableSayac� (int n1, int n2) {ilk=n1-1; son=n2;}
        public IEnumerator<int> GetEnumerator() {return new IEnumeratorSayac� (ilk, son);}
        IEnumerator IEnumerable.GetEnumerator() {return GetEnumerator();}
    }
    class IEnumeratorSayac� : IEnumerator<int> {
        private int y�l1, y�l2;
        public IEnumeratorSayac� (int n1, int n2) {y�l1=n1; y�l2=n2;}
        public bool MoveNext() {return y�l1++ < y�l2;}
        public int Current {get {return y�l1;}}
        object IEnumerator.Current {get {return Current;}}
        public void Reset() {throw new NotSupportedException();}
        public void Dispose(){}
    }
    class VeriYap�s�9C {
        static public IEnumerable<int> �kinin�sleri (int ilk, int son) {for(int i=ilk;i<=son;++i) yield return (int)Math.Pow (2,i);}
        string[] harfler;
        int endeks;
        public VeriYap�s�9C (string[] h, int e) {harfler=h; endeks=e;}
        public IEnumerator GetEnumerator() {
            for(int i=0;i<harfler.Length;i++) yield return harfler [(i + endeks) % harfler.Length];
        }
        static void Main() {
            Console.Write ("IEnumerable/IEnumerator ve yield-return'le standart listeler d���nda her tip ve s�ralamada koleksiyonlar �retilebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f1 tiplemesinin varsay�l� A-z �retilen koleksiyonu:");
            S�n�f1 s1 = new S�n�f1();
            foreach (string hrf in s1) Console.Write ("{0}", hrf); Console.WriteLine();

            Console.WriteLine ("\nVarsay�l� IEnumerator ve IEnumerable'la �lkBe� ile Ters listeler:");
            int i, j, ts1, ts2; string ad, �nvan; var r=new Random();
            ��gListe i�gListe = new ��gListe();
            for(i=0;i<10;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                �nvan=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); �nvan+=(char)(97+ts2);}
                i�gListe.��g�renEkle (new ��g�ren (ad, �nvan));
            }
            Console.Write ("\tVarsay�l� IEnumerator: "); foreach (��g�ren �ye in i�gListe) Console.Write (�ye.ToString()+" "); Console.WriteLine();
            Console.Write ("\tIEnumerable'la �lkBe�: "); foreach (��g�ren �ye in i�gListe.�lkBe�) Console.Write (�ye.ToString()+" "); Console.WriteLine();
            Console.Write ("\tIEnumerable'la Ters: "); foreach (��g�ren �ye in i�gListe.Ters) Console.Write (�ye.ToString()+" "); Console.WriteLine();

            Console.WriteLine ("\nIEnumerable'la 2^[ilk,son] 2'nin �slerini �retme:");
            IEnumerable<int> ikinin�sleri = �kinin�sleri (0, 30); //int i�in azamisi 2**30'dur
            i=0; foreach (int sonu� in ikinin�sleri) Console.Write ("2^{0}={1:#,0} ", i++, sonu�); Console.WriteLine();

            Console.WriteLine ("\n100 adet [-1000,1000] rasgele say� �retip from-select'le s�zge�leme:");
            int[] tsDizi = new int [100];
            for(i=0;i<tsDizi.Length;i++) {ts1=r.Next(-1000,1000); tsDizi [i]=ts1;}
            Console.Write ("\tT�m rasgele say�lar: "); foreach (int n in tsDizi) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> s�f�r�st�Artan = from say�lar in tsDizi where say�lar >= 0 orderby say�lar select say�lar;
            Console.Write ("\tArtan say�lar >= 0: "); foreach (int n in s�f�r�st�Artan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> s�f�rAlt�Azalan = from say�lar in tsDizi where say�lar <= 0 orderby -say�lar select say�lar;
            Console.Write ("\tAzalan say�lar <= 0: "); foreach (int n in s�f�rAlt�Azalan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> T�mArtan = from say�lar in tsDizi orderby say�lar select say�lar;
            Console.Write ("\tT�m say�lar artan: "); foreach (int n in T�mArtan) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> T�mAzalan = from say�lar in tsDizi orderby -say�lar select say�lar;
            Console.Write ("\tT�m say�lar azalan: "); foreach (int n in T�mAzalan) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\nHarfleri verili endeks'ten sona ve tekar ba�tan endeks'e s�ralama:");
            string[] dzgDizi = "a b c � d e f g � h � i j k l m n o � p r s � t u � v y z A B C � D E F G � H I � J K L M N O � P R S � T U � V Y Z q w x Q W X".Split(' ');
            VeriYap�s�9C koleksiyon = new VeriYap�s�9C (dzgDizi, dzgDizi.Length/4);
            Console.Write ("\tEndeks=dzgDizi.Length/4 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            koleksiyon = new VeriYap�s�9C (dzgDizi, dzgDizi.Length/2);
            Console.Write ("\tEndeks=dzgDizi.Length/2 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            koleksiyon = new VeriYap�s�9C (dzgDizi, dzgDizi.Length*3/4);
            Console.Write ("\tEndeks=dzgDizi.Length*3/4 ile sunum: "); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();
            ts1=r.Next(0,dzgDizi.Length);
            koleksiyon = new VeriYap�s�9C (dzgDizi, ts1);
            Console.Write ("\tEndeks=rasgele({0})ile sunum: ", ts1); foreach (string hrf in koleksiyon) Console.Write (hrf); Console.WriteLine();

            Console.WriteLine ("\nIEnumerable/IEnumerator saya�la [ilk,son] aras� saya� y�r�tme:");
            IEnumerableSayac� saya� = new IEnumerableSayac� (1881, 1938);
            Console.Write ("\tY�llar=[1881,1938]: "); foreach (int n in saya�) Console.Write (n+" "); Console.WriteLine();
            saya� = new IEnumerableSayac� (1957, 2024);
            Console.Write ("\tY�llar=[1957,2024]: "); foreach (int n in saya�) Console.Write (n+" "); Console.WriteLine();
            saya� = new IEnumerableSayac� (2000, 2100);
            Console.Write ("\tY�llar=[1957,2024]: "); foreach (int n in saya�) Console.Write (n+" "); Console.WriteLine();
            saya� = new IEnumerableSayac� (-2024, -1957);
            Console.Write ("\tY�llar=[2024,1957] ters: "); foreach (int n in saya�) Console.Write (-n+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}