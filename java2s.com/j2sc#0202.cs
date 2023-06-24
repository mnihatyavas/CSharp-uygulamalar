// j2sc#0202.cs: Bool mant�ksal true/false �zellikleri ve metodlar� �rne�i.

using System;
namespace VeriTipleri {
    class Bool {
        static void Main() {
            Console.Write ("Ald��� de�erler sadece true/do�ru ve false/yanl��.\n�zellikleri: bool.FalseString ve bool.TrueString.\nMetotlar�: CompareTo(), Equals(), GetHashCode(), GetTypeCode(), Parse(), ToString().\nTu�...");Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("-10 > -5 ? " + (-10 > -5));
            Console.WriteLine ("10 > 5 ? " + (10 > 5));

            bool b1, b2=true;
            Console.WriteLine ("\nb1 = " + (b1=false));
            Console.WriteLine ("b1 = " + (b1=true));
            if (b1) Console.WriteLine ("If �art� do�ru/true ise bu ifade i�letilir.");
            if (!(b1=false)) Console.WriteLine ("If �art� yanl��/false ise bu ifade i�letilir.");

            if (b2) Console.WriteLine ("\nIf (b2) �art� do�ru/true ise bu ifade i�letilir.");
            if (!b1) Console.WriteLine ("If (!b1) �art� do�ru/true ise bu ifade i�letilir.");
            if (!b1 && b2) Console.WriteLine ("If (!b1 && b2) �art� do�ru/true ise bu ifade i�letilir.");
            if (b1 || b2) Console.WriteLine ("If (b1 || b2) �art� do�ru/true ise bu ifade i�letilir.");

            bool b3 = true, b4 = false, b5 = b1, b6 = bool.Parse ("True");
            System.Boolean b7 = bool.Parse (bool.TrueString);
            bool b8 = new bool();
            var b9 = new bool(); b9 = true;;
            Console.WriteLine ("\nBool veriler: b3={0}, b4={1}, b5={2}, b6={3}, b7={4}, b8={5}, b9={6}", b3, b4, b5, b6, b7, b8, b9);

            bool b10 = bool.Parse ("True"), b11 = true, b12 = false;
            string s1 = b10.ToString(), s2 = b11.ToString(), s3 = b12.ToString();
            Console.WriteLine ("\nBool ve string veriler: b10={0}, s1={1}, b11={2}, s2={3}, b12={4}, s3={5}", b10, s1, b11, s2, b12, s3);

            Console.WriteLine ("\ntrue.CompareTo (true): == {0}", true.CompareTo (true));
            Console.WriteLine ("true.CompareTo (false): > {0}", true.CompareTo (false));
            Console.WriteLine ("false.CompareTo (true): < {0}", false.CompareTo (true));
            Console.WriteLine ("false.CompareTo (false): == {0}", false.CompareTo (false));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}