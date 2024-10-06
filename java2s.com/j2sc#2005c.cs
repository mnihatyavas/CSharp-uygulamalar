// j2sc#2005c.cs: lock{} blo�u gibi Mutex.WaitOne-ReleaseMutex �rne�i.

using System;
using System.Collections; //ArrayList i�in
using System.Threading; //Mutex i�in
namespace Sicimler {
    class Saya� {
        public static int saya� = 0;
        public static Mutex muteksKilit = new Mutex();
    }
    class Art�ranSicim {
        public Thread sicim;
        public Art�ranSicim() {sicim = new Thread (this.ko�); sicim.Start();} //Kurucu
        void ko�() {
            Console.WriteLine ("Art�ranSicim muteks i�in bekliyor.");
            Saya�.muteksKilit.WaitOne();
            Console.WriteLine ("Art�ranSicim muteksi yakalad�."); 
            int n = 10;
            do {Thread.Sleep (10);
                Console.WriteLine ("Art�ranSicim saya�: " + Saya�.saya�++);
                n--;
            }while (n >= 0);
            Console.WriteLine ("Art�ranSicim muteksi b�rak�yor.");
            Saya�.muteksKilit.ReleaseMutex();
        }
    }
    class AzaltanSicim {
        public Thread sicim;  
        public AzaltanSicim() {sicim = new Thread (new ThreadStart (this.ko�)); sicim.Start();}  //Kurucu
        void ko�() {
            Console.WriteLine ("AzaltanSicim muteks i�in bekliyor.");
            Saya�.muteksKilit.WaitOne();
            Console.WriteLine ("AzaltanSicim muteksi yakalad�.");
            int n = 10;
            do {Thread.Sleep (10); 
                Console.WriteLine ("AzaltanSicim saya�: " + --Saya�.saya�);
                n--;
            }while (n >= 0);  
            Console.WriteLine("AzaltanSicim muteksi b�rak�yor.");
            Saya�.muteksKilit.ReleaseMutex();
        }
    }
    class MutexBlok {
        public static ArrayList liste = new ArrayList();
        private static Mutex muteks = new Mutex (false, "Nihat");
        protected static void muteksMetodu() {
            muteks.WaitOne();
            for(int i=0;i<=57;i++) liste.Add (i+1881);
            for(int i=0;i<=57;i++) Console.Write (liste [i] + " ");
            muteks.ReleaseMutex();
        }
        private static int Ko�ular = 0;
        static Mutex muteks2 = new Mutex (false, "Muteksli Ko�ular");
        public static void Art�r() {
            while (Ko�ular < 57) {
                muteks2.WaitOne(); //muteks blo�u
                Console.Write (Thread.CurrentThread.Name + "-" + (Ko�ular++ +1881) + " ");
                Thread.Sleep (10);
                muteks2.ReleaseMutex();
            }
        }
        private static Mutex mut = new Mutex();
        private static void ip���isi() {for(int i = 0; i < 4; i++) Kaynaklar�Kullan();}
        private static void Kaynaklar�Kullan() {
            mut.WaitOne();
            Console.WriteLine ("{0} {1}.muteksi yakalad�", Thread.CurrentThread.Name, ++Ko�ular);
            Thread.Sleep (10);
            mut.ReleaseMutex();
            Console.WriteLine ("\t{0} {1}.muteksi b�rakt�", Thread.CurrentThread.Name, Ko�ular);
        }
        static void Main() {
            Console.Write ("new Mutex.WaitOne() aradaki kodlamalar� ReleaseMutex()'e de�in bloklar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Mutex bloklu [1881-->1938] y�llar� listeye ekleme ve sunma:");
            Thread ip = new Thread (new ThreadStart (muteksMetodu));
            ip.Start(); //lock, ReaderWriterLock, Join yerine Mutex blo�u

            Thread.Sleep (1000); Console.WriteLine ("\nMutex kilitle sayac� [0-->10-->0] art�ran ve azaltan sicimler:");
            Art�ranSicim ip1 = new Art�ranSicim();
            AzaltanSicim ip2 = new AzaltanSicim();
            //ip1.sicim.Join(); ip2.sicim.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n3 sicimle y�llar� [1881-->1938] payla��ml� art�rma:");
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "M.Kemal-"; ip.Start();
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "Atat�rk-"; ip.Start();
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "Gazi M.Kemal-"; ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nVerili adl� muteksin yakalanm��l�k kontrolu:");
            bool muteksliMi = false;
            if (!muteksliMi) Console.WriteLine ("Hen�z muteks tiplemesi yarat�lmam��.");
            using (Mutex muteks3 = new Mutex (true, "Muteks Kontrolu", out muteksliMi)) {
                if (muteksliMi) {
                    Console.WriteLine ("Muteks yakalanm��");
                    muteks3.ReleaseMutex();
                }else Console.WriteLine ("Ayn� adl� birba�ka muteks halihaz�rda mevcut.");
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 ayr� muteksi yakalama ve b�rakma:");
            string muteksAd�;
            Mutex muteks4 = null;
            for(int i=1;i<=5;i++) {
               muteksAd�="Nihat#"+i; muteks4 = new Mutex (false, muteksAd�);
               muteks4.WaitOne();
               Console.WriteLine ("{0} muteks yakaland�", muteksAd�);
               Thread.Sleep (500);
               muteks4.ReleaseMutex();
               Console.WriteLine ("\t{0} muteks b�rak�ld�", muteksAd�);
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 sicimin herbiri 4'er muteksi yakalay�p b�rakmakta:");
            for(int i = 0; i < 5; i++) {
                Ko�ular = 0;
                ip = new Thread (new ThreadStart (ip���isi));
                ip.Name = String.Format ("Sicim#{0}", (i + 1));
                ip.Start(); ip.Join(); //Join'suz olmaz, Ko�ular 1-->4'er de�il 1-->19 artar
            } Thread.Sleep (1000);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}