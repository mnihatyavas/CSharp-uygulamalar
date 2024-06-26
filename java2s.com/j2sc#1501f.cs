// j2sc#1501f.cs: FileStream, FileMode, FileAccess, Decoder/Encoder örneği.

using System;
using System.IO; //FileStream için
using System.Windows.Forms; //OpenFileDialog ve DialogResult için
using System.Text; //StringBuilder ve Encoding/Decoding için
namespace DosyaDizin {
    class DosyaF {
        [STAThread] //OpenFileDialog açılmasını sağlar
        static void Main() {
            Console.Write ("Dosya işlemleri: 'FileStream(string ad, FileMode kip, FileAccess erişim)'le sağlanır. Kipler: FileMode.CreateNew/Create/OpenOrCreate/Open/Append/Truncate, erişimler: FileAccess.Read/Write/ReadWrite olabilir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("FileMode.Open, mevcutsa dosyayı açar, namevcutsa hata fırlatır:");
            FileStream fs=null; 
            try {fs = new FileStream ("nihat.dat", FileMode.Open);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nFileStream.Seek() ile dosyadaki kaçıncı karaktere erişim:");
            char krk; int i, j, ebat;
            try {fs = new FileStream ("nihat1.dat", FileMode.Create); //Yoksa yada öncekini silerek yenisini yaratır
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            for(i=0;i<26;i++) {
                try {fs.WriteByte ((byte)('A'+i)); 
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            }
            try {fs.Seek (0, SeekOrigin.Begin); //Dosyadaki ilk kaydı gösterir
                krk = (char) fs.ReadByte(); Console.WriteLine ("1.karakter: " + krk);
                fs.Seek (1, SeekOrigin.Begin); //Dosyadaki ikinci kaydı gösterir
                krk = (char) fs.ReadByte(); Console.WriteLine ("2.karakter: " + krk);
                fs.Seek (25, SeekOrigin.Begin); //Dosyadaki son kaydı gösterir
                krk = (char) fs.ReadByte(); Console.WriteLine ("26.karakter: " + krk);
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            fs.Close();
            FileInfo fi = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.dat");
            fs = fi.Open (FileMode.Open, FileAccess.Read, FileShare.None); //Mevcut dosyayı okuma'lı açar, namevcutsa hata fırlatır
            Console.WriteLine ("\tSondan başa okuma:");
            for(i=1;i<=26;i++) {fs.Seek (26-i, SeekOrigin.Begin); krk = (char) fs.ReadByte(); Console.Write (krk+" ");} Console.WriteLine();
            fs.Close();
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.dat", FileMode.OpenOrCreate); //Mevcutsa açar, namevcutsa yaratır
            Console.WriteLine ("\tBaştan sona okuma:");
            for(i=0;i<26;i++) {fs.Seek (i, SeekOrigin.Begin); krk = (char) fs.ReadByte(); Console.Write (krk+" ");} Console.WriteLine();
            fs.Close();

            Console.WriteLine ("\nDosyaya byteDizi[ebat]'lı Write ve Read:");
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.dat", FileMode.Create);
            ebat = 256;
            byte[] byteDizi1 = new Byte [ebat];
            for(i=0;i<256;i++) byteDizi1 [i] = (byte)i;
            fs.Write (byteDizi1, 0, ebat);
            fs.Close();
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.dat", FileMode.Open);
            ebat=100; byte[] byteDizi2 = new Byte [ebat];
            while ((j=fs.Read (byteDizi2, 0, ebat)) > 0) for(i=0;i<j;i++) Console.Write ((char)byteDizi2 [i]); Console.WriteLine(); //j okunan byte sayısıdır.
            fs.Close();

            Console.WriteLine ("\nDosyaya WriteByte ve ReadByte'la yazma ve okuma:");
            Console.WriteLine ("\tFileInfo, FileStream, CreateNew, ReadWrite, WriteByte, ReadByte:");
            fi = new FileInfo (@"nihat.txt");
            fs = fi.Open (FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None); //Namevcutsa yaratır, mevcutsa hata fırlatır
            for(i=0;i<256;i++) fs.WriteByte ((byte)i);
            fs.Position = 0; //Dosya başını gösterir
            while ((i=fs.ReadByte()) != -1) Console.Write ((char)i); Console.WriteLine();
            fs.Close(); fi.Delete();
            Console.WriteLine ("\tFileStream, OpenOrCreate, ReadWrite, WriteByte, ReadByte:");
            fs = new FileStream ("nihat1.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite); //Namevcutsa yaratır, mevcutsa ebatı sıfırlayıp açar
            for(i = 0; i < 256; i++) fs.WriteByte ((byte)i);
            fs.Position = 0;
            for(i = 0; i < 256; i++) Console.Write ((char)fs.ReadByte()); Console.WriteLine();
            fs.Close();

            Console.WriteLine ("\nSeçilen dosyanın, aynı dizinde .bak yedeğini üretir:");
            OpenFileDialog od = new OpenFileDialog();
            od.Title="Yedeği üretilecek (.uzantılı) dosyayı seç";
            if (od.ShowDialog() == DialogResult.OK) {
                fs = File.OpenRead (od.FileName);
                string ad=od.FileName.Substring (0, od.FileName.LastIndexOf (".")) + ".bak"; //Mevcut .abc uzantıyı kırpar
                Console.WriteLine ("Yedek dosya adı: [{0}]", ad);
                FileStream fsBak =  File.OpenWrite (ad);
                while ((i = fs.ReadByte()) > -1) fsBak.WriteByte ((byte)i);
                fsBak.Flush(); fsBak.Close(); fs.Close();
                Console.WriteLine ("Seçilen dosyanın .bak yedeği üretildi...");
            }

            Console.WriteLine ("\nMevcut dosyanın 10.konumundan itibaren 'Nar Sosu' yazar:");
            try {fs = new FileStream ("nihat1.dat", FileMode.Open); //Mevcut değilse hata fırlatır
                Console.WriteLine ("Ebat: {0}, Konum: {1}", fs.Length, fs.Position);
                byte[] byteDizi3 = new byte[] {78, 97, 114, 0, 83, 111, 115, 117}; //Nar Sosu
                if (fs.CanSeek) {
                    fs.Seek (10, SeekOrigin.Begin);
                    Console.WriteLine ("Konum: {0}", fs.Position);
                    fs.Write (byteDizi3, 0, byteDizi3.Length); //10.konumdan itibaren öncekilerin üstüne "Nar Sosu" yazar
                    fs.Flush();
                } fs.Close();
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nDosyadan okunan azami 16384 byte 16'lık kolona harf/hex -kodla yazılır:");
            fs = new FileStream ("nihat1.dat", FileMode.Open, FileAccess.Read); //Mevcut dosyayı okuma erşimiyle açar
            long uzunluk = fs.Length; //256
            if (uzunluk > 65536 / 4) uzunluk = 65536 / 4; //Dosyadan azami 65536/4=16384 byte okunacak
            int kolonSayısı = 16, okunanByteSayısı = 0, bayt = 0; char kr; StringBuilder satır;
            int satırSayısı = (int)(uzunluk / kolonSayısı) + 1; //256/16+1=17
            for (i = 0; i < satırSayısı; i++) {
                satır = new StringBuilder();
                satır.Capacity = 4 * kolonSayısı; //4*16=64
                for (j = 0; j < kolonSayısı; j++) {
                    bayt = fs.ReadByte();
                    okunanByteSayısı++;
                    if (bayt < 0 || okunanByteSayısı > 65536/4) break;
                    kr = (char)bayt;
                    //Harf, rakam ve noktalamaları olduğu gibi, diğer karakterleri hex kodla yazar
                    if (kr < 16) satır.Append (" x0" + string.Format ("{0,1:X}", (int)kr));
                    else if (char.IsLetterOrDigit (kr) || char.IsPunctuation (kr)) satır.Append ("  " + kr + " ");
                    else satır.Append (" x" + string.Format ("{0,2:X}", (int)kr));
                }
                Console.WriteLine (satır);
            }
            fs.Close();

            Console.WriteLine ("Dosyanın 10.konumundan 8 byte-->char'a dekoderlenir:");
            Console.WriteLine ("\tByte'dan char'a UTF8'le dekodlama:");
            byte[] bytDizi = new byte [8];
            char[] krkDizi = new Char [8];
            fs = new FileStream ("nihat1.dat", FileMode.Open); //Mevcut dosyayı açar
            fs.Seek (10, SeekOrigin.Begin);
            fs.Read (bytDizi, 0, 8); //Dosyadaki 10.konumdan itibaren 8 byte okur
            Decoder dekod = Encoding.UTF8.GetDecoder(); //Dekoder olarak UTF8 kullanılacak
            dekod.GetChars (bytDizi, 0, bytDizi.Length, krkDizi, 0); //bytDizi byte'ları UTF8'le dekoderlenip krkDizi'ye konulur
            Console.Write ("'nihat1.dat' dosyasından UTF8'le dekodlanan [11,18] krk'ler: "); Console.WriteLine (krkDizi);
            Console.WriteLine ("\tTekrar char'dan byte'a UTF8'le kodlama:");
            fs = new FileStream ("geçici.txt", FileMode.Create); //Mevcut/namevcut yeni dosya yaratır
            Encoder kod = Encoding.UTF8.GetEncoder();
            kod.GetBytes (krkDizi, 0, krkDizi.Length, bytDizi, 0, true);
            //fs.Seek (0, SeekOrigin.Begin); //Zaten yeni yaratılan dosyabaşıdır
            fs.Write (bytDizi, 0, bytDizi.Length); //'Nar Sosu' UTF8 byte olarak dosyaya kodlanır
            Console.WriteLine ("geçici.txt içeriğine [Nar Sosu]-->[慎r潓畳]:");

            Console.WriteLine ("\nMesajı dosyaya yazar, byte okur, kodlayıp ekrana sunar:");
            using (fs = File.Open (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mesaj.txt", FileMode.Create)) {//Yeni dosya yaratır
                string mesaj = "M.Nihat Yavaş'tan herkese selamlar!";
                byte[] mesajBytDizi = Encoding.Default.GetBytes (mesaj);
                fs.Write (mesajBytDizi, 0, mesajBytDizi.Length);
                fs.Position = 0;
                byte[] dosyadanOkunanBytlar = new byte [mesajBytDizi.Length];
                for (i = 0; i < mesajBytDizi.Length; i++) {
                    dosyadanOkunanBytlar [i] = (byte)fs.ReadByte();
                    Console.Write (dosyadanOkunanBytlar [i] + " ");
                }
                Console.WriteLine (": " + Encoding.Default.GetString (dosyadanOkunanBytlar));
            }

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    }
}