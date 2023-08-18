// j2sc#0402.cs: Switch-case-default-break yapýlý tercihler örneði.

using System;
namespace Ýfadeler {
    class Switch {
        static void Main() {
            Console.Write ("switch-case-default-break yapýsýnda sabit deðer tamsayý türleri veya dizge olabilir. Uyan case olmazsa default, o da yoksa iþlemsizdir. Herbir tercih break'le sonlanmalýdýr, yoksa müteakiben birbirlerine karýþýrlar. Break yerine þartsýz goto case/default atlamasý yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10/0-9 for döngülük, 5 case ve 1 default ile switch(int) yapýsý:");
            int ts1;
            for (ts1=0; ts1<10; ts1++) //for-{ olmasa da olur
                switch (ts1) {
                    case 4: Console.WriteLine ("int ts1=4"); break; //ts1 sýralamasý gerekmez
                    case 0: Console.WriteLine ("int ts1=0"); break;
                    case 1: Console.WriteLine ("int ts1=1"); break;
                    default: Console.WriteLine ("int 10 > ts1 >= 5"); break; //default illa sonda gerekmez
                    case 2: Console.WriteLine ("int ts1=2"); break;
                    case 3: Console.WriteLine ("int ts1=3"); break;
                }

            Console.WriteLine ("\n10/A-J for döngülük, 5 case ve 1 default ile switch(char) yapýsý:");
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

            Console.WriteLine ("\n10/0-9 for döngülü, (3 break'siz) 5 case ile default'suz switch(int) yapýsý:");
            for (ts1=0; ts1<10; ts1++) //for-{ olmasa da olur
                switch (ts1) {
                    case 4: Console.WriteLine ("int ts1=4"); break;
                    case 0:
                    case 1:
                    case 2:
                    case 3: Console.WriteLine ("int ts1=(0, 1, 2 veya 3)"); break;
                }

            Console.WriteLine ("\n10/0-9 for döngülük, break yerine goto'lu switch(int) yapýsý:");
            for (ts1=0; ts1<10; ts1++) {
                switch (ts1) {
                    case 4: Console.WriteLine ("case 4:'teyim"); goto case 2;
                    case 0: Console.WriteLine ("case 0:'dayým"); goto case 4;
                    case 1: Console.WriteLine ("case 1:'deyim"); goto case 3;
                    default: Console.WriteLine ("default:'dayým"); break;
                    case 2: Console.WriteLine ("case 2:'deyim"); goto case 1;
                    case 3: Console.WriteLine ("case 3:'teyim"); goto default;
                    case 5: case 6: case 7: case 8: case 9: Console.WriteLine ("case 5:/6:/7:/8:/9:'dayýmm"); goto default;
                }
                Console.WriteLine();
            }

            Console.WriteLine ("10/sýfýr-dokuz foreach döngülük, switch(string) yapýsý:");
            string[] kelimeler = {"sýfýr", "bir", "iki", "üç", "dört", "beþ", "altý", "yedi", "sekiz", "dokuz"}; 
            foreach (string k in kelimeler) { 
                switch (k) {
                    case "dört": Console.Write (4+" "); break;
                    case "sýfýr": Console.Write (0+" "); break;
                    case "bir": Console.Write (1+" "); break;
                    default: Console.Write ("[5, 9] "); break;
                    case "iki": Console.Write (2+" "); break;
                    case "üç": Console.Write (3+" "); break;
                }
            }

            Console.WriteLine ("\n\nRasgele [0, 9] sayýlý tekkerelik switch(int) yapýsý:");
            var r=new Random(); ts1=r.Next (0, 10);
            switch (ts1) {
                case 4: Console.WriteLine ("int ts1=4"); break;
                case 0: Console.WriteLine ("int ts1=0"); break;
                case 1: Console.WriteLine ("int ts1=1"); break;
                default: Console.WriteLine ("int 10 > ts1 >= 5"); break;
                case 2: Console.WriteLine ("int ts1=2"); break;
                case 3: Console.WriteLine ("int ts1=3"); break;
            }

            giriþ: Console.WriteLine ("\nTercihinizi girin lütfen!");
            Console.WriteLine ("1: Hamburger");
            Console.WriteLine ("2: Çizburger");
            Console.WriteLine ("3: Hatdogburger");
            Console.WriteLine ("4: Çikýnburger");
            Console.WriteLine ("5: Biftekburger");
            Console.WriteLine ("9: SON");
            try {ts1 = int.Parse (Console.ReadLine());}catch {goto giriþ;}
            if (ts1 == 9) goto son;
            else if (ts1 < 1 | ts1 > 5) goto giriþ;
            switch (ts1) {
                case 1: Console.WriteLine ("Buyrun Hamburgeriniz, afiyet olsun!"); break;
                case 2: Console.WriteLine ("Buyrun Çizburgeriniz, afiyet olsun!"); break;
                case 3: Console.WriteLine ("Buyrun Hotdogburgeriniz, afiyet olsun!"); break;
                case 4: Console.WriteLine ("Buyrun Çikýnburgeriniz, afiyet olsun!"); break;
                case 5: Console.WriteLine ("Buyrun Biftekburgeriniz, afiyet olsun!"); break;
                default: Console.WriteLine ("Buraya asla gelmez!"); break;
            } goto giriþ;

            son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}