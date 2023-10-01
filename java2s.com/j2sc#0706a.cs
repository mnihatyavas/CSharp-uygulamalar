// j2sc#0706a.cs: Deðersel, referanssal, ref, params parametreleri örneði.

using System;
namespace Sýnýflar {
    class AsalSayý {  
        public bool asalMý (int x) {// Kendisi ve 1'den baþka sayýya bölünemeyen tamsayý asaldýr
            for (int i=2; i <= x/2; i++) if ((x % i) == 0) return false;
            return true;
        }
    }
    class BüyükSayý {public int büyük (int a, int b) {return a < b ? b : a;} }
    class Sýnýf1 {public int sayý = 2023;}
    class Renk {
        public string kýrmýzý;
        public string yeþil;
        public string mavi;
        public Renk() {this.kýrmýzý = "#F00"; yeþil = "#0F0"; mavi = "#00F";} //Ýlkdeðer atamalý parametresiz kurucu
        public void AlKYM (ref string kýrmýzý, ref string yeþil, ref string mavi) {kýrmýzý = this.kýrmýzý; yeþil = this.yeþil; mavi = this.mavi;}
    }
    class MetotParametresi1 {
        public static int Topla (int x, int y) {return x + y;}// Çift (deðersel) parametreli metot beyaný
        static void Metot1 (Sýnýf1 nesne, int ts) {
            nesne.sayý +=5;
            ts +=5;
        }
        static public void Metot2 (ref int ts) {ts*=2;} //return gerekmez
        static public void Metot3 (params int[] argümanlar) {for (int i = 0; i < argümanlar.Length; i++) Console.Write (argümanlar [i] + " "); Console.WriteLine();}
        static void Main() {
            Console.Write ("Deðer aktarýmlarýnda parametre deðer deðiþikliði argümaný etkilemezken, nesnel referans aktarýmlarýnda etkiler. Ayrýca 'out' ve 'ref' anahtarkelimeli aktarýmlarda ilkinde geriye, ikincindeyse geriye ve ileriye etki sözkonusudur. 'params' deðiþken adetli deðersel argümanlarý olanaklý kýlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Deðersel iki (int) sayýnýn toplamýný hesaplayan metot:");
            var r=new Random(); int ts1, ts2, ts3, i;
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); ts3 = Topla (ts1, ts2); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, ts3);
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, Topla (ts1, ts2));
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, Topla (ts1, ts2));

            Console.WriteLine ("\n50 rasgele sayýnýn asallýðýný tespit eden deðersel parametreli metot:");
            AsalSayý asal = new AsalSayý();
            for (i=1; i <= 50; i++) {
                ts1=r.Next (1, 10000000);
                if (asal.asalMý (ts1)) Console.Write ("{0}) {1:#,#} ASALDIR;  ", i, ts1);
                else Console.Write ("{0}) {1:#,#} deðildir;  ", i, ts1);
            }

            Console.WriteLine ("\n\n5 rasgele sayý çiftinin büyüðünü döndüren deðersel parametreli metot:");
            BüyükSayý büyük = new BüyükSayý();
            for (i=1; i <= 5; i++) {
                ts1=r.Next (-10000, 10000); ts1=r.Next (-10000, 10000);
                Console.WriteLine ("{0}) Büyük ({1:#,#},  {2:#,#}) = {3:#,#}", i, ts1, ts2, büyük.büyük (ts1, ts2) );
            }

            Console.WriteLine ("\nMetot nesnel parametre geriye etkisi ve sayýsal parametre geriye etkisizliði:");
            Sýnýf1 n1 = new Sýnýf1();
            ts1 = r.Next (1000, 10000);
            Console.WriteLine ("Ýlk -- n1.sayý: {0},\tts1: {1}", n1.sayý, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, sayý) sonrasý -- n1.sayý: {0},\tts1: {1}", n1.sayý, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, sayý) sonrasý -- n1.sayý: {0},\tts1: {1}", n1.sayý, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, sayý) sonrasý -- n1.sayý: {0},\tts1: {1}", n1.sayý, ts1);

            Console.WriteLine ("\nMetot ref'li argüman ve parametre deðiþikliðinin diðerini etkilemesi:");
            ts1 = ts2 = r.Next (1, 100);
            Metot2 (ref ts1); Console.WriteLine ("Önce (ts1 = {0}),\t ref metot sonrasý (ts1 = {1})", ts2, ts1);
            Metot2 (ref ts1); Console.WriteLine ("ref metot sonrasý (ts1 = {0})", ts1);
            MetotParametresi1.Metot2 (ref ts1); Console.WriteLine ("ref metot sonrasý (ts1 = {0})", ts1);
            Metot2 (ref ts1); Console.WriteLine ("ref metot sonrasý (ts1 = {0})", ts1);

            Console.WriteLine ("\nReturn'süz ref'le sýnýf alan deðerlerini alma:");
            string kýrmýzý="", yeþil="", mavi="";
            Renk R1 = new Renk(); R1.AlKYM (ref kýrmýzý, ref yeþil, ref mavi); Console.WriteLine ("Parlak (Kýrmýzý=\"{0}\", Yeþil=\"{1}\", Mavi=\"{2}\")", kýrmýzý, yeþil, mavi);
            R1.kýrmýzý = "#A55"; R1.yeþil = "#5A5"; R1.mavi = "#55A"; R1.AlKYM (ref kýrmýzý, ref yeþil, ref mavi); Console.WriteLine ("Koyu (Kýrmýzý=\"{0}\", Yeþil=\"{1}\", Mavi=\"{2}\")", kýrmýzý, yeþil, mavi);
            R1.kýrmýzý = "#511"; R1.yeþil = "#151"; R1.mavi = "#115"; R1.AlKYM (ref kýrmýzý, ref yeþil, ref mavi); Console.WriteLine ("Karanlýk (Kýrmýzý=\"{0}\", Yeþil=\"{1}\", Mavi=\"{2}\")", kýrmýzý, yeþil, mavi);
            Renk R2 = new Renk(); R2.AlKYM (ref kýrmýzý, ref yeþil, ref mavi); Console.WriteLine ("Parlak (Kýrmýzý=\"{0}\", Yeþil=\"{1}\", Mavi=\"{2}\")", kýrmýzý, yeþil, mavi);
            R1 = new Renk(); R1.AlKYM (ref kýrmýzý, ref yeþil, ref mavi); Console.WriteLine ("Parlak (Kýrmýzý=\"{0}\", Yeþil=\"{1}\", Mavi=\"{2}\")", kýrmýzý, yeþil, mavi);

            Console.WriteLine ("\n'params'la deðiþken sayýlý argümanlar tipli dizi olarak gönderilebilir:");
            Metot3 (1, 2, 3, 4, 5, 8, 15);
            ts1=r.Next (0, 1000); ts2=r.Next (0, 1000); ts3=r.Next (0, 1000); i=r.Next (0, 1000);
            MetotParametresi1.Metot3 (ts1, ts2, ts3, i);
            Metot3 (1, 2, 3, 4, 5, 8, 15, ts1, ts2, ts3, i);
            Metot3 (-1, 0, -353, 2023, ts3, ts1, i, ts2);
            Metot3(); Metot3 (20230911); Metot3 (2023, 09, 11);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}