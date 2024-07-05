// j2sc#1503c.cs: using ifadesi, FileSecurity ve TripleDESCryptoServiceProvider örneði.

using System;
using System.IO;
using System.Text; //UTF8Encoding için
using System.Security.AccessControl; //FileSecurity ve AuthorizationRuleCollection için
using System.Security.Principal; //NTAccount için
using System.Security.Cryptography; //TripleDESCryptoServiceProvider ve CryptoStream için
namespace DosyaDizin {
    class ÇeþitliC {
        static void Main() {
            Console.Write ("'using System' direktif, 'using(akýþ){}' ifadedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StreamWriter/Reader'la nihat1.txt'e satýrlar yazma ve okuma:");
            StreamWriter sw; int i; string satýr;
            using (sw = new StreamWriter ("nihat1.txt") ) {//Yeniden yaratýr
                for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atatürk: {0}", i);
                sw.Flush(); sw.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5 kayýt yazýldý");
            StreamReader sr; 
            using (sr = new StreamReader ("nihat1.txt")) {//Okur
                while((satýr=sr.ReadLine()) != null) Console.WriteLine (satýr);
                sr.Close(); 
            }

            Console.WriteLine ("\nTextWriter/Reader'la nihat1.txt'e satýrlar yazma ve okuma:");
            TextWriter tw;
            using (tw = File.CreateText ("nihat1.txt")) {//Yaratýr
                for(i=1938;i>=1881;i-=14) tw.WriteLine ("M.Kemal Atatürk: {0}", i);
                tw.Flush(); tw.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5 kayýt yazýldý");
            TextReader tr; 
            using (tr = File.OpenText ("nihat1.txt")) {//Okur
                while((satýr=tr.ReadLine()) != null) Console.WriteLine (satýr);
                tr.Close(); 
            }

            Console.WriteLine ("\nFileStream'le nihat1.txt'e 111 byte yazma ve okuma:");
            FileStream fs;
            using (fs = File.Open ("nihat1.txt", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Byte[] byteDizi;
                for(i=1881;i<=1938;i+=14) {
                    satýr = "M.Kemal Ataturk: " + i +",";
                    byteDizi = new UTF8Encoding (true).GetBytes (satýr);
                    fs.Write (byteDizi, 0, byteDizi.Length );
                } fs.WriteByte ((byte)'*');
                fs.Flush(); fs.Close();
            }
            Console.WriteLine ("==>nihat1.txt'e 5*22+1=111 byte yazýldý");
            using (fs = File.OpenRead ("nihat1.txt")) {
                while(true) {i=(byte)fs.ReadByte();
                    if((char)i==',') Console.WriteLine();
                    else if((char)i=='*') break; 
                    else Console.Write ((char)i);
                }
                fs.Close();
            }

            Console.WriteLine ("\nTextWriter/Reader'la nihat1/2.txt'e 5'er satýr yazma ve okuma:");
            using (TextWriter tw1 = File.CreateText ("nihat1.txt")) {
                for(i=1881;i<=1938;i+=14) tw1.WriteLine ("M.Kemal Atatürk: {0}", i);
                using (TextWriter tw2 = File.CreateText ("nihat2.txt")) {
                    for(i=1938;i>=1881;i-=14) tw2.WriteLine ("M.Kemal Atatürk: {0}", i);
                }
            }
            Console.WriteLine ("==>nihat1.txt ve nihat2.txt'e 5'er kayýt yazýldý");
            using (TextReader tr1 = File.OpenText ("nihat1.txt")) {
                while (null != (satýr = tr1.ReadLine())) Console.WriteLine (satýr);
                using (TextReader tr2 = File.OpenText ("nihat2.txt"))
                    while (null != (satýr = tr2.ReadLine())) Console.WriteLine ("\t"+satýr);
            }

            Console.WriteLine ("\n'C:\\Windows\\' dizinin aktüel güvenlik ve eriþim kurallarý listesi:");
            FileSecurity eriþimKontrol = File.GetAccessControl (@"C:\Windows\");
            AuthorizationRuleCollection eriþimKurallarý = eriþimKontrol.GetAccessRules (true, true, typeof (NTAccount));
            foreach (AuthorizationRule kural in eriþimKurallarý) {
                Console.WriteLine (kural.IdentityReference);
                FileSystemAccessRule erþimKuralý = kural as FileSystemAccessRule;
                if (erþimKuralý != null) Console.WriteLine ("  ...{0}", erþimKuralý.FileSystemRights);
            }

            Console.WriteLine ("\nþifreli.anh anahtarla þifreli.txt'nin 5 kaydý deþifre edilmekte:");
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\þifreli.txt");
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream (fs, tdes.CreateEncryptor(), CryptoStreamMode.Write);
            sw = new StreamWriter (cs);
            for(i=1881;i<=1938;i+=14) sw.WriteLine ("M.Kemal Atatürk: {0}", i);
            sw.Flush(); sw.Close();
            fs = File.Create (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\þifreli.anh");
            BinaryWriter bw = new BinaryWriter (fs);
            bw.Write (tdes.Key ); bw.Write (tdes.IV);
            bw.Flush(); bw.Close();
            Console.WriteLine ("==>þifreli.txt'e 5 kayýt ve þifreli.anh'a þifre anahtarlarý yazýldý");
            tdes = new TripleDESCryptoServiceProvider();
            fs = File.OpenRead ("þifreli.anh");
            BinaryReader br = new BinaryReader (fs);
            tdes.Key = br.ReadBytes (24);
            tdes.IV = br.ReadBytes (8); //anahtar dosyada toplam 24+8=32 krk var
            fs = File.OpenRead ("þifreli.txt");
            cs = new CryptoStream (fs, tdes.CreateDecryptor(), CryptoStreamMode.Read);
            sr = new StreamReader (cs);
            Console.Write (sr.ReadToEnd());
            sr.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}