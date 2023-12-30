// j2sc#0802.cs: Aþýrýyüklü kýyas, aritmetik, bool ve int iþlemcileri örneði.

using System;
namespace AþýrýYükleme {
    public struct KompleksSayý : IComparable, IEquatable<KompleksSayý>, IComparable<KompleksSayý> {
        private double gerçel, sanal;
        public KompleksSayý (double g, double s) {gerçel = g; sanal = s;} //Kurucu
        public override bool Equals (object diðer ) {//Esgeçen parametrik KompleksSayý kontrolu
            bool sonuç = false;
            if (diðer is KompleksSayý) {sonuç = Equals ((KompleksSayý)diðer);} //Alttaki esgeçenle gerçel ve sanal eþitlik kontrolunu çaðýrýr
            return sonuç;
        }
        public bool Equals (KompleksSayý þu) {return (this.gerçel == þu.gerçel && this.sanal == þu.sanal);}
        public override int GetHashCode() {return (int)this.Genlik;} //IEquatable
        int IComparable.CompareTo (object diðer) {//KompleksSayý kontrolu
            if (!(diðer is KompleksSayý)) {throw new ArgumentException ("Kötü Kýyas");}
            return CompareTo ((KompleksSayý)diðer); //Alttakiyse bu/þu genlik kontrolu
        }
        public int CompareTo (KompleksSayý þu) {
            int sonuç;
            if (Equals (þu)) {sonuç = 0; //this==þu
            }else if (this.Genlik > þu.Genlik) {sonuç = 1; //this>þu
            }else {sonuç = -1;} //this<þu
            return sonuç;
        }
        public double Genlik {get {return Math.Sqrt (Math.Pow (this.gerçel, 2) + Math.Pow (this.sanal, 2));}} //Özellik (g**2 + s**2)**0.5
        public override string ToString() {return String.Format ("({0}, {1})", gerçel, sanal);}
        //Kýyas (<, >, <=, >=, ==, !=) aþýrýyükleme iþlemcileri
        public static bool operator == (KompleksSayý soldaki, KompleksSayý saðdaki) {return soldaki.Equals (saðdaki);} //Equals ile önce KompleksSayý tipi, sonra (bool) this/þu gerçel/sanal eþitlik kontrolu
        public static bool operator != (KompleksSayý soldaki, KompleksSayý saðdaki) {return !soldaki.Equals (saðdaki);}
        public static bool operator < (KompleksSayý soldaki, KompleksSayý saðdaki) {return soldaki.CompareTo (saðdaki) < 0;} //CompareTo ile...
        public static bool operator > (KompleksSayý soldaki, KompleksSayý saðdaki) {return soldaki.CompareTo (saðdaki) > 0;}
        public static bool operator <= (KompleksSayý soldaki, KompleksSayý saðdaki) {return soldaki.CompareTo (saðdaki) <= 0;}
        public static bool operator >= (KompleksSayý soldaki, KompleksSayý saðdaki) {return soldaki.CompareTo (saðdaki) >= 0;}
    }
    public struct Vektör : IComparable {
        private int x, y;
        public override string ToString() {return string.Format ("[{0},{1}]", this.x, this.y);}
        public Vektör (int x, int y) {this.x = x; this.y = y;} //Kurucu
        //Aþýrýyüklü aritmetik (+, -, ++, --) ve kýyas (==, !=, <, >, <=, >=) iþlemciler
        public static Vektör operator + (Vektör v1, Vektör v2) {return new Vektör (v1.x + v2.x, v1.y + v2.y);}
        public static Vektör operator - (Vektör v1, Vektör v2) {return new Vektör (v1.x - v2.x, v1.y - v2.y);}
        public static bool operator == (Vektör v1, Vektör v2) {return v1.Equals (v2);} //Aþaðýdaki esgeçen bool Equals()'ý çaðýrýr
        public static bool operator != (Vektör v1, Vektör v2) {return !v1.Equals (v2);}
        public static bool operator < (Vektör v1, Vektör v2) {return (v1.CompareTo (v2) < 0);} //Aþaðýdaki esgeçen int CompareTo()'yu çaðýrýr
        public static bool operator > (Vektör v1, Vektör v2) {return (v1.CompareTo (v2) > 0);} //CompareTo()'nun int 1/-1/0 geridönüþüyle bool kýyaslamalý true/false üretir
        public static bool operator <= (Vektör v1, Vektör v2) {return (v1.CompareTo (v2) <= 0);}
        public static bool operator >= (Vektör v1, Vektör v2) {return (v1.CompareTo (v2) >= 0);}
        public static Vektör operator ++ (Vektör v1) {return new Vektör (v1.x + 1, v1.y + 1);}
        public static Vektör operator -- (Vektör v1) {return new Vektör (v1.x - 1, v1.y - 1);}
        public override bool Equals (object ns) {
            if (ns is Vektör) {if (((Vektör)ns).x == this.x && ((Vektör)ns).y == this.y) return true;}
            return false;
        }
        public int CompareTo (object ns) {//Vektör tip ve büyük:1, küçük:-1, eþit:0 kontrolu
            if (ns is Vektör) {
                Vektör v = (Vektör)ns;
                if (this.x > v.x && this.y > v.y) return 1;
                if (this.x < v.x && this.y < v.y) return -1;
                else return 0;
            }else throw new ArgumentException ("Kötü Vektör tip");
        }
        public override int GetHashCode() {return this.ToString().GetHashCode();} //Equals için
        //Aþýrýyüklü + ve - iþlemcileri yardýmýyla metotlu alternatifleri; * ve / ile Çarp() ve Böl() de tanýmlanabilir
        public static Vektör Topla (Vektör v1, Vektör v2) {return v1 + v2;}
        public static Vektör Çýkar (Vektör v1, Vektör v2) {return v1 - v2;}
    }
    public class Maaþ: IComparable {
        string isim; double maaþ;
        public override string ToString() {return(isim + " (" + maaþ + ")");}
        public Maaþ (string i, double m) {isim = i; maaþ = m;} //Kurucu
        int IComparable.CompareTo (object nes) {
            if (this.maaþ > ((Maaþ)nes).maaþ) return(1);
            if (this.maaþ < ((Maaþ)nes).maaþ) return(-1);
            else return(0);
        }
        public static bool operator < (Maaþ m1, Maaþ m2) {return(((IComparable)m1).CompareTo (m2) < 0);}
        public static bool operator > (Maaþ m1, Maaþ m2) {return(((IComparable)m1).CompareTo (m2) > 0);}
        public static bool operator <= (Maaþ m1, Maaþ m2) {return(((IComparable)m1).CompareTo (m2) <= 0);}
        public static bool operator >= (Maaþ m1, Maaþ m2) {return(((IComparable)m1).CompareTo (m2) >= 0);}
    }
    public class TiplemeliSayaç {
        public int x=1881; bool b;
        public TiplemeliSayaç (bool b) {this.b = b;}
        public static bool operator true (TiplemeliSayaç ts) {return  (ts == null) ? false : ts.b;}
        public static bool operator false (TiplemeliSayaç ts) {return  (ts == null) ? true : !ts.b;}
        public static TiplemeliSayaç operator ++ (TiplemeliSayaç ts) {ts.x++; return ts;}
    }
    class ÝkiBoyut {
        int x, y;
        public ÝkiBoyut() {x = y = 0;} //1.kurucu
        public ÝkiBoyut (int i, int j) {x = i; y = j;} //2.kurucu
        public override string ToString() {return string.Format ("{0}, {1}", x, y);}
        public static ÝkiBoyut operator + (ÝkiBoyut ib1, ÝkiBoyut ib2) {//ÝkiBoyut + ÝkiBoyut
            ÝkiBoyut ib = new ÝkiBoyut();
            ib.x = ib1.x + ib2.x;
            ib.y = ib1.y + ib2.y;
            return ib;
        } 
        public static ÝkiBoyut operator + (int i1, ÝkiBoyut ib2) {//int + ÝkiBoyut
            ÝkiBoyut ib = new ÝkiBoyut();
            ib.x = ib2.x + i1;
            ib.y = ib2.y + i1;
            return ib;
        }
        public static ÝkiBoyut operator + (ÝkiBoyut ib1, int i2) {//ÝkiBoyut + int
            ÝkiBoyut ib = new ÝkiBoyut();
            ib.x = ib1.x + i2;
            ib.y = ib1.y + i2;
            return ib;
        }
        public static explicit operator int (ÝkiBoyut ib1) {return ib1.x * ib1.y;} //ÝkiBoyut (x * y)
    } 
    class ÝþlemciAþýrýYükleme2 {
        static void Main() {
            Console.Write ("Equals (==, !=) ve CompareTo (==0, >1, <-1; <, >, <=, >=) ile esgeçen KompleksSayý tipi ve kýyaslama kontrollu özelleþtirilen aþýrýyüklemeli kýyas iþlemcileri. Aþýrýyüklü sýnýf-tipli iþlemciler: +, -, ++, --, *.\n bool true/false ve int iþlemciler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("2 komplekssayýnýn ==, !=, <, >, <=, >= kýyas sonuçlarý:");
            Random r=new Random(); double ds1, ds2; int ts1, ts2, i;
            KompleksSayý ks1; KompleksSayý ks2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks1=new KompleksSayý (ds1, ds2);
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ks2=new KompleksSayý (ds1, ds2);
                Console.WriteLine ("{4}) ks1{0} = |{1:0.00}|;\tks2{2} = |{3:0.00}|", ks1, ks1.Genlik, ks2, ks2.Genlik, i+1);
                Console.WriteLine ("\tks1 == ks2? {0};\tks1 != ks2? {1};\tks1 < ks2? {2}\n\tks1 > ks2? {3};\tks1 <= ks2? {4};\tks1 >= ks2? {5}", ks1 == ks2, ks1 != ks2, ks1 < ks2, ks1 > ks2, ks1 <= ks2, ks1 >= ks2 );
            }

            Console.WriteLine ("\nAþýrýyüklü vektörel +,-,++,--,==,!=,<,>,<=,>= iþlemci ve Topla,Çýkar:");
            Vektör v1; Vektör v2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); v1=new Vektör (ts1, ts2);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); v2=new Vektör (ts1, ts2);
                Console.WriteLine ("{0}) v1={1}; v2={2}; Topla(v1,v2)={3}; Çýkar(v1,v2)={4}", i+1, v1, v2, Vektör.Topla(v1, v2), Vektör.Çýkar(v1, v2));
                Console.WriteLine ("\tv1 == v2? {0};\tv1 != v2? {1};\tv1 < v2? {2}\n\tv1 > v2? {3};\tv1 <= v2? {4};\tv1 >= v2? {5}", v1 == v2, v1 != v2, v1 < v2, v1 > v2, v1 <= v2, v1 >= v2 );
                Console.WriteLine ("\tv1+v2={0}; v1-v2={1}; v1+=v2:{2}; v2-=v1:{3}", v1 + v2, v1 - v2, v1 += v2, v2 -= v1);
                Console.WriteLine (" ++v1={0}; --v2={1}; v1++={2}/{3}; v2--={4}/{5}", ++v1, --v2, v1++, v1, v2--, v2);
            }

            Console.WriteLine ("\nMaaþ kýyaslamalý <,>,<=,>= kýyas iþlemcileri:");
            string[] adlar=new string[]{"Hamza Candan", "Zeliha Candan", "Canan Candan", "Zafer N.Candan", "Belkýs Candan"};
            Maaþ m1; Maaþ m2;
            for(i=0;i<5;i++) {
                ds1=r.Next(7852,100000)+r.Next(10,100)/100D; ds2=r.Next(7852,100000)+r.Next(10,100)/100D;
                m1=new Maaþ (adlar [i], ds1); m2=new Maaþ ("M.Nihat Yavaþ", ds2);
                Console.WriteLine ("{0}) [{1}] < [{2}]? {3}", i+1, m1, m2, m1 < m2? "Evet" : "Hayýr");
                Console.WriteLine ("\t[{0}] >= [{1}]? {2}", m1, m2, m1 >= m2? "Doðru" : "Yanlýþ");
            }

            Console.WriteLine ("\nTikel iþlemcilerden null kontrollu true/false ve ++:");
            TiplemeliSayaç ts;
            ts=null; if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            ts=new TiplemeliSayaç (true); if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            ts=new TiplemeliSayaç (false); if (ts) Console.WriteLine ("true"); else Console.WriteLine ("false");
            do {Console.Write (ts.x++ + " ");} while (ts.x <= 1938);

            Console.WriteLine ("\n\n+ iþlemciyle obj+obj, int+obj, obj+int, obj.x*obj.y toplam sonuçlarý:");
            ÝkiBoyut ib1; ÝkiBoyut ib2; ÝkiBoyut ib3;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ib1=new ÝkiBoyut (ts1, ts2);
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ib2=new ÝkiBoyut (ts1, ts2);
                ib3=new ÝkiBoyut(); ib3=ib1 + ib2; ts1=r.Next(-100,100); ts2=r.Next(-100,100);
                Console.WriteLine ("{0}) ib1({1}) + ib2({2}) = ({3})", i+1, ib1, ib2, ib3);
                Console.WriteLine ("\tib1 + ts1({0}) = ({1});\tts2({2}) + ib2 = ({3})", ts1, ib1+ts1, ts2, ts2+ib2);
                Console.WriteLine ("\tib1({0}) + ib2({1}) - ib3({2}) + ts1({3}) - ts2({4})*1881={5}", (int)ib1, (int)ib2, (int)ib3, ts1, ts2, (int)ib1+(int)ib2-(int)ib3+ts1-ts2*1881);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}