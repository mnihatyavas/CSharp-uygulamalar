// jtpc#2201.cs: Delege olayý tiplemesinin referanslý metodlarla rakamlarý biçimleme örneði.

using System;
namespace Çeþitli {
    class Olaylar {
        public delegate void Yaz (long n);
        public static void SayýYaz (long sayý) {Console.WriteLine ("Tamsayý: {0,-12:N0}", sayý);}
        public static void ParaYaz (long para) {Console.WriteLine ("Para: {0:N2} TL", para);}
        static void Main() {
            Console.Write ("Olay, kapsüllü bir delegedir. Beyan edilen delegenin tiplemesi hangi metoda baðlanýrsa, gönderilen argümaný þekillendirir. Örnekte Yaz adlý delege olay tiplemesi yazanDelege, gönderdiði tamsayý argümaný iki farklý metoda referanslayarak, noktasal ve parasal biçime düzenlemektedir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Yaz yazanDelege = new Yaz (SayýYaz); //Yada kýsaca "=SayýYaz"
            yazanDelege (51); yazanDelege (1951); yazanDelege (19511701); yazanDelege (19511701985L);

            yazanDelege = ParaYaz;
            yazanDelege (51); yazanDelege (1951); yazanDelege (19511701); yazanDelege (19511701985);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}