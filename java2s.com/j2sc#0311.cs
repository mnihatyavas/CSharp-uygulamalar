// j2sc#0311.cs: K�sadevre AND=&& ve OR=||'da ilk false ve true'nun sonucu imas� �rne�i.

using System;
namespace ��lemciler {
    class �masal��lemci {
        static void Main() {
            Console.Write ("�oklu AND=&& i�in ilk �art�n�n false olmas� t�m �artlar sonucunun false imas�na, �oklu OR'da ise ilkinin true olmas� t�m�n true imas�na yeterlidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            bool b1=false, b2=false, b3=false, b4=false; 
            if (!b1 || b2 || b3 || b4) Console.WriteLine ("K�sadevre OR=|| i�in ilk !b1={0} olmas� t�m if �art�n�={1} imaya yeterlidir.", !b1, true);
            if (!(b1 && !b2 && !b3 && !b4)) Console.WriteLine ("K�sadevre AND=&& i�in ilk b1={0} olmas� t�m if �art�n�={1} imaya yeterlidir.", b1, false);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}