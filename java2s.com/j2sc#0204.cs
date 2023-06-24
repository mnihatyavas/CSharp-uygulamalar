// j2sc#0204.cs: C# tamsayý ailesinin kapsam, özellik, metot ve saða-kaydýrma örneði.

using System;
namespace VeriTipleri {
    class Tamsayýlar {
        static void Main() {
            Console.Write ("Tamsayý ailesi: char/Char [ASCII 0; 65,535], byte/Byte [0 to 255], sbyte/SByte [-128, 127], short/Int16 [-32,768; 32,767], ushort/UInt16 [0; 65,535], int/Int32 [-2,147,483,648; 2,147,483,647], uint/UInt32 [0; 4,294,967,295], long/Int64 [-9,223,372,036,854,775,808; 9,223,372,036,854,775,807], ulong/UInt64 [0; 18,446,744,073,709,551,615].\nzellikler: MinValue, MaxValue, PositiveInfinity, NegativeInfinity.\nMetotlar: CompareTo(), Equals(), GetHashCode(), GetTypeCode(), Parse(), ToString(), stringToString()\nTuþ...");Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("Tip: byte/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (byte).ToString(), sizeof (byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine ("Tip: sbyte/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (sbyte).ToString(), sizeof (sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine ("Tip: char/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (char).ToString(), sizeof (char), (int)char.MinValue, (int) char.MaxValue);
            Console.WriteLine ("Tip: short/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (short).ToString(), sizeof (short), short.MinValue, short.MaxValue);
            Console.WriteLine ("Tip: ushort/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (ushort).ToString(), sizeof (ushort), ushort.MinValue, ushort.MaxValue);
            Console.WriteLine ("Tip: int/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (int).ToString(), sizeof (int), int.MinValue, int.MaxValue);
            Console.WriteLine ("Tip: uint/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (uint).ToString(), sizeof (uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine ("Tip: long/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (long).ToString(), sizeof (long), long.MinValue, long.MaxValue);
            Console.WriteLine ("Tip: ulong/{0}, Ebat (byte): {1}, Kapsam: [{2}, {3}]", typeof (ulong).ToString(), sizeof (ulong), ulong.MinValue, ulong.MaxValue);

            int ts = 2023;
            object ns1 = ts;
            object ns2 = new Object();;
            Console.WriteLine ( "\nobject ns1 = int ts = 2023; object ns2 = new Object();");
            Console.WriteLine ( "nesne1 int/tamsayý mýdýr? {0}", (ns1 is int ? "EVET" : "HAYIR") );
            Console.WriteLine ( "nesne2 int/tamsayý mýdýr? {0}", (ns2 is int ? "EVET" : "HAYIR") );
            Console.WriteLine ( "nesne1 System.ValueType/DeðerTip midir? {0}", (ns1 is ValueType ? "EVET" : "HAYIR") );
            Console.WriteLine ( "nesne2 System.ValueType/DeðerTip midir? {0}", (ns2 is ValueType ? "EVET" : "HAYIR") );

            Console.WriteLine ("\n2023.GetHashCode() = {0}", 2023.GetHashCode());
            Console.WriteLine ("2023.GetTypeCode() = {0}", 2023.GetTypeCode());
            Console.WriteLine ("2023.GetType() = {0}", 2023.GetType());
            Console.WriteLine ("2023.Equals (1938)? = {0}", 2023.Equals (1938));
            Console.WriteLine ("(2023-1938).ToString() = {0}", (2023-1938).ToString());
            Console.WriteLine ("char.Parse('ç') = {0}/{1}", char.Parse ("ç"), (char) 231);
            for (int i=0; i<=263; i++) Console.Write ("{0:000}={1}, ", i, (char) i); //Azami ascii i <= 65535

            Console.WriteLine ("\n\nts=b11111100110: {0}\nts >> 1,2,3,4,5: ({1}, {2}, {3}, {4}, {5})", ts, (ts >> 1), (ts >> 2), (ts >> 3), (ts >> 4), (ts >> 5)); //11111100110-->1111110

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}