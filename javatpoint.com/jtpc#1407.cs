// jtpc#1407.cs: DirectoryInfo'yla yeni dizin yaratma, taþýma ve silme örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class DizinBilgi {
        static void Main() {
            Console.Write ("Dizinler yaratýr, taþýr ve siler. Mühürlü olduðundan miraslanamaz.\nKurucusu: DirectoryInfo(String)\nÖzellikleri: Attributes, CreationTime, CreationTimeUtc, Exists, Extension, FullName, LastAccessTime, LastAccessTimeUtc, LastWriteTime, LastWriteTimeUtc, Name, Parent, Parent, Root\nMetodlarý: Create(), Create(DirectorySecurity), CreateObjRef(Type), CreateSubdirectory(String), CreateSubdirectory(String,DirectorySecurity), Delete(), Delete(Boolean), EnumerateDirectories(), EnumerateFiles(), GetAccessControl(), GetDirectories(), GetFiles(), GetType(), MoveTo(String), Refresh(), SetAccessControl(DirectorySecurity), ToString()\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            DirectoryInfo dizin = new DirectoryInfo (@"C:/Users/nihet/Desktop/MyFiles/3. Dersler/javatpoint"); //Yollu dizin adý
            try {
                if (dizin.Exists) {Console.WriteLine ("[{0}] dizini önceden yaratýlmýþ.", dizin); goto son;}
                dizin.Create(); //Namevcutsa yaratýlýr
                Console.WriteLine ("[{0}] dizini sorunsuz yaratýldý.", dizin);

                son: Console.Write ("\nDizin silinsin mi? [e/h]: ");
                char cevap = Convert.ToChar (Console.ReadLine());
                if (cevap == 'e') {dizin.Delete(); Console.WriteLine ("[{0}] dizini silindi.", dizin);}
            }catch (Exception hata) {Console.WriteLine ("\nHATA: {0}", hata.ToString());}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}