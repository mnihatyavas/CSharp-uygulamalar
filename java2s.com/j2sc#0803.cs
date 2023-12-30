// j2sc#0803.cs: Parametrik kaynak tipin hedef tipe imalý ve aleni çevrimi örneði.

using System;
namespace AþýrýYükleme {
    public class Sýnýf1 {}
    public class Sýnýf2 {}
    public class SýnýfTipi1 {
        public static implicit operator SýnýfTipi2 (SýnýfTipi1 st1) {
           Console.WriteLine ("Kaynak SýnýfTipi1, hedef SýnýfTipi2'ye imalý çevriliyor");
           return(new SýnýfTipi2());
        }
    }
    public class SýnýfTipi2 {}
    public class SýnýfTipi3 : Sýnýf2{}
    struct YapýTipi {
        private int n;
        public int N {get {return(n);}}
        public YapýTipi (int n) {this.n = n;} //Kurucu
        public static implicit operator short (YapýTipi yt) {Console.WriteLine ("public static implicit operator short (YapýTipi yt)==>"); return short.MaxValue;} //YapýTipi, short MaxValue'a çevriliyor
        public static implicit operator string (YapýTipi yt) {Console.WriteLine ("public static implicit operator string (YapýTipi yt)==>"); return "'M.Nihat Yavaþ'";} //YapýTipi, string n'e çevriliyor
        public static explicit operator YapýTipi (short n) {Console.WriteLine ("public static explicit operator YapýTipi (short n)==>"); return new YapýTipi (n);} //short, YapýTipi'ne çevriliyor
    }
    class ÜçBoyut {
        int x, y, z;
        public override string ToString() {return (x + ", " + y + ", " + z);}
        public ÜçBoyut() {x = y = z = 0;} //Kurucu1
        public ÜçBoyut (int i, int j, int k) {x = i; y = j; z=k;}
        public static ÜçBoyut operator + (ÜçBoyut üb1, ÜçBoyut üb2) {//Aþýrýyüklü + iþlemci
            ÜçBoyut üb = new ÜçBoyut();
            üb.x = üb1.x + üb2.x;
            üb.y = üb1.y + üb2.y;
            üb.z = üb1.z + üb2.z;
            return üb;
        }
        public static explicit operator int (ÜçBoyut üb) {return üb.x + üb.y + üb.z;} //Aleni aþýrýyüklü int iþlemci
        public static implicit operator long (ÜçBoyut üb) {return üb.x + üb.y + üb.z;} //Ýmalý aþýrýyüklü long iþlemci
    }
    class Nokta {
        private double x, y, z;
        public override string ToString() {return (x + ", " + y + ", " + z);}
        public Nokta (double a, double b, double c) {x=a; y=b; z=c;}
        public static implicit operator double (Nokta nk) {return Math.Sqrt ((nk.x*nk.x)+(nk.y*nk.y)+(nk.z*nk.z));}
    }
    class SýnýfTipi {
        double bakiye;
        public SýnýfTipi (double b) {bakiye = b;} //Kurucu
        public static implicit operator double (SýnýfTipi st) {return st.bakiye;} //SýnýfTipi'nden double'a çevrim
        public static explicit operator string (SýnýfTipi st) {return st.bakiye + " TL";} //SýnýfTipi'nden string'e çevrim
    }
    public struct Kompleks {
        private double gerçel, sanal;
        public override string ToString() {return String.Format ("({0}, {1})", gerçel, sanal);}
        public Kompleks (double g, double s) {gerçel = g; sanal = s;} //Kurucu
        public double genlik {get {return Math.Sqrt (Math.Pow (gerçel, 2) + Math.Pow (sanal, 2));}}
        public static implicit operator Kompleks (double d) {return new Kompleks (d, d);} //double'dan Kompleks'e imalý çevrim
        public static explicit operator double (Kompleks k) {return k.genlik;} //Kompleks'den double'a aleni çevrim
    }
    class ÝþlemciAþýrýYükleme3 {
        static void Main() {
            Console.Write ("Sýnýf tiplemeli imalý/implicit ve aleni/explicit statik iþlemciyle parametrik kaynak-tip hedef-tipe çevrilebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýmalý iþlemci SýnýfTipi2, parametrik st1 üzerinden SýnýfTipi2'ye çevrildi:");
            Sýnýf1 s1=new Sýnýf1(); Console.WriteLine ("s1.GetType()={0},\tType s1==Sýnýf1: {1}", s1.GetType(), typeof(Sýnýf1)==s1.GetType());
            //Sýnýf2 s2=(Sýnýf2)s1; //Derleme hatasý (Sýný1 Sýnýf2'ye çevrilemez
            SýnýfTipi3 st3=new SýnýfTipi3(); Console.WriteLine ("st3.GetType()={0},\tType st3==SýnýfTipi3: {1}", st3.GetType(), typeof(SýnýfTipi3)==st3.GetType());
            Sýnýf2 s2=(Sýnýf2)st3; Console.WriteLine ("s2.GetType()={0},\tType s2==Sýnýf2: {1}", s2.GetType(), typeof(Sýnýf2)==s2.GetType()); //Ebeveyn s2, st3 üzerinden Sýnýf2'ye çevrilmedi
            SýnýfTipi1 st1 = new SýnýfTipi1(); Console.WriteLine ("st1.GetType()={0},\tType st1==SýnýfTipi1: {1}", st1.GetType(), typeof(SýnýfTipi1)==st1.GetType());
            SýnýfTipi2 st2 = (SýnýfTipi2)st1; Console.WriteLine ("st2.GetType()={0},\tType st2==SýnýfTipi2: {1}", st2.GetType(), typeof(SýnýfTipi2)==st2.GetType()); //Sýnýf iþlemcisi st2, st1 üzerinden SýnýfTipi2'ye çevrildi

            Console.WriteLine ("\nYapýTipi'nden short ve string'e, short'dan YapýTipi'ne çevrimler:");
            int ts1 = int.MaxValue; YapýTipi yt = new YapýTipi (ts1); Console.WriteLine ("Kuruculu YapýTipi: yt.N = {0}", yt.N);
            Console.WriteLine ("\tYapýTipi'nden short'a: {0}", (short)yt);
            int i = yt; Console.WriteLine ("\t" + i); //Tanýmlý yt-->short
            long l = yt; Console.WriteLine ("\t" + l); //Tanýmlý yt-->short
            Console.WriteLine ("\tYapýTipi'nden string'e: {0}", (string)yt);
            short s=short.MinValue; yt = (YapýTipi) s; Console.WriteLine ("\tshort'tan YapýTipi'ne: yt.N = {0}", yt.N);

            Console.WriteLine ("\nAþýrýyüklü + ve aleni int iþlemcilerle 3 boyutlu aritmetik:");
            var r=new Random(); int ts2, ts3, j;
            ÜçBoyut üb1; ÜçBoyut üb2; ÜçBoyut üb3=new ÜçBoyut();
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); üb1=new ÜçBoyut (ts1, ts2, ts3); 
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); üb2=new ÜçBoyut (ts1, ts2, ts3);
                üb3 = üb1 + üb2;
                Console.WriteLine ("{3}) üb1({0}) + üb2({1}) = üb3({2})", üb1, üb2, üb3, i+1);
                ts1=(int)üb1; ts2=(int)üb2; ts3=(int)üb3; //Aleni int'e çevrim
                Console.WriteLine ("\t((int)üb1, (int)üb1, (int)üb1) = ({0}, {1}, {2})", (int)üb1, (int)üb2, (int)üb3);
                j = ts1*(int)üb1 - ts2*(int)üb2 + ts3*(int)üb3;
                Console.WriteLine ("\tts1*(int)üb1-ts2*(int)üb2+ts3*(int)üb3: ({0}-{1}+{2}) = {3}", ts1*(int)üb1, ts2*(int)üb2, ts3*(int)üb3, j);
            }

            Console.WriteLine ("\nAþýrýyüklü + ve imalý int iþlemcilerle 3 boyutlu aritmetik:");
            long ls1, ls2, ls3, k;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); üb1=new ÜçBoyut (ts1, ts2, ts3);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); üb2=new ÜçBoyut (ts1, ts2, ts3);
                üb3 = üb1 + üb2;
                Console.WriteLine ("{3}) üb1({0}) + üb2({1}) = üb3({2})", üb1, üb2, üb3, i+1);
                ls1=üb3; ls2=üb1; ls3=üb2; //Ýmalý long'a çevrim
                Console.WriteLine ("\t(üb1, üb1, üb1) = ({0}, {1}, {2})", 1L*üb1, 1L*üb2, 1L*üb3);
                k = ls1*üb1 - ls2*üb2 + ls3*üb3;
                Console.WriteLine ("\tls1*üb1 - ls2*üb2 + ls3*üb3: ({0}, {1}, {2}) = {3}", ls1*üb1, ls2*üb2, ls3*üb3, k);
            }

            Console.WriteLine ("\nÝmalý double iþlemciyle 3 boyutlu 2 nokta arasýndaki mesafe:");
            double m1, m2, ds1, ds2, ds3;
            Nokta n1; Nokta n2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D; n1=new Nokta (ds1, ds2, ds3);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D; n2=new Nokta (ds1, ds2, ds3);
                m1 = n1; m2 = n2;
                Console.WriteLine ("{0}) n1=({1}),\tn2=({2})", i+1, n1, n2);
                Console.WriteLine ("\tMath.Abs (m1[{0:0.00}] - m2[{1:0.00}]) = {2:0.00}", m1, m2, Math.Abs (m1 - m2));
            }

            Console.WriteLine ("\nSýnýfTipi'ni imalý double'a ve aleni string'e çevrim:");
            string ss1;
            SýnýfTipi bky;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100000000)+r.Next(10,100)/100D; bky=new SýnýfTipi (ds1);
                ds1 = bky;
                ss1 = (string)bky;
                Console.WriteLine ("Bakiye double = {0:#,#0.00};\tstring = {1}", ds1, ss1);
            }

            Console.WriteLine ("\nDouble'dan Kompleks'e imalý ve Kompleks'ten double'a aleni çevrim:");
            Kompleks ks1; Kompleks ks2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks1=new Kompleks (ds1, ds2);
                Console.WriteLine ("{0}) Orijinal ks1 = {1}", i+1, ks1);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ks2=ds1; //Ýmalý (d-->k) çevrim
                ds2=(double)ks1; //Aleni (k-->d) çevrim
                Console.WriteLine ("\tks1-->dbl çevrim: {0:0.0000};\tdbl-->ks2 çevrim: {1}", ds2, ks2);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}