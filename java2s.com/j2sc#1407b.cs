// j2sc#1407b.cs: Trace.Listeners.Add(new TextWriterTraceListener(Console.Out/dosya)) ile Assert testleri örneði.

#define TRACE
using System;
using System.Diagnostics; //Trace için
using System.IO; //FileStream ve FileMode için
namespace Geliþimler {
    class ÝzleyiciB {
        static void Main() {
            Console.Write ("'#define TRACE' tanýmsýz izleme yapýlamaz. Trace.Listeners.Add(new TextWriterTraceListener(Console.Out/dosya)) ile Assert iddia sonuçlarý debug edilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Trace ile yönlendirilen çýktýya Assert ve WriteLine sunma:");
            Trace.Listeners.Add (new TextWriterTraceListener (Console.Out));
            Trace.WriteLine ("Trace ile ekranda izlenenler");
            int i = 0; Trace.Assert ((i == 1), "Özel Trace iddiam: [i(=0) == 1]?");
            Trace.Flush();

            FileStream dosya = new FileStream ("mny.txt", FileMode.OpenOrCreate);
            Trace.Listeners.Add (new TextWriterTraceListener (dosya));
            Trace.WriteLine ("Trace ile mny.txt dosyada izlenenler");
            Trace.Assert ((i == 1), "Özel Trace iddiam: [i(=0) == 1]?");
            Trace.Flush();
            dosya.Close();

            try {
                EventLogTraceListener izle = new EventLogTraceListener ("Uygulamam");
                Trace.Listeners.Add (izle);
                Trace.WriteLine ("My Trace String To Console");
                Trace.Assert ((i == 1), "Özel Trace iddiam: [i(=0) == 1]?");
                Trace.Flush();
            }catch (Exception ht) {Console.WriteLine ("\tHATA: [{0}]", ht.Message);}

            TraceSwitch bileþen = new TraceSwitch ("mny1.xml", "Uygulama düðmesi");
            string h;
            try {Trace.WriteLine (bileþen.TraceError, "bileþen - Error Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bileþen.TraceWarning, "bileþen - Warning Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bileþen.TraceInfo, "bileþen - Info Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bileþen.TraceVerbose, "bileþen - Verbose Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}