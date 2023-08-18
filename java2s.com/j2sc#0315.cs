// j2sc#0315.cs: Deðiþkenin deðerini yada adresini kullanma  örneði.
// unsafe kodlamalar: ">>csc /unsafe örnek.cs" seçenekli derlenir. Kodlamada ya metod satýrýnda, yada metod içi özel blok'ta "unsafe" beyaný gerekir.

using System;
namespace Ýþlemciler {
    public struct XY_Kordinatlar {
        public int X;
        public int Y;
        public override string ToString() {return "("+X+", "+Y+")";}
    }
    class AdresÝþlemci {
        static unsafe void Main() {
            Console.Write ("Deðiþken adresini 'int* gösterge=&deðiþken' atayýp, o adresteki tek yada ardýþýk deðerlere ulaþabiliriz. Deðer ts1 ve *gs1'de, adres ise &ts1 ve gs1'dedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tamsayý deðiþkenin deðerine ve bellek adresine eriþim:");
            unsafe {
                int ts1 = 2023;
                int* gs1 = &ts1;
                Console.WriteLine ("int ts1'in deðeri: {0}={1}", ts1, *gs1);
                Console.WriteLine ("int ts1'in adresi: {0}={1}", (long)gs1, (long)&ts1);
            }

            Console.WriteLine ("\nTamsayý dizinin deðerlerine ve bellek adreslerine eriþim:");
            unsafe {
                const int diziEbatý = 3;
                int[] tsDizi = new int [diziEbatý] {1951, 2023, 2051};
                fixed (int* gsÝlk = &tsDizi [0]) {
                    int* gsSon = gsÝlk + (diziEbatý - 1);
                    Console.WriteLine ("{0} adresteki ÝLK deðer: {1}", (long)gsÝlk, *gsÝlk);
                    Console.WriteLine ("{0} adresteki SON deðer: {1}", (long)gsSon, *gsSon);
                    Console.WriteLine ("{0} adresteki ORTA deðer: {1}", (long)(gsÝlk+1), *(gsÝlk+1));
                }
            }

            Console.WriteLine ("\nÇift kordinatlý xy deðerlerinin gösterge adresleriyle yansýtýlmasý:");
            XY_Kordinatlar xyKordinatlar;
            XY_Kordinatlar* gs2 = &xyKordinatlar;
            gs2->X = 1881; gs2->Y = 1938; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));
            gs2->X = 1931; gs2->Y = 2014; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));
            gs2->X = 1934; gs2->Y = 2017; Console.WriteLine ("(x, y) = {0}: {1}", gs2->ToString(), (gs2->Y-gs2->X));

            Console.WriteLine ("\nÝngilizce büyük ve küçük-harflerin ASCII tablodan yazdýrýlmasý:");
            char* gkDizi = stackalloc char [123];
            for (int i = 65; i < 123; i++) {gkDizi [i] = (char)i;}
            Console.Write ("Büyük harfler: "); for (int i = 65; i < 91; i++) {Console.Write (gkDizi [i]);}
            Console.Write ("\nKüçük harfler: "); for (int i = 97; i < 123; i++) {Console.Write (gkDizi [i]);}

            Console.WriteLine ("\n\nYýðýn adres tahsisli tamsayý deðerler:");
            int[] tsDizi2 =  new int [] {2010, 2011, 2012, 2013, 2014, 2015, 2016};
            Console.Write ("Normal tamsayý dizi: "); for (int i = 0; i < tsDizi2.Length; i++) {Console.Write (tsDizi2 [i] + " ");}
            int* tsDizi3 =  stackalloc int [tsDizi2.Length];
            Console.Write ("\nAdresli boþ tamsayý dizi: "); for (int i = 0; i < 7; i++) {Console.Write (tsDizi3 [i] + " ");}
            for (int i = 0; i < tsDizi2.Length; i++) {tsDizi3 [i] = 2010+i;}
            Console.Write ("\nAdresli deðerli tamsayý dizi: "); for (int i = 0; i < 7; i++) {Console.Write (*(tsDizi3 + i) + " ");}
            Console.Write ("\nAdresli ve deðerli tamsayý dizi: "); for (int i = 0; i < 7; i++) {Console.Write ((long)(tsDizi3+i) + ":" + *(tsDizi3 + i) + " ");}
            Console.WriteLine ("\nOrtanca deðer = {0}", tsDizi3 [tsDizi2.Length/2]);
            Console.WriteLine ("Ortanca deðer = {0}", *(tsDizi3 + tsDizi2.Length/2));

            Console.WriteLine ("\n++p ve p++ ile (birer=4 byte) adres artýþlarý");
            int* sayýlar = stackalloc int[3]; sayýlar [0]=2010; sayýlar [1]=2011; sayýlar [2]=2012;
            int* p1 = sayýlar;
            int* p2 = p1;
            Console.WriteLine ("Ýþlem öncesi: p1 = {0}, p2 = {1}", (long)p1, (long)p2);
            Console.WriteLine ("Sonek artýþlý p1: {0}", (long)(p1++));
            Console.WriteLine ("Önek artýþlý p2: {0}", (long)(++p2));
            Console.WriteLine ("Ýþlem sonrasý: p1 = {0}: {1}, p2 = {2}: {3}", (long)p1, *p1, (long)p2, *p2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}