// j2sc#0605c.cs: *&adresli yap�lar�n unsafe/g�venilmez kodlamalar� �rne�i.

using System;
namespace Yap�lar {
    public struct D���m {
        public int X;
        public unsafe D���m* Sol;
        public unsafe D���m* Sa�;
    }
    struct Nokta3B {
        public int x;
        public int y;
        public int z;
        public override string ToString() {return string.Format ("Nokta3B (x, y, z) = ({0}, {1}, {2})", x, y, z);}
    }
    class Yap�Alanlar�3 {
        static void Main() {
            Console.Write ("* ve & ile tan�ml� adresli g�sterge�lere eri�im ya 'g->x' yada '(*g).x' ile ve unsafe/g�vensiz blokta yap�lmal�, ayr�ca /unsafe parametreli derlenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yap�'da Nokta3B(x,y,z) veri�erine normal ve g�sterge'li eri�im:");
            Random r=new Random(); int i;
            Console.WriteLine ("\t==>G�sterge verilere normal eri�im.");
            Nokta3B nokta = new Nokta3B();
            for (i=0; i<3; i++) {nokta.x = r.Next (0, 1000); nokta.y = r.Next (0, 1000); nokta.z = r.Next (0, 1000); Console.WriteLine (nokta.ToString());}
            Console.WriteLine ("\t==>G�sterge verilere noktal�(.) eri�im.");
            unsafe {
                Nokta3B n1;
                Nokta3B* g1 = &n1;
                for (i=0; i<3; i++) {(*g1).x = r.Next (0, 1000); (*g1).y = r.Next (0, 1000); (*g1).z = r.Next (0, 1000); Console.WriteLine ((*g1).ToString());}
            } Console.WriteLine ("\t==>G�sterge verilere oklu(->) eri�im.");
            unsafe {
                Nokta3B n1;
                Nokta3B* g1 = &n1;
                for (i=0; i<3; i++) {g1->x = r.Next (0, 1000); g1->y = r.Next (0, 1000); g1->z = r.Next (0, 1000); Console.WriteLine (g1->ToString());}
            }

            Console.WriteLine ("\nD���m'�n normal ve g�sterge alanlar�na atama ve eri�im:");
            Console.WriteLine ("\t==>'D���m int X' alan�na normal eri�im.");
            D���m d1 = new D���m();
            for (i=0; i<3; i++) {d1.X = r.Next (0, 1000); Console.WriteLine ("Normal d1.X = {0}", d1.X);}
            Console.WriteLine ("\t==>'D���m int X' alan�na g�stergeli eri�im.");
            unsafe {D���m* d1x = &d1; for (i=0; i<3; i++) {(*d1x).X = r.Next (0, 1000); Console.WriteLine ("G�sterge d1x->X = {0}", d1x->X.ToString());}}
            Console.WriteLine ("\t==>'D���m D���m* Y' alan�na eri�im.");
            unsafe {
                try {D���m* d1x=&d1; d1x->Sol->X=r.Next (0, 1000); d1x->Sa�->X=r.Next (0, 1000);
                    Console.WriteLine ("G�sterge d1x->Sol->X = {0}", d1x->Sol->X.ToString());
                    Console.WriteLine ("G�sterge d1x->Sa�->X = {0}", d1x->Sa�->X.ToString());
                }catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}