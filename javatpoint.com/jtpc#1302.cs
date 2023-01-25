// jtpc#1302.cs: TryCath sonunda herdaim çalýþtýrýlan finally örneði.

using System;
namespace ÝstisnaYönetimi {
    class Finally {
        static void Main() {
            Console.Write ("Ýstisna yönetiminde kullanýmý tercihi olan finally bloðu, istisna fýrlasýn/fýrlamasýn, daima iþletilir. Çoklu catch kullanýlabilir. Exception genel olup, tüm fýrlatýlacak hatalarý yakalar; diðerleriyse sadece kendi özel istisnalarýna duyarlýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int a = 10;
                int b = 0;
                Console.Write ("a/b={0}/{1}=", a, b);
                Console.Write (a/b);
            }catch (NullReferenceException hata) {Console.WriteLine ("HATA-1: [{0}]", hata); //Hata yakalamaz
            }catch (DivideByZeroException hata) {Console.WriteLine ("HATA-2: [{0}]", hata); //Hata yakalar
            }finally {Console.WriteLine("Finally bloðu iþletilmekte");}
            Console.WriteLine ("\nNormal program akýþýna devam"); 

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}