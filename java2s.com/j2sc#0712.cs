// j2sc#0712.cs: Yarat�lan nesne sonlan�rken otomatik �a�r�lan y�k�c� �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        int i;
        public S�n�f1 (int i) {this.i=i; Console.WriteLine ("{0}.nci Nesne yarat�l�yor...", this.i);} //Kurucu
        ~S�n�f1() {Console.WriteLine ("{0}.nci Nesne imha ediliyor...", this.i);} //Y�k�c�
    }
    class S�n�f2 {
        int x;
        public S�n�f2 (int i) {x = i;} //Kurucu
        ~S�n�f2() {Console.WriteLine ("�mha no: " + x);} //Y�k�c�
    }
    public class S�n�f3 : IDisposable {//Interface aray�z temelli
        int a;
        public S�n�f3 (int i) {a = i;} //Kurucu
        ~S�n�f3() {Console.WriteLine ("{0}.�mhac�da...", a);} //Oyomatik y�k�c�
        public void Dispose() {//�stemli (haz�r) y�k�c�
            Console.WriteLine ("{0}.Dispose()...", a);
            GC.SuppressFinalize (this);
        }
    }
    public class TemelS�n�f {
        public int x;
        //public TemelS�n�f (int x) {this.x = x;}
        ~TemelS�n�f() {Console.WriteLine ("TemelS�n�f y�k�c�s�: {0}", x);}
    }
    public class T�rediS�n�f : TemelS�n�f {
        public T�rediS�n�f (int x) {base.x = x;}
        ~T�rediS�n�f() {Console.WriteLine ("T�rediS�n�f y�k�c�s�: {0}", base.x);}
    }
    public class S�n�f4 {
        private static int no = 0;
        public S�n�f4() {Console.WriteLine ("Yarat�lan S�n�f4 nesne no: {0}", ++no);}
        ~S�n�f4() {Console.WriteLine ("�mha edilen S�n�f4 nesne no: {0}", no--);}
        public static int S�n�f4NesneNo() {return no;}
    }
    class Y�k�c� {
        static void Main() {
            Console.Write ("Y�k�c� bir nesnenin ��p toplay�c� taraf�ndan imhas� e�i�inde otomatikmen �a�r�l�r. IDisposable.Dispose()'la istemli imhalanan nesne-ler art�k otomatik y�k�c�yla da imha edilmez-ler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayn� s�n�ftan 5 nesne yarat�larak program�n sonland�r�lmas�:");
            S�n�f1 s1; int i;
            for (i=1;i<=5;i++) s1=new S�n�f1 (i);
            Console.WriteLine ("Program sonland�r�l�yor...");

            Console.WriteLine ("\nKurulan ve sonu�ta y�k�lacak nesneler:");
            S�n�f2 s2a = new S�n�f2 (0);
            for(i=1;i<=5;i++) {S�n�f2 s2b = new S�n�f2 (i);} //Burda {} blok �art
            Console.WriteLine ("Tamamland�");

            Console.WriteLine ("\n�stemli ve otomatik y�k�c�larla nesne imhas�:");  
            S�n�f3 s3a, s3b, s3c, s3d;
            s3a = new S�n�f3(1); s3b = new S�n�f3(2); s3c = new S�n�f3(3); s3d = new S�n�f3(4);
            Console.WriteLine ("***** s3a ve s3c ��pe at�l�yor *****"); s3a.Dispose(); s3c.Dispose();

            Console.WriteLine ("\nMiraslayan nesne y�k�l�rken ebeveyn y�k�c�y� da �a��r�r:");
            T�rediS�n�f t1;
            for (i=1;i<=5;i++) t1=new T�rediS�n�f (i);
            Console.WriteLine ("5 adet mirasl� nesne yarat�ld�");

            Console.WriteLine ("\nYarat�lan ve y�k�lan nesnenin statik no'su:");
            Console.WriteLine ("S�n�f4 nesne yarat�lmadan statik no = " + S�n�f4.S�n�f4NesneNo());
            S�n�f4 s4;
            for (i=1;i<=5;i++) {s4=new S�n�f4();Console.WriteLine ("Yarat�lan S�n�f4 nesne statik no = " + S�n�f4.S�n�f4NesneNo());}
            Console.WriteLine ("5 adet statik no'lu nesne yarat�ld�");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}