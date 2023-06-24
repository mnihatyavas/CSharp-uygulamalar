// j2sc#0307.cs: K�sadevre && ve ||'un ikinci kriteri esge�mesi �rne�i.

using System;
namespace ��lemciler {
    class K�sadevre��lemci {
        static void Main() {
            Console.Write ("T�m kriterleri i�leyen AND/VE=&, OR/VEYA=| iken k�sadevre AND=&& ilk false'ta, k�sadevre OR=|| ise ilk true'da varsa di�er kriterlerleri esge�erek (false, true) sonuca ula��r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10, ts2=2; 
            Console.WriteLine ("K�sadevre AND=&& ilk kriter false ise ikinciyi esge�er:");
            if (ts2 != 0 && (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir b�lenidir.");
            ts2=0;
            if (ts2 != 0 && (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir b�lenidir.");
            else Console.WriteLine ("payda=0 oldu�undan, k�sadevre sonu�=false olup ikinci kritere bak�lmam��t�r.");
            try {if (ts2 != 0 & (ts1 % ts2) == 0) Console.WriteLine (ts2 + ", " + ts1 + "'in bir b�lenidir.");
            }catch (Exception h) {Console.WriteLine ("payda=0 oldu�undan, normal AND=&'in ikinci kriteri pay/payda 's�f�ra b�l�m hatas�' f�rlatm��t�r: " + h.Message);}

            bool b1 = true; 
            Console.WriteLine ("\nNormal OR=| t�m kriterlere bakar:");
            ts1=0; if (b1 | (ts1 > ts2) | (++ts1 > 10)) Console.WriteLine ("T�m kriterlere bak�l�r. ts1=" + ts1);
            Console.WriteLine ("K�sadevre OR=|| i�in ilk true kriter yeterlidir:");
            ts1=0; if (b1 || (ts1 > ts2) || (++ts1 > 10)) Console.WriteLine ("�lk true kriter sonras� esge�ilir. ts1=" + ts1);
    
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}