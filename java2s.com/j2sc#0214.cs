// j2sc#0214.cs: Ýþaretsis kýsa tamsayý/ushort tip, kapsam be biçimlenme örneði.

using System;
namespace VeriTipleri {
    class Yararlýk {
        public static void Ýþle (short k) {Console.WriteLine ("short {0}", k);}
        public static void Ýþle (ushort k) {Console.WriteLine ("ushort {0}", k);}
    }
    class UShort {
        static void Main() {
            Console.Write ("Unsigned-short iþaretsiz-kýsa tamsayý tipi Int16=2 byte, ve kapsamý: [0, 65535].\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            ushort uk1 = 0;
            try {uk1=(ushort)(1/uk1); //uk1 = (ushort) 20230415;
            }catch {
                Console.WriteLine ("HATA");
                unchecked {uk1 = (ushort) 20230415;}
            }
            Console.WriteLine ("ushort uk1 (= 20230415): {0}\nTipi: {1}\nEnküçük ve enbüyük deðeri: [{2}, {3}]", uk1, uk1.GetType(), ushort.MinValue, ushort.MaxValue);

            uk1 = 250;
            byte b1 = (byte) uk1;
            Console.WriteLine ("\nbyte b1 (={0}): {1} = 0x{1:X}", uk1, b1);
            uk1 = 65535;
            b1 = (byte) uk1;
            Console.WriteLine ("byte b1 (={0}): {1} = 0x{1:X}\n", uk1, b1);

            Yararlýk.Ýþle (b1);
            Yararlýk.Ýþle (uk1);
            Yararlýk.Ýþle ((byte) uk1);

            string[] biçimleyiciler = {"G", "C", "D10", "E2", "e3", "F", "N", "P", "X", "000,000.0", "#.00"};
            Console.WriteLine ("\nushort uk1 = 65535'in çeþitli biçimleniþi:");
            foreach (string biçimleyici in biçimleyiciler) Console.WriteLine ("{0}: {1}", biçimleyici, uk1.ToString (biçimleyici));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}