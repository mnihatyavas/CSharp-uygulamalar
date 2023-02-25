// jtpc#2001.cs: �oklu g�revlemenin ana sicimini adland�rma �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class AnaSicim {
        static void Main() {
            Console.Write ("�oklu g�revler, ayn� zamanda fakat herbiri birer anlar payla�arak �al���rlar.\nSystem.Threding aduzam s�n�flar�: Thread, Mutex, Timer, Monitor, Semaphore, ThreadLocal, ThreadPool, Volatile vb.\n��lem ayr� bellek kullanan bir uygulama, sicim g�reviyse genel belle�i kullanan uygulaman�n bir alti�lem mod�l�d�r.\nHerbir g�rev hayat d�ng�s� System.Threading.Thread s�n�f tiplemesiyle yarat�l�r ve g�rev tamamland���nda sonlan�r. �u safha durumlar� vard�r: Unstarted/yarat�ld�, Runnable/�a�r�ld�, Running/�al���yor, NotRunnable (uyku, bekleme, girdi/��kt�), Dead/sonland�.\nTread s�n�f �zellikleri: CurrentThread, IsAlive, IsBackground, ManagedThreadId, Name, Priority, ThreadState\nMetodlar�: Abort(), Interrupt(), Join(), ResetAbort(), Resume()/demode, Sleep(Int32), Start(), Suspend()/demode, Yield()\n��lem i�inde yarat�lan ilk sicim MainThread/AnaSicim olup, en�nce ba�lar, enson sonlan�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Sicim ad�: " + ip.Name);
            ip.Name = "AnaSicim";
            Console.WriteLine ("Sicim ad�: " + ip.Name);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}