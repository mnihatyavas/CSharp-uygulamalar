// j2sc#2001d.cs: ThreadPriority, [vas�f], ThreadState �rne�i.

using System;
using System.Threading;
namespace �okluG�rev {
    class SicimA {
        public int saya�;
        public Thread ip;
        public SicimA (string ad) {//Kurucu
            saya� = 0;
            ip = new Thread (this.ko�);
            ip.Name = ad;
        }
        void ko�() {
            Console.WriteLine ("["+ip.Name + " adl� sicim ba�l�yor.]");
            do {saya�++; Console.Write (ip.Name+" ");} while (saya� < 100);
            Console.WriteLine ("\n["+ip.Name + " adl� sicim sonlan�yor.]");
        }
    }
    class SicimlerD {
        static void SicimMetodu() {
            Thread.CurrentThread.Name = "NihatSicimi";
            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Sicimin ad�: {0}", ip.Name);
            Console.WriteLine ("Canl� m�? {0}", ip.IsAlive);
            Console.WriteLine ("�lk �nceli�i: {0}", ip.Priority);
            Console.WriteLine ("Durumu: {0}", ip.ThreadState);
            for (int i = 0; i < 100; i ++) {Console.Write (i+" "); Thread.Sleep (10);}
            Console.WriteLine ("\nSon �nceli�i: {0}", ip.Priority);
        }
        public static void GeriSay�m() {
            Console.WriteLine ("�lk �nceli�i: {0}", Thread.CurrentThread.Priority);
            for (int i = 100; i > 0; i--) {Console.Write (i + " "); Thread.Sleep (10);}
        }
        public static void Y�llar() {for (int i = 1881; i <= 1938; i++) {Console.Write (i+" "); Thread.Sleep (10);} Console.Write("\r");}
        public static void SicimDurumu (Thread ip ) {
            Console.Write ("Akt�el durum: ");
            if ((ip.ThreadState & ThreadState.Aborted) == ThreadState.Aborted) Console.WriteLine ("Aborted=K�r�ld�");
            if ((ip.ThreadState & ThreadState.AbortRequested) == ThreadState.AbortRequested) Console.WriteLine ("AbortRequested=K�r�lmaTalepli");
            if ((ip.ThreadState & ThreadState.Background) == ThreadState.Background) Console.WriteLine ("Background=Arkaplanl�");
            if ((ip.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted | ThreadState.Aborted)) == 0) Console.WriteLine ("Running=Ko�makta");
            if ((ip.ThreadState & ThreadState.Stopped) == ThreadState.Stopped) Console.WriteLine ("Stopped: Sonland�");
            if ((ip.ThreadState & ThreadState.StopRequested) == ThreadState.StopRequested) Console.WriteLine ("StopRequested=SonlanmaTalepli");
            if ((ip.ThreadState & ThreadState.Suspended) == ThreadState.Suspended) Console.WriteLine ("Suspended=Ask�da");
            if ((ip.ThreadState & ThreadState.SuspendRequested) == ThreadState.SuspendRequested) Console.WriteLine ("SuspendRequested=Ask�Talepli");
            if ((ip.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted) Console.WriteLine ("Unstarted=Ba�lamad�");
            if ((ip.ThreadState & ThreadState.WaitSleepJoin) == ThreadState.WaitSleepJoin) Console.WriteLine ("WaitSleepJoin=UykuBlokBeklemede");
        }
        // [MTAThread]
        [STAThread] //Sicim vas�flar�
        static void Main() {
            Console.Write ("Sicim �ncelikleri Lowest-->BelowNormal-->Normal-->AboveNormal-->Highest atanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Y�ksek�ncelikli sicime daha �nce ve �ok g�rev zaman� tan�n�r:");
            SicimA snfA1 = new SicimA ("-D�-"); //D���k�ncelik
            SicimA snfA2 = new SicimA ("*Y�*"); //Y�ksek�ncelik
            snfA1.ip.Priority = ThreadPriority.BelowNormal;
            snfA2.ip.Priority = ThreadPriority.AboveNormal;
            snfA1.ip.Start(); snfA2.ip.Start();
            snfA1.ip.Join(); snfA2.ip.Join();
            Console.WriteLine (snfA1.ip.Name + " adl� sicim sayac�: " + snfA1.saya�);
            Console.WriteLine (snfA2.ip.Name + " adl� sicim sayac�: " + snfA2.saya�);

            Thread.Sleep (1000); Console.WriteLine ("\nG�rev s�ras�nda �nceli�i Lowest-->Highest de�i�en sicim:");
            Thread ip = new Thread (new ThreadStart (SicimMetodu));
            ip.Priority = ThreadPriority.Lowest;
            ip.Start();
            Thread.Sleep (100); ip.Priority = ThreadPriority.Highest;

            Thread.Sleep (1000); Console.WriteLine ("\nG�rev s�ras�nda �nceli�i Normal-->BelowNormal de�i�en sicim:");
            ip = new Thread (new ThreadStart (GeriSay�m));
            ip.Priority = ThreadPriority.Normal;
            ip.Start();
            Thread.Sleep (500); Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine ("\nSon �nceli�i: {0}", Thread.CurrentThread.Priority);

            Thread.Sleep (1000); Console.WriteLine ("\nSicimin Start �ncesi, sonras�, g�rev icras� ve k�r�lma durumlar�:");
            ip = new Thread (new ThreadStart (Y�llar)); SicimDurumu (ip);
            ip.Start(); SicimDurumu (ip);
            Y�llar(); SicimDurumu (ip);
            ip.Abort(); SicimDurumu (ip);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}