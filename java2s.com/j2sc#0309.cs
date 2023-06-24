// j2sc#0309.cs: Bitvari i�lemler (AND=&, OR=|, XOR=^, DE��L=~, KAYDIR=<<>>) �rne�i.

using System;
namespace ��lemciler {
    class Bitvari��lemci {
        static void Main() {
            Console.Write ("Bitvari i�lemcilerin (VE=&, VEYA=|, FARKLIYSA=^, DE��L=~, KAYDIR: SA�A=>>, SOLA=<<) i�lenen tipi sadece tamsay� olmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=2023, ts2=1881; //7E7=0111 1110 0111 ve 759=0111 0101 1001
            Console.WriteLine ("ts1={0}={0:X} ve ts2={1}={1:X} ise, bitvari i�lemleri:", ts1, ts2);
            Console.WriteLine ("ts1 & ts2 = {0}", (ts1 & ts2));
            Console.WriteLine ("ts1 | ts2 = {0}", (ts1 | ts2));
            Console.WriteLine ("ts1 ^ ts2 = {0}", (ts1 ^ ts2));
            Console.WriteLine ("~ts1 ve ~ts2 = {0}, {1}", ~ts1, ~ts2);
            Console.WriteLine ("ts1>>=2 ve ts2<<=2 = {0}, {1}", (ts1>>=2), (ts2<<=2));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}