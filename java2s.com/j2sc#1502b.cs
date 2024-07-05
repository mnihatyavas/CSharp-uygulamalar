// j2sc#1502b.cs: Dizin, altdizin ve dosyalar yaratma, kopyalama ve silme örneði.

using System;
using System.IO;
namespace SürücüDizin {
    class DirB {
        private static void DiziniKeþfet (DirectoryInfo di) {
            Console.WriteLine ("[{0}] {1}", di.Name, di.LastAccessTime);
            DirectoryInfo[] altdizinler = di.GetDirectories();
            foreach (DirectoryInfo alt in altdizinler) DiziniKeþfet (alt);
        }
        private static void YedekleSil (DirectoryInfo di) {
            string yedekKlasör = "YedekKlasör";
            DirectoryInfo yeniDizin = di.CreateSubdirectory (yedekKlasör);
            FileInfo[] fi = di.GetFiles();
            Console.WriteLine ("\t==>Yedeklenen dosyalar...");
            foreach (FileInfo f in fi) {
                string tamAd = yeniDizin.FullName + "\\" + f.Name;
                f.CopyTo (tamAd);
                Console.WriteLine (f.FullName);
            }
            Console.Write ("\nTuþ/Sil veya ^C..."); Console.ReadKey();
            yeniDizin.Delete (true); 
        }
        static int dizinSayaç = 1;
        static int dosyaSayaç = 0;
        static void AltdizinDosyalarý (DirectoryInfo di) {
            FileInfo[] fiDizi = di.GetFiles();
            foreach (FileInfo f in fiDizi) {
                Console.WriteLine ("{0} [{1}] Ebat: {2} Byte", f.Name, f.LastWriteTime, f.Length);
                dosyaSayaç++;
            }
            DirectoryInfo[] dizinler = di.GetDirectories();
            foreach (DirectoryInfo dz in dizinler) {
                dizinSayaç++;
                AltdizinDosyalarý (dz);
            }
        }
        public static void DiziniÝncele (string dir) {
            string [] dosyalar = Directory.GetFiles (dir);
            foreach (string dosya in dosyalar) DosyayýÝncele (dosya);
            string [] altdizinler = Directory.GetDirectories (dir);
            foreach (string altdizin in altdizinler) DiziniÝncele (altdizin);
        }
        public static void DosyayýÝncele (string yol) {Console.WriteLine ("Dosya: '{0}'", yol);}
        static void Main() {
            Console.Write ("Özyineleme/recursive/kendiniçaðýrma'da bir dizin için çaðrýlan metot, kendini tüm altdizinleri için bitinceye deðin çaðýrýr (örn.yukardaki içiçe DiziniÝncele ve DosyayýÝncele çaðrýlarý).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili dizin, altdizin ve dosyalar:");
            FileInfo fi = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1502b.cs");
            DirectoryInfo di = fi.Directory;
            Console.WriteLine ("Aktüel dizin: " + di.Name);
            Console.WriteLine ("Ebeveyn dizin: " + di.Parent.Name);
            Console.WriteLine ("Verili diin mevcut mu?: " + di.Exists);
            if (di.Exists) {
                Console.WriteLine ("Dizinin yaratýlma tarihi: [{0}]", di.CreationTime);
                Console.WriteLine ("Dizinin son güncellenme tarihi: [{0}]",  di.LastWriteTime);
                Console.WriteLine ("Dizine son eriþim tarihi: [{0}]", di.LastAccessTime);
                Console.WriteLine ("Dizinin vasýflar listesi: " + di.Attributes);
                Console.WriteLine ("Dizindeki dosya sayýsý: " + di.GetFiles().Length);
            }
            Console.WriteLine ("\t==>AltKlasör1 ve AltKlasör2 mevcutlarsa siliniyor...");
            try {Directory.Delete (string.Format (@"{0}\AltKlasör1", Environment.CurrentDirectory));
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Directory.Delete (string.Format (@"{0}\AltKlasör2", Environment.CurrentDirectory));
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("\t==>Verili dizin ve altdizinleri inceleniyor...");
            DiziniKeþfet (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#"));
            Console.Write ("\nTuþ/^C..."); Console.ReadKey();
            DiziniKeþfet (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles"));
            Console.WriteLine ("\t==>AltKlasör1 ve AltKlasör2\\Nihat aktüel dizinde yaratýlýyor...");
            di = new DirectoryInfo (".");
            di.CreateSubdirectory ("AltKlasör1");
            di = di.CreateSubdirectory (@"AltKlasör2\Nihat");
            Console.WriteLine ("Yaratýlan son klasör: {0}", di);

            Console.WriteLine ("\nVerili dizin dosyalarýný önce yedekle sonra sil:");
            YedekleSil (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#"));
            YedekleSil (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham"));

            Console.WriteLine ("\nVerili dizindeki altdizin ve dosyalarýnýn listelenmesi:");
            String yol = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#";
            AltdizinDosyalarý (new DirectoryInfo (yol));
            Console.WriteLine ("Toplam dizin sayýsý: " + dizinSayaç);
            Console.WriteLine ("Toplam dosya sayýsý: " + dosyaSayaç);
            Console.WriteLine ("\t==>Dizin ve dosyalarýn özyinelemeli metotla incelenmesi:");
            Console.Write ("\nTuþ/^C..."); Console.ReadKey();
            if (File.Exists (yol)) DosyayýÝncele (yol); 
            else if (Directory.Exists (yol)) DiziniÝncele (yol);
            else Console.WriteLine ("'{0}' geçerli bir dosya yada dizin deðildir.", yol);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}