// j2sc#0901.cs: Delege fonksiyonla parametre-li/siz tekli/�oklu metot �a��rma �rne�i.

using System;
using System.Windows.Forms; //MessageBox.Show() i�in
namespace YetkiAktarma {
    delegate void �a��ranFonksiyon();
    delegate void ��rFonk (ref int x);
    delegate int ��rFonk2();
    public delegate string ��rFonk3();
    delegate string DelegeB (string dzg);
    public delegate int �arp�mDelegesi (ref short refSaya�);
    delegate void MesajDelegesi3 (string mesaj);
    class S�n�f1 {
       public void  statikOlmayanMetot() {Console.WriteLine ("statikOlmayanMetot() �a�r�ld�");}
       public static void statikMetot() {Console.WriteLine ("statikMetot() �a�r�ld�");}
    }
    public class Ki�i {
        private string ki�iAd�;
        private int ki�iYa��;
        private float maa��;
        public Ki�i (string a, int y, float m) {ki�iAd� = a; ki�iYa�� = y; maa��=m;}
        public string ki�iG�ster() {return (ki�iAd� + "'�n ya��: " + ki�iYa�� + ", maa��: " + maa�� + " TL'd�r.");}
    }
    public class Araba {
        private string arabaAd�;
        private int arabaYa��;
        private int azamiH�z�;
        public Araba (string a, int y, int h) {arabaAd� = a; arabaYa�� = y; azamiH�z�=h;}
        public string arabaG�ster() {return (arabaAd� + "'�n ya��: " + arabaYa�� + " ve azami h�z�: " + azamiH�z� + " km/s'd�r.");}
    }
    public class Makina {
        string ad;
        public Makina (string a) {ad = a;} //Kurucu
        public void ��lem (string mesaj) {Console.WriteLine ("Makina.��lem ({0}: {1})", ad, mesaj);}
    }
    class Delege {
        delegate int DelegeA (string dizge);
        delegate void ��lemY�netimi (string mesaj);
        delegate void MesajDelegesi (string msg);
        public delegate void MesajDelegesi2 (string msg);
        static int x=0;
        public static void ekle1 (ref int x) {x++;}
        public static void ekle2 (ref int x) {x += 2;}
        public static void ekle3 (ref int x) {x += 3;}
        public static int topla1() {x++; return x;}
        public static int topla2() {x += 2; return x;}
        public static int topla3() {x += 3; return x;}
        static int MetotA1 (string dzg) {Console.Write (dzg); return 1881;}
        static int MetotA2 (string dzg) {Console.Write (dzg); return 1938;}
        static public void ��lem (string mesaj) {Console.WriteLine ("\tDelege.��lem (\"{0}\")", mesaj);}
        static string bo�luklar�Tirele (string a) {Console.Write ("bo�luklar�Tirele(): {0}", a); return "Bo�luklar tirelendi";}
        static string bo�luklar�Sil (string a) {Console.Write ("bo�luklar�Sil(): {0}", a); return "Bo�luklar silindi";}
        static string dizgeyiTersle (string a) {Console.Write ("dizgeyiTersle(): {0}", a); return "Dizge terslendi";}
        public static int art�r (ref short i) {return i++;}
        static void UzunS�ren��lem (MesajDelegesi md) {
            for (int i = 0; i <= 100; i++) {if (i % 20 == 0) md (string.Format ("Tamamlanan i�lem y�zdesi: {0}%", i));}
        }
        static void MesajYaz (string m) {Console.WriteLine ("[MesajYaz] {0}", m);}
        public static void Yaz1 (String m) {Console.WriteLine ("1.{0}", m);}
        public static void Yaz2 (String m) {Console.WriteLine ("1.{0}; 2.{0}", m);}
        public static void Yaz3 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}", m);}
        public static void Yaz4 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}; 4.{0}", m);}
        public static void Yaz5 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}; 4.{0}; 5.{0}", m);}
        private static void YazWin (string mesaj) {MessageBox.Show (mesaj);}
        static void Main() {
            Console.Write ("Delege gerid�n��-tipli (parametreli) bir metodun �oklu referans metotlar� �oklu kereler �a��rabilmesidir. Delegeye ilk atama sonras� += (ayn�/farkl�) eklemeler yap�labilir. Delege fonksiyonuna atama = ve += ile yap�ld��� gibi 'new DlgFnk(Metot)'la da yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Statik olan/olmayan �oklu metotlar�n delegelendirilmesi ve �a�r�lmalar�:");
            int i, ts1, ts2; float fs1; var r=new Random();
            S�n�f1 s1 = new S�n�f1();
            �a��ranFonksiyon delegeFonksiyon;
            //delegeFonksiyon = s1.statikOlmayanMetot;
            delegeFonksiyon = S�n�f1.statikMetot;
            for(i=0; i<3;i++) {
                delegeFonksiyon += s1.statikOlmayanMetot;
                delegeFonksiyon += S�n�f1.statikMetot;
            }
            delegeFonksiyon();

            Console.WriteLine ("\nParametreli ref ve parametresiz delegeli �oklu metotlarda i�lenmesi:");
            ��rFonk dlgFonk = ekle1; ��rFonk2 dlgFonk2 = topla1;
            for(i=0; i<5;i++) {
                dlgFonk += ekle3; dlgFonk += ekle2; dlgFonk += ekle1;
                dlgFonk2+=topla3; dlgFonk2+=topla2; dlgFonk2+=topla1;
            }
            ts1=r.Next(0,100); Console.WriteLine ("Rasgele ts1 = {0};\tOrijinal x = {1}", ts1, x);
            dlgFonk (ref ts1); //Toplam ts1+=31 [=1+5*(3+2+1)]
            Console.WriteLine ("ref parametreli delegelenen ts1 = {0};\tparametresiz dlgFonk2() = {1}", ts1, dlgFonk2());

            Console.WriteLine ("\nKi�i ve araba bilgilerini ayn� delegeleyip g�sterme:");
            Ki�i ki�i; Araba araba; ��rFonk3 dlgFonk3; string g�ster;
            string[] adlar=new string[]{"Canan","Y�cel","Hilal","Fatih","Belk�s"};
            string[] arabalar=new string[]{"Audi","Pegeaut","Skoda","Toyoto","Fiat"};
            for(i=0; i<5;i++) {
                ts1=r.Next(18,85); fs1=r.Next(7800,100000)+r.Next(10,100)/100F; ki�i=new Ki�i (adlar [i], ts1, fs1);
                dlgFonk3=new ��rFonk3 (ki�i.ki�iG�ster); g�ster=dlgFonk3();
                Console.WriteLine ("Ki�i bilgileri = [" + g�ster + "]");
                ts1=r.Next(0,25); ts2=r.Next(150,300); araba=new Araba (arabalar [i], ts1, ts2);
                dlgFonk3=new ��rFonk3 (araba.arabaG�ster); g�ster=dlgFonk3();
                Console.WriteLine ("\tAraba bilgileri = [" + g�ster + "]");
            }

            Console.WriteLine ("\nDelege fonks'a metot atama, parametre g�nderme ve gerid�n�� alma:");
            DelegeA dA1 = new DelegeA (MetotA1);
            DelegeA dA2 = new DelegeA (MetotA2);
            ts1 = dA1 ("Atat�rk'�n do�um y�l�: "); Console.WriteLine (ts1);
            ts2 = dA2 ("Atat�rk'�n vefat y�l�: "); Console.WriteLine (ts2);
            Console.WriteLine ("Aat�rk {0} y�l ya�ad�.", ts2-ts1);

            Console.WriteLine ("\nDelegeyle 2 ayr� s�n�f�n ayn� adl� metodunu parametreli �a��rma:");
            Makina mkn = new Makina ("Bilgisayar");
            ��lemY�netimi iy = new ��lemY�netimi (mkn.��lem);
            iy = (��lemY�netimi) Delegate.Combine (iy, new ��lemY�netimi (��lem));
            iy ("Kodla"); iy ("Derle"); iy ("Ko�tur"); iy ("G�ncelle");

            Console.WriteLine ("\nDelegeye tek tek parametreli metot atama ve gerid�n��� g�sterme:");
            Console.WriteLine ("\tDo�rudan metotlar� atayarak delegeleme:");
            DelegeB dB = bo�luklar�Tirele; g�ster = dB ("�lk dizge i�lemi."); Console.WriteLine ("\t{0}", g�ster);
            dB = bo�luklar�Sil; g�ster = dB ("�kinci dizge i�lemi.");  Console.WriteLine ("\t{0}", g�ster);
            dB = dizgeyiTersle; g�ster = dB ("���nc� dizge i�lemi."); Console.WriteLine ("\t{0}", g�ster);
            Console.WriteLine ("\tMetotlu yeni delege yaratarak delegeleme:");
            dB = new DelegeB (bo�luklar�Tirele); g�ster = dB ("�lk dizge i�lemi."); Console.WriteLine ("\t{0}", g�ster);
            dB = new DelegeB (bo�luklar�Sil); g�ster = dB ("�kinci dizge i�lemi.");  Console.WriteLine ("\t{0}", g�ster);
            dB = new DelegeB (dizgeyiTersle); g�ster = dB ("���nc� dizge i�lemi."); Console.WriteLine ("\t{0}", g�ster);

            Console.WriteLine ("\nParametrik delegeyle azami (long) fakt�ryeli hesaplama:");
            �arp�mDelegesi[] art�r�mlar = {art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r,art�r};
            �arp�mDelegesi dlg = (�arp�mDelegesi)�arp�mDelegesi.Combine (art�r�mlar);
            long sonu� = 1; short saya� = 1;
            foreach (�arp�mDelegesi �d in dlg.GetInvocationList()) {sonu� = sonu� * �d (ref saya�); if(saya�!=dlg.GetInvocationList().Length+1) Console.Write (sonu�+", "); else Console.Write (sonu�+";");}
            Console.WriteLine("\t{0}'nin fakt�ryeli: [{1}]'dir.", dlg.GetInvocationList().Length, sonu�);

            Console.WriteLine ("\nDelegeyle tamamlanan i�lem mesajlar�n�n sunulmas�:");
            MesajDelegesi md = new MesajDelegesi (MesajYaz);
            UzunS�ren��lem (md);

            Console.WriteLine ("\n'new Delege(Metot)'la mesajlar�n artan tekarl� yaz�lmas�:");
            g�ster = "Delegelere Selam";
            MesajDelegesi2 d2 = new MesajDelegesi2 (Yaz1); d2 (g�ster);
            d2 = new MesajDelegesi2 (Yaz2); d2 (g�ster);
            d2 = new MesajDelegesi2 (Yaz3); d2 (g�ster);
            d2 = new MesajDelegesi2 (Yaz4); d2 (g�ster);
            d2 = new MesajDelegesi2 (Yaz5); d2 (g�ster);

            Console.WriteLine ("\nArg�manl� komut sat�rla pencerede, arg�mans�zda dos'ta mesaj:");
            MesajDelegesi3 d3; 
            if (Environment.GetCommandLineArgs().Length > 1) d3 = YazWin;
            else d3 = Console.WriteLine;
            for(i=0; i<5;i++) {d3 ("Merhaba, delgeler d�nyas�!");}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}