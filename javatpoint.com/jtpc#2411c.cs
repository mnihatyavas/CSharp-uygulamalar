// jtpc#2411c.cs: Fibonaki serisiyle, girilen tamsay� basamakl� dik��gen piramit kurma �rne�i.

using System;
namespace �rnekler {
    class Fibonaki��geni {
        static void Main() {
            Console.Write ("�nceki iki rakam toplaml� fibonaki serisiyle, girilen basamakl� ��gen piramit, her basamaktaki ard���k rakam say�s� 1-2-3-4... art�r�larak kurulmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i, j, a, b, c;
            Gir: Console.Write ("��genin basamak +say�s�n� [1,22] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 1 ) ts=1; if (ts > 22) ts=22;
            for (i=1; i<=ts; i++) {
                a=0;
                b=1;
                Console.Write (a+" ");
                for (j=1; j<i; j++) {
                    c=a+b;
                    Console.Write (b+" ");
                    a=b;
                    b=c;
                }
                Console.Write ("\n");
            }  
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}