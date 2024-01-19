// j2sc#1102c.cs: �ok de�erli nesnel liste elemanlar�n� girme, s�ralama ve sunma �rne�i.

using System;
using System.Collections;
namespace VeriYap�lar� {
    class Mam�l : IComparable {
        string ad;
        double maliyet;
        int mevcut;
        public Mam�l (string a, double ml, int mv) {ad = a; maliyet = ml; mevcut = mv;} //Kurucu
        public override string ToString() {return String.Format ("{0,-7}Maliyet: {1,6} TL   Mevcut: {2,3}   Toplam: {3,12:#,0.00} TL", ad, maliyet, mevcut, maliyet * mevcut);}
        public int CompareTo (object ns) {return ad.CompareTo (((Mam�l)ns).ad);}
    }
    class ��g�ren : IComparable {
        string isim;
        double maa�;
        public ��g�ren (string isim, double maa�) {this.isim = isim; this.maa� = maa�;}
        public override string ToString() {return String.Format ("�sim: {0},\tMaa�: {1,8:#,0.00} TL", isim, maa�);}
        public int K�yas (object ns1, object ns2) {
            if (((��g�ren)ns1).maa� < ((��g�ren)ns2).maa�) {return -1;
            }else if (((��g�ren)ns1).maa� > ((��g�ren)ns2).maa�) {return 1;
            }else {return 0;}
        }
        public int CompareTo (object ns) {return K�yas (this, ns);}
    }
    class VeriYap�s�2C {
        public static void ListeyiG�ster (string ad, ArrayList liste) {for(int i = 0; i < liste.Count; i++) Console.WriteLine (ad + "[" + i + "] = " + liste [i]);}
        static void Main() {
            Console.Write ("Nesne olarak �oklu alanl� listenin s�ralanabilmesi i�in temel IComparable'in CompareTo() metodu tek yada �oklu anahtarla �zelle�tirilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Y�lsonu mam�l stoklar� normal/s�ral� envanteri:");
            var r=new Random(); int i, j, ts1; double ds1, ds2=0; string dzg1;
            ArrayList envanter = new ArrayList();
            for(i=0;i<5;i++) {
                dzg1=""; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);}
                ds1=r.Next(10,1000)+r.Next(10,100)/100D;
                ts1=r.Next(1,1000);
                envanter.Add (new Mam�l(dzg1, ds1, ts1));
                ds2+=(ts1*ds1);
             }
             i=0; foreach (Mam�l m in envanter) Console.WriteLine ("{0}) {1}", ++i, m);
             Console.WriteLine ("\t\t\t\t       Genel toplam: {0,12:#,0.00} TL", ds2);
             envanter.Sort();
             Console.WriteLine ("\t==>A-Z s�ral� envanter:");
             i=0; foreach (Mam�l m in envanter) Console.WriteLine ("{0}) {1}", ++i, m);
             Console.WriteLine ("\t\t\t\t       Genel toplam: {0,12:#,0.00} TL", ds2);

            Console.WriteLine ("\nMaa�'la artan s�ralanan i�g�ren listesi:");
            ArrayList i�g�ren = new ArrayList();
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; ��g�ren i�g1 = new ��g�ren (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; ��g�ren i�g2 = new ��g�ren (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; ��g�ren i�g3 = new ��g�ren (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; ��g�ren i�g4 = new ��g�ren (dzg1, ds1);
            dzg1=""; for(j=0;j<4;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} dzg1+=" "; for(j=0;j<5;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65);} ds1=r.Next(7500,100000)+r.Next(10,100)/100D; ��g�ren i�g5 = new ��g�ren (dzg1, ds1);
            i�g�ren.Add (i�g1); i�g�ren.Add (i�g2); i�g�ren.Add (i�g3); i�g�ren.Add (i�g4); i�g�ren.Add (i�g5);
            Console.WriteLine ("\t�lk i�g�ren listesi:"); ListeyiG�ster ("i�g�ren", i�g�ren);
            if (i�g�ren.Contains (i�g3)) Console.WriteLine ("==>i�g�ren listesinin i�erdi�i i�g3'�n endeksi: {0}", i�g�ren.IndexOf (i�g3));
            i�g�ren.Remove (i�g3); Console.WriteLine ("\ti�g3 silinen i�g�ren listesi:"); ListeyiG�ster ("i�g�ren", i�g�ren);
            i�g�ren.Insert (2, i�g3);
            i�g�ren.Sort(); Console.WriteLine ("\tArtan maa� s�ral� i�g�ren listesi:"); ListeyiG�ster ("i�g�ren", i�g�ren);
            i = i�g�ren.BinarySearch (i�g5); if(i>=0) Console.WriteLine ("==>Maa� s�ral� listede aranan i�g5'in endeksi: " + i);
            ArrayList i�g�ren2 = i�g�ren.GetRange (1, 3); Console.WriteLine ("\ti�g�ren.GetRange (1,3) altlistesi:"); ListeyiG�ster ("i�g�ren2", i�g�ren2);
            IEnumerator ie = i�g�ren.GetEnumerator();
            Console.WriteLine ("\tIEnumerator'l� i�g�ren listesi:"); while (ie.MoveNext()) Console.WriteLine (ie.Current);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}