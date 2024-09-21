// j2sc#2004a.cs: Monitor.Enter/TryEnter/Exit/Wait/Pulse örneði.

using System;
using System.Threading;
using System.Collections; //ArrayList için
namespace Sicimler {
    class TikTak {
        public void tik (bool tikMi) {
            lock (this) {//Bu ip'i tamamla
               if (!tikMi) {//tik
                  Monitor.Pulse (this); //Bekleyen ip'e geç
                  return;
                }
                Console.Write ("Tik ");
                Monitor.Pulse (this); //tak() çalýþsýn
                Monitor.Wait (this); //tak()'ýn tamamlanmasýný bekle
            }
        }
        public void tak (bool takMý) {
            lock (this) {//Bu ip'i tamamla
                if (!takMý) {//tak
                    Monitor.Pulse (this); //Bekleyen ip'e geç
                    return;
                }
                Console.WriteLine ("Tak");
                Monitor.Pulse (this); //tik() çalýþsýn
                Monitor.Wait (this); //tik()'in tamamlanmasýný bekle
            }
        }
    }
    class Ýp1 {
        public Thread ip; 
        TikTak nesne;
        public Ýp1 (string ad, TikTak tt) {//Kurucu
            ip = new Thread (this.koþ);
            nesne = tt;
            ip.Name = ad;
            ip.Start();
        }
        void koþ() {
            if (ip.Name == "Tik") {
                for(int i=0;i<10;i++) nesne.tik (true);
                nesne.tik (false);
            }else {
                for(int i=0;i<10;i++) nesne.tak (true);
                nesne.tak (false);
            }
        }
    }
    class SýnýfA {
        private int sayaç;
        public void SicimliSayaç() {
            lock (this) {
                sayaç++;
                for(int i = 0; i < 5; i++) {
                    Console.WriteLine ("Sicim: {0}--> Sayaç#: {1}--> i: {2}", Thread.CurrentThread.Name, sayaç, i);
                    Thread.Sleep (50);
                }
            }
        }
    }
    class MonitorA {
        public static ArrayList liste = new ArrayList();
        static void Gözleme() {
            Monitor.Enter (liste);
            for(int i=1881;i<=1938;i++) liste.Add ("Atatürk-"+i);
            Monitor.Exit (liste);
        }
        static private int sayaç = 0;
        static private object ortakKilit = new Object();
        static private void Sicim1() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ( "Sayaç: {0} (sicim#{1})", ++sayaç, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim2() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ( "Sayaç: {0} (sicim#{1})", ++sayaç, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim3() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ("Sayaç: {0} (sicim#{1})", ++sayaç, Thread.CurrentThread.GetHashCode());
                    Monitor.Pulse (ortakKilit);
                }
            }
        }
        static private void Sicim4() {
            lock (ortakKilit) {
                for(int i = 0; i < 5; ++i) {
                    Monitor.Pulse (ortakKilit);
                    Monitor.Wait (ortakKilit, Timeout.Infinite);
                    Console.WriteLine ("Sayaç: {0} (sicim#{1})", ++sayaç, Thread.CurrentThread.GetHashCode());
                }
            }
        }
        static void Main() {
            Console.Write ("Monitor.Pulse(kilit) ortak kilitli sicimler arasýnda ardýþýk sýçramalar yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10'lu for'da çift ip'in almaþýk Tik-Tak paylaþýmý:");
            TikTak tt = new TikTak();
            Ýp1 ses1 = new Ýp1 ("Tik", tt);
            Ýp1 ses2 = new Ýp1 ("Tak", tt);
            ses1.ip.Join();
            ses2.ip.Join();
            Console.WriteLine ("Hop, saat durdu!");

            Thread.Sleep (1000); Console.WriteLine ("\nMonitor'lu liste'ye veri giriþleri ve döküm:");
            int i;
            Thread ip = new Thread (new ThreadStart (Gözleme));
            ip.Start(); Thread.Sleep (10); //Ýp'li Gözleme() veri giriþlerini tamamlamalý
            for(i=0;i<liste.Count;i++) Console.Write (liste [i] +" ");

            Thread.Sleep (1000); Console.WriteLine ("\n\nMonitor.Enter, Monitor.TryEnter ve Monitor.Exit:");
            i = 0;
            object ns = new object(); ns="Atatürk-1919";
            try {Monitor.Enter (ns); i++;
            }finally {Monitor.Exit (ns);}
            Console.WriteLine ("{0}-->{1}", i, ns);
            ns="Atatürk-1923";
            try {if (Monitor.TryEnter (ns, 20240918)) {i++;}
            }finally {
                try {Monitor.Exit (ns);
                }catch (SynchronizationLockException sle) {Console.WriteLine ("HATA: {0}", sle.Message);}
            }
            Console.WriteLine ("{0}-->{1}", i, ns);

            Thread.Sleep (1000); Console.WriteLine ("\nOrtak kilitli 4 almaþýk sicim metodunun ardýþýk sayaç artýþ uyumu:");
            Thread ip1 = new Thread (new ThreadStart (Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicim2));
            Thread ip3 = new Thread (new ThreadStart (Sicim3));
            Thread ip4 = new Thread (new ThreadStart (Sicim4));
            ip1.Start(); ip2.Start(); ip3.Start(); ip4.Start();

            Thread.Sleep (1000); Console.WriteLine ("\nAyný sýnýfýn sayaç metodlu 4 sicimin kilitli artan sunumu:");
            SýnýfA snfA = new SýnýfA();
            ip1 = new Thread (new ThreadStart (snfA.SicimliSayaç)); ip1.Name = "Zeliha";
            ip2 = new Thread (new ThreadStart (snfA.SicimliSayaç)); ip2.Name = "Nihal";
            ip3 = new Thread (new ThreadStart (snfA.SicimliSayaç)); ip3.Name = "Yavaþ";
            ip4 = new Thread (new ThreadStart (snfA.SicimliSayaç)); ip4.Name = "Candan";
            ip1.Start(); ip2.Start(); ip3.Start(); ip4.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}