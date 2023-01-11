// jtpc#0301c.cs: IfElseIf merdiveniyle notun A-B-C-D-F tespiti örneði.

using System;
namespace ControlÝfadeleri {
    class IfElseIf {
        static void Main () {
            Console.Write ("Þart true/doðruysa if, deðilse else if... bloðu iþletilir.\n new Random().Next(0,101) 0->100 arasý rasgele tamsayý üretir.\nConvert.ToInt32 (Console.ReadLine()) ile klavyeden tamsayý giriþi saðlanýr; girilen tamsayý deðilse try-catch hatayý yakalayarak yansýtýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int r, sayý;
            for (int i=0; i < 11; i++) {
                r = rasgele.Next (0, 101);
                if (r % 2 == 0)  {Console.WriteLine ("{0} bir ÇÝFT sayýdýr", r);
                }else {Console.WriteLine ("{0} bir TEK sayýdýr", r);}
            }

            Console.Write ("\nBir not gir [0,100]: ");
            try {sayý = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            if (sayý < 0 || sayý > 100) {Console.WriteLine ("Yanlýþ not girdiniz!");
            }else if (sayý >= 0 && sayý < 50) {Console.WriteLine ("F-ail Baþarýsýz");
            }else if (sayý >= 50 && sayý < 60) {Console.WriteLine ("D Zayýf");
            }else if (sayý >= 60 && sayý < 70) {Console.WriteLine ("C Orta");
            }else if (sayý >= 70 && sayý < 80) {Console.WriteLine ("B Ýyi");
            }else if (sayý >= 80 && sayý < 90) {Console.WriteLine ("A Çokiyi");
            }else {Console.WriteLine ("A+ Pekiyi");} // if (sayý >= 90 && sayý <= 100)

            son: Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}