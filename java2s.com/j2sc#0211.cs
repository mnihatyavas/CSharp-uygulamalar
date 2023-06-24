// j2sc#0211.cs: Uzun tamsayý long ile kutulama ve hesaplamalar örneði.

using System;
namespace VeriTipleri {
    class Long {
        static void Main() {
            Console.Write ("Uzun tamsayýnýn azami deðeri ondalýk D20 ve onaltýlýk X20 formatlý kýyaslanabilir. Uzun, nesneye kutulanýp tekrar kutusuzlanabilir. Bir tamsayý üstü uzuna doðrudan atanýrken, astý kýsaya belirtili (short) ile atanmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            long uz1 = 0x7FFFFFL, uz2 = long.MaxValue; //Onaltýlýk sabitenin ut/uzun-tamsayý'ya atanmasý

            Console.WriteLine ("Onaltýlýk: {0:X} atanan uzun-tamsayý: {1}", uz1, uz1);
            Console.WriteLine ("Enbüyük ondalýk uzun: {0:D20} ve onaltýlýðý: {1:X20}", uz2, uz2);

            uz1 = 2023L;
            object ns1 = uz1;
            uz2 = (long) ns1;
            Console.WriteLine ("\nUzun: {0}\nNesneye kutulanan uzun: {1}\nKutulu nesneden kutusuzlanan uzun: {2}", uz1, ns1, uz2);

            int ts1 = 1881;
            uz1 = ts1;
            short ks1 = (short) ts1;
            Console.WriteLine ("\nTamsayý: {0}\nDoðrudan atanan uzun: {1}\nBelirtili (short)'la atanan kýsa: {2}", ts1, uz1, ks1);

            long inç, mil = 93000000; //Güneþin dünyadan uzaklýðý: 93,000,000 mil
            inç = mil * 5280 * 12; //1 mil=5280 feet, 1 fit=12 inç
            uz1 = (long) (inç * 0.0254); //1 inç=2.54 sm, 1m=100 sm
            Console.WriteLine ("\nDünya'nýn güneþten uzaklýðý: {0} mil = {1} inç = {2} metre = {3} km'dir.", mil, inç, uz1, uz1/1000);

            ulong faktöryel=1;
            for (ulong i = 65; i > 0; i--) faktöryel *= i;
            Console.WriteLine ("\nAzami ulong {0}! = {1:D20}", 65, faktöryel);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}