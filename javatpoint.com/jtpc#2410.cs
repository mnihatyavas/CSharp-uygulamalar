// jtpc#2410.cs: Girilen tamsay� hanelerinin kar��l�k kelimelere �evrilmesi �rne�i.

using System;
namespace �rnekler {
    class Rakamlar�nT�rk�esi {
        static void Main() {
            Console.Write ("Bir tamsay�n�n modulus-10 (%10) ile b�l�m�n�n kalan�n�n [0,9] switch-case d�ng�de kar��l�k kelimesi arkalanarak s�f�rlan�ncaya de�in de 10'a b�l�nerek toplan�rsa t�rk�e �evrisi elde edilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, k; string tr;
            Gir: tr="";
            Console.Write ("+tamsay�y� girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            Console.Write ("Girdi�iniz {0}'in T�rk�e terc�mesi: ", ts);
            while (ts > 0) {
                k=ts%10; ts=ts/10;
                switch (k) {
                    case 0: tr="s�f�r "+tr; break;
                    case 1: tr="bir "+tr; break;
                    case 2: tr="iki "+tr; break;
                    case 3: tr="�� "+tr; break;
                    case 4: tr="d�rt "+tr; break;
                    case 5: tr="be� "+tr; break;
                    case 6: tr="alt� "+tr; break;
                    case 7: tr="yedi "+tr; break;
                    case 8: tr="sekiz "+tr; break;
                    case 9: tr="dokuz "+tr; break;
                }
            }
            Console.Write (tr);
            Console.WriteLine("\n"); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}