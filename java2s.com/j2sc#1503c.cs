// j2sc#1503c.cs: using ifadesi, FileSecurity ve TripleDESCryptoServiceProvider �rne�i.

using System;
using System.IO;
using System.Text; //UTF8Encoding i�in
using System.Security.AccessControl; //FileSecurity ve AuthorizationRuleCollection i�in
using System.Security.Principal; //NTAccount i�in
using System.Security.Cryptography; //TripleDESCryptoServiceProvider ve CryptoStream i�in
namespace DosyaDizin {
    class �e�itliC {
        static void Main() {
            Console.Write ("'using System' direktif, 'using(ak��){}' ifadedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StreamWriter/Reader'la nihat1.txt'e sat�rlar yazma ve okuma:");
            StreamWriter sw; int i; string sat�r;
            using (sw = new StreamWriter ("nihat1.txt") ) {//Yeniden yarat�r
                for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atat�rk: {0}", i);
                sw.Flush(); sw.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5 kay�t yaz�ld�");
            StreamReader sr; 
            using (sr = new StreamReader ("nihat1.txt")) {//Okur
                while((sat�r=sr.ReadLine()) != null) Console.WriteLine (sat�r);
                sr.Close(); 
            }

            Console.WriteLine ("\nTextWriter/Reader'la nihat1.txt'e sat�rlar yazma ve okuma:");
            TextWriter tw;
            using (tw = File.CreateText ("nihat1.txt")) {//Yarat�r
                for(i=1938;i>=1881;i-=14) tw.WriteLine ("M.Kemal Atat�rk: {0}", i);
                tw.Flush(); tw.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5 kay�t yaz�ld�");
            TextReader tr; 
            using (tr = File.OpenText ("nihat1.txt")) {//Okur
                while((sat�r=tr.ReadLine()) != null) Console.WriteLine (sat�r);
                tr.Close(); 
            }

            Console.WriteLine ("\nFileStream'le nihat1.txt'e 111 byte yazma ve okuma:");
            FileStream fs;
            using (fs = File.Open ("nihat1.txt", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Byte[] byteDizi;
                for(i=1881;i<=1938;i+=14) {
                    sat�r = "M.Kemal Ataturk: " + i +",";
                    byteDizi = new UTF8Encoding (true).GetBytes (sat�r);
                    fs.Write (byteDizi, 0, byteDizi.Length );
                } fs.WriteByte ((byte)'*');
                fs.Flush(); fs.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5*22+1=111 byte yaz�ld�");
            using (fs = File.OpenRead ("nihat1.txt")) {
                while(true) {i=(byte)fs.ReadByte();
                    if((char)i==',') Console.WriteLine();
                    else if((char)i=='*') break; 
                    else Console.Write ((char)i);
                }
                fs.Close();
            }

            Console.WriteLine ("\nTextWriter/Reader'la nihat1/2.txt'e 5'er sat�r yazma ve okuma:");
            using (TextWriter tw1 = File.CreateText ("nihat1.txt")) {
                for(i=1881;i<=1938;i+=14) tw1.WriteLine ("M.Kemal Atat�rk: {0}", i);
                using (TextWriter tw2 = File.CreateText ("nihat2.txt")) {
                    for(i=1938;i>=1881;i-=14) tw2.WriteLine ("M.Kemal Atat�rk: {0}", i);
                }
            }
            Console.WriteLine ("==>nihat1.txt ve nihat2.txt'e 5'er kay�t yaz�ld�");
            using (TextReader tr1 = File.OpenText ("nihat1.txt")) {
                while (null != (sat�r = tr1.ReadLine())) Console.WriteLine (sat�r);
                using (TextReader tr2 = File.OpenText ("nihat2.txt"))
                    while (null != (sat�r = tr2.ReadLine())) Console.WriteLine ("\t"+sat�r);
            }

            Console.WriteLine ("\n'C:\\Windows\\' dizinin akt�el g�venlik ve eri�im kurallar� listesi:");
            FileSecurity eri�imKontrol = File.GetAccessControl (@"C:\Windows\");
            AuthorizationRuleCollection eri�imKurallar� = eri�imKontrol.GetAccessRules (true, true, typeof (NTAccount));
            foreach (AuthorizationRule kural in eri�imKurallar�) {
                Console.WriteLine (kural.IdentityReference);
                FileSystemAccessRule er�imKural� = kural as FileSystemAccessRule;
                if (er�imKural� != null) Console.WriteLine ("  ...{0}", er�imKural�.FileSystemRights);
            }

            Console.WriteLine ("\n�ifreli.anh anahtarla �ifreli.txt'nin 5 kayd� de�ifre edilmekte:");
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\�ifreli.txt");
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream (fs, tdes.CreateEncryptor(), CryptoStreamMode.Write);
            sw = new StreamWriter (cs);
            for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atat�rk: {0}", i);
            sw.Flush(); sw.Close();
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\�ifreli.anh");
            BinaryWriter bw = new BinaryWriter (fs);
            bw.Write (tdes.Key ); bw.Write (tdes.IV);
            bw.Flush(); bw.Close();
            Console.WriteLine ("==>�ifreli.txt'e 5 kay�t ve �ifreli.anh'a �ifre anahtarlar� yaz�ld�");
            tdes = new TripleDESCryptoServiceProvider();
            fs = File.OpenRead ("�ifreli.anh");
            BinaryReader br = new BinaryReader (fs);
            tdes.Key = br.ReadBytes (24);
            tdes.IV = br.ReadBytes (8); //anahtar dosyada toplam 24+8=32 krk var
            fs = File.OpenRead ("�ifreli.txt");
            cs = new CryptoStream (fs, tdes.CreateDecryptor(), CryptoStreamMode.Read);
            sr = new StreamReader (cs);
            Console.Write (sr.ReadToEnd());
            sr.Close();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}