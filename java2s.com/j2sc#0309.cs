// j2sc#0309.cs: Bitvari iþlemler (AND=&, OR=|, XOR=^, DEÐÝL=~, KAYDIR=<<>>) örneði.

using System;
namespace Ýþlemciler {
    class BitvariÝþlemci {
        static void Main() {
            Console.Write ("Bitvari iþlemcilerin (VE=&, VEYA=|, FARKLIYSA=^, DEÐÝL=~, KAYDIR: SAÐA=>>, SOLA=<<) iþlenen tipi sadece tamsayý olmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=2023, ts2=1881; //7E7=0111 1110 0111 ve 759=0111 0101 1001
            Console.WriteLine ("ts1={0}={0:X} ve ts2={1}={1:X} ise, bitvari iþlemleri:", ts1, ts2);
            Console.WriteLine ("ts1 & ts2 = {0}", (ts1 & ts2));
            Console.WriteLine ("ts1 | ts2 = {0}", (ts1 | ts2));
            Console.WriteLine ("ts1 ^ ts2 = {0}", (ts1 ^ ts2));
            Console.WriteLine ("~ts1 ve ~ts2 = {0}, {1}", ~ts1, ~ts2);
            Console.WriteLine ("ts1>>=2 ve ts2<<=2 = {0}, {1}", (ts1>>=2), (ts2<<=2));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}