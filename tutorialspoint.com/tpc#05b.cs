// tpc#05b.cs: C# de�er ver tiplerinin byte ebatlar� �rne�i.

using System;
namespace VeriTipleri {
    class ByteEbatlar {
        static void Main (string[] args) {
            Console.Write ("'bool' ebat�: " + sizeof (bool) + " byte\n'byte' ebat�: " + sizeof (byte) + " byte\n'char' ebat�: " + sizeof (char) + " byte\n'decimal' ebat�: " + sizeof (decimal) + "byte\n'double' ebat�: " + sizeof (double) + " byte\n'float' ebat�: " + sizeof (float) + " byte\n'int' ebat�: " + sizeof (int) + " byte\n'long' ebat�: " + sizeof (long) + " byte\n'sbyte' ebat�: " + sizeof (sbyte) + " byte\n'short' ebat�: " + sizeof (short) + " byte\n'uint' ebat�: " + sizeof (uint) + " byte\n'ulong' ebat�: " + sizeof (ulong) + " byte\n'ushort' ebat�: " + sizeof (ushort) + " byte\nTu�...");
            Console.ReadKey();
        }
    }
}