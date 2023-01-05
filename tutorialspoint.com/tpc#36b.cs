// tpc#36b.cs: Soysal metod tiplemesiyle tamsay�, krk ve dizge verileri takaslama �rne�i.

using System;
using System.Collections.Generic;
namespace Soysallar {
    class SoysalMetod {
        static void De�i�Toku�<Tip> (ref Tip bu, ref Tip �u) {// "ref" anahtarkelime zorunlu
            Tip arac�;
            arac� = bu;
            bu = �u;
            �u = arac�;
        }
        static void Main() {
            Console.Write ("Ar�iv koleksiyon s�n�flar� yan�s�ra kendi �zel koleksiyon s�n�f, metod, aray�z, olay ve delegelerinizi de tan�mlayabilir, tip ve ebatlar�n� yans�mayla �al��ma-zaman�nda saptars�n�z.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int a = 1957, b = 2023;
            char c = 'M', d = 'N';
            string e = "Mahmut", f = "Nihat";
            Console.WriteLine ("De�i�toku� �ncesi tamsay�: a = {0}, b = {1}", a, b);
            Console.WriteLine ("De�i�toku� �ncesi krk: c = {0}, d = {1}", c, d);
            Console.WriteLine ("De�i�toku� �ncesi dizge: e = {0}, f = {1}", e, f);
            De�i�Toku�<int> (ref a, ref b);
            De�i�Toku�<char> (ref c, ref d);
            De�i�Toku�<string> (ref e, ref f);
            Console.WriteLine ("\nDe�i�toku� sonras� tamsay�: a = {0}, b = {1}", a, b);
            Console.WriteLine ("De�i�toku� sonras� krk: c = {0}, d = {1}", c, d);
            Console.WriteLine ("De�i�toku� sonras� dizge: e = {0}, f = {1}", e, f);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}