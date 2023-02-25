// jtpc#230105.cs: Sarýmsýz doðrudan delegeli tiplemeye metot atama örneði.

using System;
namespace YeniÖzellikler {
    class DelegeÇýkarýmý {
        delegate void delegem (string mesaj);
        public static void Selam (string selam) {Console.WriteLine (selam);}
        static void Main() {
            Console.Write ("Normalde, delege beyaný sonrasý yeni bir delege tiplemeli nesneye delegelendirilecek metod sarýlarak atanýr. Doðrudan çýkarýmda ise delege tiplemeli nesneye metod sarýmsýz yalýn atanarak, ayný sonuca ulaþýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var delege1 = new delegem (Selam); //Delegeyle sarýmlý metod
            delege1 ("Bu bir sarýmlý delege metodudur.");

            delegem delege2 = Selam; //Doðrudan delege çýkarýmlý metod
            delege2 ("Bu bir sarýmsýz, doðrudan delege çýkarýmlý metotdur.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}