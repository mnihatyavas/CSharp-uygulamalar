// j2sc#0721c.cs: Statik metot, özellik ve alan iliþkileri örneði.

using System;
namespace Sýnýflar {
    class SýnýfA {
       public static int N = 12;
       public static int NKüp() {return N*N*N;}
    }
    class SýnýfB {
    static int tiplemeliSayaç = 0;
        public SýnýfB() {tiplemeliSayaç++;}
        public static int SayacýOku() {return(tiplemeliSayaç);}
   }
   class SýnýfC {
        static int n=12;
        public static int N {set {n = value;} get {return(n*n*n);}}
    }
    class SýnýfD {
        static int kýrmýzý, yeþil, mavi;
        public SýnýfD (int r1, int r2, int r3) {kýrmýzý=r1; yeþil=r2; mavi=r3;} //Tipleme kuruculu deðer atama
        public static int Kýrmýzý {get {return(kýrmýzý);}}
        public static int Yeþil {get {return(yeþil);}}
        public static int Mavi {get {return(mavi);}}
    }
    class Statik3 {
        static void Main() {
            Console.Write ("Statik metotun this referansý olmaz, diðer statik ve kendi sýnýf tiplemeli veya statik-olmayan metodu doðrudan çaðýramaz, sadece statik veriye doðrudan eriþebilir,.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Statik metodun, statik veriye tiplemesiz doðrudan eriþimi:");
            Console.WriteLine ("SýnýfA.N'in (ilkdeðeri, küpü) = ({0}, {1})", SýnýfA.N, SýnýfA.NKüp());
            var r=new Random(); int ts1, ts2, ts3, i;
            for(i=0;i<5;i++) {ts1=r.Next(-100, 100); SýnýfA.N=ts1; Console.WriteLine ("(sayý, küpü) = ({0}, {1})", SýnýfA.N, SýnýfA.NKüp());}

            Console.WriteLine ("\nHer tiplemede kurucunun birartýrdýðý statik sayaç:");
            SýnýfB sb;
            for(i=-100;i<0;i++) {sb=new SýnýfB(); Console.Write ("{0} ", SýnýfB.SayacýOku());}

            Console.WriteLine ("\n\nStatik özellikle statik deðer koy, küpünü al:");
            Console.WriteLine ("SýnýfC.N'in ilkdeðer küpü = {0}", SýnýfC.N);
            for(i=0;i<5;i++) {ts1=r.Next(-100, 100); SýnýfC.N=ts1; Console.WriteLine ("(sayý, küpü) = ({0}, {1})", ts1, SýnýfC.N);}

            Console.WriteLine ("\nRasgele Renk(kýrmýzý,yeþil,mavi) deðerlikli karma renkler üretme:");
            SýnýfD sd;
            for(i=0;i<5;i++) {
                ts1=r.Next(0, 256); ts2=r.Next(0, 256); ts3=r.Next(0, 256);
                sd=new SýnýfD (ts1, ts2, ts3); Console.WriteLine ("Üretilen renk(k,y,m)=({0}, {1}, {2})", SýnýfD.Kýrmýzý, SýnýfD.Yeþil, SýnýfD.Mavi);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}