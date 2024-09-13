// j2sc#2001b.cs: Start ba�lat, Sleep uyut, Abort k�r �rne�i.

using System;
using System.Threading;
using System.Windows.Forms; //Form i�in
namespace �okluG�rev {
    class SicimA {public void Sicim() {Console.WriteLine ("SicimA s�n�f�n�n Sicim() metodu �a�r�ld�");}}
    class SicimB {
        public Thread ip;
        public SicimB (string ad) {ip = new Thread (this.ko�); ip.Name = ad; ip.Start();} //Kurucu
        void ko�() {
            Console.WriteLine (ip.Name + " adl� sicim ba�l�yor.");
            for (int i = 0; i < 100; i++) {  
                try {Console.Write (i + " ");
                    Thread.Sleep (50);
                }catch (ThreadAbortException ht) {
                    if ((int)ht.ExceptionState == 0) {Console.WriteLine ("ABORT iptal! Kod: " + ht.ExceptionState); Thread.ResetAbort();
                    }else Console.WriteLine ("Sicim ABORT'la sonland�r�l�yor! Kod: " + ht.ExceptionState); 
                }// catch sonu
            }// for sonu
            Console.WriteLine (ip.Name + " adl� s�cim normalen sonlan�yor");
        }// ko�() sonu
    }// SicimB sonu
    class SicimlerB {
        static void ��g�ren() {for (int i = 1; i < 100; i++) Console.Write ("��g�ren: {0}==> ", Thread.CurrentThread.ThreadState);}
        public static void Say() {for (int i = 0; i <= 10; i++) Console.Write ("Saya� {0}==> ", i);}
        private static void Fonk1() {Thread.Sleep (2000); Console.WriteLine ("2 sn uyuyup sicimi sonland�r�yorum");}
        public static Thread ip1;
        public static Thread ip2;
        public static void Saya�1() {
            Console.WriteLine ("Saya�1()'e girildi");
            for (int i = 1; i < 50; i++) {
                Console.Write (i + " ");
                if (i == 20) Thread.Sleep (1000);
            } Console.WriteLine();
            Console.WriteLine ("Saya�1()'den ��k�ld�");
        }
        public static void Saya�2() {//ThreadPriority.Highest ip2'ye i�lem �nceli�i
            Console.WriteLine ("Saya�2()'ye girildi");
            for (int i = 51; i < 100; i++) {
                Console.Write (i + " ");
                if (i == 70) Thread.Sleep (2000); //ip2 2sn uykudayken, ip1'in daha �nce sonlanmas� 
            } Console.WriteLine();
            Console.WriteLine ("Saya�2()'den ��k�ld�");
        }
        static void Main() {
            Console.Write ("'ip.Start()' metotla tiplenen sicimi ba�lat�r. 'Thread.Sleep(1000)' akt�el sicim ak���n� 1sn bekletir. 'ip.Abort()' ise akt�el sicim ak���n� yar�da kesip sonland�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sicimin ��g�ren() metotla yarat�l�p ba�lat�lmas� ve sonlanmas�:");
            Thread ip = new Thread (��g�ren); ip.Start();
            while (ip.IsAlive) {Thread.Sleep (5); Console.WriteLine ("Ara ara uyusam da, hala canl�y�m: {0}", ip.ThreadState);}
            Console.WriteLine ("Bittim: " + ip.ThreadState);

            Thread.Sleep (1000); Console.WriteLine ("\n10'a kadar say�p sonlanan sicim:");
            ip = new Thread (new ThreadStart (Say)); ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n\nFonk1()'le 2 sn uyuyup sonlanan sicim:");
            ip = new Thread (new ThreadStart (Fonk1)); ip.Start(); //Start'la sicim ba�lat�l�r ve Fonk1() �a�r�l�r, tamamlannca da sicim sonlan�r
            Console.WriteLine ("Akt�el sicim canl� m�? " + ip.IsAlive + "-" + ip.ThreadState);
            Thread.Sleep (2100); Console.WriteLine ("2.1 sn sonra akt�el sicim hala canl� m�? " + ip.IsAlive + "-" + ip.ThreadState);

            Thread.Sleep (1000); Console.WriteLine ("\nThreadPriority.Highest sicimin i�lem �nceli�i:");
            ip1 = new Thread (new ThreadStart (Saya�1));
            ip2 = new Thread (new ThreadStart (Saya�2));
            ip2.Priority = ThreadPriority.Highest;
            ip1.Start(); ip2.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n�lk 2.5sn'li�ine isimsiz, sonraki 2.5sn'de isim ba�l�kl� form:");
            Form form1 = new Form();
            form1.Show();
            Thread.Sleep (2500);
            form1.Text = "M.Nihat Yava�";
            Thread.Sleep(2500);

            Thread.Sleep (1000); Console.WriteLine ("\nRasgele 0-->1000 nokta sonras� k�r�lan sicim:");
            SicimA snfA = new SicimA();
            ip = new Thread (new ThreadStart (snfA.Sicim)); ip.Start();
            int i, ts; var r=new Random(); ts=r.Next(0,1000);
            for(i=0;i<ts;i++) Console.Write (".");
            ip.Abort(); Console.WriteLine ("{0} noktadan sonra ABORT", ts);

            Thread.Sleep (2000); Console.WriteLine ("\nSicimB'nin normalen veya ABORT'la sonlanmas�:");
            SicimB snfB = new SicimB ("SicimB-1"); Thread.Sleep (1000); Console.WriteLine ("SicimB-1 k�r�l�yor."); snfB.ip.Abort (100); 
            //snfB.ip.Join();
            snfB = new SicimB ("SicimB-2"); Thread.Sleep (1000); Console.WriteLine ("SicimB-2 k�r�lma iptali."); snfB.ip.Abort (0); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}