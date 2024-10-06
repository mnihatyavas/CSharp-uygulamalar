// j2sc#2006a.cs: AnaÝp, AktüelÝp, detaylarý, ArkazeminÝp örneði.

using System;
using System.Threading;
using System.Runtime.Remoting.Contexts; //Context için
namespace ÝpTipleri {
    public class SýnýfA {
        public SýnýfA() {//Kurucu
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("{0} nesnesinin içerik no: {1}/{2}", this, içrk.ContextID, Thread.CurrentThread.ManagedThreadId);
            foreach (IContextProperty özlk in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik: {0}", özlk.Name);
        }
    }
    public class SýnýfB : ContextBoundObject {
        public SýnýfB() {//Kurucu
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("{0} nesnesinin içerik no: {1}/{2}", this, içrk.ContextID, Thread.CurrentThread.GetHashCode());
            foreach (IContextProperty özlk in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik: {0}", özlk.Name);
        }
    }
    public class SýnýfC {
        public void Yýllar() {
            Console.Write ("-> {0}'ün yýllarý: ", Thread.CurrentThread.Name);
            for (int i = 0; i <= 57; i++) {Console.Write ((i+1881) + " "); Thread.Sleep (10);} Console.WriteLine();
        }
    }
    class AnaÝp {
        private static void ÝpFonk() {Console.WriteLine ("Sicim metodunun no'su ve adresi: {0} ve {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode());}
        public static void Say() {for (int i = 1; i<=5; i++) Console.WriteLine ( "{0} sayaç: {1}", Thread.CurrentThread.Name, i);}
        static void ÝpMetot() {
            Thread ip = Thread.CurrentThread;
            ip.Name = "Nihat";
            Console.WriteLine ("Ýp adý: {0}", ip.Name);
            Console.WriteLine ("Canlý mý? {0}", ip.IsAlive);
            Console.WriteLine ("Önceliði: {0}", ip.Priority);
            Console.WriteLine ("Durumu: {0}", ip.ThreadState);
            for(int i = 0; i < 100; i++) {Console.Write ("."); Thread.Sleep (1);}
        }
        static void Main() {
            Console.Write ("Main() metot içindeki 'Thread ip=Thread.CurrentThread' ana sicim'dir; ip.Name ad, ip.Priority öncelik, ip.ManagedThreadId no deðerleri atar; ip.IsAlive canlý mý, ip.ThreadState durumunu bildirir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ana sicimin adý, önceliði, no'su ve durumu:");
            Thread sicim = Thread.CurrentThread;
            if (sicim.Name == null) Console.WriteLine ("Ana sicime ad atanmamýþ.");
            else Console.WriteLine ("Ana sicimin adý: " + sicim.Name);
            sicim.Name = "Ana-Ýp";
            Console.WriteLine ("Ana sicimin atanan adý: " + sicim.Name);
            Console.WriteLine ("Varsayýlý önceliði: " + sicim.Priority);
            sicim.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine ("Atanan önceliði: " + sicim.Priority);
            Console.WriteLine ("Ana sicim no: " + sicim.ManagedThreadId);
            Console.WriteLine ("Canlý mý? {0}", sicim.IsAlive);
            Console.WriteLine ("Sicimin durumu: {0}", sicim.ThreadState);

            Console.WriteLine ("\nAna sicim ve sicim-fonksiyonun no'su ve adresi:");
            Thread ip = new Thread (new ThreadStart (ÝpFonk) );
            Console.WriteLine ("Ana sicimin no'su ve adresi: {0} ve {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode());
            ip.Start(); ip.Join();
        
            Thread.Sleep (1000); Console.WriteLine ("\nContext içerikli sicim ve mevcut özellikleri:");
            SýnýfA snfA1 = new SýnýfA();
            SýnýfA snfA2 = new SýnýfA();
            SýnýfB ebeveynliSnfB = new SýnýfB();

            Thread.Sleep (1000); Console.WriteLine ("\nArkaplandaki 3 sicim 1-->5'er saymakta:");
            Thread[] ipler = new Thread [3];
            for(int k = 0; k < ipler.Length; k++) {
                ipler [k] = new Thread (new ThreadStart (Say));
                ipler [k].Name = "Sicim#" + (k+1);
                ipler [k].IsBackground = true;
                ipler [k].Start();
                //ipler [k].Join(); //Karýþýk çalýþsýnlar
            }

            Thread.Sleep (1000); Console.WriteLine ("\nArkaplan ip detaylarý ve 100.'lýk bekletme:");
            ip = new Thread (new ThreadStart (ÝpMetot));
            ip.Priority = ThreadPriority.Highest;
            ip.IsBackground = true;
            ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nArkaplan ip Atatürk'ün yýllarýný 1881-->1938 yazmakta:");
            SýnýfC snfC = new SýnýfC();
            ip = new Thread (new ThreadStart (snfC.Yýllar));
            ip.Name="Atatürk";
            ip.IsBackground = true;
            ip.Start(); Thread.Sleep (1000);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}