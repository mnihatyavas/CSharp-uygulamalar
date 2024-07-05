// j2sc#1502a.cs: DriveInfo sürücü ve DirectoryInfo dizin örneði.

using System;
using System.IO;
namespace SürücüDizin {
    class DirA {
        public static void VasýflarýSapta (FileAttributes vsf) {
            if ((vsf & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Archive: Arþiv");
            if ((vsf & FileAttributes.Compressed) == FileAttributes.Compressed) Console.WriteLine ("Compressed: Sýkýþýk");
            if ((vsf & FileAttributes.Device) == FileAttributes.Device) Console.WriteLine ("Device: Aygýt");
            if ((vsf & FileAttributes.Directory) == FileAttributes.Directory) Console.WriteLine ("Directory: Dizin");
            if ((vsf & FileAttributes.Encrypted) == FileAttributes.Encrypted) Console.WriteLine ("Encrypted: Þifreli");
            if ((vsf & FileAttributes.Hidden) == FileAttributes.Hidden) Console.WriteLine ("Hidden: Gizli");
            if ((vsf & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed) Console.WriteLine ("NotContentIndexed: ÝçerikEndeksliDeðil");
            if ((vsf & FileAttributes.Offline) == FileAttributes.Offline) Console.WriteLine ("Offline: Çevrimdýþý");
            if ((vsf & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) Console.WriteLine ("ReadOnly: SadeceOkunabilir");
            if ((vsf & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) Console.WriteLine ("ReparsePoint: YenidenAyrýþýmNoktasý");
            if ((vsf & FileAttributes.SparseFile) == FileAttributes.SparseFile) Console.WriteLine ("SparseFile: AyrýþanDosya");
            if ((vsf & FileAttributes.System) == FileAttributes.System) Console.WriteLine ("System: Sistem");
            if ((vsf & FileAttributes.Temporary) == FileAttributes.Temporary) Console.WriteLine ("Temporary: Geçici");
        }
        public static void AltdizinleriGöster (DirectoryInfo di, int kertik) {
            string içerle = new String (' ', 2*kertik);
            Console.WriteLine (içerle + di.Name); int i=0;
            foreach (DirectoryInfo alt in di.GetDirectories()) {if(++i>10) {Console.Write ("\nTuþ..."); Console.ReadKey(); i=0;} AltdizinleriGöster (alt, kertik+1);} //Tüm altklasörleri 2'þer içerleyip özyinelemeli çaðýrýrarak listeler
        }
        static void Main() {
            Console.Write ("foreach(DriveInfo sürücü in DriveInfo.GetDrives()){} bilgisayarýnýzdaki mevcut sürücüleri listeler.\nforeach (DirectoryInfo di in DirectoryInfo.GetDirectories()){} aktüel dizindeki tüm altdizinleri listeler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hazýr sürücüler ve ona dair detay bilgiler:");
            int i;
            foreach (DriveInfo sürücü in DriveInfo.GetDrives()) {
                try {Console.WriteLine ("Boþ disk: {0} ==>{1} KB", sürücü.RootDirectory, sürücü.AvailableFreeSpace / 1024);
                }catch (Exception ht) {Console.Write ("HATA: {0} ==>{1}", sürücü, ht.Message);}
            }
            Console.WriteLine ("\t==>Mevcut sürücüleriniz:");
            string[] sürücüler = Directory.GetLogicalDrives();
            for(i=0;i<sürücüler.Length; i++) Console.WriteLine ("{0}) {1}", i, sürücüler [i]);
            Console.WriteLine ("\t==>Dosyadan sürücüye eriþim:");
            FileInfo fi = new FileInfo ("j2sc#1502a.cs");
            DriveInfo src = new DriveInfo (fi.FullName);
            Console.WriteLine ("Sürücü: {0}", src.Name);
            if(src.IsReady) {
                Console.WriteLine ("Sürücü tipi: {0}", src.DriveType.ToString());
                Console.WriteLine ("Sürücü biçemi: {0}", src.DriveFormat.ToString());
                Console.WriteLine ("Sürücüdeki boþ alan: {0} B", src.AvailableFreeSpace.ToString());
            }
            Console.WriteLine ("\t==>Mevcut sürücülerinizin detay bilgileri:");
            DriveInfo[] sürücülerim = DriveInfo.GetDrives();
            foreach (DriveInfo di in sürücülerim) {
                Console.WriteLine ("-->Sürücü adý: {0}", di.Name);
                Console.WriteLine ("Sürücü tipi: {0}", di.DriveType);
                if (di.IsReady) {
                    Console.WriteLine ("Boþ alan: {0} B", di.TotalFreeSpace);
                    Console.WriteLine ("Biçem: {0}", di.DriveFormat);
                    Console.WriteLine ("Etiket: {0}", di.VolumeLabel);
                }
            }

            Console.WriteLine ("\nHazýr sürücülerin kökdizin dosya listesi:");
            string[] dosyalar = Directory.GetFiles ("c:\\");
            foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            try {dosyalar = Directory.GetFiles ("D:\\");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            }catch (Exception ht) {Console.Write ("HATA: {0}-->{1}", "D:\\", ht.Message);}
            Console.WriteLine ("\t==>Verili altdizindeki dosya bilgileri:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\5.Arþiv\Resimler\manzara");
            FileInfo[] dsy = dir.GetFiles ("*.jpg");
            foreach (FileInfo bilgi in dsy) {
                Console.Write ("Dosya adý: " + bilgi.Name + "  ");
                Console.WriteLine ("Ebatý: {0:#,0} KB", bilgi.Length/1024);
            }
            Console.WriteLine ("\t==>Directory egzersizleri:");
            Console.WriteLine ("c:\\ dizini mevcut mu? {0}", Directory.Exists ("c:\\"));
            Console.WriteLine ("C:\\Users\\nihet\\Desktop\\MyFiles\\5.Arþiv\\Resimler\\manzara dizini mevcut mu? {0}", Directory.Exists (@"C:\Users\nihet\Desktop\MyFiles\5.Arþiv\Resimler\manzara"));
            Console.WriteLine ("D:\\ dizini mevcut mu? {0}", Directory.Exists ("D:\\"));
            Console.WriteLine ("Kullanýlan aktüel dizin: " + Directory.GetCurrentDirectory());
            Console.WriteLine ("j2sc#1502a.cs'nin tam yolu: " + Path.GetFullPath ("j2sc#1502a.cs"));
            Console.WriteLine ("'C:\\' dizini ayarla..."); Directory.SetCurrentDirectory (@"C:\");
            try {Console.WriteLine ("'nihat1.txt' dosyasý siliniyor..."); Directory.Delete (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("'nihat2.txt' dosyasý siliniyor..."); Directory.Delete ("nihat2.txt", true);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\n'c:\\' kökdizinin aktüel vasýflarýnýn saptanmasý:");
            dir = new DirectoryInfo ("c:\\");
            FileAttributes fa = dir.Attributes;
            VasýflarýSapta (fa);
            Console.WriteLine ("\t==>DirectoryInfo egzersizleri:");
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("Mevcut dizinde (namevcutsa) 'Altklasör' yaratýlýyor..."); dir.CreateSubdirectory ("Altklasör");
            DirectoryInfo[] dizinler = dir.GetDirectories();
            Console.WriteLine ("Mevcut dizindeki aldizinler listeleniyor...");
            foreach (DirectoryInfo di in dizinler) Console.WriteLine (di.Name);
            dsy = dir.GetFiles();
            Console.WriteLine ("Mevcut dizindeki dosyalar listeleniyor...");
            foreach (FileInfo d in dsy) Console.WriteLine (d.Name);
            dir = new DirectoryInfo (@"C:\Program Files\");
            dizinler = dir.GetDirectories ("*", SearchOption.TopDirectoryOnly);
            Console.WriteLine ("'{0}' dizindeki altdizinler:", dir.FullName);
            foreach (DirectoryInfo di in dizinler) Console.WriteLine ("\t{0}", di.Name);
            Console.WriteLine ("'{0}' dizindeki dosyalar:", dir.FullName);
            dsy = dir.GetFiles();
            foreach (FileInfo d in dsy) Console.WriteLine ("    {0} ({1} bytes)", d.Name, d.Length);

            Console.WriteLine ("\n'C:\\Users\\nihet\\Desktop\\MyFiles' tüm altdizinler 2'þer içerden listelenir:");
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles");
            try {AltdizinleriGöster (dir, 0);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}