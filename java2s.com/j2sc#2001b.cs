// j2sc#2001b.cs: Start baþlat, Sleep uyut, Abort kýr örneði.

using System;
using System.Threading;
using System.Windows.Forms; //Form için
namespace ÇokluGörev {
    class SicimA {public void Sicim() {Console.WriteLine ("SicimA sýnýfýnýn Sicim() metodu çaðrýldý");}}
    class SicimB {
        public Thread ip;
        public SicimB (string ad) {ip = new Thread (this.koþ); ip.Name = ad; ip.Start();} //Kurucu
        void koþ() {
            Console.WriteLine (ip.Name + " adlý sicim baþlýyor.");
            for (int i = 0; i < 100; i++) {  
                try {Console.Write (i + " ");
                    Thread.Sleep (50);
                }catch (ThreadAbortException ht) {
                    if ((int)ht.ExceptionState == 0) {Console.WriteLine ("ABORT iptal! Kod: " + ht.ExceptionState); Thread.ResetAbort();
                    }else Console.WriteLine ("Sicim ABORT'la sonlandýrýlýyor! Kod: " + ht.ExceptionState); 
                }// catch sonu
            }// for sonu
            Console.WriteLine (ip.Name + " adlý sýcim normalen sonlanýyor");
        }// koþ() sonu
    }// SicimB sonu
    class SicimlerB {
        static void Ýþgören() {for (int i = 1; i < 100; i++) Console.Write ("Ýþgören: {0}==> ", Thread.CurrentThread.ThreadState);}
        public static void Say() {for (int i = 0; i <= 10; i++) Console.Write ("Sayaç {0}==> ", i);}
        private static void Fonk1() {Thread.Sleep (2000); Console.WriteLine ("2 sn uyuyup sicimi sonlandýrýyorum");}
        public static Thread ip1;
        public static Thread ip2;
        public static void Sayaç1() {
            Console.WriteLine ("Sayaç1()'e girildi");
            for (int i = 1; i < 50; i++) {
                Console.Write (i + " ");
                if (i == 20) Thread.Sleep (1000);
            } Console.WriteLine();
            Console.WriteLine ("Sayaç1()'den çýkýldý");
        }
        public static void Sayaç2() {//ThreadPriority.Highest ip2'ye iþlem önceliði
            Console.WriteLine ("Sayaç2()'ye girildi");
            for (int i = 51; i < 100; i++) {
                Console.Write (i + " ");
                if (i == 70) Thread.Sleep (2000); //ip2 2sn uykudayken, ip1'in daha önce sonlanmasý 
            } Console.WriteLine();
            Console.WriteLine ("Sayaç2()'den çýkýldý");
        }
        static void Main() {
            Console.Write ("'ip.Start()' metotla tiplenen sicimi baþlatýr. 'Thread.Sleep(1000)' aktüel sicim akýþýný 1sn bekletir. 'ip.Abort()' ise aktüel sicim akýþýný yarýda kesip sonlandýrýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sicimin Ýþgören() metotla yaratýlýp baþlatýlmasý ve sonlanmasý:");
            Thread ip = new Thread (Ýþgören); ip.Start();
            while (ip.IsAlive) {Thread.Sleep (5); Console.WriteLine ("Ara ara uyusam da, hala canlýyým: {0}", ip.ThreadState);}
            Console.WriteLine ("Bittim: " + ip.ThreadState);

            Thread.Sleep (1000); Console.WriteLine ("\n10'a kadar sayýp sonlanan sicim:");
            ip = new Thread (new ThreadStart (Say)); ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nFonk1()'le 2 sn uyuyup sonlanan sicim:");
            ip = new Thread (new ThreadStart (Fonk1)); ip.Start(); //Start'la sicim baþlatýlýr ve Fonk1() çaðrýlýr, tamamlannca da sicim sonlanýr
            Console.WriteLine ("Aktüel sicim canlý mý? " + ip.IsAlive + "-" + ip.ThreadState);
            Thread.Sleep (2100); Console.WriteLine ("2.1 sn sonra aktüel sicim hala canlý mý? " + ip.IsAlive + "-" + ip.ThreadState);

            Thread.Sleep (1000); Console.WriteLine ("\nThreadPriority.Highest sicimin iþlem önceliði:");
            ip1 = new Thread (new ThreadStart (Sayaç1));
            ip2 = new Thread (new ThreadStart (Sayaç2));
            ip2.Priority = ThreadPriority.Highest;
            ip1.Start(); ip2.Start();

            Thread.Sleep (1000); Console.WriteLine ("\nÝlk 2.5sn'liðine isimsiz, sonraki 2.5sn'de isim baþlýklý form:");
            Form form1 = new Form();
            form1.Show();
            Thread.Sleep (2500);
            form1.Text = "M.Nihat Yavaþ";
            Thread.Sleep(2500);

            Thread.Sleep (1000); Console.WriteLine ("\nRasgele 0-->1000 nokta sonrasý kýrýlan sicim:");
            SicimA snfA = new SicimA();
            ip = new Thread (new ThreadStart (snfA.Sicim)); ip.Start();
            int i, ts; var r=new Random(); ts=r.Next(0,1000);
            for(i=0;i<ts;i++) Console.Write (".");
            ip.Abort(); Console.WriteLine ("{0} noktadan sonra ABORT", ts);

            Thread.Sleep (2000); Console.WriteLine ("\nSicimB'nin normalen veya ABORT'la sonlanmasý:");
            SicimB snfB = new SicimB ("SicimB-1"); Thread.Sleep (1000); Console.WriteLine ("SicimB-1 kýrýlýyor."); snfB.ip.Abort (100); 
            //snfB.ip.Join();
            snfB = new SicimB ("SicimB-2"); Thread.Sleep (1000); Console.WriteLine ("SicimB-2 kýrýlma iptali."); snfB.ip.Abort (0); 

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}