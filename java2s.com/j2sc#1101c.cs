// j2sc#1101c.cs: Çok boyutlu d[,,,] ve çentikli d[][] dizide ebat, derece, alt/üst sýnýr örneði.

using System;
namespace VeriYapýlarý {
    public class Ýþgören {
        public string isim;
        public double maaþ;
        public Ýþgören (string i, double m) {isim = i; maaþ = m;} //Kurucu
    }
    class VeriYapýsý1C {
        static void Main() {
            Console.Write ("2 boyutlu dizi1[,]'in her satýrdaki sütun sayýsý eþit ve gösterimi dizi1[i,j] iken, 2 boyutlu çentikli dizi2[][]'nin sütun sayýlarý farklý ve gösterimi dizi2[i][j]'dir. Çok boyutlu dizinin herbir boyut ebatý dizi[i].GetLength ile alt/üst sýnýr endeksleri dizi[i].GetLower/UpperBound(0/1/2..) ile alýnýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k, l, ts1, ts2, ts3, ts4; var r=new Random();
            ts1=r.Next(2,10); ts2=r.Next(2,10);
            Console.WriteLine ("2 boyutlu tsayý1({0},{1}) dizisini ilkdeðerleme (i+j) ve sunuþ:", ts1, ts2);
            int[,] tsayý1 = new int [ts1, ts2];
            // Ýlkdeðerleme
            for(i=0;i<tsayý1.GetLength(0);i++) {for(j=0;j<tsayý1.GetLength(1);j++) tsayý1[i, j]=i+j;}
            Console.WriteLine ("\tfor-i ve for-j döngüleriyle dökümleme:");
            for(i=0;i<tsayý1.GetLength(0);i++) {for(j=0;j<tsayý1.GetLength(1);j++) {Console.Write ("{0,3:##0}", tsayý1 [i, j]);} Console.WriteLine();}
            Console.WriteLine ("\tforeach döngüsüyle dökümleme:");
            foreach (int ts in tsayý1) Console.Write (ts+" ");
            Console.WriteLine ("\ntsayý1 (Length, GetLength(0), GetLength(1), Rank) = ({0}, {1}, {2}, {3})", tsayý1.Length, tsayý1.GetLength (0), tsayý1.GetLength (1), tsayý1.Rank);
            Console.WriteLine ("tsayý1.GetLower/UpperBound(0/1) = ({0}, {1}, {2}, {3})", tsayý1.GetLowerBound(0), tsayý1.GetUpperBound(0), tsayý1.GetLowerBound(1), tsayý1.GetUpperBound(1));

            ts3=r.Next(2,10); ts4=0;
            Console.WriteLine ("\n3 boyutlu tsayý2({0},{1},{2}) dizisini ilkdeðerleme (i+j+k) ve sunuþ:", ts1, ts2, ts3);
            int[,,] tsayý2 = new int [ts1, ts2, ts3];
            // Ýlkdeðerleme
            for(i=0;i<tsayý2.GetLength(0);i++) for(j=0;j<tsayý2.GetLength(1);j++) for(k=0;k<tsayý2.GetLength(2);k++) tsayý2 [i, j, k]=i+j+k;
            Console.WriteLine ("\tfor-i, for-j ve for-k döngüleriyle dökümleme:");
            for(i=0;i<tsayý2.GetLength(0);i++) {for(j=0;j<tsayý2.GetLength(1);j++) {for(k=0;k<tsayý2.GetLength(2);k++) Console.Write ("{0,3:##0}", tsayý2 [i, j, k]); Console.Write (", ");} Console.WriteLine();}
            Console.WriteLine ("\tforeach döngüsüyle dökümleme ve toplam:");
            foreach (int ts in tsayý2) {Console.Write (ts+" "); ts4 +=ts;} Console.Write ("==>Toplam: " + ts4);
            Console.WriteLine ("\ntsayý2(Length,GetLength(0),GetLength(1)GetLength(2), Rank) = ({0}, {1}, {2}, {3}, {4})", tsayý2.Length, tsayý2.GetLength (0), tsayý2.GetLength (1), tsayý2.GetLength(2), tsayý2.Rank);
            Console.WriteLine ("tsayý2.GetLower/UpperBound(0/1/2) = ({0}, {1}, {2}, {3}, {4}, {5})", tsayý2.GetLowerBound(0), tsayý2.GetUpperBound(0), tsayý2.GetLowerBound(1), tsayý2.GetUpperBound(1), tsayý2.GetLowerBound(2), tsayý2.GetUpperBound(2));

            Console.WriteLine ("\ntsayý3[{0}][] çentikli dizisini ilkdeðerleme ve sunma:", ts1);
            //ts1 ile tsayý3 ebatýný rasgele tanýmlama
            int[][] tsayý3 = new int [ts1][];
            //ts2 ile ts1 adet rasgele elemanlara her satýrda rasgele ebatlý çentikli diziler tanýmlama
            for(i=0;i<tsayý3.Length;i++) {ts2=r.Next(1,20); tsayý3 [i] = new int [ts2];}
            //Çentikli dizi elemanlarýný %[0-->100] ilkdeðerleme
            for(i=0;i<tsayý3.Length;i++) for(j=0;j<tsayý3 [i].Length;j++) tsayý3 [i][j] = (i+2) * (j+2);
            Console.WriteLine ("tsayý3 dizisinin sabit satýr sayýsý: {0}", tsayý3.Length);
            Console.Write ("tsayý3 dizisinin farklý sütun sayýlarý: "); for(i=0;i<tsayý3.Length;i++) Console.Write (tsayý3 [i].Length + " ");
            Console.Write ("\ntsayý3.GetLower/UpperBound(0): "); for(i=0;i<tsayý3.Length;i++) Console.Write (tsayý3 [i].GetLowerBound(0) + " " + tsayý3 [i].GetUpperBound(0) + ", ");
            Console.WriteLine ("\n\tÇentikli tsayý3 dizisinin dökümü:");
            for(i=0;i<tsayý3.Length;i++) {for(j=0;j<tsayý3 [i].Length;j++) Console.Write (tsayý3 [i][j] + " "); Console.WriteLine();}

            ts4=r.Next(9,20);
            Console.WriteLine ("\nndizi1[{0}] nesne dizisine her tip karma veri atanabilir:", ts4);
            object[] ndizi1 = new object [ts4]; 
            // Tamsayý yükle
            for(i=0;i<ts4/3;i++) ndizi1 [i] = i+2020;
            // Dublesayý yükle
            for(j=i;j<i*2;j++) ndizi1 [j] = Math.Sqrt (j+2020);
            // bool, char, string yükle
            ndizi1 [j++] = true; ndizi1 [j++] = (char)65;
            for(k=j;k<ts4;k++) ndizi1 [k] = "Nihat";
            for(i=0;i<ndizi1.Length; i++) Console.Write ("nesne[{0}]={1} ", i, ndizi1 [i]);

            char[] kdizi1 = {'H','o','þ','g','e','l','d','i','n','i','z','!','.','.'};
            Console.WriteLine ("\n\nkdizi1[{0}] karakter dizisi düz, ters, artan/azalan sýralý sunulabilir:", kdizi1.Length);
            Console.Write ("Düz: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");
            Console.Write ("\nTers: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [kdizi1.Length-1-i] + " ");
            Array.Sort (kdizi1); Console.Write ("\nArtan sýralý: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");
            Array.Reverse (kdizi1); Console.Write ("\nAzalan sýralý: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");

            ts1=r.Next(1,100); ts2=r.Next(1,100); ts3=r.Next(1,100); ts4=r.Next(1,100);
            Console.WriteLine ("\n\n4 boyutlu iþgDizi({0},{1},{2},{3})'nin mevcut kayýtlarý:", ts1, ts2, ts3, ts4);
            double ds1; string ad;
            Ýþgören[,,,] iþgDizi = new Ýþgören [ts1, ts2, ts3, ts4];
            for(i=0;i<5;i++) {
                ts1=r.Next(0,iþgDizi.GetLength(0)); ts2=r.Next(0,iþgDizi.GetLength(1)); ts3=r.Next(0,iþgDizi.GetLength(2)); ts4=r.Next(0,iþgDizi.GetLength(3));
                ad=""; for(j=0;j<5;j++) {k=r.Next(0,26); ad+=(char)(k+65);}
                ds1=r.Next(7500,100000)+r.Next(10,100)/100D;
                iþgDizi [ts1, ts2, ts3, ts4] = new Ýþgören (ad, ds1);
            }
            Console.WriteLine ("iþgDizi eleman sayýsý: {0};\tboyut sayýsý: {1}", iþgDizi.Length, iþgDizi.Rank);
            Console.WriteLine ("\tiþgDizi'nin maaþ ödeme günü elemanlarý:");
            for(i=0;i<iþgDizi.GetLength(0);i++) {
                for(j=0;j<iþgDizi.GetLength(1);j++) {
                    for(k=0;k<iþgDizi.GetLength(2);k++) {
                        for(l=0;l<iþgDizi.GetLength(3);l++) {
                            if (iþgDizi[i,j,k,l] != null) Console.WriteLine ("iþgDizi [{0,2},{1,2},{2,2},{3,2}].isim = {4};\t.maaþ = {5:#,0.00} TL", i, j, k, l, iþgDizi [i,j,k,l].isim, iþgDizi [i,j,k,l].maaþ);
            }}}}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}