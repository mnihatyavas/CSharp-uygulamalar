// j2sc#1503e.cs: FileVersionInfo, IsolatedStorageFile, GZipStream ve CSV dosya örneði.

using System;
using System.Diagnostics; //FileVersionInfo için
using System.IO;
using System.IO.IsolatedStorage; //IsolatedStorageFile ve IsolatedStorageFileStream için
using System.Collections; //IEnumerator için
using System.Security.Policy; //Url için
using System.IO.Compression; //GZipStream ve CompressionMode için
namespace DosyaDizin {
    class Ýkamet {
        public String kiþi, þehir, ülke, yýl;
        public Ýkamet(){} //Kurucu
        public override String ToString() {return kiþi+": "+þehir+" - "+ülke+", "+yýl;}
    }
    class ÇeþitliE {
        static void SýkýþtýrYaz (string dosya) {
            FileStream fs = new FileStream (dosya, FileMode.Create, FileAccess.Write);
            GZipStream sýkýþýkAkýþ = new GZipStream (fs, CompressionMode.Compress); //Sýkýþtýr yaz
            StreamWriter sw = new StreamWriter (sýkýþýkAkýþ);
            for(int i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atatürk: {0}", i);
            sw.Close();
        }
        static string NormalleþtirOku (string dosya) {
            FileStream fs = new FileStream (dosya, FileMode.Open, FileAccess.Read);
            GZipStream sýkýþýkAkýþ = new GZipStream (fs, CompressionMode.Decompress); //Normalleþtir oku
            StreamReader sr = new StreamReader (sýkýþýkAkýþ);
            string tümVeri = sr.ReadToEnd();
            sr.Close();
            return tümVeri;
        }
        static void Main() {
            Console.Write ("FileVersionInfo dosyaya ait sürüm ve üretici bilgilerini sunar.\nIsolatedStorageFile 'C:\\Users\\nihet\\AppData\\Local\\' dizinde IsolatedStorage klasörü yaratarak izole dosyalarý burada muhafaza eder.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili dosyanýn sürüm bilgi teferruatlarý:");
            FileVersionInfo sürüm = FileVersionInfo.GetVersionInfo (@"C:\Program Files\CCleaner\CCleaner.exe");
            Console.WriteLine ("==>Dosya adý: " + sürüm.FileName);
            Console.WriteLine ("Ürün adý: " + sürüm.ProductName);
            Console.WriteLine ("Ürüm sürümü: " + sürüm.ProductVersion);
            Console.WriteLine ("Þirket adý: " + sürüm.CompanyName);
            Console.WriteLine ("Dosya sürümü: " + sürüm.FileVersion);
            Console.WriteLine ("Dosya tasviri: " + sürüm.FileDescription);
            Console.WriteLine ("Orijinal dosya adý: " + sürüm.OriginalFilename);
            Console.WriteLine ("Yasal kopya hakký: " + sürüm.LegalCopyright);
            Console.WriteLine ("Ýçsel adý: " + sürüm.InternalName);
            Console.WriteLine ("Hatasý düzeltilebilir mi? " + sürüm.IsDebug);
            Console.WriteLine ("Yamalý mý? " + sürüm.IsPatched);
            Console.WriteLine ("Ön sürüm mü? " + sürüm.IsPreRelease);
            Console.WriteLine ("Hususi yapým mý? " + sürüm.IsPrivateBuild);
            Console.WriteLine ("Özel yapým mý? " + sürüm.IsSpecialBuild);

            Console.WriteLine ("\nGörünmez izole depo ve içerdikleri dosyalara yazma/okuma:");
            int i; string satýr; string[] dosyalar;
            IsolatedStorageFile izoleDepo; StreamWriter sw; StreamReader sr;
            using (izoleDepo = IsolatedStorageFile.GetUserStoreForAssembly()) {
                izoleDepo.CreateDirectory ("ÝzoleDepo");
                Console.WriteLine ("Aktüel ebat: {0} Byte,\tKapsam: {1}", izoleDepo.UsedSize, izoleDepo.Scope);
                using (Stream s = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Create, izoleDepo)) {
                    sw = new StreamWriter (s);
                    for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atatürk: {0}", i);
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Append, izoleDepo)) {
                    using (sw = new StreamWriter (isfs)) {
                        for(i=1938;i>=1881;i-=14) sw.WriteLine ("M.Kemal Atatürk: {0}", i);
                        sw.Flush(); sw.Close();
                    }
                }
                Console.WriteLine ("==>nihat1.txt'e 10 kayýt yazýldý");
                using (Stream s = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Open, izoleDepo)) {
                    sr = new StreamReader (s);
                    while((satýr=sr.ReadLine()) != null) Console.WriteLine (satýr);
                    sr.Close();
                }
                Console.WriteLine ("==>ÝzoleDepo klasöründeki dosyalar:");
                dosyalar = izoleDepo.GetFileNames ("*.*");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat1.txt", FileMode.Open, FileAccess.Read, izoleDepo)) {
                    using (sr = new StreamReader (isfs)) {
                        satýr = sr.ReadToEnd();
                        Console.WriteLine ("==>ReadToEnd'le okunan tüm kayýtlar:\n{0}", satýr);
                        sr.Close();
                    }
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat2.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("M.Nihat Yavaþ");
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat3.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("Canan Candan");
                    sw.Flush(); sw.Close();
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream ("nihat4.txt", FileMode.OpenOrCreate)) {
                    sw = new StreamWriter (isfs);
                    sw.WriteLine ("Süheyla Yavaþ Özbay");
                    sw.Flush(); sw.Close();
                }
            } izoleDepo.Close();
            IEnumerator ie = IsolatedStorageFile.GetEnumerator (IsolatedStorageScope.User);
            Console.WriteLine ("==>Tüm ÝzoleDepolar ve içerdikleri dosyalar:");
            while (ie.MoveNext()) {
                IsolatedStorageFile isf = (IsolatedStorageFile) ie.Current;
                Url yurel = (Url) isf.AssemblyIdentity;
                Console.WriteLine ("Koþturulan program: " + yurel.Value);
                dosyalar = isf.GetFileNames ("*");
                foreach (string dosya in dosyalar) Console.WriteLine (dosya);
            }

            Console.WriteLine ("\nGZipStream'le dosyaya sýkýþýk yazma ve normal okuma:");
            string dosyam = "mahmut1.txt";
            SýkýþtýrYaz (dosyam);
            satýr = NormalleþtirOku (dosyam);
            Console.WriteLine (satýr);

            Console.WriteLine ("Herbir kayýt alanlarý virgülle ayrýlan CSV dosyaya yazma/okuma:");
            dosyam = "mahmut1.csv";
            sw = new StreamWriter (dosyam); //CAV kayýtlarý elle de yazýlabilir
            for(i=1881;i<=1890;i++) sw.WriteLine ("Mustafa Kemal,Selanik,Yunanistan,"+i);
            sw.Close();
            Console.WriteLine ("==>mahmut1.csv'ye 10 kayýt yazýldý");
            sr = new StreamReader (dosyam);
            while ((satýr = sr.ReadLine())!=null) {
                String[] alanlar = satýr.Split (',');
                Ýkamet ikm = new Ýkamet();
                ikm.kiþi = alanlar [0];
                ikm.þehir = alanlar [1];
                ikm.ülke = alanlar [2];
                ikm.yýl = alanlar [3];        
                Console.WriteLine (ikm);
            }
            sr.Close();
  
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}