// jtpc#2305f.cs: Metodu '=>' ve özelliði 'ExpressionGet'le temsil etme örneði.

using System;
namespace YeniÖzellikler {
    class ÝfadeSembolü {
        //private static string Ad {get => "javatpoint.com";}
        private string Ýsim {get; set;}
        public void ÝsmiAl() /*=>*/ {Console.WriteLine ("Öðrencinin ismi: {0}", Ýsim);}
        static void Main() {
            Console.Write ("Tek ifadeli metodu '=>' sembolüyle, özelliðiyse 'ExpressionGet'le alabilmeyi saðlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new ÝfadeSembolü(); öðrenci1.Ýsim = "Hatice Yavaþ";
            var öðrenci2 = new ÝfadeSembolü(); öðrenci2.Ýsim = "Süheyla Yavaþ";
            öðrenci1.ÝsmiAl();
            öðrenci2.ÝsmiAl();

            //Console.WriteLine (ExpressionGet.Ad);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}