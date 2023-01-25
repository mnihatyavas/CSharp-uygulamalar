// jtpc#0402.cs: Deðerle fonksiyon çaðrýsýnda orijinal deðerin deðiþmezliði örneði.

using System;
namespace Fonksiyonlar {
    class DeðerleÇaðrý {
        public void Göster (int n) {
            n *=n;
            Console.WriteLine ("Fonksiyon içindeki iþlenen deðer: {0}", n);
        }
        static void Main () {
            Console.Write ("Deðerle çaðrýda, fonksiyona parametreli gönderilen deðiþkenin kopya içeriði, fonksiyon içinde deðiþse dahi, deðiþiklik çaðýran programdaki orijinal deðiþkenin deðerini deðiþtirmez.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n = 50;
            Console.WriteLine ("Fonksiyonu çaðýrmadan önceki deðiþken deðeri: {0}", n);
            new DeðerleÇaðrý().Göster (n);
            Console.WriteLine ("Fonksiyonu çaðýrdýktan sonraki orijinal deðiþken deðeri: {0}", n);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}