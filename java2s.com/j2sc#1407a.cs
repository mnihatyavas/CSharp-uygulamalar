// j2sc#1407a.cs: TextWriterTraceListener ve Trace.Listeners.Add'le hata takibi örneði.

#define DEBUG
#define TRACE
using System;
using System.Diagnostics; //DefaultTraceListener ve Trace için
namespace Geliþimler {
    class ÝzleyiciA {
        static void Main() {
            Console.Write ("izle=TextWriterTraceListener ve Debug/Trace.Listeners.Add(izle) ile hata-ayýklama test sonuçlarý dos/windows/diskdosya'ya yazdýrýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Birbirinden baðýmsýz 4 TraceListener ile Debug:");
            goto iz4;
            try {
                DefaultTraceListener izle1 = new DefaultTraceListener();
                izle1.AssertUiEnabled = true;
                Trace.Listeners.Add (izle1);
                Trace.Listeners.Add (new DefaultTraceListener());
                Trace.Listeners.Add (new ConsoleTraceListener());
                Trace.Listeners.Clear(); //Tüm izleyiciler silinir
                Trace.Listeners.Add (new EventLogTraceListener ("BugRiddenLog"));
                Debug.Assert (1 == 0,"Hata!","Hata: 1 == 0");
                Trace.Listeners.Clear();
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
       iz2: try {
                TextWriterTraceListener izle2 = new TextWriterTraceListener (Console.Out);
                Debug.Listeners.Add (izle2);
                Debug.WriteLine ("Main() baþlýyor");
                Debug.Assert (1 == 2, "1==2?");
                Debug.WriteLine ("Main()'den çýkýyor");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            goto son;
       iz3: BooleanSwitch bs = new BooleanSwitch ("TraceOutput", "Turn on tracing");
            TextWriterTraceListener izle3 = new TextWriterTraceListener ("izle3.txt");
            Trace.Listeners.Add (izle3);
            EventLogTraceListener izle4 = new EventLogTraceListener ("Application");
            Trace.Listeners.Add (izle4);
            Trace.WriteLineIf (bs.Enabled, "Main() baþlýyor");
            if (bs.Enabled) Trace.Assert (1 == 2, "1 == 2 ?");
            Trace.WriteLineIf (bs.Enabled, "Main()'den çýkýyor");
            Trace.Flush();
            Trace.Close(); goto son;
       iz4: TextWriterTraceListener izle5 = new TextWriterTraceListener();
            izle5.Writer = System.Console.Out;
            Trace.Listeners.Add (izle5);
            izle5.Write ("Konsol ekranýna yaz.");
            izle5.WriteLine ("Tekrar konsol ekranýna yaz.");
            izle5.Flush();
            izle5.Close();

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}