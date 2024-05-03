// j2sc#1407c.cs: TraceSwitch, StackTrace ve StackFrame örneði.

#define TRACE
#define DEBUG
using System;
using System.Diagnostics;
namespace Geliþimler {
    enum DüðmeSeviyesi {
        Sessiz = 0,
        Azöz = 1,
        Lafkalabalýðý = 2,
        Sohbet = 3
    }
    class SeçilenDüðme: Switch {
        public SeçilenDüðme (string ad, string izahat) : base (ad, izahat) {} //Ebeveynli kurucu
        public DüðmeSeviyesi Level {
            get {return((DüðmeSeviyesi) base.SwitchSetting);}
            set {base.SwitchSetting = (int) value;}    
        }
        public bool Sessiz {get {return(base.SwitchSetting == 0);}}
        public bool Azöz {get {return(base.SwitchSetting >= (int) (DüðmeSeviyesi.Azöz));}}
        public bool Lafkalabalýðý {get {return(base.SwitchSetting >= (int) DüðmeSeviyesi.Lafkalabalýðý);}}
        public bool Sohbet {get {return(base.SwitchSetting >=(int) DüðmeSeviyesi.Sohbet);}}
        protected new int SwitchSetting {
            get {return((int) base.SwitchSetting);}
            set {if (value < 0) value = 0;
                 if (value > 4) value = 4;
                 base.SwitchSetting = value;
            }
        }
    }
    class DebugSýnýf {
        static SeçilenDüðme debugSonucu = new SeçilenDüðme ("DebugSonucum", "uygulama");
        int i = 0;
        public DebugSýnýf (int i) {this.i = i;} //Kurucu
        [Conditional ("DEBUG")]
        public void OnayDurumu() {
            Console.WriteLine ("\tOnayDurumu Sessiz");
            Debug.WriteLine (debugSonucu.Azöz, "OnayDurumu Azöz'le baþladý");
            Debug.WriteLine ("OnayDurumu Lafkalabalýðý'ný kesti");
            Debug.WriteLine (debugSonucu.Sohbet, "OnayDurumu Sohbet devamýný onaylandý");
        }
     }
    class ÝzleyiciC {
        internal static void MetodA() {MetodB (10, 50);}
        internal static void MetodB (int x, int y) {MetodC ("Merhaba", x * y);}
        internal static void MetodC (string selam, int sayý) {
            Console.WriteLine ("Herkese {0} kerre {1}.", sayý, selam);
            StackTrace iz = new StackTrace();
            Console.WriteLine (iz.ToString());
        }
        static void Main() {
            Console.Write ("Trace ve Debug raporlamasý için '#define TRACE/DEBUG' gerekmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verilen izleme kaynaðýna dair hata mesajlarý neþri:");
            Trace.Listeners.Add (new ConsoleTraceListener());
            TraceSource kaynak = new TraceSource ("ÝzleyiciC");
            Trace.WriteLine ("Yeni bir ÝzleyiciC sýnýf tiplemesi", "izle1");
            Debug.Assert (2023 == 2024, "2023==2024?");
            kaynak.TraceEvent (TraceEventType.Warning, 1000,"veriler bozuk olabilir");
            kaynak.TraceInformation ("ÝzleyiciC verileri DB veritabanýndan yüklendi");
            kaynak.Flush();
            kaynak.Switch = new SourceSwitch ("kaynaðým");
            kaynak.Switch.Level = SourceLevels.Error;
            kaynak.TraceEvent (TraceEventType.Information, 0, "Bilgi olayý");
            kaynak.TraceEvent (TraceEventType.Error, 0, "Hata olayý");

            Console.WriteLine ("\nTiplemede kurucuya girilenle tüm düðmeleme seviyelerini debug'lama:");
            TraceSwitch izlemeDüðmesi = new TraceSwitch ("izlemeDüðmesi", "bilgi");
            Trace.WriteLine (izlemeDüðmesi.TraceError, "Hatalý birþeyler oluþtu");
            Trace.WriteLine (izlemeDüðmesi.TraceInfo, "Bazý bilgiler izlendi");
            Debug.Listeners.Clear(); //Önceki izleyicileri siler
            Debug.Listeners.Add (new TextWriterTraceListener (Console.Out));
            DebugSýnýf ds = new DebugSýnýf (-10); ds.OnayDurumu();
            ds = new DebugSýnýf (1); ds.OnayDurumu();
            ds = new DebugSýnýf (2); ds.OnayDurumu();
            ds = new DebugSýnýf (5); ds.OnayDurumu();

            Console.WriteLine ("\nStackTrace ile bulunan kodlama konumunun takibi:");
            StackTrace yýðýnÝzi = new StackTrace();
            Console.WriteLine ("YýðýnÝzi: [{0}]", yýðýnÝzi);
            for (int i = 0; i < yýðýnÝzi.FrameCount; i++) {
                StackFrame yýðýnÇerçeve =  yýðýnÝzi.GetFrame (i);
                Console.WriteLine ("YýðýnÇerçeve-{0}: [{1}]", i, yýðýnÇerçeve.ToString() );
            }
            MetodA();

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    } 
}