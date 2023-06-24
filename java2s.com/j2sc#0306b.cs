// j2sc#0306b.cs: Mant�ksal i�lemcilerle se�ici bilgiye eri�me �rne�i.

using System;
namespace ��lemciler {
    class Mant�ksalBa��nt�sal��lemci2 {
        static void Main() {
            Console.Write ("Mant�ksalsal i�lemciler: &, |, ^, &&, ||, !. True/do�ru i�in &'te hepsi true, |'da enaz biri true, ^'da farkl�ysa, !'da false gerekirken; k�sadevre &&'te ilki false ise false-sonu� yeterli, k�sadevre ||'da ilki true ise true-sonu� yeterlidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            bool b1=true, b2=false;
            Console.WriteLine ("'bool b1=true' ve 'b2=false ise:");
            if (b1 & !b2) Console.WriteLine ("(b1 & !b2) = true");
            if (!(b1 & b2)) Console.WriteLine ("!(b1 & b2) = true");
            if (b1 | b2) Console.WriteLine ("b1 | b2 = true");
            if (b1 ^ b2) Console.WriteLine ("b1 ^ b2 = true");
            if (!(b2 && b1)) Console.WriteLine ("K�sadevre !(b2 && b1) = true");
            if (b1 || b2) Console.WriteLine ("K�sadevre(b1 || b2) = true");

            int ts1=10, ts2=1;
            Console.WriteLine ("\nbool b1, ba�lant�sal ili�kiler sonucu ise:");
            b1 = (10 == 1); Console.WriteLine ("10 == 1? " + b1);
            b1 = (10 < 1); Console.WriteLine ("10 < 1? " + b1);
            b1 = (10 >= 1); Console.WriteLine ("10 >= 1? " + b1);
            b1 = (10 != 1); Console.WriteLine ("10 != 1? " + b1);
            b1 = (ts1 != ts2); Console.WriteLine ("ts1({0}) != ts2({1})? {2}", ts1, ts2, b1);
            b1 = !!!(ts1 == ts2); Console.WriteLine ("!!!(ts1 == ts2)? {0}", b1);

            Console.WriteLine ("\nbool b1, ba�lant�sal ve mant�ksal ili�kiler sonucu ise:");
            b1 = (1 == 1) & (2 > 1); Console.WriteLine ("(1 == 1) & (2 > 1)? " + b1);
            b1 = (1 == 2) && (2 > 1); Console.WriteLine ("K�sadevre (1 == 2) && (2 > 1)? " + b1);
            b1 = (1 == 1) | (1 == 0); Console.WriteLine ("(1 == 1) | (1 == 0)? " + b1);
            b1 = (1 == 1) || (2 == 2); Console.WriteLine ("K�sadevre (1 == 1) || (1 == 2)? " + b1);
            b1 = !(1 == 0); Console.WriteLine ("!(1 == 0)? " + b1);
            b1 = !(1 != 0); Console.WriteLine ("!(1 != 0)? " + b1);
            string ad = "nihat"; b1 = (ts1 > 1) & (ad == "nihat"); Console.WriteLine ("(ts1({0}) > 1) & (ad({1}) == \"nihat\")? {2}", ts1, ad, b1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}