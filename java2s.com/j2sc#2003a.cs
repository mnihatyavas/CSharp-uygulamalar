// j2sc#2003a.cs: Ardýþýk main() senkron ve asenkron 'new Thread()' ile 'IAsyncResult dlg.Begin/EndInvoke()' örneði.

using System;
using System.Runtime.CompilerServices; //MethodImpl için
using System.Threading;
using System.IO; //FileStream için
namespace Sicimler {
    public delegate int ÝkiliToplama (int x, int y);
    delegate void FonksiyonÇaðrýsý (string dizge);
    public delegate string AraçBakým (Araç detaylama);
    public class Araç{}
    class SenkronAsenkron {
        private static int yýl = 1881;
        private static object nesne = new object();
        static int Topla (int x, int y) {
            Console.WriteLine ("'(new Thread(metot)) Sicim'le yürütülmeyen Topla()'nýn sicim no: {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep (500);
            return x + y;
        }
        static int sayaç = 0;
        public static void Birartýr() {
            try {
                while (sayaç < 20) {
                    int aracý = sayaç;
                    aracý++;
                    Thread.Sleep (5);
                    sayaç = aracý;
                    Console.WriteLine ("Sicim{0}.Birartýr(): {1}", Thread.CurrentThread.Name, sayaç);
                }
            }catch (ThreadInterruptedException) {Console.WriteLine ("Sicim{0} kýrýldý! Kapanýþ temizliði...", Thread.CurrentThread.Name);
            }finally {Console.WriteLine ("Sicim{0} Sonlanýyor.", Thread.CurrentThread.Name);}
        }
        static FileStream dosyaAkýþ = new FileStream ("mny.dat", FileMode.Create, FileAccess.ReadWrite);
        static byte[] byteDizi = new byte [256];
        static IAsyncResult asenkSonuçArayüz = null;
        static AsyncCallback dosyaOkumaÇaðrýsý = new AsyncCallback (dosyaOkununca);
        public static void dosyaOkununca (IAsyncResult asenkSonuç) {
            sayaç=(int)dosyaAkýþ.EndRead (asenkSonuç);
            Console.WriteLine ("mny.dat'dan byteDizi'ye okunan byte sayýsý: {0}", sayaç);
            for (int i = 0; i < 256; i++) {if (byteDizi [i] != (byte)i) {Console.WriteLine ("mny.dat dosyasýndan okunan {0}.nci byte hatalý.", i); nesne="hata";} continue;}
            if(nesne.ToString() != "hata") Console.WriteLine ("mny.dat dosyasýndan okunan {0} adet byte hatasýz.", sayaç);
        }
        public static void MesajýYazÇaðrýsý (string dzg) {
            FonksiyonÇaðrýsý fonk = new FonksiyonÇaðrýsý(Console.WriteLine);
            fonk.BeginInvoke (dzg, new AsyncCallback (MesajýYaz), fonk);
        }
        public static void MesajýYaz (IAsyncResult asenkSonuç) {
            Console.WriteLine ("**MesajýYaz() metodu içi**");
            FonksiyonÇaðrýsý fonk = (FonksiyonÇaðrýsý)asenkSonuç.AsyncState;
            fonk.EndInvoke (asenkSonuç);
        }
        delegate int Delegem (string s, ref int a, ref int b);
        static int Metodum (string s, ref int a, ref int b) {
            a = 1881; b = 1938;
            Console.WriteLine ("Metodum() ateþlendi!..");
            return 20240911;
        }
        public delegate double MatMetotDelegesi (double ds);
        public static void MatMetotÇaðrýsý (MatMetotDelegesi fonk, double ilk, double son, double artýþ) {
            AsyncCallback acb = new AsyncCallback (MatMetot);
            while (ilk <= son) {
                Console.WriteLine ("Math.Sin({0}) = sonuç?", ilk);
                fonk.BeginInvoke (ilk*Math.PI/180, acb, fonk);
                ilk += artýþ;
            }
        }
        public static void MatMetot (IAsyncResult iar) {
            MatMetotDelegesi dlg = (MatMetotDelegesi)iar.AsyncState;
            double sonuç = dlg.EndInvoke (iar); Thread.Sleep (100);
            Console.WriteLine ("Fonksiyon sonucu = {0}", sonuç);
        }
        private delegate Decimal Vergi (decimal oran, decimal matrah); //Asenkron çaðrý delegesi
        private static Decimal VergiyiHesapla (decimal o, decimal m) {
            Console.WriteLine ("{0} nolu sicimle vergi hesaplanýyor...", Thread.CurrentThread.GetHashCode());
            //Thread.Sleep (2000);
            return m*o;
        }
        private static void VergiBildirimi (IAsyncResult iar) {
            Vergi vrg = (Vergi)iar.AsyncState;
            Console.WriteLine ("\tÖdenecek vergi: {0:#,0.00} TL", vrg.EndInvoke (iar));
        }
        public static string AraçDetaylama (Araç oto) {
            Console.WriteLine ("Aracýn detaylý bakýmý sicim#{0}'de yapýlýyor...", Thread.CurrentThread.GetHashCode());
            Thread.Sleep (1000);
            return "Arabanýz kullanýmýza hazýr, efendim!";
        }
        [MethodImpl (MethodImplOptions.Synchronized)]
        static void Main() {
            Console.Write ("Senkron iþlemler tek Main() sicimle ardýþýk kod akýþýný takip eder. 'new Thread(metot)' veya 'IAsyncResult iar = delege.Begin/EndInvoke(argümanlar)' ve 'return iarMesaj' ise arkazeminde çoklu, farklý, zamanpaylaþýmlý asenkron görev yaparlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Senkron ardýþýk kodlamalarla yýllar ve toplamlar:");
            int i, ts1, ts2, toplam; var r=new Random();
            for(i=0;i<=57;i++) {nesne=yýl++; Console.Write (nesne+" ");} Console.WriteLine();
            Console.WriteLine ("Main() ana metot sicim no: {0}.", Thread.CurrentThread.ManagedThreadId);
            ÝkiliToplama bo = new ÝkiliToplama (Topla);
            for(i=0;i<5;i++) {
                ts1=r.Next(1881,1938); ts2=r.Next(1938,2024);
                toplam = bo (ts1, ts2);
                Console.WriteLine ("{0} + {1} = {2}.", ts1, ts2, toplam);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nJoin'siz asenkron 3 sicimin sayaç artým metodunu paylaþýmý:");
            Thread ip1 = new Thread (new ThreadStart (Birartýr));
            ip1.IsBackground = true;
            ip1.Name = "#1";
            ip1.Start(); //ip1.Join();
            Console.WriteLine ("Sicim{0} baþladý", ip1.Name);
            Thread ip2 = new Thread (new ThreadStart (Birartýr));
            ip2.IsBackground = true; ip2.Name = "#2"; ip2.Start(); //ip2.Join();
            Console.WriteLine ("Sicim{0} baþladý", ip2.Name);
            Thread ip3 = new Thread (new ThreadStart (Birartýr));
            ip3.IsBackground = true; ip3.Name = "#3"; ip3.Start(); //ip3.Join();
            Console.WriteLine ("Sicim{0} baþladý", ip3.Name);

            Thread.Sleep (1000); Console.WriteLine ("\nmny.dat dosyaya yazýlan [0,256] byte asenkron okunup teyit edilmekte:");
            for (i = 0; i < 256; i++) byteDizi [i] = (byte)i;
            dosyaAkýþ.Write (byteDizi, 0, 256); //mny.dat'a 0-->256 byte kaydedildi
            dosyaAkýþ.Seek (0, SeekOrigin.Begin);
            asenkSonuçArayüz = dosyaAkýþ.BeginRead (byteDizi, 0, 256, dosyaOkumaÇaðrýsý, null);
            //WaitHandle okuyazBekle = asenkSonuçArayüz.AsyncWaitHandle; okuyazBekle.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli ve asenkron metot çaðrýlý mesaj yazdýrma:");
            MesajýYazÇaðrýsý ("M.Nihat Yavaþ'tan");
            MesajýYazÇaðrýsý ("Herkese,");
            MesajýYazÇaðrýsý ("Merhabalar!..");
            Thread.Sleep (100);

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron metodun geridönüþ ve ref deðerleri:");
            Delegem dlg = new Delegem (Metodum);
            int a = 0, b = 0;
            ts1=dlg ("Nihat", ref a, ref b);
            Console.WriteLine ("Delegeli metot geridönüþü: " + ts1);
            IAsyncResult iar = dlg.BeginInvoke ("Selam", ref a, ref b, null, null);
            iar.AsyncWaitHandle.WaitOne (1000, false);
            if (iar.IsCompleted) {
                int c = 0, d = 0;
                dlg.EndInvoke (ref c, ref d, iar);
                Console.WriteLine ("(a, b) ile referanslanan (c, d) = ({0}, {1})", c, d);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron metodun Math.Sin([0-->]) sonuçlarý:");
            MatMetotÇaðrýsý (new MatMetotDelegesi (Math.Sin), 0.0, 90, 15);
            double ds=0; for(i=0;i<7;i++) {Console.WriteLine ("Math.Cos({0}) = {1}", ds, Math.Cos (ds*Math.PI/180)); ds+=15;}

            Thread.Sleep (1000); Console.WriteLine ("\nAsenkron delegeli çift/tek-Invoke'la matrahlý vergi hesabý:");
            Vergi vrg = new Vergi (VergiyiHesapla);
            decimal ms;
            //Ayrý BeginInvoke ve EndInvoke'la
            for(i=0;i<5;i++) {
                ms=r.Next(1000,10000000)+r.Next(10,100)/100M;
                Console.WriteLine ("==>(matrah, %vergioraný) = ({0:#,0.00} TL, %{1})", ms, 0.15*100);
                iar = vrg.BeginInvoke (0.15M, ms, null, null);
                Console.WriteLine ("Ödenecek vergi: {0:#,0.00} TL", vrg.EndInvoke (iar));
                Thread.Sleep (200);
            }
            //Tek bir BeginInvoke'la
            for(i=0;i<5;i++) {
                ms=r.Next(1000,10000000)+r.Next(10,100)/100M;
                Console.WriteLine ("\t==>(matrah, %vergioraný) = ({0:#,0.00} TL, %{1})", ms, 0.15*100);
                vrg.BeginInvoke (0.15M, ms, new AsyncCallback (VergiBildirimi), vrg);
                Thread.Sleep (200);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron AraçDetaylama()'nýn sicimli görevi:");
            Console.WriteLine ("Main() sicim#{0}", Thread.CurrentThread.GetHashCode());
            AraçBakým ab = new AraçBakým (AraçDetaylama);
            Araç araba;
            for(i=0;i<5;i++) {
                araba = new Araç();
                iar = ab.BeginInvoke (araba, null, null);
                Console.WriteLine ("\t==>Delegeli 'ab.BeginInvoke' yapýldý");
                Console.WriteLine ("AraçDetaylama'nýn geridönüþ mesajý: " + ab.EndInvoke (iar));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}