// tpc#38d.cs: Liste deðer ve adreslerini göstergeçe atayarak görüntüleme örneði.

using System;
namespace GüvenilmezKodlamalar {
    class GöstergeçliDizi {
        unsafe static void Main() {
            Console.Write ("Liste[] tipin hafýza adresi sabit olduðundan fixed(...) anahtarkelimesi içinde liste-göstergeçine dizinin ilk eleman &adresini atamak, fixed ifade sonrasý ; koymamak ve göstergeçi araya baþka ifade-ler girmeden kullanmak gerekmektedir. Aksi durumlarda hep derleme hatasý verir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] tListe = {1932, 1933, 1953, 1954, 1954, 1957, 1959, 1961, 1963};
            Console.WriteLine ("Liste göstergeç adres ve deðerleri:\n-----------------------------------");
            fixed (int *lg = &tListe[0])
            for (int i = 0; i < tListe.Length; i++) Console.WriteLine ("{0}: [{1}={2} ==>{3}]", i, tListe [i], *(lg + i), (int)(lg + i));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}