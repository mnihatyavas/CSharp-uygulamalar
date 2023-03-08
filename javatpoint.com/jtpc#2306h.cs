// jtpc#2306h.cs: Tek '=>' ifadeli kurucu ve sonlandýrýcý metotlar örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        public string Ad {get; set;}
        public Öðrenci (string a) /*=>*/ {Ad = a;} //Tek ifadeli kurucu
        ~Öðrenci() /*=>*/ {Console.WriteLine ("{0}'in sonlanan yýkýcý metodu yürütüldü", Ad);}
    }
    class KurucuSonlandýrýcý {
        static void Main() {
            Console.Write ("Sýnýf kurucu ve '~' yýkýcý metodlarý '=>' sembolle {} bloksuz tek ifadeli kodlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðr = new Öðrenci ("Zafer"); Console.WriteLine ("Merhaba {0}, nasýlsýn?..", öðr.Ad);
            öðr = new Öðrenci ("Canan"); Console.WriteLine ("Merhaba {0}, nasýlsýn?..", öðr.Ad);
            öðr = new Öðrenci ("Belkýs"); Console.WriteLine ("Merhaba {0}, nasýlsýn?..", öðr.Ad);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}