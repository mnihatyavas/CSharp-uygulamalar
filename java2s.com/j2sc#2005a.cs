// j2sc#2005a.cs: Sicimi lock'la bloklama ve sayacý Interlocked.Increment(ref)'le birartýrma örneði.

using System;
using System.Threading;
namespace Sicimler {
    class Sicimlerim {
        public Thread ip;
        int[] sayýlar;
        public Sicimlerim (string ad, int[] sayýlar) {//Kurucu
            ip = new Thread (this.koþ);
            ip.Name = ad;
            this.sayýlar = sayýlar;
            ip.Start();
        }
        void koþ() {
            int toplam = topla();
            Console.WriteLine ("\tToplam = " + toplam);
        }  
        public int topla() {
            int toplam=0;
            lock (this) {
                  Console.Write (Thread.CurrentThread.Name);  
                  Thread.Sleep (100);
                  for(int i=0;i<sayýlar.Length;i++) toplam += sayýlar [i];
            }
            return toplam;
        }
    }
    class KilitliSayaç {
        private int sayaç=1881;
        public void Say() {lock (this) {Console.Write (sayaç++ + " ");}}
    }
    public class Yazýcý {
        public void YýllarýYaz() {
            lock (this) {
                Console.WriteLine ("\t--> {0} YýllarýYaz()'ý yürütüyor...", Thread.CurrentThread.Name);
                Console.Write ("Yýllar: ");
                Random r = new Random(); int yýl;
                for (int i = 0; i < 12; i++) {
                    Thread.Sleep (1 * r.Next (5));
                    yýl=r.Next(1881,1939);
                    Console.Write (yýl + " ");
                } Console.WriteLine();
            }
        }
    }
    class OrtakSayaç {public static int sayaç = 0;}
    class ArtýranSicim {
        public Thread sicim;
        public ArtýranSicim (string ad) {//Kurucu
            sicim = new Thread (this.koþ);
            sicim.Name = ad;
            sicim.Start();
        }
        void koþ() {
            for(int i=0; i<10; i++) {
                Thread.Sleep (200);
                Interlocked.Increment (ref OrtakSayaç.sayaç);
                Console.WriteLine (sicim.Name + ": " + OrtakSayaç.sayaç);
            }
        }
    }
    class AzaltanSicim {
        public Thread sicim;
        public AzaltanSicim (string ad) {//Kurucu
            sicim = new Thread (this.koþ);
            sicim.Name = ad;
            sicim.Start();
        }
        void koþ() {
            for(int i=0; i<10; i++) {
                Thread.Sleep (100);
                Interlocked.Decrement (ref OrtakSayaç.sayaç);
                Console.WriteLine (sicim.Name + ": " + OrtakSayaç.sayaç);
            }
        }
    }
    class SayaçlýSýnýf {
        static int güvensizSayaç = 0; //ref'siz
        static int güvenliSayaç = 0; //ref'li
        static public int GüvensizSayaç {get {return güvensizSayaç;}}
        static public int GüvenliSayaç {get {return güvenliSayaç;}}
        public SayaçlýSýnýf() {//Kurucu
            güvensizSayaç++;
            Interlocked.Increment (ref güvenliSayaç);
        }
        ~SayaçlýSýnýf() {//Yýkýcý
            güvensizSayaç--;
            Interlocked.Decrement (ref güvenliSayaç);
        }
    }
    class KilitA {
        private int koþuSayý = 0;
        public  void Artýr() {
            while (koþuSayý < 5) {
                int aracý = koþuSayý;
                aracý++;
                Console.WriteLine (Thread.CurrentThread.Name + ": " + aracý);
                Thread.Sleep (100);
                koþuSayý = aracý;
            }
        }
        public void SicimleriKoþtur() {
            Thread ip;
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "Sicim-1"; ip.Start();
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "Sicim-2"; ip.Start();
            ip = new Thread (new ThreadStart (Artýr)); ip.Name = "Sicim-3"; ip.Start();
        }
        public void Birartýr() {
            while (koþuSayý < 15) {
                //Interlocked.Increment (ref koþuSayý);
                Console.WriteLine (Thread.CurrentThread.Name + ": " + ++koþuSayý);
                Thread.Sleep (10);
            }
        }
        public void SicimleriKoþtur2() {
            Thread ip1 = new Thread (new ThreadStart (Birartýr)); ip1.Name = "Mahmut";
            Thread ip2 = new Thread (new ThreadStart (Birartýr)); ip2.Name = "Nihat";
            Thread ip3 = new Thread (new ThreadStart (Birartýr)); ip3.Name = "Yavaþ";
            ip1.Start(); ip2.Start(); ip3.Start();
        }
        static void ÝpMetodu() {for(int i = 0; i < 500; i++) {new SayaçlýSýnýf();}}
        static void Main() {
            Console.Write ("lock{} bloðu, Join() gibi sicim görevini (Monitor.Pulse yoksa) zamanpaylaþýmsýz bütünlükte tamamlar. Interlocked.Decrement/Increment/Add/Exchange/CompareExchange: birazalt/birartýr/ekle/deðiþtir/kýyasendeðiþtir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("3 sicimin herbiri zamanpaylaþýmlý 5'er kez koþacak:");
            KilitA kltA = new KilitA();
            kltA.SicimleriKoþtur();

            Thread.Sleep (1000); Console.WriteLine ("\nHerbiri lock'lu 4 sicimli toplama görevi:");
            int[] a = {1, 2, 3, 4, 5}; Sicimlerim scm = new Sicimlerim ("Sicim#1", a); scm.ip.Join();
            int[] b = {11, 12, 13, 14, 15, 16}; scm = new Sicimlerim ("Sicim#2", b); scm.ip.Join();
            int[] c = {110, 120, 130, 140}; scm = new Sicimlerim ("Sicim#3", c); scm.ip.Join();
            int[] d = {1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 16, 110, 120, 130, 140}; scm = new Sicimlerim ("Sicim#3", d); scm.ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nHerbiri kilitli artan [1881-->1938] sayaç yazan 57 sicim:");
            KilitliSayaç ks = new KilitliSayaç();
            Thread[] yýllar = new Thread [58];
            int i;
            for(i=0;i<=57;i++) {yýllar [i] = new Thread (new ThreadStart (ks.Say)); yýllar [i].Start();}

            Thread.Sleep (1000); Console.WriteLine ("\n\n10 karma sicim, herbiri lock'lu 12 rasgele [1881,1938] yýl yazýyor:");
            Yazýcý yaz = new Yazýcý();
            Thread[] ipler = new Thread [10];
            for(i=0;i<10;i++) {
                ipler [i] = new Thread (new ThreadStart (yaz.YýllarýYaz));
                ipler [i].Name = "Ýþçi#" + i;
            }
            foreach (Thread ip in ipler) ip.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n3 ayrý sicimin ayný sayacý 1-->13 ardýþýk artýrmasý:");
            kltA.koþuSayý=0; kltA.SicimleriKoþtur2();

            Thread.Sleep (1000); Console.WriteLine ("\nJoin'li 2 sicimin 'ref Interlock'la ayný sayacý artýrýp azaltmasý:");
            ArtýranSicim artýrScm = new ArtýranSicim ("ArtýranSicim"); artýrScm.sicim.Join(); //Anlýk Join olmazsa sonsuz (artýr/azalt) sayaça takýlýyor
            AzaltanSicim azaltScm = new AzaltanSicim ("AzaltanSicim"); azaltScm.sicim.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n3*500=1500 sicimli tiplemenin kurulmasý ve yýkýlmasý:");
            Thread ip1 = new Thread (new ThreadStart (ÝpMetodu));
            Thread ip2 = new Thread (new ThreadStart (ÝpMetodu));
            Thread ip3 = new Thread (new ThreadStart (ÝpMetodu));
            ip1.Start(); ip1.Join();
            ip2.Start(); ip2.Join();
            ip3.Start(); ip3.Join();
            Console.WriteLine ("ref'siz sayaç: " + SayaçlýSýnýf.GüvensizSayaç);
            Console.WriteLine ("Interlock ref'li sayaç: " + SayaçlýSýnýf.GüvenliSayaç);
            GC.Collect();
            GC.WaitForPendingFinalizers(); //Tüm yýkýcý çöpler (3 * 500 = 1500) bellekten temizlenir
            Console.WriteLine ("GC.Collect'le gerisayýmlý sýfýrlanan ref'siz sayaç: " + SayaçlýSýnýf.GüvensizSayaç);
            Console.WriteLine ("GC.Collect'le gerisayýmlý sýfýrlanan ref'li sayaç: " + SayaçlýSýnýf.GüvenliSayaç);

            Thread.Sleep (1000); Console.WriteLine ("\nInterlocked.Decrement/Increment/Add/Exchange/CompareExchange sonuçlarý:");
            int intA = 1881;
            int intB = 1938;
            Console.WriteLine ("intA'nýn ilk deðeri = {0}", intA);
            Console.WriteLine ("intB'nin ilk deðeri = {0}", intB);
            Interlocked.Decrement (ref intA);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Decrement(ref) sonrasý intA = {0}", intA);
            Interlocked.Increment (ref intB);
            Console.WriteLine ("Interlocked.Increment(ref) sonrasý intB = {0}", intB);
            Interlocked.Add (ref intA, intB);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Add(ref intA, intB) sonrasý intA = {0}", intA); //intA+=intB
            Console.WriteLine("Interlocked.Add(ref intA, intB) sonrasý intB = {0}", intB); //Deðiþmez
            Interlocked.Exchange (ref intB, intA);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.Exchange(ref intB, intA) sonrasý intA = {0}", intA); //Deðiþmez
            Console.WriteLine ("Interlocked.Exchange(ref intB, intA) sonrasý intB = {0}", intB); //intB=intA
            Interlocked.CompareExchange (ref intA, 1923, intB);
            //Console.WriteLine (Environment.NewLine);
            Console.WriteLine ("Interlocked.CompareExchange(ref intA, 1923, intB) sonrasý intA = {0}", intA);
            Console.WriteLine ("Interlocked.CompareExchange(ref intA, 1923, intB) sonrasý intB = {0}", intB);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}