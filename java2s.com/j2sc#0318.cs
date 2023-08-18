// j2sc#0318.cs: Tüm iþlemcilerin enönemliden enönemsize sýralanmasý örneði.

using System;
namespace Ýþlemciler {
    class ÝþlemciÖnceliði {
        static void Main() {
            Console.Write ("Ýþlemcilerin öncelikleri, ENYÜKSEK: (), [], ., i++, i--, checked, new, sizeof, typeof, unchecked, !, ~, (tip),  -+i, ++i,--i, *, /, %, +, -, <<, >>, <, >, <=, >=, is, ==, !=, &, ^, |, &&, ||, ?:, =, iþl=, ENDÜÞÜK.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýþlemci önceliðinin, iþlem sýralanmasý ve gruplanmasýnda sonucu etkilemesi:");
            int ts = 2 + 5 * 10; Console.WriteLine ("2 + 5 * 10 = " + ts);
            ts = (2 + 5) * 10; Console.WriteLine ("(2 + 5) * 10 = " + ts);
            ts = 2 * 20 / 5 % 3; Console.WriteLine ("2 * 20 / 5 % 3 = " + ts);
            Console.WriteLine ("3 * 4 / 2 % 4 + (2 -5) = " + 3 * 4 / 2 % 4 + (2 - 5));
            Console.WriteLine ("(3 * 4 / 2 % 4 + (2 -5)) = " + (3 * 4 / 2 % 4 + (2 - 5)));

            Console.WriteLine ("\nÝþlemci önceliklerinin, önemliden önemsize sýralanmasý:\nÖncelik no            Ýþlemciler\n----------------------------------------------------------\n1                     dizi '[ ]', \n                      checked , \n                      fonksiyon '()', \n                      üye iþlemci '.', \n                      new, \n                      sonekli birazalt , \n                      sonekli birartýr, \n                      typeof, \n                      ve unchecked\n\n2                     tikel artýlama '+', \n                      aleni tipleme '()', \n                      birli tümleyen '~', \n                      deðil '!', \n                      önekli birazalt, \n                      önekli birartýr, \n                      tikel eksileme '-'\n\n3                     böl '/', \n                      kalan '%', \n                      çarp '*'\n\n4                     topla '+' ve çýkar '-'\n\n5                     sola-kaydýr '<<' ve saða-kaydýr '>>'\n\n6                     as, \n                      is, \n                      küçük '<', \n                      küçük veya eþit '<=', \n                      büyük '>', \n                      büyük veya eþit '>='\n\n7                     eþit '==' ve eþit deðil '!='\n\n8                     mantýksal VE '&'\n\n9                     mantýksal FARKLIYSA '^' operator\n\n10                    mantýksal VEYA '|'\n\n11                    þartlý VE '&&'\n\n12                    þartlý VEYA '||'\n\n13                    þartlý üçleme '?:'\n\n14                    atama '=', \n                      bileþik '*=, /-=, %=, +=, -=, <<=, >>=, &=, ^=, |=', \n                      ve hiç çöküþü '?'");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}