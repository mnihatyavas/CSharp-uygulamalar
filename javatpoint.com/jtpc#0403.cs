// jtpc#0403.cs: "ref"le fonksiyon çaðrýsýnda orijinal deðerin de deðiþirliði örneði.

using System;
namespace Fonksiyonlar {
    class RefÇaðrý {
        public void Göster (ref int n2) {
            n2 *=n2;
            Console.WriteLine ("Fonksiyon içindeki iþlenen deðer: {0}", n2);
        }
        static void Main () {
            Console.Write ("Argümanla çaðýran ve parametreyle alan fonksiyon deðerleri önündeki 'ref' anahtarkelimesiyle, ayný bellek adresini gördüklerinden, fonksiyondaki deðiþiklik aynen orijinal deðiþkene de yansýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n1 = 50;
            Console.WriteLine ("Fonksiyonu çaðýrmadan önceki deðiþken deðeri: {0}", n1);
            new RefÇaðrý().Göster (ref n1);
            Console.WriteLine ("Fonksiyonu çaðýrdýktan sonraki orijinal deðiþken deðeri: {0}", n1);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}