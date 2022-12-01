// tpc#05a.cs: C# veri tipleri ve de�er tipleri �rne�i.

using System;
namespace VeriTipleri {
    class De�erTipleri {
        static void Main (string[] args) {
            Console.WriteLine ("�� veri tipi vard�r: value/de�er, referans ve pointer/g�sterge tip.");
            Console.WriteLine ("\nSystem.ValueType s�n�f�ndaki do�rudan say�sal veya karaktersel de�erler i�eren de�er tipleri �unlard�r (c#-2010):");
            Console.Write ("\nT�P, TEMS�L ETT���, KAPSAMI, VARSAYILI DE�ER�\n----------------------------------------------------\n1) bool, �kili de�er, True veya False, False\n2) byte, 8-bit i�aretsiz tamsay�, 0-->255, 0\n3) char, 16-bit �nikod krk, U+0000-->U+ffff, '\\0'\\n4) decimal, 128-bit 28-29 hassasiyetli ondal�k say�lar, (-7.9e28-->7.9e28)/1e0-->1e28, 0.0M\n5) double, 64-bit �ift-hassasiyetli kayannokta, -+5e-324-->-+1.7e308, 0.0D\n6) float, 32-bit tek-hassasiyetli kayannokta, -3.4e38-->3.4e38, 0.0F\n7) int, 32-bit i�aretli tamsay�, -2.147.483.648-->2.147.483.647, 0\n8) long, 64-bit i�aretli uzun tamsay�, -9.223.372.036.854.775.808-->9.223.372.036.854.775.807, 0L\n9) sbyte, 8-bit i�aretli bayt tamsay�, -128-->127, 0\n10) short, 16-bit i�aretli k�sa tamsay�, -32.768-->32.767, 0\n11) uint, 32-bit i�aretsiz tamsay�, 0-->4.294.967.295, 0\n12) ulong, 64-bit i�aretsiz uzun tamsay�, 0-->18.446.744.073.709.551.615, 0\n13) ushort, 16-bit i�aresiz k�sa tamsay�, 0-->65.535, 0\nTu�...");
            Console.ReadKey();
        }
    }
}