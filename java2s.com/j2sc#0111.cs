// j2sc#0111.cs: Metod ref parametreleriyle kar��l�kl� �oklu de�er aktar�m� �rne�i.

using System;
namespace DilTemelleri {
    class RefDeneme1 {
        public void RefsizTakas (int x, int y) {
            Console.WriteLine ("'RefsizTakas()' metodu i�inde ilk durum: x = " + x + ", y = " + y);
            int arac� = x;
            x = y;
            y = arac�;
            Console.WriteLine ("'RefsizTakas()' metodu i�inde son durum: x = " + x + ", y = " + y);
        }
        public void Karek�k (ref double n) {n = Math.Sqrt (n);}
        public void Takas (ref int a, ref int b) {
            int arac�;
            arac� = a;
            a = b;
            b = arac�;
        }
        public static void B�y�kHarf (ref string d) {d = d.ToUpper();}
        public void DaireK�re1 (double y, out double �evre, out double alan, out double k�reAlan, out double k�reHacim) {
            double pi = Math.PI;
            �evre = 2 * pi * y;
            alan = pi * y * y;
            k�reAlan = 4 * pi *  y * y;
            k�reHacim = 4 / 3 * pi * y * y * y;
        }
        public void DaireK�re2 (double y, ref double �evre, ref double alan, ref double k�reAlan, ref double k�reHacim) {
            double pi = Math.PI;
            �evre = 2 * pi * y;
            alan = pi * y * y;
            k�reAlan = 4 * pi *  y * y;
            k�reHacim = 4 / 3 * pi * y * y * y;
        }
    }
    class RefDeneme2 {
        public int a, b;
        public RefDeneme2 (int i, int j) {a = i; b = j;}
        public void Takas (ref RefDeneme2 ns1, ref RefDeneme2 ns2) {
            RefDeneme2 arac�;
            arac� = ns1;
            ns1 = ns2;
            ns2 = arac�;
        }
    }
    class Ref {
        static void Main() {
            Console.Write ("�a��ran metodun arg�man ve �a�r�lan metodun parametre-leri �n�ndeki 'ref' anahtarkelimesi teky�nl� de�eraktarma yerine ayn� haf�za adresini referanslayarak kar��l�kl� ve (return's�z) �oklu (her tip) de�er aktar�mlar�n� m�mk�n k�lmaktad�r. 'out'lu arg�manlar ilkde�ersiz kullan�l�rken (ve ileriye de�il sadece geriye de�er aktar�rken), 'ref'liler mutlaka ilkde�er olmasa derleme hatas� verir (ve heriki y�nl� de�er aktarabilirler); ba�ka farklar� yoktur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int x = 23, y = 57;
            Console.WriteLine ("'Main()' metodu i�inde ilk durum: x = " + x + ", y = " + y);
            var nesne = new RefDeneme1();
            nesne.RefsizTakas (x, y);
            Console.WriteLine ("'Main()' metodu i�inde son durum: x = " + x + ", y = " + y);

            double pi = Math.PI;
            Console.WriteLine ("\n'Karek�k()' metodu �a�r�lmadan �nce pi = " + pi);
            nesne = new RefDeneme1();
            nesne.Karek�k (ref pi);
            Console.WriteLine ("'Karek�k()' metodu �a�r�ld�ktan sonra pi = " + pi);

            string ad = "M.Nihat Yava�";
            Console.WriteLine ("\n'B�y�kHarf()' metodu �a�r�lmadan �nce ad: {0}", ad);
            RefDeneme1.B�y�kHarf (ref ad);
            Console.WriteLine ("'B�y�kHarf()' metodu �a�r�ld�ktan sonra ad: {0}", ad);

            x = 2023; y = 1957;
            Console.WriteLine ("\n'Takas1()' metodu �a�r�lmadan �nce int x ve y: " + x + ", " + y);
            nesne.Takas (ref x, ref y);
            Console.WriteLine ("'Takas1()' metodu �a�r�ld�ktan sonra int x ve y: " + x + ", " + y);

            RefDeneme2 n1 = new RefDeneme2 (2023, 1957), n2 = new RefDeneme2 (1957, 2023);
            Console.WriteLine ("\n'Takas2()' metodu �a�r�lmadan �nce nesne n1: n1.a=" + n1.a + ", n1.b=" + n1.b);
            Console.WriteLine ("'Takas2()' metodu �a�r�lmadan �nce nesne n2: n2.a=" + n2.a + ", n2.b=" + n2.b);
            n1.Takas (ref n1, ref n2);
            Console.WriteLine ("'Takas2()' metodu �a�r�ld�ktan sonra nesne n1: n1.a=" + n1.a + ", n1.b=" + n1.b);
            Console.WriteLine ("'Takas2()' metodu �a�r�ld�ktan sonra nesne n2: n2.a=" + n2.a + ", n2.b=" + n2.b);

            var r = new Random();
            double y�, �evre, alan, k�reAlan=10 /* Etkisiz */, k�reHacim;
            y� = r.Next (0, 1000000) / 100000d;
            nesne.DaireK�re1 (y�, out �evre, out alan, out k�reAlan, out k�reHacim);
            Console.WriteLine ("\nYar��ap� {0:0.00##} birim olan dairenin:\n==>�evresi = {1:0.00##} birim\n==>Alan� = {2:0.00##} birim kare\n==>K�re alan� = {3:0.00##} birim kare\n==>K�re hacmi = {4:0.00##} birim k�p't�r.", y�, �evre, alan, k�reAlan, k�reHacim);

            //double �, a, ka, kh; //(�lkde�er atanmama) derleme hatas�: [error CS0165: Use of unassigned local variable]
            double �=0, a=0, ka=0, kh=0;
            y� = r.Next (0, 1000000) / 100000d;
            nesne.DaireK�re2 (y�, ref �, ref a, ref ka, ref kh);
            Console.WriteLine ("\nYar��ap� {0:0.00##} birim olan dairenin:\n==>�evresi = {1:0.00##} birim\n==>Alan� = {2:0.00##} birim kare\n==>K�re alan� = {3:0.00##} birim kare\n==>K�re hacmi = {4:0.00##} birim k�p't�r.", y�, �, a, ka, kh);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}