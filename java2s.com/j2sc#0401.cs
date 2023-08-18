// j2sc#0401.cs: �e�itli i�(�art1){ifadeler}else if(�art2){ifadeler}...else{ifadeler} �rne�i.

using System;
namespace �fadeler {
    class �f {
        static void Main() {
            Console.Write ("if/e�er �art bool true/do�ru ise takipeden tek yada bloklu �oklu ifadeler icra edilir. Sonras�z, else/de�ilse yada zincirleme else-if/de�ilse-e�er sonral� kurulabilir.\n�f bool-�artlar�: <, <=, >, >=, == veya != olabilir; bile�ik mant�ksal �artlar (&, &&, |, ||, ^, !) kurulabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int a=1881, b=1938, c;  
            if (a < b) Console.WriteLine ("a({0}) b({1})'den k���kt�r.", a, b);
            if (a == b) Console.WriteLine ("Bu �art mevcut verilerle ger�ekle�mez.");
            c = b - a;
            if (c >= 0) Console.WriteLine ("c=b-a={0}: negatif de�ildir.", c); 
            if (c < 0) Console.WriteLine ("Bu �art olu�maz.");
            c = a - b;
            if (c >= 0) Console.WriteLine ("Bu �art olu�maz.");
            if (c < 0) Console.WriteLine ("c=a-b={0}: negatif'tir.", c);

            Console.WriteLine ("\n'if (true)' �artl� ifade i�letme:");
            bool b1 = true; if (b1) Console.WriteLine ("'if (b1:{0}) Bu ifade i�letilir.", b1);
            b1 = false; if (!b1) Console.WriteLine ("'if (!b1:!{0}) Bu ifade i�letilir.", b1);

            Console.WriteLine ("\nif-else ile negatif/pozitif say�lar�n kontrolu:");
            for (a=-3; a <= 3; a++) {
                Console.Write ("Kontrol edilen " + a + ": ");
                if (a < 0) Console.WriteLine ("Bir negatif say�d�r.");
                else Console.WriteLine ("Bir pozitif say�d�r.");
            }

            Console.WriteLine ("\nif ile && ve || karma��k �artl� kontrollar:");
            if (a != b & b > c) Console.WriteLine ("int a = {0}", a);
            if ((a > c) || (a == b)) Console.WriteLine ("int b = {0}", b);
            if ((a >= c) && !(b <= c)) Console.WriteLine ("int c = {0}", c);

            Console.WriteLine ("\nif-else-if ile negatif/s�f�r/pozitif say�lar�n kontrolu:");
            for (a=-3; a <= 3; a++) {
                Console.Write ("Kontrol edilen " + a + ": ");
                if (a < 0) Console.WriteLine ("Bir negatif say�d�r.");
                else if (a == 0) Console.WriteLine ("Bir i�aretsiz say�d�r.");
                else Console.WriteLine ("Bir pozitif say�d�r.");
            }

            Console.WriteLine ("\nif-else {ifade; if} ile �art{�oklu ifade} yap�s�:");
            var r=new Random(); a=r.Next (0, 2);
            if (a == 0) b1=false; else b1=true;
            if (b > 2023) {Console.WriteLine ("int b > 2023");
            }else {
                Console.WriteLine ("int b <= 2023");
                if (b1) {Console.WriteLine ("bool b1 = {0}/kapal�devre", b1);}
                else {Console.WriteLine ("bool b1 = {0}/a��kdevre", b1);}
            }

            Console.WriteLine ("\nif(�art){�oklu-ifade}else{�oklu-ifade} yap�s�:");
            a=r.Next(0,5); b=r.Next(0,5);
            if (a > b) {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'den", b);
                Console.Write (" B�Y�KT�R.");
            }else if (a == b) {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'ye", b);
                Console.Write (" E��TT�R.");
            }else {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'den", b);
                Console.Write (" K���KT�R.");
            }

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}