// j2sc#1405b.cs: Process.Start ile s�re� ko�turma ve sicim takibi �rne�i.

using System;
using System.Diagnostics; //ProcessStartInfo ve Process.Start i�in
namespace Geli�imler {
    class ��letB {
        static void Main() {
            Console.Write ("Process.Start(i�,arg�man) ile her t�rl� i�letilebilir (�evrim-i�i/d���) programlar ve sicimleri takip edilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IExplore.exe �al��t�r�l�p �evrimi�iyse java2s.com �a�r�lacak:");
            Console.Write ("--> IE'yi �al��t�rmak i�in [Tu�]..."); Console.ReadKey();
            Process i�let1 = Process.Start ("IExplore.exe", "www.java2s.com"); Console.WriteLine();
            Console.Write ("--> {0}'yi �ld�rmek i�in [Tu�]...", i�let1.ProcessName); Console.ReadKey();
            try {i�let1.Kill();}catch{} // �nceden �ld�r�ld�yse hata vermesin

            Console.WriteLine ("\nAkt�el s�re�, sicimleri ve detay bilgileri:");
            i�let1 = Process.GetCurrentProcess();
            ProcessThreadCollection ipler1 = i�let1.Threads;
            foreach (ProcessThread ip in ipler1) {
                Console.WriteLine ("Sicim: {0}", ip.Id);
                Console.WriteLine ("    ba�lama: {0}", ip.StartTime);
                Console.WriteLine ("    CPU vakti: {0}", ip.TotalProcessorTime);
                Console.WriteLine ("    �ncelik: {0}", ip.BasePriority);
                Console.WriteLine ("    sicim durumu: {0}", ip.ThreadState); 
            }
            Console.WriteLine ("S�re� ad�: "+ i�let1.ProcessName);
            Console.WriteLine ("Process: {0}, ID: {1}", i�let1.StartTime, i�let1.Id);
            Console.WriteLine ("    toplam CPU vakti: {0}", i�let1.TotalProcessorTime);
            Console.WriteLine ("    �ncelik s�n�f�: {0}  �nceli�i: {1}", i�let1.PriorityClass, i�let1.BasePriority);
            Console.WriteLine ("    sanal bellek: {0}", i�let1.VirtualMemorySize64);
            Console.WriteLine ("    �zel bellek: {0}", i�let1.PrivateMemorySize64);
            Console.WriteLine ("    fiziki bellek: {0}", i�let1.WorkingSet64);
            i�let1.PriorityClass = ProcessPriorityClass.High;
            Console.WriteLine ("    yeni �ncelik s�n�f�: {0}", i�let1.PriorityClass);
            Console.Write ("\nTu�..."); Console.ReadKey(); Console.WriteLine();

            Console.WriteLine ("\nSistemdeki t�m i�ler ve sicimlerinin detayl� listelenmesi:");
            Process[] t�m��ler = Process.GetProcesses();
            long toplamBellek = 0;
            foreach (Process i� in t�m��ler) {
                toplamBellek +=i�.WorkingSet64;
                ProcessThreadCollection ipler2 = i�.Threads;
                Console.WriteLine ("��: {0},  no: {1}", i�.ProcessName, i�.Id);
                foreach (ProcessThread ip in ipler2) {
                    try {Console.WriteLine ("  sicim: {0}", ip.Id);
                        Console.WriteLine ("    ba�lama: {0}", ip.StartTime.ToString());
                        Console.WriteLine ("    CPU vakti: {0}", ip.TotalProcessorTime);
                        Console.WriteLine ("    �nceli�i: {0}", ip.BasePriority);
                        Console.WriteLine ("    sicim durumu: {0}", ip.ThreadState.ToString()); 
                    }catch (Exception ht) {Console.WriteLine ("    HATA: [{0}]", ht.Message);}
                }
            }
            Console.WriteLine ("T�m i�ler i�in kullan�lan toplam fiziki bellek: {0:#,0}Byte", toplamBellek);

            Console.WriteLine ("\n�evrimi�i uzak a� ba�lant�l� t�m i�lerin listesi:");
            try {t�m��ler = Process.GetProcesses ("RemoteMachineOnYourNerwork");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            foreach (Process i� in t�m��ler) Console.WriteLine ("  -> {0} - {1}", i�.ProcessName, i�.PeakWorkingSet64);

            Console.WriteLine ("\nKapat�l�ncaya de�in her 2sn'de rapor veren NotePad.exe:");
            i�let1 = null;
            i�let1 = Process.Start ("NotePad.exe");
            do {if (!i�let1.HasExited) {
                    i�let1.Refresh();
                    Console.WriteLine ("{0} -->", i�let1.ToString());
                    Console.WriteLine ("    fiziki bellek kullan�m�: {0:#,0}Byte", i�let1.WorkingSet64);
                    Console.WriteLine ("    temel �ncelik: {0}", i�let1.BasePriority);
                    Console.WriteLine ("    �ncelik s�n�f�: {0}", i�let1.PriorityClass);
                    Console.WriteLine ("    kullan�c� i�lemci zaman�: {0}",i�let1.UserProcessorTime);
                    Console.WriteLine ("    imtiyazl� i�lemci zaman�: {0}",i�let1.PrivilegedProcessorTime);
                    Console.WriteLine ("    toplam i�lemci zaman�: {0}",i�let1.TotalProcessorTime);
                    Console.WriteLine ("    PagedSystemMemorySize64: {0:#,0}Byte",i�let1.PagedSystemMemorySize64);
                    Console.WriteLine ("    PagedMemorySize64: {0:#,0}Byte",i�let1.PagedMemorySize64);
                    Console.WriteLine ("    PeakPagedMemorySize64: {0:#,0}Byte",i�let1.PeakPagedMemorySize64);
                    Console.WriteLine ("    PeakVirtualMemorySize64: {0:#,0}Byte",i�let1.PeakVirtualMemorySize64);
                    Console.WriteLine ("    PeakWorkingSet64: {0:#,0}Byte",i�let1.PeakWorkingSet64);
                    if (i�let1.Responding) Console.WriteLine ("Stat� = �al��makta");
                    else Console.WriteLine ("Stat� = Yan�t yok");
                }
            }
            while (!i�let1.WaitForExit (2000)); //Her 2 sn'de rapor ver
            Console.WriteLine ("��in ��k�� kodu: {0}", i�let1.ExitCode);

            Console.Write ("\nTu�..."); Console.ReadKey(); Console.WriteLine();
        }
    } 
}