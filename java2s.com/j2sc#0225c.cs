// j2sc#0225c.cs: Convert.To ve haricen-imaen çeþitli tipler arasý çevrimler örneði.

using System;
namespace VeriTipleri {
    public sealed class KompleksSayý {
        public readonly double gerçel;
        public readonly double sanal;
        public KompleksSayý (double a, double b) {gerçel = a; sanal = b;}
    }
    class DizgeselÇevrimler3 {
        static void Main() {
            Console.Write ("Daralana atanan haricen, geniþleyene atanan imaen belirtilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1 = Convert.ToInt16 ("2023"); Console.WriteLine ("int ts1={0}, {1}", ts1, ts1.GetTypeCode());
            short ss1 = (short) Convert.ToInt32 ("2023"); Console.WriteLine ("short ss1={0}, {1}", ss1, ss1.GetTypeCode());
            long ls1 = Convert.ToInt64 ("2023"); Console.WriteLine ("long ls1={0}, {1}", ls1, ls1.GetTypeCode());

            string dzg1 = "true";
            bool bl1 = Convert.ToBoolean (dzg1); Console.WriteLine ("bool bl1={0}, {1}", bl1, bl1.GetTypeCode());

            var ks1 = new KompleksSayý (1.12345678, 2.12345678);
            Console.WriteLine ("({0}, j{1}), {2}", ks1.gerçel, ks1.sanal, typeof (KompleksSayý) );
            ks1 = new KompleksSayý (Math.PI, Math.E);
            Console.WriteLine ("({0}, j{1}), {2}", ks1.gerçel, ks1.sanal, typeof (KompleksSayý) );

            ss1 = 4;
            ts1 = 67;
            float fs1 = 10.5F;
            double ds1 = 9999.999, dsnç;
            dzg1 = "17";
            bl1 = false;
            Console.WriteLine ("\nAtamalarda daralana haricen ve geniþleyene imaen belirteçler:");
            dsnç = fs1 * ss1;
            Console.WriteLine ("Ýmaen,   -> double: {0} * {1} -> {2}", fs1, ss1, dsnç);
            short ssnç = (short) fs1;
            Console.WriteLine ("Haricen, -> short:  {0} -> {1}", fs1, ssnç);
            string dzsnç = Convert.ToString (bl1) + Convert.ToString (ds1);
            Console.WriteLine ("Haricen, -> string: \"{0}\" + \"{1}\" -> {2}", bl1, ds1, dzsnç);
            long lsnç = ts1 + Convert.ToInt64 (dzg1);
            Console.WriteLine ("Karma,   -> long:   {0} + {1} -> {2}", ts1, dzg1, lsnç);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}