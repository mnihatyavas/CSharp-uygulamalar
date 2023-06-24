// j2sc#0201b.cs: De�i�ken tan�m�, ilkde�er atamas�, belirtisiz/belirtili/parse �evrimler �rne�i.

using System;
namespace VeriTipleri {
    class VeriTipi2 {
        static int Varsay�l�ylaK�yasla<T> (T de�er) where T: IComparable<T> {return de�er.CompareTo (default (T));}
        static void Main() {
            Console.Write ("De�i�ken adlar� tan�mlan�r, varsay�l� de�erli yada ilkde�er atamalar� yap�l�r. Tipleraras� �evrimler belirtisiz, belirtili veya parse ��z�mlemeli yap�labilir. Sabit de�er tiplemeleri L, F, M, D harflerle yap�labilir. GetType() metodu sabit/de�i�ken tipini saptar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int tamsay�;
            double duble;
            tamsay� = 100;
            duble = 100;
            Console.WriteLine ("Tamsay�ya ilk atanan de�er: {0}", tamsay�);
            Console.WriteLine ("Dubleye ilk atanan de�er: {0}", duble);
            tamsay� /= 3;
            duble /=3; 
            Console.WriteLine ("Tamsay� /=3: {0}", tamsay�);
            Console.WriteLine ("Duble /=3: {0}", duble);

            uint i�aretsizTamsay� = 312;
            byte bayt = (byte) i�aretsizTamsay�;
            Console.WriteLine ("\nBayt = i�aretsizTamsay�: ({0} = {1} [312 - 256])", i�aretsizTamsay�, bayt);

            Console.WriteLine ("\nAlt veritipi �st veritipine belirtilmeden atan�rken, �st alta ancak belirtilerek atanabilir:");
            //Belirtisiz atama
            sbyte sb = 55;
            short sh = sb;
            int i = sh;
            long lo = i;
            Console.WriteLine ("lo=in=sh=sb: ({0}={1}={2}={3})", lo, i, sh, sb);
            //Belirtili atama
            lo = 85;
            i = (int) lo;
            sh = (short) i;
            sb = (sbyte) sh;
            Console.WriteLine ("sb=(sbyte)sh=(short)in=(int)lo: ({0}={1}={2}={3})\n", sb, sh, i, lo);

            var r=new Random(); System.Int32 ts1, ts2;
            for (int j=1; j <= 5; j++) {
                 ts1=r.Next (0, 5); ts2 = r.Next (0, 5);
                 if (ts1 == ts2) Console.WriteLine ("{0}) AYNI DE�ERLER: (ts1=ts2={1})", j, ts1);
                 else Console.WriteLine ("{0}) FARKLI DE�ERLER: (ts1, ts2)=({1}, {2})", j, ts1, ts2);
            }

            System.UInt16 ts3 = (ushort)r.Next (0, 65535);
            Console.WriteLine ("\nRasgele tamsay�: {0}\nVeri tipi: {1}\nEnk���k ve enb�y�k de�erleri: ({2}, {3})", ts3, ts3.GetType().ToString(), UInt16.MinValue, UInt16.MaxValue);

            System.Boolean x1=bool.Parse ("true"); Console.WriteLine ("\nbool.Parse = ({0}, {1})", x1, x1.GetType());
            System.SByte x2=sbyte.Parse ("-128"); Console.WriteLine ("sbyte.Parse = ({0}, {1})", x2, x2.GetType());
            System.Decimal x3=decimal.Parse ("2023.0406"); Console.WriteLine ("decimal.Parse = ({0}, {1})", x3, x3.GetType());
            System.Double x4=double.Parse ("2023.0406"); Console.WriteLine ("double.Parse = ({0}, {1})", x4, x4.GetType());
            System.Single x5=float.Parse ("2023.0406"); Console.WriteLine ("float.Parse = ({0}, {1})", x5, x5.GetType());
            System.Int64 x6=long.Parse ("2023"); Console.WriteLine ("long.Parse = ({0}, {1})", x6, x6.GetType());
            System.Int32 x7=int.Parse ("2023"); Console.WriteLine ("int.Parse = ({0}, {1})", x7, x7.GetType());
            System.Int16 x8=short.Parse ("2023"); Console.WriteLine ("short.Parse = ({0}, {1})", x8, x8.GetType());
            System.UInt64 x9=ulong.Parse ("2023"); Console.WriteLine ("ulong.Parse = ({0}, {1})", x9, x9.GetType());
            System.UInt32 x10=uint.Parse ("2023"); Console.WriteLine ("uint.Parse = ({0}, {1})", x10, x10.GetType());
            System.UInt16 x11=ushort.Parse ("2023"); Console.WriteLine ("ushort.Parse = ({0}, {1})", x11, x11.GetType());
            System.Char x12=char.Parse ("A"); Console.WriteLine ("char.Parse = ({0}, {1})", x12, x12.GetType());

            Console.WriteLine ("\nSabit de�erler ve tipleri:");
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", 2023, 2023.GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", 2023L, (2023L).GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", 2023.0406, (2023.0406).GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", 2023.0406f, (2023.0406f).GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", true, (true).GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", 'A', ('A').GetType());
            Console.WriteLine ("(de�er ==>tipi) = ({0} ==>{1})", "A", ("A").GetType());

            Console.WriteLine ("\nDe�i�kenlerin tan�mlanmas� ve ilkde�er atamalar:");
            int y1 = 2023;
            string y2; y2 = "M.Nihat Yava�";
            bool y3 = true, y4 = false, y5 = y3;
            System.Boolean y6 = false;
            bool y7 = new bool(); //false
            int y8 = new int(); //0
            double y9 = new double(); //0.0
            var y10 = new DateTime (2023, 4, 6, 3, 2, 45, 678);
            var y11 = DateTime.Now;
            Console.WriteLine ("Veriler: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, y11);

            Console.WriteLine ("\nDe�i�ken ve de�erlerin varsay�l�yla k�yaslar�:");
            Console.WriteLine ("y11 ({0}) ile varsay�l� k�yas� = {1}", y11, Varsay�l�ylaK�yasla ("y11"));
            Console.WriteLine ("({0}) ile varsay�l� k�yas� = {1}", 2023, Varsay�l�ylaK�yasla (2023));
            Console.WriteLine ("({0}) ile varsay�l� k�yas� = {1}", 0, Varsay�l�ylaK�yasla (0));
            Console.WriteLine ("({0}) ile varsay�l� k�yas� = {1}", -2023, Varsay�l�ylaK�yasla (-2023));
            Console.WriteLine ("DateTime.MinValue ({0}) ile varsay�l� k�yas� = {1}", DateTime.MinValue, Varsay�l�ylaK�yasla (DateTime.MinValue));
            Console.WriteLine ("DateTime.MaxValue ({0}) ile varsay�l� k�yas� = {1}", DateTime.MaxValue, Varsay�l�ylaK�yasla (DateTime.MaxValue));

            Console.WriteLine ("\nAritmetik kalan i�leminde sabit say� tiplemeleri:");
            Console.WriteLine ("int (5 % 2) = {0}", 5 % 2);
            Console.WriteLine ("long (-5L % 2L) = {0}", -5L % 2L);
            Console.WriteLine ("float (-5.0f % 2.4f) = {0}", -5.0f % 2.4f);
            Console.WriteLine ("double (5.0d % 2.4d) = {0}", -5.0d % 2.4d);
            Console.WriteLine ("double (5.0 % 2.2) = {0}", 5.0 % 2.2);
            Console.WriteLine ("decimal (5.0m % 2.2m) = {0}", 5.0m % 2.2m);
            Console.WriteLine ("float (5.0f % 2.2f) = {0}", 5.0f % 2.2f);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}