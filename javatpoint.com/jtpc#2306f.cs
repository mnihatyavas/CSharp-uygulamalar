// jtpc#2306f.cs: �kili de�erleri 0b ve 0x ile tamsay� de�i�kene atama �rne�i.

using System;
namespace Yeni�zellikler {
    class �kiliHarfler {
        static void Main() {
            Console.Write ("Tamsay� de�i�kene 'ob' ile ikili, '0o' ile sekizli ve 'ox' ile de onalt�l� de�er atanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1 = 0x1010; //=16**3+16=4112//0b1010; //=10
            int ts2 = 0x217; //=16**2+16+7=279//0o217; //=143
            int ts3 = 0x01A; //=26
            Console.WriteLine ("Tamsay�-1: {0}\nTamsay�-2: {1}\nTamsay�-3: {2}", ts1, ts2, ts3);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}