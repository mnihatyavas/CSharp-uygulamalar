// j2sc#0106b.cs: Sadece aduzamlý ve aduzam+sýnýflý armalarýn tiplenme farký örneði.

using System;
using A1 = Sayaç; //Aduzam armasý
using A2 = DilTemelleri;
using S1 = Sayaç.Sayacým; //Aduzamlý sýnýf armasý
using S2 = DilTemelleri.Arma2;
using S3 = Sayacým;
namespace Sayaç {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace Sayaç: {0}", ++sayaç);}
    }
}  
namespace DilTemelleri {
    class Arma2 {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace DilTemelleri: {0}", --sayaç);}
        static void Main() {
            Console.Write ("Tiplenme sýnýfla yapýldýðýndan, sadece aduzamlý arma tiplenmesinde sýnýf adlarýnýn da kullanýlmasý zorunlu olmasýna raðmen aduzam+sýnýf armalý tiplenmelerin artýk sýnýf adlarýna ihtiyaçlarý kalmadan tiplenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new A1.Sayacým(); //Ayrýca sýnýfýn tiplemesi gerekli
            var say2 = new A2.Arma2();
            var say3 = new Sayacým();
            var say4 = new S1(); //Ayrýca sýnýfýn tiplemesi gereksiz
            var say5 = new S2();
            var say6 = new S3();
            for (int i=0; i < 3; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç(); say4.Sayaç(); say5.Sayaç(); say6.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
class Sayacým {// Aduzamsýz sýnýf
    private int sayaç = 1957;
    public void Sayaç() {Console.WriteLine ("aduzamsýz: {0}", --sayaç);}
}