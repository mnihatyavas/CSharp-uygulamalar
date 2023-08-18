// j2sc#0409.cs: 'Goto etiket' ile þartsýz 'etiket:'e atlama örneði.

using System;
namespace Ýfadeler {
    class Goto {
        static void Main() {
            Console.Write ("Þartsýz 'goto' ile belirtilen 'etiket:'e atlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Switch-case'lerde break yerine diðer case:'e goto ile atlama:");
            int i, k;
            for (i=1; i <= 5; i++) {
                switch (i) {
                    case 4: Console.WriteLine ("case 2:"); goto case 2;
                    case 1: Console.WriteLine ("case 1:"); goto case 3;
                    default: Console.WriteLine ("\tdefault: ve çýkýþ"); break;
                    case 2: Console.WriteLine ("case 2:"); goto case 1;
                    case 3: Console.WriteLine ("case 3:"); goto default;
                }
            }

            Console.WriteLine ("\nFor döngüsünden if(þart)goto ile erken çýkýþ:");
            for (i=0; i < 1000; i++) {
                Console.WriteLine ("i = {0}/1000", i);
                if (i == 5) goto DUR;
            }
            DUR: Console.WriteLine ("Durdum!");

            Console.WriteLine ("\nEtiket: ile 'goto Etiket' arasýnda þartlý döngü kurma:");
            i=k=0;
            Etiket: i++;
            k +=i;
            if (i <= 5) {Console.WriteLine ("Sayaç={0}/5\tToplam={1}", i, k); goto Etiket;}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}