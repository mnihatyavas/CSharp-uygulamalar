// jtpc#2201.cs: Delege olay� tiplemesinin referansl� metodlarla rakamlar� bi�imleme �rne�i.

using System;
namespace �e�itli {
    class Olaylar {
        public delegate void Yaz (long n);
        public static void Say�Yaz (long say�) {Console.WriteLine ("Tamsay�: {0,-12:N0}", say�);}
        public static void ParaYaz (long para) {Console.WriteLine ("Para: {0:N2} TL", para);}
        static void Main() {
            Console.Write ("Olay, kaps�ll� bir delegedir. Beyan edilen delegenin tiplemesi hangi metoda ba�lan�rsa, g�nderilen arg�man� �ekillendirir. �rnekte Yaz adl� delege olay tiplemesi yazanDelege, g�nderdi�i tamsay� arg�man� iki farkl� metoda referanslayarak, noktasal ve parasal bi�ime d�zenlemektedir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Yaz yazanDelege = new Yaz (Say�Yaz); //Yada k�saca "=Say�Yaz"
            yazanDelege (51); yazanDelege (1951); yazanDelege (19511701); yazanDelege (19511701985L);

            yazanDelege = ParaYaz;
            yazanDelege (51); yazanDelege (1951); yazanDelege (19511701); yazanDelege (19511701985);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}