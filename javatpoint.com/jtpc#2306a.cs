// jtpc#2306a.cs: 'Nesne is Tip' ve 'switch-case Tip nesne' kontrollar�yla kal�ba uyum �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        public string Ad {get; set;}
        public ��renci (string a) {Ad = a;}
    }
    class ��retmen1 {
        public string Ad {get; set;}
        public string Bran� {get; set;}
        public ��retmen1() {Ad="Adil �zbay"; Bran�="Bal �retim uzman�";}
    }
    class ��renci1 {
        public string Ad {get; set;}
        public ��renci1() {Ad = "S�heyla �zbay";}
    }
    class Kal�baUyum {
        public static void Kal�pD��mesi (object nesne) {
            int i=0; if (nesne is ��renci1) {i=1;}else if (nesne is ��retmen1) {i=2;}
            switch (i) {
                case 1:
                    Console.WriteLine ("Switch-case-��renci tipe uygun: " + new ��renci1().Ad);
                    break;
                case 2:
                    Console.WriteLine ("Switch-case-��retmen tipe uygun: " + new ��retmen1().Bran� + " " + new ��retmen1().Ad);
                    break;
                default:
                    throw new ArgumentException ("Nesne tipi tan�namad�");
            }
        }
        static void Main() {
            Console.Write ("Kal�ba uyum kontrolu 'nesne is tip' ve 'switch-case tip nesne' y�ntemleriyle yap�lmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new ��renci ("Fatih �zbay"); if (��renci1 is ��renci) Console.WriteLine ("is ��renci tipe uygun: " + ��renci1.Ad);
            var ��renci2 = new ��renci ("Selda �zbay"); if (��renci2 is ��renci) Console.WriteLine ("is ��renci tipe uygun: " + ��renci2.Ad);
            var ��renci3 = new ��renci ("Sema �zbay"); if (��renci3 is ��renci) Console.WriteLine ("is ��renci tipe uygun: " + ��renci3.Ad);

            var hoca = new ��retmen1();
            var talebe = new ��renci1();
            Console.WriteLine(); Kal�pD��mesi (hoca); Kal�pD��mesi (talebe); try {Kal�pD��mesi (null);}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}