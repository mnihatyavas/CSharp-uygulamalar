// j2sc#0212.cs: Kontrollu/kontrolsuz/belirtisiz byte ta�malar�n�n try-catch y�netimi �rne�i.

using System;using System.Globalization;
namespace VeriTipleri {
    class Byte {
        static void Main() {
            Console.Write ("Kontrolsuz/unchecked ile unchecked'siz belirtili (byte) �evrimi hata vermeksizin, 0-->255 ta�mas�n� bu kapsamla s�n�rlar. Ancak kontrollu/checked blo�u bu ta�malara hata f�rlat�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            byte b1=0, b2, b3;
            Console.WriteLine ("System.Byte enk���k ve enb�y�k de�erleri: [{0}, {1}]\nByte Tipi ve ebat�: {2}, 1 {3}", byte.MinValue, byte.MaxValue, b1.GetType(), b1.GetTypeCode());
            Console.WriteLine ("byte ta�mas� olu�ursa yakalanacak...");
            try {Console.WriteLine ("(byte)({0} + {1} + -100)={2}", (b1=9), (b2=19), (b3=(byte)(b1 + b2 + -100)));} catch (Exception h){Console.WriteLine ("Hata: [{0}]", h);}
            try {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=90), (b2=190), (b3=(byte)(b1 + b2)));} catch (OverflowException h){Console.WriteLine ("Ta�ma hatas�: [{0}]", h);}

            Console.WriteLine ("\nKontrollu ve kontrolsuz kodlama...");
            try {checked {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=100), (b2=200), (b3=(byte)(b1 + b2)));}} catch (OverflowException h){Console.WriteLine ("Kontrollu ta�ma hatas�: [{0}]", h);}
            try {unchecked {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=101), (b2=201), (b3=(byte)(b1 + b2)));}} catch (OverflowException h){Console.WriteLine ("Kontrolsuz ta�ma hatas�: [{0}]", h);}
            
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}