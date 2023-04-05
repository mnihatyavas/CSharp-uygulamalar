// j2sc#0113.cs: Sýnýf nesnesi deðiþkenlerine metod parametresiyle deðer aktarma örneði.

using System;
namespace DilTemelleri {
    class SýnýfA {
        private int a, b;
        public SýnýfA (int i, int j) {a = i; b = j;}
        public bool aynýMý (SýnýfA nesne) {
            if ((nesne.a == this.a) & (nesne.b == this.b)) return true;
            else return false;
        }
        public void kopyala (SýnýfA nesne) {this.a = nesne.a; this.b  = nesne.b;}
        public void göster() {Console.WriteLine ("a: {0}, b: {1}", this.a, this.b);}
    }
    class SýnýfB {
        public int a, b;
        public SýnýfB (int i, int j) {a = i; b = j;}
        public void deðiþtir (SýnýfB nesne) {nesne.a = nesne.a - nesne.b; nesne.b = 2023 - nesne.b;}
    }
    class SýnýfC {
        public void daire (ref double yç, ref double çv, ref double al, ref double kal, ref double khc) {
            double pi=Math.PI; çv=2*pi*yç; al=pi*yç*yç; kal=4*al; khc=4/3*pi*yç*yç*yç; yç=0;
        }
    }
    class ParametreReferansý {
        static void Metod (ref string d) {d = "Haným Yavaþ";}
        static void Main() {
            Console.Write ("Sýnýf tiplemeli nesne üyesi deðiþkenlerine çeþitli metod parametresi yöntemiyle deðer aktarýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new SýnýfA (2023, 1951);
            var nesne2 = new SýnýfA (1938, 1881);
            Console.Write ("nesne1: "); nesne1.göster();
            Console.Write ("nesne2: "); nesne2.göster();
            if (nesne1.aynýMý(nesne2)) Console.WriteLine ("==>nesne1 ve nesne2'nin deðerleri AYNIDIR.");
            else Console.WriteLine ("==>nesne1 ve nesne2'nin deðerleri FARKLIDIR.");
            nesne1.kopyala (nesne2);
            Console.Write ("\nnesne2 nesne1'e kopyalandýktan sonra: "); nesne1.göster();
            if (nesne1.aynýMý(nesne2)) Console.WriteLine ("==>nesne1 ve nesne2'nin deðerleri AYNIDIR.");
            else Console.WriteLine ("==>nesne1 ve nesne2'nin deðerleri FARKLIDIR.");

            var nesne3 = new SýnýfB (1938, 1881);
            Console.WriteLine ("\nÇaðrýlmadan ÖNCE nesne3.a ve nesne3.b: " + nesne3.a + " " + nesne3.b);
            nesne3.deðiþtir (nesne3);
            Console.WriteLine ("Çaðrýldýktan SONRA nesne3.a ve nesne3.b: " + nesne3.a + " " + nesne3.b);

            var nesne4 = new SýnýfC();
            var r=new Random(); double yarýçap=r.Next (0, 1000000) / 100000d, çevre=0, alan=0, küreAlan=0, küreHacim=0;
            Console.WriteLine ("\nÇaðrýlmadan ÖNCE (yarýçap, çevre, daireAlan, küreAlan, küreHacim)\n = ({0:0.0###}, {1:0.0###}, {2:0.0###}, {3:0.0###}, {4:0.0###})", yarýçap, çevre, alan, küreAlan, küreHacim);
            nesne4.daire (ref yarýçap, ref çevre, ref alan, ref küreAlan, ref küreHacim);
            Console.WriteLine ("Çaðrýldýktan SONRA (yarýçap, çevre, daireAlan, küreAlan, küreHacim)\n = ({0:0.0###}, {1:0.0###}, {2:0.0###}, {3:0.0###}, {4:0.0###})", yarýçap, çevre, alan, küreAlan, küreHacim);

            string ad = "Haným Emanet";
            Console.WriteLine ("\nEvlenmeden ÖNCE isim: " + ad);
            Metod (ref ad);
            Console.WriteLine ("Evlendikten SONRA isim: " + ad);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}