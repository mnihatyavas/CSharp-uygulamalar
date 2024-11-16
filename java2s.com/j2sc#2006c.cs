// j2sc#2006c.cs: Ýkili almaþýk süreçler ve YerelVeriDepoYuvasý örneði.

using System;
using System.Threading;
using System.Collections.Generic; //Queue için
namespace ÝpTipleri {
    public class SýnýfA {
        private static LocalDataStoreSlot yuva = null;
        static SýnýfA() {yuva = Thread.AllocateDataSlot();}
        public SýnýfA() {Console.WriteLine ("SýnýfA yaratýlýyor..." );} //Kurucu
        public static SýnýfA SicimVeriAlKoySýnýfý {
            get {Object nesne = Thread.GetData (yuva);
                if (nesne == null) {nesne = new SýnýfA(); Thread.SetData (yuva, nesne);}
                return (SýnýfA)nesne;
            }
        }
    }
    class AlmaþýkÝp {
        private int[] ürünler = new int [100];
        private int ürünEndeksi = 0;
        private AutoResetEvent yeniÜrünOlayý = new AutoResetEvent (false);
        protected void Üretici() {
            while (this.ürünEndeksi < 20) {
                lock (this) {
                    ürünler [ürünEndeksi] = 1;
                    Console.WriteLine ("Sicim#{0} ile üretilen toplam aygýt: {1}", Thread.CurrentThread.ManagedThreadId, ++ürünEndeksi);
                    yeniÜrünOlayý.Set();
                }
                Thread.Sleep ((new Random()).Next(5) * 10);
            }
        }
        protected void Tüketici() {
            while (this.ürünEndeksi > 0) {
                //yeniÜrünOlayý.WaitOne();
                int ürünEndeksi2 = 0;
                ürünEndeksi2 = --this.ürünEndeksi;
                Console.WriteLine( "\tSicim#{0} ile tüketilen {1}.nci aygýt", Thread.CurrentThread.ManagedThreadId, ++ürünEndeksi2);
                ürünler[ürünEndeksi2--] = 0;
            }
        }
        public void Koþ() {
            Thread üret = new Thread (new ThreadStart (Üretici));
            üret.Start(); Thread.Sleep (1000);
            Thread tüket = new Thread (Tüketici);
            tüket.Start(); tüket.Join();
        }
        private static Queue<string> paylaþýlanKuyruk = new Queue<string>(); //Kuyruða (Queue) ÝLK giren (Enqueue) ÝLK çýkar (Dequeue)
        private static void Ýmalatçý() {
            for (int i = 0; i < 20; i++) {
                string birim = "Mamül#" + (i+1);
                lock (paylaþýlanKuyruk) {
                    paylaþýlanKuyruk.Enqueue (birim);
                    Monitor.Pulse (paylaþýlanKuyruk);
                }
                Console.WriteLine ("Üretilen birim: {0}", birim);
            }
        }
        private static void Müþteri() {
            for (int i = 0; i < 20; i++) {
            string birim = null;
                lock (paylaþýlanKuyruk) {
                    if (paylaþýlanKuyruk.Count == 0) Monitor.Wait (paylaþýlanKuyruk);
                    birim = paylaþýlanKuyruk.Dequeue();
                }
                Console.WriteLine ("\tTüketilen birim: {0}", birim);
            }
        }
        public static bool yemekçubuðu1MevcutMu = true;
        public static bool yemekçubuðu2MevcutMu = true;
        public static void YemekçubuklarýnýAl() {
            while (!yemekçubuðu1MevcutMu) {//Uygulanmaz
                Console.WriteLine ("Ýlk yemekçubuðunun hazýr olmasý bekleniyor...");
                Thread.Sleep (10000);
            }
            Console.WriteLine ("Ýlk yemekçubuðu alýndý."); yemekçubuðu1MevcutMu = false;
            while (!yemekçubuðu2MevcutMu) {//Uygulanmaz
                Console.WriteLine ("Ýkinci yemekçubuðunun hazýr olmasý bekleniyor...");
                Thread.Sleep (10000);
            }
            Console.WriteLine ("Ýkinci yemekçubuðu alýndý."); yemekçubuðu2MevcutMu = false;
            Console.WriteLine ("Müþteri yemeðini bitirdi ve yemekçubuklarýný býrakýyor...");
            yemekçubuðu1MevcutMu = true; yemekçubuðu2MevcutMu = true;
        }
        static int yuvaEndeksi;
        private static void SicimFonk() {
            Console.WriteLine ("\tSicim#{0} baþlýyor...", Thread.CurrentThread.GetHashCode());
            Console.WriteLine ("Bu sicimin yuva deðeri: \"{0} no'lu {1}\"", ++yuvaEndeksi, SýnýfA.SicimVeriAlKoySýnýfý);
            Console.WriteLine ("Sicim#{0} sonlanýyor.", Thread.CurrentThread.GetHashCode());
        }
        [ThreadStatic]
        private static string SicimStatikVeri = "BOÞ";
        public static void YuvlarýBilgilendir() {
            Thread.SetData (Thread.GetNamedDataSlot ("SicimNo"), Thread.CurrentThread.ManagedThreadId);
            Thread.SetData (Thread.GetNamedDataSlot ("SicimAdý"), Thread.CurrentThread.Name);
            Console.WriteLine ("Sicim adý ve no'su = ({0}, {1})", Thread.GetData (Thread.GetNamedDataSlot ("SicimAdý")), Thread.GetData (Thread.GetNamedDataSlot ("SicimNo")));
        }
        static void Main() {
            Console.Write ("Ürünler raf dizisine SGÝÇ son giren ilk çýkarken, Queque imalat kuyruðuna ÝGÝÇ ilk giren ilk çýkar. Thread.SetData(yuva, bilgi) veya Thread.SetData(Thread.AllocateNamedDataSlot('Ad'), bilgi) ile yuvaya bilgi konulur ve Thread.GetData(yuva) veya Thread.GetData(Thread.GetNamedDataSlot('Ad'))'la alýnýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ardýþýk üretilen 20 aygýt gerisin-geriye tüketilmektedir:");
            AlmaþýkÝp ak = new AlmaþýkÝp();
            ak.Koþ();

            Thread.Sleep (2000); Console.WriteLine ("\nÝmalat kuyruðundaki 20 mamul ÝGÝÇ yöntemiyle tüketilmekte:");
            Thread ip = new Thread (Ýmalatçý); ip.Start(); ip.Join();
            ip = new Thread (Müþteri); ip.Start(); ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n:");
            int i;
            for(i=0;i<5;i++) {
                Console.WriteLine ("\t{0}.nci müþteri yemeðe hazýrlanýyor...", i+1);
                ip = new Thread (new ThreadStart (YemekçubuklarýnýAl));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nYerelVeriDepoYuvasý'na sicimle konulan ve alýnan deðerler:");
            LocalDataStoreSlot yuva = Thread.AllocateDataSlot();
            int yuvadakiDeðer;
            Console.Write ("Atatürk'lü yýllar: ");
            for(i=0;i<=57;i++) {
                Thread.SetData (yuva, i+1881);
                yuvadakiDeðer = (int)Thread.GetData (yuva);
                Console.Write (yuvadakiDeðer+" ");
            }Console.WriteLine();

            Thread.Sleep (1000); Console.WriteLine ("\nAdlýVeriYuvasý'na sicimle konulan ve alýnan deðerler:");
            Console.Write ("Atatürk'lü yýllar: ");
            for(i=0;i<=57;i++) {
                Thread.SetData (Thread.AllocateNamedDataSlot ("Yýllar"+i), 1938-i); //Sabit yuva adý her veride deðiþmeli
                yuvadakiDeðer = (int)Thread.GetData (Thread.GetNamedDataSlot ("Yýllar"+i));
                Console.Write (yuvadakiDeðer+" ");
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 ayrý sicimli yuvaya, yaratýlan SýnýfA tipi koy/al:");
            yuvaEndeksi = 0;
            for(i=0;i<5;i++) {
                ip = new Thread (new ThreadStart (SicimFonk));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nSicimsiz ve 10 ayrý siclmli [SicimStatikVeri]:");
            Console.WriteLine ("Döngü öncesi [SicimStatikVeri] = {0}", SicimStatikVeri);
            Thread[] ipler = new Thread [10];
            for(i=0;i<10;i++) {
                ipler [i] = new Thread (delegate (object j) {
                    SicimStatikVeri = "[SicimStatikVeri]: " + j;
                    Console.WriteLine ("Sicim[{0}]/{1} = {2}/{3}", j, Thread.CurrentThread.GetHashCode(), SicimStatikVeri, i);
                });
                ipler [i].Start (i);
            }
            //foreach (Thread ip in ipler) ip.Join();
            Thread.Sleep (500);
            Console.WriteLine ("Döngü sonrasý [SicimStatikVeri] = {0}", SicimStatikVeri);

            Thread.Sleep (1000); Console.WriteLine ("\n10'ar adet adlý sicim yuvalarýna sicim-adý/no'su koyma ve alma:");
            Thread.AllocateNamedDataSlot ("SicimNo"); //Adlý yuvaya tahsis et
            Thread.AllocateNamedDataSlot ("SicimAdý");
            for(i=0;i<10;i++) {
                ip = new Thread (new ThreadStart (YuvlarýBilgilendir));
                ip.Name = (i+1)+".nci_Sicim";
                ip.Start();
            }
            Thread.FreeNamedDataSlot ("SicimNo"); //Adlý yuvayý serbest býrak
            Thread.FreeNamedDataSlot ("SicimAdý");
            Thread.Sleep (500);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}