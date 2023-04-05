// j2sc#0106b.cs: Sadece aduzaml� ve aduzam+s�n�fl� armalar�n tiplenme fark� �rne�i.

using System;
using A1 = Saya�; //Aduzam armas�
using A2 = DilTemelleri;
using S1 = Saya�.Sayac�m; //Aduzaml� s�n�f armas�
using S2 = DilTemelleri.Arma2;
using S3 = Sayac�m;
namespace Saya� {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace Saya�: {0}", ++saya�);}
    }
}  
namespace DilTemelleri {
    class Arma2 {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace DilTemelleri: {0}", --saya�);}
        static void Main() {
            Console.Write ("Tiplenme s�n�fla yap�ld���ndan, sadece aduzaml� arma tiplenmesinde s�n�f adlar�n�n da kullan�lmas� zorunlu olmas�na ra�men aduzam+s�n�f armal� tiplenmelerin art�k s�n�f adlar�na ihtiya�lar� kalmadan tiplenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new A1.Sayac�m(); //Ayr�ca s�n�f�n tiplemesi gerekli
            var say2 = new A2.Arma2();
            var say3 = new Sayac�m();
            var say4 = new S1(); //Ayr�ca s�n�f�n tiplemesi gereksiz
            var say5 = new S2();
            var say6 = new S3();
            for (int i=0; i < 3; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�(); say4.Saya�(); say5.Saya�(); say6.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
class Sayac�m {// Aduzams�z s�n�f
    private int saya� = 1957;
    public void Saya�() {Console.WriteLine ("aduzams�z: {0}", --saya�);}
}