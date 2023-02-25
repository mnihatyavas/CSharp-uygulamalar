// jtpc#230105.cs: Sar�ms�z do�rudan delegeli tiplemeye metot atama �rne�i.

using System;
namespace Yeni�zellikler {
    class Delege��kar�m� {
        delegate void delegem (string mesaj);
        public static void Selam (string selam) {Console.WriteLine (selam);}
        static void Main() {
            Console.Write ("Normalde, delege beyan� sonras� yeni bir delege tiplemeli nesneye delegelendirilecek metod sar�larak atan�r. Do�rudan ��kar�mda ise delege tiplemeli nesneye metod sar�ms�z yal�n atanarak, ayn� sonuca ula��l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var delege1 = new delegem (Selam); //Delegeyle sar�ml� metod
            delege1 ("Bu bir sar�ml� delege metodudur.");

            delegem delege2 = Selam; //Do�rudan delege ��kar�ml� metod
            delege2 ("Bu bir sar�ms�z, do�rudan delege ��kar�ml� metotdur.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}