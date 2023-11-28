// j2sc#0748.cs: Esgeçen ToString() metotla sýnýf alan deðerlerini gösterme örneði.

using System;
namespace Sýnýflar {
    public class XYZ {
        int x, y, z;
        public XYZ (int a, int b, int c) {x=a; y=b; z=c;} //Kurucu
        override public string ToString() {return String.Format ("(x,y,z) = ({0}, {1}, {2})", x, y, z);}
    }
    class Sayaç {
        static int sayaç = 1881;
        int no;
        public Sayaç() {no = sayaç; sayaç++;} //sayaç artýrmalý kurucu 
        public override string ToString() {return no+" ";}
    }
    struct KYM {
        int kýrmýzý, yeþil, mavi;
        public KYM (int k, int y, int m) {kýrmýzý = k; yeþil = y; mavi = m;} //Kurucu
        public override String ToString() {return kýrmýzý.ToString ("X") + yeþil.ToString ("X") + mavi.ToString ("X");}
    }
    public class Isý {
        private decimal ýsý;
        public Isý (decimal ýsý) {this.ýsý = ýsý;}
        public override string ToString() {return ýsý.ToString ("N1") + " C (selsiyüs derece)";}
    }
    class Temel {
      int x = 19381110;
      public virtual void Yaz() {Console.WriteLine ("Temel int x = {0}", x);}
      public override String ToString() {return x.ToString();}
   }
   class Türev : Temel {
      double y = 20231114.143856975;
      public override void Yaz() {
         base.Yaz();
         Console.WriteLine ("Türev double y = {0}", y);
      }
      public override String ToString() {return base.ToString() + " ve " + y.ToString();}
   }
    class Çeþitli6 {
        static void Main() {
            Console.Write ("'override ToString()'in return'üne 'ToString()', 'String.Format()' veya 'StringBuilder.AppendFormat()'la sýnýf üyelerine dair detay bilgileri Console.WriteLine'a döndürebiliriz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Esgeçen ToString()'le XYZ alanlarýný görüntüleme:");
            var r=new Random(); int ts1, ts2, ts3, i;
            XYZ xyz;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100);
                xyz=new XYZ (ts1, ts2, ts3);
                Console.WriteLine (xyz);
            }

            Console.WriteLine ("\nStatik sayaç'ýn her tiplemedeki artýþýný ToString'le gösterme:");
            Sayaç say;
            for(i=1881;i<=1938;i++) {say = new Sayaç(); Console.Write (say);}

            Console.WriteLine ("\n\nRGB (0:255, 0:255, 0:255) = #XXX ikili 00:FF hex kod karþýlýklarý:");
            KYM kym;
            for(i=0;i<5;i++) {
                ts1=r.Next(0,256); ts2=r.Next(0,256); ts3=r.Next(0,257);
                kym = new KYM (ts1, ts2, ts3);
                Console.WriteLine ("RGB ({0}, {1}, {2}) = #{3}", ts1, ts2, ts3, kym);
            }

            Console.WriteLine ("\nC:Celsius santigrad derece yaz/kýþ hava sýcaklýk deðerleri:");
            Isý ý; decimal dc1;
            for(i=0;i<5;i++) {
                dc1=r.Next(-30,40)+r.Next(10,100)/100M;
                ý = new Isý (dc1);
                Console.WriteLine ("Erzurum-Antalya yaz/kýþ sýcaklýk: {0}", ý);
            }

            Console.WriteLine ("\nTürev:Temel esgeçen Yaz()/ToString() metotlarý:");
            Temel a = new Temel();
            Türev b = new Türev();
            Temel ab = new Türev();
            Console.WriteLine ("\tYaz() metotlarý:");
            a.Yaz(); b.Yaz(); ab.Yaz();
            Console.WriteLine ("\tToString() metotlarý:");
            Console.WriteLine ("Temel a: {0}\nTürev b: {1}\nTemel-Türev ab: {2}", a, b, ab);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}