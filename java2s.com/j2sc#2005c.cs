// j2sc#2005c.cs: lock{} bloðu gibi Mutex.WaitOne-ReleaseMutex örneði.

using System;
using System.Collections; //ArrayList için
using System.Threading; //Mutex için
namespace Sicimler {
    class Sayaç {
        public static int sayaç = 0;
        public static Mutex muteksKilit = new Mutex();
    }
    class ArtýranSicim {
        public Thread sicim;
        public ArtýranSicim() {sicim = new Thread (this.koþ); sicim.Start();} //Kurucu
        void koþ() {
            Console.WriteLine ("ArtýranSicim muteks için bekliyor.");
            Sayaç.muteksKilit.WaitOne();
            Console.WriteLine ("ArtýranSicim muteksi yakaladý."); 
            int n = 10;
            do {Thread.Sleep (10);
                Console.WriteLine ("ArtýranSicim sayaç: " + Sayaç.sayaç++);
                n--;
            }while (n >= 0);
            Console.WriteLine ("ArtýranSicim muteksi býrakýyor.");
            Sayaç.muteksKilit.ReleaseMutex();
        }
    }
    class AzaltanSicim {
        public Thread sicim;  
        public AzaltanSicim() {sicim = new Thread (new ThreadStart (this.koþ)); sicim.Start();}  //Kurucu
        void koþ() {
            Console.WriteLine ("AzaltanSicim muteks için bekliyor.");
            Sayaç.muteksKilit.WaitOne();
            Console.WriteLine ("AzaltanSicim muteksi yakaladý.");
            int n = 10;
            do {Thread.Sleep (10); 
                Console.WriteLine ("AzaltanSicim sayaç: " + --Sayaç.sayaç);
                n--;
            }while (n >= 0);  
            Console.WriteLine("AzaltanSicim muteksi býrakýyor.");
            Sayaç.muteksKilit.ReleaseMutex();
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
        private static int Koþular = 0;
        static Mutex muteks2 = new Mutex (false, "Muteksli Koþular");
        public static void Artýr() {
            while (Koþular < 57) {
                muteks2.WaitOne(); //muteks bloðu
                Console.Write (Thread.CurrentThread.Name + "-" + (Koþular++ +1881) + " ");
                Thread.Sleep (10);
                muteks2.ReleaseMutex();
            }
        }
        private static Mutex mut = new Mutex();
        private static void ipÝþçisi() {for(int i = 0; i < 4; i++) KaynaklarýKullan();}
        private static void KaynaklarýKullan() {
            mut.WaitOne();
            Console.WriteLine ("{0} {1}.muteksi yakaladý", Thread.CurrentThread.Name, ++Koþular);
            Thread.Sleep (10);
            mut.ReleaseMutex();
            Console.WriteLine ("\t{0} {1}.muteksi býraktý", Thread.CurrentThread.Name, Koþular);
        }
        static void Main() {
            Console.Write ("new Mutex.WaitOne() aradaki kodlamalarý ReleaseMutex()'e deðin bloklar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Mutex bloklu [1881-->1938] yýllarý listeye ekleme ve sunma:");
            Thread ip = new Thread (new ThreadStart (muteksMetodu));
            ip.Start(); //lock, ReaderWriterLock, Join yerine Mutex bloðu

            Thread.Sleep (1000); Console.WriteLine ("\nMutex kilitle sayacý [0-->10-->0] artýran ve azaltan sicimler:");
            ArtýranSicim ip1 = new ArtýranSicim();
            AzaltanSicim ip2 = new AzaltanSicim();
            //ip1.sicim.Join(); ip2.sicim.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n3 sicimle yýllarý [1881-->1938] paylaþýmlý artýrma:");
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "M.Kemal-"; ip.Start();
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "Atatürk-"; ip.Start();
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "Gazi M.Kemal-"; ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nVerili adlý muteksin yakalanmýþlýk kontrolu:");
            bool muteksliMi = false;
            if (!muteksliMi) Console.WriteLine ("Henüz muteks tiplemesi yaratýlmamýþ.");
            using (Mutex muteks3 = new Mutex (true, "Muteks Kontrolu", out muteksliMi)) {
                if (muteksliMi) {
                    Console.WriteLine ("Muteks yakalanmýþ");
                    muteks3.ReleaseMutex();
                }else Console.WriteLine ("Ayný adlý birbaþka muteks halihazýrda mevcut.");
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 ayrý muteksi yakalama ve býrakma:");
            string muteksAdý;
            Mutex muteks4 = null;
            for(int i=1;i<=5;i++) {
               muteksAdý="Nihat#"+i; muteks4 = new Mutex (false, muteksAdý);
               muteks4.WaitOne();
               Console.WriteLine ("{0} muteks yakalandý", muteksAdý);
               Thread.Sleep (500);
               muteks4.ReleaseMutex();
               Console.WriteLine ("\t{0} muteks býrakýldý", muteksAdý);
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 sicimin herbiri 4'er muteksi yakalayýp býrakmakta:");
            for(int i = 0; i < 5; i++) {
                Koþular = 0;
                ip = new Thread (new ThreadStart (ipÝþçisi));
                ip.Name = String.Format ("Sicim#{0}", (i + 1));
                ip.Start(); ip.Join(); //Join'suz olmaz, Koþular 1-->4'er deðil 1-->19 artar
            } Thread.Sleep (1000);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}