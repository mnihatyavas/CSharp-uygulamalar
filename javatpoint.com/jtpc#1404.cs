// jtpc#1404.cs: Dosyaya ikili verileri yazma ve okuma örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class ÝkiliYazýcýOkuyucu {
        static void Main() {
            Console.Write ("BinaryWriter/Reader ikili veya belirli kodlamalý dizgesel veriyi yazar/okur. iy.Write ile yazýp io.ReadDouble/Single/Int32/String/Boolean okuyabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ÝkiliDosyayaYaz();
            Console.WriteLine ("'jtpc#1404.dat' ikili dosyaya 5 farklý veri yazýldý...\n");
            ÝkiliDosyadanOku();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
        static void ÝkiliDosyayaYaz() {
            using (BinaryWriter iy = new BinaryWriter (File.Open ("jtpc#1404.dat", FileMode.Create))) {
                iy.Write (12.5D);
                iy.Write (12.5F);
                iy.Write (12);
                iy.Write ("Bu bir dizgesel veridir");
                iy.Write (true);
            }
        }
        static void ÝkiliDosyadanOku() {
            using (BinaryReader io = new BinaryReader (File.Open ("jtpc#1404.dat", FileMode.Open))) {
                Console.WriteLine ("Double deðer: " + io.ReadDouble());
                Console.WriteLine ("Float deðer: " + io.ReadSingle());
                Console.WriteLine ("Integer deðer: " + io.ReadInt32());
                Console.WriteLine ("String deðer: " + io.ReadString());
                Console.WriteLine ("Boolean deðer: " + io.ReadBoolean());
            }
        }

    }
}