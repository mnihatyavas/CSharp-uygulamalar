// j2sc#0103.cs: Tek ve �ok sat�rl� yorumlar �rne�i.

using System;
namespace DilTemelleri {
    class Yorumlar {
        public static void Main() {
            Console.Write ("Tek sat�rl�k yorum // ile ba�lar ve sonras� yoruma aittir. �ok sat�rl� yorum /*...*/ i�indedir; �ok sat�rl� oldu�u gibi tek sat�rda ve kodlama aras�nda da bulunabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            //Bu sat�r art�k yoruma aittir, sonras�na kodlama girilemez...
            /* �oklu yorumun 1.sat�r�
               �oklu yorumun 2.sat�r�
               �oklu yorumun 3.ve son sat�r�; sonras�na kodlama girilebilir */ Console.WriteLine ("Basit bir C# program�ndan herkese MERHABALAR!");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}