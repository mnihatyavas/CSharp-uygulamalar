// tpc#05b.cs: C# deðer ver tiplerinin byte ebatlarý örneði.

using System;
namespace VeriTipleri {
    class ByteEbatlar {
        static void Main (string[] args) {
            Console.Write ("'bool' ebatý: " + sizeof (bool) + " byte\n'byte' ebatý: " + sizeof (byte) + " byte\n'char' ebatý: " + sizeof (char) + " byte\n'decimal' ebatý: " + sizeof (decimal) + "byte\n'double' ebatý: " + sizeof (double) + " byte\n'float' ebatý: " + sizeof (float) + " byte\n'int' ebatý: " + sizeof (int) + " byte\n'long' ebatý: " + sizeof (long) + " byte\n'sbyte' ebatý: " + sizeof (sbyte) + " byte\n'short' ebatý: " + sizeof (short) + " byte\n'uint' ebatý: " + sizeof (uint) + " byte\n'ulong' ebatý: " + sizeof (ulong) + " byte\n'ushort' ebatý: " + sizeof (ushort) + " byte\nTuþ...");
            Console.ReadKey();
        }
    }
}