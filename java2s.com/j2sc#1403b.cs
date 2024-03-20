// j2sc#1403b.cs: Harflerle {0,-20:H#,0.0#} veya ToString("H") çýktý biçimleme örneði.

using System;
using System.Globalization; //CultureInfo için
namespace Geliþimler {
    class KonsolB {
        static void Main() {
            Console.Write ("'0:H' veya 'sayý.ToString(Harf)' ile özgü biçimleme yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Harf, ToString(Biçim) ve diðer çýktý biçimleme uygulamalarý:");
            int i, ts1; double ds1; decimal dc1; var r=new Random();
            ds1=int.MaxValue+r.Next(10,100)/100d; ts1=int.MaxValue;
            Console.WriteLine ("Saða yanaþýk: |{0,20:#,0.00}|", ds1);
            Console.WriteLine("Sola yanaþýk: |{0,-20:#,0.00}|", ts1);
            Console.WriteLine ("Rakam: {0}", ds1);
            Console.WriteLine ("Para: {0:C}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-GB")));
            Console.WriteLine ("Para: {0:C}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine ("{0,-20:G} -- General", ds1);
            Console.WriteLine ("{0,-20} -- varsayýlý General", ds1);
            Console.WriteLine ("{0,-20:F4} -- Fixed, 4 ondalýk", ds1);
            Console.WriteLine ("{0,-20:C} -- Currency", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine ("{0,-20:E4} -- Exponential, 4 ondalýk", ds1);
            Console.WriteLine ("{0,-20:X} -- Hexadecimal tamsayý", ts1);
            Console.WriteLine ("\tSayý, Kare, Küp ve Karekök");
            for(i=1;i<=10;i++) Console.WriteLine ("{0}\t{1}\t{2}\t{3}", i, i*i, i*i*i, Math.Sqrt (i)); 
            Console.WriteLine ("\tNormal ve iskontolu tutar:");
            dc1=r.Next(10,1000000)+r.Next(10,100)/100m;
            ds1=r.Next(1,51)+r.Next(10,100)/100d; 
            Console.WriteLine ("Tutar: {0:C}\tÝskonto oraný: %{1}\tÝskontolu tutar: {2:C}", dc1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")), ds1, (dc1-(dc1*(decimal)ds1/100m)).ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            ds1=int.MaxValue*Math.PI; Console.WriteLine ("'0:#,0.00' biçimleme: {0:#,0.00}", ds1);
            Console.WriteLine ("\tsayý.ToString (\"Format\") biçimlemeler:");
            Console.WriteLine ("C: {0}", ds1.ToString ("C"));
            Console.WriteLine ("C: {0}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-GB")));
            Console.WriteLine ("D: {0}", ts1.ToString ("D"));
            Console.WriteLine ("E: {0}", ds1.ToString ("E"));
            Console.WriteLine ("F: {0}", ds1.ToString ("F"));
            Console.WriteLine ("G: {0}", ds1.ToString ("G"));
            Console.WriteLine ("N: {0}", ds1.ToString ("N"));
            Console.WriteLine ("P: {0}", .385m.ToString ("P"));
            Console.WriteLine ("R: {0}", ds1.ToString ("R"));
            Console.WriteLine ("X: {0}", ts1.ToString ("X"));
            Console.WriteLine ("\tTüm aleni arþiv veri tiplerine çevrim:");
            Console.WriteLine (
                      "byte: " + (byte)ts1 +
                      "\nushort: " + (ushort)ts1 +
                      "\nint: " + (int)ts1 +
                      "\nlong: " + (long)ts1 +
                      "\nfloat: " + (float)ts1 +
                      "\ndecimal: " + (decimal)ts1 +
                      "\ndouble: " + (double)ts1 +
                      "\nchar: " + ((char)(ts1%118)).ToString().ToUpper() +
                      "\nstring: " + ts1.ToString() +
                      "\nbool: " + (bool)true);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}