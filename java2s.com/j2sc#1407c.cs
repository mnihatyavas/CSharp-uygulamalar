// j2sc#1407c.cs: TraceSwitch, StackTrace ve StackFrame �rne�i.

#define TRACE
#define DEBUG
using System;
using System.Diagnostics;
namespace Geli�imler {
    enum D��meSeviyesi {
        Sessiz = 0,
        Az�z = 1,
        Lafkalabal��� = 2,
        Sohbet = 3
    }
    class Se�ilenD��me: Switch {
        public Se�ilenD��me (string ad, string izahat) : base (ad, izahat) {} //Ebeveynli kurucu
        public D��meSeviyesi Level {
            get {return((D��meSeviyesi) base.SwitchSetting);}
            set {base.SwitchSetting = (int) value;}    
        }
        public bool Sessiz {get {return(base.SwitchSetting == 0);}}
        public bool Az�z {get {return(base.SwitchSetting >= (int) (D��meSeviyesi.Az�z));}}
        public bool Lafkalabal��� {get {return(base.SwitchSetting >= (int) D��meSeviyesi.Lafkalabal���);}}
        public bool Sohbet {get {return(base.SwitchSetting >=(int) D��meSeviyesi.Sohbet);}}
        protected new int SwitchSetting {
            get {return((int) base.SwitchSetting);}
            set {if (value < 0) value = 0;
                 if (value > 4) value = 4;
                 base.SwitchSetting = value;
            }
        }
    }
    class DebugS�n�f {
        static Se�ilenD��me debugSonucu = new Se�ilenD��me ("DebugSonucum", "uygulama");
        int i = 0;
        public DebugS�n�f (int i) {this.i = i;} //Kurucu
        [Conditional ("DEBUG")]
        public void OnayDurumu() {
            Console.WriteLine ("\tOnayDurumu Sessiz");
            Debug.WriteLine (debugSonucu.Az�z, "OnayDurumu Az�z'le ba�lad�");
            Debug.WriteLine ("OnayDurumu Lafkalabal���'n� kesti");
            Debug.WriteLine (debugSonucu.Sohbet, "OnayDurumu Sohbet devam�n� onayland�");
        }
     }
    class �zleyiciC {
        internal static void MetodA() {MetodB (10, 50);}
        internal static void MetodB (int x, int y) {MetodC ("Merhaba", x * y);}
        internal static void MetodC (string selam, int say�) {
            Console.WriteLine ("Herkese {0} kerre {1}.", say�, selam);
            StackTrace iz = new StackTrace();
            Console.WriteLine (iz.ToString());
        }
        static void Main() {
            Console.Write ("Trace ve Debug raporlamas� i�in '#define TRACE/DEBUG' gerekmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verilen izleme kayna��na dair hata mesajlar� ne�ri:");
            Trace.Listeners.Add (new ConsoleTraceListener());
            TraceSource kaynak = new TraceSource ("�zleyiciC");
            Trace.WriteLine ("Yeni bir �zleyiciC s�n�f tiplemesi", "izle1");
            Debug.Assert (2023 == 2024, "2023==2024?");
            kaynak.TraceEvent (TraceEventType.Warning, 1000,"veriler bozuk olabilir");
            kaynak.TraceInformation ("�zleyiciC verileri DB veritaban�ndan y�klendi");
            kaynak.Flush();
            kaynak.Switch = new SourceSwitch ("kayna��m");
            kaynak.Switch.Level = SourceLevels.Error;
            kaynak.TraceEvent (TraceEventType.Information, 0, "Bilgi olay�");
            kaynak.TraceEvent (TraceEventType.Error, 0, "Hata olay�");

            Console.WriteLine ("\nTiplemede kurucuya girilenle t�m d��meleme seviyelerini debug'lama:");
            TraceSwitch izlemeD��mesi = new TraceSwitch ("izlemeD��mesi", "bilgi");
            Trace.WriteLine (izlemeD��mesi.TraceError, "Hatal� bir�eyler olu�tu");
            Trace.WriteLine (izlemeD��mesi.TraceInfo, "Baz� bilgiler izlendi");
            Debug.Listeners.Clear(); //�nceki izleyicileri siler
            Debug.Listeners.Add (new TextWriterTraceListener (Console.Out));
            DebugS�n�f ds = new DebugS�n�f (-10); ds.OnayDurumu();
            ds = new DebugS�n�f (1); ds.OnayDurumu();
            ds = new DebugS�n�f (2); ds.OnayDurumu();
            ds = new DebugS�n�f (5); ds.OnayDurumu();

            Console.WriteLine ("\nStackTrace ile bulunan kodlama konumunun takibi:");
            StackTrace y���n�zi = new StackTrace();
            Console.WriteLine ("Y���n�zi: [{0}]", y���n�zi);
            for (int i = 0; i < y���n�zi.FrameCount; i++) {
                StackFrame y���n�er�eve =  y���n�zi.GetFrame (i);
                Console.WriteLine ("Y���n�er�eve-{0}: [{1}]", i, y���n�er�eve.ToString() );
            }
            MetodA();

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    } 
}