// j2sc#0605c.cs: *&adresli yapýlarýn unsafe/güvenilmez kodlamalarý örneði.

using System;
namespace Yapýlar {
    public struct Düðüm {
        public int X;
        public unsafe Düðüm* Sol;
        public unsafe Düðüm* Sað;
    }
    struct Nokta3B {
        public int x;
        public int y;
        public int z;
        public override string ToString() {return string.Format ("Nokta3B (x, y, z) = ({0}, {1}, {2})", x, y, z);}
    }
    class YapýAlanlarý3 {
        static void Main() {
            Console.Write ("* ve & ile tanýmlý adresli göstergeçlere eriþim ya 'g->x' yada '(*g).x' ile ve unsafe/güvensiz blokta yapýlmalý, ayrýca /unsafe parametreli derlenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yapý'da Nokta3B(x,y,z) veriöerine normal ve gösterge'li eriþim:");
            Random r=new Random(); int i;
            Console.WriteLine ("\t==>Gösterge verilere normal eriþim.");
            Nokta3B nokta = new Nokta3B();
            for (i=0; i<3; i++) {nokta.x = r.Next (0, 1000); nokta.y = r.Next (0, 1000); nokta.z = r.Next (0, 1000); Console.WriteLine (nokta.ToString());}
            Console.WriteLine ("\t==>Gösterge verilere noktalý(.) eriþim.");
            unsafe {
                Nokta3B n1;
                Nokta3B* g1 = &n1;
                for (i=0; i<3; i++) {(*g1).x = r.Next (0, 1000); (*g1).y = r.Next (0, 1000); (*g1).z = r.Next (0, 1000); Console.WriteLine ((*g1).ToString());}
            } Console.WriteLine ("\t==>Gösterge verilere oklu(->) eriþim.");
            unsafe {
                Nokta3B n1;
                Nokta3B* g1 = &n1;
                for (i=0; i<3; i++) {g1->x = r.Next (0, 1000); g1->y = r.Next (0, 1000); g1->z = r.Next (0, 1000); Console.WriteLine (g1->ToString());}
            }

            Console.WriteLine ("\nDüðüm'ün normal ve gösterge alanlarýna atama ve eriþim:");
            Console.WriteLine ("\t==>'Düðüm int X' alanýna normal eriþim.");
            Düðüm d1 = new Düðüm();
            for (i=0; i<3; i++) {d1.X = r.Next (0, 1000); Console.WriteLine ("Normal d1.X = {0}", d1.X);}
            Console.WriteLine ("\t==>'Düðüm int X' alanýna göstergeli eriþim.");
            unsafe {Düðüm* d1x = &d1; for (i=0; i<3; i++) {(*d1x).X = r.Next (0, 1000); Console.WriteLine ("Gösterge d1x->X = {0}", d1x->X.ToString());}}
            Console.WriteLine ("\t==>'Düðüm Düðüm* Y' alanýna eriþim.");
            unsafe {
                try {Düðüm* d1x=&d1; d1x->Sol->X=r.Next (0, 1000); d1x->Sað->X=r.Next (0, 1000);
                    Console.WriteLine ("Gösterge d1x->Sol->X = {0}", d1x->Sol->X.ToString());
                    Console.WriteLine ("Gösterge d1x->Sað->X = {0}", d1x->Sað->X.ToString());
                }catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h);}
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}