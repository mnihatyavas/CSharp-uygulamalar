// j2sc#2004a.cs: Monitor.Enter/TryEnter/Exit/Wait/Pulse �rne�i.

using System;
using System.Threading;
using System.Collections; //ArrayList i�in
namespace Sicimler {
    class TikTak {
        public void tik (bool tikMi) {
            lock (this) {//Bu ip'i tamamla
               if (!tikMi) {//tik
                  Monitor.Pulse (this); //Bekleyen ip'e ge�
                  return;
                }
                Console.Write ("Tik ");
                Monitor.Pulse (this); //tak() �al��s�n
                Monitor.Wait (this); //tak()'�n tamamlanmas�n� bekle
            }
        }
        public void tak (bool takM�) {
            lock (this) {//Bu ip'i tamamla
                if (!takM�) {//tak
                    Monitor.Pulse (this); //Bekleyen ip'e ge�
                    return;
                }
                Console.WriteLine ("Tak");
                Monitor.Pulse (this); //tik() �al��s�n
                Monitor.Wait (this); //tik()'in tamamlanmas�n� bekle
            }
        }
    }
    class �p1 {
        public Thread ip; 
        TikTak nesne;
        public �p1 (string ad, TikTak tt) {//Kurucu
            ip = new Thread (this.ko�);
            nesne = tt;
            ip.Name = ad;
            ip.Start();
        }
        void ko�() {
            if (ip.Name == "Tik") {
                for(int i=0;i<10;i++) nesne.tik (true);
                nesne.tik (false);
            }else {
                for(int i=0;i<10;i++) nesne.tak (true);
                nesne.tak (false);
            }
        }
    }
    class S�n�fA {
        private int saya�;
        public void SicimliSaya�() {
            lock (this) {
                saya�++;
                for(int i = 0; i < 5; i++) {
                    Console.WriteLine ("Sicim: {0}--> Saya�#: {1}--> i: {2}", Thread.CurrentThread.Name, saya�, i);
                    Thread.Sleep (50);
                }
            }
        }
    }
    class MonitorA {
        public static ArrayList liste = new ArrayList();
        static void G�zleme() {
            Monitor.Enter (liste);
            for(int i=1881;i<=1938;i++) liste.Add ("Atat�rk-"+i);
            Monitor.Exit (liste);
        }
        static private int saya� = 0;
        static private object ortakKilit = new Object();
        static private void Sicim1() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ( "Saya�: {0} (sicim#{1})", ++saya�, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim2() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ( "Saya�: {0} (sicim#{1})", ++saya�, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim3() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ("Saya�: {0} (sicim#{1})", ++saya�, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim4() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Pulse (ortakKilit);
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ("Saya�: {0} (sicim#{1})", ++saya�, Thread.CurrentThread.GetHashCode());
                }
            }
        }
        static void Main() {
            Console.Write ("Monitor.Pulse(kilit) ortak kilitli sicimler aras�nda ard���k s��ramalar yapar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10'lu for'da �ift ip'in alma��k Tik-Tak payla��m�:");
            TikTak tt = new TikTak();
            �p1 ses1 = new �p1 ("Tik", tt);
            �p1 ses2 = new �p1 ("Tak", tt);
            ses1.ip.Join();
            ses2.ip.Join();
            Console.WriteLine ("Hop, saat durdu!");

            Thread.Sleep (1000); Console.WriteLine ("\nMonitor'lu liste'ye veri giri�leri ve d�k�m:");
            int i;
            Thread ip = new Thread (new ThreadStart (G�zleme));
            ip.Start(); Thread.Sleep (10); //�p'li G�zleme() veri giri�lerini tamamlamal�
            for(i=0;i<liste.Count;i++) Console.Write (liste [i] +" ");

            Thread.Sleep (1000); Console.WriteLine ("\n\nMonitor.Enter, Monitor.TryEnter ve Monitor.Exit:");
            i = 0;
            object ns = new object(); ns="Atat�rk-1919";
            try {Monitor.Enter (ns); i++;
            }finally {Monitor.Exit (ns);}
            Console.WriteLine ("{0}-->{1}", i, ns);
            ns="Atat�rk-1923";
            try {if (Monitor.TryEnter (ns, 20240918)) {i++;}
            }finally {
                try {Monitor.Exit (ns);
                }catch (SynchronizationLockException sle) {Console.WriteLine ("HATA: {0}", sle.Message);}
            }
            Console.WriteLine ("{0}-->{1}", i, ns);

            Thread.Sleep (1000); Console.WriteLine ("\nOrtak kilitli 4 alma��k sicim metodunun ard���k saya� art�� uyumu:");
            Thread ip1 = new Thread (new ThreadStart (Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicim2));
            Thread ip3 = new Thread (new ThreadStart (Sicim3));
            Thread ip4 = new Thread (new ThreadStart (Sicim4));
            ip1.Start(); ip2.Start(); ip3.Start(); ip4.Start();

            Thread.Sleep (1000); Console.WriteLine ("\nAyn� s�n�f�n saya� metodlu 4 sicimin kilitli artan sunumu:");
            S�n�fA snfA = new S�n�fA();
            ip1 = new Thread (new ThreadStart (snfA.SicimliSaya�)); ip1.Name = "Zeliha";
            ip2 = new Thread (new ThreadStart (snfA.SicimliSaya�)); ip2.Name = "Nihal";
            ip3 = new Thread (new ThreadStart (snfA.SicimliSaya�)); ip3.Name = "Yava�";
            ip4 = new Thread (new ThreadStart (snfA.SicimliSaya�)); ip4.Name = "Candan";
            ip1.Start(); ip2.Start(); ip3.Start(); ip4.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}