// j2sc#1501e.cs: FileInfo, [FileIOPermission] ve FileStream �rne�i.

using System;
using System.IO;
//using System.Reflection; //assembly i�in
using System.Security.Permissions; //[assembly: FileIOPermissionAttribute] i�in
using System.Security; //NamedPermissionSet i�in
namespace DosyaDizin {
    //[assembly: FileIOPermissionAttribute (SecurityAction.RequestMinimum, All=@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#")]
    //[assembly: PermissionSetAttribute (SecurityAction.RequestMinimum, Name="FullTrust")]
    //[assembly: FileIOPermissionAttribute (SecurityAction.RequestRefuse, Unrestricted=true)]
    [FileIOPermissionAttribute (SecurityAction.Demand,  ViewAndModify=@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#")] //Di�er dosya izin vasflar� derleme hatas� verebilir
    class DosyaE {
        static void Dosyalar�S�ralaG�ster (string ba�l�k, Comparison<FileInfo> s�ra) {
            FileInfo[] dosyalar = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#").GetFiles();
            Array.Sort (dosyalar, s�ra);
            Console.WriteLine (ba�l�k);
            foreach (FileInfo dosya in dosyalar) Console.WriteLine ("  {0} ({1} byte)", dosya.Name, dosya.Length);
        }
        [FileIOPermission (SecurityAction.Demand, AllLocalFiles=FileIOPermissionAccess.Write)] //Main() metoda dosya yazma eri�im izni
        static void Main() {
            Console.Write ("FileMode.Open eri�imde, dosya mevcutsa a��l�r, namevcutsa hata f�rlat�r. FileMode.Create eri�imde namevcutsa yarat�r, mevcutsa yazmadan esge�er. fi.CreateText() ile dosya namevcutsa yarat�l�r, mevcutsa hata f�rlat�r. Bir dosya fs.Close()'la kapat�lmadan tekrar a��lmaya �al���l�rsa hata verir. File.Create() mevcut/namevcut dosyay� yeniden yarat�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("FileInfo ve FileStream ile �e�itli dosya eri�imleri:");
            int i; FileStream fs; StreamWriter sw;
            FileInfo fi = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt");
            try {fs=fi.Open (FileMode.Open, FileAccess.Read, FileShare.None); fs.Close();
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {sw = fi.CreateText();
                sw.Write ("1881-"); sw.Write ("1919-"); sw.Write ("1923-"); sw.WriteLine ("1938"); sw.WriteLine ("Elan: 23.04.2024");
                sw.Flush(); sw.Close();
                Console.WriteLine ("fi.CreateText() ile nihat1.txt yarat�ld�, veriler y�klendi ve kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            fs = fi.OpenWrite(); //Dosya mevcutsa a�ar, ba�tan yazar.
            for(i=65;i<91;i++) fs.WriteByte ((byte)i);
            fs.Flush(); fs.Close();
            Console.WriteLine ("fi.OpenWrite() ile mevcut nihat1.txt'e veriler [A,Z] ba�tan y�klendi ve kapat�ld�.");
            fs = fi.OpenRead();
            while ((i=fs.ReadByte()) != -1) Console.Write ((char)i);
            fs.Flush(); fs.Close();
            Console.WriteLine ("fi.OpenRead() ile mevcut nihat1.txt, i=fs.ReadByte() ile okundu, sunuldu.");

            Console.WriteLine ("\nVerili dizindeki t�m dosyalar�n artan ve azalan s�ralanmas�:");
            Dosyalar�S�ralaG�ster ("Adla artan A-->Z s�ralama:", delegate (FileInfo ilk, FileInfo ikinci) {return ilk.Name.CompareTo (ikinci.Name);});
            Dosyalar�S�ralaG�ster ("Adla azalan Z-->A s�ralama:", delegate (FileInfo ilk, FileInfo ikinci) {return ikinci.Name.CompareTo (ilk.Name);});

            Console.WriteLine ("\nVerili dizindeki mevcut *.jpg resim dosyalar�n�n �zellikleri:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\5.Ar�iv\Resimler\manzara");
            FileInfo[] resimler = dir.GetFiles ("*.jpg");
            Console.WriteLine ("{0} adet *.jpg resim dosyas� bulundu\nDosya ADI, EBATI, YARATILAN TAR�H, VASIFLARI:", resimler.Length);
            foreach (FileInfo dsy in resimler) Console.WriteLine ("{0,15}: {1,10} byte, [{2}], {3}", dsy.Name, dsy.Length, dsy.CreationTime, dsy.Attributes);

            Console.WriteLine ("\nFile.Create('nihat2.txt') yarat�r ve 'StreamWriter.WriteLine' yazar:");
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat2.txt");
            sw = new StreamWriter (fs);
            for(i=1;i<=5;i++) sw.WriteLine ("{0}) {1}", i, "M.Nihat Yava�");
            sw.Flush(); sw.Close();
            Console.WriteLine ("nihat2.txt dosyas� yarat�ld�, 5 sat�r yaz�ld� ve kapat�ld�.");

            Console.Write ("\nVerili dizinin �zinK�mesi i�in Tu�..."); Console.ReadKey();
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}