// jtpc#2410.cs: Girilen tamsayý hanelerinin karþýlýk kelimelere çevrilmesi örneði.

using System;
namespace Örnekler {
    class RakamlarýnTürkçesi {
        static void Main() {
            Console.Write ("Bir tamsayýnýn modulus-10 (%10) ile bölümünün kalanýnýn [0,9] switch-case döngüde karþýlýk kelimesi arkalanarak sýfýrlanýncaya deðin de 10'a bölünerek toplanýrsa türkçe çevrisi elde edilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, k; string tr;
            Gir: tr="";
            Console.Write ("+tamsayýyý girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            Console.Write ("Girdiðiniz {0}'in Türkçe tercümesi: ", ts);
            while (ts > 0) {
                k=ts%10; ts=ts/10;
                switch (k) {
                    case 0: tr="sýfýr "+tr; break;
                    case 1: tr="bir "+tr; break;
                    case 2: tr="iki "+tr; break;
                    case 3: tr="üç "+tr; break;
                    case 4: tr="dört "+tr; break;
                    case 5: tr="beþ "+tr; break;
                    case 6: tr="altý "+tr; break;
                    case 7: tr="yedi "+tr; break;
                    case 8: tr="sekiz "+tr; break;
                    case 9: tr="dokuz "+tr; break;
                }
            }
            Console.Write (tr);
            Console.WriteLine("\n"); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}