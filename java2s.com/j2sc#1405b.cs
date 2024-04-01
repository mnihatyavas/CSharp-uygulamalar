// j2sc#1405b.cs: Process.Start ile süreç koþturma ve sicim takibi örneði.

using System;
using System.Diagnostics; //ProcessStartInfo ve Process.Start için
namespace Geliþimler {
    class ÝþletB {
        static void Main() {
            Console.Write ("Process.Start(iþ,argüman) ile her türlü iþletilebilir (çevrim-içi/dýþý) programlar ve sicimleri takip edilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IExplore.exe çalýþtýrýlýp çevrimiçiyse java2s.com çaðrýlacak:");
            Console.Write ("--> IE'yi çalýþtýrmak için [Tuþ]..."); Console.ReadKey();
            Process iþlet1 = Process.Start ("IExplore.exe", "www.java2s.com"); Console.WriteLine();
            Console.Write ("--> {0}'yi öldürmek için [Tuþ]...", iþlet1.ProcessName); Console.ReadKey();
            try {iþlet1.Kill();}catch{} // Önceden öldürüldüyse hata vermesin

            Console.WriteLine ("\nAktüel süreç, sicimleri ve detay bilgileri:");
            iþlet1 = Process.GetCurrentProcess();
            ProcessThreadCollection ipler1 = iþlet1.Threads;
            foreach (ProcessThread ip in ipler1) {
                Console.WriteLine ("Sicim: {0}", ip.Id);
                Console.WriteLine ("    baþlama: {0}", ip.StartTime);
                Console.WriteLine ("    CPU vakti: {0}", ip.TotalProcessorTime);
                Console.WriteLine ("    öncelik: {0}", ip.BasePriority);
                Console.WriteLine ("    sicim durumu: {0}", ip.ThreadState); 
            }
            Console.WriteLine ("Süreç adý: "+ iþlet1.ProcessName);
            Console.WriteLine ("Process: {0}, ID: {1}", iþlet1.StartTime, iþlet1.Id);
            Console.WriteLine ("    toplam CPU vakti: {0}", iþlet1.TotalProcessorTime);
            Console.WriteLine ("    öncelik sýnýfý: {0}  önceliði: {1}", iþlet1.PriorityClass, iþlet1.BasePriority);
            Console.WriteLine ("    sanal bellek: {0}", iþlet1.VirtualMemorySize64);
            Console.WriteLine ("    özel bellek: {0}", iþlet1.PrivateMemorySize64);
            Console.WriteLine ("    fiziki bellek: {0}", iþlet1.WorkingSet64);
            iþlet1.PriorityClass = ProcessPriorityClass.High;
            Console.WriteLine ("    yeni öncelik sýnýfý: {0}", iþlet1.PriorityClass);
            Console.Write ("\nTuþ..."); Console.ReadKey(); Console.WriteLine();

            Console.WriteLine ("\nSistemdeki tüm iþler ve sicimlerinin detaylý listelenmesi:");
            Process[] tümÝþler = Process.GetProcesses();
            long toplamBellek = 0;
            foreach (Process iþ in tümÝþler) {
                toplamBellek +=iþ.WorkingSet64;
                ProcessThreadCollection ipler2 = iþ.Threads;
                Console.WriteLine ("Ýþ: {0},  no: {1}", iþ.ProcessName, iþ.Id);
                foreach (ProcessThread ip in ipler2) {
                    try {Console.WriteLine ("  sicim: {0}", ip.Id);
                        Console.WriteLine ("    baþlama: {0}", ip.StartTime.ToString());
                        Console.WriteLine ("    CPU vakti: {0}", ip.TotalProcessorTime);
                        Console.WriteLine ("    önceliði: {0}", ip.BasePriority);
                        Console.WriteLine ("    sicim durumu: {0}", ip.ThreadState.ToString()); 
                    }catch (Exception ht) {Console.WriteLine ("    HATA: [{0}]", ht.Message);}
                }
            }
            Console.WriteLine ("Tüm iþler için kullanýlan toplam fiziki bellek: {0:#,0}Byte", toplamBellek);

            Console.WriteLine ("\nÇevrimiçi uzak að baðlantýlý tüm iþlerin listesi:");
            try {tümÝþler = Process.GetProcesses ("RemoteMachineOnYourNerwork");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            foreach (Process iþ in tümÝþler) Console.WriteLine ("  -> {0} - {1}", iþ.ProcessName, iþ.PeakWorkingSet64);

            Console.WriteLine ("\nKapatýlýncaya deðin her 2sn'de rapor veren NotePad.exe:");
            iþlet1 = null;
            iþlet1 = Process.Start ("NotePad.exe");
            do {if (!iþlet1.HasExited) {
                    iþlet1.Refresh();
                    Console.WriteLine ("{0} -->", iþlet1.ToString());
                    Console.WriteLine ("    fiziki bellek kullanýmý: {0:#,0}Byte", iþlet1.WorkingSet64);
                    Console.WriteLine ("    temel öncelik: {0}", iþlet1.BasePriority);
                    Console.WriteLine ("    öncelik sýnýfý: {0}", iþlet1.PriorityClass);
                    Console.WriteLine ("    kullanýcý iþlemci zamaný: {0}",iþlet1.UserProcessorTime);
                    Console.WriteLine ("    imtiyazlý iþlemci zamaný: {0}",iþlet1.PrivilegedProcessorTime);
                    Console.WriteLine ("    toplam iþlemci zamaný: {0}",iþlet1.TotalProcessorTime);
                    Console.WriteLine ("    PagedSystemMemorySize64: {0:#,0}Byte",iþlet1.PagedSystemMemorySize64);
                    Console.WriteLine ("    PagedMemorySize64: {0:#,0}Byte",iþlet1.PagedMemorySize64);
                    Console.WriteLine ("    PeakPagedMemorySize64: {0:#,0}Byte",iþlet1.PeakPagedMemorySize64);
                    Console.WriteLine ("    PeakVirtualMemorySize64: {0:#,0}Byte",iþlet1.PeakVirtualMemorySize64);
                    Console.WriteLine ("    PeakWorkingSet64: {0:#,0}Byte",iþlet1.PeakWorkingSet64);
                    if (iþlet1.Responding) Console.WriteLine ("Statü = Çalýþmakta");
                    else Console.WriteLine ("Statü = Yanýt yok");
                }
            }
            while (!iþlet1.WaitForExit (2000)); //Her 2 sn'de rapor ver
            Console.WriteLine ("Ýþin çýkýþ kodu: {0}", iþlet1.ExitCode);

            Console.Write ("\nTuþ..."); Console.ReadKey(); Console.WriteLine();
        }
    } 
}