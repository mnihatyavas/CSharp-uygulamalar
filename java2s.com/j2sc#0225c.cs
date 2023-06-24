// j2sc#0225c.cs: Convert.To ve haricen-imaen �e�itli tipler aras� �evrimler �rne�i.

using System;
namespace VeriTipleri {
    public sealed class KompleksSay� {
        public readonly double ger�el;
        public readonly double sanal;
        public KompleksSay� (double a, double b) {ger�el = a; sanal = b;}
    }
    class Dizgesel�evrimler3 {
        static void Main() {
            Console.Write ("Daralana atanan haricen, geni�leyene atanan imaen belirtilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1 = Convert.ToInt16 ("2023"); Console.WriteLine ("int ts1={0}, {1}", ts1, ts1.GetTypeCode());
            short ss1 = (short) Convert.ToInt32 ("2023"); Console.WriteLine ("short ss1={0}, {1}", ss1, ss1.GetTypeCode());
            long ls1 = Convert.ToInt64 ("2023"); Console.WriteLine ("long ls1={0}, {1}", ls1, ls1.GetTypeCode());

            string dzg1 = "true";
            bool bl1 = Convert.ToBoolean (dzg1); Console.WriteLine ("bool bl1={0}, {1}", bl1, bl1.GetTypeCode());

            var ks1 = new KompleksSay� (1.12345678, 2.12345678);
            Console.WriteLine ("({0}, j{1}), {2}", ks1.ger�el, ks1.sanal, typeof (KompleksSay�) );
            ks1 = new KompleksSay� (Math.PI, Math.E);
            Console.WriteLine ("({0}, j{1}), {2}", ks1.ger�el, ks1.sanal, typeof (KompleksSay�) );

            ss1 = 4;
            ts1 = 67;
            float fs1 = 10.5F;
            double ds1 = 9999.999, dsn�;
            dzg1 = "17";
            bl1 = false;
            Console.WriteLine ("\nAtamalarda daralana haricen ve geni�leyene imaen belirte�ler:");
            dsn� = fs1 * ss1;
            Console.WriteLine ("�maen,   -> double: {0} * {1} -> {2}", fs1, ss1, dsn�);
            short ssn� = (short) fs1;
            Console.WriteLine ("Haricen, -> short:  {0} -> {1}", fs1, ssn�);
            string dzsn� = Convert.ToString (bl1) + Convert.ToString (ds1);
            Console.WriteLine ("Haricen, -> string: \"{0}\" + \"{1}\" -> {2}", bl1, ds1, dzsn�);
            long lsn� = ts1 + Convert.ToInt64 (dzg1);
            Console.WriteLine ("Karma,   -> long:   {0} + {1} -> {2}", ts1, dzg1, lsn�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}