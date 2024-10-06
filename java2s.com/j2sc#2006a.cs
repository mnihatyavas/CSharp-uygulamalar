// j2sc#2006a.cs: Ana�p, Akt�el�p, detaylar�, Arkazemin�p �rne�i.

using System;
using System.Threading;
using System.Runtime.Remoting.Contexts; //Context i�in
namespace �pTipleri {
    public class S�n�fA {
        public S�n�fA() {//Kurucu
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("{0} nesnesinin i�erik no: {1}/{2}", this, i�rk.ContextID, Thread.CurrentThread.ManagedThreadId);
            foreach (IContextProperty �zlk in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik: {0}", �zlk.Name);
        }
    }
    public class S�n�fB : ContextBoundObject {
        public S�n�fB() {//Kurucu
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("{0} nesnesinin i�erik no: {1}/{2}", this, i�rk.ContextID, Thread.CurrentThread.GetHashCode());
            foreach (IContextProperty �zlk in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik: {0}", �zlk.Name);
        }
    }
    public class S�n�fC {
        public void Y�llar() {
            Console.Write ("-> {0}'�n y�llar�: ", Thread.CurrentThread.Name);
            for (int i = 0; i <= 57; i++) {Console.Write ((i+1881) + " "); Thread.Sleep (10);} Console.WriteLine();
        }
    }
    class Ana�p {
        private static void �pFonk() {Console.WriteLine ("Sicim metodunun no'su ve adresi: {0} ve {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode());}
        public static void Say() {for (int i = 1; i<=5; i++) Console.WriteLine ( "{0} saya�: {1}", Thread.CurrentThread.Name, i);}
        static void �pMetot() {
            Thread ip = Thread.CurrentThread;
            ip.Name = "Nihat";
            Console.WriteLine ("�p ad�: {0}", ip.Name);
            Console.WriteLine ("Canl� m�? {0}", ip.IsAlive);
            Console.WriteLine ("�nceli�i: {0}", ip.Priority);
            Console.WriteLine ("Durumu: {0}", ip.ThreadState);
            for(int i = 0; i < 100; i++) {Console.Write ("."); Thread.Sleep (1);}
        }
        static void Main() {
            Console.Write ("Main() metot i�indeki 'Thread ip=Thread.CurrentThread' ana sicim'dir; ip.Name ad, ip.Priority �ncelik, ip.ManagedThreadId no de�erleri atar; ip.IsAlive canl� m�, ip.ThreadState durumunu bildirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ana sicimin ad�, �nceli�i, no'su ve durumu:");
            Thread sicim = Thread.CurrentThread;
            if (sicim.Name == null) Console.WriteLine ("Ana sicime ad atanmam��.");
            else Console.WriteLine ("Ana sicimin ad�: " + sicim.Name);
            sicim.Name = "Ana-�p";
            Console.WriteLine ("Ana sicimin atanan ad�: " + sicim.Name);
            Console.WriteLine ("Varsay�l� �nceli�i: " + sicim.Priority);
            sicim.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine ("Atanan �nceli�i: " + sicim.Priority);
            Console.WriteLine ("Ana sicim no: " + sicim.ManagedThreadId);
            Console.WriteLine ("Canl� m�? {0}", sicim.IsAlive);
            Console.WriteLine ("Sicimin durumu: {0}", sicim.ThreadState);

            Console.WriteLine ("\nAna sicim ve sicim-fonksiyonun no'su ve adresi:");
            Thread ip = new Thread (new ThreadStart (�pFonk) );
            Console.WriteLine ("Ana sicimin no'su ve adresi: {0} ve {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode());
            ip.Start(); ip.Join();
        
            Thread.Sleep (1000); Console.WriteLine ("\nContext i�erikli sicim ve mevcut �zellikleri:");
            S�n�fA snfA1 = new S�n�fA();
            S�n�fA snfA2 = new S�n�fA();
            S�n�fB ebeveynliSnfB = new S�n�fB();

            Thread.Sleep (1000); Console.WriteLine ("\nArkaplandaki 3 sicim 1-->5'er saymakta:");
            Thread[] ipler = new Thread [3];
            for(int k = 0; k < ipler.Length; k++) {
                ipler [k] = new Thread (new ThreadStart (Say));
                ipler [k].Name = "Sicim#" + (k+1);
                ipler [k].IsBackground = true;
                ipler [k].Start();
                //ipler [k].Join(); //Kar���k �al��s�nlar
            }

            Thread.Sleep (1000); Console.WriteLine ("\nArkaplan ip detaylar� ve 100.'l�k bekletme:");
            ip = new Thread (new ThreadStart (�pMetot));
            ip.Priority = ThreadPriority.Highest;
            ip.IsBackground = true;
            ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nArkaplan ip Atat�rk'�n y�llar�n� 1881-->1938 yazmakta:");
            S�n�fC snfC = new S�n�fC();
            ip = new Thread (new ThreadStart (snfC.Y�llar));
            ip.Name="Atat�rk";
            ip.IsBackground = true;
            ip.Start(); Thread.Sleep (1000);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}