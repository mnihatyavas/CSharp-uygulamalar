// j2sc#0502.cs: @dizge ile çoklu satýr formlarýnýn muhafazasý örneði.

using System;
namespace Dizgeler {
    class @Dizge {
        static void Main() {
            Console.Write ("Dizgeye =@\"...\" ile atanan karakterler altalta aynen yazýldýklarý biçimlerini korurlar. Çift týrnak tek týrnak, \\uxxxx karþýlýk karakteri olarak yansýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("@\"...\" ile atanan çoksatýrlý dizgenin, yazýlý formunu muhafazasý:");
            string dizge1 = @"		AÝLE ÞECERESÝ
                1) Hamza Candan
                2) Zeliha Yavaþ Candan
                3) Canan Candan
                    3.1) Elif Ekþioðlu
                    3.2) Mert Ekþioðlu
                4) Zafer N.Candan
                    4.1) Ömer Candan
                5) Belkýs Candan";
            Console.WriteLine (dizge1);

            Console.WriteLine ("\n@\"...\" ile atanan sekmeli tablo:");
            Console.WriteLine (@"	TELEFON REHBERÝ
Nihat	1957	05515559363	Mersin
Nihal	1955	05557449909	Malatya
Canan	1975	05432508944	Antalya");
            Console.WriteLine (@"		EXCEL TABLOLAMA
	1	2	3	4 
	50	600	7000	80000");

            Console.WriteLine ("\n@Dizge ile konuþma týrnaklarýnýn yansýtýlmasý:");
            Console.WriteLine (@"Nihat: ""Merhaba Canan, nasýlsýn?..""");
            Console.WriteLine (@"Canan: ""Ýyiyim Dayýcýðým; arasýra Antalya'ya uðra, bisikletle turlayalým!..""");
            Console.WriteLine (@"Nihat: ""Çocuklarýnýn da bisikletleri var mý?""");
            Console.WriteLine (@"Canan: ""Tabii ki, hem de amortismanlýsýndan...""");

            Console.WriteLine ("\n@Dizge ile eþdeðer içerikli Dizge yansýmalarý:");
            Console.WriteLine ("\u0041BC");
            Console.WriteLine (@"\u0041BC");
            Console.WriteLine ("Hep birlikte \"Merhaba\" diyelim!");
            Console.WriteLine (@"Hep birlikte ""Merhaba"" diyelim!");
            dizge1 = @"1.Satýr
ve 2.Satýr";
            Console.WriteLine (dizge1);
            dizge1 = "1.Satýr\nve 2.Satýr";
            Console.WriteLine (dizge1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}