// j2sc#1501d.cs: FileStream, StreamWriter, Read/Write ve Read/WriteByte �rne�i.

using System;
using System.IO;
namespace DosyaDizin {
    class DosyaD {
        static void Main() {
            Console.Write ("Dosya kipleri: FileMode.Open/Append/Truncate/CreateNew/Create/OpenOrCreate.\nDosya eri�imleri: FileAccess.Write/ReadWrite/Read.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli dosya kipi ve eri�imiyle metin dosyas� a�ma/kapama, yazma/okuma:");
            int i;
            try {using (FileStream fs1 = File.Open ("mny1.txt", FileMode.Open)){
                Console.WriteLine ("\t==>'mny1.txt' dosyas�, mevcuden, hatas�z a��ld�.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Open kipinde a�mak i�in 'mny1.txt' dosyas� bulunamad�.", ht.Message);}
            try {using (FileStream fs2 = File.Open ("mny2.txt", FileMode.Append, FileAccess.Write)) {
                Console.WriteLine ("\t==>'mny2.txt' dosyas�, namevcutsa yarat�larak, Append/Write kipinde hatas�z a��ld�.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Append kipinde 'mny2.txt' dosyas� a��lamad�.", ht.Message);}
            try {using (FileStream fs3 = File.Open ("mny3.txt", FileMode.Truncate, FileAccess.ReadWrite, FileShare.Read)) {
                Console.WriteLine ("\t==>'mny3.txt' dosyas�, mevcuden, Truncate/ReadWrite kipinde hatas�z a��ld�.");}
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Truncate kipinde a�mak i�in 'mny3.txt' dosyas� bulunamad�.", ht.Message);}
            try {FileStream fs4 = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mny4.txt", FileMode.CreateNew, FileAccess.Write, FileShare.None); //Mevcutsa yeni yaratmaz, eskiyi b�rak�r, hata verir
                StreamWriter sw4 = new StreamWriter (fs4);
                for(i=1881;i<=1938;i++) sw4.WriteLine (i);
                sw4.Close(); fs4.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyas� CreateNew/Write kipinde (yoksa yeniden) yarat�l�p [1881, 1938] yaz�l�p kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.CreateNew kipinde 'mny4.txt' dosyas� yarat�lamad�.", ht.Message);}
            try {FileStream fs5 = new FileStream ("mny4.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                int bayt;
                while((bayt=fs5.ReadByte()) != -1) Console.Write ((char)bayt);
                fs5.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyas� Open/Read kipinde a��l�p [1881, 1938] okunup kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Open kipinde 'mny4.txt' dosyas� bulunamad�/a��lamad�.", ht.Message);}
/*          try {FileStream fs6 = new FileStream ("mny4.txt", FileMode.Create);
                int bayt;
                while((bayt=fs6.ReadByte()) != -1) Console.Write ((char)bayt);
                fs6.Close();
                Console.WriteLine ("\t==>'mny4.txt' dosyas� Create kipinde yeniden yarat�l�p okunacak verisiz kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFileMode.Create kipinde 'mny4.txt' dosyas� yarat�lamad�.", ht.Message);}
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
                Console.WriteLine ("\t==>'mny4.txt' dosyas� File.OpenRead kipinde okunup, 'mny5.txt', 'mny5.bak' dosyalar�na ve ekrana yaz�l�p kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFile.OpenRead/Write kipinde 'mny4.txt' dosyas� okunup/yaz�lamad�.", ht.Message);}
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
                Console.WriteLine ("\t==>'mny4.txt' dosyas� File.OpenRead kipinde tampon'la okunup, 'mny5.txt', 'mny5.bak' dosyalar�na ve ekrana yaz�l�p kapat�ld�.");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]\nFile.OpenRead/Write kipinde 'mny4.txt' dosyas� okunup/yaz�lamad�.", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}