// jtpc#2306a.cs: 'Nesne is Tip' ve 'switch-case Tip nesne' kontrollarýyla kalýba uyum örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        public string Ad {get; set;}
        public Öðrenci (string a) {Ad = a;}
    }
    class Öðretmen1 {
        public string Ad {get; set;}
        public string Branþ {get; set;}
        public Öðretmen1() {Ad="Adil Özbay"; Branþ="Bal üretim uzmaný";}
    }
    class Öðrenci1 {
        public string Ad {get; set;}
        public Öðrenci1() {Ad = "Süheyla Özbay";}
    }
    class KalýbaUyum {
        public static void KalýpDüðmesi (object nesne) {
            int i=0; if (nesne is Öðrenci1) {i=1;}else if (nesne is Öðretmen1) {i=2;}
            switch (i) {
                case 1:
                    Console.WriteLine ("Switch-case-Öðrenci tipe uygun: " + new Öðrenci1().Ad);
                    break;
                case 2:
                    Console.WriteLine ("Switch-case-Öðretmen tipe uygun: " + new Öðretmen1().Branþ + " " + new Öðretmen1().Ad);
                    break;
                default:
                    throw new ArgumentException ("Nesne tipi tanýnamadý");
            }
        }
        static void Main() {
            Console.Write ("Kalýba uyum kontrolu 'nesne is tip' ve 'switch-case tip nesne' yöntemleriyle yapýlmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new Öðrenci ("Fatih Özbay"); if (öðrenci1 is Öðrenci) Console.WriteLine ("is Öðrenci tipe uygun: " + öðrenci1.Ad);
            var öðrenci2 = new Öðrenci ("Selda Özbay"); if (öðrenci2 is Öðrenci) Console.WriteLine ("is Öðrenci tipe uygun: " + öðrenci2.Ad);
            var öðrenci3 = new Öðrenci ("Sema Özbay"); if (öðrenci3 is Öðrenci) Console.WriteLine ("is Öðrenci tipe uygun: " + öðrenci3.Ad);

            var hoca = new Öðretmen1();
            var talebe = new Öðrenci1();
            Console.WriteLine(); KalýpDüðmesi (hoca); KalýpDüðmesi (talebe); try {KalýpDüðmesi (null);}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}