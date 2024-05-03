// j2sc#1407b.cs: Trace.Listeners.Add(new TextWriterTraceListener(Console.Out/dosya)) ile Assert testleri �rne�i.

#define TRACE
using System;
using System.Diagnostics; //Trace i�in
using System.IO; //FileStream ve FileMode i�in
namespace Geli�imler {
    class �zleyiciB {
        static void Main() {
            Console.Write ("'#define TRACE' tan�ms�z izleme yap�lamaz. Trace.Listeners.Add(new TextWriterTraceListener(Console.Out/dosya)) ile Assert iddia sonu�lar� debug edilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Trace ile y�nlendirilen ��kt�ya Assert ve WriteLine sunma:");
            Trace.Listeners.Add (new TextWriterTraceListener (Console.Out));
            Trace.WriteLine ("Trace ile ekranda izlenenler");
            int i = 0; Trace.Assert ((i == 1), "�zel Trace iddiam: [i(=0) == 1]?");
            Trace.Flush();

            FileStream dosya = new FileStream ("mny.txt", FileMode.OpenOrCreate);
            Trace.Listeners.Add (new TextWriterTraceListener (dosya));
            Trace.WriteLine ("Trace ile mny.txt dosyada izlenenler");
            Trace.Assert ((i == 1), "�zel Trace iddiam: [i(=0) == 1]?");
            Trace.Flush();
            dosya.Close();

            try {
                EventLogTraceListener izle = new EventLogTraceListener ("Uygulamam");
                Trace.Listeners.Add (izle);
                Trace.WriteLine ("My Trace String To Console");
                Trace.Assert ((i == 1), "�zel Trace iddiam: [i(=0) == 1]?");
                Trace.Flush();
            }catch (Exception ht) {Console.WriteLine ("\tHATA: [{0}]", ht.Message);}

            TraceSwitch bile�en = new TraceSwitch ("mny1.xml", "Uygulama d��mesi");
            string h;
            try {Trace.WriteLine (bile�en.TraceError, "bile�en - Error Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bile�en.TraceWarning, "bile�en - Warning Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bile�en.TraceInfo, "bile�en - Info Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}
            try {Trace.WriteLine (bile�en.TraceVerbose, "bile�en - Verbose Tracing Enabled");}catch (Exception ht) {h=ht.Message; Console.WriteLine ("\tHATA: [{0}]", h.Substring(0,24));}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}