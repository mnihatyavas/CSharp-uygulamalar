// tpc#11a.cs: D�ng�ler, kontrol ifadeleri ve sonsuz d�ng� �rne�i.

using System;
namespace D�ng�ler {
    class D�ng�ler {
        static void Main (string[] args) {
            Console.WriteLine ("D�ng�ler: for, while, do-while, i�i�e-d�ng�");
            Console.WriteLine ("\nD�ng� kontrollar�: break (d�ng�y� k�r, ��k), continue (kalan� atla, d�ng�ye devam)");
            Console.WriteLine ("\nSonsuz d�ng�, hep true/do�ru, d�ng�ye devam �art�n� sa�l�yorsa sonsuz d�ng�d�r (CTRL-C ile k�r�labilir==>");
            Console.Write ("\n\nTu�..."); Console.ReadKey();
            for (;;) {Console.WriteLine ("Hey! Ben tak�ld�m... CTRL-C");}
        }
    }
}