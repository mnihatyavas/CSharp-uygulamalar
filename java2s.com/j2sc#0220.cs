// j2sc#0220.cs: Parasal verilerde kullanýlan -+7.9E+28 kapsamlý decimal-M örneði.

using System;
using System.IO;
using System.Globalization;
namespace VeriTipleri {
    class Desimal {
        public static string ÝstisnaTipi (Exception h) {
            string hTip = h.GetType().ToString();
            return hTip.Substring (hTip.LastIndexOf ('.') + 1);
        }
        public static void OndalýktanBayta (decimal ds) {
            object sb;
            object b;
            try {sb = (sbyte) ds;}catch (Exception h) {sb = ÝstisnaTipi (h);}
            try {b = (byte) ds;}catch (Exception h) {b = ÝstisnaTipi (h);}
            Console.WriteLine ("Decimal deðer: " + ds);
            Console.WriteLine ("SByte deðer: " + sb);
            Console.WriteLine ("Byte deðer: " + b);
        }
        static void Main() {
            Console.Write ("Decimal tip bilhassa finansal veriler için düþünülmüþtür. 128-bit=16-byte ebatlý, -+7.9e+28 kapsamlý, 1e-28 hassasiyetli olup yuvarlama hatalarýný telafi eder.\nMetotlarý: Add(), Subtract(), Multiply(), Divide(), Remainder(), CompareTo(), Equals(), Floor(), Round(), Truncate(), From0Accuracy(), To0Accuracy(), GetBits(), GetHashCode(), GetTypeCode(), Negate(), Parse(), ToByte/SByte/Single/Double/Int16/32/64/String()\nÖzellikleri: MinValue, MaxValue, MinusOne, One, Zero.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tipi: {0}\nEbatý: {1} byte\nKapsamý: [{2}, +{3}]\n-1, 0, 1: ({4}, {5}, {6})",
                typeof (decimal), sizeof (decimal), decimal.MinValue, decimal.MaxValue, decimal.MinusOne, decimal.Zero, decimal.One);

            decimal ds1=123456789012345.0987654321098765M, ds2=0.25m;
            Console.WriteLine ("\n[123456789012345.0987654321098765]: (float, double, decimal) = ({0}, {1}, {2})", (float)ds1, (double)ds1, ds1);

            Console.WriteLine ("\nVarsayýlý = {0} ve new decimal(1234567890, 0, 0, false, 4) = {1}\nnew decimal (1234567890, 0, 0, true, 4) = {2}\nnew decimal (1234567890, 0123456789, 1234567899, false, 4) = {3}",
                1234567890, new decimal (1234567890, 0, 0, false, 4), new decimal (1234567890, 0, 0, true, 4), new decimal (1234567890, 0123456789, 1234567899, false, 4) );

            Console.WriteLine ("\nVarsayýlý ve decimal: 10/3 = ({0}, {1})\n999999999.123456789123456789123456789m = {2}", 20/3.0, 20/3M, 999999999.123456789123456789123456789m);

            ds1=19.95m;
            Console.WriteLine ("\n(Fiyat, %25 indirim, Ýndirimli fiyat) = (${0}, ${1}, ${2})", ds1, ds1*ds2, ds1-ds1*ds2);

            ds1=100000m; ds2=0.17m;
            for (int i = 0; i < 5; i++) {ds1 = ds1 + 0.95m * (ds1 * ds2);}
            Console.WriteLine ("\n%5 stopajla yýllýk %{0} faizli {1}TL'nin {2} yýl sonraki net deðeri = {3:f2}TL", ds2*100, 100000, 5, ds1);

            byte[] bd1 = null;
            using (var bellekAkýþý = new MemoryStream()) {
                using (var ikiliYazýcý = new BinaryWriter (bellekAkýþý)) {
                    ikiliYazýcý.Write (123456789012345.0987654321098765M); bd1=bellekAkýþý.ToArray();
                    Console.WriteLine ("\n123456789012345.0987654321098765M decimal sayýnýn hex karþýlýðý\n  =[{0}]", BitConverter.ToString (bellekAkýþý.ToArray()));
                }
            }
            using (var akýþ = new MemoryStream (bd1)) {
                using (var okuyucu = new BinaryReader (akýþ)) {
                    Console.WriteLine ("Okuyucunun akýþtan ondalýk okuduðu=[{0}]", okuyucu.ReadDecimal());
                }
            }

            Console.WriteLine ("\nDecimal'den (taþma istisnalý) byte/sbyte çevrimler:");
            OndalýktanBayta (7M); Console.WriteLine ("Byte: " + Convert.ToByte (7M) + ", SByte: " + Convert.ToSByte (7M));
            OndalýktanBayta (new decimal (7, 0, 0, false, 3)); Console.WriteLine ("Byte: " + Convert.ToByte (new decimal(7, 0, 0, false, 3)) + " SByte: " + Convert.ToSByte (new decimal(7, 0, 0, false, 3)));
            OndalýktanBayta (new decimal (20230427, 0, 0, false, 3)); try {Console.WriteLine ("Byte: " + Convert.ToByte (new decimal(20230427, 0, 0, false, 3)) + ", SByte: " + Convert.ToSByte (new decimal(20230427, 0, 0, false, 3)));}catch (Exception h) {Console.WriteLine (h.Message);}
            OndalýktanBayta (new decimal (20230427, 0, 0, false, 5)); try {Console.WriteLine ("Byte: " + Convert.ToByte (new decimal (20230427, 0, 0, false, 5)) + ", SByte: " + Convert.ToSByte (new decimal (20230427, 0, 0, false, 5)));}catch (Exception h) {Console.WriteLine (h.Message);}
            OndalýktanBayta (new decimal (20230427, 0, 0, false, 6)); try {Console.WriteLine ("Byte: " + Convert.ToByte (new decimal (20230427, 0, 0, false, 6)) + ", SByte: " + Convert.ToSByte (new decimal (20230427, 0, 0, false, 6)));}catch (Exception h) {Console.WriteLine (h.Message);}

            var r=new Random();
            ds1 = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("\nDecimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", ds1, ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            ds1 = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", ds1, ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            ds1 = r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", ds1, ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            ds1 = -r.Next (1000, 100000) + r.Next (0, 1000) / 1000M; Console.WriteLine ("Decimal ({0}) ve '10:c2' biçimleme = ({0, 10:c2}TL & {1, 10:c2})", ds1, ds1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));

            Console.Write ("\nDecimal bir sayý gir: "); string st2, st3, st1 = Console.ReadLine();
            try {ds1 = Decimal.Parse (st1);
                Console.WriteLine ("Girilen decimal sayý-1 = " + ds1);
                if (st1.IndexOf ('.') > 0) {
                    st2=st1.Substring (0, st1.IndexOf ('.')); st3=st1.Substring (st1.IndexOf ('.')+1);
                    Console.WriteLine ("Girilen decimal sayý-2 = " + Decimal.Parse (st2) + "." + Decimal.Parse (st3));
                }
            } catch (FormatException h) {Console.WriteLine ("Girilen decimal sayý hatalý: [{0}]", h.Message);}

            Console.WriteLine ("\nParasal tutarlarýn hatalý-yazýlým kontrolu:");
            string[] paraDizi = new string[] {"0.99", "0,99", "1000000.00", "10.25", "90,000.00", "90.000,00", "1,000,000.00", "1,000000.00", "1.000.000,00"};
            foreach (string para in paraDizi) {
                try {Decimal.Parse (para, NumberStyles.Currency);
                    Console.WriteLine ("Kontrol [{0}]: Hatasýz", para);
                }catch (FormatException) {Console.WriteLine ("Kontrol [{0}]: HATALI", para);}
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}