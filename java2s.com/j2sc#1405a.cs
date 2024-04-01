// j2sc#1405a.cs: Process ile tüm iþletilen komutlarý yürütebilme örneði.

using System;
using System.Diagnostics; //ProcessStartInfo ve Process.Start için
namespace Geliþimler {
    class ÝþletA {
        static void SüreçTamamlandý (object gönderen, EventArgs olay) {Console.WriteLine ("Ýþletilen oyun süreci kapatýldý.");}
        public static void ÝÞNOSicimleri (int iþNO) {
            Process iþlet;
            try {iþlet = Process.GetProcessById (iþNO);
            }catch {Console.WriteLine ("Kötü iþNO"); return;}
            Console.WriteLine ("{0}({1}) için sicim No'lar:", iþlet.ProcessName, iþNO);
            ProcessThreadCollection ipler = iþlet.Threads;
            foreach (ProcessThread ip in ipler) {
                try {Console.WriteLine ("-> Sicim NO: {0}\tBaþlama vakti: {1}\tÖnceliði {2}", ip.Id , ip.StartTime.ToShortTimeString(), ip.PriorityLevel);
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            }
            Console.WriteLine ("{0}({1}) için yüklü modüller:", iþlet.ProcessName, iþNO);
            try {ProcessModuleCollection modüller = iþlet.Modules;
                foreach (ProcessModule modül in modüller) Console.WriteLine("-> Modül adý: {0}", modül.ModuleName);
            }catch {Console.WriteLine ("Modül yok!");}
        }
        static void Main() {
            Console.Write ("iþlet.Close() ve iþlet.WaitForExit() metotlarý ProcessStartInfo için deðil, Process tiplemesinde geçerlidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Process'le argümanlý ve argümansýz exe dosya iþletimi:");
            Console.WriteLine ("\t'wordpad.exe j2sc#1405a.cs' iþletilecek:");
            ProcessStartInfo iþlet1 = new ProcessStartInfo();
            iþlet1.FileName = "wordpad.exe";
            iþlet1.Arguments = "j2sc#1405a.cs";
            Process.Start (iþlet1);
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.WriteLine ("\tYeni 'notepad.exe' süreci baþlýyor:");
            Process iþlet2=Process.Start ("notepad.exe");;
            iþlet2.WaitForExit(); //notepad.exe kapatýlýncaya deðin bekler
            iþlet2.Close();
            Console.WriteLine ("Yeni süreç kapatýlarak sonlandýrýldý.");
            Process iþlet3 = new Process();
            iþlet3.StartInfo.FileName = "C:/Program Files/Microsoft Games/SpiderSolitaire/SpiderSolitaire.exe";
            iþlet3.StartInfo.Arguments = ""; //argümansýz oyun
            iþlet3.EnableRaisingEvents = true;
            iþlet3.Exited += new EventHandler (SüreçTamamlandý); //iþlet3 sonlanýnca bu metot çaðrýlacak
            iþlet3.Start();
            iþlet3.WaitForExit();
            Console.WriteLine ("WaitForExit() ve SüreçTamamlandý() sonrasý.");

            Console.WriteLine ("\nMevcut çalýþma dizindeki dosyalarýn listelenmesi:");
            iþlet3 = new Process();
            iþlet3.StartInfo.FileName = "cmd.exe";
            iþlet3.StartInfo.Arguments = "/c dir *.*";
            iþlet3.StartInfo.UseShellExecute = false;
            iþlet3.StartInfo.RedirectStandardOutput = true;
            iþlet3.Start();
            string çýktý = iþlet3.StandardOutput.ReadToEnd();
            Console.WriteLine ("'cmd.exe/c dir *.*' sonucu:"); Console.WriteLine (çýktý);

            Console.WriteLine ("\nElan bellekte çalýþan tüm programlarýn listesi:");
            Process[] iþletilenler = Process.GetProcesses (".");
            foreach (Process iþ in iþletilenler) {
                //çýktý = string.Format ("-> ÝÞNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName);
                //Console.WriteLine (çýktý);
                Console.WriteLine ("-> ÝÞNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName);
            }

            Console.WriteLine ("\nVerili iþNO ile uyumlu süreçlerin sicim ve modül bilgileri:");
            for(int iþNO=0;iþNO<5;iþNO++) ÝÞNOSicimleri (iþNO);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}