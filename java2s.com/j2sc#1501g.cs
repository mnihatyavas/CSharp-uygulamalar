// j2sc#1501g.cs: Stream, FileStream, Stream-Writer/Reader ve String-Writer/Reader örneði.

using System;
using System.IO;
using System.Text; //Encoding/Decoding ve StringBuilder için
namespace DosyaDizin {
    class DosyaF {
        static void Main() {
            Console.Write ("Stream tüm diðer akýþlarýn temelidir, byte'la iþlem yapar. I/O metotlarý: int ReadByte(), void WriteByte(byte b), int Read(byte[] buf,int offset, int numBytes), void Write(byte[] buf,int offset, int numBytes), long Seek(long offset,SeekOrigin.origin), void Flush(), void Close().\nÖzellikleri: bool CanRead, bool CanWrite, bool CanSeek, long Position, long Length.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dosya açma/yaratma, Seek, Read/Write-Byte ile byte okuma/yazma:");
            int i, j, sayaç; Stream akýþ;
            Console.WriteLine ("\t==>Seek konumlamayla yegane ReadByte() okuma:");
            using (akýþ = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mahmut1.txt", FileMode.OpenOrCreate)) {
                akýþ.Position = 0;
                for(i=0;i<256;i++) akýþ.WriteByte ((byte)i);
                akýþ.Seek (65, SeekOrigin.Current); //Aktüel dosyasonu
                Console.WriteLine ("65.(aktüel)konum: [{0} = {1}]", i=akýþ.ReadByte(), (char)i);
                akýþ.Seek (65, SeekOrigin.Begin); //65.krk
                Console.WriteLine ("65.konum: [{0} = {1}]", i=akýþ.ReadByte(), (char)i);
                 akýþ.Seek (0, SeekOrigin.Begin);
                Console.WriteLine ("0.konum: [{0} = {1}]", i=akýþ.ReadByte(), (char)i);
                akýþ.Seek (-1, SeekOrigin.End);
                Console.WriteLine ("(256-1).konum: [{0} = {1}]", i=akýþ.ReadByte(), (char)i);
                akýþ.Flush(); akýþ.Close();
            }
            Console.WriteLine ("\t==>Baþtan-sona Encoding.UTF8'li byte=krk'ler:");
            akýþ = new FileStream ("mahmut1.txt", FileMode.Open); //Mevcut dosyayý aç
            StreamReader sr;
            using (sr = new StreamReader (akýþ, Encoding.UTF8)) {
                char[] tampon = new char [1024]; // Her kerede azami 1024 byte veya eksik sayaç adet okur
                while ((sayaç = sr.Read (tampon, 0, 1024)) != 0) for (i = 0; i < sayaç; i++) Console.Write ("{0}={1} ", (j=tampon [i])==65533?-1:j, (char)j);
                sr.Close();
            } Console.WriteLine();
            Console.WriteLine ("\t==>Encoding.UTF8'li ReadLine() satýr:");
            akýþ = new FileStream ("mahmut1.txt", FileMode.Open);
            string satýr;
            using (sr = new StreamReader (akýþ, Encoding.UTF8)) {
                while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            } sr.Close(); Console.WriteLine();
            Console.WriteLine ("\t==>Encoding.UTF8'li ReadToEnd():");
            akýþ = new FileStream ("mahmut1.txt", FileMode.Open);
            using (sr = new StreamReader (akýþ, Encoding.UTF8)) {Console.WriteLine (sr.ReadToEnd()); sr.Close();}
            Console.WriteLine ("\t==>OpenRead/Write ve tamponlu Read/Write'la [mahmut1.bak] yedekleme:");
            Stream akýþOku = File.OpenRead ("mahmut1.txt");
            Stream akýþYaz = File.OpenWrite ("mahmut1.bak");
            byte[] tampon2 = new Byte [1024];
            while ((j = akýþOku.Read (tampon2, 0, 1024)) > 0) akýþYaz.Write (tampon2, 0, j);
            akýþOku.Close(); akýþYaz.Close();

            Console.WriteLine ("\nFileStream, Stream-Writer/Reader ve String-Writer/Reader ile yaz/oku:");
            FileStream fs; StreamWriter sw;
            using (fs = new FileStream ("mahmut2.txt", FileMode.Create)) {//Namevcutsa/mevcutsa yeniden yaratýlýr
                using (sw = new StreamWriter (fs, Encoding.UTF8)) {
                    sw.WriteLine (20240506.011542M);
                    sw.WriteLine ("M.Nihat Yavaþ");
                    sw.WriteLine ('!');
                    sw.Flush(); sw.Close();
                }
            }
            using (fs = new FileStream ("mahmut2.txt", FileMode.Open)) {//Mevcudu okuma/yazmalý açar
                using (sr = new StreamReader (fs, Encoding.UTF8)) {
                    Console.WriteLine (Decimal.Parse (sr.ReadLine()));
                    Console.WriteLine (sr.ReadLine());
                    Console.WriteLine (Char.Parse (sr.ReadLine()));
                    sr.Close();
                }
            }
            Console.WriteLine ("\t==>StreamWriter-WriteLine/StreamReader-ReadLine ile yazdým/okudum:");
            try {fs = new FileStream ("mahmut2.txt", FileMode.Open);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            sr = new StreamReader (fs);
            while ((satýr = sr.ReadLine()) != null) {Console.WriteLine (satýr);}
            sr.Close();
            Console.WriteLine ("\t==>while(StreamReader.ReadLine() != null) ile okudum:");
            StringWriter SW = new StringWriter();
            for(i=1881;i<=1938;i++) SW.WriteLine (i);
            StringReader SR = new StringReader (SW.ToString());
            while ((satýr=SR.ReadLine()) != null) Console.Write (satýr+" "); Console.WriteLine();
            Console.WriteLine ("\t==>StringWriter-WriteLine/StringReader-ReadLine ile yazdým/okudum:");
            StringBuilder sb = new StringBuilder();
            SW = new StringWriter (sb);
            SW.WriteLine ("M.Kemal Atatürk");
            SW.WriteLine ("1881 - Selanik");
            SW.WriteLine ("1938 - Ýstanbul");
            SW.Close();
            SR = new StringReader(sb.ToString());
            satýr = SR.ReadToEnd();
            Console.Write (satýr);
            SR.Close();
            Console.WriteLine ("\t==>StringWriter-WriteLine/StringReader-ReadToEnd() ile yazdým/okudum:");
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mahmut2.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            sr = new StreamReader (fs);
            while ((i=sr.Read()) !=-1) Console.Write ("{0}", (char)i);
            sr.Close();
            Console.WriteLine ("\t==>while((i=StringReader.Read()) !=-1) ile okudum:");
            sr = new StreamReader ("mahmut2.txt");
            while ((i=sr.Read()) !=-1) Console.Write ("{0}", (char)i);
            sr.Close();
            Console.WriteLine ("\t==>FileStream'siz while((i=StringReader.ReadByte()) !=-1) ile okudum:");
            sr = new StreamReader (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mahmut2.txt");
            Console.Write (sr.ReadToEnd().ToString());
            sr.Close();
            Console.WriteLine ("\t==>StreamReader.ReadToEnd().ToString() ile okudum:");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}