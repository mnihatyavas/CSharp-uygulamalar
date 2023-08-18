// j2sc#0409.cs: 'Goto etiket' ile �arts�z 'etiket:'e atlama �rne�i.

using System;
namespace �fadeler {
    class Goto {
        static void Main() {
            Console.Write ("�arts�z 'goto' ile belirtilen 'etiket:'e atlan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Switch-case'lerde break yerine di�er case:'e goto ile atlama:");
            int i, k;
            for (i=1; i <= 5; i++) {
                switch (i) {
                    case 4: Console.WriteLine ("case 2:"); goto case 2;
                    case 1: Console.WriteLine ("case 1:"); goto case 3;
                    default: Console.WriteLine ("\tdefault: ve ��k��"); break;
                    case 2: Console.WriteLine ("case 2:"); goto case 1;
                    case 3: Console.WriteLine ("case 3:"); goto default;
                }
            }

            Console.WriteLine ("\nFor d�ng�s�nden if(�art)goto ile erken ��k��:");
            for (i=0; i < 1000; i++) {
                Console.WriteLine ("i = {0}/1000", i);
                if (i == 5) goto DUR;
            }
            DUR: Console.WriteLine ("Durdum!");

            Console.WriteLine ("\nEtiket: ile 'goto Etiket' aras�nda �artl� d�ng� kurma:");
            i=k=0;
            Etiket: i++;
            k +=i;
            if (i <= 5) {Console.WriteLine ("Saya�={0}/5\tToplam={1}", i, k); goto Etiket;}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}