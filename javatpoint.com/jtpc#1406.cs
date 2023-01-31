// jtpc#1406.cs: FileInfo'yla metin dosyasý yaratma, yazma, okuma ve silme örneði.

using System;
using System.IO;
namespace DosyaGÇ {
    class DosyaBilgi {
        static void Main() {
            Console.Write ("Disk dosyasý yaratýr, siler, StreamWriter/Reader ile dizgesel kayýtlar yazar ve okur.\nKurucusu: FileInfo(String)\nÖzellikleri: Attributes, CreationTime, Directory, Exists, FullName, IsReadOnly, LastAccessTime, Length, Name\nMetodlarý: AppendText(), CopyTo(String), Create(), CreateText(), Decrypt(), Delete(), Encrypt(), GetAccessControl(), MoveTo(String), OpenRead(), OpenText(), OpenWrite(), Refresh(), Replace(String,String), ToString()\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                string yolluAd = "C:/Users/nihet/Desktop/MyFiles/3. Dersler/c#/jtpc#1406a.txt"; //Yollu dosya adý
                FileInfo dosya1 = new FileInfo (yolluAd);
                //dosya1.Create(); //Ýçi boþ metin disk dosyasý yaratýlýr
                StreamWriter sw=dosya1.CreateText(); sw.Close(); //Ýçi boþ metin disk dosyasý yaratýr ve kapar
                Console.WriteLine ("[{0}] dosyasý sorunsuz yaratýldý", yolluAd);

                string ad = "jtpc#1406b.txt";
                FileInfo dosya2 = new FileInfo (ad);
                StreamWriter ay = dosya2.AppendText(); //Her çalýþtýrýþta öncekilere ekler
                ay.WriteLine ("Bu metin, [{0}] dosyasýna StreamWriter sýnýfýyla eklendi.", ad);
                ay.WriteLine ("Dosya kapatýlýp, sonrasýnda StreamReader'la okunup, yansýtýlacak.");
                ay.Close();
                Console.WriteLine ("\n[{0}] dosyasýna kayýtlar eklendi ve kapatýldý", ad);

                Console.WriteLine ("\n[{0}] dosyasýndaki kayýtlar dökümleniyor", ad);
                StreamReader ao = dosya2.OpenText();
                string kayýt = ""; int i = 0;
                while ((kayýt = ao.ReadLine()) != null) {Console.WriteLine ("{0}.kayýt: [{1}]", ++i, kayýt);}
                ao.Close();
                //dosya1.Delete(); dosya2.Delete(); //Arasýra silebilirsiniz
            }catch (IOException hata) {Console.WriteLine ("HATA: [{0}]", hata);} //Hatalý dizin adý girip test et

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}