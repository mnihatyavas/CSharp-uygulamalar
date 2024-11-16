// j2sc#2102a.cs: ASCII, UTF8, UTF16, Base64String kodlamalarý örneði.

using System;
using System.Text; //Encoding için
using System.IO; //StreamWriter için
namespace Kodlama {
    class Ascii {
        static void Main() {
            Console.Write ("'byte[] dizi = Encoding.ASCII/UTF8/Unicode.GetBytes(dizge)' ile kodlamalý diziye, 'BitConverter.ToString(dizi)' ile de tekrar dizgeye çevrilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ascii-256 byte'lýk karakterlerle sýnýrlý kodlama:");
            string dizge="";
            using (StreamWriter dosya = new StreamWriter ("mny1.txt")) {
                Encoding ascii = Encoding.ASCII;
                dosya.WriteLine (ascii);
                Console.WriteLine (ascii);
                dizge = "Çemberin çevresi = 2*\u03A0*r";
                byte[] asciiDizi = ascii.GetBytes (dizge);
                dosya.WriteLine ("ASCII Bayt'lar: {0}", BitConverter.ToString (asciiDizi));
                Console.WriteLine ("ASCII Bayt'lar: {0}", BitConverter.ToString (asciiDizi));
                foreach (byte b in asciiDizi) {dosya.Write ((char)b); Console.Write ((char)b);} Console.WriteLine();
            }

            Console.WriteLine ("\nUtf8-128 byte'lýk karakterlerle sýnýrlý kodlama::");
            using (StreamWriter dosya = new StreamWriter ("mny2.txt")) {
                Encoding utf8 = Encoding.UTF8;
                dosya.WriteLine (utf8); Console.WriteLine (utf8);
                dizge = "Çemberin alaný = \u03A0*r*r";
                byte[] utf8Dizi = utf8.GetBytes (dizge);
                dosya.WriteLine ("UTF8 Bayt'lar: {0}", BitConverter.ToString (utf8Dizi));
                Console.WriteLine ("UTF8 Bayt'lar: {0}", BitConverter.ToString (utf8Dizi));
                foreach (byte b in utf8Dizi) {dosya.Write ((char)b); Console.Write ((char)b);} Console.WriteLine();
            }

            Console.WriteLine ("\nUtf16-Unicode karakterlerle kodlama::");
            using (StreamWriter dosya = new StreamWriter ("mny3.txt")) {
                Encoding utf16 = Encoding.Unicode;
                dosya.WriteLine (utf16); Console.WriteLine (utf16);
                dizge = "Çemberin hacmi = 4*\u03A0*r*r*r/3";
                byte[] utf16Dizi = utf16.GetBytes (dizge);
                dosya.WriteLine ("UTF16 Bayt'lar: {0}", BitConverter.ToString (utf16Dizi));
                Console.WriteLine ("UTF16 Bayt'lar: {0}", BitConverter.ToString (utf16Dizi));
                foreach (byte b in utf16Dizi) {dosya.Write ((char)b); Console.Write ((char)b);} Console.WriteLine();
            }

            Console.WriteLine ("\nDizgeyi byte[] ve Base64String'e, sonra tekrar dizgeye çevirme:");
            int i, ts;
            byte[] bDizi = Encoding.Unicode.GetBytes ("Mahmut Nihat Yavaþ");
            dizge =  Convert.ToBase64String (bDizi);
            Console.WriteLine ("Dizge(\"Mahmut Nihat Yavaþ\")-->Base64String: {0}", dizge);
            for(i=0;i<bDizi.Length; i+=2) Console.Write (bDizi [i] + ":" + (char)bDizi[i] + " "); Console.WriteLine();
            Console.WriteLine ("dizge(bDizi)-->string: {0}", Encoding.Unicode.GetString (bDizi));
            Console.WriteLine ("Base64String(bDizi)-->string: {0}", Encoding.Unicode.GetString (Convert.FromBase64String (dizge)));

            Console.WriteLine ("\nint[65,123]-->byte[]-->Base64String-->byte[]-->int:char çevrimleri:");
            for(i=65;i<=123; i++) {
                bDizi = BitConverter.GetBytes (i);
                dizge = Convert.ToBase64String (bDizi);
                Console.Write ("{0}-->{1}>", i, dizge);
                bDizi = Convert.FromBase64String (dizge);
                ts = BitConverter.ToInt32 (bDizi, 0);
                Console.Write ("{0}:{1}  ", ts, (char)ts);
            }Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}