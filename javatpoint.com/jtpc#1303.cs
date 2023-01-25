// jtpc#1303.cs: �zel kullan�c�-tan�ml� t�rev istiana f�rlatma �rne�i.

using System;
namespace �stisnaY�netimi {
    public class Ge�ersizYa��stisnas�: Exception {
        public Ge�ersizYa��stisnas� (String mesaj): base (mesaj){} //Parametreli t�rev kurucusu
    }
    class �zel�stisna {
        static void ya�Kontrolu (int ya�) {
            if (ya� < 18) {throw new Ge�ersizYa��stisnas� ("Ya��n�z " + ya� + ". �zg�n�m, ama re�it olmayanlar giremez!..");
            }else {Console.WriteLine ("\nYa��n�z {0}. Buyrun, girebilirsiniz!..", ya�);}
        }
        static void Main() {
            Console.Write ("Temel Exception miraslanarak, istenilen anlaml� �zel kullan�c�-tan�ml� istisnalar yarat�l�p y�netilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            for (int i=0; i < 10; i++) {
                try {ya�Kontrolu (rasgele.Next (0, 51));
                }catch (Ge�ersizYa��stisnas� hata) {Console.WriteLine ("\nHATA: [{0}]", hata);} //hata, throw mesaj�n� i�erir
            }
            Console.WriteLine ("\nNormal program ak���na devam"); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}