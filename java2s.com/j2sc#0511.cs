// j2sc#0511.cs: Last/IndexOf/Any �e�itlemeleriyle dizgedeki ibare/krk endeks tespiti �rne�i.

using System;
using System.IO;
namespace Dizgeler {
    class Arama {
        public static string DosyaAd� (string yol) {
            if (yol.Trim().EndsWith (@"\")) return String.Empty;
            int konum = yol.LastIndexOf ('\\');
            if (konum == -1) {// yolsuz dosya ad�?
                if (File.Exists (Environment.CurrentDirectory + Path.DirectorySeparatorChar + yol)) return yol;
                else return String.Empty;
            }else {
                if (File.Exists (yol)) return yol.Substring (konum + 1);
                else return String.Empty;
            }
        }
        static void Main() {
            Console.Write ("Last/IndexOf arg�man� dizge veya krk olabilirken IndexOfAny sadece krk-ler olabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IndexOf, LastIndexOf ve IndexOfAny ile bulunan endeks tamsay�lar�n� sunma:");
            string dizge1 = "Bu k��e yaz k��esi, �u k��e k�� k��esi!";
            Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            Console.WriteLine ("�lk \"k��e\" endeksi = {0}\nSon \"k��e\" endeksi = {1}\n�lk '�', '�' veya '�' krk endeksi = {2}",
                dizge1.IndexOf ("k��e"), dizge1.LastIndexOf ("k��e"), dizge1.IndexOfAny (new char[]{'�', '�', '�', '�', '�'}) );
            Console.WriteLine ("�lk namevcut'�' endeksi = {0}", dizge1.IndexOf ('�'));
            Console.WriteLine ("\"k��e\" dizge1'de mevcut mu? <{0}>", dizge1.Contains ("k��e"));

            Console.WriteLine ("\nAranan herhangibir karakterlerin dizge.ToCharArray() ile temini:");
            int endeks = dizge1.LastIndexOfAny ("k��e".ToCharArray());
            Console.Write ("dizge1'deki \"k��e\" krk'lerinden birinin son endeksi: ");
            if (endeks > -1) Console.Write (endeks);
            else Console.Write ("<bulunamad�>");
            endeks = dizge1.LastIndexOfAny ("h�SrAn".ToCharArray());
            Console.Write ("\ndizge1'deki \"h�SrAn\" krk'lerinden birinin son endeksi: ");
            if (endeks > -1) Console.Write (endeks);
            else Console.Write ("<bulunamad�>");
            Console.Write ("{0}", Environment.NewLine);

            Console.WriteLine ("\nYol-lu/suz na/mevcut dosya-ad�n� soyutlama:");
            dizge1 = DosyaAd� (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#0511.exe");
            Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAd� ("j2sc#0511.cs"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAd� ("j2sc#0511.js"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAd� (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}