// j2sc#2001a.cs: Sicimlerin parametre-siz/li ba�lat�lmas�, uyuma, i�lemler ve sonlanma �rne�i.

using System;
using System.Threading; //Thread i�in
using System.Diagnostics; //Process ve ProcessThreadCollection i�in
namespace �okluG�rev {
    class SicimA {
        public int saya�;
        string ipAd�;
        public SicimA (string ad) {saya� = 0; ipAd� = ad;} //Kurucu
        public void ko�tur() {
            Console.WriteLine (ipAd� + " ba�l�yor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki saya� no: {1}", ipAd�, saya�);
                saya�++;
            }while (saya� < 10);
            Console.WriteLine (ipAd� + " sonlan�yor.");
        }
    }
    class SicimB { //Her tipleme sayac� s�f�rlayarak yeni bir sicim yarat�r ve ba�lat�r
        int saya�;
        Thread ip;
        public SicimB (string ipAd�) {//Kurucu
           saya� = 0;
           ip = new Thread (this.ko�);
           ip.Name = ipAd�;
           ip.Start();
        }
        void ko�() {
            Console.WriteLine (ip.Name + " ba�l�yor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki saya� no: {1}", ip.Name, saya�);
                saya�++;
            }while (saya� < 10); 
            Console.WriteLine (ip.Name + " sonlan�yor.");
        }
    }
    class SicimC {
        int saya�;
        public Thread ip;
        public SicimC (string ad, int no) {//Kurucu
            saya� = no;
            ip = new Thread (new ParameterizedThreadStart (this.ko�));
            ip.Name = ad;
            ip.Start (no);
        }
        void ko� (object no) {
            Console.WriteLine (ip.Name + " saya�: " + no + " ile ba�l�yor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki saya� no: {1}", ip.Name, saya�);
                saya�++;
            }while (saya� < (int)no);
            Console.WriteLine (ip.Name + " sonlan�yor.");  
        }
    }
    class �kiIntAlan {
        public int a, b;
        public �kiIntAlan (int n1, int n2) {a = n1; b = n2;}
    }
    class Toplam {
        int a, b, tpl;
        public int Tpl {get {return tpl;}}
        public Toplam (int n1, int n2) {//Kurucu
            Console.WriteLine ("==>[Toplam.Toplam] tiplemesi {0} ve {1} kurucu parametreleriyle yap�ld�", n1, n2);
            a = n1; b = n2;
        }
        public void Topla() {Thread.Sleep (1000); tpl = a + b;}
    }
    class SicimlerS {
        private static void SicimlenenMetot (object ns) {Console.WriteLine ("Sicim parametresi: {0}", ns);}
        private static void SicimlenenMetot2() {Console.WriteLine ("Parametresiz SicimlenenMetot2 �a�r�ld�...");}
        public static void Y�llar() {Console.Write ("Y�llar: "); for(int i=1881;i<=1938;i++) Console.Write (i + " "); Console.WriteLine();}
        public static void �kiIntAlan�Topla (object veri) {
            if (veri is �kiIntAlan) {
                Console.WriteLine ("�kiIntAlan�Topla()'daki akt�el sicimin no'su: {0}", Thread.CurrentThread.GetHashCode());
                �kiIntAlan snf = (�kiIntAlan)veri;
                Console.WriteLine ("{0} + {1} = {2}", snf.a, snf.b, snf.a + snf.b);
            }
        }
        public const int TekrarSay�s� = 200;
        public static void Noktala() {for (int j = 0; j < TekrarSay�s�; j++) Console.Write ('.');}
        static void Main() {
            Console.Write ("Sicimin yarat�lmas�: 'Thread ip = new Thread(metot)', 'Thread ip = new Thread(new ThreadStart(metot))', 'Thread ip = new Thread(new ParameterizedThreadStart(metot))' ve ba�lat�lmas� 'ip.Start()'la yap�l�r. Asenkron zaman payla��ml� sicimlerin i�lemleri birbiriyle kar��acakt�r, dikkatli izlenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Metota ba�lanan sicimin nesnel parametresi:");
            Thread ip = new Thread (SicimlenenMetot); ip.Start ("SicimlenenMetot'un nesnel parametresi"); //ip.Join();
            ip = new Thread (SicimlenenMetot); ip.Start ("M.Nihat Yava�");
            ip = new Thread (SicimlenenMetot); ip.Start (20240822);
            ip = new Thread (SicimlenenMetot); ip.Start (20240822.2021);
            ip = new Thread (SicimlenenMetot); ip.Start (true);
            ip = new Thread (SicimlenenMetot); ip.Start (long.MaxValue);

            Console.WriteLine ("\nParametresiz metota ba�lanan sicimin ba�lat�lmas�:");
            ip = new Thread (SicimlenenMetot2); ip.Start(); //ip.Join();
            ip = new Thread (SicimlenenMetot2); ip.Start();

            Console.WriteLine ("\nParametresiz metota ba�lanan sicimin Y�llar'� ba�latmas�:");
            ip = new Thread (new ThreadStart (Y�llar));
            ip.Start();

            Console.WriteLine ("\nSicimA.ko�tur() saya�'l� metota ba�lanan sicimin ba�� ve sonu:");
            Console.WriteLine ("Esas ip ba�lad�...");
            SicimA snfA = new SicimA ("1.�p");
            ip = new Thread (snfA.ko�tur); // ip = new Thread (new ThreadStart (snfA.ko�tur));
            ip.Start();
            do {Console.Write ("*"); Thread.Sleep (100);} while (snfA.saya� != 10);
            Console.WriteLine ("Esas ip sonland�.");

            Console.WriteLine ("\n3 ayr� sicim ve saya�lar�n�n ba�� ve sonu:");
            Console.WriteLine ("Esas sicim ba�lad�...");
            SicimB snfB = new SicimB ("1.Sicim"); //Her tipleme yeni bir sicim daha yarat�r
            snfB = new SicimB ("2.Sicim");
            snfB = new SicimB ("3.Sicim");
            Thread.Sleep (2000);
            Console.WriteLine ("Esas sicim sonland�.");

            Console.WriteLine ("\nHerbirinin saya� ba�lang�c� farkl� olan 3'l� g�rev:");
            Console.WriteLine ("Esas g�rev ba�lad�...");
            SicimC snfC1 = new SicimC ("1.G�rev", 5);
            SicimC snfC2 = new SicimC ("2.G�rev", 3);
            SicimC snfC3 = new SicimC ("3.G�rev", 4);
            do {Thread.Sleep (100);} while (snfC1.ip.IsAlive | snfC2.ip.IsAlive | snfC3.ip.IsAlive);
            Console.WriteLine ("Esas g�rev sonland�.");

            Console.WriteLine ("\nDelegeyle 10 sicim-i�g�renli dizi yaratma ve ba�latma:");
            int ipSaya�=10, i;
            Thread[] ipler = new Thread [ipSaya�];
            for(i=0;i<ipSaya�;i++) {int j=i; ipler [i] = new Thread (delegate() {Console.WriteLine ("{0}.��g�ren", j);});}
            Array.ForEach (ipler, delegate (Thread scm) {scm.Start();});

            Console.WriteLine ("\n2 intAlan'daki geli�ig�zel say�lar� toplayan sicim:");
            Console.WriteLine ("Main()'deki akt�el sicimin no'su: {0}", Thread.CurrentThread.GetHashCode());
            var r=new Random(); int ts1, ts2;
            ts1=r.Next(1881,1939); ts2=r.Next(1881,1939);
            �kiIntAlan snf2a = new �kiIntAlan (ts1, ts2);
            ip = new Thread (�kiIntAlan�Topla);
            ip.Start (snf2a);

            Console.WriteLine ("\nToplam s�n�f�n rasgele 'int a,b' alanlar�n� toplayan sicim:");
            Toplam tplSnf;
            for(i=0;i<5;i++) {
                ts1=r.Next(1957,2025); ts2=r.Next(1957,2025);
                tplSnf = new Toplam (ts1, ts2);
                ip = new Thread (new ThreadStart (tplSnf.Topla)); ip.Start();
                for (int j = 0; j < 10; j++) {Thread.Sleep (200); Console.Write (".");}
                //ip.Join();
                Console.WriteLine ("[Main()] Toplam: {0}", tplSnf.Tpl);
            }

            Thread.Sleep (2000); Console.WriteLine ("\nAkt�el sicime dair detaylar:");
            ip = Thread.CurrentThread;
            ip.Name = "�lkSicim";
            Console.WriteLine ("Ak�el UygSaha ad�: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine ("Akt�el i�erik no: {0}", Thread.CurrentContext.ContextID);
            Console.WriteLine ("�p ad�: {0}", ip.Name);
            Console.WriteLine ("Sicim ba�lat�ld� m�?: {0}", ip.IsAlive);
            Console.WriteLine ("�ncelik seviyesi: {0}", ip.Priority);
            Console.WriteLine ("Sicimin durumu: {0}", ip.ThreadState);

            Thread.Sleep (2000); Console.WriteLine ("\nSicimle alma��k noktalar ve �izgiler s�rala:");
            ThreadStart ipiBa�lat = new ThreadStart (Noktala);
            ip = new Thread (ipiBa�lat); ip.Start();
            for (i = 0; i < TekrarSay�s�; i++) Console.Write ('-');
            //ip.Join();

            Thread.Sleep (2000); Console.WriteLine ("\n3004 s�re� no'lu sicimler koleksiyonu detaylar�:");
            Process s�re� = null;
            //for(i=3000;i<100000;i++) {//0: Idle, 4:System, 256:smss, 352-420:csrss, 408:wininit
                try {s�re� = Process.GetProcessById (3004);
                }catch {Console.Write ("?");}
                //if(s�re� != null) break;
            //}
            Console.WriteLine ("[{0}: {1}] s�re�i taraf�ndan kullan�lan sicimlerin listesi", s�re�.ProcessName, 3004);
            ProcessThreadCollection s�re�Sicimleri = s�re�.Threads;
            foreach (ProcessThread pt in s�re�Sicimleri) {
                string bilgi = string.Format ("-> Sicim No: {0}\tBa�lama zaman�: {1}\t�nceli�i: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine (bilgi);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}