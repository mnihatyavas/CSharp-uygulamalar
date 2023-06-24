// j2sc#0219.cs: �ift hassasiyetli duble -+1,79769313486232E+308 kapsaml� say�lar �rne�i.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Double {
        static void Main() {
            Console.Write ("Duble say�, �ift hassasiyetli k�s�ratl� say� olup, 64-bit=8-byte'd�r, ve enk���k-enb�y�k de�erleri = [-1,79769313486232E+308, +1,79769313486232E+308].\nMetot ve �zellikleri kayan-noktayla benzerdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tipi: {0}\nEbat�: {1} byte\nKapsam�: [{2}, +{3}]\n-+Sonsuz: [{4}, +{5}]\nEpsilon: {6}",
                typeof (double), sizeof (double), double.MinValue, double.MaxValue, double.NegativeInfinity, double.PositiveInfinity, double.Epsilon);

            Console.WriteLine ("\nDuble pi = {0}\nKayan pi = {1}", Math.PI, (float) Math.PI);
            Console.WriteLine ("Duble 20/3D = {0}\nKayan 20/3f = {1}\nDuble 10/3.0 = {2}\n", 20/3d, 20/3f, 10/3.0);

            string k�yas; double d1, d2;
            Gir1: try {Console.Write ("-+�lk duble say�y� gir:"); d1 = Convert.ToDouble (Console.ReadLine());}catch {goto Gir1;}
            Gir2: try {Console.Write ("-+�kinci duble say�y� gir:"); d2 = Convert.ToDouble (Console.ReadLine());}catch {goto Gir2;}
            if (d1 > d2) k�yas = "�lk say� ikinciden b�y�kt�r";
            else if (d1 < d2) k�yas = "�lk say� ikinciden k���kt�r";
            else k�yas = "�lk say� ikinciye e�ittir";
            Console.WriteLine (k�yas);

            var r=new Random(); int ts1=r.Next (0, 100), i=0;
            Console.WriteLine ("\nHaz�r C# ar�iv fonksiyonlu Math.Sqrt ({0}) = {1}D", ts1, Math.Sqrt (ts1));
            d1 = 1.0e-9; //se�ilen epsilon
            d2 = ts1; double karek�k = ((ts1 / d2) + d2) / 2;
            while (Math.Abs (karek�k - d2) > d1 ) {
                d2 = karek�k; i++;
                karek�k = ((ts1 / d2) + d2) / 2;
            } Console.WriteLine ("[((Say�/Tahmin)+Tahmin)/2=Karek�k(-->Tahmin) <= Epsilon({0})] �artl� {1} tekrarl� d�ng�yle karek�k = {2}", d1, i, karek�k);

            d1 = r.Next (1000, 10000) / 1000D;
            d2 = r.Next (1000, 10000) / 1000D;
            Console.WriteLine ("\nToplama: [{0} + {1} = {2}]", d1, d2, d1+d2);
            Console.WriteLine ("��karma: [{0} - {1} = {2}]", d1, d2, d1-d2);
            Console.WriteLine ("�arpma: [{0} * {1} = {2}]", d1, d2, d1*d2);
            Console.WriteLine ("B�lme: [{0} / {1} = {2}]", d1, d2, d1/d2);
            Console.WriteLine ("Kalan: [{0} % {1} = {2}]", d1, d2, d1%d2);

            ts1 = r.Next (0, 550); //Kelvin
            d1 = ts1 - 273.15D; // Derece
            d2 = d1 * 9 / 5 + 32D; //Fahrenhayt
            Console.WriteLine ("\n{0} Kelvin = {1} Derece = {2} Fahrenhayt eder.", ts1, d1, d2);

            d1 = Math.Abs (d1);
            Console.WriteLine ("\nYar��ap� {0} birim olan �emberin �evresi = {1} birim\nDairenin alan� = {2} birim kare\nK�renin alan� = {3} birim kare\nK�renin hacmi = {4} birim k�p yapar.",
                d1, (2 * Math.PI * d1), (Math.PI * d1 * d1), (4 * Math.PI *  d1 * d1), (4 / 3 * Math.PI * d1 * d1 * d1));

            d1 = 123456789.123456789012345;
            Console.WriteLine ("\n[123456789.123456789012345] Varsay�l� bi�im: {0}\n'#.###' bi�im: {0:#.###}\n'#,###.##' bi�im: {0:#,###.##}\n'#.###e+00' bilimsel bi�im: {0:#.###e+00}\n'0:#0,' 1000'le b�l�nen bi�im: {0:#0,}", d1);

            Console.WriteLine ("\n+, - ve 0 de�erleri '#.#;(#.##);0.00' ile farkl� bi�imleme:\n{0:#.#;(#.##);0.00}\n{1:#.#;(#.##);0.00}\n{2:#.#;(#.##);0.00}", d1, -d1, 0.0D);

            Console.WriteLine ("\nVarsay�l� ve '#%' ile y�zdeli bi�imleme: {0} ve {0:#%}", d1);

            d1=123456789.0987654321098765D;
            Console.WriteLine ("\n[d1=123456789.0987654321098765] ile �e�itli bi�imlemeler:");
            Console.WriteLine ("'F2' bi�im: {0:F2}", double.Parse (d1.ToString()));
            Console.WriteLine ("'N5' bi�im: {0:N5}", d1);
            Console.WriteLine ("'e' bi�im: {0:e}", d1);
            Console.WriteLine ("'r' bi�im: {0:r}", d1);
            Console.WriteLine ("'p' bi�im: {0:p}", d1);
            Console.WriteLine ("(int)'X' bi�im: {0:X}", (int)d1);
            Console.WriteLine ("(int)'D12' bi�im: {0:D12}", (int)d1);
            Console.WriteLine ("'C' bi�im: {0:C}", d1);
            Console.WriteLine ("d1.ToString('F2') bi�im: {0}", d1.ToString("F2"));
            Console.WriteLine ("d1.ToString('N5') bi�im: {0}", d1.ToString("N5"));
            Console.WriteLine ("d1.ToString('e') bi�im: {0}", d1.ToString("e"));
            Console.WriteLine ("d1.ToString('r') bi�im: {0}", d1.ToString("r"));
            Console.WriteLine ("d1.ToString('p') bi�im: {0}", d1.ToString("p"));
            Console.WriteLine ("((int)d1).ToString('X') bi�im: {0}", ((int)d1).ToString("X"));
            Console.WriteLine ("((int)d1).ToString('D12') bi�im: {0}", ((int)d1).ToString("D12"));
            Console.WriteLine ("d1.ToString('C', CultureInfo.CreateSpecificCulture ('en-US')) bi�im: {0}", d1.ToString("C", CultureInfo.CreateSpecificCulture ("en-US")));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}