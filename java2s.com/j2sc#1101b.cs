// j2sc#1101b.cs: Dizi ebatý, ilk/son endeksi, uzunluk ve derecesi örneði.

using System;
namespace VeriYapýlarý {
    class VeriYapýsý1B {
        public static void DiziYaz (int[] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.Length;i++) Console.Write ("{0}={1} ", i, d [i]); Console.WriteLine();}
        public static void MatrisYaz (int[,] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.GetLength(0);i++) for(int j=0;j<d.GetLength(1);j++) Console.Write ("{0} ", d [i, j]); Console.WriteLine();}
        public static void ÜçboyutYaz (int[,,] d) {Console.WriteLine ("Derece="+d.Rank); for(int i=0;i<d.GetLength(0);i++) for(int j=0;j<d.GetLength(1);j++) for(int k=0;k<d.GetLength(2);k++)Console.Write ("{0} ", d [i, j, k]); Console.WriteLine();}
        static void Main() {
            Console.Write ("'Array.Last/IndexOf(dizi,deðer)' deðerin dizi'deki ilk/son endeks no'sunu, namevcutsa -1 döndürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k, ts1, ts2, ts3; var r=new Random();
            ts1=r.Next(5,100);
            Console.WriteLine ("{0} ebatlý bir diziyi tüm elemanlarýyla diðerbir diziye atama:", ts1);
            int[] tsayý1 = new int [ts1]; int[] tsayý2 = new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(0,1000); tsayý1 [i] = ts2;  tsayý2 [i] = -ts2;}
            Console.Write ("\tTSayý1: [");
            for(i=0;i<ts1;i++) Console.Write (tsayý1 [i] + ", "); Console.WriteLine ("]");
            Console.Write ("\tTSayý2: [");
            for(i=0;i<ts1;i++) Console.Write (tsayý2 [i] + ", ");
            tsayý2 = tsayý1;
            Console.Write ("]\n\tTSayý2=TSayý1 sonrasý TSayý2: [");
            for(i=0;i<ts1;i++) Console.Write (tsayý2 [i] + ", "); Console.WriteLine ("]");

            ts1=r.Next(5,100);
            Console.WriteLine ("\n{0} ebatlý dizide bulunan Array.Last/IndexOf (tsayý3, ts) endeks no'lar:", ts1);
            int[] tsayý3 = new int [ts1];
            Console.Write ("TSayý3: [");
            for(i=0;i<tsayý3.Length;i++) {ts1=r.Next(0,10); tsayý3 [i] = ts1; Console.Write ("tsayý3[{0}]={1}, ", i, tsayý3 [i]);}
            Console.Write ("]\n\tArray.IndexOf(TSayý3, ts1[{0}]) = {1}", ts1, Array.IndexOf (tsayý3, ts1));
            Console.WriteLine ("\n\tArray.LastIndexOf(tsayý3, ts1[{0}]) = {1}", ts1, Array.LastIndexOf (tsayý3, ts1));

            Console.WriteLine ("\nsDizi'nin endeksli elemanlarý ve 'Selam'ýn ilk/son endeksi:");
            string[] sDizi = {"Benden", "sana", "Selam", "herkese", "Selam"};
            Console.WriteLine ("\tsDizi:");
            for(i=0;i<sDizi.Length;i++)  Console.WriteLine ("sDizi[{0}] = {1}", i, sDizi [i]);
            Console.WriteLine ("Array.IndexOf(sDizi, \"Selam\") = {0}", Array.IndexOf (sDizi, "Selam"));
            Console.WriteLine ("Array.LastIndexOf(sDizi, \"Selam\") = {0}", Array.LastIndexOf (sDizi, "Selam"));
            Console.WriteLine ("Array.IndexOf(sDizi, \"selam\") = {0}", Array.IndexOf (sDizi, "selam"));

            ts1=r.Next(5,100);
            Console.WriteLine ("\ntdizi4[{0}] diziyi Length'le ilkdeðerleme ve sunma:", ts1);
            int[] tsayý4 = new int [ts1];
            Console.WriteLine ("\ttsayý4 dizisinin rasgele uzunluðu = {0}", tsayý4.Length);
            Console.WriteLine ("Length kullanarak tsdizi'yi rasgele ilkdeðerleme...");
            for(i=0;i<tsayý4.Length;i++) {ts2=r.Next(0,100); tsayý4 [i] = ts2 * ts2;}
            Console.WriteLine ("Length kullanarak tsdizi elemanlarýný dökümleme...");
            for(i=0;i<tsayý4.Length;i++) Console.Write (tsayý4 [i] + " ");

            Console.WriteLine ("\n\nBir dizinin herbir boyut ebatý program içinde deðiþtirilebilir:");
            int[,,] tsayý5;
            for(i=0;i<5;i++) {
                ts1=r.Next(1,50); ts2=r.Next(1,50); ts3=r.Next(1,50);
                tsayý5 = new int [ts1, ts2, ts3];
                Console.WriteLine ("3 boyutlu tsayý5 dizisinin rasgele uzunluðu: ({0} * {1} * {2}) = {3}", tsayý5.GetLength (0), tsayý5.GetLength (1), tsayý5.GetLength (2), tsayý5.Length);
            }

            ts1=r.Next(1,11);
            Console.WriteLine ("\ntsayý6[{0}][] çentikli dizisini ilkdeðerleme ve sunma:", ts1);
            //ts1 ile tsayý6 ebatýný rasgele tanýmlama
            int[][] tsayý6 = new int[ts1][];
            //ts2 ile ts1 adet rasgele elemanlara rasgele ebatlý çentikli diziler tanýmlama
            for(i=0;i<tsayý6.Length;i++) {ts2=r.Next(1,11); tsayý6 [i] = new int [ts2];}
            //Çentikli dizi elemanlarýný %[0-->100] ilkdeðerleme
            for(i=0;i<tsayý6.Length;i++) {
                for(j=0;j<tsayý6 [i].Length;j++) {tsayý6 [i][j] = (i+1) * (j+1);}
            }
            Console.WriteLine ("tsayý6 dizisinin düðüm sayýsý: {0}", tsayý6.Length);
            for(i=0;i<tsayý6.Length;i++) {
                for(j=0;j<tsayý6 [i].Length;j++) {Console.WriteLine ("tsayý6 [{0}][{1}] = %{2}", i, j, tsayý6 [i][j]);}
            }

            Console.WriteLine ("\nadlar[4,9] dizgesel matrisinin ebat ve deðerleri:");
            string[,] adlar = {
                {"J", "M", "P", "J", "M", "P", "P", "J", "M"},
                {"S", "E", "S", "S", "E", "S", "C", "A", "W"},
                {"C", "A", "W", "C", "A", "W", "G", "P", "J"},
                {"G", "P", "J", "G", "P", "J", "P", "J", "G"},
            };
            Console.WriteLine ("'adlar' matrisin (satýr[{0}] * sütun[{1}] = uzunluk[{2}])", adlar.GetLength (0), adlar.GetLength (1), adlar.Length);
            for(i=0;i<adlar.GetLength(0);i++) {for(j=0;j<adlar.GetLength(1);j++) Console.Write (adlar [i,j] + "  "); Console.WriteLine();}

            Console.WriteLine ("\nTek, çift ve 3 boyutlu dizileri ilkdeðerleme, sunma ve derece/boyut:");
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
            ÜçboyutYaz (z);

            Console.WriteLine ("\nDizi ebatýný her çalýþtýrmada siz de girebilirsiniz:");
            string[] liste;
            Console.Write ("Dizi listesinde kaç kalem olsun? ");
            try {ts1 = Math.Abs (int.Parse (Console.ReadLine()));}catch {ts1=100;} if(ts1>500)ts1=500;
            liste = new string [ts1];
            for(i=0;i<liste.Length;i++) liste [i]=((char)i).ToString();
            for(i=0;i<liste.Length;i++) Console.Write (liste [i] + ", "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}