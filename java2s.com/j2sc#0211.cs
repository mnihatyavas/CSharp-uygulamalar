// j2sc#0211.cs: Uzun tamsay� long ile kutulama ve hesaplamalar �rne�i.

using System;
namespace VeriTipleri {
    class Long {
        static void Main() {
            Console.Write ("Uzun tamsay�n�n azami de�eri ondal�k D20 ve onalt�l�k X20 formatl� k�yaslanabilir. Uzun, nesneye kutulan�p tekrar kutusuzlanabilir. Bir tamsay� �st� uzuna do�rudan atan�rken, ast� k�saya belirtili (short) ile atanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            long uz1 = 0x7FFFFFL, uz2 = long.MaxValue; //Onalt�l�k sabitenin ut/uzun-tamsay�'ya atanmas�

            Console.WriteLine ("Onalt�l�k: {0:X} atanan uzun-tamsay�: {1}", uz1, uz1);
            Console.WriteLine ("Enb�y�k ondal�k uzun: {0:D20} ve onalt�l���: {1:X20}", uz2, uz2);

            uz1 = 2023L;
            object ns1 = uz1;
            uz2 = (long) ns1;
            Console.WriteLine ("\nUzun: {0}\nNesneye kutulanan uzun: {1}\nKutulu nesneden kutusuzlanan uzun: {2}", uz1, ns1, uz2);

            int ts1 = 1881;
            uz1 = ts1;
            short ks1 = (short) ts1;
            Console.WriteLine ("\nTamsay�: {0}\nDo�rudan atanan uzun: {1}\nBelirtili (short)'la atanan k�sa: {2}", ts1, uz1, ks1);

            long in�, mil = 93000000; //G�ne�in d�nyadan uzakl���: 93,000,000 mil
            in� = mil * 5280 * 12; //1 mil=5280 feet, 1 fit=12 in�
            uz1 = (long) (in� * 0.0254); //1 in�=2.54 sm, 1m=100 sm
            Console.WriteLine ("\nD�nya'n�n g�ne�ten uzakl���: {0} mil = {1} in� = {2} metre = {3} km'dir.", mil, in�, uz1, uz1/1000);

            ulong fakt�ryel=1;
            for (ulong i = 65; i > 0; i--) fakt�ryel *= i;
            Console.WriteLine ("\nAzami ulong {0}! = {1:D20}", 65, fakt�ryel);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}