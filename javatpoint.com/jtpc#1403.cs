// jtpc#1403.cs: Dosyaya metin satýrlarý yazma ve okuma örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class MetinYazýcýOkuyucu {
        static void Main() {
            Console.Write ("TextWriter ve TextReader (MetinYazýcý/Okuyucu) baþka akýþ gerekmeden my.WriteLine ve mo.ReadLine/mo.ReadToEnd ile dosyaya yazýp okuyabilmektedir. Dosya adý önünde yol belirtilmezse aktüel dizinde yaratýlýr. Tipleme new ile deðil File.CreateText/OpenText ile yapýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string satýr = "Merhaba C#-";
            using (TextWriter my = File.CreateText ("jtpc#1403.txt") ) {
                for (int i = 0; i < 10; i++) {satýr +=i; my.WriteLine (satýr);}
            }
            Console.WriteLine ("'jtpc#1403.txt' metin dosyasýna 10 satýr yazýldý...\n");

            using (TextReader mo = File.OpenText ("jtpc#1403.txt") ) {// Otomatik dosyasonu kontrolu çalýþýr
                Console.WriteLine (mo.ReadLine()); // Tek seferde sadece ardýþýk tek satýr okur
                Console.WriteLine (mo.ReadLine());
                Console.WriteLine (mo.ReadLine());
                Console.WriteLine (mo.ReadToEnd()); // Tek seferde tüm metni kalandan-sona okur
            }

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}