// j2sc#1501i.cs: Stram,FileStream, FileInfo, File, StreamWriter ve StreamReader �rne�i.

using System;
using System.IO;
using System.Text; //StringBuilder i�in
namespace DosyaDizin {
    class Dosya� {
        static void Main() {
            Console.Write ("Do�rudan FileStream'le dosya yaz�l�p okunabildi�i gibi StreamWriter ve StreamReader yaz�c�/okuyucu olabilir. T�m dosya File.WriteAllLines ile yaz�l�p File.ReadAllLines'la da okunabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("j2sc#1501i.cs dosyas�n�n ilk 10 sat�r�n� okuma:");
            StreamReader sr; StreamWriter sw; string sat�r=null; int i=0, j=0;
            try {sr = File.OpenText (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1501i.cs");
                while (null != (sat�r = sr.ReadLine())) if(++i > 10) break; else Console.WriteLine (sat�r);
                sr.Close();
            }catch (Exception ist) {Console.WriteLine ("HATA: [{0}]", ist.Message);}

            Console.WriteLine ("\nnihat1.txt dosyaya A-->Z, a-->z ve 0-->9 yazama/okuma:");
            FileStream fs=null;
            try {fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt", FileMode.Create); //Yeniden dosyay� yarat�r
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {for(char k = 'A'; k <= 'Z'; k++) fs.WriteByte ((byte) k);
                for(char k = 'a'; k <= 'z'; k++) fs.WriteByte ((byte) k);
                for(char k = '0'; k <= '9'; k++) fs.WriteByte ((byte) k);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            fs.Close();
            try {fs = new FileStream ("nihat1.txt", FileMode.Open); //Mevcut dosyay� a�ar
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            do { 
                try {i = fs.ReadByte();
                }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
                if (i != -1) Console.Write ((char) i); if(++j%26==0) Console.Write (" ");
            }while (i != -1); Console.WriteLine();
            fs.Close();

            Console.WriteLine ("\nDosyaya dizgeler ve rakamlar yaz�p/okuma:");
            FileInfo fi = new FileInfo ("nihat1.txt");
            sw = fi.CreateText();
            sw.WriteLine ("M.Kemal Atat�rk");
            sw.WriteLine ("Samsun, 19 May�s 1919");
            for(i = 1881; i <=1938; i++) sw.Write (i + " ");
            sw.Write (sw.NewLine);
            sw.Close();
            sr = File.OpenText ("nihat1.txt");
            while ((sat�r = sr.ReadLine()) != null) Console.WriteLine (sat�r);
            sr.Close();

            Console.WriteLine ("\nStringWriter, StringBuilder ve StringReader'la dizgeye yazma/okuma:");
            StringWriter yaz = new StringWriter();
            yaz.WriteLine ("M.Kemal Atat�rk");
            for(i = 1881; i <= 1938; i++) yaz.Write (i + " "); yaz.Write (yaz.NewLine);
            yaz.WriteLine ("Samsun, 19 May�s 1919");
            yaz.Close();
            Console.WriteLine ("\t==>StringWriter i�eri�i:\n{0}", yaz);
            StringBuilder sb = yaz.GetStringBuilder();
            sat�r = sb.ToString();
            Console.WriteLine ("\t-->StringBuilder i�eri�i:\n{0}", sat�r);
            sb.Insert (50, "[50.KONUMA G�R�LEN]");
            sat�r = sb.ToString();
            Console.WriteLine ("\t==>StringBuilder i�eri�i:\n{0}", sat�r);
            StringReader oku = new StringReader (yaz.ToString());
            Console.WriteLine ("\t==>StringReader i�eri�i:");
            while ((sat�r = oku.ReadLine()) != null) Console.WriteLine (sat�r);
            oku.Close();

            Console.WriteLine ("\nFileStream, StreamWriter ve StreamReader'la dosyaya yazma/okuma:");
            fs = File.Create ("nihat1.txt");
            sw = new StreamWriter (fs);
            sw.WriteLine ("M.Kemal Atat�k, Selanik 1881");
            sw.WriteLine ("Samsun, 19 May�s 1919");
            sw.WriteLine ("Ankara, 23 Nisan 1920, TBMM");
            sw.WriteLine ("Ankara, 29 Ekim 1923, Cumhuriyet");
            sw.WriteLine ("�stanbul, 10 Kas�m 1938");
            sw.Flush(); sw.Close();
            sr = new StreamReader ("nihat1.txt");
            while ((sat�r = sr.ReadLine()) != null) Console.WriteLine (sat�r);
            sr.Close();

            Console.WriteLine ("\nStream'e tek ve dizi byte yazma/okuma:");
            using (Stream s = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt", FileMode.Create)) {
                Console.WriteLine ("Okunabilir mi? {0}", s.CanRead); // true
                Console.WriteLine ("Yaz�labilir mi? {0}", s.CanWrite); // true
                Console.WriteLine ("Aranabilir mi? {0}", s.CanSeek); // true
                s.WriteByte (65);
                s.WriteByte (66);
                byte[] dizi = {97, 98, 99, 100, 101};
                s.Write (dizi, 0, dizi.Length);
                Console.WriteLine ("nihat1.text'in ebat�: {0} Byte", s.Length);
                Console.WriteLine ("Dosya konumu: {0}", s.Position);
                s.Position = 0; //Konumu ba�a al
                Console.WriteLine ("Okunan 1.byte: {0}", (char)s.ReadByte());
                Console.WriteLine ("Okunan 2.byte: {0}", (char)s.ReadByte());
                Console.WriteLine ("Okunan dizi ebat�: {0}", s.Read (dizi, 0, dizi.Length));
                for(i=0;i<dizi.Length;i++) Console.Write ((char)dizi [i]+" "); Console.WriteLine();
                Console.WriteLine ("Tekrar okunan dizi ebat�: {0}", s.Read (dizi, 0, dizi.Length));
                s.Close();
            }

            Console.WriteLine ("\nj2sc#1501i.cs kaynak dosyan�n .bak yede�ini kopyalama:");
            fi = new FileInfo ("j2sc#1501i.cs");
            sr = fi.OpenText();
            sw = new StreamWriter ("j2sc#1501i.bak", false);
            do {sat�r = sr.ReadLine();
                sw.WriteLine (sat�r);
                //Console.WriteLine (sat�r);
            } while (sat�r != null);
            sr.Close(); sw.Close();
            Console.WriteLine ("...j2sc#1501i.bak yedek dosya kopyaland�.");

            Console.WriteLine ("\nnihat1.txt dosyaya File.Write/ReadAllLines ile adlar yazma/okuma:");
            string[] adlar = {"Sevim Yava�", "Y�cel K���kbay", "Fatih �zbay","Zafer N.Candan", "Atilla G�kyi�it"};
            File.WriteAllLines (@"nihat1.txt", adlar);
            foreach (string ad in File.ReadAllLines (@"nihat1.txt")) Console.WriteLine (ad);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}