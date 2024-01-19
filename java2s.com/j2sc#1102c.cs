// j2sc#1102c.cs: Çok deðerli nesnel liste elemanlarýný girme, sýralama ve sunma örneði.

using System;
using System.Collections;
namespace VeriYapýlarý {
    class Mamül : IComparable {
        string ad;
        double maliyet;
        int mevcut;
        public Mamül (string a, double ml, int mv) {ad = a; maliyet = ml; mevcut = mv;} //Kurucu
        public override string ToString() {return String.Format ("{0,-7}Maliyet: {1,6} TL   Mevcut: {2,3}   Toplam: {3,12:#,0.00} TL", ad, maliyet, mevcut, maliyet * mevcut);}
        public int CompareTo (object ns) {return ad.CompareTo (((Mamül)ns).ad);}
    }
    class Ýþgören : IComparable {
        string isim;
        double maaþ;
        public Ýþgören (string isim, double maaþ) {this.isim = isim; this.maaþ = maaþ;}
        public override string ToString() {return String.Format ("Ýsim: {0},\tMaaþ: {1,8:#,0.00} TL", isim, maaþ);}
        public int Kýyas (object ns1, object ns2) {
            if (((Ýþgören)ns1).maaþ < ((Ýþgören)ns2).maaþ) {return -1;
            }else if (((Ýþgören)ns1).maaþ > ((Ýþgören)ns2).maaþ) {return 1;
            }else {return 0;}
        }
        public int CompareTo (object ns) {return Kýyas (this, ns);}
    }
    class VeriYapýsý2C {
        public static void ListeyiGöster (string ad, ArrayList liste) {for(int i = 0; i < liste.Count; i++) Console.WriteLine (ad + "[" + i + "] = " + liste [i]);}
        static void Main() {
            Console.Write ("Nesne olarak çoklu alanlý listenin sýralanabilmesi için temel IComparable'in CompareTo() metodu tek yada çoklu anahtarla özelleþtirilmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yýlsonu mamül stoklarý normal/sýralý envanteri:");
            var r=new Random(); int i, j, ts1; double ds1, ds2=0; string dzg1;
            ArrayList envanter = new ArrayList();
            for(i=0;i<5;i++) {
                dzg1=""; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);}
                ds1=r.Next(10,1000)+r.Next(10,100)/100D;
                ts1=r.Next(1,1000);
                envanter.Add (new Mamül(dzg1, ds1, ts1));
                ds2+=(ts1*ds1);
             }
             i=0; foreach (Mamül m in envanter) Console.WriteLine ("{0}) {1}", ++i, m);
             Console.WriteLine ("\t\t\t\t       Genel toplam: {0,12:#,0.00} TL", ds2);
             envanter.Sort();
             Console.WriteLine ("\t==>A-Z sýralý envanter:");
             i=0; foreach (Mamül m in envanter) Console.WriteLine ("{0}) {1}", ++i, m);
             Console.WriteLine ("\t\t\t\t       Genel toplam: {0,12:#,0.00} TL", ds2);

            Console.WriteLine ("\nMaaþ'la artan sýralanan iþgören listesi:");
            ArrayList iþgören = new ArrayList();
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; Ýþgören iþg1 = new Ýþgören (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; Ýþgören iþg2 = new Ýþgören (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; Ýþgören iþg3 = new Ýþgören (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; Ýþgören iþg4 = new Ýþgören (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; Ýþgören iþg5 = new Ýþgören (dzg1, ds1);
            iþgören.Add (iþg1); iþgören.Add (iþg2); iþgören.Add (iþg3); iþgören.Add (iþg4); iþgören.Add (iþg5);
            Console.WriteLine ("\tÝlk iþgören listesi:"); ListeyiGöster ("iþgören", iþgören);
            if (iþgören.Contains (iþg3)) Console.WriteLine ("==>iþgören listesinin içerdiði iþg3'ün endeksi: {0}", iþgören.IndexOf (iþg3));
            iþgören.Remove (iþg3); Console.WriteLine ("\tiþg3 silinen iþgören listesi:"); ListeyiGöster ("iþgören", iþgören);
            iþgören.Insert (2, iþg3);
            iþgören.Sort(); Console.WriteLine ("\tArtan maaþ sýralý iþgören listesi:"); ListeyiGöster ("iþgören", iþgören);
            i = iþgören.BinarySearch (iþg5); if(i>=0) Console.WriteLine ("==>Maaþ sýralý listede aranan iþg5'in endeksi: " + i);
            ArrayList iþgören2 = iþgören.GetRange (1, 3); Console.WriteLine ("\tiþgören.GetRange (1,3) altlistesi:"); ListeyiGöster ("iþgören2", iþgören2);
            IEnumerator ie = iþgören.GetEnumerator();
            Console.WriteLine ("\tIEnumerator'lü iþgören listesi:"); while (ie.MoveNext()) Console.WriteLine (ie.Current);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}