// j2sc#2006c.cs: �kili alma��k s�re�ler ve YerelVeriDepoYuvas� �rne�i.

using System;
using System.Threading;
using System.Collections.Generic; //Queue i�in
namespace �pTipleri {
    public class S�n�fA {
        private static LocalDataStoreSlot yuva = null;
        static S�n�fA() {yuva = Thread.AllocateDataSlot();}
        public S�n�fA() {Console.WriteLine ("S�n�fA yarat�l�yor..." );} //Kurucu
        public static S�n�fA SicimVeriAlKoyS�n�f� {
            get {Object nesne = Thread.GetData (yuva);
                if (nesne == null) {nesne = new S�n�fA(); Thread.SetData (yuva, nesne);}
                return (S�n�fA)nesne;
            }
        }
    }
    class Alma��k�p {
        private int[] �r�nler = new int [100];
        private int �r�nEndeksi = 0;
        private AutoResetEvent yeni�r�nOlay� = new AutoResetEvent (false);
        protected void �retici() {
            while (this.�r�nEndeksi < 20) {
                lock (this) {
                    �r�nler [�r�nEndeksi] = 1;
                    Console.WriteLine ("Sicim#{0} ile �retilen toplam ayg�t: {1}", Thread.CurrentThread.ManagedThreadId, ++�r�nEndeksi);
                    yeni�r�nOlay�.Set();
                }
                Thread.Sleep ((new Random()).Next(5) * 10);
            }
        }
        protected void T�ketici() {
            while (this.�r�nEndeksi > 0) {
                //yeni�r�nOlay�.WaitOne();
                int �r�nEndeksi2 = 0;
                �r�nEndeksi2 = --this.�r�nEndeksi;
                Console.WriteLine( "\tSicim#{0} ile t�ketilen {1}.nci ayg�t", Thread.CurrentThread.ManagedThreadId, ++�r�nEndeksi2);
                �r�nler[�r�nEndeksi2--] = 0;
            }
        }
        public void Ko�() {
            Thread �ret = new Thread (new ThreadStart (�retici));
            �ret.Start(); Thread.Sleep (1000);
            Thread t�ket = new Thread (T�ketici);
            t�ket.Start(); t�ket.Join();
        }
        private static Queue<string> payla��lanKuyruk = new Queue<string>(); //Kuyru�a (Queue) �LK giren (Enqueue) �LK ��kar (Dequeue)
        private static void �malat��() {
            for (int i = 0; i < 20; i++) {
                string birim = "Mam�l#" + (i+1);
                lock (payla��lanKuyruk) {
                    payla��lanKuyruk.Enqueue (birim);
                    Monitor.Pulse (payla��lanKuyruk);
                }
                Console.WriteLine ("�retilen birim: {0}", birim);
            }
        }
        private static void M��teri() {
            for (int i = 0; i < 20; i++) {
            string birim = null;
                lock (payla��lanKuyruk) {
                    if (payla��lanKuyruk.Count == 0) Monitor.Wait (payla��lanKuyruk);
                    birim = payla��lanKuyruk.Dequeue();
                }
                Console.WriteLine ("\tT�ketilen birim: {0}", birim);
            }
        }
        public static bool yemek�ubu�u1MevcutMu = true;
        public static bool yemek�ubu�u2MevcutMu = true;
        public static void Yemek�ubuklar�n�Al() {
            while (!yemek�ubu�u1MevcutMu) {//Uygulanmaz
                Console.WriteLine ("�lk yemek�ubu�unun haz�r olmas� bekleniyor...");
                Thread.Sleep (10000);
            }
            Console.WriteLine ("�lk yemek�ubu�u al�nd�."); yemek�ubu�u1MevcutMu = false;
            while (!yemek�ubu�u2MevcutMu) {//Uygulanmaz
                Console.WriteLine ("�kinci yemek�ubu�unun haz�r olmas� bekleniyor...");
                Thread.Sleep (10000);
            }
            Console.WriteLine ("�kinci yemek�ubu�u al�nd�."); yemek�ubu�u2MevcutMu = false;
            Console.WriteLine ("M��teri yeme�ini bitirdi ve yemek�ubuklar�n� b�rak�yor...");
            yemek�ubu�u1MevcutMu = true; yemek�ubu�u2MevcutMu = true;
        }
        static int yuvaEndeksi;
        private static void SicimFonk() {
            Console.WriteLine ("\tSicim#{0} ba�l�yor...", Thread.CurrentThread.GetHashCode());
            Console.WriteLine ("Bu sicimin yuva de�eri: \"{0} no'lu {1}\"", ++yuvaEndeksi, S�n�fA.SicimVeriAlKoyS�n�f�);
            Console.WriteLine ("Sicim#{0} sonlan�yor.", Thread.CurrentThread.GetHashCode());
        }
        [ThreadStatic]
        private static string SicimStatikVeri = "BO�";
        public static void Yuvlar�Bilgilendir() {
            Thread.SetData (Thread.GetNamedDataSlot ("SicimNo"), Thread.CurrentThread.ManagedThreadId);
            Thread.SetData (Thread.GetNamedDataSlot ("SicimAd�"), Thread.CurrentThread.Name);
            Console.WriteLine ("Sicim ad� ve no'su = ({0}, {1})", Thread.GetData (Thread.GetNamedDataSlot ("SicimAd�")), Thread.GetData (Thread.GetNamedDataSlot ("SicimNo")));
        }
        static void Main() {
            Console.Write ("�r�nler raf dizisine SG�� son giren ilk ��karken, Queque imalat kuyru�una �G�� ilk giren ilk ��kar. Thread.SetData(yuva, bilgi) veya Thread.SetData(Thread.AllocateNamedDataSlot('Ad'), bilgi) ile yuvaya bilgi konulur ve Thread.GetData(yuva) veya Thread.GetData(Thread.GetNamedDataSlot('Ad'))'la al�n�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ard���k �retilen 20 ayg�t gerisin-geriye t�ketilmektedir:");
            Alma��k�p ak = new Alma��k�p();
            ak.Ko�();

            Thread.Sleep (2000); Console.WriteLine ("\n�malat kuyru�undaki 20 mamul �G�� y�ntemiyle t�ketilmekte:");
            Thread ip = new Thread (�malat��); ip.Start(); ip.Join();
            ip = new Thread (M��teri); ip.Start(); ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\n:");
            int i;
            for(i=0;i<5;i++) {
                Console.WriteLine ("\t{0}.nci m��teri yeme�e haz�rlan�yor...", i+1);
                ip = new Thread (new ThreadStart (Yemek�ubuklar�n�Al));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nYerelVeriDepoYuvas�'na sicimle konulan ve al�nan de�erler:");
            LocalDataStoreSlot yuva = Thread.AllocateDataSlot();
            int yuvadakiDe�er;
            Console.Write ("Atat�rk'l� y�llar: ");
            for(i=0;i<=57;i++) {
                Thread.SetData (yuva, i+1881);
                yuvadakiDe�er = (int)Thread.GetData (yuva);
                Console.Write (yuvadakiDe�er+" ");
            }Console.WriteLine();

            Thread.Sleep (1000); Console.WriteLine ("\nAdl�VeriYuvas�'na sicimle konulan ve al�nan de�erler:");
            Console.Write ("Atat�rk'l� y�llar: ");
            for(i=0;i<=57;i++) {
                Thread.SetData (Thread.AllocateNamedDataSlot ("Y�llar"+i), 1938-i); //Sabit yuva ad� her veride de�i�meli
                yuvadakiDe�er = (int)Thread.GetData (Thread.GetNamedDataSlot ("Y�llar"+i));
                Console.Write (yuvadakiDe�er+" ");
            }

            Thread.Sleep (1000); Console.WriteLine ("\n5 ayr� sicimli yuvaya, yarat�lan S�n�fA tipi koy/al:");
            yuvaEndeksi = 0;
            for(i=0;i<5;i++) {
                ip = new Thread (new ThreadStart (SicimFonk));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nSicimsiz ve 10 ayr� siclmli [SicimStatikVeri]:");
            Console.WriteLine ("D�ng� �ncesi [SicimStatikVeri] = {0}", SicimStatikVeri);
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
            Console.WriteLine ("D�ng� sonras� [SicimStatikVeri] = {0}", SicimStatikVeri);

            Thread.Sleep (1000); Console.WriteLine ("\n10'ar adet adl� sicim yuvalar�na sicim-ad�/no'su koyma ve alma:");
            Thread.AllocateNamedDataSlot ("SicimNo"); //Adl� yuvaya tahsis et
            Thread.AllocateNamedDataSlot ("SicimAd�");
            for(i=0;i<10;i++) {
                ip = new Thread (new ThreadStart (Yuvlar�Bilgilendir));
                ip.Name = (i+1)+".nci_Sicim";
                ip.Start();
            }
            Thread.FreeNamedDataSlot ("SicimNo"); //Adl� yuvay� serbest b�rak
            Thread.FreeNamedDataSlot ("SicimAd�");
            Thread.Sleep (500);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}