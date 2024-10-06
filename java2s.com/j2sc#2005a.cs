// j2sc#2005a.cs: Sicimi lock'la bloklama ve sayac� Interlocked.Increment(ref)'le birart�rma �rne�i.

using System;
using System.Threading;
namespace Sicimler {
    class Sicimlerim {
        public Thread ip;
        int[] say�lar;
        public Sicimlerim (string ad, int[] say�lar) {//Kurucu
            ip = new Thread (this.ko�);
            ip.Name = ad;
            this.say�lar = say�lar;
            ip.Start();
        }
        void ko�() {
            int toplam = topla();
            Console.WriteLine ("\tToplam = " + toplam);
        }  
        public int topla() {
            int toplam=0;
            lock (this) {
                  Console.Write (Thread.CurrentThread.Name);  
                  Thread.Sleep (100);
                  for(int i=0;i<say�lar.Length;i++) toplam += say�lar [i];
            }
            return toplam;
        }
    }
    class KilitliSaya� {
        private int saya�=1881;
        public void Say() {lock (this) {Console.Write (saya�++ + " ");}}
    }
    public class Yaz�c� {
        public void Y�llar�Yaz() {
            lock (this) {
                Console.WriteLine ("\t--> {0} Y�llar�Yaz()'� y�r�t�yor...", Thread.CurrentThread.Name);
                Console.Write ("Y�llar: ");
                Random r = new Random(); int y�l;
                for (int i = 0; i < 12; i++) {
                    Thread.Sleep (1 * r.Next (5));
                    y�l=r.Next(1881,1939);
                    Console.Write (y�l + " ");
                } Console.WriteLine();
            }
        }
    }
    class OrtakSaya� {public static int saya� = 0;}
    class Art�ranSicim {
        public Thread sicim;
        public Art�ranSicim (string ad) {//Kurucu
            sicim = new Thread (this.ko�);
            sicim.Name = ad;
            sicim.Start();
        }
        void ko�() {
            for(int i=0; i<10; i++) {
                Thread.Sleep (200);
                Interlocked.Increment (ref OrtakSaya�.saya�);
                Console.WriteLine (sicim.Name + ": " + OrtakSaya�.saya�);
            }
        }
    }
    class AzaltanSicim {
        public Thread sicim;
        public AzaltanSicim (string ad) {//Kurucu
            sicim = new Thread (this.ko�);
            sicim.Name = ad;
            sicim.Start();
        }
        void ko�() {
            for(int i=0; i<10; i++) {
                Thread.Sleep (100);
                Interlocked.Decrement (ref OrtakSaya�.saya�);
                Console.WriteLine (sicim.Name + ": " + OrtakSaya�.saya�);
            }
        }
    }
    class Saya�l�S�n�f {
        static int g�vensizSaya� = 0; //ref'siz
        static int g�venliSaya� = 0; //ref'li
        static public int G�vensizSaya� {get {return g�vensizSaya�;}}
        static public int G�venliSaya� {get {return g�venliSaya�;}}
        public Saya�l�S�n�f() {//Kurucu
            g�vensizSaya�++;
            Interlocked.Increment (ref g�venliSaya�);
        }
        ~Saya�l�S�n�f() {//Y�k�c�
            g�vensizSaya�--;
            Interlocked.Decrement (ref g�venliSaya�);
        }
    }
    class KilitA {
        private int ko�uSay� = 0;
        public  void Art�r() {
            while (ko�uSay� < 5) {
                int arac� = ko�uSay�;
                arac�++;
                Console.WriteLine (Thread.CurrentThread.Name + ": " + arac�);
                Thread.Sleep (100);
                ko�uSay� = arac�;
            }
        }
        public void SicimleriKo�tur() {
            Thread ip;
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "Sicim-1"; ip.Start();
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "Sicim-2"; ip.Start();
            ip = new Thread (new ThreadStart (Art�r)); ip.Name = "Sicim-3"; ip.Start();
        }
        public void Birart�r() {
            while (ko�uSay� < 15) {
                //Interlocked.Increment (ref ko�uSay�);
                Console.WriteLine (Thread.CurrentThread.Name + ": " + ++ko�uSay�);
                Thread.Sleep (10);
            }
        }
        public void SicimleriKo�tur2() {
            Thread ip1 = new Thread (new ThreadStart (Birart�r)); ip1.Name = "Mahmut";
            Thread ip2 = new Thread (new ThreadStart (Birart�r)); ip2.Name = "Nihat";
            Thread ip3 = new Thread (new ThreadStart (Birart�r)); ip3.Name = "Yava�";
            ip1.Start(); ip2.Start(); ip3.Start();
        }
        static void �pMetodu() {for(int i = 0; i < 500; i++) {new Saya�l�S�n�f();}}
        static void Main() {
            Console.Write ("lock{} blo�u, Join() gibi sicim g�revini (Monitor.Pulse yoksa) zamanpayla��ms�z b�t�nl�kte tamamlar. Interlocked.Decrement/Increment/Add/Exchange/CompareExchange: birazalt/birart�r/ekle/de�i�tir/k�yasende�i�tir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("3 sicimin herbiri zamanpayla��ml� 5'er kez ko�acak:");
            KilitA kltA = new KilitA();
            kltA.SicimleriKo�tur();

            Thread.Sleep (1000); Console.WriteLine ("\nHerbiri lock'lu 4 sicimli toplama g�revi:");
            int[] a = {1, 2, 3, 4, 5}; Sicimlerim scm = new Sicimlerim ("Sicim#1", a); scm.ip.Join();
            int[] b = {11, 12, 13, 14, 15, 16}; scm = new Sicimlerim ("Sicim#2", b); scm.ip.Join();
            int[] c = {110, 120, 130, 140}; scm = new Sicimlerim ("Sicim#3", c); scm.ip.Join();
            int[] d = {1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 16, 110, 120, 130, 140}; scm = new Sicimlerim ("Sicim#3", d); scm.ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nHerbiri kilitli artan [1881-->1938] saya� yazan 57 sicim:");
            KilitliSaya� ks = new KilitliSaya�();
            Thread[] y�llar = new Thread [58];
            int i;
            for(i=0;i<=57;i++) {y�llar [i] = new Thread (new ThreadStart (ks.Say)); y�llar [i].Start();}

            Thread.Sleep (1000); Console.WriteLine ("\n\n10 karma sicim, herbiri lock'lu 12 rasgele [1881,1938] y�l yaz�yor:");
            Yaz�c� yaz = new Yaz�c�();
            Thread[] ipler = new Thread [10];
            for(i=0;i<10;i++) {
                ipler [i] = new Thread (new ThreadStart (yaz.Y�llar�Yaz));
                ipler [i].Name = "���i#" + i;
            }
            foreach (Thread ip in ipler) ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n3 ayr� sicimin ayn� sayac� 1-->13 ard���k art�rmas�:");
            kltA.ko�uSay�=0; kltA.SicimleriKo�tur2();

            Thread.Sleep (1000); Console.WriteLine ("\nJoin'li 2 sicimin 'ref Interlock'la ayn� sayac� art�r�p azaltmas�:");
            Art�ranSicim art�rScm = new Art�ranSicim ("Art�ranSicim"); art�rScm.sicim.Join(); //Anl�k Join olmazsa sonsuz (art�r/azalt) saya�a tak�l�yor
            AzaltanSicim azaltScm = new AzaltanSicim ("AzaltanSicim"); azaltScm.sicim.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n3*500=1500 sicimli tiplemenin kurulmas� ve y�k�lmas�:");
            Thread ip1 = new Thread (new ThreadStart (�pMetodu));
            Thread ip2 = new Thread (new ThreadStart (�pMetodu));
            Thread ip3 = new Thread (new ThreadStart (�pMetodu));
            ip1.Start(); ip1.Join();
            ip2.Start(); ip2.Join();
            ip3.Start(); ip3.Join();
            Console.WriteLine ("ref'siz saya�: " + Saya�l�S�n�f.G�vensizSaya�);
            Console.WriteLine ("Interlock ref'li saya�: " + Saya�l�S�n�f.G�venliSaya�);
            GC.Collect();
            GC.WaitForPendingFinalizers(); //T�m y�k�c� ��pler (3 * 500 = 1500) bellekten temizlenir
            Console.WriteLine ("GC.Collect'le gerisay�ml� s�f�rlanan ref'siz saya�: " + Saya�l�S�n�f.G�vensizSaya�);
            Console.WriteLine ("GC.Collect'le gerisay�ml� s�f�rlanan ref'li saya�: " + Saya�l�S�n�f.G�venliSaya�);

            Thread.Sleep (1000); Console.WriteLine ("\nInterlocked.Decrement/Increment/Add/Exchange/CompareExchange sonu�lar�:");
            int intA = 1881;
            int intB = 1938;
            Console.WriteLine ("intA'n�n ilk de�eri = {0}", intA);
            Console.WriteLine ("intB'nin ilk de�eri = {0}", intB);
            Interlocked.Decrement (ref intA);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Decrement(ref) sonras� intA = {0}", intA);
            Interlocked.Increment (ref intB);
            Console.WriteLine ("Interlocked.Increment(ref) sonras� intB = {0}", intB);
            Interlocked.Add (ref intA, intB);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Add(ref intA, intB) sonras� intA = {0}", intA); //intA+=intB
            Console.WriteLine("Interlocked.Add(ref intA, intB) sonras� intB = {0}", intB); //De�i�mez
            Interlocked.Exchange (ref intB, intA);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Exchange(ref intB, intA) sonras� intA = {0}", intA); //De�i�mez
            Console.WriteLine ("Interlocked.Exchange(ref intB, intA) sonras� intB = {0}", intB); //intB=intA
            Interlocked.CompareExchange (ref intA, 1923, intB);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.CompareExchange(ref intA, 1923, intB) sonras� intA = {0}", intA);
            Console.WriteLine ("Interlocked.CompareExchange(ref intA, 1923, intB) sonras� intB = {0}", intB);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}