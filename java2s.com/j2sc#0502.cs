// j2sc#0502.cs: @dizge ile �oklu sat�r formlar�n�n muhafazas� �rne�i.

using System;
namespace Dizgeler {
    class @Dizge {
        static void Main() {
            Console.Write ("Dizgeye =@\"...\" ile atanan karakterler altalta aynen yaz�ld�klar� bi�imlerini korurlar. �ift t�rnak tek t�rnak, \\uxxxx kar��l�k karakteri olarak yans�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("@\"...\" ile atanan �oksat�rl� dizgenin, yaz�l� formunu muhafazas�:");
            string dizge1 = @"		A�LE �ECERES�
                1) Hamza Candan
                2) Zeliha Yava� Candan
                3) Canan Candan
                    3.1) Elif Ek�io�lu
                    3.2) Mert Ek�io�lu
                4) Zafer N.Candan
                    4.1) �mer Candan
                5) Belk�s Candan";
            Console.WriteLine (dizge1);

            Console.WriteLine ("\n@\"...\" ile atanan sekmeli tablo:");
            Console.WriteLine (@"	TELEFON REHBER�
Nihat	1957	05515559363	Mersin
Nihal	1955	05557449909	Malatya
Canan	1975	05432508944	Antalya");
            Console.WriteLine (@"		EXCEL TABLOLAMA
	1	2	3	4 
	50	600	7000	80000");

            Console.WriteLine ("\n@Dizge ile konu�ma t�rnaklar�n�n yans�t�lmas�:");
            Console.WriteLine (@"Nihat: ""Merhaba Canan, nas�ls�n?..""");
            Console.WriteLine (@"Canan: ""�yiyim Day�c���m; aras�ra Antalya'ya u�ra, bisikletle turlayal�m!..""");
            Console.WriteLine (@"Nihat: ""�ocuklar�n�n da bisikletleri var m�?""");
            Console.WriteLine (@"Canan: ""Tabii ki, hem de amortismanl�s�ndan...""");

            Console.WriteLine ("\n@Dizge ile e�de�er i�erikli Dizge yans�malar�:");
            Console.WriteLine ("\u0041BC");
            Console.WriteLine (@"\u0041BC");
            Console.WriteLine ("Hep birlikte \"Merhaba\" diyelim!");
            Console.WriteLine (@"Hep birlikte ""Merhaba"" diyelim!");
            dizge1 = @"1.Sat�r
ve 2.Sat�r";
            Console.WriteLine (dizge1);
            dizge1 = "1.Sat�r\nve 2.Sat�r";
            Console.WriteLine (dizge1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}