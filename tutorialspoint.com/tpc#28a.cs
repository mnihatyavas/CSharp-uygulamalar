// tpc#28a.cs: Disk dosyas�na FileStream ak��la 1-25 say�lar yazma ve okuma �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class DosyaYazOku {
        static void Main() {
            Console.Write ("Disk dosyas� byte verilerini okuma/yazma i�in girdi/��kt� ak���/stream kullan�l�r. System.IO aduzam�ndaki dosya yaratan, a�an, okuyan, yazan, kapayan, silen vb soyut-olmayan en genel s�n�flar: BinaryReader, BinaryWriter, BufferedStream, Directory, DirectoryInfo, DriveInfo, File, FileInfo, FileStream, MemoryStream, Path, StreamReader, StreamWriter, StringReader, StringWriter\nDosyadan ard���k byte veri okuma �rne�i: FileStream F = new FileStream('�rnek.txt', FileMode.Open, FileAccess.Read, FileShare.Read);\nFileMode'un say�sallanan �yeleri: Append, Create, CreateNew, Open, OpenOrCreate, Truncate\nFileAccess'in say�sallanan �yeleri: Read, ReadWrite, Write\nFileShare'in say�sallanan �yeleri: Inheritable, None, Read, ReadWrite, Write\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream dosya = new FileStream ("mny1.veri", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 1; i <= 25; i++) {dosya.WriteByte ((byte)i);}
            dosya.Position = 0;
            for (int i = 0; i <= 26; i++) {Console.Write (dosya.ReadByte() + " ");}// Veri kalmay�nca -1 yans�t�r
            dosya.Close();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}