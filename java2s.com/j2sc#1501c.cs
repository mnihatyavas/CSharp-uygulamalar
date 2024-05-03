// j2sc#1501c.cs: Dosya vas�flar�, �zellikleri, eri�imleri ve de�i�iklik �rne�i.

using System;
using System.IO;
using System.Windows.Forms; //OpenFileDialog ve DialogResult i�in
using System.Security.AccessControl; //FileSecurity, FileSystemAccessRule, FileSystemRights, AccessControlType i�in
using System.Security.Principal; //WindowsIdentity i�in
namespace DosyaDizin {
    class DosyaC {
        public static void DosyaVas�flar� (FileAttributes dvsf) {
            if ((dvsf & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Archive: Ar�iv");
            if ((dvsf & FileAttributes.Compressed) == FileAttributes.Compressed) Console.WriteLine ("Compressed: S�k���k");
            if ((dvsf & FileAttributes.Device) == FileAttributes.Device) Console.WriteLine ("Device: Alet");
            if ((dvsf & FileAttributes.Directory) == FileAttributes.Directory) Console.WriteLine ("Directory: Dizin");
            if ((dvsf & FileAttributes.Encrypted) == FileAttributes.Encrypted) Console.WriteLine ("Encrypted: �ifreli");
            if ((dvsf & FileAttributes.Hidden) == FileAttributes.Hidden) Console.WriteLine ("Hidden: Gizli");
            if ((dvsf & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed) Console.WriteLine ("NotContentIndexed: ��erikEndeksliDe�il");
            if ((dvsf & FileAttributes.Offline)  == FileAttributes.Offline) Console.WriteLine ("Offline: �evrimd���");
            if ((dvsf & FileAttributes.ReadOnly)  == FileAttributes.ReadOnly) Console.WriteLine ("ReadOnly: SadeceOkunabilir");
            if ((dvsf & FileAttributes.ReparsePoint)  == FileAttributes.ReparsePoint) Console.WriteLine ("ReparsePoint: Ayr���mNoktas�");
            if ((dvsf & FileAttributes.SparseFile)  == FileAttributes.SparseFile) Console.WriteLine ("SparseFile: SeyrekDosya");
            if ((dvsf & FileAttributes.System)  == FileAttributes.System) Console.WriteLine ("System: Sistem");
            if ((dvsf & FileAttributes.Temporary)  == FileAttributes.Temporary) Console.WriteLine ("Temporary: Ge�ici");
        }
        [STAThread] //Main() �n�nde bu vas�f olmadan OpenFileDialog diyalog men�s� a��lmaz
        static void Main (string[] a) {
            Console.Write ("Dosya vas�flar�: Archive, Compressed, Device, Directory, Encrypted, Hidden, NotContentIndexed, Offline, ReadOnly, ReparsePoint, SparseFile, System, Temporary.\n�zellikleri: Name, Exist, CreationTime, LastWriteTime, LastAccessTime, Length, Attributes, Extension.\nj2sc#1501c.exe'nin eri�im izni DENY oldu�undan ko�turulamaz da.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili yada diyaloglu dosyaya ait vasf�n mevcudiyet kontrolu:");
            FileInfo dosya1 = new FileInfo ("j2sc#1501c.cs");
            Console.WriteLine ("'j2sc#1501c.cs' vas�flar�: {0}", dosya1.Attributes.ToString());
            if (dosya1.Attributes == FileAttributes.ReadOnly) Console.WriteLine ("Dosya vasf�, sadece-okunabilir'dir (yanl�� test).");
            if ((dosya1.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) Console.WriteLine ("Dosya vasf�, sadece-okunabilir'dir (do�ru test).");
            if ((dosya1.Attributes & FileAttributes.Archive) == FileAttributes.Archive) Console.WriteLine ("Dosya vasf�, ar�iv'dir (do�ru test).");
            OpenFileDialog dylgA� = new OpenFileDialog();
            if (dylgA�.ShowDialog() == DialogResult.OK) {
                FileAttributes dvsf = File.GetAttributes (dylgA�.FileName);
                Console.WriteLine ("\tSe�ilen '{0}' dosyan�n vasf�: [{1}]", dylgA�.FileName, dvsf);
                DosyaVas�flar� (dvsf);
            }
            if (a.Length > 0) {
                Console.WriteLine ("==>Komutsat�r�ndan verili dosya vasf� +r/-r k�l�nacak...");
                if (a [1] == "+r") File.SetAttributes (a [0], File.GetAttributes (a [0]) | FileAttributes.ReadOnly);
                else if (a [1] == "-r" ) File.SetAttributes (a [0], File.GetAttributes (a [0]) & (~FileAttributes.ReadOnly));
            }

            Console.WriteLine ("\nVerili 'j2sc#1501c.cs' dosyan�n �zellikleri:");
            Console.WriteLine ("Dosya ad�: " + dosya1.Name);
            Console.WriteLine ("Ad�ge�en dosya mevcut mu?  " + dosya1.Exists.ToString());
            if (dosya1.Exists) {
                Console.Write ("Yarat�lma tarihi: "); Console.WriteLine (dosya1.CreationTime.ToString());
                Console.Write ("Son g�ncellenme tarihi: "); Console.WriteLine (dosya1.LastWriteTime.ToString());
                Console.Write ("Son eri�im tarihi: "); Console.WriteLine (dosya1.LastAccessTime.ToString());
                Console.Write ("Ebat� (byte): "); Console.WriteLine (dosya1.Length.ToString());
                Console.Write ("Vas�flar�: "); Console.WriteLine (dosya1.Attributes.ToString());
            }

            Console.WriteLine ("\n'c:\\' k�k dizinindeki dosyalar�n birka� �zelli�i:");
            string[] dosyalar = Directory.GetFiles (@"c:\");
            foreach (string ad in dosyalar) {
                FileInfo dsy = new FileInfo (ad);
                Console.WriteLine ("{0} dosyas� {1} tarihinde {2} uzant�l� yarat�ld�.", dsy.Name, dsy.CreationTime, dsy.Extension);
            }

            Console.WriteLine ("\n'j2sc#1501c.cs'ye CreateFiles, Modify, Delete ve Allow/eri�im izinleri verme:");
            string dosyaAd� = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501c.cs";
            FileSecurity fs1 = new FileSecurity();
            fs1.AddAccessRule (new FileSystemAccessRule (WindowsIdentity.GetCurrent().Name, FileSystemRights.CreateFiles | FileSystemRights.Modify | FileSystemRights.Delete, AccessControlType.Allow));
            using (FileStream ak� = File.Open (dosyaAd�, FileMode.OpenOrCreate)) {}
            dosyaAd�="j2sc#1501c.exe"; FileStream ak�� = null;
            FileSecurity fs2 = File.GetAccessControl (dosyaAd�);
            fs2.AddAccessRule (new FileSystemAccessRule ("Everyone", FileSystemRights.Read, AccessControlType.Deny));
            File.SetAccessControl (dosyaAd�, fs2);
            try {ak�� = new FileStream (dosyaAd�, FileMode.Create);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);
            }finally {/*ak��.Close(); ak��.Dispose();*/} //Eri�im izni yok
            Console.WriteLine ("==>j2sc#1501c.exe'yi sil, yoksa eri�im izinsiz oldu�undan derleme yapamaz...");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}