// jtpc#1401.cs: 0-255 ASCII karakterleri dosyaya yazma ve okuma örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class DosyaAkýþý {
        static void Main() {
            Console.Write ("FileStream/DosyaAkýþý sýnýf tiplemesiyle istenilen dizindeki veri dosyasýna yazýlabilir ve okunabilir. WriteByte() ve ReadByte() metodlarýyla 0-255 rakamlý ASCII karakterler yazýlýp okunabilir. FileMode.OpenOrCreate dosya kipiyle dosya yoksa yaratýlarak, varsa doðrudan (okuma veya yazma için) açýlýr. Okunanýn geri dönüþü -1 ise dosya sonudur. Dizin ayracý için ya çift \\\\ (tek deðil), ya çift //, yada tek / kullanýlabilir. Senkron veya asenkron okuma-yazma yapabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream da1 = new FileStream ("C:\\Users\\nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\jtpc#1401a.txt", FileMode.OpenOrCreate); //Dizin ayracý çift \\ olmalýdýr
            da1.WriteByte (0); da1.WriteByte (1); // Yaratýlan metin dosya içerik ardýþýk ASCII krk'ler kontrol edilebilir 
            for (int i = 2; i <= 255; i++) {da1.WriteByte ((byte)i);}
            da1.Close();
            FileStream da2 = new FileStream ("C:/Users/nihet//Desktop\\MyFiles\\3. Dersler\\c#\\jtpc#1401a.txt", FileMode.OpenOrCreate);
            int k = 0;
            while ( (k = da2.ReadByte()) != -1) {Console.Write ("{0}:[{1}], ", k, (char)k );}
            da2.Close();

            string mesaj = "System.IO siniflari: BinaryReader, BinaryWriter, BufferedStream, Directory, DirectoryInfo, DirectoryNotFoundException, DriveInfo, DirectoryNotFoundException, EndOfStreamException, ErrorEventArgs, File, FileFormatException, FileInfo, FileLoadException, FileNotFoundException, FileStream, FileSystemEventArgs, FileSystemInfo, FileSystemWatcher, InternalBufferOverflowException, InvalidDataException, IODescriptionAttribute, IOException, MemoryStream, Path, PathTooLongException, PipeException, RenamedEventArgs, Stream, StreamReader, StringReader, StringWriter, TextReader, TextWriter, UnmanagedMemoryAccessor, UnmanagedMemoryStream\n\nDelegeler: ErrorEventHandler, FileSystemEventHandler, RenamedEventHandler\n\nSayilanabilenler: DriveType, FileAccess, FileAttributes, FileMode, FileOptions, FileShare, HandleInheritability, NotifyFilters, SearchOption, SeekOrigin, WatcherChangeTypes";
            FileStream da3 = new FileStream ("jtpc#1401b.txt", FileMode.OpenOrCreate);
            for (int i = 0; i < mesaj.Length; i++) {da3.WriteByte ((byte)mesaj [i]);}
            da3.Close();
            Console.WriteLine ("\n");
            FileStream da4 = new FileStream ("jtpc#1401b.txt", FileMode.OpenOrCreate);
            while ((k = da4.ReadByte()) != -1) {Console.Write ((char)k);}
            da4.Close();

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    }
}