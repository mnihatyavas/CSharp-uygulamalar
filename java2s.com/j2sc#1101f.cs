// j2sc#1101f.cs: Array.ForEach ve Array.BinarySearch �rne�i.

using System;
namespace VeriYap�lar� {
    class S�n�f1 {
        private int i;
        public S�n�f1() {i = 0;} //Kurucu
        public S�n�f1 (int x) {i = x;} //Kurucu
        public void g�ster (S�n�f1 nes) {Console.Write (nes.i + " ");}
    }
    class VeriYap�s�1F {
        static int[] BoyutEndeksleri (int endeks, Array dizi) {
            int[] endeksler = new int [dizi.Rank];
            int k = 1;
            for (int i = dizi.Rank-1; i >= 0; i--) {
                endeksler [i] = (((endeks/k)) % (dizi.GetUpperBound (i)+1));
                if(i > 0) {k *= dizi.GetUpperBound (i)+1;}
            }
            return endeksler;
        }
        static void Main() {
            Console.Write ("Array.ForEach<T>(dizi,delegate(){}) ile dizi ��eanlar� tek-tek anonim delegeyle i�lem g�r�r. Anonim delege yerine nrsnel/statik metot da kullan�labilir.\nArray.BinarySearch �al��mas� i�in dizi artan s�ralanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ForEach'li anonim delegeyle dizi elemanlar�n�n taranmas�:");
            int i, j, k, ts1, ts2; var r=new Random();
            int[] tsDizi1 = new int [58];
            for(i=0;i<tsDizi1.Length;i++) tsDizi1 [i]=i+1881;
            Array.ForEach<int> (tsDizi1, delegate (int x) {Console.Write (x + " ");});

            ts1=r.Next(2,50);
            Console.WriteLine ("\n\nRasgele tamsay� ��eanl� tsDizi1[{0}]'yi ForEach'le g�sterme:", ts1);
            S�n�f1[] tsDizi2 = new S�n�f1 [ts1];
            for(i=0;i<tsDizi2.Length;i++) {ts1=r.Next(-1000,1000); tsDizi2 [i]=new S�n�f1 (ts1);}
            Array.ForEach (tsDizi2, new S�n�f1().g�ster);

            i=r.Next(1,5); j=r.Next(1,5); k=r.Next(1,5);
            Console.WriteLine ("\n\n3 boyutlu tsDizi3[{0},{1},{2}] dizisinin ard���k [i,j,k]=de�er d�k�m�:", i, j, k);
            int[,,] tsDizi3 = new int [i,j,k];
            for(i=0;i<tsDizi3.GetLength(0);i++) {
                for(j=0;j<tsDizi3.GetLength(1);j++) {
                    for(k=0;k<tsDizi3.GetLength(2);k++) tsDizi3 [i,j,k] = i + j + k;
                }
            }
            int endeks = 0;
            foreach (int ��e in tsDizi3) {
                foreach (int endeksler in BoyutEndeksleri (endeks, tsDizi3)) Console.Write ("[{0}]", endeksler);
                Console.WriteLine ("={0}", ��e);
                endeks++;
            }

            ts1=r.Next(2,50); ts2=r.Next(0,20);
            Console.WriteLine ("\ntsDizi4[{0}] dizi elemanlar�nda {1} de�erinin ilk endeks no'su?:", ts1, ts2);
            int[] tsDizi4 = new int [ts1];
            for(i=0;i<tsDizi4.Length;i++) {ts1=r.Next(0,20); tsDizi4 [i]=ts1;}
            Array.Sort (tsDizi4);
            for(i=0;i<tsDizi4.Length;i++) Console.Write (tsDizi4 [i]+" ");
            i = Array.BinarySearch (tsDizi4, ts2);
            Console.WriteLine ("\nArray.BinarySearch (tsDizi4, {0}) = {1}", ts2, i<0?-1:i);

            ts1=r.Next(2,50); ts2=r.Next(65,91);
            Console.WriteLine ("\nhrfDizi1[{0}] dizi elemanlar�nda {1} de�erinin ilk endeks no'su?:", ts1, (char)ts2);
            char[] hrfDizi1 = new char [ts1];
            for(i=0;i<hrfDizi1.Length;i++) {ts1=r.Next(65,91); hrfDizi1 [i]=(char)ts1;}
            Array.Sort (hrfDizi1);
            for(i=0;i<hrfDizi1.Length;i++) Console.Write (hrfDizi1 [i]+" ");
            i = Array.BinarySearch (hrfDizi1, (char)ts2);
            Console.WriteLine ("\nArray.BinarySearch (hrfDizi1, {0}) = {1}", (char)ts2, i<0?-1:i);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}