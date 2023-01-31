// jtpc#1402.cs: Dosyaya dizge satýrlarý yazma ve okuma örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class AkýþYazýcýOkuyucu {
        static void Main() {
            Console.Write ("FileStream/DosyaAkýþý ile açýlan dosyaya TextWriter mirascýsý olan StreamWriter ve TextReader türevi StreamReader ile tek krk yerine dizge (ay.Write/Read) yada satýr (ay.WriteLine/ReadLine) yazýlýp okunabilir. Dosya sonu kontrolu -1 deðil 'null'dur. Belirtilen kodlamada da yazabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream da1 = new FileStream ("C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1402.txt", FileMode.OpenOrCreate);
            StreamWriter ay = new StreamWriter (da1); string satýr1 = "Merhaba C#-";
            for (int i = 0; i < 5; i++) {satýr1 +=i; ay.WriteLine (satýr1);}
            ay.Close();
            da1.Close();
            Console.WriteLine ("'jtpc#1402.txt' metin dosyasýna 5 satýr yazýldý...\n");

            FileStream da2 = new FileStream ("C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1402.txt", FileMode.OpenOrCreate);
            StreamReader ao = new StreamReader (da2);
            string satýr2 = "";
            while ((satýr2 = ao.ReadLine()) != null) {Console.WriteLine ("Okunan satýr: [{0}], ", satýr2);}
            ao.Close();
            da2.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}