// j2sc#2002a.cs: ThreadPool ve metodun durum parametreli mesajý örneði.

using System;
using System.Threading;
namespace SicimHavuzu {
    class HavuzA {
        static void Sayaç (object durum) {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine ("  Sicim#1: {0}", i);
                Thread.Sleep (100);
            }
        }
        static void Sayaç2 (object durum) {//WaitCallback uyumu için parametre
            for (int i = 0; i < 10; i++) {
                Console.WriteLine ("    Sicim#2: {0}", i);
                Thread.Sleep (200);
            }
        }
        public static ManualResetEvent ManüelOlay = new ManualResetEvent (false);
        public static AutoResetEvent OtomatikOlay = new AutoResetEvent (false);
        public static void ManüelZeminGörevi (Object drm) {Console.WriteLine ("ManüelSicim"); ManüelOlay.Set();}
        public static void OtomatikZeminGörevi (Object drm) {Console.WriteLine ("OtomatikSicim"); OtomatikOlay.Set();}
        public static void MesajýGöster (object mesaj) {Console.WriteLine (mesaj==null?"null":mesaj.ToString()); Thread.Sleep (1000);}
        public static void yýllar (Object ns) {
            Console.Write (ns==null?"":ns.ToString());
            for (int i = 1881; i <= 1938; i++) Console.Write (i+" "); Console.WriteLine();
        }
        private static void SicimHavuzuMetodu (object durum) {
            ManualResetEvent manüelOlay = (ManualResetEvent)durum;
            Console.WriteLine ("Sicim-havuzu görev no: {0}", Thread.CurrentThread.ManagedThreadId);
            manüelOlay.Set();
        }
        static void Main() {
            Console.Write ("SicimHavuzu 'ThreadPool.QueueUserWorkItem(new WaitCallback(Metot), durumMesajý)' ile yürütülür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Main() ve Join'siz 2 sicimin farklý Sleep'li görev paylaþýmý:");
            int i;
            ThreadPool.QueueUserWorkItem (new WaitCallback (Sayaç));
            ThreadPool.QueueUserWorkItem (new WaitCallback (Sayaç2));
            for(i=0;i<10;i++) {
                Console.WriteLine ("Main(): {0}", i);
                Thread.Sleep (50);
            }

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuzu'nun manüel/otomatik olay'lý sicim metot çaðrýsý:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (ManüelZeminGörevi));
            ManüelOlay.WaitOne(); //1sn bekle
            ManüelOlay.Reset();
            ThreadPool.QueueUserWorkItem (new WaitCallback (OtomatikZeminGörevi));
            OtomatikOlay.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuz metot parametresiyle mesaj yollama:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (MesajýGöster));
            ThreadPool.QueueUserWorkItem (new WaitCallback (MesajýGöster), "Herkese selamlar...");
            ThreadPool.QueueUserWorkItem (MesajýGöster);
            ThreadPool.QueueUserWorkItem (MesajýGöster, "Merhabalar...");
            ThreadPool.QueueUserWorkItem (MesajýGöster, "Selam!..");

            Thread.Sleep (1000); Console.WriteLine ("\nNesnel bilgi yada null iletimli SicimHavuz metot çaðrýsý:");
            ThreadPool.QueueUserWorkItem (new WaitCallback (yýllar), null);
            ThreadPool.QueueUserWorkItem (new WaitCallback (yýllar), "Selanik'ten AnýtKabir'e Atatürk: ");
            ThreadPool.QueueUserWorkItem (new WaitCallback (yýllar), "TC Baþkenti Ankara ve Atatürk: ");

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli ve manüel olay kullanýmlý iki sicim görevi:");
            using (EventWaitHandle olayBekleYönetimi = new ManualResetEvent (false))
                using (EventWaitHandle çaðrýOlayý = new ManualResetEvent (false)) {
                    ThreadPool.RegisterWaitForSingleObject (olayBekleYönetimi,
                        delegate {Console.WriteLine ("Tetiklenen sicim no: {0}", Thread.CurrentThread.ManagedThreadId); çaðrýOlayý.Set();},
                        null, Timeout.Infinite, true);
                    Console.WriteLine ("Olay kuran sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
                    olayBekleYönetimi.Set();
                    çaðrýOlayý.WaitOne();
            }
            int n1, n2;
            ThreadPool.GetAvailableThreads (out n1, out n2);
            Console.WriteLine ("Mevcut sicim no'lar = ({0}, {1})", n1, n2);
            ThreadPool.GetMaxThreads (out n1, out n2);
            Console.WriteLine ("Enbüyük sicim no'lar = ({0}, {1})", n1, n2);
            ThreadPool.GetMinThreads (out n1, out n2);
            Console.WriteLine ("Enküçük sicim no'lar = ({0}, {1})", n1, n2);

            Thread.Sleep (1000); Console.WriteLine ("\nHer yeni SicimHavuz no ve Main sicim no:");
            ManüelOlay = new ManualResetEvent (false);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), ManüelOlay);
            ManüelOlay.Reset(); ManüelOlay.WaitOne(); Thread.Sleep (1000);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), ManüelOlay);
            ManüelOlay.Reset(); ManüelOlay.WaitOne(); Thread.Sleep (2000);
            ThreadPool.QueueUserWorkItem (new WaitCallback (SicimHavuzuMetodu), ManüelOlay);
            ManüelOlay.Reset(); ManüelOlay.WaitOne();
            Console.WriteLine ("Main sicim no: {0}", Thread.CurrentThread.ManagedThreadId);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}