// j2sc#2001c.cs: Join birleþtir ve Interrupt uyku iptali örneði.

using System;
using System.Threading;
namespace ÇokluGörev {
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
        int sayaç;
        public Thread scm;
        public SicimB (string ad) {//Kurucu
            sayaç = 0;
            scm = new Thread (this.koþ);
            scm.Name = ad;
            scm.Start();
        }
        void koþ() {
            Console.WriteLine (scm.Name + " adlý sicim baþlýyor...");
            do {Thread.Sleep (500);
                Console.WriteLine (scm.Name + "'ýn sicim sayacý: " + sayaç);
                sayaç++;
            }while (sayaç < 5);
            Console.WriteLine (scm.Name + " adlý sicim sonlandý.");
        }
    }
    class SicimlerC {
        private static void Say() {// 5sn'de 5 zaman gösterecek
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
            }catch (ThreadAbortException ht) {Console.WriteLine ("Sicim uykusu kýrýldý: [{0}]\nVe kýrýlma iptal edildi", ht.Message); Thread.ResetAbort();}
        }
        public static Thread uykucu;
        public static Thread iþgüzar;
        public static void UyumaSicimi() {
            for (int i = 1; i < 10; i++) {
                Console.WriteLine ("Uyku sayacý: " + i);
                Thread.Sleep (0); //Uyku kesilse de 0+ mS hatalý prg.kapýyor
            }
        }
        public static void UyanmaSicimi() {
            for (int i = 11; i < 20; i++) {
                Console.Write (i + " ");
                if (uykucu.ThreadState == ThreadState.WaitSleepJoin) {Console.WriteLine ("Uyku iptal edildi"); uykucu.Interrupt();}
            }
        }
        public static void AzalanSayaç() {
            for (int i = 5; i >= 0; i--) {
                Console.WriteLine ("Sicim#{0}-AzalanSayaç: {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep (2);
            }
            Console.WriteLine ("Sicim#{0} sonlanýyor.", Thread.CurrentThread.Name);
        }
        public static void ArtanSayaç() {
            for (int i = 0; i < 5; i++) {
                Console.WriteLine ("Sicim#{0}-ArtanSayaç: {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep (2);
            }
            Console.WriteLine ("Sicim#{0} sonlanýyor.", Thread.CurrentThread.Name);
        }
        static void Main() {
            Console.Write ("Hemen ip.Start()'ý takiben yapýlan ip.Join() görev bütünlüðünü saðlar. Thread.Sleep(mS) beklemesi, ip.Interrupt() tarafýndan iptal edilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ip.Join(2000) ile baþlayan asenkron sicim 2sn sonra kesintisiz göreve geçer:");
            Thread ip = new Thread (Say);
            Console.WriteLine ("{0} : Say() metotlu sicim baþlýyor", DateTime.Now.ToString ("HH:mm:ss.ffff"));
            ip.Start(); //Asenkron ip araya baþka görevler alabilir
            if (!ip.Join (2000)) Console.WriteLine ("{0} : Hala ip.Join(2000) bloklu DEÐÝLDÝ", DateTime.Now.ToString ("HH:mm:ss.ffff"));
            ip.Join(); //Artýk tüm Say() blok olarak tamamlanmadan araya baþka görevler almaz
            if (ip.Join(0)) Console.WriteLine ("{0} : ip.Join(2000) sonrasý birleþik bloklu OLDU", DateTime.Now.ToString ("HH:mm:ss.ffff"));

            Thread.Sleep (1000); Console.WriteLine ("\nSýnýf UykuSicimi Uyu metotla 5sn bekletip ip.Join() yapýlmakta:");
            ip = SicimA.UykuSicimi();
            Console.WriteLine ("ip.Join() ile görev bileþik blok yapýlýyor...");
            ip.Join(); Console.WriteLine ("Ýp birleþti.");

            Thread.Sleep (1000); Console.WriteLine ("\nscm.Start() ardýndaki scm.Join() tüm sicimleri ayrý blok yapar:");
            Console.WriteLine ("3.görev baþlýyor...");
            SicimB snfB1 = new SicimB ("Nihat"); snfB1.scm.Join(); Console.WriteLine ("Nihat adlý sicim birleþti.");
            SicimB snfB2 = new SicimB ("Hatice"); snfB2.scm.Join(); Console.WriteLine ("Nihal adlý sicim birleþti.");
            SicimB snfB3 = new SicimB ("Sevim"); snfB3.scm.Join(); Console.WriteLine ("Sevim adlý sicim birleþti.");
            Console.WriteLine ("3.görev sonlandý.");

            Thread.Sleep (1000); Console.WriteLine ("\nSicimin herbiri ardýþýk Start'la Join yaparak görevleri bloklar:");
            Thread[] ipler = new Thread [ipAdet];
            for(int k=0; k<ipAdet; k++) {
                ipler [k] = new Thread (new ThreadStart (Say2));
                ipler [k].Name = "Ýp#" + k;
                ipler [k].Start(); ipler [k].Join();
            }
            //for(int k=0; k<ipAdet; k++) ipler [k].Join(); //Join harici olsaydý bloklama etkisizleþirdi

            Thread.Sleep (1000); Console.WriteLine ("\nip.Interrupt(), Sleep beklemeyi keserek iptal eder:");
            ip = new Thread (new ThreadStart (Uyu)); ip.Start(); ip.Abort();
            ip = new Thread (new ThreadStart (Uyu)); ip.Start(); ip.Interrupt();
            ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nuykucu.Start()'ýn Sleep'i iþgüzar.Start()'ca iptal edilmekte:");
            uykucu = new Thread (new ThreadStart (UyumaSicimi));
            iþgüzar = new Thread (new ThreadStart (UyanmaSicimi));
            uykucu.Start();
            iþgüzar.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\n4 adet ÝP1-->ÝP4 ve azalanýn 5-->0, artanýn 0-->4 sayaçlarý:");
            Thread[] ipDizi = {new Thread (new ThreadStart (AzalanSayaç)), new Thread (new ThreadStart (ArtanSayaç)), new Thread (new ThreadStart (AzalanSayaç)), new Thread (new ThreadStart (ArtanSayaç))};
            int adNo = 1;
            foreach (Thread scm in ipDizi) {
                scm.IsBackground = true;
                scm.Start();
                scm.Name = "ÝP" + adNo.ToString();
                adNo++;
                Console.WriteLine ("Baþlayan görev: {0}", scm.Name);
                scm.Join(); //ÝP-adNo atandýktan sonra bloklama
                Thread.Sleep (50); //Bu uyku süresi alttaki ip.Abort()'u geçersiz kýlar, görev tamamlanýr
            }
            ipDizi [0].Interrupt(); //Uyku iptal
            ipDizi [1].Abort(); //Görev yarýda kýrýlýr
            //foreach (Thread scm in ipDizi) scm.Join(); //Sonraki ip.Join() bloklamada geç kalýr, görevler birbirine karýþýr

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}