// j2sc#1501c.cs: Dosya vasýflarý, özellikleri, eriþimleri ve deðiþiklik örneði.

using System;
using System.IO;
using System.Windows.Forms; //OpenFileDialog ve DialogResult için
using System.Security.AccessControl; //FileSecurity, FileSystemAccessRule, FileSystemRights, AccessControlType için
using System.Security.Principal; //WindowsIdentity için
namespace DosyaDizin {
    class DosyaC {
        public static void DosyaVasýflarý (FileAttributes dvsf) {
            if ((dvsf & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Archive: Arþiv");
            if ((dvsf & FileAttributes.Compressed) == FileAttributes.Compressed) Console.WriteLine ("Compressed: Sýkýþýk");
            if ((dvsf & FileAttributes.Device) == FileAttributes.Device) Console.WriteLine ("Device: Alet");
            if ((dvsf & FileAttributes.Directory) == FileAttributes.Directory) Console.WriteLine ("Directory: Dizin");
            if ((dvsf & FileAttributes.Encrypted) == FileAttributes.Encrypted) Console.WriteLine ("Encrypted: Þifreli");
            if ((dvsf & FileAttributes.Hidden) == FileAttributes.Hidden) Console.WriteLine ("Hidden: Gizli");
            if ((dvsf & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed) Console.WriteLine ("NotContentIndexed: ÝçerikEndeksliDeðil");
            if ((dvsf & FileAttributes.Offline)  == FileAttributes.Offline) Console.WriteLine ("Offline: Çevrimdýþý");
            if ((dvsf & FileAttributes.ReadOnly)  == FileAttributes.ReadOnly) Console.WriteLine ("ReadOnly: SadeceOkunabilir");
            if ((dvsf & FileAttributes.ReparsePoint)  == FileAttributes.ReparsePoint) Console.WriteLine ("ReparsePoint: AyrýþýmNoktasý");
            if ((dvsf & FileAttributes.SparseFile)  == FileAttributes.SparseFile) Console.WriteLine ("SparseFile: SeyrekDosya");
            if ((dvsf & FileAttributes.System)  == FileAttributes.System) Console.WriteLine ("System: Sistem");
            if ((dvsf & FileAttributes.Temporary)  == FileAttributes.Temporary) Console.WriteLine ("Temporary: Geçici");
        }
        [STAThread] //Main() önünde bu vasýf olmadan OpenFileDialog diyalog menüsü açýlmaz
        static void Main (string[] a) {
            Console.Write ("Dosya vasýflarý: Archive, Compressed, Device, Directory, Encrypted, Hidden, NotContentIndexed, Offline, ReadOnly, ReparsePoint, SparseFile, System, Temporary.\nÖzellikleri: Name, Exist, CreationTime, LastWriteTime, LastAccessTime, Length, Attributes, Extension.\nj2sc#1501c.exe'nin eriþim izni DENY olduðundan koþturulamaz da.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili yada diyaloglu dosyaya ait vasfýn mevcudiyet kontrolu:");
            FileInfo dosya1 = new FileInfo ("j2sc#1501c.cs");
            Console.WriteLine ("'j2sc#1501c.cs' vasýflarý: {0}", dosya1.Attributes.ToString());
            if (dosya1.Attributes == FileAttributes.ReadOnly) Console.WriteLine ("Dosya vasfý, sadece-okunabilir'dir (yanlýþ test).");
            if ((dosya1.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) Console.WriteLine ("Dosya vasfý, sadece-okunabilir'dir (doðru test).");
            if ((dosya1.Attributes & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Dosya vasfý, arþiv'dir (doðru test).");
            OpenFileDialog dylgAç = new OpenFileDialog();
            if (dylgAç.ShowDialog() == DialogResult.OK) {
                FileAttributes dvsf = File.GetAttributes (dylgAç.FileName);
                Console.WriteLine ("\tSeçilen '{0}' dosyanýn vasfý: [{1}]", dylgAç.FileName, dvsf);
                DosyaVasýflarý (dvsf);
            }
            if (a.Length > 0) {
                Console.WriteLine ("==>Komutsatýrýndan verili dosya vasfý +r/-r kýlýnacak...");
                if (a [1] == "+r") File.SetAttributes (a [0], File.GetAttributes (a [0]) | FileAttributes.ReadOnly);
                else if (a [1] == "-r" ) File.SetAttributes (a [0], File.GetAttributes (a [0]) & (~FileAttributes.ReadOnly));
            }

            Console.WriteLine ("\nVerili 'j2sc#1501c.cs' dosyanýn özellikleri:");
            Console.WriteLine ("Dosya adý: " + dosya1.Name);
            Console.WriteLine ("Adýgeçen dosya mevcut mu?  " + dosya1.Exists.ToString());
            if (dosya1.Exists) {
                Console.Write ("Yaratýlma tarihi: "); Console.WriteLine (dosya1.CreationTime.ToString());
                Console.Write ("Son güncellenme tarihi: "); Console.WriteLine (dosya1.LastWriteTime.ToString());
                Console.Write ("Son eriþim tarihi: "); Console.WriteLine (dosya1.LastAccessTime.ToString());
                Console.Write ("Ebatý (byte): "); Console.WriteLine (dosya1.Length.ToString());
                Console.Write ("Vasýflarý: "); Console.WriteLine (dosya1.Attributes.ToString());
            }

            Console.WriteLine ("\n'c:\\' kök dizinindeki dosyalarýn birkaç özelliði:");
            string[] dosyalar = Directory.GetFiles (@"c:\");
            foreach (string ad in dosyalar) {
                FileInfo dsy = new FileInfo (ad);
                Console.WriteLine ("{0} dosyasý {1} tarihinde {2} uzantýlý yaratýldý.", dsy.Name, dsy.CreationTime, dsy.Extension);
            }

            Console.WriteLine ("\n'j2sc#1501c.cs'ye CreateFiles, Modify, Delete ve Allow/eriþim izinleri verme:");
            string dosyaAdý = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501c.cs";
            FileSecurity fs1 = new FileSecurity();
            fs1.AddAccessRule (new FileSystemAccessRule (WindowsIdentity.GetCurrent().Name, FileSystemRights.CreateFiles | FileSystemRights.Modify | FileSystemRights.Delete, AccessControlType.Allow));
            using (FileStream akþ = File.Open (dosyaAdý, FileMode.OpenOrCreate)) {}
            dosyaAdý="j2sc#1501c.exe"; FileStream akýþ = null;
            FileSecurity fs2 = File.GetAccessControl (dosyaAdý);
            fs2.AddAccessRule (new FileSystemAccessRule ("Everyone", FileSystemRights.Read, AccessControlType.Deny));
            File.SetAccessControl (dosyaAdý, fs2);
            try {akýþ = new FileStream (dosyaAdý, FileMode.Create);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);
            }finally {/*akýþ.Close(); akýþ.Dispose();*/} //Eriþim izni yok
            Console.WriteLine ("==>j2sc#1501c.exe'yi sil, yoksa eriþim izinsiz olduðundan derleme yapamaz...");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}