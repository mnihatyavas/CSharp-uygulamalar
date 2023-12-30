// j2sc#0802.cs: A��r�y�kl� k�yas, aritmetik, bool ve int i�lemcileri �rne�i.

using System;
namespace A��r�Y�kleme {
    public struct KompleksSay� : IComparable, IEquatable<KompleksSay�>, IComparable<KompleksSay�> {
        private double ger�el, sanal;
        public KompleksSay� (double g, double s) {ger�el = g; sanal = s;} //Kurucu
        public override bool Equals (object di�er ) {//Esge�en parametrik KompleksSay� kontrolu
            bool sonu� = false;
            if (di�er is KompleksSay�) {sonu� = Equals ((KompleksSay�)di�er);} //Alttaki esge�enle ger�el ve sanal e�itlik kontrolunu �a��r�r
            return sonu�;
        }
        public bool Equals (KompleksSay� �u) {return (this.ger�el == �u.ger�el && this.sanal == �u.sanal);}
        public override int GetHashCode() {return (int)this.Genlik;} //IEquatable
        int IComparable.CompareTo (object di�er) {//KompleksSay� kontrolu
            if (!(di�er is KompleksSay�)) {throw new ArgumentException ("K�t� K�yas");}
            return CompareTo ((KompleksSay�)di�er); //Alttakiyse bu/�u genlik kontrolu
        }
        public int CompareTo (KompleksSay� �u) {
            int sonu�;
            if (Equals (�u)) {sonu� = 0; //this==�u
            }else if (this.Genlik > �u.Genlik) {sonu� = 1; //this>�u
            }else {sonu� = -1;} //this<�u
            return sonu�;
        }
        public double Genlik {get {return Math.Sqrt (Math.Pow (this.ger�el, 2) + Math.Pow (this.sanal, 2));}} //�zellik (g**2 + s**2)**0.5
        public override string ToString() {return String.Format ("({0}, {1})", ger�el, sanal);}
        //K�yas (<, >, <=, >=, ==, !=) a��r�y�kleme i�lemcileri
        public static bool operator == (KompleksSay� soldaki, KompleksSay� sa�daki) {return soldaki.Equals (sa�daki);} //Equals ile �nce KompleksSay� tipi, sonra (bool) this/�u ger�el/sanal e�itlik kontrolu
        public static bool operator != (KompleksSay� soldaki, KompleksSay� sa�daki) {return !soldaki.Equals (sa�daki);}
        public static bool operator < (KompleksSay� soldaki, KompleksSay� sa�daki) {return soldaki.CompareTo (sa�daki) < 0;} //CompareTo ile...
        public static bool operator > (KompleksSay� soldaki, KompleksSay� sa�daki) {return soldaki.CompareTo (sa�daki) > 0;}
        public static bool operator <= (KompleksSay� soldaki, KompleksSay� sa�daki) {return soldaki.CompareTo (sa�daki) <= 0;}
        public static bool operator >= (KompleksSay� soldaki, KompleksSay� sa�daki) {return soldaki.CompareTo (sa�daki) >= 0;}
    }
    public struct Vekt�r : IComparable {
        private int x, y;
        public override string ToString() {return string.Format ("[{0},{1}]", this.x, this.y);}
        public Vekt�r (int x, int y) {this.x = x; this.y = y;} //Kurucu
        //A��r�y�kl� aritmetik (+, -, ++, --) ve k�yas (==, !=, <, >, <=, >=) i�lemciler
        public static Vekt�r operator + (Vekt�r v1, Vekt�r v2) {return new Vekt�r (v1.x + v2.x, v1.y + v2.y);}
        public static Vekt�r operator - (Vekt�r v1, Vekt�r v2) {return new Vekt�r (v1.x - v2.x, v1.y - v2.y);}
        public static bool operator == (Vekt�r v1, Vekt�r v2) {return v1.Equals (v2);} //A�a��daki esge�en bool Equals()'� �a��r�r
        public static bool operator != (Vekt�r v1, Vekt�r v2) {return !v1.Equals (v2);}
        public static bool operator < (Vekt�r v1, Vekt�r v2) {return (v1.CompareTo (v2) < 0);} //A�a��daki esge�en int CompareTo()'yu �a��r�r
        public static bool operator > (Vekt�r v1, Vekt�r v2) {return (v1.CompareTo (v2) > 0);} //CompareTo()'nun int 1/-1/0 gerid�n���yle bool k�yaslamal� true/false �retir
        public static bool operator <= (Vekt�r v1, Vekt�r v2) {return (v1.CompareTo (v2) <= 0);}
        public static bool operator >= (Vekt�r v1, Vekt�r v2) {return (v1.CompareTo (v2) >= 0);}
        public static Vekt�r operator ++ (Vekt�r v1) {return new Vekt�r (v1.x + 1, v1.y + 1);}
        public static Vekt�r operator -- (Vekt�r v1) {return new Vekt�r (v1.x - 1, v1.y - 1);}
        public override bool Equals (object ns) {
            if (ns is Vekt�r) {if (((Vekt�r)ns).x == this.x && ((Vekt�r)ns).y == this.y) return true;}
            return false;
        }
        public int CompareTo (object ns) {//Vekt�r tip ve b�y�k:1, k���k:-1, e�it:0 kontrolu
            if (ns is Vekt�r) {
                Vekt�r v = (Vekt�r)ns;
                if (this.x > v.x && this.y > v.y) return 1;
                if (this.x < v.x && this.y < v.y) return -1;
                else return 0;
            }else throw new ArgumentException ("K�t� Vekt�r tip");
        }
        public override int GetHashCode() {return this.ToString().GetHashCode();} //Equals i�in
        //A��r�y�kl� + ve - i�lemcileri yard�m�yla metotlu alternatifleri; * ve / ile �arp() ve B�l() de tan�mlanabilir
        public static Vekt�r Topla (Vekt�r v1, Vekt�r v2) {return v1 + v2;}
        public static Vekt�r ��kar (Vekt�r v1, Vekt�r v2) {return v1 - v2;}
    }
    public class Maa�: IComparable {
        string isim; double maa�;
        public override string ToString() {return(isim + " (" + maa� + ")");}
        public Maa� (string i, double m) {isim = i; maa� = m;} //Kurucu
        int IComparable.CompareTo (object nes) {
            if (this.maa� > ((Maa�)nes).maa�) return(1);
            if (this.maa� < ((Maa�)nes).maa�) return(-1);
            else return(0);
        }
        public static bool operator < (Maa� m1, Maa� m2) {return(((IComparable)m1).CompareTo (m2) < 0);}
        public static bool operator > (Maa� m1, Maa� m2) {return(((IComparable)m1).CompareTo (m2) > 0);}
        public static bool operator <= (Maa� m1, Maa� m2) {return(((IComparable)m1).CompareTo (m2) <= 0);}
        public static bool operator >= (Maa� m1, Maa� m2) {return(((IComparable)m1).CompareTo (m2) >= 0);}
    }
    public class TiplemeliSaya� {
        public int x=1881; bool b;
        public TiplemeliSaya� (bool b) {this.b = b;}
        public static bool operator true (TiplemeliSaya� ts) {return  (ts == null) ? false : ts.b;}
        public static bool operator false (TiplemeliSaya� ts) {return  (ts == null) ? true : !ts.b;}
        public static TiplemeliSaya� operator ++ (TiplemeliSaya� ts) {ts.x++; return ts;}
    }
    class �kiBoyut {
        int x, y;
        public �kiBoyut() {x = y = 0;} //1.kurucu
        public �kiBoyut (int i, int j) {x = i; y = j;} //2.kurucu
        public override string ToString() {return string.Format ("{0}, {1}", x, y);}
        public static �kiBoyut operator + (�kiBoyut ib1, �kiBoyut ib2) {//�kiBoyut + �kiBoyut
            �kiBoyut ib = new �kiBoyut();
            ib.x = ib1.x + ib2.x;
            ib.y = ib1.y + ib2.y;
            return ib;
        } 
        public static �kiBoyut operator + (int i1, �kiBoyut ib2) {//int + �kiBoyut
            �kiBoyut ib = new �kiBoyut();
            ib.x = ib2.x + i1;
            ib.y = ib2.y + i1;
            return ib;
        }
        public static �kiBoyut operator + (�kiBoyut ib1, int i2) {//�kiBoyut + int
            �kiBoyut ib = new �kiBoyut();
            ib.x = ib1.x + i2;
            ib.y = ib1.y + i2;
            return ib;
        }
        public static explicit operator int (�kiBoyut ib1) {return ib1.x * ib1.y;} //�kiBoyut (x * y)
    } 
    class ��lemciA��r�Y�kleme2 {
        static void Main() {
            Console.Write ("Equals (==, !=) ve CompareTo (==0, >1, <-1; <, >, <=, >=) ile esge�en KompleksSay� tipi ve k�yaslama kontrollu �zelle�tirilen a��r�y�klemeli k�yas i�lemcileri. A��r�y�kl� s�n�f-tipli i�lemciler: +, -, ++, --, *.\n bool true/false ve int i�lemciler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("2 komplekssay�n�n ==, !=, <, >, <=, >= k�yas sonu�lar�:");
            Random r=new Random(); double ds1, ds2; int ts1, ts2, i;
            KompleksSay� ks1; KompleksSay� ks2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks1=new KompleksSay� (ds1, ds2);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks2=new KompleksSay� (ds1, ds2);
                Console.WriteLine ("{4}) ks1{0} = |{1:0.00}|;\tks2{2} = |{3:0.00}|", ks1, ks1.Genlik, ks2, ks2.Genlik, i+1);
                Console.WriteLine ("\tks1 == ks2? {0};\tks1 != ks2? {1};\tks1 < ks2? {2}\n\tks1 > ks2? {3};\tks1 <= ks2? {4};\tks1 >= ks2? {5}", ks1 == ks2, ks1 != ks2, ks1 < ks2, ks1 > ks2, ks1 <= ks2, ks1 >= ks2 );
            }

            Console.WriteLine ("\nA��r�y�kl� vekt�rel +,-,++,--,==,!=,<,>,<=,>= i�lemci ve Topla,��kar:");
            Vekt�r v1; Vekt�r v2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); v1=new Vekt�r (ts1, ts2);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); v2=new Vekt�r (ts1, ts2);
                Console.WriteLine ("{0}) v1={1}; v2={2}; Topla(v1,v2)={3}; ��kar(v1,v2)={4}", i+1, v1, v2, Vekt�r.Topla(v1, v2), Vekt�r.��kar(v1, v2));
                Console.WriteLine ("\tv1 == v2? {0};\tv1 != v2? {1};\tv1 < v2? {2}\n\tv1 > v2? {3};\tv1 <= v2? {4};\tv1 >= v2? {5}", v1 == v2, v1 != v2, v1 < v2, v1 > v2, v1 <= v2, v1 >= v2 );
                Console.WriteLine ("\tv1+v2={0}; v1-v2={1}; v1+=v2:{2}; v2-=v1:{3}", v1 + v2, v1 - v2, v1 += v2, v2 -= v1);
                Console.WriteLine (" ++v1={0}; --v2={1}; v1++={2}/{3}; v2--={4}/{5}", ++v1, --v2, v1++, v1, v2--, v2);
            }

            Console.WriteLine ("\nMaa� k�yaslamal� <,>,<=,>= k�yas i�lemcileri:");
            string[] adlar=new string[]{"Hamza Candan", "Zeliha Candan", "Canan Candan", "Zafer N.Candan", "Belk�s Candan"};
            Maa� m1; Maa� m2;
            for(i=0;i<5;i++) {
                ds1=r.Next(7852,100000)+r.Next(10,100)/100D; ds2=r.Next(7852,100000)+r.Next(10,100)/100D;
                m1=new Maa� (adlar [i], ds1); m2=new Maa� ("M.Nihat Yava�", ds2);
                Console.WriteLine ("{0}) [{1}] < [{2}]? {3}", i+1, m1, m2, m1 < m2? "Evet" : "Hay�r");
                Console.WriteLine ("\t[{0}] >= [{1}]? {2}", m1, m2, m1 >= m2? "Do�ru" : "Yanl��");
            }

            Console.WriteLine ("\nTikel i�lemcilerden null kontrollu true/false ve ++:");
            TiplemeliSaya� ts;
            ts=null; if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            ts=new TiplemeliSaya� (true); if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            ts=new TiplemeliSaya� (false); if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            do {Console.Write (ts.x++ + " ");} while (ts.x <= 1938);

            Console.WriteLine ("\n\n+ i�lemciyle obj+obj, int+obj, obj+int, obj.x*obj.y toplam sonu�lar�:");
            �kiBoyut ib1; �kiBoyut ib2; �kiBoyut ib3;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ib1=new �kiBoyut (ts1, ts2);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ib2=new �kiBoyut (ts1, ts2);
                ib3=new �kiBoyut(); ib3=ib1 + ib2; ts1=r.Next(-100,100); ts2=r.Next(-100,100);
                Console.WriteLine ("{0}) ib1({1}) + ib2({2}) = ({3})", i+1, ib1, ib2, ib3);
                Console.WriteLine ("\tib1 + ts1({0}) = ({1});\tts2({2}) + ib2 = ({3})", ts1, ib1+ts1, ts2, ts2+ib2);
                Console.WriteLine ("\tib1({0}) + ib2({1}) - ib3({2}) + ts1({3}) - ts2({4})*1881={5}", (int)ib1, (int)ib2, (int)ib3, ts1, ts2, (int)ib1+(int)ib2-(int)ib3+ts1-ts2*1881);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}