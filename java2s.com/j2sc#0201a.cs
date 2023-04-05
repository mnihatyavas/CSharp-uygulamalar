// j2sc#0201a.cs: T�m c# veri tipleri ve enk���k/enb�y�k de�erleri �rne�i.

using System;
namespace VeriTipleri {
    class VeriTipi1 {
        //De�er ve referans ar�iv veri tip tan�mlar�
        public sbyte i�aretliBayt; //8-ASCII bit kar��l���: [00000000=0, 11111111=255]
        public byte bayt;
        public short k�sa;
        public ushort i�aretsizK�sa;
        public int tamsay�;
        public uint i�aretsizTamsay�;
        public long uzun;
        public ulong i�aretsizUzun;
        public char karakter;
        public float kayan; //kayan (ondal�k) nokta
        public double duble;
        public bool ikili;
        public decimal ondal�k; //finansal k�s�ratl�
        public string dizge;
        public object nesne;

        static void Main() {
            Console.Write ("C#'�n 2 �e�it veri tipi vard�r: ilkel veri tipleri ve s�n�f tan�ml� referans (bellek adresi) veri tipleri.\nA-Z ilkel veri tipleri ve baz� say�sal .NET yap� adlar�: bool (true/false=1/0, 1-bit), byte/Byte (8-bit), char (16-bit), decimal/Decimal (128-bit), double/Double (64-bit), float/Single (32-bit), int/Int32 (32-bit), long/Int64 (64-bit), sbyte/Sbyte (8-bit), short/Int16 (16-bit), uint/UInt32 (32-bit), ulong/UInt64 (64-bit), ushort/UInt16 (16-bit).\nSabit rakam sonlar�na konan k���k/b�y�k-harf veri tipini belirtir: l-L/long, u-U/uint, ul-UL/ulong, f-F/float, m-M/decimal; �ndeki 0x/hexa, 0o/octal.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var vt = new VeriTipi1();
            //A-Z ar�iv veri tipleri ve varsay�l� de�erleri
            Console.WriteLine ("De�erler: (varsay�l�, enk���k, enb�y�k, +sonsuz, -sonsuz, epsilon)");
            Console.WriteLine ("bool ikili = ({0}, {1}, {2})", vt.ikili, bool.FalseString, bool.TrueString);
            Console.WriteLine ("byte bayt = ({0}, {1}, {2})", vt.bayt, byte.MinValue, byte.MaxValue);
            Console.WriteLine ("char karakter = ({0}, {1}, {2})", vt.karakter, (vt.karakter='A'), (vt.karakter=(char)122));
            Console.WriteLine ("decimal ondal�k = ({0}, {1}, {2})", vt.ondal�k, decimal.MinValue, decimal.MaxValue);//decimal.PositiveInfinity, decimal.NegativeInfinity, decimal.Epsilon
            Console.WriteLine ("double duble = ({0}, {1}, {2}, {3}, {4}, {5})", vt.duble, double.MinValue, double.MaxValue, double.PositiveInfinity, double.NegativeInfinity, double.Epsilon);
            Console.WriteLine ("float kayan = ({0}, {1}, {2}, {3}, {4}, {5})", vt.kayan, float.MinValue, float.MaxValue, float.PositiveInfinity, float.NegativeInfinity, float.Epsilon);
            Console.WriteLine ("int tamsay� = ({0}, {1}, {2})", vt.tamsay�, int.MinValue, int.MaxValue);
            Console.WriteLine ("long uzun = ({0}, {1}, {2})", vt.uzun, long.MinValue, long.MaxValue);
            Console.WriteLine ("object nesne = ({0}, {1}, {2}, {3})", vt.nesne, (vt.nesne=null), (vt.nesne="Nihat"), (vt.nesne=(2023-1957)));
            Console.WriteLine ("short k�sa = ({0}, {1}, {2})", vt.k�sa, short.MinValue, short.MaxValue);
            Console.WriteLine ("sbyte i�aretliBayt = ({0}, {1}, {2})", vt.i�aretliBayt, sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine ("string dizge = ({0}, {1}, {2}, {3})", vt.dizge, (vt.dizge=null), (vt.dizge="Nihat"), (vt.dizge=(2023-1957).ToString()));
            Console.WriteLine ("uint i�aretsizTamsay� = ({0}, {1}, {2})", vt.i�aretsizTamsay�, uint.MinValue, uint.MaxValue);
            Console.WriteLine ("ulong i�aretsizUzun = ({0}, {1}, {2})", vt.i�aretsizUzun, ulong.MinValue, ulong.MaxValue);
            Console.WriteLine ("ushort i�aretsizK�sa = ({0}, {1}, {2})", vt.i�aretsizK�sa, ushort.MinValue, ushort.MaxValue);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}