// jtpc#1403.cs: Dosyaya metin sat�rlar� yazma ve okuma �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class MetinYaz�c�Okuyucu {
        static void Main() {
            Console.Write ("TextWriter ve TextReader (MetinYaz�c�/Okuyucu) ba�ka ak�� gerekmeden my.WriteLine ve mo.ReadLine/mo.ReadToEnd ile dosyaya yaz�p okuyabilmektedir. Dosya ad� �n�nde yol belirtilmezse akt�el dizinde yarat�l�r. Tipleme new ile de�il File.CreateText/OpenText ile yap�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string sat�r = "Merhaba C#-";
            using (TextWriter my = File.CreateText ("jtpc#1403.txt") ) {
                for (int i = 0; i < 10; i++) {sat�r +=i; my.WriteLine (sat�r);}
            }
            Console.WriteLine ("'jtpc#1403.txt' metin dosyas�na 10 sat�r yaz�ld�...\n");

            using (TextReader mo = File.OpenText ("jtpc#1403.txt") ) {// Otomatik dosyasonu kontrolu �al���r
                Console.WriteLine (mo.ReadLine()); // Tek seferde sadece ard���k tek sat�r okur
                Console.WriteLine (mo.ReadLine());
                Console.WriteLine (mo.ReadLine());
                Console.WriteLine (mo.ReadToEnd()); // Tek seferde t�m metni kalandan-sona okur
            }

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}