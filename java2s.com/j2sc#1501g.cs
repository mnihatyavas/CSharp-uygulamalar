// j2sc#1501g.cs: Stream, FileStream, Stream-Writer/Reader ve String-Writer/Reader �rne�i.

using System;
using System.IO;
using System.Text; //Encoding/Decoding ve StringBuilder i�in
namespace DosyaDizin {
    class DosyaF {
        static void Main() {
            Console.Write ("Stream t�m di�er ak��lar�n temelidir, byte'la i�lem yapar. I/O metotlar�: int ReadByte(), void WriteByte(byte b), int Read(byte[] buf,int offset, int numBytes), void Write(byte[] buf,int offset, int numBytes), long Seek(long offset,SeekOrigin.origin), void Flush(), void Close().\n�zellikleri: bool CanRead, bool CanWrite, bool CanSeek, long Position, long Length.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dosya a�ma/yaratma, Seek, Read/Write-Byte ile byte okuma/yazma:");
            int i, j, saya�; Stream ak��;
            Console.WriteLine ("\t==>Seek konumlamayla yegane ReadByte() okuma:");
            using (ak�� = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mahmut1.txt", FileMode.OpenOrCreate)) {
                ak��.Position = 0;
                for(i=0;i<256;i++) ak��.WriteByte ((byte)i);
                ak��.Seek (65, SeekOrigin.Current); //Akt�el dosyasonu
                Console.WriteLine ("65.(akt�el)konum: [{0} = {1}]", i=ak��.ReadByte(), (char)i);
                ak��.Seek (65, SeekOrigin.Begin); //65.krk
                Console.WriteLine ("65.konum: [{0} = {1}]", i=ak��.ReadByte(), (char)i);
                 ak��.Seek (0, SeekOrigin.Begin);
                Console.WriteLine ("0.konum: [{0} = {1}]", i=ak��.ReadByte(), (char)i);
                ak��.Seek (-1, SeekOrigin.End);
                Console.WriteLine ("(256-1).konum: [{0} = {1}]", i=ak��.ReadByte(), (char)i);
                ak��.Flush(); ak��.Close();
            }
            Console.WriteLine ("\t==>Ba�tan-sona Encoding.UTF8'li byte=krk'ler:");
            ak�� = new FileStream ("mahmut1.txt", FileMode.Open); //Mevcut dosyay� a�
            StreamReader sr;
            using (sr = new StreamReader (ak��, Encoding.UTF8)) {
                char[] tampon = new char [1024]; // Her kerede azami 1024 byte veya eksik saya� adet okur
                while ((saya� = sr.Read (tampon, 0, 1024)) != 0) for (i = 0; i < saya�; i++) Console.Write ("{0}={1} ", (j=tampon [i])==65533?-1:j, (char)j);
                sr.Close();
            } Console.WriteLine();
            Console.WriteLine ("\t==>Encoding.UTF8'li ReadLine() sat�r:");
            ak�� = new FileStream ("mahmut1.txt", FileMode.Open);
            string sat�r;
            using (sr = new StreamReader (ak��, Encoding.UTF8)) {
                while ((sat�r = sr.ReadLine()) != null) Console.WriteLine (sat�r);
            } sr.Close(); Console.WriteLine();
            Console.WriteLine ("\t==>Encoding.UTF8'li ReadToEnd():");
            ak�� = new FileStream ("mahmut1.txt", FileMode.Open);
            using (sr = new StreamReader (ak��, Encoding.UTF8)) {Console.WriteLine (sr.ReadToEnd()); sr.Close();}
            Console.WriteLine ("\t==>OpenRead/Write ve tamponlu Read/Write'la [mahmut1.bak] yedekleme:");
            Stream ak��Oku = File.OpenRead ("mahmut1.txt");
            Stream ak��Yaz = File.OpenWrite ("mahmut1.bak");
            byte[] tampon2 = new Byte [1024];
            while ((j = ak��Oku.Read (tampon2, 0, 1024)) > 0) ak��Yaz.Write (tampon2, 0, j);
            ak��Oku.Close(); ak��Yaz.Close();

            Console.WriteLine ("\nFileStream, Stream-Writer/Reader ve String-Writer/Reader ile yaz/oku:");
            FileStream fs; StreamWriter sw;
            using (fs = new FileStream ("mahmut2.txt", FileMode.Create)) {//Namevcutsa/mevcutsa yeniden yarat�l�r
                using (sw = new StreamWriter (fs, Encoding.UTF8)) {
                    sw.WriteLine (20240506.011542M);
                    sw.WriteLine ("M.Nihat Yava�");
                    sw.WriteLine ('!');
                    sw.Flush(); sw.Close();
                }
            }
            using (fs = new FileStream ("mahmut2.txt", FileMode.Open)) {//Mevcudu okuma/yazmal� a�ar
                using (sr = new StreamReader (fs, Encoding.UTF8)) {
                    Console.WriteLine (Decimal.Parse (sr.ReadLine()));
                    Console.WriteLine (sr.ReadLine());
                    Console.WriteLine (Char.Parse (sr.ReadLine()));
                    sr.Close();
                }
            }
            Console.WriteLine ("\t==>StreamWriter-WriteLine/StreamReader-ReadLine ile yazd�m/okudum:");
            try {fs = new FileStream ("mahmut2.txt", FileMode.Open);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            sr = new StreamReader (fs);
            while ((sat�r = sr.ReadLine()) != null) {Console.WriteLine (sat�r);}
            sr.Close();
            Console.WriteLine ("\t==>while(StreamReader.ReadLine() != null) ile okudum:");
            StringWriter SW = new StringWriter();
            for(i=1881;i<=1938;i++) SW.WriteLine (i);
            StringReader SR = new StringReader (SW.ToString());
            while ((sat�r=SR.ReadLine()) != null) Console.Write (sat�r+" "); Console.WriteLine();
            Console.WriteLine ("\t==>StringWriter-WriteLine/StringReader-ReadLine ile yazd�m/okudum:");
            StringBuilder sb = new StringBuilder();
            SW = new StringWriter (sb);
            SW.WriteLine ("M.Kemal Atat�rk");
            SW.WriteLine ("1881 - Selanik");
            SW.WriteLine ("1938 - �stanbul");
            SW.Close();
            SR = new StringReader(sb.ToString());
            sat�r = SR.ReadToEnd();
            Console.Write (sat�r);
            SR.Close();
            Console.WriteLine ("\t==>StringWriter-WriteLine/StringReader-ReadToEnd() ile yazd�m/okudum:");
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}