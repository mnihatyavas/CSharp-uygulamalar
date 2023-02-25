// jtpc#2204.cs: ��sel, d��sal ve kullan�c�-tan�ml� tip �evrimleri �rne�i.

using System;
namespace �e�itli {
    class Tip�evrimi {
       public struct Feet {
            public float ayak;
            public Feet (float n) {this.ayak = n;}
            public static explicit operator Feet (int m) {
                float sonu� = 3.28f * m;
                Feet ara = new Feet (sonu�);
                return ara;
            }
        }
       public struct �n� {
            public float in�;
            public �n� (float n) {this.in� = n;}
            public static explicit operator �n� (int m) {
                float sonu� = 3.28f * 12 * m;
                �n� ara = new �n� (sonu�);
                return ara;
            }
        }
        static void Main() {
            Console.Write ("Bir veri tipli de�i�kenin ba�ka veri tipine d�n��t�r�lmesine Tip �evrimi/(Explicit)TypeCasting denir. Tip �evrimi i�sel (k���k tamsay�dan b�y��e, t�revden temel s�n�fa), d��sal (g�r�n�r () semboll� b�y�k tamsay�dan k����e, temelden t�rev s�n�fa), kullan�c�-tan�ml� (�zel metodla i�sel veya d��sal) veya uyumsuz tipleri yard�mc� s�n�flarla (tamsay�dan DateTime nesnesine) yap�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tamsay�1 = 1951;
            int tamsay�2 = 72;
            long uzunsay�;
            uzunsay� = tamsay�1 + tamsay�2; //��sel tip �evrimi
            Console.WriteLine ("��sel tip�evrimi: [int {0}] + [int {1}] = [long {2}]", tamsay�1, tamsay�2, uzunsay�);

            double duble1 = 1951.25;
            double duble2 = 72.75;
            int tamsay�3;
            tamsay�3 = (int)duble1 + (int)duble2; //D��sal tip �evrimi
            Console.WriteLine ("D��sal tip�evrimi: (int)[double {0}] + (int)[double {1}] = [int {2}]", duble1, duble2, tamsay�3);

            int metre;
            gir: Console.Write ("\nTamsay� metre gir [��k: 0]: ");
            try {metre = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            if (metre == 0) goto son;
            Feet fit = (Feet)metre; //Kullan�c�-tan�ml� tip �evrimi
            var inc = (�n�)metre; //Kullan�c�-tan�ml� tip �evrimi
            Console.WriteLine ("Girilen {0} metre = {1} feet veya {2} in�.", metre, fit.ayak, inc.in�);
            goto gir;

            son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}