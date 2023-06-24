// j2sc#0307.cs: Kýsadevre && ve ||'un ikinci kriteri esgeçmesi örneði.

using System;
namespace Ýþlemciler {
    class KýsadevreÝþlemci {
        static void Main() {
            Console.Write ("Tüm kriterleri iþleyen AND/VE=&, OR/VEYA=| iken kýsadevre AND=&& ilk false'ta, kýsadevre OR=|| ise ilk true'da varsa diðer kriterlerleri esgeçerek (false, true) sonuca ulaþýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10, ts2=2; 
            Console.WriteLine ("Kýsadevre AND=&& ilk kriter false ise ikinciyi esgeçer:");
            if (ts2 != 0 && (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir bölenidir.");
            ts2=0;
            if (ts2 != 0 && (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir bölenidir.");
            else Console.WriteLine ("payda=0 olduðundan, kýsadevre sonuç=false olup ikinci kritere bakýlmamýþtýr.");
            try {if (ts2 != 0 & (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir bölenidir.");
            }catch (Exception h) {Console.WriteLine ("payda=0 olduðundan, normal AND=&'in ikinci kriteri pay/payda 'sýfýra bölüm hatasý' fýrlatmýþtýr: " + h.Message);}

            bool b1 = true; 
            Console.WriteLine ("\nNormal OR=| tüm kriterlere bakar:");
            ts1=0; if (b1 | (ts1 > ts2) | (++ts1 > 10)) Console.WriteLine ("Tüm kriterlere bakýlýr. ts1=" + ts1);
            Console.WriteLine ("Kýsadevre OR=|| için ilk true kriter yeterlidir:");
            ts1=0; if (b1 || (ts1 > ts2) || (++ts1 > 10)) Console.WriteLine ("Ýlk true kriter sonrasý esgeçilir. ts1=" + ts1);
    
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}