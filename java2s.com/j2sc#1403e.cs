// j2sc#1403e.cs: �zelle�tirilen IFormattable ve harf formatlar� �rne�i.

using System;
using System.Text; //StringBuilder i�in
using System.Globalization; //CultureInfo i�in
namespace Geli�imler {
    class ��g�ren: IFormattable {
        int no;
        string ad, soyad;
        public ��g�ren (int n, string a, string s) {no = n; ad = a; soyad = s;} //Kurucu
        public string ToString (string bi�im, IFormatProvider ifp) {
            if ((bi�im != null) && (bi�im.Equals ("A"))) return (String.Format ("{0}: {1}, {2}", no, soyad, ad));
            else if ((bi�im != null) && (bi�im.Equals ("B"))) return (String.Format ("{0}: {1} {2}", no, ad, soyad));
            else return (no.ToString (bi�im, ifp)+"= "+ad+" "+soyad);
        }
    }
    public struct Kompleks : IFormattable {
        private double ger�el, sanal;
        public Kompleks (double g, double s) {ger�el = g; sanal = s;} //Kurucu
        public string ToString (string bi�im, IFormatProvider ifp ) {
            StringBuilder sb = new StringBuilder();
            if (bi�im == "DBG") {
                sb.Append (this.GetType().ToString() + "\n");
                sb.AppendFormat ("\tger�el: {0}\n", ger�el);
                sb.AppendFormat ("\tsanal: {0}", sanal);
            }else {
                sb.Append ("(");
                sb.Append (ger�el.ToString (bi�im, ifp));
                sb.Append (" : ");
                sb.Append (sanal.ToString (bi�im, ifp));
                sb.Append (")");
            }
            return sb.ToString();
        }
    }
    class KonsolE {
        static void Main() {
            Console.Write ("Harf formatlar�: C=Currency, D=Decimal, E=Exponential, F=Fixed-point, G=General, N=Number, P=Percent, X=Hexadecimal.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�zelle�tirilen A, B, N harf formatl� i�g�ren bilgileri:");
            ��g�ren i�g = new ��g�ren (12345, "M.Nihat", "Yava�");
            Console.WriteLine ("A bi�im: {0:A}", i�g);
            Console.WriteLine ("B bi�im: {0:B}", i�g);
            Console.WriteLine ("N bi�im: {0:N}", i�g);

            Console.WriteLine ("\nKompleks say�lar� k�lt�rlerle sunma:");
            CultureInfo yerel = CultureInfo.CurrentCulture;
            CultureInfo alman = new CultureInfo ("ru-RU");
            CultureInfo abd = new CultureInfo ("fr-FR");
            Kompleks kmp = new Kompleks (12.3456, 1234.56);
            string �zlKmp = kmp.ToString ("N", yerel); Console.WriteLine (�zlKmp);
            �zlKmp = kmp.ToString ("N", alman); Console.WriteLine (�zlKmp);
            �zlKmp = kmp.ToString ("N", abd); Console.WriteLine (�zlKmp);
            Console.WriteLine ("DBG ��kt�:\n{0:DBG}", kmp);

            Console.WriteLine ("\nHarf (c, d, f, n, e, x) formatlar�:");
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
            Console.WriteLine ("\t�zel k�s�ratl� parasal");
            foreach (double n in dsDizi) Console.WriteLine ("{0:$#,0 + $.00;} = {0:$#,0.00}", n);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}