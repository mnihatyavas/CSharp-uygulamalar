// j2sc#1501i.cs: Stram,FileStream, FileInfo, File, StreamWriter ve StreamReader örneði.

using System;
using System.IO;
using System.Text; //StringBuilder için
namespace DosyaDizin {
    class DosyaÝ {
        static void Main() {
            Console.Write ("Doðrudan FileStream'le dosya yazýlýp okunabildiði gibi StreamWriter ve StreamReader yazýcý/okuyucu olabilir. Tüm dosya File.WriteAllLines ile yazýlýp File.ReadAllLines'la da okunabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("j2sc#1501i.cs dosyasýnýn ilk 10 satýrýný okuma:");
            StreamReader sr; StreamWriter sw; string satýr=null; int i=0, j=0;
            try {sr = File.OpenText (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501i.cs");
                while (null != (satýr = sr.ReadLine())) if(++i > 10) break; else Console.WriteLine (satýr);
                sr.Close();
            }catch (Exception ist) {Console.WriteLine ("HATA: [{0}]", ist.Message);}

            Console.WriteLine ("\nnihat1.txt dosyaya A-->Z, a-->z ve 0-->9 yazama/okuma:");
            FileStream fs=null;
            try {fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt", FileMode.Create); //Yeniden dosyayý yaratýr
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {for(char k = 'A'; k <= 'Z'; k++) fs.WriteByte ((byte) k);
                for(char k = 'a'; k <= 'z'; k++) fs.WriteByte ((byte) k);
                for(char k = '0'; k <= '9'; k++) fs.WriteByte ((byte) k);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            fs.Close();
            try {fs = new FileStream ("nihat1.txt", FileMode.Open); //Mevcut dosyayý açar
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            do { 
                try {i = fs.ReadByte();
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
                if (i != -1) Console.Write ((char) i); if(++j%26==0) Console.Write (" ");
            }while (i != -1); Console.WriteLine();
            fs.Close();

            Console.WriteLine ("\nDosyaya dizgeler ve rakamlar yazýp/okuma:");
            FileInfo fi = new FileInfo ("nihat1.txt");
            sw = fi.CreateText();
            sw.WriteLine ("M.Kemal Atatürk");
            sw.WriteLine ("Samsun, 19 Mayýs 1919");
            for(i = 1881; i <=1938; i++) sw.Write (i + " ");
            sw.Write (sw.NewLine);
            sw.Close();
            sr = File.OpenText ("nihat1.txt");
            while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            sr.Close();

            Console.WriteLine ("\nStringWriter, StringBuilder ve StringReader'la dizgeye yazma/okuma:");
            StringWriter yaz = new StringWriter();
            yaz.WriteLine ("M.Kemal Atatürk");
            for(i = 1881; i <= 1938; i++) yaz.Write (i + " "); yaz.Write (yaz.NewLine);
            yaz.WriteLine ("Samsun, 19 Mayýs 1919");
            yaz.Close();
            Console.WriteLine ("\t==>StringWriter içeriði:\n{0}", yaz);
            StringBuilder sb = yaz.GetStringBuilder();
            satýr = sb.ToString();
            Console.WriteLine ("\t-->StringBuilder içeriði:\n{0}", satýr);
            sb.Insert (50, "[50.KONUMA GÝRÝLEN]");
            satýr = sb.ToString();
            Console.WriteLine ("\t==>StringBuilder içeriði:\n{0}", satýr);
            StringReader oku = new StringReader (yaz.ToString());
            Console.WriteLine ("\t==>StringReader içeriði:");
            while ((satýr = oku.ReadLine()) != null) Console.WriteLine (satýr);
            oku.Close();

            Console.WriteLine ("\nFileStream, StreamWriter ve StreamReader'la dosyaya yazma/okuma:");
            fs = File.Create ("nihat1.txt");
            sw = new StreamWriter (fs);
            sw.WriteLine ("M.Kemal Atatük, Selanik 1881");
            sw.WriteLine ("Samsun, 19 Mayýs 1919");
            sw.WriteLine ("Ankara, 23 Nisan 1920, TBMM");
            sw.WriteLine ("Ankara, 29 Ekim 1923, Cumhuriyet");
            sw.WriteLine ("Ýstanbul, 10 Kasým 1938");
            sw.Flush(); sw.Close();
            sr = new StreamReader ("nihat1.txt");
            while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            sr.Close();

            Console.WriteLine ("\nStream'e tek ve dizi byte yazma/okuma:");
            using (Stream s = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt", FileMode.Create)) {
                Console.WriteLine ("Okunabilir mi? {0}", s.CanRead); // true
                Console.WriteLine ("Yazýlabilir mi? {0}", s.CanWrite); // true
                Console.WriteLine ("Aranabilir mi? {0}", s.CanSeek); // true
                s.WriteByte (65);
                s.WriteByte (66);
                byte[] dizi = {97, 98, 99, 100, 101};
                s.Write (dizi, 0, dizi.Length);
                Console.WriteLine ("nihat1.text'in ebatý: {0} Byte", s.Length);
                Console.WriteLine ("Dosya konumu: {0}", s.Position);
                s.Position = 0; //Konumu baþa al
                Console.WriteLine ("Okunan 1.byte: {0}", (char)s.ReadByte());
                Console.WriteLine ("Okunan 2.byte: {0}", (char)s.ReadByte());
                Console.WriteLine ("Okunan dizi ebatý: {0}", s.Read (dizi, 0, dizi.Length));
                for(i=0;i<dizi.Length;i++) Console.Write ((char)dizi [i]+" "); Console.WriteLine();
                Console.WriteLine ("Tekrar okunan dizi ebatý: {0}", s.Read (dizi, 0, dizi.Length));
                s.Close();
            }

            Console.WriteLine ("\nj2sc#1501i.cs kaynak dosyanýn .bak yedeðini kopyalama:");
            fi = new FileInfo ("j2sc#1501i.cs");
            sr = fi.OpenText();
            sw = new StreamWriter ("j2sc#1501i.bak", false);
            do {satýr = sr.ReadLine();
                sw.WriteLine (satýr);
                //Console.WriteLine (satýr);
            } while (satýr != null);
            sr.Close(); sw.Close();
            Console.WriteLine ("...j2sc#1501i.bak yedek dosya kopyalandý.");

            Console.WriteLine ("\nnihat1.txt dosyaya File.Write/ReadAllLines ile adlar yazma/okuma:");
            string[] adlar = {"Sevim Yavaþ", "Yücel Küçükbay", "Fatih Özbay","Zafer N.Candan", "Atilla Gökyiðit"};
            File.WriteAllLines (@"nihat1.txt", adlar);
            foreach (string ad in File.ReadAllLines (@"nihat1.txt")) Console.WriteLine (ad);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}