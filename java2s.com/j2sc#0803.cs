// j2sc#0803.cs: Parametrik kaynak tipin hedef tipe imal� ve aleni �evrimi �rne�i.

using System;
namespace A��r�Y�kleme {
    public class S�n�f1 {}
    public class S�n�f2 {}
    public class S�n�fTipi1 {
        public static implicit operator S�n�fTipi2 (S�n�fTipi1 st1) {
           Console.WriteLine ("Kaynak S�n�fTipi1, hedef S�n�fTipi2'ye imal� �evriliyor");
           return(new S�n�fTipi2());
        }
    }
    public class S�n�fTipi2 {}
    public class S�n�fTipi3 : S�n�f2{}
    struct Yap�Tipi {
        private int n;
        public int N {get {return(n);}}
        public Yap�Tipi (int n) {this.n = n;} //Kurucu
        public static implicit operator short (Yap�Tipi yt) {Console.WriteLine ("public static implicit operator short (Yap�Tipi yt)==>"); return short.MaxValue;} //Yap�Tipi, short MaxValue'a �evriliyor
        public static implicit operator string (Yap�Tipi yt) {Console.WriteLine ("public static implicit operator string (Yap�Tipi yt)==>"); return "'M.Nihat Yava�'";} //Yap�Tipi, string n'e �evriliyor
        public static explicit operator Yap�Tipi (short n) {Console.WriteLine ("public static explicit operator Yap�Tipi (short n)==>"); return new Yap�Tipi (n);} //short, Yap�Tipi'ne �evriliyor
    }
    class ��Boyut {
        int x, y, z;
        public override string ToString() {return (x + ", " + y + ", " + z);}
        public ��Boyut() {x = y = z = 0;} //Kurucu1
        public ��Boyut (int i, int j, int k) {x = i; y = j; z=k;}
        public static ��Boyut operator + (��Boyut �b1, ��Boyut �b2) {//A��r�y�kl� + i�lemci
            ��Boyut �b = new ��Boyut();
            �b.x = �b1.x + �b2.x;
            �b.y = �b1.y + �b2.y;
            �b.z = �b1.z + �b2.z;
            return �b;
        }
        public static explicit operator int (��Boyut �b) {return �b.x + �b.y + �b.z;} //Aleni a��r�y�kl� int i�lemci
        public static implicit operator long (��Boyut �b) {return �b.x + �b.y + �b.z;} //�mal� a��r�y�kl� long i�lemci
    }
    class Nokta {
        private double x, y, z;
        public override string ToString() {return (x + ", " + y + ", " + z);}
        public Nokta (double a, double b, double c) {x=a; y=b; z=c;}
        public static implicit operator double (Nokta nk) {return Math.Sqrt ((nk.x*nk.x)+(nk.y*nk.y)+(nk.z*nk.z));}
    }
    class S�n�fTipi {
        double bakiye;
        public S�n�fTipi (double b) {bakiye = b;} //Kurucu
        public static implicit operator double (S�n�fTipi st) {return st.bakiye;} //S�n�fTipi'nden double'a �evrim
        public static explicit operator string (S�n�fTipi st) {return st.bakiye + " TL";} //S�n�fTipi'nden string'e �evrim
    }
    public struct Kompleks {
        private double ger�el, sanal;
        public override string ToString() {return String.Format ("({0}, {1})", ger�el, sanal);}
        public Kompleks (double g, double s) {ger�el = g; sanal = s;} //Kurucu
        public double genlik {get {return Math.Sqrt (Math.Pow (ger�el, 2) + Math.Pow (sanal, 2));}}
        public static implicit operator Kompleks (double d) {return new Kompleks (d, d);} //double'dan Kompleks'e imal� �evrim
        public static explicit operator double (Kompleks k) {return k.genlik;} //Kompleks'den double'a aleni �evrim
    }
    class ��lemciA��r�Y�kleme3 {
        static void Main() {
            Console.Write ("S�n�f tiplemeli imal�/implicit ve aleni/explicit statik i�lemciyle parametrik kaynak-tip hedef-tipe �evrilebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�mal� i�lemci S�n�fTipi2, parametrik st1 �zerinden S�n�fTipi2'ye �evrildi:");
            S�n�f1 s1=new S�n�f1(); Console.WriteLine ("s1.GetType()={0},\tType s1==S�n�f1: {1}", s1.GetType(), typeof(S�n�f1)==s1.GetType());
            //S�n�f2 s2=(S�n�f2)s1; //Derleme hatas� (S�n�1 S�n�f2'ye �evrilemez
            S�n�fTipi3 st3=new S�n�fTipi3(); Console.WriteLine ("st3.GetType()={0},\tType st3==S�n�fTipi3: {1}", st3.GetType(), typeof(S�n�fTipi3)==st3.GetType());
            S�n�f2 s2=(S�n�f2)st3; Console.WriteLine ("s2.GetType()={0},\tType s2==S�n�f2: {1}", s2.GetType(), typeof(S�n�f2)==s2.GetType()); //Ebeveyn s2, st3 �zerinden S�n�f2'ye �evrilmedi
            S�n�fTipi1 st1 = new S�n�fTipi1(); Console.WriteLine ("st1.GetType()={0},\tType st1==S�n�fTipi1: {1}", st1.GetType(), typeof(S�n�fTipi1)==st1.GetType());
            S�n�fTipi2 st2 = (S�n�fTipi2)st1; Console.WriteLine ("st2.GetType()={0},\tType st2==S�n�fTipi2: {1}", st2.GetType(), typeof(S�n�fTipi2)==st2.GetType()); //S�n�f i�lemcisi st2, st1 �zerinden S�n�fTipi2'ye �evrildi

            Console.WriteLine ("\nYap�Tipi'nden short ve string'e, short'dan Yap�Tipi'ne �evrimler:");
            int ts1 = int.MaxValue; Yap�Tipi yt = new Yap�Tipi (ts1); Console.WriteLine ("Kuruculu Yap�Tipi: yt.N = {0}", yt.N);
            Console.WriteLine ("\tYap�Tipi'nden short'a: {0}", (short)yt);
            int i = yt; Console.WriteLine ("\t" + i); //Tan�ml� yt-->short
            long l = yt; Console.WriteLine ("\t" + l); //Tan�ml� yt-->short
            Console.WriteLine ("\tYap�Tipi'nden string'e: {0}", (string)yt);
            short s=short.MinValue; yt = (Yap�Tipi) s; Console.WriteLine ("\tshort'tan Yap�Tipi'ne: yt.N = {0}", yt.N);

            Console.WriteLine ("\nA��r�y�kl� + ve aleni int i�lemcilerle 3 boyutlu aritmetik:");
            var r=new Random(); int ts2, ts3, j;
            ��Boyut �b1; ��Boyut �b2; ��Boyut �b3=new ��Boyut();
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); �b1=new ��Boyut (ts1, ts2, ts3); 
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); �b2=new ��Boyut (ts1, ts2, ts3);
                �b3 = �b1 + �b2;
                Console.WriteLine ("{3}) �b1({0}) + �b2({1}) = �b3({2})", �b1, �b2, �b3, i+1);
                ts1=(int)�b1; ts2=(int)�b2; ts3=(int)�b3; //Aleni int'e �evrim
                Console.WriteLine ("\t((int)�b1, (int)�b1, (int)�b1) = ({0}, {1}, {2})", (int)�b1, (int)�b2, (int)�b3);
                j = ts1*(int)�b1 - ts2*(int)�b2 + ts3*(int)�b3;
                Console.WriteLine ("\tts1*(int)�b1-ts2*(int)�b2+ts3*(int)�b3: ({0}-{1}+{2}) = {3}", ts1*(int)�b1, ts2*(int)�b2, ts3*(int)�b3, j);
            }

            Console.WriteLine ("\nA��r�y�kl� + ve imal� int i�lemcilerle 3 boyutlu aritmetik:");
            long ls1, ls2, ls3, k;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); �b1=new ��Boyut (ts1, ts2, ts3);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); �b2=new ��Boyut (ts1, ts2, ts3);
                �b3 = �b1 + �b2;
                Console.WriteLine ("{3}) �b1({0}) + �b2({1}) = �b3({2})", �b1, �b2, �b3, i+1);
                ls1=�b3; ls2=�b1; ls3=�b2; //�mal� long'a �evrim
                Console.WriteLine ("\t(�b1, �b1, �b1) = ({0}, {1}, {2})", 1L*�b1, 1L*�b2, 1L*�b3);
                k = ls1*�b1 - ls2*�b2 + ls3*�b3;
                Console.WriteLine ("\tls1*�b1 - ls2*�b2 + ls3*�b3: ({0}, {1}, {2}) = {3}", ls1*�b1, ls2*�b2, ls3*�b3, k);
            }

            Console.WriteLine ("\n�mal� double i�lemciyle 3 boyutlu 2 nokta aras�ndaki mesafe:");
            double m1, m2, ds1, ds2, ds3;
            Nokta n1; Nokta n2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D; n1=new Nokta (ds1, ds2, ds3);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D; n2=new Nokta (ds1, ds2, ds3);
                m1 = n1; m2 = n2;
                Console.WriteLine ("{0}) n1=({1}),\tn2=({2})", i+1, n1, n2);
                Console.WriteLine ("\tMath.Abs (m1[{0:0.00}] - m2[{1:0.00}]) = {2:0.00}", m1, m2, Math.Abs (m1 - m2));
            }

            Console.WriteLine ("\nS�n�fTipi'ni imal� double'a ve aleni string'e �evrim:");
            string ss1;
            S�n�fTipi bky;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100000000)+r.Next(10,100)/100D; bky=new S�n�fTipi (ds1);
                ds1 = bky;
                ss1 = (string)bky;
                Console.WriteLine ("Bakiye double = {0:#,#0.00};\tstring = {1}", ds1, ss1);
            }

            Console.WriteLine ("\nDouble'dan Kompleks'e imal� ve Kompleks'ten double'a aleni �evrim:");
            Kompleks ks1; Kompleks ks2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks1=new Kompleks (ds1, ds2);
                Console.WriteLine ("{0}) Orijinal ks1 = {1}", i+1, ks1);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ks2=ds1; //�mal� (d-->k) �evrim
                ds2=(double)ks1; //Aleni (k-->d) �evrim
                Console.WriteLine ("\tks1-->dbl �evrim: {0:0.0000};\tdbl-->ks2 �evrim: {1}", ds2, ks2);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}