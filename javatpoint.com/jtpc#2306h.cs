// jtpc#2306h.cs: Tek '=>' ifadeli kurucu ve sonland�r�c� metotlar �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        public string Ad {get; set;}
        public ��renci (string a) /*=>*/ {Ad = a;} //Tek ifadeli kurucu
        ~��renci() /*=>*/ {Console.WriteLine ("{0}'in sonlanan y�k�c� metodu y�r�t�ld�", Ad);}
    }
    class KurucuSonland�r�c� {
        static void Main() {
            Console.Write ("S�n�f kurucu ve '~' y�k�c� metodlar� '=>' sembolle {} bloksuz tek ifadeli kodlanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��r = new ��renci ("Zafer"); Console.WriteLine ("Merhaba {0}, nas�ls�n?..", ��r.Ad);
            ��r = new ��renci ("Canan"); Console.WriteLine ("Merhaba {0}, nas�ls�n?..", ��r.Ad);
            ��r = new ��renci ("Belk�s"); Console.WriteLine ("Merhaba {0}, nas�ls�n?..", ��r.Ad);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}