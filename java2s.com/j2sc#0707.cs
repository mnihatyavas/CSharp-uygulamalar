// j2sc#0707.cs: Tipli metotlarýn sayýsal, dizgesel, nesnel ve dizisel geridönüþleri örneði.

using System;
namespace Sýnýflar {
    class Dikdörtgen {
        int en; //Varsayýlý private
        int boy;
        public Dikdörtgen (int e, int b) {en = e; boy = b;} //Çift paramtreli kurucu
        public int alan() {return en * boy;}
        public void göster() {Console.WriteLine ("(" + en + ", " + boy + ")");}
        public Dikdörtgen büyüt (int kat) {return new Dikdörtgen (en * kat, boy * kat);}
        public Dikdörtgen küçült (int kat) {return new Dikdörtgen (en / kat, boy / kat);}
    }
    class Sýnýf1 {
        int a, b; //private 
        public Sýnýf1 ilkNesne (int i, int j) {
            Sýnýf1 n2 = new Sýnýf1(); //2.nesne
            n2.a = i;
            n2.b = j;
            return n2; //nesne geridönüþü
        }
        public void göster() {Console.WriteLine ("({0}, {1}) = (+ - * / %): ({2}, {3}, {4}, {5:0.##}, {6})", a, b, a+b, a-b, a*b, 1F*a/b, a>b?a%b:b%a);}
    }
    class OrtakBölenler {
        public int[] bölenleriBul (int n, out int bölenAdet) {
            int[] bölenler = new int [100]; //Fazla fazla dizi ebatý
            int i, j;
            for (i=2, j=0; i < n/2 + 1; i++) if ((n%i)==0) {bölenler [j] = i; j++;}
            bölenAdet = j;
            return bölenler;
        }
    }
    class MetotGeridönüþü {
        public static DateTime TarihAl() {return DateTime.Now;}
        static void Main() {
            Console.Write ("Metot return tipi metodunkiyle ayný olmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("TarihAl() metot ve geridönen tipi DateTime'dýr:");
            Console.WriteLine ("Güncel terih ve zaman: [{0}]", TarihAl());

            Console.WriteLine ("\nDikdörtgen alan hesabý, katlamalý büyütme/küçültme:");
            var r=new Random(); int ts1, ts2, i, j;
            ts1=r.Next (1, 100); ts2=r.Next (1, 100); Dikdörtgen dd1 = new Dikdörtgen (ts1, ts2);
            Console.Write ("\tDikdörtgenin (en, boy) = "); dd1.göster();
            Console.WriteLine ("1.Dikdörtgenin alaný = " + dd1.alan());
            Console.WriteLine ("Orijinal alaný 4 kat büyüt = " + dd1.büyüt (4).alan() );
            Console.WriteLine ("Orijinal alaný 2 kat küçült = " + dd1.küçült (2).alan() );
            Dikdörtgen dd2 = dd1.büyüt (3); //Öncekinden 3 kat büyük yeni dikdörtgen
            Console.Write ("\tDikdörtgenin (en, boy) = "); dd2.göster();
            Console.WriteLine ("1.Dikdörtgenin alaný = " + dd2.alan());
            Console.WriteLine ("Orijinal alaný 2 kat büyüt = " + dd2.büyüt (2).alan() );
            Console.WriteLine ("Orijinal alaný 3 kat küçült = " + dd2.küçült (3).alan() );

            Console.WriteLine ("\n(1,9)-->(9,1) birer ilerleyen topla, çýkar, çarp, böl, kalan hesaplarý:");
            Sýnýf1 n1 = new Sýnýf1();
            for (i=1, j=9; i < 10; i++, j--) {
                Sýnýf1 n2 = n1.ilkNesne (i, j); //Nesne geridönüþü
                n2.göster();
            }

            Console.WriteLine ("\n5 adet rasgele tamsayýnýn bölenleri:");
            OrtakBölenler b = new OrtakBölenler();
            int bölenAdet; int [] bölenler;
            for (i=0; i < 5; i++) {
                ts1=r.Next (1000, 10000);
                bölenler = b.bölenleriBul (ts1, out bölenAdet);
                Console.Write ("{0}'in bölenleri: ", ts1);
                for (j=0; j < bölenAdet; j++) Console.Write (bölenler [j] + " ");
                Console.WriteLine ();
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}