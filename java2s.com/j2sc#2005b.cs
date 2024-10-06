// j2sc#2005b.cs: �zelKilit, mutexSicim, �l�kilit, okuyazKilit �rne�i.

using System;
using System.Threading;
namespace Sicimler {
    class F�r�lKilit {
        private int durum;
        private EventWaitHandle olayBekleY�net = new AutoResetEvent (false);
        private static bool tek��levMi = (Environment.ProcessorCount == 1);
        private const int d��DeneSaya� = 5;
        private const int fazlaDeneSaya� = 100;
        public void Gir (out bool tekMi) {
            tekMi = false;
            while (!tekMi) {
                if (tek��levMi) {
                    Thread.BeginCriticalRegion();
                    tekMi = Interlocked.CompareExchange (ref durum, 1, 0) == 0;
                    if (!tekMi) Thread.EndCriticalRegion();
                }else {
                    for (int i = 0; !tekMi && i < d��DeneSaya�; i++) {
                        Thread.BeginCriticalRegion();
                        int deneme = 0;
                        while (!(tekMi = Interlocked.CompareExchange (ref durum, 1, 0) == 0) && deneme++ < fazlaDeneSaya�) {Thread.SpinWait (1);}
                        if (!tekMi) {
                            Thread.EndCriticalRegion();
                            Thread.Sleep (0);
                        }
                    }
                }
                if (!tekMi) olayBekleY�net.WaitOne();
            }
            return;
        }
        public void Gir() {bool b;  Gir (out b);}
        public void ��k() {
            if (Interlocked.CompareExchange (ref durum, 0, 1) == 1) { 
                olayBekleY�net.Set();
                Thread.EndCriticalRegion();
            }
        }
    }
    public abstract class ���iSicim {
        private object  sicimVeri;
        private Thread  sicim;
        public object SicimVeri {get {return sicimVeri;} set {sicimVeri = value;}} //�zellik
        public object IsAlive {get {return sicim == null? false : sicim.IsAlive;}}
        public ���iSicim (object veri) {sicimVeri = veri;} //Kurucu-1
        public ���iSicim() {sicimVeri = null;} //Kurucu-2
        public void Ba�lat() {
            sicim = new Thread (new ThreadStart (this.Ko�tur));
            sicim.Start();
        }
        public void Bitir() {
            sicim.Abort();
            while (sicim.IsAlive);
            sicim = null;
        }
        protected abstract void Ko�tur();
    }
    public struct A�M��teriVerileri {//Yap�
        public int M��teriNo;
        public Mutex Sa�Y�ubuk;
        public Mutex SolY�ubuk;
        public int YenenLokma;
        public int KalanLokma;
    }
    public class A�M��teri : ���iSicim {
        public A�M��teri (object veri) : base (veri){} //Kurucu
        protected override void Ko�tur() {
            A�M��teriVerileri amv = (A�M��teriVerileri)SicimVeri;
            Random r = new Random (amv.M��teriNo);
            Console.WriteLine ("A�M��teri#{0} yemeye haz�r", amv.M��teriNo);
            WaitHandle[] yemek�ubuklar� =  new WaitHandle[] {amv.SolY�ubuk, amv.Sa�Y�ubuk};
            while (amv.KalanLokma > 0) {
                WaitHandle.WaitAll (yemek�ubuklar�); //Heriki �ubu�u al
                Console.WriteLine ("A�M��teri#{0} kalan {1} lokman�n {2}'n� a�z�na koyuyor", amv.M��teriNo, amv.KalanLokma, amv.YenenLokma);
                amv.KalanLokma -= amv.YenenLokma;
                Thread.Sleep (r.Next(10,100));
                Console.WriteLine ("A�M��teri#{0} lokmalar� �i�niyor", amv.M��teriNo);
                amv.Sa�Y�ubuk.ReleaseMutex(); //�i�neme s�resince �ubuklar� b�rak�yor
                amv.SolY�ubuk.ReleaseMutex();
                Thread.Sleep (r.Next(10,100));
            }
            Console.WriteLine ("A�M��teri#{0} yeme�ini bitirdi", amv.M��teriNo);
        }
    }
    class Hesap {
        string isim ="Y�cel K���kbay";
        decimal bakiye= 50000.0m;
        DateTime tarih = DateTime.Now;
        ReaderWriterLock oyKilit = new ReaderWriterLock();
        public decimal BakiyeG�ncelleme (decimal tutar) {
            oyKilit.AcquireWriterLock (-1); //kilitle
            Thread.Sleep (500);
            try {bakiye += tutar;
                tarih = DateTime.Now;
                return bakiye;
            }finally  {oyKilit.ReleaseWriterLock();} //Kilidi a�
        }
        public void HesapDurumu (out string isim, out decimal bakiye, out DateTime tarih) {
            oyKilit.AcquireReaderLock (-1); //kilitle
            Thread.Sleep (500);
            try {isim = this.isim;
                bakiye = this.bakiye;
                tarih = this.tarih;
            }finally {oyKilit.ReleaseReaderLock();} //Kilidi a�
        }
    }
    class KilitB {
        private static object �l�kilitA = new object();
        private static object �l�kilitB = new object();
        static void Main() {
            Console.Write ("lock{} blo�u yerine ayr� ifadeleli ReaderWriterLock.AcquireReaderLock()/ReleaseWriterLock() kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�m muhtemel �evre sicimlere �zel �l�kilit gir-��k kontrolu:");
            F�r�lKilit fk=null;; int i;
            for(i=0;i<5;i++) {
                try {fk = new F�r�lKilit();
                    fk.Gir();
                    Console.WriteLine ((i+1) + ".F�r�lKilit yakaland�");
                }finally {
                    fk.��k();
                    Console.WriteLine ("\t�l�Kilit'lenme olmadan {0}.F�r�lKilit serbest b�rak�ld�", (i+1));
                }
            }

            Thread.Sleep (1000); Console.WriteLine ("\n4 m��teri, 4 �ift �ubukla 3/9'er lokmalarla yemek yiyorlar:");
            Mutex[] yemek�ubuklar� = new Mutex [4];
            for(i = 0; i < 4; i++) yemek�ubuklar� [i] = new Mutex(false);
            for(i = 0; i < 4; i++) {//5 m��teri
                A�M��teriVerileri amv;
                amv.M��teriNo = i + 1;
                amv.Sa�Y�ubuk = yemek�ubuklar� [i - 1 >= 0 ? (i - 1) : 3];
                amv.SolY�ubuk = yemek�ubuklar� [i];
                amv.YenenLokma = 3;
                amv.KalanLokma = 9;
                A�M��teri am = new A�M��teri (amv);
                am.Ba�lat();
            }

            Thread.Sleep (2000); Console.WriteLine ("\n��i�e kilitli blok bazen sistemi dondurmaktad�r:");
            lock (�l�kilitA) {
                ThreadPool.QueueUserWorkItem (delegate {
                    lock (�l�kilitB) {
                        Console.WriteLine ("�l�kilitA-->�l�kilitB");
                        lock (�l�kilitA) {Console.WriteLine ("�l�kilitA-->�l�kilitB-->�l�kilitA");}
                    }
                });
                lock (�l�kilitB) {Console.WriteLine ("�l�kilitA-->�l�kilitB");}
                lock (�l�kilitA) {Console.WriteLine ("�l�kilitA-->�l�kilitA");}
            }

            Thread.Sleep (1000); Console.WriteLine ("\nOkuyucuYaz�c�Kilit'in yakalanma, y�kselme, d��me ve serbestlenmesi:");
            ReaderWriterLock oyKilit = new ReaderWriterLock();
            oyKilit.AcquireReaderLock (250); Console.WriteLine ("Okuyucu kilit yakaland� m�? " + oyKilit.IsReaderLockHeld);
            if (!oyKilit.IsReaderLockHeld) return;
            Console.WriteLine ("Tutulan okuyucu kilit: " + oyKilit);
            LockCookie �erez = oyKilit.UpgradeToWriterLock (250);
            if (oyKilit.IsWriterLockHeld) {
                Console.WriteLine ("Yaz�c� kilite y�kseltildi");
                oyKilit.DowngradeFromWriterLock (ref �erez);
                Console.WriteLine ("Yaz�c� kilitten d���r�ld�: " + �erez);
            }
            oyKilit.ReleaseReaderLock();
            Console.WriteLine ("Okuyucu kilit serbest b�rak�ld�");
            oyKilit = new ReaderWriterLock();
            oyKilit.AcquireWriterLock (100); Console.WriteLine ("Yaz�c� kilit yakaland� m�? " + oyKilit.IsWriterLockHeld);
            if (oyKilit.IsWriterLockHeld) {
                Console.WriteLine ("Yaz�c� kilit tutuldu");
                oyKilit.ReleaseWriterLock();
                Console.WriteLine ("Yaz�c� kilit serbest b�rak�ld�");
            }
            //Tekrar serbestlemeyi dene
            try {oyKilit.ReleaseWriterLock();}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Thread.Sleep (1000); Console.WriteLine ("\nHesap yat/�ek ve hesapdurumu oyKilit yakala/b�rak'la bloklu:");
            Hesap hsp = new Hesap();
            string a; decimal b; DateTime c;
            hsp.HesapDurumu (out a, out b, out c); Console.WriteLine ("�LK DURUM [�sim: {0}, Bakiye: {1}, Tarih: {2}]", a, b, c);
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeG�ncelleme (+12500.75m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeG�ncelleme (-6743.65m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeG�ncelleme (-25675.15m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeG�ncelleme (+32652.92m));
            hsp.HesapDurumu (out a, out b, out c); Console.WriteLine ("SON DURUM [�sim: {0}, Bakiye: {1}, Tarih: {2}]", a, b, c);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}