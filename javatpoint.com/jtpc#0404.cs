// jtpc#0404.cs: "out" ilkdeðersiz argümaný onaylarken "ref"in hata vermesi örneði.

using System;
namespace Fonksiyonlar {
    class OutÇaðrý {
        public void Göster1 (ref int n) {n=5; n *=n;}
        public void Göster2 (out int n) {n=10; n *=n;}
        public void Göster3 (out int n1, out int n2, out int n3, out int n4, out int n5) {
            Random r = new Random();
            n1=r.Next (1, 100); n2=r.Next (1, 100); n3=r.Next (1, 100); n4=r.Next (1, 100); n5=r.Next (1, 100); 
        }
        static void Main () {
            Console.Write ("'out' anahtarkelimesi de 'ref' gibidir, ancak ref deðer atanmamýþ argümaný kabul etmezken out kabul eder. Ayrýca out bir bakýma fonksiyondan return'süz çoklu geridönüþler için kullanýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n1;
            //new OutÇaðrý().Göster1 (ref n1); // Deðer atanmamýþ ref-n1 hata verir
            //Console.WriteLine ("ref'li fonksiyonu çaðýrdýktan sonraki orijinal deðiþken deðeri: {0}", n1);

            new OutÇaðrý().Göster2 (out n1);
            Console.WriteLine ("out'lu fonksiyonu çaðýrdýktan sonraki orijinal deðiþken deðeri: {0}", n1);

            new OutÇaðrý().Göster1 (ref n1); // Artýk deðer içerdiðinden ref-n1 hata vermez
            Console.WriteLine ("ref'li fonksiyonu çaðýrdýktan sonraki orijinal deðiþken deðeri: {0}", n1);

            int r1, r2, r3, r4, r5;
            new OutÇaðrý().Göster3 (out r1, out r2, out r3, out r4, out r5);
            Console.WriteLine ("out ile fonksiyonda yaratýlan 5 rasgele [0,99] sayý: [{0}, {1}, {2}, {3}, {4}]", r1, r2, r3, r4, r5);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}