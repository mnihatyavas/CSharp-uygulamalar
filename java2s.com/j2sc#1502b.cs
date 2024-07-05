// j2sc#1502b.cs: Dizin, altdizin ve dosyalar yaratma, kopyalama ve silme �rne�i.

using System;
using System.IO;
namespace S�r�c�Dizin {
    class DirB {
        private static void DiziniKe�fet (DirectoryInfo di) {
            Console.WriteLine ("[{0}] {1}", di.Name, di.LastAccessTime);
            DirectoryInfo[] altdizinler = di.GetDirectories();
            foreach (DirectoryInfo alt in altdizinler) DiziniKe�fet (alt);
        }
        private static void YedekleSil (DirectoryInfo di) {
            string yedekKlas�r = "YedekKlas�r";
            DirectoryInfo yeniDizin = di.CreateSubdirectory (yedekKlas�r);
            FileInfo[] fi = di.GetFiles();
            Console.WriteLine ("\t==>Yedeklenen dosyalar...");
            foreach (FileInfo f in fi) {
                string tamAd = yeniDizin.FullName + "\\" + f.Name;
                f.CopyTo (tamAd);
                Console.WriteLine (f.FullName);
            }
            Console.Write ("\nTu�/Sil veya ^C..."); Console.ReadKey();
            yeniDizin.Delete (true); 
        }
        static int dizinSaya� = 1;
        static int dosyaSaya� = 0;
        static void AltdizinDosyalar� (DirectoryInfo di) {
            FileInfo[] fiDizi = di.GetFiles();
            foreach (FileInfo f in fiDizi) {
                Console.WriteLine ("{0} [{1}] Ebat: {2} Byte", f.Name, f.LastWriteTime, f.Length);
                dosyaSaya�++;
            }
            DirectoryInfo[] dizinler = di.GetDirectories();
            foreach (DirectoryInfo dz in dizinler) {
                dizinSaya�++;
                AltdizinDosyalar� (dz);
            }
        }
        public static void Dizini�ncele (string dir) {
            string [] dosyalar = Directory.GetFiles (dir);
            foreach (string dosya in dosyalar) Dosyay��ncele (dosya);
            string [] altdizinler = Directory.GetDirectories (dir);
            foreach (string altdizin in altdizinler) Dizini�ncele (altdizin);
        }
        public static void Dosyay��ncele (string yol) {Console.WriteLine ("Dosya: '{0}'", yol);}
        static void Main() {
            Console.Write ("�zyineleme/recursive/kendini�a��rma'da bir dizin i�in �a�r�lan metot, kendini t�m altdizinleri i�in bitinceye de�in �a��r�r (�rn.yukardaki i�i�e Dizini�ncele ve Dosyay��ncele �a�r�lar�).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili dizin, altdizin ve dosyalar:");
            FileInfo fi = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1502b.cs");
            DirectoryInfo di = fi.Directory;
            Console.WriteLine ("Akt�el dizin: " + di.Name);
            Console.WriteLine ("Ebeveyn dizin: " + di.Parent.Name);
            Console.WriteLine ("Verili diin mevcut mu?: " + di.Exists);
            if (di.Exists) {
                Console.WriteLine ("Dizinin yarat�lma tarihi: [{0}]", di.CreationTime);
                Console.WriteLine ("Dizinin son g�ncellenme tarihi: [{0}]",  di.LastWriteTime);
                Console.WriteLine ("Dizine son eri�im tarihi: [{0}]", di.LastAccessTime);
                Console.WriteLine ("Dizinin vas�flar listesi: " + di.Attributes);
                Console.WriteLine ("Dizindeki dosya say�s�: " + di.GetFiles().Length);
            }
            Console.WriteLine ("\t==>AltKlas�r1 ve AltKlas�r2 mevcutlarsa siliniyor...");
            try {Directory.Delete (string.Format (@"{0}\AltKlas�r1", Environment.CurrentDirectory));
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Directory.Delete (string.Format (@"{0}\AltKlas�r2", Environment.CurrentDirectory));
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("\t==>Verili dizin ve altdizinleri inceleniyor...");
            DiziniKe�fet (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#"));
            Console.Write ("\nTu�/^C..."); Console.ReadKey();
            DiziniKe�fet (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles"));
            Console.WriteLine ("\t==>AltKlas�r1 ve AltKlas�r2\\Nihat akt�el dizinde yarat�l�yor...");
            di = new DirectoryInfo (".");
            di.CreateSubdirectory ("AltKlas�r1");
            di = di.CreateSubdirectory (@"AltKlas�r2\Nihat");
            Console.WriteLine ("Yarat�lan son klas�r: {0}", di);

            Console.WriteLine ("\nVerili dizin dosyalar�n� �nce yedekle sonra sil:");
            YedekleSil (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#"));
            YedekleSil (new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham"));

            Console.WriteLine ("\nVerili dizindeki altdizin ve dosyalar�n�n listelenmesi:");
            String yol = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#";
            AltdizinDosyalar� (new DirectoryInfo (yol));
            Console.WriteLine ("Toplam dizin say�s�: " + dizinSaya�);
            Console.WriteLine ("Toplam dosya say�s�: " + dosyaSaya�);
            Console.WriteLine ("\t==>Dizin ve dosyalar�n �zyinelemeli metotla incelenmesi:");
            Console.Write ("\nTu�/^C..."); Console.ReadKey();
            if (File.Exists (yol)) Dosyay��ncele (yol); 
            else if (Directory.Exists (yol)) Dizini�ncele (yol);
            else Console.WriteLine ("'{0}' ge�erli bir dosya yada dizin de�ildir.", yol);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}