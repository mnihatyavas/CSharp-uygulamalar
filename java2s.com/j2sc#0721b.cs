// j2sc#0721b.cs: Tiplemesiz sýnýf uzantýlý statik alanlar örneði.

using System;
namespace Sýnýflar {
    class SýnýfA {
        public static int tiplemeliSayaç = 0;
        public SýnýfA() {tiplemeliSayaç++;} //Sayaçlý kurucu
    }
    class SýnýfB {
        static int sayaç = 0; //private
        public SýnýfB() {sayaç++;} //Her tiplemede kurucu sayacý birartýrýr
        ~SýnýfB() {sayaç--;} //Her çöplemede yýkýcý sayacý birazaltýr
        public static int sayacýAl() {return sayaç;}
    }
    class SýnýfC {
        public int a; public static int b; //Ýlk yükleniþte sýfýrlanýrlar
        public SýnýfC() {a++;} //Tiplemeli kurucu
        static SýnýfC() {b++;} //Statik kurucu tek kere kullanýlýr ve b=1 kalýr
    }
    class SýnýfD {
        public int a; public static int b; //Ýlk yükleniþte sýfýrlanýrlar
        public SýnýfD() {a++; b++;} //Tiplemeli kurucu statik deðiþkeni her tiplemede birartýrýr
    }
    public class SýnýfE {
        public int a = ÝlkdeðerleA();
        public int b = ÝlkdeðerleB();
        public static int x = ÝlkdeðerleX();
        public static int y = ÝlkdeðerleY();
        private static int ÝlkdeðerleA() {Console.WriteLine ("SýnýfE.ÝlkdeðerleA()"); return 1881;}
        private static int ÝlkdeðerleB() {Console.WriteLine ("SýnýfE.ÝlkdeðerleB()"); return 1923;}
        private static int ÝlkdeðerleX() {Console.WriteLine ("SýnýfE.ÝlkdeðerleX()"); return 1938;}
        private static int ÝlkdeðerleY() {Console.WriteLine ("SýnýfE.ÝlkdeðerleY()"); return 2023;}
    }
    class Statik2 {
        public static string Ad {get; private set;}
        public static int Yaþ {get; private set;}
        private static int Sayaç {get; set;}
        private static readonly object sayaçKilidi = new object();
        static void Main (string[] arg) {
            Console.Write ("Global olan statik deðiþken ilkdeðerlenmemiþse 0/null/false'dýr. Sýnýfý farklý/çoklu tiplense de tiplenmesiz uzantýlý kullanýlmasý gerektiðinden deðiþen deðeri globaldýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Global statik deðiþken sadece sýnýfadý uzantýlý kullanýlabilir:");
            //SýnýfA tipleme1 = new SýnýfA(); SýnýfA tipleme2 = new SýnýfA(); SýnýfA tipleme3 = new SýnýfA(); //Statik deðiþkenini kullanmak için farklý adla çoklu tipleme gereksiz
            //Console.WriteLine ("tipleme1/2/3.tiplemeliSayaç = ({0}, {1}, {2})", tipleme1.tiplemeliSayaç, tipleme2.tiplemeliSayaç, tipleme3.tiplemeliSayaç); //Tiplemeli statik deðiþken derleme hatasý verir
            SýnýfA tipleme; //Her tipleme sayacý birartýrýr
            int i;
            for(i=0;i<100;i++) {tipleme=new SýnýfA(); Console.Write ("{0} ", SýnýfA.tiplemeliSayaç);}

            Console.WriteLine ("\n\nHer kurulumda birartan, her yýkýlýmda birazalan sayaç:");
            SýnýfB nes;
            for(i=0;i<100;i++) {nes=new SýnýfB(); Console.Write ("{0} ", SýnýfB.sayacýAl());}

            Console.WriteLine ("\n\nTiplemeli ve statik sayaçlarýn birlikte kullanýlmasý:");
            SýnýfC nes2; SýnýfD nes3;
            Console.WriteLine ("\tAyrý static ve public kurucularla:");
            for(i=0;i<5;i++) {nes2=new SýnýfC(); Console.WriteLine ("Tiplemeli sayaç nes2.a={0}\tStatik sayaç SýnýfC.b={1}", nes2.a, SýnýfC.b);}
            Console.WriteLine ("\tAyný public kurucuyla:");
            for(i=0;i<5;i++) {nes3=new SýnýfD(); Console.WriteLine ("Tiplemeli sayaç nes3.a={0}\tStatik sayaç SýnýfD.b={1}", nes3.a, SýnýfD.b);}

            Console.WriteLine ("\nÝçmetotla ilkdeðerli tipleme ve statik alanlarýn birlikte kullanýlmasý:");
            SýnýfE a = new SýnýfE();
            Console.WriteLine ("(a,b, x, y) = ({0}, {1}, {2}, {3})", a.a, a.b, SýnýfE.x, SýnýfE.y);

            Console.WriteLine ("\nStatik komut satýrlý giriþler ve sayaç:");
            try {Ad = arg [0]; Yaþ = int.Parse (arg [1]);
            Console.WriteLine ("Komut satýrlý Ad = {0},\tYaþ = {1}", Ad, Yaþ);}catch{}
            Sayaç=2023;
            for(i=0;i<5;i++) lock (sayaçKilidi) {Console.WriteLine ("Main statik sayaç = {0}", Sayaç++);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}