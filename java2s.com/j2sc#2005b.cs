// j2sc#2005b.cs: ÖzelKilit, mutexSicim, ölükilit, okuyazKilit örneði.

using System;
using System.Threading;
namespace Sicimler {
    class FýrýlKilit {
        private int durum;
        private EventWaitHandle olayBekleYönet = new AutoResetEvent (false);
        private static bool tekÝþlevMi = (Environment.ProcessorCount == 1);
        private const int dýþDeneSayaç = 5;
        private const int fazlaDeneSayaç = 100;
        public void Gir (out bool tekMi) {
            tekMi = false;
            while (!tekMi) {
                if (tekÝþlevMi) {
                    Thread.BeginCriticalRegion();
                    tekMi = Interlocked.CompareExchange (ref durum, 1, 0) == 0;
                    if (!tekMi) Thread.EndCriticalRegion();
                }else {
                    for (int i = 0; !tekMi && i < dýþDeneSayaç; i++) {
                        Thread.BeginCriticalRegion();
                        int deneme = 0;
                        while (!(tekMi = Interlocked.CompareExchange (ref durum, 1, 0) == 0) && deneme++ < fazlaDeneSayaç) {Thread.SpinWait (1);}
                        if (!tekMi) {
                            Thread.EndCriticalRegion();
                            Thread.Sleep (0);
                        }
                    }
                }
                if (!tekMi) olayBekleYönet.WaitOne();
            }
            return;
        }
        public void Gir() {bool b;  Gir (out b);}
        public void Çýk() {
            if (Interlocked.CompareExchange (ref durum, 0, 1) == 1) { 
                olayBekleYönet.Set();
                Thread.EndCriticalRegion();
            }
        }
    }
    public abstract class ÝþçiSicim {
        private object  sicimVeri;
        private Thread  sicim;
        public object SicimVeri {get {return sicimVeri;} set {sicimVeri = value;}} //Özellik
        public object IsAlive {get {return sicim == null? false : sicim.IsAlive;}}
        public ÝþçiSicim (object veri) {sicimVeri = veri;} //Kurucu-1
        public ÝþçiSicim() {sicimVeri = null;} //Kurucu-2
        public void Baþlat() {
            sicim = new Thread (new ThreadStart (this.Koþtur));
            sicim.Start();
        }
        public void Bitir() {
            sicim.Abort();
            while (sicim.IsAlive);
            sicim = null;
        }
        protected abstract void Koþtur();
    }
    public struct AçMüþteriVerileri {//Yapý
        public int MüþteriNo;
        public Mutex SaðYÇubuk;
        public Mutex SolYÇubuk;
        public int YenenLokma;
        public int KalanLokma;
    }
    public class AçMüþteri : ÝþçiSicim {
        public AçMüþteri (object veri) : base (veri){} //Kurucu
        protected override void Koþtur() {
            AçMüþteriVerileri amv = (AçMüþteriVerileri)SicimVeri;
            Random r = new Random (amv.MüþteriNo);
            Console.WriteLine ("AçMüþteri#{0} yemeye hazýr", amv.MüþteriNo);
            WaitHandle[] yemekÇubuklarý =  new WaitHandle[] {amv.SolYÇubuk, amv.SaðYÇubuk};
            while (amv.KalanLokma > 0) {
                WaitHandle.WaitAll (yemekÇubuklarý); //Heriki çubuðu al
                Console.WriteLine ("AçMüþteri#{0} kalan {1} lokmanýn {2}'nü aðzýna koyuyor", amv.MüþteriNo, amv.KalanLokma, amv.YenenLokma);
                amv.KalanLokma -= amv.YenenLokma;
                Thread.Sleep (r.Next(10,100));
                Console.WriteLine ("AçMüþteri#{0} lokmalarý çiðniyor", amv.MüþteriNo);
                amv.SaðYÇubuk.ReleaseMutex(); //Çiðneme süresince çubuklarý býrakýyor
                amv.SolYÇubuk.ReleaseMutex();
                Thread.Sleep (r.Next(10,100));
            }
            Console.WriteLine ("AçMüþteri#{0} yemeðini bitirdi", amv.MüþteriNo);
        }
    }
    class Hesap {
        string isim ="Yücel Küçükbay";
        decimal bakiye= 50000.0m;
        DateTime tarih = DateTime.Now;
        ReaderWriterLock oyKilit = new ReaderWriterLock();
        public decimal BakiyeGüncelleme (decimal tutar) {
            oyKilit.AcquireWriterLock (-1); //kilitle
            Thread.Sleep (500);
            try {bakiye += tutar;
                tarih = DateTime.Now;
                return bakiye;
            }finally  {oyKilit.ReleaseWriterLock();} //Kilidi aç
        }
        public void HesapDurumu (out string isim, out decimal bakiye, out DateTime tarih) {
            oyKilit.AcquireReaderLock (-1); //kilitle
            Thread.Sleep (500);
            try {isim = this.isim;
                bakiye = this.bakiye;
                tarih = this.tarih;
            }finally {oyKilit.ReleaseReaderLock();} //Kilidi aç
        }
    }
    class KilitB {
        private static object ölükilitA = new object();
        private static object ölükilitB = new object();
        static void Main() {
            Console.Write ("lock{} bloðu yerine ayrý ifadeleli ReaderWriterLock.AcquireReaderLock()/ReleaseWriterLock() kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm muhtemel çevre sicimlere özel ölükilit gir-çýk kontrolu:");
            FýrýlKilit fk=null;; int i;
            for(i=0;i<5;i++) {
                try {fk = new FýrýlKilit();
                    fk.Gir();
                    Console.WriteLine ((i+1) + ".FýrýlKilit yakalandý");
                }finally {
                    fk.Çýk();
                    Console.WriteLine ("\tÖlüKilit'lenme olmadan {0}.FýrýlKilit serbest býrakýldý", (i+1));
                }
            }

            Thread.Sleep (1000); Console.WriteLine ("\n4 müþteri, 4 çift çubukla 3/9'er lokmalarla yemek yiyorlar:");
            Mutex[] yemekÇubuklarý = new Mutex [4];
            for(i = 0; i < 4; i++) yemekÇubuklarý [i] = new Mutex(false);
            for(i = 0; i < 4; i++) {//5 müþteri
                AçMüþteriVerileri amv;
                amv.MüþteriNo = i + 1;
                amv.SaðYÇubuk = yemekÇubuklarý [i - 1 >= 0 ? (i - 1) : 3];
                amv.SolYÇubuk = yemekÇubuklarý [i];
                amv.YenenLokma = 3;
                amv.KalanLokma = 9;
                AçMüþteri am = new AçMüþteri (amv);
                am.Baþlat();
            }

            Thread.Sleep (2000); Console.WriteLine ("\nÝçiçe kilitli blok bazen sistemi dondurmaktadýr:");
            lock (ölükilitA) {
                ThreadPool.QueueUserWorkItem (delegate {
                    lock (ölükilitB) {
                        Console.WriteLine ("ölükilitA-->ölükilitB");
                        lock (ölükilitA) {Console.WriteLine ("ölükilitA-->ölükilitB-->ölükilitA");}
                    }
                });
                lock (ölükilitB) {Console.WriteLine ("ölükilitA-->ölükilitB");}
                lock (ölükilitA) {Console.WriteLine ("ölükilitA-->ölükilitA");}
            }

            Thread.Sleep (1000); Console.WriteLine ("\nOkuyucuYazýcýKilit'in yakalanma, yükselme, düþme ve serbestlenmesi:");
            ReaderWriterLock oyKilit = new ReaderWriterLock();
            oyKilit.AcquireReaderLock (250); Console.WriteLine ("Okuyucu kilit yakalandý mý? " + oyKilit.IsReaderLockHeld);
            if (!oyKilit.IsReaderLockHeld) return;
            Console.WriteLine ("Tutulan okuyucu kilit: " + oyKilit);
            LockCookie çerez = oyKilit.UpgradeToWriterLock (250);
            if (oyKilit.IsWriterLockHeld) {
                Console.WriteLine ("Yazýcý kilite yükseltildi");
                oyKilit.DowngradeFromWriterLock (ref çerez);
                Console.WriteLine ("Yazýcý kilitten düþürüldü: " + çerez);
            }
            oyKilit.ReleaseReaderLock();
            Console.WriteLine ("Okuyucu kilit serbest býrakýldý");
            oyKilit = new ReaderWriterLock();
            oyKilit.AcquireWriterLock (100); Console.WriteLine ("Yazýcý kilit yakalandý mý? " + oyKilit.IsWriterLockHeld);
            if (oyKilit.IsWriterLockHeld) {
                Console.WriteLine ("Yazýcý kilit tutuldu");
                oyKilit.ReleaseWriterLock();
                Console.WriteLine ("Yazýcý kilit serbest býrakýldý");
            }
            //Tekrar serbestlemeyi dene
            try {oyKilit.ReleaseWriterLock();}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Thread.Sleep (1000); Console.WriteLine ("\nHesap yat/çek ve hesapdurumu oyKilit yakala/býrak'la bloklu:");
            Hesap hsp = new Hesap();
            string a; decimal b; DateTime c;
            hsp.HesapDurumu (out a, out b, out c); Console.WriteLine ("ÝLK DURUM [Ýsim: {0}, Bakiye: {1}, Tarih: {2}]", a, b, c);
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeGüncelleme (+12500.75m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeGüncelleme (-6743.65m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeGüncelleme (-25675.15m));
            Console.WriteLine ("Son bakiye: {0,10:#,0.00} TL", hsp.BakiyeGüncelleme (+32652.92m));
            hsp.HesapDurumu (out a, out b, out c); Console.WriteLine ("SON DURUM [Ýsim: {0}, Bakiye: {1}, Tarih: {2}]", a, b, c);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}