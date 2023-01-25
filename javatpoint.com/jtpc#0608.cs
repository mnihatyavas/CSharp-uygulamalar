// jtpc#0608.cs: 'struct' yap� tiplemesiyle dikd�rtgen alan�n�n hesaplanmas� �rne�i.

using System;
namespace NesneS�n�f� {
    public struct Dikd�rtgen1 {public int en, boy;}
    public struct Dikd�rtgen2 {
        public int en, boy;
        public Dikd�rtgen2 (int en, int boy) {//Parametreli kurucu
            this.en = en;
            this.boy = boy;
        }
        public void Dikd�rtgen2Alan�() {Console.WriteLine ("{0}x{1} ebatl� dikd�rtgenin alan� = {2}", en, boy, (en * boy));}
    }
    class Yap�lar {
        static void Main() {
            Console.Write ("'struct' anahtarkelimeli yap�lar�n da s�n�f gibi alan, metod ve kurucusu vard�r ve tiplemeyle yarat�l�r, ancak s�n�f gibi referans de�il de�er tiplidir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Dikd�rtgen1 d1 = new Dikd�rtgen1();
            d1.en = 4; d1.boy = 5;
            Console.WriteLine ("{0}x{1} ebatl� dikd�rtgenin alan� = {2}", d1.en, d1.boy, (d1.en * d1.boy));
            d1.en = 8; d1.boy = 4;
            Console.WriteLine ("{0}x{1} ebatl� dikd�rtgenin alan� = {2}\n", d1.en, d1.boy, (d1.en * d1.boy));

            Dikd�rtgen2 d2 = new Dikd�rtgen2 (4, 5); d2.Dikd�rtgen2Alan�();
            new Dikd�rtgen2 (8, 4).Dikd�rtgen2Alan�();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}