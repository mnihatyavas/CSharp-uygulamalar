// jtpc#1304.cs: Tamsay�larda kontrolsuz/kontrollu ta�ma hatalar� �rne�i.

using System;
namespace �stisnaY�netimi {
    class CheckedUnchecked {
        static void Main() {
            Console.Write ("Sadece tamsay�larda, ta�ma hatalar�, normalda veya unchecked/kontrolsuz blokta hatas�zm��cas�na e�reti verilirken, checked/kontrollu blokta hatay� yans�tarak y�netilmezse ak��� k�rar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            tekrar: int say�=0;
            Console.Write ("Bir -+tamsay� gir [SON: 999]: "); //goto d�ng�s�nden sadece 999 ile ��k�l�r
            try {
                say� = Convert.ToInt32 (Console.ReadLine());
                if (say� == 999) goto son;
                unchecked {Console.WriteLine ("unchecked: {0} + {1} = {2}", say�, int.MaxValue, say�+int.MaxValue);}
                checked {Console.Write ("checked: {0} + {1} = ", say�, int.MaxValue); Console.Write (say�+int.MaxValue + "\n\n");}
                goto tekrar;
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]\n", hata); goto tekrar;}
            son: Console.WriteLine ("\nNormal program ak���na devam"); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}