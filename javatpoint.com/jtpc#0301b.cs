// jtpc#0301b.cs: IfElse ile say�n�n tek/�ift tespiti �rne�i.

using System;
namespace Control�fadeleri {
    class IfElse {
        static void Main () {
            Console.Write ("�art true/do�ruysa if, de�ilse else blo�u i�letilir.\nConvert.ToInt32 (Console.ReadLine()) ile klavyeden tamsay� giri�i sa�lan�r; girilen tamsay� de�ilse try-catch hatay� yakalayarak yans�t�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            for (int i=0; i < 11; i++) {
                if (i % 2 == 0)  {Console.WriteLine ("{0} bir ��FT say�d�r", i);
                }else {Console.WriteLine ("{0} bir TEK say�d�r", i);}
            }

            Console.Write ("\nBir tamsay� gir: "); int say�=0;
            try {say� = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            if (say� % 2 == 0)  {Console.WriteLine ("{0} bir ��FT say�d�r", say�);
            }else {Console.WriteLine ("{0} bir TEK say�d�r", say�);}

            son: Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}