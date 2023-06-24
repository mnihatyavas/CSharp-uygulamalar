// j2sc#0218.cs: Tek hassasiyetli k�s�ratl� kayan-noktal� say�lar �rne�i.

using System;
namespace VeriTipleri {
    class Float {
        public static float Ortalama (float N1, float N2) {return (N1 + N2) / 2;}
        static void Main() {
            Console.Write ("Kayan-noktal�, tek hassasiyetli k�s�ratl� say� olup, 32-bit=4-byte'd�r, ve enk���k-enb�y�k de�erleri = -+[1.5E-45, 3.4E+38].\nMetotlar�: CompareTo(), Equals(), GetHashCode(), GetTypeCode(), IsInfinity(), IsNegativeInfinity(), IsNaN(), Parse(), ToString()\n�zellikler: Epsilon, MinValue, MaxValue, NaN, NegativeInfinity, PositiveInfinity\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tipi: {0}\nEbat�: {1} byte\nKapsam�: [{2}, +{3}]", typeof (float), sizeof (float), float.MinValue, float.MaxValue);

            decimal ondal�kSay� = 0.1m * 42M;
            double dubleSay�1 = 0.1f * 42F;
            double dubleSay�2 = 0.1d * 42D;
            float kayanSay� = 0.1f * 42F;
            Console.WriteLine ("\n{0} != {1}", ondal�kSay�, (decimal) dubleSay�1);
            Console.WriteLine ("{0} != {1}", (double) ondal�kSay�, dubleSay�1);
            Console.WriteLine ("(float){0}M != {1}F",(float) ondal�kSay�, kayanSay�);
            Console.WriteLine ("{0} != {1}", dubleSay�1, (double) kayanSay�);
            Console.WriteLine ("{0} != {1}", dubleSay�1, dubleSay�2);
            Console.WriteLine ("{0}F != {1}D", kayanSay�, dubleSay�2);
            Console.WriteLine ("{0} != {1}", (double) 4.2F, 4.2D);
            Console.WriteLine ("{0}F != {1}D", 4.2F, 4.2D);

            int ts1; float kn1; bool b1;
            Console.WriteLine ("\nint.Parse('2023')={0}\nfloat.Parse('2023.0420')={1}\nbool.Parse('true')={2}", (ts1 = int.Parse ("2023")), (kn1 = float.Parse ("2023.0420")), (b1 = bool.Parse ("true")));
            Console.WriteLine ("float.Parse ('20230420E-31') = {0}\nfloat.Parse ('2023.0420E-31') = {1}", float.Parse ("20230420E-31"), float.Parse ("2023.0420E-31"));

            Console.WriteLine ("\n�e�itli bi�imlemeli '1234.56789' duble, ondal�k ve kayan say�lar:");
            dubleSay�1 = 1234.56789; kayanSay� = 1234.56789f; ondal�kSay� = 1234.56789m;
            Console.WriteLine ("Duble ve 10:f3 bi�imleme = {0, 10:f3}", dubleSay�1);
            Console.WriteLine ("Ondal�k ve 10:f3 bi�imleme = {0, 10:f3}", ondal�kSay�);
            Console.WriteLine ("Kayan ve 10:f3 bi�imleme = {0, 10:f3}", kayanSay�);
            Console.WriteLine ("Kayan ve 10:e3 bi�imleme = {0, 10:e3}",kayanSay�);
            Console.WriteLine ("Kayan ve 10:p2 bi�imleme = {0, 10:p2}",kayanSay�);
            Console.WriteLine ("Kayan ve 10:n2 bi�imleme = {0, 10:n2}",kayanSay�);
            Console.WriteLine ("Kayan ve 10:g2 bi�imleme = {0, 10:g2}",kayanSay�);

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
            kayanSay� = 10; kn1 = 3;
            Console.WriteLine ("ks2(=10) / ks1(=3) = " + kayanSay� / kn1);

            Console.WriteLine ("\nOrtalama (10, 3) = " + Ortalama (10, 3));
            Console.WriteLine ("Ortalama ((float)10D, (float)3d) = " + Ortalama ((float)10D, (float)3d));
            Console.WriteLine ("Ortalama (Math.E, Math.PI) = " + Ortalama ((float)Math.E, (float)Math.PI));

            Console.WriteLine ("\nS�f�ra b�l�m hatas�z: -1f / 0 = {0}", -1f / 0);
            ts1=0; try {ts1 = 1 / ts1;}catch (Exception h) {Console.WriteLine ("HATA (ts1 = 1 / 0): [{0}]", h.Message);}
            Console.WriteLine ("Ta�ma hatas�z: 3.402823E+38f * 2f = {0}", 3.402823E+38f * 2f);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}