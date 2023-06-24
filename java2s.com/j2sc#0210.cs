// j2sc#0210.cs: Ondalýk ve onaltýlýk sayýlar arasýnda çevrimler örneði.

using System;
namespace VeriTipleri {
    class Onaltýlýk {
        static void Main() {
            Console.Write ("Bir tamsayý {0:X} formatýyla onaltýlýða çevrilirken, '0x' önekli onaltýlýk bir sayý da ondalýða çevrilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random(); int ts1=r.Next (1000, 10000), ts2=r.Next (1000, 10000);
            Console.WriteLine ("Ondalýk: {0} = Onaltýlýk: {1:X}", ts1, ts1);
            Console.WriteLine ("Ondalýk: {0:D8} = Onaltýlýk: {1:X8}", ts2, ts2);

            Console.WriteLine ("\nOndalýðýn onaltýlýk karþýlýðý: 0x{0:X}", 2023);
            Console.WriteLine ("Onaltýlýðýn ondalýk karþýlýðý: {0}", 0x7e7);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}