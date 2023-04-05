// j2sc#0201a.cs: Tüm c# veri tipleri ve enküçük/enbüyük deðerleri örneði.

using System;
namespace VeriTipleri {
    class VeriTipi1 {
        //Deðer ve referans arþiv veri tip tanýmlarý
        public sbyte iþaretliBayt; //8-ASCII bit karþýlýðý: [00000000=0, 11111111=255]
        public byte bayt;
        public short kýsa;
        public ushort iþaretsizKýsa;
        public int tamsayý;
        public uint iþaretsizTamsayý;
        public long uzun;
        public ulong iþaretsizUzun;
        public char karakter;
        public float kayan; //kayan (ondalýk) nokta
        public double duble;
        public bool ikili;
        public decimal ondalýk; //finansal küsüratlý
        public string dizge;
        public object nesne;

        static void Main() {
            Console.Write ("C#'ýn 2 çeþit veri tipi vardýr: ilkel veri tipleri ve sýnýf tanýmlý referans (bellek adresi) veri tipleri.\nA-Z ilkel veri tipleri ve bazý sayýsal .NET yapý adlarý: bool (true/false=1/0, 1-bit), byte/Byte (8-bit), char (16-bit), decimal/Decimal (128-bit), double/Double (64-bit), float/Single (32-bit), int/Int32 (32-bit), long/Int64 (64-bit), sbyte/Sbyte (8-bit), short/Int16 (16-bit), uint/UInt32 (32-bit), ulong/UInt64 (64-bit), ushort/UInt16 (16-bit).\nSabit rakam sonlarýna konan küçük/büyük-harf veri tipini belirtir: l-L/long, u-U/uint, ul-UL/ulong, f-F/float, m-M/decimal; öndeki 0x/hexa, 0o/octal.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var vt = new VeriTipi1();
            //A-Z arþiv veri tipleri ve varsayýlý deðerleri
            Console.WriteLine ("Deðerler: (varsayýlý, enküçük, enbüyük, +sonsuz, -sonsuz, epsilon)");
            Console.WriteLine ("bool ikili = ({0}, {1}, {2})", vt.ikili, bool.FalseString, bool.TrueString);
            Console.WriteLine ("byte bayt = ({0}, {1}, {2})", vt.bayt, byte.MinValue, byte.MaxValue);
            Console.WriteLine ("char karakter = ({0}, {1}, {2})", vt.karakter, (vt.karakter='A'), (vt.karakter=(char)122));
            Console.WriteLine ("decimal ondalýk = ({0}, {1}, {2})", vt.ondalýk, decimal.MinValue, decimal.MaxValue);//decimal.PositiveInfinity, decimal.NegativeInfinity, decimal.Epsilon
            Console.WriteLine ("double duble = ({0}, {1}, {2}, {3}, {4}, {5})", vt.duble, double.MinValue, double.MaxValue, double.PositiveInfinity, double.NegativeInfinity, double.Epsilon);
            Console.WriteLine ("float kayan = ({0}, {1}, {2}, {3}, {4}, {5})", vt.kayan, float.MinValue, float.MaxValue, float.PositiveInfinity, float.NegativeInfinity, float.Epsilon);
            Console.WriteLine ("int tamsayý = ({0}, {1}, {2})", vt.tamsayý, int.MinValue, int.MaxValue);
            Console.WriteLine ("long uzun = ({0}, {1}, {2})", vt.uzun, long.MinValue, long.MaxValue);
            Console.WriteLine ("object nesne = ({0}, {1}, {2}, {3})", vt.nesne, (vt.nesne=null), (vt.nesne="Nihat"), (vt.nesne=(2023-1957)));
            Console.WriteLine ("short kýsa = ({0}, {1}, {2})", vt.kýsa, short.MinValue, short.MaxValue);
            Console.WriteLine ("sbyte iþaretliBayt = ({0}, {1}, {2})", vt.iþaretliBayt, sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine ("string dizge = ({0}, {1}, {2}, {3})", vt.dizge, (vt.dizge=null), (vt.dizge="Nihat"), (vt.dizge=(2023-1957).ToString()));
            Console.WriteLine ("uint iþaretsizTamsayý = ({0}, {1}, {2})", vt.iþaretsizTamsayý, uint.MinValue, uint.MaxValue);
            Console.WriteLine ("ulong iþaretsizUzun = ({0}, {1}, {2})", vt.iþaretsizUzun, ulong.MinValue, ulong.MaxValue);
            Console.WriteLine ("ushort iþaretsizKýsa = ({0}, {1}, {2})", vt.iþaretsizKýsa, ushort.MinValue, ushort.MaxValue);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}