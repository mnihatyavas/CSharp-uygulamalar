// j2sc#0210.cs: Ondal�k ve onalt�l�k say�lar aras�nda �evrimler �rne�i.

using System;
namespace VeriTipleri {
    class Onalt�l�k {
        static void Main() {
            Console.Write ("Bir tamsay� {0:X} format�yla onalt�l��a �evrilirken, '0x' �nekli onalt�l�k bir say� da ondal��a �evrilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random(); int ts1=r.Next (1000, 10000), ts2=r.Next (1000, 10000);
            Console.WriteLine ("Ondal�k: {0} = Onalt�l�k: {1:X}", ts1, ts1);
            Console.WriteLine ("Ondal�k: {0:D8} = Onalt�l�k: {1:X8}", ts2, ts2);

            Console.WriteLine ("\nOndal���n onalt�l�k kar��l���: 0x{0:X}", 2023);
            Console.WriteLine ("Onalt�l���n ondal�k kar��l���: {0}", 0x7e7);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}