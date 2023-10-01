// j2sc#0707.cs: Tipli metotlar�n say�sal, dizgesel, nesnel ve dizisel gerid�n��leri �rne�i.

using System;
namespace S�n�flar {
    class Dikd�rtgen {
        int en; //Varsay�l� private
        int boy;
        public Dikd�rtgen (int e, int b) {en = e; boy = b;} //�ift paramtreli kurucu
        public int alan() {return en * boy;}
        public void g�ster() {Console.WriteLine ("(" + en + ", " + boy + ")");}
        public Dikd�rtgen b�y�t (int kat) {return new Dikd�rtgen (en * kat, boy * kat);}
        public Dikd�rtgen k���lt (int kat) {return new Dikd�rtgen (en / kat, boy / kat);}
    }
    class S�n�f1 {
        int a, b; //private 
        public S�n�f1 ilkNesne (int i, int j) {
            S�n�f1 n2 = new S�n�f1(); //2.nesne
            n2.a = i;
            n2.b = j;
            return n2; //nesne gerid�n���
        }
        public void g�ster() {Console.WriteLine ("({0}, {1}) = (+ - * / %): ({2}, {3}, {4}, {5:0.##}, {6})", a, b, a+b, a-b, a*b, 1F*a/b, a>b?a%b:b%a);}
    }
    class OrtakB�lenler {
        public int[] b�lenleriBul (int n, out int b�lenAdet) {
            int[] b�lenler = new int [100]; //Fazla fazla dizi ebat�
            int i, j;
            for (i=2, j=0; i < n/2 + 1; i++) if ((n%i)==0) {b�lenler [j] = i; j++;}
            b�lenAdet = j;
            return b�lenler;
        }
    }
    class MetotGerid�n��� {
        public static DateTime TarihAl() {return DateTime.Now;}
        static void Main() {
            Console.Write ("Metot return tipi metodunkiyle ayn� olmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("TarihAl() metot ve gerid�nen tipi DateTime'd�r:");
            Console.WriteLine ("G�ncel terih ve zaman: [{0}]", TarihAl());

            Console.WriteLine ("\nDikd�rtgen alan hesab�, katlamal� b�y�tme/k���ltme:");
            var r=new Random(); int ts1, ts2, i, j;
            ts1=r.Next (1, 100); ts2=r.Next (1, 100); Dikd�rtgen dd1 = new Dikd�rtgen (ts1, ts2);
            Console.Write ("\tDikd�rtgenin (en, boy) = "); dd1.g�ster();
            Console.WriteLine ("1.Dikd�rtgenin alan� = " + dd1.alan());
            Console.WriteLine ("Orijinal alan� 4 kat b�y�t = " + dd1.b�y�t (4).alan() );
            Console.WriteLine ("Orijinal alan� 2 kat k���lt = " + dd1.k���lt (2).alan() );
            Dikd�rtgen dd2 = dd1.b�y�t (3); //�ncekinden 3 kat b�y�k yeni dikd�rtgen
            Console.Write ("\tDikd�rtgenin (en, boy) = "); dd2.g�ster();
            Console.WriteLine ("1.Dikd�rtgenin alan� = " + dd2.alan());
            Console.WriteLine ("Orijinal alan� 2 kat b�y�t = " + dd2.b�y�t (2).alan() );
            Console.WriteLine ("Orijinal alan� 3 kat k���lt = " + dd2.k���lt (3).alan() );

            Console.WriteLine ("\n(1,9)-->(9,1) birer ilerleyen topla, ��kar, �arp, b�l, kalan hesaplar�:");
            S�n�f1 n1 = new S�n�f1();
            for (i=1, j=9; i < 10; i++, j--) {
                S�n�f1 n2 = n1.ilkNesne (i, j); //Nesne gerid�n���
                n2.g�ster();
            }

            Console.WriteLine ("\n5 adet rasgele tamsay�n�n b�lenleri:");
            OrtakB�lenler b = new OrtakB�lenler();
            int b�lenAdet; int [] b�lenler;
            for (i=0; i < 5; i++) {
                ts1=r.Next (1000, 10000);
                b�lenler = b.b�lenleriBul (ts1, out b�lenAdet);
                Console.Write ("{0}'in b�lenleri: ", ts1);
                for (j=0; j < b�lenAdet; j++) Console.Write (b�lenler [j] + " ");
                Console.WriteLine ();
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}