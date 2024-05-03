// j2sc#1501e.cs: FileInfo, [FileIOPermission] ve FileStream örneði.

using System;
using System.IO;
//using System.Reflection; //assembly için
using System.Security.Permissions; //[assembly: FileIOPermissionAttribute] için
using System.Security; //NamedPermissionSet için
namespace DosyaDizin {
    //[assembly: FileIOPermissionAttribute (SecurityAction.RequestMinimum, All=@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#")]
    //[assembly: PermissionSetAttribute (SecurityAction.RequestMinimum, Name="FullTrust")]
    //[assembly: FileIOPermissionAttribute (SecurityAction.RequestRefuse, Unrestricted=true)]
    [FileIOPermissionAttribute (SecurityAction.Demand,  ViewAndModify=@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#")] //Diðer dosya izin vasflarý derleme hatasý verebilir
    class DosyaE {
        static void DosyalarýSýralaGöster (string baþlýk, Comparison<FileInfo> sýra) {
            FileInfo[] dosyalar = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#").GetFiles();
            Array.Sort (dosyalar, sýra);
            Console.WriteLine (baþlýk);
            foreach (FileInfo dosya in dosyalar) Console.WriteLine ("  {0} ({1} byte)", dosya.Name, dosya.Length);
        }
        [FileIOPermission (SecurityAction.Demand, AllLocalFiles=FileIOPermissionAccess.Write)] //Main() metoda dosya yazma eriþim izni
        static void Main() {
            Console.Write ("FileMode.Open eriþimde, dosya mevcutsa açýlýr, namevcutsa hata fýrlatýr. FileMode.Create eriþimde namevcutsa yaratýr, mevcutsa yazmadan esgeçer. fi.CreateText() ile dosya namevcutsa yaratýlýr, mevcutsa hata fýrlatýr. Bir dosya fs.Close()'la kapatýlmadan tekrar açýlmaya çalýþýlýrsa hata verir. File.Create() mevcut/namevcut dosyayý yeniden yaratýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("FileInfo ve FileStream ile çeþitli dosya eriþimleri:");
            int i; FileStream fs; StreamWriter sw;
            FileInfo fi = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt");
            try {fs=fi.Open (FileMode.Open, FileAccess.Read, FileShare.None); fs.Close();
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {sw = fi.CreateText();
                sw.Write ("1881-"); sw.Write ("1919-"); sw.Write ("1923-"); sw.WriteLine ("1938"); sw.WriteLine ("Elan: 23.04.2024");
                sw.Flush(); sw.Close();
                Console.WriteLine ("fi.CreateText() ile nihat1.txt yaratýldý, veriler yüklendi ve kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            fs = fi.OpenWrite(); //Dosya mevcutsa açar, baþtan yazar.
            for(i=65;i<91;i++) fs.WriteByte ((byte)i);
            fs.Flush(); fs.Close();
            Console.WriteLine ("fi.OpenWrite() ile mevcut nihat1.txt'e veriler [A,Z] baþtan yüklendi ve kapatýldý.");
            fs = fi.OpenRead();
            while ((i=fs.ReadByte()) != -1) Console.Write ((char)i);
            fs.Flush(); fs.Close();
            Console.WriteLine ("fi.OpenRead() ile mevcut nihat1.txt, i=fs.ReadByte() ile okundu, sunuldu.");

            Console.WriteLine ("\nVerili dizindeki tüm dosyalarýn artan ve azalan sýralanmasý:");
            DosyalarýSýralaGöster ("Adla artan A-->Z sýralama:", delegate (FileInfo ilk, FileInfo ikinci) {return ilk.Name.CompareTo (ikinci.Name);});
            DosyalarýSýralaGöster ("Adla azalan Z-->A sýralama:", delegate (FileInfo ilk, FileInfo ikinci) {return ikinci.Name.CompareTo (ilk.Name);});

            Console.WriteLine ("\nVerili dizindeki mevcut *.jpg resim dosyalarýnýn özellikleri:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\5.Arþiv\Resimler\manzara");
            FileInfo[] resimler = dir.GetFiles ("*.jpg");
            Console.WriteLine ("{0} adet *.jpg resim dosyasý bulundu\nDosya ADI, EBATI, YARATILAN TARÝH, VASIFLARI:", resimler.Length);
            foreach (FileInfo dsy in resimler) Console.WriteLine ("{0,15}: {1,10} byte, [{2}], {3}", dsy.Name, dsy.Length, dsy.CreationTime, dsy.Attributes);

            Console.WriteLine ("\nFile.Create('nihat2.txt') yaratýr ve 'StreamWriter.WriteLine' yazar:");
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat2.txt");
            sw = new StreamWriter (fs);
            for(i=1;i<=5;i++) sw.WriteLine ("{0}) {1}", i, "M.Nihat Yavaþ");
            sw.Flush(); sw.Close();
            Console.WriteLine ("nihat2.txt dosyasý yaratýldý, 5 satýr yazýldý ve kapatýldý.");

            Console.Write ("\nVerili dizinin ÝzinKümesi için Tuþ..."); Console.ReadKey();
            NamedPermissionSet ps = new NamedPermissionSet ("SamplePermissionSet", PermissionState.None);
            ps.AddPermission (new FileIOPermission (FileIOPermissionAccess.AllAccess, @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\"));
            ps.AddPermission (new ReflectionPermission (PermissionState.Unrestricted));
            ps.AddPermission (new SecurityPermission (SecurityPermissionFlag.Execution));
            Console.WriteLine ("\n"+ps.ToXml().ToString());

            Console.WriteLine ("FileStream/FileMode.Create ile 'nihat3.txt' yaratma ve [A-Z a-z] yazma:");
            fs = new FileStream ("nihat3.txt", FileMode.Create);
            for(i=0;i<26;i++) fs.WriteByte ((byte)(i+65));
            fs.WriteByte (0);
            for(i=0;i<26;i++) fs.WriteByte ((byte)(i+97));
            fs.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}