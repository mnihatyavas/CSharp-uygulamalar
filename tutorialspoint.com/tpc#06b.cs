// tpc#06b.cs: Veri tipleri çevrimleri metodlarý örneði.

using System;
namespace TipÇevrimi {
    class ÇevrimMetodlarý {
        static void Main (string[] args) {
            Console.WriteLine ("Tüm c# tip çevrimi arþiv metotlarý: ToBoolean, ToByte, ToChar, ToDateTime, ToDecimal, ToDouble, ToInt16, ToInt32, ToInt64, ToSbyte, ToSingle, ToString, ToType..., ToUInt16, ToUInt32, ToUInt64.\nÖrnek:\n");
            // Tüm tipleri dizgeye çevirme
            int i = 75;
            long l = 9223372036854775807L;
            float f = 53.005f;
            double db = 2.718281828459045;
            bool b = true;
            decimal dc = 3.141592653589793M;
            Console.Write ("int i = {0}, String i = {1}\nlong l = {2}, String l = {3}\nfloat f = {4}, String f = {5}\ndouble db = {6}, String db = {7}\nbool b = {8}, String b = {9}\ndecimal dc = {10}, String dc = {11}\n\nTuþ...", i, i.ToString(), l, l.ToString(), f, f.ToString(), db, db.ToString(), b, b.ToString(), dc, dc.ToString() );
            Console.ReadKey();
        }
    }
}