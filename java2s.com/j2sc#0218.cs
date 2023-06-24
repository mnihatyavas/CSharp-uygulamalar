// j2sc#0218.cs: Tek hassasiyetli küsüratlý kayan-noktalý sayýlar örneði.

using System;
namespace VeriTipleri {
    class Float {
        public static float Ortalama (float N1, float N2) {return (N1 + N2) / 2;}
        static void Main() {
            Console.Write ("Kayan-noktalý, tek hassasiyetli küsüratlý sayý olup, 32-bit=4-byte'dýr, ve enküçük-enbüyük deðerleri = -+[1.5E-45, 3.4E+38].\nMetotlarý: CompareTo(), Equals(), GetHashCode(), GetTypeCode(), IsInfinity(), IsNegativeInfinity(), IsNaN(), Parse(), ToString()\nÖzellikler: Epsilon, MinValue, MaxValue, NaN, NegativeInfinity, PositiveInfinity\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tipi: {0}\nEbatý: {1} byte\nKapsamý: [{2}, +{3}]", typeof (float), sizeof (float), float.MinValue, float.MaxValue);

            decimal ondalýkSayý = 0.1m * 42M;
            double dubleSayý1 = 0.1f * 42F;
            double dubleSayý2 = 0.1d * 42D;
            float kayanSayý = 0.1f * 42F;
            Console.WriteLine ("\n{0} != {1}", ondalýkSayý, (decimal) dubleSayý1);
            Console.WriteLine ("{0} != {1}", (double) ondalýkSayý, dubleSayý1);
            Console.WriteLine ("(float){0}M != {1}F",(float) ondalýkSayý, kayanSayý);
            Console.WriteLine ("{0} != {1}", dubleSayý1, (double) kayanSayý);
            Console.WriteLine ("{0} != {1}", dubleSayý1, dubleSayý2);
            Console.WriteLine ("{0}F != {1}D", kayanSayý, dubleSayý2);
            Console.WriteLine ("{0} != {1}", (double) 4.2F, 4.2D);
            Console.WriteLine ("{0}F != {1}D", 4.2F, 4.2D);

            int ts1; float kn1; bool b1;
            Console.WriteLine ("\nint.Parse('2023')={0}\nfloat.Parse('2023.0420')={1}\nbool.Parse('true')={2}", (ts1 = int.Parse ("2023")), (kn1 = float.Parse ("2023.0420")), (b1 = bool.Parse ("true")));
            Console.WriteLine ("float.Parse ('20230420E-31') = {0}\nfloat.Parse ('2023.0420E-31') = {1}", float.Parse ("20230420E-31"), float.Parse ("2023.0420E-31"));

            Console.WriteLine ("\nÇeþitli biçimlemeli '1234.56789' duble, ondalýk ve kayan sayýlar:");
            dubleSayý1 = 1234.56789; kayanSayý = 1234.56789f; ondalýkSayý = 1234.56789m;
            Console.WriteLine ("Duble ve 10:f3 biçimleme = {0, 10:f3}", dubleSayý1);
            Console.WriteLine ("Ondalýk ve 10:f3 biçimleme = {0, 10:f3}", ondalýkSayý);
            Console.WriteLine ("Kayan ve 10:f3 biçimleme = {0, 10:f3}", kayanSayý);
            Console.WriteLine ("Kayan ve 10:e3 biçimleme = {0, 10:e3}",kayanSayý);
            Console.WriteLine ("Kayan ve 10:p2 biçimleme = {0, 10:p2}",kayanSayý);
            Console.WriteLine ("Kayan ve 10:n2 biçimleme = {0, 10:n2}",kayanSayý);
            Console.WriteLine ("Kayan ve 10:g2 biçimleme = {0, 10:g2}",kayanSayý);

            Console.WriteLine ("\nKayan D sabite: Math.PI = {0}", Math.PI);
            Console.WriteLine ("Kayan F sabite: Math.PI = {0}", (float) Math.PI);
            Console.WriteLine ("Kayan F sabite: {0}", 3.14159265358979F);

            Console.WriteLine ("\n0.0f % 1.3f = {0}", 0.0f % 1.3f);
            Console.WriteLine ("0.3f % 1.3f = {0}", 0.3f % 1.3f);
            Console.WriteLine ("1.0f % 1.3f = {0}", 1.0f % 1.3f);
            Console.WriteLine ("1.3f % 1.3f = {0}", 1.3f % 1.3f);
            Console.WriteLine ("2.0f % 1.3f = {0}", 2.0f % 1.3f);
            Console.WriteLine ("2.3f % 1.3f = {0}", 2.3f % 1.3f);

            Console.WriteLine ("\n10f / 3f = " + 10f / 3f);
            Console.WriteLine ("10 / 3 = " + 10 / 3);
            Console.WriteLine ("10 / 3.0 = " + 10 / 3.0);
            kayanSayý = 10; kn1 = 3;
            Console.WriteLine ("ks2(=10) / ks1(=3) = " + kayanSayý / kn1);

            Console.WriteLine ("\nOrtalama (10, 3) = " + Ortalama (10, 3));
            Console.WriteLine ("Ortalama ((float)10D, (float)3d) = " + Ortalama ((float)10D, (float)3d));
            Console.WriteLine ("Ortalama (Math.E, Math.PI) = " + Ortalama ((float)Math.E, (float)Math.PI));

            Console.WriteLine ("\nSýfýra bölüm hatasýz: -1f / 0 = {0}", -1f / 0);
            ts1=0; try {ts1 = 1 / ts1;}catch (Exception h) {Console.WriteLine ("HATA (ts1 = 1 / 0): [{0}]", h.Message);}
            Console.WriteLine ("Taþma hatasýz: 3.402823E+38f * 2f = {0}", 3.402823E+38f * 2f);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}