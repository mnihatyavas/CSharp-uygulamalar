// j2sc#0306b.cs: Mantýksal iþlemcilerle seçici bilgiye eriþme örneði.

using System;
namespace Ýþlemciler {
    class MantýksalBaðýntýsalÝþlemci2 {
        static void Main() {
            Console.Write ("Mantýksalsal iþlemciler: &, |, ^, &&, ||, !. True/doðru için &'te hepsi true, |'da enaz biri true, ^'da farklýysa, !'da false gerekirken; kýsadevre &&'te ilki false ise false-sonuç yeterli, kýsadevre ||'da ilki true ise true-sonuç yeterlidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            bool b1=true, b2=false;
            Console.WriteLine ("'bool b1=true' ve 'b2=false ise:");
            if (b1 & !b2) Console.WriteLine ("(b1 & !b2) = true");
            if (!(b1 & b2)) Console.WriteLine ("!(b1 & b2) = true");
            if (b1 | b2) Console.WriteLine ("b1 | b2 = true");
            if (b1 ^ b2) Console.WriteLine ("b1 ^ b2 = true");
            if (!(b2 && b1)) Console.WriteLine ("Kýsadevre !(b2 && b1) = true");
            if (b1 || b2) Console.WriteLine ("Kýsadevre(b1 || b2) = true");

            int ts1=10, ts2=1;
            Console.WriteLine ("\nbool b1, baðlantýsal iliþkiler sonucu ise:");
            b1 = (10 == 1); Console.WriteLine ("10 == 1? " + b1);
            b1 = (10 < 1); Console.WriteLine ("10 < 1? " + b1);
            b1 = (10 >= 1); Console.WriteLine ("10 >= 1? " + b1);
            b1 = (10 != 1); Console.WriteLine ("10 != 1? " + b1);
            b1 = (ts1 != ts2); Console.WriteLine ("ts1({0}) != ts2({1})? {2}", ts1, ts2, b1);
            b1 = !!!(ts1 == ts2); Console.WriteLine ("!!!(ts1 == ts2)? {0}", b1);

            Console.WriteLine ("\nbool b1, baðlantýsal ve mantýksal iliþkiler sonucu ise:");
            b1 = (1 == 1) & (2 > 1); Console.WriteLine ("(1 == 1) & (2 > 1)? " + b1);
            b1 = (1 == 2) && (2 > 1); Console.WriteLine ("Kýsadevre (1 == 2) && (2 > 1)? " + b1);
            b1 = (1 == 1) | (1 == 0); Console.WriteLine ("(1 == 1) | (1 == 0)? " + b1);
            b1 = (1 == 1) || (2 == 2); Console.WriteLine ("Kýsadevre (1 == 1) || (1 == 2)? " + b1);
            b1 = !(1 == 0); Console.WriteLine ("!(1 == 0)? " + b1);
            b1 = !(1 != 0); Console.WriteLine ("!(1 != 0)? " + b1);
            string ad = "nihat"; b1 = (ts1 > 1) & (ad == "nihat"); Console.WriteLine ("(ts1({0}) > 1) & (ad({1}) == \"nihat\")? {2}", ts1, ad, b1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}