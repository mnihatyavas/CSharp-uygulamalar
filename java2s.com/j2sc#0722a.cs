// j2sc#0722a.cs: Ebeveyn base, ayný adlý new alan/metot ve içiçe sýnýflar örneði.

using System;
namespace Sýnýflar {
    class TemelSýnýf {public int n1 = 0;}
    class TürediSýnýf : TemelSýnýf {
        public TürediSýnýf (int a, int b) {n1=a; base.n1=b;}
        new public int n1 = 0;
        public void Göster() {Console.WriteLine ("Temel.n1={0},\tTüredi.n1={1}", base.n1, n1);}
    }
    public class Temel {
        public int n1;
        public Temel() { n1=0; Console.WriteLine ("\tParametresiz Temel kurucusu: {0}", n1);}
        public Temel (int i) {Console.WriteLine ("\tTek parametreli Temel kurucusu: {0}", i); n1=i;}
    }
    public class Türedi : Temel {
        new public int n1;
        public Türedi() {n1=0; base.n1=0; Console.WriteLine ("Parametresiz Türedi kurucusu: ({0}, {1})", n1, base.n1);}
        public Türedi (int i1, int i2) : base (i1) {n1=i2; Console.WriteLine ("Çift parametreli Türedi kurucusu: ({0}, {1})", n1, base.n1);}
    }
    class Temel2 { 
        public int n = 0;
        public void göster() {Console.WriteLine ("\tTemel n = {0}", n);}
    }
    class Türedi2 : Temel2 {
        new int n; //Bu n, Temel n'i gizler
        public Türedi2 (int a, int b) {base.n = a; n = b;}
        new public void göster() {base.göster(); Console.WriteLine ("Türedi n = {0}", n);}
    }
    internal class Dýþ1 {
        internal class Dýþ2 {
            public static int sayaç;
            internal class Ýç {public void Birartýr() {sayaç++;}}
        }
    }
    class SýnýfA {
        class Sayacým {public int Say = 0;}
        private Sayacým sayaç;
        public SýnýfA() {sayaç = new Sayacým();} //Kurucu
        public int Birartýr() {return sayaç.Say++;}
        public int DeðeriAl() {return sayaç.Say;}
    }
    class Çeþitli1 {
        static void Main() {
            Console.Write ("'base' türedi sýnýfta temel kasdýyla kullanýlýr. Türedinin tiplenmesi öncelikle miraslanan temel kurucuyu otomatikmen çaðýrýr. Türedinin temelle ayný new adlý alaný temelinkini gizler, ancak base.alan onu ifþa eder. Temel'le ayný adlý türedi alan ve metot adlarý önünde new olmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Temel'in n1'ini Türedi'ninkinden ayýran 'base' anahtarkelimesi:");
            var r=new Random(); int ts1, ts2, i;
            TürediSýnýf t1;
            for(i=0;i<5;i++) {
                ts1=r.Next(); ts2=r.Next();
                t1=new TürediSýnýf (ts1, ts2);
                t1.Göster();
            }

            Console.WriteLine ("\nTek/çift parametreli kurucularla türedi/temel alanlara deðer atama:");
            Türedi trd1 = new Türedi();
            Türedi trd2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                trd2=new Türedi (ts1, ts2);
            }

            Console.WriteLine ("\nTemelin kurucusuz alan deðerinin base.metot()'la gösterilmesi:");
            Türedi2 tr2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                tr2=new Türedi2 (ts1, ts2);
                tr2.göster();
            }

            Console.WriteLine ("\nStatik sayacýn içiçe 3 sýnýflý tiplemeli metotla artýrýlmasý:");
            Dýþ1.Dýþ2.Ýç di=new Dýþ1.Dýþ2.Ýç();
            for(i=0;i<100;i++) {di.Birartýr(); Console.Write ("{0} ", Dýþ1.Dýþ2.sayaç);}

            Console.WriteLine ("\n\nAyný iþlemin statik olmayan içiçe 2 sýnýf alan ve metoduyla yapýlmasý:");
            SýnýfA sa = new SýnýfA();
            for(i=0;i<100;i++) {sa.Birartýr(); Console.Write ("{0} ", sa.DeðeriAl());}

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}