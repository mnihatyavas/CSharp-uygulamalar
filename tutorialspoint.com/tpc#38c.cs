// tpc#38c.cs: G�sterge� de�i�ken-lerin metoda parametrik g�nderilmesi �rne�i.

using System;
namespace G�venilmezKodlamalar {
    class G�sterge�liParametre {
        unsafe public void takas (int* a, int *b) {int ara = *a; *a = *b; *b = ara;}
        unsafe static void Main() {
            Console.Write ("G�sterge� de�i�ken-ler metoda arg�manl� aktar�l�rken ilgili metod parametre-leri g�sterge�li tan�mlanmal�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tsay�1 = 2022, tsay�2 = 2023;
            int *x = &tsay�1; int *y = &tsay�2;
            Console.WriteLine ("Takas �ncesi de�er(adres)ler: tsay�1:{0}({1}), tsay�2: {2}({3})", tsay�1, (int)&tsay�1, tsay�2, (int)&tsay�2);
            G�sterge�liParametre tipleme = new G�sterge�liParametre();
            tipleme.takas (x, y);
            Console.WriteLine ("Takas sonras� de�er(adres)ler: tsay�1:{0}({1}), tsay�2: {2}({3})", tsay�1, (int)&tsay�1, tsay�2, (int)&tsay�2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}