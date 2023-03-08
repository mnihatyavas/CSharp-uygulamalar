// jtpc#2302b.cs: Statik uzantý tiplemeli metodun çaðrýlmasý örneði.

using System;
namespace YeniÖzellikler {
    public static class DizgeYardýmcý {
        public static string BüyükHarfle (this string dizge) {return dizge.ToUpper();}
    }
    public static class ÖðrenciYardýmcý {
        public static string BüyükHarfleAl (this Öðrenci öðrenci) {return öðrenci.ad.ToUpper();}
    }  
    public class Öðrenci {
        public string ad = "M.Nihat Yavaþ";
        public string AdýAl() {return this.ad;}
    }
    class UzantýMetodu {
        static string d = "javatpoint";
        static void Main() {
            Console.Write ("Uzantý metodu parametre listesinin ilkinde sýnýf adýna atfen 'this' anahtarkelimesi kullanmalý, statik olmalý ve tipleme metodu olarak çaðrýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string diz = d.BüyükHarfle(); //Statik uzantý metod tiplemesi
            Console.WriteLine ("Küçükharfli [{0}]'in büyükharflisi: [{1}]", d, diz);

            Öðrenci öðr = new Öðrenci();
            Console.WriteLine ("Küçükharfli [{0}]'in büyükharflisi: [{1}]", öðr.AdýAl(), öðr.BüyükHarfleAl());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}