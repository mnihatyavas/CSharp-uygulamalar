// j2sc#1501a.cs: OpenFileDialog, File.Read/WriteAllLines, Create ve Delete örneði.

using System;
using System.Windows.Forms; //OpenFileDialog ve DialogResult için
using System.IO; //File için
namespace DosyaDizin {
    class DosyaA {
        [STAThread] //Main() önünde bu vasýf olmadan OpenFileDialog diyalog menüsü açýlmaz
        static void Main() {
            Console.Write ("System.IO sýnýf tipleri: BinaryReader, BinaryWriter, BufferedStream, Directory, DirectoryInfo, DriveInfo, File, FileInfo, FileStream, FileSystemWatcher, MemoryStream, Path, StreamReader, StreamWriter, StringReader, StringWriter.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("OpenFileDialog'la açýlacak dosya seçimi:");
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                string dosya = ofd.FileName;
                Console.WriteLine ("Dosya adý: " + dosya);
                Console.WriteLine ("Yaratýlma tarihi: " + File.GetCreationTime (dosya));
                Console.WriteLine ("Eriþim tarihi: " + File.GetLastAccessTime (dosya));
                Console.WriteLine ("j2sc#1501a.exe dosyasý mevcut mu? " + File.Exists ("C:\\Users/nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\j2sc#1501a.exe"));
            }

            Console.WriteLine ("\nStreamWriter'la 'mny1.txt' dosyaya yazma ve File.ReadAllLines'la okuma:");
            int i;
            StreamWriter akþYazýcý = new StreamWriter ("mny1.txt");
            for(i=1881;i<=1938;i++) akþYazýcý.WriteLine (i.ToString());
            akþYazýcý.Flush();
            akþYazýcý.Close();
            foreach (string satýr in File.ReadAllLines ("mny1.txt")) Console.Write (satýr + " ");

            Console.WriteLine ("\n\nFile.WriteAllLines'la diziyi 'mny2.txt'e yazma ve File.ReadAllLines'la okuma:");
            string[] satýrDizi = new string [58];
            for(i=0;i<=57;i++) satýrDizi [i] = String.Format ("Satýrno'lu yýl=[{0}:{1}]", i, i+1881);
            File.WriteAllLines ("mny2.txt", satýrDizi);
            foreach (string satýr in File.ReadAllLines ("mny2.txt")) Console.Write (satýr + " ");

            Console.WriteLine ("\nFileInfo ve FileStream'le 'mny3.txt' dosyasýný yaratma ve silme:");
            FileInfo fi = new FileInfo (@"mny3.txt"); //@ ile çift\\ gerekmez
            FileStream fs = fi.Create();
            Console.WriteLine ("Yaratým tarihi: {0}", fi.CreationTime);
            Console.WriteLine ("Tam yollu dosya adý: {0}", fi.FullName);
            Console.WriteLine ("Dosya vasýflarý: {0}", fi.Attributes.ToString());
            fs.Close();
            fi.Delete();
            FileInfo fi2 = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\deneme.txt");
            FileStream fs2=fi2.Create();
            Console.Write ("\n'deneme.txt' yaratýldý, þimdi de SÝL==>Tuþ..."); Console.ReadKey();
            fs2.Close();
            fi2.Delete();

            Console.WriteLine ("\n\nFile.CreateText('mny3.txt'), StreamWriter ve File.ReadAllLines kullanýmý:");
            akþYazýcý = null;
            string selam = "Selam size disk dosyalarý!";
            try {akþYazýcý = File.CreateText ("mny3.txt");
                for(i=0;i<5;i++) akþYazýcý.WriteLine ((i+1)+") "+selam);
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);
            }catch (Exception ht){Console.WriteLine ("HATA: [{0}]", ht.Message);
            }finally {if (akþYazýcý != null) akþYazýcý.Close();}
            foreach (string satýr in File.ReadAllLines ("mny3.txt")) Console.WriteLine (satýr);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}