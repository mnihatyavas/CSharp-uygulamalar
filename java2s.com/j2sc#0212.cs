// j2sc#0212.cs: Kontrollu/kontrolsuz/belirtisiz byte taþmalarýnýn try-catch yönetimi örneði.

using System;using System.Globalization;
namespace VeriTipleri {
    class Byte {
        static void Main() {
            Console.Write ("Kontrolsuz/unchecked ile unchecked'siz belirtili (byte) çevrimi hata vermeksizin, 0-->255 taþmasýný bu kapsamla sýnýrlar. Ancak kontrollu/checked bloðu bu taþmalara hata fýrlatýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            byte b1=0, b2, b3;
            Console.WriteLine ("System.Byte enküçük ve enbüyük deðerleri: [{0}, {1}]\nByte Tipi ve ebatý: {2}, 1 {3}", byte.MinValue, byte.MaxValue, b1.GetType(), b1.GetTypeCode());
            Console.WriteLine ("byte taþmasý oluþursa yakalanacak...");
            try {Console.WriteLine ("(byte)({0} + {1} + -100)={2}", (b1=9), (b2=19), (b3=(byte)(b1 + b2 + -100)));} catch (Exception h){Console.WriteLine ("Hata: [{0}]", h);}
            try {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=90), (b2=190), (b3=(byte)(b1 + b2)));} catch (OverflowException h){Console.WriteLine ("Taþma hatasý: [{0}]", h);}

            Console.WriteLine ("\nKontrollu ve kontrolsuz kodlama...");
            try {checked {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=100), (b2=200), (b3=(byte)(b1 + b2)));}} catch (OverflowException h){Console.WriteLine ("Kontrollu taþma hatasý: [{0}]", h);}
            try {unchecked {Console.WriteLine ("(byte)({0} + {1})={2}", (b1=101), (b2=201), (b3=(byte)(b1 + b2)));}} catch (OverflowException h){Console.WriteLine ("Kontrolsuz taþma hatasý: [{0}]", h);}
            
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}