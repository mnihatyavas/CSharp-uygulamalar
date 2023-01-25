// jtpc#1301.cs: Fýrlatýlan sýfýra bölüm istisnasýnýn yakalanýp yönetilmesi örneði.

using System;
namespace ÝstisnaYönetimi {
    class TryCatch {
        static void Main() {
            Console.Write ("Çalýþmazamanlý hatalar, ilgili  System.Exception sýnýf hata nesnesini fýrlatýp programý kýrar. Ýstisna yönetimi bu istisnayý yönetip, normal program akýþýný sürdürür.\nSystem.Exception'ýn birkaç türev sýnýfý: System.DivideByZeroException, System.NullReferenceException, System.InvalidCastException, System.IO.IOException, System.FieldAccessException\nÝstisna yönetiminin 4 anahtarkelimesi: try, catch, finally, throw\nAyrýca kullanýcý-tanýmlý özel istisnalar da yaratýlabilir.\nTry bloðu fýrlatýlabilecek istisna kodlamasýný, catch bloðuysa fýrlatýlan istisnayý yakalayýp yöneten kodlamayý içerir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int a = 10;
                int b = 0;
                Console.Write ("a/b={0}/{1}=", a, b);
                Console.Write (a/b);
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata);}
            Console.WriteLine ("\nNormal program akýþýna devam"); 

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}