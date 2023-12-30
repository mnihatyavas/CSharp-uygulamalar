// j2sc#0905.cs: Delege parametresi, geridönüþü ve tipli delegeler örneði.

using System;
using System.Collections; //Hashtable için
using System.Collections.Generic; //List için
using System.Reflection; //MethodInfo için
namespace YetkiAktarma {
    delegate void DelegeA();
    public delegate void DelegeB();
    delegate void TipliDelege1<T> (T deðer);
    public delegate S TipliDelege2<T1, T2, T3, S> (T1 p1, T2 p2, T3 p3)
        where T1: struct
        where T2: struct
        where T3: struct
        where S:  struct;
    public delegate void TipliDelege3<T> (T prm);
    delegate void HesapDelegesi<T> (T tipleme, Decimal yüzde);
    delegate T TipliDelege4<T>();

    public delegate bool AnahtarYönetimi (string anahtar);
    public class Kontrol {
        Hashtable kontrolTablosu;
        public Kontrol() {kontrolTablosu = new Hashtable();} //Kurucu
        public void AnahtarYöneticisiniEkle (string anahtar, AnahtarYönetimi yönetici) {kontrolTablosu.Add (anahtar, yönetici);}
        public bool AnahtarýnKontrolu (string anahtar) {
            AnahtarYönetimi fonk = (AnahtarYönetimi)kontrolTablosu [anahtar];
            if (fonk == null) return false;
            return fonk (anahtar);
        }
    }
    public class Argüman1Yönetimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Argüman1Yönetimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class Argüman2Yönetimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Argüman2Yönetimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class Argüman3Yönetimi {
        public static bool KontrolEt (string dzg) {Console.WriteLine ("Onaylanan Argüman3Yönetimi.KontrolEt(): {0}", dzg); return true;}
    }
    public class DelegeListesi<T> {
        private List<TipliDelege3<T> > liste = new List< TipliDelege3<T> >(); //Tipli delegeli liste tiplemesi
        public void Ekle (TipliDelege3<T> dlg) {liste.Add (dlg);}
        public void DelegeleriÇaðýr (T k) {foreach (TipliDelege3<T> td3 in liste) {td3 (k);}}
    }
    public class Ýþgören {
        public Decimal maaþ;
        public Ýþgören (Decimal m) {maaþ = m;} //Kurucu
        public void MaaþýHesapla (Decimal yüzde) {maaþ *= (1 + yüzde);}
    }
    class Delege5 {
        static void Yürüt5Kez (DelegeA d) {for(int i=1881;i<1938;i++) d();}
        public static DelegeB DelegelerYarat() {
            DelegeB delegeler = delegate {for(int i=0;i<5;i++) Console.WriteLine ("Anonim delegeyle: " + (i+1) + ".inci Selam");};
            return delegeler;
        }
        static public void Yaz (string s) {Console.WriteLine (s);}
        static public void BüyükYaz (string s) {Console.WriteLine (s.ToUpper());}
        static public void KüçükYaz (string s) {Console.WriteLine (s.ToLower());}
        public static double Topla (int d1, long d2, float d3) {return d1 + d2 + d3;}
        static void YazTs (int i) {Console.WriteLine ("{0,13:#,0}", i);}
        static void SonucuYaz<T> (TipliDelege4<T> fonk) {Console.WriteLine (fonk());}
        static void Main (string[] argümanlar) {
            Console.Write ("Delege tiplemesi parametre olarak metoda aktarýlabilir. Delegeye atanabilen <T> tipli çoklu/farklý parametre ve sonucu aktarýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Parametrik anonim delegenin 1938-1881=57 kez i++ ile çaðrýlmasý");
            int i = 0, ts1, ts2;
            Yürüt5Kez (delegate {i++;});
            Console.WriteLine ("Atatürk 1938-1881={0} yýl yaþadý.", i);

            Console.WriteLine ("\nAnahtarYönetimi delegesiyle girilen 3 argümanýn doðruluk kontrolu:");
            //Komut satýrý argümanlarý: Mahmut Nihat Yavaþ ==>j2sc#0906 Mahmut nihaT yavþak (olarak komutla)
            Kontrol k = new Kontrol();
            k.AnahtarYöneticisiniEkle ("mahmut", new AnahtarYönetimi (Argüman1Yönetimi.KontrolEt));
            k.AnahtarYöneticisiniEkle ("nihat", new AnahtarYönetimi (Argüman2Yönetimi.KontrolEt));
            k.AnahtarYöneticisiniEkle ("yavaþ", new AnahtarYönetimi (Argüman3Yönetimi.KontrolEt));
            for (i = 0; i < argümanlar.Length; ++i) if (k.AnahtarýnKontrolu (argümanlar [i].ToLower()) == false) Console.WriteLine ("Onaylanmayan anahtarkelime: {0}", argümanlar [i]);

            Console.WriteLine ("\nYaratýlan 5 anonim delegeli sunumun geridönüþü:");
            DelegeB delegeler = DelegelerYarat();
            delegeler();

            Console.WriteLine ("\nString tiplemeli delegeyle 3 farklý sunum:");
            TipliDelege1<string> td1 = Yaz; td1 +=BüyükYaz; td1 +=KüçükYaz;
            td1 ("M.Nihat Yavaþ");                              

            Console.WriteLine ("\nTipli delegeyle ts1+ls1+fs1 toplamýnýn sonuç double'la sunulmasý:");
            TipliDelege2<int, long, float, double> td2 = new TipliDelege2<int, long, float, double> (Topla);
            long ls1; float fs1; var r=new Random();
            for(i=0;i<5;i++) {
                ts1=r.Next(0,100); ls1=r.Next(0,100)*1L; fs1=r.Next(0,100)+r.Next(10,100)/100F;
                Console.WriteLine ("int({0}) + long({1}) + float({2}) = double({3})", ts1, ls1, fs1, td2 (ts1, ls1, fs1));
            }

            Console.WriteLine ("\nListeye eklenen tipli delegeyle rasgele tamsayý yazdýrma:");
            DelegeListesi<int> delegeler2 = new DelegeListesi<int>();
            delegeler2.Ekle (YazTs);
            for(i=0;i<5;i++) {ts1=r.Next(); delegeler2.DelegeleriÇaðýr (ts1);}

            Console.WriteLine ("\nMaaþlý iþgören listesiyle tipli delegenin artýþlý maaþ hesabý:");
            List<Ýþgören> iþgListesi = new List<Ýþgören>();
            decimal dsm1, dsm2;
            for(i=0;i<5;i++) {
                dsm1=r.Next(7852,100000)+r.Next(10,100)/100M;
                iþgListesi.Add (new Ýþgören (dsm1));
            }
            MethodInfo bilgi = typeof (Ýþgören).GetMethod ("MaaþýHesapla", BindingFlags.Public | BindingFlags.Instance);
            HesapDelegesi<Ýþgören> maaþArtýþý = (HesapDelegesi<Ýþgören>)Delegate.CreateDelegate (typeof (HesapDelegesi<Ýþgören>), bilgi);
            foreach (Ýþgören iþg in iþgListesi) {
                dsm1=r.Next(10,100)/100M; dsm2=iþg.maaþ;
                maaþArtýþý (iþg, (Decimal) dsm1);
                Console.WriteLine ("Çýplak maaþ: {0};\tArtýþ: {1};\tArtýþlý maaþ: {2:#,0.00}", dsm2, dsm1, iþg.maaþ);
            }

            Console.WriteLine ("\nGenel tipli anonim delegeyle tamsayý veya object döndürme:");
            for(i=0;i<5;i++) {
                ts1=r.Next(); ts2=r.Next();
                SonucuYaz (delegate {if (ts1 > ts2) return ts1-ts2; return new object();});
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}