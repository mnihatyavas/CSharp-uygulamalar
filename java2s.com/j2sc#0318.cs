// j2sc#0318.cs: T�m i�lemcilerin en�nemliden en�nemsize s�ralanmas� �rne�i.

using System;
namespace ��lemciler {
    class ��lemci�nceli�i {
        static void Main() {
            Console.Write ("��lemcilerin �ncelikleri, ENY�KSEK: (), [], ., i++, i--, checked, new, sizeof, typeof, unchecked, !, ~, (tip),  -+i, ++i,--i, *, /, %, +, -, <<, >>, <, >, <=, >=, is, ==, !=, &, ^, |, &&, ||, ?:, =, i�l=, END���K.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��lemci �nceli�inin, i�lem s�ralanmas� ve gruplanmas�nda sonucu etkilemesi:");
            int ts = 2 + 5 * 10; Console.WriteLine ("2 + 5 * 10 = " + ts);
            ts = (2 + 5) * 10; Console.WriteLine ("(2 + 5) * 10 = " + ts);
            ts = 2 * 20 / 5 % 3; Console.WriteLine ("2 * 20 / 5 % 3 = " + ts);
            Console.WriteLine ("3 * 4 / 2 % 4 + (2 -5) = " + 3 * 4 / 2 % 4 + (2 - 5));
            Console.WriteLine ("(3 * 4 / 2 % 4 + (2 -5)) = " + (3 * 4 / 2 % 4 + (2 - 5)));

            Console.WriteLine ("\n��lemci �nceliklerinin, �nemliden �nemsize s�ralanmas�:\n�ncelik no            ��lemciler\n----------------------------------------------------------\n1                     dizi '[ ]', \n                      checked , \n                      fonksiyon '()', \n                      �ye i�lemci '.', \n                      new, \n                      sonekli birazalt , \n                      sonekli birart�r, \n                      typeof, \n                      ve unchecked\n\n2                     tikel art�lama '+', \n                      aleni tipleme '()', \n                      birli t�mleyen '~', \n                      de�il '!', \n                      �nekli birazalt, \n                      �nekli birart�r, \n                      tikel eksileme '-'\n\n3                     b�l '/', \n                      kalan '%', \n                      �arp '*'\n\n4                     topla '+' ve ��kar '-'\n\n5                     sola-kayd�r '<<' ve sa�a-kayd�r '>>'\n\n6                     as, \n                      is, \n                      k���k '<', \n                      k���k veya e�it '<=', \n                      b�y�k '>', \n                      b�y�k veya e�it '>='\n\n7                     e�it '==' ve e�it de�il '!='\n\n8                     mant�ksal VE '&'\n\n9                     mant�ksal FARKLIYSA '^' operator\n\n10                    mant�ksal VEYA '|'\n\n11                    �artl� VE '&&'\n\n12                    �artl� VEYA '||'\n\n13                    �artl� ��leme '?:'\n\n14                    atama '=', \n                      bile�ik '*=, /-=, %=, +=, -=, <<=, >>=, &=, ^=, |=', \n                      ve hi� ��k��� '?'");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}