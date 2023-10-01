// j2sc#0712.cs: Yaratýlan nesne sonlanýrken otomatik çaðrýlan yýkýcý örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        int i;
        public Sýnýf1 (int i) {this.i=i; Console.WriteLine ("{0}.nci Nesne yaratýlýyor...", this.i);} //Kurucu
        ~Sýnýf1() {Console.WriteLine ("{0}.nci Nesne imha ediliyor...", this.i);} //Yýkýcý
    }
    class Sýnýf2 {
        int x;
        public Sýnýf2 (int i) {x = i;} //Kurucu
        ~Sýnýf2() {Console.WriteLine ("Ýmha no: " + x);} //Yýkýcý
    }
    public class Sýnýf3 : IDisposable {//Interface arayüz temelli
        int a;
        public Sýnýf3 (int i) {a = i;} //Kurucu
        ~Sýnýf3() {Console.WriteLine ("{0}.Ýmhacýda...", a);} //Oyomatik yýkýcý
        public void Dispose() {//Ýstemli (hazýr) yýkýcý
            Console.WriteLine ("{0}.Dispose()...", a);
            GC.SuppressFinalize (this);
        }
    }
    public class TemelSýnýf {
        public int x;
        //public TemelSýnýf (int x) {this.x = x;}
        ~TemelSýnýf() {Console.WriteLine ("TemelSýnýf yýkýcýsý: {0}", x);}
    }
    public class TürediSýnýf : TemelSýnýf {
        public TürediSýnýf (int x) {base.x = x;}
        ~TürediSýnýf() {Console.WriteLine ("TürediSýnýf yýkýcýsý: {0}", base.x);}
    }
    public class Sýnýf4 {
        private static int no = 0;
        public Sýnýf4() {Console.WriteLine ("Yaratýlan Sýnýf4 nesne no: {0}", ++no);}
        ~Sýnýf4() {Console.WriteLine ("Ýmha edilen Sýnýf4 nesne no: {0}", no--);}
        public static int Sýnýf4NesneNo() {return no;}
    }
    class Yýkýcý {
        static void Main() {
            Console.Write ("Yýkýcý bir nesnenin çöp toplayýcý tarafýndan imhasý eþiðinde otomatikmen çaðrýlýr. IDisposable.Dispose()'la istemli imhalanan nesne-ler artýk otomatik yýkýcýyla da imha edilmez-ler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayný sýnýftan 5 nesne yaratýlarak programýn sonlandýrýlmasý:");
            Sýnýf1 s1; int i;
            for (i=1;i<=5;i++) s1=new Sýnýf1 (i);
            Console.WriteLine ("Program sonlandýrýlýyor...");

            Console.WriteLine ("\nKurulan ve sonuçta yýkýlacak nesneler:");
            Sýnýf2 s2a = new Sýnýf2 (0);
            for(i=1;i<=5;i++) {Sýnýf2 s2b = new Sýnýf2 (i);} //Burda {} blok þart
            Console.WriteLine ("Tamamlandý");

            Console.WriteLine ("\nÝstemli ve otomatik yýkýcýlarla nesne imhasý:");  
            Sýnýf3 s3a, s3b, s3c, s3d;
            s3a = new Sýnýf3(1); s3b = new Sýnýf3(2); s3c = new Sýnýf3(3); s3d = new Sýnýf3(4);
            Console.WriteLine ("***** s3a ve s3c çöpe atýlýyor *****"); s3a.Dispose(); s3c.Dispose();

            Console.WriteLine ("\nMiraslayan nesne yýkýlýrken ebeveyn yýkýcýyý da çaðýrýr:");
            TürediSýnýf t1;
            for (i=1;i<=5;i++) t1=new TürediSýnýf (i);
            Console.WriteLine ("5 adet miraslý nesne yaratýldý");

            Console.WriteLine ("\nYaratýlan ve yýkýlan nesnenin statik no'su:");
            Console.WriteLine ("Sýnýf4 nesne yaratýlmadan statik no = " + Sýnýf4.Sýnýf4NesneNo());
            Sýnýf4 s4;
            for (i=1;i<=5;i++) {s4=new Sýnýf4();Console.WriteLine ("Yaratýlan Sýnýf4 nesne statik no = " + Sýnýf4.Sýnýf4NesneNo());}
            Console.WriteLine ("5 adet statik no'lu nesne yaratýldý");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}