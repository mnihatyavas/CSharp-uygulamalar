// j2sc#0105g.cs: Aduzamlarý armalarý tiplemesinde :: sembolü örneði.

using System;
using Sayaç1;
using Sayaç2;
using S1 = Sayaç1;
using S2 = Sayaç2;
namespace Sayaç1 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç1: {0}", --sayaç);}
    }
}
namespace Sayaç2 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç2: {0}", ++sayaç);}
    }
}
namespace Sayaç3 {
    class Sayacým {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("Sayaç3: {0}", ++sayaç);}
    }
}
namespace DilTemelleri {
    class Aduzam7 {
        static void Main() {
            Console.Write ("Aduzamlarý çok uzunsa ve de program içinde çok sýk kullanýlýyorsa daha kýsa ve pratik bir arma/alias adý kullanýlabilir. Ancak armalý tiplemenin '.' yanýsýra '::' sembolle de yapýlabileceði bilinmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new S1::Sayacým();
            var say2 = new S2.Sayacým();
            var say3 = new Sayaç3.Sayacým();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}