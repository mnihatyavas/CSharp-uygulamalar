// j2sc#0219.cs: Çift hassasiyetli duble -+1,79769313486232E+308 kapsamlı sayılar örneği.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Double {
        static void Main() {
            Console.Write ("Duble sayı, çift hassasiyetli küsüratlı sayı olup, 64-bit=8-byte'dır, ve enküçük-enbüyük değerleri = [-1,79769313486232E+308, +1,79769313486232E+308].\nMetot ve özellikleri kayan-noktayla benzerdir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tipi: {0}\nEbatı: {1} byte\nKapsamı: [{2}, +{3}]\n-+Sonsuz: [{4}, +{5}]\nEpsilon: {6}",
                typeof (double), sizeof (double), double.MinValue, double.MaxValue, double.NegativeInfinity, double.PositiveInfinity, double.Epsilon);

            Console.WriteLine ("\nDuble pi = {0}\nKayan pi = {1}", Math.PI, (float) Math.PI);
            Console.WriteLine ("Duble 20/3D = {0}\nKayan 20/3f = {1}\nDuble 10/3.0 = {2}\n", 20/3d, 20/3f, 10/3.0);

            string kıyas; double d1, d2;
            Gir1: try {Console.Write ("-+İlk duble sayıyı gir:"); d1 = Convert.ToDouble (Console.ReadLine());}catch {goto Gir1;}
            Gir2: try {Console.Write ("-+İkinci duble sayıyı gir:"); d2 = Convert.ToDouble (Console.ReadLine());}catch {goto Gir2;}
            if (d1 > d2) kıyas = "İlk sayı ikinciden büyüktür";
            else if (d1 < d2) kıyas = "İlk sayı ikinciden küçüktür";
            else kıyas = "İlk sayı ikinciye eşittir";
            Console.WriteLine (kıyas);

            var r=new Random(); int ts1=r.Next (0, 100), i=0;
            Console.WriteLine ("\nHazır C# arşiv fonksiyonlu Math.Sqrt ({0}) = {1}D", ts1, Math.Sqrt (ts1));
            d1 = 1.0e-9; //seçilen epsilon
            d2 = ts1; double karekök = ((ts1 / d2) + d2) / 2;
            while (Math.Abs (karekök - d2) > d1 ) {
                d2 = karekök; i++;
                karekök = ((ts1 / d2) + d2) / 2;
            } Console.WriteLine ("[((Sayı/Tahmin)+Tahmin)/2=Karekök(-->Tahmin) <= Epsilon({0})] şartlı {1} tekrarlı döngüyle karekök = {2}", d1, i, karekök);

            d1 = r.Next (1000, 10000) / 1000D;
            d2 = r.Next (1000, 10000) / 1000D;
            Console.WriteLine ("\nToplama: [{0} + {1} = {2}]", d1, d2, d1+d2);
            Console.WriteLine ("Çıkarma: [{0} - {1} = {2}]", d1, d2, d1-d2);
            Console.WriteLine ("Çarpma: [{0} * {1} = {2}]", d1, d2, d1*d2);
            Console.WriteLine ("Bölme: [{0} / {1} = {2}]", d1, d2, d1/d2);
            Console.WriteLine ("Kalan: [{0} % {1} = {2}]", d1, d2, d1%d2);

            ts1 = r.Next (0, 550); //Kelvin
            d1 = ts1 - 273.15D; // Derece
            d2 = d1 * 9 / 5 + 32D; //Fahrenhayt
            Console.WriteLine ("\n{0} Kelvin = {1} Derece = {2} Fahrenhayt eder.", ts1, d1, d2);

            d1 = Math.Abs (d1);
            Console.WriteLine ("\nYarıçapı {0} birim olan çemberin çevresi = {1} birim\nDairenin alanı = {2} birim kare\nKürenin alanı = {3} birim kare\nKürenin hacmi = {4} birim küp yapar.",
                d1, (2 * Math.PI * d1), (Math.PI * d1 * d1), (4 * Math.PI *  d1 * d1), (4 / 3 * Math.PI * d1 * d1 * d1));

            d1 = 123456789.123456789012345;
            Console.WriteLine ("\n[123456789.123456789012345] Varsayılı biçim: {0}\n'#.###' biçim: {0:#.###}\n'#,###.##' biçim: {0:#,###.##}\n'#.###e+00' bilimsel biçim: {0:#.###e+00}\n'0:#0,' 1000'le bölünen biçim: {0:#0,}", d1);

            Console.WriteLine ("\n+, - ve 0 değerleri '#.#;(#.##);0.00' ile farklı biçimleme:\n{0:#.#;(#.##);0.00}\n{1:#.#;(#.##);0.00}\n{2:#.#;(#.##);0.00}", d1, -d1, 0.0D);

            Console.WriteLine ("\nVarsayılı ve '#%' ile yüzdeli biçimleme: {0} ve {0:#%}", d1);

            d1=123456789.0987654321098765D;
            Console.WriteLine ("\n[d1=123456789.0987654321098765] ile çeşitli biçimlemeler:");
            Console.WriteLine ("'F2' biçim: {0:F2}", double.Parse (d1.ToString()));
            Console.WriteLine ("'N5' biçim: {0:N5}", d1);
            Console.WriteLine ("'e' biçim: {0:e}", d1);
            Console.WriteLine ("'r' biçim: {0:r}", d1);
            Console.WriteLine ("'p' biçim: {0:p}", d1);
            Console.WriteLine ("(int)'X' biçim: {0:X}", (int)d1);
            Console.WriteLine ("(int)'D12' biçim: {0:D12}", (int)d1);
            Console.WriteLine ("'C' biçim: {0:C}", d1);
            Console.WriteLine ("d1.ToString('F2') biçim: {0}", d1.ToString("F2"));
            Console.WriteLine ("d1.ToString('N5') biçim: {0}", d1.ToString("N5"));
            Console.WriteLine ("d1.ToString('e') biçim: {0}", d1.ToString("e"));
            Console.WriteLine ("d1.ToString('r') biçim: {0}", d1.ToString("r"));
            Console.WriteLine ("d1.ToString('p') biçim: {0}", d1.ToString("p"));
            Console.WriteLine ("((int)d1).ToString('X') biçim: {0}", ((int)d1).ToString("X"));
            Console.WriteLine ("((int)d1).ToString('D12') biçim: {0}", ((int)d1).ToString("D12"));
            Console.WriteLine ("d1.ToString('C', CultureInfo.CreateSpecificCulture ('en-US')) biçim: {0}", d1.ToString("C", CultureInfo.CreateSpecificCulture ("en-US")));

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}