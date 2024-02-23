// j2sc#1109a.cs: IComparable/CompareTo() ve IComparer/Compare() ile özel sýralama örneði.

using System;
using System.Collections;
using System.Collections.Generic; //List<T> için
namespace VeriYapýlarý {
    class Mamül : IComparable {
        string ad;
        double fiyat;
        int mevcut;
        public Mamül (string a, double f, int m) {ad = a; fiyat = f; mevcut = m;}
        public override string ToString() {return String.Format ("Ürün: {0,-10}Fiyat: {1,6:#,0.00}TL  Mevcut: {2,-6}Toplam: {3,10:#,0.00}TL", ad, fiyat, mevcut, fiyat*mevcut);}
        public int KýyasF (object n1, object n2) {if (((Mamül)n1).fiyat > ((Mamül)n2).fiyat) return -1; else if (((Mamül)n1).fiyat < ((Mamül)n2).fiyat) return 1; else return 0;}
        //public int KýyasM (object n1, object n2) {if (((Mamül)n1).mevcut > ((Mamül)n2).mevcut) return 1; else if (((Mamül)n1).mevcut < ((Mamül)n2).mevcut) return -1; else return 0;}
        //public int CompareTo (object ns) {return ad.CompareTo (((Mamül)ns).ad);}
        public int CompareTo (object ns) {return KýyasF (this, ns);}
        //public int CompareTo (object ns) {return KýyasM (this, ns);}
    }
    class Sýnýf1 : IComparable {
        public int n;
        public Sýnýf1 (int x) {n = x;} //Kurucu
        public int CompareTo (object ns) {return n - ((Sýnýf1) ns).n;}
    }
    public class KompleksSayý : IComparable {
        private int gerçel, sanal;
        public KompleksSayý (int gerçel, int sanal) {this.gerçel = gerçel; this.sanal = sanal;} //Kurucu
        public double Genlik {get {return Math.Sqrt (Math.Pow (this.gerçel, 2) + Math.Pow (this.sanal, 2));}}
        public int CompareTo (object ns) {
            if (ns is KompleksSayý) {
                KompleksSayý þu = (KompleksSayý) ns;
                if ((this.gerçel == þu.gerçel) && (this.sanal == þu.sanal)) return 0;
                else if (this.Genlik < þu.Genlik) return -1;
                else return 1;
            }else throw new System.ArgumentException ("KompleksSayý tipli deðil!");
        }
        public override string ToString() {return String.Format ("({0}{1}j{2})", gerçel, sanal>=0?"+":"-", Math.Abs (sanal));}
    }
    public class Ýþgören : IComparable<Ýþgören> {
        private int iþgNo;
        private int hizmetYýlý = 1;
        public Ýþgören (int iþgNo) {this.iþgNo = iþgNo;} //Kurucu-1
        public Ýþgören (int iþgNo, int hizmetYýlý) {this.iþgNo = iþgNo; this.hizmetYýlý = hizmetYýlý;} //Kurucu-2
        public override string ToString() {return "No: " + iþgNo.ToString() + "\t   Hizmet yýllarý: " + hizmetYýlý.ToString();}
        public static ÝþgKýyas KýyascýyýAl() {return new Ýþgören.ÝþgKýyas();}
        public int CompareTo (Ýþgören þu) {return 0;} //(Varsayýlý) Esasý bir alttaki
        public int CompareTo (Ýþgören þu, Ýþgören.ÝþgKýyas.KýyasAlaný alan) {
            switch (alan) {
                case Ýþgören.ÝþgKýyas.KýyasAlaný.ÝþgNo: return this.iþgNo.CompareTo (þu.iþgNo);
                case Ýþgören.ÝþgKýyas.KýyasAlaný.HYýl: return this.hizmetYýlý.CompareTo (þu.hizmetYýlý);
            }
            return 0;
        }
        public class ÝþgKýyas : IComparer<Ýþgören> {
            public enum KýyasAlaný {ÝþgNo, HYýl};
            public int Compare (Ýþgören bu, Ýþgören þu) {return bu.CompareTo (þu, ÝþgKýyasAlaný);}
            public Ýþgören.ÝþgKýyas.KýyasAlaný ÝþgKýyasAlaný {get; set;}
        }
    }
    public class Ýþgören2: IComparable {
        string ad;
        int no;
        public Ýþgören2 (string ad, int no) {this.ad = ad; this.no = no;} //Kurucu
        int IComparable.CompareTo (object ns) {//Varsayýlý no'yla artan sýralý
            if (this.no > ((Ýþgören2)ns).no) return(1);
            if (this.no < ((Ýþgören2)ns).no) return(-1);
            else return(0);
        }
        public static IComparer AdlaSýrala {get {return ((IComparer) new AdSýralýSýnýf());}}
        public static IComparer NoylaSýrala {get {return ((IComparer) new NoSýralýSýnýf());}}
        public override string ToString() {return(ad + ": " + no);}
        class AdSýralýSýnýf: IComparer {
            public int Compare (object ns1, object ns2) {return (String.Compare (((Ýþgören2)ns1).ad, ((Ýþgören2)ns2).ad));}
        }
        class NoSýralýSýnýf: IComparer {
            public int Compare (object ns1, object ns2) {return (((IComparable)ns2).CompareTo (ns1));} //no'yla azalan sýralý
        }
    }
    class VeriYapýsý9A {
        public static bool mevcutMu<T> (T ne, T[] dizi) where T : IComparable {
            foreach (T x in dizi) if (x.CompareTo (ne) == 0) return true;
            return false;
        }
        static void Main() {
            Console.Write ("IComparable CompareTo()'yu, IComparer ise Compare()'i arar. Azalan sýralama için deðer1 ile deðer2'nin yerdeðiþtirmesi yeterlidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Rasgele mamül ad, fiyat ve mevcutla özelleþtirilen sýralamalar:");
            int i, j, ts1, ts2; double ds1; string ad; var r=new Random();
            ArrayList envanter = new ArrayList();
            for(i=0;i<5;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ds1=r.Next(1,1000)+r.Next(10,100)/100D;
                ts1=r.Next(1,1000);
                envanter.Add (new Mamül (ad, ds1, ts1));
            }
            Console.WriteLine ("\tSýralama öncesi mamül listesi:");
            foreach (Mamül m in envanter) Console.WriteLine (m);
            //Console.WriteLine ("\tArtan ad'la sýralama sonrasý mamül listesi:");
            Console.WriteLine ("\tAzalan fiyat'la sýralama sonrasý mamül listesi:");
            //Console.WriteLine ("\tArtan mevcut'la sýralama sonrasý mamül listesi:");
            envanter.Sort();
            foreach (Mamül m in envanter) Console.WriteLine (m);

            Console.WriteLine ("\ntsDizi'de, dzgDizi'de ve snfDizi'de deðer mevcudiyeti sorgulama:");
            int[] tsDizi = {1, 2, 3, 4, 5};
            Console.WriteLine ("tsDizi'de '4' mevcut mu? {0}", mevcutMu (4, tsDizi)?"EVET":"HAYIR");
            Console.WriteLine ("tsDizi'de '0' mevcut mu? {0}", mevcutMu (0, tsDizi)?"EVET":"HAYIR"); 
            string[] dzgDizi = {"bir", "iki", "üç", "dört", "beþ"};
            Console.WriteLine ("dzgDizi'de 'dört' mevcut mu? {0}", mevcutMu ("dört", dzgDizi)?"EVET":"HAYIR");
            Console.WriteLine ("dzgDizi'de 'sýfýr' mevcut mu? {0}", mevcutMu ("sýfýr", dzgDizi)?"EVET":"HAYIR"); 
            Sýnýf1[] snfDizi = {new Sýnýf1 (1), new Sýnýf1 (2), new Sýnýf1 (3), new Sýnýf1 (4), new Sýnýf1 (5)};
            Console.WriteLine ("snfDizi'de 'new Sýnýf1(4)' mevcut mu? {0}", mevcutMu (new Sýnýf1(4), snfDizi)?"EVET":"HAYIR");
            Console.WriteLine ("snfDizi'de 'new Sýnýf1(0)' mevcut mu? {0}", mevcutMu (new Sýnýf1(0), snfDizi)?"EVET":"HAYIR");

            Console.WriteLine ("\nKompleks sayýlarýn büyüklüðü/+1, küçüklüðü/-1 ve eþitliði/0 testi:");
            KompleksSayý ks1 = new KompleksSayý (1, 2);
            KompleksSayý ks2 = new KompleksSayý (1, 2);
            KompleksSayý ks3 = new KompleksSayý (2, 3);
            KompleksSayý ks4 = new KompleksSayý (2, -3);
            Console.WriteLine ("ks1{0}.CompareTo(ks2{1} = {2})", ks1, ks2, ks1.CompareTo (ks2));
            Console.WriteLine ("ks1{0}.CompareTo(ks3{1} = {2})", ks1, ks3, ks1.CompareTo (ks3));
            Console.WriteLine ("ks3{0}.CompareTo(ks2{1} = {2})", ks3, ks2, ks3.CompareTo (ks2));
            Console.WriteLine ("ks3{0}.CompareTo(ks4{1} = {2})", ks3, ks4, ks3.CompareTo (ks4));
            Console.WriteLine ("ks4{0}.CompareTo(ks3{1} = {2})", ks4, ks3, ks4.CompareTo (ks3)); //HATA: Genlik dýþý açýsal -+ kaale alýnmýyor.

            Console.WriteLine ("\nÝþgören listesini iþgNo ve hyýl'a göre artan sýralama:");
            List<Ýþgören> iþgListe  = new List<Ýþgören>();
            for(i=0;i<10;i++) {iþgListe.Add (new Ýþgören (r.Next (10) + 100, r.Next (20)));}
            Ýþgören.ÝþgKýyas kýyascý = Ýþgören.KýyascýyýAl();
            kýyascý.ÝþgKýyasAlaný = Ýþgören.ÝþgKýyas.KýyasAlaný.ÝþgNo;
            iþgListe.Sort (kýyascý);
            for(i=0;i<iþgListe.Count;i++) Console.WriteLine (iþgListe [i]);
            kýyascý.ÝþgKýyasAlaný = Ýþgören.ÝþgKýyas.KýyasAlaný.HYýl;
            iþgListe.Sort (kýyascý);
            for(i=0;i<iþgListe.Count;i++) Console.WriteLine ("\t"+iþgListe [i]);

            Console.WriteLine ("\niþgDizi ve iþgListe'yle rasgele, ad ve no'yla sýralý sunumlar:");
            Ýþgören2[] iþgDizi = new Ýþgören2 [10];
            ArrayList iþgListe1 = new ArrayList(); ArrayList iþgListe2 = new ArrayList(); ArrayList iþgListe3 = new ArrayList();
            for(i=0;i<iþgDizi.Length;i++) {
                ad=""; ts1=r.Next(3,10); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                ts1=r.Next(1000,10000);
                iþgDizi [i] = new Ýþgören2 (ad, ts1);
                iþgListe1.Add (iþgDizi [i]); iþgListe2.Add (iþgDizi [i]); iþgListe3.Add (iþgDizi [i]);
            }
            Console.WriteLine ("\tSýralamasýz rasgele iþgDizi:");
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine ("Ad ve no = ({0})", iþg);
            Array.Sort (iþgDizi, Ýþgören2.AdlaSýrala);
            Console.WriteLine ("\tAd'la artan sýralý iþgDizi:");
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine ("Ad ve no = ({0})", iþg);
            Array.Sort (iþgDizi, Ýþgören2.NoylaSýrala);
            Console.WriteLine ("\tNo'yla azalan sýralý iþgDizi:");
            foreach (Ýþgören2 iþg in iþgDizi) Console.WriteLine ("Ad ve no = ({0})", iþg);
            iþgListe2.Sort (Ýþgören2.AdlaSýrala);
            iþgListe3.Sort(); //Varsayýlý no'yla sýralý
            Console.WriteLine ("\tRasgele, ad'la ve no'yla artan sýralý iþgListe:");
            for(i=0;i<iþgListe1.Count;i++) Console.WriteLine ("{0}\t{1}\t{2}", iþgListe1 [i], iþgListe2 [i], iþgListe3 [i]);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}