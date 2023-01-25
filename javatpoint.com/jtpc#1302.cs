// jtpc#1302.cs: TryCath sonunda herdaim �al��t�r�lan finally �rne�i.

using System;
namespace �stisnaY�netimi {
    class Finally {
        static void Main() {
            Console.Write ("�stisna y�netiminde kullan�m� tercihi olan finally blo�u, istisna f�rlas�n/f�rlamas�n, daima i�letilir. �oklu catch kullan�labilir. Exception genel olup, t�m f�rlat�lacak hatalar� yakalar; di�erleriyse sadece kendi �zel istisnalar�na duyarl�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int a = 10;
                int b = 0;
                Console.Write ("a/b={0}/{1}=", a, b);
                Console.Write (a/b);
            }catch (NullReferenceException hata) {Console.WriteLine ("HATA-1: [{0}]", hata); //Hata yakalamaz
            }catch (DivideByZeroException hata) {Console.WriteLine ("HATA-2: [{0}]", hata); //Hata yakalar
            }finally {Console.WriteLine("Finally blo�u i�letilmekte");}
            Console.WriteLine ("\nNormal program ak���na devam"); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}