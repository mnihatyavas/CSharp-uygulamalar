// j2sc#1403e.cs: Özelleþtirilen IFormattable ve harf formatlarý örneði.

using System;
using System.Text; //StringBuilder için
using System.Globalization; //CultureInfo için
namespace Geliþimler {
    class Ýþgören: IFormattable {
        int no;
        string ad, soyad;
        public Ýþgören (int n, string a, string s) {no = n; ad = a; soyad = s;} //Kurucu
        public string ToString (string biçim, IFormatProvider ifp) {
            if ((biçim != null) && (biçim.Equals ("A"))) return (String.Format ("{0}: {1}, {2}", no, soyad, ad));
            else if ((biçim != null) && (biçim.Equals ("B"))) return (String.Format ("{0}: {1} {2}", no, ad, soyad));
            else return (no.ToString (biçim, ifp)+"= "+ad+" "+soyad);
        }
    }
    public struct Kompleks : IFormattable {
        private double gerçel, sanal;
        public Kompleks (double g, double s) {gerçel = g; sanal = s;} //Kurucu
        public string ToString (string biçim, IFormatProvider ifp ) {
            StringBuilder sb = new StringBuilder();
            if (biçim == "DBG") {
                sb.Append (this.GetType().ToString() + "\n");
                sb.AppendFormat ("\tgerçel: {0}\n", gerçel);
                sb.AppendFormat ("\tsanal: {0}", sanal);
            }else {
                sb.Append ("(");
                sb.Append (gerçel.ToString (biçim, ifp));
                sb.Append (" : ");
                sb.Append (sanal.ToString (biçim, ifp));
                sb.Append (")");
            }
            return sb.ToString();
        }
    }
    class KonsolE {
        static void Main() {
            Console.Write ("Harf formatlarý: C=Currency, D=Decimal, E=Exponential, F=Fixed-point, G=General, N=Number, P=Percent, X=Hexadecimal.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Özelleþtirilen A, B, N harf formatlý iþgören bilgileri:");
            Ýþgören iþg = new Ýþgören (12345, "M.Nihat", "Yavaþ");
            Console.WriteLine ("A biçim: {0:A}", iþg);
            Console.WriteLine ("B biçim: {0:B}", iþg);
            Console.WriteLine ("N biçim: {0:N}", iþg);

            Console.WriteLine ("\nKompleks sayýlarý kültürlerle sunma:");
            CultureInfo yerel = CultureInfo.CurrentCulture;
            CultureInfo alman = new CultureInfo ("ru-RU");
            CultureInfo abd = new CultureInfo ("fr-FR");
            Kompleks kmp = new Kompleks (12.3456, 1234.56);
            string özlKmp = kmp.ToString ("N", yerel); Console.WriteLine (özlKmp);
            özlKmp = kmp.ToString ("N", alman); Console.WriteLine (özlKmp);
            özlKmp = kmp.ToString ("N", abd); Console.WriteLine (özlKmp);
            Console.WriteLine ("DBG çýktý:\n{0:DBG}", kmp);

            Console.WriteLine ("\nHarf (c, d, f, n, e, x) formatlarý:");
            double ds1=20240317.031938;
            Console.WriteLine ("c format: {0:c}", ds1.ToString ("C", new CultureInfo ("en-US")));
            Console.WriteLine ("d9 format: {0:d9}", (int)ds1);
            Console.WriteLine ("f6 format: {0:f3}", ds1);
            Console.WriteLine ("n4 format: {0:n4}", ds1);
            Console.WriteLine ("E format: {0:E}", ds1);
            Console.WriteLine ("e format: {0:e}", ds1);
            Console.WriteLine ("X format: {0:X}", (int)ds1);
            Console.WriteLine ("x format: {0:x}", (int)ds1);
            double[] dsDizi = {0, 12, 14.5, 1454.43, 20240317.0328};
            Console.WriteLine ("\tC=Currency");
            foreach (double n in dsDizi) Console.Write ("{0:C}\t", n.ToString ("C", new CultureInfo ("en-US"))); Console.WriteLine();
            Console.WriteLine ("\thex (0x)" );
            foreach (double n in dsDizi) Console.Write ("0x{0:x8}\t", (int)n);
            Console.WriteLine ("\tHex (0X)" );
            foreach (double n in dsDizi) Console.Write ("0X{0:X8}\t", (int)n);
            Console.WriteLine ("\tÖzel küsüratlý parasal");
            foreach (double n in dsDizi) Console.WriteLine ("{0:$#,0 + $.00;} = {0:$#,0.00}", n);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}