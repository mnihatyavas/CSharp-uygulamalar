// j2sc#0406.cs: �arts�z enaz 1 kez i�letilen do{ifade-ler}while(�art) d�ng�s� �rne�i.

using System;
namespace �fadeler {
    class DoWhile {
        static void Main() {
            Console.Write ("dp{ifade-ler}while(�art) d�ng�s�, �art �ncesi enaz 1 kez i�letilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Do-while d�ng�s�yle ard���k A-->Z harflerinin s�ralanmas�:");
            char k1='A'; int i, j=0;
            do {Console.Write (k1); j++;} while (k1++ < 'Z');
            Console.Write ("\tHarf say�s�: {0}\n", j);

            Console.WriteLine ("\n\nDo-while ile long.MaxValue({0})'nin terslenmesi:", long.MaxValue);
            long ls1=long.MaxValue;
            j=0;
            Console.Write ("Tersten: ");
            do {i = (int)(ls1 % 10);
                Console.Write (i);
                ls1 /=10;
                j++;
            }while (ls1 > 0);
            Console.Write ("\tRakam say�s�: {0}\n", j);

            Console.WriteLine ("\nDo-while d�ng�s�n�n i�-�art:break ile erken k�r�lmas�:");
            i=2023; j=0;
            do {if (i < 1955) break;
                Console.Write (i + " ");
                i--;
                j++;
            }while (i > 0);
            Console.WriteLine ("(�yi ki {0} y�l �nce do�dun Nihal!)", (j-1));

            double tolerans   = 1.0e-9;
            var r=new Random(); double say�=(double)r.Next (0, 10000) + r.Next (0, 10000) /100000.0;
            Console.WriteLine ("\nDo-while d�ng�s�n�n rasgele {0}'in yak�n karek�k optimizasyonu:", say�);
            double tahmin=say�*2.0, sonu�=0.0; j=0;
            sonu� = ((say� / tahmin) + tahmin) / 2; 
            do {Console.WriteLine ("{0}.inci tahmin = {1}", ++j, tahmin);
                Console.WriteLine ("\t{0}.nci sonu� = {1}", j, sonu�);
                tahmin = sonu�;
                sonu� = ((say� / tahmin) + tahmin) / 2;
            }while (Math.Abs (sonu� - tahmin) > tolerans);
            Console.WriteLine ("{0} tolerans alt� Karek�k ({1}) = {2}", tolerans, say�, sonu�);

            Console.WriteLine ("\nDo-while d�ng�s�n�n 'hay�r/HAYIR' cevaba de�in soruyu tekrarlamas�:");
            string cevap="";
            do {Console.Write ("D�ng�ye devam m� [hay�r]?: "); cevap = Console.ReadLine();} while(cevap.ToLower() != "hay�r");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}