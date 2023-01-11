// jtpc#0301b.cs: IfElse ile sayýnýn tek/çift tespiti örneði.

using System;
namespace ControlÝfadeleri {
    class IfElse {
        static void Main () {
            Console.Write ("Þart true/doðruysa if, deðilse else bloðu iþletilir.\nConvert.ToInt32 (Console.ReadLine()) ile klavyeden tamsayý giriþi saðlanýr; girilen tamsayý deðilse try-catch hatayý yakalayarak yansýtýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            for (int i=0; i < 11; i++) {
                if (i % 2 == 0)  {Console.WriteLine ("{0} bir ÇÝFT sayýdýr", i);
                }else {Console.WriteLine ("{0} bir TEK sayýdýr", i);}
            }

            Console.Write ("\nBir tamsayý gir: "); int sayý=0;
            try {sayý = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            if (sayý % 2 == 0)  {Console.WriteLine ("{0} bir ÇÝFT sayýdýr", sayý);
            }else {Console.WriteLine ("{0} bir TEK sayýdýr", sayý);}

            son: Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}