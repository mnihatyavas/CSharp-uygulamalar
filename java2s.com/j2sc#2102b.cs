// j2sc#2102b.cs: Encoding.UTF8/Unicode/GetEncoding(1254).GetBytes(dizge) örneði.

using System;
using System.Text; //Encoding içins
namespace Kodlama {
    class Unicode {
        static void Main() {
            Console.Write ("'byte[] bDizi=Encoding.Unicode.GetBytes(dizge)' dizgenin her krk'ini ikilli {0:X2} byte'lara, 'Encoding.Unicode.GetString(bDizi)' ise ikili byte'larý Unicode tek krk'li dizgeye çevirir. 'for(i=0x0000;i<=0x00FF;i++)' döngüyle tüm krk'ler listelenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgeeyi BigEndian/Unicode baytDizi'ye ve tekrar dizgeye  çevirme:");
            string dizge = "M.Nihat Yavaþ!..", dzg2=""; int i, j;
            Encoding tekkod = Encoding.Unicode;
            byte[] bDizi1 = tekkod.GetBytes (dizge);
            Console.WriteLine ("Ýlk dizge: {0}", dizge);
            Console.Write ("Unicode bDizi: ");
            foreach(byte b in bDizi1) dzg2+=b+" ";
            Console.Write (dzg2+"\n");
            for(i=0;i<bDizi1.Length;i+=2) Console.Write ("{0}:{1} ", bDizi1 [i], (char)bDizi1 [i]); Console.WriteLine();
            Encoding betekkod = Encoding.BigEndianUnicode;
            byte[] bDizi2 = betekkod.GetBytes (dizge);
            Console.Write ("BigEndiianUnicode bDizi: ");
            dzg2="";
            foreach(byte b in bDizi2) dzg2+=b+" ";
            Console.Write (dzg2+"\n");
            for(i=0;i<bDizi2.Length;i+=2) Console.Write ("{0}", (char)bDizi2 [i+1]); Console.WriteLine();
            Console.WriteLine ("BitConverter.ToString(bDizi1): " + BitConverter.ToString (bDizi1));
            Console.WriteLine ("dizge(bDizi1)-->string: {0}", Encoding.Unicode.GetString (bDizi1));
            Console.WriteLine ("BitConverter.ToString(bDizi2): " + BitConverter.ToString (bDizi2));
            Console.WriteLine ("dizge(bDizi2)-->string: {0}", Encoding.BigEndianUnicode.GetString (bDizi2));
            Encoding türkçe = Encoding.GetEncoding (1254);
            Console.WriteLine (türkçe);
            byte[] bDizi3 = türkçe.GetBytes (dizge);
            Console.Write ("Türkçe(1254) bDizi: ");
            dzg2="";
            foreach(byte b in bDizi2) dzg2+=b+" ";
            Console.Write (dzg2+"\n");
            for(i=0;i<bDizi2.Length;i++) Console.Write ("{0}", (char)bDizi2 [i]); Console.WriteLine();
            Console.WriteLine ("dizge(bDizi3)-->string: {0}", türkçe.GetString (bDizi3));

            Console.WriteLine ("\nKarakterleri ikili byte kodlama ve tekli krk kodçözme:");
            UnicodeEncoding u16 = new UnicodeEncoding (false, true, true);
            Encoder kodlayýcý = u16.GetEncoder();
            Decoder kodçözücü = u16.GetDecoder();
            char[] krkler = new char [7] { 'z', 'a', '\u0306', '\u01FD', '\u03B2', 'Z', 'A'};
            Console.Write ("Ýlk krk'ler: "); Console.WriteLine (krkler);
            int bytSayý = kodlayýcý.GetByteCount (krkler, 0, krkler.Length, true);
            byte[] bDizi4 = new byte [bytSayý];
            kodlayýcý.GetBytes (krkler, 0, krkler.Length, bDizi4, 0, true);
            int krkSayý  = kodçözücü.GetCharCount (bDizi4, 0, bDizi4.Length, true);
            char[] kDizi = new char [krkSayý];
            kodçözücü.GetChars (bDizi4, 0, bDizi4.Length, kDizi, 0, true);
            Console.WriteLine ("bytSayý: {0}\tkrkSayý: {1}", bytSayý, krkSayý);
            Console.Write ("Enkoderli bayt'lar: ");
            for (i = 0; i < bDizi4.Length; i++ ) Console.Write ("{0:X2} ", bDizi4 [i]); Console.WriteLine();
            Console.Write ("Dekoderli krk'ler: "); Console.Write (kDizi); Console.WriteLine();

            Console.WriteLine ("\nKarakterleri Türkçe(81254), UTF8Encoding ve UnicodeEncoding'le kodlama:");
            dizge = "Dairenin alaný = \u03A0r\u03062";
            byte[] bDizi = Encoding.GetEncoding (1254).GetBytes (dizge);
            Console.WriteLine ("-->Kaynak dizge: " + dizge);
            Console.Write ("Türkçe(1254) bDizi: "); foreach(byte b in bDizi) Console.Write (b+" ");
            Console.WriteLine ("\nbDizi-->string: {0}", Encoding.GetEncoding (1254).GetString (bDizi));
            krkler = new Char[] {
                '\u0023', // #
                '\u0025', // %
                '\u03a0', // Pi
                '\u03a3'  // Sigma
            };
            Console.Write ("-->Ýlk krkler: "); Console.WriteLine (krkler);
            foreach (Char k in krkler) Console.Write ("{0}:{1} ", (byte)k, k); Console.WriteLine();
            UTF8Encoding utf8 = new UTF8Encoding();
            bytSayý = utf8.GetByteCount (krkler, 0, krkler.Length);
            Console.WriteLine ("UTF8 bytSayý(krkler): {0}", bytSayý);
            UnicodeEncoding utf16 = new UnicodeEncoding();
            bytSayý = utf16.GetByteCount (krkler, 0, krkler.Length);
            Console.WriteLine ("UTF16 bytSayý(krkler): {0}", bytSayý);

            Console.WriteLine ("\n0-->FFFF tüm krk'leri 6'þarlý sütun ve 25 satýr duraksamalý listeleme:");
            j=0;
            for(i = 0x0000; i <= 0x00FF; i++) {//0xFFFF
                char k = Convert.ToChar (i);
                //if (char.IsControl (k)) {
                       Console.Write (@"\U{0:X4}: {1}   ", i, k);
                    j++;
                    if (j % 6 == 0) Console.WriteLine();
                    //if (j%256==0) {Console.Write ("\nTuþ..."); Console.ReadKey();}
                //}
            } 
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}