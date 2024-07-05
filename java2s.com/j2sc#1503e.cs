// j2sc#1503e.cs: FileVersionInfo, IsolatedStorageFile, GZipStream ve CSV dosya �rne�i.

using System;
using System.Diagnostics; //FileVersionInfo i�in
using System.IO;
using System.IO.IsolatedStorage; //IsolatedStorageFile ve IsolatedStorageFileStream i�in
using System.Collections; //IEnumerator i�in
using System.Security.Policy; //Url i�in
using System.IO.Compression; //GZipStream ve CompressionMode i�in
namespace DosyaDizin {
    class �kamet {
        public String ki�i, �ehir, �lke, y�l;
        public �kamet(){} //Kurucu
        public override String ToString() {return ki�i+": "+�ehir+" - "+�lke+", "+y�l;}
    }
    class �e�itliE {
        static void S�k��t�rYaz (string dosya) {
            FileStream fs = new FileStream (dosya, FileMode.Create, FileAccess.Write);
            GZipStream s�k���kAk�� = new GZipStream (fs, CompressionMode.Compress); //S�k��t�r yaz
            StreamWriter sw = new StreamWriter (s�k���kAk��);
            for(int i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atat�rk: {0}", i);
            sw.Close();
        }
        static string Normalle�tirOku (string dosya) {
            FileStream fs = new FileStream (dosya, FileMode.Open, FileAccess.Read);
            GZipStream s�k���kAk�� = new GZipStream (fs, CompressionMode.Decompress); //Normalle�tir oku
            StreamReader sr = new StreamReader (s�k���kAk��);
            string t�mVeri = sr.ReadToEnd();
            sr.Close();
            return t�mVeri;
        }
        static void Main() {
            Console.Write ("FileVersionInfo dosyaya ait s�r�m ve �retici bilgilerini sunar.\nIsolatedStorageFile 'C:\\Users\\nihet\\AppData\\Local\\' dizinde IsolatedStorage klas�r� yaratarak izole dosyalar� burada muhafaza eder.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili dosyan�n s�r�m bilgi teferruatlar�:");
            FileVersionInfo s�r�m = FileVersionInfo.GetVersionInfo (@"C:\Program Files\CCleaner\CCleaner.exe");
            Console.WriteLine ("==>Dosya ad�: " + s�r�m.FileName);
            Console.WriteLine ("�r�n ad�: " + s�r�m.ProductName);
            Console.WriteLine ("�r�m s�r�m�: " + s�r�m.ProductVersion);
            Console.WriteLine ("�irket ad�: " + s�r�m.CompanyName);
            Console.WriteLine ("Dosya s�r�m�: " + s�r�m.FileVersion);
            Console.WriteLine ("Dosya tasviri: " + s�r�m.FileDescription);
            Console.WriteLine ("Orijinal dosya ad�: " + s�r�m.OriginalFilename);
            Console.WriteLine ("Yasal kopya hakk�: " + s�r�m.LegalCopyright);
            Console.WriteLine ("��sel ad�: " + s�r�m.InternalName);
            Console.WriteLine ("Hatas� d�zeltilebilir mi? " + s�r�m.IsDebug);
            Console.WriteLine ("Yamal� m�? " + s�r�m.IsPatched);
            Console.WriteLine ("�n s�r�m m�? " + s�r�m.IsPreRelease);
            Console.WriteLine ("Hususi yap�m m�? " + s�r�m.IsPrivateBuild);
            Console.WriteLine ("�zel yap�m m�? " + s�r�m.IsSpecialBuild);

            Console.WriteLine ("\nG�r�nmez izole depo ve i�erdikleri dosyalara yazma/okuma:");
            int i; string sat�r; string[] dosyalar;
            IsolatedStorageFile izoleDepo; StreamWriter sw; StreamReader sr;
            using (izoleDepo = IsolatedStorageFile.GetUserStoreForAssembly()) {
                izoleDepo.CreateDirectory ("�zoleDepo");
                Console.WriteLine ("Akt�el ebat: {0} Byte,\tKapsam: {1}", izoleDepo.UsedSize, izoleDepo.Scope);
                using (Stream s = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Create, izoleDepo)) {
                    sw = new StreamWriter (s);
                    for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atat�rk: {0}", i);
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Append, izoleDepo)) {
                    using (sw = new StreamWriter (isfs)) {
                        for(i=1938;i>=1881;i-=14) sw.WriteLine ("M.Kemal Atat�rk: {0}", i);
                        sw.Flush(); sw.Close();
                    }
                }
                Console.WriteLine ("==>nihat1.txt'e 10 kay�t yaz�ld�");
                using (Stream s = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Open, izoleDepo)) {
                    sr = new StreamReader (s);
                    while((sat�r=sr.ReadLine()) != null) Console.WriteLine (sat�r);
                    sr.Close();
                }
                Console.WriteLine ("==>�zoleDepo klas�r�ndeki dosyalar:");
                dosyalar = izoleDepo.GetFileNames ("*.*");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Open, FileAccess.Read, izoleDepo)) {
                    using (sr = new StreamReader (isfs)) {
                        sat�r = sr.ReadToEnd();
                        Console.WriteLine ("==>ReadToEnd'le okunan t�m kay�tlar:\n{0}", sat�r);
                        sr.Close();
                    }
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat2.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("M.Nihat Yava�");
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat3.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("Canan Candan");
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat4.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("S�heyla Yava� �zbay");
                    sw.Flush(); sw.Close();
                }
            } izoleDepo.Close();
            IEnumerator ie = IsolatedStorageFile.GetEnumerator (IsolatedStorageScope.User);
            Console.WriteLine ("==>T�m �zoleDepolar ve i�erdikleri dosyalar:");
            while (ie.MoveNext()) {
                IsolatedStorageFile isf = (IsolatedStorageFile) ie.Current;
                Url yurel = (Url) isf.AssemblyIdentity;
                Console.WriteLine ("Ko�turulan program: " + yurel.Value);
                dosyalar = isf.GetFileNames ("*");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            }

            Console.WriteLine ("\nGZipStream'le dosyaya s�k���k yazma ve normal okuma:");
            string dosyam = "mahmut1.txt";
            S�k��t�rYaz (dosyam);
            sat�r = Normalle�tirOku (dosyam);
            Console.WriteLine (sat�r);

            Console.WriteLine ("Herbir kay�t alanlar� virg�lle ayr�lan CSV dosyaya yazma/okuma:");
            dosyam = "mahmut1.csv";
            sw = new StreamWriter (dosyam); //CAV kay�tlar� elle de yaz�labilir
            for(i=1881;i<=1890;i++) sw.WriteLine ("Mustafa Kemal,Selanik,Yunanistan,"+i);
            sw.Close();
            Console.WriteLine ("==>mahmut1.csv'ye 10 kay�t yaz�ld�");
            sr = new StreamReader (dosyam);
            while ((sat�r = sr.ReadLine())!=null) {
                String[] alanlar = sat�r.Split (',');
                �kamet ikm = new �kamet();
                ikm.ki�i = alanlar [0];
                ikm.�ehir = alanlar [1];
                ikm.�lke = alanlar [2];
                ikm.y�l = alanlar [3];        
                Console.WriteLine (ikm);
            }
            sr.Close();
  
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}