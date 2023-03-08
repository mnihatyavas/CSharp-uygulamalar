// jtpc#2306f.cs: Ýkili deðerleri 0b ve 0x ile tamsayý deðiþkene atama örneði.

using System;
namespace YeniÖzellikler {
    class ÝkiliHarfler {
        static void Main() {
            Console.Write ("Tamsayý deðiþkene 'ob' ile ikili, '0o' ile sekizli ve 'ox' ile de onaltýlý deðer atanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1 = 0x1010; //=16**3+16=4112//0b1010; //=10
            int ts2 = 0x217; //=16**2+16+7=279//0o217; //=143
            int ts3 = 0x01A; //=26
            Console.WriteLine ("Tamsayý-1: {0}\nTamsayý-2: {1}\nTamsayý-3: {2}", ts1, ts2, ts3);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}