// j2sc#2002a.cs: ThreadPool ve metodun durum parametreli mesaj� �rne�i.

using System;
using System.Threading;
namespace SicimHavuzu {
    class HavuzA {
        static void Saya� (object durum) {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine ("  Sicim#1: {0}", i);
                Thread.Sleep (100);
            }
        }
        static void Saya�2 (object durum) {//WaitCallback uyumu i�in parametre
            for (int i = 0; i < 10; i++) {
                Console.WriteLine ("    Sicim#2: {0}", i);
                Thread.Sleep (200);
            }
        }
        public static ManualResetEvent Man�elOlay = new ManualResetEvent (false);
        public static AutoResetEvent OtomatikOlay = new AutoResetEvent (false);
        public static void Man�elZeminG�revi (Object drm) {Console.WriteLine ("Man�elSicim"); Man�elOlay.Set();}
        public static void OtomatikZeminG�revi (Object drm) {Console.WriteLine ("OtomatikSicim"); OtomatikOlay.Set();}
        public static void Mesaj�G�ster (object mesaj) {Console.WriteLine (mesaj==null?"null":mesaj.ToString()); Thread.Sleep (1000);}
        public static void y�llar (Object ns) {
            Console.Write (ns==null?"":ns.ToString());
            for (int i = 1881; i <= 1938; i++) Console.Write (i+" "); Console.WriteLine();
        }
        private static void SicimHavuzuMetodu (object durum) {
            ManualResetEvent man�elOlay = (ManualResetEvent)durum;
            Console.WriteLine ("Sicim-havuzu g�rev no: {0}", Thread.CurrentThread.ManagedThreadId);
            man�elOlay.Set();
        }
        static void Main() {
            Console.Write ("SicimHavuzu 'ThreadPool.QueueUserWorkItem(new WaitCallback(Metot), durumMesaj�)' ile y�r�t�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Main() ve Join'siz 2 sicimin farkl� Sleep'li g�rev payla��m�:");
            int i;
            ThreadPool.QueueUserWorkItem (new WaitCallback (Saya�));
            ThreadPool.QueueUserWorkItem (new WaitCallback (Saya�2));
            for(i=0;i<10;i++) {
                Console.WriteLine ("Main(): {0}", i);
                Thread.Sleep (50);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuzu'nun man�el/otomatik olay'l� sicim metot �a�r�s�:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (Man�elZeminG�revi));
            Man�elOlay.WaitOne(); //1sn bekle
            Man�elOlay.Reset();
            ThreadPool.QueueUserWorkItem (new WaitCallback (OtomatikZeminG�revi));
            OtomatikOlay.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuz metot parametresiyle mesaj yollama:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (Mesaj�G�ster));
            ThreadPool.QueueUserWorkItem (new WaitCallback (Mesaj�G�ster), "Herkese selamlar...");
            ThreadPool.QueueUserWorkItem (Mesaj�G�ster);
            ThreadPool.QueueUserWorkItem (Mesaj�G�ster, "Merhabalar...");
            ThreadPool.QueueUserWorkItem (Mesaj�G�ster, "Selam!..");

            Thread.Sleep (1000); Console.WriteLine ("\nNesnel bilgi yada null iletimli SicimHavuz metot �a�r�s�:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (y�llar), null);
            ThreadPool.QueueUserWorkItem (new WaitCallback (y�llar), "Selanik'ten An�tKabir'e Atat�rk: ");
            ThreadPool.QueueUserWorkItem (new WaitCallback (y�llar), "TC Ba�kenti Ankara ve Atat�rk: ");

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli ve man�el olay kullan�ml� iki sicim g�revi:");
            using (EventWaitHandle olayBekleY�netimi = new ManualResetEvent (false))
                using (EventWaitHandle �a�r�Olay� = new ManualResetEvent (false)) {
                    ThreadPool.RegisterWaitForSingleObject (olayBekleY�netimi,
                        delegate {Console.WriteLine ("Tetiklenen sicim no: {0}", Thread.CurrentThread.ManagedThreadId); �a�r�Olay�.Set();},
                        null, Timeout.Infinite, true);
                    Console.WriteLine ("Olay kuran sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
                    olayBekleY�netimi.Set();
                    �a�r�Olay�.WaitOne();
            }
            int n1, n2;
            ThreadPool.GetAvailableThreads (out n1, out n2);
            Console.WriteLine ("Mevcut sicim no'lar = ({0}, {1})", n1, n2);
            ThreadPool.GetMaxThreads (out n1, out n2);
            Console.WriteLine ("Enb�y�k sicim no'lar = ({0}, {1})", n1, n2);
            ThreadPool.GetMinThreads (out n1, out n2);
            Console.WriteLine ("Enk���k sicim no'lar = ({0}, {1})", n1, n2);

            Thread.Sleep (1000); Console.WriteLine ("\nHer yeni SicimHavuz no ve Main sicim no:");
            Man�elOlay = new ManualResetEvent (false);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), Man�elOlay);
            Man�elOlay.Reset(); Man�elOlay.WaitOne(); Thread.Sleep (1000);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), Man�elOlay);
            Man�elOlay.Reset(); Man�elOlay.WaitOne(); Thread.Sleep (2000);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), Man�elOlay);
            Man�elOlay.Reset(); Man�elOlay.WaitOne();
            Console.WriteLine ("Main sicim no: {0}", Thread.CurrentThread.ManagedThreadId);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}