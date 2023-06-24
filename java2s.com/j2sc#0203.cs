// j2sc#0203.cs: ��aretli bayt ile �evrim ve k�lt�rel bi�imlemeler �rne�i.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Sbyte {
        static void Main() {
            Console.Write ("'sbyte' i�aretli [-128, 127] tamsay�lar� kapsar. Belirtili (sbyte) g�sterim ta�an say�lar� bu kapsama uyarlar. System.Globalization ile �e�itli �lke say�sal bi�imlemeleri farklar� g�r�lebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            sbyte sb1, sb2; var r=new Random(); int ts1;
            Console.WriteLine ("sbyte: [enk���k, enb�y�k] = [{0}, {1}]", sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine ("int={0}==> sbyte={1}\n", (ts1=r.Next (-1000, 1000)), (sb1 = (sbyte) ts1));

            CultureInfo[] k�lt�rler = {
                    CultureInfo.CreateSpecificCulture ("en-US"), 
                    CultureInfo.CreateSpecificCulture ("fr-FR"), 
                    CultureInfo.CreateSpecificCulture ("es-ES"),
                    CultureInfo.CreateSpecificCulture ("tr-TR") };
            sb1 = (sbyte) r.Next (0, 1000);
            sb2 = (sbyte) -r.Next (0, 1000);
            string[] dizi = {"G", "C", "D6", "E2", "F", "N", "P", "X2"};
            foreach (string birim in dizi) {
                foreach (CultureInfo k�lt�r in k�lt�rler)
                    Console.WriteLine ("{0} k�lt�rle bi�imleme {1,2}: {2, 16} {3, 16}",
                            k�lt�r, birim, sb1.ToString (birim, k�lt�r), sb2.ToString (birim, k�lt�r));
            }

            Console.WriteLine ("\n(sbyte = {0}) say�s�n�n �e�itli bi�imleni�leri:", sb1.ToString());
            Console.WriteLine ("K�s�rats�z: [{0}]", sb1.ToString ("G"));
            Console.WriteLine ("Para: [{0}]", sb1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine ("4 haneli: [{0}]", sb1.ToString ("D4"));
            Console.WriteLine ("�sl�: [{0}]", sb1.ToString ("E2"));
            Console.WriteLine ("5 k�s�ratl�: [{0}]", (sb1+0.123456789).ToString ("F5"));
            Console.WriteLine ("1 k�s�ratl�: [{0}]", (sb1+0.123456789).ToString ("N1"));
            Console.WriteLine ("Y�zde: [{0}]", sb1.ToString ("P"));
            Console.WriteLine ("Hexa: [{0}]", sb1.ToString ("X"));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}