// j2sc#1501j.cs: Bellekte BufferedStream ve MemoryStream akýþlarý örneði.

using System;
using System.IO;
namespace DosyaDizin {
    class DosyaJ {
        public static void BellektenYedekle (MemoryStream bellek, string dosya) {
            FileStream akýþ = File.OpenWrite (dosya);
            bellek.WriteTo (akýþ);
            akýþ.Flush(); akýþ.Close();
        }
        static void Main() {
            Console.Write ("Dosya okuma metotlarý: void Close(), int Peek(), int Read(), int Read-Block(char[] dizi, int ilk, int adet), string ReadLine(), string ReadToEnd()\nDosyaya yazma metotlarý: void Write(int/double/bool deðer), void WriteLine(string/uint/char deðer), void Flush(), void Close()\nAkýþ sýnýflarý: StreamReader, StreamWriter, StringReader, StringWriter.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("TextWriter=Console.Out'la metin dosyasý olarak ekrana yazma:");
            TextWriter tw;
            using (tw = Console.Out) {//Ekrana yazacak
                tw.Write (202400514.071759m);
                tw.Write (" M.Kemal Atatürk [1881-1938] ");
                tw.Write (true);
                tw.WriteLine ('.');
                tw.WriteLine ("19 Mayýs 1919, Sinop");
                tw.WriteLine ("23 Nisan 1920, TBMM-Ankara");
                tw.WriteLine ("29 Ekim 1923, Cumhuriyet/TBMM-Ankara");
                tw.Flush(); tw.Close();
            }

            Console.WriteLine ("\nnihat1.dat dosyaya BufferedStream.Write/Read'le byteDizi yazma/okuma:");
            int i, j;
            FileStream fs = new FileStream ("nihat1.dat", FileMode.Create, FileAccess.ReadWrite);
            BufferedStream bs = new BufferedStream (fs);
            byte[] byteDizi = {65, 0x7a, 0x3, 0x0, 0x5A, 0x38, 97};
            bs.Write (byteDizi, 0, byteDizi.Length);
            //bs.Close(); fs.Close();
            bs.Read (byteDizi, 0, byteDizi.Length);
            bs.Close(); fs.Close();
            for(i=0;i<byteDizi.Length;i++) Console.WriteLine ("{0}) {1}={2}", i, byteDizi [i], (char)byteDizi [i]);

            Console.WriteLine ("\nnihat1.dat dosyasýnýn nihat1.bak ve nihat1.txt yedekleri kopyalanacak:");
            FileStream fsOku = File.OpenRead (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.dat");
            FileStream fsYaz = File.OpenWrite (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.bak");
            BufferedStream bsOku = new BufferedStream (fsOku);
            BufferedStream bsYaz = new BufferedStream (fsYaz);
            byteDizi = new byte [1024];
            while ((i = bsOku.Read (byteDizi, 0, 1024)) > 0) bsYaz.Write (byteDizi, 0, i);
            bsYaz.Flush(); bsYaz.Close(); bsOku.Close();
            fsYaz.Close(); fsOku.Close();
            j = 128;
            Stream sOku = File.OpenRead ("nihat1.dat");
            Stream sYaz = File.OpenWrite("nihat2.txt");
            bsOku = new BufferedStream (sOku);
            bsYaz = new BufferedStream (sYaz);
            byteDizi = new Byte [j];
            while ((i =
            bsOku.Read (byteDizi, 0, j)) > 0) bsYaz.Write (byteDizi, 0, i);
            bsYaz.Flush(); bsYaz.Close(); bsOku.Close();
            sYaz.Close(); sOku.Close();

            Console.WriteLine ("\nbyteDizi ve StreamReader(ms)'in [0-->9, A-->Z, a-->z] elemanlarý:");
            byteDizi = new byte [4629]; //629/256=18, her 18 byte "byteDizi[65]=A " için gerekir
            MemoryStream ms = new MemoryStream (byteDizi);
            StreamWriter sw = new StreamWriter (ms);
            StreamReader sr = new StreamReader (ms);
            for (i=0;i<256;i++) sw.WriteLine ("byteDizi[{0}]={1} ", i, (char)i); sw.WriteLine (".");
            sw.Flush();
            Console.WriteLine ("\t==>Doðrudan byteDizi[4629]'dan okunuyor:");
            j=0;
            foreach (char k in byteDizi) if((++j>806 & j<974) | (j>1092 & j<1554) | (j>1639 & j<2105)) Console.Write (k);
            Console.WriteLine ("\t==>StreamReader(MemoryStream)[256]'dan okunuyor:");
            ms.Seek (0, SeekOrigin.Begin);
            string satýr; j=0;
            while ((satýr=sr.ReadLine()) != ".") if((++j>50 & j<61) | (j>67 & j<94) | (j>99 & j<126)) Console.Write (satýr+" ");
            Console.WriteLine ("\n\t==>MemoryStream.Capacity=256'dan yazýlýp okunuyor:");
            ms = new MemoryStream();
            ms.Capacity = 256;
            for(i = 0; i < 256; i++) ms.WriteByte ((byte)i);
            ms.Position = 0;
            for(i = 0; i < 256; i++) Console.Write ("{0}={1} ", i, (char)ms.ReadByte()); Console.WriteLine();
            Console.WriteLine ("\t==>MemoryStream[256]'dan mahmut1.dat'a yazýlýyor:");
            fs = new FileStream ("mahmut1.dat", FileMode.Create, FileAccess.ReadWrite);
            ms.WriteTo (fs); fs.Close();
            Console.WriteLine ("\t==>MemoryStream[256]'dan byteDizi[256]'ya yazýlýp okunuyor:");
            byteDizi = ms.ToArray();
            ms.Close();
            for(i = 0; i < byteDizi.Length; i++) Console.Write ((char)byteDizi [i] + " ");  Console.WriteLine();

            Console.WriteLine ("\nmahmut1.dat'tan belleðe, oradan da mahmut1.bak'a yedekleme:");
            fs = File.OpenRead (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mahmut1.dat");
            ms = new MemoryStream();
            ms.SetLength (fs.Length);
            fs.Read (ms.GetBuffer(), 0, (int)fs.Length);
            ms.Flush();
            fs.Close();
            BellektenYedekle (ms, "mahmut1.bak");
            ms.Close();

            Console.WriteLine ("\nnihat1.dat-->MemoryStream-->nihat1.txt-->byteDizi:");
            fsOku = File.OpenRead ("nihat1.dat");
            BinaryReader br = new BinaryReader (fsOku);
            fsYaz = File.Open ("nihat1.txt", FileMode.Create);
            ms = new MemoryStream();
            while ((i = br.Read()) != -1) {ms.WriteByte ((byte)i);}
            ms.Seek (0, SeekOrigin.Begin);
            byteDizi = ms.ToArray();
            BinaryWriter bw = new BinaryWriter (fsYaz);
            bw.Write (byteDizi);
            foreach (char k in byteDizi) Console.Write (k); Console.WriteLine();
            br.Close(); bw.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}