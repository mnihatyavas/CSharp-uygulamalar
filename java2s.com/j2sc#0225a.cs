// j2sc#0225a.cs: say�.ToString() ve dizge+say� y�ntemleriyle dizgesele �evrim �rne�i.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Dizgesel�evrimler1 {
        static void Main() {
            Console.Write ("Say�lar ToString() metoduyla yada bir dizgeselle toplanma i�leminde dizgeye �evrilirler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts = 2023;
            float ks = (float)Math.PI + 3.05f;
            double ds = Math.PI + 3.05;
            bool bl = true;
            string dzg;
            Console.WriteLine ("'say�.ToString()' metoduyla dizgesele �evrim y�ntemi:");
            dzg=ts.ToString(); Console.WriteLine ("Say�sal (int) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=ks.ToString(); Console.WriteLine ("Say�sal (float) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=ds.ToString(); Console.WriteLine ("Say�sal (double) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=bl.ToString(); Console.WriteLine ("Mant�ksal (booll) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());

            const double Pi = Math.PI;
            Console.WriteLine ("\n'String + say�' toplam�yla dizgesele �evrim y�ntemi:");
            dzg="Pi = " + Pi; Console.WriteLine ("Say�sal (double) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg="Pi = " + (float)Pi; Console.WriteLine ("Say�sal (float) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());

            var r=new Random();
            Console.WriteLine ("\nK�lt�rel 'say�.ToString (\"C\", CultureInfo.CreateSpecificCulture (\"en-US\"))' metoduyla dizgesele �evrim y�ntemi:");
            decimal des = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' bi�imleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' bi�imleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' bi�imleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' bi�imleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}