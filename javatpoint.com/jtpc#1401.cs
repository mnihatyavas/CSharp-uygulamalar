// jtpc#1401.cs: 0-255 ASCII karakterleri dosyaya yazma ve okuma �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class DosyaAk��� {
        static void Main() {
            Console.Write ("FileStream/DosyaAk��� s�n�f tiplemesiyle istenilen dizindeki veri dosyas�na yaz�labilir ve okunabilir. WriteByte() ve ReadByte() metodlar�yla 0-255 rakaml� ASCII karakterler yaz�l�p okunabilir. FileMode.OpenOrCreate dosya kipiyle dosya yoksa yarat�larak, varsa do�rudan (okuma veya yazma i�in) a��l�r. Okunan�n geri d�n��� -1 ise dosya sonudur. Dizin ayrac� i�in ya �ift \\\\ (tek de�il), ya �ift //, yada tek / kullan�labilir. Senkron veya asenkron okuma-yazma yapabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream da1 = new FileStream ("C:\\Users\\nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\jtpc#1401a.txt", FileMode.OpenOrCreate); //Dizin ayrac� �ift \\ olmal�d�r
            da1.WriteByte (0); da1.WriteByte (1); // Yarat�lan metin dosya i�erik ard���k ASCII krk'ler kontrol edilebilir 
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

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    }
}