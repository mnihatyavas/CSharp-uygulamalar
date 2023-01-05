// tpc#38d.cs: Liste de�er ve adreslerini g�sterge�e atayarak g�r�nt�leme �rne�i.

using System;
namespace G�venilmezKodlamalar {
    class G�sterge�liDizi {
        unsafe static void Main() {
            Console.Write ("Liste[] tipin haf�za adresi sabit oldu�undan fixed(...) anahtarkelimesi i�inde liste-g�sterge�ine dizinin ilk eleman &adresini atamak, fixed ifade sonras� ; koymamak ve g�sterge�i araya ba�ka ifade-ler girmeden kullanmak gerekmektedir. Aksi durumlarda hep derleme hatas� verir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] tListe = {1932, 1933, 1953, 1954, 1954, 1957, 1959, 1961, 1963};
            Console.WriteLine ("Liste g�sterge� adres ve de�erleri:\n-----------------------------------");
            fixed (int *lg = &tListe[0])
            for (int i = 0; i < tListe.Length; i++) Console.WriteLine ("{0}: [{1}={2} ==>{3}]", i, tListe [i], *(lg + i), (int)(lg + i));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}