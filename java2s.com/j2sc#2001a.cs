// j2sc#2001a.cs: Sicimlerin parametre-siz/li baþlatýlmasý, uyuma, iþlemler ve sonlanma örneði.

using System;
using System.Threading; //Thread için
using System.Diagnostics; //Process ve ProcessThreadCollection için
namespace ÇokluGörev {
    class SicimA {
        public int sayaç;
        string ipAdý;
        public SicimA (string ad) {sayaç = 0; ipAdý = ad;} //Kurucu
        public void koþtur() {
            Console.WriteLine (ipAdý + " baþlýyor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki sayaç no: {1}", ipAdý, sayaç);
                sayaç++;
            }while (sayaç < 10);
            Console.WriteLine (ipAdý + " sonlanýyor.");
        }
    }
    class SicimB { //Her tipleme sayacý sýfýrlayarak yeni bir sicim yaratýr ve baþlatýr
        int sayaç;
        Thread ip;
        public SicimB (string ipAdý) {//Kurucu
           sayaç = 0;
           ip = new Thread (this.koþ);
           ip.Name = ipAdý;
           ip.Start();
        }
        void koþ() {
            Console.WriteLine (ip.Name + " baþlýyor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki sayaç no: {1}", ip.Name, sayaç);
                sayaç++;
            }while (sayaç < 10); 
            Console.WriteLine (ip.Name + " sonlanýyor.");
        }
    }
    class SicimC {
        int sayaç;
        public Thread ip;
        public SicimC (string ad, int no) {//Kurucu
            sayaç = no;
            ip = new Thread (new ParameterizedThreadStart (this.koþ));
            ip.Name = ad;
            ip.Start (no);
        }
        void koþ (object no) {
            Console.WriteLine (ip.Name + " sayaç: " + no + " ile baþlýyor.");
            do {Thread.Sleep (500);
                Console.WriteLine ("{0}'deki sayaç no: {1}", ip.Name, sayaç);
                sayaç++;
            }while (sayaç < (int)no);
            Console.WriteLine (ip.Name + " sonlanýyor.");  
        }
    }
    class ÝkiIntAlan {
        public int a, b;
        public ÝkiIntAlan (int n1, int n2) {a = n1; b = n2;}
    }
    class Toplam {
        int a, b, tpl;
        public int Tpl {get {return tpl;}}
        public Toplam (int n1, int n2) {//Kurucu
            Console.WriteLine ("==>[Toplam.Toplam] tiplemesi {0} ve {1} kurucu parametreleriyle yapýldý", n1, n2);
            a = n1; b = n2;
        }
        public void Topla() {Thread.Sleep (1000); tpl = a + b;}
    }
    class SicimlerS {
        private static void SicimlenenMetot (object ns) {Console.WriteLine ("Sicim parametresi: {0}", ns);}
        private static void SicimlenenMetot2() {Console.WriteLine ("Parametresiz SicimlenenMetot2 çaðrýldý...");}
        public static void Yýllar() {Console.Write ("Yýllar: "); for(int i=1881;i<=1938;i++) Console.Write (i + " "); Console.WriteLine();}
        public static void ÝkiIntAlanýTopla (object veri) {
            if (veri is ÝkiIntAlan) {
                Console.WriteLine ("ÝkiIntAlanýTopla()'daki aktüel sicimin no'su: {0}", Thread.CurrentThread.GetHashCode());
                ÝkiIntAlan snf = (ÝkiIntAlan)veri;
                Console.WriteLine ("{0} + {1} = {2}", snf.a, snf.b, snf.a + snf.b);
            }
        }
        public const int TekrarSayýsý = 200;
        public static void Noktala() {for (int j = 0; j < TekrarSayýsý; j++) Console.Write ('.');}
        static void Main() {
            Console.Write ("Sicimin yaratýlmasý: 'Thread ip = new Thread(metot)', 'Thread ip = new Thread(new ThreadStart(metot))', 'Thread ip = new Thread(new ParameterizedThreadStart(metot))' ve baþlatýlmasý 'ip.Start()'la yapýlýr. Asenkron zaman paylaþýmlý sicimlerin iþlemleri birbiriyle karýþacaktýr, dikkatli izlenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Metota baðlanan sicimin nesnel parametresi:");
            Thread ip = new Thread (SicimlenenMetot); ip.Start ("SicimlenenMetot'un nesnel parametresi"); //ip.Join();
            ip = new Thread (SicimlenenMetot); ip.Start ("M.Nihat Yavaþ");
            ip = new Thread (SicimlenenMetot); ip.Start (20240822);
            ip = new Thread (SicimlenenMetot); ip.Start (20240822.2021);
            ip = new Thread (SicimlenenMetot); ip.Start (true);
            ip = new Thread (SicimlenenMetot); ip.Start (long.MaxValue);

            Console.WriteLine ("\nParametresiz metota baðlanan sicimin baþlatýlmasý:");
            ip = new Thread (SicimlenenMetot2); ip.Start(); //ip.Join();
            ip = new Thread (SicimlenenMetot2); ip.Start();

            Console.WriteLine ("\nParametresiz metota baðlanan sicimin Yýllar'ý baþlatmasý:");
            ip = new Thread (new ThreadStart (Yýllar));
            ip.Start();

            Console.WriteLine ("\nSicimA.koþtur() sayaç'lý metota baðlanan sicimin baþý ve sonu:");
            Console.WriteLine ("Esas ip baþladý...");
            SicimA snfA = new SicimA ("1.Ýp");
            ip = new Thread (snfA.koþtur); // ip = new Thread (new ThreadStart (snfA.koþtur));
            ip.Start();
            do {Console.Write ("*"); Thread.Sleep (100);} while (snfA.sayaç != 10);
            Console.WriteLine ("Esas ip sonlandý.");

            Console.WriteLine ("\n3 ayrý sicim ve sayaçlarýnýn baþý ve sonu:");
            Console.WriteLine ("Esas sicim baþladý...");
            SicimB snfB = new SicimB ("1.Sicim"); //Her tipleme yeni bir sicim daha yaratýr
            snfB = new SicimB ("2.Sicim");
            snfB = new SicimB ("3.Sicim");
            Thread.Sleep (2000);
            Console.WriteLine ("Esas sicim sonlandý.");

            Console.WriteLine ("\nHerbirinin sayaç baþlangýcý farklý olan 3'lü görev:");
            Console.WriteLine ("Esas görev baþladý...");
            SicimC snfC1 = new SicimC ("1.Görev", 5);
            SicimC snfC2 = new SicimC ("2.Görev", 3);
            SicimC snfC3 = new SicimC ("3.Görev", 4);
            do {Thread.Sleep (100);} while (snfC1.ip.IsAlive | snfC2.ip.IsAlive | snfC3.ip.IsAlive);
            Console.WriteLine ("Esas görev sonlandý.");

            Console.WriteLine ("\nDelegeyle 10 sicim-iþgörenli dizi yaratma ve baþlatma:");
            int ipSayaç=10, i;
            Thread[] ipler = new Thread [ipSayaç];
            for(i=0;i<ipSayaç;i++) {int j=i; ipler [i] = new Thread (delegate() {Console.WriteLine ("{0}.Ýþgören", j);});}
            Array.ForEach (ipler, delegate (Thread scm) {scm.Start();});

            Console.WriteLine ("\n2 intAlan'daki geliþigüzel sayýlarý toplayan sicim:");
            Console.WriteLine ("Main()'deki aktüel sicimin no'su: {0}", Thread.CurrentThread.GetHashCode());
            var r=new Random(); int ts1, ts2;
            ts1=r.Next(1881,1939); ts2=r.Next(1881,1939);
            ÝkiIntAlan snf2a = new ÝkiIntAlan (ts1, ts2);
            ip = new Thread (ÝkiIntAlanýTopla);
            ip.Start (snf2a);

            Console.WriteLine ("\nToplam sýnýfýn rasgele 'int a,b' alanlarýný toplayan sicim:");
            Toplam tplSnf;
            for(i=0;i<5;i++) {
                ts1=r.Next(1957,2025); ts2=r.Next(1957,2025);
                tplSnf = new Toplam (ts1, ts2);
                ip = new Thread (new ThreadStart (tplSnf.Topla)); ip.Start();
                for (int j = 0; j < 10; j++) {Thread.Sleep (200); Console.Write (".");}
                //ip.Join();
                Console.WriteLine ("[Main()] Toplam: {0}", tplSnf.Tpl);
            }

            Thread.Sleep (2000); Console.WriteLine ("\nAktüel sicime dair detaylar:");
            ip = Thread.CurrentThread;
            ip.Name = "ÝlkSicim";
            Console.WriteLine ("Aküel UygSaha adý: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine ("Aktüel içerik no: {0}", Thread.CurrentContext.ContextID);
            Console.WriteLine ("Ýp adý: {0}", ip.Name);
            Console.WriteLine ("Sicim baþlatýldý mý?: {0}", ip.IsAlive);
            Console.WriteLine ("Öncelik seviyesi: {0}", ip.Priority);
            Console.WriteLine ("Sicimin durumu: {0}", ip.ThreadState);

            Thread.Sleep (2000); Console.WriteLine ("\nSicimle almaþýk noktalar ve çizgiler sýrala:");
            ThreadStart ipiBaþlat = new ThreadStart (Noktala);
            ip = new Thread (ipiBaþlat); ip.Start();
            for (i = 0; i < TekrarSayýsý; i++) Console.Write ('-');
            //ip.Join();

            Thread.Sleep (2000); Console.WriteLine ("\n3004 süreç no'lu sicimler koleksiyonu detaylarý:");
            Process süreç = null;
            //for(i=3000;i<100000;i++) {//0: Idle, 4:System, 256:smss, 352-420:csrss, 408:wininit
                try {süreç = Process.GetProcessById (3004);
                }catch {Console.Write ("?");}
                //if(süreç != null) break;
            //}
            Console.WriteLine ("[{0}: {1}] süreçi tarafýndan kullanýlan sicimlerin listesi", süreç.ProcessName, 3004);
            ProcessThreadCollection süreçSicimleri = süreç.Threads;
            foreach (ProcessThread pt in süreçSicimleri) {
                string bilgi = string.Format ("-> Sicim No: {0}\tBaþlama zamaný: {1}\tÖnceliði: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine (bilgi);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}