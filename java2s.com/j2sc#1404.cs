// j2sc#1404.cs: Math.Sin/Cos/Tan, Math.Sign/Max/Sqrt/PI ve Random() uygulamalar� �rne�i.

using System;
namespace Geli�imler {
    class MathFonksiyonu {
        public static String ��aret (int n) {
            if (n == 0) return "SIFIR";
            else if (n < 0) return "EKS�";
            else return "ARTI";
        }
        static void Main() {
            Console.Write ("T�m statik Math metotlar�: Abs, Acos, Asin, Atan, Atan2, Ceiling, Cos, Cosh, Exp, Floor, IEEERemainder, Log, Log10, Max, Min, Pow, Round, Sign, Sin, Sinh, Sqrt, Tan, Tanh. T�m a��lar radyand�r. Double PI, E sabitleri tan�ml�d�r.\nnew Random().Next(i,j) rasgele [i,j] tamsay�, r.NextDouble() ise rasgele [0,1] ondal�ksay� �retir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli Math fonksiyonlar�n�n uygulamas�:");
            Console.WriteLine ("Abs({0})={1}\tAbs({2})={3}", -20240319, Math.Abs (-20240319), 19550807, Math.Abs (19550807));
            Console.WriteLine ("Ceiling({0})={1}\tCeiling({2})={3}", 365.01, Math.Ceiling (365.01), 365.99, Math.Ceiling (365.99));
            Console.WriteLine ("Round({0})={1}\tRound({2})={3}", 365.3, Math.Round (365.3), 365.6, Math.Round (365.6));
            Console.WriteLine ("Pow({0}, {1})={2}", 10.5, 3.75, Math.Pow (10.5, 3.75));
            Console.WriteLine ("Sin({0})={1}", 90D, Math.Sin (Math.PI/2));
            Console.WriteLine ("Cos({0})={1}", 150D, Math.Cos (150*Math.PI/180));
            Console.WriteLine ("Tan({0})={1}", 90D, Math.Tan (Math.PI/2));
            Console.WriteLine ("\t[0,360;30] 30D art��larla tam 2pi=360D d�ng�l� sin�s:");
            for(int a��=0;a��<=360;a��+=30) Console.Write ("Sin({0})={1:0.000} ", a��, Math.Sin (a��*(Math.PI*2)/360)); Console.WriteLine();
            Console.WriteLine ("\t[0,360;30] 30D art��larla tam 2pi=360D d�ng�l� kosin�s:");
            for(int a��=0;a��<=360;a��+=30) Console.Write ("Cos({0})={1:0.000} ", a��, Math.Cos (a��*(Math.PI*2)/360)); Console.WriteLine();
            Console.WriteLine ("\t[0,360;30] 30D art��larla tam 2pi=360D d�ng�l� tanjant:");
            for(int a��=0;a��<=360;a��+=30) Console.Write ("Tan({0})={1:e3} ", a��, Math.Tan (a��*(Math.PI*2)/360)); Console.WriteLine();
            byte xByte = 0; sbyte xSbyte = -101; short xShort = -2; int xInt = -3; long xLong = -4; float xSingle = 0.0f; double xDouble = 6.0; Decimal xDecimal = -7m;
            Console.WriteLine ("\tMath.Sign ile say�sal tiplerin i�aret kontrolleri:");
            Console.Write ("Math.Sign(xByte:{0})={1} ", xByte, Math.Sign (xByte));
            Console.Write ("Math.Sign(xSbyte:{0})={1} ", xSbyte, Math.Sign (xSbyte));
            Console.Write ("Math.Sign(xShort:{0})={1} ", xShort, Math.Sign (xShort));
            Console.Write ("Math.Sign(xInt:{0})={1} ", xInt, Math.Sign (xInt));
            Console.Write ("Math.Sign(xLong:{0})={1} ", xLong, Math.Sign (xLong));
            Console.Write ("Math.Sign(xSingle:{0})={1} ", xSingle, Math.Sign (xSingle));
            Console.Write ("Math.Sign(xDouble:{0})={1} ", xDouble, Math.Sign (xDouble));
            Console.Write ("Math.Sign(xDecimal:{0})={1} ", xDecimal, Math.Sign (xDecimal)); Console.WriteLine();
            Console.WriteLine ("\t��aret(Math.Sign) ile say�sal tiplerin 's�f�r, eksi, art�' kontrolleri:");
            Console.Write ("��aret(Math.Sign(xByte:{0}))={1} ", xByte, ��aret (Math.Sign (xByte)));
            Console.Write ("��aret(Math.Sign(xSbyte:{0}))={1} ", xSbyte, ��aret (Math.Sign (xSbyte)));
            Console.Write ("��aret(Math.Sign(xShort:{0}))={1} ", xShort, ��aret (Math.Sign (xShort)));
            Console.Write ("��aret(Math.Sign(xInt:{0}))={1} ", xInt, ��aret (Math.Sign (xInt)));
            Console.Write ("��aret(Math.Sign(xLong:{0}))={1} ", xLong, ��aret (Math.Sign (xLong)));
            Console.Write ("��aret(Math.Sign(xSingle:{0}))={1} ", xSingle, ��aret (Math.Sign (xSingle)));
            Console.Write ("��aret(Math.Sign(xDouble:{0}))={1} ", xDouble, ��aret (Math.Sign (xDouble)));
            Console.Write ("��aret(Math.Sign(xDecimal:{0}))={1} ", xDecimal, ��aret (Math.Sign (xDecimal))); Console.WriteLine();
            byte     xByte1    = 1,    xByte2    = 51;    
            short    xShort1   = -2,   xShort2   = 52;
            int      xInt1     = -3,   xInt2     = 53;
            long     xLong1    = -4,   xLong2    = 54;
            float    xSingle1  = 5.0f, xSingle2  = 55.0f;
            double   xDouble1  = 6.0,  xDouble2  = 56.0;
            Decimal  xDecimal1 = 7m,   xDecimal2 = 57m;
            sbyte    xSbyte1   = 101, xSbyte2  = 111;
            ushort   xUshort1  = 102, xUshort2 = 112;
            uint     xUint1    = 103, xUint2   = 113;
            ulong    xUlong1   = 104, xUlong2  = 114;
            Console.WriteLine ("\tMath.Max ile verili iki say�n�n b�y���n� d�nd�rme:");
            Console.Write ("Math.Max(xByte1:{0},xByte2:{1})={2} ", xByte1, xByte2, Math.Max (xByte1, xByte2));
            Console.Write ("Math.Max(xShort1:{0},xShort2:{1})={2} ", xShort1, xShort2, Math.Max (xShort1, xShort2));
            Console.Write ("Math.Max(xInt1:{0},xInt2:{1})={2} ", xInt1, xInt2, Math.Max (xInt1, xInt2));
            Console.Write ("Math.Max(xLong1:{0},xLong2:{1})={2} ", xLong1, xLong2, Math.Max (xLong1, xLong2));
            Console.Write ("Math.Max(xSingle1:{0},xSingle2:{1})={2} ", xSingle1, xSingle2, Math.Max (xSingle1, xSingle2));
            Console.Write ("Math.Max(xDouble1:{0},xDouble2:{1})={2} ", xDouble1, xDouble2, Math.Max (xDouble1, xDouble2));
            Console.Write ("Math.Max(xDecimal1:{0},xDecimal2:{1})={2} ", xDecimal1, xDecimal2, Math.Max (xDecimal1, xDecimal2));
            Console.Write ("Math.Max(xSbyte1:{0},xSbyte2:{1})={2} ", xSbyte1, xSbyte2, Math.Max (xSbyte1, xSbyte2));
            Console.Write ("Math.Max(xUshort1:{0},xUshort2:{1})={2} ", xUshort1, xUshort2, Math.Max (xUshort1, xUshort2));
            Console.Write ("Math.Max(xUint1:{0},xUint2:{1})={2} ", xUint1, xUint2, Math.Max (xUint1, xUint2));
            Console.Write ("Math.Max(xUlong1:{0},xUlong2:{1})={2} ", xUlong1, xUlong2, Math.Max (xUlong1, xUlong2)); Console.WriteLine();
            Console.WriteLine ("\tMath.Sqrt(alan/Math.PI) ile verili daire alan�n�n yar��ap�:");
            int i, j, ts1; double ds1; var r=new Random();
            for(i=0;i<10;i++) {ds1=r.Next(10,1000)+r.Next(10,100)/100d; Console.Write ("(Alan:{0},r:{1:0.000}) ", ds1, Math.Sqrt (ds1/Math.PI));} Console.WriteLine();

            Console.WriteLine ("\nRandom() ile rasgele say� �retme:");
            int[] y�llar=new int[1938-1881]; for(j=0;j<y�llar.Length;j++) y�llar [j]=0; int y�l=0;
            for(i=0;i<1000;i++) {
               ts1=r.Next(1881,1939);
               for(j=0;j<y�llar.Length;j++) {if (y�llar [j]==ts1) break; else if (y�llar [j]==0) {y�llar [j]=ts1; y�l++; break;}}
               if (y�l==y�llar.Length) break;
            }
            Console.WriteLine ("\tRasgele �retilen [1881,1938] say�lar:");
            for(i=0;i<y�llar.Length;i++) Console.Write (y�llar[i]+" "); Console.WriteLine();
            Console.WriteLine ("\tRasgele �retilen artan s�ral� [1881,1938] say�lar:");
            Array.Sort(y�llar); for(i=0;i<y�llar.Length;i++) Console.Write (y�llar[i]+" "); Console.WriteLine();
            Console.WriteLine ("\tRasgele �retilen tam ve ondal�k say�lar:");
            r=new Random (20240320);
            ts1=r.Next(); Console.WriteLine ("Sabit: 561635394 = " + ts1);
            ts1=r.Next (152000); Console.WriteLine ("[0, 152000]: " + ts1);
            ts1=r.Next(1900, 2025); Console.WriteLine ("[1900, 2025]: " + ts1);
            ds1=r.NextDouble(); Console.WriteLine ("K�s�ratl� [0, 1]: " + ds1);
            r=new Random(); ts1=r.Next(); Console.WriteLine ("Tamsay� [0, {0}]: {1}", int.MaxValue, ts1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}