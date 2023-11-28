// j2sc#0715c.cs: System metotlar�n�n override ve temel'den alan alma �rne�i.

using System;
using System.Text;
namespace S�n�flar {
    class Ki�i {
        public string isim, tcNo, gsm;
        public byte ya�;
        public Ki�i (string i, string t, string g, byte y) {isim = i; tcNo = t; gsm = g; ya� = y;}
        public override bool Equals (object n) {//this-->p1, temp-->p2
            Ki�i ara = (Ki�i)n;
            if (ara.isim == this.isim && ara.tcNo == this.tcNo && ara.gsm == this.gsm && ara.ya� == this.ya�) return true;
            else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("isim= {0}", this.isim);
            sb.AppendFormat(", tcNo= {0}", this.tcNo);
            sb.AppendFormat(", gsm= {0}", this.gsm);
            sb.AppendFormat(", ya�= {0}", this.ya�);
            return sb.ToString();
        }
        public override int GetHashCode() {return gsm.GetHashCode();}
    }
    class Nokta2B {
        public float X, Y;
        public virtual void Yaz() {Console.WriteLine ("(x, y) = ({0}, {1})", X, Y);}
    }
    class Nokta3B : Nokta2B {
        public float Z;
        public override void Yaz() {Console.WriteLine ("(x, y, z) = ({0}, {1}, {2})", X, Y, Z);}
    }
    public class TemelS�n�f {
        private int n; public int N {get{return n;}}
        public TemelS�n�f() {var r=new Random(); n = r.Next(0, 1000);}
        public virtual int G�ster() {return 0;}
    }
    public class T�rediS�n�f : TemelS�n�f {override public int G�ster() {return base.N;}}
    class SanalMetot3 {
        static void Main() {
            Console.Write ("System'in Equals, GetHashCode ve ToString metotlar� override ile �zelle�tirilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("2 nesne alan de�erlerinin tam e�itli�i kontrolu:");
            Ki�i k1 = new Ki�i ("M.Nihat Yava�", "43879353471", "+90-551 555 76 86", 2023-1956);
            Ki�i k2 = new Ki�i ("M.Nihat Yava�", "43879353471", "+90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI de�erlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI de�erlere sahiptir: ", k1.ToString(), k2.ToString());
            k2 = new Ki�i ("M.Nedim Yava�", "43879353471", "+90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI de�erlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI de�erlere sahiptir: ", k1.ToString(), k2.ToString());
            k2 = new Ki�i ("M.Nihat Yava�", "43879353471", "90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI de�erlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI de�erlere sahiptir: ", k1.ToString(), k2.ToString());

            Console.WriteLine ("\n3 boyutun ilk 2'sinin virtual-override ile temel'den al�nmas�:");
            var r=new Random(); float fs1, fs2, fs3; int i;
            Nokta2B n2b; Nokta3B n3b;
            for(i=0;i<5;i++) {
                fs1=r.Next(-100, 100) + r.Next(10, 100)/100F; fs2=r.Next(-100, 100) + r.Next(10, 100)/100F; fs3=r.Next(-100, 100) + r.Next(10, 100)/100F;
                n2b = new Nokta2B(); n2b.X=fs1; n2b.Y=fs2;
                n3b = new Nokta3B();  n3b.X=++fs1; n3b.Y=++fs2;n3b.Z=fs3;
                n2b.Yaz(); n3b.Yaz();
            }

            Console.WriteLine ("\nT�redi alan de�erlerinin tamamen temel'den al�nmas�:");
            T�rediS�n�f t�rs;
            for(i=1;i<=5;i++) {
                t�rs = new T�rediS�n�f();
                Console.WriteLine (t�rs.G�ster() * i);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}