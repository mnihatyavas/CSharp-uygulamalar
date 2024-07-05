// j2sc#1502a.cs: DriveInfo s�r�c� ve DirectoryInfo dizin �rne�i.

using System;
using System.IO;
namespace S�r�c�Dizin {
    class DirA {
        public static void Vas�flar�Sapta (FileAttributes vsf) {
            if ((vsf & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Archive: Ar�iv");
            if ((vsf & FileAttributes.Compressed) == FileAttributes.Compressed) Console.WriteLine ("Compressed: S�k���k");
            if ((vsf & FileAttributes.Device) == FileAttributes.Device) Console.WriteLine ("Device: Ayg�t");
            if ((vsf & FileAttributes.Directory) == FileAttributes.Directory) Console.WriteLine ("Directory: Dizin");
            if ((vsf & FileAttributes.Encrypted) == FileAttributes.Encrypted) Console.WriteLine ("Encrypted: �ifreli");
            if ((vsf & FileAttributes.Hidden) == FileAttributes.Hidden) Console.WriteLine ("Hidden: Gizli");
            if ((vsf & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed) Console.WriteLine ("NotContentIndexed: ��erikEndeksliDe�il");
            if ((vsf & FileAttributes.Offline) == FileAttributes.Offline) Console.WriteLine ("Offline: �evrimd���");
            if ((vsf & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) Console.WriteLine ("ReadOnly: SadeceOkunabilir");
            if ((vsf & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) Console.WriteLine ("ReparsePoint: YenidenAyr���mNoktas�");
            if ((vsf & FileAttributes.SparseFile) == FileAttributes.SparseFile) Console.WriteLine ("SparseFile: Ayr��anDosya");
            if ((vsf & FileAttributes.System) == FileAttributes.System) Console.WriteLine ("System: Sistem");
            if ((vsf & FileAttributes.Temporary) == FileAttributes.Temporary) Console.WriteLine ("Temporary: Ge�ici");
        }
        public static void AltdizinleriG�ster (DirectoryInfo di, int kertik) {
            string i�erle = new String (' ', 2*kertik);
            Console.WriteLine (i�erle + di.Name); int i=0;
            foreach (DirectoryInfo alt in di.GetDirectories()) {if(++i>10) {Console.Write ("\nTu�..."); Console.ReadKey(); i=0;} AltdizinleriG�ster (alt, kertik+1);} //T�m altklas�rleri 2'�er i�erleyip �zyinelemeli �a��r�rarak listeler
        }
        static void Main() {
            Console.Write ("foreach(DriveInfo s�r�c� in DriveInfo.GetDrives()){} bilgisayar�n�zdaki mevcut s�r�c�leri listeler.\nforeach (DirectoryInfo di in DirectoryInfo.GetDirectories()){} akt�el dizindeki t�m altdizinleri listeler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Haz�r s�r�c�ler ve ona dair detay bilgiler:");
            int i;
            foreach (DriveInfo s�r�c� in DriveInfo.GetDrives()) {
                try {Console.WriteLine ("Bo� disk: {0} ==>{1} KB", s�r�c�.RootDirectory, s�r�c�.AvailableFreeSpace / 1024);
                }catch (Exception ht) {Console.Write ("HATA: {0} ==>{1}", s�r�c�, ht.Message);}
            }
            Console.WriteLine ("\t==>Mevcut s�r�c�leriniz:");
            string[] s�r�c�ler = Directory.GetLogicalDrives();
            for(i=0;i<s�r�c�ler.Length; i++) Console.WriteLine ("{0}) {1}", i, s�r�c�ler [i]);
            Console.WriteLine ("\t==>Dosyadan s�r�c�ye eri�im:");
            FileInfo fi = new FileInfo ("j2sc#1502a.cs");
            DriveInfo src = new DriveInfo (fi.FullName);
            Console.WriteLine ("S�r�c�: {0}", src.Name);
            if(src.IsReady) {
                Console.WriteLine ("S�r�c� tipi: {0}", src.DriveType.ToString());
                Console.WriteLine ("S�r�c� bi�emi: {0}", src.DriveFormat.ToString());
                Console.WriteLine ("S�r�c�deki bo� alan: {0} B", src.AvailableFreeSpace.ToString());
            }
            Console.WriteLine ("\t==>Mevcut s�r�c�lerinizin detay bilgileri:");
            DriveInfo[] s�r�c�lerim = DriveInfo.GetDrives();
            foreach (DriveInfo di in s�r�c�lerim) {
                Console.WriteLine ("-->S�r�c� ad�: {0}", di.Name);
                Console.WriteLine ("S�r�c� tipi: {0}", di.DriveType);
                if (di.IsReady) {
                    Console.WriteLine ("Bo� alan: {0} B", di.TotalFreeSpace);
                    Console.WriteLine ("Bi�em: {0}", di.DriveFormat);
                    Console.WriteLine ("Etiket: {0}", di.VolumeLabel);
                }
            }

            Console.WriteLine ("\nHaz�r s�r�c�lerin k�kdizin dosya listesi:");
            string[] dosyalar = Directory.GetFiles ("c:\\");
            foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            try {dosyalar = Directory.GetFiles ("D:\\");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            }catch (Exception ht) {Console.Write ("HATA: {0}-->{1}", "D:\\", ht.Message);}
            Console.WriteLine ("\t==>Verili altdizindeki dosya bilgileri:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\5.Ar�iv\Resimler\manzara");
            FileInfo[] dsy = dir.GetFiles ("*.jpg");
            foreach (FileInfo bilgi in dsy) {
                Console.Write ("Dosya ad�: " + bilgi.Name + "  ");
                Console.WriteLine ("Ebat�: {0:#,0} KB", bilgi.Length/1024);
            }
            Console.WriteLine ("\t==>Directory egzersizleri:");
            Console.WriteLine ("c:\\ dizini mevcut mu? {0}", Directory.Exists ("c:\\"));
            Console.WriteLine ("C:\\Users\\nihet\\Desktop\\MyFiles\\5.Ar�iv\\Resimler\\manzara dizini mevcut mu? {0}", Directory.Exists (@"C:\Users\nihet\Desktop\MyFiles\5.Ar�iv\Resimler\manzara"));
            Console.WriteLine ("D:\\ dizini mevcut mu? {0}", Directory.Exists ("D:\\"));
            Console.WriteLine ("Kullan�lan akt�el dizin: " + Directory.GetCurrentDirectory());
            Console.WriteLine ("j2sc#1502a.cs'nin tam yolu: " + Path.GetFullPath ("j2sc#1502a.cs"));
            Console.WriteLine ("'C:\\' dizini ayarla..."); Directory.SetCurrentDirectory (@"C:\");
            try {Console.WriteLine ("'nihat1.txt' dosyas� siliniyor..."); Directory.Delete (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("'nihat2.txt' dosyas� siliniyor..."); Directory.Delete ("nihat2.txt", true);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\n'c:\\' k�kdizinin akt�el vas�flar�n�n saptanmas�:");
            dir = new DirectoryInfo ("c:\\");
            FileAttributes fa = dir.Attributes;
            Vas�flar�Sapta (fa);
            Console.WriteLine ("\t==>DirectoryInfo egzersizleri:");
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("Mevcut dizinde (namevcutsa) 'Altklas�r' yarat�l�yor..."); dir.CreateSubdirectory ("Altklas�r");
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

            Console.WriteLine ("\n'C:\\Users\\nihet\\Desktop\\MyFiles' t�m altdizinler 2'�er i�erden listelenir:");
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles");
            try {AltdizinleriG�ster (dir, 0);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}