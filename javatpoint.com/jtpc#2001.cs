// jtpc#2001.cs: Çoklu görevlemenin ana sicimini adlandýrma örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class AnaSicim {
        static void Main() {
            Console.Write ("Çoklu görevler, ayný zamanda fakat herbiri birer anlar paylaþarak çalýþýrlar.\nSystem.Threding aduzam sýnýflarý: Thread, Mutex, Timer, Monitor, Semaphore, ThreadLocal, ThreadPool, Volatile vb.\nÝþlem ayrý bellek kullanan bir uygulama, sicim göreviyse genel belleði kullanan uygulamanýn bir altiþlem modülüdür.\nHerbir görev hayat döngüsü System.Threading.Thread sýnýf tiplemesiyle yaratýlýr ve görev tamamlandýðýnda sonlanýr. Þu safha durumlarý vardýr: Unstarted/yaratýldý, Runnable/çaðrýldý, Running/çalýþýyor, NotRunnable (uyku, bekleme, girdi/çýktý), Dead/sonlandý.\nTread sýnýf özellikleri: CurrentThread, IsAlive, IsBackground, ManagedThreadId, Name, Priority, ThreadState\nMetodlarý: Abort(), Interrupt(), Join(), ResetAbort(), Resume()/demode, Sleep(Int32), Start(), Suspend()/demode, Yield()\nÝþlem içinde yaratýlan ilk sicim MainThread/AnaSicim olup, enönce baþlar, enson sonlanýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Sicim adý: " + ip.Name);
            ip.Name = "AnaSicim";
            Console.WriteLine ("Sicim adý: " + ip.Name);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}