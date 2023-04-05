// j2sc#0103.cs: Tek ve çok satýrlý yorumlar örneði.

using System;
namespace DilTemelleri {
    class Yorumlar {
        public static void Main() {
            Console.Write ("Tek satýrlýk yorum // ile baþlar ve sonrasý yoruma aittir. Çok satýrlý yorum /*...*/ içindedir; çok satýrlý olduðu gibi tek satýrda ve kodlama arasýnda da bulunabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            //Bu satýr artýk yoruma aittir, sonrasýna kodlama girilemez...
            /* Çoklu yorumun 1.satýrý
               Çoklu yorumun 2.satýrý
               Çoklu yorumun 3.ve son satýrý; sonrasýna kodlama girilebilir */ Console.WriteLine ("Basit bir C# programýndan herkese MERHABALAR!");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}