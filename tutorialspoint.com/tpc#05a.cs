// tpc#05a.cs: C# veri tipleri ve deðer tipleri örneði.

using System;
namespace VeriTipleri {
    class DeðerTipleri {
        static void Main (string[] args) {
            Console.WriteLine ("Üç veri tipi vardýr: value/deðer, referans ve pointer/gösterge tip.");
            Console.WriteLine ("\nSystem.ValueType sýnýfýndaki doðrudan sayýsal veya karaktersel deðerler içeren deðer tipleri þunlardýr (c#-2010):");
            Console.Write ("\nTÝP, TEMSÝL ETTÝÐÝ, KAPSAMI, VARSAYILI DEÐERÝ\n----------------------------------------------------\n1) bool, Ýkili deðer, True veya False, False\n2) byte, 8-bit iþaretsiz tamsayý, 0-->255, 0\n3) char, 16-bit ünikod krk, U+0000-->U+ffff, '\\0'\\n4) decimal, 128-bit 28-29 hassasiyetli ondalýk sayýlar, (-7.9e28-->7.9e28)/1e0-->1e28, 0.0M\n5) double, 64-bit çift-hassasiyetli kayannokta, -+5e-324-->-+1.7e308, 0.0D\n6) float, 32-bit tek-hassasiyetli kayannokta, -3.4e38-->3.4e38, 0.0F\n7) int, 32-bit iþaretli tamsayý, -2.147.483.648-->2.147.483.647, 0\n8) long, 64-bit iþaretli uzun tamsayý, -9.223.372.036.854.775.808-->9.223.372.036.854.775.807, 0L\n9) sbyte, 8-bit iþaretli bayt tamsayý, -128-->127, 0\n10) short, 16-bit iþaretli kýsa tamsayý, -32.768-->32.767, 0\n11) uint, 32-bit iþaretsiz tamsayý, 0-->4.294.967.295, 0\n12) ulong, 64-bit iþaretsiz uzun tamsayý, 0-->18.446.744.073.709.551.615, 0\n13) ushort, 16-bit iþaresiz kýsa tamsayý, 0-->65.535, 0\nTuþ...");
            Console.ReadKey();
        }
    }
}