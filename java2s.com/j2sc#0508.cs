// j2sc#0508.cs: Copy ve CopyTo ile farkl� kopyalama teferruatlar� �rne�i.

using System;
namespace Dizgeler {
    class Kopyalama {
        static void Main() {
            Console.Write ("Copy, '=' atamayla ayn� kpyalay� sa�lar. 'dizge1.CopyTo(9, kDizi1, 4, 7)' dizge1'in 9.karakterinden itibaren takipeden 7 karakteri kDizi1'in 4.krk'inden itibaren �zerlerine kopyalar; kDizi1 endeksi ta�mamal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayn�/farkl� kopyalama ve sonras� k�yas kontrollar�:");
            string dizge1 = "ABC�DEFG�HI�JKlmno�prs�tu�vyz1234567890";
            string dizge2 = string.Copy (dizge1);
            string dizge3 = string.Copy (dizge1).ToUpper(); 
            Console.WriteLine ("dizge1 = {0}\ndizge2 = {1}\ndizge3 = {2}", dizge1, dizge2, dizge3);
            if (dizge1 == dizge2) Console.WriteLine ("dizge1 == dizge2");
            else Console.WriteLine ("dizge1 != dizge2");
            if (dizge1 == dizge3) Console.WriteLine ("dizge1 == dizge3");
            else Console.WriteLine ("dizge1 != dizge3");

            Console.WriteLine ("\nCopy ve kontrollu CopyTo ile kopyalama:");
            char[] kDizi1 = { 'M', '.', 'N', 'i', 'h', 'a', 't', ' ', 'Y', 'a', 'v', 'a', '�'};
            Console.Write ("Orijinal kDizi1: "); Console.WriteLine (kDizi1);
            dizge1.CopyTo (9, kDizi1, 4, 7);
            Console.Write ("dizge1'den CopyTo sonras� kDizi1: "); Console.WriteLine (kDizi1);
            dizge1 = new String (kDizi1);
            Console.Write ("'dizge1 = new String (kDizi1)' sonras�: "); Console.WriteLine (dizge1);

            Console.WriteLine ("\nContains ve kontrollu CopyTo ile �artl� kopyalama:");
            if (dizge3.Contains ("DEF")) dizge3.CopyTo (9, kDizi1, 4, 7);
            else "HI�JKLMNO".CopyTo (0, kDizi1, 4, 7);
            Console.Write ("Contains �artl� CopyTo sonras� kDizi1: "); Console.WriteLine (kDizi1); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}