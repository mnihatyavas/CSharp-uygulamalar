// j2sc#0511.cs: Last/IndexOf/Any çeþitlemeleriyle dizgedeki ibare/krk endeks tespiti örneði.

using System;
using System.IO;
namespace Dizgeler {
    class Arama {
        public static string DosyaAdý (string yol) {
            if (yol.Trim().EndsWith (@"\")) return String.Empty;
            int konum = yol.LastIndexOf ('\\');
            if (konum == -1) {// yolsuz dosya adý?
                if (File.Exists (Environment.CurrentDirectory + Path.DirectorySeparatorChar + yol)) return yol;
                else return String.Empty;
            }else {
                if (File.Exists (yol)) return yol.Substring (konum + 1);
                else return String.Empty;
            }
        }
        static void Main() {
            Console.Write ("Last/IndexOf argümaný dizge veya krk olabilirken IndexOfAny sadece krk-ler olabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IndexOf, LastIndexOf ve IndexOfAny ile bulunan endeks tamsayýlarýný sunma:");
            string dizge1 = "Bu köþe yaz köþesi, þu köþe kýþ köþesi!";
            Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            Console.WriteLine ("Ýlk \"köþe\" endeksi = {0}\nSon \"köþe\" endeksi = {1}\nÝlk 'ý', 'ö' veya 'þ' krk endeksi = {2}",
                dizge1.IndexOf ("köþe"), dizge1.LastIndexOf ("köþe"), dizge1.IndexOfAny (new char[]{'ý', 'ö', 'þ', 'ð', 'ü'}) );
            Console.WriteLine ("Ýlk namevcut'ü' endeksi = {0}", dizge1.IndexOf ('ü'));
            Console.WriteLine ("\"köþe\" dizge1'de mevcut mu? <{0}>", dizge1.Contains ("köþe"));

            Console.WriteLine ("\nAranan herhangibir karakterlerin dizge.ToCharArray() ile temini:");
            int endeks = dizge1.LastIndexOfAny ("köþe".ToCharArray());
            Console.Write ("dizge1'deki \"köþe\" krk'lerinden birinin son endeksi: ");
            if (endeks > -1) Console.Write (endeks);
            else Console.Write ("<bulunamadý>");
            endeks = dizge1.LastIndexOfAny ("hüSrAn".ToCharArray());
            Console.Write ("\ndizge1'deki \"hüSrAn\" krk'lerinden birinin son endeksi: ");
            if (endeks > -1) Console.Write (endeks);
            else Console.Write ("<bulunamadý>");
            Console.Write ("{0}", Environment.NewLine);

            Console.WriteLine ("\nYol-lu/suz na/mevcut dosya-adýný soyutlama:");
            dizge1 = DosyaAdý (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#0511.exe");
            Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAdý ("j2sc#0511.cs"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAdý ("j2sc#0511.js"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);
            dizge1 = DosyaAdý (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\"); Console.WriteLine ("{0}", String.IsNullOrEmpty (dizge1) ? "<namevcut>" : dizge1);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}