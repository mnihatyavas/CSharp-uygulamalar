// j2sc#1101d.cs: �okboyutlu, �entikli, istisna, nesne, klon ve kopya diziler �rne�i.

using System;
using System.Collections.Generic; //IEnumerable i�in
namespace VeriYap�lar� {
    class S�n�f1 {public int n = 20231223;}
    class S�n�f2 {
        private static readonly string[] aylar = new string[] {"Ocak","�ubat","Mart","Nisan","May�s","Haziran","Temmuz","A�ustos","Eyl�l","Ekim","Kas�m","Aral�k"};
        public string[] Aylar {get {return (string[])aylar.Clone();}}
        public IEnumerable<string> AylarEnumerable {get {return Array.AsReadOnly<string>(aylar);}}
   }
    class VeriYap�s�1D {
        static void Main() {
            Console.Write ("[,]�okluDizi, [][]�entikliDizi, dizi endeks ta�ma istisnas�, nesnel dizinin karma tipli elemanlar�, asl�n� etkileyen referans ve etkilemeyen basit tipli klonlama ve kopyalama �e�itleri.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�ok boyutlu dizilerin derece ve eleman say�lar�:");
            int i, ts1, ts2, ts3, ts4, ts5; var r=new Random();
            ts1=r.Next(1,20); ts2=r.Next(1,20); ts3=r.Next(1,20); ts4=r.Next(1,20); ts5=r.Next(1,20);
            int[] tsay�1=new int [ts1]; Console.WriteLine ("tsay�1 [{0}] dizisinin derecesi = {1},\teleman say�s� = {2}", ts1, tsay�1.Rank, tsay�1.Length);
            int[,] tsay�2=new int [ts1,ts2]; Console.WriteLine ("tsay�2 [{0},{1}] dizisinin derecesi = {2},\teleman say�s� = {3}", ts1, ts2, tsay�2.Rank, tsay�2.Length);
            int[,,] tsay�3=new int [ts1,ts2,ts3]; Console.WriteLine ("tsay�3 [{0},{1},{2}] dizisinin derecesi = {3},\teleman say�s� = {4}", ts1, ts2, ts3, tsay�3.Rank, tsay�3.Length);
            int[,,,] tsay�4=new int [ts1,ts2,ts3,ts4]; Console.WriteLine ("tsay�4 [{0},{1},{2},{3}] dizisinin derecesi = {4},\teleman say�s� = {5}", ts1, ts2, ts3, ts4, tsay�4.Rank, tsay�4.Length);
            int[,,,,] tsay�5=new int [ts1,ts2,ts3,ts4,ts5]; Console.WriteLine ("tsay�5 [{0},{1},{2},{3},{4}] dizisinin derecesi = {5},\teleman say�s� = {6}", ts1, ts2, ts3, ts4, ts5, tsay�5.Rank, tsay�5.Length);

            Console.WriteLine ("\nDizi endeks ta�mas�yla IndexOutOfRangeException istisnas�:");
            try {
                for(i=0;i<=tsay�1.Length;i++) {
                    tsay�1 [i] = (int)Math.Pow (i, 3);
                    Console.WriteLine ("tsay�1 [{0}] = {1}", i, tsay�1 [i]);
                }
            }catch (Exception h) {
                Console.WriteLine ("�stisna hatas� olu�tu...");
                Console.WriteLine ("Tam hata mesaj� = [{0}]", h);
                Console.WriteLine ("Sadece mesaj = [{0}]", h.Message);
                Console.WriteLine ("Y���n takip = [{0}]", h.StackTrace);
            }

            Console.WriteLine ("\nAleni tiplemeli komple dizisel atamalar:");
            string[] nihat = new string[]{"M.Nihat", "Yava�", 20231222.ToString(), 1959+"", "Toroslar", "Mersin", "TR", "mny2023@gmail.com", (905515559298D).ToString()};
            object[] nesne = nihat;
            string[] mnihat = (string[]) nesne;
            Console.WriteLine (mnihat);
            foreach(string ��e in mnihat) Console.WriteLine (��e);

            Console.WriteLine ("\nKlon dizi de�i�ikli�i aynen s�n�f referans� kayna�� da etkiler:");
            S�n�f1[] kaynakDizi1 = new S�n�f1[5] {new S�n�f1(), new S�n�f1(), new S�n�f1(), new S�n�f1(), new S�n�f1()};
            Console.Write ("kaynakDizi1 [{0}] �LK de�erleri: ", kaynakDizi1.Length); foreach (S�n�f1 a in kaynakDizi1) Console.Write (a.n+" ");
            S�n�f1[] klonDizi1 = (S�n�f1[]) kaynakDizi1.Clone();
            for(i=0;i<klonDizi1.Length-1;i++) {ts1=r.Next(-1000,1000); klonDizi1 [i].n = ts1;}
            Console.Write ("\nklonDizi1 [{0}] de�erleri: ", klonDizi1.Length); foreach (S�n�f1 a in klonDizi1) Console.Write (a.n+" ");
            Console.Write ("\nkaynakDizi1 [{0}] SON de�erleri: ", kaynakDizi1.Length); foreach (S�n�f1 a in kaynakDizi1) Console.Write (a.n+" ");

            Console.WriteLine ("\n\nKopya dizi de�i�ikli�i aynen s�n�f referans� kayna�� da etkiler:");
            Console.Write ("kaynakDizi1 [{0}] �LK de�erleri: ", kaynakDizi1.Length); foreach (S�n�f1 a in kaynakDizi1) Console.Write (a.n+" ");
            S�n�f1[] kopyaDizi1 = (S�n�f1[]) kaynakDizi1;
            Array.Copy (kaynakDizi1, kopyaDizi1, kaynakDizi1.Length); //Asl�nda bir�nceki kopya i�in yeterli
            for(i=0;i<kopyaDizi1.Length;i++) {ts1=r.Next(-1000,1000); kopyaDizi1 [i].n = ts1;}
            Console.Write ("\nkopyaDizi1 [{0}] de�erleri: ", kopyaDizi1.Length); foreach (S�n�f1 a in kopyaDizi1) Console.Write (a.n+" ");
            Console.Write ("\nkaynakDizi1 [{0}] SON de�erleri: ", kaynakDizi1.Length); foreach (S�n�f1 a in kaynakDizi1) Console.Write (a.n+" ");

            Console.WriteLine ("\n\nKlon/kopya dizi de�i�ikli�i int kayna�� etkilemez:");
            int[] kaynakDizi2 = new int[5] {new S�n�f1().n, new S�n�f1().n, new S�n�f1().n, new S�n�f1().n, new S�n�f1().n};
            Console.Write ("kaynakDizi2 [{0}] �LK de�erleri: ", kaynakDizi2.Length); foreach (int a in kaynakDizi2) Console.Write (a+" ");
            int[] klonDizi2 = (int[]) kaynakDizi2.Clone();
            for(i=0;i<klonDizi2.Length;i++) {ts1=r.Next(-1000,1000); klonDizi2 [i] = ts1;}
            Console.Write ("\nklonDizi2 [{0}] de�erleri: ", klonDizi2.Length); foreach (int a in klonDizi2) Console.Write (a+" ");
            Console.Write ("\nkaynakDizi2 [{0}] SON de�erleri: ", kaynakDizi2.Length); foreach (int a in kaynakDizi2) Console.Write (a+" ");

            Console.WriteLine ("\n\nS�n�f2'den string'e klonlama de�i�ikli�i kayna�� etkilemez:");
            S�n�f2 aylar1 = new S�n�f2();
            Console.Write ("==>S�n�f2 aylar1 �LK de�erleri: "); foreach (string a in aylar1.Aylar) {Console.Write (a+" ");}
            string[] aylar2 = aylar1.Aylar;
            for(i=0;i<aylar2.Length;i++) aylar2 [i] = aylar2 [i].Substring (0,3);
            Console.Write ("\n==>string[] aylar2 de�erleri: "); foreach (string a in aylar2) {Console.Write (a+" ");}
            Console.Write ("\n==>S�n�f2 aylar1 SON de�erleri: "); foreach (string a in aylar1.Aylar) {Console.Write (a+" ");}

            Console.WriteLine ("\n\n�e�itli int[] Copy ve CopyTo sonu�lar�:");
            int[] kaynakDizi3 = new int[5];
            int[] hedefDizi3 = new int[10];
            for(i=0;i<kaynakDizi3.Length;i++) {kaynakDizi3 [i] = i;}
            for(i=0;i<hedefDizi3.Length;i++) {hedefDizi3 [i] = i+10;}
            Console.Write ("==>kaynakDizi3 [{0}]: ", kaynakDizi3.Length); for(i=0;i<kaynakDizi3.Length;i++) Console.Write (kaynakDizi3 [i]+" ");
            Console.Write ("\n==>hedefDizi3 [{0}]: ", hedefDizi3.Length); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");
            Array.Copy (kaynakDizi3, hedefDizi3, kaynakDizi3.Length);
            Console.Write ("\n==>Array.Copy (kaynakDizi3, hedefDizi3, kaynakDizi3.Length): "); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");
            Array.Copy (kaynakDizi3, 0, hedefDizi3, 2, kaynakDizi3.Length);
            Console.Write ("\n==>Array.Copy (kaynakDizi3, 0, hedefDizi3, 2, kaynakDizi3.Length): "); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");
            Array.Copy (kaynakDizi3, 2, hedefDizi3, 3, 2); 
            Console.Write ("\n==>Array.Copy (kaynakDizi3, 2, hedefDizi3, 3, 2): "); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");
            kaynakDizi3.CopyTo (hedefDizi3, 0);
            Console.Write ("\n==>kaynakDizi3.CopyTo (hedefDizi3, 0): "); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");
            kaynakDizi3.CopyTo (hedefDizi3, 3);
            Console.Write ("\n==>kaynakDizi3.CopyTo (hedefDizi3, 3): "); for(i=0;i<hedefDizi3.Length;i++) Console.Write (hedefDizi3 [i]+" ");

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}