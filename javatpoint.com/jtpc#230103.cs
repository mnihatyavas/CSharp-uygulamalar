// jtpc#230103.cs: Hi�lenebilen de�er de alabilen de�i�kenler �rne�i.

using System;
namespace Yeni�zellikler {
    class Hi�lenebilenTipler {
        static void Main() {
            Console.Write ("Hi�lenebilen Nullable de�i�kenler, kendi tip de�erleri yan�s�ra, hata vermeksizin 'null' de�er de i�erebilir. System.Nullable tiplemeli veya ? i�lemcili yarat�labilir. Referansl� de�i�kenlerde kullan�lamaz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Nullable<int> a = 2023;
            Nullable<double> d = Math.PI;
            Nullable<char> c = 'M';
            Nullable<bool> b = true;
            char[] s = new char[] {'M', '.', 'N', 'i', 'h', 'a', 't', ' ', 'Y', 'a', 'v', 'a', '�'}; //Referans tipli string Nullable olmaz
            Console.WriteLine ("int({0}), double({1}), char({2}), bool({3}), string({4})", a.Value, d, c, b, new string (s));

            a = null; d = null; c = null; b = null; s = null;
            Console.WriteLine ("Nullable tiplemeli: int({0}), double({1}), char({2}), bool({3}), string({4})", a, d, c, b, new string (s));
            if (a.HasValue) Console.WriteLine (a.Value);
            if(a == null & d==null & c==null & b==null & s==null) Console.WriteLine ("Mevcut t�m de�i�ken de�erleri 'null'dur.");

            int? ab = 2023;
            double? ds = Math.PI;
            char? cs = 'M';
            bool? bs = false;
            Console.WriteLine ("\nint({0}), double({1}), char({2}), bool({3}))", ab.Value, ds, cs, bs);

            ab = null; ds = null; cs = null; bs = null;
            Console.WriteLine ("? i�lemcili: int({0}), double({1}), char({2}), bool({3})", ab, ds, cs, bs);
            if (ab.HasValue) Console.WriteLine (ab.Value);
            if(ab==null & ds==null & cs==null & bs==null) Console.WriteLine ("Mevcut t�m de�i�ken de�erleri 'null'dur.");

            //int n = null; //Nullable olmayan int'e null atanamaz, derleme hatas� verir

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}