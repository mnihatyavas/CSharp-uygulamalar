// j2sc#1101d.cs: Çokboyutlu, çentikli, istisna, nesne, klon ve kopya diziler örneði.

using System;
using System.Collections.Generic; //IEnumerable için
namespace VeriYapýlarý {
    class Sýnýf1 {public int n = 20231223;}
    class Sýnýf2 {
        private static readonly string[] aylar = new string[] {"Ocak","Þubat","Mart","Nisan","Mayýs","Haziran","Temmuz","Aðustos","Eylül","Ekim","Kasým","Aralýk"};
        public string[] Aylar {get {return (string[])aylar.Clone();}}
        public IEnumerable<string> AylarEnumerable {get {return Array.AsReadOnly<string>(aylar);}}
   }
    class VeriYapýsý1D {
        static void Main() {
            Console.Write ("[,]çokluDizi, [][]çentikliDizi, dizi endeks taþma istisnasý, nesnel dizinin karma tipli elemanlarý, aslýný etkileyen referans ve etkilemeyen basit tipli klonlama ve kopyalama çeþitleri.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çok boyutlu dizilerin derece ve eleman sayýlarý:");
            int i, ts1, ts2, ts3, ts4, ts5; var r=new Random();
            ts1=r.Next(1,20); ts2=r.Next(1,20); ts3=r.Next(1,20); ts4=r.Next(1,20); ts5=r.Next(1,20);
            int[] tsayý1=new int [ts1]; Console.WriteLine ("tsayý1 [{0}] dizisinin derecesi = {1},\teleman sayýsý = {2}", ts1, tsayý1.Rank, tsayý1.Length);
            int[,] tsayý2=new int [ts1,ts2]; Console.WriteLine ("tsayý2 [{0},{1}] dizisinin derecesi = {2},\teleman sayýsý = {3}", ts1, ts2, tsayý2.Rank, tsayý2.Length);
            int[,,] tsayý3=new int [ts1,ts2,ts3]; Console.WriteLine ("tsayý3 [{0},{1},{2}] dizisinin derecesi = {3},\teleman sayýsý = {4}", ts1, ts2, ts3, tsayý3.Rank, tsayý3.Length);
            int[,,,] tsayý4=new int [ts1,ts2,ts3,ts4]; Console.WriteLine ("tsayý4 [{0},{1},{2},{3}] dizisinin derecesi = {4},\teleman sayýsý = {5}", ts1, ts2, ts3, ts4, tsayý4.Rank, tsayý4.Length);
            int[,,,,] tsayý5=new int [ts1,ts2,ts3,ts4,ts5]; Console.WriteLine ("tsayý5 [{0},{1},{2},{3},{4}] dizisinin derecesi = {5},\teleman sayýsý = {6}", ts1, ts2, ts3, ts4, ts5, tsayý5.Rank, tsayý5.Length);

            Console.WriteLine ("\nDizi endeks taþmasýyla IndexOutOfRangeException istisnasý:");
            try {
                for(i=0;i<=tsayý1.Length;i++) {
                    tsayý1 [i] = (int)Math.Pow (i, 3);
                    Console.WriteLine ("tsayý1 [{0}] = {1}", i, tsayý1 [i]);
                }
            }catch (Exception h) {
                Console.WriteLine ("Ýstisna hatasý oluþtu...");
                Console.WriteLine ("Tam hata mesajý = [{0}]", h);
                Console.WriteLine ("Sadece mesaj = [{0}]", h.Message);
                Console.WriteLine ("Yýðýn takip = [{0}]", h.StackTrace);
            }

            Console.WriteLine ("\nAleni tiplemeli komple dizisel atamalar:");
            string[] nihat = new string[]{"M.Nihat", "Yavaþ", 20231222.ToString(), 1959+"", "Toroslar", "Mersin", "TR", "mny2023@gmail.com", (905515559298D).ToString()};
            object[] nesne = nihat;
            string[] mnihat = (string[]) nesne;
            Console.WriteLine (mnihat);
            foreach(string öðe in mnihat) Console.WriteLine (öðe);

            Console.WriteLine ("\nKlon dizi deðiþikliði aynen sýnýf referansý kaynaðý da etkiler:");
            Sýnýf1[] kaynakDizi1 = new Sýnýf1[5] {new Sýnýf1(), new Sýnýf1(), new Sýnýf1(), new Sýnýf1(), new Sýnýf1()};
            Console.Write ("kaynakDizi1 [{0}] ÝLK deðerleri: ", kaynakDizi1.Length); foreach (Sýnýf1 a in kaynakDizi1) Console.Write (a.n+" ");
            Sýnýf1[] klonDizi1 = (Sýnýf1[]) kaynakDizi1.Clone();
            for(i=0;i<klonDizi1.Length-1;i++) {ts1=r.Next(-1000,1000); klonDizi1 [i].n = ts1;}
            Console.Write ("\nklonDizi1 [{0}] deðerleri: ", klonDizi1.Length); foreach (Sýnýf1 a in klonDizi1) Console.Write (a.n+" ");
            Console.Write ("\nkaynakDizi1 [{0}] SON deðerleri: ", kaynakDizi1.Length); foreach (Sýnýf1 a in kaynakDizi1) Console.Write (a.n+" ");

            Console.WriteLine ("\n\nKopya dizi deðiþikliði aynen sýnýf referansý kaynaðý da etkiler:");
            Console.Write ("kaynakDizi1 [{0}] ÝLK deðerleri: ", kaynakDizi1.Length); foreach (Sýnýf1 a in kaynakDizi1) Console.Write (a.n+" ");
            Sýnýf1[] kopyaDizi1 = (Sýnýf1[]) kaynakDizi1;
            Array.Copy (kaynakDizi1, kopyaDizi1, kaynakDizi1.Length); //Aslýnda birönceki kopya için yeterli
            for(i=0;i<kopyaDizi1.Length;i++) {ts1=r.Next(-1000,1000); kopyaDizi1 [i].n = ts1;}
            Console.Write ("\nkopyaDizi1 [{0}] deðerleri: ", kopyaDizi1.Length); foreach (Sýnýf1 a in kopyaDizi1) Console.Write (a.n+" ");
            Console.Write ("\nkaynakDizi1 [{0}] SON deðerleri: ", kaynakDizi1.Length); foreach (Sýnýf1 a in kaynakDizi1) Console.Write (a.n+" ");

            Console.WriteLine ("\n\nKlon/kopya dizi deðiþikliði int kaynaðý etkilemez:");
            int[] kaynakDizi2 = new int[5] {new Sýnýf1().n, new Sýnýf1().n, new Sýnýf1().n, new Sýnýf1().n, new Sýnýf1().n};
            Console.Write ("kaynakDizi2 [{0}] ÝLK deðerleri: ", kaynakDizi2.Length); foreach (int a in kaynakDizi2) Console.Write (a+" ");
            int[] klonDizi2 = (int[]) kaynakDizi2.Clone();
            for(i=0;i<klonDizi2.Length;i++) {ts1=r.Next(-1000,1000); klonDizi2 [i] = ts1;}
            Console.Write ("\nklonDizi2 [{0}] deðerleri: ", klonDizi2.Length); foreach (int a in klonDizi2) Console.Write (a+" ");
            Console.Write ("\nkaynakDizi2 [{0}] SON deðerleri: ", kaynakDizi2.Length); foreach (int a in kaynakDizi2) Console.Write (a+" ");

            Console.WriteLine ("\n\nSýnýf2'den string'e klonlama deðiþikliði kaynaðý etkilemez:");
            Sýnýf2 aylar1 = new Sýnýf2();
            Console.Write ("==>Sýnýf2 aylar1 ÝLK deðerleri: "); foreach (string a in aylar1.Aylar) {Console.Write (a+" ");}
            string[] aylar2 = aylar1.Aylar;
            for(i=0;i<aylar2.Length;i++) aylar2 [i] = aylar2 [i].Substring (0,3);
            Console.Write ("\n==>string[] aylar2 deðerleri: "); foreach (string a in aylar2) {Console.Write (a+" ");}
            Console.Write ("\n==>Sýnýf2 aylar1 SON deðerleri: "); foreach (string a in aylar1.Aylar) {Console.Write (a+" ");}

            Console.WriteLine ("\n\nÇeþitli int[] Copy ve CopyTo sonuçlarý:");
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

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}