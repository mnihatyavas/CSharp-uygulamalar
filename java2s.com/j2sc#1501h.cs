// j2sc#1501h.cs: StreamWriter ve StreamReader'la dosya yaratma/yazma/okuma örneði.

using System;
using System.IO;
using System.Text; //StringBuilder için
//using System.Security.Permissions;
namespace DosyaDizin {
    //[assembly: IsolatedStorageFilePermission (SecurityAction.RequestMinimum, UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser)]
    class DosyaH {
        static void Main() {
            Console.Write ("StreamWriter'la her tip veri yazýlabilir, StreamReader'la da sr.ReadLine() veya Type.Parse (sr.ReadLine()) çevrimli okunabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StreamWriter ve StreamReader'la dosyalar yaratma/yazma/okuma:");
            FileStream fs; StreamWriter sw; StreamReader sr; int i, j; string satýr; var r=new Random();
            Console.WriteLine ("\t==>FileStream, StreamWriter ve StreamReader ile dosyaya yazma/okuma:");
            using (fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\nihat1.txt", FileMode.Create)) {
                using (sw = new StreamWriter (fs)) {
                    sw.WriteLine (20240507.042559M);
                    sw.WriteLine ("M.Nihat Yavaþ");
                    sw.WriteLine ('!');
                    sw.WriteLine (true);
                }
            }
            using (fs = new FileStream ("nihat1.txt", FileMode.Open)) {
                using (sr = new StreamReader (fs)) {
                    Console.WriteLine (Decimal.Parse (sr.ReadLine()));
                    Console.WriteLine (sr.ReadLine());
                    Console.WriteLine (Char.Parse (sr.ReadLine()));
                    Console.WriteLine (Boolean.Parse (sr.ReadLine()));
                }
            }
            Console.WriteLine ("\t==>while((satýr=sr.ReadLine()) != null) ile dosya okuma:");
            fs = new FileStream ("nihat1.txt", FileMode.Create);
            sw = new StreamWriter (fs);
            for(i=0;i<5;i++) {j=r.Next(1881,1939); sw.WriteLine ("{0}: {1}", "Atatürk", j);}
            sw.Close(); fs.Close();
            fs = new FileStream ("nihat1.txt", FileMode.Open);
            sr = new StreamReader (fs);
            while ((satýr=sr.ReadLine()) != null) {Console.WriteLine (satýr);}
            sr.Close(); fs.Close();
            Console.WriteLine ("\t==>while((i=sr.Read()) != -1) ile rakamlý dosya okuma");
            try {sw = new StreamWriter ("nihat1.txt"); //Create gibi yaratýr
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {for(i=1881;i<=1938;i++) sw.Write (i);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);} 
            sw.Close();
            try {sr = new StreamReader ("nihat1.txt");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {j=0; while((i=sr.Read()) != -1) {Console.Write ((char)i); if(++j%4==0) Console.Write (" ");} Console.WriteLine();
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);} 
            sr.Close();
            Console.WriteLine ("\t==>while((i=sr.Read()) != -1) ile harfli dosya okuma");
            sw = new StreamWriter ("nihat1.txt");
            for(i=0;i<26;i++) sw.Write ((char)(i+65));
            for(i=0;i<26;i++) sw.Write ((char)(i+97));
            sw.Close();
            sr = new StreamReader ("nihat1.txt");
            while((i=sr.Read()) != -1) Console.Write ((char)i); Console.WriteLine();
            sr.Close();
            Console.WriteLine ("\t==>satýr=sr.ReadToEnd() ile dosyayý komple okuma");
            sw = new StreamWriter ("nihat1.txt");
            for(i=0;i<10;i++) {j=r.Next(1881,1939); sw.WriteLine (j);}
            sw.Close();
            sr = new StreamReader ("nihat1.txt");
            satýr=sr.ReadToEnd();
            Console.Write (satýr);
            sr.Close();
            Console.WriteLine ("\t==>while((i=sr.Read()) != -1) ile ascii diziyi dosyaya yazma/okuma:");
            sw = new StreamWriter ("nihat1.txt");
            char[] ascii = new char [256];
            for(i=0;i<256;i++) ascii [i] = (char)i;
            sw.Write (ascii);
            sw.Close();
            sr = new StreamReader ("nihat1.txt");
            while((i=sr.Read()) != -1) Console.Write ((char)i); Console.WriteLine();
            sr.Close();
            Console.WriteLine ("\t==>A-->Z harfler ve 1-->12 rakam satýrlarý yazma/okuma:");
            using (sw = new StreamWriter ("nihat1.txt")) {
                for(char k='A';k<='Z';k++) sw.Write (k); sw.Write (sw.NewLine);
                for (i = 0; i <= 12; i++) sw.Write (i + " "); sw.Write (sw.NewLine);
            }
            using (sr = new StreamReader ("nihat1.txt")) {
                satýr = null;
                while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            }
            Console.WriteLine ("\t==>Dosyaya dizge, tarih, bool yazma/okuma:");
            fs = new FileStream ("nihat1.txt", FileMode.OpenOrCreate); //Sýfýr ebatla açar/yaratýr
            sw = new StreamWriter (fs);
            bool doðru = true;
            sw.WriteLine ("Herkese merhabalar.");
            sw.WriteLine ("Saat elan [{0}] ve herþey yolunda gibi.", DateTime.Now.ToLongTimeString());
            sw.Write ("Daha da iyisi,");
            sw.Write (" c#'ýn eðlendiriciliði {0}'dur.", doðru);
            sw.Close(); fs.Close();
            sr = new StreamReader ("nihat1.txt");
            satýr = null;
            while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            Console.WriteLine ("\t==>File.CreateText ile dosya yaratma ve yazma/okuma:");
            satýr="nihat2.txt";
            sw = File.CreateText (satýr);
            sw.WriteLine ("Dosyaya ÝLK yazma zamaný: " + DateTime.Now);
            if (File.Exists (satýr)) sw.WriteLine ("{0} dosyasý mevcuttur.", satýr);
            else sw.WriteLine ("{0} dosyasý NAmevcuttur.", satýr);
            sw.WriteLine ("Dosyaya SON yazma zamaný: " + DateTime.Now);
            sw.Close();
            sr = new StreamReader ("nihat2.txt");
            satýr = null;
            while ((satýr = sr.ReadLine()) != null) Console.WriteLine (satýr);
            Console.WriteLine ("\t==>StringWriter/Reader'la dizgeler yazma/okuma:");
            using (StringWriter yaz = new StringWriter()) {
                yaz.WriteLine ("Ahmet"); yaz.WriteLine ("Iþýk"); yaz.WriteLine ("Seyhan-ADANA");
                Console.WriteLine ("-> {0}", yaz.ToString());
                StringBuilder sb = yaz.GetStringBuilder();
                sb.Insert (0, "Hey!! ");
                Console.WriteLine ("-> {0}", sb.ToString());
                sb.Remove (0, "Hey!! ".Length); //sb yaz'ý etkiler
                Console.WriteLine ("-> {0}", sb.ToString());
                using (StringReader oku = new StringReader (yaz.ToString())) {
                    satýr = null;
                    while ((satýr = oku.ReadLine()) != null) Console.WriteLine (satýr);
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}