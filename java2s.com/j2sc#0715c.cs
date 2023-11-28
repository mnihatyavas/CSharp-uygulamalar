// j2sc#0715c.cs: System metotlarýnýn override ve temel'den alan alma örneði.

using System;
using System.Text;
namespace Sýnýflar {
    class Kiþi {
        public string isim, tcNo, gsm;
        public byte yaþ;
        public Kiþi (string i, string t, string g, byte y) {isim = i; tcNo = t; gsm = g; yaþ = y;}
        public override bool Equals (object n) {//this-->p1, temp-->p2
            Kiþi ara = (Kiþi)n;
            if (ara.isim == this.isim && ara.tcNo == this.tcNo && ara.gsm == this.gsm && ara.yaþ == this.yaþ) return true;
            else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("isim= {0}", this.isim);
            sb.AppendFormat(", tcNo= {0}", this.tcNo);
            sb.AppendFormat(", gsm= {0}", this.gsm);
            sb.AppendFormat(", yaþ= {0}", this.yaþ);
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
    public class TemelSýnýf {
        private int n; public int N {get{return n;}}
        public TemelSýnýf() {var r=new Random(); n = r.Next(0, 1000);}
        public virtual int Göster() {return 0;}
    }
    public class TürediSýnýf : TemelSýnýf {override public int Göster() {return base.N;}}
    class SanalMetot3 {
        static void Main() {
            Console.Write ("System'in Equals, GetHashCode ve ToString metotlarý override ile özelleþtirilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("2 nesne alan deðerlerinin tam eþitliði kontrolu:");
            Kiþi k1 = new Kiþi ("M.Nihat Yavaþ", "43879353471", "+90-551 555 76 86", 2023-1956);
            Kiþi k2 = new Kiþi ("M.Nihat Yavaþ", "43879353471", "+90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI deðerlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI deðerlere sahiptir: ", k1.ToString(), k2.ToString());
            k2 = new Kiþi ("M.Nedim Yavaþ", "43879353471", "+90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI deðerlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI deðerlere sahiptir: ", k1.ToString(), k2.ToString());
            k2 = new Kiþi ("M.Nihat Yavaþ", "43879353471", "90-551 555 76 86", 2023-1956);
            if (k1.Equals (k2) && k1.GetHashCode() == k2.GetHashCode()) Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYNI deðerlere sahiptir: ", k1.ToString(), k2.ToString());
            else Console.WriteLine ("k1[{0}]\nve k2[{1}]\n\tAYRI deðerlere sahiptir: ", k1.ToString(), k2.ToString());

            Console.WriteLine ("\n3 boyutun ilk 2'sinin virtual-override ile temel'den alýnmasý:");
            var r=new Random(); float fs1, fs2, fs3; int i;
            Nokta2B n2b; Nokta3B n3b;
            for(i=0;i<5;i++) {
                fs1=r.Next(-100, 100) + r.Next(10, 100)/100F; fs2=r.Next(-100, 100) + r.Next(10, 100)/100F; fs3=r.Next(-100, 100) + r.Next(10, 100)/100F;
                n2b = new Nokta2B(); n2b.X=fs1; n2b.Y=fs2;
                n3b = new Nokta3B();  n3b.X=++fs1; n3b.Y=++fs2;n3b.Z=fs3;
                n2b.Yaz(); n3b.Yaz();
            }

            Console.WriteLine ("\nTüredi alan deðerlerinin tamamen temel'den alýnmasý:");
            TürediSýnýf türs;
            for(i=1;i<=5;i++) {
                türs = new TürediSýnýf();
                Console.WriteLine (türs.Göster() * i);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}