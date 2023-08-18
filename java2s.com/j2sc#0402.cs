// j2sc#0402.cs: Switch-case-default-break yap�l� tercihler �rne�i.

using System;
namespace �fadeler {
    class Switch {
        static void Main() {
            Console.Write ("switch-case-default-break yap�s�nda sabit de�er tamsay� t�rleri veya dizge olabilir. Uyan case olmazsa default, o da yoksa i�lemsizdir. Herbir tercih break'le sonlanmal�d�r, yoksa m�teakiben birbirlerine kar���rlar. Break yerine �arts�z goto case/default atlamas� yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10/0-9 for d�ng�l�k, 5 case ve 1 default ile switch(int) yap�s�:");
            int ts1;
            for (ts1=0; ts1<10; ts1++) //for-{ olmasa da olur
                switch (ts1) {
                    case 4: Console.WriteLine ("int ts1=4"); break; //ts1 s�ralamas� gerekmez
                    case 0: Console.WriteLine ("int ts1=0"); break;
                    case 1: Console.WriteLine ("int ts1=1"); break;
                    default: Console.WriteLine ("int 10 > ts1 >= 5"); break; //default illa sonda gerekmez
                    case 2: Console.WriteLine ("int ts1=2"); break;
                    case 3: Console.WriteLine ("int ts1=3"); break;
                }

            Console.WriteLine ("\n10/A-J for d�ng�l�k, 5 case ve 1 default ile switch(char) yap�s�:");
            char kr1;
            for (kr1='A'; kr1 <= 'J'; kr1++)
                switch (kr1) {
                    case 'E': Console.WriteLine ("int kr1=E"); break;
                    case 'A': Console.WriteLine ("int kr1=A"); break;
                    case 'B': Console.WriteLine ("int kr1=B"); break;
                    default: Console.WriteLine ("int J >= kr1 >= F"); break;
                    case 'C': Console.WriteLine ("int kr1=C"); break;
                    case 'D': Console.WriteLine ("int kr1=D"); break;
                }

            Console.WriteLine ("\n10/0-9 for d�ng�l�, (3 break'siz) 5 case ile default'suz switch(int) yap�s�:");
            for (ts1=0; ts1<10; ts1++) //for-{ olmasa da olur
                switch (ts1) {
                    case 4: Console.WriteLine ("int ts1=4"); break;
                    case 0:
                    case 1:
                    case 2:
                    case 3: Console.WriteLine ("int ts1=(0, 1, 2 veya 3)"); break;
                }

            Console.WriteLine ("\n10/0-9 for d�ng�l�k, break yerine goto'lu switch(int) yap�s�:");
            for (ts1=0; ts1<10; ts1++) {
                switch (ts1) {
                    case 4: Console.WriteLine ("case 4:'teyim"); goto case 2;
                    case 0: Console.WriteLine ("case 0:'day�m"); goto case 4;
                    case 1: Console.WriteLine ("case 1:'deyim"); goto case 3;
                    default: Console.WriteLine ("default:'day�m"); break;
                    case 2: Console.WriteLine ("case 2:'deyim"); goto case 1;
                    case 3: Console.WriteLine ("case 3:'teyim"); goto default;
                    case 5: case 6: case 7: case 8: case 9: Console.WriteLine ("case 5:/6:/7:/8:/9:'day�mm"); goto default;
                }
                Console.WriteLine();
            }

            Console.WriteLine ("10/s�f�r-dokuz foreach d�ng�l�k, switch(string) yap�s�:");
            string[] kelimeler = {"s�f�r", "bir", "iki", "��", "d�rt", "be�", "alt�", "yedi", "sekiz", "dokuz"}; 
            foreach (string k in kelimeler) { 
                switch (k) {
                    case "d�rt": Console.Write (4+" "); break;
                    case "s�f�r": Console.Write (0+" "); break;
                    case "bir": Console.Write (1+" "); break;
                    default: Console.Write ("[5, 9] "); break;
                    case "iki": Console.Write (2+" "); break;
                    case "��": Console.Write (3+" "); break;
                }
            }

            Console.WriteLine ("\n\nRasgele [0, 9] say�l� tekkerelik switch(int) yap�s�:");
            var r=new Random(); ts1=r.Next (0, 10);
            switch (ts1) {
                case 4: Console.WriteLine ("int ts1=4"); break;
                case 0: Console.WriteLine ("int ts1=0"); break;
                case 1: Console.WriteLine ("int ts1=1"); break;
                default: Console.WriteLine ("int 10 > ts1 >= 5"); break;
                case 2: Console.WriteLine ("int ts1=2"); break;
                case 3: Console.WriteLine ("int ts1=3"); break;
            }

            giri�: Console.WriteLine ("\nTercihinizi girin l�tfen!");
            Console.WriteLine ("1: Hamburger");
            Console.WriteLine ("2: �izburger");
            Console.WriteLine ("3: Hatdogburger");
            Console.WriteLine ("4: �ik�nburger");
            Console.WriteLine ("5: Biftekburger");
            Console.WriteLine ("9: SON");
            try {ts1 = int.Parse (Console.ReadLine());}catch {goto giri�;}
            if (ts1 == 9) goto son;
            else if (ts1 < 1 | ts1 > 5) goto giri�;
            switch (ts1) {
                case 1: Console.WriteLine ("Buyrun Hamburgeriniz, afiyet olsun!"); break;
                case 2: Console.WriteLine ("Buyrun �izburgeriniz, afiyet olsun!"); break;
                case 3: Console.WriteLine ("Buyrun Hotdogburgeriniz, afiyet olsun!"); break;
                case 4: Console.WriteLine ("Buyrun �ik�nburgeriniz, afiyet olsun!"); break;
                case 5: Console.WriteLine ("Buyrun Biftekburgeriniz, afiyet olsun!"); break;
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto giri�;

            son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}