// jtpc#2305b.cs: Try-catch bloðunun when anahtarkelimeli þartlý kýlýnmasý örneði.

using System;
namespace YeniÖzellikler {
    class SüzgeçliÝstisna {
        static void DiðerMetod1 (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}
        static void DiðerMetod2 (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        static void Main() {
            Console.Write ("Try-catch bloðunun catch safhasý when anahtarkelimesiyle þartlý yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            try {int[] a = new int[5]; //5 elemanlý dizi
                a [10] = 2023; //10.elemana atama  IndexOutOfRangeException fýrlatýr
            }catch (Exception hata) /*when (hata.GetType().ToString() == "System.IndexOutOfRangeException")*/ {DiðerMetod1 (hata);}

            try {throw new IndexOutOfRangeException ("Dizi Kapsam Taþma Ýstisnasý oluþtu"); 
            }catch (Exception hata) /*when (hata.Message  == "Dizi Kapsam Taþma Ýstisnasý oluþtu")*/ {DiðerMetod2 (hata.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}