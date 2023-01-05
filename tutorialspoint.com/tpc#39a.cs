// tpc#39a.cs: Ana sicimin yarat�lmas� ve adland�r�lmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class AnaSicim {
        static void Main() {
            Console.Write ("�oklug�rev/sicim CPU/M�B payla��m�yla, bir program i�inde ayn� anda birden fazla g�revin icras�d�r. Herbir g�rev thread/ip-sicim olarak adland�r�l�r. Bir sicimin �e�itli durumlar�: ba�lamad�, haz�r, ko�turulamaz (uyku, bekleme, blokeli), �l� (sonland�, k�r�ld�). �lk �al��an ana sicim olup, Thread'le yarat�lanlar �ocuk sicimler, akt�el sicimi tespitleyen ise CurrentThread �zelli�idir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip1 = Thread.CurrentThread;
            ip1.Name = "AnaSicim";
            Console.WriteLine ("Ak�el �al��an sicim ad�: {0}", ip1.Name);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}