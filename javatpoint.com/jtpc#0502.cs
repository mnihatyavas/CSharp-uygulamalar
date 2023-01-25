// jtpc#0502.cs: Diziyi fonksiyonlara gönderip dökümleme ve en-küçük/büyük elemanýný bulma örneði.

using System;
namespace Diziler {
    class DizidenFonksiyona {
        static void diziyiDökümle (int[] d) {
            Console.WriteLine ("Dizi elemanlarý dökümleniyor:");
            for (int i = 0; i < d.Length; i++) Console.WriteLine (d [i]);  
        }
        static void enküçüðüBul (int[] d) {
            int enküçük = d [0], endeks = 0;  
            for (int i = 1; i < d.Length; i++) {if (enküçük > d [i]) {enküçük = d [i]; endeks = i;} }  
            Console.WriteLine ("Dizinin enküçük elemaný ve endeksi =  [{0}, {1}]", enküçük, endeks);
        }
        static void enbüyüðüBul (int[] d) {
            int enbüyük = d [0], endeks = 0;  
            for (int i = 1; i < d.Length; i++) {if (enbüyük < d [i]) {enbüyük = d [i]; endeks = i;} }  
            Console.WriteLine ("Dizinin enbüyük elemaný ve endeksi =  [{0}, {1}]", enbüyük, endeks);
        }
        static void Main() {
            Console.Write ("Fonksiyona dizi geçirirken argüman olarak yalýn diziadý kullanýlmalýdýr. Statik fonksiyon sýnýfýyla tiplenmeden doðrudan çaðrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random r = new Random();
            int[] dizi1 = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2 = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            diziyiDökümle (dizi1); enküçüðüBul (dizi1); enbüyüðüBul (dizi1);
            Console.WriteLine(); diziyiDökümle (dizi2); enküçüðüBul (dizi2); enbüyüðüBul (dizi2);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}