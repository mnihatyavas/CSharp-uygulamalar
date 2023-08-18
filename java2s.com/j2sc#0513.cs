// j2sc#0513.cs: Say�lar�n FNeRPXDC harfleriyle bi�imlendirilmesi �rne�i.

using System;
using System.Globalization;
namespace Dizgeler {
    class Bi�imleme {
        static void Main() {
            Console.Write ("Say�sal bi�imleme harfleri cC: Currency/parasal, dD: Decimal/ondal�k. eE: exponantial/�sl�, fF:Fixed/kayannokta, gG: General/genel, nN: Numeric/say�sal, rR: Round/k�s�ratl�, xX: Hexa/onalt�l�. D ve X bi�imleme (int)double gerektirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            double ds1=20230208.0148976;
            Console.WriteLine ("ds1({0}) say�n�n �e�itli harfsel bi�imlemeleri:", ds1);
            string dizge1 = String.Format ("Fixed-point: {0:F2}", ds1); Console.WriteLine (dizge1);  
            dizge1 = String.Format ("Numerical: {0:N5}", ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Exponantial: {0:e}", ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Round: {0:r}", ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Percent: {0:p}", ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Hexadecimal: {0:X}", (int)ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Decimal: {0:D}", (int)ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Currency: {0:C}", ds1); Console.WriteLine (dizge1);
            dizge1 = String.Format ("Currency: {0:C}", ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")) ); Console.WriteLine (dizge1);

            Console.WriteLine ("\n{0}'den {1}'a ard���k artan toplam ve �arp�mlar�n bi�imli sunumu:", 1, 20);
            int ts1 = 0;
            long ls1 = 1;
            for (int i=1; i <= 20; i++) {
                ts1 +=i;
                ls1 *=i;
                dizge1 = String.Format ("{0,3:D}) Toplam:{1,4:D}\t�arp�m:{2,20:D}", i, ts1, ls1); Console.WriteLine (dizge1);
            }

            Console.WriteLine ("\nds1 = {0} ile �e�itli bi�imli sunumlar:", ds1);
            dizge1 = 20230208.0148976.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")); Console.WriteLine (dizge1);
            dizge1 = string.Format ("Cari hesap bakiyeniz: {0:C} TL'dir.", 20230208.0148976); Console.WriteLine (dizge1);
            dizge1 = string.Format ("{0}", ds1); double ds2 = double.Parse (dizge1); Console.WriteLine ("{0}: ds2({1}) != ds1", ds2 != ds1, ds2);
            dizge1 = string.Format ("{0:R}", ds1); ds2 = double.Parse (dizge1); Console.WriteLine ("{0}: (0:R) ile ds2 == ds1", ds2 == ds1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}