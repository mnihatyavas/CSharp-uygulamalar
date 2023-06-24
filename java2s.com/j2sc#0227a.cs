// j2sc#0227a.cs: Tüm sayý çeþitlerini D, F, G, N, E, C ile biçimleme örneði.

using System;
using System.Globalization;
namespace VeriTipleri {
    class SayýBiçimleme1 {
        static void Main() {
            Console.Write ("{argNo, en:biçim} ile çok çeþitli sayý biçimleme varyasyonlarý saðlanýr. D:Decimal ondalýk tamsayý/long biçimleme, küsürat kabul etmez. F, G, N küsüratlýlarý da biçimler. D ve X biçinler sadece tamsayý biçimler. C/Currency para biriminin istenen ülke uyarlamasý için 'using System.Globalization' ve 'ds.ToString (\"C\", CultureInfo.CreateSpecificCulture (\"en-US\"))' gerekmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("D:Decimal ile küsüratsýz ondalýk int/long sayýlarýn gösterimi:");
            var r=new Random();
            int ts1=r.Next (10000, 100000);
            Console.WriteLine ("\"0:D\" biçimleme: {0:D}", ts1);
            Console.WriteLine ("\"0:D7\" biçimleme: {0:D7}", ts1);
            Console.WriteLine ("\"0,25:D20\" biçimleme: {0,25:D20}", long.MaxValue);

            double ds1=(double)r.Next (10000, 100000) + r.Next (10000, 100000) / 100000D;
            float fs1=(float)ds1;
            Console.WriteLine ("\nF:Float ile küsüratlý float ve double sayýlarýn gösterimi:");
            Console.WriteLine ("\"0:F\" biçimleme: {0:F}\t{1:F}", fs1, ds1);
            Console.WriteLine ("\"0:F0\" biçimleme: {0:F0}\t{1:F0}", fs1, ds1);
            Console.WriteLine ("\"0:F5\" biçimleme: {0:F5}\t{1:F5}", fs1, ds1);
            Console.WriteLine ("\"0,25:F8\" biçimleme: {0,25:F8}\t{1,25:F8}", fs1, ds1);
            Console.WriteLine ("\"0,25:F16\" biçimleme: {0,25:F16}\t{1,25:F16}", (float)Math.PI, Math.PI);

            Console.WriteLine ("\nG:Global ile int-float-double sayýlara küsüratlý+tamsayý alan sýnýrlama:");
            Console.WriteLine("\"0:G\" biçimleme: {0:G}\t {1:G}\t {2:G}", ts1, fs1, ds1);
            Console.WriteLine("\"0:G8\" biçimleme: {0:G8}\t {1:G8}\t {2:G8}", ts1, fs1, ds1);
            Console.WriteLine("\"0:G4\" biçimleme: {0:G4}\t {1:G4}\t {2:G4}", ts1, fs1, ds1);
            Console.WriteLine("\"0,14:G12\" biçimleme: {0,14:G12}\t {1,14:G12}\t {2,14:G12}", ts1, fs1, ds1);

            Console.WriteLine ("\nN:Noktalý ile int-float-double sayýlara küsüratlý+noktalýtamsayý sýnýrlama:");
            Console.WriteLine("\"0:N\" biçimleme: {0:N}", long.MaxValue);
            Console.WriteLine("\"0:N\" biçimleme: {0:N}\t {1:N}\t {2:N}", ts1, fs1, ds1);
            Console.WriteLine("\"0:N7\" biçimleme: {0:N7}\t {1:N7}\t {2:N7}", ts1, fs1, ds1);
            Console.WriteLine("\"0,7:N5\" biçimleme: {0,7:N5}\t {1,7:N5}\t {2,7:N5}", ts1, fs1, ds1);
            Console.WriteLine("\"0,25:N20\" biçimleme: {0,25:N12}", (ds1+Math.PI));

            Console.WriteLine ("\nE:Exponent ile int-double sayýlara '1.xxeyy' gösterim:");
            Console.WriteLine ("\"0:E\" biçimleme: {0:E}\t{1:E}\t{2:E}", ts1, fs1, ds1);
            Console.WriteLine ("\"0:E8\" biçimleme: {0:E8}\t{1:E8}\t{2:E8}", ts1, fs1, ds1);
            Console.WriteLine ("\"0:e2\" biçimleme: {0:e2}\t{1:e2}\t{2:e2}", ts1, fs1, ds1);
            Console.WriteLine ("\"0,35:e20\" biçimleme (int, long, float, double, decimal):\n{0,35:e20}\n{1,35:e20}\n{2,35:e20}\n{3,35:e20}\n{4,45:e30}", int.MaxValue, long.MaxValue, float.MaxValue, double.MaxValue, decimal.MaxValue);

            Console.WriteLine ("\nKarma (C, D, E, F, G, N, X, x) double sayý gösterimi:");
            Console.WriteLine("\"0:C\" biçimleme: {0:C}", ds1);
            Console.WriteLine("\"0:C\" biçimleme: {0:C}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine("\"0:D9\" biçimleme: {0:D9}", (int)ds1);
            Console.WriteLine("\"0:F3\" biçimleme: {0:F3}", ds1);
            Console.WriteLine("\"0:G\" biçimleme: {0:G}", ds1);
            Console.WriteLine("\"0:N\" biçimleme: {0:N}", ds1);
            Console.WriteLine("\"0:E\" biçimleme: {0:E}", ds1);
            Console.WriteLine("\"0:X\" biçimleme: {0:X}", (int)ds1);
            Console.WriteLine("\"0:x\" biçimleme: {0:x}", (int)ds1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}