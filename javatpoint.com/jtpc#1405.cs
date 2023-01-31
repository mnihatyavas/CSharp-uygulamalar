// jtpc#1405.cs: Bellek tampona dizgesel verileri yazma ve okuma örneði.

using System;
using System.IO;
using System.Text; //StringBuilder için gerekli
namespace DosyaGÇ {
    class DizgeYazýcýOkuyucu {
        static void Main() {
            Console.Write ("Text sýnýfý türevi StringWriter/Reader verilerini disk dosyasýna deðil bellekte StringBuilder tamponuna yazar/okur.\nKurucularý: StringWriter(), StringWriter(IFormatProvider), StringWriter(StringBuilder), StringWriter(StringBuilder,?IFormatProvider)\nÖzellikleri: Encoding, FormatProvider, NewLine\nMetodlarý: Close(), Dispose(), Equals(Object), Finalize(), GetHashCode(), GetStringBuilder(), ToString(), WriteAsync(String), Write(Boolean), Write(String), WriteLine(String), WriteLineAsync(String)\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string dizge = "Selam, javatpoint.com sitesine hoþgeldin.\n" +
                "Güzel tasarlanmýþ bir site.\n" +
                "Hemen tüm programlama dillerinin ücretsiz eðitimi mevcuttur.";
            StringBuilder di = new StringBuilder(); //DizgeÝnþacý tiplemesi
            StringWriter dy = new StringWriter (di); //DizgeÝnþacý DizgeYazýcý'ya geçirildi
            dy.WriteLine (dizge); //dizge DizgeYazýcý'ya yazýldý
            dy.Flush(); //dizge DizgeYazýcý'dan DizgeÝnþacý'ya sürüldü
            dy.Close(); //dizge DizgeYazýcý'ya ihtiyaç kalmadý
            StringReader dok = new StringReader (di.ToString()); // dizge DizgeÝnþacý'dan DizgeOkuyucu'ya okundu
            while (dok.Peek() > -1) {//dizge satýrlarý kalmayýncaya deðin ardýþýk yansýtýlacak
                Console.WriteLine (dok.ReadLine());
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}