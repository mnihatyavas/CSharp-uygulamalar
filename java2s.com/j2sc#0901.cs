// j2sc#0901.cs: Delege fonksiyonla parametre-li/siz tekli/çoklu metot çaðýrma örneði.

using System;
using System.Windows.Forms; //MessageBox.Show() için
namespace YetkiAktarma {
    delegate void ÇaðýranFonksiyon();
    delegate void çðrFonk (ref int x);
    delegate int çðrFonk2();
    public delegate string ÇðrFonk3();
    delegate string DelegeB (string dzg);
    public delegate int ÇarpýmDelegesi (ref short refSayaç);
    delegate void MesajDelegesi3 (string mesaj);
    class Sýnýf1 {
       public void  statikOlmayanMetot() {Console.WriteLine ("statikOlmayanMetot() çaðrýldý");}
       public static void statikMetot() {Console.WriteLine ("statikMetot() çaðrýldý");}
    }
    public class Kiþi {
        private string kiþiAdý;
        private int kiþiYaþý;
        private float maaþý;
        public Kiþi (string a, int y, float m) {kiþiAdý = a; kiþiYaþý = y; maaþý=m;}
        public string kiþiGöster() {return (kiþiAdý + "'ýn yaþý: " + kiþiYaþý + ", maaþý: " + maaþý + " TL'dýr.");}
    }
    public class Araba {
        private string arabaAdý;
        private int arabaYaþý;
        private int azamiHýzý;
        public Araba (string a, int y, int h) {arabaAdý = a; arabaYaþý = y; azamiHýzý=h;}
        public string arabaGöster() {return (arabaAdý + "'ýn yaþý: " + arabaYaþý + " ve azami hýzý: " + azamiHýzý + " km/s'dýr.");}
    }
    public class Makina {
        string ad;
        public Makina (string a) {ad = a;} //Kurucu
        public void Ýþlem (string mesaj) {Console.WriteLine ("Makina.Ýþlem ({0}: {1})", ad, mesaj);}
    }
    class Delege {
        delegate int DelegeA (string dizge);
        delegate void ÝþlemYönetimi (string mesaj);
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
        static public void Ýþlem (string mesaj) {Console.WriteLine ("\tDelege.Ýþlem (\"{0}\")", mesaj);}
        static string boþluklarýTirele (string a) {Console.Write ("boþluklarýTirele(): {0}", a); return "Boþluklar tirelendi";}
        static string boþluklarýSil (string a) {Console.Write ("boþluklarýSil(): {0}", a); return "Boþluklar silindi";}
        static string dizgeyiTersle (string a) {Console.Write ("dizgeyiTersle(): {0}", a); return "Dizge terslendi";}
        public static int artýr (ref short i) {return i++;}
        static void UzunSürenÝþlem (MesajDelegesi md) {
            for (int i = 0; i <= 100; i++) {if (i % 20 == 0) md (string.Format ("Tamamlanan iþlem yüzdesi: {0}%", i));}
        }
        static void MesajYaz (string m) {Console.WriteLine ("[MesajYaz] {0}", m);}
        public static void Yaz1 (String m) {Console.WriteLine ("1.{0}", m);}
        public static void Yaz2 (String m) {Console.WriteLine ("1.{0}; 2.{0}", m);}
        public static void Yaz3 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}", m);}
        public static void Yaz4 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}; 4.{0}", m);}
        public static void Yaz5 (String m) {Console.WriteLine ("1.{0}; 2.{0}; 3.{0}; 4.{0}; 5.{0}", m);}
        private static void YazWin (string mesaj) {MessageBox.Show (mesaj);}
        static void Main() {
            Console.Write ("Delege geridönüþ-tipli (parametreli) bir metodun çoklu referans metotlarý çoklu kereler çaðýrabilmesidir. Delegeye ilk atama sonrasý += (ayný/farklý) eklemeler yapýlabilir. Delege fonksiyonuna atama = ve += ile yapýldýðý gibi 'new DlgFnk(Metot)'la da yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Statik olan/olmayan çoklu metotlarýn delegelendirilmesi ve çaðrýlmalarý:");
            int i, ts1, ts2; float fs1; var r=new Random();
            Sýnýf1 s1 = new Sýnýf1();
            ÇaðýranFonksiyon delegeFonksiyon;
            //delegeFonksiyon = s1.statikOlmayanMetot;
            delegeFonksiyon = Sýnýf1.statikMetot;
            for(i=0; i<3;i++) {
                delegeFonksiyon += s1.statikOlmayanMetot;
                delegeFonksiyon += Sýnýf1.statikMetot;
            }
            delegeFonksiyon();

            Console.WriteLine ("\nParametreli ref ve parametresiz delegeli çoklu metotlarda iþlenmesi:");
            çðrFonk dlgFonk = ekle1; çðrFonk2 dlgFonk2 = topla1;
            for(i=0; i<5;i++) {
                dlgFonk += ekle3; dlgFonk += ekle2; dlgFonk += ekle1;
                dlgFonk2+=topla3; dlgFonk2+=topla2; dlgFonk2+=topla1;
            }
            ts1=r.Next(0,100); Console.WriteLine ("Rasgele ts1 = {0};\tOrijinal x = {1}", ts1, x);
            dlgFonk (ref ts1); //Toplam ts1+=31 [=1+5*(3+2+1)]
            Console.WriteLine ("ref parametreli delegelenen ts1 = {0};\tparametresiz dlgFonk2() = {1}", ts1, dlgFonk2());

            Console.WriteLine ("\nKiþi ve araba bilgilerini ayný delegeleyip gösterme:");
            Kiþi kiþi; Araba araba; ÇðrFonk3 dlgFonk3; string göster;
            string[] adlar=new string[]{"Canan","Yücel","Hilal","Fatih","Belkýs"};
            string[] arabalar=new string[]{"Audi","Pegeaut","Skoda","Toyoto","Fiat"};
            for(i=0; i<5;i++) {
                ts1=r.Next(18,85); fs1=r.Next(7800,100000)+r.Next(10,100)/100F; kiþi=new Kiþi (adlar [i], ts1, fs1);
                dlgFonk3=new ÇðrFonk3 (kiþi.kiþiGöster); göster=dlgFonk3();
                Console.WriteLine ("Kiþi bilgileri = [" + göster + "]");
                ts1=r.Next(0,25); ts2=r.Next(150,300); araba=new Araba (arabalar [i], ts1, ts2);
                dlgFonk3=new ÇðrFonk3 (araba.arabaGöster); göster=dlgFonk3();
                Console.WriteLine ("\tAraba bilgileri = [" + göster + "]");
            }

            Console.WriteLine ("\nDelege fonks'a metot atama, parametre gönderme ve geridönüþ alma:");
            DelegeA dA1 = new DelegeA (MetotA1);
            DelegeA dA2 = new DelegeA (MetotA2);
            ts1 = dA1 ("Atatürk'ün doðum yýlý: "); Console.WriteLine (ts1);
            ts2 = dA2 ("Atatürk'ün vefat yýlý: "); Console.WriteLine (ts2);
            Console.WriteLine ("Aatürk {0} yýl yaþadý.", ts2-ts1);

            Console.WriteLine ("\nDelegeyle 2 ayrý sýnýfýn ayný adlý metodunu parametreli çaðýrma:");
            Makina mkn = new Makina ("Bilgisayar");
            ÝþlemYönetimi iy = new ÝþlemYönetimi (mkn.Ýþlem);
            iy = (ÝþlemYönetimi) Delegate.Combine (iy, new ÝþlemYönetimi (Ýþlem));
            iy ("Kodla"); iy ("Derle"); iy ("Koþtur"); iy ("Güncelle");

            Console.WriteLine ("\nDelegeye tek tek parametreli metot atama ve geridönüþü gösterme:");
            Console.WriteLine ("\tDoðrudan metotlarý atayarak delegeleme:");
            DelegeB dB = boþluklarýTirele; göster = dB ("Ýlk dizge iþlemi."); Console.WriteLine ("\t{0}", göster);
            dB = boþluklarýSil; göster = dB ("Ýkinci dizge iþlemi.");  Console.WriteLine ("\t{0}", göster);
            dB = dizgeyiTersle; göster = dB ("Üçüncü dizge iþlemi."); Console.WriteLine ("\t{0}", göster);
            Console.WriteLine ("\tMetotlu yeni delege yaratarak delegeleme:");
            dB = new DelegeB (boþluklarýTirele); göster = dB ("Ýlk dizge iþlemi."); Console.WriteLine ("\t{0}", göster);
            dB = new DelegeB (boþluklarýSil); göster = dB ("Ýkinci dizge iþlemi.");  Console.WriteLine ("\t{0}", göster);
            dB = new DelegeB (dizgeyiTersle); göster = dB ("Üçüncü dizge iþlemi."); Console.WriteLine ("\t{0}", göster);

            Console.WriteLine ("\nParametrik delegeyle azami (long) faktöryeli hesaplama:");
            ÇarpýmDelegesi[] artýrýmlar = {artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr,artýr};
            ÇarpýmDelegesi dlg = (ÇarpýmDelegesi)ÇarpýmDelegesi.Combine (artýrýmlar);
            long sonuç = 1; short sayaç = 1;
            foreach (ÇarpýmDelegesi çd in dlg.GetInvocationList()) {sonuç = sonuç * çd (ref sayaç); if(sayaç!=dlg.GetInvocationList().Length+1) Console.Write (sonuç+", "); else Console.Write (sonuç+";");}
            Console.WriteLine("\t{0}'nin faktöryeli: [{1}]'dir.", dlg.GetInvocationList().Length, sonuç);

            Console.WriteLine ("\nDelegeyle tamamlanan iþlem mesajlarýnýn sunulmasý:");
            MesajDelegesi md = new MesajDelegesi (MesajYaz);
            UzunSürenÝþlem (md);

            Console.WriteLine ("\n'new Delege(Metot)'la mesajlarýn artan tekarlý yazýlmasý:");
            göster = "Delegelere Selam";
            MesajDelegesi2 d2 = new MesajDelegesi2 (Yaz1); d2 (göster);
            d2 = new MesajDelegesi2 (Yaz2); d2 (göster);
            d2 = new MesajDelegesi2 (Yaz3); d2 (göster);
            d2 = new MesajDelegesi2 (Yaz4); d2 (göster);
            d2 = new MesajDelegesi2 (Yaz5); d2 (göster);

            Console.WriteLine ("\nArgümanlý komut satýrla pencerede, argümansýzda dos'ta mesaj:");
            MesajDelegesi3 d3; 
            if (Environment.GetCommandLineArgs().Length > 1) d3 = YazWin;
            else d3 = Console.WriteLine;
            for(i=0; i<5;i++) {d3 ("Merhaba, delgeler dünyasý!");}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}