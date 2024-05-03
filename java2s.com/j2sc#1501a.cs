// j2sc#1501a.cs: OpenFileDialog, File.Read/WriteAllLines, Create ve Delete �rne�i.

using System;
using System.Windows.Forms; //OpenFileDialog ve DialogResult i�in
using System.IO; //File i�in
namespace DosyaDizin {
    class DosyaA {
        [STAThread] //Main() �n�nde bu vas�f olmadan OpenFileDialog diyalog men�s� a��lmaz
        static void Main() {
            Console.Write ("System.IO s�n�f tipleri: BinaryReader, BinaryWriter, BufferedStream, Directory, DirectoryInfo, DriveInfo, File, FileInfo, FileStream, FileSystemWatcher, MemoryStream, Path, StreamReader, StreamWriter, StringReader, StringWriter.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("OpenFileDialog'la a��lacak dosya se�imi:");
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                string dosya = ofd.FileName;
                Console.WriteLine ("Dosya ad�: " + dosya);
                Console.WriteLine ("Yarat�lma tarihi: " + File.GetCreationTime (dosya));
                Console.WriteLine ("Eri�im tarihi: " + File.GetLastAccessTime (dosya));
                Console.WriteLine ("j2sc#1501a.exe dosyas� mevcut mu? " + File.Exists ("C:\\Users/nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\j2sc#1501a.exe"));
            }

            Console.WriteLine ("\nStreamWriter'la 'mny1.txt' dosyaya yazma ve File.ReadAllLines'la okuma:");
            int i;
            StreamWriter ak�Yaz�c� = new StreamWriter ("mny1.txt");
            for(i=1881;i<=1938;i++) ak�Yaz�c�.WriteLine (i.ToString());
            ak�Yaz�c�.Flush();
            ak�Yaz�c�.Close();
            foreach (string sat�r in File.ReadAllLines ("mny1.txt")) Console.Write (sat�r + " ");

            Console.WriteLine ("\n\nFile.WriteAllLines'la diziyi 'mny2.txt'e yazma ve File.ReadAllLines'la okuma:");
            string[] sat�rDizi = new string [58];
            for(i=0;i<=57;i++) sat�rDizi [i] = String.Format ("Sat�rno'lu y�l=[{0}:{1}]", i, i+1881);
            File.WriteAllLines ("mny2.txt", sat�rDizi);
            foreach (string sat�r in File.ReadAllLines ("mny2.txt")) Console.Write (sat�r + " ");

            Console.WriteLine ("\nFileInfo ve FileStream'le 'mny3.txt' dosyas�n� yaratma ve silme:");
            FileInfo fi = new FileInfo (@"mny3.txt"); //@ ile �ift\\ gerekmez
            FileStream fs = fi.Create();
            Console.WriteLine ("Yarat�m tarihi: {0}", fi.CreationTime);
            Console.WriteLine ("Tam yollu dosya ad�: {0}", fi.FullName);
            Console.WriteLine ("Dosya vas�flar�: {0}", fi.Attributes.ToString());
            fs.Close();
            fi.Delete();
            FileInfo fi2 = new FileInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\deneme.txt");
            FileStream fs2=fi2.Create();
            Console.Write ("\n'deneme.txt' yarat�ld�, �imdi de S�L==>Tu�..."); Console.ReadKey();
            fs2.Close();
            fi2.Delete();

            Console.WriteLine ("\n\nFile.CreateText('mny3.txt'), StreamWriter ve File.ReadAllLines kullan�m�:");
            ak�Yaz�c� = null;
            string selam = "Selam size disk dosyalar�!";
            try {ak�Yaz�c� = File.CreateText ("mny3.txt");
                for(i=0;i<5;i++) ak�Yaz�c�.WriteLine ((i+1)+") "+selam);
            }catch (IOException ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);
            }catch (Exception ht){Console.WriteLine ("HATA: [{0}]", ht.Message);
            }finally {if (ak�Yaz�c� != null) ak�Yaz�c�.Close();}
            foreach (string sat�r in File.ReadAllLines ("mny3.txt")) Console.WriteLine (sat�r);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}