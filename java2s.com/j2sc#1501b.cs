// j2sc#1501b.cs: CopyTo/kopyala, MoveTo/taþý, Hash-no'larý kýyasla örneði.

using System;
using System.IO;
using System.Security.Cryptography; //HashAlgorithm için
namespace DosyaDizin {
    class DosyaB {
        static void Main() {
            Console.Write ("Ýlk 'null' atamasýz 'dosyaOku/yaz' sonraki try-catch {}blokiçi atamalarý görmeyip derleme hatasý vermekte. Yaratýlan dosya MoveTo/taþýnmadan önce Close/kapanýþ gerektirmekte.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ReadByte() ve WriteByte() ile orijinal dosyanýn kopyasýný türetme:");
            int i;
            FileStream dosyaOku=null; FileStream dosyaYaz=null;
            try {dosyaOku = new FileStream ("j2sc#1501b.cs", FileMode.Open);
            }catch (FileNotFoundException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {dosyaYaz = new FileStream ("kopya1.cs", FileMode.Create);
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);} 
            try {do {
                    i = dosyaOku.ReadByte();
                    if (i != -1) dosyaYaz.WriteByte ((byte)i);
                }while (i != -1);
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);} 
            dosyaOku.Close(); dosyaYaz.Close();
            Console.WriteLine ("Kopya j2sc#1501b.cs==>kopya1.cs iþlemi tamamlandý...");

            Console.WriteLine ("\nRead() ve Write() ile orijinal dosyanýn kopyasýný türetme:");
            using (Stream kaynak = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501b.cs", FileMode.Open)) {
                using (Stream hedef = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\kopya2.cs", FileMode.OpenOrCreate)) {
                    int okunan;
                    byte[] tampon = new byte [1024];
                    while ((okunan = kaynak.Read (tampon, 0, 1024)) != 0) hedef.Write (tampon, 0, okunan);
                }
            }
            Console.WriteLine ("Kopya j2sc#1501b.cs==>kopya2.cs iþlemi tamamlandý...");

            Console.WriteLine ("\nCopyTo() ile orijinal dosyanýn kopyasýný türetme:");
            FileInfo fi1 = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501b.cs");
            fi1.CopyTo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\kopya3.cs", true); //true, varsa önceki kopya3.cs'yi yeniden yaratýr
            fi1.CopyTo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\resim\j2sc#1501b.cs", true);
            Console.WriteLine ("Kopya j2sc#1501b.cs==>(kopya3.cs ve resim\\j2sc#1501b.cs) iþlemi tamamlandý...");

            Console.WriteLine ("\nYaratýlan 'mny1.txt' dosyasýný baþka klasöre taþýma:");
            fi1 = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\mny1.txt");
            FileStream akþ=new FileStream (fi1.ToString(), FileMode.OpenOrCreate); akþ.Close(); //Dosya baþka türlü kapanmýyor.
            Console.Write ("\n'mny1.txt' taþýnacak. Tuþ..."); Console.ReadKey();
            //fi1.MoveTo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\resim\mny1.txt");
            //fi1.MoveTo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\resim\mny2.txt");
            Console.WriteLine ("Taþý 'mny1.txt==>\\resim' iþlemi tamamlandý...");

            Console.WriteLine ("\nÝçerikleri ayný olan 'kopya1.cs == kopya2.cs?' kontrolu:");
            using (HashAlgorithm ha = HashAlgorithm.Create()) {
                using (
                    FileStream fs1 = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\kopya1.cs", FileMode.Open),
                    fs2 = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\kopya2.cs", FileMode.Open) ) {
                    byte[] hByte1 = ha.ComputeHash (fs1);
                    byte[] hByte2 = ha.ComputeHash (fs2);
                    if (BitConverter.ToString (hByte1) == BitConverter.ToString (hByte2)) Console.WriteLine ("kopya1.cs == kopya2.cs");
                    else Console.WriteLine ("kopya1.cs[{0}] != kopya2.cs[{1}]", BitConverter.ToString (hByte1), BitConverter.ToString (hByte2));
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}