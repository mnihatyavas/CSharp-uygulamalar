// j2sc#0315.cs: De�i�kenin de�erini yada adresini kullanma  �rne�i.
// unsafe kodlamalar: ">>csc /unsafe �rnek.cs" se�enekli derlenir. Kodlamada ya metod sat�r�nda, yada metod i�i �zel blok'ta "unsafe" beyan� gerekir.

using System;
namespace ��lemciler {
    public struct XY_Kordinatlar {
        public int X;
        public int Y;
        public override string ToString() {return "("+X+", "+Y+")";}
    }
    class Adres��lemci {
        static unsafe void Main() {
            Console.Write ("De�i�ken adresini 'int* g�sterge=&de�i�ken' atay�p, o adresteki tek yada ard���k de�erlere ula�abiliriz. De�er ts1 ve *gs1'de, adres ise &ts1 ve gs1'dedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tamsay� de�i�kenin de�erine ve bellek adresine eri�im:");
            unsafe {
                int ts1 = 2023;
                int* gs1 = &ts1;
                Console.WriteLine ("int ts1'in de�eri: {0}={1}", ts1, *gs1);
                Console.WriteLine ("int ts1'in adresi: {0}={1}", (long)gs1, (long)&ts1);
            }

            Console.WriteLine ("\nTamsay� dizinin de�erlerine ve bellek adreslerine eri�im:");
            unsafe {
                const int diziEbat� = 3;
                int[] tsDizi = new int [diziEbat�] {1951, 2023, 2051};
                fixed (int* gs�lk = &tsDizi [0]) {
                    int* gsSon = gs�lk + (diziEbat� - 1);
                    Console.WriteLine ("{0} adresteki �LK de�er: {1}", (long)gs�lk, *gs�lk);
                    Console.WriteLine ("{0} adresteki SON de�er: {1}", (long)gsSon, *gsSon);
                    Console.WriteLine ("{0} adresteki ORTA de�er: {1}", (long)(gs�lk+1), *(gs�lk+1));
                }
            }

            Console.WriteLine ("\n�ift kordinatl� xy de�erlerinin g�sterge adresleriyle yans�t�lmas�:");
            XY_Kordinatlar xyKordinatlar;
            XY_Kordinatlar* gs2 = &xyKordinatlar;
            gs2->X = 1881; gs2->Y = 1938; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));
            gs2->X = 1931; gs2->Y = 2014; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));
            gs2->X = 1934; gs2->Y = 2017; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));

            Console.WriteLine ("\n�ngilizce b�y�k ve k���k-harflerin ASCII tablodan yazd�r�lmas�:");
            char* gkDizi = stackalloc char [123];
            for (int i = 65; i < 123; i++) {gkDizi [i] = (char)i;}
            Console.Write ("B�y�k harfler: "); for (int i = 65; i < 91; i++) {Console.Write (gkDizi [i]);}
            Console.Write ("\nK���k harfler: "); for (int i = 97; i < 123; i++) {Console.Write (gkDizi [i]);}

            Console.WriteLine ("\n\nY���n adres tahsisli tamsay� de�erler:");
            int[] tsDizi2 =  new int [] {2010, 2011, 2012, 2013, 2014, 2015, 2016};
            Console.Write ("Normal tamsay� dizi: "); for (int i = 0; i < tsDizi2.Length; i++) {Console.Write (tsDizi2 [i] + " ");}
            int* tsDizi3 =  stackalloc int [tsDizi2.Length];
            Console.Write ("\nAdresli bo� tamsay� dizi: "); for (int i = 0; i < 7; i++) {Console.Write (tsDizi3 [i] + " ");}
            for (int i = 0; i < tsDizi2.Length; i++) {tsDizi3 [i] = 2010+i;}
            Console.Write ("\nAdresli de�erli tamsay� dizi: "); for (int i = 0; i < 7; i++) {Console.Write (*(tsDizi3 + i) + " ");}
            Console.Write ("\nAdresli ve de�erli tamsay� dizi: "); for (int i = 0; i < 7; i++) {Console.Write ((long)(tsDizi3+i) + ":" + *(tsDizi3 + i) + " ");}
            Console.WriteLine ("\nOrtanca de�er = {0}", tsDizi3 [tsDizi2.Length/2]);
            Console.WriteLine ("Ortanca de�er = {0}", *(tsDizi3 + tsDizi2.Length/2));

            Console.WriteLine ("\n++p ve p++ ile (birer=4 byte) adres art��lar�");
            int* say�lar = stackalloc int[3]; say�lar [0]=2010; say�lar [1]=2011; say�lar [2]=2012;
            int* p1 = say�lar;
            int* p2 = p1;
            Console.WriteLine ("��lem �ncesi: p1 = {0}, p2 = {1}", (long)p1, (long)p2);
            Console.WriteLine ("Sonek art��l� p1: {0}", (long)(p1++));
            Console.WriteLine ("�nek art��l� p2: {0}", (long)(++p2));
            Console.WriteLine ("��lem sonras�: p1 = {0}: {1}, p2 = {2}: {3}", (long)p1, *p1, (long)p2, *p2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}