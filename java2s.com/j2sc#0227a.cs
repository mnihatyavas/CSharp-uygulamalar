// j2sc#0227a.cs: T�m say� �e�itlerini D, F, G, N, E, C ile bi�imleme �rne�i.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Say�Bi�imleme1 {
        static void Main() {
            Console.Write ("{argNo, en:bi�im} ile �ok �e�itli say� bi�imleme varyasyonlar� sa�lan�r. D:Decimal ondal�k tamsay�/long bi�imleme, k�s�rat kabul etmez. F, G, N k�s�ratl�lar� da bi�imler. D ve X bi�inler sadece tamsay� bi�imler. C/Currency para biriminin istenen �lke uyarlamas� i�in 'using System.Globalization' ve 'ds.ToString (\"C\", CultureInfo.CreateSpecificCulture (\"en-US\"))' gerekmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("D:Decimal ile k�s�rats�z ondal�k int/long say�lar�n g�sterimi:");
            var r=new Random();
            int ts1=r.Next (10000, 100000);
            Console.WriteLine ("\"0:D\" bi�imleme: {0:D}", ts1);
            Console.WriteLine ("\"0:D7\" bi�imleme: {0:D7}", ts1);
            Console.WriteLine ("\"0,25:D20\" bi�imleme: {0,25:D20}", long.MaxValue);

            double ds1=(double)r.Next (10000, 100000) + r.Next (10000, 100000) / 100000D;
            float fs1=(float)ds1;
            Console.WriteLine ("\nF:Float ile k�s�ratl� float ve double say�lar�n g�sterimi:");
            Console.WriteLine ("\"0:F\" bi�imleme: {0:F}\t{1:F}", fs1, ds1);
            Console.WriteLine ("\"0:F0\" bi�imleme: {0:F0}\t{1:F0}", fs1, ds1);
            Console.WriteLine ("\"0:F5\" bi�imleme: {0:F5}\t{1:F5}", fs1, ds1);
            Console.WriteLine ("\"0,25:F8\" bi�imleme: {0,25:F8}\t{1,25:F8}", fs1, ds1);
            Console.WriteLine ("\"0,25:F16\" bi�imleme: {0,25:F16}\t{1,25:F16}", (float)Math.PI, Math.PI);

            Console.WriteLine ("\nG:Global ile int-float-double say�lara k�s�ratl�+tamsay� alan s�n�rlama:");
            Console.WriteLine("\"0:G\" bi�imleme: {0:G}\t {1:G}\t {2:G}", ts1, fs1, ds1);
            Console.WriteLine("\"0:G8\" bi�imleme: {0:G8}\t {1:G8}\t {2:G8}", ts1, fs1, ds1);
            Console.WriteLine("\"0:G4\" bi�imleme: {0:G4}\t {1:G4}\t {2:G4}", ts1, fs1, ds1);
            Console.WriteLine("\"0,14:G12\" bi�imleme: {0,14:G12}\t {1,14:G12}\t {2,14:G12}", ts1, fs1, ds1);

            Console.WriteLine ("\nN:Noktal� ile int-float-double say�lara k�s�ratl�+noktal�tamsay� s�n�rlama:");
            Console.WriteLine("\"0:N\" bi�imleme: {0:N}", long.MaxValue);
            Console.WriteLine("\"0:N\" bi�imleme: {0:N}\t {1:N}\t {2:N}", ts1, fs1, ds1);
            Console.WriteLine("\"0:N7\" bi�imleme: {0:N7}\t {1:N7}\t {2:N7}", ts1, fs1, ds1);
            Console.WriteLine("\"0,7:N5\" bi�imleme: {0,7:N5}\t {1,7:N5}\t {2,7:N5}", ts1, fs1, ds1);
            Console.WriteLine("\"0,25:N20\" bi�imleme: {0,25:N12}", (ds1+Math.PI));

            Console.WriteLine ("\nE:Exponent ile int-double say�lara '1.xxeyy' g�sterim:");
            Console.WriteLine ("\"0:E\" bi�imleme: {0:E}\t{1:E}\t{2:E}", ts1, fs1, ds1);
            Console.WriteLine ("\"0:E8\" bi�imleme: {0:E8}\t{1:E8}\t{2:E8}", ts1, fs1, ds1);
            Console.WriteLine ("\"0:e2\" bi�imleme: {0:e2}\t{1:e2}\t{2:e2}", ts1, fs1, ds1);
            Console.WriteLine ("\"0,35:e20\" bi�imleme (int, long, float, double, decimal):\n{0,35:e20}\n{1,35:e20}\n{2,35:e20}\n{3,35:e20}\n{4,45:e30}", int.MaxValue, long.MaxValue, float.MaxValue, double.MaxValue, decimal.MaxValue);

            Console.WriteLine ("\nKarma (C, D, E, F, G, N, X, x) double say� g�sterimi:");
            Console.WriteLine("\"0:C\" bi�imleme: {0:C}", ds1);
            Console.WriteLine("\"0:C\" bi�imleme: {0:C}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine("\"0:D9\" bi�imleme: {0:D9}", (int)ds1);
            Console.WriteLine("\"0:F3\" bi�imleme: {0:F3}", ds1);
            Console.WriteLine("\"0:G\" bi�imleme: {0:G}", ds1);
            Console.WriteLine("\"0:N\" bi�imleme: {0:N}", ds1);
            Console.WriteLine("\"0:E\" bi�imleme: {0:E}", ds1);
            Console.WriteLine("\"0:X\" bi�imleme: {0:X}", (int)ds1);
            Console.WriteLine("\"0:x\" bi�imleme: {0:x}", (int)ds1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}