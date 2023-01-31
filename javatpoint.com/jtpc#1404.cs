// jtpc#1404.cs: Dosyaya ikili verileri yazma ve okuma �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class �kiliYaz�c�Okuyucu {
        static void Main() {
            Console.Write ("BinaryWriter/Reader ikili veya belirli kodlamal� dizgesel veriyi yazar/okur. iy.Write ile yaz�p io.ReadDouble/Single/Int32/String/Boolean okuyabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            �kiliDosyayaYaz();
            Console.WriteLine ("'jtpc#1404.dat' ikili dosyaya 5 farkl� veri yaz�ld�...\n");
            �kiliDosyadanOku();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
        static void �kiliDosyayaYaz() {
            using (BinaryWriter iy = new BinaryWriter (File.Open ("jtpc#1404.dat", FileMode.Create))) {
                iy.Write (12.5D);
                iy.Write (12.5F);
                iy.Write (12);
                iy.Write ("Bu bir dizgesel veridir");
                iy.Write (true);
            }
        }
        static void �kiliDosyadanOku() {
            using (BinaryReader io = new BinaryReader (File.Open ("jtpc#1404.dat", FileMode.Open))) {
                Console.WriteLine ("Double de�er: " + io.ReadDouble());
                Console.WriteLine ("Float de�er: " + io.ReadSingle());
                Console.WriteLine ("Integer de�er: " + io.ReadInt32());
                Console.WriteLine ("String de�er: " + io.ReadString());
                Console.WriteLine ("Boolean de�er: " + io.ReadBoolean());
            }
        }

    }
}