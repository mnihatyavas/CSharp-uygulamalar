// j2sc#1405c.cs: ProcessStartInfo ve Process ile tek/çoklu iþlere eriþim örneði.

using System;
using System.Diagnostics;
namespace Geliþimler {
    class ÝþletC {
        static void Main() {
            Console.Write ("Bilgisayarda çalýþan tüm yerel veya uzak iþlerin no ve adlarýna tek tek veya dizili eriþilip detaylarý listelenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tam ekranlý wordpad.exe çalýþmasýný 5 sn sonlama beklemesi:");
            ProcessStartInfo iþletBilgi = new ProcessStartInfo();
            iþletBilgi.FileName = "wordpad.exe";
            iþletBilgi.Arguments = "j2sc#1405c.cs";
            iþletBilgi.WorkingDirectory = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#";
            iþletBilgi.WindowStyle = ProcessWindowStyle.Maximized; //Tam ekranlý wordpad.exe
            iþletBilgi.ErrorDialog = true;
            Process iþlet;
            try {iþlet = Process.Start (iþletBilgi);
                Console.WriteLine ("Ýþlemin tamamlanmasý için [5-->60]sn bekleyelim.");
                if (iþlet.WaitForExit (5000)) Console.WriteLine ("5 sn içinde iþlem sonlandýrýldý.");
                else Console.WriteLine ("5 sn geçti; iþlem sonlandýrýlmayýnca akýþa devam...");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nBilgisayarda çalýþan çeþitli iþlerin no ve adlarý:");
            Process aktüelÝþ = Process.GetCurrentProcess();
            Console.WriteLine ("-> ÝþNO: {0}\tAd: {1}", aktüelÝþ.Id, aktüelÝþ.ProcessName);
            Process [] adlýÝþ = Process.GetProcessesByName ("notepad");
            foreach (Process iþ in adlýÝþ) Console.WriteLine ("\t-> ÝþNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName);
            try {Process [] ipliÝþ = Process.GetProcessesByName ("notepad", "127.0.0.1");
                foreach (Process iþ in ipliÝþ) Console.WriteLine ("-> ÝþNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Process [] tümYerel = Process.GetProcesses();
            int NO=0;
            foreach (Process iþ in tümYerel) {Console.WriteLine ("\t-> ÝþNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName); if(iþ.ProcessName.ToString()=="Sozluk") NO=iþ.Id;}
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Process [] tümUzak = Process.GetProcesses ("nihet957");
            foreach (Process iþ in tümUzak) Console.WriteLine ("-> ÝþNO: {0}\tAd: {1}", iþ.Id, iþ.ProcessName);
            Process noluYerel = Process.GetProcessById (NO);
            Console.WriteLine ("\t-> ÝþNO: {0}\tAd: {1}", noluYerel.Id, noluYerel.ProcessName);
            Process noluUzak = Process.GetProcessById (3356, "nihet957");
            Console.WriteLine ("-> ÝþNO: {0}\tAd: {1}", noluUzak.Id, noluUzak.ProcessName);
            //n0: Sozluk detaylarý
            Console.WriteLine ("\nÝþ adý: "+ noluYerel.ProcessName);
            Console.WriteLine ("Süreç: {0}, ID: {1}", noluYerel.StartTime, noluYerel.Id);
            Console.WriteLine ("    toplam CPU vakti: {0}", noluYerel.TotalProcessorTime);
            Console.WriteLine ("    öncelik sýnýfý: {0}  önceliði: {1}", noluYerel.PriorityClass, noluYerel.BasePriority);
            Console.WriteLine ("    sanal bellek: {0:#,0} Byte", noluYerel.VirtualMemorySize64);
            Console.WriteLine ("    özel bellek: {0:#,0} Byte", noluYerel.PrivateMemorySize64);
            Console.WriteLine ("    fiziki bellek: {0:#,0} Byte", noluYerel.WorkingSet64);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}