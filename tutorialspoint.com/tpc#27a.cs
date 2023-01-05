// tpc#27a.cs: Try-catch bloðuyla sýfýra bölüm hatasýnýn yakalanmasý örneði.

using System;
namespace ÝstisnaYönetimi {
    class SýfýraBölüm {
        int sonuç;
        SýfýraBölüm() {sonuç = 0;}
        public void böl (int pay, int payda) {
            try {sonuç = pay / payda;
            } catch (DivideByZeroException hata) {Console.WriteLine ("Yakalanan hata: {0}", hata);
            } finally {Console.WriteLine ("[{0}/{1}] bölüm sonucu: {2}\n", pay, payda, sonuç);}
        }
        static void Main() {
            Console.Write ("Try/Dene bloðundaki kodlamanýn çalýþma zamanlý olasý hatasýný yada throw/fýrlattýðýný tek-çoklu catch/yakala ile, programý kýrmadan yöneten, sonuçta/finally çýkýþ kodlamasýný iþleten yöntemdir.\nSystem.SystemExeption'dan türeyen bazý istisna sýnýflarý: System.IO.IOException, System.IndexOutOfRangeException, System.ArrayTypeMismatchException, System.NullReferenceException, System.DivideByZeroException, System.InvalidCastException, System.OutOfMemoryException, System.StackOverflowException\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            new SýfýraBölüm().böl (25, 0);
            new SýfýraBölüm().böl (25, 5);
            new SýfýraBölüm().böl (0, 0);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}