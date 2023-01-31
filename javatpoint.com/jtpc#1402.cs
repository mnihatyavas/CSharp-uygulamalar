// jtpc#1402.cs: Dosyaya dizge sat�rlar� yazma ve okuma �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class Ak��Yaz�c�Okuyucu {
        static void Main() {
            Console.Write ("FileStream/DosyaAk��� ile a��lan dosyaya TextWriter mirasc�s� olan StreamWriter ve TextReader t�revi StreamReader ile tek krk yerine dizge (ay.Write/Read) yada sat�r (ay.WriteLine/ReadLine) yaz�l�p okunabilir. Dosya sonu kontrolu -1 de�il 'null'dur. Belirtilen kodlamada da yazabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            FileStream da1 = new FileStream ("C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1402.txt", FileMode.OpenOrCreate);
            StreamWriter ay = new StreamWriter (da1); string sat�r1 = "Merhaba C#-";
            for (int i = 0; i < 5; i++) {sat�r1 +=i; ay.WriteLine (sat�r1);}
            ay.Close();
            da1.Close();
            Console.WriteLine ("'jtpc#1402.txt' metin dosyas�na 5 sat�r yaz�ld�...\n");

            FileStream da2 = new FileStream ("C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1402.txt", FileMode.OpenOrCreate);
            StreamReader ao = new StreamReader (da2);
            string sat�r2 = "";
            while ((sat�r2 = ao.ReadLine()) != null) {Console.WriteLine ("Okunan sat�r: [{0}], ", sat�r2);}
            ao.Close();
            da2.Close();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}