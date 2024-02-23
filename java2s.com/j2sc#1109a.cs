// j2sc#1109a.cs: IComparable/CompareTo() ve IComparer/Compare() ile �zel s�ralama �rne�i.

using System;
using System.Collections;
using System.Collections.Generic; //List<T> i�in
namespace VeriYap�lar� {
    class Mam�l : IComparable {
        string ad;
        double fiyat;
        int mevcut;
        public Mam�l (string a, double f, int m) {ad = a; fiyat = f; mevcut = m;}
        public override string ToString() {return String.Format ("�r�n: {0,-10}Fiyat: {1,6:#,0.00}TL  Mevcut: {2,-6}Toplam: {3,10:#,0.00}TL", ad, fiyat, mevcut, fiyat*mevcut);}
        public int K�yasF (object n1, object n2) {if (((Mam�l)n1).fiyat > ((Mam�l)n2).fiyat) return -1; else if (((Mam�l)n1).fiyat < ((Mam�l)n2).fiyat) return 1; else return 0;}
        //public int K�yasM (object n1, object n2) {if (((Mam�l)n1).mevcut > ((Mam�l)n2).mevcut) return 1; else if (((Mam�l)n1).mevcut < ((Mam�l)n2).mevcut) return -1; else return 0;}
        //public int CompareTo (object ns) {return ad.CompareTo (((Mam�l)ns).ad);}
        public int CompareTo (object ns) {return K�yasF (this, ns);}
        //public int CompareTo (object ns) {return K�yasM (this, ns);}
    }
    class S�n�f1 : IComparable {
        public int n;
        public S�n�f1 (int x) {n = x;} //Kurucu
        public int CompareTo (object ns) {return n - ((S�n�f1) ns).n;}
    }
    public class KompleksSay� : IComparable {
        private int ger�el, sanal;
        public KompleksSay� (int ger�el, int sanal) {this.ger�el = ger�el; this.sanal = sanal;} //Kurucu
        public double Genlik {get {return Math.Sqrt (Math.Pow (this.ger�el, 2) + Math.Pow (this.sanal, 2));}}
        public int CompareTo (object ns) {
            if (ns is KompleksSay�) {
                KompleksSay� �u = (KompleksSay�) ns;
                if ((this.ger�el == �u.ger�el) && (this.sanal == �u.sanal)) return 0;
                else if (this.Genlik < �u.Genlik) return -1;
                else return 1;
            }else throw new System.ArgumentException ("KompleksSay� tipli de�il!");
        }
        public override string ToString() {return String.Format ("({0}{1}j{2})", ger�el, sanal>=0?"+":"-", Math.Abs (sanal));}
    }
    public class ��g�ren : IComparable<��g�ren> {
        private int i�gNo;
        private int hizmetY�l� = 1;
        public ��g�ren (int i�gNo) {this.i�gNo = i�gNo;} //Kurucu-1
        public ��g�ren (int i�gNo, int hizmetY�l�) {this.i�gNo = i�gNo; this.hizmetY�l� = hizmetY�l�;} //Kurucu-2
        public override string ToString() {return "No: " + i�gNo.ToString() + "\t   Hizmet y�llar�: " + hizmetY�l�.ToString();}
        public static ��gK�yas K�yasc�y�Al() {return new ��g�ren.��gK�yas();}
        public int CompareTo (��g�ren �u) {return 0;} //(Varsay�l�) Esas� bir alttaki
        public int CompareTo (��g�ren �u, ��g�ren.��gK�yas.K�yasAlan� alan) {
            switch (alan) {
                case ��g�ren.��gK�yas.K�yasAlan�.��gNo: return this.i�gNo.CompareTo (�u.i�gNo);
                case ��g�ren.��gK�yas.K�yasAlan�.HY�l: return this.hizmetY�l�.CompareTo (�u.hizmetY�l�);
            }
            return 0;
        }
        public class ��gK�yas : IComparer<��g�ren> {
            public enum K�yasAlan� {��gNo, HY�l};
            public int Compare (��g�ren bu, ��g�ren �u) {return bu.CompareTo (�u, ��gK�yasAlan�);}
            public ��g�ren.��gK�yas.K�yasAlan� ��gK�yasAlan� {get; set;}
        }
    }
    public class ��g�ren2: IComparable {
        string ad;
        int no;
        public ��g�ren2 (string ad, int no) {this.ad = ad; this.no = no;} //Kurucu
        int IComparable.CompareTo (object ns) {//Varsay�l� no'yla artan s�ral�
            if (this.no > ((��g�ren2)ns).no) return(1);
            if (this.no < ((��g�ren2)ns).no) return(-1);
            else return(0);
        }
        public static IComparer AdlaS�rala {get {return ((IComparer) new AdS�ral�S�n�f());}}
        public static IComparer NoylaS�rala {get {return ((IComparer) new NoS�ral�S�n�f());}}
        public override string ToString() {return(ad + ": " + no);}
        class AdS�ral�S�n�f: IComparer {
            public int Compare (object ns1, object ns2) {return (String.Compare (((��g�ren2)ns1).ad, ((��g�ren2)ns2).ad));}
        }
        class NoS�ral�S�n�f: IComparer {
            public int Compare (object ns1, object ns2) {return (((IComparable)ns2).CompareTo (ns1));} //no'yla azalan s�ral�
        }
    }
    class VeriYap�s�9A {
        public static bool mevcutMu<T> (T ne, T[] dizi) where T : IComparable {
            foreach (T x in dizi) if (x.CompareTo (ne) == 0) return true;
            return false;
        }
        static void Main() {
            Console.Write ("IComparable CompareTo()'yu, IComparer ise Compare()'i arar. Azalan s�ralama i�in de�er1 ile de�er2'nin yerde�i�tirmesi yeterlidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Rasgele mam�l ad, fiyat ve mevcutla �zelle�tirilen s�ralamalar:");
            int i, j, ts1, ts2; double ds1; string ad; var r=new Random();
            ArrayList envanter = new ArrayList();
            for(i=0;i<5;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ds1=r.Next(1,1000)+r.Next(10,100)/100D;
                ts1=r.Next(1,1000);
                envanter.Add (new Mam�l (ad, ds1, ts1));
            }
            Console.WriteLine ("\tS�ralama �ncesi mam�l listesi:");
            foreach (Mam�l m in envanter) Console.WriteLine (m);
            //Console.WriteLine ("\tArtan ad'la s�ralama sonras� mam�l listesi:");
            Console.WriteLine ("\tAzalan fiyat'la s�ralama sonras� mam�l listesi:");
            //Console.WriteLine ("\tArtan mevcut'la s�ralama sonras� mam�l listesi:");
            envanter.Sort();
            foreach (Mam�l m in envanter) Console.WriteLine (m);

            Console.WriteLine ("\ntsDizi'de, dzgDizi'de ve snfDizi'de de�er mevcudiyeti sorgulama:");
            int[] tsDizi = {1, 2, 3, 4, 5};
            Console.WriteLine ("tsDizi'de '4' mevcut mu? {0}", mevcutMu (4, tsDizi)?"EVET":"HAYIR");
            Console.WriteLine ("tsDizi'de '0' mevcut mu? {0}", mevcutMu (0, tsDizi)?"EVET":"HAYIR"); 
            string[] dzgDizi = {"bir", "iki", "��", "d�rt", "be�"};
            Console.WriteLine ("dzgDizi'de 'd�rt' mevcut mu? {0}", mevcutMu ("d�rt", dzgDizi)?"EVET":"HAYIR");
            Console.WriteLine ("dzgDizi'de 's�f�r' mevcut mu? {0}", mevcutMu ("s�f�r", dzgDizi)?"EVET":"HAYIR"); 
            S�n�f1[] snfDizi = {new S�n�f1 (1), new S�n�f1 (2), new S�n�f1 (3), new S�n�f1 (4), new S�n�f1 (5)};
            Console.WriteLine ("snfDizi'de 'new S�n�f1(4)' mevcut mu? {0}", mevcutMu (new S�n�f1(4), snfDizi)?"EVET":"HAYIR");
            Console.WriteLine ("snfDizi'de 'new S�n�f1(0)' mevcut mu? {0}", mevcutMu (new S�n�f1(0), snfDizi)?"EVET":"HAYIR");

            Console.WriteLine ("\nKompleks say�lar�n b�y�kl���/+1, k���kl���/-1 ve e�itli�i/0 testi:");
            KompleksSay� ks1 = new KompleksSay� (1, 2);
            KompleksSay� ks2 = new KompleksSay� (1, 2);
            KompleksSay� ks3 = new KompleksSay� (2, 3);
            KompleksSay� ks4 = new KompleksSay� (2, -3);
            Console.WriteLine ("ks1{0}.CompareTo(ks2{1} = {2})", ks1, ks2, ks1.CompareTo (ks2));
            Console.WriteLine ("ks1{0}.CompareTo(ks3{1} = {2})", ks1, ks3, ks1.CompareTo (ks3));
            Console.WriteLine ("ks3{0}.CompareTo(ks2{1} = {2})", ks3, ks2, ks3.CompareTo (ks2));
            Console.WriteLine ("ks3{0}.CompareTo(ks4{1} = {2})", ks3, ks4, ks3.CompareTo (ks4));
            Console.WriteLine ("ks4{0}.CompareTo(ks3{1} = {2})", ks4, ks3, ks4.CompareTo (ks3)); //HATA: Genlik d��� a��sal -+ kaale al�nm�yor.

            Console.WriteLine ("\n��g�ren listesini i�gNo ve hy�l'a g�re artan s�ralama:");
            List<��g�ren> i�gListe  = new List<��g�ren>();
            for(i=0;i<10;i++) {i�gListe.Add (new ��g�ren (r.Next (10) + 100, r.Next (20)));}
            ��g�ren.��gK�yas k�yasc� = ��g�ren.K�yasc�y�Al();
            k�yasc�.��gK�yasAlan� = ��g�ren.��gK�yas.K�yasAlan�.��gNo;
            i�gListe.Sort (k�yasc�);
            for(i=0;i<i�gListe.Count;i++) Console.WriteLine (i�gListe [i]);
            k�yasc�.��gK�yasAlan� = ��g�ren.��gK�yas.K�yasAlan�.HY�l;
            i�gListe.Sort (k�yasc�);
            for(i=0;i<i�gListe.Count;i++) Console.WriteLine ("\t"+i�gListe [i]);

            Console.WriteLine ("\ni�gDizi ve i�gListe'yle rasgele, ad ve no'yla s�ral� sunumlar:");
            ��g�ren2[] i�gDizi = new ��g�ren2 [10];
            ArrayList i�gListe1 = new ArrayList(); ArrayList i�gListe2 = new ArrayList(); ArrayList i�gListe3 = new ArrayList();
            for(i=0;i<i�gDizi.Length;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1000,10000);
                i�gDizi [i] = new ��g�ren2 (ad, ts1);
                i�gListe1.Add (i�gDizi [i]); i�gListe2.Add (i�gDizi [i]); i�gListe3.Add (i�gDizi [i]);
            }
            Console.WriteLine ("\tS�ralamas�z rasgele i�gDizi:");
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine ("Ad ve no = ({0})", i�g);
            Array.Sort (i�gDizi, ��g�ren2.AdlaS�rala);
            Console.WriteLine ("\tAd'la artan s�ral� i�gDizi:");
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine ("Ad ve no = ({0})", i�g);
            Array.Sort (i�gDizi, ��g�ren2.NoylaS�rala);
            Console.WriteLine ("\tNo'yla azalan s�ral� i�gDizi:");
            foreach (��g�ren2 i�g in i�gDizi) Console.WriteLine ("Ad ve no = ({0})", i�g);
            i�gListe2.Sort (��g�ren2.AdlaS�rala);
            i�gListe3.Sort(); //Varsay�l� no'yla s�ral�
            Console.WriteLine ("\tRasgele, ad'la ve no'yla artan s�ral� i�gListe:");
            for(i=0;i<i�gListe1.Count;i++) Console.WriteLine ("{0}\t{1}\t{2}", i�gListe1 [i], i�gListe2 [i], i�gListe3 [i]);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}