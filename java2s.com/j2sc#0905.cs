// j2sc#0905.cs: Delege parametresi, gerid�n��� ve tipli delegeler �rne�i.

using System;
using System.Collections; //Hashtable i�in
using System.Collections.Generic; //List i�in
using System.Reflection; //MethodInfo i�in
namespace YetkiAktarma {
    delegate void DelegeA();
    public delegate void DelegeB();
    delegate void TipliDelege1<T> (T de�er);
    public delegate S TipliDelege2<T1, T2, T3, S> (T1 p1, T2 p2, T3 p3)
        where T1: struct
        where T2: struct
        where T3: struct
        where S:  struct;
    public delegate void TipliDelege3<T> (T prm);
    delegate void HesapDelegesi<T> (T tipleme, Decimal y�zde);
    delegate T TipliDelege4<T>();

    public delegate bool AnahtarY�netimi (string anahtar);
    public class Kontrol {
        Hashtable kontrolTablosu;
        public Kontrol() {kontrolTablosu = new Hashtable();} //Kurucu
        public void AnahtarY�neticisiniEkle (string anahtar, AnahtarY�netimi y�netici) {kontrolTablosu.Add (anahtar, y�netici);}
        public bool Anahtar�nKontrolu (string anahtar) {
            AnahtarY�netimi fonk = (AnahtarY�netimi)kontrolTablosu [anahtar];
            if (fonk == null) return false;
            return fonk (anahtar);
        }
    }
    public class Arg�man1Y�netimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Arg�man1Y�netimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class Arg�man2Y�netimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Arg�man2Y�netimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class Arg�man3Y�netimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Arg�man3Y�netimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class DelegeListesi<T> {
        private List<TipliDelege3<T> > liste = new List< TipliDelege3<T> >(); //Tipli delegeli liste tiplemesi
        public void Ekle (TipliDelege3<T> dlg) {liste.Add (dlg);}
        public void Delegeleri�a��r (T k) {foreach (TipliDelege3<T> td3 in liste) {td3 (k);}}
    }
    public class ��g�ren {
        public Decimal maa�;
        public ��g�ren (Decimal m) {maa� = m;} //Kurucu
        public void Maa��Hesapla (Decimal y�zde) {maa� *= (1 + y�zde);}
    }
    class Delege5 {
        static void Y�r�t5Kez (DelegeA d) {for(int i=1881;i<1938;i++) d();}
        public static DelegeB DelegelerYarat() {
            DelegeB delegeler = delegate {for(int i=0;i<5;i++) Console.WriteLine ("Anonim delegeyle: " + (i+1) + ".inci Selam");};
            return delegeler;
        }
        static public void Yaz (string s) {Console.WriteLine (s);}
        static public void B�y�kYaz (string s) {Console.WriteLine (s.ToUpper());}
        static public void K���kYaz (string s) {Console.WriteLine (s.ToLower());}
        public static double Topla (int d1, long d2, float d3) {return d1 + d2 + d3;}
        static void YazTs (int i) {Console.WriteLine ("{0,13:#,0}", i);}
        static void SonucuYaz<T> (TipliDelege4<T> fonk) {Console.WriteLine (fonk());}
        static void Main (string[] arg�manlar) {
            Console.Write ("Delege tiplemesi parametre olarak metoda aktar�labilir. Delegeye atanabilen <T> tipli �oklu/farkl� parametre ve sonucu aktar�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Parametrik anonim delegenin 1938-1881=57 kez i++ ile �a�r�lmas�");
            int i = 0, ts1, ts2;
            Y�r�t5Kez (delegate {i++;});
            Console.WriteLine ("Atat�rk 1938-1881={0} y�l ya�ad�.", i);

            Console.WriteLine ("\nAnahtarY�netimi delegesiyle girilen 3 arg�man�n do�ruluk kontrolu:");
            //Komut sat�r� arg�manlar�: Mahmut Nihat Yava� ==>j2sc#0906 Mahmut nihaT yav�ak (olarak komutla)
            Kontrol k = new Kontrol();
            k.AnahtarY�neticisiniEkle ("mahmut", new AnahtarY�netimi (Arg�man1Y�netimi.KontrolEt));
            k.AnahtarY�neticisiniEkle ("nihat", new AnahtarY�netimi (Arg�man2Y�netimi.KontrolEt));
            k.AnahtarY�neticisiniEkle ("yava�", new AnahtarY�netimi (Arg�man3Y�netimi.KontrolEt));
            for (i = 0; i < arg�manlar.Length; ++i) if (k.Anahtar�nKontrolu (arg�manlar [i].ToLower()) == false) Console.WriteLine ("Onaylanmayan anahtarkelime: {0}", arg�manlar [i]);

            Console.WriteLine ("\nYarat�lan 5 anonim delegeli sunumun gerid�n���:");
            DelegeB delegeler = DelegelerYarat();
            delegeler();

            Console.WriteLine ("\nString tiplemeli delegeyle 3 farkl� sunum:");
            TipliDelege1<string> td1 = Yaz; td1 +=B�y�kYaz; td1 +=K���kYaz;
            td1 ("M.Nihat Yava�");                              

            Console.WriteLine ("\nTipli delegeyle ts1+ls1+fs1 toplam�n�n sonu� double'la sunulmas�:");
            TipliDelege2<int, long, float, double> td2 = new TipliDelege2<int, long, float, double> (Topla);
            long ls1; float fs1; var r=new Random();
            for(i=0;i<5;i++) {
                ts1=r.Next(0,100); ls1=r.Next(0,100)*1L; fs1=r.Next(0,100)+r.Next(10,100)/100F;
                Console.WriteLine ("int({0}) + long({1}) + float({2}) = double({3})", ts1, ls1, fs1, td2 (ts1, ls1, fs1));
            }

            Console.WriteLine ("\nListeye eklenen tipli delegeyle rasgele tamsay� yazd�rma:");
            DelegeListesi<int> delegeler2 = new DelegeListesi<int>();
            delegeler2.Ekle (YazTs);
            for(i=0;i<5;i++) {ts1=r.Next(); delegeler2.Delegeleri�a��r (ts1);}

            Console.WriteLine ("\nMaa�l� i�g�ren listesiyle tipli delegenin art��l� maa� hesab�:");
            List<��g�ren> i�gListesi = new List<��g�ren>();
            decimal dsm1, dsm2;
            for(i=0;i<5;i++) {
                dsm1=r.Next(7852,100000)+r.Next(10,100)/100M;
                i�gListesi.Add (new ��g�ren (dsm1));
            }
            MethodInfo bilgi = typeof (��g�ren).GetMethod ("Maa��Hesapla", BindingFlags.Public | BindingFlags.Instance);
            HesapDelegesi<��g�ren> maa�Art��� = (HesapDelegesi<��g�ren>)Delegate.CreateDelegate (typeof (HesapDelegesi<��g�ren>), bilgi);
            foreach (��g�ren i�g in i�gListesi) {
                dsm1=r.Next(10,100)/100M; dsm2=i�g.maa�;
                maa�Art��� (i�g, (Decimal) dsm1);
                Console.WriteLine ("��plak maa�: {0};\tArt��: {1};\tArt��l� maa�: {2:#,0.00}", dsm2, dsm1, i�g.maa�);
            }

            Console.WriteLine ("\nGenel tipli anonim delegeyle tamsay� veya object d�nd�rme:");
            for(i=0;i<5;i++) {
                ts1=r.Next(); ts2=r.Next();
                SonucuYaz (delegate {if (ts1 > ts2) return ts1-ts2; return new object();});
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}