// jtpc#0606.cs: 'static' s�n�f�n sadece statik �yeleri ve tiplemesiz i�letilebilmesi �rne�i.

using System;
namespace NesneS�n�f� {
    public static class �zelMath {
        //public int ts = 2023; //Derleme hatas�
        public static double PI=3.141592653589793d;
        public static double E=2.718281828459045d;
        public static int k�p (int n) {return n*n*n;}
        public static double karek�k (double n) {return Math.Sqrt (n);}
    }
    class StatikS�n�f {
        static void Main() {
            Console.Write ("'static' s�n�f i�inde sadece statik �ye tan�mlanabilir ve tiplenemez (derleme hatas�).\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            //Console.WriteLine (new �zelMath().k�p (3)); //Derleme hatas�
            Console.WriteLine ("�ember �evresi/�ap�: Pi = [{0}]", �zelMath.PI);
            Console.WriteLine ("Do�al logaritmik taban E = [{0}]", �zelMath.E);
            Console.WriteLine ("2'nin k�p�= [{0}]", �zelMath.k�p (2));
            Console.WriteLine ("2'nin karek�k�= [{0}]", �zelMath.karek�k (2d));

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}