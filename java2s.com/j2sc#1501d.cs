// j2sc#1501d.cs: FileStream, StreamWriter, Read/Write ve Read/WriteByte örneði.

using System;
using System.IO;
namespace DosyaDizin {
    class DosyaD {
        static void Main() {
            Console.Write ("Dosya kipleri: FileMode.Open/Append/Truncate/CreateNew/Create/OpenOrCreate.\nDosya eriþimleri: FileAccess.Write/ReadWrite/Read.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli dosya kipi ve eriþimiyle metin dosyasý açma/kapama, yazma/okuma:");
            int i;
            try {using (FileStream fs1 = File.Open ("mny1.txt", FileMode.Open)){
                Console.WriteLine ("\t==>'mny1.txt' dosyasý, mevcuden, hatasýz açýldý.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Open kipinde açmak için 'mny1.txt' dosyasý bulunamadý.", ht.Message);}
            try {using (FileStream fs2 = File.Open ("mny2.txt", FileMode.Append, FileAccess.Write)) {
                Console.WriteLine ("\t==>'mny2.txt' dosyasý, namevcutsa yaratýlarak, Append/Write kipinde hatasýz açýldý.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Append kipinde 'mny2.txt' dosyasý açýlamadý.", ht.Message);}
            try {using (FileStream fs3 = File.Open ("mny3.txt", FileMode.Truncate, FileAccess.ReadWrite, FileShare.Read)) {
                Console.WriteLine ("\t==>'mny3.txt' dosyasý, mevcuden, Truncate/ReadWrite kipinde hatasýz açýldý.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Truncate kipinde açmak için 'mny3.txt' dosyasý bulunamadý.", ht.Message);}
            try {FileStream fs4 = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mny4.txt", FileMode.CreateNew, FileAccess.Write, FileShare.None); //Mevcutsa yeni yaratmaz, eskiyi býrakýr, hata verir
                StreamWriter sw4 = new StreamWriter (fs4);
                for(i=1881;i<=1938;i++) sw4.WriteLine (i);
                sw4.Close(); fs4.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyasý CreateNew/Write kipinde (yoksa yeniden) yaratýlýp [1881, 1938] yazýlýp kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.CreateNew kipinde 'mny4.txt' dosyasý yaratýlamadý.", ht.Message);}
            try {FileStream fs5 = new FileStream ("mny4.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                int bayt;
                while((bayt=fs5.ReadByte()) != -1) Console.Write ((char)bayt);
                fs5.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyasý Open/Read kipinde açýlýp [1881, 1938] okunup kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Open kipinde 'mny4.txt' dosyasý bulunamadý/açýlamadý.", ht.Message);}
/*          try {FileStream fs6 = new FileStream ("mny4.txt", FileMode.Create);
                int bayt;
                while((bayt=fs6.ReadByte()) != -1) Console.Write ((char)bayt);
                fs6.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyasý Create kipinde yeniden yaratýlýp okunacak verisiz kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Create kipinde 'mny4.txt' dosyasý yaratýlamadý.", ht.Message);}
*/
            Console.WriteLine ("\nRead/Write tampon diziyle, Read/WriteByte bayt'la okur/yazar:");
            try {FileStream fsOku = File.OpenRead ("mny4.txt");
                FileStream fsYaz1 = File.OpenWrite ("mny5.txt");
                FileStream fsYaz2 = File.OpenWrite ("mny5.bak");
                int byt;
                while ((byt = fsOku.ReadByte()) != -1) {fsYaz1.WriteByte ((byte)byt); fsYaz2.WriteByte ((byte)byt); Console.Write ((char)byt);}
                fsYaz1.Flush(); fsYaz2.Flush();
                fsYaz1.Close(); fsYaz2.Close();
                fsOku.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyasý File.OpenRead kipinde okunup, 'mny5.txt', 'mny5.bak' dosyalarýna ve ekrana yazýlýp kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFile.OpenRead/Write kipinde 'mny4.txt' dosyasý okunup/yazýlamadý.", ht.Message);}
            try {FileStream fsOku = File.OpenRead ("mny4.txt");
                FileStream fsYaz1 = File.OpenWrite ("mny5.txt");
                FileStream fsYaz2 = File.OpenWrite ("mny5.bak");
                byte[] tampon=new byte [4096];
                int byt;
                while ((byt = fsOku.Read (tampon, 0, 4096)) > 0) {
                    fsYaz1.Write (tampon, 0, byt);
                    fsYaz2.Write (tampon, 0, byt);
                    for(i=0;i<byt;i++) Console.Write ((char)tampon [i]);
                }
                fsYaz1.Flush(); fsYaz2.Flush();
                fsYaz1.Close(); fsYaz2.Close();
                fsOku.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyasý File.OpenRead kipinde tampon'la okunup, 'mny5.txt', 'mny5.bak' dosyalarýna ve ekrana yazýlýp kapatýldý.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFile.OpenRead/Write kipinde 'mny4.txt' dosyasý okunup/yazýlamadý.", ht.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}