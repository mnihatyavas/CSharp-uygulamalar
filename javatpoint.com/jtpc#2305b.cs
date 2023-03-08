// jtpc#2305b.cs: Try-catch blo�unun when anahtarkelimeli �artl� k�l�nmas� �rne�i.

using System;
namespace Yeni�zellikler {
    class S�zge�li�stisna {
        static void Di�erMetod1 (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}
        static void Di�erMetod2 (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        static void Main() {
            Console.Write ("Try-catch blo�unun catch safhas� when anahtarkelimesiyle �artl� yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            try {int[] a = new int[5]; //5 elemanl� dizi
                a [10] = 2023; //10.elemana atama  IndexOutOfRangeException f�rlat�r
            }catch (Exception hata) /*when (hata.GetType().ToString() == "System.IndexOutOfRangeException")*/ {Di�erMetod1 (hata);}

            try {throw new IndexOutOfRangeException ("Dizi Kapsam Ta�ma �stisnas� olu�tu"); 
            }catch (Exception hata) /*when (hata.Message  == "Dizi Kapsam Ta�ma �stisnas� olu�tu")*/ {Di�erMetod2 (hata.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}