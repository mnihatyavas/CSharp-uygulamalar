// j2sc#1503f.cs: AsyncCallback ve Thread'le dosyaya asenkron yazma ve okuma örneði.

using System;
using System.IO;
using System.Threading; //Thread için
using System.Text; //Encoding için
namespace DosyaDizin {
    class ÇeþitliF {
        private static FileStream fs;
        private static void YazmaTamamlandý (IAsyncResult iar) {
            Console.WriteLine ("AsyncCallback YazmaTamamlandý metodunun sicim no'su: {0}", Thread.CurrentThread.GetHashCode());
            fs = (FileStream)iar.AsyncState;
            fs.EndWrite (iar);
        }
        static void OkumaTamamlandý (IAsyncResult iar) {
            fs.EndRead (iar); fs.Close();
            Console.WriteLine ("AsyncCallback OkumaTamamlandý metodunun sicim no'su: {0}", Thread.CurrentThread.GetHashCode());
        }
        private static void AsenkronYaz (IAsyncResult iar) {
            fs = (FileStream)iar.AsyncState;
            fs.EndWrite (iar);
        }
        static void AsenkronOku (IAsyncResult iar) {fs.EndRead (iar);}
        static void Main() {
            Console.Write ("Dosyaya ayrý sicimli görev no'yla asenkron okuma/yazma 'AsyncCallback  acb = new AsyncCallback (Tamamlandý)' ifadesiyle saðlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'yavas1.txt' dosyaya sicimli asenkron yazma ve okuma:");
            Console.WriteLine ("{0} no'lu ana sicim baþladý.", Thread.CurrentThread.GetHashCode());
            fs = new FileStream ("yavaþ1.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            string satýr; int i, n; byte[] tampon;
            for(i=1881;i<=1938;i+=14) {
                satýr="M.Kemal Ataturk: " + i;
                tampon = Encoding.ASCII.GetBytes (satýr);
                fs.BeginWrite (tampon, 0, tampon.Length, new AsyncCallback (YazmaTamamlandý), fs);
            } fs.Flush(); fs.Close();
            Console.WriteLine ("\t==>'yavas1.txt'ye (5 kayýt * 22 krk =) 110 krk yazýldý.");
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\yavaþ1.txt", FileMode.Open, FileAccess.Read, FileShare.None, 2048, true);
            AsyncCallback  acb = new AsyncCallback (OkumaTamamlandý);
            tampon = new byte [110];
            fs.BeginRead (tampon, 0, 110, acb, null);
            Console.Write ("Asenkron okuma bitsin: Tuþ...\n"); Console.ReadKey();
            for(i=0;i<110;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();} //yavaþ1.txt'de kaç krk olduðu biliniyorsa
            Console.WriteLine ("\t==>'yavas1.txt'den 110 krk okundu.");
            using (fs = new FileStream ("yavaþ1.txt", FileMode.Open)) {
                tampon = new byte [4096]; //yavaþ1.txt'de kaç krk olduðu bilinmiyorsa
                do {IAsyncResult iar = fs.BeginRead (tampon, 0, tampon.Length, null, null);
                    n = fs.EndRead (iar);
                } while (n == tampon.Length); fs.Close();
                Console.Write ("Asenkron okuma bitsin: Tuþ...\n"); Console.ReadKey();
                for(i=0;i<n;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();}
            }

            Console.WriteLine ("\n'yavaþ2.txt' dosyaya asenkron yazma ve okuma:");
            fs = new FileStream ("yavaþ2.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            satýr="";
            for(i=1938;i>=1881;i-=14) satýr += "M.Kemal Ataturk: " + i;
            tampon = Encoding.ASCII.GetBytes (satýr);
            fs.BeginWrite (tampon, 0, tampon.Length, new AsyncCallback (AsenkronYaz), fs);
            Console.Write ("Asenkron yazma bitsin: Tuþ...\n"); Console.ReadKey();
            fs.Close();
            fs = File.OpenRead ("yavaþ2.txt" );
            n=satýr.Length;
            tampon = new byte [n];
            acb = new AsyncCallback (AsenkronOku);
            fs.BeginRead (
                tampon, //okunanlarýn deposu
                0, //ilk endeks
                tampon.Length, //son endeks
                acb, //geriçaðýrma delegesi
                null); //yerel durum
            Console.Write ("Asenkron okuma bitsin: Tuþ...\n"); Console.ReadKey();
            fs.Close();
            for(i=0;i<n;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}