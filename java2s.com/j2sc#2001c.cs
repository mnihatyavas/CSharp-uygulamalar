// j2sc#2001c.cs: Join birle�tir ve Interrupt uyku iptali �rne�i.

using System;
using System.Threading;
namespace �okluG�rev {
    class SicimA {
        public void Uyu() {Console.WriteLine ("{0} saniye uyuyacak", 5); Thread.Sleep (5 * 1000);}
        public static Thread UykuSicimi() {
            SicimA snfA = new SicimA();
            Thread ip = new Thread (new ThreadStart (snfA.Uyu));
            ip.Start();
            return (ip);
        }
    }
    class SicimB {
        int saya�;
        public Thread scm;
        public SicimB (string ad) {//Kurucu
            saya� = 0;
            scm = new Thread (this.ko�);
            scm.Name = ad;
            scm.Start();
        }
        void ko�() {
            Console.WriteLine (scm.Name + " adl� sicim ba�l�yor...");
            do {Thread.Sleep (500);
                Console.WriteLine (scm.Name + "'�n sicim sayac�: " + saya�);
                saya�++;
            }while (saya� < 5);
            Console.WriteLine (scm.Name + " adl� sicim sonland�.");
        }
    }
    class SicimlerC {
        private static void Say() {// 5sn'de 5 zaman g�sterecek
            for (int i = 0; i < 10; i++) {
                Console.WriteLine ("{0}==> Say() metotlu sicim", DateTime.Now.ToString ("HH:mm:ss.ffff"));
                Thread.Sleep (1000);
            }
        }
        private static int ipAdet = 5;
        public static void Say2() {for (int i = 0; i <= 3; i++) Console.WriteLine ("{0}: {1}", Thread.CurrentThread.Name, i);}
        public static void Uyu() {
            try {Thread.Sleep (Timeout.Infinite);
            }catch (ThreadInterruptedException ht) {Console.WriteLine ("Sicim kesildi: [{0}]", ht.Message); //ip.Interrupt(), sonsuz uykuyu keser
            }catch (ThreadAbortException ht) {Console.WriteLine ("Sicim uykusu k�r�ld�: [{0}]\nVe k�r�lma iptal edildi", ht.Message); Thread.ResetAbort();}
        }
        public static Thread uykucu;
        public static Thread i�g�zar;
        public static void UyumaSicimi() {
            for (int i = 1; i < 10; i++) {
                Console.WriteLine ("Uyku sayac�: " + i);
                Thread.Sleep (0); //Uyku kesilse de 0+ mS hatal� prg.kap�yor
            }
        }
        public static void UyanmaSicimi() {
            for (int i = 11; i < 20; i++) {
                Console.Write (i + " ");
                if (uykucu.ThreadState == ThreadState.WaitSleepJoin) {Console.WriteLine ("Uyku iptal edildi"); uykucu.Interrupt();}
            }
        }
        public static void AzalanSaya�() {
            for (int i = 5; i >= 0; i--) {
                Console.WriteLine ("Sicim#{0}-AzalanSaya�: {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep (2);
            }
            Console.WriteLine ("Sicim#{0} sonlan�yor.", Thread.CurrentThread.Name);
        }
        public static void ArtanSaya�() {
            for (int i = 0; i < 5; i++) {
                Console.WriteLine ("Sicim#{0}-ArtanSaya�: {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep (2);
            }
            Console.WriteLine ("Sicim#{0} sonlan�yor.", Thread.CurrentThread.Name);
        }
        static void Main() {
            Console.Write ("Hemen ip.Start()'� takiben yap�lan ip.Join() g�rev b�t�nl���n� sa�lar. Thread.Sleep(mS) beklemesi, ip.Interrupt() taraf�ndan iptal edilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ip.Join(2000) ile ba�layan asenkron sicim 2sn sonra kesintisiz g�reve ge�er:");
            Thread ip = new Thread (Say);
            Console.WriteLine ("{0} : Say() metotlu sicim ba�l�yor", DateTime.Now.ToString ("HH:mm:ss.ffff"));
            ip.Start(); //Asenkron ip araya ba�ka g�revler alabilir
            if (!ip.Join (2000)) Console.WriteLine ("{0} : Hala ip.Join(2000) bloklu DE��LD�", DateTime.Now.ToString ("HH:mm:ss.ffff"));
            ip.Join(); //Art�k t�m Say() blok olarak tamamlanmadan araya ba�ka g�revler almaz
            if (ip.Join(0)) Console.WriteLine ("{0} : ip.Join(2000) sonras� birle�ik bloklu OLDU", DateTime.Now.ToString ("HH:mm:ss.ffff"));

            Thread.Sleep (1000); Console.WriteLine ("\nS�n�f UykuSicimi Uyu metotla 5sn bekletip ip.Join() yap�lmakta:");
            ip = SicimA.UykuSicimi();
            Console.WriteLine ("ip.Join() ile g�rev bile�ik blok yap�l�yor...");
            ip.Join(); Console.WriteLine ("�p birle�ti.");

            Thread.Sleep (1000); Console.WriteLine ("\nscm.Start() ard�ndaki scm.Join() t�m sicimleri ayr� blok yapar:");
            Console.WriteLine ("3.g�rev ba�l�yor...");
            SicimB snfB1 = new SicimB ("Nihat"); snfB1.scm.Join(); Console.WriteLine ("Nihat adl� sicim birle�ti.");
            SicimB snfB2 = new SicimB ("Hatice"); snfB2.scm.Join(); Console.WriteLine ("Nihal adl� sicim birle�ti.");
            SicimB snfB3 = new SicimB ("Sevim"); snfB3.scm.Join(); Console.WriteLine ("Sevim adl� sicim birle�ti.");
            Console.WriteLine ("3.g�rev sonland�.");

            Thread.Sleep (1000); Console.WriteLine ("\nSicimin herbiri ard���k Start'la Join yaparak g�revleri bloklar:");
            Thread[] ipler = new Thread [ipAdet];
            for(int k=0; k<ipAdet; k++) {
                ipler [k] = new Thread (new ThreadStart (Say2));
                ipler [k].Name = "�p#" + k;
                ipler [k].Start(); ipler [k].Join();
            }
            //for(int k=0; k<ipAdet; k++) ipler [k].Join(); //Join harici olsayd� bloklama etkisizle�irdi

            Thread.Sleep (1000); Console.WriteLine ("\nip.Interrupt(), Sleep beklemeyi keserek iptal eder:");
            ip = new Thread (new ThreadStart (Uyu)); ip.Start(); ip.Abort();
            ip = new Thread (new ThreadStart (Uyu)); ip.Start(); ip.Interrupt();
            ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nuykucu.Start()'�n Sleep'i i�g�zar.Start()'ca iptal edilmekte:");
            uykucu = new Thread (new ThreadStart (UyumaSicimi));
            i�g�zar = new Thread (new ThreadStart (UyanmaSicimi));
            uykucu.Start();
            i�g�zar.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\n4 adet �P1-->�P4 ve azalan�n 5-->0, artan�n 0-->4 saya�lar�:");
            Thread[] ipDizi = {new Thread (new ThreadStart (AzalanSaya�)), new Thread (new ThreadStart (ArtanSaya�)), new Thread (new ThreadStart (AzalanSaya�)), new Thread (new ThreadStart (ArtanSaya�))};
            int adNo = 1;
            foreach (Thread scm in ipDizi) {
                scm.IsBackground = true;
                scm.Start();
                scm.Name = "�P" + adNo.ToString();
                adNo++;
                Console.WriteLine ("Ba�layan g�rev: {0}", scm.Name);
                scm.Join(); //�P-adNo atand�ktan sonra bloklama
                Thread.Sleep (50); //Bu uyku s�resi alttaki ip.Abort()'u ge�ersiz k�lar, g�rev tamamlan�r
            }
            ipDizi [0].Interrupt(); //Uyku iptal
            ipDizi [1].Abort(); //G�rev yar�da k�r�l�r
            //foreach (Thread scm in ipDizi) scm.Join(); //Sonraki ip.Join() bloklamada ge� kal�r, g�revler birbirine kar���r

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}