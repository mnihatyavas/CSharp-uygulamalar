// j2sc#1101b.cs: Dizi ebat�, ilk/son endeksi, uzunluk ve derecesi �rne�i.

using System;
namespace VeriYap�lar� {
    class VeriYap�s�1B {
        public static void DiziYaz (int[] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.Length;i++) Console.Write ("{0}={1} ", i, d [i]); Console.WriteLine();}
        public static void MatrisYaz (int[,] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.GetLength(0);i++) for(int j=0;j<d.GetLength(1);j++) Console.Write ("{0} ", d [i, j]); Console.WriteLine();}
        public static void ��boyutYaz (int[,,] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.GetLength(0);i++) for(int j=0;j<d.GetLength(1);j++) for(int k=0;k<d.GetLength(2);k++)Console.Write ("{0} ", d [i, j, k]); Console.WriteLine();}
        static void Main() {
            Console.Write ("'Array.Last/IndexOf(dizi,de�er)' de�erin dizi'deki ilk/son endeks no'sunu, namevcutsa -1 d�nd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k, ts1, ts2, ts3; var r=new Random();
            ts1=r.Next(5,100);
            Console.WriteLine ("{0} ebatl� bir diziyi t�m elemanlar�yla di�erbir diziye atama:", ts1);
            int[] tsay�1 = new int [ts1]; int[] tsay�2 = new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(0,1000); tsay�1 [i] = ts2;  tsay�2 [i] = -ts2;}
            Console.Write ("\tTSay�1: [");
            for(i=0;i<ts1;i++) Console.Write (tsay�1 [i] + ", "); Console.WriteLine ("]");
            Console.Write ("\tTSay�2: [");
            for(i=0;i<ts1;i++) Console.Write (tsay�2 [i] + ", ");
            tsay�2 = tsay�1;
            Console.Write ("]\n\tTSay�2=TSay�1 sonras� TSay�2: [");
            for(i=0;i<ts1;i++) Console.Write (tsay�2 [i] + ", "); Console.WriteLine ("]");

            ts1=r.Next(5,100);
            Console.WriteLine ("\n{0} ebatl� dizide bulunan Array.Last/IndexOf (tsay�3, ts) endeks no'lar:", ts1);
            int[] tsay�3 = new int [ts1];
            Console.Write ("TSay�3: [");
            for(i=0;i<tsay�3.Length;i++) {ts1=r.Next(0,10); tsay�3 [i] = ts1; Console.Write ("tsay�3[{0}]={1}, ", i, tsay�3 [i]);}
            Console.Write ("]\n\tArray.IndexOf(TSay�3, ts1[{0}]) = {1}", ts1, Array.IndexOf (tsay�3, ts1));
            Console.WriteLine ("\n\tArray.LastIndexOf(tsay�3, ts1[{0}]) = {1}", ts1, Array.LastIndexOf (tsay�3, ts1));

            Console.WriteLine ("\nsDizi'nin endeksli elemanlar� ve 'Selam'�n ilk/son endeksi:");
            string[] sDizi = {"Benden", "sana", "Selam", "herkese", "Selam"};
            Console.WriteLine ("\tsDizi:");
            for(i=0;i<sDizi.Length;i++)  Console.WriteLine ("sDizi[{0}] = {1}", i, sDizi [i]);
            Console.WriteLine ("Array.IndexOf(sDizi, \"Selam\") = {0}", Array.IndexOf (sDizi, "Selam"));
            Console.WriteLine ("Array.LastIndexOf(sDizi, \"Selam\") = {0}", Array.LastIndexOf (sDizi, "Selam"));
            Console.WriteLine ("Array.IndexOf(sDizi, \"selam\") = {0}", Array.IndexOf (sDizi, "selam"));

            ts1=r.Next(5,100);
            Console.WriteLine ("\ntdizi4[{0}] diziyi Length'le ilkde�erleme ve sunma:", ts1);
            int[] tsay�4 = new int [ts1];
            Console.WriteLine ("\ttsay�4 dizisinin rasgele uzunlu�u = {0}", tsay�4.Length);
            Console.WriteLine ("Length kullanarak tsdizi'yi rasgele ilkde�erleme...");
            for(i=0;i<tsay�4.Length;i++) {ts2=r.Next(0,100); tsay�4 [i] = ts2 * ts2;}
            Console.WriteLine ("Length kullanarak tsdizi elemanlar�n� d�k�mleme...");
            for(i=0;i<tsay�4.Length;i++) Console.Write (tsay�4 [i] + " ");

            Console.WriteLine ("\n\nBir dizinin herbir boyut ebat� program i�inde de�i�tirilebilir:");
            int[,,] tsay�5;
            for(i=0;i<5;i++) {
                ts1=r.Next(1,50); ts2=r.Next(1,50); ts3=r.Next(1,50);
                tsay�5 = new int [ts1, ts2, ts3];
                Console.WriteLine ("3 boyutlu tsay�5 dizisinin rasgele uzunlu�u: ({0} * {1} * {2}) = {3}", tsay�5.GetLength (0), tsay�5.GetLength (1), tsay�5.GetLength (2), tsay�5.Length);
            }

            ts1=r.Next(1,11);
            Console.WriteLine ("\ntsay�6[{0}][] �entikli dizisini ilkde�erleme ve sunma:", ts1);
            //ts1 ile tsay�6 ebat�n� rasgele tan�mlama
            int[][] tsay�6 = new int[ts1][];
            //ts2 ile ts1 adet rasgele elemanlara rasgele ebatl� �entikli diziler tan�mlama
            for(i=0;i<tsay�6.Length;i++) {ts2=r.Next(1,11); tsay�6 [i] = new int [ts2];}
            //�entikli dizi elemanlar�n� %[0-->100] ilkde�erleme
            for(i=0;i<tsay�6.Length;i++) {
                for(j=0;j<tsay�6 [i].Length;j++) {tsay�6 [i][j] = (i+1) * (j+1);}
            }
            Console.WriteLine ("tsay�6 dizisinin d���m say�s�: {0}", tsay�6.Length);
            for(i=0;i<tsay�6.Length;i++) {
                for(j=0;j<tsay�6 [i].Length;j++) {Console.WriteLine ("tsay�6 [{0}][{1}] = %{2}", i, j, tsay�6 [i][j]);}
            }

            Console.WriteLine ("\nadlar[4,9] dizgesel matrisinin ebat ve de�erleri:");
            string[,] adlar = {
                {"J", "M", "P", "J", "M", "P", "P", "J", "M"},
                {"S", "E", "S", "S", "E", "S", "C", "A", "W"},
                {"C", "A", "W", "C", "A", "W", "G", "P", "J"},
                {"G", "P", "J", "G", "P", "J", "P", "J", "G"},
            };
            Console.WriteLine ("'adlar' matrisin (sat�r[{0}] * s�tun[{1}] = uzunluk[{2}])", adlar.GetLength (0), adlar.GetLength (1), adlar.Length);
            for(i=0;i<adlar.GetLength(0);i++) {for(j=0;j<adlar.GetLength(1);j++) Console.Write (adlar [i,j] + "  "); Console.WriteLine();}

            Console.WriteLine ("\nTek, �ift ve 3 boyutlu dizileri ilkde�erleme, sunma ve derece/boyut:");
            ts1=r.Next(1,57);
            int[] x = new int [ts1];
            for(i=0;i<x.Length;i++) x [i] = 1881+i;
            DiziYaz (x);
            ts1=r.Next(1,30); ts2=r.Next(1,30);
            int[,] y = new int [ts1, ts2];
            for(i=0;i<y.GetLength (0);i++) for(j=0;j<y.GetLength (1);j++) y [i, j] = i + j + 1881;
            MatrisYaz (y);
            ts1=r.Next(1,20); ts2=r.Next(1,20); ts3=r.Next(1,20);
            int[,,] z = new int [ts1, ts2, ts3];
            for(i=0;i<z.GetLength (0);i++) for(j=0;j<z.GetLength (1);j++) for(k=0;k<z.GetLength (2);k++) z [i, j, k] = i + j + k + 1881;
            ��boyutYaz (z);

            Console.WriteLine ("\nDizi ebat�n� her �al��t�rmada siz de girebilirsiniz:");
            string[] liste;
            Console.Write ("Dizi listesinde ka� kalem olsun? ");
            try {ts1 = Math.Abs (int.Parse (Console.ReadLine()));}catch {ts1=100;} if(ts1>500)ts1=500;
            liste = new string [ts1];
            for(i=0;i<liste.Length;i++) liste [i]=((char)i).ToString();
            for(i=0;i<liste.Length;i++) Console.Write (liste [i] + ", "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}