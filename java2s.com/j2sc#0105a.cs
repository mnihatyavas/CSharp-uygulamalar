// j2sc#0105a.cs: 'using System' ve i�i�e aduzamlar �rne�i.

using System;
namespace DilTemelleri {
    class Aduzam1 {
        static void Main() {
            Console.Write ("Bir aduzam, bir katagoriyi di�erinden ay�r�r. 'System' aduzam� .NET Framework s�n�f dll k�t�phanesi i�in ayr�lm��t�r. Bir aduzamdaki isimler di�erlerinde de aynen bulunsa da birbirleriyle kar��t�r�lmazlar. 'using' ayr�lm�� kelimesi ad�ge�en aduzamdaki isimleri kullanaca��n� beyan eder.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");
/*
namespace D��Aduzam {
    namespace ��Aduzam {
        //...
    }
}
==>
namespace D��Aduzam.��Aduzam {
    // ...
}
*/
            Console.WriteLine ("��i�e aduzamlar, i�i�e {} bloklarla temsil edilirler. ��i�e aduzamlar noktalamal� tek blo�a da �evrilebilir.");
            System.Console.WriteLine ("'using' kullan�lmazsa ilgili aduzam komut ba�lar�na gelmelidir.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}