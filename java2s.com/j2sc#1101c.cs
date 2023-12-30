// j2sc#1101c.cs: �ok boyutlu d[,,,] ve �entikli d[][] dizide ebat, derece, alt/�st s�n�r �rne�i.

using System;
namespace VeriYap�lar� {
    public class ��g�ren {
        public string isim;
        public double maa�;
        public ��g�ren (string i, double m) {isim = i; maa� = m;} //Kurucu
    }
    class VeriYap�s�1C {
        static void Main() {
            Console.Write ("2 boyutlu dizi1[,]'in her sat�rdaki s�tun say�s� e�it ve g�sterimi dizi1[i,j] iken, 2 boyutlu �entikli dizi2[][]'nin s�tun say�lar� farkl� ve g�sterimi dizi2[i][j]'dir. �ok boyutlu dizinin herbir boyut ebat� dizi[i].GetLength ile alt/�st s�n�r endeksleri dizi[i].GetLower/UpperBound(0/1/2..) ile al�n�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k, l, ts1, ts2, ts3, ts4; var r=new Random();
            ts1=r.Next(2,10); ts2=r.Next(2,10);
            Console.WriteLine ("2 boyutlu tsay�1({0},{1}) dizisini ilkde�erleme (i+j) ve sunu�:", ts1, ts2);
            int[,] tsay�1 = new int [ts1, ts2];
            // �lkde�erleme
            for(i=0;i<tsay�1.GetLength(0);i++) {for(j=0;j<tsay�1.GetLength(1);j++) tsay�1[i, j]=i+j;}
            Console.WriteLine ("\tfor-i ve for-j d�ng�leriyle d�k�mleme:");
            for(i=0;i<tsay�1.GetLength(0);i++) {for(j=0;j<tsay�1.GetLength(1);j++) {Console.Write ("{0,3:##0}", tsay�1 [i, j]);} Console.WriteLine();}
            Console.WriteLine ("\tforeach d�ng�s�yle d�k�mleme:");
            foreach (int ts in tsay�1) Console.Write (ts+" ");
            Console.WriteLine ("\ntsay�1 (Length, GetLength(0), GetLength(1), Rank) = ({0}, {1}, {2}, {3})", tsay�1.Length, tsay�1.GetLength (0), tsay�1.GetLength (1), tsay�1.Rank);
            Console.WriteLine ("tsay�1.GetLower/UpperBound(0/1) = ({0}, {1}, {2}, {3})", tsay�1.GetLowerBound(0), tsay�1.GetUpperBound(0), tsay�1.GetLowerBound(1), tsay�1.GetUpperBound(1));

            ts3=r.Next(2,10); ts4=0;
            Console.WriteLine ("\n3 boyutlu tsay�2({0},{1},{2}) dizisini ilkde�erleme (i+j+k) ve sunu�:", ts1, ts2, ts3);
            int[,,] tsay�2 = new int [ts1, ts2, ts3];
            // �lkde�erleme
            for(i=0;i<tsay�2.GetLength(0);i++) for(j=0;j<tsay�2.GetLength(1);j++) for(k=0;k<tsay�2.GetLength(2);k++) tsay�2 [i, j, k]=i+j+k;
            Console.WriteLine ("\tfor-i, for-j ve for-k d�ng�leriyle d�k�mleme:");
            for(i=0;i<tsay�2.GetLength(0);i++) {for(j=0;j<tsay�2.GetLength(1);j++) {for(k=0;k<tsay�2.GetLength(2);k++) Console.Write ("{0,3:##0}", tsay�2 [i, j, k]); Console.Write (", ");} Console.WriteLine();}
            Console.WriteLine ("\tforeach d�ng�s�yle d�k�mleme ve toplam:");
            foreach (int ts in tsay�2) {Console.Write (ts+" "); ts4 +=ts;} Console.Write ("==>Toplam: " + ts4);
            Console.WriteLine ("\ntsay�2(Length,GetLength(0),GetLength(1)GetLength(2), Rank) = ({0}, {1}, {2}, {3}, {4})", tsay�2.Length, tsay�2.GetLength (0), tsay�2.GetLength (1), tsay�2.GetLength(2), tsay�2.Rank);
            Console.WriteLine ("tsay�2.GetLower/UpperBound(0/1/2) = ({0}, {1}, {2}, {3}, {4}, {5})", tsay�2.GetLowerBound(0), tsay�2.GetUpperBound(0), tsay�2.GetLowerBound(1), tsay�2.GetUpperBound(1), tsay�2.GetLowerBound(2), tsay�2.GetUpperBound(2));

            Console.WriteLine ("\ntsay�3[{0}][] �entikli dizisini ilkde�erleme ve sunma:", ts1);
            //ts1 ile tsay�3 ebat�n� rasgele tan�mlama
            int[][] tsay�3 = new int [ts1][];
            //ts2 ile ts1 adet rasgele elemanlara her sat�rda rasgele ebatl� �entikli diziler tan�mlama
            for(i=0;i<tsay�3.Length;i++) {ts2=r.Next(1,20); tsay�3 [i] = new int [ts2];}
            //�entikli dizi elemanlar�n� %[0-->100] ilkde�erleme
            for(i=0;i<tsay�3.Length;i++) for(j=0;j<tsay�3 [i].Length;j++) tsay�3 [i][j] = (i+2) * (j+2);
            Console.WriteLine ("tsay�3 dizisinin sabit sat�r say�s�: {0}", tsay�3.Length);
            Console.Write ("tsay�3 dizisinin farkl� s�tun say�lar�: "); for(i=0;i<tsay�3.Length;i++) Console.Write (tsay�3 [i].Length + " ");
            Console.Write ("\ntsay�3.GetLower/UpperBound(0): "); for(i=0;i<tsay�3.Length;i++) Console.Write (tsay�3 [i].GetLowerBound(0) + " " + tsay�3 [i].GetUpperBound(0) + ", ");
            Console.WriteLine ("\n\t�entikli tsay�3 dizisinin d�k�m�:");
            for(i=0;i<tsay�3.Length;i++) {for(j=0;j<tsay�3 [i].Length;j++) Console.Write (tsay�3 [i][j] + " "); Console.WriteLine();}

            ts4=r.Next(9,20);
            Console.WriteLine ("\nndizi1[{0}] nesne dizisine her tip karma veri atanabilir:", ts4);
            object[] ndizi1 = new object [ts4]; 
            // Tamsay� y�kle
            for(i=0;i<ts4/3;i++) ndizi1 [i] = i+2020;
            // Dublesay� y�kle
            for(j=i;j<i*2;j++) ndizi1 [j] = Math.Sqrt (j+2020);
            // bool, char, string y�kle
            ndizi1 [j++] = true; ndizi1 [j++] = (char)65;
            for(k=j;k<ts4;k++) ndizi1 [k] = "Nihat";
            for(i=0;i<ndizi1.Length; i++) Console.Write ("nesne[{0}]={1} ", i, ndizi1 [i]);

            char[] kdizi1 = {'H','o','�','g','e','l','d','i','n','i','z','!','.','.'};
            Console.WriteLine ("\n\nkdizi1[{0}] karakter dizisi d�z, ters, artan/azalan s�ral� sunulabilir:", kdizi1.Length);
            Console.Write ("D�z: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");
            Console.Write ("\nTers: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [kdizi1.Length-1-i] + " ");
            Array.Sort (kdizi1); Console.Write ("\nArtan s�ral�: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");
            Array.Reverse (kdizi1); Console.Write ("\nAzalan s�ral�: "); for(i=0;i<kdizi1.Length;i++) Console.Write (kdizi1 [i] + " ");

            ts1=r.Next(1,100); ts2=r.Next(1,100); ts3=r.Next(1,100); ts4=r.Next(1,100);
            Console.WriteLine ("\n\n4 boyutlu i�gDizi({0},{1},{2},{3})'nin mevcut kay�tlar�:", ts1, ts2, ts3, ts4);
            double ds1; string ad;
            ��g�ren[,,,] i�gDizi = new ��g�ren [ts1, ts2, ts3, ts4];
            for(i=0;i<5;i++) {
                ts1=r.Next(0,i�gDizi.GetLength(0)); ts2=r.Next(0,i�gDizi.GetLength(1)); ts3=r.Next(0,i�gDizi.GetLength(2)); ts4=r.Next(0,i�gDizi.GetLength(3));
                ad=""; for(j=0;j<5;j++) {k=r.Next(0,26); ad+=(char)(k+65);}
                ds1=r.Next(7500,100000)+r.Next(10,100)/100D;
                i�gDizi [ts1, ts2, ts3, ts4] = new ��g�ren (ad, ds1);
            }
            Console.WriteLine ("i�gDizi eleman say�s�: {0};\tboyut say�s�: {1}", i�gDizi.Length, i�gDizi.Rank);
            Console.WriteLine ("\ti�gDizi'nin maa� �deme g�n� elemanlar�:");
            for(i=0;i<i�gDizi.GetLength(0);i++) {
                for(j=0;j<i�gDizi.GetLength(1);j++) {
                    for(k=0;k<i�gDizi.GetLength(2);k++) {
                        for(l=0;l<i�gDizi.GetLength(3);l++) {
                            if (i�gDizi[i,j,k,l] != null) Console.WriteLine ("i�gDizi [{0,2},{1,2},{2,2},{3,2}].isim = {4};\t.maa� = {5:#,0.00} TL", i, j, k, l, i�gDizi [i,j,k,l].isim, i�gDizi [i,j,k,l].maa�);
            }}}}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}