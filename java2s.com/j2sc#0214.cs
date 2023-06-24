// j2sc#0214.cs: ��aretsis k�sa tamsay�/ushort tip, kapsam be bi�imlenme �rne�i.

using System;
namespace VeriTipleri {
    class Yararl�k {
        public static void ��le (short k) {Console.WriteLine ("short {0}", k);}
        public static void ��le (ushort k) {Console.WriteLine ("ushort {0}", k);}
    }
    class UShort {
        static void Main() {
            Console.Write ("Unsigned-short i�aretsiz-k�sa tamsay� tipi Int16=2 byte, ve kapsam�: [0, 65535].\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            ushort uk1 = 0;
            try {uk1=(ushort)(1/uk1); //uk1 = (ushort) 20230415;
            }catch {
                Console.WriteLine ("HATA");
                unchecked {uk1 = (ushort) 20230415;}
            }
            Console.WriteLine ("ushort uk1 (= 20230415): {0}\nTipi: {1}\nEnk���k ve enb�y�k de�eri: [{2}, {3}]", uk1, uk1.GetType(), ushort.MinValue, ushort.MaxValue);

            uk1 = 250;
            byte b1 = (byte) uk1;
            Console.WriteLine ("\nbyte b1 (={0}): {1} = 0x{1:X}", uk1, b1);
            uk1 = 65535;
            b1 = (byte) uk1;
            Console.WriteLine ("byte b1 (={0}): {1} = 0x{1:X}\n", uk1, b1);

            Yararl�k.��le (b1);
            Yararl�k.��le (uk1);
            Yararl�k.��le ((byte) uk1);

            string[] bi�imleyiciler = {"G", "C", "D10", "E2", "e3", "F", "N", "P", "X", "000,000.0", "#.00"};
            Console.WriteLine ("\nushort uk1 = 65535'in �e�itli bi�imleni�i:");
            foreach (string bi�imleyici in bi�imleyiciler) Console.WriteLine ("{0}: {1}", bi�imleyici, uk1.ToString (bi�imleyici));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}