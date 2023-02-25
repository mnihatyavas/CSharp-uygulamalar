// jtpc#230103.cs: Hiçlenebilen deðer de alabilen deðiþkenler örneði.

using System;
namespace YeniÖzellikler {
    class HiçlenebilenTipler {
        static void Main() {
            Console.Write ("Hiçlenebilen Nullable deðiþkenler, kendi tip deðerleri yanýsýra, hata vermeksizin 'null' deðer de içerebilir. System.Nullable tiplemeli veya ? iþlemcili yaratýlabilir. Referanslý deðiþkenlerde kullanýlamaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Nullable<int> a = 2023;
            Nullable<double> d = Math.PI;
            Nullable<char> c = 'M';
            Nullable<bool> b = true;
            char[] s = new char[] {'M', '.', 'N', 'i', 'h', 'a', 't', ' ', 'Y', 'a', 'v', 'a', 'þ'}; //Referans tipli string Nullable olmaz
            Console.WriteLine ("int({0}), double({1}), char({2}), bool({3}), string({4})", a.Value, d, c, b, new string (s));

            a = null; d = null; c = null; b = null; s = null;
            Console.WriteLine ("Nullable tiplemeli: int({0}), double({1}), char({2}), bool({3}), string({4})", a, d, c, b, new string (s));
            if (a.HasValue) Console.WriteLine (a.Value);
            if(a == null & d==null & c==null & b==null & s==null) Console.WriteLine ("Mevcut tüm deðiþken deðerleri 'null'dur.");

            int? ab = 2023;
            double? ds = Math.PI;
            char? cs = 'M';
            bool? bs = false;
            Console.WriteLine ("\nint({0}), double({1}), char({2}), bool({3}))", ab.Value, ds, cs, bs);

            ab = null; ds = null; cs = null; bs = null;
            Console.WriteLine ("? iþlemcili: int({0}), double({1}), char({2}), bool({3})", ab, ds, cs, bs);
            if (ab.HasValue) Console.WriteLine (ab.Value);
            if(ab==null & ds==null & cs==null & bs==null) Console.WriteLine ("Mevcut tüm deðiþken deðerleri 'null'dur.");

            //int n = null; //Nullable olmayan int'e null atanamaz, derleme hatasý verir

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}