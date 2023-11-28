// j2sc#0721c.cs: Statik metot, �zellik ve alan ili�kileri �rne�i.

using System;
namespace S�n�flar {
    class S�n�fA {
       public static int N = 12;
       public static int NK�p() {return N*N*N;}
    }
    class S�n�fB {
    static int tiplemeliSaya� = 0;
        public S�n�fB() {tiplemeliSaya�++;}
        public static int Sayac�Oku() {return(tiplemeliSaya�);}
   }
   class S�n�fC {
        static int n=12;
        public static int N {set {n = value;} get {return(n*n*n);}}
    }
    class S�n�fD {
        static int k�rm�z�, ye�il, mavi;
        public S�n�fD (int r1, int r2, int r3) {k�rm�z�=r1; ye�il=r2; mavi=r3;} //Tipleme kuruculu de�er atama
        public static int K�rm�z� {get {return(k�rm�z�);}}
        public static int Ye�il {get {return(ye�il);}}
        public static int Mavi {get {return(mavi);}}
    }
    class Statik3 {
        static void Main() {
            Console.Write ("Statik metotun this referans� olmaz, di�er statik ve kendi s�n�f tiplemeli veya statik-olmayan metodu do�rudan �a��ramaz, sadece statik veriye do�rudan eri�ebilir,.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Statik metodun, statik veriye tiplemesiz do�rudan eri�imi:");
            Console.WriteLine ("S�n�fA.N'in (ilkde�eri, k�p�) = ({0}, {1})", S�n�fA.N, S�n�fA.NK�p());
            var r=new Random(); int ts1, ts2, ts3, i;
            for(i=0;i<5;i++) {ts1=r.Next(-100, 100); S�n�fA.N=ts1; Console.WriteLine ("(say�, k�p�) = ({0}, {1})", S�n�fA.N, S�n�fA.NK�p());}

            Console.WriteLine ("\nHer tiplemede kurucunun birart�rd��� statik saya�:");
            S�n�fB sb;
            for(i=-100;i<0;i++) {sb=new S�n�fB(); Console.Write ("{0} ", S�n�fB.Sayac�Oku());}

            Console.WriteLine ("\n\nStatik �zellikle statik de�er koy, k�p�n� al:");
            Console.WriteLine ("S�n�fC.N'in ilkde�er k�p� = {0}", S�n�fC.N);
            for(i=0;i<5;i++) {ts1=r.Next(-100, 100); S�n�fC.N=ts1; Console.WriteLine ("(say�, k�p�) = ({0}, {1})", ts1, S�n�fC.N);}

            Console.WriteLine ("\nRasgele Renk(k�rm�z�,ye�il,mavi) de�erlikli karma renkler �retme:");
            S�n�fD sd;
            for(i=0;i<5;i++) {
                ts1=r.Next(0, 256); ts2=r.Next(0, 256); ts3=r.Next(0, 256);
                sd=new S�n�fD (ts1, ts2, ts3); Console.WriteLine ("�retilen renk(k,y,m)=({0}, {1}, {2})", S�n�fD.K�rm�z�, S�n�fD.Ye�il, S�n�fD.Mavi);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}