// jtpc#2306b.cs: Farkl� tipleri i�eren t�ple veri yap�s� �rne�i.

using System;
namespace Yeni�zellikler {
    class T�ple {
        static void Main() {
            Console.Write ("Bir-sekiz farkl� veri yap�s� yaratabilen t�ple metodlar�: Create<T1>(T1), Create<T1,T2>(T1,T2), Create<T1,T2,T3>(T1,T2,T3), Create(T1,T2,T3,T4), Create<T1,T2,T3,T4,T5>(T1,T2,T3,T4,T5), Create<T1,T2,T3,T4,T5,T6>(T1,T2,T3,T4,T5,T6), Create<T1,T2,T3,T4,T5,T6,T7>(T1,T2,T3,T4,T5,T6,T7), Create<T1,T2,T3,T4,T5,T6,T7,T8>(T1,T2,T3,T4,T5,T6,T7,T8).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            //Do�rudan new Tuple<T1,T2,T3>(T1,T2,T3) ile kay�t yaratma
            var kitap1 = new Tuple<string, string, double> ("C# uygulamalar�", "Jon Skeet", 15360.50);
            var kitap2 = new Tuple<string, string, double> ("C# temelleri", "Jon Skeet", 9500.00);
            var kitap3 = new Tuple<string, string, double> ("�leri C#", "Jon Skeet", 12460.50);
            Console.WriteLine ("{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap1.Item2, kitap1.Item3, kitap1.Item1);
            Console.WriteLine ("{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap2.Item2, kitap2.Item3, kitap2.Item1);
            Console.WriteLine ("{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap3.Item2, kitap3.Item3, kitap3.Item1);

            //Statik 3'l� Create metoduyla kay�t yaratma
            var kitap4 = Tuple.Create ("C# uygulamalar�", "Jon Skeet", 15360.50);
            var kitap5 = Tuple.Create ("C# temelleri", "Jon Skeet", 9500.00);
            var kitap6 = Tuple.Create ("�leri C#", "Jon Skeet", 12460.50);
            Console.WriteLine ("\n{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap4.Item2, kitap4.Item3, kitap4.Item1);
            Console.WriteLine ("{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap5.Item2, kitap5.Item3, kitap5.Item1);
            Console.WriteLine ("{0}'in {1} TL'l�k [{2}] adl� kitab�", kitap6.Item2, kitap6.Item3, kitap6.Item1);

            var ��renci = Tuple.Create (1001, "Nur K���kbay", "nrkucukbay@gmail.com");
            Console.WriteLine ("\n{0} no'lu ��renci {1}'in epostas�: {2}", ��renci.Item1, ��renci.Item2, ��renci.Item3);
            ��renci = Tuple.Create (1002, "Y�cel K���kbay", "yckucukbay@gmail.com");
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", ��renci.Item1, ��renci.Item2, ��renci.Item3);
            ��renci = Tuple.Create (1003, "Serap K���kbay", "srkucukbay@gmail.com");
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", ��renci.Item1, ��renci.Item2, ��renci.Item3);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}