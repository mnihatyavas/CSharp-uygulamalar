// j2sc#1405a.cs: Process ile t�m i�letilen komutlar� y�r�tebilme �rne�i.

using System;
using System.Diagnostics; //ProcessStartInfo ve Process.Start i�in
namespace Geli�imler {
    class ��letA {
        static void S�re�Tamamland� (object g�nderen, EventArgs olay) {Console.WriteLine ("��letilen oyun s�reci kapat�ld�.");}
        public static void ��NOSicimleri (int i�NO) {
            Process i�let;
            try {i�let = Process.GetProcessById (i�NO);
            }catch {Console.WriteLine ("K�t� i�NO"); return;}
            Console.WriteLine ("{0}({1}) i�in sicim No'lar:", i�let.ProcessName, i�NO);
            ProcessThreadCollection ipler = i�let.Threads;
            foreach (ProcessThread ip in ipler) {
                try {Console.WriteLine ("-> Sicim NO: {0}\tBa�lama vakti: {1}\t�nceli�i {2}", ip.Id , ip.StartTime.ToShortTimeString(), ip.PriorityLevel);
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            }
            Console.WriteLine ("{0}({1}) i�in y�kl� mod�ller:", i�let.ProcessName, i�NO);
            try {ProcessModuleCollection mod�ller = i�let.Modules;
                foreach (ProcessModule mod�l in mod�ller) Console.WriteLine("-> Mod�l ad�: {0}", mod�l.ModuleName);
            }catch {Console.WriteLine ("Mod�l yok!");}
        }
        static void Main() {
            Console.Write ("i�let.Close() ve i�let.WaitForExit() metotlar� ProcessStartInfo i�in de�il, Process tiplemesinde ge�erlidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Process'le arg�manl� ve arg�mans�z exe dosya i�letimi:");
            Console.WriteLine ("\t'wordpad.exe j2sc#1405a.cs' i�letilecek:");
            ProcessStartInfo i�let1 = new ProcessStartInfo();
            i�let1.FileName = "wordpad.exe";
            i�let1.Arguments = "j2sc#1405a.cs";
            Process.Start (i�let1);
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.WriteLine ("\tYeni 'notepad.exe' s�reci ba�l�yor:");
            Process i�let2=Process.Start ("notepad.exe");;
            i�let2.WaitForExit(); //notepad.exe kapat�l�ncaya de�in bekler
            i�let2.Close();
            Console.WriteLine ("Yeni s�re� kapat�larak sonland�r�ld�.");
            Process i�let3 = new Process();
            i�let3.StartInfo.FileName = "C:/Program Files/Microsoft Games/SpiderSolitaire/SpiderSolitaire.exe";
            i�let3.StartInfo.Arguments = ""; //arg�mans�z oyun
            i�let3.EnableRaisingEvents = true;
            i�let3.Exited += new EventHandler (S�re�Tamamland�); //i�let3 sonlan�nca bu metot �a�r�lacak
            i�let3.Start();
            i�let3.WaitForExit();
            Console.WriteLine ("WaitForExit() ve S�re�Tamamland�() sonras�.");

            Console.WriteLine ("\nMevcut �al��ma dizindeki dosyalar�n listelenmesi:");
            i�let3 = new Process();
            i�let3.StartInfo.FileName = "cmd.exe";
            i�let3.StartInfo.Arguments = "/c dir *.*";
            i�let3.StartInfo.UseShellExecute = false;
            i�let3.StartInfo.RedirectStandardOutput = true;
            i�let3.Start();
            string ��kt� = i�let3.StandardOutput.ReadToEnd();
            Console.WriteLine ("'cmd.exe/c dir *.*' sonucu:"); Console.WriteLine (��kt�);

            Console.WriteLine ("\nElan bellekte �al��an t�m programlar�n listesi:");
            Process[] i�letilenler = Process.GetProcesses (".");
            foreach (Process i� in i�letilenler) {
                //��kt� = string.Format ("-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName);
                //Console.WriteLine (��kt�);
                Console.WriteLine ("-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName);
            }

            Console.WriteLine ("\nVerili i�NO ile uyumlu s�re�lerin sicim ve mod�l bilgileri:");
            for(int i�NO=0;i�NO<5;i�NO++) ��NOSicimleri (i�NO);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}