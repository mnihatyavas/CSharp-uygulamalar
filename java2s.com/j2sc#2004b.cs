// j2sc#2004b.cs: Ortak lock(kilit)'li Monitor.Enter/TryEnter/Exit/Wait/Pulse �rne�i.

using System;
using System.Threading;
namespace Sicimler {
    class VeriTaban� {
        public void VeriKaydet (string veri) {
            Console.WriteLine ("[VeriKaydet-{0}] ba�lad�", veri);
            Monitor.Enter (this);
            Console.WriteLine("[VeriKaydet-{0}] �al���yor...", veri);
            //throw new Exception ("HATA!");
            for(int i = 0; i < 50; i++) {
                Thread.Sleep (10);
                Console.Write (veri);
            }
            Monitor.Exit (this);
            Console.WriteLine ("\n[VeriKaydet-{0}] bitti", veri);
        }
    }
    public class �retici {
        private Veri veri;
        public �retici (Veri veri) {this.veri = veri;} //Kurucu
        public void ko�() {for(int i=0;i<20;i++) {veri.�ret(); Thread.Sleep (100);}} //for(int i=0;i<20;i++) {
    }
    public class T�ketici {
        private Veri veri;
        public T�ketici (Veri veri) {this.veri = veri;}
        public void ko�() {for(int i=0;i<20;i++) {veri.t�ket(); Thread.Sleep (100);}}
    }
    public class Veri {
        int saya�=0;
        bool haz�rM� = false;
        public void �ret() {
            lock (this) {
                if (haz�rM�) Monitor.Wait (this);
                saya�++;
                Console.Write ("�retilen: "+saya�+"==>\t");
                haz�rM� = true;
                Monitor.Pulse (this);
            }
        }
        public void t�ket() {
            lock (this) {
                if (!haz�rM�) Monitor.Wait (this);
                Console.WriteLine ("T�ketilen: "+saya�); 
                haz�rM� = false;
                Monitor.Pulse (this);
            }
        }
    }
    class MonitorB {
        private static Object kitleyici = new Object();
        private static int saya� = 0;
        public int Sayac�Art�r() {
            int sy�;
            lock (kitleyici) {sy� = ++saya�;}
            return sy�;
        }
        public void Say() {
            for(int i = 0; i < 4; i++) {
                Console.WriteLine ("Sicim({0}): saya� = {1}", Thread.CurrentThread.Name, Sayac�Art�r());
                Thread.Sleep (10);
            }
        }
        private const int limit2 = 6;
        private const int toplami� = 30;
        private static Object kitleyici2 = new Object();
        static void ���i() {
            while (true) {
                lock (kitleyici2) {Monitor.Wait (kitleyici2);} //== Monitor.Wait (ortakKilit, Timeout.Infinite)
                Console.WriteLine ("{0} �al���yor...", Thread.CurrentThread.Name);
                Thread.Sleep (100);
            }
        }
        public static VeriTaban� vt = new VeriTaban�();
        public static void SicimMetodu1() {
            Console.WriteLine ("[SicimMetodu1] ba�lad�");
            Console.WriteLine ("[SicimMetodu1] " + "VeriTaban�.VeriKaydet()'i �a��r�yor");
            try {vt.VeriKaydet ("X");} catch{}
            Console.WriteLine ("[SicimMetodu1] bitti");
        }
        public static void SicimMetodu2() {
            Console.WriteLine ("[SicimMetodu2] ba�lad�");
            Console.WriteLine ("[SicimMetodu2] " + "VeriTaban�.VeriKaydet()'i �a��r�yor");
            try {vt.VeriKaydet ("W");} catch{}
            Console.WriteLine ("[SicimMetodu2] bitti");
        }
        static long saya�2;
        static void Azalt�c�() {
            saya�2 = 10;
            try {Monitor.Enter (saya�2);
                if (saya�2 < 11) {
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (saya�2);
                    //Monitor.Wait (saya�2);
                }
                while (saya�2 > 0) {
                    long arac� = saya�2; //��g�zarl�k
                    arac�--;
                    Thread.Sleep (1);
                    saya�2 = arac�;
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (saya�2);
                }

            }finally {try {Monitor.Exit(saya�2);}catch (Exception ht) {Console.WriteLine(ht.Message);}}
        }
        static void Art�r�c�() {
            saya�2 = -1;
            try {Monitor.Enter (saya�2);
                while (saya�2 < 10) {
                    long arac� = saya�2; //��g�zarl�k
                    arac�++;
                    Thread.Sleep (1);
                    saya�2 = arac�;
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (saya�2);
                }
                try {Monitor.Pulse(saya�2);}catch (Exception ht) {Console.WriteLine(ht.Message);}

            }finally {try {Monitor.Exit(saya�2);}catch (Exception ht) {Console.WriteLine(ht.Message);}}
        }
        static void Main() {
            Console.Write ("Monitor.Pulse(kilit) ortak kilitli sicimler aras�nda ard���k ve alma��k tek-tek s��ramalar yapar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 lock&join sicimin herbiri sayac� [1-->20] birer art�rmakta:");
            int limit = 5, i;
            Thread[] ipler = new Thread [limit];
            for(i=0;i<limit;i++) {
                MonitorB mB = new MonitorB();
                ipler [i] = new Thread (new ThreadStart (mB.Say));
                ipler [i].Name = "�p#" + i;
            }
            for(i=0;i<limit;i++) ipler [i].Start();
            for(i=0;i<limit;i++) ipler [i].Join();
            Console.WriteLine ("T�m {0} adet ipler tamamland�.", limit);

            Thread.Sleep (1000); Console.WriteLine ("\n6 lock&Pulse [1-->6].sicim birer s��ramal� 30 toplami� yapmakta:");
            Thread[] ipler2 = new Thread [limit2];
            for(i=0;i<limit2;i++) {
                ipler2 [i] = new Thread (���i);
                ipler2 [i].Name = (i+1) + ".sicim";
                ipler2 [i].IsBackground = true;
                ipler2 [i].Start();
            }
            for(i=0;i<toplami�;i++) {
                Thread.Sleep (200);
                lock (kitleyici2) {Monitor.Pulse (kitleyici2);}
            }

            Thread.Sleep (1000); Console.WriteLine ("\nAsenkron 2 sicim lock&join'siz zamanpayla��ml� 50'�er (X-W) veri kaydetmekte:");
            ThreadStart i��i1 = new ThreadStart (SicimMetodu1);
            ThreadStart i��i2 = new ThreadStart (SicimMetodu2);
            Thread ip1 = new Thread (i��i1);
            Thread ip2 = new Thread (i��i2);
            ip1.Start(); ip2.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n2 join'li sicimin azaltan [10--0] ve art�ran [0-->10] icraatlar�:");
            Thread[] ipler3 = {new Thread (new ThreadStart (Azalt�c�)), new Thread (new ThreadStart (Art�r�c�))};
            i = 1;
            foreach (Thread ip in ipler3) {
                ip.IsBackground = true;
                ip.Start();
                ip.Name = "Saya�-" + i.ToString();
                Console.WriteLine ("{0} ba�lad�", ip.Name);
                Thread.Sleep (50);
                i++;
            }
            foreach (Thread ip in ipler3) ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nMonitor.Pulse ile toplam 20 adet alma��k �retim-->t�ketim d�ng�s�:");
            Veri vr = new Veri();
            �retici �ret = new �retici (vr);
            T�ketici t�ket = new T�ketici (vr);
            ip1 = new Thread (new ThreadStart (�ret.ko�));
            ip2 = new Thread (new ThreadStart (t�ket.ko�));
            ip1.Start(); ip2.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}