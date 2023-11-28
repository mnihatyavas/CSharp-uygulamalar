// j2sc#0748.cs: Esge�en ToString() metotla s�n�f alan de�erlerini g�sterme �rne�i.

using System;
namespace S�n�flar {
    public class XYZ {
        int x, y, z;
        public XYZ (int a, int b, int c) {x=a; y=b; z=c;} //Kurucu
        override public string ToString() {return String.Format ("(x,y,z) = ({0}, {1}, {2})", x, y, z);}
    }
    class Saya� {
        static int saya� = 1881;
        int no;
        public Saya�() {no = saya�; saya�++;} //saya� art�rmal� kurucu 
        public override string ToString() {return no+" ";}
    }
    struct KYM {
        int k�rm�z�, ye�il, mavi;
        public KYM (int k, int y, int m) {k�rm�z� = k; ye�il = y; mavi = m;} //Kurucu
        public override String ToString() {return k�rm�z�.ToString ("X") + ye�il.ToString ("X") + mavi.ToString ("X");}
    }
    public class Is� {
        private decimal �s�;
        public Is� (decimal �s�) {this.�s� = �s�;}
        public override string ToString() {return �s�.ToString ("N1") + " C (selsiy�s derece)";}
    }
    class Temel {
      int x = 19381110;
      public virtual void Yaz() {Console.WriteLine ("Temel int x = {0}", x);}
      public override String ToString() {return x.ToString();}
   }
   class T�rev : Temel {
      double y = 20231114.143856975;
      public override void Yaz() {
         base.Yaz();
         Console.WriteLine ("T�rev double y = {0}", y);
      }
      public override String ToString() {return base.ToString() + " ve " + y.ToString();}
   }
    class �e�itli6 {
        static void Main() {
            Console.Write ("'override ToString()'in return'�ne 'ToString()', 'String.Format()' veya 'StringBuilder.AppendFormat()'la s�n�f �yelerine dair detay bilgileri Console.WriteLine'a d�nd�rebiliriz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Esge�en ToString()'le XYZ alanlar�n� g�r�nt�leme:");
            var r=new Random(); int ts1, ts2, ts3, i;
            XYZ xyz;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100);
                xyz=new XYZ (ts1, ts2, ts3);
                Console.WriteLine (xyz);
            }

            Console.WriteLine ("\nStatik saya�'�n her tiplemedeki art���n� ToString'le g�sterme:");
            Saya� say;
            for(i=1881;i<=1938;i++) {say = new Saya�(); Console.Write (say);}

            Console.WriteLine ("\n\nRGB (0:255, 0:255, 0:255) = #XXX ikili 00:FF hex kod kar��l�klar�:");
            KYM kym;
            for(i=0;i<5;i++) {
                ts1=r.Next(0,256); ts2=r.Next(0,256); ts3=r.Next(0,257);
                kym = new KYM (ts1, ts2, ts3);
                Console.WriteLine ("RGB ({0}, {1}, {2}) = #{3}", ts1, ts2, ts3, kym);
            }

            Console.WriteLine ("\nC:Celsius santigrad derece yaz/k�� hava s�cakl�k de�erleri:");
            Is� �; decimal dc1;
            for(i=0;i<5;i++) {
                dc1=r.Next(-30,40)+r.Next(10,100)/100M;
                � = new Is� (dc1);
                Console.WriteLine ("Erzurum-Antalya yaz/k�� s�cakl�k: {0}", �);
            }

            Console.WriteLine ("\nT�rev:Temel esge�en Yaz()/ToString() metotlar�:");
            Temel a = new Temel();
            T�rev b = new T�rev();
            Temel ab = new T�rev();
            Console.WriteLine ("\tYaz() metotlar�:");
            a.Yaz(); b.Yaz(); ab.Yaz();
            Console.WriteLine ("\tToString() metotlar�:");
            Console.WriteLine ("Temel a: {0}\nT�rev b: {1}\nTemel-T�rev ab: {2}", a, b, ab);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}