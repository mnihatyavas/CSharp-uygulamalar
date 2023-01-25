// jtpc#1201.cs: Dizge yaratma ve dizge metodlarý örneði.

using System;
namespace Dizgeler {
    class Dizge {
        static void Main() {
            Console.Write ("Dizge System.String sýnýfýnýn nesnesi olup, String ve string (alias: arma, öteki ad) aynýdýr.\nBirkaç önemli dizge metodlarý: Clone(), Compare(String,String), CompareOrdinal(String,String), CompareTo(String), Concat(String,String), Contains(String), Copy(String), CopyTo(Int32,Char[],Int32,Int32), EndsWith(String), Equals(String,String), Format(String,Object), GetEnumerator(), GetHashCode(), GetType(), GetTypeCode(), IndexOf(String), Insert(Int32,String), Intern(String), IsInterned(String), IsNormalized(), IsNullOrEmpty(String), IsNullOrWhiteSpace(String), Join(String,String[]), LastIndexOf(Char), LastIndexOfAny(Char[]), Normalize(), PadLeft(Int32), PadRight(Int32), Remove(Int32), Replace(String,String), Split(Char[]), StartsWith(String), Substring(Int32), ToCharArray(), ToLower(), ToLowerInvariant(), ToString(), ToUpper(), Trim(), TrimEnd(Char[]), TrimStart(Char[])\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string d1 = "Merhaba";
            char[] krkDizi = {'C', 'S', 'h', 'a', 'r', 'p'};
            string d2 = new string (krkDizi);
            String d3 = ", Nasýlsýn";
            String d4 = new String (new char[]{'!', '.', '.'});
            Console.WriteLine (d1 + d2 + d3 + d4);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}