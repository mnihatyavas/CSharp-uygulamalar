// j2sc#0721b.cs: Tiplemesiz s�n�f uzant�l� statik alanlar �rne�i.

using System;
namespace S�n�flar {
    class S�n�fA {
        public static int tiplemeliSaya� = 0;
        public S�n�fA() {tiplemeliSaya�++;} //Saya�l� kurucu
    }
    class S�n�fB {
        static int saya� = 0; //private
        public S�n�fB() {saya�++;} //Her tiplemede kurucu sayac� birart�r�r
        ~S�n�fB() {saya�--;} //Her ��plemede y�k�c� sayac� birazalt�r
        public static int sayac�Al() {return saya�;}
    }
    class S�n�fC {
        public int a; public static int b; //�lk y�kleni�te s�f�rlan�rlar
        public S�n�fC() {a++;} //Tiplemeli kurucu
        static S�n�fC() {b++;} //Statik kurucu tek kere kullan�l�r ve b=1 kal�r
    }
    class S�n�fD {
        public int a; public static int b; //�lk y�kleni�te s�f�rlan�rlar
        public S�n�fD() {a++; b++;} //Tiplemeli kurucu statik de�i�keni her tiplemede birart�r�r
    }
    public class S�n�fE {
        public int a = �lkde�erleA();
        public int b = �lkde�erleB();
        public static int x = �lkde�erleX();
        public static int y = �lkde�erleY();
        private static int �lkde�erleA() {Console.WriteLine ("S�n�fE.�lkde�erleA()"); return 1881;}
        private static int �lkde�erleB() {Console.WriteLine ("S�n�fE.�lkde�erleB()"); return 1923;}
        private static int �lkde�erleX() {Console.WriteLine ("S�n�fE.�lkde�erleX()"); return 1938;}
        private static int �lkde�erleY() {Console.WriteLine ("S�n�fE.�lkde�erleY()"); return 2023;}
    }
    class Statik2 {
        public static string Ad {get; private set;}
        public static int Ya� {get; private set;}
        private static int Saya� {get; set;}
        private static readonly object saya�Kilidi = new object();
        static void Main (string[] arg) {
            Console.Write ("Global olan statik de�i�ken ilkde�erlenmemi�se 0/null/false'd�r. S�n�f� farkl�/�oklu tiplense de tiplenmesiz uzant�l� kullan�lmas� gerekti�inden de�i�en de�eri globald�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Global statik de�i�ken sadece s�n�fad� uzant�l� kullan�labilir:");
            //S�n�fA tipleme1 = new S�n�fA(); S�n�fA tipleme2 = new S�n�fA(); S�n�fA tipleme3 = new S�n�fA(); //Statik de�i�kenini kullanmak i�in farkl� adla �oklu tipleme gereksiz
            //Console.WriteLine ("tipleme1/2/3.tiplemeliSaya� = ({0}, {1}, {2})", tipleme1.tiplemeliSaya�, tipleme2.tiplemeliSaya�, tipleme3.tiplemeliSaya�); //Tiplemeli statik de�i�ken derleme hatas� verir
            S�n�fA tipleme; //Her tipleme sayac� birart�r�r
            int i;
            for(i=0;i<100;i++) {tipleme=new S�n�fA(); Console.Write ("{0} ", S�n�fA.tiplemeliSaya�);}

            Console.WriteLine ("\n\nHer kurulumda birartan, her y�k�l�mda birazalan saya�:");
            S�n�fB nes;
            for(i=0;i<100;i++) {nes=new S�n�fB(); Console.Write ("{0} ", S�n�fB.sayac�Al());}

            Console.WriteLine ("\n\nTiplemeli ve statik saya�lar�n birlikte kullan�lmas�:");
            S�n�fC nes2; S�n�fD nes3;
            Console.WriteLine ("\tAyr� static ve public kurucularla:");
            for(i=0;i<5;i++) {nes2=new S�n�fC(); Console.WriteLine ("Tiplemeli saya� nes2.a={0}\tStatik saya� S�n�fC.b={1}", nes2.a, S�n�fC.b);}
            Console.WriteLine ("\tAyn� public kurucuyla:");
            for(i=0;i<5;i++) {nes3=new S�n�fD(); Console.WriteLine ("Tiplemeli saya� nes3.a={0}\tStatik saya� S�n�fD.b={1}", nes3.a, S�n�fD.b);}

            Console.WriteLine ("\n��metotla ilkde�erli tipleme ve statik alanlar�n birlikte kullan�lmas�:");
            S�n�fE a = new S�n�fE();
            Console.WriteLine ("(a,b, x, y) = ({0}, {1}, {2}, {3})", a.a, a.b, S�n�fE.x, S�n�fE.y);

            Console.WriteLine ("\nStatik komut sat�rl� giri�ler ve saya�:");
            try {Ad = arg [0]; Ya� = int.Parse (arg [1]);
            Console.WriteLine ("Komut sat�rl� Ad = {0},\tYa� = {1}", Ad, Ya�);}catch{}
            Saya�=2023;
            for(i=0;i<5;i++) lock (saya�Kilidi) {Console.WriteLine ("Main statik saya� = {0}", Saya�++);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}