// jtpc#0301c.cs: IfElseIf merdiveniyle notun A-B-C-D-F tespiti �rne�i.

using System;
namespace Control�fadeleri {
    class IfElseIf {
        static void Main () {
            Console.Write ("�art true/do�ruysa if, de�ilse else if... blo�u i�letilir.\n new Random().Next(0,101) 0->100 aras� rasgele tamsay� �retir.\nConvert.ToInt32 (Console.ReadLine()) ile klavyeden tamsay� giri�i sa�lan�r; girilen tamsay� de�ilse try-catch hatay� yakalayarak yans�t�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int r, say�;
            for (int i=0; i < 11; i++) {
                r = rasgele.Next (0, 101);
                if (r % 2 == 0)  {Console.WriteLine ("{0} bir ��FT say�d�r", r);
                }else {Console.WriteLine ("{0} bir TEK say�d�r", r);}
            }

            Console.Write ("\nBir not gir [0,100]: ");
            try {say� = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            if (say� < 0 || say� > 100) {Console.WriteLine ("Yanl�� not girdiniz!");
            }else if (say� >= 0 && say� < 50) {Console.WriteLine ("F-ail Ba�ar�s�z");
            }else if (say� >= 50 && say� < 60) {Console.WriteLine ("D Zay�f");
            }else if (say� >= 60 && say� < 70) {Console.WriteLine ("C Orta");
            }else if (say� >= 70 && say� < 80) {Console.WriteLine ("B �yi");
            }else if (say� >= 80 && say� < 90) {Console.WriteLine ("A �okiyi");
            }else {Console.WriteLine ("A+ Pekiyi");} // if (say� >= 90 && say� <= 100)

            son: Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}