// j2sc#0406.cs: Þartsýz enaz 1 kez iþletilen do{ifade-ler}while(þart) döngüsü örneði.

using System;
namespace Ýfadeler {
    class DoWhile {
        static void Main() {
            Console.Write ("dp{ifade-ler}while(þart) döngüsü, þart öncesi enaz 1 kez iþletilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Do-while döngüsüyle ardýþýk A-->Z harflerinin sýralanmasý:");
            char k1='A'; int i, j=0;
            do {Console.Write (k1); j++;} while (k1++ < 'Z');
            Console.Write ("\tHarf sayýsý: {0}\n", j);

            Console.WriteLine ("\n\nDo-while ile long.MaxValue({0})'nin terslenmesi:", long.MaxValue);
            long ls1=long.MaxValue;
            j=0;
            Console.Write ("Tersten: ");
            do {i = (int)(ls1 % 10);
                Console.Write (i);
                ls1 /=10;
                j++;
            }while (ls1 > 0);
            Console.Write ("\tRakam sayýsý: {0}\n", j);

            Console.WriteLine ("\nDo-while döngüsünün iç-þart:break ile erken kýrýlmasý:");
            i=2023; j=0;
            do {if (i < 1955) break;
                Console.Write (i + " ");
                i--;
                j++;
            }while (i > 0);
            Console.WriteLine ("(Ýyi ki {0} yýl önce doðdun Nihal!)", (j-1));

            double tolerans   = 1.0e-9;
            var r=new Random(); double sayý=(double)r.Next (0, 10000) + r.Next (0, 10000) /100000.0;
            Console.WriteLine ("\nDo-while döngüsünün rasgele {0}'in yakýn karekök optimizasyonu:", sayý);
            double tahmin=sayý*2.0, sonuç=0.0; j=0;
            sonuç = ((sayý / tahmin) + tahmin) / 2; 
            do {Console.WriteLine ("{0}.inci tahmin = {1}", ++j, tahmin);
                Console.WriteLine ("\t{0}.nci sonuç = {1}", j, sonuç);
                tahmin = sonuç;
                sonuç = ((sayý / tahmin) + tahmin) / 2;
            }while (Math.Abs (sonuç - tahmin) > tolerans);
            Console.WriteLine ("{0} tolerans altý Karekök ({1}) = {2}", tolerans, sayý, sonuç);

            Console.WriteLine ("\nDo-while döngüsünün 'hayýr/HAYIR' cevaba deðin soruyu tekrarlamasý:");
            string cevap="";
            do {Console.Write ("Döngüye devam mý [hayýr]?: "); cevap = Console.ReadLine();} while(cevap.ToLower() != "hayýr");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}