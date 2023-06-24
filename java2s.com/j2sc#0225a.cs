// j2sc#0225a.cs: sayý.ToString() ve dizge+sayý yöntemleriyle dizgesele çevrim örneði.

using System;
using System.Globalization;
namespace VeriTipleri {
    class DizgeselÇevrimler1 {
        static void Main() {
            Console.Write ("Sayýlar ToString() metoduyla yada bir dizgeselle toplanma iþleminde dizgeye çevrilirler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts = 2023;
            float ks = (float)Math.PI + 3.05f;
            double ds = Math.PI + 3.05;
            bool bl = true;
            string dzg;
            Console.WriteLine ("'sayý.ToString()' metoduyla dizgesele çevrim yöntemi:");
            dzg=ts.ToString(); Console.WriteLine ("Sayýsal (int) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=ks.ToString(); Console.WriteLine ("Sayýsal (float) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=ds.ToString(); Console.WriteLine ("Sayýsal (double) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg=bl.ToString(); Console.WriteLine ("Mantýksal (booll) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());

            const double Pi = Math.PI;
            Console.WriteLine ("\n'String + sayý' toplamýyla dizgesele çevrim yöntemi:");
            dzg="Pi = " + Pi; Console.WriteLine ("Sayýsal (double) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());
            dzg="Pi = " + (float)Pi; Console.WriteLine ("Sayýsal (float) dizge ve tipi: ({0}, {1})", dzg, dzg.GetTypeCode());

            var r=new Random();
            Console.WriteLine ("\nKültürel 'sayý.ToString (\"C\", CultureInfo.CreateSpecificCulture (\"en-US\"))' metoduyla dizgesele çevrim yöntemi:");
            decimal des = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            des = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", des, des.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}