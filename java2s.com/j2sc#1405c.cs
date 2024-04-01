// j2sc#1405c.cs: ProcessStartInfo ve Process ile tek/�oklu i�lere eri�im �rne�i.

using System;
using System.Diagnostics;
namespace Geli�imler {
    class ��letC {
        static void Main() {
            Console.Write ("Bilgisayarda �al��an t�m yerel veya uzak i�lerin no ve adlar�na tek tek veya dizili eri�ilip detaylar� listelenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tam ekranl� wordpad.exe �al��mas�n� 5 sn sonlama beklemesi:");
            ProcessStartInfo i�letBilgi = new ProcessStartInfo();
            i�letBilgi.FileName = "wordpad.exe";
            i�letBilgi.Arguments = "j2sc#1405c.cs";
            i�letBilgi.WorkingDirectory = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#";
            i�letBilgi.WindowStyle = ProcessWindowStyle.Maximized; //Tam ekranl� wordpad.exe
            i�letBilgi.ErrorDialog = true;
            Process i�let;
            try {i�let = Process.Start (i�letBilgi);
                Console.WriteLine ("��lemin tamamlanmas� i�in [5-->60]sn bekleyelim.");
                if (i�let.WaitForExit (5000)) Console.WriteLine ("5 sn i�inde i�lem sonland�r�ld�.");
                else Console.WriteLine ("5 sn ge�ti; i�lem sonland�r�lmay�nca ak��a devam...");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nBilgisayarda �al��an �e�itli i�lerin no ve adlar�:");
            Process akt�el�� = Process.GetCurrentProcess();
            Console.WriteLine ("-> ��NO: {0}\tAd: {1}", akt�el��.Id, akt�el��.ProcessName);
            Process [] adl��� = Process.GetProcessesByName ("notepad");
            foreach (Process i� in adl���) Console.WriteLine ("\t-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName);
            try {Process [] ipli�� = Process.GetProcessesByName ("notepad", "127.0.0.1");
                foreach (Process i� in ipli��) Console.WriteLine ("-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Process [] t�mYerel = Process.GetProcesses();
            int NO=0;
            foreach (Process i� in t�mYerel) {Console.WriteLine ("\t-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName); if(i�.ProcessName.ToString()=="Sozluk") NO=i�.Id;}
            Console.Write ("\nTu�..."); Console.ReadKey();
            Process [] t�mUzak = Process.GetProcesses ("nihet957");
            foreach (Process i� in t�mUzak) Console.WriteLine ("-> ��NO: {0}\tAd: {1}", i�.Id, i�.ProcessName);
            Process noluYerel = Process.GetProcessById (NO);
            Console.WriteLine ("\t-> ��NO: {0}\tAd: {1}", noluYerel.Id, noluYerel.ProcessName);
            Process noluUzak = Process.GetProcessById (3356, "nihet957");
            Console.WriteLine ("-> ��NO: {0}\tAd: {1}", noluUzak.Id, noluUzak.ProcessName);
            //n0: Sozluk detaylar�
            Console.WriteLine ("\n�� ad�: "+ noluYerel.ProcessName);
            Console.WriteLine ("S�re�: {0}, ID: {1}", noluYerel.StartTime, noluYerel.Id);
            Console.WriteLine ("    toplam CPU vakti: {0}", noluYerel.TotalProcessorTime);
            Console.WriteLine ("    �ncelik s�n�f�: {0}  �nceli�i: {1}", noluYerel.PriorityClass, noluYerel.BasePriority);
            Console.WriteLine ("    sanal bellek: {0:#,0} Byte", noluYerel.VirtualMemorySize64);
            Console.WriteLine ("    �zel bellek: {0:#,0} Byte", noluYerel.PrivateMemorySize64);
            Console.WriteLine ("    fiziki bellek: {0:#,0} Byte", noluYerel.WorkingSet64);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}