// j2sc#2003a.cs: Ard���k main() senkron ve asenkron 'new Thread()' ile 'IAsyncResult dlg.Begin/EndInvoke()' �rne�i.

using System;
using System.Runtime.CompilerServices; //MethodImpl i�in
using System.Threading;
using System.IO; //FileStream i�in
namespace Sicimler {
    public delegate int �kiliToplama (int x, int y);
    delegate void Fonksiyon�a�r�s� (string dizge);
    public delegate string Ara�Bak�m (Ara� detaylama);
    public class Ara�{}
    class SenkronAsenkron {
        private static int y�l = 1881;
        private static object nesne = new object();
        static int Topla (int x, int y) {
            Console.WriteLine ("'(new Thread(metot)) Sicim'le y�r�t�lmeyen Topla()'n�n sicim no: {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep (500);
            return x + y;
        }
        static int saya� = 0;
        public static void Birart�r() {
            try {
                while (saya� < 20) {
                    int arac� = saya�;
                    arac�++;
                    Thread.Sleep (5);
                    saya� = arac�;
                    Console.WriteLine ("Sicim{0}.Birart�r(): {1}", Thread.CurrentThread.Name, saya�);
                }
            }catch (ThreadInterruptedException) {Console.WriteLine ("Sicim{0} k�r�ld�! Kapan�� temizli�i...", Thread.CurrentThread.Name);
            }finally {Console.WriteLine ("Sicim{0} Sonlan�yor.", Thread.CurrentThread.Name);}
        }
        static FileStream dosyaAk�� = new FileStream ("mny.dat", FileMode.Create, FileAccess.ReadWrite);
        static byte[] byteDizi = new byte [256];
        static IAsyncResult asenkSonu�Aray�z = null;
        static AsyncCallback dosyaOkuma�a�r�s� = new AsyncCallback (dosyaOkununca);
        public static void dosyaOkununca (IAsyncResult asenkSonu�) {
            saya�=(int)dosyaAk��.EndRead (asenkSonu�);
            Console.WriteLine ("mny.dat'dan byteDizi'ye okunan byte say�s�: {0}", saya�);
            for (int i = 0; i < 256; i++) {if (byteDizi [i] != (byte)i) {Console.WriteLine ("mny.dat dosyas�ndan okunan {0}.nci byte hatal�.", i); nesne="hata";} continue;}
            if(nesne.ToString() != "hata") Console.WriteLine ("mny.dat dosyas�ndan okunan {0} adet byte hatas�z.", saya�);
        }
        public static void Mesaj�Yaz�a�r�s� (string dzg) {
            Fonksiyon�a�r�s� fonk = new Fonksiyon�a�r�s�(Console.WriteLine);
            fonk.BeginInvoke (dzg, new AsyncCallback (Mesaj�Yaz), fonk);
        }
        public static void Mesaj�Yaz (IAsyncResult asenkSonu�) {
            Console.WriteLine ("**Mesaj�Yaz() metodu i�i**");
            Fonksiyon�a�r�s� fonk = (Fonksiyon�a�r�s�)asenkSonu�.AsyncState;
            fonk.EndInvoke (asenkSonu�);
        }
        delegate int Delegem (string s, ref int a, ref int b);
        static int Metodum (string s, ref int a, ref int b) {
            a = 1881; b = 1938;
            Console.WriteLine ("Metodum() ate�lendi!..");
            return 20240911;
        }
        public delegate double MatMetotDelegesi (double ds);
        public static void MatMetot�a�r�s� (MatMetotDelegesi fonk, double ilk, double son, double art��) {
            AsyncCallback acb = new AsyncCallback (MatMetot);
            while (ilk <= son) {
                Console.WriteLine ("Math.Sin({0}) = sonu�?", ilk);
                fonk.BeginInvoke (ilk*Math.PI/180, acb, fonk);
                ilk += art��;
            }
        }
        public static void MatMetot (IAsyncResult iar) {
            MatMetotDelegesi dlg = (MatMetotDelegesi)iar.AsyncState;
            double sonu� = dlg.EndInvoke (iar); Thread.Sleep (100);
            Console.WriteLine ("Fonksiyon sonucu = {0}", sonu�);
        }
        private delegate Decimal Vergi (decimal oran, decimal matrah); //Asenkron �a�r� delegesi
        private static Decimal VergiyiHesapla (decimal o, decimal m) {
            Console.WriteLine ("{0} nolu sicimle vergi hesaplan�yor...", Thread.CurrentThread.GetHashCode());
            //Thread.Sleep (2000);
            return m*o;
        }
        private static void VergiBildirimi (IAsyncResult iar) {
            Vergi vrg = (Vergi)iar.AsyncState;
            Console.WriteLine ("\t�denecek vergi: {0:#,0.00} TL", vrg.EndInvoke (iar));
        }
        public static string Ara�Detaylama (Ara� oto) {
            Console.WriteLine ("Arac�n detayl� bak�m� sicim#{0}'de yap�l�yor...", Thread.CurrentThread.GetHashCode());
            Thread.Sleep (1000);
            return "Araban�z kullan�m�za haz�r, efendim!";
        }
        [MethodImpl (MethodImplOptions.Synchronized)]
        static void Main() {
            Console.Write ("Senkron i�lemler tek Main() sicimle ard���k kod ak���n� takip eder. 'new Thread(metot)' veya 'IAsyncResult iar = delege.Begin/EndInvoke(arg�manlar)' ve 'return iarMesaj' ise arkazeminde �oklu, farkl�, zamanpayla��ml� asenkron g�rev yaparlar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Senkron ard���k kodlamalarla y�llar ve toplamlar:");
            int i, ts1, ts2, toplam; var r=new Random();
            for(i=0;i<=57;i++) {nesne=y�l++; Console.Write (nesne+" ");} Console.WriteLine();
            Console.WriteLine ("Main() ana metot sicim no: {0}.", Thread.CurrentThread.ManagedThreadId);
            �kiliToplama bo = new �kiliToplama (Topla);
            for(i=0;i<5;i++) {
                ts1=r.Next(1881,1938); ts2=r.Next(1938,2024);
                toplam = bo (ts1, ts2);
                Console.WriteLine ("{0} + {1} = {2}.", ts1, ts2, toplam);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nJoin'siz asenkron 3 sicimin saya� art�m metodunu payla��m�:");
            Thread ip1 = new Thread (new ThreadStart (Birart�r));
            ip1.IsBackground = true;
            ip1.Name = "#1";
            ip1.Start(); //ip1.Join();
            Console.WriteLine ("Sicim{0} ba�lad�", ip1.Name);
            Thread ip2 = new Thread (new ThreadStart (Birart�r));
            ip2.IsBackground = true; ip2.Name = "#2"; ip2.Start(); //ip2.Join();
            Console.WriteLine ("Sicim{0} ba�lad�", ip2.Name);
            Thread ip3 = new Thread (new ThreadStart (Birart�r));
            ip3.IsBackground = true; ip3.Name = "#3"; ip3.Start(); //ip3.Join();
            Console.WriteLine ("Sicim{0} ba�lad�", ip3.Name);

            Thread.Sleep (1000); Console.WriteLine ("\nmny.dat dosyaya yaz�lan [0,256] byte asenkron okunup teyit edilmekte:");
            for (i = 0; i < 256; i++) byteDizi [i] = (byte)i;
            dosyaAk��.Write (byteDizi, 0, 256); //mny.dat'a 0-->256 byte kaydedildi
            dosyaAk��.Seek (0, SeekOrigin.Begin);
            asenkSonu�Aray�z = dosyaAk��.BeginRead (byteDizi, 0, 256, dosyaOkuma�a�r�s�, null);
            //WaitHandle okuyazBekle = asenkSonu�Aray�z.AsyncWaitHandle; okuyazBekle.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli ve asenkron metot �a�r�l� mesaj yazd�rma:");
            Mesaj�Yaz�a�r�s� ("M.Nihat Yava�'tan");
            Mesaj�Yaz�a�r�s� ("Herkese,");
            Mesaj�Yaz�a�r�s� ("Merhabalar!..");
            Thread.Sleep (100);

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron metodun gerid�n�� ve ref de�erleri:");
            Delegem dlg = new Delegem (Metodum);
            int a = 0, b = 0;
            ts1=dlg ("Nihat", ref a, ref b);
            Console.WriteLine ("Delegeli metot gerid�n���: " + ts1);
            IAsyncResult iar = dlg.BeginInvoke ("Selam", ref a, ref b, null, null);
            iar.AsyncWaitHandle.WaitOne (1000, false);
            if (iar.IsCompleted) {
                int c = 0, d = 0;
                dlg.EndInvoke (ref c, ref d, iar);
                Console.WriteLine ("(a, b) ile referanslanan (c, d) = ({0}, {1})", c, d);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron metodun Math.Sin([0-->]) sonu�lar�:");
            MatMetot�a�r�s� (new MatMetotDelegesi (Math.Sin), 0.0, 90, 15);
            double ds=0; for(i=0;i<7;i++) {Console.WriteLine ("Math.Cos({0}) = {1}", ds, Math.Cos (ds*Math.PI/180)); ds+=15;}

            Thread.Sleep (1000); Console.WriteLine ("\nAsenkron delegeli �ift/tek-Invoke'la matrahl� vergi hesab�:");
            Vergi vrg = new Vergi (VergiyiHesapla);
            decimal ms;
            //Ayr� BeginInvoke ve EndInvoke'la
            for(i=0;i<5;i++) {
                ms=r.Next(1000,10000000)+r.Next(10,100)/100M;
                Console.WriteLine ("==>(matrah, %vergioran�) = ({0:#,0.00} TL, %{1})", ms, 0.15*100);
                iar = vrg.BeginInvoke (0.15M, ms, null, null);
                Console.WriteLine ("�denecek vergi: {0:#,0.00} TL", vrg.EndInvoke (iar));
                Thread.Sleep (200);
            }
            //Tek bir BeginInvoke'la
            for(i=0;i<5;i++) {
                ms=r.Next(1000,10000000)+r.Next(10,100)/100M;
                Console.WriteLine ("\t==>(matrah, %vergioran�) = ({0:#,0.00} TL, %{1})", ms, 0.15*100);
                vrg.BeginInvoke (0.15M, ms, new AsyncCallback (VergiBildirimi), vrg);
                Thread.Sleep (200);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron Ara�Detaylama()'n�n sicimli g�revi:");
            Console.WriteLine ("Main() sicim#{0}", Thread.CurrentThread.GetHashCode());
            Ara�Bak�m ab = new Ara�Bak�m (Ara�Detaylama);
            Ara� araba;
            for(i=0;i<5;i++) {
                araba = new Ara�();
                iar = ab.BeginInvoke (araba, null, null);
                Console.WriteLine ("\t==>Delegeli 'ab.BeginInvoke' yap�ld�");
                Console.WriteLine ("Ara�Detaylama'n�n gerid�n�� mesaj�: " + ab.EndInvoke (iar));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}