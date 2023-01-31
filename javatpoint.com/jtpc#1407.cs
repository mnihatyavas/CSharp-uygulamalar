// jtpc#1407.cs: DirectoryInfo'yla yeni dizin yaratma, ta��ma ve silme �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class DizinBilgi {
        static void Main() {
            Console.Write ("Dizinler yarat�r, ta��r ve siler. M�h�rl� oldu�undan miraslanamaz.\nKurucusu: DirectoryInfo(String)\n�zellikleri: Attributes, CreationTime, CreationTimeUtc, Exists, Extension, FullName, LastAccessTime, LastAccessTimeUtc, LastWriteTime, LastWriteTimeUtc, Name, Parent, Parent, Root\nMetodlar�: Create(), Create(DirectorySecurity), CreateObjRef(Type), CreateSubdirectory(String), CreateSubdirectory(String,DirectorySecurity), Delete(), Delete(Boolean), EnumerateDirectories(), EnumerateFiles(), GetAccessControl(), GetDirectories(), GetFiles(), GetType(), MoveTo(String), Refresh(), SetAccessControl(DirectorySecurity), ToString()\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            DirectoryInfo dizin = new DirectoryInfo (@"C:/Users/nihet/Desktop/MyFiles/3. Dersler/javatpoint"); //Yollu dizin ad�
            try {
                if (dizin.Exists) {Console.WriteLine ("[{0}] dizini �nceden yarat�lm��.", dizin); goto son;}
                dizin.Create(); //Namevcutsa yarat�l�r
                Console.WriteLine ("[{0}] dizini sorunsuz yarat�ld�.", dizin);

                son: Console.Write ("\nDizin silinsin mi? [e/h]: ");
                char cevap = Convert.ToChar (Console.ReadLine());
                if (cevap == 'e') {dizin.Delete(); Console.WriteLine ("[{0}] dizini silindi.", dizin);}
            }catch (Exception hata) {Console.WriteLine ("\nHATA: {0}", hata.ToString());}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}