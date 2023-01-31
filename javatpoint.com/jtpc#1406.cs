// jtpc#1406.cs: FileInfo'yla metin dosyas� yaratma, yazma, okuma ve silme �rne�i.

using System;
using System.IO;
namespace DosyaG� {
    class DosyaBilgi {
        static void Main() {
            Console.Write ("Disk dosyas� yarat�r, siler, StreamWriter/Reader ile dizgesel kay�tlar yazar ve okur.\nKurucusu: FileInfo(String)\n�zellikleri: Attributes, CreationTime, Directory, Exists, FullName, IsReadOnly, LastAccessTime, Length, Name\nMetodlar�: AppendText(), CopyTo(String), Create(), CreateText(), Decrypt(), Delete(), Encrypt(), GetAccessControl(), MoveTo(String), OpenRead(), OpenText(), OpenWrite(), Refresh(), Replace(String,String), ToString()\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                string yolluAd = "C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1406a.txt"; //Yollu dosya ad�
                FileInfo dosya1 = new FileInfo (yolluAd);
                //dosya1.Create(); //��i bo� metin disk dosyas� yarat�l�r
                StreamWriter sw=dosya1.CreateText(); sw.Close(); //��i bo� metin disk dosyas� yarat�r ve kapar
                Console.WriteLine ("[{0}] dosyas� sorunsuz yarat�ld�", yolluAd);

                string ad = "jtpc#1406b.txt";
                FileInfo dosya2 = new FileInfo (ad);
                StreamWriter ay = dosya2.AppendText(); //Her �al��t�r��ta �ncekilere ekler
                ay.WriteLine ("Bu metin, [{0}] dosyas�na StreamWriter s�n�f�yla eklendi.", ad);
                ay.WriteLine ("Dosya kapat�l�p, sonras�nda StreamReader'la okunup, yans�t�lacak.");
                ay.Close();
                Console.WriteLine ("\n[{0}] dosyas�na kay�tlar eklendi ve kapat�ld�", ad);

                Console.WriteLine ("\n[{0}] dosyas�ndaki kay�tlar d�k�mleniyor", ad);
                StreamReader ao = dosya2.OpenText();
                string kay�t = ""; int i = 0;
                while ((kay�t = ao.ReadLine()) != null) {Console.WriteLine ("{0}.kay�t: [{1}]", ++i, kay�t);}
                ao.Close();
                //dosya1.Delete(); dosya2.Delete(); //Aras�ra silebilirsiniz
            }catch (IOException hata) {Console.WriteLine ("HATA: [{0}]", hata);} //Hatal� dizin ad� girip test et

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}