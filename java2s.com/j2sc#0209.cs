// j2sc#0209.cs: Parse() metotla girilen dizgenin tamsayýya ayrýþtýrýlmasý örneði.

using System;
namespace VeriTipleri {
    class TamsayýyaAyrýþtýr {
        static void Main() {
            Console.Write ("Int32.Parse(), int.Parse() ve int.TryParse() metotlarýyla Console.ReadLine() dizgesel giriþler tamsayýya çevrilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts = Int32.Parse ("2023"); Console.WriteLine ("Ayrýþtýrýlan deðer: {0}", ts);
            ts = int.Parse ("1881"); Console.WriteLine ("Ayrýþtýrýlan deðer: {0}", ts);

            Console.Write ("\nBir tamsayý gir [Ent]: ");
            while (! int.TryParse (Console.ReadLine(), out ts)) {Console.Write ("HATA: Tekrar deneyin [Ent]: ");}
            Console.WriteLine ("Girdiðiniz tamsayý: " + ts.ToString());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}