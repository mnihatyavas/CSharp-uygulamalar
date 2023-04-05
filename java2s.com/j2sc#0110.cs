// j2sc#0110.cs: De�i�kenlerin tan�mland�klar� blok ve altbloklar�nda ge�erlili�i �rne�i.

using System;
namespace DilTemelleri {
    class De�i�kenKapsam� {
        static void Main() {
            Console.Write ("De�i�kenler tan�mland�klar� {} blok ve alt-bloklar� kapam�nda ge�erli olup, blo�a her giri�te yarat�l�r, bir �st blo�a ��k�ld���na imha edilirler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int x;
            for (x = 0; x < 3; x++) {
                int y = -1;
                Console.WriteLine ("y for blo�una her giri�te {0} ilk de�erle yeniden yarat�l�r.", y);
                y = 100;
                Console.WriteLine ("y for blo�undan ��karken son de�eri: " + y);
            } Console.WriteLine();

            int y�l; //Main() i�indeki her blokta ge�erli
            y�l = 2023;
            if (y�l%2 == 1) {//Yeni i�-blok kapsam�
                int ya� = y�l - 1957; //ya� bu blok kapsam�nda ge�erli
                Console.WriteLine ("Abimin {0} y�l�ndaki ya��: {1}", y�l, ya�); 
            }else {
                int ya� = y�l - 1951; //ya� bu blok kapsam�nda ge�erli
                Console.WriteLine ("Ablam�n {0} y�l�ndaki ya��: {1}", y�l, ya�); 
            }
            Console.WriteLine ("Y�l de�eri: " + y�l);
            //Console.WriteLine ("Ya� de�eri: " + ya�); //Derleme hatas� verir

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}