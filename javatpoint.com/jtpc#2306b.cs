// jtpc#2306b.cs: Farklý tipleri içeren tüple veri yapýsý örneði.

using System;
namespace YeniÖzellikler {
    class Tüple {
        static void Main() {
            Console.Write ("Bir-sekiz farklý veri yapýsý yaratabilen tüple metodlarý: Create<T1>(T1), Create<T1,T2>(T1,T2), Create<T1,T2,T3>(T1,T2,T3), Create(T1,T2,T3,T4), Create<T1,T2,T3,T4,T5>(T1,T2,T3,T4,T5), Create<T1,T2,T3,T4,T5,T6>(T1,T2,T3,T4,T5,T6), Create<T1,T2,T3,T4,T5,T6,T7>(T1,T2,T3,T4,T5,T6,T7), Create<T1,T2,T3,T4,T5,T6,T7,T8>(T1,T2,T3,T4,T5,T6,T7,T8).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            //Doðrudan new Tuple<T1,T2,T3>(T1,T2,T3) ile kayýt yaratma
            var kitap1 = new Tuple<string, string, double> ("C# uygulamalarý", "Jon Skeet", 15360.50);
            var kitap2 = new Tuple<string, string, double> ("C# temelleri", "Jon Skeet", 9500.00);
            var kitap3 = new Tuple<string, string, double> ("Ýleri C#", "Jon Skeet", 12460.50);
            Console.WriteLine ("{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap1.Item2, kitap1.Item3, kitap1.Item1);
            Console.WriteLine ("{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap2.Item2, kitap2.Item3, kitap2.Item1);
            Console.WriteLine ("{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap3.Item2, kitap3.Item3, kitap3.Item1);

            //Statik 3'lü Create metoduyla kayýt yaratma
            var kitap4 = Tuple.Create ("C# uygulamalarý", "Jon Skeet", 15360.50);
            var kitap5 = Tuple.Create ("C# temelleri", "Jon Skeet", 9500.00);
            var kitap6 = Tuple.Create ("Ýleri C#", "Jon Skeet", 12460.50);
            Console.WriteLine ("\n{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap4.Item2, kitap4.Item3, kitap4.Item1);
            Console.WriteLine ("{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap5.Item2, kitap5.Item3, kitap5.Item1);
            Console.WriteLine ("{0}'in {1} TL'lýk [{2}] adlý kitabý", kitap6.Item2, kitap6.Item3, kitap6.Item1);

            var öðrenci = Tuple.Create (1001, "Nur Küçükbay", "nrkucukbay@gmail.com");
            Console.WriteLine ("\n{0} no'lu öðrenci {1}'in epostasý: {2}", öðrenci.Item1, öðrenci.Item2, öðrenci.Item3);
            öðrenci = Tuple.Create (1002, "Yücel Küçükbay", "yckucukbay@gmail.com");
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", öðrenci.Item1, öðrenci.Item2, öðrenci.Item3);
            öðrenci = Tuple.Create (1003, "Serap Küçükbay", "srkucukbay@gmail.com");
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", öðrenci.Item1, öðrenci.Item2, öðrenci.Item3);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}