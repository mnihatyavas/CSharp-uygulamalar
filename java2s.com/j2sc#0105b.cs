// j2sc#0105b.cs: Aduzam içi sýnýf üyelerine tiplemeyle eriþim örneði.

using System;
namespace DilTemelleri {
    class Sayacým {
        private int sayaç = 0;
        public void Sayaç() {Console.WriteLine ("Sayaç: {0}", ++sayaç);}
    }
    class Aduzam2 {
        static void Main() {
            Console.Write ("Bir aduzam içinde (statik olmayan) çoklu sýnýf tanýmlarý mevcutsa, sýnýf ve üyeleri 'new' anahtarkelimeli tiplenerek kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say = new DilTemelleri.Sayacým();
            for (int i=0; i < 5; i++) {say.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}