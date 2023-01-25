// jtpc#0404.cs: "out" ilkde�ersiz arg�man� onaylarken "ref"in hata vermesi �rne�i.

using System;
namespace Fonksiyonlar {
    class Out�a�r� {
        public void G�ster1 (ref int n) {n=5; n *=n;}
        public void G�ster2 (out int n) {n=10; n *=n;}
        public void G�ster3 (out int n1, out int n2, out int n3, out int n4, out int n5) {
            Random r = new Random();
            n1=r.Next (1, 100); n2=r.Next (1, 100); n3=r.Next (1, 100); n4=r.Next (1, 100); n5=r.Next (1, 100); 
        }
        static void Main () {
            Console.Write ("'out' anahtarkelimesi de 'ref' gibidir, ancak ref de�er atanmam�� arg�man� kabul etmezken out kabul eder. Ayr�ca out bir bak�ma fonksiyondan return's�z �oklu gerid�n��ler i�in kullan�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n1;
            //new Out�a�r�().G�ster1 (ref n1); // De�er atanmam�� ref-n1 hata verir
            //Console.WriteLine ("ref'li fonksiyonu �a��rd�ktan sonraki orijinal de�i�ken de�eri: {0}", n1);

            new Out�a�r�().G�ster2 (out n1);
            Console.WriteLine ("out'lu fonksiyonu �a��rd�ktan sonraki orijinal de�i�ken de�eri: {0}", n1);

            new Out�a�r�().G�ster1 (ref n1); // Art�k de�er i�erdi�inden ref-n1 hata vermez
            Console.WriteLine ("ref'li fonksiyonu �a��rd�ktan sonraki orijinal de�i�ken de�eri: {0}", n1);

            int r1, r2, r3, r4, r5;
            new Out�a�r�().G�ster3 (out r1, out r2, out r3, out r4, out r5);
            Console.WriteLine ("out ile fonksiyonda yarat�lan 5 rasgele [0,99] say�: [{0}, {1}, {2}, {3}, {4}]", r1, r2, r3, r4, r5);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}