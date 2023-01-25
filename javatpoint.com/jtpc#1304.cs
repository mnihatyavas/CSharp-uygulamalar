// jtpc#1304.cs: Tamsayýlarda kontrolsuz/kontrollu taþma hatalarý örneði.

using System;
namespace ÝstisnaYönetimi {
    class CheckedUnchecked {
        static void Main() {
            Console.Write ("Sadece tamsayýlarda, taþma hatalarý, normalda veya unchecked/kontrolsuz blokta hatasýzmýþcasýna eðreti verilirken, checked/kontrollu blokta hatayý yansýtarak yönetilmezse akýþý kýrar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            tekrar: int sayý=0;
            Console.Write ("Bir -+tamsayý gir [SON: 999]: "); //goto döngüsünden sadece 999 ile çýkýlýr
            try {
                sayý = Convert.ToInt32 (Console.ReadLine());
                if (sayý == 999) goto son;
                unchecked {Console.WriteLine ("unchecked: {0} + {1} = {2}", sayý, int.MaxValue, sayý+int.MaxValue);}
                checked {Console.Write ("checked: {0} + {1} = ", sayý, int.MaxValue); Console.Write (sayý+int.MaxValue + "\n\n");}
                goto tekrar;
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]\n", hata); goto tekrar;}
            son: Console.WriteLine ("\nNormal program akýþýna devam"); 

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}