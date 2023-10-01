// j2sc#0706a.cs: De�ersel, referanssal, ref, params parametreleri �rne�i.

using System;
namespace S�n�flar {
    class AsalSay� {  
        public bool asalM� (int x) {// Kendisi ve 1'den ba�ka say�ya b�l�nemeyen tamsay� asald�r
            for (int i=2; i <= x/2; i++) if ((x % i) == 0) return false;
            return true;
        }
    }
    class B�y�kSay� {public int b�y�k (int a, int b) {return a < b ? b : a;} }
    class S�n�f1 {public int say� = 2023;}
    class Renk {
        public string k�rm�z�;
        public string ye�il;
        public string mavi;
        public Renk() {this.k�rm�z� = "#F00"; ye�il = "#0F0"; mavi = "#00F";} //�lkde�er atamal� parametresiz kurucu
        public void AlKYM (ref string k�rm�z�, ref string ye�il, ref string mavi) {k�rm�z� = this.k�rm�z�; ye�il = this.ye�il; mavi = this.mavi;}
    }
    class MetotParametresi1 {
        public static int Topla (int x, int y) {return x + y;}// �ift (de�ersel) parametreli metot beyan�
        static void Metot1 (S�n�f1 nesne, int ts) {
            nesne.say� +=5;
            ts +=5;
        }
        static public void Metot2 (ref int ts) {ts*=2;} //return gerekmez
        static public void Metot3 (params int[] arg�manlar) {for (int i = 0; i < arg�manlar.Length; i++) Console.Write (arg�manlar [i] + " "); Console.WriteLine();}
        static void Main() {
            Console.Write ("De�er aktar�mlar�nda parametre de�er de�i�ikli�i arg�man� etkilemezken, nesnel referans aktar�mlar�nda etkiler. Ayr�ca 'out' ve 'ref' anahtarkelimeli aktar�mlarda ilkinde geriye, ikincindeyse geriye ve ileriye etki s�zkonusudur. 'params' de�i�ken adetli de�ersel arg�manlar� olanakl� k�lar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("De�ersel iki (int) say�n�n toplam�n� hesaplayan metot:");
            var r=new Random(); int ts1, ts2, ts3, i;
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); ts3 = Topla (ts1, ts2); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, ts3);
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, Topla (ts1, ts2));
            ts1 = r.Next (-1000, 1000); ts2 = r.Next (-1000, 1000); Console.WriteLine ("int x({0}) + int y({1}) = int ({2})", ts1, ts2, Topla (ts1, ts2));

            Console.WriteLine ("\n50 rasgele say�n�n asall���n� tespit eden de�ersel parametreli metot:");
            AsalSay� asal = new AsalSay�();
            for (i=1; i <= 50; i++) {
                ts1=r.Next (1, 10000000);
                if (asal.asalM� (ts1)) Console.Write ("{0}) {1:#,#} ASALDIR;  ", i, ts1);
                else Console.Write ("{0}) {1:#,#} de�ildir;  ", i, ts1);
            }

            Console.WriteLine ("\n\n5 rasgele say� �iftinin b�y���n� d�nd�ren de�ersel parametreli metot:");
            B�y�kSay� b�y�k = new B�y�kSay�();
            for (i=1; i <= 5; i++) {
                ts1=r.Next (-10000, 10000); ts1=r.Next (-10000, 10000);
                Console.WriteLine ("{0}) B�y�k ({1:#,#},  {2:#,#}) = {3:#,#}", i, ts1, ts2, b�y�k.b�y�k (ts1, ts2) );
            }

            Console.WriteLine ("\nMetot nesnel parametre geriye etkisi ve say�sal parametre geriye etkisizli�i:");
            S�n�f1 n1 = new S�n�f1();
            ts1 = r.Next (1000, 10000);
            Console.WriteLine ("�lk -- n1.say�: {0},\tts1: {1}", n1.say�, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, say�) sonras� -- n1.say�: {0},\tts1: {1}", n1.say�, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, say�) sonras� -- n1.say�: {0},\tts1: {1}", n1.say�, ts1);
            Metot1 (n1, ts1); Console.WriteLine ("Metot1 (nesne, say�) sonras� -- n1.say�: {0},\tts1: {1}", n1.say�, ts1);

            Console.WriteLine ("\nMetot ref'li arg�man ve parametre de�i�ikli�inin di�erini etkilemesi:");
            ts1 = ts2 = r.Next (1, 100);
            Metot2 (ref ts1); Console.WriteLine ("�nce (ts1 = {0}),\t ref metot sonras� (ts1 = {1})", ts2, ts1);
            Metot2 (ref ts1); Console.WriteLine ("ref metot sonras� (ts1 = {0})", ts1);
            MetotParametresi1.Metot2 (ref ts1); Console.WriteLine ("ref metot sonras� (ts1 = {0})", ts1);
            Metot2 (ref ts1); Console.WriteLine ("ref metot sonras� (ts1 = {0})", ts1);

            Console.WriteLine ("\nReturn's�z ref'le s�n�f alan de�erlerini alma:");
            string k�rm�z�="", ye�il="", mavi="";
            Renk R1 = new Renk(); R1.AlKYM (ref k�rm�z�, ref ye�il, ref mavi); Console.WriteLine ("Parlak (K�rm�z�=\"{0}\", Ye�il=\"{1}\", Mavi=\"{2}\")", k�rm�z�, ye�il, mavi);
            R1.k�rm�z� = "#A55"; R1.ye�il = "#5A5"; R1.mavi = "#55A"; R1.AlKYM (ref k�rm�z�, ref ye�il, ref mavi); Console.WriteLine ("Koyu (K�rm�z�=\"{0}\", Ye�il=\"{1}\", Mavi=\"{2}\")", k�rm�z�, ye�il, mavi);
            R1.k�rm�z� = "#511"; R1.ye�il = "#151"; R1.mavi = "#115"; R1.AlKYM (ref k�rm�z�, ref ye�il, ref mavi); Console.WriteLine ("Karanl�k (K�rm�z�=\"{0}\", Ye�il=\"{1}\", Mavi=\"{2}\")", k�rm�z�, ye�il, mavi);
            Renk R2 = new Renk(); R2.AlKYM (ref k�rm�z�, ref ye�il, ref mavi); Console.WriteLine ("Parlak (K�rm�z�=\"{0}\", Ye�il=\"{1}\", Mavi=\"{2}\")", k�rm�z�, ye�il, mavi);
            R1 = new Renk(); R1.AlKYM (ref k�rm�z�, ref ye�il, ref mavi); Console.WriteLine ("Parlak (K�rm�z�=\"{0}\", Ye�il=\"{1}\", Mavi=\"{2}\")", k�rm�z�, ye�il, mavi);

            Console.WriteLine ("\n'params'la de�i�ken say�l� arg�manlar tipli dizi olarak g�nderilebilir:");
            Metot3 (1, 2, 3, 4, 5, 8, 15);
            ts1=r.Next (0, 1000); ts2=r.Next (0, 1000); ts3=r.Next (0, 1000); i=r.Next (0, 1000);
            MetotParametresi1.Metot3 (ts1, ts2, ts3, i);
            Metot3 (1, 2, 3, 4, 5, 8, 15, ts1, ts2, ts3, i);
            Metot3 (-1, 0, -353, 2023, ts3, ts1, i, ts2);
            Metot3(); Metot3 (20230911); Metot3 (2023, 09, 11);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}