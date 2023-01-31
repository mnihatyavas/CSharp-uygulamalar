// jtpc#1405.cs: Bellek tampona dizgesel verileri yazma ve okuma �rne�i.

using System;
using System.IO;
using System.Text; //StringBuilder i�in gerekli
namespace DosyaG� {
    class DizgeYaz�c�Okuyucu {
        static void Main() {
            Console.Write ("Text s�n�f� t�revi StringWriter/Reader verilerini disk dosyas�na de�il bellekte StringBuilder tamponuna yazar/okur.\nKurucular�: StringWriter(), StringWriter(IFormatProvider), StringWriter(StringBuilder), StringWriter(StringBuilder,?IFormatProvider)\n�zellikleri: Encoding, FormatProvider, NewLine\nMetodlar�: Close(), Dispose(), Equals(Object), Finalize(), GetHashCode(), GetStringBuilder(), ToString(), WriteAsync(String), Write(Boolean), Write(String), WriteLine(String), WriteLineAsync(String)\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string dizge = "Selam, javatpoint.com sitesine ho�geldin.\n" +
                "G�zel tasarlanm�� bir site.\n" +
                "Hemen t�m programlama dillerinin �cretsiz e�itimi mevcuttur.";
            StringBuilder di = new StringBuilder(); //Dizge�n�ac� tiplemesi
            StringWriter dy = new StringWriter (di); //Dizge�n�ac� DizgeYaz�c�'ya ge�irildi
            dy.WriteLine (dizge); //dizge DizgeYaz�c�'ya yaz�ld�
            dy.Flush(); //dizge DizgeYaz�c�'dan Dizge�n�ac�'ya s�r�ld�
            dy.Close(); //dizge DizgeYaz�c�'ya ihtiya� kalmad�
            StringReader dok = new StringReader (di.ToString()); // dizge Dizge�n�ac�'dan DizgeOkuyucu'ya okundu
            while (dok.Peek() > -1) {//dizge sat�rlar� kalmay�ncaya de�in ard���k yans�t�lacak
                Console.WriteLine (dok.ReadLine());
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}