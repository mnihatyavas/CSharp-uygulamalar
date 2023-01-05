// tpc#37a.cs: Adl� ve ads�z anonim metodlar�n delegeli �a�r�lmas� �rne�i.

using System;
delegate void Hesapc� (int n);
namespace AnonimMetodlar {
    class DelegeliMetodlar {
        static int say� = 10;
        public static void Topla (int n) {Console.WriteLine ("Topla adl� metod: {0}", (say� +=n));}
        public static void �arp (int n) {Console.WriteLine ("�arp adl� metod: {0}", (say� *=n));}
        public static void B�l (int n) {Console.WriteLine ("B�l adl� metod: {0}", (say� /=(n-3)));}

        static void Main() {
            Console.Write ("Metodlar do�rudan yada referansl� delegesiyle �a�r�labilmektedir. Anonim metod isimsiz kodlama g�vdesi olup parametreli veri al�r. Hem ads�z hem de adl� metodlar delegeli �a�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesapc� h = delegate (int x) {Console.WriteLine ("Ads�z delegeli anonim metod: {0}", x-1957);};
            h (2023); // Ads�z anonim metodun delegeli �a�r�lmas�
            h = new Hesapc� (Topla);
            h (5); // Topla Adl� metodun delegeli �a�r�lmas�
            h = new Hesapc� (�arp);
            h (3); // �arp Adl� metodun delegeli �a�r�lmas�
            h = new Hesapc� (B�l);
            h (12); // B�l Adl� metodun delegeli �a�r�lmas�

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}