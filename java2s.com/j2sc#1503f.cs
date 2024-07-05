// j2sc#1503f.cs: AsyncCallback ve Thread'le dosyaya asenkron yazma ve okuma �rne�i.

using System;
using System.IO;
using System.Threading; //Thread i�in
using System.Text; //Encoding i�in
namespace DosyaDizin {
    class �e�itliF {
        private static FileStream fs;
        private static void YazmaTamamland� (IAsyncResult iar) {
            Console.WriteLine ("AsyncCallback YazmaTamamland� metodunun sicim no'su: {0}", Thread.CurrentThread.GetHashCode());
            fs = (FileStream)iar.AsyncState;
            fs.EndWrite (iar);
        }
        static void OkumaTamamland� (IAsyncResult iar) {
            fs.EndRead (iar); fs.Close();
            Console.WriteLine ("AsyncCallback OkumaTamamland� metodunun sicim no'su: {0}", Thread.CurrentThread.GetHashCode());
        }
        private static void AsenkronYaz (IAsyncResult iar) {
            fs = (FileStream)iar.AsyncState;
            fs.EndWrite (iar);
        }
        static void AsenkronOku (IAsyncResult iar) {fs.EndRead (iar);}
        static void Main() {
            Console.Write ("Dosyaya ayr� sicimli g�rev no'yla asenkron okuma/yazma 'AsyncCallback  acb = new AsyncCallback (Tamamland�)' ifadesiyle sa�lan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'yavas1.txt' dosyaya sicimli asenkron yazma ve okuma:");
            Console.WriteLine ("{0} no'lu ana sicim ba�lad�.", Thread.CurrentThread.GetHashCode());
            fs = new FileStream ("yava�1.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            string sat�r; int i, n; byte[] tampon;
            for(i=1881;i<=1938;i+=14) {
                sat�r="M.Kemal Ataturk: " + i;
                tampon = Encoding.ASCII.GetBytes (sat�r);
                fs.BeginWrite (tampon, 0, tampon.Length, new AsyncCallback (YazmaTamamland�), fs);
            } fs.Flush(); fs.Close();
            Console.WriteLine ("\t==>'yavas1.txt'ye (5 kay�t * 22 krk =) 110 krk yaz�ld�.");
            fs = new FileStream (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\yava�1.txt", FileMode.Open, FileAccess.Read, FileShare.None, 2048, true);
            AsyncCallback  acb = new AsyncCallback (OkumaTamamland�);
            tampon = new byte [110];
            fs.BeginRead (tampon, 0, 110, acb, null);
            Console.Write ("Asenkron okuma bitsin: Tu�...\n"); Console.ReadKey();
            for(i=0;i<110;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();} //yava�1.txt'de ka� krk oldu�u biliniyorsa
            Console.WriteLine ("\t==>'yavas1.txt'den 110 krk okundu.");
            using (fs = new FileStream ("yava�1.txt", FileMode.Open)) {
                tampon = new byte [4096]; //yava�1.txt'de ka� krk oldu�u bilinmiyorsa
                do {IAsyncResult iar = fs.BeginRead (tampon, 0, tampon.Length, null, null);
                    n = fs.EndRead (iar);
                } while (n == tampon.Length); fs.Close();
                Console.Write ("Asenkron okuma bitsin: Tu�...\n"); Console.ReadKey();
                for(i=0;i<n;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();}
            }

            Console.WriteLine ("\n'yava�2.txt' dosyaya asenkron yazma ve okuma:");
            fs = new FileStream ("yava�2.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
            sat�r="";
            for(i=1938;i>=1881;i-=14) sat�r += "M.Kemal Ataturk: " + i;
            tampon = Encoding.ASCII.GetBytes (sat�r);
            fs.BeginWrite (tampon, 0, tampon.Length, new AsyncCallback (AsenkronYaz), fs);
            Console.Write ("Asenkron yazma bitsin: Tu�...\n"); Console.ReadKey();
            fs.Close();
            fs = File.OpenRead ("yava�2.txt" );
            n=sat�r.Length;
            tampon = new byte [n];
            acb = new AsyncCallback (AsenkronOku);
            fs.BeginRead (
                tampon, //okunanlar�n deposu
                0, //ilk endeks
                tampon.Length, //son endeks
                acb, //geri�a��rma delegesi
                null); //yerel durum
            Console.Write ("Asenkron okuma bitsin: Tu�...\n"); Console.ReadKey();
            fs.Close();
            for(i=0;i<n;i++) {Console.Write ((char)tampon [i]); if((i+1)%21==0) Console.WriteLine();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}