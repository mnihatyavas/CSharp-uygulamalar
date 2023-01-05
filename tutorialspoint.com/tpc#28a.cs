// tpc#28a.cs: Disk dosyasýna FileStream akýþla 1-25 sayýlar yazma ve okuma örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class DosyaYazOku {
        static void Main() {
            Console.Write ("Disk dosyasý byte verilerini okuma/yazma için girdi/çýktý akýþý/stream kullanýlýr. System.IO aduzamýndaki dosya yaratan, açan, okuyan, yazan, kapayan, silen vb soyut-olmayan en genel sýnýflar: BinaryReader, BinaryWriter, BufferedStream, Directory, DirectoryInfo, DriveInfo, File, FileInfo, FileStream, MemoryStream, Path, StreamReader, StreamWriter, StringReader, StringWriter\nDosyadan ardýþýk byte veri okuma örneði: FileStream F = new FileStream('örnek.txt', FileMode.Open, FileAccess.Read, FileShare.Read);\nFileMode'un sayýsallanan üyeleri: Append, Create, CreateNew, Open, OpenOrCreate, Truncate\nFileAccess'in sayýsallanan üyeleri: Read, ReadWrite, Write\nFileShare'in sayýsallanan üyeleri: Inheritable, None, Read, ReadWrite, Write\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream dosya = new FileStream ("mny1.veri", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 1; i <= 25; i++) {dosya.WriteByte ((byte)i);}
            dosya.Position = 0;
            for (int i = 0; i <= 26; i++) {Console.Write (dosya.ReadByte() + " ");}// Veri kalmayýnca -1 yansýtýr
            dosya.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}