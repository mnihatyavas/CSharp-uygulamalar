// jtpc#2305f.cs: Metodu '=>' ve �zelli�i 'ExpressionGet'le temsil etme �rne�i.

using System;
namespace Yeni�zellikler {
    class �fadeSembol� {
        //private static string Ad {get => "javatpoint.com";}
        private string �sim {get; set;}
        public void �smiAl() /*=>*/ {Console.WriteLine ("��rencinin ismi: {0}", �sim);}
        static void Main() {
            Console.Write ("Tek ifadeli metodu '=>' sembol�yle, �zelli�iyse 'ExpressionGet'le alabilmeyi sa�lar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new �fadeSembol�(); ��renci1.�sim = "Hatice Yava�";
            var ��renci2 = new �fadeSembol�(); ��renci2.�sim = "S�heyla Yava�";
            ��renci1.�smiAl();
            ��renci2.�smiAl();

            //Console.WriteLine (ExpressionGet.Ad);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}