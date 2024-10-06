// j2sc#2006b.cs: [ThreadStatic], Process, WaitHandle, Semaphore, Manual/AutoResetEvent �rne�i.

using System;
using System.Threading;
using System.Diagnostics; //Process, ProcessThreadCollection i�in
namespace �pTipleri {
    public class S�n�fA {
        public S�n�fA() {Console.WriteLine ("S�n�fA tiplemesi yarat�l�yor");} //Kurucu
    }
    public class StatikSicim {
        [ThreadStatic]
        public static S�n�fA snfA = new S�n�fA();
    }
    public class G�rev {
        [ThreadStatic] 
        static int no = 2024;
        public string  ipAd�;
        public void Ko� (string ipAd) {
            ipAd� = ipAd;
            Thread ip = new Thread (new ThreadStart (s�re�));
            ip.Start(); ip.Join();
        }
        public void s�re�() {
            Console.WriteLine ("\t{0} ko�uyor", ipAd�);
            for(int i = 0; i < 6; i++) Console.WriteLine ("{0} no = {1}", this.ipAd�, no++);
        }
    }
    class UyutucuSicim {
        AutoResetEvent otoYenileOlay� = new AutoResetEvent (false);
        public static WaitHandle BekletenY�netici() {
            UyutucuSicim us = new UyutucuSicim();
            Thread ip = new Thread (new ThreadStart (us.Uyut));
            ip.Start(); ip.Join();
            return (us.otoYenileOlay�);
        }
        public void Uyut() {
            Thread.Sleep (100);
            otoYenileOlay�.Set();
            Console.WriteLine ("\t-->Akt�elSicim#: {0} 100mS uyuttu...", Thread.CurrentThread.ManagedThreadId);
        }
    }
    class S�n�fB {
        public Thread ip;
        static Semaphore izin = new Semaphore(1,1);
        public S�n�fB (string ad) {//Kurucu
            ip = new Thread (this.ko�);
            ip.Name = ad;
            ip.Start(); ip.Join();
        }  
        void ko�() {
            Console.WriteLine (ip.Name + " �al��ma izni bekliyor...");
            izin.WaitOne();
            Console.WriteLine (ip.Name + " �al��ma iznini ald�.");
            Console.WriteLine ("\t-->���i no: " + Thread.CurrentThread.GetHashCode());
            Thread.Sleep (50);
            Console.WriteLine (ip.Name + " �al��ma iznini b�rak�yor.");
            izin.Release();
        }
    }
    class S�n�fC {
        public Thread ip;
        ManualResetEvent elleYenileOlay�;
        public S�n�fC (string ad, ManualResetEvent olay) {//Kurucu
            ip = new Thread (this.ko�);
            ip.Name = ad;  
            elleYenileOlay� = olay;
            ip.Start(); ip.Join();
        }
        void ko�() {
            Console.WriteLine ("\t{0} adl� sicim ko�uyor...", ip.Name);
            for(int i=0; i<3; i++) {Console.WriteLine("\t-->Sicim no: " + Thread.CurrentThread.GetHashCode()); Thread.Sleep (50);}
            Console.WriteLine ("\t{0}/{1} ko�usunu tamamlad�.", ip.Name, ip.ManagedThreadId);
            elleYenileOlay�.Set();
        }
    }
    public class S�n�fD {
        public RegisteredWaitHandle kay�tl�BekleY�netimi = null;
        public string bilgi=null;
    } 
    class Akt�el�p {
        private static void �pFonk() {
            Console.WriteLine ("\tSicim#{0} ba�l�yor...", Thread.CurrentThread.GetHashCode());
            Console.WriteLine ("StatikSicim.snfA: {0}", StatikSicim.snfA);
            Console.WriteLine ("Sicim#{0} sonlan�yor", Thread.CurrentThread.ManagedThreadId);
        }
        public static void ��lemSicimKoleksiyonu (int ��lemNo) {
            Process i�lem;
       mny: try {i�lem = Process.GetProcessById (��lemNo);} catch {��lemNo++; goto mny;}
            Console.WriteLine ("��lem no: " + ��lemNo);
            Console.WriteLine ("��lem ad�: " + i�lem.ProcessName);
            ProcessThreadCollection ipler = i�lem.Threads;
            foreach (ProcessThread pt in ipler) Console.WriteLine ("-> Sicim No: {0}\tBa�lama zaman�: {1}\t�ncelik: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
        }
        public static AutoResetEvent otoYenileOlay� = new AutoResetEvent (false);
        public static int endeks = 0;
        public static void Zamanlay�c�Y�netimi (object durum) {
            Console.Write ("Zamanlay�c�Y�netimi: ");
            if (++endeks % 5 == 0) otoYenileOlay�.Set();
            Console.WriteLine (endeks);
        }
        private static void OlayY�netimi (object durum, bool zamana��m�) {
            Console.WriteLine ("-->{0}\tZamana��m� m�? {1}\tDurum: {2}\t{3}", endeks++, zamana��m�, durum, DateTime.Now.ToString ("HH:mm:ss.ffff"));
            if (endeks % 5 == 0) otoYenileOlay�.Set();
        }
        public static void BekletMetodu (object durum, bool zamana��m�) {
            S�n�fD snfD = (S�n�fD) durum;
            if (endeks==0 & zamana��m�) Console.WriteLine ("Mahmut " + snfD.bilgi + " Yava�");
            if (endeks == 10 && snfD.kay�tl�BekleY�netimi != null) snfD.kay�tl�BekleY�netimi.Unregister (null); //D�ng� endeks=10'la s�n�rl�
            Console.WriteLine ("{0}/10-->BekletMetodu({1}) sicim#{2} ile {3} y�r�t�lmekte..", endeks++, snfD.bilgi, Thread.CurrentThread.GetHashCode(), "OTOS�NYALL�");
        }
        static void Main() {
            Console.Write ("[ThreadStatic]'in alt�ndaki statik sicim alan�d�r. Thread.CurrentThread.GetHashCode() veya Thread.CurrentThread.ManagedThreadId ayn�d�r, akt�el sicim no'yu verir. Timer Dispose() ile, RegisteredWaitHandle ise Unregister(null) ile devred��� b�rak�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 join'li sicim statik sicim alan�yla S�n�fA tiplemesi yarat�yor:");
            int i; Thread ip;
            for(i=0;i<5;i++) {
                ip = new Thread (new ThreadStart (�pFonk));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\n3 Ko�'lu sicimli g�rev ve 1 s�re�'li sicimsiz g�rev:");
            G�rev grv = new G�rev(); grv.Ko� ("Sicim#1");
            grv = new G�rev(); grv.Ko� ("Sicim#2");
            grv = new G�rev(); grv.Ko� ("Sicim#3");
            grv = new G�rev(); grv.ipAd�="Ustaba�� Main"; grv.s�re�();

            Thread.Sleep (1000); Console.WriteLine ("\nBellekte aktif ilk s�re� no, ad, ipleri, �ncelikleri:");
            ��lemSicimKoleksiyonu (2000);

            Thread.Sleep (1000); Console.WriteLine ("\n5 BekletenY�netici'nin 5 sicimle 100mS'�er bekletmesi:");
            WaitHandle[] bekletenler = new WaitHandle [5];
            Console.WriteLine ("Sicimlerin tamamlanmas� bekleniyor...");
            for(i=0;i<5;i++) bekletenler [i] = UyutucuSicim.BekletenY�netici();
            WaitHandle.WaitAll (bekletenler);
            Console.WriteLine ("Bekleten sicimler tamamland�");

            Thread.Sleep (1000); Console.WriteLine ("\n5 i��i sicimi �al��ma izni bekliyor, al�yor ve b�rak�yor:");
            S�n�fB snfB;
            for(i=0;i<5;i++) snfB = new S�n�fB ("���i#" + (i+1));

            Thread.Sleep (1000); Console.WriteLine ("\nElleYenileOlay'l� 5 sicim 3'er kerre ko�makta:");
            ManualResetEvent elleYenileOlay� = new ManualResetEvent (false);
            S�n�fC snfC;
            Console.WriteLine ("{0} no'lu ana sicim olayl� sicimleri bekliyor...", Thread.CurrentThread.ManagedThreadId);
            for(i=0;i<5;i++) {
                snfC = new S�n�fC ("Olayl�Sicim#"+(i+1), elleYenileOlay�);
                elleYenileOlay�.WaitOne();
                Console.WriteLine ("Ana sicim {0}.olay� tamamlad�.", i+1);
                elleYenileOlay�.Reset(); 
            }

            Thread.Sleep (1000); Console.WriteLine ("\n4 OtoYenileOlay'l� herbiri 5'er kez yenileyen zamanlay�c�:");
            Timer zamanlay�c�;
            for(i=0;i<4;i++) {
                zamanlay�c� = new Timer (new TimerCallback (Zamanlay�c�Y�netimi), null, 50, 100);
                otoYenileOlay�.WaitOne();
                Console.WriteLine ("Zamanlay�c� {0}.nci sinyalini tamamlad�.", i+1);
                zamanlay�c�.Dispose();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nHer 1sn'de yinelenen RegisteredWaitHandle Thread.Sleep(18000)'le s�n�rlan�r:");
            otoYenileOlay� = new AutoResetEvent (false);
            endeks = 0;
            string durum = "Oto sinyalli.";
            RegisteredWaitHandle kay�tl�BekleY�netimi = null;
            kay�tl�BekleY�netimi = ThreadPool.RegisterWaitForSingleObject (otoYenileOlay�, OlayY�netimi, durum, 1000, false);
            Thread.Sleep (17500);
            Console.WriteLine ("Bekle i�lemi kay�t d��� b�rak�l�yor.");
            kay�tl�BekleY�netimi.Unregister (null);

            Thread.Sleep (1000); Console.WriteLine ("\nHer 10msn'de yinelenen RegisteredWaitHandle d�ng�s� endeks=10 ile s�n�rlan�r:");
            otoYenileOlay� = new AutoResetEvent (false);
            endeks = 0;
            S�n�fD snfD = new S�n�fD();
            snfD.bilgi = "Nihat";
            snfD.kay�tl�BekleY�netimi = ThreadPool.RegisterWaitForSingleObject (otoYenileOlay�, new WaitOrTimerCallback (BekletMetodu), snfD, 10, false);
            //otoYenileOlay�.Set();
            Thread.Sleep (1000);
            Console.WriteLine ("Bekle i�lemi [snfD.kay�tl�BekleY�netimi.Unregister(null)] ile kay�t d��� b�rak�ld�.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}